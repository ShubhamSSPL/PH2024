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

namespace Pharmacy2024.CandidateModuleCAPRound1
{
    public partial class frmInsertChoiceCodeDirect : System.Web.UI.Page
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
            if (DateTime.Now < Global.OptionFormFillingCAPRound1StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound1EndDateTime)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=2", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsCurrentLink = reg.getCurrentLinkCAPRound1(objSessionData.PID, "frmInsertChoiceCodeDirect.aspx");

                    hdnStepID.Value = (objSessionData.StepIDCAPRound1 + 1).ToString();
                    a_1.HRef = objSessionData.StepIDCAPRound1 + 1 >= Convert.ToInt32(a_1.ID.Split('_')[1]) ? "frmShortListOptions.aspx?tms=101" : "#";
                    a_2.HRef = objSessionData.StepIDCAPRound1 + 1 >= Convert.ToInt32(a_2.ID.Split('_')[1]) ? "frmSetPreferences.aspx?tms=101" : "#";
                    a_3.HRef = objSessionData.StepIDCAPRound1 + 1 >= Convert.ToInt32(a_3.ID.Split('_')[1]) ? "frmOptionFormSummary.aspx?tms=101" : "#";
                    a_4.HRef = objSessionData.StepIDCAPRound1 + 1 >= Convert.ToInt32(a_4.ID.Split('_')[1]) ? "frmConfirmOptionForm.aspx?tms=101" : "#";

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if (objSessionData.EligibleForCAPRound1 == 0)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                    }
                    if (objSessionData.OptionFormStatusCAPRound1 == 'A' || objSessionData.StepIDCAPRound1 < 2)
                    {
                        Response.Redirect("../CandidateModuleCAPRound1/frmOptionForm.aspx?tms=101", true);
                    }

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

                Int32 PreferenceCount = reg.getPreferencesCountCAPRound1(objSessionData.PID);
                showPreferenceNo(ddlPreferenceNo, PreferenceCount);
                ddlPreferenceNo.SelectedValue = PreferenceCount.ToString();

                if (PreferenceCount > 300)
                {
                    //btnInsert.Visible = false;
                    btnInsertDirect.Visible = false;
                }

                gvPreferencedOptionsList.DataSource = reg.getPreferancedOptionsListCAPRound1(objSessionData.PID);
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
        protected void btnVerifyChoiceCode_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                string ChoiceCodeDisplay = txtChoiceCode.Text;

                DataSet ds = reg.verifyChoiceCode(1, objSessionData.PID, ChoiceCodeDisplay);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    trInstituteName.Visible = true;
                    trCourseName.Visible = true;
                    trInvalid.Visible = false;

                    lblInstituteName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
                    lblCourseName.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                }
                else
                {
                    trInstituteName.Visible = false;
                    trCourseName.Visible = false;
                    trInvalid.Visible = true;

                    lblInvalid.Text = "Invalid Choice Code or You are not eligible to fill this Choice Code.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnInsertDirect_click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int32 PreferenceNo = Convert.ToInt32(ddlPreferenceNo.SelectedValue);
                string ChoiceCodeDisplay = txtChoiceCode.Text;

                switch (reg.insertOptionDirectCAPRound1(objSessionData.PID, PreferenceNo, ChoiceCodeDisplay, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    case 0:
                        shInfo.SetMessage("Invalid Choice Code or You are not eligible to fill this Choice Code.", ShowMessageType.Information);
                        break;
                    case 1:
                        shInfo.SetMessage("This Choice Code is already added.", ShowMessageType.Information);
                        break;
                    case 2:
                        objSessionData.StepIDCAPRound1 = 4;
                        objSessionData.OptionFormStatusCAPRound1 = 'A';
                        Session["SessionData"] = objSessionData;

                        Response.Redirect("../CandidateModuleCAPRound1/frmOptionForm.aspx?tms=101");
                        break;
                    case 3:
                        getPreferencedOptionsList();

                        txtChoiceCode.Text = "";
                        lblInstituteName.Text = "";
                        lblCourseName.Text = "";
                        lblInvalid.Text = "";

                        trInstituteName.Visible = false;
                        trCourseName.Visible = false;
                        trInvalid.Visible = false;

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
            Response.Redirect("../CandidateModuleCAPRound1/frmMoveChoiceCode.aspx?tms=101");
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModuleCAPRound1/frmInsertChoiceCode.aspx?tms=101");
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

                if (Global.MasterChoiceCodeStatusCAPRound1.Tables[0].Rows.Count > 0)
                {
                    lblChoiceCodeStatus.Text = "";
                    for (Int32 i = 0; i < Global.MasterChoiceCodeStatusCAPRound1.Tables[0].Rows.Count; i++)
                    {
                        lblChoiceCodeStatus.Text += Global.MasterChoiceCodeStatusCAPRound1.Tables[0].Rows[i]["ChoiceCodeStatusInstructions"].ToString();
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
                    Response.Redirect("../CandidateModuleCAPRound1/frmOptionFormSummary.aspx?tms=101");
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