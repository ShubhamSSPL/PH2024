using AjaxPro;
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.E_FCModule
{
    public partial class VerificationAppliction : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        AzureDocumentUpload objDU = new AzureDocumentUpload();
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string NEETName = Global.NEETName;
        public string MHTCETName = Global.MHTCETName;
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) == 91 || Convert.ToInt32(Session["UserTypeID"].ToString()) == 43)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if ((DateTime.Now < Global.DocumentVerificationStartDateTime || DateTime.Now > Global.DocumentVerificationEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            if (reg.CheckISEFC(Session["UserLoginId"].ToString()) == "N" && (Convert.ToInt16(Session["UserTypeID"]) == 23 || Convert.ToInt16(Session["UserTypeID"]) == 24))
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    hdnApplicationURL.Value = ConfigurationManager.AppSettings["ApplicationURL"];
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                    }

                    Int32 res = reg.CheckDiscrepancyExists(PID);
                    if (res == 2) //Not Attepted Compulsory Discrepancy Types exists, FC need to attempt verification for those discrepancy Types
                    {
                        shInfo.SetMessage("Please complete all verification steps and then proceed.", ShowMessageType.Information);
                        btnProceed.Visible = false;
                        btnBack.Visible = true;
                        shInfo.Focus();
                    }
                    else
                    {
                        btnProceed.Visible = true;
                        btnBack.Visible = false;
                    }

                    PersonalInformation obj = reg.getPersonalInformation(PID);
                    Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(PID);
                    Int32 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                    //Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);
                    //Int32 ApplicationFeePaid = reg.getApplicationFeePaidAmount(PID);
                    //Int32 CandidatureTypeID = obj.FinalCandidatureTypeID;
                    Int64 CETApplicationFormNo = obj.CETApplicationFormNo;
                    Int32 ApplicationFeePaid = obj.CETApplicationFee + obj.OnlineApplicationFee;
                    AjaxPro.Utility.RegisterTypeForAjax(typeof(EVerificationCandidatureType));
                    //string EligibilityRemark = reg.getEligibilityFlag(PID);
                    //if (EligibilityRemark.Length > 0)
                    //{
                    //    shInfo.SetMessage(EligibilityRemark, ShowMessageType.Information);
                    //    btnProceed.Visible = false;
                    //}
                    //string ForSEBC = "N";
                    if (Request.QueryString["ForSEBC"] != null)
                    {
                  //      ForSEBC = Request.QueryString["ForSEBC"].ToString();
                    }

                    DataSet ds = reg.GetApplicationFormConfirmationDetailsGrivance(PID);
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        if (Global.CheckDuplicateMobileNo == 1 && reg.isApplicationFormConfirmedUsingThisMobileNo(obj.MobileNo))//&& ForSEBC=="N"
                        {
                            shInfo.SetMessage("Application Form using mobile number " + DataEncryption.DecryptDataByEncryptionKey(obj.MobileNo) + " is already confirmed. Please change mobile number.", ShowMessageType.Information);
                           // btnProceed.Visible = false;
                        }
                        DataSet dsChkCETApplicationNo = reg.isApplicationFormConfirmedUsingThisCETApplicationNo(CETApplicationFormNo, PID);
                        if (dsChkCETApplicationNo.Tables[0].Rows.Count > 0)
                        {
                            if (dsChkCETApplicationNo.Tables[0].Rows[0]["Status"].ToString() == "0")
                            {
                                //string sCETApplicationNumber = dsChkCETApplicationNo.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();
                                string sApplicationID = dsChkCETApplicationNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                                string sConfirmedBy = dsChkCETApplicationNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                                shInfo.SetMessage("Application Form using CET Application Number " + CETApplicationFormNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
                               // btnProceed.Visible = false;
                            }
                        }
                    }

                    DataSet dsEligibilityRemark = reg.getEligibilityFlag(PID);
                    if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Length > 0)
                    {
                        if (dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Contains("You are NOT ELIGIBLE for Admission in B.Pharmacy & Post Graduate Pharm.D. "))
                        {
                            shInfo.SetMessage((dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString()), ShowMessageType.Information);
                            //btnProceed.Visible = false;
                        }
                         
                    }
                 
                    //if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && dsEligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                    //{
                    //    tblPrint1.Visible = false;
                    //    tblPrint2.Visible = false;
                    //    tblHeader1.Visible = false;
                    //    tblHeader2.Visible = false;
                    //    tblFooter1.Visible = false;
                    //}
                    //string EligibilityRemark = reg.getEligibilityFlag(PID);
                    //if (EligibilityRemark.Length > 0)
                    //{
                    //    shInfo.SetMessage(EligibilityRemark, ShowMessageType.Information);
                    //    btnProceed.Visible = false;
                    //}


                    if (obj.FinalHomeUniversity == "NA")
                    {
                        if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4 || CandidatureTypeID == 5)
                        {
                           // Response.Redirect("../AFCModule/frmEditHomeUniversityAndCategoryDetails?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                        else
                        {
                            HomeUniversityAndCategoryDetails objHUC = new HomeUniversityAndCategoryDetails();

                            objHUC.PID = PID;
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

                    //if (ApplicationFeeToBePaid > 0)
                    //{
                    //    Session["FeeGroupId"] = null;
                    //    Session["PhaseId"] = null;
                    //    Session["PayeeUserTypeId"] = null;
                    //    Session["PayeeId"] = null;

                    //    Session["FeeGroupId"] = "2";
                    //    Session["PhaseId"] = "1";
                    //    Session["PayeeUserTypeId"] = "91";
                    //    Session["PayeeId"] = PID.ToString();

                    //    Response.Redirect("../FeeProcess/PaymentDetails", true);
                    //}
                  
                    lblApplicationID.Text = obj.ApplicationID;
                    lblVersionNo.Text = obj.VersionNo.ToString();
                    lblLastModifiedOn.Text = obj.LastModifiedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", obj.LastModifiedOn);
                    AzureDocumentUpload azObj = new AzureDocumentUpload();
                    imgPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(PID, "Photograph"));
                    imgSignature.ImageUrl = azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(PID, "Signature"));

                    lblCandidateName.Text = obj.CandidateName;
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

                    if (CandidatureTypeID == 1)
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;

                        lblQ1.Text = "District from which Candidate has Passed SSC";
                        lblQ2.Text = "District from which Candidate has Passed HSC / Diploma in Pharmacy";
                        lblDistrict1.Text = obj.SSCDistrict;
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (CandidatureTypeID == 2)
                    {
                        trDistrict1.Visible = false;

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
                    else if (CandidatureTypeID == 3)
                    {
                        trDistrict1.Visible = false;
                        trMothersName.Visible = false;

                        lblDocumentOfHead.Text = "Whose Proforma - A You are Submitting at SC?";
                        lblDocumentOf.Text = obj.DocumentOf;
                        lblQ2.Text = "District where Father or Mother of Candidate is Posted";
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (CandidatureTypeID == 4)
                    {
                        trDistrict1.Visible = false;
                        trMothersName.Visible = false;

                        lblDocumentOfHead.Text = "Whose Proforma - B / Undertaking for Place of Settlement You are Submitting at SC?";
                        lblDocumentOf.Text = obj.DocumentOf;
                        lblQ2.Text = "District where Father or Mother of Candidate is Posted / Settled after Retirement";
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (CandidatureTypeID == 5)
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;

                        lblQ1.Text = "District from which Candidate has Passed SSC";
                        lblQ2.Text = "District from which Candidate has Passed HSC / Diploma in Pharmacy";
                        lblDistrict1.Text = obj.SSCDistrict;
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;
                        trDistrict1.Visible = false;
                        trDistrict2.Visible = false;
                    }
                    lblApplicationFeePaidAmount.Text = obj.CETApplicationFee.ToString() + "/-";
                    lblOnlineApplicationFee.Text = obj.OnlineApplicationFee.ToString() + "/-";
                    lblNationality.Text = obj.Nationality;

                    if (obj.QualifyingExam == "Diploma" || obj.QualifyingExam == "B.Sc.")
                    {
                        if (obj.SSCMathMarksObtained > 0)
                        {
                            lblSSCMathMarksObtained.Text = obj.SSCMathMarksObtained.ToString();
                            lblSSCMathMarksOutOf.Text = obj.SSCMathMarksOutOf.ToString();
                            lblSSCMathPercentage.Text = obj.SSCMathPercentage.ToString();
                        }
                        else
                        {
                            lblSSCMathMarksObtained.Text = "-";
                            lblSSCMathMarksOutOf.Text = "-";
                            lblSSCMathPercentage.Text = "-";
                        }
                        if (obj.SSCScienceMarksObtained > 0)
                        {
                            lblSSCScienceMarksObtained.Text = obj.SSCScienceMarksObtained.ToString();
                            lblSSCScienceMarksOutOf.Text = obj.SSCScienceMarksOutOf.ToString();
                            lblSSCSciencePercentage.Text = obj.SSCSciencePercentage.ToString();
                        }
                        else
                        {
                            lblSSCScienceMarksObtained.Text = "-";
                            lblSSCScienceMarksOutOf.Text = "-";
                            lblSSCSciencePercentage.Text = "-";
                        }
                        if (obj.SSCEnglishMarksObtained > 0)
                        {
                            lblSSCEnglishMarksObtained.Text = obj.SSCEnglishMarksObtained.ToString();
                            lblSSCEnglishMarksOutOf.Text = obj.SSCEnglishMarksOutOf.ToString();
                            lblSSCEnglishPercentage.Text = obj.SSCEnglishPercentage.ToString();
                        }
                        else
                        {
                            lblSSCEnglishMarksObtained.Text = "-";
                            lblSSCEnglishMarksOutOf.Text = "-";
                            lblSSCEnglishPercentage.Text = "-";
                        }
                        lblSSCTotalMarksObtained.Text = obj.SSCTotalMarksObtained.ToString();
                        lblSSCTotalMarksOutOf.Text = obj.SSCTotalMarksOutOf.ToString();
                        lblSSCTotalPercentage.Text = obj.SSCTotalPercentage.ToString();
                    }
                    else
                    {
                        trSSCMathematicsMarks.Visible = false;
                        trSSCScienceMarks.Visible = false;
                        trSSCEnglishMarks.Visible = false;
                        trSSCTotalMarks.Visible = false;
                    }
                    lblHSCPhysicsMarksObtained.Text = obj.HSCPhysicsMarksObtained.ToString();
                    lblHSCPhysicsMarksOutOf.Text = obj.HSCPhysicsMarksOutOf.ToString();
                    lblHSCPhysicsPercentage.Text = obj.HSCPhysicsPercentage.ToString();
                    lblHSCChemistryMarksObtained.Text = obj.HSCChemistryMarksObtained.ToString();
                    lblHSCChemistryMarksOutOf.Text = obj.HSCChemistryMarksOutOf.ToString();
                    lblHSCChemistryPercentage.Text = obj.HSCChemistryPercentage.ToString();
                   // lblHSCMathMarksObtained.Text = obj.HSCMathMarksObtained.ToString();
                   // lblHSCMathMarksOutOf.Text = obj.HSCMathMarksOutOf.ToString();
                  //  lblHSCMathPercentage.Text = obj.HSCMathPercentage.ToString();
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
                    lblSSCBoard.Text = obj.SSCBoard;
                    lblSSCPassingYear.Text = obj.SSCPassingYear;
                    lblSSCSeatNo.Text = obj.SSCSeatNo;
                    StringMatching stringMatchingg = new StringMatching();
                    int matchingPercentagee = stringMatchingg.CheckString(obj.CandidateName, obj.NameAsPerHSCResult);

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

                    // lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult;
                    lblHSCPassingStatus.Text = obj.HSCPassingStatus;
                    lblHSCBoard.Text = obj.HSCBoard;
                    lblHSCPassingYear.Text = SynCommon.GetPassingYear(obj.HSCPassingYear);
                    lblHSCSeatNo.Text = obj.HSCSeatNo;

                    if (obj.QualifyingExam == "Diploma" || obj.QualifyingExam == "B.Sc.")
                    {
                        trHSCPhysicsMarks.Visible = false;
                        trHSCChemistryMarks.Visible = false;
                      //  trHSCMathMarks.Visible = false;
                        trHSCSubjectMarks.Visible = false;
                        trHSCEnglishMarks.Visible = false;

                        if (obj.DiplomaMarksType == "CGPA")
                        {
                            lblHSCTotalMarks.Text = obj.QualifyingExam + " CGPA";
                        }
                        else
                        {
                            lblHSCTotalMarks.Text = obj.QualifyingExam + " Aggregate Marks";
                        }
                        lblHSCPassingStatusHeader.Text = obj.QualifyingExam + " Passing Status";
                        lblHSCBoardHeader.Text = obj.QualifyingExam + " Board / University";
                        lblHSCPassingYearHeader.Text = obj.QualifyingExam + " Passing Year";
                        lblHSCSeatNoHeader.Text = obj.QualifyingExam + " Seat Number";
                    }
                    else
                    {
                        if (obj.HSCSubject == "Not Applicable")
                        {
                            trHSCSubjectMarks.Visible = false;
                        }
                    }

                    if ((CandidatureTypeID == 1 || CandidatureTypeID == 5) && obj.QualifyingExamPlace != "India")
                    {
                      //  Response.Redirect("../AFCModule/frmEditQualificationDetails?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }

                    //DataSet dsCETResult = reg.getCETDetails(CETApplicationFormNo);
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
                    //        lblCETTotalScore.Text = dsCETResult.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString();
                    //    }
                    //    else
                    //    {
                    //        lblAppearedForCET.Text = "No";
                    //        lblCETRollNoHeader.Text = "";
                    //        trCETScore1.Visible = false;
                    //        trCETScore2.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    lblAppearedForCET.Text = "No";
                    //    lblCETRollNoHeader.Text = "";
                    //    trCETScore1.Visible = false;
                    //    trCETScore2.Visible = false;
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


                        if (CandidatureTypeID < 11 && obj.QualifyingExam == "HSC" && CETApplicationFormNo == 0)
                        {
                           // Response.Redirect("../AFCModule/frmEditJEEDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                    }
                    DataSet dsDiscrepanty = reg.GetDiscrepancyDetails(PID);
                    if (dsDiscrepanty.Tables[0].Rows.Count > 0)
                    {
                        tblDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepanty;
                        gvDiscrepancy.DataBind();
                    }
                    gvDocuments.DataSource = reg.getRequiredDocumentList(PID);
                    gvDocuments.DataBind();

                    for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                    {
                        gvDocuments.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
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

                    if (((HiddenField)e.Row.Cells[7].FindControl("hdnImgUrl")).Value.Length > 0)
                    {
                        if (((Label)e.Row.Cells[5].FindControl("lblIsSubmitted")).Text == "N")
                        {
                            ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = false;
                            ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = true;
                        }
                        else
                        {
                            ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = true;
                            ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = false;
                        }
                    }
                    else
                    {
                        ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = false;
                        ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = true;
                        ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Enabled = false;
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                    ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Enabled = false;
                    ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Enabled = false;
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

                //string XMLstring = "<DocumentList>";
                //for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                //{
                //    string DocumentID = ((Label)gvDocuments.Rows[i].FindControl("lblDocumentID")).Text;

                //    if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                //    {
                //        XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "Y" + "\"></Document>";
                //    }
                //    else
                //    {
                //        XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "N" + "\"></Document>";
                //    }
                //}
                //XMLstring += "</DocumentList>";

                //if (reg.updateDocumentSubmission(PID, XMLstring, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                //{
                    Response.Redirect("../E_FCModule/VerificationSummary.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                //}
                //else
                //{
                //    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                //}
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        [AjaxMethod]
        public ResponseCommon GetDocumentFetchData(Int64 PersonalID, Int64 DocID)
        {
            return reg.GetDocumentFetchData(PersonalID, DocID);

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Response.Redirect("../E_FCModule/FCApplicationFormVerificationDashboard?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
        }

    }
}