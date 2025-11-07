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
    public partial class frmPrintAdmissionCancellationLetter : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
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
                if (Session["UserLoginID"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                }
                if (!IsPostBack)
                {
                    try
                    {
                        Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                        Int64 ChoiceCode = Convert.ToInt64(Request.QueryString["ChoiceCode"].ToString());
                        Int32 CAPRound = Convert.ToInt32(Request.QueryString["CAPRound"].ToString());
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
                        lblAppliedForTFWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();

                        DataSet dsReportingDetails = reg.getReportingDetailsByChoiceCode(PID, ChoiceCode, CAPRound, 'C');

                        lblReceiptNo.Text += dsReportingDetails.Tables[0].Rows[0]["CancellationReceiptNo"].ToString();
                        lblMeritNo.Text = dsReportingDetails.Tables[0].Rows[0]["MeritNo"].ToString();
                        lblMeritMarks.Text = dsReportingDetails.Tables[0].Rows[0]["MeritMarks"].ToString();
                        lblInstituteName.Text = dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString() + " - " + dsReportingDetails.Tables[0].Rows[0]["InstituteName"].ToString();
                        lblCourseName.Text = dsReportingDetails.Tables[0].Rows[0]["CourseName"].ToString();
                        lblChoiceCode.Text = dsReportingDetails.Tables[0].Rows[0]["ChoiceCodeDisplay"].ToString();
                        lblSeatType.Text = dsReportingDetails.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                        lblPreferenceNo.Text = dsReportingDetails.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString();
                        lblCancellationCharge.Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(dsReportingDetails.Tables[0].Rows[0]["CancellationCharge"].ToString())) + "/-";

                        gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Refund", dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString(), "CAP");
                        gvFeeList.DataBind();

                        for (Int32 i = 0; i < gvFeeList.Rows.Count; i++)
                        {
                            gvFeeList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            gvFeeList.Rows[i].Cells[2].Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text)) + "/-";
                        }
                        if (gvFeeList.Rows.Count == 0)
                        {
                            trFee1.Visible = false;
                            trFee2.Visible = false;
                        }

                        if (dsReportingDetails.Tables[0].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                        {
                            trReasonForCancellation.Visible = true;
                            lblComments.Text += dsReportingDetails.Tables[0].Rows[0]["ReasonForCancellation"].ToString();
                        }
                        lblPrintedBy.Text = Session["UserLoginID"].ToString();
                        lblCancelledBy.Text = dsReportingDetails.Tables[0].Rows[0]["CancelledBy"].ToString() + " ," + dsReportingDetails.Tables[0].Rows[0]["CancelledByIPAddress"].ToString();
                        DateTime CancelledDateTime = Convert.ToDateTime(dsReportingDetails.Tables[0].Rows[0]["CancelledDateTime"].ToString());
                        lblCancelledOn.Text = CancelledDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", CancelledDateTime);
                        lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                        DateTime CancellationRequestedOn = Convert.ToDateTime(dsReportingDetails.Tables[0].Rows[0]["InterestShownInAdmissionCancellationDateTime"].ToString());
                        lblCancellationRequestedOn.Text = CancellationRequestedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", CancellationRequestedOn);
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