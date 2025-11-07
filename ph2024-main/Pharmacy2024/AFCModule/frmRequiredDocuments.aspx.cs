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

namespace Pharmacy2024.AFCModule
{
    public partial class frmRequiredDocuments : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string NEETName = Global.NEETName;
        public string MHTCETName = Global.MHTCETName;
        AzureDocumentUpload objDU = new AzureDocumentUpload();
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) == 91 || Convert.ToInt32(Session["UserTypeID"].ToString()) == 43)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if ((DateTime.Now < Global.DocumentVerificationStartDateTime || DateTime.Now > Global.DocumentVerificationEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    AzureDocumentUpload azObj = new AzureDocumentUpload();
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                    hdnApplicationURL.Value = ConfigurationManager.AppSettings["ApplicationURL"];

                    string ApplicationID = Global.ApplicationFormPrefix + PID;
                    if (!reg.OnlyThisCandidateOperation(ApplicationID))
                    {
                        Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                    }

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }

                    Int32 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                    Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);
                    Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(PID);
                    Int32 ApplicationFeePaid = reg.getApplicationFeePaidAmount(PID);
                   
                    PersonalInformation obj = reg.getPersonalInformation(PID);

                    DataSet dsEligibilityRemark = reg.getEligibilityFlag(PID);
                    DataSet dsChkCETApplicationNo = reg.isApplicationFormConfirmedUsingThisCETApplicationNo(CETApplicationFormNo, PID);
                    //NEETDetails obj = reg.getNEETDetails(PID);
                    DataSet dsChkNEETRollNo = reg.isApplicationFormConfirmedUsingThisNEETRollNo(Convert.ToInt64(obj.NEETRollNo.ToString()), PID);

                    if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && dsEligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                    {
                        shInfo.SetMessage(dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString(), ShowMessageType.Information);
                        btnProceed.Visible = false;
                    }
                    if (Global.CheckDuplicateMobileNo == 1 && reg.isApplicationFormConfirmedUsingThisMobileNo(obj.MobileNo))
                    {
                        shInfo.SetMessage("Application Form using mobile number " + DataEncryption.DecryptDataByEncryptionKey(obj.MobileNo) + " is already confirmed. Please change mobile number.", ShowMessageType.Information);
                        btnProceed.Visible = false;
                    }
                    else if (Global.CheckDuplicateEmailID == 1 && reg.isApplicationFormConfirmedUsingThisEMailID(obj.EMailID, PID))
                    {
                        shInfo.SetMessage("Application Form using E-Mail ID- " + obj.EMailID + " is already registered. Please register using other E-Mail ID.", ShowMessageType.Information);
                        btnProceed.Visible = false;
                    }
                    else if (reg.IsEditApplicationFormConfirmedUsingThisHSCSeatNo(PID))
                    {
                        DataSet dsHScSeatno = reg.getHSCSeatNo(PID);
                        DataSet GetApplicationID = reg.GetApplicationIDIsFormConfirmedUsingHSCSeatNo(PID);
                        shInfo.SetMessage("Application Form using This HSC Seat number " + dsHScSeatno.Tables[0].Rows[0]["HSCSeatNo"].ToString() + "," + " ApplicationID-" + GetApplicationID.Tables[0].Rows[0]["ApplicationID"].ToString() + "  is already confirmed. Please change HSC Seat number.", ShowMessageType.Information);
                        btnProceed.Visible = false;
                    }
                    else if (dsChkCETApplicationNo.Tables[0].Rows[0]["Status"].ToString() == "0")
                    {
                        string sApplicationID = dsChkCETApplicationNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                        string sConfirmedBy = dsChkCETApplicationNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();
                        shInfo.SetMessage("Application Form using CET Application Number " + CETApplicationFormNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
                        btnProceed.Visible = false;
                    }
                    else if (dsChkNEETRollNo.Tables[0].Rows.Count > 0 && dsChkNEETRollNo.Tables[0].Rows[0]["Status"].ToString() == "0")
                    {
                        string sApplicationID = dsChkNEETRollNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                        string sConfirmedBy = dsChkNEETRollNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();
                        shInfo.SetMessage("Application Form using NEETRollNo " + obj.NEETRollNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
                        btnProceed.Visible = false;

                    }

                    if (Global.CheckNEETResult)
                    {
                        DataSet dsNEETResult = reg.checkNEETDetails(PID, obj.NEETRollNo, obj.AppearedForNEET);
                        if (dsNEETResult.Tables.Count > 0 && dsNEETResult.Tables[0].Rows.Count > 0)
                        {
                            string neetMsg = "";
                            if (dsNEETResult.Tables[0].Rows.Count > 0)
                            {
                                if (dsNEETResult.Tables[0].Rows[0]["Status"].ToString() == "0")
                                {
                                    neetMsg = dsNEETResult.Tables[0].Rows[0]["Msg"].ToString();
                                    shInfo.SetMessage(neetMsg, ShowMessageType.Information);
                                    btnProceed.Visible = false;
                                }
                                else if (dsNEETResult.Tables[0].Rows[0]["Status"].ToString() == "1")
                                {
                                    neetMsg = "Wrong NEET 2024 Score. Please verify the Score. It should be <br/>";
                                    neetMsg = neetMsg + "Physics : " + dsNEETResult.Tables[0].Rows[0]["NEETPhysicScoreFinal"].ToString() + " | ";
                                    neetMsg = neetMsg + "Chemistry : " + dsNEETResult.Tables[0].Rows[0]["NEETChemistryScoreFinal"].ToString() + " | ";
                                    neetMsg = neetMsg + "Biology : " + dsNEETResult.Tables[0].Rows[0]["NEETBiologyScoreFinal"].ToString() + " | ";
                                    neetMsg = neetMsg + "Total : " + dsNEETResult.Tables[0].Rows[0]["NEETTotalFinal"].ToString();

                                    shInfo.SetMessage(neetMsg, ShowMessageType.Information);
                                    btnProceed.Visible = false;
                                }
                            }
                        }
                    }

                    if (obj.FinalHomeUniversity == "NA")
                    {
                        if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4 || CandidatureTypeID == 5)
                        {
                            Response.Redirect("../AFCModule/frmEditHomeUniversityAndCategoryDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
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

                    if (ApplicationFeeToBePaid > 0)
                    {
                        Session["FeeGroupId"] = null;
                        Session["PhaseId"] = null;
                        Session["PayeeUserTypeId"] = null;
                        Session["PayeeId"] = null;

                        Session["FeeGroupId"] = "2";
                        Session["PhaseId"] = "1";
                        Session["PayeeUserTypeId"] = "91";
                        Session["PayeeId"] = PID.ToString();

                        Response.Redirect("../FeeProcess/PaymentDetails.aspx", true);
                    }

                        lblVersionNo.Text = obj.VersionNo.ToString();
                        lblLastModifiedOn.Text = obj.LastModifiedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", obj.LastModifiedOn);

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
                        trTaluka.Visible = false;
                        trVillage.Visible = false;

                        lblQ1.Text = "District from which Candidate has Passed SSC";
                        lblQ2.Text = "District from which Candidate has Passed HSC / Diploma";
                        lblDistrict1.Text = obj.SSCDistrict;
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (CandidatureTypeID == 2)
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
                    else if (CandidatureTypeID == 3)
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
                    else if (CandidatureTypeID == 4)
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
                    else if (CandidatureTypeID == 5)
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

                    //  lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult;
                    if (obj.AppearedForDiploma == "Yes")
                    {
                        trDiplomaTotalMarks.Visible = true;
                        if (obj.DiplomaMarksType == "CGPA")
                        {
                            lblDiplomaTotalMarks.Text = "Diploma CGPA";
                        }
                    }

                    if ((CandidatureTypeID == 1 || CandidatureTypeID == 5) && obj.HSCPlace != "India")
                    {
                        Response.Redirect("../AFCModule/frmEditQualificationDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
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

                        if (CandidatureTypeID < 11 && CETApplicationFormNo == 0)
                        {
                            Response.Redirect("../AFCModule/frmEditNEETDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                    }

                        gvDocuments.DataSource = reg.getDocumentList(PID);
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
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

                string XMLstring = "<DocumentList>";
                for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                {
                    string DocumentID = ((Label)gvDocuments.Rows[i].FindControl("lblDocumentID")).Text;

                    if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                    {
                        XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "Y" + "\"></Document>";
                    }
                    else
                    {
                        XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "N" + "\"></Document>";
                    }
                }
                XMLstring += "</DocumentList>";

                if (reg.updateDocumentSubmission(PID, XMLstring, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    Response.Redirect("../AFCModule/frmDisplayDocumentSubmission.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
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