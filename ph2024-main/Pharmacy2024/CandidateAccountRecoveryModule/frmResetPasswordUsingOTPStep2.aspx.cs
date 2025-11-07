using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateAccountRecoveryModule
{
    public partial class frmResetPasswordUsingOTPStep2 : System.Web.UI.Page
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
                        Int64 PID = Convert.ToInt64(DataEncryption.URLParamDecrypt(Request.QueryString["PID"]));
                        ViewState["PID"] = PID;
                        string MobileNo = DataEncryption.DecryptDataByEncryptionKey(reg.verifyCandidateMobileNo(PID));
                        lblMobileNo.Text = MobileNo.Substring(0, 3) + "****" + MobileNo.Substring(7, 3);
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
                string ApplicationID = Global.ApplicationFormPrefix + PID.ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();
                int COTPAttempts = 0;
                int OtpIsBlock = 0;
                DataSet OTPVerificationAttempts = reg.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, 6, "SendOTPforResetPassword");
                if (OTPVerificationAttempts.Tables[0].Rows.Count > 0)
                {
                    COTPAttempts = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["OTPAttempts"].ToString());
                    OtpIsBlock = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["OtpIsBlock"].ToString());
                }

                if (OtpIsBlock == 1)
                {
                    ContentTable1.Visible = false;
                    shInfo.SetMessage("Dear Candidate your Application ID is blocked till 11:59:59 PM, please try on next day.", ShowMessageType.Information);
                }
                else
                {
                    SMSTemplate sMSTemplate = new SMSTemplate();
                    sMSTemplate.PID = PID;
                    SynCommon synCommon = new SynCommon();
                    if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.SendOTPforResetPassword))
                        //DataSet ds = reg.getSMSContent(PID, "Send OTP for Reset Password");
                        //SMS objSMS = new SMS();

                        //objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[0].Rows[0]["MobileNo"].ToString()), ConfigurationManager.AppSettings["Project_Name"].ToString() + " : " + ds.Tables[0].Rows[0]["SMSContent"].ToString());

                        this.Context.Items["PID"] = PID;
                    Response.Redirect("~/CandidateAccountRecoveryModule/frmResetPasswordUsingOTPStep3.aspx?PID=" + DataEncryption.URLParamEncrypt(PID.ToString()));
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