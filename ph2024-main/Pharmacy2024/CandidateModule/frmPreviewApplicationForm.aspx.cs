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

namespace Pharmacy2024.CandidateModule
{
    public partial class frmPreviewApplicationForm : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string NEETName = Global.NEETName;
        public string MHTCETName = Global.MHTCETName;
        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    if (Request.Cookies["Theme"] == null)
        //    {
        //        Page.Theme = "default";
        //    }
        //    else
        //    {
        //        Page.Theme = Request.Cookies["Theme"].Value;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
            }           

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            string _leftMenu = ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"];
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormLinks = true;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormNumber = false;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFadingEffect = true; ((ExpanderMenu)Master.FindControl(_leftMenu)).FormType = 1;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).FormNumber = Convert.ToInt64(Session["UserID"]);
            if (!IsPostBack)
            {
                try
                {
                    printFH.HeaderTitle = "Application Form for Admission to First Year of Four Year Degree Course in Pharmacy & First Year of Six Year Post Graduate Degree Course in Pharm. D. for the Academic Year " + AdmissionYear;

                    //IApplicationContext ctx = ContextRegistry.GetContext();
                    //IServices reg = (IServices)ctx.GetObject("Services");

                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    if (reg.CheckFCVerificationStatus(objSessionData.PID))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }
                    Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(objSessionData.PID);
                    Int32 ApplicationFeePaid = reg.getApplicationFeePaidAmount(objSessionData.PID);
                    // DataSet ds = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmPreviewApplicationForm");


                    //if (objSessionData.StepID >= 9)
                    //{
                    //    ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormLinks = false;
                    //}

                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                    char IsLockedByCandidate = Convert.ToChar(statusDs.Tables[0].Rows[0]["IsLockedByCandidate"].ToString());

                    if (ApplicationFeeToBePaid > 0 && objSessionData.ApplicationFormStatus != 'A')
                    {
                        Response.Redirect("../CandidateModule/frmPayApplicationFee.aspx", true);
                    }

                    if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["FormFillingLockDate"]))
                    {
                        btnProceed.Visible = false;
                        btnProceed1.Visible = false;
                    }
                    else
                    {
                        btnProceed.Visible = true;
                        btnProceed1.Visible = true;
                    }

                    if (reg.CheckFCVerificationStatusForResubmission(objSessionData.PID))
                    {
                        btnProceed.Text = "Re-Submit Application Form >>>";
                        btnProceed1.Text = "Re-Submit Application Form >>>";
                    }
                    else
                    {
                        btnProceed.Text = "Submit Application Form For E-Verification>>>";
                        btnProceed1.Text = "Submit Application Form For E-Verification >>>";
                    }
                    PersonalInformation obj = reg.getPersonalInformation(objSessionData.PID);

                    if (obj.HSCDistrict == "NA")
                    {
                        if (objSessionData.CandidatureTypeID == 1 || objSessionData.CandidatureTypeID == 2 || objSessionData.CandidatureTypeID == 3 || objSessionData.CandidatureTypeID == 4 || objSessionData.CandidatureTypeID == 5)
                        {
                            Response.Redirect("../CandidateModule/frmHomeUniversityAndCategoryDetails.aspx");
                        }
                    }

                    lblApplicationID.Text = obj.ApplicationID;
                    lblVersionNo.Text = obj.VersionNo.ToString();

                    AzureDocumentUpload azObj = new AzureDocumentUpload();
                    imgPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(objSessionData.PID, "Photograph"));
                    imgSignature.ImageUrl = imgSignature1.ImageUrl= azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(objSessionData.PID, "Signature"));
                    //imgPhotograph.ImageUrl = UserInfo.GetImageURL(objSessionData.PID, "Photograph");
                    // imgSignature.ImageUrl = imgSignature1.ImageUrl = UserInfo.GetImageURL(objSessionData.PID, "Signature");

                    lblCandidateName.Text = lblDeclarationName.Text = obj.CandidateName;
                    lblFatherName.Text = obj.FatherName;
                    lblMotherName.Text = obj.MotherName;
                    lblGender.Text = obj.Gender;
                    lblDOB.Text = obj.DOB;
                    lblCandidatureType.Text = obj.FinalCandidatureType;
                    if (obj.CandidatureType != obj.FinalCandidatureType)
                    {
                        lblCandidatureType.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    lblHomeUniversity.Text = obj.FinalHomeUniversity;
                    if (obj.HomeUniversity != obj.FinalHomeUniversity)
                    {
                        lblHomeUniversity.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    lblOriginalCategory.Text = obj.Category;
                    lblCategoryForAdmission.Text = obj.FinalCategory;
                    if (obj.Category != obj.FinalCategory)
                    {
                        lblCategoryForAdmission.Text = obj.FinalCategory + "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    lblAppliedForEWS.Text = obj.FinalAppliedForEWS;
                    if (obj.AppliedForEWS != obj.FinalAppliedForEWS)
                    {
                        lblAppliedForEWS.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    lblPHType.Text = obj.FinalPHType;
                    if (obj.PHType != obj.FinalPHType)
                    {
                        lblPHType.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    lblDefenceType.Text = obj.FinalDefenceType;
                    if (obj.DefenceType != obj.FinalDefenceType)
                    {
                        lblDefenceType.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    lblIsOrphan.Text = obj.FinalIsOrphan;
                    if (obj.IsOrphan != obj.FinalIsOrphan)
                    {
                        lblIsOrphan.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    //if (obj.FinalIsOrphan == "Yes")
                    //{
                    //    lblIsOrphan.Text += " (Orphan Registration No - " + obj.OrphanRegistrationNo + ", Has Relative - " + obj.OrphanHasRelative + ")";
                    //}
                    lblAppliedForTFWS.Text = obj.FinalAppliedForTFWS;
                    if (obj.AppliedForTFWS != obj.FinalAppliedForTFWS)
                    {
                        lblAppliedForTFWS.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    if (obj.AppliedForMinoritySeats == "Yes")
                    {
                        if (obj.FinalLinguisticMinorityDetails == "Not Applicable" && obj.FinalReligiousMinorityDetails == "Not Applicable")
                        {
                            lblAppliedForMinoritySeats.Text = "No <font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                        }
                        else if (obj.FinalLinguisticMinorityDetails != "Not Applicable" && obj.FinalReligiousMinorityDetails != "Not Applicable")
                        {
                            lblAppliedForMinoritySeats.Text = obj.AppliedForMinoritySeats + " - " + obj.FinalLinguisticMinorityDetails + ", " + obj.FinalReligiousMinorityDetails;
                        }
                        else if (obj.FinalLinguisticMinorityDetails != "Not Applicable" && obj.FinalReligiousMinorityDetails == "Not Applicable")
                        {
                            lblAppliedForMinoritySeats.Text = obj.AppliedForMinoritySeats + " - " + obj.FinalLinguisticMinorityDetails;
                        }
                        else if (obj.FinalLinguisticMinorityDetails == "Not Applicable" && obj.FinalReligiousMinorityDetails != "Not Applicable")
                        {
                            lblAppliedForMinoritySeats.Text = obj.AppliedForMinoritySeats + " - " + obj.FinalReligiousMinorityDetails;
                        }
                    }
                    else
                    {
                        lblAppliedForMinoritySeats.Text = obj.AppliedForMinoritySeats;
                    }

                    if (objSessionData.CandidatureTypeID == 1)
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;
                        trTaluka.Visible = false;
                        trVillage.Visible = false;

                        lblQ1.Text = "District from which Candidate has Passed SSC";
                        lblQ2.Text = "District from which Candidate has Passed HSC / Diploma in Pharmacy";
                        lblDistrict1.Text = obj.SSCDistrict;
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (objSessionData.CandidatureTypeID == 2)
                    {
                        trDistrict1.Visible = false;
                        trTaluka.Visible = false;
                        trVillage.Visible = false;

                        lblDocumentOfHead.Text = "Whose Domicile Cerificate You are Submitting at SC?";
                        lblDocumentOf.Text = obj.DocumentOf;
                        if (obj.DocumentOf == "Mother")
                        {
                            lblMothersName.Text = obj.MothersName;
                        }
                        else
                        {
                            trMothersName.Visible = false;
                        }
                        lblQ2.Text = "District where Candidate / Father or Mother of Candidate is Domiciled";
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (objSessionData.CandidatureTypeID == 3)
                    {
                        trDistrict1.Visible = false;
                        trMothersName.Visible = false;
                        trTaluka.Visible = false;
                        trVillage.Visible = false;

                        lblDocumentOfHead.Text = "Whose Proforma - A You are Submitting at SC?";
                        lblDocumentOf.Text = obj.DocumentOf;
                        lblQ2.Text = "District where Father or Mother of Candidate is Posted";
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (objSessionData.CandidatureTypeID == 4)
                    {
                        trDistrict1.Visible = false;
                        trMothersName.Visible = false;
                        trTaluka.Visible = false;
                        trVillage.Visible = false;

                        lblDocumentOfHead.Text = "Whose Proforma - B / Undertaking for Place of Settlement You are Submitting at SC?";
                        lblDocumentOf.Text = obj.DocumentOf;
                        lblQ2.Text = "District where Father or Mother of Candidate is Posted / Settled after Retirement";
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (objSessionData.CandidatureTypeID == 5)
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;
                        trTaluka.Visible = true;
                        trVillage.Visible = true;

                        lblQ1.Text = "District from which Candidate has Passed SSC";
                        lblQ2.Text = "District from which Candidate has Passed HSC / Diploma in Pharmacy";
                        lblQ3.Text = "Taluka from which Candidate has Passed HSC/ Diploma in Pharmacy";
                        lblQ4.Text = "Village from which Candidate has Passed HSC/ Diploma in Pharmacy";
                        lblDistrict1.Text = obj.SSCDistrict;
                        lblDistrict2.Text = obj.HSCDistrict;
                        lblTaluka.Text = obj.HSCTaluka;
                        lblvillage.Text = obj.HSCVillage;
                    }
                    else
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;
                        trDistrict1.Visible = false;
                        trDistrict2.Visible = false;
                        trTaluka.Visible = false;
                        trVillage.Visible = false;
                    }
                    lblApplicationFeePaidAmount.Text = obj.CETApplicationFee.ToString() + "/-";
                    lblOnlineApplicationFee.Text = obj.OnlineApplicationFee.ToString() + "/-";
                    lblNationality.Text = obj.Nationality;

                    lblHSCPhysicsMarksObtained.Text = obj.HSCPhysicsMarksObtained.ToString();
                    lblHSCPhysicsMarksOutOf.Text = obj.HSCPhysicsMarksOutOf.ToString();
                    lblHSCPhysicsPercentage.Text = obj.HSCPhysicsPercentage.ToString();
                    lblHSCChemistryMarksObtained.Text = obj.HSCChemistryMarksObtained.ToString();
                    lblHSCChemistryMarksOutOf.Text = obj.HSCChemistryMarksOutOf.ToString();
                    lblHSCChemistryPercentage.Text = obj.HSCChemistryPercentage.ToString();
                    lblHSCSubject.Text = obj.HSCSubject;
                    lblHSCSubjectMarksObtained.Text = obj.HSCSubjectMarksObtained.ToString();
                    lblHSCSubjectMarksOutOf.Text = obj.HSCSubjectMarksOutOf.ToString();
                    lblHSCSubjectPercentage.Text = obj.HSCSubjectPercentage.ToString();
                    lblHSCEnglishMarksObtained.Text = obj.HSCEnglishMarksObtained.ToString();
                    lblHSCEnglishMarksOutOf.Text = obj.HSCEnglishMarksOutOf.ToString();
                    lblHSCEnglishPercentage.Text = obj.HSCEnglishPercentage.ToString();
                    lblHSCTotalMarksObtained.Text = obj.HSCTotalMarksObtained.ToString();
                    lblHSCTotalMarksOutOf.Text = obj.HSCTotalMarksOutOf.ToString();
                    lblHSCTotalPercentage.Text = obj.HSCTotalPercentage.ToString();
                    lblDiplomaTotalMarksObtained.Text = obj.DiplomaTotalMarksObtained.ToString();
                    lblDiplomaTotalMarksOutOf.Text = obj.DiplomaTotalMarksOutOf.ToString();
                    lblDiplomaTotalPercentage.Text = obj.DiplomaTotalPercentage.ToString();
                    lblSSCBoard.Text = obj.SSCBoard;
                    lblSSCPassingYear.Text = obj.SSCPassingYear;
                    lblSSCSeatNo.Text = obj.SSCSeatNo;
                    lblHSCPassingStatus.Text = obj.HSCPassingStatus;
                    lblHSCBoard.Text = obj.HSCBoard;
                    lblHSCPassingYear.Text = SynCommon.GetPassingYear(obj.HSCPassingYear);
                    lblHSCSeatNo.Text = obj.HSCSeatNo;
                    StringMatching stringMatchingg = new StringMatching();
                    int matchingPercentagee = stringMatchingg.CheckString(obj.CandidateName, obj.NameAsPerHSCResult);

                    if (obj.HSCPassingYear == Global.CurrentYear && obj.HSCBoard == "Maharashtra State Board of Secondary and Higher Secondary Education, Pune" && obj.HSCPassingYear == Global.CurrentYear)
                    {
                        if (matchingPercentagee == 0)
                        {
                            lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult + " " + "<font color = 'red' size='2'>(Name As Per HSC Result)[Not Matching]</font>";
                        }
                        else if (matchingPercentagee == 50 && matchingPercentagee < 100)
                        {
                            lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult + " " + "<font color = 'red' size='2'>(Name As Per HSC Result)[Partially Matching]</font>";
                        }
                        else
                        {
                            lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult + " " + "<font color = 'red' size='2'>(Name As Per HSC Result)</font>";
                        }

                        //lblCETCandidateName.Text = dsCETResult.Tables[0].Rows[0]["CandidateName"].ToString() + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result)</font>";
                        lblNameAsPerHSCResult.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult + " " + "<font color = 'red' size='2'>(Name As Per HSC Result)</font>";
                        lblNameAsPerHSCResult.ForeColor = System.Drawing.Color.Blue;
                    }

                    // lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult;
                    if (obj.AppearedForDiploma == "Yes")
                    {
                        trDiplomaTotalMarks.Visible = true;
                        if (obj.DiplomaMarksType == "CGPA")
                        {
                            lblDiplomaTotalMarks.Text = "Diploma CGPA";
                        }
                    }
                    lblHSCPassingStatus.Text = obj.HSCPassingStatus;
                    lblHSCBoard.Text = obj.HSCBoard;
                    lblHSCPassingYear.Text = SynCommon.GetPassingYear(obj.HSCPassingYear);
                    lblHSCSeatNo.Text = obj.HSCSeatNo;

                    if ((objSessionData.CandidatureTypeID == 1 || objSessionData.CandidatureTypeID == 5) && obj.QualifyingExamPlace != "India")
                    {
                        Response.Redirect("../CandidateModule/frmQualificationDetails", true);
                    }

                    //DataSet dsCETResult = reg.getCETDetails(objSessionData.CETApplicationFormNo);
                    //if (dsCETResult.Tables[0].Rows.Count > 0)
                    //{
                    //    if (dsCETResult.Tables[0].Rows[0]["IsCandidateGivenCET"].ToString() == "Y")
                    //    {
                    //        lblAppearedForCETHeader.Text = "Application Number";
                    //        lblAppearedForCET.Text = dsCETResult.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();
                    //        lblCETRollNo.Text = dsCETResult.Tables[0].Rows[0]["CETRollNo"].ToString();
                    //        lblCETPhysicsScore.Text = dsCETResult.Tables[0].Rows[0]["CETPhysicsMarks"].ToString();
                    //        lblCETChemistryScore.Text = dsCETResult.Tables[0].Rows[0]["CETChemistryMarks"].ToString();
                    //        lblCETMathScore.Text = dsCETResult.Tables[0].Rows[0]["CETMathMarks"].ToString();
                    //        lblCETBiologyScore.Text = dsCETResult.Tables[0].Rows[0]["CETBiologyMarks"].ToString();
                    //        lblCETPCMScore.Text = dsCETResult.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString();
                    //        lblCETPCBScore.Text = dsCETResult.Tables[0].Rows[0]["CETPCBTotalMarks"].ToString();
                    //    }
                    //    else
                    //    {
                    //        lblAppearedForCET.Text = "No";
                    //        lblCETRollNoHeader.Text = "";
                    //        trCETScore1.Visible = false;
                    //        trCETScore2.Visible = false;
                    //        trCETScore3.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    lblAppearedForCET.Text = "No";
                    //    lblCETRollNoHeader.Text = "";
                    //    trCETScore1.Visible = false;
                    //    trCETScore2.Visible = false;
                    //    trCETScore3.Visible = false;
                    //}

                    if (obj.CETApplicationFormNo > 0)
                    {
                        lblAppearedForCETHeader.Text = "Application Number";
                        lblAppearedForCET.Text = obj.CETApplicationFormNo.ToString();
                        lblCETRollNo.Text = obj.CETRollNo.ToString();
                        lblCETPhysicsScore.Text = obj.CETPhysicsMarks.ToString();
                        lblCETChemistryScore.Text = obj.CETChemistryMarks.ToString();
                        lblCETMathScore.Text = obj.CETMathMarks.ToString();
                        lblCETBiologyScore.Text = obj.CETBiologyMarks.ToString();
                        lblCETPCMScore.Text = obj.CETPCMTotalMarks.ToString();
                        lblCETPCBScore.Text = obj.CETPCBTotalMarks.ToString();

                        StringMatching stringMatching = new StringMatching();
                        int matchingPercentage = stringMatching.CheckString(obj.CandidateName, obj.CETCandidateName);

                        if (matchingPercentage == 0)
                        {
                            lblCETCandidateName.Text = obj.CETCandidateName + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result) [Not Matching]</font>";
                        }
                        else if (matchingPercentage == 50 && matchingPercentage < 100)
                        {
                            lblCETCandidateName.Text = obj.CETCandidateName + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result) [Partially Matching]</font>";
                        }
                        else
                        {
                            lblCETCandidateName.Text = obj.CETCandidateName + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result)</font>";
                        }
                        //lblCETCandidateName.Text = obj.CETCandidateName.ToString() + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result)</font>";
                        lblCETCandidateName.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        lblAppearedForCET.Text = "No";
                        lblCETRollNoHeader.Text = "";
                        trCETScore1.Visible = false;
                        trCETScore2.Visible = false;
                        trCETScore3.Visible = false;
                        lblCETCandidateName.Visible = false;
                    }

                    lblAppearedForNEET.Text = obj.AppearedForNEET;
                    if (obj.AppearedForNEET == "Yes")
                    {
                        lblNEETRollNo.Text = obj.NEETRollNo.ToString();
                        lblNEETPhysicsScore.Text = obj.NEETPhysicsScore.ToString();
                        lblNEETChemistryScore.Text = obj.NEETChemistryScore.ToString();
                        lblNEETBiologyScore.Text = obj.NEETBiologyScore.ToString();
                        lblNEETTotalScore.Text = obj.NEETTotalScore.ToString();
                        if (Global.CheckNEETResult)
                        {
                            lblNEETName.Text = obj.NEETCName.ToString() + " " + "<font color = 'red' size='2'>(Name As Per NEET Result)</font>";

                            StringMatching stringMatching = new StringMatching();
                            int matchingPercentage = stringMatching.CheckString(obj.CandidateName, obj.NEETCName);

                            if (matchingPercentage == 0)
                            {
                                lblNEETName.Text = obj.NEETCName + " " + "<font color = 'red' size='2'>(Name As Per NEET Result) [Not Matching]</font>";
                            }
                            else if (matchingPercentage == 50 && matchingPercentage < 100)
                            {
                                lblNEETName.Text = obj.NEETCName + " " + "<font color = 'red' size='2'>(Name As Per NEET Result) [Partially Matching]</font>";
                            }
                            else
                            {
                                lblNEETName.Text = obj.NEETCName + " " + "<font color = 'red' size='2'>(Name As Per NEET Result)</font>";
                            }
                            lblNEETName.ForeColor = System.Drawing.Color.Blue;
                        }
                    }
                    else
                    {
                        lblNEETRollNoHeader.Text = "";
                        trNEETScore1.Visible = false;
                        trNEETScore2.Visible = false;
                        lblNEETName.Visible = false;
                    }

                    if (objSessionData.CandidatureTypeID > 7)
                    {
                        Not1.Visible = true;
                        lblDocumenSubmittNote.Text = "NRI/PIO/OCI/CIWGC/FN candidates should send the print of online filled & confirmed application form & required documents by hand/speed post/courier for verification & confirmation to <b>“The Principal, Bombay College of Pharmacy, Kalina, Santacruz, Mumbai – 400 098“</b>";
                    }
                    if (objSessionData.CandidatureTypeID > 14)
                    {
                        Not1.Visible = false;
                        lblDocumenSubmittNote.Text = "";
                    }
                    //gvDocuments.DataSource = reg.getDocumentList(objSessionData.PID);
                    //gvDocuments.DataBind();

                    //for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                    //{
                    //    gvDocuments.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    //}
                    DataSet dsDiscrepanty = reg.GetDiscrepancyDetails(objSessionData.PID);
                    string ScruType = reg.CheckCandidateFCVerificationFor(objSessionData.PID);
                    if (dsDiscrepanty.Tables[0].Rows.Count > 0 && ScruType == "E")
                    {
                        tblDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepanty;
                        gvDiscrepancy.DataBind();
                    }
                    DataSet dsEligibilityRemark = reg.getEligibilityFlag(objSessionData.PID);
                    if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Length > 0 && dsEligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && dsEligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                    {
                        trEligibilityRemark.Visible = true;
                        lblEligibilityRemark.Text += dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString();
                        lblEligibilityRemark.ForeColor = System.Drawing.Color.Red;
                    }
                    if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && dsEligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                    {
                        //tblPrint1.Visible = false;
                        //tblPrint2.Visible = false;
                        //tblHeader1.Visible = false;
                        //tblHeader2.Visible = false;
                        //tblFooter1.Visible = false;
                    }

                    if (objSessionData.CandidatureTypeID == 8 || objSessionData.CandidatureTypeID == 9 || objSessionData.CandidatureTypeID == 10 || objSessionData.CandidatureTypeID == 11 || objSessionData.CandidatureTypeID == 12 || objSessionData.CandidatureTypeID == 13 || objSessionData.CandidatureTypeID == 14 || objSessionData.CandidatureTypeID == 18)
                    {
                        tblEScrutiny.Visible = false;
                        //tblPhysicalScrutiny.Visible = false;
                    }

                    lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                    lblLastModifiedOn.Text = obj.LastModifiedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", obj.LastModifiedOn);
                    lblLastModifiedBy.Text = obj.LastModifiedBy + ", " + obj.LastModifiedByIPAddress;

                    //if (objSessionData.StepID >= 9 && reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "N" && !reg.CheckFCVerificationStatus(objSessionData.PID))
                    //{
                    //    if (FCVerificationStatus == 'N')
                    //    {
                    //        Response.Redirect("../CandidateModule/frmVerifyAndConfirmApplicationForm.aspx", true);
                    //    }
                    //}

                    lblDisplayDocumentSubmissionStatus.Text = "";
                    string BlockFlag = "";
                    string NationalityFlag = "";
                    string CandidatureTypeFlag = "";
                    string CasteCertificateFlag = "";
                    string CasteValidityCertificateFlag = "";
                    string CVCReceiptFlag = "";
                    string NonCreamyLayerCertificateFlag = "";
                    string NCLReceiptFlag = "";
                    string EWSFlag = "";
                    string PHTypeFlag = "";
                    string DefenceTypeFlag = "";
                    string OrphanFlag = "";
                    string TFWSFlag = "";
                    string MinorityFlag = "";
                    string IGDFlag = "";
                    Int32 CategoryChangeFlag = 0;
                    string EWSReceiptFlag = "";

                    gvDocumentsNotSubmitted.DataSource = reg.GetDocumentListByUploadedFlag(objSessionData.PID, "N");
                    gvDocumentsNotSubmitted.DataBind();
                    if (gvDocumentsNotSubmitted.Rows.Count >0)
                    {
                        trDocumentsNotSubmitted1.Visible = true;
                        trDocumentsNotSubmitted2.Visible = true;                       
                    }
                    gvDocumentsSubmitted.DataSource = reg.GetDocumentListByUploadedFlag(objSessionData.PID, "Y");
                    gvDocumentsSubmitted.DataBind();
                    for (Int32 i = 0; i < gvDocumentsNotSubmitted.Rows.Count; i++)
                    {
                        gvDocumentsNotSubmitted.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    }
                    for (Int32 i = 0; i < gvDocumentsSubmitted.Rows.Count; i++)
                    {
                        gvDocumentsSubmitted.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    }
                    for (Int32 i = 0; i < gvDocumentsNotSubmitted.Rows.Count; i++)
                    {

                        Int32 DocumentID = Int32.Parse(((Label)gvDocumentsNotSubmitted.Rows[i].FindControl("lblDocumentID")).Text);
                        string DocumentDetails = gvDocumentsNotSubmitted.Rows[i].Cells[1].Text;

                        if (DocumentID == 1)
                        {
                            //BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                            NationalityFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 2)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 3)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 4)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 5)
                        {
                            CandidatureTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 6)
                        {
                            CandidatureTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 7)
                        {
                            CandidatureTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 8)
                        {
                            CandidatureTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 9)
                        {
                            CandidatureTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 10)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 11)
                        {
                            CandidatureTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 12)
                        {
                            CandidatureTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 20)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 21)
                        {
                            CasteCertificateFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 22)
                        {
                            CasteValidityCertificateFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 23)
                        {
                            CVCReceiptFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 24)
                        {
                            NonCreamyLayerCertificateFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 40)
                        {
                            NCLReceiptFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 25)
                        {
                            PHTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 26)
                        {
                            PHTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 27)
                        {
                            DefenceTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 28)
                        {
                            DefenceTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 29)
                        {
                            DefenceTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 30)
                        {
                            DefenceTypeFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 32)
                        {
                            TFWSFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 33)
                        {
                            MinorityFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 35)
                        {
                            OrphanFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 36)
                        {
                            EWSFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 42)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 43)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 45)
                        {
                            IGDFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 47)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 81)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 82)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 83)
                        {
                            BlockFlag += "As you have not Uploaded  " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 84)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 85)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 86)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 87)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 88)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 89)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 90)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 91)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 92)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 93)
                        {
                            BlockFlag += "As you have not Uploaded  " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 94)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 95)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 96)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 97)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 98)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 99)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 100)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 101)
                        {
                            BlockFlag += "As you have not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 102)
                        {
                            EWSFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                        }
                    }

                    for (Int32 i = 0; i < gvDocumentsSubmitted.Rows.Count; i++)
                    {
                        Int32 DocumentID = Int32.Parse(((Label)gvDocumentsSubmitted.Rows[i].FindControl("lblDocumentID")).Text);

                        if (DocumentID == 24)
                        {
                            // trNCLIssueDate.Visible = true;
                            // trNCLValidUpTo.Visible = true;
                        }
                        else if (DocumentID == 25)
                        {
                            PHTypeFlag += "NA";
                        }
                        else if (DocumentID == 26)
                        {
                            PHTypeFlag += "NA";
                        }
                        else if (DocumentID == 27)
                        {
                            DefenceTypeFlag += "NA";
                        }
                        else if (DocumentID == 28)
                        {
                            DefenceTypeFlag += "NA";
                        }
                        else if (DocumentID == 29)
                        {
                            DefenceTypeFlag += "NA";
                        }
                        else if (DocumentID == 30)
                        {
                            DefenceTypeFlag += "NA";
                        }
                        else if (DocumentID == 32)
                        {
                            TFWSFlag += "NA";
                        }
                        else if (DocumentID == 33)
                        {
                            MinorityFlag += "NA";
                        }
                        else if (DocumentID == 35)
                        {
                            OrphanFlag += "NA";
                        }
                        else if (DocumentID == 36)
                        {
                            EWSFlag += "NA";
                        }
                        else if (DocumentID == 45)
                        {
                            IGDFlag += "NA";
                        }
                    }
                    if (BlockFlag.Length > 0)
                    {
                        BlockFlag += "And Hence, Candidate is not Allowed to Submit the Application Form.";
                        lblDisplayDocumentSubmissionStatus.Text += BlockFlag + "<br /><br />";

                    }
                    else
                    {
                        if (CandidatureTypeFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, Your Type of Candidature will be converted to 'OMS'.<br />";
                            CandidatureTypeFlag += "And hence, Your Category will be converted to 'OPEN'.<br />";
                            CategoryChangeFlag = 1;
                            if (PHTypeFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, you will not avail the Privilege for Person with Disability Quota.<br />";
                                PHTypeFlag = "Change";
                            }
                            if (DefenceTypeFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, you will not avail the Privilege for Defence Employee Quota.<br />";
                                DefenceTypeFlag = "Change";
                            }
                            if (EWSFlag.Length > 0||EWSReceiptFlag.Length>0)
                            {
                                CandidatureTypeFlag += "And hence, you will not avail the Privilege for EWS Quota.<br />";
                                EWSFlag = "Change";
                            }
                            if (TFWSFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, you will not avail the Privilege for TFWS Quota.<br />";
                                TFWSFlag = "Change";
                            }
                            if (OrphanFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, you will not avail the Privilege for Orphan Quota.<br />";
                                OrphanFlag = "Change";
                            }
                            if (MinorityFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, you will not avail the Privilege for Linguistic / Religious Minority Quota.<br />";
                                MinorityFlag = "Change";
                            }
                            if (IGDFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, you will not avail the Privilege for Intermediate Grade Drawing.<br />";
                                IGDFlag = "Change";
                            }
                            lblDisplayDocumentSubmissionStatus.Text += CandidatureTypeFlag + "<br /><br />";
                        }
                        else
                        {
                            if (CasteCertificateFlag.Length > 0 || CasteValidityCertificateFlag.Length > 0 || CVCReceiptFlag.Length > 0 || NonCreamyLayerCertificateFlag.Length > 0 || NCLReceiptFlag.Length > 0)
                            {
                                CasteCertificateFlag += CasteValidityCertificateFlag + CVCReceiptFlag + NonCreamyLayerCertificateFlag + NCLReceiptFlag + "And hence, Your Category will be converted to 'OPEN'.";
                                lblDisplayDocumentSubmissionStatus.Text += CasteCertificateFlag + "<br /><br />";
                                CategoryChangeFlag = 1;
                            }
                            if (PHTypeFlag.Length > 2)
                            {
                                PHTypeFlag += "And hence, you will not avail the Privilege for Person with Disability Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += PHTypeFlag + "<br /><br />";
                            }
                            if (DefenceTypeFlag.Length > 4)
                            {
                                DefenceTypeFlag += "And hence, you will not avail the Privilege for Defence Employee Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += DefenceTypeFlag + "<br /><br />";
                            }
                            if (EWSFlag.Length > 2 || EWSReceiptFlag.Length>0)
                            {
                                EWSFlag += "And hence, you will not avail the Privilege for EWS Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += EWSFlag + "<br /><br />";
                            }
                            if (TFWSFlag.Length > 2)
                            {
                                TFWSFlag += "And hence, you will not avail the Privilege for TFWS Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += TFWSFlag + "<br /><br />";
                            }
                            if (OrphanFlag.Length > 2)
                            {
                                OrphanFlag += "And hence, you will not avail the Privilege for Orphan Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += OrphanFlag + "<br /><br />";
                            }
                            if (MinorityFlag.Length > 2)
                            {
                                MinorityFlag += "And hence, you will not avail the Privilege for Linguistic / Religious Minority Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += MinorityFlag + "<br /><br />";
                            }
                            if (IGDFlag.Length > 2)
                            {
                                IGDFlag += "And hence, you will not avail the Privilege for Intermediate Grade Drawing.";
                                lblDisplayDocumentSubmissionStatus.Text += IGDFlag + "<br /><br />";
                            }
                        }
                        if (lblDisplayDocumentSubmissionStatus.Text.Length > 0)
                        {
                            Int32 IsCandidatureTypeChanged = 0;
                            Int32 IsCategoryChanged = 0;
                            Int32 IsPHTypeChanged = 0;
                            Int32 IsEWSChanged = 0;

                            if (CandidatureTypeFlag.Length > 0)
                            {
                                IsCandidatureTypeChanged = 1;
                            }
                            if (CategoryChangeFlag == 1)
                            {
                                IsCategoryChanged = 1;
                            }
                            if (PHTypeFlag.Length > 2)
                            {
                                IsPHTypeChanged = 1;
                            }
                            if (EWSFlag.Length > 2|| EWSReceiptFlag.Length>0)
                            {
                                IsEWSChanged = 1;
                            }
                            Int32 ProposedApplicationFeeToBePaid = reg.getProposedApplicationFeeToBePaid(objSessionData.PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsEWSChanged);

                            if (ProposedApplicationFeeToBePaid > 0)
                            {
                                //lblDisplayDocumentSubmissionStatus.Text += "<font size='4'><b>Please collect Rs. " + ProposedApplicationFeeToBePaid.ToString() + "/- ONLINE as a difference in fee.</b></font><br /><br />";
                            }
                            lblDisplayDocumentSubmissionStatus.Visible = true;
                        }
                    }


                    //lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    //lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                    //lblLastModifiedOn.Text = obj.LastModifiedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", obj.LastModifiedOn);
                    //lblLastModifiedBy.Text = obj.LastModifiedBy + ", " + obj.LastModifiedByIPAddress;
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        //protected void btnUploadDocuments_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("../CandidateModule/frmUploadRequiredDocuments.aspx", true);
        //}

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            lblDisplayDocumentSubmissionStatus1.Text = "";
            SessionData objSessionData = (SessionData)Session["SessionData"];
            string BlockFlag = "";
            string NationalityFlag = "";
            string CandidatureTypeFlag = "";
            string CasteCertificateFlag = "";
            string CasteValidityCertificateFlag = "";
            string CVCReceiptFlag = "";
            string NonCreamyLayerCertificateFlag = "";
            string NCLReceiptFlag = "";
            string EWSFlag = "";
            string PHTypeFlag = "";
            string DefenceTypeFlag = "";
            string OrphanFlag = "";
            string TFWSFlag = "";
            string MinorityFlag = "";
            string IGDFlag = "";
            Int32 CategoryChangeFlag = 0;
            string EWSReceiptFlag = "";

            gvDocumentsNotSubmitted.DataSource = reg.GetDocumentListByUploadedFlag(objSessionData.PID, "N");
            gvDocumentsNotSubmitted.DataBind();

            gvDocumentsSubmitted.DataSource = reg.GetDocumentListByUploadedFlag(objSessionData.PID, "Y");
            gvDocumentsSubmitted.DataBind();

            for (Int32 i = 0; i < gvDocumentsNotSubmitted.Rows.Count; i++)
            {
                gvDocumentsNotSubmitted.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
            }
            for (Int32 i = 0; i < gvDocumentsSubmitted.Rows.Count; i++)
            {
                gvDocumentsSubmitted.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
            }

            for (Int32 i = 0; i < gvDocumentsNotSubmitted.Rows.Count; i++)
            {

                Int32 DocumentID = Int32.Parse(((Label)gvDocumentsNotSubmitted.Rows[i].FindControl("lblDocumentID")).Text);
                string DocumentDetails = gvDocumentsNotSubmitted.Rows[i].Cells[1].Text;

                if (DocumentID == 1)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    //NationalityFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 5)
                {
                    CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 6)
                {
                    CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 7)
                {
                    CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 8)
                {
                    CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 9)
                {
                    CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 10)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 11)
                {
                    CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 12)
                {
                    CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 20)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 21)
                {
                    CasteCertificateFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 22)
                {
                    CasteValidityCertificateFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 23)
                {
                    CVCReceiptFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 24)
                {
                    NonCreamyLayerCertificateFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 40)
                {
                    NCLReceiptFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 25)
                {
                    PHTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 26)
                {
                    PHTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 27)
                {
                    DefenceTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 28)
                {
                    DefenceTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 29)
                {
                    DefenceTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 30)
                {
                    DefenceTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 32)
                {
                    TFWSFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 33)
                {
                    MinorityFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 35)
                {
                    OrphanFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 36)
                {
                    EWSFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 42)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 43)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 45)
                {
                    IGDFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 47)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 51)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 73)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 81)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 82)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 83)
                {
                    BlockFlag += "As you have not uploaded the  " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 84)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 85)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 86)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 87)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 88)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 89)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 90)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 91)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 92)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 93)
                {
                    BlockFlag += "As you have not uploaded the  " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 94)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 95)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 96)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 97)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 98)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 99)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 100)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 101)
                {
                    BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
                else if (DocumentID == 102)
                {
                    EWSFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                }
            }

            for (Int32 i = 0; i < gvDocumentsSubmitted.Rows.Count; i++)
            {
                Int32 DocumentID = Int32.Parse(((Label)gvDocumentsSubmitted.Rows[i].FindControl("lblDocumentID")).Text);

                if (DocumentID == 24)
                {
                    // trNCLIssueDate.Visible = true;
                    // trNCLValidUpTo.Visible = true;
                }
                else if (DocumentID == 25)
                {
                    PHTypeFlag += "NA";
                }
                else if (DocumentID == 26)
                {
                    PHTypeFlag += "NA";
                }
                else if (DocumentID == 27)
                {
                    DefenceTypeFlag += "NA";
                }
                else if (DocumentID == 28)
                {
                    DefenceTypeFlag += "NA";
                }
                else if (DocumentID == 29)
                {
                    DefenceTypeFlag += "NA";
                }
                else if (DocumentID == 30)
                {
                    DefenceTypeFlag += "NA";
                }
                else if (DocumentID == 32)
                {
                    TFWSFlag += "NA";
                }
                else if (DocumentID == 33)
                {
                    MinorityFlag += "NA";
                }
                else if (DocumentID == 35)
                {
                    OrphanFlag += "NA";
                }
                else if (DocumentID == 36)
                {
                    EWSFlag += "NA";
                }
                else if (DocumentID == 45)
                {
                    IGDFlag += "NA";
                }
            }
            if (BlockFlag.Length > 0)
            {
                SessionData objSessionDat = (SessionData)Session["SessionData"];
                BlockFlag += "And Hence, You are not Allowed to Submit the Application Form.";
                lblDisplayDocumentSubmissionStatus1.Text += BlockFlag + "<br /><br />";
                lblDisplayDocumentSubmissionStatus1.Visible = true;
                shInfo.SetMessage(BlockFlag + "<br /><br />", ShowMessageType.Information);
            }
            else
            {
                if (CandidatureTypeFlag.Length > 0)
                {
                    
                    CandidatureTypeFlag += "And hence, Your Category will be converted to 'OPEN'.<br />";
                    CategoryChangeFlag = 1;
                    if (PHTypeFlag.Length > 0)
                    {
                        CandidatureTypeFlag += "And hence, you can not avail the Privilege for Person with Disability Quota.<br />";
                        PHTypeFlag = "Change";
                    }
                    if (DefenceTypeFlag.Length > 0)
                    {
                        CandidatureTypeFlag += "And hence, you can not avail the Privilege for Defence Employee Quota.<br />";
                        DefenceTypeFlag = "Change";
                    }
                    if (EWSFlag.Length > 0 || EWSReceiptFlag.Length > 0)
                    {
                        CandidatureTypeFlag += "And hence, you can not avail the Privilege for EWS Quota.<br />";
                        EWSFlag = "Change";
                    }
                    if (TFWSFlag.Length > 0)
                    {
                        CandidatureTypeFlag += "And hence, you can not avail the Privilege for TFWS Quota.<br />";
                        TFWSFlag = "Change";
                    }
                    if (OrphanFlag.Length > 0)
                    {
                        CandidatureTypeFlag += "And hence, you can not avail the Privilege for Orphan Quota.<br />";
                        OrphanFlag = "Change";
                    }
                    if (MinorityFlag.Length > 0)
                    {
                        CandidatureTypeFlag += "And hence, you can not avail the Privilege for Linguistic / Religious Minority Quota.<br />";
                        MinorityFlag = "Change";
                    }
                    //if (IGDFlag.Length > 0)
                    //{
                    //    CandidatureTypeFlag += "And hence, you can not avail the Privilege for Intermediate Grade Drawing.<br />";
                    //    IGDFlag = "Change";
                    //}
                    lblDisplayDocumentSubmissionStatus1.Text += CandidatureTypeFlag + "<br /><br />";
                }
                else
                {
                    if (CasteCertificateFlag.Length > 0 || CasteValidityCertificateFlag.Length > 0 || CVCReceiptFlag.Length > 0 || NonCreamyLayerCertificateFlag.Length > 0 || NCLReceiptFlag.Length > 0)
                    {
                        CasteCertificateFlag += CasteValidityCertificateFlag + CVCReceiptFlag + NonCreamyLayerCertificateFlag + NCLReceiptFlag + "And hence, Your Category will be converted to 'OPEN'.";
                        lblDisplayDocumentSubmissionStatus1.Text += CasteCertificateFlag + "<br /><br />";
                        CategoryChangeFlag = 1;
                    }
                    if (PHTypeFlag.Length > 2)
                    {
                        PHTypeFlag += "And hence, you can not avail the Privilege for Person with Disability Quota.";
                        lblDisplayDocumentSubmissionStatus1.Text += PHTypeFlag + "<br /><br />";
                    }
                    if (DefenceTypeFlag.Length > 4)
                    {
                        DefenceTypeFlag += "And hence, you can not avail the Privilege for Defence Employee Quota.";
                        lblDisplayDocumentSubmissionStatus1.Text += DefenceTypeFlag + "<br /><br />";
                    }
                    if (EWSFlag.Length > 2 || EWSReceiptFlag.Length > 0)
                    {
                        EWSFlag += "And hence, you can not avail the Privilege for EWS Quota.";
                        lblDisplayDocumentSubmissionStatus1.Text += EWSFlag + "<br /><br />";
                    }
                    if (TFWSFlag.Length > 2)
                    {
                        TFWSFlag += "And hence, you can not avail the Privilege for TFWS Quota.";
                        lblDisplayDocumentSubmissionStatus1.Text += TFWSFlag + "<br /><br />";
                    }
                    if (OrphanFlag.Length > 2)
                    {
                        OrphanFlag += "And hence, you can not avail the Privilege for Orphan Quota.";
                        lblDisplayDocumentSubmissionStatus1.Text += OrphanFlag + "<br /><br />";
                    }
                    if (MinorityFlag.Length > 2)
                    {
                        MinorityFlag += "And hence, you can not avail the Privilege for Linguistic / Religious Minority Quota.";
                        lblDisplayDocumentSubmissionStatus1.Text += MinorityFlag + "<br /><br />";
                    }
                    if (IGDFlag.Length > 2)
                    {
                        IGDFlag += "And hence, you can not avail the Privilege for Intermediate Grade Drawing.";
                        lblDisplayDocumentSubmissionStatus1.Text += IGDFlag + "<br /><br />";
                    }
                }
                if (lblDisplayDocumentSubmissionStatus1.Text.Length > 0)
                {
                    Int32 IsCandidatureTypeChanged = 0;
                    Int32 IsCategoryChanged = 0;
                    Int32 IsPHTypeChanged = 0;
                    Int32 IsEWSChanged = 0;

                    if (CandidatureTypeFlag.Length > 0)
                    {
                        IsCandidatureTypeChanged = 1;
                    }
                    if (CategoryChangeFlag == 1)
                    {
                        IsCategoryChanged = 1;
                    }
                    if (PHTypeFlag.Length > 2)
                    {
                        IsPHTypeChanged = 1;
                    }
                    if (EWSFlag.Length > 2 || EWSReceiptFlag.Length > 0)
                    {
                        IsEWSChanged = 1;
                    }
                    //Int32 ProposedApplicationFeeToBePaid = reg.getProposedApplicationFeeToBePaid(objSessionData.PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsEWSChanged);

                    //if (ProposedApplicationFeeToBePaid > 0)
                    //{
                    //    lblDisplayDocumentSubmissionStatus1.Text += "<font size='4'><b>You have to Pay Rs. " + ProposedApplicationFeeToBePaid.ToString() + "/- ONLINE as a difference in fee.</b></font><br /><br />";
                    //}
                    shInfo.SetMessage(lblDisplayDocumentSubmissionStatus1.Text, ShowMessageType.Information);
                    contentDocumentConferamtion.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowConfirmationBox();", true);
                    lblDisplayDocumentSubmissionStatus1.Visible = true;
                    // trYesNo.Visible = true;
                    btnProceed.Visible = false;
                    btnProceed1.Visible = false;
                }
                else
                {
                    Response.Redirect("../CandidateModule/frmVerifyAndConfirmApplicationForm.aspx", true);
                }
            }

        }
        protected void btnYes_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModule/frmVerifyAndConfirmApplicationForm.aspx", true);
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            btnProceed.Visible = true;
            btnProceed1.Visible = true;
            lblDisplayDocumentSubmissionStatus.Text = "";

        }


    }
}