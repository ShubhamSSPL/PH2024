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

namespace Pharmacy2024.ApplicationPages
{
    public partial class WelcomePageCandidate : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;
        public string strVerificationMode = "";
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
            if (!IsPostBack)
            {
                try
                {
                    DataSet dsLoginDetails = reg.getLoginDetails(Session["UserLoginID"].ToString(), Convert.ToInt32(Session["UserTypeID"]));
                    if (dsLoginDetails.Tables[0].Rows.Count > 0)
                    {
                        lblLoginID.Text = dsLoginDetails.Tables[0].Rows[0]["LoginID"].ToString();
                        lblUserName.Text = dsLoginDetails.Tables[0].Rows[0]["UserName"].ToString();
                        lblUserType.Text = dsLoginDetails.Tables[0].Rows[0]["UserTypeName"].ToString();
                        DateTime CurrentLoginDateTime = Convert.ToDateTime(dsLoginDetails.Tables[0].Rows[0]["CurrentLoginDateTime"].ToString());
                        lblCurrentLoginTime.Text = CurrentLoginDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", CurrentLoginDateTime);
                        DateTime LastLoginDateTime = Convert.ToDateTime(dsLoginDetails.Tables[0].Rows[0]["LastLoginDateTime"].ToString());
                        lblPreviousLoginTime.Text = LastLoginDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", LastLoginDateTime);
                        lblIPAddress.Text = UserInfo.GetIPAddress();
                    }

                    SessionData objSessionData = new SessionData();
                    if (Session["SessionData"] == null)
                    {
                        Session["SessionData"] = objSessionData = reg.getSessionDataForCandidate(Convert.ToInt64(Session["UserID"]));
                    }
                    else
                    {
                        objSessionData = (SessionData)Session["SessionData"];
                    }

                    Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(objSessionData.PID);
                    if (ApplicationFeeToBePaid > 0 && objSessionData.StepID > 9)
                    {
                        shInfo.SetMessage("Please pay the difference Fee of Rs. 200/- by using link 'Pay Application Form Fee Difference'.", ShowMessageType.Information);
                        tblPayDifferenceFee.Visible = true;
                    }
                    else
                    {
                        tblPayDifferenceFee.Visible = false;
                    }
                    //***********For E-Vrification Un comment code******************

                    //if (reg.CheckBankDetailsStatus(objSessionData.PID) && (objSessionData.ApplicationFormStatus == 'C' || objSessionData.ApplicationFormStatus == 'A'))
                    //{
                    //    if (objSessionData.BankDetailsSkip != 'Y')
                    //        Response.Redirect("../CandidateModule/frmBankDetails.aspx", true);
                    //}
                    strVerificationMode = reg.CheckCandidateFCVerificationFor(objSessionData.PID);
                    if (Global.CurrentScrutinyMode == "Both")
                    {

                        if (strVerificationMode == "" || strVerificationMode == " ")
                        {
                            Response.Redirect("../CandidateModule/FCSlotBooking.aspx", true);
                        }
                        if (strVerificationMode == "P" && reg.CheckIsSlotBooked(objSessionData.PID))
                        {
                            Response.Redirect("../CandidateModule/FCSlotBooking.aspx", true);
                        }
                    }

                    if (!reg.isCandidateNameAppearedInFinalMeritList(objSessionData.PID))
                    {
                        tblApplicationFormStatus.Visible = true;
                        tblApplicationFormInstructions.Visible = true;
                        if (objSessionData.ApplicationFormStatus != 'A')
                        {
                            tblProceedToCompleteApplicationForm.Visible = true;
                        }

                        gvApplicationFormLinksStatus.DataSource = reg.getApplicationFormLinksStatus(objSessionData.PID);
                        gvApplicationFormLinksStatus.DataBind();

                        if (Global.IsDocumentUploadRequired == 1)
                        {
                            tblDocumentUploadStatus.Visible = true;

                            gvRequiredDocumentsUploadStatus.DataSource = reg.getRequiredDocumentsUploadStatusReportForCandidate(objSessionData.PID);
                            gvRequiredDocumentsUploadStatus.DataBind();
                        }
                    }
                    else
                    {
                        if (Global.CurrentCAPRoundForOptionFormFilling == 1 && DateTime.Now >= Global.OptionFormFillingCAPRound1StartDateTime && DateTime.Now <= Global.OptionFormFillingCAPRound1EndDateTime)
                        {
                            tblOptionForm.Visible = true;
                            trOptionFormStatusCAPRound1.Visible = true;

                            if (objSessionData.EligibleForCAPRound1 == 0)
                            {
                                trOptionFormInstructionsCAPRound1.Visible = false;
                                trProceedToCompleteOptionForm.Visible = false;

                                lblOptionFormStatusCAPRound1.ForeColor = System.Drawing.Color.Red;
                                lblOptionFormStatusCAPRound1.Text = "You are Not Eligible to Submit Option Form for CAP Round-I";
                            }
                            else
                            {
                                if (objSessionData.OptionFormStatusCAPRound1 == 'I')
                                {
                                    trOptionFormInstructionsCAPRound1.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = true;

                                    lblOptionFormStatusCAPRound1.ForeColor = System.Drawing.Color.Red;
                                    lblOptionFormStatusCAPRound1.Text = "Incomplete Option Form for CAP Round-I";
                                }
                                else if (objSessionData.OptionFormStatusCAPRound1 == 'C')
                                {
                                    trOptionFormInstructionsCAPRound1.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = true;

                                    lblOptionFormStatusCAPRound1.ForeColor = System.Drawing.Color.Red;
                                    lblOptionFormStatusCAPRound1.Text = "Complete Option Form for CAP Round-I. Now confirm it";
                                }
                                else if (objSessionData.OptionFormStatusCAPRound1 == 'A')
                                {
                                    trOptionFormInstructionsCAPRound1.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = false;

                                    lblOptionFormStatusCAPRound1.ForeColor = System.Drawing.Color.Green;
                                    lblOptionFormStatusCAPRound1.Text = "Option Form for CAP Round-I is Confirmed";
                                }
                            }

                            if (Request.QueryString["Err"] != null)
                            {
                                if (Request.QueryString["Err"].ToString() == "1")
                                {
                                    shInfo.SetMessage("You are NOT ELIGIBLE to Submit Option Form for CAP Round-I.", ShowMessageType.Information);
                                }
                                else if (Request.QueryString["Err"].ToString() == "2")
                                {
                                    if (DateTime.Now < Global.OptionFormFillingCAPRound1StartDateTime)
                                    {
                                        shInfo.SetMessage("Option Form Filling is Not Started for CAP Round-I.", ShowMessageType.Information);
                                    }
                                    else if (DateTime.Now > Global.OptionFormFillingCAPRound1EndDateTime)
                                    {
                                        shInfo.SetMessage("Option Form Filling is Closed for CAP Round-I.", ShowMessageType.Information);
                                    }
                                }
                            }
                        }
                        else if (Global.CurrentCAPRoundForOptionFormFilling == 2 && DateTime.Now >= Global.OptionFormFillingCAPRound2StartDateTime && DateTime.Now <= Global.OptionFormFillingCAPRound2EndDateTime)
                        {
                            tblOptionForm.Visible = true;
                            trOptionFormStatusCAPRound2.Visible = true;

                            if (objSessionData.EligibleForCAPRound2 == 0)
                            {
                                trOptionFormInstructionsCAPRound2.Visible = false;
                                trProceedToCompleteOptionForm.Visible = false;

                                lblOptionFormStatusCAPRound2.ForeColor = System.Drawing.Color.Red;
                                lblOptionFormStatusCAPRound2.Text = "You are Not Eligible to Submit Option Form for CAP Round-II";
                            }
                            else
                            {
                                if (objSessionData.OptionFormStatusCAPRound2 == 'I')
                                {
                                    trOptionFormInstructionsCAPRound2.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = true;

                                    lblOptionFormStatusCAPRound2.ForeColor = System.Drawing.Color.Red;
                                    lblOptionFormStatusCAPRound2.Text = "Incomplete Option Form for CAP Round-II";
                                }
                                else if (objSessionData.OptionFormStatusCAPRound2 == 'C')
                                {
                                    trOptionFormInstructionsCAPRound2.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = true;

                                    lblOptionFormStatusCAPRound2.ForeColor = System.Drawing.Color.Red;
                                    lblOptionFormStatusCAPRound2.Text = "Complete Option Form for CAP Round-II. Now confirm it";
                                }
                                else if (objSessionData.OptionFormStatusCAPRound2 == 'A')
                                {
                                    trOptionFormInstructionsCAPRound2.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = false;

                                    lblOptionFormStatusCAPRound2.ForeColor = System.Drawing.Color.Green;
                                    lblOptionFormStatusCAPRound2.Text = "Option Form for CAP Round-II is Confirmed";
                                }
                            }

                            if (Request.QueryString["Err"] != null)
                            {
                                if (Request.QueryString["Err"].ToString() == "1")
                                {
                                    shInfo.SetMessage("You are NOT ELIGIBLE to Submit Option Form for CAP Round-II.", ShowMessageType.Information);
                                }
                                else if (Request.QueryString["Err"].ToString() == "2")
                                {
                                    if (DateTime.Now < Global.OptionFormFillingCAPRound2StartDateTime)
                                    {
                                        shInfo.SetMessage("Option Form Filling is Not Started for CAP Round-II.", ShowMessageType.Information);
                                    }
                                    else if (DateTime.Now > Global.OptionFormFillingCAPRound2EndDateTime)
                                    {
                                        shInfo.SetMessage("Option Form Filling is Closed for CAP Round-II.", ShowMessageType.Information);
                                    }
                                }
                            }
                        }
                        else if (Global.CurrentCAPRoundForOptionFormFilling == 3 && DateTime.Now >= Global.OptionFormFillingCAPRound3StartDateTime && DateTime.Now <= Global.OptionFormFillingCAPRound3EndDateTime)
                        {
                            tblOptionForm.Visible = true;
                            trOptionFormStatusCAPRound3.Visible = true;

                            if (objSessionData.EligibleForCAPRound3 == 0)
                            {
                                trOptionFormInstructionsCAPRound3.Visible = false;
                                trProceedToCompleteOptionForm.Visible = false;

                                lblOptionFormStatusCAPRound3.ForeColor = System.Drawing.Color.Red;
                                lblOptionFormStatusCAPRound3.Text = "You are Not Eligible to Submit Option Form for CAP Round-III";
                            }
                            else
                            {
                                if (objSessionData.OptionFormStatusCAPRound3 == 'I')
                                {
                                    trOptionFormInstructionsCAPRound3.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = true;

                                    lblOptionFormStatusCAPRound3.ForeColor = System.Drawing.Color.Red;
                                    lblOptionFormStatusCAPRound3.Text = "Incomplete Option Form for CAP Round-III";
                                }
                                else if (objSessionData.OptionFormStatusCAPRound3 == 'C')
                                {
                                    trOptionFormInstructionsCAPRound3.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = true;

                                    lblOptionFormStatusCAPRound3.ForeColor = System.Drawing.Color.Red;
                                    lblOptionFormStatusCAPRound3.Text = "Complete Option Form for CAP Round-III. Now confirm it";
                                }
                                else if (objSessionData.OptionFormStatusCAPRound3 == 'A')
                                {
                                    trOptionFormInstructionsCAPRound3.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = false;

                                    lblOptionFormStatusCAPRound3.ForeColor = System.Drawing.Color.Green;
                                    lblOptionFormStatusCAPRound3.Text = "Option Form for CAP Round-III is Confirmed";
                                }
                            }

                            if (Request.QueryString["Err"] != null)
                            {
                                if (Request.QueryString["Err"].ToString() == "1")
                                {
                                    shInfo.SetMessage("You are NOT ELIGIBLE to Submit Option Form for CAP Round-III.", ShowMessageType.Information);
                                }
                                else if (Request.QueryString["Err"].ToString() == "2")
                                {
                                    if (DateTime.Now < Global.OptionFormFillingCAPRound3StartDateTime)
                                    {
                                        shInfo.SetMessage("Option Form Filling is Not Started for CAP Round-III.", ShowMessageType.Information);
                                    }
                                    else if (DateTime.Now > Global.OptionFormFillingCAPRound3EndDateTime)
                                    {
                                        shInfo.SetMessage("Option Form Filling is Closed for CAP Round-III.", ShowMessageType.Information);
                                    }
                                }
                            }
                        }
                        else if (Global.CurrentCAPRoundForOptionFormFilling == 4 && DateTime.Now >= Global.OptionFormFillingCAPRound4StartDateTime && DateTime.Now <= Global.OptionFormFillingCAPRound4EndDateTime)
                        {
                            tblOptionForm.Visible = true;
                            trOptionFormStatusCAPRound4.Visible = true;

                            if (objSessionData.EligibleForCAPRound4 == 0)
                            {
                                trOptionFormInstructionsCAPRound4.Visible = false;
                                trProceedToCompleteOptionForm.Visible = false;

                                lblOptionFormStatusCAPRound4.ForeColor = System.Drawing.Color.Red;
                                lblOptionFormStatusCAPRound4.Text = "You are Not Eligible to Submit Option Form for Additional Round for Government / Govt. Aided Institutes";
                            }
                            else
                            {
                                if (objSessionData.OptionFormStatusCAPRound4 == 'I')
                                {
                                    trOptionFormInstructionsCAPRound4.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = true;

                                    lblOptionFormStatusCAPRound4.ForeColor = System.Drawing.Color.Red;
                                    lblOptionFormStatusCAPRound4.Text = "Incomplete Option Form for Additional Round for Government / Govt. Aided Institutes";
                                }
                                else if (objSessionData.OptionFormStatusCAPRound4 == 'C')
                                {
                                    trOptionFormInstructionsCAPRound4.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = true;

                                    lblOptionFormStatusCAPRound4.ForeColor = System.Drawing.Color.Red;
                                    lblOptionFormStatusCAPRound4.Text = "Complete Option Form for Additional Round for Government / Govt. Aided Institutes. Now confirm it";
                                }
                                else if (objSessionData.OptionFormStatusCAPRound4 == 'A')
                                {
                                    trOptionFormInstructionsCAPRound4.Visible = true;
                                    trProceedToCompleteOptionForm.Visible = false;

                                    lblOptionFormStatusCAPRound4.ForeColor = System.Drawing.Color.Green;
                                    lblOptionFormStatusCAPRound4.Text = "Option Form for Additional Round for Government / Govt. Aided Institutes is Confirmed";
                                }
                            }

                            if (Request.QueryString["Err"] != null)
                            {
                                if (Request.QueryString["Err"].ToString() == "1")
                                {
                                    shInfo.SetMessage("You are NOT ELIGIBLE to Submit Option Form for Additional Round for Government/Govt. Aided Institutes.", ShowMessageType.Information);
                                }
                                else if (Request.QueryString["Err"].ToString() == "2")
                                {
                                    if (DateTime.Now < Global.OptionFormFillingCAPRound4StartDateTime)
                                    {
                                        shInfo.SetMessage("Option Form Filling is Not Started for Additional Round for Government/Govt. Aided Institutes.", ShowMessageType.Information);
                                    }
                                    else if (DateTime.Now > Global.OptionFormFillingCAPRound4EndDateTime)
                                    {
                                        shInfo.SetMessage("Option Form Filling is Closed for Additional Round for Government/Govt. Aided Institutes.", ShowMessageType.Information);
                                    }
                                }
                            }
                        }

                        if
                        (
                            (Global.CurrentCAPRoundForARCReporting == 1 && DateTime.Now >= Global.ARCReportingCAPRound1StartDateTime && DateTime.Now <= Global.ARCReportingCAPRound1EndDateTime) ||
                            (Global.CurrentCAPRoundForARCReporting == 2 && DateTime.Now >= Global.ARCReportingCAPRound2StartDateTime && DateTime.Now <= Global.ARCReportingCAPRound2EndDateTime) ||
                            (Global.CurrentCAPRoundForARCReporting == 3 && DateTime.Now >= Global.ARCReportingCAPRound3StartDateTime && DateTime.Now <= Global.ARCReportingCAPRound3EndDateTime) ||
                            (Global.CurrentCAPRoundForARCReporting == 4 && DateTime.Now >= Global.ARCReportingCAPRound4StartDateTime && DateTime.Now <= Global.ARCReportingCAPRound4EndDateTime)
                        )
                        {
                            tblSeatAcceptanceStatus.Visible = true;
                            DataSet dsCAD = reg.getCurrentAllotmentDetails(objSessionData.PID);
                            string BenefitTaken = reg.getBenefitTakenByCandidate(objSessionData.PID, 0);
                            DataSet seatAcceptanceGrivance = reg.GetSeatAcceptanceGrivanceStatusByPID(objSessionData.PID);
                            string IsGrivanceRaised = "";
                            Int16 IsAllotmentCancellationRequired = 0;
                            if (seatAcceptanceGrivance.Tables[0].Rows.Count > 0)
                            {
                                IsGrivanceRaised = seatAcceptanceGrivance.Tables[0].Rows[0]["IsGrivanceRaised"].ToString();
                                IsAllotmentCancellationRequired = Convert.ToInt16(seatAcceptanceGrivance.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString());
                                if (IsGrivanceRaised == "Y" || IsGrivanceRaised == "P" || (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 1))
                                {
                                    trSeatAcceptanceGrivanceStatus.Visible = true;
                                    lblFCCode.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["AFCCode"].ToString();
                                    lblFCName.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["AFCName"].ToString();
                                    lblCoordinatorName.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["CoordinatorName"].ToString();
                                    lblCoordinatorMobileNo.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["CoordinatorMobileNo"].ToString();
                                    lblCoordinatorAltMobileNo.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["CoordinatorAltMobileNo"].ToString();
                                    lblGrivanceStatus.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["GrivanceStatus"].ToString();
                                    lblFCMessage.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["FCMessage"].ToString();
                                    lblFCMessage.ForeColor = System.Drawing.Color.Green;
                                }
                                else if (IsGrivanceRaised == "R")
                                {
                                    trSeatAcceptanceGrivanceStatus.Visible = true;
                                    lblFCCode.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["AFCCode"].ToString();
                                    lblFCName.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["AFCName"].ToString();
                                    lblCoordinatorName.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["CoordinatorName"].ToString();
                                    lblCoordinatorMobileNo.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["CoordinatorMobileNo"].ToString();
                                    lblCoordinatorAltMobileNo.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["CoordinatorAltMobileNo"].ToString();
                                    lblGrivanceStatus.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["GrivanceStatus"].ToString();
                                    lblFCMessage.Text = seatAcceptanceGrivance.Tables[0].Rows[0]["FCMessage"].ToString();
                                    lblFCMessage.ForeColor = System.Drawing.Color.Green;
                                }
                            }

                            if (dsCAD.Tables[0].Rows.Count > 0)
                            {
                                if (BenefitTaken == "")
                                {
                                    //lblBenefitTaken.Text = "NA";
                                    trBenefitTaken.Visible = false;
                                }
                                else
                                {
                                    lblBenefitTaken.Text = BenefitTaken;
                                }

                                tblAllotmentDetails.Visible = true;
                                lblInstituteAllotted.Text = dsCAD.Tables[0].Rows[0]["InstituteAllotted"].ToString();
                                lblCourseAllotted.Text = dsCAD.Tables[0].Rows[0]["CourseAllotted"].ToString();
                                lblSeatTypeAllotted.Text = dsCAD.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                                lblPreferenceNoAllotted.Text = dsCAD.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString();

                                trCAP2Betterment.Visible = false;

                                if (IsGrivanceRaised == "" || IsGrivanceRaised == "N" || IsGrivanceRaised == "R" || (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 0))
                                {
                                    string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(objSessionData.PID);
                                    if (SeatAcceptanceConfirmationStatus == "Y")
                                    {
                                        btnSeatAcceptanceStep1.Text = "Complete";
                                        btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        btnSeatAcceptanceStep1.Enabled = false;

                                        btnSeatAcceptanceStep2.Text = "Complete";
                                        btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        btnSeatAcceptanceStep2.Enabled = false;

                                        btnSeatAcceptanceStep3.Text = "Complete";
                                        btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        btnSeatAcceptanceStep3.Enabled = false;

                                        btnSeatAcceptanceStep4.Text = "Complete";
                                        btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);

                                        DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetailsForBettermentCandidate(objSessionData.PID);
                                        string SeatAcceptanceStatusDetails = "";
                                        int SACAPRound = 0;
                                        if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                                        {
                                            SeatAcceptanceStatusDetails = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["SeatAcceptanceStatus"].ToString();
                                            SACAPRound = Convert.ToInt32(dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["CAPRound"].ToString());
                                        }
                                        if (Global.CAPRound == SACAPRound && dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                                        {
                                            if (reg.GetSeatAcceptanceCAPRoundWise(objSessionData.PID, Global.CAPRound))
                                            {
                                                if (Global.CAPRound == 2)
                                                {
                                                    lblSeatAccetanceStatus.Text = "Seat Acceptance Status Of Previous Round";
                                                    lblStep2.Text = "Seat Acceptance Option (Freeze/Betterment (Not Freeze)) for CAP-I";
                                                }
                                                else if (Global.CAPRound == 3)
                                                {
                                                    lblSeatAccetanceStatus.Text = "Seat Acceptance Status Of Previous Round";
                                                    lblStep2.Text = "Seat Acceptance Option (Freeze/Betterment (Not Freeze)) for CAP-II";
                                                }

                                                btnSeatAcceptanceStep5.Text = "Complete";
                                                btnSeatAcceptanceStep5.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                                btnSeatAcceptanceStep5.Enabled = false;
                                                trCAP2Betterment.Visible = true;
                                            }
                                            else
                                            {
                                                trCAP2Betterment.Visible = false;
                                            }

                                        }
                                        else
                                        {
                                            //string strAdmissionDetails = reg.getAdmissionDetails(objSessionData.PID);
                                            if (reg.GetSeatAcceptanceStatusforBettermentcandidate(objSessionData.PID))
                                            {
                                                if (Global.CAPRound == 2)
                                                {
                                                    lblStep2.Text = "Seat Acceptance Option (Freeze/Betterment (Not Freeze)) for CAP-I";
                                                    lblSeatAccetanceStatus.Text = "Seat Acceptance Status Of Previous Round";
                                                }
                                                else if (Global.CAPRound == 3)
                                                {
                                                    lblStep2.Text = "Seat Acceptance Option (Freeze/Betterment (Not Freeze)) for CAP-II";
                                                    lblSeatAccetanceStatus.Text = "Seat Acceptance Status Of Previous Round";
                                                }
                                                btnSeatAcceptanceStep5.Text = "Incomplete";
                                                btnSeatAcceptanceStep5.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                                btnSeatAcceptanceStep5.Enabled = true;
                                                trCAP2Betterment.Visible = true;
                                            }
                                            else
                                            {
                                                trCAP2Betterment.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!reg.CheckSelfVerificationIsDone(objSessionData.PID))
                                        {
                                            if (reg.CheckCandidateinAllotmentCancellationRemark(objSessionData.PID))
                                            {
                                                btnSeatAcceptanceStep1.Text = "Your Allotment is Cancelled";
                                                btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                                btnSeatAcceptanceStep1.Enabled = false;
                                                btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                                btnSeatAcceptanceStep1.Enabled = false;
                                                btnSeatAcceptanceStep2.Text = "Incomplete";
                                                btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                                btnSeatAcceptanceStep2.Enabled = false;
                                                btnSeatAcceptanceStep3.Text = "Incomplete";
                                                btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                                btnSeatAcceptanceStep3.Enabled = false;
                                                btnSeatAcceptanceStep4.Text = "Incomplete";
                                                btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                                btnSeatAcceptanceStep4.Enabled = false;
                                               
                                            }
                                            else
                                            {
                                                btnSeatAcceptanceStep1.Text = "Complete";
                                                btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                            }

                                            
                                        }
                                        else
                                        {
                                            btnSeatAcceptanceStep1.Text = "Incomplete";
                                            btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        }
                                        DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(objSessionData.PID);
                                        if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                                        {
                                            btnSeatAcceptanceStep2.Text = "Complete";
                                            btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        }
                                        else
                                        {
                                            btnSeatAcceptanceStep2.Text = "Incomplete";
                                            btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        }

                                        DataSet dsSeatAcceptanceFeeDetails = reg.getSeatAcceptanceFeeList(objSessionData.PID, "Seat Acceptance Fee");
                                        if (dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0)
                                        {
                                            btnSeatAcceptanceStep3.Text = "Complete";
                                            btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        }
                                        else
                                        {
                                            btnSeatAcceptanceStep3.Text = "Incomplete";
                                            btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        }
                                        if (SeatAcceptanceConfirmationStatus == "Y" && dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0)
                                        {
                                            btnSeatAcceptanceStep4.Text = "Complete";
                                            btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        }
                                        else
                                        {
                                            btnSeatAcceptanceStep4.Text = "Incomplete";
                                            btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                            if (dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0 && dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                                                btnSeatAcceptanceStep4.Enabled = true;
                                        }
                                            
                                    }
                                }
                                else
                                {
                                    if (IsGrivanceRaised == "Y")
                                    {
                                        btnSeatAcceptanceStep1.Text = "Grievance Is Raised";
                                    }
                                    if (IsGrivanceRaised == "P")
                                    {
                                        btnSeatAcceptanceStep1.Text = "Grievance is Picked for Verification";
                                    }
                                    if (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 1)
                                    {
                                        btnSeatAcceptanceStep1.Text = "Your Allotment is Cancelled";
                                    }
                                    if (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 0)
                                    {
                                        btnSeatAcceptanceStep1.Text = "Your Grievance is Approved";
                                    }
                                    if (reg.CheckCandidateinAllotmentCancellationRemark(objSessionData.PID))
                                    {
                                        btnSeatAcceptanceStep1.Text = "Your Allotment is Cancelled";
                                        btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        btnSeatAcceptanceStep1.Enabled = false;
                                    }

                                    btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                    btnSeatAcceptanceStep1.Enabled = false;
                                    btnSeatAcceptanceStep2.Text = "Incomplete";
                                    btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptanceStep2.Enabled = false;
                                    btnSeatAcceptanceStep3.Text = "Incomplete";
                                    btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptanceStep3.Enabled = false;
                                    btnSeatAcceptanceStep4.Text = "Incomplete";
                                    btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptanceStep4.Enabled = false;
                                }
                                if (Global.CurrentCAPRoundForARCReporting == 1 &&
                                    DateTime.Now >= Global.ARCReportingCAPRound1StartDateTime &&
                                    DateTime.Now <= Global.ARCReportingCAPRound1EndDateTime)
                                {
                                    trInstructionsARCReportingCAPRound1.Visible = true;
                                }
                                else if (Global.CurrentCAPRoundForARCReporting == 2 &&
                                         DateTime.Now >= Global.ARCReportingCAPRound2StartDateTime &&
                                         DateTime.Now <= Global.ARCReportingCAPRound2EndDateTime)
                                {
                                    trInstructionsARCReportingCAPRound2.Visible = true;
                                }
                                else if (Global.CurrentCAPRoundForARCReporting == 3 &&
                                         DateTime.Now >= Global.ARCReportingCAPRound3StartDateTime &&
                                         DateTime.Now <= Global.ARCReportingCAPRound3EndDateTime)
                                {
                                    trInstructionsARCReportingCAPRound3.Visible = true;
                                }
                                else if (Global.CurrentCAPRoundForARCReporting == 4 &&
                                         DateTime.Now >= Global.ARCReportingCAPRound4StartDateTime &&
                                         DateTime.Now <= Global.ARCReportingCAPRound4EndDateTime)
                                {
                                    trInstructionsARCReportingCAPRound4.Visible = true;
                                }
                            }
                            else
                            {
                                tdSeatAcceptanceStatus.Visible = false;
                                tblNoAllotmentDetails.Visible = true;
                                // trInstructionforNotAllotment.Visible = true;
                                linotAllotted.Visible = true;
                                lblAllotmentStatus.Text = "Not Allotted Till Now.";
                            }
                        }

                        if (Global.DisplayAdmissionStatusInCandidateLogin == 1)
                        {
                            tblAdmissionStatus.Visible = true;
                            DataSet dsCAD = reg.getCurrentAdmissionDetails(objSessionData.PID);

                            if (dsCAD.Tables[0].Rows.Count == 0)
                            {
                                tblNoAdmissionDetails.Visible = true;
                                lblAdmissionStatus.Text = "Not Admitted Till Now.";
                            }
                            else if (dsCAD.Tables[0].Rows.Count == 1)
                            {
                                tblAdmissionDetails.Visible = true;
                                lblInstituteAdmitted.Text = dsCAD.Tables[0].Rows[0]["InstituteAdmitted"].ToString();
                                lblCourseAdmitted.Text = dsCAD.Tables[0].Rows[0]["CourseAdmitted"].ToString();
                                lblSeatTypeAdmitted.Text = dsCAD.Tables[0].Rows[0]["SeatTypeAdmitted"].ToString();
                                lblAdmissionRound.Text = dsCAD.Tables[0].Rows[0]["AdmissionRound"].ToString();
                            }
                            else if (dsCAD.Tables[0].Rows.Count > 1)
                            {
                                tblNoAdmissionDetails.Visible = true;
                                lblAdmissionStatus.Text = "You have been admitted in more then one courses. Please cancel the extra admission.";
                            }
                        }
                    }
                    string AdmissionCategory = reg.GetAdmissionCategory(Convert.ToInt64(objSessionData.PID));
                    if (AdmissionCategory.Contains("$") || AdmissionCategory.Contains("#") || AdmissionCategory.Contains("@"))
                    {
                        trCVCMsg.Visible = true;
                    }
                    else
                    {
                        trCVCMsg.Visible = false;
                    }
                    LoadApplicationFormStatus();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void LoadApplicationFormStatus()
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
            char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
            char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
            char IsLockedByCandidate = Convert.ToChar(statusDs.Tables[0].Rows[0]["IsLockedByCandidate"].ToString());
            char CancelFlag = Convert.ToChar(statusDs.Tables[0].Rows[0]["CancelFlag"].ToString());

            string FCVerificationStatusDate = statusDs.Tables[0].Rows[0]["FCVerificationStatusDate"].ToString();
            string ApplicationFormStatusDate = statusDs.Tables[0].Rows[0]["ApplicationFormStatusDate"].ToString();
            string LockDate = statusDs.Tables[0].Rows[0]["LockDate"].ToString();

            string FCVerificationModifiedBy = statusDs.Tables[0].Rows[0]["FCVerificationModifiedBy"].ToString();
            string ApplicationFormStatusModifiedBy = statusDs.Tables[0].Rows[0]["ApplicationFormStatusModifiedBy"].ToString();

            tblApplicationFormStatus.Visible = true;

            if (strVerificationMode == "E") //For EVerification
            {
                string strMappedFC = "";
                string strMappedTime = "";
                DataSet dsEScr = reg.GetCandidateEFCAllotted(objSessionData.PID);
                if (dsEScr.Tables[0].Rows.Count > 0)
                {
                    strMappedFC = dsEScr.Tables[0].Rows[0]["AFCName"].ToString();
                    strMappedTime = Convert.ToDateTime(dsEScr.Tables[0].Rows[0]["CreatedOn"]).ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", Convert.ToDateTime(dsEScr.Tables[0].Rows[0]["CreatedOn"]));
                }

                if (ApplicationFormStatus == 'I' && FCVerificationStatus == 'N')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is incomplete, Please Fill the Complete Application Form for E-Verification and Confirmation.";
                }
                else if ((ApplicationFormStatus == 'C' || ApplicationFormStatus == 'A') && FCVerificationStatus == 'N')
                {
                    if (reg.CheckFCVerificationStatusForResubmission(objSessionData.PID))
                    {
                        if (IsLockedByCandidate == 'Y')
                        {
                            lblDiscrepancyStatus.Text = "Your Application Form is Completed and Resubmitted to " + strMappedFC + " on " + LockDate + " for Re-E-Verification(E-Scrutiny).";
                            //lblDiscrepancyStatus.Text = "Your Application Form is Completed and Resubmitted to for Re-E-Verification(E-Scrutiny)-It will be verified soon.";
                        }
                        else
                        {
                            lblDiscrepancyStatus.Text = "Your Application Form is Completed and Ready for Resubmission. Please Check the Details once again and Resubmit it for Re-E-Verification(E-Scrutiny).";
                            trReSubmitButton.Visible = true;
                        }
                        btnProceedToCompleteApplicationForm.Visible = false;
                    }
                    else
                    {
                        if (IsLockedByCandidate == 'N' && (ApplicationFormStatus == 'C' || ApplicationFormStatus == 'A') && FCVerificationStatus == 'N')
                        {
                            if (objSessionData.CandidatureTypeID == 15 || objSessionData.CandidatureTypeID == 16)
                            {
                                tblDiscrepancyDetails.Visible = false;
                            }
                            else
                            {
                                lblDiscrepancyStatus.Text = "Your Application Form is Completed, Please Lock and Submit for E-Verification(E-Scrutiny).";
                                trSubmitButton.Visible = true;
                                //btnProceedToCompleteApplicationForm.Visible = false;
                            }
                        }
                        else
                        {
                            //lblDiscrepancyStatus.Text = "Your Application Form is Completed and Sent to " + strMappedFC + " on " + strMappedTime + " for E-Verification(E-Scrutiny).";
                            lblDiscrepancyStatus.Text = "Your Application Form is Completed and Sent to SC for E-Verification(E-Scrutiny)-It will be verified soon.";
                            btnProceedToCompleteApplicationForm.Visible = false;
                        }
                    }
                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'C' && FCVerificationStatus == 'P')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is Picked for E-Verification and Locked by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ". It will be verified soon.";
                    //lblDiscrepancyStatus.Text = "Your Application Form is Picked for E-Verification and Locked - It will be verified soon.";
                    lblDiscrepancyStatus.ForeColor = System.Drawing.Color.Orange;
                    tblApplicationFormStatus.Visible = false;
                }
                else if ((ApplicationFormStatus == 'C' || ApplicationFormStatus == 'A' || ApplicationFormStatus == 'P') && FCVerificationStatus == 'D')
                {
                    //lblDiscrepancyStatus.Text = "Following Discrepancy(s) are found in Your Application Form by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ", and Reverted back your Application Form, Kindly Correct the Discrepancy by making necessory Corrections and Uploading related Documents.";
                    lblDiscrepancyStatus.Text = "Following Discrepancy(s) are found in Your Application Form  Reverted back your Application Form, Kindly Correct the Discrepancy by making necessory Corrections and Uploading related Documents.";
                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        trDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();
                        //trEditButton.Visible = true;

                        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                        {
                            if (gvDiscrepancy.Rows[i].Cells[2].Text == "Duplicate Mobile Number")
                            {
                                Button btnStep = (Button)gvDiscrepancy.Rows[i].FindControl("btnStep");
                                btnStep.Visible = true;
                                //gvDiscrepancy.Rows[i].Cells[6].Controls[0].Visible = false;
                            }
                            else
                            {
                                gvDiscrepancy.Rows[i].Cells[4].Visible = true;
                            }
                        }
                    }
                    else
                    {
                        trDiscrepancy.Visible = false;
                    }
                    tblApplicationFormStatus.Visible = false;
                    btnProceedToCompleteApplicationForm.Visible = false;
                }
                else if (ApplicationFormStatus == 'A' && FCVerificationStatus == 'C')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ". Please Check the Acknowledgement.";
                    //lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed Please Check the Acknowledgement.";
                    lblDiscrepancyStatus.ForeColor = System.Drawing.Color.Green;

                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        lblDiscrepancyStatus.Text += "<br/>Following Discrepancy(s) are found in Your Application Form. You can raise the Grievance to Unlock the Application Form.";

                        trDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();

                        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                        {
                            Button btnStep = (Button)gvDiscrepancy.Rows[i].FindControl("btnStep");
                            btnStep.Visible = false;
                        }
                    }
                    else
                    {
                        trDiscrepancy.Visible = false;
                    }

                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'A' && FCVerificationStatus == 'U')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is Unlocked on your Request(Grievance Raised) for Corrections. Please Edit the Application Form and ReSubmit it.";
                    trEditButton.Visible = true;

                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        lblDiscrepancyStatus.Text += "<br/>Following Discrepancy(s) are found in Your Application Form. Edit the Application Form and Upload the required Documents";

                        trDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();
                        //trEditButton.Visible = true;

                        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                        {
                            if (gvDiscrepancy.Rows[i].Cells[2].Text == "Duplicate Mobile Number")
                            {
                                Button btnStep = (Button)gvDiscrepancy.Rows[i].FindControl("btnStep");
                                btnStep.Visible = false;
                            }
                            else
                            {
                                gvDiscrepancy.Rows[i].Cells[4].Visible = true;
                            }
                        }
                    }
                    else
                    {
                        trDiscrepancy.Visible = false;
                    }
                    tblApplicationFormStatus.Visible = false;
                    btnProceedToCompleteApplicationForm.Visible = false;

                }
                else if (ApplicationFormStatus == 'A' && FCVerificationStatus == 'N' && IsLockedByCandidate == 'Y')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Re-Submitted to " + strMappedFC + " on " + FCVerificationStatusDate + " for Re-E-Verification(E-Scrutiny). It will be Verified soon.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Re-Submitted for Re-E-Verification(E-Scrutiny). It will be Verified soon.";
                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'A' && FCVerificationStatus == 'P')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Picked by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + " for Re-E-Verification and Locked. It will be Re-Vverified soon.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Picked for Re-E-Verification and Locked. It will be Re-Verified soon.";
                    tblApplicationFormStatus.Visible = false;
                }


                else if (ApplicationFormStatus == 'P' && FCVerificationStatus == 'C')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed Provissionally Please Check the Acknowledgement and Pay the difference in fee ONLINE.";
                    tblApplicationFormStatus.Visible = false;

                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        lblDiscrepancyStatus.Text += "<br/>Following Discrepancy(s) are found in Your Application Form. You can raise the Grievance to Unlock the Application Form.";

                        trDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();

                        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                        {
                            Button btnStep = (Button)gvDiscrepancy.Rows[i].FindControl("btnStep");
                            btnStep.Visible = false;
                        }
                    }
                    else
                    {
                        trDiscrepancy.Visible = false;
                    }
                    tblApplicationFormStatus.Visible = false;
                    btnProceedToCompleteApplicationForm.Visible = false;

                }
                else if (ApplicationFormStatus == 'P' && FCVerificationStatus == 'U')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is Unlocked By " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ", on your Request(Grievance Raised) for Corrections. Please Edit the Application Form and ReSubmit it.";
                    //lblDiscrepancyStatus.Text = "Your Application Form is Unlocked on your Request(Grievance Raised) for Corrections. Please Edit the Application Form and ReSubmit it.";
                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        lblDiscrepancyStatus.Text += "<br/>Following Discrepancy(s) are found in Your Application Form. Edit the Application Form and Upload the required Documents";

                        trDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();
                        //trEditButton.Visible = true;

                        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                        {
                            if (gvDiscrepancy.Rows[i].Cells[2].Text == "Duplicate Mobile Number")
                            {
                                Button btnStep = (Button)gvDiscrepancy.Rows[i].FindControl("btnStep");
                                btnStep.Visible = false;
                            }
                            else
                            {
                                gvDiscrepancy.Rows[i].Cells[4].Visible = true;
                            }
                        }
                    }
                    else
                    {
                        trDiscrepancy.Visible = false;
                    }
                    tblApplicationFormStatus.Visible = false;
                    btnProceedToCompleteApplicationForm.Visible = false;
                }
                else if (ApplicationFormStatus == 'P' && FCVerificationStatus == 'N')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is Ready for Resubmission.";
                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'P' && FCVerificationStatus == 'P')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Picked by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + " for Re-E-Verification and Locked. It will be verified soon.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Picked for Re-E-Verification and Locked. It will be verified soon.";
                    tblApplicationFormStatus.Visible = false;
                }
            }

            if (strVerificationMode == "P") //In Person Physical SC Verification
            {
                if (ApplicationFormStatus == 'I')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is In-Complete, Please Fill the Complete Application Form and Visit to any nearest Scrutiny Center (SC) with all original Documents for Verification and Confirmation of your application form.";
                }
                else if (ApplicationFormStatus == 'C')
                {
                    DataSet ds = reg.GetCandidateBookingSlotDetails(objSessionData.PID);
                    if (ds.Tables[0].Rows.Count > 0 && strVerificationMode != "E")
                    {
                        lblDiscrepancyStatus.Text = "Your Application Form is Complete, Please Visit to any nearest Scrutiny Center (SC) with all original Documents for Verification and Confirmation of your application form.";
                    }
                    else
                    {
                        //lblDiscrepancyStatus.Text = "Your Application Form is Complete, Please Book a Slot for Visit to Scrutiny Center for Confirmation.";
                        lblDiscrepancyStatus.Text = "Your Application Form is Complete, Please Visit to any nearest Scrutiny Center (SC) with all original Documents for Verification and Confirmation of your application form.";
                        trBookSlotButton.Visible = false;
                    }
                }
                else if (ApplicationFormStatus == 'A')
                {
                    if (CancelFlag == 'P')
                    {
                        lblDiscrepancyStatus.Text = "Your Application Form is Provissionally Verified by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + " Please Pay the difference in fee ONLINE and collect the Acknowledgement copy from SC.";
                        //lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed by ";
                        lblDiscrepancyStatus.ForeColor = System.Drawing.Color.Red;
                        tblApplicationFormStatus.Visible = false;
                    }
                    else
                    {
                        //lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ".";
                        lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ".";
                        lblDiscrepancyStatus.ForeColor = System.Drawing.Color.Green;
                        tblApplicationFormStatus.Visible = false;
                    }
                }
            }
            //added by anjali
            DataSet statusARAds = reg.getNotRecommendedAndRecommendedForApprovalCandidateList(objSessionData.PID);
            if (statusARAds.Tables[0].Rows.Count > 0)
            {
                tblARAStatus.Visible = true;
                lblARAStatus.Visible = true;
                string ARANotRecommendedAndRecommendedStatus = statusARAds.Tables[0].Rows[0]["IsVerifiedATMVSO"].ToString();
                if (ARANotRecommendedAndRecommendedStatus == "A")
                {
                    lblARAStatus.Text = "Your admission is approved by Admissions Regulating Authority(ARA).";

                }
                else if (ARANotRecommendedAndRecommendedStatus == "R")
                {
                    lblARAStatus.Text = "Your admission is not approved by Admissions Regulating Authority(ARA). Kindly log into your respective application for further details and corrective actions.";
                }
            }
            //tblSEBCTOOpen.Visible = false;
        }
        protected void btnEditApplicationForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
        }
        protected void btnReSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModule/frmPreviewApplicationForm", true);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModule/frmPreviewApplicationForm", true);
        }
        protected void btnBookSlot_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModule/FCSlotBooking.aspx", true);
        }
        protected void btnProceedToCompleteApplicationForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
        }
        protected void btnProceedToCompleteOptionForm_Click(object sender, EventArgs e)
        {
            if (Global.CurrentCAPRoundForOptionFormFilling == 1 && DateTime.Now >= Global.OptionFormFillingCAPRound1StartDateTime && DateTime.Now <= Global.OptionFormFillingCAPRound1EndDateTime)
            {
                Response.Redirect("../CandidateModuleCAPRound1/frmOptionForm.aspx");
            }
            else if (Global.CurrentCAPRoundForOptionFormFilling == 2 && DateTime.Now >= Global.OptionFormFillingCAPRound2StartDateTime && DateTime.Now <= Global.OptionFormFillingCAPRound2EndDateTime)
            {
                Response.Redirect("../CandidateModuleCAPRound2/frmOptionForm.aspx");
            }
            else if (Global.CurrentCAPRoundForOptionFormFilling == 3 && DateTime.Now >= Global.OptionFormFillingCAPRound3StartDateTime && DateTime.Now <= Global.OptionFormFillingCAPRound3EndDateTime)
            {
                Response.Redirect("../CandidateModuleCAPRound3/frmOptionForm.aspx");
            }
            else if (Global.CurrentCAPRoundForOptionFormFilling == 4 && DateTime.Now >= Global.OptionFormFillingCAPRound4StartDateTime && DateTime.Now <= Global.OptionFormFillingCAPRound4EndDateTime)
            {
                Response.Redirect("../CandidateModuleCAPRound4/frmOptionForm.aspx");
            }
        }
        protected void btnSeatAcceptanceStep1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx", true);
        }
        protected void btnSeatAcceptanceStep2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceFeeDetails.aspx", true);
        }
        protected void btnSeatAcceptanceStep4_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceForm.aspx", true);
        }

        protected void btnSeatAcceptanceStep_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx", true);
        }
        protected void btnUlockOptionForm_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            SMSTemplate sMSTemplate = new SMSTemplate();
            sMSTemplate.PID = objSessionData.PID;
            SynCommon synCommon = new SynCommon();
            if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OptionFormUnlockCAPIOTP))
                //SMS objSMS1 = new SMS();
                //DataSet ds1 = reg.GetSMSEmailContent(objSessionData.PID, "OptionFormUnlockCAPI OTP", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                //if (ds1.Tables[1] != null)
                //{
                //    if (ds1.Tables[1].Rows.Count > 0)
                //    {
                //        objSMS1.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds1.Tables[1].Rows[0]["MobileNo"].ToString()), ds1.Tables[1].Rows[0]["SMSContent"].ToString());
                //        if (Global.IsEmailSend == 1)
                //        {
                //            objSMS1.SendEmail(ds1.Tables[1].Rows[0]["EmailID"].ToString(), ds1.Tables[1].Rows[0]["EmailBody"].ToString(), ds1.Tables[1].Rows[0]["EmailSubject"].ToString(), true);
                //        }
                //        
                //    }
                //}
                Response.Redirect("../CandidateModuleCAPRound1/frmUnlockOptionForm.aspx", true);

        }
        protected void btnDifferenceFee_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Response.Redirect("../CandidateModule/frmPayApplicationFeeDifference.aspx", true);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSeatAcceptanceStep5_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateAdmissionReportingModule/frmChangeSeatAcceptanceStatus.aspx", true);
        }
    }
}