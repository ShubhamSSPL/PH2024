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

namespace Pharmacy2024.CandidateAdmissionReportingModule
{
    public partial class SelfDocVerification : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        AzureDocumentUpload objDU = new AzureDocumentUpload();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            SessionData objSessionData = (SessionData)Session["SessionData"];
            MyCheckBox.Text = "I have read the Information Brochure and as per the instructions given in the Rule No 9, i have verified that the seat allotment made to me is as per the Rules & regulations. I also ensure that the claims made by me in the application form related with Qualifying Marks, Category, Gender, Reservation, Special Reservation  are correct and the relevant documents uploaded to substantiate the claim are authentic & correct to the best of my knowledge & belief. I also know that, in the later stage, if it is found that i have furnished wrong information and /or submitted false certificates, and seat allotted to me on the false claims made in the application form, then such allotment/admission taken in the allotted institute shall be cancelled automatically and fees paid by me will be forfeited. Further I will be subject to legal and/or penal action as per the provision of the Law.";
            DataSet dsAllotmentDetails = reg.getAllotmentDetails(objSessionData.PID);
            if (reg.CheckSelfVerificationIsDone(objSessionData.PID))
            {
                if (dsAllotmentDetails.Tables[0].Rows.Count > 0)
                {
                    ViewState["IsAllotted"] = "Yes";
                }
            }
            else
            {
               
                if (Global.CAPRound >= 1)
                {
                    if (dsAllotmentDetails.Tables[0].Rows.Count > 0)
                    {
                        ViewState["IsAllotted"] = "Yes";
                    }
                    else
                    {
                        if (Global.CAPRound >= 2)
                        {
                            if (dsAllotmentDetails.Tables[1].Rows.Count > 0)
                            {
                                ViewState["IsAllotted"] = "Yes";
                            }
                            else
                            {
                                Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx", true);
                            }

                        }
                    }
                }
                
            }
            if (!IsPostBack)
            {
                ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                contentConfermation.Visible = false;
                contentOTPVerify.Visible = false;
                Int64 PID = objSessionData.PID;
                ViewState["PID"] = PID;
                ViewState["IsAllotted"] = "No";
                CandidateBasicInformation.PID = PID;
                if (reg.CheckSelfVerificationIsDone(PID))
                {
                    //DataSet ds = reg.CheckCandidateValid(Convert.ToInt64(ViewState["PID"]));

                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    DataSet ds1 = reg.CheckCandidateUpladedDoc(Convert.ToInt64(ViewState["PID"]));
                    //    if (ds1.Tables[0].Rows.Count > 0)
                    //    {
                    //        ContentTable1.Visible = false;
                    //        contentConfermation.Visible = false;
                    //        UpdatePanel2.Visible = false;
                    //        shInfo.SetMessage("Your CVC/TVC, NCL or EWS Certificate is Uploaded. SC will verify Soon!", ShowMessageType.Information);
                    //    }
                    //    else
                    //    {
                    //        ContentTable1.Visible = false;
                    //        contentConfermation.Visible = false;
                    //        UpdatePanel2.Visible = false;
                    //        shInfo.SetMessage("Your CVC/TVC, NCL or EWS Certificate is not Uploaded Please Upload the Certificates first then Process for Seat acceptance .!", ShowMessageType.Information);
                    //        Response.Redirect("../CandidateAdmissionReportingModule/frmUploadCVCNCLCertificate.aspx", true);

                    //    }
                    //}
                    //else
                    //{
                    if (reg.isCandidateNameAppearedInFinalMeritList(PID))
                    { 
                        LoadData(PID);
                    }
                    else
                    {
                    ContentTable1.Visible = false;
                    contentConfermation.Visible = false;
                    UpdatePanel2.Visible = false;
                    shInfo.SetMessage("Only for Candidate are in Final Merit List!", ShowMessageType.Information);
                    }

                    //}
                    //LoadData(PID);
                }
                else
                {
                    ContentTable1.Visible = false;
                    contentConfermation.Visible = false;
                    UpdatePanel2.Visible = false;
                    shInfo.SetMessage("Self Verification step is Complete!", ShowMessageType.Information);
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

            PersonalInformation obj = reg.getPersonalInformation(PID);
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
            hdnSubjectID.Value = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectID"].ToString();
            if (dsPersonalInformation.Tables[0].Rows[0]["FinalCandidatureType"].ToString() == "OMS")
            {
                chkCandidatureV.Checked = true;
                chkCandidatureV.Enabled = false;
                chkCandidatureNV.Enabled = false;
                lblCandidatureStatus.Text = "Correct";
                lblCandidatureStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString() == "Open" || dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString() == "Not Applicable")
            {
                chkCategoryV.Checked = true;
                chkCategoryV.Enabled = false;
                chkCategoryNV.Enabled = false;
                lblCategoryStatus.Text = "Correct";
                lblCategoryStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString() == "No")
            {
                chkEWSV.Checked = true;
                chkEWSV.Enabled = false;
                chkEWSNV.Enabled = false;
                lblEWSStatus.Text = "Correct";
                lblEWSStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString() == "Not Applicable")
            {
                chkPWDV.Checked = true;
                chkPWDV.Enabled = false;
                chkPWDNV.Enabled = false;
                lblPWDStatus.Text = "Correct";
                lblPWDStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString() == "Not Applicable")
            {
                chkDefV.Checked = true;
                chkDefV.Enabled = false;
                chkDefNV.Enabled = false;
                lblDefStatus.Text = "Correct";
                lblDefStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString() == "No")
            {
                chkOrphanV.Checked = true;
                chkOrphanV.Enabled = false;
                chkOrphanNV.Enabled = false;
                lblOrphanStatus.Text = "Correct";
                lblOrphanStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString() == "No")
            {
                chkTFWSV.Checked = true;
                chkTFWSV.Enabled = false;
                chkTFWSNV.Enabled = false;
                lblTFWSStatus.Text = "Correct";
                lblTFWSStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (obj.FinalReligiousMinorityDetails == "Not Applicable")
            {
                chkReligiousMinorityV.Checked = true;
                chkReligiousMinorityV.Enabled = false;
                chkReligiousMinorityNV.Enabled = false;
                lblReligiousMinorityStatus.Text = "Correct";
                lblReligiousMinorityStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (obj.FinalLinguisticMinorityDetails == "Not Applicable")
            {
                chkLinguisticMinorityV.Checked = true;
                chkLinguisticMinorityV.Enabled = false;
                chkLinguisticMinorityNV.Enabled = false;
                lblLinguisticMinorityStatus.Text = "Correct";
                lblLinguisticMinorityStatus.ForeColor = System.Drawing.Color.Green;
            }


            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["SSCTotalPercentage"].ToString()) > 1)
            {
                //if (obj.CourseAbbr == "HMCT")
                //{
                //    trSSCPercentage.Visible = false;
                //}
                //else
                {
                    lblSSCCurrentPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["SSCTotalPercentage"].ToString() + " %";
                    lblSSCPercentagecmp.Text = dsPersonalInformation.Tables[0].Rows[0]["SSCTotalPercentage"].ToString();
                    trSSCPercentage.Visible = false;
                }
            }
            else
                trSSCPercentage.Visible = false;
            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCTotalPercentage"].ToString()) > 0)
            {
                lblHSCCurrentPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCTotalPercentage"].ToString() + " %";
                lblHSCPercentagecmp.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCTotalPercentage"].ToString();
                trHSCPercentage.Visible = false;
            }
            else
                trHSCPercentage.Visible = false;



            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["SSCMathMarksObtained"].ToString()) > 1)
            {
                //if (obj.CourseAbbr == "HMCT")
                //{
                //    trSSCMath.Visible = false;
                //}
                //else
                {
                    lblCurrentSSCMathematics.Text = dsPersonalInformation.Tables[0].Rows[0]["SSCMathMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["SSCMathMarksOutOf"].ToString();
                    lblSSCMathematicscmp.Text = dsPersonalInformation.Tables[0].Rows[0]["SSCMathMarksObtained"].ToString();
                }
            }
            else
                trSSCMath.Visible = false;
            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["SSCTotalMarksObtained"].ToString()) > 0)
            {
                //if (obj.CourseAbbr == "HMCT")
                //{
                //    trSSCTotal.Visible = false;

                //}
                //else
                {
                    lblCurrentSSCTotal.Text = dsPersonalInformation.Tables[0].Rows[0]["SSCTotalMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["SSCTotalMarksOutOf"].ToString();
                    lblSSCTotalcmp.Text = dsPersonalInformation.Tables[0].Rows[0]["SSCTotalMarksObtained"].ToString();
                }
            }
            else
                trSSCTotal.Visible = false;
            // lblHSCStream.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCStream"].ToString();
            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCPhysicsMarksObtained"].ToString()) > 0)
            {
                lblCurrentHSCPhysics.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCPhysicsMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCPhysicsMarksOutOf"].ToString();
                lblHSCPhysicscmp.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCPhysicsMarksObtained"].ToString();
            }
            else
                trPhysics.Visible = false;
            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCChemistryMarksObtained"].ToString()) > 0)
            {
                lblCurrentHSCChemistry.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCChemistryMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCChemistryMarksOutOf"].ToString();
                lblHSCChemistrycmp.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCChemistryMarksObtained"].ToString();
            }
            else
                trHSCChemistry.Visible = false;

            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString()) > 0 && dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectID"].ToString() == "2")
            {
                lblCurrentHSCMathematics.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksOutOf"].ToString();
                lblHSCMathematicscmp.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString();
            }
            else
            {
                trHSCMathematics.Visible = false;
            }
            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString()) > 0 && dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectID"].ToString() == "1")
            {
                lblCurrentHSCBiology.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksOutOf"].ToString();
                lblHSCBiologycmp.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString();
            }
            else
            {
                trHSCBiology.Visible = false;
            }
            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCEnglishMarksObtained"].ToString()) > 0)
            {
                lblCurrentHSCEnglish.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCEnglishMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCEnglishMarksOutOf"].ToString();
                lblHSCEnglishcmp.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCEnglishMarksObtained"].ToString();
            }
            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCTotalMarksObtained"].ToString()) > 0)
            {
                lblCurrentHSCAggregate.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCTotalMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCTotalMarksOutOf"].ToString();
                lblHSCTotalCmp.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCTotalMarksObtained"].ToString();
            }
            else
                trHSCTotal.Visible = false;
            //if (obj.CourseAbbr == "SCT")
            //    lblCurrentIntermediateGradeDrawing.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsIntermediateGradeDrawing"].ToString();
            //else
            trIntermediateGradeDrawing.Visible = false;

            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString()) > 0 && dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectID"].ToString() == "1")
            {
                lblCurrentHSCBiology.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksOutOf"].ToString();
                lblHSCBiologycmp.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectMarksObtained"].ToString();
            }
            else
            {
                trHSCBiology.Visible = false;
            }

            if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalMarksObtained"].ToString()) > 0)
            {
                lblCurrentDiploma.Text = dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalMarksObtained"].ToString() + " / " + dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalMarksOutOf"].ToString();
                lblDiplomacmp.Text = dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalMarksObtained"].ToString();
                lblDiplomaMarkType.Text = dsPersonalInformation.Tables[0].Rows[0]["DiplomaMarksType"].ToString();
            }
            else
            {
                trDiploma.Visible = false;
            }



            gvDocuments.DataSource = dsDocumentList;
            gvDocuments.DataBind();

            for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
            {
                gvDocuments.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
            }
        }
        protected void GenderStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGenderV.Checked)
            {
                lblGenderStatus.Text = "Correct";
                lblGenderStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkGendreNV.Checked)
            {
                lblGenderStatus.Text = "InCorrect";
                lblGenderStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void CandidatureStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCandidatureV.Checked)
            {
                lblCandidatureStatus.Text = "Correct";
                lblCandidatureStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkCandidatureNV.Checked)
            {
                lblCandidatureStatus.Text = "InCorrect";
                lblCandidatureStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void CategoryStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoryV.Checked)
            {
                lblCategoryStatus.Text = "Correct";
                lblCategoryStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkCategoryNV.Checked)
            {
                lblCategoryStatus.Text = "InCorrect";
                lblCategoryStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void EWSStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEWSV.Checked)
            {
                lblEWSStatus.Text = "Correct";
                lblEWSStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkEWSNV.Checked)
            {
                lblEWSStatus.Text = "InCorrect";
                lblEWSStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void PWDStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPWDV.Checked)
            {
                lblPWDStatus.Text = "Correct";
                lblPWDStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkPWDNV.Checked)
            {
                lblPWDStatus.Text = "InCorrect";
                lblPWDStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void DEFStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDefV.Checked)
            {
                lblDefStatus.Text = "Correct";
                lblDefStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkDefNV.Checked)
            {
                lblDefStatus.Text = "InCorrect";
                lblDefStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void OrphanStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOrphanV.Checked)
            {
                lblOrphanStatus.Text = "Correct";
                lblOrphanStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkOrphanNV.Checked)
            {
                lblOrphanStatus.Text = "InCorrect";
                lblOrphanStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void TFWSStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTFWSV.Checked)
            {
                lblTFWSStatus.Text = "Correct";
                lblTFWSStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkTFWSNV.Checked)
            {
                lblTFWSStatus.Text = "InCorrect";
                lblTFWSStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void LinguisticMinorityStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLinguisticMinorityV.Checked)
            {
                lblLinguisticMinorityStatus.Text = "Correct";
                lblLinguisticMinorityStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkLinguisticMinorityNV.Checked)
            {
                lblLinguisticMinorityStatus.Text = "InCorrect";
                lblLinguisticMinorityStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void ReligiousMinorityStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReligiousMinorityV.Checked)
            {
                lblReligiousMinorityStatus.Text = "Correct";
                lblReligiousMinorityStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkReligiousMinorityNV.Checked)
            {
                lblReligiousMinorityStatus.Text = "InCorrect";
                lblReligiousMinorityStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void HSCPercengage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHSCPercengageV.Checked)
            {
                txtHSCPercentage.Text = "";
                txtHSCPercentage.Enabled = false;
                lblHSCPercentageStatus.Text = "Correct";
                lblHSCPercentageStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkHSCPercengageNV.Checked)
            {
                lblHSCPercentageStatus.Text = "InCorrect";
                txtHSCPercentage.Enabled = true;
                lblHSCPercentageStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void SSCPercengage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSSCPercengageV.Checked)
            {
                txtSSCPercentage.Text = "";
                txtSSCPercentage.Enabled = false;
                lblSSCPercentageStatus.Text = "Correct";
                lblSSCPercentageStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkSSCPercengageNV.Checked)
            {
                lblSSCPercentageStatus.Text = "InCorrect";
                txtSSCPercentage.Enabled = true;
                lblSSCPercentageStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void HSCAggregateStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHSCAggregateV.Checked)
            {
                txtHSCTotal.Text = "";
                txtHSCTotalOutof.Text = "";
                txtHSCTotal.Enabled = false;
                txtHSCTotalOutof.Enabled = false;
                lblHSCAggregateStatus.Text = "Correct";
                lblHSCAggregateStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkHSCAggregateNV.Checked)
            {
                lblHSCAggregateStatus.Text = "InCorrect";
                txtHSCTotal.Enabled = true;
                txtHSCTotalOutof.Enabled = true;
                lblHSCAggregateStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void HSCPhysicsStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHSCPhysicsV.Checked)
            {
                txtHSCPhysicsStatus.Text = "";
                txtHSCPhysicsStatusOutOf.Text = "";
                txtHSCPhysicsStatus.Enabled = false;
                txtHSCPhysicsStatusOutOf.Enabled = false;
                lblHSCPhysicsStatus.Text = "Correct";
                lblHSCPhysicsStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkHSCPhysicsNV.Checked)
            {
                txtHSCPhysicsStatus.Enabled = true;
                txtHSCPhysicsStatusOutOf.Enabled = true;
                lblHSCPhysicsStatus.Text = "InCorrect";
                lblHSCPhysicsStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void HSCChemistryStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHSCChemistryV.Checked)
            {

                txtHSCChemistryStatus.Text = "";
                txtHSCChemistryOutofMarks.Text = "";
                txtHSCChemistryStatus.Enabled = false;
                txtHSCChemistryOutofMarks.Enabled = false;
                lblHSCChemistryStatus.Text = "Correct";
                lblHSCChemistryStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkHSCChemistryNV.Checked)
            {
                txtHSCChemistryStatus.Enabled = true;
                txtHSCChemistryOutofMarks.Enabled = true;
                lblHSCChemistryStatus.Text = "InCorrect";
                lblHSCChemistryStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void HSCBiologyStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHSCBiologyV.Checked)
            {
                txtHSCBiology.Text = "";
                txtHSCBiologyOutofMarks.Text = "";
                txtHSCBiology.Enabled = false;
                txtHSCBiologyOutofMarks.Enabled = false;
                lblHSCBiologyStatus.Text = "Correct";
                lblHSCBiologyStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkHSCBiologyNV.Checked)
            {
                txtHSCBiology.Enabled = true;
                txtHSCBiologyOutofMarks.Enabled = true;
                lblHSCBiologyStatus.Text = "InCorrect";
                lblHSCBiologyStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void HSCMathematicsStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHSCMathematicsV.Checked)
            {
                txtHSCMathematics.Text = "";
                txtHSCMathematicsOutof.Text = "";
                txtHSCMathematics.Enabled = false;
                txtHSCMathematicsOutof.Enabled = false;
                lblHSCMathematicsStatus.Text = "Correct";
                lblHSCMathematicsStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkHSCMathematicsNV.Checked)
            {
                txtHSCMathematics.Enabled = true;
                txtHSCMathematicsOutof.Enabled = true;
                lblHSCMathematicsStatus.Text = "InCorrect";
                lblHSCMathematicsStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void HSCEnglishStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHSCEnglishV.Checked)
            {
                txtHSCEnglish.Text = "";
                txtHSCEnglishOutof.Text = "";
                txtHSCEnglish.Enabled = false;
                txtHSCEnglishOutof.Enabled = false;
                lblHSCEnglishStatus.Text = "Correct";
                lblHSCEnglishStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkHSCEnglishNV.Checked)
            {
                txtHSCEnglish.Enabled = true;
                txtHSCEnglishOutof.Enabled = true;
                lblHSCEnglishStatus.Text = "InCorrect";
                lblHSCEnglishStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void SSCTotalStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSSCTotalV.Checked)
            {
                txtSSCTotal.Text = "";
                txtSSCTotalOutof.Text = "";
                txtSSCTotal.Enabled = false;
                txtSSCTotalOutof.Enabled = false;
                lbltxtSSCTotalStatus.Text = "Correct";
                lbltxtSSCTotalStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkSSCTotalNV.Checked)
            {
                txtSSCTotal.Enabled = true;
                txtSSCTotalOutof.Enabled = true;
                lbltxtSSCTotalStatus.Text = "InCorrect";
                lbltxtSSCTotalStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void SSCMathematicsStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSSCMathematicsV.Checked)
            {
                txtSSCMathematics.Text = "";
                txtSSCMathematicsOutOf.Text = "";
                txtSSCMathematics.Enabled = false;
                txtSSCMathematicsOutOf.Enabled = false;
                lblMathematicsStatus.Text = "Correct";
                lblMathematicsStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkSSCMathematicsNV.Checked)
            {
                txtSSCMathematics.Enabled = true;
                txtSSCMathematicsOutOf.Enabled = true;
                lblMathematicsStatus.Text = "InCorrect";
                lblMathematicsStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void IntermediateGradeDrawingStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIntermediateGradeDrawingV.Checked)
            {
                lblIntermediateGradeDrawingNo.Visible = false;
                lblIntermediateGradeDrawingStatus.Text = "Correct";
                lblIntermediateGradeDrawingStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkIntermediateGradeDrawingNV.Checked)
            {
                lblIntermediateGradeDrawingNo.Visible = true;
                lblIntermediateGradeDrawingStatus.Text = "InCorrect";
                lblIntermediateGradeDrawingStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void DiplomaStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiplomaV.Checked)
            {
                txtDiplomaMarks.Text = "";
                txtDiplomaOutofMarks.Text = "";
                txtDiplomaMarks.Enabled = false;
                txtDiplomaOutofMarks.Enabled = false;
                lblDiplomaStatus.Text = "Correct";
                lblDiplomaStatus.ForeColor = System.Drawing.Color.Green;
            }
            if (chkDiplomaNV.Checked)
            {
                txtDiplomaMarks.Enabled = true;
                txtDiplomaOutofMarks.Enabled = true;
                lblDiplomaStatus.Text = "InCorrect";
                lblDiplomaStatus.ForeColor = System.Drawing.Color.Red;
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
                //DisableRadioButton();
                if (Convert.ToInt64(ViewState["PID"]) == reg.getPersonalID(Session["UserLoginID"].ToString()))
                {
                    string valmsg = ValidateParameters();
                    string valDoc = ValidateDocument();
                    if (valmsg.Length == 0)
                    {
                        if (valDoc.Length == 0)
                        {
                            string XMLstring = "<DocumentList>";
                            for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                            {
                                string DocumentID = ((Label)gvDocuments.Rows[i].FindControl("lblDocumentID")).Text;

                                if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                                {
                                    XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtARC=\"" + "Y" + "\"></Document>";
                                }
                                else
                                {
                                    XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtARC=\"" + "N" + "\"></Document>";

                                }
                            }
                            XMLstring += "</DocumentList>";

                            SelfVerification selfVerification = SaveSelfVerification();

                            selfVerification.XMLstring = XMLstring;
                            contentConfermation.Visible = true;
                            btnProceed.Visible = false;
                            selfVerification.ReportedCAPRound = Global.CAPRound;
                            selfVerification.PersonalID = Convert.ToInt64(ViewState["PID"]);
                            selfVerification.CreatedBy = Session["UserLoginID"].ToString();
                            selfVerification.CreatedByIPAddress = UserInfo.GetIPAddress();
                            string json = JsonConvert.SerializeObject(selfVerification);
                            ViewState["selfVerification"] = json;
                            // ViewState["selfVerification"] = (SelfVerification)selfVerification;
                            gvDocuments.Enabled = false;
                            DisableRadioButton();
                            // reg.SaveSelfVerification(selfVerification);

                        }
                        else
                        {
                            shInfo.SetMessage(valDoc, ShowMessageType.Information);
                            shInfo.Focus();
                        }
                    }
                    else
                    {
                        shInfo.SetMessage(valmsg, ShowMessageType.Information);
                        shInfo.Focus();
                    }
                }
                else
                {
                    shInfo.SetMessage("Please Login again or clear the browser History", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private SelfVerification SaveSelfVerification()
        {
            lblDisplayDocumentSubmissionStatus.Text = "";
            string BlockFlag = "";
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
            string GenderFlag = "";
            string CategoryFlag = "";
            string QualificationFlag = "";
            Int32 CategoryChangeFlag = 0;

            SessionData objSessionData = (SessionData)Session["SessionData"];
            DataSet dsCurrentAllotmentDetails = reg.getCurrentAllotmentDetails(objSessionData.PID);

            if (dsCurrentAllotmentDetails.Tables[0].Rows.Count == 0)
            {
                DataRow dr = dsCurrentAllotmentDetails.Tables[0].NewRow();
                dr["CandidatureType_Benifited"] = "No";
                dr["Category_Benifited"] = "No";
                dr["EWS_Benifited"] = "No";
                dr["PWD_Benifited"] = "No";
                dr["Defense_Benifited"] = "No";
                dr["ORPHAN_Benifited"] = "No";
                dr["TFWS_Benifited"] = "No";
                dr["LinguisticMinority_Benifited"] = "No";
                dr["MinorityFlag"] = "No";
                dr["ReligiousMinority_Benifited"] = "No";
                dr["FemaleReservation_Benifited"] = "No";
                dr["Nationality_Benifited"] = "No";
                dsCurrentAllotmentDetails.Tables[0].Rows.Add(dr);
            }

            DataSet dsPersonalInformation = reg.getPersonalInformationForAllotmentDisplay(objSessionData.PID);

            for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
            {
                if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnNo")).Checked)
                {
                    Int32 DocumentID = Int32.Parse(((Label)gvDocuments.Rows[i].FindControl("lblDocumentID")).Text);
                    string DocumentDetails = gvDocuments.Rows[i].Cells[1].Text;

                    if (DocumentID == 1)
                    {
                        // BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";

                    }
                    else if (DocumentID == 5)
                    {
                        CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 6)
                    {
                        CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 7)
                    {
                        CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 8)
                    {
                        CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 9)
                    {
                        CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 11)
                    {
                        CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 12)
                    {
                        CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 20)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 21)
                    {
                        CasteCertificateFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 22)
                    {
                        CasteValidityCertificateFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 23)
                    {
                        CVCReceiptFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 24)
                    {
                        NonCreamyLayerCertificateFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 40)
                    {
                        NCLReceiptFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 25)
                    {
                        PHTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 26)
                    {
                        PHTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 27)
                    {
                        DefenceTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 28)
                    {
                        DefenceTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 29)
                    {
                        DefenceTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 30)
                    {
                        DefenceTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 32)
                    {
                        TFWSFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 33)
                    {
                        MinorityFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 35)
                    {
                        OrphanFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 36)
                    {
                        EWSFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 42)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 43)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 45)
                    {
                        IGDFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 47)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 81)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 82)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 83)
                    {
                        BlockFlag += "As candidate has not submitted  " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 84)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 85)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 86)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 87)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 88)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 89)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 90)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 91)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 92)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 93)
                    {
                        BlockFlag += "As candidate has not submitted  " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 94)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 95)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 96)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 97)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 98)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 99)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 100)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 101)
                    {
                        BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                    }

                    if (CandidatureTypeFlag.Length > 0)
                    {
                        CandidatureTypeFlag += "And hence, candidate's Type of Candidature is converted to 'OMS'.<br />";
                        CandidatureTypeFlag += "And hence, candidate's Category has been converted to 'OPEN'.<br />";
                        CategoryChangeFlag = 1;
                        if (PHTypeFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Person with Disability Quota.<br />";
                            PHTypeFlag = "Change";
                        }
                        if (DefenceTypeFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Defence Employee Quota.<br />";
                            DefenceTypeFlag = "Change";
                        }
                        if (EWSFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for EWS Quota.<br />";
                            EWSFlag = "Change";
                        }
                        if (TFWSFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for TFWS Quota.<br />";
                            TFWSFlag = "Change";
                        }
                        if (OrphanFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Orphan Quota.<br />";
                            OrphanFlag = "Change";
                        }
                        if (MinorityFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Linguistic / Religious Minority Quota.<br />";
                            MinorityFlag = "Change";
                        }
                        if (IGDFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Intermediate Grade Drawing.<br />";
                            IGDFlag = "Change";
                        }
                        lblDisplayDocumentSubmissionStatus.Text += CandidatureTypeFlag + "<br /><br />";
                    }
                    else
                    {
                        if (CasteCertificateFlag.Length > 0 || CasteValidityCertificateFlag.Length > 0 || CVCReceiptFlag.Length > 0 || NonCreamyLayerCertificateFlag.Length > 0 || NCLReceiptFlag.Length > 0)
                        {
                            CasteCertificateFlag += CasteValidityCertificateFlag + CVCReceiptFlag + NonCreamyLayerCertificateFlag + NCLReceiptFlag + "And hence, candidate's Category has been converted to 'OPEN'.";
                            lblDisplayDocumentSubmissionStatus.Text += CasteCertificateFlag + "<br /><br />";
                            CategoryChangeFlag = 1;
                        }
                        if (PHTypeFlag.Length > 2)
                        {
                            PHTypeFlag += "And hence, candidate can not avail the Privilege for Person with Disability Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += PHTypeFlag + "<br /><br />";
                        }
                        if (DefenceTypeFlag.Length > 4)
                        {
                            DefenceTypeFlag += "And hence, candidate can not avail the Privilege for Defence Employee Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += DefenceTypeFlag + "<br /><br />";
                        }
                        if (EWSFlag.Length > 2)
                        {
                            EWSFlag += "And hence, candidate can not avail the Privilege for EWS Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += EWSFlag + "<br /><br />";
                        }
                        if (TFWSFlag.Length > 2)
                        {
                            TFWSFlag += "And hence, candidate can not avail the Privilege for TFWS Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += TFWSFlag + "<br /><br />";
                        }
                        if (OrphanFlag.Length > 2)
                        {
                            OrphanFlag += "And hence, candidate can not avail the Privilege for Orphan Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += OrphanFlag + "<br /><br />";
                        }
                        if (MinorityFlag.Length > 2)
                        {
                            MinorityFlag += "And hence, candidate can not avail the Privilege for Linguistic / Religious Minority Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += MinorityFlag + "<br /><br />";
                        }
                        if (IGDFlag.Length > 2)
                        {
                            IGDFlag += "And hence, candidate can not avail the Privilege for Intermediate Grade Drawing.";
                            lblDisplayDocumentSubmissionStatus.Text += IGDFlag + "<br /><br />";
                        }
                    }
                }
            }
            SelfVerification obj = new SelfVerification();
            if (trGender.Visible == true)
            {
                if (chkGenderV.Checked)
                {
                    obj.Gender = "Y";
                }
                else
                {
                    obj.Gender = "N";

                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["FemaleReservation_Benifited"].ToString() == "Yes")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        GenderFlag += "As candidate has not Self Verified the Gender and hence Alloted institute will be Cancelled and Eligible for Next Subsequent Round.<br /> ";
                    }
                    else
                    {
                        GenderFlag += "As candidate has not Self Verified the Gender and has not taken the benefit of Female Reservation in allotment, hence Alloted institute will not be  Cancelled and Gender will be updated.<br />";
                    }

                    lblDisplayDocumentSubmissionStatus.Text += GenderFlag + "<br /><br />";
                    obj.IsGrivanceRaised = "Y";

                    //GenderFlag += "As candidate has not Self Verify the Gender And hence Alloted Institue will be Cancelled And Eligible for Next Subsequent Round.<br /> ";
                    //lblDisplayDocumentSubmissionStatus.Text += GenderFlag + "<br /><br />";
                    //obj.isAllotmentCancellationRequired = 1;
                    //obj.IsGrivanceRaised = "Y";
                }
            }
            else
            {
                obj.Gender = "";

            }
            if (trCandidature.Visible == true)
            {
                if (chkCandidatureV.Checked)
                {
                    obj.FinalCandidatureType = "Y";
                }
                else
                {
                    obj.FinalCandidatureType = "N";

                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["CandidatureType_Benifited"].ToString() == "Yes")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        CandidatureTypeFlag += "As candidate has not Self Verified the Candidature Type And hence, candidate's Type of Candidature will be converted to 'OMS' and Alloted institute will be Cancelled.<br /> ";
                    }
                    else
                    {
                        CandidatureTypeFlag += "As candidate has not Self Verified the Candidature Type and has not taken the benefit of Candidature Type in allotment hence, candidate's Type of Candidature is converted to 'OMS'.<br /> ";
                    }

                    lblDisplayDocumentSubmissionStatus.Text += CandidatureTypeFlag + "<br /><br />";
                    obj.IsGrivanceRaised = "Y";

                    //CandidatureTypeFlag += "As candidate has not Self Verify the Candidature Type And hence, candidate's Type of Candidature is converted to 'OMS'.<br /> ";
                    //lblDisplayDocumentSubmissionStatus.Text += CandidatureTypeFlag + "<br /><br />";
                    //obj.isAllotmentCancellationRequired = 1;
                    //obj.IsGrivanceRaised = "Y";
                }
            }
            else
            {
                obj.FinalCandidatureType = "";
            }
            if (trCategory.Visible == true)
            {
                if (chkCategoryV.Checked)
                { 
                    obj.FinalCategory = "Y";
                }
                else
                {
                    obj.FinalCategory = "N";
                    DataSet EligibilityRemark = reg.getEligibilityFlag(objSessionData.PID);

                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["Category_Benifited"].ToString() == "Yes")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        CategoryFlag += "As candidate has not Self Verified the Admission Category And hence, candidate's Category has been converted to 'OPEN' And Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";

                    }
                    else if (EligibilityRemark.Tables[0].Rows.Count > 0 && EligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && EligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                    {

                        obj.isAllotmentCancellationRequired = 1;
                        CategoryFlag += "As candidate has not Self Verified the Admission Category And hence, candidate's Category has been converted to 'OPEN' And Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";
                    }
                    else
                    {
                        CategoryFlag += "As candidate has not Self Verified the Admission Category and has not taken the benefit of Category Reservation in allotment hence, candidate's Category has been converted to 'OPEN' and Alloted institute will not be  Cancelled.<br /> ";
                    }

                    lblDisplayDocumentSubmissionStatus.Text += CategoryFlag + "<br /><br />";
                    obj.IsGrivanceRaised = "Y";

                    //CategoryFlag += "As candidate has not Self Verify the Admission Category And hence, candidate's Category has been converted to 'OPEN' And Alloted Institue will be Cancelled.<br /> ";
                    //lblDisplayDocumentSubmissionStatus.Text += CategoryFlag + "<br /><br />";
                    //obj.isAllotmentCancellationRequired = 1;
                    //obj.IsGrivanceRaised = "Y";
                }
            }
            else
            {
                obj.FinalCategory = "";
            }
            if (trEWS.Visible == true)
            {
                if (chkEWSV.Checked)
                { obj.FinalAppliedForEWS = "Y"; }
                else
                {
                    obj.FinalAppliedForEWS = "N";

                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["EWS_Benifited"].ToString() == "Yes")
                    {
                        obj.isAllotmentCancellationRequired = 1;

                        EWSFlag += "As candidate has not Self Verified the EWS and hence, candidate can not avail the Privilege for EWS Quota, Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";

                    }
                    else
                    {
                        EWSFlag += "As candidate has not Self Verified the EWS and has not taken the benefit of EWS Quota in allotment hence, candidate will be converted to Non-EWS, Alloted institute will not be Cancelled.<br /> ";
                    }

                    lblDisplayDocumentSubmissionStatus.Text += EWSFlag + "<br /><br />";
                    obj.IsGrivanceRaised = "Y";

                    //EWSFlag += "As candidate has not Self Verify the EWS And hence, candidate can not avail the Privilege for EWS Quota.<br />";
                    //lblDisplayDocumentSubmissionStatus.Text += EWSFlag + "<br /><br />";
                    //obj.isAllotmentCancellationRequired = 1;
                    //obj.IsGrivanceRaised = "Y";
                }
            }
            else
            {
                obj.FinalAppliedForEWS = "";
            }
            if (trPH.Visible == true)
            {
                if (chkPWDV.Checked)
                {
                    obj.FinalPHType = "Y";
                }
                else
                {
                    obj.FinalPHType = "N";

                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["PWD_Benifited"].ToString() == "Yes")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        PHTypeFlag += "As candidate has not Self Verified the PWD and hence, candidate can not avail the Privilege for PWD Quota, Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";
                    }
                    else
                    {
                        PHTypeFlag += "As candidate has not Self Verified the PWD and has not taken the benefit of PWD Quota in allotment hence, candidate will be converted to Non-PWD, Alloted institute will not be Cancelled.<br /> ";
                    }

                    lblDisplayDocumentSubmissionStatus.Text += PHTypeFlag + "<br /><br />";
                    obj.IsGrivanceRaised = "Y";

                    //PHTypeFlag = "As candidate has not Self Verify the PWD And hence, candidate can not avail the Privilege for Person with Disability Quota.<br />";
                    //lblDisplayDocumentSubmissionStatus.Text += PHTypeFlag + "<br /><br />";
                    //obj.isAllotmentCancellationRequired = 1;
                    //obj.IsGrivanceRaised = "Y";
                }
            }
            else
            {
                obj.FinalPHType = "";
            }
            if (trDef.Visible == true)
            {
                if (chkDefV.Checked)
                { obj.FinalDefenceType = "Y"; }
                else
                {
                    obj.FinalDefenceType = "N";

                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["Defense_Benifited"].ToString() == "Yes")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        DefenceTypeFlag += "As candidate has not Self Verified the DEF and hence, candidate can not avail the Privilege for DEF Quota, Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";
                    }
                    else
                    {
                        DefenceTypeFlag += "As candidate has not Self Verified the DEF and has not taken the benefit of DEF Quota in allotment hence, candidate will be converted to Non-DEF, Alloted institute will not be Cancelled.<br /> ";
                    }

                    lblDisplayDocumentSubmissionStatus.Text += DefenceTypeFlag + "<br /><br />";
                    obj.IsGrivanceRaised = "Y";

                    //DefenceTypeFlag = "As candidate has not Self Verify the DEF And hence, candidate can not avail the Privilege for Defence Employee Quota.<br />";
                    //lblDisplayDocumentSubmissionStatus.Text += DefenceTypeFlag + "<br /><br />";
                    //obj.isAllotmentCancellationRequired = 1;
                    //obj.IsGrivanceRaised = "Y";
                }
            }
            else
            {
                obj.FinalDefenceType = "";
            }
            if (trorphan.Visible == true)
            {
                if (chkOrphanV.Checked)
                { obj.FinalIsOrphan = "Y"; }
                else
                {
                    obj.FinalIsOrphan = "N";

                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["ORPHAN_Benifited"].ToString() == "Yes")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        OrphanFlag += "As candidate has not Self Verified the ORPHAN and hence, candidate can not avail the Privilege for ORPHAN Quota, Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";
                    }
                    else
                    {
                        OrphanFlag += "As candidate has not Self Verified the ORPHAN and has not taken the benefit of ORPHAN Quota in allotment hence, candidate will be converted to Non-ORPHAN, Alloted institute will not be Cancelled.<br /> ";

                    }

                    lblDisplayDocumentSubmissionStatus.Text += OrphanFlag + "<br /><br />";
                    obj.IsGrivanceRaised = "Y";

                    //OrphanFlag = "As candidate has not Self Verify the ORPHAN And hence, candidate can not avail the Privilege for Orphan Quota.<br />";
                    //lblDisplayDocumentSubmissionStatus.Text += OrphanFlag + "<br /><br />";
                    //obj.isAllotmentCancellationRequired = 1;
                    //obj.IsGrivanceRaised = "Y";
                }
            }
            else
            {
                obj.FinalIsOrphan = "";
            }
            if (trTFWS.Visible == true)
            {
                if (chkTFWSV.Checked)
                {
                    obj.FinalAppliedForTFWS = "Y";
                }
                else
                {
                    obj.FinalAppliedForTFWS = "N";

                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["TFWS_Benifited"].ToString() == "Yes")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        TFWSFlag += "As candidate has not Self Verified the TFWS and hence, candidate can not avail the Privilege for TFWS Quota, Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";
                    }
                    else
                    {
                        TFWSFlag += "As candidate has not Self Verified the TFWS and has not taken the benefit of TFWS Quota in allotment hence, candidate will be converted to Non-TFWS, Alloted institute will not be Cancelled.<br /> ";
                    }

                    lblDisplayDocumentSubmissionStatus.Text += TFWSFlag + "<br /><br />";
                    obj.IsGrivanceRaised = "Y";

                    //TFWSFlag = "As candidate has not Self Verify the TFWS And hence, candidate can not avail the Privilege for TFWS Quota.<br />";
                    //lblDisplayDocumentSubmissionStatus.Text += TFWSFlag + "<br /><br />";
                    //obj.isAllotmentCancellationRequired = 1;
                    //obj.IsGrivanceRaised = "Y";
                }
            }
            else
            {
                obj.FinalAppliedForTFWS = "";
            }
            if (trLinguisticMinority.Visible == true)
            {
                if (chkLinguisticMinorityV.Checked)
                { obj.FinalLinguisticMinority = "Y"; }
                else
                {
                    obj.FinalLinguisticMinority = "N";

                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["LinguisticMinority_Benifited"].ToString() == "Yes" && dsCurrentAllotmentDetails.Tables[0].Rows[0]["MinorityFlag"].ToString() == "L")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        MinorityFlag += "As candidate has not Self Verified the Linguistic Minority and hence, candidate can not avail the Privilege for Linguistic Minority Quota, Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";
                    }
                    else if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["LinguisticMinority_Benifited"].ToString() == "Yes" && dsCurrentAllotmentDetails.Tables[0].Rows[0]["ReligiousMinority_Benifited"].ToString() == "No" && dsCurrentAllotmentDetails.Tables[0].Rows[0]["MinorityFlag"].ToString() == "LR")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        MinorityFlag += "As candidate has not Self Verified the Linguistic Minority and hence, candidate can not avail the Privilege for Linguistic Minority Quota, Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";
                    }
                    else
                    {
                        MinorityFlag += "As candidate has not Self Verified the Linguistic Minority and has not taken the benefit of Linguistic Minority Quota in allotment hence, candidate will be converted to Non-Linguistic Minority, Alloted institute will not be Cancelled.<br /> ";
                    }

                    lblDisplayDocumentSubmissionStatus.Text += MinorityFlag + "<br /><br />";
                    obj.IsGrivanceRaised = "Y";

                    //MinorityFlag += "As candidate has not Self Verify the Linguistic Minority And hence, candidate can not avail the Privilege for Linguistic / Religious Minority Quota.<br />";
                    //lblDisplayDocumentSubmissionStatus.Text += MinorityFlag + "<br /><br />";
                    //obj.isAllotmentCancellationRequired = 1;
                    //obj.IsGrivanceRaised = "Y";
                }
            }
            else
            {
                obj.FinalLinguisticMinority = "";
            }
            if (trReligiousMinority.Visible == true)
            {
                if (chkReligiousMinorityV.Checked)
                {
                    obj.FinalReligiousMinority = "Y";
                }
                else
                {
                    obj.FinalReligiousMinority = "N";

                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["ReligiousMinority_Benifited"].ToString() == "Yes" && dsCurrentAllotmentDetails.Tables[0].Rows[0]["MinorityFlag"].ToString() == "R")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        MinorityFlag += "As candidate has not Self Verified the Religious Minority and hence, candidate can not avail the Privilege for Religious Minority Quota, Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";

                    }
                    else if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["LinguisticMinority_Benifited"].ToString() == "No" && dsCurrentAllotmentDetails.Tables[0].Rows[0]["ReligiousMinority_Benifited"].ToString() == "Yes" && dsCurrentAllotmentDetails.Tables[0].Rows[0]["MinorityFlag"].ToString() == "LR")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                        MinorityFlag += "As candidate has not Self Verified the Religious Minority and hence, candidate can not avail the Privilege for Religious Minority Quota, Alloted institute will be Cancelled And Eligible for Next Subsequent Round.<br /> ";
                    }
                    else
                    {
                        MinorityFlag += "As candidate has not Self Verified the Religious Minority and has not taken the benefit of Religious Minority Quota in allotment hence, candidate will be converted to Non-Religious Minority, Alloted institute will not be Cancelled.<br /> ";
                    }

                    lblDisplayDocumentSubmissionStatus.Text += MinorityFlag + "<br /><br />";
                    obj.IsGrivanceRaised = "Y";


                    //MinorityFlag += "As candidate has not Self Verify the Religious Minority And hence, candidate can not avail the Privilege for Linguistic / Religious Minority Quota.<br />";
                    //lblDisplayDocumentSubmissionStatus.Text += MinorityFlag + "<br /><br />";
                    //obj.isAllotmentCancellationRequired = 1;
                    //obj.IsGrivanceRaised = "Y";
                }
            }
            else
            {
                obj.FinalReligiousMinority = "";
            }
            if (trLinguisticMinority.Visible == true && trReligiousMinority.Visible == true)
            {
                if (obj.FinalLinguisticMinority == "N" && obj.FinalReligiousMinority == "N")
                {
                    if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["LinguisticMinority_Benifited"].ToString() == "Yes" && dsCurrentAllotmentDetails.Tables[0].Rows[0]["ReligiousMinority_Benifited"].ToString() == "Yes" && dsCurrentAllotmentDetails.Tables[0].Rows[0]["MinorityFlag"].ToString() == "LR")
                    {
                        obj.isAllotmentCancellationRequired = 1;
                    }
                }

            }
            //Qualification 
            if (trHSCPercentage.Visible == true)
            {
                if (chkHSCPercengageNV.Checked)
                {
                    obj.HSCTotalPercentageNew = Convert.ToDecimal(txtHSCPercentage.Text);

                    obj.HSCTotalPercentage = "N";
                    if (Convert.ToDecimal(lblHSCPercentagecmp.Text) > Convert.ToDecimal(txtHSCPercentage.Text))
                    {
                        QualificationFlag += "Your HSC Percentage is InCorrect And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.HSCTotalPercentage = "Y";
            }
            else
                obj.HSCTotalPercentage = "";

            if (trSSCPercentage.Visible == true)
            {
                if (chkSSCPercengageNV.Checked)
                {
                    obj.SSCTotalPercentageNew = Convert.ToDecimal(txtSSCPercentage.Text);

                    obj.SSCTotalPercentage = "N";
                    if (Convert.ToDecimal(lblSSCPercentagecmp.Text) > Convert.ToDecimal(txtSSCPercentage.Text))
                    {
                        QualificationFlag += "Your SSC Percentage is InCorrect, SSC Percentage will be updated and Allotment will not be cancelled.<br />";
                        //QualificationFlag += "Your HSC Percentage is InCorrect And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        //obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.SSCTotalPercentage = "Y";
            }
            else
                obj.SSCTotalPercentage = "";

            if (trHSCTotal.Visible == true)
            {
                if (chkHSCAggregateNV.Checked)
                {
                    obj.HSCTotalMarksNew = Convert.ToDecimal(txtHSCTotal.Text);
                    obj.HSCTotalMarksOutofNew = Convert.ToDecimal(txtHSCTotalOutof.Text);
                    obj.HSCTotalMarksObtained = "N";

                    decimal HSCTotalPercentageOld = Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCTotalPercentage"].ToString());
                    decimal HSCTotalPercentageNew = Math.Round(Convert.ToDecimal(obj.HSCTotalMarksNew * 100) / obj.HSCTotalMarksOutofNew, 2);

                    if (HSCTotalPercentageOld > HSCTotalPercentageNew)
                    {
                        QualificationFlag += "As candidate has not Self Verify the HSC Aggregate And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.HSCTotalMarksObtained = "Y";
            }
            else
            {
                obj.HSCTotalMarksObtained = "";
            }
            if (trPhysics.Visible == true)
            {
                if (chkHSCPhysicsNV.Checked)
                {
                    obj.HSCPhysicsMarksNew = Convert.ToDecimal(txtHSCPhysicsStatus.Text);
                    obj.HSCPhysicsMarksOutofNew = Convert.ToDecimal(txtHSCPhysicsStatusOutOf.Text);
                    obj.HSCPhysicsMarksObtained = "N";

                    decimal physicsPercentageOld = Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCPhysicsPercentage"].ToString());
                    decimal physicsPercentageNew = Math.Round(Convert.ToDecimal(obj.HSCPhysicsMarksNew * 100) / obj.HSCPhysicsMarksOutofNew, 2);

                    if (physicsPercentageOld > physicsPercentageNew)
                    {
                        QualificationFlag += "As candidate has not Self Verify the HSC Physics And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.HSCPhysicsMarksObtained = "Y";
            }
            else
            {
                obj.HSCPhysicsMarksObtained = "";
            }

            if (trHSCChemistry.Visible == true)
            {

                if (chkHSCChemistryNV.Checked)
                {
                    obj.HSCChemistryMarksNew = Convert.ToDecimal(txtHSCChemistryStatus.Text);
                    obj.HSCChemistryMarksOutofNew = Convert.ToDecimal(txtHSCChemistryOutofMarks.Text);
                    obj.HSCChemistryMarksObtained = "N";

                    decimal chemistryPercentageOld = Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCChemistryPercentage"].ToString());
                    decimal chemistryPercentageNew = Math.Round(Convert.ToDecimal(obj.HSCChemistryMarksNew * 100) / obj.HSCChemistryMarksOutofNew, 2);

                    if (chemistryPercentageOld > chemistryPercentageNew)
                    {
                        QualificationFlag += "As candidate has not Self Verify the HSC Chemistry And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.HSCChemistryMarksObtained = "Y";
            }
            else
            {
                obj.HSCChemistryMarksObtained = "";
            }
            if (trHSCMathematics.Visible == true)
            {
                obj.SubjectId = 2;
                if (chkHSCMathematicsNV.Checked)
                {
                    obj.HSCSubjectMarksNew = Convert.ToDecimal(txtHSCMathematics.Text);
                    obj.HSCSubjectMarksOutOfNew = Convert.ToDecimal(txtHSCMathematicsOutof.Text);
                    obj.HSCSubjectMarksObtained = "N";

                    decimal MathePercentageOld = Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectPercentage"].ToString());
                    decimal MathePercentageNew = Math.Round(Convert.ToDecimal(obj.HSCSubjectMarksNew * 100) / obj.HSCSubjectMarksOutOfNew, 2);

                    if (MathePercentageOld > MathePercentageNew)
                    {
                        QualificationFlag += "As candidate has not Self Verify the HSC Mathematics And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.HSCSubjectMarksObtained = "Y";
            }
            else
            {
                if (hdnSubjectID.ToString() == "2")
                    obj.HSCSubjectMarksObtained = "";
            }
            if (trHSCBiology.Visible == true)
            {
                obj.SubjectId = 1;
                if (chkHSCBiologyNV.Checked)
                {
                    obj.HSCSubjectMarksNew = Convert.ToDecimal(txtHSCBiology.Text);
                    obj.HSCSubjectMarksOutOfNew = Convert.ToDecimal(txtHSCBiologyOutofMarks.Text);
                    obj.HSCSubjectMarksObtained = "N";

                    decimal BiologyPercentageOld = Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectPercentage"].ToString());
                    decimal BiologyPercentageNew = Math.Round(Convert.ToDecimal(obj.HSCSubjectMarksNew * 100) / obj.HSCSubjectMarksOutOfNew, 2);

                    if (BiologyPercentageOld > BiologyPercentageNew)
                    {
                        QualificationFlag += "As candidate has not Self Verify the HSC Biology And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.HSCSubjectMarksObtained = "Y";
            }
            else
            {
                if (hdnSubjectID.ToString() == "1")
                    obj.HSCSubjectMarksObtained = "";
            }
            if (trHSCEnglish.Visible == true)
            {
                if (chkHSCEnglishNV.Checked)
                {
                    obj.HSCEnglishMarksNew = Convert.ToDecimal(txtHSCEnglish.Text);
                    obj.HSCEnglishMarksOutofNew = Convert.ToDecimal(txtHSCEnglishOutof.Text);
                    obj.HSCEnglishMarksObtained = "N";
                    if (Convert.ToDecimal(lblHSCEnglishcmp.Text) > Convert.ToDecimal(txtHSCEnglish.Text))
                    {
                        QualificationFlag += "As candidate has not Self Verify the HSC English And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.HSCEnglishMarksObtained = "Y";
            }
            else
                obj.HSCEnglishMarksObtained = "";
            if (trSSCTotal.Visible == true)
            {
                if (chkSSCTotalNV.Checked)
                {
                    obj.SSCTotalMarksNew = Convert.ToDecimal(txtSSCTotal.Text);
                    obj.SSCTotalMarksOutofNew = Convert.ToDecimal(txtSSCTotalOutof.Text);
                    obj.SSCTotalMarksObtained = "N";
                    if (Convert.ToDecimal(lblSSCTotalcmp.Text) > Convert.ToDecimal(txtSSCTotal.Text))
                    {
                        QualificationFlag += "Your SSC Total Marks is InCorrect, SSC Total Marks will be updated and Allotment will not be cancelled.<br />";
                        //QualificationFlag += "As candidate has not Self Verify the SSC Total And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        //obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.SSCTotalMarksObtained = "Y";
            }
            else
                obj.SSCTotalMarksObtained = "";
            if (trSSCMath.Visible == true)
            {
                if (chkSSCMathematicsNV.Checked)
                {
                    obj.SSCMathMarksNew = Convert.ToDecimal(txtSSCMathematics.Text);
                    obj.SSCMathMarksOutofNew = Convert.ToDecimal(txtSSCMathematicsOutOf.Text);
                    obj.SSCMathMarksObtained = "N";
                    if (Convert.ToDecimal(lblSSCMathematicscmp.Text) > Convert.ToDecimal(txtSSCMathematics.Text))
                    {
                        QualificationFlag += "Your SSC Mathematics Marks is InCorrect, SSC Mathematics Marks will be updated and Allotment will not be cancelled.<br />";
                        //QualificationFlag += "As candidate has not Self Verify the SSC Mathematics And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        //obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.SSCMathMarksObtained = "Y";
            }
            else
                obj.SSCMathMarksObtained = "";
            if (trIntermediateGradeDrawing.Visible == true)
            {
                if (chkIntermediateGradeDrawingNV.Checked)
                {
                    obj.FinalIsIntermediateGradeDrawingNew = "No";
                    obj.FinalIsIntermediateGradeDrawing = "N";
                    QualificationFlag += "As candidate has not Self Verify the Intermediate Grade Drawing And hence, Allotment will be cancelled.<br />";
                    lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                    obj.isAllotmentCancellationRequired = 1;
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.FinalIsIntermediateGradeDrawing = "Y";
            }
            else
                obj.FinalIsIntermediateGradeDrawing = "";
            if (trDiploma.Visible == true)
            {
                obj.DiplomaMarksType = lblDiplomaMarkType.Text;
                if (chkDiplomaNV.Checked)
                {
                    obj.DiplomaMarksNew = Convert.ToDecimal(txtDiplomaMarks.Text);
                    obj.DiplomaMarksOutofNew = Convert.ToDecimal(txtDiplomaOutofMarks.Text);
                    obj.DiplomaMarksObtained = "N";
                    if (Convert.ToDecimal(lblDiplomacmp.Text) > Convert.ToDecimal(txtDiplomaMarks.Text))
                    {
                        QualificationFlag += "As candidate has not Self Verify the Diploma Marks And hence, Allotment will be cancelled.<br />";
                        lblDisplayDocumentSubmissionStatus.Text += QualificationFlag + "<br /><br />";
                        obj.isAllotmentCancellationRequired = 1;
                    }
                    obj.IsGrivanceRaised = "Y";
                }
                else
                    obj.DiplomaMarksObtained = "Y";
            }
            else
                obj.DiplomaMarksObtained = "";
            return obj;

        }
        private string ValidateParameters()
        {
            string valmsg = string.Empty;
            if (!chkGenderV.Checked && !chkGendreNV.Checked)
            {
                valmsg += "Please Verify Gender ! <br/>";
            }
            if (!chkCandidatureV.Checked && !chkCandidatureNV.Checked)
            {
                valmsg += "Please Verify Candidature Type ! <br/>";
            }
            if (!chkCategoryV.Checked && !chkCategoryNV.Checked)
            {
                valmsg += "Please Verify Category for Admission ! <br/>";
            }
            if (!chkEWSV.Checked && !chkEWSNV.Checked)
            {
                valmsg += "Please Verify EWS ! <br/>";
            }
            if (!chkPWDV.Checked && !chkPWDNV.Checked)
            {
                valmsg += "Please Verify PWD ! <br/>";
            }
            if (!chkDefV.Checked && !chkDefNV.Checked)
            {
                valmsg += "Please Verify DEF ! <br/>";
            }
            if (!chkOrphanV.Checked && !chkOrphanNV.Checked)
            {
                valmsg += "Please Verify Orphan ! <br/>";
            }
            if (!chkTFWSV.Checked && !chkTFWSNV.Checked)
            {
                valmsg += "Please Verify TFWS ! <br/>";
            }
            if (!chkLinguisticMinorityV.Checked && !chkLinguisticMinorityNV.Checked)
            {
                valmsg += "Please Verify Linguistic Minority ! <br/>";
            }
            if (!chkReligiousMinorityV.Checked && !chkReligiousMinorityNV.Checked)
            {
                valmsg += "Please Verify Religious Minority ! <br/>";
            }
            if (!chkHSCAggregateV.Checked && !chkHSCAggregateNV.Checked)
            {
                valmsg += "Please Verify HSC Total Marks ! <br/>";
            }
            if (trPhysics.Visible == true)
                if (!chkHSCPhysicsV.Checked && !chkHSCPhysicsNV.Checked)
                {
                    valmsg += "Please Verify HSC Physics Marks ! <br/>";
                }
            if (trHSCChemistry.Visible == true)
                if (trHSCChemistry.Visible == true)
                {
                    if (!chkHSCChemistryV.Checked && !chkHSCChemistryNV.Checked)
                    {
                        valmsg += "Please Verify HSC Chemistry Marks ! <br/>";
                    }
                }
            if (trHSCBiology.Visible == true)
            {
                if (!chkHSCBiologyV.Checked && !chkHSCBiologyNV.Checked)
                {
                    valmsg += "Please Verify HSC Biology Marks ! <br/>";
                }
            }
            if (!chkHSCAggregateV.Checked && !chkHSCAggregateNV.Checked)
            {
                valmsg += "Please Verify HSC Aggregate Marks ! <br/>";
            }
            if (trHSCMathematics.Visible == true)
                if (!chkHSCMathematicsV.Checked && !chkHSCMathematicsNV.Checked)
                {
                    valmsg += "Please Verify HSC Mathematics Marks ! <br/>";
                }
            if (trHSCEnglish.Visible == true)
                if (!chkHSCEnglishV.Checked && !chkHSCEnglishNV.Checked)
                {
                    valmsg += "Please Verify HSC English Marks ! <br/>";
                }
            if (trSSCTotal.Visible == true)
                if (!chkSSCTotalV.Checked && !chkSSCTotalNV.Checked)
                {
                    valmsg += "Please Verify SSC Total Marks ! <br/>";
                }
            if (trSSCMath.Visible == true)
                if (!chkSSCMathematicsV.Checked && !chkSSCMathematicsNV.Checked)
                {
                    valmsg += "Please Verify SSC Mathematics Marks ! <br/>";
                }
            if (trIntermediateGradeDrawing.Visible == true)
                if (!chkIntermediateGradeDrawingV.Checked && !chkIntermediateGradeDrawingNV.Checked)
                {
                    valmsg += "Please Verify Intermediate Grade Drawing ! <br/>";
                }
            if (trDiploma.Visible == true)
                if (!chkDiplomaV.Checked && !chkDiplomaNV.Checked)
                {
                    valmsg += "Please Verify Diploma Marks ! <br/>";
                }
            if (chkSSCMathematicsNV.Checked && txtSSCMathematics.Text == "")
            {
                valmsg += "Please Enter SSC Mathematics Marks! <br/>";
            }
            if (chkHSCAggregateNV.Checked && txtHSCTotal.Text == "")
            {
                valmsg += "Please Enter HSC Total Marks! <br/>";
            }
            if (chkHSCPhysicsNV.Checked && txtHSCPhysicsStatus.Text == "")
            {
                valmsg += "Please Enter HSC Physics Marks! <br/>";
            }
            if (chkHSCChemistryNV.Checked && txtHSCChemistryStatus.Text == "")
            {
                valmsg += "Please Enter HSC Chemistry Marks ! <br/>";
            }
            if (chkHSCBiologyNV.Checked && txtHSCBiology.Text == "")
            {
                valmsg += "Please Enter HSC Biology Marks ! <br/>";
            }
            if (chkHSCMathematicsNV.Checked && txtHSCMathematics.Text == "")
            {
                valmsg += "Please Enter HSC Mathematics Marks ! <br/>";
            }
            if (chkHSCEnglishNV.Checked && txtHSCEnglish.Text == "")
            {
                valmsg += "Please Enter HSC English Marks ! <br/>";
            }
            //     if (trSSCTotal.Visible == true)
            if (chkSSCTotalNV.Checked && txtSSCTotal.Text == "")
            {
                valmsg += "Please Enter SSC Total Marks ! <br/>";
            }
            //////////////////////////////
            ///
            if (chkSSCMathematicsNV.Checked && txtSSCMathematicsOutOf.Text == "")
            {
                valmsg += "Please Enter SSC Mathematics Out of Marks! <br/>";
            }
            if (chkHSCAggregateNV.Checked && txtHSCTotalOutof.Text == "")
            {
                valmsg += "Please Enter HSC Total Out of Marks! <br/>";
            }
            if (chkHSCPhysicsNV.Checked && txtHSCPhysicsStatusOutOf.Text == "")
            {
                valmsg += "Please Enter HSC Physics Out of Marks! <br/>";
            }
            if (chkHSCChemistryNV.Checked && txtHSCChemistryOutofMarks.Text == "")
            {
                valmsg += "Please Enter HSC Chemistry Out of Marks ! <br/>";
            }
            if (chkHSCBiologyNV.Checked && txtHSCBiologyOutofMarks.Text == "")
            {
                valmsg += "Please Enter HSC Biology Out of Marks ! <br/>";
            }
            if (chkHSCMathematicsNV.Checked && txtHSCMathematicsOutof.Text == "")
            {
                valmsg += "Please Enter HSC Mathematics Out of Marks ! <br/>";
            }
            if (chkHSCEnglishNV.Checked && txtHSCEnglishOutof.Text == "")
            {
                valmsg += "Please Enter HSC English Out of Marks ! <br/>";
            }
            //     if (trSSCTotal.Visible == true)
            if (chkSSCTotalNV.Checked && txtSSCTotalOutof.Text == "")
            {
                valmsg += "Please Enter SSC Total Out of Marks ! <br/>";
            }
            if (chkSSCPercengageNV.Checked && txtSSCPercentage.Text == "")
            {
                valmsg += "Please Enter SSC Percentage ! <br/>";
            }
            if (chkHSCPercengageNV.Checked && txtHSCPercentage.Text == "")
            {
                valmsg += "Please Enter HSC Percentage ! <br/>";
            }
            if (chkDiplomaNV.Checked && txtDiplomaMarks.Text == "")
            {
                valmsg += "Please Enter Diploma Marks ! <br/>";
            }
            if (chkDiplomaNV.Checked && txtDiplomaOutofMarks.Text == "")
            {
                valmsg += "Please Enter Diploma Out of Marks ! <br/>";
            }
            return valmsg;
        }
        private string ValidateDocument()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string NotCheckDiscripancy = string.Empty;
                for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                {
                    //string DiscrepancyID = ((Label)gvDocuments.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    //string DiscrepancyRemark = ((TextBox)gvDocuments.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

                    if (!((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked && !((RadioButton)gvDocuments.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        if (NotCheckDiscripancy == String.Empty)
                        {
                            NotCheckDiscripancy = gvDocuments.Rows[i].Cells[1].Text;
                        }
                        else
                            NotCheckDiscripancy = NotCheckDiscripancy + ", " + gvDocuments.Rows[i].Cells[1].Text;
                    }

                }
                return NotCheckDiscripancy;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return null;
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            EnagbleRadioButton();
            LoadData(Convert.ToInt64(ViewState["PID"]));
            contentConfermation.Visible = false;
            btnProceed.Visible = true;

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (MyCheckBox.Checked)
            {
                if (lblDisplayDocumentSubmissionStatus.Text.Length == 0)
                {
                    lblDisplayDocumentSubmissionStatus.Text = "You have Verify all the Data!";
                }
                if (ViewState["selfVerification"] != null)
                {
                    string json = (string)ViewState["selfVerification"];
                    SelfVerification selfVerification = JsonConvert.DeserializeObject<SelfVerification>(json);

                    if (selfVerification.IsGrivanceRaised == "Y")
                    {
                        contentConfermation.Visible = false;
                        contentOTPVerify.Visible = true;
                        tblOtp.Visible = false;
                    }
                    else
                    {
                        selfVerification.IsGrivanceRaised = "N";
                        if (reg.SaveSelfVerification(selfVerification))
                            Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceStatusDetails", true);
                        else
                            contentConfermation.Visible = true;
                    }
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                }

            }
            else
            {
                shInfo.SetMessage("Please Check the Terms", ShowMessageType.Information);
                shInfo.Focus();
            }

        }
        protected void mychekbox_checkedChanged(object sender, EventArgs e)
        {
            if (MyCheckBox.Checked)
            {
                btnSave.Focus();
            }
            else
                MyCheckBox.Focus();
        }
        protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            //  e.IsValid = MyCheckBox.Checked;
        }


        protected void btnCall_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            string mobno = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID));

            SMS objSMS = new SMS();
            objSMS.voiceCallOTP(mobno);
            this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemouts();</script>"));
        }
        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();
                if (txtOneTimePassword.Text.Length == 0)
                {
                    shInfo.SetMessage("Enter the OTP", ShowMessageType.Information);
                }
                else
                {
                    if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, (int)SynCommon.TemplateSystemType.OTPARCSelfGrivanceRase))
                    {
                        string json = (string)ViewState["selfVerification"];
                        SelfVerification selfVerification = JsonConvert.DeserializeObject<SelfVerification>(json);
                        if (reg.SaveSelfVerification(selfVerification))
                        {
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = objSessionData.PID;
                            sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                            sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                            sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ARCSelfGrivanceRase);
                            Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                        }
                        btnCall.Visible = false;
                    }
                    else
                    {
                        shInfo.SetMessage("OTP is Invalid.", ShowMessageType.Information);
                        this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                    }
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnpassword_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int64 result = reg.authenticateCandidateLogin(Session["UserLoginID"].ToString(), DataEncryption.EncryptDataByHashSHA1(txtPassword.Text));
                if (result > 0)
                {
                    if (true)
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = true;
                        hdnPassword.Value = txtPassword.Text;
                        btnCall.Visible = true;
                        long PID = objSessionData.PID;
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        sMSTemplate.PID = PID;
                        SynCommon synCommon = new SynCommon();
                        if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OTPARCSelfGrivanceRase))
                        {
                            trMobileNo.Visible = true;
                            lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID).ToString())).ToString();
                        }
                        this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                    }
                    else
                    {

                    }
                }
                else
                {
                    shInfo.SetMessage("Password does not Match.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        private void DisableRadioButton()
        {
            chkGenderV.Enabled = false; chkGendreNV.Enabled = false;
            chkCandidatureV.Enabled = false; chkCandidatureNV.Enabled = false;
            chkCategoryV.Enabled = false; chkCategoryNV.Enabled = false;
            chkEWSV.Enabled = false; chkEWSNV.Enabled = false;
            chkPWDV.Enabled = false; chkPWDNV.Enabled = false;
            chkDefV.Enabled = false; chkDefNV.Enabled = false;
            chkOrphanV.Enabled = false; chkOrphanNV.Enabled = false;
            chkTFWSV.Enabled = false; chkTFWSNV.Enabled = false;
            chkLinguisticMinorityV.Enabled = false; chkLinguisticMinorityNV.Enabled = false;
            chkReligiousMinorityV.Enabled = false; chkReligiousMinorityNV.Enabled = false;
            chkHSCAggregateV.Enabled = false; chkHSCAggregateNV.Enabled = false;
            chkHSCPhysicsV.Enabled = false; chkHSCPhysicsNV.Enabled = false;
            chkHSCChemistryV.Enabled = false; chkHSCChemistryNV.Enabled = false;
            chkHSCBiologyV.Enabled = false; chkHSCBiologyNV.Enabled = false;
            chkHSCAggregateV.Enabled = false; chkHSCAggregateNV.Enabled = false;
            chkHSCMathematicsV.Enabled = false; chkHSCMathematicsNV.Enabled = false;
            chkHSCEnglishV.Enabled = false; chkHSCEnglishNV.Enabled = false;
            chkSSCTotalV.Enabled = false; chkSSCTotalNV.Enabled = false;
            chkSSCMathematicsV.Enabled = false; chkSSCMathematicsNV.Enabled = false;
            chkIntermediateGradeDrawingV.Enabled = false; chkIntermediateGradeDrawingNV.Enabled = false;
            chkDiplomaV.Enabled = false; chkDiplomaNV.Enabled = false;
            txtSSCMathematics.Enabled = false;
            txtHSCTotal.Enabled = false;
            txtHSCPhysicsStatus.Enabled = false;
            txtHSCChemistryStatus.Enabled = false;
            txtHSCBiology.Enabled = false;
            txtHSCMathematics.Enabled = false;
            txtHSCEnglish.Enabled = false;
            txtSSCTotal.Enabled = false;
            txtSSCMathematicsOutOf.Enabled = false;
            txtHSCTotalOutof.Enabled = false;
            txtHSCPhysicsStatusOutOf.Enabled = false;
            txtHSCChemistryOutofMarks.Enabled = false;
            txtHSCBiologyOutofMarks.Enabled = false;
            txtHSCMathematicsOutof.Enabled = false;
            txtHSCEnglishOutof.Enabled = false;
            txtSSCTotalOutof.Enabled = false;
            txtSSCPercentage.Enabled = false;
            txtHSCPercentage.Enabled = false;
            txtDiplomaMarks.Enabled = false;
            txtDiplomaOutofMarks.Enabled = false;


        }
        private void EnagbleRadioButton()
        {
            chkGenderV.Enabled = true; chkGendreNV.Enabled = true;
            chkCandidatureV.Enabled = true; chkCandidatureNV.Enabled = true;
            chkCategoryV.Enabled = true; chkCategoryNV.Enabled = true;
            chkEWSV.Enabled = true; chkEWSNV.Enabled = true;
            chkPWDV.Enabled = true; chkPWDNV.Enabled = true;
            chkDefV.Enabled = true; chkDefNV.Enabled = true;
            chkOrphanV.Enabled = true; chkOrphanNV.Enabled = true;
            chkTFWSV.Enabled = true; chkTFWSNV.Enabled = true;
            chkLinguisticMinorityV.Enabled = true; chkLinguisticMinorityNV.Enabled = true;
            chkReligiousMinorityV.Enabled = true; chkReligiousMinorityNV.Enabled = true;
            chkHSCAggregateV.Enabled = true; chkHSCAggregateNV.Enabled = true;
            chkHSCPhysicsV.Enabled = true; chkHSCPhysicsNV.Enabled = true;
            chkHSCChemistryV.Enabled = true; chkHSCChemistryNV.Enabled = true;
            chkHSCBiologyV.Enabled = true; chkHSCBiologyNV.Enabled = true;
            chkHSCAggregateV.Enabled = true; chkHSCAggregateNV.Enabled = true;
            chkHSCMathematicsV.Enabled = true; chkHSCMathematicsNV.Enabled = true;
            chkHSCEnglishV.Enabled = true; chkHSCEnglishNV.Enabled = true;
            chkSSCTotalV.Enabled = true; chkSSCTotalNV.Enabled = true;
            chkSSCMathematicsV.Enabled = true; chkSSCMathematicsNV.Enabled = true;
            chkIntermediateGradeDrawingV.Enabled = true; chkIntermediateGradeDrawingNV.Enabled = true;
            chkDiplomaV.Enabled = true; chkDiplomaNV.Enabled = true;

            if (chkSSCMathematicsNV.Checked)
            {
                txtSSCMathematics.Enabled = true;
                txtSSCMathematicsOutOf.Enabled = true;
            }

            if (chkHSCAggregateNV.Checked)
            {
                txtHSCTotal.Enabled = true;
                txtHSCTotalOutof.Enabled = true;
            }

            if (chkHSCPhysicsNV.Checked)
            {
                txtHSCPhysicsStatus.Enabled = true;
                txtHSCPhysicsStatusOutOf.Enabled = true;
            }

            if (chkHSCChemistryNV.Checked)
            {
                txtHSCChemistryStatus.Enabled = true;
                txtHSCChemistryOutofMarks.Enabled = true;
            }

            if (chkHSCBiologyNV.Checked)
            {
                txtHSCBiology.Enabled = true;
                txtHSCBiologyOutofMarks.Enabled = true;
            }

            if (chkHSCMathematicsNV.Checked)
            {
                txtHSCMathematics.Enabled = true;
                txtHSCMathematicsOutof.Enabled = true;
            }

            if (chkHSCEnglishNV.Checked)
            {
                txtHSCEnglish.Enabled = true;
                txtHSCEnglishOutof.Enabled = true;
            }
            txtSSCTotal.Enabled = true;
            txtSSCTotalOutof.Enabled = true;
            txtSSCPercentage.Enabled = true;
            txtHSCPercentage.Enabled = true;
            if (chkDiplomaNV.Checked)
            {
                txtDiplomaMarks.Enabled = true;
                txtDiplomaOutofMarks.Enabled = true;
            }
        }

    }
}