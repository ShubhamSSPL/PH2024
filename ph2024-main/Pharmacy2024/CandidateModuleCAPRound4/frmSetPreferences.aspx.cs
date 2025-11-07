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
    public partial class frmSetPreferences : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public Int32 CheckCount = 0;
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
            if (Global.OptionFormFillingCAPRound4 == 0)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=2", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (ViewState["CheckCount"] != null)
            {
                CheckCount = Convert.ToInt32(ViewState["CheckCount"].ToString());
            }
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsCurrentLink = reg.getCurrentLinkCAPRound4(objSessionData.PID, "frmSetPreferences.aspx");

                    hdnStepID.Value = (objSessionData.StepIDCAPRound4 + 1).ToString();
                    a_1.HRef = objSessionData.StepIDCAPRound4 + 1 >= Convert.ToInt32(a_1.ID.Split('_')[1]) ? "frmShortListOptions.aspx?tms=101" : "#";
                    a_2.HRef = objSessionData.StepIDCAPRound4 + 1 >= Convert.ToInt32(a_2.ID.Split('_')[1]) ? "frmSetPreferences.aspx?tms=101" : "#";
                    a_3.HRef = objSessionData.StepIDCAPRound4 + 1 >= Convert.ToInt32(a_3.ID.Split('_')[1]) ? "frmOptionFormSummary.aspx?tms=101" : "#";
                    a_4.HRef = objSessionData.StepIDCAPRound4 + 1 >= Convert.ToInt32(a_4.ID.Split('_')[1]) ? "frmConfirmOptionForm.aspx?tms=101" : "#";

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if (objSessionData.EligibleForCAPRound4 == 0)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                    }
                    if (objSessionData.OptionFormStatusCAPRound4 == 'A' || objSessionData.StepIDCAPRound4 < 1)
                    {
                        Response.Redirect("../CandidateModuleCAPRound4/frmOptionForm.aspx?tms=101", true);
                    }

                    if (objSessionData.StepIDCAPRound4 >= 2)
                    {
                        if (!reg.checkPreferenceNoCAPRound4(objSessionData.PID))
                        {
                            shInfo.SetMessage("As Preferences given by you are not Valid, Please give your Preferances again.", ShowMessageType.Information);
                        }
                    }

                    dgSetPreferences.DataSource = reg.getSelectedOptionsListCAPRound4(objSessionData.PID);
                    CheckCount = 0;
                    dgSetPreferences.DataBind();
                    if (dgSetPreferences.Items.Count == 0)
                    {
                        Response.Redirect("../CandidateModuleCAPRound4/frmShortListOptions.aspx?tms=101", true);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void dgSetPreferences_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.Item.ItemIndex >= 0)
                {
                    e.Item.Cells[0].Text = ((int)(e.Item.ItemIndex + 1)).ToString() + ".";

                    CheckBox ck = new CheckBox();
                    ck = (CheckBox)e.Item.FindControl("chkSetPreferences");
                    ck.Attributes.Add("onClick", "checkpass(this);");
                    ck.EnableViewState = true;
                    e.Item.CssClass = "";

                    if (Convert.ToInt32(((Label)e.Item.FindControl("lblPreferenceNo")).Text) > 0)
                    {
                        ((TextBox)e.Item.FindControl("txtPreferenceNo")).Text = ((Label)e.Item.FindControl("lblPreferenceNo")).Text;
                        ck.Checked = true;
                        CheckCount++;
                        e.Item.CssClass = "SelectedRow";
                    }
                    else
                    {
                        ((TextBox)e.Item.FindControl("txtPreferenceNo")).Text = "";
                    }

                    ViewState["CheckCount"] = CheckCount;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
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

                if (Global.MasterChoiceCodeStatusCAPRound4.Tables[0].Rows.Count > 0)
                {
                    lblChoiceCodeStatus.Text = "";
                    for (Int32 i = 0; i < Global.MasterChoiceCodeStatusCAPRound4.Tables[0].Rows.Count; i++)
                    {
                        lblChoiceCodeStatus.Text += Global.MasterChoiceCodeStatusCAPRound4.Tables[0].Rows[i]["ChoiceCodeStatusInstructions"].ToString();
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
                SessionData objSessionData = (SessionData)Session["SessionData"];
                CheckCount = 0;

                string PreferencesList = "<PreferencesList>";
                for (Int32 i = 0; i < dgSetPreferences.Items.Count; i++)
                {
                    string PreferenceNo = ((TextBox)dgSetPreferences.Items[i].FindControl("txtPreferenceNo")).Text.Trim();
                    string ChoiceCode = ((Label)dgSetPreferences.Items[i].FindControl("lblChoiceCode")).Text;

                    if (PreferenceNo == "")
                    {
                        PreferenceNo = "0";
                    }

                    if (((Label)dgSetPreferences.Items[i].FindControl("lblPreferenceNo")).Text.Trim() != PreferenceNo)
                    {
                        PreferencesList += "<Preference ChoiceCode='" + ChoiceCode + "' PreferenceNo='" + PreferenceNo + "'></Preference>";
                    }
                }
                PreferencesList += "</PreferencesList>";

                ViewState["CheckCount"] = CheckCount;

                switch (reg.savePreferencesCAPRound4(objSessionData.PID, PreferencesList, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    case 0:
                        shInfo.Visible = true;
                        shInfo.SetMessage("<b>Error In Saving Sequences. Please try again!!!</b>", ShowMessageType.UserError);
                        break;
                    case 1:
                        if (objSessionData.StepIDCAPRound4 < 2)
                        {
                            objSessionData.StepIDCAPRound4 = 2;
                        }

                        if (objSessionData.OptionFormStatusCAPRound4 == 'I')
                        {
                            objSessionData.OptionFormStatusCAPRound4 = 'C';
                        }

                        Session["SessionData"] = objSessionData;

                        Response.Redirect("../CandidateModuleCAPRound4/frmOptionFormSummary.aspx?tms=101");
                        break;
                    case 2:
                        Session["StepIDCAPRound4"] = 3;
                        Session["OptionFormStatusCAPRound4"] = "A";

                        Response.Redirect("../CandidateModuleCAPRound4/frmOptionForm.aspx?tms=101");
                        break;
                    default:
                        Response.Redirect("../CandidateModuleCAPRound4/frmOptionForm.aspx?tms=101");
                        break;
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