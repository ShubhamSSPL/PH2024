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

namespace Pharmacy2024.InstituteModule
{
    public partial class frmAdmissionCancellationLetterAtIL : System.Web.UI.Page
    {
        public Int64 PID = 0;
        public Int64 ChoiceCode = 0;
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageInstitute.aspx", true);
                    }

                    ChoiceCode = Convert.ToInt64(Request.QueryString["ChoiceCode"].ToString());
                    DataSet dsPersonalInformation = reg.getPersonalInformationForInstitute(PID);

                    lblApplicationID.Text = dsPersonalInformation.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblCandidateName.Text = lblDeclarationName.Text = dsPersonalInformation.Tables[0].Rows[0]["CandidateName"].ToString().ToUpper();
                    lblGender.Text = dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString();
                    lblDOB.Text = dsPersonalInformation.Tables[0].Rows[0]["DOB"].ToString();
                    lblCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                    lblHomeUniversity.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                    lblOriginalCategory.Text = dsPersonalInformation.Tables[0].Rows[0]["Category"].ToString();
                    lblCategoryForAdmission.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCategory"].ToString();
                    lblAppliedForEWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                    lblAppliedForOrphan.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                    lblPHType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString();
                    lblDefenceType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                    lblLinguisticMinority.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalLinguisticMinority"].ToString();
                    lblReligiousMinority.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalReligiousMinority"].ToString();
                    lblHSCEligibilityPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCEligibilityPercentage"].ToString() + " %";
                    lblAppliedForTFWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();

                    if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["DiplomaEligibilityPercentage"].ToString()) > 0)
                    {
                        lblDiplomaEligibilityPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["DiplomaEligibilityPercentage"].ToString() + " %";
                    }
                    else
                    {
                        lblDiplomaEligibilityPercentage.Text = "--";
                    }

                    DataSet dsReportingDetails = reg.getReportingDetailsAtIL(PID, ChoiceCode, 'C');
                    Int32 Count = dsReportingDetails.Tables[0].Rows.Count;

                    if (Count == 0)
                    {
                        shInfo.SetMessage("Admission of this candidate is not cancelled. So you can not print admission cancellation letter.", ShowMessageType.Information);
                    }
                    else if (Count == 1)
                    {
                        lblReceiptNo.Text += dsReportingDetails.Tables[0].Rows[0]["CancellationReceiptNo"].ToString();

                        lblMeritNo.Text = dsReportingDetails.Tables[0].Rows[0]["MeritNo"].ToString();
                        lblMeritMarks.Text = dsReportingDetails.Tables[0].Rows[0]["MeritMarks"].ToString();
                        lblInstituteName.Text = dsReportingDetails.Tables[0].Rows[0]["InstituteAllotted"].ToString();
                        lblCourseName.Text = dsReportingDetails.Tables[0].Rows[0]["CourseAllotted"].ToString();
                        lblChoiceCode.Text = dsReportingDetails.Tables[0].Rows[0]["ChoiceCodeAllotted"].ToString();
                        lblSeatType.Text = dsReportingDetails.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                        lblCancellationCharge.Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(dsReportingDetails.Tables[0].Rows[0]["CancellationCharge"].ToString())) + "/-";

                        gvFeePaidList.DataSource = reg.getInstituteFeeList(PID, "Fee", dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString(), "IL");
                        gvFeePaidList.DataBind();
                        for (Int32 i = 0; i < gvFeePaidList.Rows.Count; i++)
                        {
                            gvFeePaidList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            gvFeePaidList.Rows[i].Cells[2].Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(gvFeePaidList.Rows[i].Cells[2].Text)) + "/-";
                        }
                        if (gvFeePaidList.Rows.Count == 0)
                        {
                            trFeePaid1.Visible = false;
                            trFeePaid2.Visible = false;
                        }

                        gvFeeRefundList.DataSource = reg.getInstituteFeeList(PID, "Refund", dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString(), "IL");
                        gvFeeRefundList.DataBind();
                        for (Int32 i = 0; i < gvFeeRefundList.Rows.Count; i++)
                        {
                            gvFeeRefundList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            gvFeeRefundList.Rows[i].Cells[2].Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(gvFeeRefundList.Rows[i].Cells[2].Text)) + "/-";
                        }
                        if (gvFeeRefundList.Rows.Count == 0)
                        {
                            trFeeRefund1.Visible = false;
                            trFeeRefund2.Visible = false;
                        }

                        if (dsReportingDetails.Tables[0].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                        {
                            trReasonForCancellation.Visible = true;
                            lblComments.Text += dsReportingDetails.Tables[0].Rows[0]["ReasonForCancellation"].ToString();
                        }
                        lblPrintedBy.Text = Session["UserLoginID"].ToString();
                        lblCancelledBy.Text = dsReportingDetails.Tables[0].Rows[0]["CancelledBy"].ToString();
                        DateTime CancelledDateTime = Convert.ToDateTime(dsReportingDetails.Tables[0].Rows[0]["CancelledDateTime"].ToString());
                        lblCancelledOn.Text = CancelledDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", CancelledDateTime);
                        lblCancelledByIPAddress.Text = dsReportingDetails.Tables[0].Rows[0]["CancelledByIPAddress"].ToString();
                        lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                        DateTime CancellationRequestedOn = Convert.ToDateTime(dsReportingDetails.Tables[0].Rows[0]["InterestShownInAdmissionCancellationDateTime"].ToString());
                        lblCancellationRequestedOn.Text = CancellationRequestedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", CancellationRequestedOn);
                        lblCancellationRequestedByIPAddress.Text = dsReportingDetails.Tables[0].Rows[0]["InterestShownInAdmissionCancellationByIPAddress"].ToString();
                    }
                    else if (Count > 1)
                    {
                        shInfo.SetMessage("Admission of this candidate is cancelled in more then one courses. So please contact to CET.", ShowMessageType.Information);
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