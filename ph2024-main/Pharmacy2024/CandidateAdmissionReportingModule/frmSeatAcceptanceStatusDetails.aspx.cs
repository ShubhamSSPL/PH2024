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

namespace Pharmacy2024.CandidateAdmissionReportingModule
{
    public partial class frmSeatAcceptanceStatusDetails : System.Web.UI.Page
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
            if (Global.ARCReporting == 0)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx");
            }
         //   Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx");
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    if (reg.isCandidateEligibleForAdmission(objSessionData.PID))
                    {
                        if (reg.CheckSelfVerificationIsDone(objSessionData.PID))
                        {
                            Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx");
                        }
                        if (reg.CheckCandidateinAllotmentCancellationRemark(objSessionData.PID))
                        {
                            //shInfo.SetMessage("Your Allotment is Cancelled you can't give Seat Acceptance.", ShowMessageType.Information);
                            shInfo.Visible = true;
                            string str = "Your Allotment is Cancelled you can't give Seat Acceptance";
                            Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx?str=" + str);
                        }
                        DataSet ds = reg.GetSelfVerificationstatus(objSessionData.PID);
                        string selfVerificationStatus = "";
                        Int16 IsAllotmentCancellationRequired = 0;
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                selfVerificationStatus = ds.Tables[0].Rows[0]["IsGrivanceRaised"].ToString();
                                IsAllotmentCancellationRequired = Convert.ToInt16(ds.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString());
                            }
                        }
                        if (IsAllotmentCancellationRequired == 1)
                        {
                            if (selfVerificationStatus == "P" || selfVerificationStatus == "A" || selfVerificationStatus == "Y")
                                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx");
                        }
                        string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(objSessionData.PID);
                        if (SeatAcceptanceConfirmationStatus == "Y")
                        {
                            Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx");
                        }
                        else if (SeatAcceptanceConfirmationStatus == "C")
                        {
                            if (!reg.isEligibleForSeatAcceptance(objSessionData.PID, Global.CAPRound))
                            {
                                Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx");
                            }
                        }
                        else
                        {
                            if (!reg.isEligibleForSeatAcceptance(objSessionData.PID, Global.CAPRound))
                            {
                                Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx");
                            }
                        }
                        PageLoad();
                    }
                    else
                    {
                        ContentTable2.Visible = false;
                        contentOTPVerify.Visible = false;
                        shInfo.SetMessage("The candidate is not Eligible for Seat Acceptance", ShowMessageType.Information);
                    }

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnBettermentNotFreeze_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                ViewState["SeatAcceptanceStatus"] = lblEligibilityRemark.Text = "Betterment (Not Freeze)";
                contentOTPVerify.Visible = true;
                //tblBettermentNotFreeze.Visible = true;
                tblBettermentNotFreeze.Visible = false;
                tblFreeze.Visible = false;
                tblAutoFreeze.Visible = false;
                tblOtp.Visible = false;
                btnBettermentNotFreeze.Visible = false;
                tblPasword.Visible = true;

                //string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(objSessionData.PID);

                //if (SeatAcceptanceConfirmationStatus != "Y")
                //{
                //    if (reg.saveSeatAcceptanceStatusDetails(objSessionData.PID, ViewState["SeatAcceptanceStatus"].ToString(), Global.CAPRound, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                //    {
                //        Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceForm.aspx");
                //    }
                //    else
                //    {
                //        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                //    }
                //}
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnFreeze_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                ViewState["SeatAcceptanceStatus"] = lblEligibilityRemark.Text = "Freeze";
                contentOTPVerify.Visible = true;
                tblBettermentNotFreeze.Visible = false;
                tblFreeze.Visible = true;
                tblAutoFreeze.Visible = false;
                tblOtp.Visible = false;
                btnFreeze.Visible = false;
                tblPasword.Visible = true;

                //SessionData objSessionData = (SessionData)Session["SessionData"];
                //string SeatAcceptanceStatus = "Freeze";
                //string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(objSessionData.PID);

                //if (SeatAcceptanceConfirmationStatus != "Y")
                //{
                //    if (reg.saveSeatAcceptanceStatusDetails(objSessionData.PID, SeatAcceptanceStatus, Global.CAPRound, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                //    {
                //        SMSTemplate sMSTemplate = new SMSTemplate();
                //        SynCommon synCommon = new SynCommon();
                //        sMSTemplate.PID = objSessionData.PID;
                //        sMSTemplate.SeatAcceptanceStatus = ViewState["SeatAcceptanceStatus"].ToString();
                //        sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                //        sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                //        sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                //        sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                //        if (Global.SendSMSToCandidate == 1)
                //            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.SeatAceptanceVerify);
                //        Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceForm.aspx");
                //    }
                //    else
                //    {
                //        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                //    }
              //}
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnAutoFreeze_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                ViewState["SeatAcceptanceStatus"] = lblEligibilityRemark.Text = "Auto Freeze";
                contentOTPVerify.Visible = false;
                tblBettermentNotFreeze.Visible = false;
                tblFreeze.Visible = false;
                tblAutoFreeze.Visible = true;
                tblOtp.Visible = false;
                btnAutoFreeze.Visible = false;
                SessionData objSessionData = (SessionData)Session["SessionData"];
                string SeatAcceptanceStatus = "Auto Freeze";
                string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(objSessionData.PID);

                if (SeatAcceptanceConfirmationStatus != "Y")
                {
                    if (reg.saveSeatAcceptanceStatusDetails(objSessionData.PID, SeatAcceptanceStatus, Global.CAPRound, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        SynCommon synCommon = new SynCommon();
                        sMSTemplate.PID = objSessionData.PID;
                        sMSTemplate.SeatAcceptanceStatus = ViewState["SeatAcceptanceStatus"].ToString();
                        sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                        sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                        sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                        sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                        if (Global.SendSMSToCandidate == 1)
                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.SeatAceptanceVerify);
                        Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceForm.aspx");
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        private void PageLoad()
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            Int32 PreferenceNoAllotted = reg.getPreferenceNoAllotted(objSessionData.PID, Global.CAPRound);

            if (PreferenceNoAllotted == 0)
            {
                Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx");
            }
            else if (PreferenceNoAllotted == 1)
            {
                tblBettermentNotFreeze.Visible = false;
                tblFreeze.Visible = false;
                tblAutoFreeze.Visible = true;
            }
            else if (PreferenceNoAllotted > 1)
            {
                //tblBettermentNotFreeze.Visible = true;
                tblBettermentNotFreeze.Visible = false;
                tblFreeze.Visible = true;
                tblAutoFreeze.Visible = false;
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            PageLoad();
            btnAutoFreeze.Visible = true;
            btnBettermentNotFreeze.Visible = true;
            btnFreeze.Visible = true;
            tblPasword.Visible = true;
            contentOTPVerify.Visible = false;
        }
        protected void btnCall_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            string mobno = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID));

            SMS objSMS = new SMS();
            objSMS.voiceCallOTP(mobno);
            this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemouts();</script>"));
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
                    if (ViewState["SeatAcceptanceStatus"] != null)
                    {
                        if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, (int)SynCommon.TemplateSystemType.OTPSeatAcceptance))
                        {
                            string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(objSessionData.PID);

                            if (SeatAcceptanceConfirmationStatus != "Y")
                            {
                                if (reg.saveSeatAcceptanceStatusDetails(objSessionData.PID, ViewState["SeatAcceptanceStatus"].ToString(), Global.CAPRound, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                {
                                    SMSTemplate sMSTemplate = new SMSTemplate();
                                    SynCommon synCommon = new SynCommon();
                                    sMSTemplate.PID = objSessionData.PID;
                                    sMSTemplate.SeatAcceptanceStatus = ViewState["SeatAcceptanceStatus"].ToString();
                                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                    sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                                    if (Global.SendSMSToCandidate == 1)
                                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.SeatAceptanceVerify);
                                    Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceFeeDetails.aspx");
                                }
                                else
                                {
                                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                }
                                btnCall.Visible = false;
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("OTP is Invalid.", ShowMessageType.Information);
                            this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Please give your SeatAcceptance Status.", ShowMessageType.Information);
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
                if (result > 0)
                {
                    if (true)
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = true;
                        hdnPassword.Value = txtPassword.Text;
                        btnCall.Visible = true;
                        long PID = objSessionData.PID;
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        sMSTemplate.PID = PID;
                        SynCommon synCommon = new SynCommon();
                        if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OTPSeatAcceptance))
                        {
                            trMobileNo.Visible = true;
                            lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID).ToString())).ToString();
                        }
                        this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                    }
                    else
                    {

                    }
                }
                else
                {
                    shInfo.SetMessage("Password does not Match.", ShowMessageType.Information);
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