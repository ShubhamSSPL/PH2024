using BusinessLayer;
using EntityModel;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.RegistrationModule
{
    public partial class frmVerifyOTP : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public Int32 CounterOTP = 120;
        public Int32 OTPSlap = 120000;
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
            if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    string ApplicationID = Request.QueryString["ApplicationID"];
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();
                    Int64 PID = reg.getPersonalID(ApplicationID);
                    string Code = Request.QueryString["Code"];

                    if (ApplicationID.GetHashCode() != Convert.ToInt32(Code))
                    {
                        Response.Write("<BR /><BR /><center><H1>You are not Authorised to see the login details.</H1></center>");
                        Response.End();
                    }
                    DataSet OTPVerificationAttempts = reg.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, 1, "OtpRegistration");
                    int MaxResendOTP = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["MaxResendOTP"].ToString());

                    if (MaxResendOTP >= 5)
                    {
                        tdverifyOTP.Visible = false;
                        tdResendOTP.Visible = false;
                        ContentTable1.Visible = false;
                        shInfo.SetMessage("you have not valid user.", ShowMessageType.Information);
                    }
                    lblMaskMobileno.Text = "Enter One Time Password(OTP) Sent on " + DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(PID).ToString())).ToString();
                }
                catch (Exception ex)
                {
                    //Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string ApplicationID = Request.QueryString["ApplicationID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();
                DataSet OTPVerificationAttempts = reg.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, 1, "OtpRegistration");
                int COTPAttempts = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["OTPAttempts"].ToString());

                if (txtOneTimePassword.Text.Length == 0)
                {
                    shInfo.SetMessage("Enter the OTP", ShowMessageType.Information);
                }
                else
                {
                    if (COTPAttempts != 3)
                    {
                        if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, 1))
                        {
                            Int64 PID = reg.getPersonalID(ApplicationID);
                            // DataSet ds = reg.getSMSContent(PID, "Registration");

                            if (Global.SendSMSToCandidate == 1)
                            {
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = PID;
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.Registration);

                                //SMS objSMS = new SMS();
                                //DataSet ds = reg.GetSMSEmailContent(PID, "Registration", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                                //if (ds.Tables[1] != null)
                                //{
                                //    if (ds.Tables[1].Rows.Count > 0)
                                //    {
                                //        objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[1].Rows[0]["MobileNo"].ToString()), ds.Tables[1].Rows[0]["SMSContent"].ToString());
                                //        if (Global.IsEmailSend == 1)
                                //        {
                                //            //objSMS.SendEmail(ds.Tables[1].Rows[0]["EmailID"].ToString(), ds.Tables[1].Rows[0]["EmailBody"].ToString(), ds.Tables[1].Rows[0]["EmailSubject"].ToString(), true);
                                //        }
                                //    }
                                //}
                            }
                            Response.Redirect("~/RegistrationModule/frmInstructionsAfterRegistration?ApplicationID=" + ApplicationID + "&Code=" + ApplicationID.GetHashCode(), true);

                        }
                        else
                        {
                            shInfo.SetMessage("You have Entered Wrong One Time Password. Please Try Again.", ShowMessageType.Information);
                        }
                    }
                }

                if (COTPAttempts >= 3)
                {
                    tdverifyOTP.Visible = false;
                    tdResendOTP.Visible = false;
                    ContentTable1.Visible = false;
                    shInfo.SetMessage("Dear Candidate your Application ID is blocked till next day. Please try on next day.", ShowMessageType.Information);
                }
                else
                {
                    if (COTPAttempts > 1)
                    {
                        CounterOTP = 60;
                        for (int i = 0; i < COTPAttempts; i++)
                        {
                            CounterOTP = CounterOTP + 60;
                            OTPSlap = CounterOTP * 1000;
                        }
                    }
                    if (OTPVerificationAttempts.Tables[0].Rows.Count > 0)
                    {
                        if (OTPVerificationAttempts.Tables[0].Rows[0]["OtpIsBlock"].ToString() == "1")
                        {
                            //tdverifyOTP.Visible = false;
                            btnVerifyOTP.Visible = false;
                            tdResendOTP.Visible = true;
                            txtOneTimePassword.Text = "";
                            //shInfo.SetMessage("You have Entered Wrong One Time Password. Please Click On Resend Button after " + CounterOTP + " seconds.", ShowMessageType.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnResendOTP_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string Counter = myHiddenInput.Value;

                if (Convert.ToInt32(Counter) <= 1 || Convert.ToInt32(Counter) <= 2)
                {
                    string ApplicationID = Request.QueryString["ApplicationID"].ToString();
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();
                    DataSet OTPVerificationAttempts = reg.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, 1, "OtpRegistration");
                    int MaxResendOTP = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["MaxResendOTP"].ToString());

                    if (MaxResendOTP >= 5)
                    {
                        tdverifyOTP.Visible = false;
                        tdResendOTP.Visible = false;
                        ContentTable1.Visible = false;
                        shInfo.SetMessage("you have not valid user.", ShowMessageType.Information);
                    }
                    else
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "id", "btnResendOTP()", true);
                        //string OTP = Global.IsOTPVerificationRequired == 1 ? UserInfo.GenerateOTP() : "";
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        SynCommon synCommon = new SynCommon();
                        sMSTemplate.PID = reg.getPersonalID(ApplicationID);
                        if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OtpRegistration))
                            btnVerifyOTP.Visible = true;
                        //tdverifyOTP.Visible = true;
                        //tdResendOTP.Visible = false;
                        txtOneTimePassword.Text = "";
                    }
                }
                else
                {
                    CounterOTP = Convert.ToInt32(Counter);
                    OTPSlap = CounterOTP * 1000;
                    //shInfo.SetMessage("Resend OTP Counter Count is Not-0 - " + Counter + "-Second is Remaining.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {

                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        //protected void btnVerifyCall_Click(object sender, EventArgs e)
        //{
        //    ClientScript.RegisterStartupScript(GetType(), "id", "codeAddress()", true);
        //    SMS objSMS = new SMS();
        //    string mobno = DataEncryption.DecryptDataByEncryptionKey(Request.QueryString["MobileNo"]);
        //    objSMS.voiceCallOTP(mobno);
        //}
        //protected void btnCall_Click(object sender, EventArgs e)
        //{
        //    ClientScript.RegisterStartupScript(GetType(), "id", "showRetryTiemout()", true);
        //    string mobno = DataEncryption.DecryptDataByEncryptionKey(Request.QueryString["MobileNo"]);
        //    SMS objSMS = new SMS();
        //    objSMS.voiceCallOTP(mobno);
        //}
    }
}