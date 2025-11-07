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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.FeeProcess
{
    public partial class PaymentModeSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["PayeeId"] == null || Session["PayeeId"].ToString().Trim() == "" || Convert.ToInt64(Session["PayeeId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["PayeeUserTypeId"] == null || Session["PayeeUserTypeId"].ToString().Trim() == "" || Convert.ToInt64(Session["PayeeUserTypeId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }




            if (IsValidRequest())
            {
                long cartId = Convert.ToInt64(Request.QueryString["CartId"]);
                ViewState["CartId"] = cartId.ToString();
                if (!IsPostBack)
                {
                    LoadPaymentModeGroup(cartId);
                }
            }
            else
            {
                LogWriterService.WriteErrorLog("Invalid Request: Received Invalid Cart ID", "Payment Mode Selection");
                Response.Redirect(ConfigurationManager.AppSettings["ErrorURL"].ToString(), true);
            }
        }
        protected void LoadPaymentModeGroup(long CartId)
        {

            Form1.Visible = true;
            DataSet ds = null;
            StringBuilder strModeInstruction = new StringBuilder();
            try
            {
                ds = new clsPaymentModeSelectionDB().GetPaymentModeGroupDetails(CartId);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(ds.Tables[2].Rows[0]["CartCount"]) != 0)
                        {
                            lblCartAmount.Text = ds.Tables[2].Rows[0]["CartAmount"].ToString();
                            lblCartCount.Text = ds.Tables[2].Rows[0]["CartCount"].ToString();


                            if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                            {
                                HtmlGenericControl table = new HtmlGenericControl("Table");
                                foreach (DataRow row in ds.Tables[3].Rows)
                                {
                                    HtmlGenericControl tr = new HtmlGenericControl("TR");

                                    HtmlGenericControl td1 = new HtmlGenericControl("TD");
                                    td1.InnerHtml = "<font color='#18A348'><B>" + row["Item"].ToString() + "</B></font> ";

                                    HtmlGenericControl td = new HtmlGenericControl("TD");
                                    td.InnerHtml = "<B>&nbsp;&nbsp;:&nbsp;&nbsp;</B>";

                                    HtmlGenericControl td2 = new HtmlGenericControl("TD");
                                    td2.Attributes.Add("align", "center");
                                    td2.InnerHtml = " <font color='#FF2B2B'><B>" + row["Amount"].ToString() + "</B></font>";

                                    tr.Controls.Add(td1);
                                    tr.Controls.Add(td);
                                    tr.Controls.Add(td2);

                                    table.Controls.Add(tr);
                                }
                                popovercartlist.Controls.Add(table);

                            }
                            /////////////////////
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                                    anchor.Attributes.Add("href", "#");
                                    anchor.Attributes.Add("class", Convert.ToString(row["Active"]));
                                    anchor.InnerHtml = "<h4 class='" + Convert.ToString(row["ImgClass"]) + "' ></h4><br/>" + Convert.ToString(row["DisplayGroupName"]);
                                    divPayGroup.Controls.Add(anchor);

                                }
                            }
                            //--------------------------------
                            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                            {
                                ViewState["paymentMode"] = ds.Tables[1];

                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    HtmlGenericControl div = new HtmlGenericControl("div");
                                    div.Attributes.Add("class", row["ActiveMode"].ToString());
                                    foreach (DataRow row1 in ds.Tables[1].Rows)
                                    {
                                        if (row["PayModeGroup"].ToString() == row1["PayModeGroup"].ToString())
                                        {
                                            strModeInstruction.Append(row1["PaymentMode"].ToString() + "#" + row1["Instructions"].ToString() + "|");

                                            HtmlGenericControl label = new HtmlGenericControl("label");
                                            label.Attributes.Add("class", "radio-inline text-center");
                                            label.Attributes.Add("runat", "server");

                                            HtmlGenericControl div1 = new HtmlGenericControl("div");
                                            div1.Attributes.Add("class", row1["PaymodeLogo"].ToString());

                                            RadioButton rb = new RadioButton();
                                            rb.Text = "&nbsp;&nbsp;" + row1["PayModeName"].ToString();
                                            rb.Attributes.Add("value", row1["PaymentMode"].ToString());
                                            rb.GroupName = "PaymentMode";
                                            rb.Attributes.Add("onClick", "return ShowDetails('" + row1["PaymentMode"].ToString() + "','" + row["PayModeGroup"].ToString() + "')");
                                            rb.AutoPostBack = false;

                                            label.Controls.Add(div1);
                                            label.Controls.Add(rb);
                                            div.Controls.Add(label);

                                        }
                                        divPayMode.Controls.Add(div);
                                    }

                                }
                                hdnModeInstruction.Value = strModeInstruction.ToString().Substring(0, strModeInstruction.ToString().Length - 1);
                            }
                            //----------------------------------

                            ////////////////////////
                        }
                        else
                        {

                            Form1.Visible = false;

                            LogWriterService.WriteErrorLog("There is no post selected for payment.", "Payment Mode Selection");
                            Response.Redirect(ConfigurationManager.AppSettings["ErrorURL"].ToString(), true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriterService.WriteErrorLog(ex.Message, "Payment Mode Selection");
                Response.Redirect(ConfigurationManager.AppSettings["ErrorURL"].ToString(), true);
            }
            finally
            {
                ds = null;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnPaymentMode.Value != "")
            {
                SendToPayment((DataTable)(ViewState["paymentMode"]), hdnPaymentMode.Value);
            }
            else
            {
                LoadPaymentModeGroup(Convert.ToInt64(ViewState["CartId"]));
            }
        }

        protected void SendToPayment(DataTable dt, string Mode)
        {
            string responseURL = string.Empty;
            string requestURL = string.Empty;
            string PaymentModeId = "";

            StringBuilder msg = new StringBuilder();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["PaymentMode"].ToString() == Mode)
                    {
                        responseURL = row["ResponseURL"].ToString();
                        requestURL = row["GenerateRequestURL"].ToString();
                        PaymentModeId = row["PayModeId"].ToString();
                        break;
                    }
                }


                string SECURE_SECRET = ConfigurationManager.AppSettings["Oasis_SecureHashSecret"].ToString();
                System.Collections.SortedList transactionData = new System.Collections.SortedList(new VPCStringComparer());

                string queryString = "";
                transactionData.Add("CartId", ViewState["CartId"].ToString());
                transactionData.Add("ModeId", PaymentModeId);
                string rawHashData = SECURE_SECRET;
                string seperator = "";

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
                    //queryString = ConfigurationManager.AppSettings["PaymentURL"].ToString() + "?" + "vpc_SecureHash=" + signature + seperator + queryString;

                    Page.Response.Redirect(queryString);

                }

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
        private bool IsValidRequest()
        {
            string signature = "";
            bool isValid = true;
            string SECURE_SECRET = ConfigurationManager.AppSettings["Oasis_SecureHashSecret"].ToString();
            string rawHashData = SECURE_SECRET;

            try
            {
                if (Page.Request.QueryString["vpc_SecureHash"].Length > 0)
                {
                    foreach (string item in Page.Request.QueryString)
                    {
                        if (SECURE_SECRET.Length > 0 && !item.Equals("vpc_SecureHash"))
                        {
                            rawHashData += Page.Request.QueryString[item];
                        }
                    }
                }


                if (SECURE_SECRET.Length > 0)
                {
                    signature = CreateMD5Signature(rawHashData);
                    if (Page.Request.QueryString["vpc_SecureHash"].Equals(signature))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }
            }
            catch (Exception)
            {

            }

            return isValid;

        }
    }
    public class clsPaymentModeSelectionDB
    {
        public DataSet GetPaymentModeGroupDetails(long CartId)
        {
            SqlParameter[] param = {
                                   new SqlParameter("@CartId",SqlDbType.BigInt)
                               };
            param[0].Value = CartId;
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("Fee_Client_GetPayModeForPaymentGateway", param);

            }
            finally
            {
                db.Dispose();
            }
        }
    }
}