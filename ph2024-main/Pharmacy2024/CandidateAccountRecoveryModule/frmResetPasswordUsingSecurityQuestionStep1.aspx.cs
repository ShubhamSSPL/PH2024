using BusinessLayer;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateAccountRecoveryModule
{
    public partial class frmResetPasswordUsingSecurityQuestionStep1 : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    btnBack.Attributes.Add("onclick", "history.back();return false");

                    ddlSecurityQuestion.DataSource = Global.MasterSecurityQuestion;
                    ddlSecurityQuestion.DataTextField = "SecurityQuestionDetails";
                    ddlSecurityQuestion.DataValueField = "SecurityQuestionID";
                    ddlSecurityQuestion.DataBind();
                    ddlSecurityQuestion.Items.Insert(0, new ListItem("-- Select Security Question --", "0"));
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string ApplicationID = txtApplicationID.Text;
                Int16 SecurityQuestionID = Convert.ToInt16(ddlSecurityQuestion.SelectedValue);
                string SecurityAnswer = txtSecurityAnswer.Text;

                Int64 PID = reg.checkCandidateSecurityQuestionDetails(ApplicationID, SecurityQuestionID, SecurityAnswer);

                if (PID == 1)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else if (PID == 2)
                {
                    shInfo.SetMessage("Wrong Security Question or its Answer. Select the correct Security Question and give correct answer which you have entered during Application Form Submission.", ShowMessageType.Information);
                }
                else if (PID > 100000)
                {
                    this.Context.Items["PID"] = PID;
                    Server.Transfer("~/CandidateAccountRecoveryModule/frmResetPasswordUsingSecurityQuestionStep2.aspx");
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Retrival. Please try again.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}