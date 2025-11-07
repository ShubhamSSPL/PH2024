using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using EntityModel;
using System.Data;
using System.Configuration;
using Synthesys.Controls;
using System.Data.SqlClient;
using Synthesys.DataAcess;

namespace Pharmacy2024.AFCModule
{
    public partial class frmCVCNCLEWSCandidateListForVerification : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    if (Request.Cookies["Theme"] == null)
        //    {
        //        Page.Theme = "default";
        //    }
        //    else
        //    {
        //        Page.Theme = Request.Cookies["Theme"].Value;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);

                    gvCandidateList.DataSource = new dbUtility().GetCVCNCLEWSVerificationPendingList(UserTypeID, Session["UserLoginID"].ToString());
                    gvCandidateList.DataBind();

                    for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                    {
                        gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        DateTime dt = Convert.ToDateTime(gvCandidateList.Rows[i].Cells[4].Text);
                        gvCandidateList.Rows[i].Cells[4].Text = dt.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", dt);
                        gvCandidateList.Rows[i].Cells[3].Text = DataEncryption.DecryptDataByEncryptionKey(gvCandidateList.Rows[i].Cells[3].Text);
                    }

                    lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void gvCandidateList_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void gvCandidateList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
            try
            {
                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 PID = Convert.ToInt64(((Label)gvCandidateList.Rows[RowID].FindControl("lblPersonalID")).Text);
                //char VerificationMode = Convert.ToChar(((Label)gvCandidateList.Rows[RowID].FindControl("lblVerificationMode")).Text);

                if (e.CommandName == "Verify")
                {

                    int res = 0;
                    res = new dbUtility().UpdateFlag(PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                    //if (VerificationMode == 'E')
                    //{
                    //    Response.Redirect("../E_FCModule/EVerificationHomeDistrictAndCategoryDetails?PID=" + PID + "&Code=" + PID.ToString().GetHashCode().ToString() + "&ApplicationFormStepID=4&ForSEBC=Y");
                    //}
                    //else
                    //    Response.Redirect("../AFCModule/frmEditRequiredDocuments.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    if (res > 0)
                    {
                        Response.Redirect("../AFCModule/frmEVerificationCVCTVCNCLEWS?PID=" + PID + "&Code=" + PID.ToString().GetHashCode().ToString());
                    }
                    else
                    {
                        shInfo.SetMessage("There is a Technical Error. Please try after sometime.", ShowMessageType.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        private class dbUtility
        {
            public DataSet GetCVCNCLEWSVerificationPendingList(int UserTypeID, string UserLoginID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@UserTypeID", SqlDbType.Int),
                     new SqlParameter("@UserLoginID", SqlDbType.VarChar)
                };

                param[0].Value = UserTypeID;
                param[1].Value = UserLoginID;

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetCVCNCLEWSVerificationPendingList", param);

                }
                finally
                {
                    db.Dispose();
                }

                //return ExecProcedure("MHDTE_spGetAllDocuments", param, "tbl");
            }
            public int UpdateFlag(Int64 PersonalID, string UserLoginID, string IPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PersonalID", SqlDbType.Int),
                     new SqlParameter("@UserLoginID", SqlDbType.VarChar),
                       new SqlParameter("@IPAddress", SqlDbType.VarChar)
                };

                param[0].Value = PersonalID;
                param[1].Value = UserLoginID;
                param[2].Value = IPAddress;

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteNonQuery("MHDTE_spUpdateCVCNCLFlag", param);

                }
                finally
                {
                    db.Dispose();
                }

                //return ExecProcedure("MHDTE_spGetAllDocuments", param, "tbl");
            }
        }
    }
}