using BusinessLayer;
using EntityModel;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModuleCAPRound4
{
    public partial class frmPrintOptionForm : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;
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
                        SessionData objSessionData = (SessionData)Session["SessionData"];
                        DataSet dsPersonalInformation = reg.getPersonalInformationCAPRound4(objSessionData.PID);

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
                        lblAppliedForTFWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                        lblMinorityCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
                        lblAppliedforEWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                        lblAppliedforOrphan.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                        DataSet dsPreferancedOptionsList = reg.getPreferancedOptionsListForDisplayCAPRound4(objSessionData.PID);
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

                        DataSet dsInstructions = reg.getInstructionsCAPRound4(objSessionData.PID);
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

                        DataSet dsOptionFormConfirmationDetails = reg.getOptionFormConfirmationDetailsCAPRound4(objSessionData.PID);
                        DateTime ConfirmedDateTime = Convert.ToDateTime(dsOptionFormConfirmationDetails.Tables[0].Rows[0]["ConfirmedDateTime"].ToString());
                        lblConfirmedOn.Text = ConfirmedDateTime.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", ConfirmedDateTime);
                        lblConfirmedBy.Text = dsOptionFormConfirmationDetails.Tables[0].Rows[0]["ConfirmedBy"].ToString() + ", " + dsOptionFormConfirmationDetails.Tables[0].Rows[0]["ConfirmedByIPAddress"].ToString();
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