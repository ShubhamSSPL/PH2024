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

namespace Pharmacy2024.CandidateModule
{
    public partial class frmChangeSecurityQuestionDetails : System.Web.UI.Page
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

            if (Request.QueryString["Flag"] != null)
            {
                this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageWithOutLeftMenu.master";
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

                    Int64 PID = ((SessionData)Session["SessionData"]).PID;

                    ddlSecurityQuestion.Attributes.Add("onChange", "blankSecurityAnswer()");

                    ddlSecurityQuestion.DataSource = Global.MasterSecurityQuestion;
                    ddlSecurityQuestion.DataTextField = "SecurityQuestionDetails";
                    ddlSecurityQuestion.DataValueField = "SecurityQuestionID";
                    ddlSecurityQuestion.DataBind();
                    ddlSecurityQuestion.Items.Insert(0, new ListItem("-- Select Security Question --", "0"));

                    DataSet ds = reg.getSecurityQuestionDetails(PID);

                    ddlSecurityQuestion.SelectedValue = ds.Tables[0].Rows[0]["SecurityQuestionID"].ToString();
                    txtSecurityAnswer.Text = txtConfirmSecurityAnswer.Text = ds.Tables[0].Rows[0]["SecurityAnswer"].ToString();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                Int64 PID = ((SessionData)Session["SessionData"]).PID;
                Int16 SecurityQuestionID = Int16.Parse(ddlSecurityQuestion.SelectedValue);
                string SecurityAnswer = txtSecurityAnswer.Text;

                if (reg.saveSecurityQuestionDetails(PID, SecurityQuestionID, SecurityAnswer, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    if (Request.QueryString["Flag"] != null)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
                    }
                    else
                    {
                        shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
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