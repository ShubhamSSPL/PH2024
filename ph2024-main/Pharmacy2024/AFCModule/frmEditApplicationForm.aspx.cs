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

namespace Pharmacy2024.AFCModule
{
    public partial class frmEditApplicationForm : System.Web.UI.Page
    {
        public string CurrentYear = Global.CurrentYear;
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string NEETName = Global.NEETName;
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
            if ((DateTime.Now < Global.EdittingOfApplicationFormStartDateTime || DateTime.Now > Global.EdittingOfApplicationFormEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }

                    Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                    Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);
                    Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(PID);
                    PersonalInformation obj = reg.getPersonalInformation(PID);

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

                    lblCandidateName.Text = obj.CandidateName;
                    lblFatherName.Text = obj.FatherName;
                    lblMotherName.Text = obj.MotherName;
                    lblGender.Text = obj.Gender;
                    lblDOB.Text = obj.DOB;
                    lblReligion.Text = obj.Religion;
                    lblRegion.Text = obj.Region;
                    lblMotherTongue.Text = obj.MotherTongue;
                    lblAnnualFamilyIncome.Text = obj.AnnualFamilyIncome;
                    lblNationality.Text = obj.Nationality;

                    lblCandidatureType.Text = obj.FinalCandidatureType;
                    if (obj.CandidatureType != obj.FinalCandidatureType)
                    {
                        lblCandidatureType.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
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

                        lblDocumentOfHead.Text = "Whose Domicile Cerificate You are Submitting at SC ?";
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

                        lblDocumentOfHead.Text = "Whose Proforma - A You are Submitting at SC ?";
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

                        lblDocumentOfHead.Text = "Whose Proforma - B / Undertaking for Place of Settlement You are Submitting at SC ?";
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

                    DataSet dsCETResult = reg.getCETDetails(CETApplicationFormNo);
                    if (dsCETResult.Tables[0].Rows.Count > 0)
                    {
                        if (dsCETResult.Tables[0].Rows[0]["IsCandidateGivenCET"].ToString() == "Y")
                        {
                            lblAppearedForCETHeader.Text = "Application Number";
                            lblAppearedForCET.Text = dsCETResult.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();
                            lblCETRollNo.Text = dsCETResult.Tables[0].Rows[0]["CETRollNo"].ToString();
                            lblCETPhysicsScore.Text = dsCETResult.Tables[0].Rows[0]["CETPhysicsMarks"].ToString();
                            lblCETChemistryScore.Text = dsCETResult.Tables[0].Rows[0]["CETChemistryMarks"].ToString();
                            lblCETMathScore.Text = dsCETResult.Tables[0].Rows[0]["CETMathMarks"].ToString();
                            lblCETBiologyScore.Text = dsCETResult.Tables[0].Rows[0]["CETBiologyMarks"].ToString();
                            lblCETPCMScore.Text = dsCETResult.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString();
                            lblCETPCBScore.Text = dsCETResult.Tables[0].Rows[0]["CETPCBTotalMarks"].ToString();
                        }
                        else
                        {
                            lblAppearedForCET.Text = "No";
                            lblCETRollNoHeader.Text = "";
                            trCETScore1.Visible = false;
                            trCETScore2.Visible = false;
                            trCETScore3.Visible = false;
                        }
                    }
                    else
                    {
                        lblAppearedForCET.Text = "No";
                        lblCETRollNoHeader.Text = "";
                        trCETScore1.Visible = false;
                        trCETScore2.Visible = false;
                        trCETScore3.Visible = false;
                    }

                    lblAppearedForNEET.Text = obj.AppearedForNEET;
                    if (obj.AppearedForNEET == "Yes")
                    {
                        lblNEETRollNo.Text = obj.NEETRollNo.ToString();
                        lblNEETPhysicsScore.Text = obj.NEETPhysicsScore.ToString();
                        lblNEETChemistryScore.Text = obj.NEETChemistryScore.ToString();
                        lblNEETBiologyScore.Text = obj.NEETBiologyScore.ToString();
                        lblNEETTotalScore.Text = obj.NEETTotalScore.ToString();
                    }
                    else
                    {
                        lblNEETRollNoHeader.Text = "";
                        trNEETScore1.Visible = false;
                        trNEETScore2.Visible = false;

                        if (CandidatureTypeID < 11 && CETApplicationFormNo == 0)
                        {
                            Response.Redirect("../AFCModule/frmEditNEETDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                    }
                    AzureDocumentUpload azObj = new AzureDocumentUpload();
                    imgPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(PID, "Photograph"));
                    imgSignature.ImageUrl = azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(PID, "Signature"));

                    gvDocuments.DataSource = reg.getDocumentList(PID);
                    gvDocuments.DataBind();

                    for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                    {
                        gvDocuments.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    }

                    if (CandidatureTypeID >= 7)
                    {
                        btnHomeUniversityAndCategoryDetails.Visible = false;
                    }

                    if (CandidatureTypeID >= 5)
                    {
                        btnSpecialReservationDetails.Visible = false;
                    }

                    if ((UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        string Flag = reg.isCandidateEligibleForEdittingAtARC(PID);

                        if (Flag.Length > 0)
                        {
                            Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                        }
                    }
                    else if ((UserTypeID == 23 || UserTypeID == 24) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        btnRegistrationDetails.Visible = false;
                        btnCandidatureTypeDetails.Visible = false;
                        btnHomeUniversityAndCategoryDetails.Visible = false;
                        btnSpecialReservationDetails.Visible = false;
                        btnQualificationDetails.Visible = false;
                        btnNEETDetails.Visible = false;
                        btnScannedImages.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnRegistrationDetails_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Response.Redirect("../AFCModule/frmEditRegistrationDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
        }
        protected void btnCandidatureTypeDetails_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Response.Redirect("../AFCModule/frmEditCandidatureTypeDetailsNew.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
        }
        protected void btnHomeUniversityAndCategoryDetails_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Response.Redirect("../AFCModule/frmEditHomeUniversityAndCategoryDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
        }
        protected void btnSpecialReservationDetails_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Response.Redirect("../AFCModule/frmEditSpecialReservationDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
        }
        protected void btnQualificationDetails_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Response.Redirect("../AFCModule/frmEditQualificationDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
        }
        protected void btnNEETDetails_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Response.Redirect("../AFCModule/frmEditNEETDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
        }
        protected void btnScannedImages_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Response.Redirect("../AFCModule/frmEditScannedImages.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
        }
    }
}