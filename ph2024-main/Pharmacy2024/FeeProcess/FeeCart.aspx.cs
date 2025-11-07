using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.FeeProcess
{
    public partial class FeeCart : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        ShowMessage ShowMsg;
        private bool _refreshState, _isRefresh;
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request.Cookies["Theme"] == null)
            {
                Page.Theme = "default";
            }
            else
            {
                Page.Theme = Request.Cookies["Theme"].Value;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["FeeGroupId"] == null || Session["FeeGroupId"].ToString().Trim() == "" || Convert.ToInt64(Session["FeeGroupId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["PhaseId"] == null || Session["PhaseId"].ToString().Trim() == "" || Convert.ToInt64(Session["PhaseId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["PayeeUserTypeId"] == null || Session["PayeeUserTypeId"].ToString().Trim() == "" || Convert.ToInt64(Session["PayeeUserTypeId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["PayeeId"] == null || Session["PayeeId"].ToString().Trim() == "" || Convert.ToInt64(Session["PayeeId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMsg = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {

                if (Convert.ToInt32(Session["UserTypeID"]) == 91 && !reg.isApplicationFormConfirmed(Convert.ToInt64(Session["UserID"])))
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];

                    if (objSessionData.ApplicationFormStatus != 'A' && objSessionData.StepID >= 8)
                    {
                        string _leftMenu = ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"];
                        ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormLinks = true;
                        ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormNumber = false;
                        ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFadingEffect = true; ((ExpanderMenu)Master.FindControl(_leftMenu)).FormType = 1;
                        ((ExpanderMenu)Master.FindControl(_leftMenu)).FormNumber = Convert.ToInt64(Session["UserID"]);
                    }
                }

                Session["CartID"] = null;

                BindGrid(Convert.ToInt32(Session["FeeGroupId"]), Convert.ToInt32(Session["PhaseId"]), Convert.ToInt32(Session["PayeeUserTypeId"]), Convert.ToInt64(Session["PayeeId"]), Session["UserLoginID"].ToString());
            }
        }
        protected void BindGrid(Int32 FeeGroupId, Int32 PhaseId, Int32 PayeeUserTypeId, Int64 PayeeId, string UserLoginId)
        {
            DataSet ds = null;
            EGrassery_FeeCalculationNewDB cls = null;
            try
            {
                cls = new EGrassery_FeeCalculationNewDB();
                ds = cls.GetAllAppliedPostGroupDetails(FeeGroupId, PhaseId, PayeeUserTypeId, PayeeId, UserLoginId);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblTotalFee.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                        ViewState["CartID"] = ds.Tables[0].Rows[0]["CartId"].ToString();

                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["CartId"]) > 0)
                        {
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["PaymentInitiated"]))
                            {
                                btnPayment.Visible = false;
                                ShowMsg.SetMessage("As your payment has been initiated, you cannot make payment.<br/>If you want to reattempt payment, please go to \"Payment Hsitory\" to cancel this cart payment, and retry the payment again.", ShowMessageType.Information);
                            }
                            else
                            {
                                btnPayment.Visible = true;
                            }
                        }
                        //else
                        //{
                        //    ShowMsg.SetMessage("Application Fee Is Already Paid.", ShowMessageType.Information);
                        //}
                    }
                    else
                    {
                        tblPayment.Style.Value = "display:none";
                        trPostGroup.Style.Value = "display:none";
                    }

                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        grdFee.DataSource = ds.Tables[1];
                        grdFee.DataBind();
                        tblPayment.Style.Value = "display";
                        trPostGroup.Style.Value = "display:";
                    }
                    else
                    {
                        tblPayment.Style.Value = "display:none";
                        trPostGroup.Style.Value = "display:none";
                        ContentCart.Visible = false;
                    }
                }
                else
                {
                    tblPayment.Style.Value = "display:none";
                    trPostGroup.Style.Value = "display:none";
                    ShowMsg.SendMessage("No Course Details Found for payment. Please Apply for Course before calculation of fee.", ShowMessageType.Information);
                }
            }
            catch (System.Threading.ThreadAbortException thx)
            {
            }
            catch (Exception ex)
            {
                ShowMsg.SendMessage(ex.Message, ShowMessageType.TechnicalError);
                LogWriterService.WriteErrorLog(ex.Message, "BindGrid method of FeeCart page");

            }
            finally
            {
                ds = null;
                cls = null;
            }
        }
        private class VPCStringComparer : IComparer
        {
            public int Compare(Object a, Object b)
            {
                if (a == b) return 0;
                if (a == null) return -1;
                if (b == null) return 1;

                string sa = a as string;
                string sb = b as string;

                System.Globalization.CompareInfo myComparer = System.Globalization.CompareInfo.GetCompareInfo("en-US");
                if (sa != null && sb != null)
                {
                    return myComparer.Compare(sa, sb, System.Globalization.CompareOptions.Ordinal);
                }
                throw new ArgumentException("a and b should be strings.");
            }
        }
        private string CreateMD5Signature(string RawData)
        {
            System.Security.Cryptography.MD5 hasher = System.Security.Cryptography.MD5CryptoServiceProvider.Create();
            byte[] HashValue = hasher.ComputeHash(Encoding.ASCII.GetBytes(RawData));

            string strHex = "";
            foreach (byte b in HashValue)
            {
                strHex += b.ToString("x2");
            }
            return strHex.ToUpper();
        }
        protected void grdVwTransactions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ImageButton lbtn = (ImageButton)e.Row.FindControl("btnLink");
                dt = (DataTable)ViewState["Data"];

                lbtn.OnClientClick = "window.open('" + dt.Rows[e.Row.RowIndex]["PrintPage"].ToString() + "');return false;";
            }
        }
        protected void btnPayment_Click(object sender, EventArgs e)
        {
            if (_isRefresh == _refreshState)
            {

                decimal totalFee = 0;
                decimal givenpostFee = 0;
                int postGroupId = 0;
                CheckBox chk = null;
                LiteralControl ltPostId = null;
                EGrassery_FeeCalculationNewDB cls = null;
                DataSet ds = null;
                int initialGroup = 0;
                int nextGroup = 0;

                bool flag = false;
                System.Text.StringBuilder sb = null;
                try
                {
                    sb = new System.Text.StringBuilder();
                    sb.Append("<Root>");
                    foreach (GridViewRow gr in grdFee.Rows)
                    {
                        if ((gr.RowType != DataControlRowType.Header) && (gr.RowType != DataControlRowType.Footer))
                        {
                            chk = new CheckBox();

                            chk = (CheckBox)gr.Cells[0].FindControl("chkPostGroup");
                            if (chk.Checked)
                            {
                                nextGroup = 0;
                                nextGroup = Convert.ToInt32(gr.Cells[5].Text.Trim());

                                if (initialGroup == 0 && nextGroup > 0)
                                {
                                    initialGroup = nextGroup;
                                }

                                if (initialGroup > 0 && nextGroup > 0)
                                {
                                    if (initialGroup != nextGroup)
                                    {
                                        ShowMsg.SetMessage("You can select only same payment Group items for payment proceeding.", ShowMessageType.Information);
                                        return;
                                    }
                                }

                                flag = true;
                                givenpostFee = Convert.ToDecimal(gr.Cells[2].Text.Trim());
                                totalFee = totalFee + givenpostFee;
                                postGroupId = Convert.ToInt32(gr.Cells[3].Text.Trim());
                                sb.Append("<Item ItemId=\"" + postGroupId.ToString() + "\" Fee =\"" + givenpostFee.ToString() + "\"/>");
                            }
                        }
                    }
                    sb.Append("</Root>");

                    if (flag && totalFee > 0 && sb.ToString().Trim().Length > 12)
                    {
                        cls = new EGrassery_FeeCalculationNewDB();

                        ds = cls.SetCartItem(Convert.ToInt64(Session["PayeeId"]), sb.ToString().Trim(), totalFee, Convert.ToInt64(ViewState["CartID"]), Convert.ToInt32(Session["PayeeUserTypeId"]));

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["DataSaved"].ToString().ToUpper() == "Y")
                            {
                                /************    ENcrypting ***************************/

                                string SECURE_SECRET = ConfigurationManager.AppSettings["Oasis_SecureHashSecret"].ToString();
                                System.Collections.SortedList transactionData = new System.Collections.SortedList(new VPCStringComparer());

                                string queryString = "";
                                transactionData.Add("CartId", ds.Tables[0].Rows[0]["CartId"].ToString());

                                string rawHashData = SECURE_SECRET;
                                string seperator = "";
                                string requestURL = "PaymentModeSelection.aspx";
                                foreach (System.Collections.DictionaryEntry item in transactionData)
                                {
                                    queryString += seperator + System.Web.HttpUtility.UrlEncode(item.Key.ToString()) + "=" + System.Web.HttpUtility.UrlEncode(item.Value.ToString());
                                    seperator = "&";

                                    if (SECURE_SECRET.Length > 0)
                                    {
                                        rawHashData += item.Value.ToString();
                                    }
                                }

                                string signature = "";
                                if (SECURE_SECRET.Length > 0)
                                {
                                    signature = CreateMD5Signature(rawHashData);
                                    queryString = requestURL + "?" + "vpc_SecureHash=" + signature + seperator + queryString;

                                    Page.Response.Redirect(queryString);

                                }
                            }
                            else
                            {
                                ShowMsg.SetMessage("Your posts fee has not been saved. Please try again.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            ShowMsg.SetMessage("Your posts fee has not been saved. Please try again.", ShowMessageType.Information);
                        }
                    }
                }
                catch (System.Threading.ThreadAbortException tex)
                {
                }
                catch (Exception ex)
                {
                    ShowMsg.SetMessage(ex.StackTrace, ShowMessageType.TechnicalError);
                }
                finally
                {
                    chk = null;
                    ltPostId = null;
                    cls = null;
                }
            }
        }
        public class EGrassery_FeeCalculationNewDB
        {

            public DataSet GetAllAppliedPostGroupDetails(Int32 FeeGroupId, Int32 PhaseId, Int32 UserTypeId, Int64 PayeeId, string UserLoginId)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@FeeGroupId", FeeGroupId),
                new SqlParameter("@PhaseId", PhaseId),
                new SqlParameter("@UserTypeId", UserTypeId),
                new SqlParameter("@PayeeId", PayeeId),
                new SqlParameter("@UserLoginId", UserLoginId)
            };

                //parameters[0].Value = ;
                //parameters[1].Value = ;
                //parameters[2].Value = ;
                //parameters[3].Value = ;
                //parameters[4].Value = ;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("Fee_Client_GetAppliedPostGroupFee", parameters);

                }
                finally
                {
                    db.Dispose();
                }

            }
            public DataSet SetCartItem(long applicationFormNo, string postIds_Fee, decimal totalFee, long cartId, int userTypeId)
            {
                SqlParameter[] parameters = {
                                            new SqlParameter("@ApplicationFormNo", SqlDbType.BigInt) ,
                                            new SqlParameter("@Post_FEE", SqlDbType.Text),
                                            new SqlParameter("@TotalFee", SqlDbType.Decimal),
                                            new SqlParameter("@CartId", SqlDbType.BigInt),
                                            new SqlParameter("@UserTypeId", SqlDbType.Int)
                                        };
                parameters[0].Value = applicationFormNo;
                parameters[1].Value = postIds_Fee;
                parameters[2].Value = totalFee;
                parameters[3].Value = cartId;
                parameters[4].Value = userTypeId;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("Fee_Client_SetSelectedPostGroupFee", parameters);

                }
                finally
                {
                    db.Dispose();
                }
            }
        }
        protected override void LoadViewState(object savedState)
        {
            if (Session["__ISREFRESH"] != null)
            {
                object[] allStates = (object[])savedState;
                base.LoadViewState(allStates[0]);
                _refreshState = (bool)allStates[1];
                _isRefresh = (bool)Session["__ISREFRESH"];
            }
        }
        protected override object SaveViewState()
        {
            Session["__ISREFRESH"] = !_refreshState;
            object[] allStates = new object[2];
            allStates[0] = base.SaveViewState();
            allStates[1] = !_refreshState;
            return allStates;
        }
    }
}