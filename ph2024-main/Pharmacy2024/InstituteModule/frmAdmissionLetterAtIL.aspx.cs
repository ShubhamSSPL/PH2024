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
    public partial class frmAdmissionLetterAtIL : System.Web.UI.Page
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
                    lblNameAsPerHSCResult.Text = dsPersonalInformation.Tables[0].Rows[0]["NameAsPerHSCResult"].ToString();
                    lblNameAsPerHSCResult.ForeColor = System.Drawing.Color.Red;
                    lblCETCandidateName.Text = dsPersonalInformation.Tables[0].Rows[0]["CETCandidateName"].ToString();
                    lblCETCandidateName.ForeColor = System.Drawing.Color.Blue;
                    if (dsPersonalInformation.Tables[0].Rows[0]["CETCandidateName"].ToString() == "")
                    {
                        lblCETCandidateName.Text = "-- (Not Appeared for Exam)";
                    }
                    lblNEETName.Text = dsPersonalInformation.Tables[0].Rows[0]["NEETCName"].ToString();
                    lblNEETName.ForeColor = System.Drawing.Color.DarkOrange;
                    if (dsPersonalInformation.Tables[0].Rows[0]["NEETCName"].ToString() == "")
                    {
                        lblNEETName.Text = "-- (Not Appeared for Exam)";
                    }
                    if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["DiplomaEligibilityPercentage"].ToString()) > 0)
                    {
                        lblDiplomaEligibilityPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["DiplomaEligibilityPercentage"].ToString() + " %";
                    }
                    else
                    {
                        lblDiplomaEligibilityPercentage.Text = "--";
                    }
                    if (dsPersonalInformation.Tables[0].Rows[0]["CETPCMBMAX"].ToString() == "0")
                    {
                        lblCETPCMBMAX.Text = "-";
                    }
                    else
                    {
                        lblCETPCMBMAX.Text = dsPersonalInformation.Tables[0].Rows[0]["CETPCMBMAX"].ToString();
                    }

                    if (dsPersonalInformation.Tables[0].Rows[0]["NEETTotalScore"].ToString() == "0.0000000")
                    {
                        lblNEETTotal.Text = "-";
                    }
                    else
                    {
                        lblNEETTotal.Text = dsPersonalInformation.Tables[0].Rows[0]["NEETTotalScore"].ToString();
                    }

                    if (dsPersonalInformation.Tables[0].Rows[0]["StateGeneralMeritNo"].ToString() == "0")
                    {
                        lblStateGeneralMeritNo.Text = "-";
                    }
                    else
                    {
                        lblStateGeneralMeritNo.Text = dsPersonalInformation.Tables[0].Rows[0]["StateGeneralMeritNo"].ToString();
                    }

                    if (dsPersonalInformation.Tables[0].Rows[0]["AIMeritNo"].ToString() == "0")
                    {
                        lblAIMertiNo.Text = "-";
                    }
                    else
                    {
                        lblAIMertiNo.Text = dsPersonalInformation.Tables[0].Rows[0]["AIMeritNo"].ToString();
                    }
                    DataSet dsReportingDetails = reg.getReportingDetailsAtIL(PID, ChoiceCode, 'Y');
                    Int32 Count = dsReportingDetails.Tables[0].Rows.Count;

                    if (Count == 0)
                    {
                        shInfo.SetMessage("Admission of this candidate is not confirmed. So you can not print admission letter.", ShowMessageType.Information);
                    }
                    else if (Count == 1)
                    {
                        lblReceiptNo.Text += dsReportingDetails.Tables[0].Rows[0]["ReceiptNo"].ToString();

                        lblMeritNo.Text = dsReportingDetails.Tables[0].Rows[0]["MeritNo"].ToString();
                        lblMeritMarks.Text = dsReportingDetails.Tables[0].Rows[0]["MeritMarks"].ToString();
                        lblInstituteName.Text = dsReportingDetails.Tables[0].Rows[0]["InstituteAllotted"].ToString();
                        lblCourseName.Text = dsReportingDetails.Tables[0].Rows[0]["CourseAllotted"].ToString();
                        lblChoiceCode.Text = dsReportingDetails.Tables[0].Rows[0]["ChoiceCodeAllotted"].ToString();
                        lblSeatType.Text = dsReportingDetails.Tables[0].Rows[0]["SeatTypeAllottedDisplay"].ToString();
                        lblAdmissionDate.Text = dsReportingDetails.Tables[0].Rows[0]["AdmissionDate"].ToString();

                        gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Fee", dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString(), "IL");
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
                    else if (Count > 1)
                    {
                        shInfo.SetMessage("This candidate is admitted in more then one courses. So please contact to DTE.", ShowMessageType.Information);
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