using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateAccountRecoveryModule
{
    public partial class frmResetPasswordUsingOTPStep4 : System.Web.UI.Page
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
                    Int64 PID = Convert.ToInt64(DataEncryption.URLParamDecrypt(Request.QueryString["PID"]));
                    Int32 Code = Convert.ToInt32(DataEncryption.URLParamDecrypt(Request.QueryString["Code"]));
                    if(!reg.CheckISOTPverifyed(PID, 6))
                    {
                        this.Context.Items["PID"] = PID;
                        Response.Redirect("~/CandidateAccountRecoveryModule/frmResetPasswordUsingOTPStep1.aspx?PID=" + DataEncryption.URLParamEncrypt(PID.ToString()));
                    }
                    if (!reg.CheckIsVerifiedUseResetPassword(PID, 6))
                    {
                        this.Context.Items["PID"] = PID;
                        Response.Redirect("~/CandidateAccountRecoveryModule/frmResetPasswordUsingOTPStep1.aspx?PID=" + DataEncryption.URLParamEncrypt(PID.ToString()));
                    }
                    if (PID.ToString().GetHashCode() != Code)
                    {
                        this.Context.Items["PID"] = PID;
                        Response.Redirect("~/CandidateAccountRecoveryModule/frmResetPasswordUsingOTPStep3.aspx?PID=" + DataEncryption.URLParamEncrypt(PID.ToString()));
                    }
                    if (DataEncryption.URLParamDecrypt(Request.QueryString["PID"]) == null)
                    {
                        Response.Write("<BR /><BR /><center><H1>You are not Authorised to see this page.</H1></center>");
                        Response.End();
                    }
                    else
                    {
                        ViewState["PID"] = DataEncryption.URLParamDecrypt(Request.QueryString["PID"]);
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
            shInfo.Visible = false;
            try
            {
                Int64 PID = Convert.ToInt64(ViewState["PID"]);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid URL Parameters so password is not updated.", ShowMessageType.Information);
                }
                else
                {
                    string CandidatePassword = HashSHA1Password(txtPassword.Text);

                    if (reg.resetCandidatePassword(PID, CandidatePassword, "Forgot Password Utility", UserInfo.GetIPAddress()))
                    {
                        this.Context.Items["PID"] = PID;
                        Server.Transfer("~/CandidateAccountRecoveryModule/frmResetPasswordUsingOTPStep5.aspx?PID=" + DataEncryption.URLParamEncrypt(PID.ToString()));
                    }
                    else
                    {
                        shInfo.SetMessage("New password can not be same as last 3 password, so please choose a diffrent password.", ShowMessageType.Information);
                    }
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