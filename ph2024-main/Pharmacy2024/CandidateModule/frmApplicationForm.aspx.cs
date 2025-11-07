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

namespace Pharmacy2024.CandidateModule
{
    public partial class frmApplicationForm : System.Web.UI.Page
    {
        public string AdmissionYear = Global.AdmissionYear;
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string NEETName = Global.NEETName;
        public string CurrentYear = Global.CurrentYear;
        public string MHTCETName = Global.MHTCETName;
        private readonly IBusinessService reg = new BusinessServiceImp();
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
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(objSessionData.PID);
                    Int32 ApplicationFeePaid = reg.getApplicationFeePaidAmount(objSessionData.PID);
                    DataSet ds = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmApplicationForm");

                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                  

                    if (ds.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(ds.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    else
                    {
                        if (objSessionData.StepID >= 9)
                        {
                            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormLinks = true;
                        }

                        PersonalInformation obj = reg.getPersonalInformation(objSessionData.PID);

                        if (ApplicationFeeToBePaid > 0 && objSessionData.ApplicationFormStatus != 'A')
                        {
                            Response.Redirect("../CandidateModule/frmPayApplicationFee", true);
                        }

                        if (obj.FinalHomeUniversity == "NA")
                        {
                            if (objSessionData.CandidatureTypeID == 1 || objSessionData.CandidatureTypeID == 2 || objSessionData.CandidatureTypeID == 3 || objSessionData.CandidatureTypeID == 4 || objSessionData.CandidatureTypeID == 5)
                            {
                                Response.Redirect("../CandidateModule/frmHomeUniversityAndCategoryDetails", true);
                            }
                            else
                            {
                                HomeUniversityAndCategoryDetails objHUC = new HomeUniversityAndCategoryDetails();

                                objHUC.PID = objSessionData.PID;
                                objHUC.DocumentForTypeACode = 'N';
                                objHUC.DocumentOfCode = 'N';
                                objHUC.MothersName = "";
                                objHUC.SSCDistrictID = 0;
                                objHUC.HSCDistrictID = 0;
                                objHUC.HSCTalukaID = 0;
                                objHUC.HomeUniversityID = 99;
                                objHUC.CategoryID = 0;
                                objHUC.CasteNameForOpen = "";
                                objHUC.CasteID = 0;

                                if (reg.saveHomeUniversityAndCategoryDetails(objHUC, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                {
                                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                }
                            }
                        }
                         
                        if (objSessionData.CandidatureTypeID != 15 && objSessionData.CandidatureTypeID != 16)
                        {
                            if (objSessionData.StepID >= 9 && reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "N" && !reg.CheckFCVerificationStatus(objSessionData.PID))
                            {
                                //Response.Redirect("../CandidateModule/frmVerifyAndConfirmApplicationForm.aspx", true);
                                //if (FCVerificationStatus == 'U')
                                //{
                                // Response.Redirect("../CandidateModule/frmVerifyAndConfirmApplicationForm.aspx", true);
                                Response.Redirect("../CandidateModule/frmPreviewApplicationForm", true);
                                //}

                            }
                        }
                        AzureDocumentUpload azObj = new AzureDocumentUpload();
                        imgPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(objSessionData.PID, "Photograph"));
                        imgSignature.ImageUrl = imgSignature1.ImageUrl= azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(objSessionData.PID, "Signature"));
                        //imgPhotograph.ImageUrl = UserInfo.GetImageURL(objSessionData.PID, "Photograph");
                        //imgSignature.ImageUrl = imgSignature1.ImageUrl = UserInfo.GetImageURL(objSessionData.PID, "Signature");
                        ////if (Convert.ToDateTime("2020-07-01 23:59:59") < reg.getApplicationFormCreatedDate(objSessionData.PID))
                        if (Convert.ToDateTime(ConfigurationManager.AppSettings["FormFillingCAPDate"]) < reg.getApplicationFormCreatedDate(objSessionData.PID))
                        {
                            lblTitle.Visible = true;
                        }
                        string ScruType = reg.CheckCandidateFCVerificationFor(objSessionData.PID);
                        if (Global.CurrentScrutinyMode == "Both")
                        {
                            DataSet dsSlot = reg.GetCandidateBookingSlotDetails(objSessionData.PID);
                            if (objSessionData.CandidatureTypeID == 8 || objSessionData.CandidatureTypeID == 9 || objSessionData.CandidatureTypeID == 10 || objSessionData.CandidatureTypeID == 11 || objSessionData.CandidatureTypeID == 12 || objSessionData.CandidatureTypeID == 13 || objSessionData.CandidatureTypeID == 14 || objSessionData.CandidatureTypeID == 18)
                            {
                                tblEScrutiny.Visible = false;
                                tblPhysicalScrutiny.Visible = false;
                                if (ScruType == "P")
                                {
                                    if (dsSlot.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsSlot.Tables[0].Rows[0]["FCID"].ToString() != "SC3016")
                                        {
                                            reg.SaveCandidateBookedSlot(1050, 7, objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                                        }
                                    }
                                }
                                else if (ScruType == "E")
                                {
                                    reg.ChangeFCVerificationMode(objSessionData.PID, "P", Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                                    reg.UpdateCandidateFCVerificationFor(objSessionData.PID, "P", Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                                    reg.SaveCandidateBookedSlot(1050, 7, objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                                }
                            }
                            if (dsSlot.Tables[0].Rows.Count > 0 && ScruType != "E")
                            {
                                tblPhysicalScrutiny.Visible = true;
                                lblSlotDateTime.Text = Convert.ToDateTime(dsSlot.Tables[0].Rows[0]["SlotDate"]).ToString("dd/MM/yyyy") + " - " + dsSlot.Tables[0].Rows[0]["SlotTime"].ToString();
                                lblFCDetails.Text = dsSlot.Tables[0].Rows[0]["FCDetails"].ToString();
                            }

                            if (objSessionData.CandidatureTypeID != 15 && objSessionData.CandidatureTypeID != 16)
                            {
                                if (ScruType == "E")
                                {
                                    DataSet dsEScr = reg.GetCandidateEFCAllotted(objSessionData.PID);
                                    if (dsEScr.Tables[0].Rows.Count > 0)
                                    {
                                        tblEScrutiny.Visible = true;
                                        lblEScrutiny.Text = dsEScr.Tables[0].Rows[0]["AFCName"].ToString() + "  ," + Convert.ToDateTime(dsEScr.Tables[0].Rows[0]["CreatedOn"]).ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", Convert.ToDateTime(dsEScr.Tables[0].Rows[0]["CreatedOn"]));
                                    }
                                }
                            }
                        }
                       
                        lblApplicationID.Text = obj.ApplicationID;
                        lblVersionNo.Text = obj.VersionNo.ToString();

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
                            lblQ2.Text = "District from which Candidate has Passed HSC / Diploma";
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
                            lblQ2.Text = "District from which Candidate has Passed HSC / Diploma";
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

                        //lblSSCMathMarksObtained.Text = obj.SSCMathMarksObtained.ToString();
                        //lblSSCMathMarksOutOf.Text = obj.SSCMathMarksOutOf.ToString();
                        //lblSSCMathPercentage.Text = obj.SSCMathPercentage.ToString();
                        //lblSSCTotalMarksObtained.Text = obj.SSCTotalMarksObtained.ToString();
                        //lblSSCTotalMarksOutOf.Text = obj.SSCTotalMarksOutOf.ToString();
                        //lblSSCTotalPercentage.Text = obj.SSCTotalPercentage.ToString();
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
                        if (objSessionData.CandidatureTypeID == 11 || objSessionData.CandidatureTypeID == 12 || objSessionData.CandidatureTypeID == 13 || objSessionData.CandidatureTypeID == 14)
                        {
                            trFCRApplicationNo.Visible = true;
                            lblFCRApplicationNo.Text = obj.FCRApplicationID;
                        }
                        else
                        {
                            trFCRApplicationNo.Visible = false;
                        }
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
                        //  lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult;
                        if (obj.AppearedForDiploma == "Yes")
                        {
                            trDiplomaTotalMarks.Visible = true;
                            if (obj.DiplomaMarksType == "CGPA")
                            {
                                lblDiplomaTotalMarks.Text = "Diploma CGPA";
                            }
                        }

                        if ((objSessionData.CandidatureTypeID == 1 || objSessionData.CandidatureTypeID == 5) && obj.HSCPlace != "India")
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
                            //trCETScore3.Visible = false;
                            lblNEETName.Visible = false;

                            if (objSessionData.CandidatureTypeID < 11 && objSessionData.CETApplicationFormNo == 0)
                            {
                                Response.Redirect("../CandidateModule/frmNEETDetails");
                            }
                        }
                        if (objSessionData.CandidatureTypeID == 8 || objSessionData.CandidatureTypeID == 9 || objSessionData.CandidatureTypeID == 10 || objSessionData.CandidatureTypeID == 11 || objSessionData.CandidatureTypeID == 12 || objSessionData.CandidatureTypeID == 13 || objSessionData.CandidatureTypeID == 14 || objSessionData.CandidatureTypeID == 18)
                        {
                            tblEScrutiny.Visible = false;
                            tblPhysicalScrutiny.Visible = false;
                        }

                        gvDocuments.DataSource = reg.getDocumentList(objSessionData.PID);
                        gvDocuments.DataBind();

                        for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                        {
                            gvDocuments.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        }

                        if (objSessionData.CandidatureTypeID > 7)
                        {
                            Not1.Visible = true;
                            lblDocumenSubmittNote.Text = "NRI/PIO/OCI/CIWGC/FN candidates should send the print of online filled & confirmed application form & required documents by hand/speed post/courier for verification & confirmation to <b>“The Principal, Bombay College of Pharmacy, Kalina, Santacruz, Mumbai – 400 098“</b>";
                        }

                        DataSet dsEligibilityRemark = reg.getEligibilityFlag(objSessionData.PID);
                        if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Length > 0)
                        {
                            
                            if (Convert.ToInt16(dsEligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString()) == 0 && Convert.ToInt16(dsEligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString()) == 0)
                            {
                                lblEligibilityRemark.ForeColor = System.Drawing.Color.Red;
                                trEligibilityRemark.Visible = true;
                                lblEligibilityRemark.Text += dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString();
                                lblEligibilityRemark.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && dsEligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                        {
                            tblPrint1.Visible = false;
                            tblPrint2.Visible = false;
                            tblHeader1.Visible = false;
                            tblHeader2.Visible = false;
                            tblFooter1.Visible = false;
                        }

                        lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                        lblLastModifiedOn.Text = obj.LastModifiedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", obj.LastModifiedOn);
                        lblLastModifiedBy.Text = obj.LastModifiedBy + ", " + obj.LastModifiedByIPAddress;
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnUploadDocuments_Click(object sender, EventArgs e)
        {
            //Response.Redirect("../CandidateModule/frmUploadRequiredDocuments", true);
            Response.Redirect("../CandidateModule/frmUploadRequiredDocumentsStep", true);
        }
    }
}