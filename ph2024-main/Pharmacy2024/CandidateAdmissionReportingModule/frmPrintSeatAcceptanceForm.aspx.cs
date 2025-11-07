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
    public partial class frmPrintSeatAcceptanceForm : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            try
            {
                if (!IsPostBack)
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsPersonalInformation = reg.getPersonalInformationForAllotmentDisplay(objSessionData.PID);
                    //imgSignature1.ImageUrl = UserInfo.GetImageURL(objSessionData.PID, "Signature");
                    DataSet dsAllotmentDetails = reg.getAllotmentDetails(objSessionData.PID);
                    DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(objSessionData.PID);

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
                            //trCVC.Visible = true;
                        //if (dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString().Contains("#"))
                        //    trNCL.Visible = true;
                        lblAppliedForEWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                        lblAppliedForOrphan.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                        lblAppliedForTFWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                        lblPHType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString();
                        lblDefenceType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                        lblMinorityCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
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

                    if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                    {
                        tblSeatAcceptanceStatusDetails.Visible = true;
                        lblVersionNo.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["VersionNo"].ToString();
                        lblSeatAcceptanceStatus.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["SeatAcceptanceStatus"].ToString();
                        lblSeatAcceptanceConfirmationDetails.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["ReportingStatus"].ToString();
                    }

                    gvFeeDetails.DataSource = reg.getSeatAcceptanceFeeList(objSessionData.PID, "Seat Acceptance Fee");
                    gvFeeDetails.DataBind();

                    if (gvFeeDetails.Rows.Count == 0)
                    {
                        trFeeDetails1.Visible = false;
                    }
                    else
                    {
                        trFeeDetails2.Visible = false;
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
                if (Global.CAPRound == 1)
                    CAP1.Visible = false;
                if (Global.CAPRound == 2)
                    CAP2.Visible = false;
                if (Global.CAPRound == 3)
                    CAP3.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}