using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmSendSMSToCandidates : System.Web.UI.Page
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                if (PID.ToString().GetHashCode() != Code)
                {
                    Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                }

                string ApplicationID = Request.QueryString["ApplicationID"].ToString();

                lblApplicationID.Text = ApplicationID;
                lblCandidateName.Text = reg.getCandidateName(PID);
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                string mobileNo = reg.getMobileNo(PID);
                SMS objSMS = new SMS();
                objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(mobileNo), ConfigurationManager.AppSettings["Project_Name"].ToString() + " : " + txtSMSContent.Text.ToString() + " -Sent From " + Session["UserLoginID"].ToString(), "CustomMessage", PID.ToString(),"111");
                shInfo.SetMessage("SMS Sent Successfully.", ShowMessageType.Information);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}