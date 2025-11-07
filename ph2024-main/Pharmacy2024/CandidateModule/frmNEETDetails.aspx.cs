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
    public partial class frmNEETDetails_Fetch : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string MHTCETName = Global.MHTCETName;
        public string CurrentYear = Global.CurrentYear;
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
            if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime || Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            string _leftMenu = ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"];
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormLinks = true;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormNumber = false;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFadingEffect = true; ((ExpanderMenu)Master.FindControl(_leftMenu)).FormType = 1;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).FormNumber = Convert.ToInt64(Session["UserID"]);
            try
            {
                ContentTable2.HeaderText = "NEET " + CurrentYear + " Details";
                cvAppearedForNEET.ErrorMessage = "Please Select Appeared Status for NEET " + CurrentYear + ".";
                rfvNEETRollNo.ErrorMessage = "Please Enter NEET " + CurrentYear + " Roll No.";
                revNEETRollNo.ErrorMessage = "NEET " + CurrentYear + " Roll No. should be numeric and of 10 digits.";
                cvNEETRollNo.ErrorMessage = "NEET " + CurrentYear + " Roll No. should not be zero.";

                rfvNEETPhysicsScore.ErrorMessage = "Please Enter NEET " + CurrentYear + " Physics Percentile.";
                revNEETPhysicsScore.ErrorMessage = "NEET " + CurrentYear + " Physics Percentile Should be Numeric.";
                rvNEETPhysicsScore.ErrorMessage = "NEET " + CurrentYear + " Physics Percentile Should be less than or equal to 100.";

                rfvNEETChemistryScore.ErrorMessage = "Please Enter NEET " + CurrentYear + " Chemistry Percentile.";
                revNEETChemistryScore.ErrorMessage = "NEET " + CurrentYear + " Chemistry Percentile Should be Numeric.";
                rvNEETChemistryScore.ErrorMessage = "NEET " + CurrentYear + " Chemistry Percentile Should be less than or equal to 100.";

                rfvNEETBiologyScore.ErrorMessage = "Please Enter NEET " + CurrentYear + " Biology (Botany & Zoology) Percentile.";
                revNEETBiologyScore.ErrorMessage = "NEET " + CurrentYear + " Biology (Botany & Zoology) Percentile Should be Numeric.";
                rvNEETBiologyScore.ErrorMessage = "NEET " + CurrentYear + " Biology (Botany & Zoology) Percentile Should be less than or equal to 100.";

                rfvNEETTotalScore.ErrorMessage = "Please Enter NEET " + CurrentYear + " Total Percentile.";
                revNEETTotalScore.ErrorMessage = "NEET " + CurrentYear + " Total Percentile Should be Numeric.";
                rvNEETTotalScore.ErrorMessage = "NEET " + CurrentYear + " Total Percentile Should be less than or equal to 100.";

                if (!IsPostBack)
                {

                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsCurrentLink = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmNEETDetails");

                    if (reg.CheckFCVerificationStatus(objSessionData.PID))
                    {
                        shInfo.SetMessage("Application Form is Confirmed or Has been picked for SC E-Verification", ShowMessageType.Information);
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }

                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if ((objSessionData.ApplicationFormStatus == 'A' || objSessionData.StepID < 5) && (FCVerificationStatus == 'C' || FCVerificationStatus == 'P'))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }
                    if (reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "Y")
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }

                    if (objSessionData.StepID >= 6)
                    {
                        NEETDetails obj = reg.getNEETDetails(objSessionData.PID);

                        if (obj.AppearedForNEET == "Yes")
                        {
                            rbnAppearedForNEETYes.Checked = true;

                            txtNEETRollNo.Text = obj.NEETRollNo.ToString();
                            txtNEETPhysicsScore.Text = obj.NEETPhysicsScore.ToString();
                            txtNEETChemistryScore.Text = obj.NEETChemistryScore.ToString();
                            txtNEETBiologyScore.Text = obj.NEETBiologyScore.ToString();
                            txtNEETTotalScore.Text = obj.NEETTotalScore.ToString();
                            lblCandidateNameasPerNEET.Text = obj.NameAsPerNEET;
                            tblNEETDetail.Visible = true;
                        }
                        else
                        {
                            rbnAppearedForNEETNo.Checked = true;
                        }
                    }

                    if (objSessionData.CandidatureTypeID < 11 && objSessionData.CETApplicationFormNo == 0)
                    {
                        shInfo.SetMessage("As you have not appeared for" + MHTCETName + ". So you have to fill NEET " + CurrentYear + " Details.", ShowMessageType.Information);

                        rbnAppearedForNEETYes.Checked = true;
                        rbnAppearedForNEETNo.Checked = false;
                        rbnAppearedForNEETNo.Enabled = false;
                        btnChangeCETDetails.Visible = true;
                    }

                    onPageLoad();
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
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
                    trNEETRollNo.Visible = true;
                    trNEETScore1.Visible = true;
                    trNEETScore2.Visible = true;
                    trNEETScore3.Visible = true;
                    trNEETScore4.Visible = true;
                    trNEETDOB.Visible = true;
                    trFetchNEETData.Visible = true;
                    trNEETScore0.Visible = true;
                    btnProceed.Visible = false;
                }
                else
                {
                    trNEETRollNo.Visible = false;
                    trNEETScore1.Visible = false;
                    trNEETScore2.Visible = false;
                    trNEETScore3.Visible = false;
                    trNEETScore4.Visible = false;
                    trNEETDOB.Visible = false;
                    trFetchNEETData.Visible = false;
                    trNEETScore0.Visible = false;

                    btnProceed.Visible = true;
                }

                txtNEETRollNo.Text = "";
                txtNEETPhysicsScore.Text = "";
                txtNEETChemistryScore.Text = "";
                txtNEETBiologyScore.Text = "";
                txtNEETTotalScore.Text = "";
                lblCandidateNameasPerNEET.Text = "";
                txtNEETDOB.Text = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void onPageLoad()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (rbnAppearedForNEETYes.Checked)
                {
                    trNEETRollNo.Visible = true;
                    trNEETScore1.Visible = true;
                    trNEETScore2.Visible = true;
                    trNEETScore3.Visible = true;
                    trNEETScore4.Visible = true;
                    trNEETDOB.Visible = true;
                    trFetchNEETData.Visible = true;
                    trNEETScore0.Visible = true;
                }
                else
                {
                    trNEETRollNo.Visible = false;
                    trNEETScore1.Visible = false;
                    trNEETScore2.Visible = false;
                    trNEETScore3.Visible = false;
                    trNEETScore4.Visible = false;
                    trNEETDOB.Visible = false;
                    trFetchNEETData.Visible = false;
                    trNEETScore0.Visible = false;
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
                SessionData objSessionData = (SessionData)Session["SessionData"];
                RegistrationDetails regObj = new RegistrationDetails();
                NEETDetails obj = new NEETDetails();

                regObj = reg.getRegistrationDetails(objSessionData.PID);

                StringMatching stringMatching = new StringMatching();
                int matchingPercentage = stringMatching.CheckString(regObj.CandidateName, lblCandidateNameasPerNEET.Text);

                if (matchingPercentage == 0 && rbnAppearedForNEETYes.Checked)
                {
                    obj.NameMatchingFlag = "N";
                    shInfo.SetMessage("Your name as per CAP Registration and name as per NEET Result Data is not matching. You are not allowed to continue. To change your name, go the Registration Details Step.", ShowMessageType.Information);
                }
                else if (matchingPercentage == 50 && matchingPercentage < 100 && rbnAppearedForNEETYes.Checked)
                {
                    contentDocumentConferamtion.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowConfirmationBox();", true);
                    lblDisplayDocumentSubmissionStatus.Visible = true;
                    trYesNo.Visible = true;
                    btnProceed.Visible = false;
                    obj.NameMatchingFlag = "P";
                }
                else
                {

                    obj.PID = objSessionData.PID;
                    obj.NameMatchingFlag = "Y";
                    if (rbnAppearedForNEETYes.Checked)
                    {
                        obj.AppearedForNEET = "Yes";
                        obj.NEETRollNo = Convert.ToInt64(txtNEETRollNo.Text);
                        obj.NEETPhysicsScore = Convert.ToDecimal(txtNEETPhysicsScore.Text);
                        obj.NEETChemistryScore = Convert.ToDecimal(txtNEETChemistryScore.Text);
                        obj.NEETBiologyScore = Convert.ToDecimal(txtNEETBiologyScore.Text);
                        obj.NEETTotalScore = Convert.ToDecimal(txtNEETTotalScore.Text);
                        obj.NameAsPerNEET = lblCandidateNameasPerNEET.Text.ToString();
                    }
                    else
                    {
                        obj.AppearedForNEET = "No";
                        obj.NEETRollNo = 0;
                        obj.NEETPhysicsScore = 0;
                        obj.NEETChemistryScore = 0;
                        obj.NEETBiologyScore = 0;
                        obj.NEETTotalScore = 0;
                        obj.NameAsPerNEET = "";
                    }
                    string ModifiedBy = Session["UserLoginID"].ToString();
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();

                    if(obj.AppearedForNEET == "Yes")
                    {
                        Int32 CandidatureTypeID = reg.getCandidatureTypeID(obj.PID);
                        DataSet DsJeeCheckRegisterd = reg.IsApplicationFormRegisteredUsingThisNEETRollNo(objSessionData.PID, obj.NEETRollNo.ToString(), objSessionData.StepID);
                        DataSet dsChkNEETRollNo = reg.isApplicationFormConfirmedUsingThisNEETRollNo(Convert.ToInt64(obj.NEETRollNo.ToString()), objSessionData.PID);
                        if (Global.CheckDuplicateNEETSetNo == 1 && DsJeeCheckRegisterd.Tables[0].Rows[0]["Status"].ToString() == "0" && rbnAppearedForNEETYes.Checked && CandidatureTypeID < 8)
                        {
                            string ApplicationID = DsJeeCheckRegisterd.Tables[0].Rows[0]["ApplicationID"].ToString();
                            string NEETRollNo = DsJeeCheckRegisterd.Tables[0].Rows[0]["NEETRollNo"].ToString();
                            shInfo.SetMessage("Application Form using NEET RollNo " + NEETRollNo + " is already Registered for Application ID - " + ApplicationID + " .", ShowMessageType.Information);
                            ContentTable2.Focus();
                        }
                        else if (dsChkNEETRollNo.Tables[0].Rows[0]["Status"].ToString() != "0")
                        {
                            if (Global.CheckNEETResult)
                            {
                                DataSet dsNEETResult = reg.checkNEETDetailsOnSave(obj);

                                if (dsNEETResult.Tables.Count > 0 && dsNEETResult.Tables[0].Rows.Count > 0)
                                {
                                    string neetMsg = "";
                                    if (dsNEETResult.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsNEETResult.Tables[0].Rows[0]["Status"].ToString() == "0")
                                        {
                                            neetMsg = dsNEETResult.Tables[0].Rows[0]["Msg"].ToString();
                                            shInfo.SetMessage(neetMsg, ShowMessageType.Information);
                                            //btnProceed.Visible = false;
                                        }
                                        else if (dsNEETResult.Tables[0].Rows[0]["Status"].ToString() == "1")
                                        {
                                            neetMsg = "Wrong " + NEETName + ". Please verify the Score. It should be <br/>";
                                            neetMsg = neetMsg + "Physics : " + dsNEETResult.Tables[0].Rows[0]["NEETPhysicScoreFinal"].ToString() + " | ";
                                            neetMsg = neetMsg + "Chemistry : " + dsNEETResult.Tables[0].Rows[0]["NEETChemistryScoreFinal"].ToString() + " | ";
                                            neetMsg = neetMsg + "Biology : " + dsNEETResult.Tables[0].Rows[0]["NEETBiologyScoreFinal"].ToString() + " | ";
                                            neetMsg = neetMsg + "Total : " + dsNEETResult.Tables[0].Rows[0]["NEETTotalFinal"].ToString();

                                            shInfo.SetMessage(neetMsg, ShowMessageType.Information);
                                            //btnProceed.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (reg.saveNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                                    {
                                        if (objSessionData.StepID < 6)
                                        {
                                            ((SessionData)Session["SessionData"]).StepID = 6;
                                        }

                                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                                    }
                                    else
                                    {
                                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                    }
                                }
                            }
                            else
                            {
                                if (reg.saveNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                                {
                                    if (objSessionData.StepID < 6)
                                    {
                                        ((SessionData)Session["SessionData"]).StepID = 6;
                                    }

                                    Response.Redirect("../CandidateModule/frmApplicationForm", true);
                                }
                                else
                                {
                                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                }
                            }
                        }
                        else
                        {
                            string sApplicationID = dsChkNEETRollNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                            string sConfirmedBy = dsChkNEETRollNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                            shInfo.SetMessage("Application Form using NEETRollNo " + obj.NEETRollNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        if (reg.saveNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                        {
                            if (objSessionData.StepID < 6)
                            {
                                ((SessionData)Session["SessionData"]).StepID = 6;
                            }

                            Response.Redirect("../CandidateModule/frmApplicationForm", true);
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                        }
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnFetchNEETData_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            string dobDate = txtNEETDOB.Text;
            if (dobDate.Contains("-"))
            {
                dobDate = dobDate.Replace("-", "/");
            }
            dobDate = dobDate.Split("/".ToCharArray())[0] + "/" + dobDate.Split("/".ToCharArray())[1] + "/" + dobDate.Split("/".ToCharArray())[2];

            DataSet dsNEETResult = reg.getNEETResult(txtNEETRollNo.Text.TrimEnd().TrimStart(), dobDate);
            if (dsNEETResult.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drCurrent in dsNEETResult.Tables[0].Rows)
                {
                    txtNEETPhysicsScore.Text = drCurrent["NEETPhysicScoreFinal"].ToString();
                    txtNEETChemistryScore.Text = drCurrent["NEETChemistryScoreFinal"].ToString();
                    txtNEETBiologyScore.Text = drCurrent["NEETBiologyScoreFinal"].ToString();
                    txtNEETTotalScore.Text = drCurrent["NEETTotalFinal"].ToString();

                    lblCandidateNameasPerNEET.Text = drCurrent["CName"].ToString();
                    lblCandidateNameasPerNEET.ForeColor = System.Drawing.Color.BlueViolet;
                }
                btnProceed.Enabled = true;
                tblNEETDetail.Visible = true;
                btnProceed.Visible = true;
            }
            else
            {
                shInfo.SetMessage("Enter Valid NEET Application No. and Date of Birth as on NEET Score Card.", ShowMessageType.Information);
                btnProceed.Enabled = false;
                tblNEETDetail.Visible = false;
                btnProceed.Visible = false;
            }

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                NEETDetails obj = new NEETDetails();

                obj.NameMatchingFlag = "P";

                obj.PID = objSessionData.PID;

                if (rbnAppearedForNEETYes.Checked)
                {
                    obj.AppearedForNEET = "Yes";
                    obj.NEETRollNo = Convert.ToInt64(txtNEETRollNo.Text);
                    obj.NEETPhysicsScore = Convert.ToDecimal(txtNEETPhysicsScore.Text);
                    obj.NEETChemistryScore = Convert.ToDecimal(txtNEETChemistryScore.Text);
                    obj.NEETBiologyScore = Convert.ToDecimal(txtNEETBiologyScore.Text);
                    obj.NEETTotalScore = Convert.ToDecimal(txtNEETTotalScore.Text);
                    obj.NameAsPerNEET = lblCandidateNameasPerNEET.Text.ToString();
                }
                else
                {
                    obj.AppearedForNEET = "No";
                    obj.NEETRollNo = 0;
                    obj.NEETPhysicsScore = 0;
                    obj.NEETChemistryScore = 0;
                    obj.NEETBiologyScore = 0;
                    obj.NEETTotalScore = 0;
                    obj.NameAsPerNEET = "";
                }
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                if(obj.AppearedForNEET == "Yes")
                {
                    Int32 CandidatureTypeID = reg.getCandidatureTypeID(obj.PID);
                    DataSet DsJeeCheckRegisterd = reg.IsApplicationFormRegisteredUsingThisNEETRollNo(objSessionData.PID, obj.NEETRollNo.ToString(), objSessionData.StepID);
                    DataSet dsChkNEETRollNo = reg.isApplicationFormConfirmedUsingThisNEETRollNo(Convert.ToInt64(obj.NEETRollNo.ToString()), objSessionData.PID);
                    if (Global.CheckDuplicateNEETSetNo == 1 && DsJeeCheckRegisterd.Tables[0].Rows[0]["Status"].ToString() == "0" && rbnAppearedForNEETYes.Checked && CandidatureTypeID < 8)
                    {
                        string ApplicationID = DsJeeCheckRegisterd.Tables[0].Rows[0]["ApplicationID"].ToString();
                        string NEETRollNo = DsJeeCheckRegisterd.Tables[0].Rows[0]["NEETRollNo"].ToString();
                        shInfo.SetMessage("Application Form using NEET RollNo " + NEETRollNo + " is already Registered for Application ID - " + ApplicationID + " .", ShowMessageType.Information);
                        ContentTable2.Focus();
                    }
                    else if (dsChkNEETRollNo.Tables[0].Rows[0]["Status"].ToString() != "0")
                    {
                        if (Global.CheckNEETResult)
                        {
                            DataSet dsNEETResult = reg.checkNEETDetailsOnSave(obj);

                            if (dsNEETResult.Tables.Count > 0 && dsNEETResult.Tables[0].Rows.Count > 0)
                            {
                                string neetMsg = "";
                                if (dsNEETResult.Tables[0].Rows.Count > 0)
                                {
                                    if (dsNEETResult.Tables[0].Rows[0]["Status"].ToString() == "0")
                                    {
                                        neetMsg = dsNEETResult.Tables[0].Rows[0]["Msg"].ToString();
                                        shInfo.SetMessage(neetMsg, ShowMessageType.Information);
                                        //btnProceed.Visible = false;
                                    }
                                    else if (dsNEETResult.Tables[0].Rows[0]["Status"].ToString() == "1")
                                    {
                                        neetMsg = "Wrong " + NEETName + ". Please verify the Score. It should be <br/>";
                                        neetMsg = neetMsg + "Physics : " + dsNEETResult.Tables[0].Rows[0]["NEETPhysicScoreFinal"].ToString() + " | ";
                                        neetMsg = neetMsg + "Chemistry : " + dsNEETResult.Tables[0].Rows[0]["NEETChemistryScoreFinal"].ToString() + " | ";
                                        neetMsg = neetMsg + "Biology : " + dsNEETResult.Tables[0].Rows[0]["NEETBiologyScoreFinal"].ToString() + " | ";
                                        neetMsg = neetMsg + "Total : " + dsNEETResult.Tables[0].Rows[0]["NEETTotalFinal"].ToString();

                                        shInfo.SetMessage(neetMsg, ShowMessageType.Information);
                                        //btnProceed.Visible = false;
                                    }
                                }
                            }
                            else
                            {
                                if (reg.saveNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                                {
                                    if (objSessionData.StepID < 6)
                                    {
                                        ((SessionData)Session["SessionData"]).StepID = 6;
                                    }

                                    Response.Redirect("../CandidateModule/frmApplicationForm", true);
                                }
                                else
                                {
                                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                }
                            }
                        }
                        else
                        {
                            if (reg.saveNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                            {
                                if (objSessionData.StepID < 6)
                                {
                                    ((SessionData)Session["SessionData"]).StepID = 6;
                                }

                                Response.Redirect("../CandidateModule/frmApplicationForm", true);
                            }
                            else
                            {
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        string sApplicationID = dsChkNEETRollNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                        string sConfirmedBy = dsChkNEETRollNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                        shInfo.SetMessage("Application Form using NEETRollNo  " + obj.NEETRollNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
                    }
                }
                else
                {
                    if (reg.saveNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                    {
                        if (objSessionData.StepID < 6)
                        {
                            ((SessionData)Session["SessionData"]).StepID = 6;
                        }

                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                    }
                }
               
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            btnProceed.Visible = true;
        }
        protected void btnChangeCETDetails_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Response.Redirect("../CandidateModule/CETDetails.aspx", true);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

    }
}