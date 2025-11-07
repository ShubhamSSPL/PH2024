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

namespace Pharmacy2024.CandidateModuleCAPRound3
{
    public partial class frmConfirmOptionForm : System.Web.UI.Page
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
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (DateTime.Now < Global.OptionFormFillingCAPRound3StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound3EndDateTime)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=2", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsCurrentLink = reg.getCurrentLinkCAPRound3(objSessionData.PID, "frmConfirmOptionForm.aspx");

                    hdnStepID.Value = (objSessionData.StepIDCAPRound3 + 1).ToString();
                    a_1.HRef = objSessionData.StepIDCAPRound3 + 1 >= Convert.ToInt32(a_1.ID.Split('_')[1]) ? "frmShortListOptions.aspx?tms=101" : "#";
                    a_2.HRef = objSessionData.StepIDCAPRound3 + 1 >= Convert.ToInt32(a_2.ID.Split('_')[1]) ? "frmSetPreferences.aspx?tms=101" : "#";
                    a_3.HRef = objSessionData.StepIDCAPRound3 + 1 >= Convert.ToInt32(a_3.ID.Split('_')[1]) ? "frmOptionFormSummary.aspx?tms=101" : "#";
                    a_4.HRef = objSessionData.StepIDCAPRound3 + 1 >= Convert.ToInt32(a_4.ID.Split('_')[1]) ? "frmConfirmOptionForm.aspx?tms=101" : "#";

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if (objSessionData.EligibleForCAPRound3 == 0)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                    }
                    if (objSessionData.OptionFormStatusCAPRound3 == 'A' || objSessionData.StepIDCAPRound3 < 3)
                    {
                        Response.Redirect("../CandidateModuleCAPRound3/frmOptionForm.aspx?tms=101", true);
                    }

                    //txtPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnProceed.ClientID + "')");

                    if (!reg.checkPreferenceNoCAPRound3(objSessionData.PID))
                    {
                        Response.Redirect("../CandidateModuleCAPRound3/frmSetPreferences.aspx?tms=101");
                    }

                    if (!reg.isCandidateSelectedOptionsCAPRound3(objSessionData.PID))
                    {
                        Response.Redirect("../CandidateModuleCAPRound3/frmSetPreferences.aspx?tms=101");
                    }

                    DataSet dsPreferancedOptionsList = reg.getPreferancedOptionsListForDisplayCAPRound3(objSessionData.PID);
                    if (dsPreferancedOptionsList.Tables[0].Rows.Count > 0)
                    {
                        gvPreferencedOptionsList1.DataSource = dsPreferancedOptionsList.Tables[0];
                        gvPreferencedOptionsList1.DataBind();
                    }
                    else
                    {
                        Response.Redirect("../CandidateModuleCAPRound3/frmSetPreferences.aspx?tms=101");
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

                    string strInvalidChoiceCodes = reg.getInvalidChoiceCodeListCAPRound3(objSessionData.PID);

                    if (strInvalidChoiceCodes.Length > 6)
                    {
                        btnProceed.Visible = false;
                        shInfo.SetMessage("List of Invalid Choice Codes : <br />" + strInvalidChoiceCodes + "<br />Please remove these Choice Codes from your Preferences and then Confirm your Option Form.", ShowMessageType.Information);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModuleCAPRound3/frmInsertChoiceCode.aspx?tms=101");
        }
        protected void btnInsertDirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModuleCAPRound3/frmInsertChoiceCodeDirect.aspx?tms=101");
        }
        protected void btnMove_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModuleCAPRound3/frmMoveChoiceCode.aspx?tms=101");
        }
        protected void btnViewInformation_click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplayInOptionForm(objSessionData.PID);

                if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                {
                    lblApplicationID.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblCandidateName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CandidateName"].ToString();
                    lblGender.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["Gender"].ToString();
                    lblDOB.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["DOB"].ToString();
                    lblCandidatureType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                    lblHomeUniversity.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                    lblCategoryForAdmission.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalCategory"].ToString();
                    lblPHType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalPHType"].ToString();
                    lblDefenceType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                    lblAppliedForTFWS.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                    lblMinorityCandidatureType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
                    lblAppliedforEWS.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                    lblAppliedforOrphan.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                }

                if (Global.MasterChoiceCodeStatusCAPRound3.Tables[0].Rows.Count > 0)
                {
                    lblChoiceCodeStatus.Text = "";
                    for (Int32 i = 0; i < Global.MasterChoiceCodeStatusCAPRound3.Tables[0].Rows.Count; i++)
                    {
                        lblChoiceCodeStatus.Text += Global.MasterChoiceCodeStatusCAPRound3.Tables[0].Rows[i]["ChoiceCodeStatusInstructions"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            SessionData objSessionData = (SessionData)Session["SessionData"];
            if (reg.GetPreferancedOptionsListOnlyTFWSSelectCap3(objSessionData.PID))
            {
                contentConfirmation.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowConfirmationBox();", true);
                btnProceed.Visible = false;
            }
            else
            {
                Response.Redirect("../CandidateModuleCAPRound3/frmVerifyAndConfirmOptionForm.aspx?tms=101", true);
            }
            
        }
        protected void btnYes_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Response.Redirect("../CandidateModuleCAPRound3/frmVerifyAndConfirmOptionForm.aspx?tms=101", true);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            btnProceed.Visible = true;
        }
    }
}