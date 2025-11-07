using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AdminModule
{
    public partial class frmCheckCandidateEligibilityForCapRound : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
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
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    ContentBox1.Visible = false;

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            lblApplicationID.Text += txtApplicationID.Text;
            Int64 PID = reg.getPersonalID(txtApplicationID.Text);
            lblPersonalID.Text += PID.ToString();
            ContentTable1.Visible = false;
            ContentBox1.Visible = true;
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                DataSet dsDashboard = new DBUtilityCheckEligibilityforCapRound().getCheckEligibilityforCapRound(PID);
                if (dsDashboard.Tables.Count > 0)
                {
                    if (dsDashboard.Tables[0].Rows.Count > 0)
                    {
                        // tblDashboard.Visible = true;

                        gvCheckEligibleCand.DataSource = dsDashboard.Tables[0];
                        gvCheckEligibleCand.DataBind();
                    }
                    else
                    {
                        // tblDashboard.Visible = false;
                        shInfo.SetMessage("No records to display.", ShowMessageType.Information);
                    }
                }
                else
                {
                    // tblDashboard.Visible = false;
                    shInfo.SetMessage("No records to display.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
    public class DBUtilityCheckEligibilityforCapRound
    {
        public DataSet getCheckEligibilityforCapRound(Int64 PID)
        {


            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("sp_CheckCaproundIIEligibility", new SqlParameter[]
                  {
                    new SqlParameter("@PID",PID),
                   // new SqlParameter("@DocumentStatus",documentStatus)
                  });
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}