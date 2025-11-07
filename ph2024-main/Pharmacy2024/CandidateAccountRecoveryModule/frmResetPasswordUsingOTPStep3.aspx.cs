using BusinessLayer;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateAccountRecoveryModule
{
    public partial class frmResetPasswordUsingOTPStep3 : System.Web.UI.Page
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
                    if (DataEncryption.URLParamDecrypt(Request.QueryString["PID"]) == null)
                    {
                        Response.Write("<BR /><BR /><center><H1>You are not Authorised to see this page.</H1></center>");
                        Response.End();
                    }
                    else
                    {
                        ViewState["PID"] = DataEncryption.URLParamDecrypt(Request.QueryString["PID"]);
                    }

                    Int64 PID = Convert.ToInt64(ViewState["PID"]);
                    string ApplicationID = Global.ApplicationFormPrefix + PID.ToString();
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();
                    DataSet OTPVerificationAttempts = reg.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, 6, "SendOTPforResetPassword");
                    int COTPAttempts = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["OTPAttempts"].ToString());
                    int OtpIsBlock = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["OtpIsBlock"].ToString());

                    if (OtpIsBlock == 1)
                    {
                        ContentTable1.Visible = false;
                        shInfo.SetMessage("Dear Candidate your Application ID is blocked till 11:59:59 PM, please try on next day.", ShowMessageType.Information);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(ViewState["PID"]);
                string OTPCode = txtOTPCode.Text.Trim();
                string ApplicationID = Global.ApplicationFormPrefix + PID.ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                if (Global.IsCaptchaRequired == 1)
                    Captcha1.ValidateCaptcha(txtSecurityPin.Text.Trim());
                if (Captcha1.UserValidated)
                {
                    DataSet OTPVerificationAttempts = reg.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, 6, "SendOTPforResetPassword");
                    int COTPAttempts = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["OTPAttempts"].ToString());
                    int OtpIsBlock = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["OtpIsBlock"].ToString());
                    if (OtpIsBlock != 1)
                    {
                        if (OTPCode != "")
                        {
                            //if (reg.verifyCandidateOTPCode(PID, OTPCode))
                            if (reg.verifyOTP(Global.ApplicationFormPrefix + PID.ToString(), OTPCode, (int)SynCommon.TemplateSystemType.SendOTPforResetPassword))
                            {
                                this.Context.Items["PID"] = PID;
                                Response.Redirect("~/CandidateAccountRecoveryModule/frmResetPasswordUsingOTPStep4.aspx?PID=" + DataEncryption.URLParamEncrypt(PID.ToString()) + "&Code=" + DataEncryption.URLParamEncrypt(Convert.ToString(PID.ToString().GetHashCode())), true);
                            }
                            else
                            {
                                shInfo.SetMessage("This verification code is no longer valid. The code you received via text message (SMS) is expired or you may already have used it.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("Enter OTP verification code. The code you received via text message (SMS).", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        ContentTable1.Visible = false;
                        shInfo.SetMessage("Dear Candidate your Application ID is blocked till 11:59:59 PM, please try on next day.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("Invalid Captcha. Please try again.", ShowMessageType.Information);
                }
                txtOTPCode.Text = "";
                txtSecurityPin.Text = "";

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}