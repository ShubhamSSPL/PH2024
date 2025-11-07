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
    public partial class frmUnlockApplicationForm : System.Web.UI.Page
    {
        //This page is incomplete Implemented on 16/07/2020 it is pending due to Not use this page.
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            //if (Request.Cookies["Theme"] == null)
            //{
            //    Page.Theme = "default";
            //}
            //else
            //{
            //    Page.Theme = Request.Cookies["Theme"].Value;
            //}
        }
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
                    if (reg.isCandidateNameAppearedInFinalMeritList(objSessionData.PID))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }
                    string FCVerificationStatus = reg.CheckCandidateFCVerificationFor(objSessionData.PID);


                    if (objSessionData.StepID >= 9 && FCVerificationStatus == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "Y" && !reg.CheckFCVerificationStatus(objSessionData.PID))
                    {
                        tblPasword.Visible = true;
                        tblOtp.Visible = false;
                    }
                    else
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = false;
                        if (FCVerificationStatus == "P")
                        {
                            shInfo.SetMessage("You have Selected Physical Scrutiny Mode, You don't have permission for Lock and Unlock Application Form", ShowMessageType.Information);
                            tblPasword.Visible = false;
                            tblOtp.Visible = false;
                        }
                        else if (objSessionData.StepID < 9)
                        {
                            shInfo.SetMessage("Complete your Application form.", ShowMessageType.Information);
                            tblPasword.Visible = false;
                            tblOtp.Visible = false;
                        }
                        else if (reg.GetApplicationLockStatus(objSessionData.PID) == "N")
                        {
                            shInfo.SetMessage("Application form is not locked.", ShowMessageType.Information);
                            tblPasword.Visible = false;
                            tblOtp.Visible = false;
                        }
                        else
                        {
                            shInfo.SetMessage("Raise the grievance for Unlock the ApplicaitonForm", ShowMessageType.Information);
                            tblPasword.Visible = false;
                            tblOtp.Visible = false;
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
                if (txtOneTimePassword.Text.Length == 0)
                {
                    shInfo.SetMessage("Enter the OTP", ShowMessageType.Information);
                }
                else
                {
                    if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, (int)SynCommon.TemplateSystemType.OTPApplicationFormUnlock))
                    {
                        if (reg.UnLockApplicationFormByCandidate(objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = objSessionData.PID;
                            sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                            sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                            sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ApplicationFormUnlock);


                            Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx");
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                        }
                        btnCall.Visible = false;
                    }
                    else
                    {
                        shInfo.SetMessage("OTP is Invalid.", ShowMessageType.Information);
                        this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
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
                DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                if (ApplicationFormStatus == 'A' && (FCVerificationStatus == 'P' || FCVerificationStatus == 'C'))
                {
                    shInfo.SetMessage("Your Application Form is Verified and Confirmed by SC. To Unlock Application Form Raise the Grievance.", ShowMessageType.Information);
                }
                else if (ApplicationFormStatus == 'I' && FCVerificationStatus == 'N')
                {

                    shInfo.SetMessage("Your Application Form is not Complete, so You Can't Unlock Application Form.", ShowMessageType.Information);
                }
                else if(ApplicationFormStatus == 'C' && FCVerificationStatus =='P' )
                {
                    shInfo.SetMessage("Your Application Form Picked by SC for E-Scrutiny, so You Can't Unlock Application Form.", ShowMessageType.Information);
                }
                else
                {
                    Int64 result = reg.authenticateCandidateLogin(Session["UserLoginID"].ToString(), DataEncryption.EncryptDataByHashSHA1(txtPassword.Text));
                    if (result > 0)
                    {

                        if (Global.IsOTPVerificationRequiredForConfirmApplicationForm == 1)
                        {
                            tblPasword.Visible = false;
                            tblOtp.Visible = true;
                            hdnPassword.Value = txtPassword.Text;
                            btnCall.Visible = true;

                            long PID = objSessionData.PID;
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            sMSTemplate.PID = PID;
                            SynCommon synCommon = new SynCommon();
                            if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OTPApplicationFormUnlock))
                            {
                                trMobileNo.Visible = true;
                                lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID).ToString())).ToString();
                            }
                            this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                        }
                        else
                        {
                            if (reg.UnLockApplicationFormByCandidate(objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                            {
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = objSessionData.PID;
                                sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate.CurrentDateTime = DateTime.Now.ToString();

                                if (Global.SendSMSToCandidate == 1)
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ApplicationFormUnlock);

                                //if (objSessionData.StepID < 9)
                                //{
                                //    objSessionData.StepID = 10;
                                //}

                                //if (objSessionData.ApplicationFormStatus == 'C')
                                //{
                                //    objSessionData.ApplicationFormStatus = 'S';
                                //}
                                
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
        protected void btnCall_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                string mobno = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID));

                SMS objSMS = new SMS();
                objSMS.voiceCallOTP(mobno);
                this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemouts();</script>"));
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }


    }
}