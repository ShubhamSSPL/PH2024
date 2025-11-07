using BusinessLayer;
using DataAccess.Implementation;
using forProjectCustomExceptions;
using Newtonsoft.Json;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.RegistrationModule
{
    public partial class frmCheckCETDetails : System.Web.UI.Page
    {
        private readonly IBusinessService _IbusinessService = new BusinessServiceImp();
        public string NEETName = Global.NEETName;
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string MHTCETName = Global.MHTCETName;
        public string CurrentYear = Global.CurrentYear;
        public int ApplicationFormFilling = Global.ApplicationFormFilling;
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

            //ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            // ContentTable2.Visible = false;
            // shInfo.SetMessage("Registration for ACAP / Non-CAP admissions will be start on 04 DEC 2021.", ShowMessageType.Information);
            if (ApplicationFormFilling != 1)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["SecretKey"] == null && ConfigurationManager.AppSettings["IsTestKeyRequired"] == "Y")
            {
                ClientScript.RegisterStartupScript(GetType(), "id", "showSecretKey()", true);
            }
            else
            {
                ContentTable2.HeaderText = MHTCETName + " Details";
                cvAppearedForCET.ErrorMessage = "Please Select Appeared Status for " + MHTCETName + ".";
                cvAppearedForNEET.ErrorMessage = "Please Select Appeared Status for " + NEETName + ".";
                cvAppearedForNEET.ErrorMessage = "Please Select Appeared Status for " + NEETName + ".";
                rfvCETApplicationFormNo.ErrorMessage = "Please Enter " + MHTCETName + " Application Number.";
                revCETApplicationFormNo.ErrorMessage = MHTCETName + " Application Number Should be Numeric and of 9 Digits.";
                rfvCETRollNo.ErrorMessage = "Please Enter " + MHTCETName + " Roll Number.";
                revCETRollNo.ErrorMessage = MHTCETName + " Roll Number Should be Numeric and of 10 Digits.";
                rfvCETDOB.ErrorMessage = "Please Enter " + MHTCETName + " DOB.";
                {
                    if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime)
                    {
                        Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                    }
                    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                    if (!IsPostBack)
                    {
                        try
                        {
                            onPageLoad();
                        }
                        catch (Exception ex)
                        {
                            //Logging.LogException(ex, "[Page Level Error]");
                            shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                        }
                    }
                }
            }
        }
        protected void AppearedForCET_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                if (rbnAppearedForCETYes.Checked)
                {
                    trAppearedForNEET.Visible = false;
                    trCETApplicationFormNo.Visible = true;
                    trCETRollNo.Visible = true;
                    trCheckCETDetails.Visible = true;
                    btnProceed.Visible = false;
                    trCETName.Visible = true;

                    trCandidateType2.Visible = false;
                    trCheckFCRDetails.Visible = false;
                    trCheckFCRDOB.Visible = false;
                    trFCRGetData.Visible = false;
                }
                else if (rbnAppearedForCETNo.Checked)
                {
                    trAppearedForNEET.Visible = true;
                    trCETApplicationFormNo.Visible = false;
                    trCETRollNo.Visible = false;
                    trCheckCETDetails.Visible = false;
                    btnProceed.Visible = true;
                    trCETName.Visible = false;

                    trCandidateType2.Visible = false;
                    trCheckFCRDetails.Visible = false;
                    trCheckFCRDOB.Visible = false;
                    trFCRGetData.Visible = false;
                }
                else
                {
                    trAppearedForNEET.Visible = false;
                    trCETApplicationFormNo.Visible = false;
                    trCETRollNo.Visible = false;
                    trCheckCETDetails.Visible = false;
                    btnProceed.Visible = false;
                    trCETName.Visible = false;

                    trCandidateType2.Visible = false;
                    trCheckFCRDetails.Visible = false;
                    trCheckFCRDOB.Visible = false;
                    trFCRGetData.Visible = false;
                }

                trCandidateType.Visible = false;
                trQualifyingExam.Visible = false;
                tblCETDetails.Visible = false;
                tblFRNoDetails.Visible = false;

                rbnAppearedForNEETYes.Checked = false;
                rbnAppearedForNEETNo.Checked = false;
                rbnCandidateTypeYes.Checked = false;
                rbnCandidateTypeNo.Checked = false;
                rbnQualifyingExamHSC.Checked = false;
                rbnQualifyingExamDiploma.Checked = false;
                rbnQualifyingExamBSc.Checked = false;
                txtCETApplicationFormNo.Text = "";
                txtCETRollNo.Text = "";
            }
            catch (Exception ex)
            {
               //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void AppearedForNEET_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                

                if (rbnAppearedForNEETYes.Checked)
                {
                    trCandidateType.Visible = false;
                }
                else if (rbnAppearedForNEETNo.Checked)
                {
                    trCandidateType.Visible = true;
                }
                else
                {
                    trCandidateType.Visible = false;
                }

                trQualifyingExam.Visible = false;

                rbnCandidateTypeYes.Checked = false;
                rbnCandidateTypeNo.Checked = false;
                rbnQualifyingExamHSC.Checked = false;
                rbnQualifyingExamDiploma.Checked = false;
                rbnQualifyingExamBSc.Checked = false;

                trCandidateType2.Visible = false;
                trCheckFCRDetails.Visible = false;
                trCheckFCRDOB.Visible = false;
                trFCRGetData.Visible = false;
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void CandidateType_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                

                if (rbnCandidateTypeYes.Checked)
                {
                    trQualifyingExam.Visible = false;
                    trCandidateType2.Visible = false;
                    trCheckFCRDetails.Visible = true;
                    trCheckFCRDOB.Visible = true;
                    trFCRGetData.Visible = true;
                    btnProceed.Visible = false;
                    string FCRURL = "https://fn.mahacet.org/StaticPages/HomePage";
                    lblNote.Text = "Note: Candidates those who want to apply under the candidature type Foreign National / NRI / PIO / OCI / CIWGC must register on the FCR Portal as per the proposed rules.To Register use the following Link -" + "<a href=\"https://fn.mahacet.org/StaticPages/HomePage\" >https://fn.mahacet.org/StaticPages/HomePage</a>";
                    lblNote.ForeColor = System.Drawing.Color.Red;
                }
                else if (rbnAppearedForNEETNo.Checked)
                {
                    if (rbnCandidateTypeNo.Checked)
                    {
                        rbnCandidateType2Yes.Checked = false;
                        rbnCandidateType2No.Checked = false;
                        trQualifyingExam.Visible = false;
                    }
                    
                    trCandidateType2.Visible = true;
                    trCheckFCRDetails.Visible = false;
                    trCheckFCRDOB.Visible = false;
                    trFCRGetData.Visible = false;
                    btnProceed.Visible = true;
                }
                else
                {
                    trQualifyingExam.Visible = false;
                }

                rbnQualifyingExamHSC.Checked = false;
                rbnQualifyingExamDiploma.Checked = false;
                rbnQualifyingExamBSc.Checked = false;
                txtFCRApplicationFormNo.Text = "";
                txtDOB.Text = "";
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void CandidateType2_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (rbnCandidateType2Yes.Checked)
                {
                    trQualifyingExam.Visible = false;
                }
                else if (rbnCandidateType2No.Checked)
                {
                    trQualifyingExam.Visible = true;
                }
                else
                {
                    trQualifyingExam.Visible = false;
                }

                rbnQualifyingExamHSC.Checked = false;
                rbnQualifyingExamDiploma.Checked = false;
                rbnQualifyingExamBSc.Checked = false;
            }
            catch (Exception ex)
            {
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void onPageLoad()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                

                if (rbnAppearedForCETYes.Checked)
                {
                    trAppearedForNEET.Visible = false;
                    trCandidateType.Visible = false;
                    trQualifyingExam.Visible = false;
                    trCETApplicationFormNo.Visible = true;
                    trCETRollNo.Visible = true;
                    trCheckCETDetails.Visible = true;
                    btnProceed.Visible = false;
                    trCETName.Visible = true;

                    trCandidateType2.Visible = false;
                    trCheckFCRDetails.Visible = false;
                    trCheckFCRDOB.Visible = false;
                    trFCRGetData.Visible = false;
                }
                else if (rbnAppearedForCETNo.Checked)
                {
                    trAppearedForNEET.Visible = true;
                    if (rbnAppearedForNEETYes.Checked)
                    {
                        trCandidateType.Visible = false;
                        trQualifyingExam.Visible = false;
                    }
                    else if (rbnAppearedForNEETNo.Checked)
                    {
                        trCandidateType.Visible = true;
                        if (rbnCandidateTypeYes.Checked)
                        {
                            trCandidateType2.Visible = false;
                            trCandidateType.Visible = true;
                            trQualifyingExam.Visible = false;
                            trCheckFCRDetails.Visible = true;
                            trCheckFCRDOB.Visible = true;
                            trFCRGetData.Visible = true;
                        }
                        else if (rbnCandidateTypeNo.Checked)
                        {
                            trQualifyingExam.Visible = true;

                            trCandidateType2.Visible = true;
                            trCandidateType.Visible = false;
                            trCheckFCRDetails.Visible = false;
                            trCheckFCRDOB.Visible = false;
                            trFCRGetData.Visible = false;
                        }
                        else
                        {
                            trCandidateType.Visible = false;
                            trQualifyingExam.Visible = false;
                        }
                    }
                    else
                    {
                        trCandidateType.Visible = false;
                        trQualifyingExam.Visible = false;
                    }
                    trCETApplicationFormNo.Visible = false;
                    trCETRollNo.Visible = false;
                    trCheckCETDetails.Visible = false;
                    btnProceed.Visible = true;
                    trCETName.Visible = false;

                    trCandidateType2.Visible = false;
                    trCheckFCRDetails.Visible = false;
                    trCheckFCRDOB.Visible = false;
                    trFCRGetData.Visible = false;
                }
                else
                {
                    trAppearedForNEET.Visible = false;
                    trCandidateType.Visible = false;
                    trQualifyingExam.Visible = false;
                    trCETApplicationFormNo.Visible = false;
                    trCETRollNo.Visible = false;
                    trCheckCETDetails.Visible = false;
                    btnProceed.Visible = false;
                    trCETName.Visible = false;

                    trCandidateType2.Visible = false;
                    trCheckFCRDetails.Visible = false;
                    trCheckFCRDOB.Visible = false;
                    trFCRGetData.Visible = false;
                }

                tblCETDetails.Visible = false;
                tblFRNoDetails.Visible = false;
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnCheckCETDetails_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                 

                Int64 CETApplicationFormNo = Convert.ToInt64(txtCETApplicationFormNo.Text);
                string CETRollNo = txtCETRollNo.Text;
                string DOB = txtCETDOB.Text;

                DataSet ds = _IbusinessService.checkCETDetails(CETApplicationFormNo, CETRollNo, DOB);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    tblCETDetails.Visible = true;
                    btnProceed.Visible = true;

                    lblCandidateName.Text = ds.Tables[0].Rows[0]["CandidateName"].ToString();
                    lblCandidateName.ForeColor = System.Drawing.Color.BlueViolet;
                    if (ds.Tables[0].Rows[0]["IsCandidateGivenCET"].ToString() == "Y")
                    {
                        trCET1.Visible = true;
                        trCET2.Visible = true;
                        trCET3.Visible = true;
                        trCET4.Visible = true;

                        trCET5.Visible = false;

                        lblCETPhysicsMarks.Text = ds.Tables[0].Rows[0]["CETPhysicsMarks"].ToString();
                        lblCETChemistryMarks.Text = ds.Tables[0].Rows[0]["CETChemistryMarks"].ToString();

                        if (ds.Tables[0].Rows[0]["CETMathMarks"].ToString() == "--")
                        {
                            lblSubjectName.Text = "Biology";
                            lblCETMathMarks.Text = ds.Tables[0].Rows[0]["CETBiologyMarks"].ToString();
                        }
                        else
                        {
                            lblSubjectName.Text = "Mathematics";
                            lblCETMathMarks.Text = ds.Tables[0].Rows[0]["CETMathMarks"].ToString();
                        }
                        if ( ds.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString()=="--")
                        {
                            lblGroupName.Text = "Total PCB";
                            lblCETPCMTotalMarks.Text = ds.Tables[0].Rows[0]["CETPCBTotalMarks"].ToString();
                        }
                        else
                        {
                            lblGroupName.Text = "Total PCM";
                            lblCETPCMTotalMarks.Text = ds.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString();
                        }

                        
                    }
                    else
                    {
                        trCET1.Visible = false;
                        trCET2.Visible = false;
                        trCET3.Visible = false;
                        trCET4.Visible = false;

                        trCET5.Visible = true;

                        lblNoCET.Text = "Absent in "+ MHTCETName + ". You are ELIGIBLE for Admission on the basis of "+ NEETName + ".";
                    }
                }
                else
                {
                    tblCETDetails.Visible = false;
                    btnProceed.Visible = false;
                    shInfo.SetMessage("Mismatched "+MHTCETName +" Details.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
               // Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string CETApplicationFormNo = "0";
                string FCRApplicationID = "";
                string FCRCandidateName = "";
                string FCRCandidatureTypeName = "";
                string FCRMotherName = "";
                string FCRGender = "";
                DateTime FCRDOB = Convert.ToDateTime(("01/01/1990").ToString());

                if (chkIAgree.Checked)
                {
                    if (rbnAppearedForCETYes.Checked)
                    {
                        CETApplicationFormNo = txtCETApplicationFormNo.Text;
                        DataSet DSchkRegistred = _IbusinessService.ISApplicationFormRegisteredUsingThisCETApplicationNo(Convert.ToInt64(CETApplicationFormNo), 0, 0);
                       // DataSet dsChkCETApplicationNo = _IbusinessService.isApplicationFormConfirmedUsingThisCETApplicationNo(Convert.ToInt64(CETApplicationFormNo));
                        if (Global.CheckDuplicateCETApplicationNo == 1 && DSchkRegistred.Tables[0].Rows[0]["Status"].ToString() == "0")
                        {
                            string ApplicationID = DSchkRegistred.Tables[0].Rows[0]["ApplicationID"].ToString();
                            shInfo.SetMessage("Application Form using CET Application Number " + CETApplicationFormNo.ToString() + " is already registered for Application ID - " + ApplicationID + " .", ShowMessageType.Information);
                            ContentTable2.Focus();
                        }
                        else //if (dsChkCETApplicationNo.Tables[0].Rows[0]["Status"].ToString() != "0")
                        {
                            //CETApplicationFormNo = txtCETApplicationFormNo.Text;
                            Response.Redirect("~/RegistrationModule/frmRegistrationDetails?CETApplicationFormNo=" + CETApplicationFormNo + "&Code=" + CETApplicationFormNo.GetHashCode() + "&FCRApplicationID=" + FCRApplicationID + "&FCRCandidateName=" + FCRCandidateName + "&FCRCandidatureTypeName=" + FCRCandidatureTypeName + "&FCRMotherName=" + FCRMotherName + "&FCRGender=" + FCRGender + "&FCRDOB=" + FCRDOB, true);
                        }
                        //else
                        //{
                        //    tblCETDetails.Visible = false;
                        //    btnProceed.Visible = false;
                        //    string sApplicationID = dsChkCETApplicationNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                        //    string sConfirmedBy = dsChkCETApplicationNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                        //    shInfo.SetMessage("Application Form using CET Application Number " + CETApplicationFormNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
                        //}
                    }
                    else
                    {
                        if (rbnAppearedForNEETYes.Checked)
                        {
                            Response.Redirect("~/RegistrationModule/frmRegistrationDetails?CETApplicationFormNo=" + CETApplicationFormNo + "&Code=" + CETApplicationFormNo.GetHashCode() + "&FCRApplicationID=" + FCRApplicationID + "&FCRCandidateName=" + FCRCandidateName + "&FCRCandidatureTypeName=" + FCRCandidatureTypeName + "&FCRMotherName=" + FCRMotherName + "&FCRGender=" + FCRGender + "&FCRDOB=" + FCRDOB, true);
                        }
                        else
                        {
                            if (rbnCandidateTypeYes.Checked)
                            {
                                FCRApplicationID = lblFCRApplicationNo.Text;
                                FCRCandidateName = lblFCRCandidateName.Text;
                                FCRCandidatureTypeName = lblFCRCandidatureTypeName.Text;
                                FCRMotherName = lblFCRMotherName.Text;
                                FCRGender = lblFCRGender.Text;
                                //string FCRDOB = lblFCRDOB.Text;
                                if (lblFCRDOB.Text.Contains("-"))
                                {
                                    lblFCRDOB.Text = lblFCRDOB.Text.Replace('-', '/');
                                }
                                FCRDOB = Convert.ToDateTime(lblFCRDOB.Text.Split("/".ToCharArray())[1] + "/" + lblFCRDOB.Text.Split("/".ToCharArray())[0] + "/" + lblFCRDOB.Text.Split("/".ToCharArray())[2]);

                                Response.Redirect("~/RegistrationModule/frmRegistrationDetails?CETApplicationFormNo=" + CETApplicationFormNo + "&Code=" + FCRApplicationID.GetHashCode() + "&FCRApplicationID=" + FCRApplicationID + "&FCRCandidateName=" + FCRCandidateName + "&FCRCandidatureTypeName=" + FCRCandidatureTypeName + "&FCRMotherName=" + FCRMotherName + "&FCRGender=" + FCRGender + "&FCRDOB=" + FCRDOB, true);
                            }
                            else if (rbnCandidateType2Yes.Checked)
                            {
                                Response.Redirect("~/RegistrationModule/frmRegistrationDetails?CETApplicationFormNo=" + CETApplicationFormNo + "&Code=" + CETApplicationFormNo.GetHashCode() + "&FCRApplicationID=" + FCRApplicationID + "&FCRCandidateName=" + FCRCandidateName + "&FCRCandidatureTypeName=" + FCRCandidatureTypeName + "&FCRMotherName=" + FCRMotherName + "&FCRGender=" + FCRGender + "&FCRDOB=" + FCRDOB, true);
                            }
                            else
                            {
                                if (rbnQualifyingExamDiploma.Checked || rbnQualifyingExamBSc.Checked)
                                {
                                    Response.Redirect("~/RegistrationModule/frmRegistrationDetails?CETApplicationFormNo=" + CETApplicationFormNo + "&Code=" + CETApplicationFormNo.GetHashCode() + "&FCRApplicationID=" + FCRApplicationID + "&FCRCandidateName=" + FCRCandidateName + "&FCRCandidatureTypeName=" + FCRCandidatureTypeName + "&FCRMotherName=" + FCRMotherName + "&FCRGender=" + FCRGender + "&FCRDOB=" + FCRDOB, true);
                                }
                                else
                                {
                                    //shInfo.SetMessage("You have not appeared for " + MHTCETName + " and " + NEETName + ", You are not Foreign National/NRI/PIO/OCI/CIWGC/NEUT/JKSSS Candidate and also Your Qualifying Exam is not Diploma in B.Pharmacy & Post Graduate Pharm.D, so you are NOT ELIGIBLE for Admission.", ShowMessageType.Information);
                                    shInfo.SetMessage("You have not appeared for " + MHTCETName + " or " + NEETName + ", or you are not a Foreign National/NRI/PIO/OCI/CIWGC/NEUT/JKSSS/PMSSS Candidate, hence you are NOT ELIGIBLE for Admission.", ShowMessageType.Information);                                    
                                }
                            }
                        }
                    }
                }
                else
                {
                    ContentTable2.Focus();
                    shInfo.SetMessage("Please accept that you have read all Important Instructions", ShowMessageType.Information);
                    shInfo.Focus();
                }

               
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSecretKey_Click(object sender, EventArgs e)
        {
            if (txtkey.Text == Application["SecretKey"].ToString())
            {
                Session["SecretKey"] = Application["SecretKey"].ToString();
                Response.Redirect("frmCheckCETDetails");
            }
            else
            {
                lblmsg.Text = "Enter the Correct SecretKey For Filling Form!!";
                lblmsg.Visible = true;
                //Response.Redirect(ConfigurationManager.AppSettings["ApplicationURL"]);
            }
        }
        protected void btnCheckFCRGetData_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string FRN_No = txtFCRApplicationFormNo.Text;
                string DOB = txtDOB.Text;
                //DateTime DOB = Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]);
                DataSet FCRds = GetFromAPI(FRN_No, DOB);

                if (FCRds.Tables[0].Rows.Count > 0)
                {
                    tblFRNoDetails.Visible = true;
                    btnProceed.Visible = true;
                    lblFCRApplicationNo.Text = FCRds.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblFCRCandidateName.Text = FCRds.Tables[0].Rows[0]["CandidateName"].ToString();
                    lblFCRCandidatureTypeName.Text = FCRds.Tables[0].Rows[0]["CandidatureTypeName"].ToString();
                    lblFCRMotherName.Text = FCRds.Tables[0].Rows[0]["MotherName"].ToString();
                    lblFCRGender.Text = FCRds.Tables[0].Rows[0]["Gender"].ToString();
                    lblFCRDOB.Text = FCRds.Tables[0].Rows[0]["DOB"].ToString();
                }
                else
                {
                    shInfo.SetMessage("Mismatched FCR Application Number/ DOB Details", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                // Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        public DataSet GetFromAPI(string FRN_No, string DOB)
        {
            //List<Table> lstchoiceCode = new List<Table>();
            DataSet myDataSet = new DataSet();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["FCRBaseURL"]);
                    client.DefaultRequestHeaders.Add("token", "FCRAPIdatashare2024_");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("api/FCR/FCRCandidateData?ApplicationID=" + FRN_No + "&DOB=" + DOB).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseString);
                        DataTable DTIMPORT = ReadRootData(myDeserializedClass);
                        myDataSet.Tables.Add(DTIMPORT);
                    }
                }
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "api/InstDataForAdmission?degreeLevel=UG&degreeName=ENGG", "");
            }
            return myDataSet;
        }

        public class Datum
        {
            public string ApplicationID { get; set; }
            public string CandidateName { get; set; }
            public string CandidatureTypeName { get; set; }
            public string MotherName { get; set; }
            public string Gender { get; set; }
            public string DOB { get; set; }
        }

        public class Root
        {
            public string Responsecode { get; set; }
            public List<Datum> Data { get; set; }
            public string Message { get; set; }
            public string NumberofRecords { get; set; }
        }
        private static DataTable ReadRootData(Root myDeserializedClass)
        {
            DataTable DTIMPORT = new DataTable();

            DTIMPORT.Columns.Add("ApplicationID");
            DTIMPORT.Columns.Add("CandidateName");
            DTIMPORT.Columns.Add("CandidatureTypeName");
            DTIMPORT.Columns.Add("MotherName");
            DTIMPORT.Columns.Add("Gender");
            DTIMPORT.Columns.Add("DOB");

            foreach (var item in myDeserializedClass.Data)
            {
                var row = DTIMPORT.NewRow();
                row["ApplicationID"] = item.ApplicationID;
                row["CandidateName"] = item.CandidateName;
                row["CandidatureTypeName"] = item.CandidatureTypeName;
                row["MotherName"] = item.MotherName;
                row["Gender"] = item.Gender;
                row["DOB"] = item.DOB;

                DTIMPORT.Rows.Add(row);
            }

            return DTIMPORT;

        }
    }
}