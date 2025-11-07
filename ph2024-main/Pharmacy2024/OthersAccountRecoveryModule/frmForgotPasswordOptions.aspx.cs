using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.OthersAccountRecoveryModule
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
                Server.Transfer("../OthersAccountRecoveryModule/frmResetPasswordUsingSecurityQuestionStep1.aspx");
            }
            else if (rbnResetPasswordUsingOTP.Checked)
            {
                Server.Transfer("../OthersAccountRecoveryModule/frmResetPasswordUsingOTPStep1.aspx");
            }
            else if (rbnResetPasswordUsingEMailVerification.Checked)
            {
                Server.Transfer("../OthersAccountRecoveryModule/frmResetPasswordUsingEMailVerificationStep1.aspx");
            }
        }
    }
}