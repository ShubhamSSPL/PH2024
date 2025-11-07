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

namespace Pharmacy2024.AdminModule
{
    public partial class CandidateApplicationFormStaus : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                    LoadApplicationFormStatus(PID);
                    DataSet dsEligibilityRemark = reg.getEligibilityFlag(PID);
                    if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Length > 0 && dsEligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && dsEligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                    {
                        trEligibilityRemark.Visible = true;
                        lblEligibilityRemark.Text += dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void LoadApplicationFormStatus(Int64 PID)
        {
            string strVerificationMode = reg.CheckCandidateFCVerificationFor(PID);

            DataSet statusDs = reg.getVerificationFlags(PID);
            char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
            char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
            char IsLockedByCandidate = Convert.ToChar(statusDs.Tables[0].Rows[0]["IsLockedByCandidate"].ToString());

            string FCVerificationStatusDate = statusDs.Tables[0].Rows[0]["FCVerificationStatusDate"].ToString();
            string ApplicationFormStatusDate = statusDs.Tables[0].Rows[0]["ApplicationFormStatusDate"].ToString();
            string LockDate = statusDs.Tables[0].Rows[0]["LockDate"].ToString();

            string FCVerificationModifiedBy = statusDs.Tables[0].Rows[0]["FCVerificationModifiedBy"].ToString();
            string ApplicationFormStatusModifiedBy = statusDs.Tables[0].Rows[0]["ApplicationFormStatusModifiedBy"].ToString();

            tblApplicationFormStatus.Visible = true;

            if (strVerificationMode == "E") //For EVerification
            {
                string strMappedFC = "";
                string strMappedTime = "";
                DataSet dsEScr = reg.GetCandidateEFCAllotted(PID);
                if (dsEScr.Tables[0].Rows.Count > 0)
                {
                    strMappedFC = dsEScr.Tables[0].Rows[0]["AFCName"].ToString();
                    strMappedTime = Convert.ToDateTime(dsEScr.Tables[0].Rows[0]["CreatedOn"]).ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", Convert.ToDateTime(dsEScr.Tables[0].Rows[0]["CreatedOn"]));
                }

                if (ApplicationFormStatus == 'I' && FCVerificationStatus == 'N')
                {
                    lblDiscrepancyStatus.Text = "Your Application Form is InComplete, Please Fill the Complete Application Form for E-Verification and Confirmation.";
                }
                else if ((ApplicationFormStatus == 'C' || ApplicationFormStatus == 'A') && FCVerificationStatus == 'N')
                {
                    if (reg.CheckFCVerificationStatusForResubmission(PID))
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
                        // btnProceedToCompleteApplicationForm.Visible = false;
                    }
                    else
                    {
                        if (IsLockedByCandidate == 'N' && (ApplicationFormStatus == 'C' || ApplicationFormStatus == 'A') && FCVerificationStatus == 'N')
                        {
                            lblDiscrepancyStatus.Text = "Your Application Form is Completed, Please Lock and Submit for E-Verification(E-Scrutiny).";
                            trSubmitButton.Visible = true;
                            //btnProceedToCompleteApplicationForm.Visible = false;
                        }
                        else
                        {
                            //lblDiscrepancyStatus.Text = "Your Application Form is Completed and Sent to " + strMappedFC + " on " + strMappedTime + " for E-Verification(E-Scrutiny).";
                            lblDiscrepancyStatus.Text = "Your Application Form is Completed and Sent to SC for E-Verification(E-Scrutiny)-It will be verified soon.";
                            //btnProceedToCompleteApplicationForm.Visible = false;
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
                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(PID);
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
                                btnStep.Visible = false;
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
                    //btnProceedToCompleteApplicationForm.Visible = false;
                }
                else if (ApplicationFormStatus == 'A' && FCVerificationStatus == 'C')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed by " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ". Please Check the Acknowledgement.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Verified and Confirmed Please Check the Acknowledgement.";
                    lblDiscrepancyStatus.ForeColor = System.Drawing.Color.Green;

                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(PID);
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

                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(PID);
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
                    //btnProceedToCompleteApplicationForm.Visible = false;

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

                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(PID);
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
                    //btnProceedToCompleteApplicationForm.Visible = false;

                }
                else if (ApplicationFormStatus == 'P' && FCVerificationStatus == 'U')
                {
                    //lblDiscrepancyStatus.Text = "Your Application Form is Unlocked By " + FCVerificationModifiedBy + " on " + FCVerificationStatusDate + ", on your Request(Grievance Raised) for Corrections. Please Edit the Application Form and ReSubmit it.";
                    lblDiscrepancyStatus.Text = "Your Application Form is Unlocked on your Request(Grievance Raised) for Corrections. Please Edit the Application Form and ReSubmit it.";
                    DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(PID);
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
                    //btnProceedToCompleteApplicationForm.Visible = false;
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
                    DataSet ds = reg.GetCandidateBookingSlotDetails(PID);
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
        }
    }
}