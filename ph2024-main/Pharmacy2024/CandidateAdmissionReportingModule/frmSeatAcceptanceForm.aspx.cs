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
    public partial class frmSeatAcceptanceForm : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;
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
            SessionData objSessionData = (SessionData)Session["SessionData"];
            DataSet ds = reg.getSeatAcceptanceFeeList(objSessionData.PID, "Seat Acceptance Fee");

            if (ds.Tables[0].Rows.Count == 0)
            {
                trFeeDetails1.Visible = false;
            }
            else
            {
                trFeeDetails2.Visible = false;
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (!IsPostBack)
                {

                    DataSet dsPersonalInformation = reg.getPersonalInformationForAllotmentDisplay(objSessionData.PID);
                    DataSet dsAllotmentDetails = reg.getAllotmentDetails(objSessionData.PID);
                    //imgSignature1.ImageUrl = UserInfo.GetImageURL(objSessionData.PID, "Signature");

                    AzureDocumentUpload azObj = new AzureDocumentUpload();
                    imgSignature1.ImageUrl = azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(objSessionData.PID, "Signature"));

                    string selfVerificationStatus = "";
                    Int16 IsAllotmentCancellationRequired = 0;
                    DataSet dsstatus = reg.GetSelfVerificationstatus(objSessionData.PID);
                    if (dsstatus.Tables.Count > 0)
                    {
                        if (dsstatus.Tables[0].Rows.Count > 0)
                        {
                            selfVerificationStatus = dsstatus.Tables[0].Rows[0]["IsGrivanceRaised"].ToString();
                            IsAllotmentCancellationRequired = Convert.ToInt16(dsstatus.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString());
                        }
                    }
                    if (reg.CheckCandidateinAllotmentCancellationRemark(objSessionData.PID))
                    {
                        shInfo.SetMessage("Your Allotment is Cancelled you can't confirm Seat Acceptance.", ShowMessageType.Information);
                        shInfo.Visible = true;
                        Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx");
                    }
                    if (selfVerificationStatus == "P" || (selfVerificationStatus == "A" && IsAllotmentCancellationRequired == 1) || selfVerificationStatus == "Y")
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx");

                    if (reg.CheckSelfVerificationIsDone(objSessionData.PID))
                    {
                        if (Global.CAPRound >= 1)
                        {
                            if (dsAllotmentDetails.Tables[0].Rows.Count > 0)
                            {
                                Response.Redirect("../CandidateAdmissionReportingModule/SelfDocVerification.aspx", true);
                            }
                        }
                        if (Global.CAPRound >= 2)
                        {
                            if (dsAllotmentDetails.Tables[1].Rows.Count > 0)
                            {
                                Response.Redirect("../CandidateAdmissionReportingModule/SelfDocVerification.aspx", true);
                            }
                        }
                        if (Global.CAPRound >= 3)
                        {
                            if (dsAllotmentDetails.Tables[2].Rows.Count > 0)
                            {
                                Response.Redirect("../CandidateAdmissionReportingModule/SelfDocVerification.aspx", true);
                            }
                        }
                    }
                    if (dsPersonalInformation.Tables[0].Rows.Count > 0)
                    {
                        lblApplicationID.Text = dsPersonalInformation.Tables[0].Rows[0]["ApplicationID"].ToString();
                        lblCandidateName.Text = lblDeclarationName.Text = dsPersonalInformation.Tables[0].Rows[0]["CandidateName"].ToString();
                        lblGender.Text = dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString();
                        lblDOB.Text = dsPersonalInformation.Tables[0].Rows[0]["DOB"].ToString();
                        lblCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                        lblHomeUniversity.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                        lblOriginalCategory.Text = dsPersonalInformation.Tables[0].Rows[0]["OriginalCategory"].ToString();
                        lblCategoryForAdmission.Text = dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString();
                        //if (dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString().Contains("$"))
                        //    trCVC.Visible = true;
                        //if (dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString().Contains("#"))
                        //    trNCL.Visible = true;
                        lblAppliedForEWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                        lblAppliedForOrphan.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                        lblPHType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString();
                        lblDefenceType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                        lblMinorityCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
                        lblAppliedForTFWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                        lblHSCPhysicsPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCPhysicsPercentage"].ToString() + " %";
                        lblHSCChemistryPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCChemistryPercentage"].ToString() + " %";
                        lblHSCSubject.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubject"].ToString();
                        lblHSCSubjectPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectPercentage"].ToString() + " %";

                        string AdmissionCategory = reg.GetAdmissionCategory(objSessionData.PID);
                        if (AdmissionCategory.Contains("$") || AdmissionCategory.Contains("#") || AdmissionCategory.Contains("@"))
                        {
                            trCVCMsg.Visible = true;
                        }
                        else
                        {
                            trCVCMsg.Visible = false;
                        }

                        //if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCBioTechnologyPercentage"].ToString()) > 0)
                        //{
                        //    lblHSCBioTechnologyPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCBioTechnologyPercentage"].ToString() + " %";
                        //}
                        //else
                        //{
                        //    lblHSCBioTechnologyPercentage.Text = "--";
                        //}
                        lblHSCTotalPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCTotalPercentage"].ToString() + " %";
                        if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalPercentage"].ToString()) > 0)
                        {
                            lblDiplomaTotalPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalPercentage"].ToString() + " %";
                        }
                        else
                        {
                            lblDiplomaTotalPercentage.Text = "--";
                        }
                        lblMHMeritNo.Text = dsPersonalInformation.Tables[0].Rows[0]["MHMeritNo"].ToString();
                        lblMHMeritScore.Text = dsPersonalInformation.Tables[0].Rows[0]["MHMeritScore"].ToString();
                        lblAIMeritNo.Text = dsPersonalInformation.Tables[0].Rows[0]["AIMeritNo"].ToString();
                        lblAIMeritScore.Text = dsPersonalInformation.Tables[0].Rows[0]["AIMeritScore"].ToString();

                        lblNameAsPerHSCResult.Text = dsPersonalInformation.Tables[0].Rows[0]["NameAsPerHSCResult"].ToString();
                        lblNameAsPerHSCResult.ForeColor = System.Drawing.Color.Red;
                        lblCETCandidateName.Text = dsPersonalInformation.Tables[0].Rows[0]["CETCandidateName"].ToString();
                        lblCETCandidateName.ForeColor = System.Drawing.Color.Blue;
                        if(dsPersonalInformation.Tables[0].Rows[0]["CETCandidateName"].ToString()=="")
                        {
                            lblCETCandidateName.Text = "-- (Not Appeared for Exam)";
                        }
                        lblNEETName.Text = dsPersonalInformation.Tables[0].Rows[0]["NEETCName"].ToString();
                        lblNEETName.ForeColor = System.Drawing.Color.DarkOrange;
                        if (dsPersonalInformation.Tables[0].Rows[0]["NEETCName"].ToString() == "")
                        {
                            lblNEETName.Text = "-- (Not Appeared for Exam)";
                        }
                        tblExmDetail.Visible = true;
                    }

                    //if (Convert.ToInt16(dsAllotmentDetails.Tables[0].Rows[0]["PreferenceNoAllotted"]) == 1)
                    //{
                    //    lifirstprefcap1.Visible = true;
                    //    lisecondprefcap1.Visible = false;
                    //    lithirdprefcap1.Visible = false;
                    //}
                    //else
                    //{
                    //    lifirstprefcap1.Visible = false;
                    //    lisecondprefcap1.Visible = true;
                    //    lithirdprefcap1.Visible = true;
                    //}

                    if (Global.CAPRound >= 1)
                    {
                        if (dsAllotmentDetails.Tables[0].Rows.Count > 0)
                        {
                            tblAllotmentDetailsCAPRound1.Visible = true;
                            lblInstituteAllottedCAPRound1.Text = dsAllotmentDetails.Tables[0].Rows[0]["InstituteAllotted"].ToString();
                            lblCourseAllottedCAPRound1.Text = dsAllotmentDetails.Tables[0].Rows[0]["CourseAllotted"].ToString();
                            lblSeatTypeAllottedCAPRound1.Text = dsAllotmentDetails.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                            lblPreferenceNoAllottedCAPRound1.Text = dsAllotmentDetails.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString();
                            lblCoordinatorName1.Text = dsAllotmentDetails.Tables[0].Rows[0]["lblCoordinatorName"].ToString();
                            lblCoordinatorMobile1.Text = dsAllotmentDetails.Tables[0].Rows[0]["lblCoordinatorMobile"].ToString();
                            if (dsAllotmentDetails.Tables[0].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                            {
                                trCommentsCAPRound1.Visible = true;
                                lblCommentsCAPRound1.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[0].Rows[0]["ReasonForCancellation"].ToString();
                            }
                            else
                            {
                                trCommentsCAPRound1.Visible = false;
                            }
                            string BenefitTaken1 = reg.getBenefitTakenByCandidate(objSessionData.PID, 1);

                            if (BenefitTaken1 == "")
                            {
                                //lblBenefitTaken.Text = "NA";
                                trBenefitTaken.Visible = false;
                            }
                            else
                            {
                                lblBenefitTaken.Text = BenefitTaken1;
                            }
                        }
                        else
                        {
                            tblNoAllotmentDetailsCAPRound1.Visible = true;
                            lblAllotmentStatusCAPRound1.Text = "Not Allotted in CAP Round-I";
                        }
                    }
                    if (Global.CAPRound >= 2)
                    {
                        if (dsAllotmentDetails.Tables[1].Rows.Count > 0)
                        {
                            tblAllotmentDetailsCAPRound2.Visible = true;
                            lblInstituteAllottedCAPRound2.Text = dsAllotmentDetails.Tables[1].Rows[0]["InstituteAllotted"].ToString();
                            lblCourseAllottedCAPRound2.Text = dsAllotmentDetails.Tables[1].Rows[0]["CourseAllotted"].ToString();
                            lblSeatTypeAllottedCAPRound2.Text = dsAllotmentDetails.Tables[1].Rows[0]["SeatTypeAllotted"].ToString();
                            lblPreferenceNoAllottedCAPRound2.Text = dsAllotmentDetails.Tables[1].Rows[0]["PreferenceNoAllotted"].ToString();
                            lblCoordinatorName2.Text = dsAllotmentDetails.Tables[1].Rows[0]["lblCoordinatorName"].ToString();
                            lblCoordinatorMobile2.Text = dsAllotmentDetails.Tables[1].Rows[0]["lblCoordinatorMobile"].ToString();
                            if (dsAllotmentDetails.Tables[1].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                            {
                                trCommentsCAPRound2.Visible = true;
                                lblCommentsCAPRound2.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[1].Rows[0]["ReasonForCancellation"].ToString();
                            }
                            else
                            {
                                trCommentsCAPRound2.Visible = false;
                            }
                            string BenefitTaken2 = reg.getBenefitTakenByCandidate(objSessionData.PID, 2);

                            if (BenefitTaken2 == "")
                            {
                                //lblBenefitTaken.Text = "NA";
                                trBenefitTaken2.Visible = false;
                            }
                            else
                            {
                                lblBenefitTaken2.Text = BenefitTaken2;
                            }
                        }
                        else
                        {
                            tblNoAllotmentDetailsCAPRound2.Visible = true;
                            lblAllotmentStatusCAPRound2.Text = "Not Allotted in CAP Round-II / Not Allotted New Choice Code in CAP Round-II";
                        }
                    }

                    if (Global.CAPRound >= 3)
                    {
                        if (dsAllotmentDetails.Tables[2].Rows.Count > 0)
                        {
                            tblAllotmentDetailsCAPRound3.Visible = true;
                            lblInstituteAllottedCAPRound3.Text = dsAllotmentDetails.Tables[2].Rows[0]["InstituteAllotted"].ToString();
                            lblCourseAllottedCAPRound3.Text = dsAllotmentDetails.Tables[2].Rows[0]["CourseAllotted"].ToString();
                            lblSeatTypeAllottedCAPRound3.Text = dsAllotmentDetails.Tables[2].Rows[0]["SeatTypeAllotted"].ToString();
                            lblPreferenceNoAllottedCAPRound3.Text = dsAllotmentDetails.Tables[2].Rows[0]["PreferenceNoAllotted"].ToString();
                            lblCoordinatorName3.Text = dsAllotmentDetails.Tables[2].Rows[0]["lblCoordinatorName"].ToString();
                            lblCoordinatorMobile3.Text = dsAllotmentDetails.Tables[2].Rows[0]["lblCoordinatorMobile"].ToString();
                            if (dsAllotmentDetails.Tables[2].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                            {
                                trCommentsCAPRound3.Visible = true;
                                lblCommentsCAPRound3.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[2].Rows[0]["ReasonForCancellation"].ToString();
                            }
                            else
                            {
                                trCommentsCAPRound3.Visible = false;
                            }
                            string BenefitTaken3 = reg.getBenefitTakenByCandidate(objSessionData.PID, 3);

                            if (BenefitTaken3 == "")
                            {
                                //lblBenefitTaken.Text = "NA";
                                trBenefitTaken3.Visible = false;
                            }
                            else
                            {
                                lblBenefitTaken3.Text = BenefitTaken3;
                            }
                        }
                        else
                        {
                            tblNoAllotmentDetailsCAPRound3.Visible = true;
                            lblAllotmentStatusCAPRound3.Text = "Not Allotted in CAP Round-III / Not Allotted New Choice Code in CAP Round-III";
                        }
                    }

                    if (Global.CAPRound >= 4)
                    {
                        if (dsAllotmentDetails.Tables[3].Rows.Count > 0)
                        {
                            tblAllotmentDetailsCAPRound4.Visible = true;
                            lblInstituteAllottedCAPRound4.Text = dsAllotmentDetails.Tables[3].Rows[0]["InstituteAllotted"].ToString();
                            lblCourseAllottedCAPRound4.Text = dsAllotmentDetails.Tables[3].Rows[0]["CourseAllotted"].ToString();
                            lblSeatTypeAllottedCAPRound4.Text = dsAllotmentDetails.Tables[3].Rows[0]["SeatTypeAllotted"].ToString();
                            lblPreferenceNoAllottedCAPRound4.Text = dsAllotmentDetails.Tables[3].Rows[0]["PreferenceNoAllotted"].ToString();
                            if (dsAllotmentDetails.Tables[3].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                            {
                                trCommentsCAPRound4.Visible = true;
                                lblCommentsCAPRound4.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[3].Rows[0]["ReasonForCancellation"].ToString();
                            }
                            else
                            {
                                trCommentsCAPRound4.Visible = false;
                            }
                        }
                        else
                        {
                            tblNoAllotmentDetailsCAPRound4.Visible = true;
                            lblAllotmentStatusCAPRound4.Text = "Not Allotted in Additional Admission Round / Not Allotted New Choice Code in Additional Admission Round";
                        }
                    }

                    DataSet dsSeatAcceptanceStatusDetails1 = reg.getSeatAcceptanceStatusDetails(objSessionData.PID);
                    if (dsSeatAcceptanceStatusDetails1.Tables[0].Rows.Count > 0)
                    {
                        //tblSeatAcceptanceStatusDetails.Visible = true;
                        //lblVersionNo.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["VersionNo"].ToString();
                        //lblSeatAcceptanceStatus.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["SeatAcceptanceStatus"].ToString();
                        //lblSeatAcceptanceConfirmationDetails.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["ReportingStatus"].ToString();
                    }
                    else
                    {
                        Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx");
                    }

                    gvFeeDetails.DataSource = reg.getSeatAcceptanceFeeList(objSessionData.PID, "Seat Acceptance Fee");
                    gvFeeDetails.DataBind();
                   
                    if (gvFeeDetails.Rows.Count == 0)
                    {
                        Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceFeeDetails.aspx");
                        trFeeDetails1.Visible = false;
                    }
                    else
                    {
                        if
                            (
                                (Global.CurrentCAPRoundForARCReporting == 1 &&
                                 DateTime.Now >= Global.ARCReportingCAPRound1StartDateTime &&
                                 DateTime.Now <= Global.ARCReportingCAPRound1EndDateTime) ||
                                (Global.CurrentCAPRoundForARCReporting == 2 &&
                                 DateTime.Now >= Global.ARCReportingCAPRound2StartDateTime &&
                                 DateTime.Now <= Global.ARCReportingCAPRound2EndDateTime) ||
                                (Global.CurrentCAPRoundForARCReporting == 3 &&
                                 DateTime.Now >= Global.ARCReportingCAPRound3StartDateTime &&
                                 DateTime.Now <= Global.ARCReportingCAPRound3EndDateTime) ||
                                (Global.CurrentCAPRoundForARCReporting == 4 &&
                                 DateTime.Now >= Global.ARCReportingCAPRound4StartDateTime &&
                                 DateTime.Now <= Global.ARCReportingCAPRound4EndDateTime)
                            )
                        {
                            if (ConfirmSeatAcceptance(objSessionData.PID))
                            {
                                ContentTable2.Visible = true;
                            }
                            else
                            {
                                ContentTable2.Visible = false;
                            }
                            trFeeDetails2.Visible = false;
                        }
                    }

                    DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(objSessionData.PID);
                    if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                    {
                        tblSeatAcceptanceStatusDetails.Visible = true;
                        lblVersionNo.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["VersionNo"].ToString();
                        lblSeatAcceptanceStatus.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["SeatAcceptanceStatus"].ToString();
                        lblSeatAcceptanceConfirmationDetails.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["ReportingStatus"].ToString();
                    }
                    else
                    {
                        Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx");
                    }

                    DataSet EligibilityRemark = reg.getEligibilityFlag(objSessionData.PID);
                    if (EligibilityRemark.Tables[0].Rows.Count > 0 && EligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && EligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                    {
                        trEligibilityRemark.Visible = true;
                        lblEligibilityRemark.Text += EligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString();
                        lblEligibilityRemark.ForeColor = System.Drawing.Color.Red;
                    }


                    DateTime ReportedDateTime = Convert.ToDateTime(dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["ReportedDateTime"].ToString());
                    lblConfirmedOn.Text = ReportedDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ReportedDateTime);
                    lblConfirmedBy.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["ReportedBy"].ToString() +" ,"+ dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["ReportedByIPAddress"].ToString();
                    lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                }
                //if (Global.CAPRound == 1)
                //    CAP1.Visible = true;
                //if (Global.CAPRound == 2)
                //    CAP2.Visible = true;
                //if (Global.CAPRound == 3)
                //    CAP3.Visible = true;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceFeeDetails.aspx", true);
        }
        private bool ConfirmSeatAcceptance(Int64 PID)
        {
            string XMLstring = string.Empty;
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(PID);

            if (SeatAcceptanceConfirmationStatus == "Y")
            {
                shInfo.SetMessage("Seat Acceptance Status is Already Confirmed.", ShowMessageType.Information);
                return true;
            }
            else if (SeatAcceptanceConfirmationStatus == "C")
            {
                if (reg.isEligibleForSeatAcceptance(PID, Global.CAPRound))
                {
                    if (reg.confirmSeatAcceptanceForm(PID, XMLstring, "", Global.CAPRound, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        if (Global.SendSMSToCandidate == 1)
                        {
                            DataSet ds = reg.getSeatAcceptanceStatusDetails(PID);
                            if (ds != null && ds.Tables.Count > 0)
                            {
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = PID;
                                sMSTemplate.ReportedBy = ds.Tables[0].Rows[0]["ReportedBy"].ToString();
                                sMSTemplate.ReportedDateTime = ds.Tables[0].Rows[0]["ReportedDateTime"].ToString();
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ConfirmSeatAcceptanceForm);
                                return true;
                            }
                            return true;
                        }
                        return true;
                    }
                    else
                    {
                        shInfo.SetMessage("Error on Confirmation of Seat Acceptance!", ShowMessageType.Information);
                        return false;
                    }
                }
                else
                {
                    shInfo.SetMessage("Seat Acceptance Status is Cancelled.", ShowMessageType.Information);
                }
                return true;
            }
            else
            {
                if (!reg.isEligibleForSeatAcceptance(PID, Global.CAPRound))
                {
                    shInfo.SetMessage("Not Allotted in CAP Round " + Global.CAPRound.ToString() + ".", ShowMessageType.Information);
                    return false;
                }
                else
                {
                    if (reg.confirmSeatAcceptanceForm(PID, XMLstring, "", Global.CAPRound, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        if (Global.SendSMSToCandidate == 1)
                        {
                            DataSet ds = reg.getSeatAcceptanceStatusDetails(PID);
                            if (ds != null && ds.Tables.Count > 0)
                            {
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = PID;
                                sMSTemplate.ReportedBy = ds.Tables[0].Rows[0]["ReportedBy"].ToString();
                                sMSTemplate.ReportedDateTime = ds.Tables[0].Rows[0]["ReportedDateTime"].ToString();
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ConfirmSeatAcceptanceForm);
                                return true;
                            }
                            return true;
                        }
                        return true;
                    }
                    else
                    {
                        shInfo.SetMessage("Error on Confirmation of Seat Acceptance!", ShowMessageType.Information);
                        return false;
                    }
                }
            }
        }
    }
}