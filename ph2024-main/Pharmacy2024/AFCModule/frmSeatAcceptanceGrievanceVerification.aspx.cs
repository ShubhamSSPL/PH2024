using BusinessLayer;
using EntityModel;
using Newtonsoft.Json;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmSeatAcceptanceGrievanceVerification : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        AzureDocumentUpload objDU = new AzureDocumentUpload();
        public int CurrentDocID;
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
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
            ViewState["PID"] = PID;
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMyDocument));
            CandidateBasicInformation.PID = Convert.ToInt64(ViewState["PID"].ToString());
            if (!IsPostBack)
            {
                try
                {
                    ViewState["CurrentDocID"] = 0;

                    if (Request.QueryString["PID"] != null)
                    {

                        if (PID.ToString().GetHashCode() != Code)
                        {
                            Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                        }
                        ViewState["PID"] = PID;

                        txtSSCMathMarksObtained.Attributes.Add("OnBlur", "sscMathMarksChanged();");
                        txtSSCMathMarksOutOf.Attributes.Add("OnBlur", "sscMathMarksChanged();");
                        txtSSCTotalMarksObtained.Attributes.Add("OnBlur", "sscTotalMarksChanged();");
                        txtSSCTotalMarksOutOf.Attributes.Add("OnBlur", "sscTotalMarksChanged();");
                        txtHSCPhysicsMarksObtained.Attributes.Add("OnBlur", "hscPhysicsMarksChanged();");
                        txtHSCPhysicsMarksOutOf.Attributes.Add("OnBlur", "hscPhysicsMarksChanged();");
                        txtHSCChemistryMarksObtained.Attributes.Add("OnBlur", "hscChemistryMarksChanged();");
                        txtHSCChemistryMarksOutOf.Attributes.Add("OnBlur", "hscChemistryMarksChanged();");
                        txtHSCMathMarksObtained.Attributes.Add("OnBlur", "hscMathMarksChanged();");
                        txtHSCMathMarksOutOf.Attributes.Add("OnBlur", "hscMathMarksChanged();");
                        txtHSCBiologyMarksObtained.Attributes.Add("OnBlur", "hscBiologyMarksChanged();");
                        txtHSCBiologyMarksOutOf.Attributes.Add("OnBlur", "hscBiologyMarksChanged();");
                        txtHSCEnglishMarksObtained.Attributes.Add("OnBlur", "hscEnglishMarksChanged();");
                        txtHSCEnglishMarksOutOf.Attributes.Add("OnBlur", "hscEnglishMarksChanged();");
                        txtHSCTotalMarksObtained.Attributes.Add("OnBlur", "hscTotalMarksChanged();");
                        txtHSCTotalMarksOutOf.Attributes.Add("OnBlur", "hscTotalMarksChanged();");
                        txtDiplomaTotalMarksObtained.Attributes.Add("OnBlur", "diplomaTotalMarksChanged();");
                        txtDiplomaTotalMarksOutOf.Attributes.Add("OnBlur", "diplomaTotalMarksChanged();");

                        LoadData(PID);

                        DataSet ds = reg.GetDocumentListForDataVerificationByStepID(PID, 5);  //here 6 is used for StpeId for loading Qualification Documents
                        ReadoDocumentList.DataSource = ds;
                        ReadoDocumentList.DataTextField = "DocumentName";
                        ReadoDocumentList.DataValueField = "DocumentName";
                        ReadoDocumentList.SelectedIndex = 0;
                        ReadoDocumentList.DataBind();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            trdocument.Visible = true;
                            CurrentDocID = 0;
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (i == CurrentDocID && ds.Tables[0].Rows[i]["FilePath"].ToString() != "")
                                {
                                    string docpath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                                    string docName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
                                    string docfun = "LoadDocument('" + docpath + "','" + docName + "');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);
                                    break;
                                }
                                else
                                {
                                    CurrentDocID = CurrentDocID + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Invalid Access!!!", ShowMessageType.UserError);
                    }

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        private void LoadData(Int64 PID)
        {
            DataSet dsPersonalInformation = reg.getPersonalInformationForAllotmentDisplay(PID);
            DataSet dsAllotmentDetails = reg.getAllotmentDetails(PID);
            DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(PID);
            DataSet dsSeatAcceptanceFeeList = reg.getSeatAcceptanceFeeList(PID, "Seat Acceptance Fee");
            DataSet dsDocumentList = reg.getDocumentList(PID, "Y");
            DataSet dsSelfVerification = reg.getSelfVerificationDetails(PID);

            PersonalInformation obj = reg.getPersonalInformation(PID);

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
                    if (dsAllotmentDetails.Tables[0].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                    {
                        trCommentsCAPRound1.Visible = true;
                        lblCommentsCAPRound1.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[0].Rows[0]["ReasonForCancellation"].ToString();
                    }
                    else
                    {
                        trCommentsCAPRound1.Visible = false;
                    }
                    string BenefitTaken1 = reg.getBenefitTakenByCandidate(PID, 1);

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
                    if (dsAllotmentDetails.Tables[1].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                    {
                        trCommentsCAPRound2.Visible = true;
                        lblCommentsCAPRound2.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[1].Rows[0]["ReasonForCancellation"].ToString();
                    }
                    else
                    {
                        trCommentsCAPRound2.Visible = false;
                    }
                    string BenefitTaken2 = reg.getBenefitTakenByCandidate(PID, 2);

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
                    if (dsAllotmentDetails.Tables[2].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                    {
                        trCommentsCAPRound3.Visible = true;
                        lblCommentsCAPRound3.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[2].Rows[0]["ReasonForCancellation"].ToString();
                    }
                    else
                    {
                        trCommentsCAPRound3.Visible = false;
                    }
                    string BenefitTaken3 = reg.getBenefitTakenByCandidate(PID, 3);

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


            lblCurrentGender.Text = dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString();
            lblCurrentCandidature.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
            lblCurrentCategory.Text = dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString();
            lblCurrentEWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
            lblCurrentPWD.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString();
            lblCurrentDEF.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString();
            lblCurrentOrphan.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
            lblCurrentTFWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
            lblCurrentLinguistic.Text = obj.FinalLinguisticMinorityDetails;
            lblCurrentReligious.Text = obj.FinalReligiousMinorityDetails;
           // lblCurrentIntermediateGradeDrawing.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsIntermediateGradeDrawing"].ToString();

            if (dsSelfVerification.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(dsSelfVerification.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString()) == 1)
                {
                    //  rbLstRequest.Items[0].Text = "<b>Yes, Candidate's Request is Valid. Update Candidate Details, Cancel Allotment and Make Eligible for Next Round.</b>";
                    rbLstRequest.Items[0].Text = "<b> Yes, Candidate's request is accepted. Candidate's details shall be updated by the system, the allotted seat shall be cancelled and Candidate shall be eligible for next CAP Round.</ b > ";
                    rbLstRequest.Items[0].Attributes.Add("style", "color:red; font-weight:bold; padding:6px;");
                }
                else
                {
                    //rbLstRequest.Items[0].Text = "Yes, Candidate's Request is Valid. Update Candidate Details and Make Eligible for Next Round/Seat Acceptance.";
                    rbLstRequest.Items[0].Text = "Yes, Candidate's request is accepted. Candidate's details shall be updated by the system and Candidate shall be eligible for next CAP Round/Seat Acceptance.";
                }

                if (dsSelfVerification.Tables[0].Rows[0]["Gender"].ToString() == "N")
                {
                    trGender.Visible = true;
                    if (dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString() == "Male")
                        lblGenderStatus.Text = "Female";
                    else if (dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString() == "Female")
                        lblGenderStatus.Text = "Male";
                    else
                        lblGenderStatus.Text = "Male";
                }
                else
                {
                    trGender.Visible = false;
                }

                if (dsSelfVerification.Tables[0].Rows[0]["FinalCandidatureType"].ToString() == "N")
                {
                    trCandidature.Visible = true;
                    lblCandidatureStatus.Text = "OMS";
                }
                else
                    trCandidature.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["FinalCategory"].ToString() == "N")
                {
                    trCategory.Visible = true;
                    lblCategoryStatus.Text = "Open";
                }
                else
                    trCategory.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString() == "N")
                {
                    trEWS.Visible = true;
                    lblEWSStatus.Text = "No";
                }
                else
                    trEWS.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["FinalPHType"].ToString() == "N")
                {
                    trPH.Visible = true;
                    lblPWDStatus.Text = "Not Applicable";
                }
                else
                    trPH.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["FinalDefenceType"].ToString() == "N")
                {
                    trDef.Visible = true;
                    lblDefStatus.Text = "Not Applicable";
                }
                else
                    trDef.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["FinalIsOrphan"].ToString() == "N")
                {
                    trorphan.Visible = true;
                    lblOrphanStatus.Text = "No";
                }
                else
                    trorphan.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString() == "N")
                {
                    trTFWS.Visible = true;
                    lblTFWSStatus.Text = "No";
                }
                else
                    trTFWS.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["FinalLinguisticMinority"].ToString() == "N")
                {
                    trLinguisticMinority.Visible = true;
                    lblLinguisticMinorityStatus.Text = "Not Applicable";
                }
                else
                    trLinguisticMinority.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["FinalReligiousMinority"].ToString() == "N")
                {
                    trReligiousMinority.Visible = true;
                    lblReligiousMinorityStatus.Text = "Not Applicable";
                }
                else
                    trReligiousMinority.Visible = false;

                //=======================================================
                // QUALIFICATION
                //=======================================================
                //if (dsSelfVerification.Tables[0].Rows[0]["FinalIsIntermediateGradeDrawing"].ToString() == "N")
                //{
                //    trIntermediateGradeDrawing.Visible = true;
                //    lblIntermediateGradeDrawingStatus.Text = "No";
                //}
                //else
                //    trIntermediateGradeDrawing.Visible = false;



                if (dsSelfVerification.Tables[0].Rows[0]["SSCMathMarksObtained"].ToString() == "N")
                {
                    trSSCMath.Visible = true;
                    lblCurrentSSCMathematics.Text = dsPersonalInformation.Tables[0].Rows[0]["SSCMathMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["SSCMathMarksOutOf"].ToString();
                    txtSSCMathMarksObtained.Text = dsSelfVerification.Tables[0].Rows[0]["SSCMathMarksNew"].ToString();
                    txtSSCMathMarksOutOf.Text = dsSelfVerification.Tables[0].Rows[0]["SSCMathOutofMarksNew"].ToString();
                }
                else
                    trSSCMath.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["SSCTotalMarksObtained"].ToString() == "N")
                {
                    trSSCTotal.Visible = true;
                    lblCurrentSSCTotal.Text = dsPersonalInformation.Tables[0].Rows[0]["SSCTotalMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["SSCTotalMarksOutOf"].ToString();
                    txtSSCTotalMarksObtained.Text = dsSelfVerification.Tables[0].Rows[0]["SSCTotalMarksNew"].ToString();
                    txtSSCTotalMarksOutOf.Text = dsSelfVerification.Tables[0].Rows[0]["SSCTotalOutofMarksNew"].ToString();
                }
                else
                    trSSCTotal.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["HSCPhysicsMarksObtained"].ToString() == "N")
                {
                    trPhysics.Visible = true;
                    lblCurrentHSCPhysics.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCPhysicsMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCPhysicsMarksOutOf"].ToString();
                    txtHSCPhysicsMarksObtained.Text = dsSelfVerification.Tables[0].Rows[0]["HSCPhysicsMarksNew"].ToString();
                    txtHSCPhysicsMarksOutOf.Text = dsSelfVerification.Tables[0].Rows[0]["HSCPhysicsOutofMarksNew"].ToString();
                }
                else
                    trPhysics.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["HSCChemistryMarksObtained"].ToString() == "N")
                {
                    trHSCChemistry.Visible = true;
                    lblCurrentHSCChemistry.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCChemistryMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCChemistryMarksOutOf"].ToString();
                    txtHSCChemistryMarksObtained.Text = dsSelfVerification.Tables[0].Rows[0]["HSCChemistryMarksNew"].ToString();
                    txtHSCChemistryMarksOutOf.Text = dsSelfVerification.Tables[0].Rows[0]["HSCChemistryOutofMarksNew"].ToString();
                }
                else
                    trHSCChemistry.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["SubjectId"].ToString() == "1") //Biology
                {
                    if (dsSelfVerification.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString() == "N")
                    {
                        trHSCBiology.Visible = true;
                        lblCurrentHSCBiology.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksOutOf"].ToString();
                        txtHSCBiologyMarksObtained.Text = dsSelfVerification.Tables[0].Rows[0]["HSCSubjectMarksNew"].ToString();
                        txtHSCBiologyMarksOutOf.Text = dsSelfVerification.Tables[0].Rows[0]["HSCSubjectMarksOutOfNew"].ToString();
                    }
                    else
                        trHSCBiology.Visible = false;
                }
                else
                    trHSCBiology.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["SubjectId"].ToString() == "2") //Math
                {
                    if (dsSelfVerification.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString() == "N")
                    {
                        trHSCMathematics.Visible = true;
                        lblCurrentHSCMathematics.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksOutOf"].ToString();
                        txtHSCMathMarksObtained.Text = dsSelfVerification.Tables[0].Rows[0]["HSCSubjectMarksNew"].ToString();
                        txtHSCMathMarksOutOf.Text = dsSelfVerification.Tables[0].Rows[0]["HSCSubjectMarksOutOfNew"].ToString();
                    }
                    else
                        trHSCMathematics.Visible = false;
                }
                else
                    trHSCMathematics.Visible = false;



                if (dsSelfVerification.Tables[0].Rows[0]["HSCEnglishMarksObtained"].ToString() == "N")
                {
                    trHSCEnglish.Visible = true;
                    lblCurrentHSCEnglish.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCEnglishMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCEnglishMarksOutOf"].ToString();
                    txtHSCEnglishMarksObtained.Text = dsSelfVerification.Tables[0].Rows[0]["HSCEnglishMarksNew"].ToString();
                    txtHSCEnglishMarksOutOf.Text = dsSelfVerification.Tables[0].Rows[0]["HSCEnglishOutofMarksNew"].ToString();
                }
                else
                    trHSCEnglish.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["HSCTotalMarksObtained"].ToString() == "N")
                {
                    trHSCTotal.Visible = true;
                    lblCurrentHSCAggregate.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCTotalMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCTotalMarksOutOf"].ToString();
                    txtHSCTotalMarksObtained.Text = dsSelfVerification.Tables[0].Rows[0]["HSCTotalMarksNew"].ToString();
                    txtHSCTotalMarksOutOf.Text = dsSelfVerification.Tables[0].Rows[0]["HSCTotalOutofMarksNew"].ToString();
                }
                else
                    trHSCTotal.Visible = false;

                if (dsSelfVerification.Tables[0].Rows[0]["DiplomaMarksType"].ToString() == "Percentage") //Percentage
                {
                    if (dsSelfVerification.Tables[0].Rows[0]["DiplomaMarksObtained"].ToString() == "N")
                    {
                        trDiplomaMarks.Visible = true;
                        lblCurrentDiplomaMarks.Text = dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalMarksOutOf"].ToString();
                        txtDiplomaTotalMarksObtained.Text = dsSelfVerification.Tables[0].Rows[0]["DiplomaMarksNew"].ToString();
                        txtDiplomaTotalMarksOutOf.Text = dsSelfVerification.Tables[0].Rows[0]["DiplomaMarksOutofNew"].ToString();
                    }
                    else
                        trDiplomaMarks.Visible = false;
                }
                else
                    trDiplomaMarks.Visible = false;
                if (dsSelfVerification.Tables[0].Rows[0]["DiplomaMarksType"].ToString() == "CGPA") //CGPA
                {
                    if (dsSelfVerification.Tables[0].Rows[0]["DiplomaMarksObtained"].ToString() == "N")
                    {
                        trDiplomaMarksTypeCGPA.Visible = true;
                        lblCurrentDiplomaCGPA.Text = dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalMarksObtained"].ToString();

                        txtDiplomaCGPAObtained.Text = obj.DiplomaTotalMarksObtained.ToString();
                        txtDiplomaCGPAOutOf.Text = obj.DiplomaTotalMarksOutOf.ToString();
                        txtDiplomaCGPAPercentage.Text = obj.DiplomaTotalPercentage.ToString();
                         
                    }
                    else
                        trDiplomaMarksTypeCGPA.Visible = false;

                }
                else
                    trDiplomaMarksTypeCGPA.Visible = false;



            }


            gvDocuments.DataSource = dsDocumentList;
            gvDocuments.DataBind();

            for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
            {
                gvDocuments.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
            }




        }
        //protected void GenderStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkGenderV.Checked)
        //    {
        //        lblGenderStatus.Text = "Valid";
        //        lblGenderStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkGendreNV.Checked)
        //    {
        //        lblGenderStatus.Text = "Not Valid";
        //        lblGenderStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void CandidatureStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkCandidatureV.Checked)
        //    {
        //        lblCandidatureStatus.Text = "Valid";
        //        lblCandidatureStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkCandidatureNV.Checked)
        //    {
        //        lblCandidatureStatus.Text = "Not Valid";
        //        lblCandidatureStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void CategoryStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkCategoryV.Checked)
        //    {
        //        lblCategoryStatus.Text = "Valid";
        //        lblCategoryStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkCategoryNV.Checked)
        //    {
        //        lblCategoryStatus.Text = "Not Valid";
        //        lblCategoryStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void EWSStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkEWSV.Checked)
        //    {
        //        lblEWSStatus.Text = "Valid";
        //        lblEWSStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkEWSNV.Checked)
        //    {
        //        lblEWSStatus.Text = "Not Valid";
        //        lblEWSStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void PWDStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkPWDV.Checked)
        //    {
        //        lblPWDStatus.Text = "Valid";
        //        lblPWDStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkPWDNV.Checked)
        //    {
        //        lblPWDStatus.Text = "Not Valid";
        //        lblPWDStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void DEFStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkDefV.Checked)
        //    {
        //        lblDefStatus.Text = "Valid";
        //        lblDefStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkDefNV.Checked)
        //    {
        //        lblDefStatus.Text = "Not Valid";
        //        lblDefStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void OrphanStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkOrphanV.Checked)
        //    {
        //        lblOrphanStatus.Text = "Valid";
        //        lblOrphanStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkOrphanNV.Checked)
        //    {
        //        lblOrphanStatus.Text = "Not Valid";
        //        lblOrphanStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void TFWSStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkTFWSV.Checked)
        //    {
        //        lblTFWSStatus.Text = "Valid";
        //        lblTFWSStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkTFWSNV.Checked)
        //    {
        //        lblTFWSStatus.Text = "Not Valid";
        //        lblTFWSStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void LinguisticMinorityStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkLinguisticMinorityV.Checked)
        //    {
        //        lblLinguisticMinorityStatus.Text = "Valid";
        //        lblLinguisticMinorityStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkLinguisticMinorityNV.Checked)
        //    {
        //        lblLinguisticMinorityStatus.Text = "Not Valid";
        //        lblLinguisticMinorityStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void ReligiousMinorityStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkReligiousMinorityV.Checked)
        //    {
        //        lblReligiousMinorityStatus.Text = "Valid";
        //        lblReligiousMinorityStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkReligiousMinorityNV.Checked)
        //    {
        //        lblReligiousMinorityStatus.Text = "Not Valid";
        //        lblReligiousMinorityStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}


        //protected void HSCAggregateStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkHSCAggregateV.Checked)
        //    {
        //        txtHSCTotal.Text = "";
        //        txtHSCTotal.Enabled = false;
        //        lblHSCAggregateStatus.Text = "Valid";
        //        lblHSCAggregateStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkHSCAggregateNV.Checked)
        //    {
        //        lblHSCAggregateStatus.Text = "Not Valid";
        //        txtHSCTotal.Enabled = true;
        //        lblHSCAggregateStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void HSCPhysicsStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkHSCPhysicsV.Checked)
        //    {
        //        txtHSCPhysicsStatus.Text = "";
        //        txtHSCPhysicsStatus.Enabled = false;
        //        lblHSCPhysicsStatus.Text = "Valid";
        //        lblHSCPhysicsStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkHSCPhysicsNV.Checked)
        //    {
        //        txtHSCPhysicsStatus.Enabled = true;
        //        lblHSCPhysicsStatus.Text = "Not Valid";
        //        lblHSCPhysicsStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void HSCChemistryStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkHSCChemistryV.Checked)
        //    {

        //        txtHSCChemistryStatus.Text = "";
        //        txtHSCChemistryStatus.Enabled = false;
        //        lblHSCChemistryStatus.Text = "Valid";
        //        lblHSCChemistryStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkHSCChemistryNV.Checked)
        //    {
        //        txtHSCChemistryStatus.Enabled = true;
        //        lblHSCChemistryStatus.Text = "Not Valid";
        //        lblHSCChemistryStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void HSCBiologyStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkHSCBiologyV.Checked)
        //    {
        //        txtHSCBiology.Text = "";
        //        txtHSCBiology.Enabled = false;
        //        lblHSCBiologyStatus.Text = "Valid";
        //        lblHSCBiologyStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkHSCBiologyNV.Checked)
        //    {
        //        txtHSCBiology.Enabled = true;
        //        lblHSCBiologyStatus.Text = "Not Valid";
        //        lblHSCBiologyStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void HSCMathematicsStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkHSCMathematicsV.Checked)
        //    {
        //        txtHSCMathematics.Text = "";
        //        txtHSCMathematics.Enabled = false;
        //        lblHSCMathematicsStatus.Text = "Valid";
        //        lblHSCMathematicsStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkHSCMathematicsNV.Checked)
        //    {
        //        txtHSCMathematics.Enabled = true;
        //        lblHSCMathematicsStatus.Text = "Not Valid";
        //        lblHSCMathematicsStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void HSCEnglishStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkHSCEnglishV.Checked)
        //    {
        //        txtHSCEnglish.Text = "";
        //        txtHSCEnglish.Enabled = false;
        //        lblHSCEnglishStatus.Text = "Valid";
        //        lblHSCEnglishStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkHSCEnglishNV.Checked)
        //    {
        //        txtHSCEnglish.Enabled = true;
        //        lblHSCEnglishStatus.Text = "Not Valid";
        //        lblHSCEnglishStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void SSCTotalStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkSSCTotalV.Checked)
        //    {
        //        txtSSCTotal.Text = "";
        //        txtSSCTotal.Enabled = false;
        //        lbltxtSSCTotalStatus.Text = "Valid";
        //        lbltxtSSCTotalStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkSSCTotalNV.Checked)
        //    {
        //        txtSSCTotal.Enabled = true;
        //        lbltxtSSCTotalStatus.Text = "Not Valid";
        //        lbltxtSSCTotalStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void SSCMathematicsStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkSSCMathematicsV.Checked)
        //    {
        //        txtSSCMathematics.Text = "";
        //        txtSSCMathematics.Enabled = false;
        //        lblMathematicsStatus.Text = "Valid";
        //        lblMathematicsStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkSSCMathematicsNV.Checked)
        //    {
        //        txtSSCMathematics.Enabled = true;
        //        lblMathematicsStatus.Text = "Not Valid";
        //        lblMathematicsStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void IntermediateGradeDrawingStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkIntermediateGradeDrawingV.Checked)
        //    {
        //        lblIntermediateGradeDrawingNo.Visible = false;
        //        lblIntermediateGradeDrawingStatus.Text = "Valid";
        //        lblIntermediateGradeDrawingStatus.ForeColor = System.Drawing.Color.Green;
        //    }
        //    if (chkIntermediateGradeDrawingNV.Checked)
        //    {
        //        lblIntermediateGradeDrawingNo.Visible = true;
        //        lblIntermediateGradeDrawingStatus.Text = "Not Valid";
        //        lblIntermediateGradeDrawingStatus.ForeColor = System.Drawing.Color.Red;
        //    }
        //}

        protected void gvDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hidFURL = (HiddenField)e.Row.FindControl("hidFURL");
                    if (hidFURL.Value != "")
                    {
                        string ext = System.IO.Path.GetExtension(hidFURL.Value).ToLower();
                        HtmlImage imgDoc = (HtmlImage)e.Row.FindControl("imgDoc");
                        HiddenField hidDID = (HiddenField)e.Row.FindControl("hidDID");
                        HtmlAnchor hrefURL = (HtmlAnchor)e.Row.FindControl("hrefURL");
                        HiddenField hdnImgByteArray = (HiddenField)e.Row.FindControl("hdnImgByteArray");
                        hrefURL.HRef = ConfigurationManager.AppSettings["ApplicationURL"] + "ViewMyDocument.aspx?documentID=" + hidDID.Value;
                        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".bmp")
                        {
                            string url = hidFURL.Value;
                            if (hidFURL.Value.Contains("studentdocuments"))
                            {
                                url = hidFURL.Value.Replace("studentdocuments", "studentdocumentsthumbnail");
                                string checkurl = url.Replace(ConfigurationManager.AppSettings["HttpAddress"], "");
                                if (!objDU.Exists(checkurl))
                                {
                                    url = hidFURL.Value;
                                }
                            }
                            string base64 = objDU.GetBlobContentAsBase64("studentdocumentsthumbnail", url);//objDU.ConvertImageURLToBase64(url);
                            imgDoc.Src = base64; //"data:image/png;base64," +
                        }
                        else if (ext == ".pdf")
                        {
                            imgDoc.Src = "../images/pdf.gif";
                        }
                        else if (ext == ".zip" || ext == ".rar")
                        {
                            hrefURL.Target = "self";
                            imgDoc.Src = "../images/zip.png";
                        }
                        hdnImgByteArray.Value = objDU.GetBlobContentAsBase64("studentdocuments", hidFURL.Value.ToString());
                    }

                    //if (((HiddenField)e.Row.Cells[5].FindControl("hdnImgUrl")).Value.Length > 0)
                    //{
                    //    if (((Label)e.Row.Cells[5].FindControl("lblIsSubmitted")).Text == "N")
                    //    {
                    //        ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = false;
                    //        ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = true;
                    //    }
                    //    else
                    //    {
                    //        ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = true;
                    //        ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = false;
                    //    }
                    //}
                    //else
                    //{
                    //    ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = false;
                    //    ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = true;
                    //    ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Enabled = false;
                    //    e.Row.BackColor = System.Drawing.Color.Red;
                    //}
                    //((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Enabled = false;
                    //((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Enabled = false;
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 IsGenderChanged = 0;
                Int32 IsCandidatureTypeChanged = 0;
                Int32 IsCategoryChanged = 0;
                Int32 IsEWSChanged = 0;
                Int32 IsPHTypeChanged = 0;
                Int32 IsDefenceTypeChanged = 0;
                Int32 IsOrphanChanged = 0;
                Int32 IsTFWSChanged = 0;
                Int32 IsLinguisticMinorityChanged = 0;
                Int32 IsReligiousMinorityChanged = 0;
                Int32 IsIGDChanged = 0;

                Int32 IsSSCMathematicsMarksChanged = 0;
                Int32 IsSSCTotalMarksChanged = 0;
                Int32 IsHSCPhysicsMarksChanged = 0;
                Int32 IsHSCChemistryMarksChanged = 0;
                //Int32 IsHSCBiologyMarksChanged = 0;
                //Int32 IsHSCMathematicsMarksChanged = 0;
                Int32 IsHSCEnglishMarksChanged = 0;
                Int32 IsHSCTotalMarksChanged = 0;
                Int32 IsHSCSubjectMarksChanged = 0;
                Int32 IsDiplomaMarksChanged = 0;

                string NewGenderCode = "";
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                DataSet dsSelfVerification = reg.getSelfVerificationDetails(PID);
                DataSet dsPersonalInformation = reg.getPersonalInformationForAllotmentDisplay(PID);

                QualificationDetails obj = new QualificationDetails();

                if (dsSelfVerification.Tables[0].Rows.Count > 0)
                {
                    if (dsSelfVerification.Tables[0].Rows[0]["Gender"].ToString() == "N")
                    {
                        IsGenderChanged = 1;
                        if (dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString() == "Male")
                            NewGenderCode = "F";
                        else if (dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString() == "Female")
                            NewGenderCode = "M";
                        else
                            NewGenderCode = "M";
                    }
                    else
                    {
                        IsGenderChanged = 0;
                    }

                    if (dsSelfVerification.Tables[0].Rows[0]["FinalCandidatureType"].ToString() == "N")
                    {
                        IsCandidatureTypeChanged = 1;
                    }
                    else
                        IsCandidatureTypeChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["FinalCategory"].ToString() == "N")
                    {
                        IsCategoryChanged = 1;
                    }
                    else
                        IsCategoryChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString() == "N")
                    {
                        IsEWSChanged = 1;
                    }
                    else
                        IsEWSChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["FinalPHType"].ToString() == "N")
                    {
                        IsPHTypeChanged = 1;
                    }
                    else
                        IsPHTypeChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["FinalDefenceType"].ToString() == "N")
                    {
                        IsDefenceTypeChanged = 1;
                    }
                    else
                        IsDefenceTypeChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["FinalIsOrphan"].ToString() == "N")
                    {
                        IsOrphanChanged = 1;
                    }
                    else
                        IsOrphanChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString() == "N")
                    {
                        IsTFWSChanged = 1;
                    }
                    else
                        IsTFWSChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["FinalLinguisticMinority"].ToString() == "N")
                    {
                        IsLinguisticMinorityChanged = 1;
                    }
                    else
                        IsLinguisticMinorityChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["FinalReligiousMinority"].ToString() == "N")
                    {
                        IsReligiousMinorityChanged = 1;
                    }
                    else
                        IsReligiousMinorityChanged = 0;

                    //=======================================================
                    // QUALIFICATION
                    //=======================================================
                    if (dsSelfVerification.Tables[0].Rows[0]["FinalIsIntermediateGradeDrawing"].ToString() == "N")
                    {
                        IsIGDChanged = 1;
                    }
                    else
                        IsIGDChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["SSCMathMarksObtained"].ToString() == "N")
                    {
                        IsSSCMathematicsMarksChanged = 1;
                        obj.SSCMathMarksObtained = Convert.ToDecimal(txtSSCMathMarksObtained.Text);
                        obj.SSCMathMarksOutOf = Convert.ToDecimal(txtSSCMathMarksOutOf.Text);
                        obj.SSCMathPercentage = Math.Round(Convert.ToDecimal(obj.SSCMathMarksObtained * 100) / obj.SSCMathMarksOutOf,2);
                    }
                    else
                        IsSSCMathematicsMarksChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["SSCTotalMarksObtained"].ToString() == "N")
                    {
                        IsSSCTotalMarksChanged = 1;
                        obj.SSCTotalMarksObtained = Convert.ToDecimal(txtSSCTotalMarksObtained.Text);
                        obj.SSCTotalMarksOutOf = Convert.ToDecimal(txtSSCTotalMarksOutOf.Text);
                        obj.SSCTotalPercentage = Math.Round(Convert.ToDecimal(obj.SSCTotalMarksObtained * 100) / obj.SSCTotalMarksOutOf,2);
                    }
                    else
                        IsSSCTotalMarksChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["HSCPhysicsMarksObtained"].ToString() == "N")
                    {
                        IsHSCPhysicsMarksChanged = 1;
                        obj.HSCPhysicsMarksObtained = Convert.ToDecimal(txtHSCPhysicsMarksObtained.Text);
                        obj.HSCPhysicsMarksOutOf = Convert.ToDecimal(txtHSCPhysicsMarksOutOf.Text);
                        obj.HSCPhysicsPercentage = Math.Round(Convert.ToDecimal(obj.HSCPhysicsMarksObtained * 100) / obj.HSCPhysicsMarksOutOf,2);
                    }
                    else
                        IsHSCPhysicsMarksChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["HSCChemistryMarksObtained"].ToString() == "N")
                    {
                        IsHSCChemistryMarksChanged = 1;
                        obj.HSCChemistryMarksObtained = Convert.ToDecimal(txtHSCChemistryMarksObtained.Text);
                        obj.HSCChemistryMarksOutOf = Convert.ToDecimal(txtHSCChemistryMarksOutOf.Text);
                        obj.HSCChemistryPercentage = Math.Round(Convert.ToDecimal(obj.HSCChemistryMarksObtained * 100) / obj.HSCChemistryMarksOutOf,2);
                    }
                    else
                        IsHSCChemistryMarksChanged = 0;

                    if (dsSelfVerification.Tables[0].Rows[0]["SubjectId"].ToString() == "1") //Biology
                    {
                        if (dsSelfVerification.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString() == "N")
                        {
                            IsHSCSubjectMarksChanged = 1;
                            obj.HSCSubjectMarksObtained = Convert.ToDecimal(txtHSCBiologyMarksObtained.Text);
                            obj.HSCSubjectMarksOutOf = Convert.ToDecimal(txtHSCBiologyMarksOutOf.Text);
                            obj.HSCSubjectPercentage = Math.Round(Convert.ToDecimal(obj.HSCSubjectMarksObtained * 100) / obj.HSCSubjectMarksOutOf,2);
                        }
                        else
                            IsHSCSubjectMarksChanged = 0;
                    }
                    if (dsSelfVerification.Tables[0].Rows[0]["SubjectId"].ToString() == "2") //Math
                    {
                        if (dsSelfVerification.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString() == "N")
                        {
                            IsHSCSubjectMarksChanged = 1;
                            obj.HSCSubjectMarksObtained = Convert.ToDecimal(txtHSCMathMarksObtained.Text);
                            obj.HSCSubjectMarksOutOf = Convert.ToDecimal(txtHSCMathMarksOutOf.Text);
                            obj.HSCSubjectPercentage = Math.Round(Convert.ToDecimal(obj.HSCSubjectMarksObtained * 100) / obj.HSCSubjectMarksOutOf, 2);
                        }
                        else
                            IsHSCSubjectMarksChanged = 0;
                    }

                    if (dsSelfVerification.Tables[0].Rows[0]["HSCEnglishMarksObtained"].ToString() == "N")
                    {
                        IsHSCEnglishMarksChanged = 1;
                        obj.HSCEnglishMarksObtained = Convert.ToDecimal(txtHSCEnglishMarksObtained.Text);
                        obj.HSCEnglishMarksOutOf = Convert.ToDecimal(txtHSCEnglishMarksOutOf.Text);
                        obj.HSCEnglishPercentage = Math.Round(Convert.ToDecimal(obj.HSCEnglishMarksObtained * 100) / obj.HSCEnglishMarksOutOf,2);
                    }
                    else
                        IsHSCEnglishMarksChanged = 0;
                   
                    if (dsSelfVerification.Tables[0].Rows[0]["HSCTotalMarksObtained"].ToString() == "N")
                    {
                        IsHSCTotalMarksChanged = 1;
                        obj.HSCTotalMarksObtained = Convert.ToDecimal(txtHSCTotalMarksObtained.Text);
                        obj.HSCTotalMarksOutOf = Convert.ToDecimal(txtHSCTotalMarksOutOf.Text);
                        obj.HSCTotalPercentage = Math.Round(Convert.ToDecimal(obj.HSCTotalMarksObtained * 100) / obj.HSCTotalMarksOutOf,2);
                    }
                    else
                        IsHSCTotalMarksChanged = 0;
                    //=========================================
                    if (dsSelfVerification.Tables[0].Rows[0]["DiplomaMarksType"].ToString() == "Percentage") //Percentage
                    {
                        if (dsSelfVerification.Tables[0].Rows[0]["DiplomaMarksObtained"].ToString() == "N")
                        {
                            IsDiplomaMarksChanged = 1;
                            obj.DiplomaTotalMarksObtained = Convert.ToDecimal(txtDiplomaTotalMarksObtained.Text);
                            obj.DiplomaTotalMarksOutOf = Convert.ToDecimal(txtDiplomaTotalMarksOutOf.Text);
                            obj.DiplomaTotalPercentage = Math.Round(Convert.ToDecimal(obj.DiplomaTotalMarksObtained * 100) / obj.DiplomaTotalMarksOutOf, 2);
                        }
                        else
                            IsDiplomaMarksChanged = 0;
                    }
                    if (dsSelfVerification.Tables[0].Rows[0]["DiplomaMarksType"].ToString() == "CGPA") //CGPA
                    {
                        if (dsSelfVerification.Tables[0].Rows[0]["DiplomaMarksObtained"].ToString() == "N")
                        {
                            IsDiplomaMarksChanged = 1;
                            obj.DiplomaTotalMarksObtained = Convert.ToDecimal(txtDiplomaCGPAObtained.Text);
                            obj.DiplomaTotalMarksOutOf = Convert.ToDecimal(txtDiplomaCGPAOutOf.Text);
                            obj.DiplomaTotalPercentage = Convert.ToDecimal(txtDiplomaCGPAPercentage.Text);
                        }
                        else
                            IsDiplomaMarksChanged = 0;
                        //========================================
                    }
                }

                if (rbLstRequest.SelectedValue == "Yes")
                {
                    //if request is valid, edit details, and Set Request as Approved
                    // if cancellation required flag is true then cancel allotment
                    //else only edit details

                    if (reg.EditConfirmedApplicationFormSelfVerification(PID, Global.CAPRound, NewGenderCode, IsGenderChanged,
                        IsCandidatureTypeChanged, IsCategoryChanged, IsEWSChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsOrphanChanged,
                        IsTFWSChanged, IsLinguisticMinorityChanged, IsReligiousMinorityChanged, IsIGDChanged,
                        IsSSCMathematicsMarksChanged, IsSSCTotalMarksChanged, IsHSCPhysicsMarksChanged, IsHSCChemistryMarksChanged,
                      IsHSCEnglishMarksChanged, IsHSCTotalMarksChanged, IsHSCSubjectMarksChanged, IsDiplomaMarksChanged,
                        obj, Convert.ToInt32(dsSelfVerification.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString()),
                        "A", txtComments.Text.ToString(), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        if (Global.SendSMSToCandidate == 1)
                        {

                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = PID;
                            sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                            sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                            if (Global.SendSMSToCandidate == 1)
                            {
                                if (Convert.ToInt32(dsSelfVerification.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString()) == 1) // if Allotment Cancellation Required
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.SeatAcceptanceGrievanceApprovedWithCancellation);
                                if (Convert.ToInt32(dsSelfVerification.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString()) == 0) // if Allotment Cancellation Not Required.
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.SeatAcceptanceGrievanceApprovedWithOutCancellation);
                            }
                        }

                        Response.Redirect("../AFCModule/frmSeatAcceptanceGrievanceCandidateListApproved.aspx", true);  // to Approved List
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                        shInfo.Focus();
                    }
                }
                else if (rbLstRequest.SelectedValue == "No")
                {
                    if (reg.UpdateSeatAcceptanceGrievanceStaus(PID, Global.CAPRound, "R", txtComments.Text.ToString(), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        if (Global.SendSMSToCandidate == 1)
                        {

                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = PID;
                            sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                            sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                            sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.SeatAcceptanceGrievanceRejected);
                        }

                        Response.Redirect("../AFCModule/frmSeatAcceptanceGrievanceCandidateListRejected.aspx", true); //to Rejected List
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                        shInfo.Focus();
                    }
                }
                else
                {
                    shInfo.SetMessage("Please Select the Request Status whether it is Valid or Invalid!!!", ShowMessageType.Information);
                    shInfo.Focus();
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }



        protected void ReadoDocumentList_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                // ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                string selectedvalue = ReadoDocumentList.SelectedValue;
                DataSet ds = reg.GetDocumentListForDataVerificationByStepID(Convert.ToInt64(ViewState["PID"]), 5);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["DocumentName"].ToString() == selectedvalue)
                        {
                            if (ds.Tables[0].Rows[i]["FilePath"].ToString() != "")
                            {
                                string docpath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                                string docName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
                                string docfun = "LoadDocument('" + docpath + "','" + docName + "');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);
                            }
                            else
                            {
                                shInfo.SetMessage("Candidate has not uploaded the Document :" + selectedvalue, ShowMessageType.Information);
                            }
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
}