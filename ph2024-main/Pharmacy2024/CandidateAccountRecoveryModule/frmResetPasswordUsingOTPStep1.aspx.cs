using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateAccountRecoveryModule
{
    public partial class frmResetPasswordUsingOTPStep1 : System.Web.UI.Page
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
            btnBack.Attributes.Add("onclick", "history.back();return true");
            //btnBack.Attributes.Add("onclick", "history.back();return false");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (Global.IsCaptchaRequired == 1)
                    Captcha1.ValidateCaptcha(txtSecurityPin.Text.Trim());

                if (Captcha1.UserValidated)
                {
                    string ApplicationID = txtApplicationID.Text;
                    DateTime DOB = Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]);

                    Int64 PID = reg.checkCandidateApplicationIDAndDOB(ApplicationID, DOB);

                    if (PID == 1)
                    {
                        shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                    }
                    else if (PID == 2)
                    {
                        shInfo.SetMessage("Wrong DOB. Select the correct DOB which you have entered during Application Form Submission.", ShowMessageType.Information);
                    }
                    else if (PID > 100000)
                    {
                        this.Context.Items["PID"] = PID;
                        Response.Redirect("~/CandidateAccountRecoveryModule/frmResetPasswordUsingOTPStep2.aspx?PID=" + DataEncryption.URLParamEncrypt(PID.ToString()));
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Retrival. Please try again.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("Invalid Captcha. Please try again.", ShowMessageType.Information);
                }
                txtApplicationID.Text = "";
                txtDOB.Text = "";
                txtSecurityPin.Text = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateAccountRecoveryModule/frmAccountRecovery.aspx");
        }
    }
}