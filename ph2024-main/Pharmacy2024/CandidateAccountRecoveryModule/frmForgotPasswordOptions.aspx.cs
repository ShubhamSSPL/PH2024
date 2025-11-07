using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateAccountRecoveryModule
{
    public partial class frmForgotPasswordOptions : System.Web.UI.Page
    {
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

        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (rbnResetPasswordUsingSecurityQuestion.Checked)
            {
                Server.Transfer("../CandidateAccountRecoveryModule/frmResetPasswordUsingSecurityQuestionStep1.aspx");
            }
            else if (rbnResetPasswordUsingOTP.Checked)
            {
                Server.Transfer("../CandidateAccountRecoveryModule/frmResetPasswordUsingOTPStep1.aspx");
            }
            else if (rbnResetPasswordUsingEMailVerification.Checked)
            {
                Server.Transfer("../CandidateAccountRecoveryModule/frmResetPasswordUsingEMailVerificationStep1.aspx");
            }
        }
    }
}