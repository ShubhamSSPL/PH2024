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

namespace Pharmacy2024.CandidateAdmissionReportingModule
{
    public partial class frmPrintProformaO : System.Web.UI.Page
    {
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
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    Int64 ChoiceCode = Convert.ToInt64(Request.QueryString["ChoiceCode"]);
                    Int32 CAPRound = Convert.ToInt32(Request.QueryString["CAPRound"]);
                    DataSet dsPersonalInformation = reg.getPersonalInformationForInstitute(objSessionData.PID);
                    DataSet dsReportingDetails = reg.getRequestedForAdmissionCancellationChoiceCodeDetails(objSessionData.PID, ChoiceCode, CAPRound);

                    lblApplicationID.Text = dsPersonalInformation.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblCandidateName.Text = lblDeclarationName.Text = dsPersonalInformation.Tables[0].Rows[0]["CandidateName"].ToString().ToUpper();
                    lblGender.Text = dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString();
                    lblDOB.Text = dsPersonalInformation.Tables[0].Rows[0]["DOB"].ToString();

                    if (dsReportingDetails.Tables[0].Rows.Count > 0)
                    {
                        lblInstituteName.Text = dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString() + " - " + dsReportingDetails.Tables[0].Rows[0]["InstituteName"].ToString();
                        lblCourseName.Text = dsReportingDetails.Tables[0].Rows[0]["ChoiceCodeDisplay"].ToString() + " - " + dsReportingDetails.Tables[0].Rows[0]["CourseName"].ToString();
                        lblSeatType.Text = dsReportingDetails.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                        lblPreferenceNo.Text = dsReportingDetails.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString();
                        lblAdmissionDate.Text = dsReportingDetails.Tables[0].Rows[0]["AdmissionDate"].ToString();
                        lblAdmittedThrough.Text = dsReportingDetails.Tables[0].Rows[0]["AdmittedThrough"].ToString();

                        gvFeeList.DataSource = reg.getInstituteFeeList(objSessionData.PID, "Fee", dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString(), CAPRound == 7 ? "IL" : "CAP");
                        gvFeeList.DataBind();

                        for (Int32 i = 0; i < gvFeeList.Rows.Count; i++)
                        {
                            gvFeeList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        }
                        if (gvFeeList.Rows.Count == 0)
                        {
                            trFee1.Visible = false;
                            trFee2.Visible = false;
                        }

                        DateTime OnlineCancelledDateTime = Convert.ToDateTime(dsReportingDetails.Tables[0].Rows[0]["InterestShownInAdmissionCancellationDateTime"].ToString());
                        lblOnlineCancelledOn.Text = OnlineCancelledDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", OnlineCancelledDateTime);
                        lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
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