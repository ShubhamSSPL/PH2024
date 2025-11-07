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
    public partial class frmPrintAdmissionLetter : System.Web.UI.Page
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
                        lblNameAsPerHSCResult.Text = dsPersonalInformation.Tables[0].Rows[0]["NameAsPerHSCResult"].ToString();
                        lblNameAsPerHSCResult.ForeColor = System.Drawing.Color.Red;
                        lblCETCandidateName.Text = dsPersonalInformation.Tables[0].Rows[0]["CETCandidateName"].ToString();
                        lblCETCandidateName.ForeColor = System.Drawing.Color.Blue;
                        if (dsPersonalInformation.Tables[0].Rows[0]["CETCandidateName"].ToString() == "")
                        {
                            lblCETCandidateName.Text = "Not Appeared";
                        }
                        lblNEETName.Text = dsPersonalInformation.Tables[0].Rows[0]["NEETCName"].ToString();
                        lblNEETName.ForeColor = System.Drawing.Color.DarkOrange;
                        if (dsPersonalInformation.Tables[0].Rows[0]["NEETCName"].ToString() == "")
                        {
                            lblNEETName.Text = "Not Appeared";
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
                        DataSet dsReportingDetails = reg.getReportingDetailsByChoiceCode(PID, ChoiceCode, CAPRound, 'Y');

                        lblReceiptNo.Text += dsReportingDetails.Tables[0].Rows[0]["ReceiptNo"].ToString();

                        lblMeritNo.Text = dsReportingDetails.Tables[0].Rows[0]["MeritNo"].ToString();
                        lblMeritMarks.Text = dsReportingDetails.Tables[0].Rows[0]["MeritMarks"].ToString();
                        lblInstituteName.Text = dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString() + " - " + dsReportingDetails.Tables[0].Rows[0]["InstituteName"].ToString();
                        lblCourseName.Text = dsReportingDetails.Tables[0].Rows[0]["CourseName"].ToString();
                        lblChoiceCode.Text = dsReportingDetails.Tables[0].Rows[0]["ChoiceCodeDisplay"].ToString();
                        lblSeatType.Text = dsReportingDetails.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                        lblPreferenceNo.Text = dsReportingDetails.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString();
                        lblAdmissionDate.Text = dsReportingDetails.Tables[0].Rows[0]["AdmissionDate"].ToString();

                        gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Fee", dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString(), "CAP");
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

                        gvDocumentsSubmitted.DataSource = reg.getDocumentListForInstitute(PID, "Y");
                        gvDocumentsSubmitted.DataBind();
                        if (gvDocumentsSubmitted.Rows.Count > 0)
                        {
                            for (Int32 i = 0; i < gvDocumentsSubmitted.Rows.Count; i++)
                            {
                                gvDocumentsSubmitted.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            }
                        }
                        else
                        {
                            trDocumentsSubmitted1.Visible = false;
                            trDocumentsSubmitted2.Visible = false;
                        }

                        gvDocumentsNotSubmitted.DataSource = reg.getDocumentListForInstitute(PID, "N");
                        gvDocumentsNotSubmitted.DataBind();
                        if (gvDocumentsNotSubmitted.Rows.Count > 0)
                        {
                            for (Int32 i = 0; i < gvDocumentsNotSubmitted.Rows.Count; i++)
                            {
                                gvDocumentsNotSubmitted.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            }
                        }
                        else
                        {
                            trDocumentsNotSubmitted1.Visible = false;
                            trDocumentsNotSubmitted2.Visible = false;
                        }

                        if (dsReportingDetails.Tables[0].Rows[0]["Comments"].ToString().Length > 0)
                        {
                            trComments.Visible = true;
                            lblComments.Text += dsReportingDetails.Tables[0].Rows[0]["Comments"].ToString();
                        }
                        lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                        lblPrintedBy.Text = Session["UserLoginID"].ToString();
                        lblReportedBy.Text = dsReportingDetails.Tables[0].Rows[0]["ReportedBy"].ToString() + " ," + dsReportingDetails.Tables[0].Rows[0]["ReportedByIPAddress"].ToString();
                        DateTime ReportedDateTime = Convert.ToDateTime(dsReportingDetails.Tables[0].Rows[0]["ReportedDateTime"].ToString());
                        lblReportedOn.Text = ReportedDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ReportedDateTime);
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