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
    public partial class frmConfirmedChoiceCodeList : System.Web.UI.Page
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
        ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
        if (!IsPostBack)
        {
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                if (objSessionData.EligibleForCAPRound2 == 0)
                {
                    Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                }
                if (objSessionData.OptionFormStatusCAPRound2 != 'A')
                {
                    Response.Redirect("../CandidateModuleCAPRound2/frmOptionForm.aspx?tms=101", true);
                }

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

                gvPreferencedOptionsList.DataSource = reg.getPreferancedOptionsListCAPRound2(objSessionData.PID);
                gvPreferencedOptionsList.DataBind();
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
