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
    public partial class frmOptionFormCAPRound4 : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;
        public Int64 PID = 0;
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
            try
            {
                if (!IsPostBack)
                {
                    PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }

                    DataSet dsPersonalInformation = reg.getPersonalInformationCAPRound4(PID);

                    lblApplicationID.Text += dsPersonalInformation.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblVersionNo.Text += dsPersonalInformation.Tables[0].Rows[0]["VersionNoCAPRound4"].ToString();

                    lblCandidateName.Text = lblDeclarationName.Text = dsPersonalInformation.Tables[0].Rows[0]["CandidateName"].ToString();
                    lblFatherName.Text = dsPersonalInformation.Tables[0].Rows[0]["FatherName"].ToString();
                    lblMotherName.Text = dsPersonalInformation.Tables[0].Rows[0]["MotherName"].ToString();
                    lblGender.Text = dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString();
                    lblDOB.Text = dsPersonalInformation.Tables[0].Rows[0]["DOB"].ToString();
                    lblCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                    lblHomeUniversity.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                    lblOriginalCategory.Text = dsPersonalInformation.Tables[0].Rows[0]["OriginalCategory"].ToString();
                    lblCategoryForAdmission.Text = dsPersonalInformation.Tables[0].Rows[0]["CategoryForAdmission"].ToString();
                    lblPHType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString();
                    lblDefenceType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                    lblMinorityCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();

                    DataSet dsPreferancedOptionsList = reg.getPreferancedOptionsListForDisplayCAPRound4(PID);
                    if (dsPreferancedOptionsList.Tables[0].Rows.Count > 0)
                    {
                        gvPreferencedOptionsList1.DataSource = dsPreferancedOptionsList.Tables[0];
                        gvPreferencedOptionsList1.DataBind();
                    }
                    if (dsPreferancedOptionsList.Tables[1].Rows.Count > 0)
                    {
                        gvPreferencedOptionsList2.DataSource = dsPreferancedOptionsList.Tables[1];
                        gvPreferencedOptionsList2.DataBind();
                    }
                    if (dsPreferancedOptionsList.Tables[2].Rows.Count > 0)
                    {
                        gvPreferencedOptionsList3.DataSource = dsPreferancedOptionsList.Tables[2];
                        gvPreferencedOptionsList3.DataBind();
                    }
                    if (dsPreferancedOptionsList.Tables[3].Rows.Count > 0)
                    {
                        gvPreferencedOptionsList4.DataSource = dsPreferancedOptionsList.Tables[3];
                        gvPreferencedOptionsList4.DataBind();
                    }

                    DataSet dsInstructions = reg.getInstructionsCAPRound4(PID);
                    if (dsInstructions.Tables[0].Rows.Count > 0)
                    {
                        lblInstructions.Text = "<b>Instructions :</b><ol class='list-text'>";
                        for (int i = 0; i < dsInstructions.Tables[0].Rows.Count; i++)
                        {
                            lblInstructions.Text += dsInstructions.Tables[0].Rows[i]["ChoiceCodeStatusInstructions"].ToString();
                        }
                        lblInstructions.Text += "</ol>";
                    }
                    else
                    {
                        trInstructions.Visible = false;
                    }

                    lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                    DateTime LastModifiedOn = Convert.ToDateTime(dsPersonalInformation.Tables[0].Rows[0]["LastModifiedOnCAPRound4"].ToString());
                    lblLastModifiedOn.Text = LastModifiedOn.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", LastModifiedOn);
                    lblLastModifiedBy.Text = dsPersonalInformation.Tables[0].Rows[0]["LastModifiedByCAPRound4"].ToString() + ", " + dsPersonalInformation.Tables[0].Rows[0]["LastModifiedByIPAddressCAPRound4"].ToString();

                    DataSet dsOptionFormConfirmationDetails = reg.getOptionFormConfirmationDetailsCAPRound4(PID);
                    DateTime ConfirmedDateTime = Convert.ToDateTime(dsOptionFormConfirmationDetails.Tables[0].Rows[0]["ConfirmedDateTime"].ToString());
                    lblConfirmedOn.Text = ConfirmedDateTime.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", ConfirmedDateTime);
                    lblConfirmedBy.Text = dsOptionFormConfirmationDetails.Tables[0].Rows[0]["ConfirmedBy"].ToString() + ", " + dsOptionFormConfirmationDetails.Tables[0].Rows[0]["ConfirmedByIPAddress"].ToString();
                }
            }
            catch (Exception ex)
            {
                shInfo.Visible = true;
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}