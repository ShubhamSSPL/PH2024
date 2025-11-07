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

namespace Pharmacy2024.CandidateModuleCAPRound2
{
    public partial class frmInsertChoiceCode : System.Web.UI.Page
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
            if (DateTime.Now < Global.OptionFormFillingCAPRound2StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound2EndDateTime)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=2", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsCurrentLink = reg.getCurrentLinkCAPRound2(objSessionData.PID, "frmInsertChoiceCode.aspx");

                    hdnStepID.Value = (objSessionData.StepIDCAPRound2 + 1).ToString();
                    a_1.HRef = objSessionData.StepIDCAPRound2 + 1 >= Convert.ToInt32(a_1.ID.Split('_')[1]) ? "frmShortListOptions.aspx?tms=101" : "#";
                    a_2.HRef = objSessionData.StepIDCAPRound2 + 1 >= Convert.ToInt32(a_2.ID.Split('_')[1]) ? "frmSetPreferences.aspx?tms=101" : "#";
                    a_3.HRef = objSessionData.StepIDCAPRound2 + 1 >= Convert.ToInt32(a_3.ID.Split('_')[1]) ? "frmOptionFormSummary.aspx?tms=101" : "#";
                    a_4.HRef = objSessionData.StepIDCAPRound2 + 1 >= Convert.ToInt32(a_4.ID.Split('_')[1]) ? "frmConfirmOptionForm.aspx?tms=101" : "#";

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if (objSessionData.EligibleForCAPRound2 == 0)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                    }
                    if (objSessionData.OptionFormStatusCAPRound2 == 'A' || objSessionData.StepIDCAPRound2 < 2)
                    {
                        Response.Redirect("../CandidateModuleCAPRound2/frmOptionForm.aspx?tms=101", true);
                    }

                    ddlUniversity.DataSource = reg.getUniversityListByPID(2, objSessionData.PID);
                    ddlUniversity.DataTextField = "UniversityName";
                    ddlUniversity.DataValueField = "UniversityID";
                    ddlUniversity.DataBind();
                    ddlUniversity.Items.Insert(0, new ListItem("-- Select University --", "0"));

                    ddlInstitute.Items.Insert(0, new ListItem("-- Select Institute --", "0"));

                    ddlChoiceCode.Items.Insert(0, new ListItem("-- Select Choice Code --", "0"));

                    getPreferencedOptionsList();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public void showPreferenceNo(DropDownList ddlPreferenceNo, Int32 PreferenceCount)
        {
            ddlPreferenceNo.Items.Clear();

            for (Int32 i = 1; i <= PreferenceCount; i++)
            {
                ddlPreferenceNo.Items.Add(i.ToString());
            }
        }
        protected void getPreferencedOptionsList()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                Int32 PreferenceCount = reg.getPreferencesCountCAPRound2(objSessionData.PID);
                showPreferenceNo(ddlPreferenceNo, PreferenceCount);
                ddlPreferenceNo.SelectedValue = PreferenceCount.ToString();

                if (PreferenceCount > 300)
                {
                    btnInsert.Visible = false;
                }

                gvPreferencedOptionsList.DataSource = reg.getPreferancedOptionsListCAPRound2(objSessionData.PID);
                gvPreferencedOptionsList.DataBind();

                if (gvPreferencedOptionsList.Rows.Count > 0)
                {
                    gvPreferencedOptionsList.Visible = true;
                }
                else
                {
                    tblPreferencedOptionsList.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int16 UniversityID = Convert.ToInt16(ddlUniversity.SelectedValue);

                ddlInstitute.DataSource = reg.getInstituteListByUniversityID(2, objSessionData.PID, UniversityID);
                ddlInstitute.DataTextField = "InstituteName";
                ddlInstitute.DataValueField = "InstituteID";
                ddlInstitute.DataBind();
                ddlInstitute.Items.Insert(0, new ListItem("-- Select Institute --", "0"));

                ddlChoiceCode.Items.Clear();
                ddlChoiceCode.Items.Insert(0, new ListItem("-- Select Choice Code --", "0"));
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int32 InstituteID = Convert.ToInt32(ddlInstitute.SelectedValue);

                ddlChoiceCode.DataSource = reg.getChoiceCodeListByInstituteID(2, objSessionData.PID, InstituteID);
                ddlChoiceCode.DataTextField = "ChoiceCodeDisplay";
                ddlChoiceCode.DataValueField = "ChoiceCode";
                ddlChoiceCode.DataBind();
                ddlChoiceCode.Items.Insert(0, new ListItem("-- Select Choice Code --", "0"));
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnInsert_click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int32 PreferenceNo = Convert.ToInt32(ddlPreferenceNo.SelectedValue);
                Int64 ChoiceCode = Convert.ToInt64(ddlChoiceCode.SelectedValue);
                Int32 InstituteID = Convert.ToInt32(ddlInstitute.SelectedValue);

                switch (reg.insertOptionCAPRound2(objSessionData.PID, PreferenceNo, ChoiceCode, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    case 0:
                        shInfo.SetMessage("Invalid Choice Code or You are not eligible to fill this Choice Code.", ShowMessageType.Information);
                        break;
                    case 1:
                        shInfo.SetMessage("This Choice Code is already added.", ShowMessageType.Information);
                        break;
                    case 2:
                        objSessionData.StepIDCAPRound2 = 4;
                        objSessionData.OptionFormStatusCAPRound2 = 'A';
                        Session["SessionData"] = objSessionData;

                        Response.Redirect("../CandidateModuleCAPRound2/frmOptionForm.aspx?tms=101");
                        break;
                    case 3:
                        getPreferencedOptionsList();

                        ddlChoiceCode.DataSource = reg.getChoiceCodeListByInstituteID(2, objSessionData.PID, InstituteID);
                        ddlChoiceCode.DataTextField = "ChoiceCodeDisplay";
                        ddlChoiceCode.DataValueField = "ChoiceCode";
                        ddlChoiceCode.DataBind();
                        ddlChoiceCode.Items.Insert(0, new ListItem("-- Select Choice Code --", "0"));

                        shInfo.SetMessage("Choice Code Added Successfully.", ShowMessageType.Information);
                        break;
                    default:
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.TechnicalError);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnMove_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModuleCAPRound2/frmMoveChoiceCode.aspx?tms=101");
        }
        protected void btnInsertDirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModuleCAPRound2/frmInsertChoiceCodeDirect.aspx?tms=101");
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

                if (Global.MasterChoiceCodeStatusCAPRound2.Tables[0].Rows.Count > 0)
                {
                    lblChoiceCodeStatus.Text = "";
                    for (Int32 i = 0; i < Global.MasterChoiceCodeStatusCAPRound2.Tables[0].Rows.Count; i++)
                    {
                        lblChoiceCodeStatus.Text += Global.MasterChoiceCodeStatusCAPRound2.Tables[0].Rows[i]["ChoiceCodeStatusInstructions"].ToString();
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
            try
            {
                if (gvPreferencedOptionsList.Rows.Count > 0)
                {
                    Response.Redirect("../CandidateModuleCAPRound2/frmOptionFormSummary.aspx?tms=101");
                }
                else
                {
                    shInfo.SetMessage("Please Add Atleast One Choice Code.", ShowMessageType.Information);
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