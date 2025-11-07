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
    public partial class frmAllotmentDetails : System.Web.UI.Page
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
            if (Request.QueryString["str"] != null)
            {
                string strWhow = (Request.QueryString["str"].ToString());
                shInfo.SetMessage(strWhow, ShowMessageType.Information);
            }
            try
            {
                if (!IsPostBack)
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];

                    if (reg.isCandidateEligibleForAdmission(objSessionData.PID))
                    {
                        DataSet dsPersonalInformation = reg.getPersonalInformationForAllotmentDisplay(objSessionData.PID);
                        DataSet dsAllotmentDetails = reg.getAllotmentDetails(objSessionData.PID);
                        DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(objSessionData.PID);

                        if (dsPersonalInformation.Tables[0].Rows.Count > 0)
                        {
                            lblCandidateName.Text = dsPersonalInformation.Tables[0].Rows[0]["CandidateName"].ToString();
                            lblGender.Text = dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString();
                            lblDOB.Text = dsPersonalInformation.Tables[0].Rows[0]["DOB"].ToString();
                            lblCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                            lblHomeUniversity.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                            lblOriginalCategory.Text = dsPersonalInformation.Tables[0].Rows[0]["OriginalCategory"].ToString();
                            lblCategoryForAdmission.Text = dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString();
                            lblAppliedForEWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                            lblAppliedForOrphan.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                            lblPHType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString();
                            lblDefenceType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                            lblMinorityCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
                            lblHSCPhysicsPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCPhysicsPercentage"].ToString() + " %";
                            lblHSCChemistryPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCChemistryPercentage"].ToString() + " %";
                            lblHSCSubject.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubject"].ToString();
                            lblHSCSubjectPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectPercentage"].ToString() + " %";
                            lblAppliedForTFWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();

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
                        }

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

                        if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                        {
                            tblSeatAcceptanceStatusDetails.Visible = true;
                            lblSeatAcceptanceStatus.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["SeatAcceptanceStatus"].ToString();
                            lblSeatAcceptanceConfirmationDetails.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["ReportingStatus"].ToString();
                        }

                        if (Global.ARCReporting == 1)
                        {
                            string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(objSessionData.PID);

                            if (SeatAcceptanceConfirmationStatus == "Y")
                            {
                                //shInfo.SetMessage("Seat Acceptance Status is Already Confirmed at Admission Reporting Center.", ShowMessageType.Information);
                                shInfo.SetMessage("Seat Acceptance Status is Already Confirmed.", ShowMessageType.Information);
                                btnProceed.Visible = false;
                            }
                            else if (SeatAcceptanceConfirmationStatus == "C")
                            {
                                if (!reg.isEligibleForSeatAcceptance(objSessionData.PID, Global.CAPRound))
                                {
                                    shInfo.SetMessage("Seat Acceptance Status is Cancelled.", ShowMessageType.Information);
                                    btnProceed.Visible = false;
                                }
                            }
                            else
                            {
                                if (!reg.isEligibleForSeatAcceptance(objSessionData.PID, Global.CAPRound))
                                {
                                    shInfo.SetMessage("Not Allotted in CAP Round " + Global.CAPRound.ToString() + ".", ShowMessageType.Information);
                                    btnProceed.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("Updation of Seat Acceptance Status is Not Started OR Closed.", ShowMessageType.Information);
                            btnProceed.Visible = false;
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("This Candidate is not Eligible for Seat Acceptance.", ShowMessageType.Information);
                        ContentTable2.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(objSessionData.PID);
            if (ApplicationFeeToBePaid > 0)
            {
                Session["FeeGroupId"] = null;
                Session["PhaseId"] = null;
                Session["PayeeUserTypeId"] = null;
                Session["PayeeId"] = null;

                Session["FeeGroupId"] = "2";
                Session["PhaseId"] = "1";
                Session["PayeeUserTypeId"] = "91";
                Session["PayeeId"] = objSessionData.PID.ToString();

                Response.Redirect("../FeeProcess/PaymentDetails.aspx", true);
            }
            if (!reg.CheckSelfVerificationIsDone(objSessionData.PID))
            {
                if (reg.CheckCandidateinAllotmentCancellationRemark(objSessionData.PID))
                {
                    shInfo.SetMessage("Your Allotment is Cancelled you can't give Seat Acceptance.", ShowMessageType.Information);
                    shInfo.Visible = true;
                }
                else
                    Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceStatusDetails.aspx", true);
            }
            else
                Response.Redirect("../CandidateAdmissionReportingModule/SelfDocVerification.aspx");
        }
    }
}