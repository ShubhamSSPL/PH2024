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

namespace Pharmacy2024.InstituteModule
{
    public partial class frmAdmissionNotCancelledConvertedToOpen : System.Web.UI.Page
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

                    string UserTypeID = "Open";

                    gvCandidateList.DataSource = new dbUtility().GetAdmissionNotCancelledConvertedToOpen(UserTypeID, Session["UserLoginID"].ToString());
                    gvCandidateList.DataBind();

                    for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                    {
                        gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        gvCandidateList.Rows[i].Cells[3].Text = DataEncryption.DecryptDataByEncryptionKey(gvCandidateList.Rows[i].Cells[3].Text);
                    }

                    //lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        

        private class dbUtility
        {
            public DataSet GetAdmissionNotCancelledConvertedToOpen(string UserTypeID, string UserLoginID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@UserTypeID", SqlDbType.VarChar),
                     new SqlParameter("@UserLoginID", SqlDbType.VarChar)
                };

                param[0].Value = UserTypeID;
                param[1].Value = UserLoginID;

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetAdmissionNotCancelledConvertedToOpenList", param);

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