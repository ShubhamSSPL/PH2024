using BusinessLayer;
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
    public partial class frmAskApplicationID : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    txtApplicationID.Text = Global.ApplicationFormPrefix;
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                    string userlogin = (Session["UserLoginId"].ToString());
                    string Flag = Request.QueryString["Flag"].ToString();

                    string a = userlogin;
                    string b = string.Empty;
                    int val = 0;

                    for (int i = 0; i < a.Length; i++)
                    {
                        if (Char.IsDigit(a[i]))
                            b += a[i];
                    }

                    if (b.Length > 0)
                        val = int.Parse(b);

                    if ((val < 8080 || val> 9999 ) ||Flag == "PrintApplicationForm" || Flag == "PrintAcknowledgement")
                    {
                        ContentTable2.Visible = true;
                        switch (Request.QueryString["Flag"])
                        {
                            case "ConfirmApplicationForm":
                                if ((DateTime.Now < Global.DocumentVerificationStartDateTime || DateTime.Now > Global.DocumentVerificationEndDateTime) && UserTypeID != 21)
                                {
                                    ContentTable2.Visible = false;
                                    shInfo.SetMessage("Confirmation of Application Form is Closed.", ShowMessageType.Information);
                                }
                                else
                                {
                                    ContentTable2.HeaderText = "Confirm Application Form";
                                    trVersionNo.Visible = true;
                                }
                                break;
                            case "CanceApplicationForm":
                                if ((DateTime.Now < Global.DocumentVerificationStartDateTime || DateTime.Now > Global.DocumentVerificationEndDateTime) && UserTypeID != 21)
                                {
                                    ContentTable2.Visible = false;
                                    shInfo.SetMessage("Cancellation of Application Form is Closed.", ShowMessageType.Information);
                                }
                                else
                                {
                                    ContentTable2.HeaderText = "Cancel Application Form";
                                }
                                break;
                            case "EditConfirmedDocuments":
                                if ((DateTime.Now < Global.EdittingOfApplicationFormStartDateTime || DateTime.Now > Global.EdittingOfApplicationFormEndDateTime) && UserTypeID != 21)
                                {
                                    ContentTable2.Visible = false;
                                    shInfo.SetMessage("Editting of Confirmed Documents is Closed.", ShowMessageType.Information);
                                }
                                else
                                {
                                    ContentTable2.HeaderText = "Edit Confirmed Documents";
                                }
                                break;
                            case "EditApplicationForm":
                                if ((DateTime.Now < Global.EdittingOfApplicationFormStartDateTime || DateTime.Now > Global.EdittingOfApplicationFormEndDateTime) && UserTypeID != 21)
                                {
                                    ContentTable2.Visible = false;
                                    shInfo.SetMessage("Editting of Application Form is Closed.", ShowMessageType.Information);
                                }
                                else
                                {
                                    ContentTable2.HeaderText = "Edit Application Form";
                                }
                                break;
                            case "UploadRequiredDocuments":
                                if ((DateTime.Now < Global.EdittingOfApplicationFormStartDateTime || DateTime.Now > Global.EdittingOfApplicationFormEndDateTime) && UserTypeID != 21)
                                {
                                    ContentTable2.Visible = false;
                                    shInfo.SetMessage("Uploading of Required Documents is Closed.", ShowMessageType.Information);
                                }
                                else
                                {
                                    ContentTable2.HeaderText = "Upload Required Documents";
                                }
                                break;
                            case "CheckApplicationStatus":
                                ContentTable2.HeaderText = "Check Application Status";
                                break;
                            case "CheckPaymentHistory":
                                ContentTable2.HeaderText = "Check Payment History";
                                break;
                            case "PayApplicationFee":
                                ContentTable2.HeaderText = "Pay Application Fee";
                                break;
                            case "SendSMS":
                                ContentTable2.HeaderText = "Send SMS to Candidate";
                                break;
                            case "PrintApplicationForm":
                                ContentTable2.HeaderText = "Print Application Form";
                                break;
                            case "PrintAcknowledgement":
                                ContentTable2.HeaderText = "Print Acknowledgement";
                                break;
                            case "ResetCandidatePassword":
                                ContentTable2.HeaderText = "Reset Candidate's Password";
                                break;
                            case "GetCandidateSecurityQuestion":
                                ContentTable2.HeaderText = "Get Candidate's Security Question Details";
                                break;
                            case "CancelOptionFormCAPRound1":
                                ContentTable2.HeaderText = "Cancel Option Form CAP Round-I";
                                trDOB.Visible = true;
                                break;
                            case "ChangeEligibilityCAPRound1":
                                ContentTable2.HeaderText = "Change Candidate's Eligibility CAP Round-I";
                                break;
                            case "PrintOptionFormCAPRound1":
                                ContentTable2.HeaderText = "Print Option Form CAP Round-I";
                                break;
                            case "PrintConfirmedChoiceCodeListCAPRound1":
                                ContentTable2.HeaderText = "Print Confirmed Choice Code List CAP Round-I";
                                break;
                            case "CancelOptionFormCAPRound2":
                                ContentTable2.HeaderText = "Cancel Option Form CAP Round-II";
                                trDOB.Visible = true;
                                break;
                            case "ChangeEligibilityCAPRound2":
                                ContentTable2.HeaderText = "Change Candidate's Eligibility CAP Round-II";
                                break;
                            case "PrintOptionFormCAPRound2":
                                ContentTable2.HeaderText = "Print Option Form CAP Round-II";
                                break;
                            case "PrintConfirmedChoiceCodeListCAPRound2":
                                ContentTable2.HeaderText = "Print Confirmed Choice Code List CAP Round-II";
                                break;
                            case "CancelOptionFormCAPRound3":
                                ContentTable2.HeaderText = "Cancel Option Form CAP Round-III";
                                trDOB.Visible = true;
                                break;
                            case "ChangeEligibilityCAPRound3":
                                ContentTable2.HeaderText = "Change Candidate's Eligibility CAP Round-III";
                                break;
                            case "PrintOptionFormCAPRound3":
                                ContentTable2.HeaderText = "Print Option Form CAP Round-III";
                                break;
                            case "PrintConfirmedChoiceCodeListCAPRound3":
                                ContentTable2.HeaderText = "Print Confirmed Choice Code List CAP Round-III";
                                break;
                            case "CancelOptionFormCAPRound4":
                                ContentTable2.HeaderText = "Cancel Option Form CAP Round-IV";
                                trDOB.Visible = true;
                                break;
                            case "ChangeEligibilityCAPRound4":
                                ContentTable2.HeaderText = "Change Candidate's Eligibility CAP Round-IV";
                                break;
                            case "PrintOptionFormCAPRound4":
                                ContentTable2.HeaderText = "Print Option Form CAP Round-IV";
                                break;
                            case "PrintConfirmedChoiceCodeListCAPRound4":
                                ContentTable2.HeaderText = "Print Confirmed Choice Code List CAP Round-IV";
                                break;
                            case "ChangeMobileNumber":
                                ContentTable2.HeaderText = "Change Candidate's Mobile Number";
                                break;
                            case "ChangeCandidateName":
                                ContentTable2.HeaderText = "Change Candidate's Name";
                                break;
                            case "CheckCasteValidityCertificate":
                                ContentTable2.HeaderText = "Check Caste Validity Certificate";
                                break;
                            case "UploadCVCNCLCertificate":
                                if (DateTime.Now.Date > Convert.ToDateTime("08/31/2024") && UserTypeID != 21)
                                {
                                    ContentTable2.Visible = false;
                                    shInfo.Visible = true;

                                    shInfo.SetMessage("Upload CVC NCL Certificate Link is Closed.", ShowMessageType.Information);
                                }
                                else
                                {
                                    trcvctvcNote.Visible = true;
                                    ContentTable2.HeaderText = "Upload CVC Certificate";
                                }
                                break;
                            case "CandidateApplicationFormStatus":
                                ContentTable2.HeaderText = "Candidate Application Form Status";
                                break;
                            case "PrintAcknowledgementByVersionNo":
                                ContentTable2.HeaderText = "Print Acknowledgement By VersionNo";
                                break;
                            case "EditNEETDetails":
                                ContentTable2.HeaderText = "Edit NEET Details";
                                break;
                            case "UploadDocumentafterReporting":
                                ContentTable2.HeaderText = "Upload Document after Reporting ";
                                break;

                            // Commited by sharad ARC closed than uplode cvc and tvc and ews closed
                            case "VerificationforCVCTVCNCLEWSDocument":
                                ContentTable2.HeaderText = "Upload CVC/TVC/NCL/EWS Certificate ";
                                break;
                        }
                    }
                    else
                    {
                        ContentTable2.Visible = false;
                        shInfo.SetMessage("You are not allowed to select Physical Scrutiny verification..", ShowMessageType.Information);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                reg.updateUserAction(Session["UserLoginID"].ToString(), txtApplicationID.Text, ContentTable2.HeaderText, "AFCModule", UserInfo.GetIPAddress());

                switch (Request.QueryString["Flag"])
                {
                    case "ConfirmApplicationForm":
                        if (CheckIsAllowedForEFC("N"))
                            ConfirmApplicationForm();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "CanceApplicationForm":
                        if (CheckIsAllowedForEFC("N"))
                            CanceApplicationForm();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "EditConfirmedDocuments":
                        if (CheckIsAllowedForEFC("N"))
                            EditConfirmedDocuments();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "EditApplicationForm":
                        if (CheckIsAllowedForEFC("N"))
                            EditApplicationForm();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "UploadRequiredDocuments":
                        //if (CheckIsAllowedForEFC("N"))
                            UploadRequiredDocuments();
                        //else
                            //shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "CheckApplicationStatus":
                        if (CheckIsAllowedForEFC("Y"))
                            CheckApplicationStatus();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "CheckPaymentHistory":
                        if (CheckIsAllowedForEFC("Y"))
                            CheckPaymentHistory();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "PayApplicationFee":
                        //if (CheckIsAllowedForEFC("N"))
                            PayApplicationFee();
                       // else
                           // shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "SendSMS":
                        if (CheckIsAllowedForEFC("Y"))
                            SendSMS();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "PrintApplicationForm":
                        if (CheckIsAllowedForEFC("Y"))
                            PrintApplicationForm();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "PrintAcknowledgement":
                        if (CheckIsAllowedForEFC("Y"))
                            PrintAcknowledgement();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "ResetCandidatePassword":
                        if (CheckIsAllowedForEFC("N"))
                            ResetCandidatePassword();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "GetCandidateSecurityQuestion":
                        if (CheckIsAllowedForEFC("N"))
                            GetCandidateSecurityQuestion();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "CancelOptionFormCAPRound1":
                        CancelOptionFormCAPRound1();
                        break;
                    case "ChangeEligibilityCAPRound1":
                        ChangeEligibilityCAPRound1();
                        break;
                    case "PrintOptionFormCAPRound1":
                        PrintOptionFormCAPRound1();
                        break;
                    case "PrintConfirmedChoiceCodeListCAPRound1":
                        PrintConfirmedChoiceCodeListCAPRound1();
                        break;
                    case "CancelOptionFormCAPRound2":
                        CancelOptionFormCAPRound2();
                        break;
                    case "ChangeEligibilityCAPRound2":
                        ChangeEligibilityCAPRound2();
                        break;
                    case "PrintOptionFormCAPRound2":
                        PrintOptionFormCAPRound2();
                        break;
                    case "PrintConfirmedChoiceCodeListCAPRound2":
                        PrintConfirmedChoiceCodeListCAPRound2();
                        break;
                    case "CancelOptionFormCAPRound3":
                        CancelOptionFormCAPRound3();
                        break;
                    case "ChangeEligibilityCAPRound3":
                        ChangeEligibilityCAPRound3();
                        break;
                    case "PrintOptionFormCAPRound3":
                        PrintOptionFormCAPRound3();
                        break;
                    case "PrintConfirmedChoiceCodeListCAPRound3":
                        PrintConfirmedChoiceCodeListCAPRound3();
                        break;
                    case "CancelOptionFormCAPRound4":
                        CancelOptionFormCAPRound4();
                        break;
                    case "ChangeEligibilityCAPRound4":
                        ChangeEligibilityCAPRound4();
                        break;
                    case "PrintOptionFormCAPRound4":
                        PrintOptionFormCAPRound4();
                        break;
                    case "PrintConfirmedChoiceCodeListCAPRound4":
                        PrintConfirmedChoiceCodeListCAPRound4();
                        break;
                    case "ChangeMobileNumber":
                        ChangeMobileNumber();
                        break;
                    case "ChangeCandidateName":
                        ChangeCandidateName();
                        break;
                    case "CheckCasteValidityCertificate":
                        CheckCasteValidityCertificate();
                        break;
                    case "UploadCVCNCLCertificate":
                        UploadCVCNCLCertificate();
                        break;
                    case "CandidateApplicationFormStatus":
                        CandidateApplicationFormStatus();
                        break;
                    case "PrintAcknowledgementByVersionNo":
                        if (CheckIsAllowedForEFC("Y"))
                            PrintAcknowledgementByVersionNo();
                        else
                            shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "EditNEETDetails":
                        //if (CheckIsAllowedForEFC("Y"))
                        EditNEETDetails();
                        //else
                        //    shInfo.SetMessage(CheckCandidateEverificationStatus(), ShowMessageType.Information);
                        break;
                    case "UploadDocumentafterReporting":

                        UploadDocumentafterReporting();

                        break;
                        //Commited by sharad ARC closed than uplode cvc and tvc and ews  closed
                    case "VerificationforCVCTVCNCLEWSDocument":
                        VerificationforCVCTVCNCLEWSDocument();
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ConfirmApplicationForm()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string ApplicationID = txtApplicationID.Text;
                //This Function add only Candidate any one Opration using table existing  recored. add by sharad
                if (reg.OnlyThisCandidateOperation(ApplicationID))
                {
                    if (reg.isCandidateNameAppearedInProvisionalMeritList(ApplicationID))
                    {
                        Int64 PID = reg.checkApplicationStatus(txtApplicationID.Text, Convert.ToInt32(txtVersionNo.Text));
                        if (PID == 0)
                        {
                            shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                        }
                        else if (PID == 1 || PID == 3)
                        {
                            DataSet ds = reg.getApplicationFormConfirmationDetails(reg.getPersonalID(txtApplicationID.Text));
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DateTime ConfirmedDateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ConfirmedDateTime"]);
                                string ConfirmedOn = ConfirmedDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ConfirmedDateTime);
                                string ConfirmedBy = ds.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                                shInfo.SetMessage("Application Form is Already Confirmed By " + ConfirmedBy + " on " + ConfirmedOn + ".", ShowMessageType.Information);
                            }
                            else
                            {
                                shInfo.SetMessage("Application Form is already Confirmed.", ShowMessageType.Information);
                            }
                        }
                        else if (PID == 2)
                        {
                            shInfo.SetMessage("Application Form is incomplete, You can not Confirm it.", ShowMessageType.Information);
                        }
                        else if (PID == 4)
                        {
                            shInfo.SetMessage("Version No is not Correct. Please take fresh PrintOut of Application Form and Confirm again using new Version No.", ShowMessageType.Information);
                        }
                        else
                        {
                            Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                            if (CandidatureTypeID >= 8)
                            {
                                if (reg.getParentID(Convert.ToInt64(Session["UserID"])) == 3016)
                                {
                                    Response.Redirect("../AFCModule/frmRequiredDocuments.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                                }
                                else
                                {
                                    shInfo.SetMessage("Sorry, Only FC3016 [Bombay College of Pharmacy, Santacruz(E), Mumbai] can Confirm this Candidate.", ShowMessageType.Information);
                                }
                            }
                            else
                            {
                                Response.Redirect("../AFCModule/frmRequiredDocuments.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Candidate name is not in Provisional Merit List so you Can Not Confirm Application Form.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void CanceApplicationForm()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isApplicationFormConfirmed(PID))
                    {
                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                        string UserLoginID = Session["UserLoginID"].ToString();

                        if (reg.checkApplicationFormConfirmationDetails(PID, UserTypeID, UserLoginID))
                        {
                            if (!reg.isCandidateNameAppearedInFinalMeritList(PID) || UserTypeID == 21)
                            {
                                Response.Redirect("../AFCModule/frmCancelApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode() + "&ApplicationID=" + txtApplicationID.Text, true);
                            }
                            else
                            {
                                shInfo.SetMessage("Cancellation is Closed for Candidates Whose Name Appeared in Final Merit List.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            if (UserTypeID == 22)
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by AFC under your Region, Hence you can not Cancel it.", ShowMessageType.Information);
                            }
                            else
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by You, Hence you can not Cancel it.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Application Form is not Confirmed yet. You can Cancel Application Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void EditConfirmedDocuments()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isApplicationFormConfirmed(PID))
                    {
                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                        string UserLoginID = Session["UserLoginID"].ToString();

                        if (reg.checkApplicationFormConfirmationDetails(PID, UserTypeID, UserLoginID))
                        {
                            if (!reg.isCandidateNameAppearedInFinalMeritList(PID) || UserTypeID == 21)
                            {
                                Response.Redirect("../AFCModule/frmEditRequiredDocuments.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode() + "&ApplicationID=" + txtApplicationID.Text, true);
                            }
                            else
                            {
                                shInfo.SetMessage("Editting is Closed for Candidates Whose Name Appeared in Final Merit List.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            if (UserTypeID == 22)
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by AFC under your Region, Hence you can not Edit it.", ShowMessageType.Information);
                            }
                            else
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by You, Hence you can not Edit it.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Application Form is not Confirmed yet. You can Edit Documents after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void EditApplicationForm()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isApplicationFormConfirmed(PID))
                    {
                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                        string UserLoginID = Session["UserLoginID"].ToString();

                        if (reg.checkApplicationFormConfirmationDetails(PID, UserTypeID, UserLoginID))
                        {
                            //if (reg.isCandidateNameAppearedInFinalMeritList(PID))
                            //{
                            //    if (UserTypeID == 21)
                            //    {
                            //        Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                            //    }
                            //    else if (UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34)
                            //    {
                            //        string Flag = reg.isCandidateEligibleForEdittingAtARC(PID);

                            //        if (Flag.Length > 0)
                            //        {
                            //            shInfo.SetMessage(Flag, ShowMessageType.Information);
                            //        }
                            //        else
                            //        {
                            //            Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        shInfo.SetMessage("Editting is Closed for Candidates Whose Name Appeared in Final Merit List.", ShowMessageType.Information);
                            //    }
                            //}
                            //else
                            //{
                            //    Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                            //}

                            shInfo.SetMessage("As this Application Form is Confirmed, Hence you can not Edit it. In order to Edit, first Cancel the Aapplication Form and then Edit. ", ShowMessageType.Information);
                        }
                        else
                        {
                            if (UserTypeID == 22)
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by AFC under your Region, Hence you can not Edit it.", ShowMessageType.Information);
                            }
                            else
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by You, Hence you can not Edit it.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        if (reg.isCandidateNameAppearedInFinalMeritList(PID))
                        {
                            shInfo.SetMessage("Editting is Closed for Candidates Whose Name Appeared in Final Merit List.", ShowMessageType.Information);
                        }
                        else
                        {
                            char ApplicationFormStatus = reg.getApplicationFormStatusApplicationRound(PID);
                            if (ApplicationFormStatus == 'C')
                            {
                                Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                            }
                            else
                            {
                                shInfo.SetMessage("Application Form is Incomplete. Hence you can not Edit it.", ShowMessageType.Information);
                            }
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
        protected void UploadRequiredDocuments()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isApplicationFormConfirmed(PID))
                    {
                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                        string UserLoginID = Session["UserLoginID"].ToString();

                        if (reg.checkApplicationFormConfirmationDetails(PID, UserTypeID, UserLoginID))
                        {
                            if (!reg.isCandidateNameAppearedInFinalMeritList(PID) || UserTypeID == 21 || UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34)
                            {
                                Response.Redirect("../AFCModule/frmUploadRequiredDocumentsStep.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode() + "&ApplicationID=" + txtApplicationID.Text, true);
                            }
                            else
                            {
                                shInfo.SetMessage("Uploading of Documents is Closed for Candidates Whose Name Appeared in Final Merit List.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            if (UserTypeID == 22)
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by AFC under your Region, Hence you can not Upload Required Documents.", ShowMessageType.Information);
                            }
                            else
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by You, Hence you can not Upload Required Documents.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        char ApplicationFormStatus = reg.getApplicationFormStatusApplicationRound(PID);
                        if (ApplicationFormStatus == 'C')
                        {
                            Response.Redirect("../AFCModule/frmUploadRequiredDocumentsStep.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode() + "&ApplicationID=" + txtApplicationID.Text, true);
                        }
                        else
                        {
                            shInfo.SetMessage("Application Form is Incomplete. Hence you can not Upload Required Documents.", ShowMessageType.Information);
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
        protected void CheckApplicationStatus()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../AFCModule/frmCheckApplicationStatus.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void CheckPaymentHistory()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../FeeProcess/PaymentHistory.aspx?PID=" + PID + "&Code1=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PayApplicationFee()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
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
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void SendSMS()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isApplicationFormConfirmed(PID))
                    {
                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                        string UserLoginID = Session["UserLoginID"].ToString();

                        if (reg.checkApplicationFormConfirmationDetails(PID, UserTypeID, UserLoginID))
                        {
                            Response.Redirect("../AFCModule/frmSendSMSToCandidates.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode() + "&ApplicationID=" + txtApplicationID.Text, true);
                        }
                        else
                        {
                            if (UserTypeID == 22)
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by AFC under your Region, Hence you can not Send SMS.", ShowMessageType.Information);
                            }
                            else
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by You, Hence you can not Send SMS.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Application Form is not Confirmed. Hence you can not send SMS.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintApplicationForm()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    char ApplicationFormStatus = reg.getApplicationFormStatusApplicationRound(PID);

                    if (ApplicationFormStatus == 'C' || ApplicationFormStatus == 'A')
                    {
                        Response.Redirect("../AFCModule/frmApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Application Form is Not Completed by Candidate. So you can not Print Application Form.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintAcknowledgement()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isApplicationFormConfirmed(PID))
                    {
                        Response.Redirect("../AFCModule/frmAcknowledgement.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Application Form is not Confirmed. You can Print Acknowledgement after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ResetCandidatePassword()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../AFCModule/frmResetCandidatePassword.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void GetCandidateSecurityQuestion()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    DataSet ds = reg.getSecurityQuestionDetails(PID);

                    shInfo.SetMessage("<b>Security Question : </b>" + ds.Tables[0].Rows[0]["SecurityQuestionDetails"].ToString() + "<br /><b>Answer : </b>" + ds.Tables[0].Rows[0]["SecurityAnswer"].ToString(), ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void CancelOptionFormCAPRound1()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.authenticateApplicationIDnDOB(txtApplicationID.Text, Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]));
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID or DOB.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound1(PID))
                    {
                        if (!reg.isOptionFormCancelledBeforeCAPRound1(PID))
                        {
                            Response.Redirect("../AFCModule/frmCancelOptionFormCAPRound1.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                        else
                        {
                            shInfo.SetMessage("Option Form is Already Cancelled Once. You can Cancel Option Form Only Once.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Cancel Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ChangeEligibilityCAPRound1()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../AFCModule/frmChangeEligibilityCAPRound1.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintOptionFormCAPRound1()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound1(PID))
                    {
                        Response.Redirect("../AFCModule/frmOptionFormCAPRound1.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Print Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintConfirmedChoiceCodeListCAPRound1()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound1(PID))
                    {
                        Response.Redirect("../AFCModule/frmConfirmedChoiceCodeListCAPRound1.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Print Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void CancelOptionFormCAPRound2()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.authenticateApplicationIDnDOB(txtApplicationID.Text, Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]));
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID or DOB.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound2(PID))
                    {
                        if (!reg.isOptionFormCancelledBeforeCAPRound2(PID))
                        {
                            Response.Redirect("../AFCModule/frmCancelOptionFormCAPRound2.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                        else
                        {
                            shInfo.SetMessage("Option Form is Already Cancelled Once. You can Cancel Option Form Only Once.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Cancel Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ChangeEligibilityCAPRound2()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../AFCModule/frmChangeEligibilityCAPRound2.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintOptionFormCAPRound2()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound2(PID))
                    {
                        Response.Redirect("../AFCModule/frmOptionFormCAPRound2.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Print Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintConfirmedChoiceCodeListCAPRound2()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound2(PID))
                    {
                        Response.Redirect("../AFCModule/frmConfirmedChoiceCodeListCAPRound2.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Print Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void CancelOptionFormCAPRound3()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.authenticateApplicationIDnDOB(txtApplicationID.Text, Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]));
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID or DOB.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound3(PID))
                    {
                        if (!reg.isOptionFormCancelledBeforeCAPRound3(PID))
                        {
                            Response.Redirect("../AFCModule/frmCancelOptionFormCAPRound3.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                        else
                        {
                            shInfo.SetMessage("Option Form is Already Cancelled Once. You can Cancel Option Form Only Once.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Cancel Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ChangeEligibilityCAPRound3()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../AFCModule/frmChangeEligibilityCAPRound3.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintOptionFormCAPRound3()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound3(PID))
                    {
                        Response.Redirect("../AFCModule/frmOptionFormCAPRound3.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Print Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintConfirmedChoiceCodeListCAPRound3()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound3(PID))
                    {
                        Response.Redirect("../AFCModule/frmConfirmedChoiceCodeListCAPRound3.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Print Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void CancelOptionFormCAPRound4()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.authenticateApplicationIDnDOB(txtApplicationID.Text, Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]));
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID or DOB.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound4(PID))
                    {
                        if (!reg.isOptionFormCancelledBeforeCAPRound4(PID))
                        {
                            Response.Redirect("../AFCModule/frmCancelOptionFormCAPRound4.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                        else
                        {
                            shInfo.SetMessage("Option Form is Already Cancelled Once. You can Cancel Option Form Only Once.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Cancel Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ChangeEligibilityCAPRound4()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../AFCModule/frmChangeEligibilityCAPRound4.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintOptionFormCAPRound4()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound4(PID))
                    {
                        Response.Redirect("../AFCModule/frmOptionFormCAPRound4.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Print Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintConfirmedChoiceCodeListCAPRound4()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isOptionFormConfirmedCAPRound4(PID))
                    {
                        Response.Redirect("../AFCModule/frmConfirmedChoiceCodeListCAPRound4.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Option Form is not Confirmed yet. You can Print Option Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ChangeMobileNumber()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../AFCModule/frmChangeMobileNo.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void ChangeCandidateName()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../AFCModule/frmChangeName.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void CheckCasteValidityCertificate()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../AFCModule/frmCheckCasteValidityCertificate.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void UploadCVCNCLCertificate()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                string UserLoginID = Session["UserLoginID"].ToString();

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        if (reg.CheckCandidateCVCStatus(PID))
                        {
                            if (UserTypeID == 21)// || UserTypeID == 22 || UserTypeID == 33 || UserTypeID == 34)
                            {
                                Response.Redirect("../AFCModule/frmUploadCVCNCLCertificate.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                            }
                            else
                            {
                                shInfo.SetMessage("You are not Authorised to upload CVC / TVC.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("Candidate is  not Eligible to upload CVC / TVC or CVC / TVC already uploaded Please check the Documents.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Candidate name is not in Final Merit List so you can't upload CVC /TVC Certificate.", ShowMessageType.Information);
                    }
                    //string strAdmissionDetails = reg.getAdmissionDetails(PID);

                    //if (UserTypeID == 21 || UserTypeID == 22 || UserTypeID == 33 || UserTypeID == 34)
                    //{
                    //    Response.Redirect("../AFCModule/frmUploadCVCNCLCertificate.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    //}
                    //else if (UserTypeID == 33 || UserTypeID == 34)
                    //{
                    //    if (strAdmissionDetails.Length > 0)
                    //    {
                    //        shInfo.SetMessage("Admission of this Candidate is Already Confirmed by Institute. Now Only the Institute where Candidate is Admitted can Upload the CVC / NCL.", ShowMessageType.Information);
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("../AFCModule/frmUploadCVCNCLCertificate.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    //    }
                    //}
                    //else if (UserTypeID == 43)
                    //{
                    //    if (strAdmissionDetails.Length == 0)
                    //    {
                    //        shInfo.SetMessage("Admission of this Candidate is Not Confirmed. Institute can Only Upload the CVC / NCL after Admission Confirmation Only.", ShowMessageType.Information);
                    //    }
                    //    else
                    //    {
                    //        DataSet dsCAD = reg.getCurrentAdmissionDetails(PID);

                    //        if (dsCAD.Tables[0].Rows[0]["InstituteCode"].ToString() == UserLoginID)
                    //        {
                    //            Response.Redirect("../AFCModule/frmUploadCVCNCLCertificate.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    //        }
                    //        else
                    //        {
                    //            shInfo.SetMessage("This Candidate is Not Admitted in this Institute. You can not Upload the CVC / NCL.", ShowMessageType.Information);
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void CandidateApplicationFormStatus()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Response.Redirect("../AdminModule/CandidateApplicationFormStaus.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }

        }
        protected bool CheckIsAllowedForEFC(string AllowEFC)
        {
            string candidateScrutinyType = reg.CheckCandidateFCVerificationFor(reg.getPersonalID(txtApplicationID.Text));
            if (AllowEFC == "Y")
            {
                if ((candidateScrutinyType == "P" || candidateScrutinyType == "" || candidateScrutinyType == " ") || (Convert.ToInt32(Session["UserTypeID"].ToString()) == 21 || reg.CheckISEFC(Session["UserLoginID"].ToString()) == "Y" || (Convert.ToInt32(Session["UserTypeID"].ToString()) == 66)))
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                if ((candidateScrutinyType == "P" || candidateScrutinyType == "" || candidateScrutinyType == " ") || (Convert.ToInt32(Session["UserTypeID"].ToString()) == 21))
                {
                    return true;
                }
                else
                    return false;
            }
        }
        protected string CheckCandidateEverificationStatus()
        {
            string message = string.Empty;
            DataSet statusDs = reg.getVerificationFlags(reg.getPersonalID(txtApplicationID.Text));
            char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
            char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
            char IsLockedByCandidate = Convert.ToChar(statusDs.Tables[0].Rows[0]["IsLockedByCandidate"].ToString());
            if (FCVerificationStatus == 'P')
                message = "Candidate has Apply for E-Scrutiny, Candidate Application Form is Picked by SC for E-Scrutiny. ";
            else if (IsLockedByCandidate == 'Y')
                message = "Candidate has Apply for E-Scrutiny, Candidate Application Form is not Available for In person Verification. Unlock the Form and Select Physical Scrutiny mode.";
            else
                message = "Candidate has Apply for E-Scrutiny, Candidate Application Form is not Available for Physical Scrutiny.";
            return message;
        }
        protected void PrintAcknowledgementByVersionNo()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isApplicationFormConfirmed(PID))
                    {
                        //Response.Redirect("../AFCModule/frmAcknowledgementByVersionNo.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        Response.Redirect("../CandidateModule/frmAcknowledgementByVersionNo.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Application Form is not Confirmed. You can Print Acknowledgement By VersionNo after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void EditNEETDetails()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {

                    if (reg.isApplicationFormConfirmed(PID))
                    {
                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                        string UserLoginID = Session["UserLoginID"].ToString();

                        if (reg.checkApplicationFormConfirmationDetails(PID, UserTypeID, UserLoginID))
                        {
                            Response.Redirect("../AFCModule/frmEditNEETDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode() + "&From=Correction", true);
                        }
                        else
                        {
                            if (UserTypeID == 22)
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by AFC under your Region, Hence you can not Edit it.", ShowMessageType.Information);
                            }
                            else
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by You, Hence you can not Edit it.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Application Form is not Confirmed yet. You can Edit NEET Details after Confirmation Only.", ShowMessageType.Information);
                    }




                   
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void UploadDocumentafterReporting()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isApplicationFormConfirmed(PID))
                    {
                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                        string UserLoginID = Session["UserLoginID"].ToString();

                        if (reg.checkApplicationFormConfirmationDetails(PID, UserTypeID, UserLoginID))
                        {
                            if (UserTypeID == 21)
                            {
                                
                                Response.Redirect("../AFCModule/frmUploadDocumentafterReporting.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode() + "&ApplicationID=" + txtApplicationID.Text, true);
                            }
                            else
                            {
                                shInfo.SetMessage("Uploading of Documents is Closed for Candidates Whose Name Appeared in Final Merit List.", ShowMessageType.Information);
                            }
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
        protected void VerificationforCVCTVCNCLEWSDocument()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                //Commited by sharad ARC closed than uplode cvc and tvc and ews  closed

                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                string UserLoginID = Session["UserLoginID"].ToString();

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.checkApplicationFormModifiedDetailsForCVCTVCEWS(PID, UserTypeID, UserLoginID))
                    {
                        if (reg.isCandidateNameAppearedInFinalMeritList(PID))
                        {
                            if (reg.CheckCandidateCVCTVCEWSStatus(PID))
                            {
                                if (UserTypeID != 91)//|| UserTypeID == 22 || UserTypeID == 33 || UserTypeID == 34)
                                //if (UserTypeID == 21)
                                {
                                    Response.Redirect("../AFCModule/frmVerificationforCVCTVCNCLEWSDocument.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                                }
                                else
                                {
                                    shInfo.SetMessage("You are not Authorised to upload CVC / TVC.", ShowMessageType.Information);
                                }
                            }
                            else
                            {
                                shInfo.SetMessage("Candidate is  not Eligible to upload CVC / TVC or CVC / TVC already uploaded Please check the Documents.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("Candidate name is not in Final Merit List so you can't upload CVC /TVC Certificate.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("As this Application Form is not Confirmed by You, Hence you can not Upload CVC_TVC_EWS Document.", ShowMessageType.Information);
                    }

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