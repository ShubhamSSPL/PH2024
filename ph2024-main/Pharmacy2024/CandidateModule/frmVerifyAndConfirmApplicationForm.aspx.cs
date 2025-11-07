using BusinessLayer;
using EntityModel;
 
using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class frmVerifyAndConfirmApplicationForm : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public Int32 CounterOTP = 120;
        public Int32 OTPSlap = 120000;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime || Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
            }

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                    char IsLockedByCandidate = Convert.ToChar(statusDs.Tables[0].Rows[0]["IsLockedByCandidate"].ToString());
                    if (reg.isCandidateNameAppearedInFinalMeritList(objSessionData.PID))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }
                    if (ApplicationFormStatus == 'I')
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
                    }
                    //if (reg.getCategoryID(objSessionData.PID) == 10 && (ApplicationFormStatus == 'I' || ApplicationFormStatus == 'C'))
                    //{
                    //    Response.Redirect("../CandidateModule/frmHomeUniversityAndCategoryDetails.aspx", true);
                    //}
                    if (reg.CheckFCVerificationStatus(objSessionData.PID))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }
                    //if (reg.getCategoryID(objSessionData.PID) == 10)
                    //{
                    //    Response.Redirect("../CandidateModule/frmHomeUniversityAndCategoryDetails.aspx", true);
                    //}

                    //reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" &&
                    if ( reg.GetApplicationLockStatus(objSessionData.PID) == "Y")
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }

                    int MaxResendOTP = 0;
                    int COTPAttempts = 0;
                    string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();
                    DataSet OTPVerificationAttempts = reg.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, 16, "OTPApplicationFormConfermation");
                    if (OTPVerificationAttempts.Tables[0].Rows.Count > 0)
                    {
                        MaxResendOTP = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["MaxResendOTP"].ToString());
                        COTPAttempts = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["OTPAttempts"].ToString());
                    }

                    if (/*MaxResendOTP >= 5 ||*/ COTPAttempts >= 3)
                    {
                        tdverifyOTP.Visible = false;
                        tdResendOTP.Visible = false;
                        cbPassword.Visible = false;
                        shInfo.SetMessage("you have not valid user.", ShowMessageType.Information);
                    }
                    else
                    {
                        DataSet dsEligibilityRemark = reg.getEligibilityFlag(objSessionData.PID);
                        if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Length > 0)
                        {
                            if (dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Contains("You are NOT ELIGIBLE for Admission in B.Pharmacy & Post Graduate Pharm.D. ") && dsEligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && dsEligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                            {
                                tblPasword.Visible = false;
                                tblOtp.Visible = false;
                                trEligibilityRemark.Visible = true;
                                lblEligibilityRemark.Text += dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString();
                            }
                            else
                            {
                                DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                                if (dsDiscrepancy.Tables[0].Rows.Count == 0)
                                {
                                    tblPasword.Visible = true;
                                    tblOtp.Visible = false;
                                }
                                else
                                {
                                    tblPasword.Visible = false;
                                    tblOtp.Visible = false;
                                    shInfo.SetMessage("Solve all the Discrepancy(s) are found in Your Application Form.", ShowMessageType.Information);
                                }
                            }

                            //trEligibilityRemark.Visible = true;
                            //lblEligibilityRemark.Text += dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString(); 
                        }
                        else
                        {
                            DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                            if (dsDiscrepancy.Tables[0].Rows.Count == 0)
                            {
                                tblPasword.Visible = true;
                                tblOtp.Visible = false;
                            }
                            else
                            {
                                tblPasword.Visible = false;
                                tblOtp.Visible = false;
                                shInfo.SetMessage("Solve all the Discrepancy(s) are found in Your Application Form.", ShowMessageType.Information);
                            }
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
        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();
                DataSet OTPVerificationAttempts = reg.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, 16, "OTPApplicationFormConfermation");
                int COTPAttempts = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["OTPAttempts"].ToString());

                if (txtOneTimePassword.Text.Length == 0)
                {
                    shInfo.SetMessage("Enter the OTP", ShowMessageType.Information);
                }
                else
                {
                    if (COTPAttempts != 3)
                    {
                        if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, (int)SynCommon.TemplateSystemType.OTPApplicationFormConfermation))
                        {
                            if (reg.LockApplicationForm(objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                            {
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = objSessionData.PID;
                                sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ApplicationFormConfermation);


                                Response.Redirect("../CandidateModule/frmApplicationForm.aspx");
                            }
                            else
                            {
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                            }
                            //btnCall.Visible = false;
                        }
                        else
                        {
                            shInfo.SetMessage("OTP is Invalid.", ShowMessageType.Information);
                            this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                        }
                    }
                       
                }

                if (COTPAttempts >= 3)
                {
                    tdverifyOTP.Visible = false;
                    tdResendOTP.Visible = false;
                    cbPassword.Visible = false;
                    shInfo.SetMessage("Dear Candidate your Application ID is blocked till next day please try on next day.", ShowMessageType.Information);
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
                            tdverifyOTP.Visible = false;
                            tdResendOTP.Visible = true;
                            txtOneTimePassword.Text = "";
                            shInfo.SetMessage("You have Entered Wrong One Time Password. Please Click ON Resend Button After " + CounterOTP + "-Seconds.", ShowMessageType.Information);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnpassword_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int64 result = reg.authenticateCandidateLogin(Session["UserLoginID"].ToString(), DataEncryption.EncryptDataByHashSHA1(txtPassword.Text));
                int MaxResendOTP = 0;
                int COTPAttempts = 0;
                string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();
                DataSet OTPVerificationAttempts = reg.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, 16, "OTPApplicationFormConfermation");

                if (OTPVerificationAttempts.Tables[0].Rows.Count > 0)
                {
                    MaxResendOTP = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["MaxResendOTP"].ToString());
                    COTPAttempts = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["OTPAttempts"].ToString());
                }

                if (/*MaxResendOTP >= 5 ||*/ COTPAttempts >= 3)
                {
                    tdverifyOTP.Visible = false;
                    tdResendOTP.Visible = false;
                    cbPassword.Visible = false;
                    shInfo.SetMessage("you have not valid user.", ShowMessageType.Information);
                }
                else
                {
                    if (result > 0)
                    {
                        if (Global.IsOTPVerificationRequiredForUnlockApplicationForm == 1)
                        {

                            if (reg.CheckFCVerificationStatusForResubmission(objSessionData.PID))
                                btnVerifyOtp.Text = "Verify OTP For Re-Submit Application Form";
                            long PID = objSessionData.PID;
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            sMSTemplate.PID = PID;
                            SynCommon synCommon = new SynCommon();
                            if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OTPApplicationFormConfermation))
                            {
                                tblPasword.Visible = false;
                                tblOtp.Visible = true;
                                hdnPassword.Value = txtPassword.Text;
                                // btnCall.Visible = true;
                                trMobileNo.Visible = true;
                                lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID).ToString())).ToString();
                                this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                            }
                            else
                            {
                                shInfo.SetMessage("There is some problem in OTP Sending. Please try again. or Contact to Help Center", ShowMessageType.Information);
                            }

                        }
                        else
                        {
                            if (reg.LockApplicationForm(objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                            {
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = objSessionData.PID;
                                sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ApplicationFormConfermation);

                                Response.Redirect("../CandidateModule/frmApplicationForm.aspx");
                            }
                            else
                            {
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Password does not Match.", ShowMessageType.Information);
                    }
                }

               
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnResendOTP_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            SessionData objSessionData = (SessionData)Session["SessionData"];
            try
            {
                string Counter = myHiddenInput.Value;

                if (Convert.ToInt32(Counter) <= 1 || Convert.ToInt32(Counter) <= 2)
                {
                    string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();
                    DataSet OTPVerificationAttempts = reg.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, 16, "OTPApplicationFormConfermation");
                    int MaxResendOTP = Convert.ToInt32(OTPVerificationAttempts.Tables[0].Rows[0]["MaxResendOTP"].ToString());

                    if (MaxResendOTP >= 5)
                    {
                        tdverifyOTP.Visible = false;
                        tdResendOTP.Visible = false;
                        cbPassword.Visible = false;
                        shInfo.SetMessage("you have not valid user.", ShowMessageType.Information);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "id", "btnResendOTP()", true);
                        //string OTP = Global.IsOTPVerificationRequired == 1 ? UserInfo.GenerateOTP() : "";
                        if (reg.CheckFCVerificationStatusForResubmission(objSessionData.PID))
                            btnVerifyOtp.Text = "Verify OTP For Re-Submit Application Form";
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        SynCommon synCommon = new SynCommon();
                        sMSTemplate.PID = reg.getPersonalID(ApplicationID);
                        if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OTPApplicationFormConfermation))
                            tdverifyOTP.Visible = true;
                        tdResendOTP.Visible = false;
                        txtOneTimePassword.Text = "";
                    }
                }
                else
                {
                    CounterOTP = Convert.ToInt32(Counter);
                    OTPSlap = CounterOTP * 1000;
                    shInfo.SetMessage("Resend OTP Counter Count is Not-0 -" + Counter + "-Second is Remaining.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {

                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        //protected void btnCall_Click(object sender, EventArgs e)
        //{

        //    SessionData objSessionData = (SessionData)Session["SessionData"];
        //    string mobno = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID));

        //    SMS objSMS = new SMS();
        //    objSMS.voiceCallOTP(mobno);
        //    this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemouts();</script>"));
        //}


    }
}