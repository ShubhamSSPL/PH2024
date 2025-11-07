using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Configuration;
using System.Text;
using System.Web.UI;

namespace Pharmacy2024.CandidateModule
{
    public partial class frmChangePassword : System.Web.UI.Page
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

                Int64 PID = ((SessionData)Session["SessionData"]).PID;
                string OLDCandidatePassword = HashSHA1Password(txtoldPassword.Text);
                string CandidatePassword = HashSHA1Password(txtPassword.Text);

                if (reg.CheckOldCandidatePassword(Session["UserLoginID"].ToString(), OLDCandidatePassword))
                {
                    if (reg.resetCandidatePassword(PID, CandidatePassword, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        shInfo.SetMessage("Password changed successfully.", ShowMessageType.Information);
                    }
                    else
                    {
                        shInfo.SetMessage("New password can not be same as last 3 password, so please choose a diffrent password.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("Old password can not be same as last Password.", ShowMessageType.Information);
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