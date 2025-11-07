using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateAccountRecoveryModule
{
    public partial class frmAccountRecovery : System.Web.UI.Page
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
            if (rbnForgotPassword.Checked)
            {
                //Server.Transfer("../CandidateAccountRecoveryModule/frmForgotPasswordOptions.aspx");
                Response.Redirect("../CandidateAccountRecoveryModule/frmResetPasswordUsingOTPStep1.aspx");
            }
            else if (rbnForgotApplicationID.Checked)
            {
                Response.Redirect("../CandidateAccountRecoveryModule/frmForgotApplicationID.aspx");
            }
        }
    }
}