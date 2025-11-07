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
    public partial class frmPrintAcknowledgement : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string NEETName = Global.NEETName;
        public string CurrentYear = Global.CurrentYear;
        public string MHTCETName = Global.MHTCETName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.FilePath.Contains("StaticPages/HomePage"))
            {
                string strPreviousPage = "";
                if (Request.UrlReferrer != null)
                {
                    strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                }
                if (strPreviousPage == "")
                {
                    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                }
                if (Session["UserLoginId"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                }
                if (!IsPostBack)
                {
                    try
                    {
                        AzureDocumentUpload azObj = new AzureDocumentUpload();
                        Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                        Int32 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                        Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);
                        Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(PID);
                        Int32 ApplicationFeePaid = reg.getApplicationFeePaidAmount(PID);
                        PersonalInformation obj = reg.getPersonalInformation(PID);
                        string ScruType = reg.CheckCandidateFCVerificationFor(PID);
                        DataSet dsSlot = reg.GetCandidateBookingSlotDetails(PID);
                        if (dsSlot.Tables[0].Rows.Count > 0 && ScruType != "E")
                        {
                            tblPhysicalScrutiny.Visible = true;
                            lblSlotDateTime.Text = Convert.ToDateTime(dsSlot.Tables[0].Rows[0]["SlotDate"]).ToString("dd/MM/yyyy") + " - " + dsSlot.Tables[0].Rows[0]["SlotTime"].ToString();
                            lblFCDetails.Text = dsSlot.Tables[0].Rows[0]["FCDetails"].ToString();
                        }
                        if (ScruType == "E")
                        {
                            DataSet dsEScr = reg.GetCandidateEFCAllotted(PID);
                            if (dsEScr.Tables[0].Rows.Count > 0)
                            {
                                tblEScrutiny.Visible = true;
                                lblEScrutiny.Text = dsEScr.Tables[0].Rows[0]["AFCName"].ToString() + "  ," + Convert.ToDateTime(dsEScr.Tables[0].Rows[0]["CreatedOn"]).ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", Convert.ToDateTime(dsEScr.Tables[0].Rows[0]["CreatedOn"]));
                            }
                        }

                        imgPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(PID, "Photograph"));
                        imgSignature.ImageUrl = azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(PID, "Signature"));

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
                        lblCategoryForAdmission.Text = obj.DisplayFinalCategory;
                        if (obj.Category != obj.DisplayFinalCategory)
                        {
                            lblCategoryForAdmission.Text = obj.DisplayFinalCategory + "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                        }
                        lblAppliedForEWS.Text = obj.DisplayFinalAppliedForEWS;
                        if (obj.AppliedForEWS != obj.DisplayFinalAppliedForEWS)
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

                            // lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult;
                        }
                        else
                        {
                            lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult + " " + "<font color = 'red' size='2'>(Name As Per HSC Result)</font>";
                            lblNameAsPerHSCResult.ForeColor = System.Drawing.Color.Blue;
                        }
                        if (obj.AppearedForDiploma == "Yes")
                        {
                            trDiplomaTotalMarks.Visible = true;
                            if (obj.DiplomaMarksType == "CGPA")
                            {
                                lblDiplomaTotalMarks.Text = "Diploma CGPA";
                            }
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
                            //lblCETCandidateName.Text = obj.CETCandidateName.ToString() + " " + "<font color = 'red' size='1'>(Name As Per MHTCET Result)</font>";
                            lblCETCandidateName.ForeColor = System.Drawing.Color.Blue;
                        }
                        else
                        {
                            //lblAppearedForCET.Text = "No";
                            //lblCETRollNoHeader.Text = "";
                            //trCETScore1.Visible = false;
                            //trCETScore2.Visible = false;
                            //lblCETCandidateName.Visible = false;

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
                        DataSet DSAdmissionCategoryforReceipt = reg.GetAdmissionCategoryforReceipt(PID);
                        if (DSAdmissionCategoryforReceipt.Tables[0].Rows.Count > 0)
                        {
                            trCVCMsg.Visible = true;
                        }
                        else
                        {
                            trCVCMsg.Visible = false;
                        }

                        gvDocumentsSubmitted.DataSource = reg.getDocumentList(PID, "Y");
                        gvDocumentsSubmitted.DataBind();
                        if (gvDocumentsSubmitted.Rows.Count > 0)
                        {
                            string DocumentsNotUploaded = "";
                            Int32 j = 1;
                            for (Int32 i = 0; i < gvDocumentsSubmitted.Rows.Count; i++)
                            {
                                gvDocumentsSubmitted.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                                string IsUploaded = ((Label)gvDocumentsSubmitted.Rows[i].FindControl("lblIsUploaded")).Text;
                                if (IsUploaded == "No")
                                {
                                    DocumentsNotUploaded += j.ToString() + ". " + gvDocumentsSubmitted.Rows[i].Cells[1].Text + "<br />";
                                    j++;
                                }
                            }

                            if (DocumentsNotUploaded.Length > 0)
                            {
                                shInfo.SetMessage("Please upload the following Documents which are Submitted but not Uploaded : <br />" + DocumentsNotUploaded, ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            trDocumentsSubmitted1.Visible = false;
                            trDocumentsSubmitted2.Visible = false;
                        }

                        gvDocumentsNotSubmitted.DataSource = reg.getDocumentList(PID, "N");
                        gvDocumentsNotSubmitted.DataBind();
                        if (gvDocumentsNotSubmitted.Rows.Count > 0)
                        {
                            for (Int32 i = 0; i < gvDocumentsNotSubmitted.Rows.Count; i++)
                            {
                                gvDocumentsNotSubmitted.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            }
                        }
                        else
                        {
                            trDocumentsNotSubmitted1.Visible = false;
                            trDocumentsNotSubmitted2.Visible = false;
                        }

                        DataSet dsEligibilityRemark = reg.getEligibilityFlag(PID);
                        if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Length > 0)
                        {
                            trEligibilityRemark.Visible = true;
                            lblEligibilityRemark.Text += dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString();
                            lblEligibilityRemark.ForeColor = System.Drawing.Color.Red;
                        }

                        lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        lblLastModifiedOn.Text = obj.LastModifiedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", obj.LastModifiedOn);
                        lblLastModifiedBy.Text = obj.LastModifiedBy + ", " + obj.LastModifiedByIPAddress;

                        DataSet ds = reg.getApplicationFormConfirmationDetails(PID);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["ConfirmedUnder"].ToString() != "CAP")
                            {
                                lblTitle.Visible = true;
                            }
                            if (ds.Tables[0].Rows[0]["Comments"].ToString().Length > 0)
                            {
                                trComments.Visible = true;
                                lblComments.Text += ds.Tables[0].Rows[0]["Comments"].ToString();
                            }
                            lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                            DateTime ConfirmedDateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ConfirmedDateTime"]);
                            lblConfirmedOn.Text = ConfirmedDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ConfirmedDateTime);
                            lblConfirmedBy.Text = ds.Tables[0].Rows[0]["ConfirmedBy"].ToString() + ", " + ds.Tables[0].Rows[0]["ConfirmedByIPAddress"].ToString();
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
    }
}