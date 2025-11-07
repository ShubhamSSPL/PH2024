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

namespace Pharmacy2024.StaticPages
{
    public partial class frmCheckFinalMeritStatus : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        //public string JEEName = Global.JEEName;
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string CurrentYear = Global.CurrentYear;
        string Flag = "";
        protected override void OnPreInit(EventArgs e)
        {
            Flag = Request.QueryString["Flag"].ToString();
            base.OnInit(e);
            if (Request.Cookies["Theme"] == null)
            {
                Page.Theme = "default";
            }
            else
            {
                Page.Theme = Request.Cookies["Theme"].Value;
            }

            if (Session["UserLoginId"] != null && Flag != null)
            {
                this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPage.master";
            }
            else if (Session["UserLoginId"] != null)
            {
                this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                if (Flag != null && Flag == "CandidateLogin")
                {
                    if (Session["UserLoginID"] == null)
                    {
                        Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                    }
                    cbCheckResult.Visible = false;
                    cbDisplayResult.Visible = true;

                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    string RDOB = reg.getCandidateDOB(objSessionData.PID);
                    DateTime DOB = Convert.ToDateTime(RDOB.Split("/".ToCharArray())[1] + "/" + RDOB.Split("/".ToCharArray())[0] + "/" + RDOB.Split("/".ToCharArray())[2]);
                    DataSet ds = reg.getFinalMeritStatus(Global.ApplicationFormPrefix + objSessionData.PID, DOB);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //DataSet dsNEET = reg.GetIncorrectNEETDetailsCandidate(Convert.ToInt64(ds.Tables[0].Rows[0]["PersonalID"]));
                        if (ds.Tables[0].Rows[0]["IsDuplicate"].ToString() == "Y")
                        {
                            shInfo.SetMessage("You have filled more than one Application Form. Please contact to SC.", ShowMessageType.Information);
                        }
                        //else if (dsNEET.Tables[0].Rows.Count > 0)
                        //{
                        //    shInfo.SetMessage("You have entered wrong NEET 2024 Details. Kindly correct your details(Score) immediately.", ShowMessageType.Information);
                        //}
                        else
                        {
                            cbCheckResult.Visible = false;
                            cbDisplayResult.Visible = true;

                            lblApplicationID.Text = ds.Tables[0].Rows[0]["ApplicationID"].ToString();

                            lblCandidateName.Text = ds.Tables[0].Rows[0]["CandidateName"].ToString().ToUpper();
                            lblGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                            lblDOB.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                            lblCandidatureType.Text = ds.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                            lblHomeUniversity.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                            lblOriginalCategory.Text = ds.Tables[0].Rows[0]["OriginalCategory"].ToString();
                            lblCategoryForAdmission.Text = ds.Tables[0].Rows[0]["AdmissionCategoryForDisplay"].ToString();
                            lblAppliedForTFWS.Text = ds.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                            if (ds.Tables[0].Rows[0]["AdmissionCategoryForDisplay"].ToString().Contains("$") || ds.Tables[0].Rows[0]["AdmissionCategoryForDisplay"].ToString().Contains("#") || ds.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString().Contains("@"))
                            {
                                //liCVCStatus.Visible = false;
                                //trCVCTVCRemark.Visible = true;
                                trCVCMsg.Visible = true;
                            }
                            else
                            {
                                trCVCMsg.Visible = false;
                            }
                            if (lblCategoryForAdmission.Text == "SBC")
                            {
                                lblCategoryForAdmission.Text += " - " + ds.Tables[0].Rows[0]["CategoryForMerit"].ToString();
                            }
                            lblAppliedForEWS.Text = ds.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                            lblIsOrphan.Text = ds.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                            lblPHType.Text = ds.Tables[0].Rows[0]["FinalPHType"].ToString();
                            lblDefenceType.Text = ds.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                            lblLinguisticMinority.Text = ds.Tables[0].Rows[0]["FinalLinguisticMinority"].ToString();
                            lblReligiousMinority.Text = ds.Tables[0].Rows[0]["FinalReligiousMinority"].ToString();

                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CETPCMBMAX"].ToString()) > 0)
                            {
                                trCETScore1.Visible = true;
                                trCETScore2.Visible = true;
                                trCETScore3.Visible = true;
                                trCETScore4.Visible = true;
                                trCETScore5.Visible = true;

                                lblCandidateNameAsPerCET.Text = ds.Tables[0].Rows[0]["CandidateNameAsPerCET"].ToString();
                                lblCETRollNo.Text = ds.Tables[0].Rows[0]["CETRollNo"].ToString();
                                lblCETPhysicsScore.Text = ds.Tables[0].Rows[0]["CETPhysicsMarks"].ToString();
                                lblCETChemistryScore.Text = ds.Tables[0].Rows[0]["CETChemistryMarks"].ToString();
                                lblCETMathScore.Text = ds.Tables[0].Rows[0]["CETMathMarks"].ToString();

                            }
                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CETMathMarks"].ToString()) > 0)
                            {
                                lblCETMathScore.Text = ds.Tables[0].Rows[0]["CETMathMarks"].ToString();
                            }
                            else
                            {
                                lblCETMathScore.Text = "--";
                            }

                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CETBiologyMarks"].ToString()) > 0)
                            {
                                lblCETBiologyScore.Text = ds.Tables[0].Rows[0]["CETBiologyMarks"].ToString();
                            }
                            else
                            {
                                lblCETBiologyScore.Text = "--";
                            }
                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString()) > 0)
                            {
                                lblCETPCMScore.Text = ds.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString();
                            }
                            else
                            {
                                lblCETPCMScore.Text = "--";
                            }
                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CETPCBTotalMarks"].ToString()) > 0)
                            {
                                lblCETPCBScore.Text = ds.Tables[0].Rows[0]["CETPCBTotalMarks"].ToString();
                            }
                            else
                            {
                                lblCETPCBScore.Text = "--";
                            }
                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["NEETTotalScore"].ToString()) > 0)
                            {
                                trNEETScore1.Visible = true;
                                trNEETScore2.Visible = true;
                                trNEETScore3.Visible = true;
                                trNEETScore4.Visible = true;


                                lblCandidateNameAsPerNEET.Text = ds.Tables[0].Rows[0]["CandidateNameAsPerNEET"].ToString();
                                lblNEETRollNo.Text = ds.Tables[0].Rows[0]["NEETRollNo"].ToString();
                                lblNEETPhysicsScore.Text = ds.Tables[0].Rows[0]["NEETPhysicsScore"].ToString();
                                lblNEETChemistryScore.Text = ds.Tables[0].Rows[0]["NEETChemistryScore"].ToString();
                                lblNEETBiologyScore.Text = ds.Tables[0].Rows[0]["NEETBiologyScore"].ToString();
                                lblNEETTotalScore.Text = ds.Tables[0].Rows[0]["NEETTotalScore"].ToString();
                            }


                            lblHSCPhysicsPercentage.Text = ds.Tables[0].Rows[0]["HSCPhysicsPercentage"].ToString() + " %";
                            lblHSCChemistryPercentage.Text = ds.Tables[0].Rows[0]["HSCChemistryPercentage"].ToString() + " %";
                            lblHSCSubject.Text = ds.Tables[0].Rows[0]["HSCSubject"].ToString();
                            lblHSCSubjectPercentage.Text = ds.Tables[0].Rows[0]["HSCSubjectPercentage"].ToString() + " %";
                            lblHSCTotalPercentage.Text = ds.Tables[0].Rows[0]["HSCTotalPercentage"].ToString() + " %";
                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["DiplomaTotalPercentage"].ToString()) > 0)
                            {
                                lblDiplomaTotalPercentage.Text = ds.Tables[0].Rows[0]["DiplomaTotalPercentage"].ToString() + " %";
                            }
                            else
                            {
                                lblDiplomaTotalPercentage.Text = "--";
                            }
                            lblHSCEligibilityPercentage.Text = ds.Tables[0].Rows[0]["HSCEligibilityPercentage"].ToString() + " %";
                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["DiplomaEligibilityPercentage"].ToString()) > 0)
                            {
                                lblDiplomaEligibilityPercentage.Text = ds.Tables[0].Rows[0]["DiplomaEligibilityPercentage"].ToString() + " %";
                            }
                            else
                            {
                                lblDiplomaEligibilityPercentage.Text = "--";
                            }
                            lblEligibleForMeritBPharmacy.Text = ds.Tables[0].Rows[0]["EligibleForMeritBPharmacy"].ToString();
                            lblEligibleForMeritPharmD.Text = ds.Tables[0].Rows[0]["EligibleForMeritPharmD"].ToString();

                            if (ds.Tables[0].Rows[0]["StateGeneralMeritNo"].ToString() != "0")
                            {
                                trStateGeneralMeritNo.Visible = true;
                                lblStateGeneralMeritNo.Text = ds.Tables[0].Rows[0]["StateGeneralMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["MeritExamMH"].ToString() + " (" + ds.Tables[0].Rows[0]["MeritScoreMH"].ToString() + ")";
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["UniversityGeneralMeritNo"].ToString()) > 0)
                            {
                                trUniversityGeneralMeritNo.Visible = true;
                                lblUniversityGeneralMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["UniversityGeneralMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["StateCategoryMeritNo"].ToString()) > 0)
                            {
                                trStateCategoryMeritNo.Visible = true;
                                lblStateCategoryMeritNo.Text = ds.Tables[0].Rows[0]["CategoryForMerit"].ToString() + " - " + ds.Tables[0].Rows[0]["StateCategoryMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["UniversityCategoryMeritNo"].ToString()) > 0)
                            {
                                trUniversityCategoryMeritNo.Visible = true;
                                lblUniversityCategoryMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["CategoryForMerit"].ToString() + " - " + ds.Tables[0].Rows[0]["UniversityCategoryMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["StateSBCMeritNo"].ToString()) > 0)
                            {
                                trStateSBCMeritNo.Visible = true;
                                lblStateSBCMeritNo.Text = ds.Tables[0].Rows[0]["AdmissionCategory"].ToString() + " - " + ds.Tables[0].Rows[0]["StateSBCMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["UniversitySBCMeritNo"].ToString()) > 0)
                            {
                                trUniversitySBCMeritNo.Visible = true;
                                lblUniversitySBCMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["AdmissionCategory"].ToString() + " - " + ds.Tables[0].Rows[0]["UniversitySBCMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesStateGeneralMeritNo"].ToString()) > 0)
                            {
                                trLadiesStateGeneralMeritNo.Visible = true;
                                lblLadiesStateGeneralMeritNo.Text = ds.Tables[0].Rows[0]["LadiesStateGeneralMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesUniversityGeneralMeritNo"].ToString()) > 0)
                            {
                                trLadiesUniversityGeneralMeritNo.Visible = true;
                                lblLadiesUniversityGeneralMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["LadiesUniversityGeneralMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesStateCategoryMeritNo"].ToString()) > 0)
                            {
                                trLadiesStateCategoryMeritNo.Visible = true;
                                lblLadiesStateCategoryMeritNo.Text = ds.Tables[0].Rows[0]["CategoryForMerit"].ToString() + " - " + ds.Tables[0].Rows[0]["LadiesStateCategoryMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesUniversityCategoryMeritNo"].ToString()) > 0)
                            {
                                trLadiesUniversityCategoryMeritNo.Visible = true;
                                lblLadiesUniversityCategoryMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["CategoryForMerit"].ToString() + " - " + ds.Tables[0].Rows[0]["LadiesUniversityCategoryMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesStateSBCMeritNo"].ToString()) > 0)
                            {
                                trLadiesStateSBCMeritNo.Visible = true;
                                lblLadiesStateSBCMeritNo.Text = ds.Tables[0].Rows[0]["AdmissionCategory"].ToString() + " - " + ds.Tables[0].Rows[0]["LadiesStateSBCMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesUniversitySBCMeritNo"].ToString()) > 0)
                            {
                                trLadiesUniversitySBCMeritNo.Visible = true;
                                lblLadiesUniversitySBCMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["AdmissionCategory"].ToString() + " - " + ds.Tables[0].Rows[0]["LadiesUniversitySBCMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["StatePHMeritNo"].ToString()) > 0)
                            {
                                trStatePHMeritNo.Visible = true;
                                lblStatePHMeritNo.Text = ds.Tables[0].Rows[0]["StatePHMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["PHTypeForMerit"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["UniversityPHMeritNo"].ToString()) > 0)
                            {
                                trUniversityPHMeritNo.Visible = true;
                                lblUniversityPHMeritNo.Text = ds.Tables[0].Rows[0]["UniversityPHMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["PHTypeForMerit"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["StateDefenceMeritNo"].ToString()) > 0)
                            {
                                trStateDefenceMeritNo.Visible = true;
                                lblStateDefenceMeritNo.Text = ds.Tables[0].Rows[0]["StateDefenceMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["TFWSMeritNo"].ToString()) > 0)
                            {
                                trTFWSMeritNo.Visible = true;
                                lblTFWSMeritNo.Text = ds.Tables[0].Rows[0]["TFWSMeritNo"].ToString() + " - [Income : " + ds.Tables[0].Rows[0]["AnnualFamilyIncomeDetails"].ToString() + "]";
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["EWSMeritNo"].ToString()) > 0)
                            {
                                trEWSMeritNo.Visible = true;
                                lblEWSMeritNo.Text = ds.Tables[0].Rows[0]["EWSMeritNo"].ToString();
                            }
                            if (Convert.ToInt64(ds.Tables[0].Rows[0]["OrphanMeritNo"].ToString()) > 0)
                            {
                                trOrphanMeritNo.Visible = true;
                                lblOrphanMeritNo.Text = ds.Tables[0].Rows[0]["OrphanMeritNo"].ToString();
                            }
                            //if (Convert.ToInt64(ds.Tables[0].Rows[0]["KonkanStateGeneralMeritNo"].ToString()) > 0)
                            //{
                            //    trKonkanStateGeneralMeritNo.Visible = true;
                            //    lblKonkanStateGeneralMeritNo.Text = ds.Tables[0].Rows[0]["KonkanStateGeneralMeritNo"].ToString();
                            //}
                            //if (Convert.ToInt64(ds.Tables[0].Rows[0]["KonkanStateCategoryMeritNo"].ToString()) > 0)
                            //{
                            //    trKonkanStateCategoryMeritNo.Visible = true;
                            //    lblKonkanStateCategoryMeritNo.Text = ds.Tables[0].Rows[0]["KonkanStateCategoryMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["CategoryForMerit"].ToString();
                            //}
                            if (ds.Tables[0].Rows[0]["AIMeritNo"].ToString() != "0")
                            {
                                trAIMeritNo.Visible = true;
                                lblAIMeritNo.Text = ds.Tables[0].Rows[0]["AIMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["MeritExamAI"].ToString() + " (" + ds.Tables[0].Rows[0]["MeritScoreAI"].ToString() + ")";
                            }
                        }
                    }
                    else
                    {
                        cbCheckResult.Visible = false;
                        cbDisplayResult.Visible = false;

                        shInfo.SetMessage("You are not Eligible for Merit.", ShowMessageType.Information);
                    }
                }
                else
                {
                    txtApplicationID.Text = Global.ApplicationFormPrefix;
                    if (Global.DisplayFinalMeritList == 1)
                    {
                        cbCheckResult.Visible = true;
                        cbDisplayResult.Visible = false;
                    }
                    else
                    {
                        cbCheckResult.Visible = false;
                        cbDisplayResult.Visible = false;
                        shInfo.SetMessage("Final Merit List is Not Published.", ShowMessageType.Information);
                    }
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                string ApplicationID = txtApplicationID.Text;
                if (txtDOB.Text.Contains("-"))
                {
                    txtDOB.Text = txtDOB.Text.Replace('-', '/');
                }
                DateTime DOB = Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]);

                DataSet ds = reg.getFinalMeritStatus(ApplicationID, DOB);

                if (ds.Tables[0].Rows.Count > 0)
                {
                   // DataSet dsNEET = reg.GetIncorrectNEETDetailsCandidate(Convert.ToInt64(ds.Tables[0].Rows[0]["PersonalID"]));
                    if (ds.Tables[0].Rows[0]["IsDuplicate"].ToString() == "Y")
                    {
                        shInfo.SetMessage("You have filled more than one Application Form. Please contact to SC.", ShowMessageType.Information);
                    }
                    //else if (dsNEET.Tables[0].Rows.Count > 0)
                    //{
                    //    shInfo.SetMessage("You have entered wrong NEET 2024 Details. Kindly correct your details(Score) immediately.", ShowMessageType.Information);
                    //}
                    else
                    {
                        cbCheckResult.Visible = false;
                        cbDisplayResult.Visible = true;

                        lblApplicationID.Text = ds.Tables[0].Rows[0]["ApplicationID"].ToString();

                        lblCandidateName.Text = ds.Tables[0].Rows[0]["CandidateName"].ToString().ToUpper();
                        lblGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                        lblDOB.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                        lblCandidatureType.Text = ds.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                        lblHomeUniversity.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                        lblOriginalCategory.Text = ds.Tables[0].Rows[0]["OriginalCategory"].ToString();
                        lblCategoryForAdmission.Text = ds.Tables[0].Rows[0]["AdmissionCategoryForDisplay"].ToString();
                        lblAppliedForTFWS.Text = ds.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                        if (ds.Tables[0].Rows[0]["AdmissionCategoryForDisplay"].ToString().Contains("$") || ds.Tables[0].Rows[0]["AdmissionCategoryForDisplay"].ToString().Contains("#") || ds.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString().Contains("@"))
                        {
                            //liCVCStatus.Visible = false;
                            //trCVCTVCRemark.Visible = true;
                            trCVCMsg.Visible = true;
                        }
                        else
                        {
                            trCVCMsg.Visible = false;
                        }
                        if (lblCategoryForAdmission.Text == "SBC")
                        {
                            lblCategoryForAdmission.Text += " - " + ds.Tables[0].Rows[0]["CategoryForMerit"].ToString();
                        }
                        lblAppliedForEWS.Text = ds.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                        lblIsOrphan.Text = ds.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                        lblPHType.Text = ds.Tables[0].Rows[0]["FinalPHType"].ToString();
                        lblDefenceType.Text = ds.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                        lblLinguisticMinority.Text = ds.Tables[0].Rows[0]["FinalLinguisticMinority"].ToString();
                        lblReligiousMinority.Text = ds.Tables[0].Rows[0]["FinalReligiousMinority"].ToString();

                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CETPCMBMAX"].ToString()) > 0)
                        {
                            trCETScore1.Visible = true;
                            trCETScore2.Visible = true;
                            trCETScore3.Visible = true;
                            trCETScore4.Visible = true;
                            trCETScore5.Visible = true;

                            lblCandidateNameAsPerCET.Text = ds.Tables[0].Rows[0]["CandidateNameAsPerCET"].ToString();
                            lblCETRollNo.Text = ds.Tables[0].Rows[0]["CETRollNo"].ToString();
                            lblCETPhysicsScore.Text = ds.Tables[0].Rows[0]["CETPhysicsMarks"].ToString();
                            lblCETChemistryScore.Text = ds.Tables[0].Rows[0]["CETChemistryMarks"].ToString();
                            lblCETMathScore.Text = ds.Tables[0].Rows[0]["CETMathMarks"].ToString();
                           
                        }
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CETMathMarks"].ToString()) > 0)
                        {
                            lblCETMathScore.Text = ds.Tables[0].Rows[0]["CETMathMarks"].ToString();
                        }
                        else
                        {
                            lblCETMathScore.Text = "--";
                        }
                        
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CETBiologyMarks"].ToString()) > 0)
                        {
                            lblCETBiologyScore.Text = ds.Tables[0].Rows[0]["CETBiologyMarks"].ToString();
                        }
                        else
                        {
                            lblCETBiologyScore.Text = "--";
                        }
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString()) > 0)
                        {
                            lblCETPCMScore.Text = ds.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString();
                        }
                        else
                        {
                            lblCETPCMScore.Text = "--";
                        }
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CETPCBTotalMarks"].ToString()) > 0)
                        {
                            lblCETPCBScore.Text = ds.Tables[0].Rows[0]["CETPCBTotalMarks"].ToString();
                        }
                        else
                        {
                            lblCETPCBScore.Text = "--";
                        }
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["NEETTotalScore"].ToString()) > 0)
                        {
                            trNEETScore1.Visible = true;
                            trNEETScore2.Visible = true;
                            trNEETScore3.Visible = true;
                            trNEETScore4.Visible = true;
                          

                            lblCandidateNameAsPerNEET.Text = ds.Tables[0].Rows[0]["CandidateNameAsPerNEET"].ToString();
                            lblNEETRollNo.Text = ds.Tables[0].Rows[0]["NEETRollNo"].ToString();
                            lblNEETPhysicsScore.Text = ds.Tables[0].Rows[0]["NEETPhysicsScore"].ToString();
                            lblNEETChemistryScore.Text = ds.Tables[0].Rows[0]["NEETChemistryScore"].ToString();
                            lblNEETBiologyScore.Text = ds.Tables[0].Rows[0]["NEETBiologyScore"].ToString();
                            lblNEETTotalScore.Text = ds.Tables[0].Rows[0]["NEETTotalScore"].ToString();
                        }

                        
                            lblHSCPhysicsPercentage.Text = ds.Tables[0].Rows[0]["HSCPhysicsPercentage"].ToString() + " %";
                            lblHSCChemistryPercentage.Text = ds.Tables[0].Rows[0]["HSCChemistryPercentage"].ToString() + " %";
                            lblHSCSubject.Text = ds.Tables[0].Rows[0]["HSCSubject"].ToString();
                            lblHSCSubjectPercentage.Text = ds.Tables[0].Rows[0]["HSCSubjectPercentage"].ToString() + " %";
                            lblHSCTotalPercentage.Text = ds.Tables[0].Rows[0]["HSCTotalPercentage"].ToString() + " %";
                           if (Convert.ToDecimal(ds.Tables[0].Rows[0]["DiplomaTotalPercentage"].ToString()) > 0)
                            {
                                lblDiplomaTotalPercentage.Text = ds.Tables[0].Rows[0]["DiplomaTotalPercentage"].ToString() + " %";
                            }
                            else
                            {
                                lblDiplomaTotalPercentage.Text = "--";
                            }
                            lblHSCEligibilityPercentage.Text = ds.Tables[0].Rows[0]["HSCEligibilityPercentage"].ToString() + " %";
                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["DiplomaEligibilityPercentage"].ToString()) > 0)
                            {
                                lblDiplomaEligibilityPercentage.Text = ds.Tables[0].Rows[0]["DiplomaEligibilityPercentage"].ToString() + " %";
                            }
                            else
                            {
                                lblDiplomaEligibilityPercentage.Text = "--";
                            }
                            lblEligibleForMeritBPharmacy.Text = ds.Tables[0].Rows[0]["EligibleForMeritBPharmacy"].ToString();
                            lblEligibleForMeritPharmD.Text = ds.Tables[0].Rows[0]["EligibleForMeritPharmD"].ToString();

                        if ( ds.Tables[0].Rows[0]["StateGeneralMeritNo"].ToString() != "0")
                        {
                            trStateGeneralMeritNo.Visible = true;
                            lblStateGeneralMeritNo.Text = ds.Tables[0].Rows[0]["StateGeneralMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["MeritExamMH"].ToString() + " (" + ds.Tables[0].Rows[0]["MeritScoreMH"].ToString() + ")";
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["UniversityGeneralMeritNo"].ToString()) > 0)
                        {
                            trUniversityGeneralMeritNo.Visible = true;
                            lblUniversityGeneralMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["UniversityGeneralMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["StateCategoryMeritNo"].ToString()) > 0)
                        {
                            trStateCategoryMeritNo.Visible = true;
                            lblStateCategoryMeritNo.Text = ds.Tables[0].Rows[0]["CategoryForMerit"].ToString() + " - " + ds.Tables[0].Rows[0]["StateCategoryMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["UniversityCategoryMeritNo"].ToString()) > 0)
                        {
                            trUniversityCategoryMeritNo.Visible = true;
                            lblUniversityCategoryMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["CategoryForMerit"].ToString() + " - " + ds.Tables[0].Rows[0]["UniversityCategoryMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["StateSBCMeritNo"].ToString()) > 0)
                        {
                            trStateSBCMeritNo.Visible = true;
                            lblStateSBCMeritNo.Text = ds.Tables[0].Rows[0]["AdmissionCategory"].ToString() + " - " + ds.Tables[0].Rows[0]["StateSBCMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["UniversitySBCMeritNo"].ToString()) > 0)
                        {
                            trUniversitySBCMeritNo.Visible = true;
                            lblUniversitySBCMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["AdmissionCategory"].ToString() + " - " + ds.Tables[0].Rows[0]["UniversitySBCMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesStateGeneralMeritNo"].ToString()) > 0)
                        {
                            trLadiesStateGeneralMeritNo.Visible = true;
                            lblLadiesStateGeneralMeritNo.Text = ds.Tables[0].Rows[0]["LadiesStateGeneralMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesUniversityGeneralMeritNo"].ToString()) > 0)
                        {
                            trLadiesUniversityGeneralMeritNo.Visible = true;
                            lblLadiesUniversityGeneralMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["LadiesUniversityGeneralMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesStateCategoryMeritNo"].ToString()) > 0)
                        {
                            trLadiesStateCategoryMeritNo.Visible = true;
                            lblLadiesStateCategoryMeritNo.Text = ds.Tables[0].Rows[0]["CategoryForMerit"].ToString() + " - " + ds.Tables[0].Rows[0]["LadiesStateCategoryMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesUniversityCategoryMeritNo"].ToString()) > 0)
                        {
                            trLadiesUniversityCategoryMeritNo.Visible = true;
                            lblLadiesUniversityCategoryMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["CategoryForMerit"].ToString() + " - " + ds.Tables[0].Rows[0]["LadiesUniversityCategoryMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesStateSBCMeritNo"].ToString()) > 0)
                        {
                            trLadiesStateSBCMeritNo.Visible = true;
                            lblLadiesStateSBCMeritNo.Text = ds.Tables[0].Rows[0]["AdmissionCategory"].ToString() + " - " + ds.Tables[0].Rows[0]["LadiesStateSBCMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["LadiesUniversitySBCMeritNo"].ToString()) > 0)
                        {
                            trLadiesUniversitySBCMeritNo.Visible = true;
                            lblLadiesUniversitySBCMeritNo.Text = ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["AdmissionCategory"].ToString() + " - " + ds.Tables[0].Rows[0]["LadiesUniversitySBCMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["StatePHMeritNo"].ToString()) > 0)
                        {
                            trStatePHMeritNo.Visible = true;
                            lblStatePHMeritNo.Text = ds.Tables[0].Rows[0]["StatePHMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["PHTypeForMerit"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["UniversityPHMeritNo"].ToString()) > 0)
                        {
                            trUniversityPHMeritNo.Visible = true;
                            lblUniversityPHMeritNo.Text = ds.Tables[0].Rows[0]["UniversityPHMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["FinalHomeUniversity"].ToString() + " - " + ds.Tables[0].Rows[0]["PHTypeForMerit"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["StateDefenceMeritNo"].ToString()) > 0)
                        {
                            trStateDefenceMeritNo.Visible = true;
                            lblStateDefenceMeritNo.Text = ds.Tables[0].Rows[0]["StateDefenceMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["TFWSMeritNo"].ToString()) > 0)
                        {
                            trTFWSMeritNo.Visible = true;
                            lblTFWSMeritNo.Text = ds.Tables[0].Rows[0]["TFWSMeritNo"].ToString() + " - [Income : " + ds.Tables[0].Rows[0]["AnnualFamilyIncomeDetails"].ToString() + "]";
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["EWSMeritNo"].ToString()) > 0)
                        {
                            trEWSMeritNo.Visible = true;
                            lblEWSMeritNo.Text = ds.Tables[0].Rows[0]["EWSMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["OrphanMeritNo"].ToString()) > 0)
                        {
                            trOrphanMeritNo.Visible = true;
                            lblOrphanMeritNo.Text = ds.Tables[0].Rows[0]["OrphanMeritNo"].ToString();
                        }
                        //if (Convert.ToInt64(ds.Tables[0].Rows[0]["KonkanStateGeneralMeritNo"].ToString()) > 0)
                        //{
                        //    trKonkanStateGeneralMeritNo.Visible = true;
                        //    lblKonkanStateGeneralMeritNo.Text = ds.Tables[0].Rows[0]["KonkanStateGeneralMeritNo"].ToString();
                        //}
                        //if (Convert.ToInt64(ds.Tables[0].Rows[0]["KonkanStateCategoryMeritNo"].ToString()) > 0)
                        //{
                        //    trKonkanStateCategoryMeritNo.Visible = true;
                        //    lblKonkanStateCategoryMeritNo.Text = ds.Tables[0].Rows[0]["KonkanStateCategoryMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["CategoryForMerit"].ToString();
                        //}
                        if ( ds.Tables[0].Rows[0]["AIMeritNo"].ToString() != "0")
                        {
                            trAIMeritNo.Visible = true;
                            lblAIMeritNo.Text = ds.Tables[0].Rows[0]["AIMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["MeritExamAI"].ToString() + " (" + ds.Tables[0].Rows[0]["MeritScoreAI"].ToString() + ")";
                        }
                        //if (Convert.ToInt64(ds.Tables[0].Rows[0]["JKMeritNo"].ToString()) > 0)
                        //{
                        //    trJKMeritNo.Visible = true;
                        //    lblJKMeritNo.Text = ds.Tables[0].Rows[0]["MeritExamJK"].ToString() + " (" + ds.Tables[0].Rows[0]["MeritScoreJK"].ToString() + ") - " + ds.Tables[0].Rows[0]["JKMeritNo"].ToString();
                        //}
                        //if (Convert.ToInt64(ds.Tables[0].Rows[0]["NRIMeritNo"].ToString()) > 0)
                        //{
                        //    trNRIMeritNo.Visible = true;
                        //    lblNRIMeritNo.Text = ds.Tables[0].Rows[0]["NRIMeritNo"].ToString();
                        //}
                        //if (Convert.ToInt64(ds.Tables[0].Rows[0]["FNPIOMeritNo"].ToString()) > 0)
                        //{
                        //    trFNPIOMeritNo.Visible = true;
                        //    lblFNPIOMeritNo.Text = ds.Tables[0].Rows[0]["FNPIOMeritNo"].ToString();
                        //}
                        //if (Convert.ToInt64(ds.Tables[0].Rows[0]["CIWGCMeritNo"].ToString()) > 0)
                        //{
                        //    trCIWGCMeritNo.Visible = true;
                        //    lblCIWGCMeritNo.Text = ds.Tables[0].Rows[0]["CIWGCMeritNo"].ToString();
                        //}
                    }
                }
                else
                {
                    cbCheckResult.Visible = true;
                    cbDisplayResult.Visible = false;

                    shInfo.SetMessage("Invalid Application ID OR Date of Birth OR You are not Eligible for Merit.", ShowMessageType.Information);
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