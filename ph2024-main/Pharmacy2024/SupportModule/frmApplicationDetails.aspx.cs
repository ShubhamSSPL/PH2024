using BusinessLayer;
using EntityModel;
using Synthesys.Controls;

using SynthesysDAL;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;

namespace Pharmacy2024.SupportModule
{
    public partial class frmApplicationDetails : System.Web.UI.Page
    {
        AzureDocumentUpload objDU = new AzureDocumentUpload();
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string strVerificationMode = "";
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string NEETName = Global.NEETName;
        public string MHTCETName = Global.MHTCETName;

        public int AcknowledgementVersionNo = 0;
        public Int64 PID = 0;
        public Int64 ChoiceCode = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (Session["Error"] != null)
            {
                shInfo.SetMessage(Session["Error"].ToString(), ShowMessageType.Information);
                Session["Error"] = null;
            }
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                //PersonalInformation objPISupport =  reg.getPersonalInformationForSupport(PID);
                PersonalInformation obj1 = reg.getPersonalInformation(PID);
                lblLoginIDapp.Text = obj1.ApplicationID;
                lblUserNameapp.Text = obj1.CandidateName;
                // reg.GetSearchCandidatebySupport(strSearch)
                lblFatherNameapp.Text = obj1.FatherName;
                lblMothernameapp.Text = obj1.MotherName;
                lblDOBapp.Text = obj1.DOB;
                lblCandidaturetypeapp.Text = obj1.CandidatureType;
                lblGenderapp.Text = obj1.Gender;
                lblLastModifiedbyapp.Text = obj1.LastModifiedBy;
                lblCategory.Text = obj1.Category;
                lblCategoryForAdmissionBox.Text = obj1.FinalCategory;
                tblApplicationFormStatus.Visible = false;

                if (lblCategory.Text == lblCategoryForAdmissionBox.Text)
                {
                    //lblCategory.BackColor= lblCategoryForAdmissionBox.BackColor=   Color.FromName("#5CB850C");
                    lblCategory.BackColor = lblCategoryForAdmissionBox.BackColor = Color.Green;
                }
                else
                {
                    // lblCategory.BackColor = lblCategoryForAdmissionBox.BackColor = Color.FromName("#D9332C");
                    lblCategory.BackColor = lblCategoryForAdmissionBox.BackColor = Color.Red;
                }
                lblLastModifiedonapp.Text = obj1.LastModifiedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", obj1.LastModifiedOn);

                //lblApplicationFee.Text = Convert.ToString(obj1.CETApplicationFee);

                DataSet dsFeedetails = reg.getFeeDetailsForSupport(PID);
                //  lblSeatAcceptanceFee.Text = Convert.ToString(obj1.OnlineApplicationFee);
                // Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(PID);
                // lblConversionFee.Text = Convert.ToString(ApplicationFeeToBePaid);
                if (dsFeedetails.Tables[0].Rows.Count > 0)
                {
                    lblApplicationFee.Text = dsFeedetails.Tables[0].Rows[0][0].ToString();
                    lblConversionFee.Text = dsFeedetails.Tables[1].Rows[0][0].ToString();
                    lblSeatAcceptanceFee.Text = dsFeedetails.Tables[2].Rows[0][0].ToString();
                }
                else
                {
                    lblApplicationFee.Text = "0";
                    lblConversionFee.Text = "0";
                    lblSeatAcceptanceFee.Text = "0";

                }
                // lblSeatAcceptanceFee.Text= Convert.ToString(obj.sea)
                // Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                LoadApplicationFormStatus(PID);
                CheckStepID(PID);
                GetDocStatusForSupport(PID);
                GetCheckPaymentButtoncolor();
                if (obj1.VersionNo == 0)
                {
                    btnPrintApplicationForm.Text = "Print( " + Convert.ToString(obj1.VersionNo) + ") " + "Application Form";
                    btnPrintApplicationForm.Enabled = false;
                }
                else
                {
                    btnPrintApplicationForm.Text = "Print( " + Convert.ToString(obj1.VersionNo) + ") " + "Application Form";
                    btnPrintApplicationForm.Enabled = true;
                }

                DataSet dsACKNo = reg.GetApplicationFormAcknowledgeFormMaxVersionNo(PID, "Acknowledgement");
                // if (dsACKNo.Tables[0].Rows.Count > 0)
                if (Convert.ToInt32(dsACKNo.Tables[0].Rows[0]["VersionNo"].ToString()) > 0)
                {
                    AcknowledgementVersionNo = Convert.ToInt32(dsACKNo.Tables[0].Rows[0]["VersionNo"].ToString());
                    btnPrintAcknowledgement.Text = "Print( " + Convert.ToString(dsACKNo.Tables[0].Rows[0]["VersionNo"].ToString()) + ") " + "Acknowledgement";
                    btnPrintAcknowledgement.Enabled = true;
                    btnPrintAcknowledgement.BackColor = Color.FromName("#5CB85C");
                }
                else
                {
                    AcknowledgementVersionNo = 0;
                    btnPrintAcknowledgement.Text = "Print(0)Acknowledgement";
                    btnPrintAcknowledgement.BackColor = Color.FromName("#D9332C");
                    btnPrintAcknowledgement.Enabled = false;
                }
                DataSet dsCheckDocumentUploaded = reg.getRequiredDocumentsUploadStatusReportForCandidate(PID);
                if (dsCheckDocumentUploaded.Tables[0].Rows.Count > 0)
                {
                    if (dsCheckDocumentUploaded.Tables[0].Rows[2]["DocumentsUploadStatus"].ToString() == "Total Required Documents to be Uploaded")
                    {
                        int TotalDocuments = Convert.ToInt32(dsCheckDocumentUploaded.Tables[0].Rows[2]["TotalDocuments"].ToString());
                        if (TotalDocuments == 0)
                        {
                            btnCheckUploadedDoc.BackColor = Color.FromName("#5CB85C");

                        }
                        else
                        {
                            btnCheckUploadedDoc.BackColor = Color.FromName("#D9332C");
                        }
                    }
                }
                DateTime DOB = Convert.ToDateTime(obj1.DOB.Split("/".ToCharArray())[1] + "/" + obj1.DOB.Split("/".ToCharArray())[0] + "/" + obj1.DOB.Split("/".ToCharArray())[2]);

                DataSet ds = reg.getProvisionalMeritStatus(obj1.ApplicationID, DOB);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnProvMeritNo.BackColor = Color.FromName("#5CB85C");
                }
                else
                {
                    btnProvMeritNo.BackColor = Color.FromName("#D9332C");
                }

                DataSet dsDatesOptionForms1 = reg.getImportantDates(9);
                if (dsDatesOptionForms1.Tables[0].Rows.Count > 0)
                {
                    lblOptionForm1StartDate.Text = dsDatesOptionForms1.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                    lblOptionForm1EndDate.Text = dsDatesOptionForms1.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                }
                else
                {
                    lblOptionForm1StartDate.Text = "-";
                    lblOptionForm1EndDate.Text = "-";
                }
                DataSet dsDatesAllotment1 = reg.getImportantDates(10);
                if (dsDatesAllotment1.Tables[0].Rows.Count > 0)
                {
                    lblAllotment1StartDate.Text = dsDatesAllotment1.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                    //lblAllotment1EndDate.Text = dsDatesAllotment1.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                }
                else
                {
                    lblAllotment1StartDate.Text = "-";
                    //lblAllotment1EndDate.Text = "-";
                }
                DataSet dsDatesSelfARC1 = reg.getImportantDates(11);
                if (dsDatesSelfARC1.Tables[0].Rows.Count > 0)
                {
                    lblSelfARC1StartDate.Text = dsDatesSelfARC1.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                    lblSelfARC1EndDate.Text = dsDatesSelfARC1.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                }
                else
                {
                    lblSelfARC1StartDate.Text = "-";
                    lblSelfARC1EndDate.Text = "-";
                }
                DataSet dsDatesInstReporting1 = reg.getImportantDates(12);
                if (dsDatesInstReporting1.Tables[0].Rows.Count > 0)
                {
                    lblInstReporting1StartDate.Text = dsDatesInstReporting1.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                    lblInstReporting1EndDate.Text = dsDatesInstReporting1.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                }
                else
                {
                    lblInstReporting1StartDate.Text = "-";
                    lblInstReporting1EndDate.Text = "-";
                }
                DataSet dsDatesOptionForms2 = reg.getImportantDates(14);
                if (dsDatesOptionForms2.Tables[0].Rows.Count > 0)
                {
                    lblOptionForm2StartDate.Text = dsDatesOptionForms2.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                    lblOptionForm2EndDate.Text = dsDatesOptionForms2.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                }
                else
                {
                    lblOptionForm2StartDate.Text = "-";
                    lblOptionForm2EndDate.Text = "-";
                }
                DataSet dsDatesAllotment2 = reg.getImportantDates(15);
                if (dsDatesAllotment2.Tables[0].Rows.Count > 0)
                {
                    lblAllotment2StartDate.Text = dsDatesAllotment2.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                }
                else
                {
                    lblAllotment2StartDate.Text = "-";
                }
                DataSet dsDatesSelfARC2 = reg.getImportantDates(16);
                if (dsDatesSelfARC2.Tables[0].Rows.Count > 0)
                {
                    lblSelfARC2StartDate.Text = dsDatesSelfARC2.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                    lblSelfARC2EndDate.Text = dsDatesSelfARC2.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                }
                else
                {
                    lblSelfARC2StartDate.Text = "-";
                    lblSelfARC2EndDate.Text = "-";
                }

                DataSet dsDatesInstReporting2 = reg.getImportantDates(17);
                if (dsDatesInstReporting2.Tables[0].Rows.Count > 0)
                {
                    lblInstReporting2StartDate.Text = dsDatesInstReporting2.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                    lblInstReporting2EndDate.Text = dsDatesInstReporting2.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                }
                else
                {
                    lblInstReporting2StartDate.Text = "-";
                    lblInstReporting2EndDate.Text = "-";
                }
                DataSet dsDatesOptionForms3 = reg.getImportantDates(29);
                if (dsDatesOptionForms3.Tables[0].Rows.Count > 0)
                {
                    lblOptionForm3StartDate.Text = dsDatesOptionForms3.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                    lblOptionForm3EndDate.Text = dsDatesOptionForms3.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                }
                else
                {
                    lblOptionForm3StartDate.Text = "-";
                    lblOptionForm3EndDate.Text = "-";
                }
                DataSet dsDatesAllotment3 = reg.getImportantDates(30);
                if (dsDatesAllotment3.Tables[0].Rows.Count > 0)
                {
                    lblAllotment3StartDate.Text = dsDatesAllotment3.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                }
                else
                {
                    lblAllotment3StartDate.Text = "-";
                }
                DataSet dsDatesSelfARC3 = reg.getImportantDates(31);
                if (dsDatesSelfARC3.Tables[0].Rows.Count > 0)
                {
                    lblSelfARC3StartDate.Text = dsDatesSelfARC3.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                    lblSelfARC3EndDate.Text = dsDatesSelfARC3.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                }
                else
                {
                    lblSelfARC3StartDate.Text = "-";
                    lblSelfARC3EndDate.Text = "-";
                }

                DataSet dsDatesInstReporting3 = reg.getImportantDates(32);
                if (dsDatesInstReporting3.Tables[0].Rows.Count > 0)
                {
                    lblInstReporting3StartDate.Text = dsDatesInstReporting3.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                    lblInstReporting3EndDate.Text = dsDatesInstReporting3.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                }
                else
                {
                    lblInstReporting3StartDate.Text = "-";
                    lblInstReporting3EndDate.Text = "-";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void LoadApplicationFormStatus(Int64 PID)
        {

            SessionData objSessionData = new SessionData();
            Session["SessionData"] = objSessionData = reg.getSessionDataForCandidate(PID);
            // SessionData objSessionData = (SessionData)Session["SessionData"];
            DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
            char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
            char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
            char IsLockedByCandidate = Convert.ToChar(statusDs.Tables[0].Rows[0]["IsLockedByCandidate"].ToString());

            string FCVerificationStatusDate = statusDs.Tables[0].Rows[0]["FCVerificationStatusDate"].ToString();
            string ApplicationFormStatusDate = statusDs.Tables[0].Rows[0]["ApplicationFormStatusDate"].ToString();
            string LockDate = statusDs.Tables[0].Rows[0]["LockDate"].ToString();

            string FCVerificationModifiedBy = statusDs.Tables[0].Rows[0]["FCVerificationModifiedBy"].ToString();
            string ApplicationFormStatusModifiedBy = statusDs.Tables[0].Rows[0]["ApplicationFormStatusModifiedBy"].ToString();
            strVerificationMode = reg.CheckCandidateFCVerificationFor(objSessionData.PID);
            tblApplicationFormStatus.Visible = true;

            if (strVerificationMode == "E") //For EVerification
            {
                string strMappedFC = "";
                string strMappedTime = "";
                DataSet dsEScr = reg.GetCandidateEFCAllotted(objSessionData.PID);
                if (dsEScr.Tables[0].Rows.Count > 0)
                {
                    strMappedFC = dsEScr.Tables[0].Rows[0]["AFCName"].ToString();
                    strMappedTime = Convert.ToDateTime(dsEScr.Tables[0].Rows[0]["CreatedOn"]).ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", Convert.ToDateTime(dsEScr.Tables[0].Rows[0]["CreatedOn"]));
                }

                if (ApplicationFormStatus == 'I' && FCVerificationStatus == 'N')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is incomplete, Please Fill the Complete Application Form for E-Verification and Confirmation.";
                }
                else if ((ApplicationFormStatus == 'C' || ApplicationFormStatus == 'A') && FCVerificationStatus == 'N')
                {
                    if (reg.CheckFCVerificationStatusForResubmission(objSessionData.PID))
                    {
                        if (IsLockedByCandidate == 'Y')
                        {
                            //lblDiscrepancyStatus.Text = "Your Application Form is Completed and Resubmitted to " + strMappedFC + " on " + LockDate + " for Re-E-Verification(E-Scrutiny).";
                            lblDiscrepancyStatus.Text = "Your Application Form is Completed and Resubmitted to for Re-E-Verification(E-Scrutiny)-It will be verified soon.";
                        }
                        else
                        {
                            lblDiscrepancyStatus.Text = "Your Application Form is Completed and Ready for Resubmission. Please Check the Details once again and Resubmit it for Re-E-Verification(E-Scrutiny).";
                            trReSubmitButton.Visible = true;
                        }
                    }
                    else
                    {
                        if (IsLockedByCandidate == 'N' && (ApplicationFormStatus == 'C' || ApplicationFormStatus == 'A') && FCVerificationStatus == 'N')
                        {
                            if (objSessionData.CandidatureTypeID == 15 || objSessionData.CandidatureTypeID == 16)
                            {
                                tblDiscrepancyDetails.Visible = false;
                            }
                            else
                            {
                                lblDiscrepancyStatus.Text = "Your Application Form is Completed, Please Lock and Submit for E-Verification(E-Scrutiny).";
                                trSubmitButton.Visible = true;
                                //btnProceedToCompleteApplicationForm.Visible = false;
                            }
                        }
                        else
                        {
                            //lblDiscrepancyStatus.Text = "Your Application Form is Completed and Sent to " + strMappedFC + " on " + strMappedTime + " for E-Verification(E-Scrutiny).";
                            lblDiscrepancyStatus.Text = "Your Application Form is Completed and Sent to SC for E-Verification(E-Scrutiny)-It will be verified soon.";

                        }
                    }
                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'C' && FCVerificationStatus == 'P')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Picked for E-Verification and Locked by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ". It will be verified soon.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Picked for E-Verification and Locked - It will be verified soon.";
                    lblDiscrepancyStatus.ForeColor = System.Drawing.Color.Orange;
                    tblApplicationFormStatus.Visible = false;
                }
                else if ((ApplicationFormStatus == 'C' || ApplicationFormStatus == 'A' || ApplicationFormStatus == 'P') && FCVerificationStatus == 'D')
                {
                    //lblDiscrepancyStatus.Text = "Following Discrepancy(s) are found in Your Application Form by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ", and Reverted back your Application Form, Kindly Correct the Discrepancy by making necessory Corrections and Uploading related Documents.";
                    lblDiscrepancyStatus.Text = "Following Discrepancy(s) are found in Your Application Form  Reverted back your Application Form, Kindly Correct the Discrepancy by making necessory Corrections and Uploading related Documents.";
                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        trDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();
                        //trEditButton.Visible = true;

                        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                        {
                            if (gvDiscrepancy.Rows[i].Cells[2].Text == "Duplicate Mobile Number")
                            {
                                Button btnStep = (Button)gvDiscrepancy.Rows[i].FindControl("btnStep");
                                btnStep.Visible = true;
                                //gvDiscrepancy.Rows[i].Cells[6].Controls[0].Visible = false;
                            }
                            else
                            {
                                gvDiscrepancy.Rows[i].Cells[4].Visible = true;
                            }
                        }
                    }
                    else
                    {
                        trDiscrepancy.Visible = false;
                    }
                    tblApplicationFormStatus.Visible = false;

                }
                else if (ApplicationFormStatus == 'A' && FCVerificationStatus == 'C')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ". Please Check the Acknowledgement.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed Please Check the Acknowledgement.";
                    lblDiscrepancyStatus.ForeColor = System.Drawing.Color.Green;

                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        lblDiscrepancyStatus.Text += "<br/>Following Discrepancy(s) are found in Your Application Form. You can raise the Grievance to Unlock the Application Form.";

                        trDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();

                        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                        {
                            Button btnStep = (Button)gvDiscrepancy.Rows[i].FindControl("btnStep");
                            btnStep.Visible = false;
                        }
                    }
                    else
                    {
                        trDiscrepancy.Visible = false;
                    }

                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'A' && FCVerificationStatus == 'U')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is Unlocked on your Request(Grievance Raised) for Corrections. Please Edit the Application Form and ReSubmit it.";
                    trEditButton.Visible = true;

                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        lblDiscrepancyStatus.Text += "<br/>Following Discrepancy(s) are found in Your Application Form. Edit the Application Form and Upload the required Documents";

                        trDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();
                        //trEditButton.Visible = true;

                        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                        {
                            if (gvDiscrepancy.Rows[i].Cells[2].Text == "Duplicate Mobile Number")
                            {
                                Button btnStep = (Button)gvDiscrepancy.Rows[i].FindControl("btnStep");
                                btnStep.Visible = false;
                            }
                            else
                            {
                                gvDiscrepancy.Rows[i].Cells[4].Visible = true;
                            }
                        }
                    }
                    else
                    {
                        trDiscrepancy.Visible = false;
                    }
                    tblApplicationFormStatus.Visible = false;


                }
                else if (ApplicationFormStatus == 'A' && FCVerificationStatus == 'N' && IsLockedByCandidate == 'Y')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Re-Submitted to " + strMappedFC + " on " + FCVerificationStatusDate + " for Re-E-Verification(E-Scrutiny). It will be Verified soon.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Re-Submitted for Re-E-Verification(E-Scrutiny). It will be Verified soon.";
                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'A' && FCVerificationStatus == 'P')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Picked by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + " for Re-E-Verification and Locked. It will be Re-Vverified soon.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Picked for Re-E-Verification and Locked. It will be Re-Verified soon.";
                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'P' && FCVerificationStatus == 'C')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed Provissionally Please Check the Acknowledgement and Pay the difference in fee ONLINE.";
                    tblApplicationFormStatus.Visible = false;

                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        lblDiscrepancyStatus.Text += "<br/>Following Discrepancy(s) are found in Your Application Form. You can raise the Grievance to Unlock the Application Form.";

                        trDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();

                        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                        {
                            Button btnStep = (Button)gvDiscrepancy.Rows[i].FindControl("btnStep");
                            btnStep.Visible = false;
                        }
                    }
                    else
                    {
                        trDiscrepancy.Visible = false;
                    }
                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'P' && FCVerificationStatus == 'U')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Unlocked By " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ", on your Request(Grievance Raised) for Corrections. Please Edit the Application Form and ReSubmit it.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Unlocked on your Request(Grievance Raised) for Corrections. Please Edit the Application Form and ReSubmit it.";
                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        lblDiscrepancyStatus.Text += "<br/>Following Discrepancy(s) are found in Your Application Form. Edit the Application Form and Upload the required Documents";

                        trDiscrepancy.Visible = true;
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();
                        //trEditButton.Visible = true;

                        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                        {
                            if (gvDiscrepancy.Rows[i].Cells[2].Text == "Duplicate Mobile Number")
                            {
                                Button btnStep = (Button)gvDiscrepancy.Rows[i].FindControl("btnStep");
                                btnStep.Visible = false;
                            }
                            else
                            {
                                gvDiscrepancy.Rows[i].Cells[4].Visible = true;
                            }
                        }
                    }
                    else
                    {
                        trDiscrepancy.Visible = false;
                    }
                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'P' && FCVerificationStatus == 'N')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is Ready for Resubmission.";
                    tblApplicationFormStatus.Visible = false;
                }
                else if (ApplicationFormStatus == 'P' && FCVerificationStatus == 'P')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Picked by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + " for Re-E-Verification and Locked. It will be verified soon.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Picked for Re-E-Verification and Locked. It will be verified soon.";
                    tblApplicationFormStatus.Visible = false;
                }
            }
            if (strVerificationMode == "P") //In Person Physical SC Verification
            {
                if (ApplicationFormStatus == 'I')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is In-Complete, Please Fill the Complete Application Form and Visit to any nearest Scrutiny Center (SC) with all original Documents for Verification and Confirmation of your application form.";
                }
                else if (ApplicationFormStatus == 'C')
                {
                    DataSet ds = reg.GetCandidateBookingSlotDetails(objSessionData.PID);
                    if (ds.Tables[0].Rows.Count > 0 && strVerificationMode != "E")
                    {
                        lblDiscrepancyStatus.Text = "Your Application Form is Complete, Please Visit to any nearest Scrutiny Center (SC) with all original Documents for Verification and Confirmation of your application form.";
                    }
                    else
                    {
                        lblDiscrepancyStatus.Text = "Your Application Form is Complete, Please Book a Slot for Visit to Scrutiny Center for Confirmation.";
                        trBookSlotButton.Visible = true;
                    }
                }
                else if (ApplicationFormStatus == 'A')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ".";
                    lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed by ";
                    lblDiscrepancyStatus.ForeColor = System.Drawing.Color.Green;
                    tblApplicationFormStatus.Visible = false;
                }
            }
            //tblSEBCTOOpen.Visible = false;
        }
        protected void CheckStepID(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet statusDs = reg.getStepIDforSupport(PID);
                if (statusDs.Tables[0].Rows.Count > 0)
                {
                    btnFormStatus.Text = Convert.ToString(statusDs.Tables[0].Rows[0]["LinkStatus"].ToString());
                    btnFormStatus.BackColor = System.Drawing.Color.FromName(statusDs.Tables[0].Rows[0]["LinkBackColor"].ToString());
                    btnPrintApplicationForm.BackColor = System.Drawing.Color.FromName(statusDs.Tables[0].Rows[0]["LinkBackColor"].ToString());
                }
                else
                {
                    btnFormStatus.Text = "Step(0)Application";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void GetDocStatusForSupport(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet DSDocStatus = reg.GetDocStatusForSupport(PID);
                imgEWS.ImageUrl = "../Images/SupportModuleImages/" + DSDocStatus.Tables[0].Rows[0]["EWS"].ToString() + ".png";
                imgDef.ImageUrl = "../Images/SupportModuleImages/" + DSDocStatus.Tables[0].Rows[0]["DEF"].ToString() + ".png";
                imgMinority.ImageUrl = "../Images/SupportModuleImages/" + DSDocStatus.Tables[0].Rows[0]["Minority"].ToString() + ".png";
                imgOrphan.ImageUrl = "../Images/SupportModuleImages/" + DSDocStatus.Tables[0].Rows[0]["Orphan"].ToString() + ".png";
                imgPWD.ImageUrl = "../Images/SupportModuleImages/" + DSDocStatus.Tables[0].Rows[0]["PWD"].ToString() + ".png";
                imgTFWS.ImageUrl = "../Images/SupportModuleImages/" + DSDocStatus.Tables[0].Rows[0]["TFWS"].ToString() + ".png";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void GetCheckPaymentButtoncolor()
        {
            EGrassery_PaymentHistoryDB reg = new EGrassery_PaymentHistoryDB();
            Int64 PayeeID = 0;
            PayeeID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            DataSet ds = reg.checkPaymentHistory(PayeeID);
            grdPrevData.DataSource = ds.Tables[0];
            grdPrevData.DataBind();
            grdFail.DataSource = ds.Tables[1];
            grdFail.DataBind();

            if (grdPrevData.Rows.Count == 0 && grdFail.Rows.Count == 0)
            {
                btncheckPaymentHistory.BackColor = Color.FromName("#D9332C");
            }
            else
            {
                btncheckPaymentHistory.BackColor = Color.FromName("#5CB85C");
            }
        }
        protected void CheckPaymentHistory(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                EGrassery_PaymentHistoryDB reg = new EGrassery_PaymentHistoryDB();

                Int64 PayeeID = 0;
                if (Request.QueryString["PID"] != null)
                {
                    PayeeID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                }
                else
                {
                    PayeeID = Convert.ToInt64(Session["UserID"].ToString());
                }
                DataSet ds = reg.checkPaymentHistory(PayeeID);

                grdPrevData.DataSource = ds.Tables[0];
                grdPrevData.DataBind();

                if (grdPrevData.Rows.Count == 0)
                {
                    cntPrev.Visible = false;
                }
                grdFail.DataSource = ds.Tables[1];
                grdFail.DataBind();

                if (grdFail.Rows.Count == 0)
                {
                    cntFail.Visible = false;
                }
                if (grdPrevData.Rows.Count == 0 && grdFail.Rows.Count == 0)
                {
                    tblpaymentmsg.Visible = true;
                }
                else
                {
                    tblpaymentmsg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btncheckPaymentHistory_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                cntPrev.Visible = true;
                cntFail.Visible = true;
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                CheckPaymentHistory(PID);
                //contentViewDocument.Visible = false;
                ContentBoxDocumentDetails.Visible = false;
                CntChkGrievance.Visible = false;
                tblApplicationFormStatus.Visible = false;
                ContentBoxEntranceExamDetails.Visible = false;
                CntChkProvisionMerit.Visible = false;
                cntOptionForm.Visible = false;
                cntAllotmentDetails1.Visible = false;
                cntSelfArc1.Visible = false;
                cntInstituteReportingStatus1.Visible = false;
                cntOptionForm2.Visible = false;
                cntAllotmentDetails2.Visible = false;
                cntSelfArc2.Visible = false;
                cntInstituteReportingStatus2.Visible = false;
                cntOptionForm3.Visible = false;
                cntAllotmentDetails3.Visible = false;
                cntSelfArc3.Visible = false;
                cntInstituteReportingStatus3.Visible = false;
                cntILReporting.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnFormStatus_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                if (!reg.isCandidateNameAppearedInFinalMeritList(PID))
                {
                    tblApplicationFormStatus.Visible = true;
                    gvApplicationFormLinksStatus.DataSource = reg.getApplicationFormLinksStatus(PID);
                    gvApplicationFormLinksStatus.DataBind();
                }
                ContentBoxEntranceExamDetails.Visible = false;
                cntPrev.Visible = false;
                cntFail.Visible = false;
                ContentBoxDocumentDetails.Visible = false;
                CntChkGrievance.Visible = false;
                tblpaymentmsg.Visible = false;
                CntChkProvisionMerit.Visible = false;
                cntOptionForm.Visible = false;
                cntAllotmentDetails1.Visible = false;
                cntSelfArc1.Visible = false;
                cntInstituteReportingStatus1.Visible = false;
                cntOptionForm2.Visible = false;
                cntAllotmentDetails2.Visible = false;
                cntSelfArc2.Visible = false;
                cntInstituteReportingStatus2.Visible = false;
                cntOptionForm3.Visible = false;
                cntAllotmentDetails3.Visible = false;
                cntSelfArc3.Visible = false;
                cntInstituteReportingStatus3.Visible = false;
                cntILReporting.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
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
            }
        }
        protected void btnEntExamDetails_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                CheckEntranceExam(PID);
                ContentBoxEntranceExamDetails.Visible = true;
                cntPrev.Visible = false;
                cntFail.Visible = false;
                tblApplicationFormStatus.Visible = false;
                ContentBoxEntranceExamDetails.Focus();
                ContentBoxDocumentDetails.Visible = false;
                CntChkGrievance.Visible = false;
                tblpaymentmsg.Visible = false;
                CntChkProvisionMerit.Visible = false;
                cntOptionForm.Visible = false;
                cntAllotmentDetails1.Visible = false;
                cntSelfArc1.Visible = false;
                cntInstituteReportingStatus1.Visible = false;
                cntOptionForm2.Visible = false;
                cntAllotmentDetails2.Visible = false;
                cntSelfArc2.Visible = false;
                cntInstituteReportingStatus2.Visible = false;
                cntOptionForm3.Visible = false;
                cntAllotmentDetails3.Visible = false;
                cntSelfArc3.Visible = false;
                cntInstituteReportingStatus3.Visible = false;
                cntILReporting.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void CheckEntranceExam(Int64 PID)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            DataSet dsCETResult = reg.getCETDetails(objSessionData.CETApplicationFormNo);
            PersonalInformation obj = reg.getPersonalInformation(objSessionData.PID);
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
            else
            {
                lblNEETRollNoHeader.Text = "";
                trNEETScore1.Visible = false;
                trNEETScore2.Visible = false;
                lblNEETName.Visible = false;
            }
        }
        protected void btnCheckUploadedDoc_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (Global.IsDocumentUploadRequired == 1)
                {
                    tblDocumentUploadStatus.Visible = true;
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    gvRequiredDocumentsUploadStatus.DataSource = reg.getRequiredDocumentsUploadStatusReportForCandidate(PID);
                    gvRequiredDocumentsUploadStatus.DataBind();
                    ContentBoxDocumentDetails.Visible = true;
                    LoadDocuments(PID);
                    ContentBoxEntranceExamDetails.Visible = false;
                    cntPrev.Visible = false;
                    cntFail.Visible = false;
                    tblApplicationFormStatus.Visible = false;
                    CntChkGrievance.Visible = false;
                    tblpaymentmsg.Visible = false;
                    CntChkProvisionMerit.Visible = false;
                    cntOptionForm.Visible = false;
                    cntAllotmentDetails1.Visible = false;
                    cntSelfArc1.Visible = false;
                    cntInstituteReportingStatus1.Visible = false;
                    cntOptionForm2.Visible = false;
                    cntAllotmentDetails2.Visible = false;
                    cntSelfArc2.Visible = false;
                    cntInstituteReportingStatus2.Visible = false;
                    cntOptionForm3.Visible = false;
                    cntAllotmentDetails3.Visible = false;
                    cntSelfArc3.Visible = false;
                    cntInstituteReportingStatus3.Visible = false;
                    cntILReporting.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void LoadDocuments(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            DataSet ds = null;
            //DocumentJWT docJWT = new DocumentJWT();
            try
            {
                //var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                //var expiryTime = Math.Round((DateTime.UtcNow.AddMinutes(5) - unixEpoch).TotalSeconds);
                //docJWT.ApplicationFormNo = PID.ToString();
                //docJWT.Root = ConfigurationManager.AppSettings["DocRoot"].ToString();
                //docJWT.FolderName = ConfigurationManager.AppSettings["DocFolderName"].ToString();
                //docJWT.exp = expiryTime;
                //hdnToken.Value = JWTUtility.GetToken(docJWT);
                //hdnFileAddress.Value = ConfigurationManager.AppSettings["FileUploadServiceURL"].ToString();
                hdnFileTypes.Value = "0";
                hdnFileTypesCode.Value = "0";
                hdnMaxSize.Value = "0";
                hdnMaxSizeCode.Value = "0";

                ds = new dbUtility().GetAllDocuments(PID);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "1")
                        {
                            gvDocuments.DataSource = ds.Tables[0];
                            gvDocuments.DataBind();

                            // lblFileTypesAllowed.Text = hdnFileTypes.Value = Convert.ToString(ds.Tables[1].Rows[0]["FileExtensions"]);
                            hdnMaxSize.Value = Convert.ToString(ds.Tables[1].Rows[0]["MaxSizeInKB"]);
                            // lblMaxFileSize.Text = hdnMaxSize.Value + " KB";
                            string CasteValidityStatus = Convert.ToString(ds.Tables[1].Rows[0]["CasteValidityStatus"]);
                            string NCLStatus = Convert.ToString(ds.Tables[1].Rows[0]["NCLStatus"]);

                            for (int i = 0; i < gvDocuments.Rows.Count; i++)
                            {
                                int DocumentID = Convert.ToInt32(((HiddenField)gvDocuments.Rows[i].FindControl("hdnDocId")).Value);

                                if (DocumentID == 22 && CasteValidityStatus != "R")
                                {
                                    gvDocuments.Rows[i].Cells[3].ColumnSpan = 3;
                                    gvDocuments.Rows[i].Cells[4].Visible = false;
                                    gvDocuments.Rows[i].Cells[5].Visible = false;
                                    gvDocuments.Rows[i].Cells[3].Text = CasteValidityStatus == "A"
                                        ? "<font color='red'><b>Applied but Not Received</b></font>"
                                        : "<font color='red'><b>Not Applied</b></font>";
                                }

                                if (DocumentID == 24 && NCLStatus != "R")
                                {
                                    gvDocuments.Rows[i].Cells[3].ColumnSpan = 3;
                                    gvDocuments.Rows[i].Cells[4].Visible = false;
                                    gvDocuments.Rows[i].Cells[5].Visible = false;
                                    gvDocuments.Rows[i].Cells[3].Text = NCLStatus == "A"
                                        ? "<font color='red'><b>Applied but Not Received</b></font>"
                                        : "<font color='red'><b>Not Applied</b></font>";
                                }
                            }


                            //Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                            //if ((UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                            //{
                            //    for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                            //    {
                            //        gvDocuments.Rows[i].Cells[5].Text = "";
                            //    }
                            //}
                            //else if ((UserTypeID == 23 || UserTypeID == 24) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                            //{
                            //    Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                            //}
                        }
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "0")
                        {
                            gvDocuments.DataSource = null;
                            gvDocuments.DataBind();
                            shInfo.SetMessage(Convert.ToString(ds.Tables[0].Rows[0]["Message"]), ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("No Data Found!!!", ShowMessageType.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError);
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
        }
        protected void gvDocuments_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        private class dbUtility
        {
            public DataSet GetAllDocuments(Int64 PID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.BigInt)
                };

                param[0].Value = PID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetAllDocuments", param);
                }
                finally
                {
                    db.Dispose();
                }


            }
            public DataSet saveUploadedDocument(Int64 PID, Int64 DocumentID, string FileName, string AbsoluteFilePath, string OriginalFileName, string FileUploadedBy, string FileUploadedByIPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@DocumentID",SqlDbType.BigInt),
                    new SqlParameter("@FileName",SqlDbType.VarChar),
                    new SqlParameter("@AbsoluteFilePath",SqlDbType.VarChar),
                    new SqlParameter("@OriginalFileName",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),
                    new SqlParameter("@DocumentStatus",SqlDbType.VarChar)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = FileName;
                param[3].Value = AbsoluteFilePath;
                param[4].Value = OriginalFileName;
                param[5].Value = FileUploadedBy;
                param[6].Value = FileUploadedByIPAddress;
                param[7].Value = "A";

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUpdateDocumentUploadStatus", param);
                }
                finally
                {
                    db.Dispose();
                }


            }
            public DataSet deleteUploadedDocument(Int64 PID, Int64 DocumentID, string FileUploadedBy, string FileUploadedByIPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@DocumentID",SqlDbType.BigInt),
                    new SqlParameter("@FileName",SqlDbType.VarChar),
                    new SqlParameter("@AbsoluteFilePath",SqlDbType.VarChar),
                    new SqlParameter("@OriginalFileName",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),
                    new SqlParameter("@DocumentStatus",SqlDbType.VarChar)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = "";
                param[3].Value = "";
                param[4].Value = "";
                param[5].Value = FileUploadedBy;
                param[6].Value = FileUploadedByIPAddress;
                param[7].Value = "D";

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUpdateDocumentUploadStatus", param);
                }
                finally
                {
                    db.Dispose();
                }


            }
            public DataSet saveUploadedDocumentJuridiction(Int64 PID, Int64 DocumentID, string FileUploadedBy, string FileUploadedByIPAddress, int JuridictionID, int DistrictID, int TalukaID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@DocumentID",SqlDbType.BigInt),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),
                    new SqlParameter("@JuridictionID",SqlDbType.Int),
                    new SqlParameter("@DistrictID",SqlDbType.Int),
                    new SqlParameter("@TalukaID",SqlDbType.Int)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = FileUploadedBy;
                param[3].Value = FileUploadedByIPAddress;
                param[4].Value = JuridictionID;
                param[5].Value = DistrictID;
                param[6].Value = TalukaID;

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUpdateJuridictionDocumentUpload", param);
                }
                finally
                {
                    db.Dispose();
                }


            }
        }
        public class EGrassery_PaymentHistoryDB
        {

            public DataSet checkPaymentHistory(Int64 PayeeID)
            {
                SqlParameter[] param =
                {
            new SqlParameter("@PayeeID", SqlDbType.BigInt)
        };

                param[0].Value = PayeeID;

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("Fee_Client_CheckPaymentHistory", param);

                }
                finally
                {
                    db.Dispose();
                }
            }
        }


        //protected void checkGrivence (Int64 PID)
        //{
        //    DBUtility regDB = new DBUtility();
        //    DataSet dschkgrivence = regDB.GetCandidateSendGrievances("CANDIDATE", PID);
        //    //gvMessages.DataBind();
        //    if (dschkgrivence.Tables[0].Rows.Count > 0)               
        //    {
        //        btnCheckGrivence.Text = Color.Red;

        //    }
        //    else
        //    {

        //    }
        //}
        private class DBUtility
        {
            public DataSet GetCandidateSendGrievances(string Flag, Int64 PID)
            {
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetCandidateSendGrievances", new SqlParameter[]
                        {
                            new SqlParameter("@Flag", Flag),
                            new SqlParameter("@PID", PID)
                        });
                }
                finally
                {
                    db.Dispose();
                }
            }
        }

        protected void btnCheckGrivence_Click(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

            // SessionData objSessionData = (SessionData)Session["SessionData"];
            try
            {
                CntChkGrievance.Visible = true;
                ContentBoxEntranceExamDetails.Visible = false;
                cntPrev.Visible = false;
                cntFail.Visible = false;
                tblApplicationFormStatus.Visible = false;
                tblpaymentmsg.Visible = false;
                ContentBoxDocumentDetails.Visible = false;
                CntChkProvisionMerit.Visible = false;
                cntOptionForm.Visible = false;
                cntAllotmentDetails1.Visible = false;
                cntSelfArc1.Visible = false;
                cntInstituteReportingStatus1.Visible = false;
                cntOptionForm2.Visible = false;
                cntAllotmentDetails2.Visible = false;
                cntSelfArc2.Visible = false;
                cntInstituteReportingStatus2.Visible = false;
                cntOptionForm3.Visible = false;
                cntAllotmentDetails3.Visible = false;
                cntSelfArc3.Visible = false;
                cntInstituteReportingStatus3.Visible = false;
                cntILReporting.Visible = false;

                DBUtility regDB = new DBUtility();
                gvMessages.DataSource = regDB.GetCandidateSendGrievances("CANDIDATE", PID);
                gvMessages.DataBind();

                Int32 Count = gvMessages.Rows.Count;
                if (Count == 0)
                {
                    gvMessages.Visible = false;
                    tblMsg.Visible = true;
                }
                else
                {
                    Int32 j = 1;
                    for (Int32 m = 0; m < Count; m++)
                    {
                        DateTime tempSentDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[4].Text);
                        string SentDate = tempSentDate.Day.ToString() + "/" + tempSentDate.Month.ToString() + "/" + tempSentDate.Year.ToString() + " " + String.Format("{0:T}", tempSentDate);
                        gvMessages.Rows[m].Cells[4].Text = SentDate;

                        //DateTime tempReplyDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[7].Text);
                        //string ReplyDate = tempReplyDate.Day.ToString() + "/" + tempReplyDate.Month.ToString() + "/" + tempReplyDate.Year.ToString() + " " + String.Format("{0:T}", tempReplyDate);
                        //gvMessages.Rows[m].Cells[7].Text = ReplyDate;

                        gvMessages.Rows[m].Cells[0].Text = j.ToString() + ".";
                        j++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvMessages_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //try
            //{
            //    string GrievanceID = gvMessages.Rows[e.NewSelectedIndex].Cells[1].Text;

            //    Response.Redirect("../CandidateModule/frmViewGrievance.aspx?GrievanceID=" + GrievanceID, true);
            //}
            //catch (Exception ex)
            //{
            //    Logging.LogException(ex, "[Page Level Error]");
            //    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            //}
        }

        protected void btnProvMeritNo_Click(object sender, EventArgs e)
        {
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;

            CntChkProvisionMerit.Visible = true;
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string ApplicationID = lblLoginIDapp.Text;
                // DateTime DOB = Convert.ToDateTime(lblDOBapp.Text.Split("/".ToCharArray())[1] + "/" + lblDOBapp.Text.Split("/".ToCharArray())[0] + "/" + lblDOBapp.Text.Split("/".ToCharArray())[2]);
                DateTime DOB = Convert.ToDateTime(lblDOBapp.Text.Split("/".ToCharArray())[1] + "/" + lblDOBapp.Text.Split("/".ToCharArray())[0] + "/" + lblDOBapp.Text.Split("/".ToCharArray())[2]);

                DataSet ds = reg.getProvisionalMeritStatus(ApplicationID, DOB);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    tblProvMeritEligible.Visible = true;
                    tblProvMeritNotEligible.Visible = false;
                    DataSet dsJEE = reg.GetIncorrectNEETDetailsCandidate(Convert.ToInt64(ds.Tables[0].Rows[0]["PersonalID"]));
                    if (ds.Tables[0].Rows[0]["IsDuplicate"].ToString() == "Y")
                    {
                        shInfo.SetMessage("You have filled more than one Application Form. Please contact to Help Line Number.", ShowMessageType.Information);
                    }
                    else if (dsJEE.Tables[0].Rows.Count > 0)
                    {
                        shInfo.SetMessage("You have entered wrong  NEET " + CurrentYear + " Details. Kindly correct your details(Score) immediately.", ShowMessageType.Information);
                    }
                    else
                    {
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["StateGeneralMeritNo"].ToString()) > 0)
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
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["KonkanStateGeneralMeritNo"].ToString()) > 0)
                        {
                            trKonkanStateGeneralMeritNo.Visible = true;
                            lblKonkanStateGeneralMeritNo.Text = ds.Tables[0].Rows[0]["KonkanStateGeneralMeritNo"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["KonkanStateCategoryMeritNo"].ToString()) > 0)
                        {
                            trKonkanStateCategoryMeritNo.Visible = true;
                            lblKonkanStateCategoryMeritNo.Text = ds.Tables[0].Rows[0]["KonkanStateCategoryMeritNo"].ToString() + " - " + ds.Tables[0].Rows[0]["CategoryForMerit"].ToString();
                        }
                        if (Convert.ToInt64(ds.Tables[0].Rows[0]["AIMeritNo"].ToString()) > 0)
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
                    tblProvMeritEligible.Visible = false;
                    tblProvMeritNotEligible.Visible = true;
                    shInfo.SetMessage("You are not Eligible for Merit.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnOptionForm1_Click(object sender, EventArgs e)
        {
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            cntOptionForm.Visible = true;
            tblOptionForm.Visible = true;
            trOptionFormStatusCAPRound1.Visible = true;

            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                SessionData objSessionData = new SessionData();
                Session["SessionData"] = objSessionData = reg.getSessionDataForCandidate(PID);
                if (objSessionData.EligibleForCAPRound1 == 0)
                {
                    lblOptionFormStatusCAPRound1.ForeColor = System.Drawing.Color.Red;
                    lblOptionFormStatusCAPRound1.Text = "You are Not Eligible to Submit Option Form for CAP Round-I";
                }
                else
                {
                    if (objSessionData.OptionFormStatusCAPRound1 == 'I')
                    {
                        lblOptionFormStatusCAPRound1.ForeColor = System.Drawing.Color.Red;
                        lblOptionFormStatusCAPRound1.Text = "Incomplete Option Form for CAP Round-I";
                    }
                    else if (objSessionData.OptionFormStatusCAPRound1 == 'C')
                    {
                        lblOptionFormStatusCAPRound1.ForeColor = System.Drawing.Color.Red;
                        lblOptionFormStatusCAPRound1.Text = "Complete Option Form for CAP Round-I. Now confirm it";
                    }
                    else if (objSessionData.OptionFormStatusCAPRound1 == 'A')
                    {
                        lblOptionFormStatusCAPRound1.ForeColor = System.Drawing.Color.Green;
                        lblOptionFormStatusCAPRound1.Text = "Option Form for CAP Round-I is Confirmed";
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnAllotmentDetails1_Click(object sender, EventArgs e)
        {
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                DataSet dsCAD = reg.getCurrentAllotmentDetails(PID);
                string BenefitTaken = reg.getBenefitTakenByCandidate(PID, 0);
                if (Global.CAPRound >= 1)
                {
                    if (dsCAD.Tables[0].Rows.Count > 0)
                    {
                        if (BenefitTaken == "")
                        {
                            trBenefitTaken.Visible = false;
                        }
                        else
                        {
                            lblBenefitTaken.Text = BenefitTaken;
                        }
                        cntAllotmentDetails1.Visible = true;
                        tblAllotmentDetails.Visible = true;
                        tblNoAllotmentDetails.Visible = false;
                        lblInstituteAllotted.Text = dsCAD.Tables[0].Rows[0]["InstituteAllotted"].ToString();
                        lblCourseAllotted.Text = dsCAD.Tables[0].Rows[0]["CourseAllotted"].ToString();
                        lblSeatTypeAllotted.Text = dsCAD.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                        lblPreferenceNoAllotted.Text = dsCAD.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString();
                    }
                    else
                    {
                        cntAllotmentDetails1.Visible = true;
                        tblAllotmentDetails.Visible = false;
                        tblNoAllotmentDetails.Visible = true;
                        lblAllotmentStatus.Text = "Not Allotted Till Now.";
                    }
                }
                else
                {
                    cntAllotmentDetails1.Visible = true;
                    tblAllotmentDetails.Visible = false;
                    tblNoAllotmentDetails.Visible = true;
                    lblAllotmentStatus.Text = "Not Allotted Till Now.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnSelfARC1_Click(object sender, EventArgs e)
        {
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                DataSet seatAcceptanceGrivance = reg.GetSeatAcceptanceGrivanceStatusByPID(PID);
                string IsGrivanceRaised = "";
                Int16 IsAllotmentCancellationRequired = 0;

                if (Global.CAPRound >= 1)
                {
                    if (seatAcceptanceGrivance.Tables[0].Rows.Count > 0)
                    {
                        IsGrivanceRaised = seatAcceptanceGrivance.Tables[0].Rows[0]["IsGrivanceRaised"].ToString();
                        IsAllotmentCancellationRequired = Convert.ToInt16(seatAcceptanceGrivance.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString());
                    }
                    DataSet dsCAD = reg.getCurrentAllotmentDetails(PID);
                    if (dsCAD.Tables[0].Rows.Count > 0)
                    {
                        cntSelfArc1.Visible = true;
                        tblSelfArc1.Visible = true;
                        tblNoSelfArc1.Visible = false;
                        if (IsGrivanceRaised == "" || IsGrivanceRaised == "N" || IsGrivanceRaised == "R" || (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 0))
                        {
                            string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(PID);

                            if (SeatAcceptanceConfirmationStatus == "Y")
                            {
                                btnSeatAcceptanceStep1.Text = "Complete";
                                btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptanceStep1.Enabled = false;

                                btnSeatAcceptanceStep2.Text = "Complete";
                                btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptanceStep2.Enabled = false;

                                btnSeatAcceptanceStep3.Text = "Complete";
                                btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptanceStep3.Enabled = false;

                                btnSeatAcceptanceStep4.Text = "Complete";
                                btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                            }
                            else
                            {
                                if (!reg.CheckSelfVerificationIsDone(PID))
                                {
                                    if (reg.CheckCandidateinAllotmentCancellationRemark(PID))
                                    {
                                        btnSeatAcceptanceStep1.Text = "Your Allotment is Cancelled";
                                        btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        btnSeatAcceptanceStep1.Enabled = false;
                                        btnSeatAcceptanceStep2.Text = "Incomplete";
                                        btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        btnSeatAcceptanceStep2.Enabled = false;
                                        btnSeatAcceptanceStep3.Text = "Incomplete";
                                        btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        btnSeatAcceptanceStep3.Enabled = false;
                                        btnSeatAcceptanceStep4.Text = "Incomplete";
                                        btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        btnSeatAcceptanceStep4.Enabled = false;
                                    }
                                    else
                                    {
                                        btnSeatAcceptanceStep1.Text = "Complete";
                                        btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        btnSeatAcceptanceStep1.Enabled = false;
                                    }
                                }
                                else
                                {
                                    btnSeatAcceptanceStep1.Text = "Incomplete";
                                    btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptanceStep1.Enabled = false;
                                }
                                DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(PID);
                                if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                                {
                                    btnSeatAcceptanceStep2.Text = "Complete";
                                    btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                    btnSeatAcceptanceStep2.Enabled = false;
                                }
                                else
                                {
                                    btnSeatAcceptanceStep2.Text = "Incomplete";
                                    btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptanceStep2.Enabled = false;
                                }

                                DataSet dsSeatAcceptanceFeeDetails = reg.getSeatAcceptanceFeeList(PID, "Seat Acceptance Fee");
                                if (dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0)
                                {
                                    btnSeatAcceptanceStep3.Text = "Complete";
                                    btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                    btnSeatAcceptanceStep3.Enabled = false;
                                }
                                else
                                {
                                    btnSeatAcceptanceStep3.Text = "Incomplete";
                                    btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptanceStep3.Enabled = false;
                                }
                                if (SeatAcceptanceConfirmationStatus == "Y" && dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0)
                                {
                                    btnSeatAcceptanceStep4.Text = "Complete";
                                    btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptanceStep4.Enabled = false;
                                }
                                else
                                {
                                    btnSeatAcceptanceStep4.Text = "Incomplete";
                                    btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptanceStep4.Enabled = false;
                                    if (dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0 && dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                                        btnSeatAcceptanceStep4.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            if (IsGrivanceRaised == "Y")
                            {
                                btnSeatAcceptanceStep1.Text = "Grievance Is Raised";
                            }
                            if (IsGrivanceRaised == "P")
                            {
                                btnSeatAcceptanceStep1.Text = "Grievance is Picked for Verification";
                            }
                            if (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 1)
                            {
                                btnSeatAcceptanceStep1.Text = "Your Allotment is Cancelled";
                            }
                            if (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 0)
                            {
                                btnSeatAcceptanceStep1.Text = "Your Grievance is Approved";
                            }
                            if (reg.CheckCandidateinAllotmentCancellationRemark(PID))
                            {
                                btnSeatAcceptanceStep1.Text = "Your Allotment is Cancelled";
                                btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptanceStep1.Enabled = false;
                            }
                            //btnSeatAcceptanceStep1.Text = "Incomplete";
                            btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                            btnSeatAcceptanceStep1.Enabled = false;
                            btnSeatAcceptanceStep2.Text = "Incomplete";
                            btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                            btnSeatAcceptanceStep2.Enabled = false;
                            btnSeatAcceptanceStep3.Text = "Incomplete";
                            btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                            btnSeatAcceptanceStep3.Enabled = false;
                            btnSeatAcceptanceStep4.Text = "Incomplete";
                            btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                            btnSeatAcceptanceStep4.Enabled = false;
                        }
                    }
                    else
                    {
                        cntSelfArc1.Visible = true;
                        tblNoSelfArc1.Visible = true;
                        tblSelfArc1.Visible = false;
                        lblNoSelfArc1Status.Text = "Not Self Verified Till Now.";
                        //btnSeatAcceptanceStep1.Text = "Incomplete";
                        //btnSeatAcceptanceStep1.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                        //btnSeatAcceptanceStep1.Enabled = false;
                        //btnSeatAcceptanceStep2.Text = "Incomplete";
                        //btnSeatAcceptanceStep2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                        //btnSeatAcceptanceStep2.Enabled = false;
                        //btnSeatAcceptanceStep3.Text = "Incomplete";
                        //btnSeatAcceptanceStep3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                        //btnSeatAcceptanceStep3.Enabled = false;
                        //btnSeatAcceptanceStep4.Text = "Incomplete";
                        //btnSeatAcceptanceStep4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                        //btnSeatAcceptanceStep4.Enabled = false;
                    }
                }
                else
                {
                    cntSelfArc1.Visible = true;
                    tblNoSelfArc1.Visible = true;
                    tblSelfArc1.Visible = false;
                    lblNoSelfArc1Status.Text = "Not Self Verified Till Now.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnInstituteReportingStatus1_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;

            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                DataSet dsCAD = reg.getCurrentAdmissionDetails(PID);
                if (Global.CAPRound >= 1)
                {
                    if (dsCAD.Tables[0].Rows.Count == 0)
                    {
                        cntInstituteReportingStatus1.Visible = true;
                        tblNoAdmissionDetails.Visible = true;
                        tblAdmissionDetails.Visible = false;
                        lblAdmissionStatus.Text = "Not Admitted Till Now.";
                    }
                    else if (dsCAD.Tables[0].Rows.Count == 1)
                    {
                        cntInstituteReportingStatus1.Visible = true;
                        tblAdmissionDetails.Visible = true;
                        tblNoAdmissionDetails.Visible = false;
                        lblInstituteAdmitted.Text = dsCAD.Tables[0].Rows[0]["InstituteAdmitted"].ToString();
                        lblCourseAdmitted.Text = dsCAD.Tables[0].Rows[0]["CourseAdmitted"].ToString();
                        lblSeatTypeAdmitted.Text = dsCAD.Tables[0].Rows[0]["SeatTypeAdmitted"].ToString();
                        lblAdmissionRound.Text = dsCAD.Tables[0].Rows[0]["AdmissionRound"].ToString();
                    }
                    else if (dsCAD.Tables[0].Rows.Count > 1)
                    {
                        cntInstituteReportingStatus1.Visible = true;
                        tblNoAdmissionDetails.Visible = true;
                        tblAdmissionDetails.Visible = false;
                        lblAdmissionStatus.Text = "You have been admitted in more then one courses. Please cancel the extra admission.";
                    }
                }
                else
                {
                    cntInstituteReportingStatus1.Visible = true;
                    tblNoAdmissionDetails.Visible = true;
                    tblAdmissionDetails.Visible = false;
                    lblAdmissionStatus.Text = "Not Admitted Till Now.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnOptionForm2_Click(object sender, EventArgs e)
        {
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            cntOptionForm2.Visible = true;
            tblOptionForm2.Visible = true;
            trOptionFormStatusCAPRound2.Visible = true;

            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                SessionData objSessionData = new SessionData();
                Session["SessionData"] = objSessionData = reg.getSessionDataForCandidate(PID);
                if (objSessionData.EligibleForCAPRound2 == 0)
                {
                    lblOptionFormStatusCAPRound2.ForeColor = System.Drawing.Color.Red;
                    lblOptionFormStatusCAPRound2.Text = "You are Not Eligible to Submit Option Form for CAP Round-II";
                }
                else
                {
                    if (objSessionData.OptionFormStatusCAPRound2 == 'I')
                    {
                        lblOptionFormStatusCAPRound2.ForeColor = System.Drawing.Color.Red;
                        lblOptionFormStatusCAPRound2.Text = "Incomplete Option Form for CAP Round-II";
                    }
                    else if (objSessionData.OptionFormStatusCAPRound2 == 'C')
                    {
                        lblOptionFormStatusCAPRound2.ForeColor = System.Drawing.Color.Red;
                        lblOptionFormStatusCAPRound2.Text = "Complete Option Form for CAP Round-II. Now confirm it";
                    }
                    else if (objSessionData.OptionFormStatusCAPRound2 == 'A')
                    {
                        lblOptionFormStatusCAPRound2.ForeColor = System.Drawing.Color.Green;
                        lblOptionFormStatusCAPRound2.Text = "Option Form for CAP Round-II is Confirmed";
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnAllotmentDetails2_Click(object sender, EventArgs e)
        {
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                DataSet dsCAD = reg.getAllotmentDetails(PID);
                string BenefitTaken = reg.getBenefitTakenByCandidate(PID, 0);

                if (dsCAD.Tables[1].Rows.Count > 0)
                {
                    string ReportingStatus = dsCAD.Tables[1].Rows[0]["ReportingStatus"].ToString();
                    if (ReportingStatus == "Y" || ReportingStatus == "N" || ReportingStatus == "C")
                    {
                        if (BenefitTaken == "")
                        {
                            trBenefitTaken2.Visible = false;
                        }
                        else
                        {
                            lblBenefitTaken2.Text = BenefitTaken;
                        }
                        cntAllotmentDetails2.Visible = true;
                        tblAllotmentDetails2.Visible = true;
                        tblNoAllotmentDetails2.Visible = false;
                        lblInstituteAllotted2.Text = dsCAD.Tables[1].Rows[0]["InstituteAllotted"].ToString();
                        lblCourseAllotted2.Text = dsCAD.Tables[1].Rows[0]["CourseAllotted"].ToString();
                        lblSeatTypeAllotted2.Text = dsCAD.Tables[1].Rows[0]["SeatTypeAllotted"].ToString();
                        lblPreferenceNoAllotted2.Text = dsCAD.Tables[1].Rows[0]["PreferenceNoAllotted"].ToString();
                    }
                    else
                    {
                        cntAllotmentDetails2.Visible = true;
                        tblAllotmentDetails2.Visible = false;
                        tblNoAllotmentDetails2.Visible = true;
                        lblAllotmentStatus2.Text = "Not Allotted Till Now.";
                    }
                }
                else
                {
                    cntAllotmentDetails2.Visible = true;
                    tblAllotmentDetails2.Visible = false;
                    tblNoAllotmentDetails2.Visible = true;
                    lblAllotmentStatus2.Text = "Not Allotted Till Now.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnSelfArc2_Click(object sender, EventArgs e)
        {
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                DataSet seatAcceptanceGrivance = reg.GetSeatAcceptanceGrivanceStatusByPID(PID);
                string IsGrivanceRaised = "";
                Int16 IsAllotmentCancellationRequired = 0;

                if (seatAcceptanceGrivance.Tables[0].Rows.Count > 0)
                {
                    IsGrivanceRaised = seatAcceptanceGrivance.Tables[0].Rows[0]["IsGrivanceRaised"].ToString();
                    IsAllotmentCancellationRequired = Convert.ToInt16(seatAcceptanceGrivance.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString());
                }
                DataSet dsCAD = reg.getAllotmentDetails(PID);
                if (dsCAD.Tables[1].Rows.Count > 0)
                {
                    string ReportingStatus = dsCAD.Tables[1].Rows[0]["ReportingStatus"].ToString();
                    if (ReportingStatus == "Y" || ReportingStatus == "N" || ReportingStatus == "C")
                    {
                        cntSelfArc2.Visible = true;
                        tblSelfArc2.Visible = true;
                        tblNoSelfArc2.Visible = false;
                        if (IsGrivanceRaised == "" || IsGrivanceRaised == "N" || IsGrivanceRaised == "R" || (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 0))
                        {
                            string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(PID);

                            if (SeatAcceptanceConfirmationStatus == "Y")
                            {
                                btnSeatAcceptance2Step1.Text = "Complete";
                                btnSeatAcceptance2Step1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptance2Step1.Enabled = false;

                                btnSeatAcceptance2Step2.Text = "Complete";
                                btnSeatAcceptance2Step2.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptance2Step2.Enabled = false;

                                btnSeatAcceptance2Step3.Text = "Complete";
                                btnSeatAcceptance2Step3.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptance2Step3.Enabled = false;

                                btnSeatAcceptance2Step4.Text = "Complete";
                                btnSeatAcceptance2Step4.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                            }
                            else
                            {
                                if (!reg.CheckSelfVerificationIsDone(PID))
                                {
                                    if (reg.CheckCandidateinAllotmentCancellationRemark(PID))
                                    {
                                        btnSeatAcceptance2Step1.Text = "Your Allotment is Cancelled";
                                        btnSeatAcceptance2Step1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        btnSeatAcceptance2Step1.Enabled = false;
                                        btnSeatAcceptance2Step2.Text = "Incomplete";
                                        btnSeatAcceptance2Step2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        btnSeatAcceptance2Step2.Enabled = false;
                                        btnSeatAcceptance2Step3.Text = "Incomplete";
                                        btnSeatAcceptance2Step3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        btnSeatAcceptance2Step3.Enabled = false;
                                        btnSeatAcceptance2Step4.Text = "Incomplete";
                                        btnSeatAcceptance2Step4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        btnSeatAcceptance2Step4.Enabled = false;
                                    }
                                    else
                                    {
                                        btnSeatAcceptance2Step1.Text = "Complete";
                                        btnSeatAcceptance2Step1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        btnSeatAcceptance2Step1.Enabled = false;
                                    }
                                }
                                else
                                {
                                    btnSeatAcceptance2Step1.Text = "Incomplete";
                                    btnSeatAcceptance2Step1.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptance2Step1.Enabled = false;
                                }
                                DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(PID);
                                if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                                {
                                    btnSeatAcceptance2Step2.Text = "Complete";
                                    btnSeatAcceptance2Step2.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                    btnSeatAcceptance2Step2.Enabled = false;
                                }
                                else
                                {
                                    btnSeatAcceptance2Step2.Text = "Incomplete";
                                    btnSeatAcceptance2Step2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptance2Step2.Enabled = false;
                                }

                                DataSet dsSeatAcceptanceFeeDetails = reg.getSeatAcceptanceFeeList(PID, "Seat Acceptance Fee");
                                if (dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0)
                                {
                                    btnSeatAcceptance2Step3.Text = "Complete";
                                    btnSeatAcceptance2Step3.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                    btnSeatAcceptance2Step3.Enabled = false;
                                }
                                else
                                {
                                    btnSeatAcceptance2Step3.Text = "Incomplete";
                                    btnSeatAcceptance2Step3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptance2Step3.Enabled = false;
                                }
                                if (SeatAcceptanceConfirmationStatus == "Y" && dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0)
                                {
                                    btnSeatAcceptance2Step4.Text = "Complete";
                                    btnSeatAcceptance2Step4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptance2Step4.Enabled = false;
                                }
                                else
                                {
                                    btnSeatAcceptance2Step4.Text = "Incomplete";
                                    btnSeatAcceptance2Step4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptance2Step4.Enabled = false;
                                    if (dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0 && dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                                        btnSeatAcceptance2Step4.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            if (IsGrivanceRaised == "Y")
                            {
                                btnSeatAcceptance2Step1.Text = "Grievance Is Raised";
                            }
                            if (IsGrivanceRaised == "P")
                            {
                                btnSeatAcceptance2Step1.Text = "Grievance is Picked for Verification";
                            }
                            if (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 1)
                            {
                                btnSeatAcceptance2Step1.Text = "Your Allotment is Cancelled";
                            }
                            if (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 0)
                            {
                                btnSeatAcceptance2Step1.Text = "Your Grievance is Approved";
                            }
                            if (reg.CheckCandidateinAllotmentCancellationRemark(PID))
                            {
                                btnSeatAcceptance2Step1.Text = "Your Allotment is Cancelled";
                                btnSeatAcceptance2Step1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptance2Step1.Enabled = false;
                            }
                            //btnSeatAcceptanceStep1.Text = "Incomplete";
                            btnSeatAcceptance2Step1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                            btnSeatAcceptance2Step1.Enabled = false;
                            btnSeatAcceptance2Step2.Text = "Incomplete";
                            btnSeatAcceptance2Step2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                            btnSeatAcceptance2Step2.Enabled = false;
                            btnSeatAcceptance2Step3.Text = "Incomplete";
                            btnSeatAcceptance2Step3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                            btnSeatAcceptance2Step3.Enabled = false;
                            btnSeatAcceptance2Step4.Text = "Incomplete";
                            btnSeatAcceptance2Step4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                            btnSeatAcceptance2Step4.Enabled = false;
                        }
                    }
                    else
                    {
                        cntSelfArc2.Visible = true;
                        tblNoSelfArc2.Visible = true;
                        tblSelfArc2.Visible = false;
                        lblNoSelfArc2Status.Text = "Not Self Verified Till Now.";
                    }
                }
                else
                {
                    cntSelfArc2.Visible = true;
                    tblNoSelfArc2.Visible = true;
                    tblSelfArc2.Visible = false;
                    lblNoSelfArc2Status.Text = "Not Self Verified Till Now.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnInstituteReportingStatus2_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                DataSet dsCAD = reg.getCurrentAdmissionDetails(PID);

                if (dsCAD.Tables[0].Rows.Count == 0)
                {
                    cntInstituteReportingStatus2.Visible = true;
                    tblNoAdmissionDetails2.Visible = true;
                    tblAdmissionDetails2.Visible = false;
                    lblAdmissionStatus2.Text = "Not Admitted Till Now.";
                }
                //else if (dsCAD.Tables[0].Rows[0]["AdmissionRound"].ToString() == "CAP Round-II")
                //{
                else if (dsCAD.Tables[0].Rows.Count == 1)
                {
                    cntInstituteReportingStatus2.Visible = true;
                    tblAdmissionDetails2.Visible = true;
                    tblNoAdmissionDetails2.Visible = false;
                    lblInstituteAdmitted2.Text = dsCAD.Tables[0].Rows[0]["InstituteAdmitted"].ToString();
                    lblCourseAdmitted2.Text = dsCAD.Tables[0].Rows[0]["CourseAdmitted"].ToString();
                    lblSeatTypeAdmitted2.Text = dsCAD.Tables[0].Rows[0]["SeatTypeAdmitted"].ToString();
                    lblAdmissionRound2.Text = dsCAD.Tables[0].Rows[0]["AdmissionRound"].ToString();
                }
                else if (dsCAD.Tables[0].Rows.Count > 1)
                {
                    cntInstituteReportingStatus2.Visible = true;
                    tblNoAdmissionDetails2.Visible = true;
                    tblAdmissionDetails2.Visible = false;
                    lblAdmissionStatus2.Text = "You have been admitted in more then one courses. Please cancel the extra admission.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnOptionForm3_Click(object sender, EventArgs e)
        {
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            cntOptionForm3.Visible = true;
            tblOptionForm3.Visible = true;
            trOptionFormStatusCAPRound3.Visible = true;

            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                SessionData objSessionData = new SessionData();
                Session["SessionData"] = objSessionData = reg.getSessionDataForCandidate(PID);
                if (objSessionData.EligibleForCAPRound3 == 0)
                {
                    lblOptionFormStatusCAPRound3.ForeColor = System.Drawing.Color.Red;
                    lblOptionFormStatusCAPRound3.Text = "You are Not Eligible to Submit Option Form for CAP Round-III";
                }
                else
                {
                    if (objSessionData.OptionFormStatusCAPRound3 == 'I')
                    {
                        lblOptionFormStatusCAPRound3.ForeColor = System.Drawing.Color.Red;
                        lblOptionFormStatusCAPRound3.Text = "Incomplete Option Form for CAP Round-III";
                    }
                    else if (objSessionData.OptionFormStatusCAPRound3 == 'C')
                    {
                        lblOptionFormStatusCAPRound3.ForeColor = System.Drawing.Color.Red;
                        lblOptionFormStatusCAPRound3.Text = "Complete Option Form for CAP Round-III. Now confirm it";
                    }
                    else if (objSessionData.OptionFormStatusCAPRound3 == 'A')
                    {
                        lblOptionFormStatusCAPRound3.ForeColor = System.Drawing.Color.Green;
                        lblOptionFormStatusCAPRound3.Text = "Option Form for CAP Round-III is Confirmed";
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnAllotmentDetails3_Click(object sender, EventArgs e)
        {
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            cntILReporting.Visible = false;

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                DataSet dsCAD = reg.getAllotmentDetails(PID);
                string BenefitTaken = reg.getBenefitTakenByCandidate(PID, 0);

                if (dsCAD.Tables[2].Rows.Count > 0)
                {
                    string ReportingStatus = dsCAD.Tables[2].Rows[0]["ReportingStatus"].ToString();
                    if (ReportingStatus == "Y" || ReportingStatus == "N" || ReportingStatus == "C")
                    {
                        if (BenefitTaken == "")
                        {
                            trBenefitTaken3.Visible = false;
                        }
                        else
                        {
                            lblBenefitTaken3.Text = BenefitTaken;
                        }
                        cntAllotmentDetails3.Visible = true;
                        tblAllotmentDetails3.Visible = true;
                        tblNoAllotmentDetails3.Visible = false;
                        lblInstituteAllotted3.Text = dsCAD.Tables[2].Rows[0]["InstituteAllotted"].ToString();
                        lblCourseAllotted3.Text = dsCAD.Tables[2].Rows[0]["CourseAllotted"].ToString();
                        lblSeatTypeAllotted3.Text = dsCAD.Tables[2].Rows[0]["SeatTypeAllotted"].ToString();
                        lblPreferenceNoAllotted3.Text = dsCAD.Tables[2].Rows[0]["PreferenceNoAllotted"].ToString();
                    }
                    else
                    {
                        cntAllotmentDetails3.Visible = true;
                        tblAllotmentDetails3.Visible = false;
                        tblNoAllotmentDetails3.Visible = true;
                        lblAllotmentStatus3.Text = "Not Allotted Till Now.";
                    }
                }
                else
                {
                    cntAllotmentDetails3.Visible = true;
                    tblAllotmentDetails3.Visible = false;
                    tblNoAllotmentDetails3.Visible = true;
                    lblAllotmentStatus3.Text = "Not Allotted Till Now.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnSelfArc3_Click(object sender, EventArgs e)
        {
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                DataSet seatAcceptanceGrivance = reg.GetSeatAcceptanceGrivanceStatusByPID(PID);
                string IsGrivanceRaised = "";
                Int16 IsAllotmentCancellationRequired = 0;

                if (seatAcceptanceGrivance.Tables[0].Rows.Count > 0)
                {
                    IsGrivanceRaised = seatAcceptanceGrivance.Tables[0].Rows[0]["IsGrivanceRaised"].ToString();
                    IsAllotmentCancellationRequired = Convert.ToInt16(seatAcceptanceGrivance.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString());
                }
                DataSet dsCAD = reg.getAllotmentDetails(PID);
                if (dsCAD.Tables[2].Rows.Count > 0)
                {
                    string ReportingStatus = dsCAD.Tables[2].Rows[0]["ReportingStatus"].ToString();
                    if (ReportingStatus == "Y" || ReportingStatus == "N" || ReportingStatus == "C")
                    {
                        cntSelfArc3.Visible = true;
                        tblSelfArc3.Visible = true;
                        tblNoSelfArc3.Visible = false;
                        if (IsGrivanceRaised == "" || IsGrivanceRaised == "N" || IsGrivanceRaised == "R" || (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 0))
                        {
                            string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(PID);

                            if (SeatAcceptanceConfirmationStatus == "Y")
                            {
                                btnSeatAcceptance3Step1.Text = "Complete";
                                btnSeatAcceptance3Step1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptance3Step1.Enabled = false;

                                btnSeatAcceptance3Step2.Text = "Complete";
                                btnSeatAcceptance3Step2.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptance3Step2.Enabled = false;

                                btnSeatAcceptance3Step3.Text = "Complete";
                                btnSeatAcceptance3Step3.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptance3Step3.Enabled = false;

                                btnSeatAcceptance3Step4.Text = "Complete";
                                btnSeatAcceptance3Step4.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                            }
                            else
                            {
                                if (!reg.CheckSelfVerificationIsDone(PID))
                                {
                                    if (reg.CheckCandidateinAllotmentCancellationRemark(PID))
                                    {
                                        btnSeatAcceptance3Step1.Text = "Your Allotment is Cancelled";
                                        btnSeatAcceptance3Step1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        btnSeatAcceptance3Step1.Enabled = false;
                                        btnSeatAcceptance3Step2.Text = "Incomplete";
                                        btnSeatAcceptance3Step2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        btnSeatAcceptance3Step2.Enabled = false;
                                        btnSeatAcceptance3Step3.Text = "Incomplete";
                                        btnSeatAcceptance3Step3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        btnSeatAcceptance3Step3.Enabled = false;
                                        btnSeatAcceptance3Step4.Text = "Incomplete";
                                        btnSeatAcceptance3Step4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                        btnSeatAcceptance3Step4.Enabled = false;
                                    }
                                    else
                                    {
                                        btnSeatAcceptance3Step1.Text = "Complete";
                                        btnSeatAcceptance3Step1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                        btnSeatAcceptance3Step1.Enabled = false;
                                    }
                                }
                                else
                                {
                                    btnSeatAcceptance3Step1.Text = "Incomplete";
                                    btnSeatAcceptance3Step1.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptance3Step1.Enabled = false;
                                }
                                DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(PID);
                                if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                                {
                                    btnSeatAcceptance3Step2.Text = "Complete";
                                    btnSeatAcceptance3Step2.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                    btnSeatAcceptance3Step2.Enabled = false;
                                }
                                else
                                {
                                    btnSeatAcceptance3Step2.Text = "Incomplete";
                                    btnSeatAcceptance3Step2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptance3Step2.Enabled = false;
                                }

                                DataSet dsSeatAcceptanceFeeDetails = reg.getSeatAcceptanceFeeList(PID, "Seat Acceptance Fee");
                                if (dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0)
                                {
                                    btnSeatAcceptance3Step3.Text = "Complete";
                                    btnSeatAcceptance3Step3.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                    btnSeatAcceptance3Step3.Enabled = false;
                                }
                                else
                                {
                                    btnSeatAcceptance3Step3.Text = "Incomplete";
                                    btnSeatAcceptance3Step3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptance3Step3.Enabled = false;
                                }
                                if (SeatAcceptanceConfirmationStatus == "Y" && dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0)
                                {
                                    btnSeatAcceptance3Step4.Text = "Complete";
                                    btnSeatAcceptance3Step4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptance3Step4.Enabled = false;
                                }
                                else
                                {
                                    btnSeatAcceptance3Step4.Text = "Incomplete";
                                    btnSeatAcceptance3Step4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                                    btnSeatAcceptance3Step4.Enabled = false;
                                    if (dsSeatAcceptanceFeeDetails.Tables[0].Rows.Count > 0 && dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                                        btnSeatAcceptance3Step4.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            if (IsGrivanceRaised == "Y")
                            {
                                btnSeatAcceptance3Step1.Text = "Grievance Is Raised";
                            }
                            if (IsGrivanceRaised == "P")
                            {
                                btnSeatAcceptance3Step1.Text = "Grievance is Picked for Verification";
                            }
                            if (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 1)
                            {
                                btnSeatAcceptance3Step1.Text = "Your Allotment is Cancelled";
                            }
                            if (IsGrivanceRaised == "A" && IsAllotmentCancellationRequired == 0)
                            {
                                btnSeatAcceptance3Step1.Text = "Your Grievance is Approved";
                            }
                            if (reg.CheckCandidateinAllotmentCancellationRemark(PID))
                            {
                                btnSeatAcceptance3Step1.Text = "Your Allotment is Cancelled";
                                btnSeatAcceptance3Step1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                                btnSeatAcceptance3Step1.Enabled = false;
                            }
                            //btnSeatAcceptanceStep1.Text = "Incomplete";
                            btnSeatAcceptance3Step1.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
                            btnSeatAcceptance3Step1.Enabled = false;
                            btnSeatAcceptance3Step2.Text = "Incomplete";
                            btnSeatAcceptance3Step2.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                            btnSeatAcceptance3Step2.Enabled = false;
                            btnSeatAcceptance3Step3.Text = "Incomplete";
                            btnSeatAcceptance3Step3.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                            btnSeatAcceptance3Step3.Enabled = false;
                            btnSeatAcceptance3Step4.Text = "Incomplete";
                            btnSeatAcceptance3Step4.BackColor = System.Drawing.Color.FromArgb(217, 51, 44);
                            btnSeatAcceptance3Step4.Enabled = false;
                        }
                    }
                    else
                    {
                        cntSelfArc3.Visible = true;
                        tblNoSelfArc3.Visible = true;
                        tblSelfArc3.Visible = false;
                        lblNoSelfArc3Status.Text = "Not Self Verified Till Now.";
                    }
                }
                else
                {
                    cntSelfArc3.Visible = true;
                    tblNoSelfArc3.Visible = true;
                    tblSelfArc3.Visible = false;
                    lblNoSelfArc3Status.Text = "Not Self Verified Till Now.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnInstituteReportingStatus3_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntILReporting.Visible = false;
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                DataSet dsCAD = reg.getCurrentAdmissionDetails(PID);

                if (dsCAD.Tables[0].Rows.Count == 0)
                {
                    cntInstituteReportingStatus3.Visible = true;
                    tblNoAdmissionDetails3.Visible = true;
                    tblAdmissionDetails3.Visible = false;
                    lblAdmissionStatus3.Text = "Not Admitted Till Now.";
                }
                else if (dsCAD.Tables[0].Rows.Count == 1)
                {
                    cntInstituteReportingStatus3.Visible = true;
                    tblAdmissionDetails3.Visible = true;
                    tblNoAdmissionDetails3.Visible = false;
                    lblInstituteAdmitted3.Text = dsCAD.Tables[0].Rows[0]["InstituteAdmitted"].ToString();
                    lblCourseAdmitted3.Text = dsCAD.Tables[0].Rows[0]["CourseAdmitted"].ToString();
                    lblSeatTypeAdmitted3.Text = dsCAD.Tables[0].Rows[0]["SeatTypeAdmitted"].ToString();
                    lblAdmissionRound3.Text = dsCAD.Tables[0].Rows[0]["AdmissionRound"].ToString();
                }
                else if (dsCAD.Tables[0].Rows.Count > 1)
                {
                    cntInstituteReportingStatus3.Visible = true;
                    tblNoAdmissionDetails3.Visible = true;
                    tblAdmissionDetails3.Visible = false;
                    lblAdmissionStatus3.Text = "You have been admitted in more then one courses. Please cancel the extra admission.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnILReporting_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            CntChkGrievance.Visible = false;
            ContentBoxEntranceExamDetails.Visible = false;
            cntPrev.Visible = false;
            cntFail.Visible = false;
            tblApplicationFormStatus.Visible = false;
            tblpaymentmsg.Visible = false;
            ContentBoxDocumentDetails.Visible = false;
            CntChkProvisionMerit.Visible = false;
            cntOptionForm.Visible = false;
            cntAllotmentDetails1.Visible = false;
            cntSelfArc1.Visible = false;
            cntInstituteReportingStatus1.Visible = false;
            cntOptionForm2.Visible = false;
            cntAllotmentDetails2.Visible = false;
            cntSelfArc2.Visible = false;
            cntInstituteReportingStatus2.Visible = false;
            cntOptionForm3.Visible = false;
            cntAllotmentDetails3.Visible = false;
            cntSelfArc3.Visible = false;
            cntInstituteReportingStatus3.Visible = false;
            try
            {
                Int32 ApplicationFeeToBePaid = 0, FeesPaid = 0;
                ApplicationFeeToBePaid = 1000;
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                FeesPaid = reg.getSeatAcceptanceFeePaidAmount(PID);
                //DataSet dsReportingDetails = reg.getReportingDetailsAtIL(PID, ChoiceCode, 'Y');
                //Int32 Count = dsReportingDetails.Tables[0].Rows.Count;               
                //string AdmissionRound = dsCAD.Tables[0].Rows[0]["AdmissionRound"].ToString();
                //if(dsCAD.Tables[0].Rows[0]["AdmissionRound"].ToString() == "IL Level Round")
                //{                                                         
                if (FeesPaid >= ApplicationFeeToBePaid)
                {
                    DataSet dsCAD = reg.getCurrentAdmissionDetails(PID);
                    Int32 Count = dsCAD.Tables[0].Rows.Count;                                   
                    if (dsCAD.Tables[0].Rows.Count == 0)
                    {
                        cntILReporting.Visible = true;
                        tblNOILReporting.Visible = true;
                        tblILReporting.Visible = false;
                        lblNOILReportingStatus.Text = "Not Admitted Till Now.";
                    }
                    else if (dsCAD.Tables[0].Rows.Count == 1)
                    {
                        cntILReporting.Visible = true;
                        tblILReporting.Visible = true;
                        tblNOILReporting.Visible = false;
                        lblInstituteAdmittedIL.Text = dsCAD.Tables[0].Rows[0]["InstituteAdmitted"].ToString();
                        lblCourseAdmittedIL.Text = dsCAD.Tables[0].Rows[0]["CourseAdmitted"].ToString();
                        lblSeatTypeAdmittedIL.Text = dsCAD.Tables[0].Rows[0]["SeatTypeAdmitted"].ToString();
                        lblAdmissionRoundIL.Text = dsCAD.Tables[0].Rows[0]["AdmissionRound"].ToString();
                    }
                    else if (dsCAD.Tables[0].Rows.Count > 1)
                    {
                        cntILReporting.Visible = true;
                        tblNOILReporting.Visible = true;
                        tblILReporting.Visible = false;
                        lblNOILReportingStatus.Text = "You have been admitted in more then one courses. Please cancel the extra admission.";
                    }
                }
                else
                {
                    shInfo.SetMessage("Seat Acceptance Fee is Not Paid Please Pay the Seat Acceptance Fee of Candidate Using the Link Pay SeatAcceptance Fee.", ShowMessageType.Information);
                    cntILReporting.Visible = true;
                    tblNOILReporting.Visible = true;
                    tblILReporting.Visible = false;
                    lblNOILReportingStatus.Text = "Seat Acceptance Fee is Not Paid Please Pay the Seat Acceptance Fee of Candidate Using the Link Pay SeatAcceptance Fee.";
                }
                //}
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}