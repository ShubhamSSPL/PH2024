using BusinessLayer;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmCheckAllotmentStatusCAPRound3 : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                txtApplicationID.Text = Global.ApplicationFormPrefix;
                if (Global.DisplayProvisionalAllotmentListCAPRound3 == 1)
                {
                    cbCheckResult.Visible = true;
                    cbDisplayResult.Visible = false;
                }
                else
                {
                    cbCheckResult.Visible = false;
                    cbDisplayResult.Visible = false;
                    shInfo.SetMessage("Provisional Allotment List CAP Round-III is Not Published.", ShowMessageType.Information);
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                string ApplicationID = txtApplicationID.Text;
                string var = ApplicationID;
                string mystr = Regex.Replace(var, @"\d", "");
                //string mynumber = Regex.Replace(var, @"\D", "");
                DateTime DOB = Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]);

                if (ApplicationID.Length == 10 && mystr.Length <= 2)
                {
                    Int64 PID = Convert.ToInt64(ApplicationID.Substring(4));
                    DataSet ds = reg.getAllotmentStatusCAPRound3(ApplicationID, DOB);
                    string BenefitTaken = reg.getBenefitTakenByCandidate(PID, 3);
                    if (ds.Tables[0].Rows.Count > 0)
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
                        lblCategoryForAdmission.Text = ds.Tables[0].Rows[0]["AdmissionCategory"].ToString();
                        //if (ds.Tables[0].Rows[0]["AdmissionCategory"].ToString().Contains("$"))
                        //    trCVC.Visible = true;
                        //if (ds.Tables[0].Rows[0]["AdmissionCategory"].ToString().Contains("#"))
                        //    trNCL.Visible = true;
                        if (lblCategoryForAdmission.Text == "SBC")
                        {
                            lblCategoryForAdmission.Text += " - OBC";
                        }
                        lblAppliedForEWS.Text = ds.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                        lblIsOrphan.Text = ds.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                        lblPHType.Text = ds.Tables[0].Rows[0]["FinalPHType"].ToString();
                        lblDefenceType.Text = ds.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                        lblLinguisticMinority.Text = ds.Tables[0].Rows[0]["FinalLinguisticMinority"].ToString();
                        lblReligiousMinority.Text = ds.Tables[0].Rows[0]["FinalReligiousMinority"].ToString();
                        lblFinalAppliedForTFWS.Text = ds.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();

                        if (ds.Tables[0].Rows[0]["ChoiceCodeAllotted"].ToString().Trim() != "NA")
                        {
                            if (BenefitTaken == "")
                            {
                                //lblBenefitTaken.Text = "NA";
                                trBenefitTaken.Visible = false;
                            }
                            else
                            {
                                lblBenefitTaken.Text = BenefitTaken;
                            }

                            trNotAllotted.Visible = false;

                            lblInstituteAllotted.Text = ds.Tables[0].Rows[0]["InstituteAllotted"].ToString();
                            lblCourseAllotted.Text = ds.Tables[0].Rows[0]["CourseAllotted"].ToString();
                            lblChoiceCodeAllotted.Text = ds.Tables[0].Rows[0]["ChoiceCodeAllotted"].ToString();
                            lblSeatTypeAllotted.Text = ds.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                            lblPreferenceNoAllotted.Text = ds.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString();

                            if (ds.Tables[0].Rows[0]["SeatTypeAllotted"].ToString() == "AI (All India)")
                            {
                                lblMeritNo.Text = ds.Tables[0].Rows[0]["MeritNo"].ToString() + " (AI Merit No)";
                                lblMeritScore.Text = ds.Tables[0].Rows[0]["MeritMarks"].ToString() + " (" + ds.Tables[0].Rows[0]["MeritExamAI"].ToString() + ")";
                            }
                            else
                            {
                                lblMeritNo.Text = ds.Tables[0].Rows[0]["MeritNo"].ToString() + " (State General Merit No)";
                                lblMeritScore.Text = ds.Tables[0].Rows[0]["MeritMarks"].ToString() + " (" + MHTCETName + " Score)";
                            }
                            lblChoiceCodeStatusDetails.Text = "<ul class='list-text'>" + ds.Tables[0].Rows[0]["ChoiceCodeStatusDetails"].ToString() + "</ul>";
                            if (ds.Tables[0].Rows[0]["ChoiceCodeAllottedCAPRound1and2"].ToString() == "NA")
                            {
                                trFirstTime.Visible = true;
                            }
                            else
                            {
                                trBeterment.Visible = true;
                            }
                        }
                        else
                        {
                            trInstituteAllotted.Visible = false;
                            trCourseAllotted.Visible = false;
                            trChoiceCodeAllotted.Visible = false;
                            trSeatTypeAllotted.Visible = false;
                            trPreferenceNoAllotted.Visible = false;
                            trCAPRoundAllotted.Visible = false;
                            trMeritNo.Visible = false;
                            trMeritMarks.Visible = false;
                            trChoiceCodeStatusDetails.Visible = false;
                            trBenefitTaken.Visible = false;

                            if (ds.Tables[0].Rows[0]["ChoiceCodeAllottedCAPRound1and2"].ToString() == "NA")
                            {
                                if (ds.Tables[0].Rows[0]["EligibleForCAPRound3"].ToString() == "0")
                                {
                                    lblNotAllotted.Text = "Not Eligible for CAP Round-III. Hence No Seat is Allotted in CAP Round-III.";
                                }
                                else
                                {
                                    if (ds.Tables[0].Rows[0]["OptionFormCancelFlag"].ToString() == "C" || ds.Tables[0].Rows[0]["OptionFormCancelFlag"].ToString() == "Y")
                                    {
                                        lblNotAllotted.Text = "Option Form is not Confirmed for CAP Round-III. Hence No Seat is Allotted in CAP Round-III.";
                                        trEligibleButNotFilledOptionForm.Visible = true;
                                    }
                                    else
                                    {
                                        lblNotAllotted.Text = "Not Allotted in CAP Round-III.";
                                        trSubmitOptionNoAllotment.Visible = true;
                                    }
                                }
                            }
                            else
                            {
                                if (ds.Tables[0].Rows[0]["EligibleForCAPRound3"].ToString() == "0")
                                {
                                    lblNotAllotted.Text = "Not Eligible for CAP Round-III. Hence No Betterment in CAP Round-III.";
                                }
                                else
                                {
                                    if (ds.Tables[0].Rows[0]["OptionFormCancelFlag"].ToString() == "C" || ds.Tables[0].Rows[0]["OptionFormCancelFlag"].ToString() == "Y")
                                    {
                                        lblNotAllotted.Text = "Option Form is not Confirmed for CAP Round-III. Hence No Betterment in CAP Round-III.";
                                        trNoBeterment.Visible = true;
                                    }
                                    else
                                    {
                                        lblNotAllotted.Text = "No Betterment in CAP Round-III.";
                                        trNoBeterment.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        cbCheckResult.Visible = true;
                        cbDisplayResult.Visible = false;
                        shInfo.SetMessage("Invalid Application ID OR Date of Birth.", ShowMessageType.Information);
                    }
                    string AdmissionCategory = reg.GetAdmissionCategory(PID);
                    if (AdmissionCategory.Contains("$") || AdmissionCategory.Contains("#") || AdmissionCategory.Contains("@"))
                    {
                        trCVCMsg.Visible = true;
                    }
                    else
                    {
                        trCVCMsg.Visible = false;
                    }
                }
                else
                {
                    cbCheckResult.Visible = true;
                    cbDisplayResult.Visible = false;
                    shInfo.SetMessage("Invalid Application ID OR Date of Birth.", ShowMessageType.Information);
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