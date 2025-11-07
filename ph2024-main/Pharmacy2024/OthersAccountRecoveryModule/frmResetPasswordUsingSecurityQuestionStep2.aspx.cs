using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.OthersAccountRecoveryModule
{
    public partial class frmResetPasswordUsingSecurityQuestionStep2 : System.Web.UI.Page
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


                    if (this.Context.Items["LoginID"] == null)
                    {
                        Response.Write("<BR /><BR /><center><H1>You are not Authorised to see this page.</H1></center>");
                        Response.End();
                    }
                    else
                    {
                        ViewState["LoginID"] = this.Context.Items["LoginID"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public static string HashSHA1Password(string Password)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(Password);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                string LoginID = ViewState["LoginID"].ToString();
                string Password = HashSHA1Password(txtPassword.Text);

                if (reg.resetOthersPassword(LoginID, Password, UserInfo.GetIPAddress()))
                {
                    this.Context.Items["LoginID"] = LoginID;
                    Server.Transfer("~/OthersAccountRecoveryModule/frmResetPasswordUsingSecurityQuestionStep3.aspx");
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