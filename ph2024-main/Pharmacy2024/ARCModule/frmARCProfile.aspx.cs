using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ARCModule
{
    public partial class frmARCProfile : System.Web.UI.Page
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
                    ddlSecurityQuestion.DataSource = reg.getMasterSecurityQuestion();
                    ddlSecurityQuestion.DataTextField = "SecurityQuestionDetails";
                    ddlSecurityQuestion.DataValueField = "SecurityQuestionID";
                    ddlSecurityQuestion.DataBind();
                    ddlSecurityQuestion.Items.Insert(0, new ListItem("-- Select Security Question --", "0"));

                    ARCProfile obj = reg.getARCProfile(Session["UserLoginID"].ToString());

                    lblARCName.Text = obj.ARCName;
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
                string ARCCode = Session["UserLoginID"].ToString();
                ARCProfile obj = new ARCProfile();

                obj.ARCCode = ARCCode;
                obj.ARCAddress = txtARCAddress.Text;
                obj.ARCPhoneNo = txtARCPhoneNo.Text;
                obj.ARCFaxNo = txtARCFaxNo.Text;
                obj.CoordinatorName = txtCoordinatorName.Text;
                obj.CoordinatorDesignation = txtCoordinatorDesignation.Text;
                obj.CoordinatorDOB = Convert.ToDateTime(txtCoordinatorDOB.Text.Split("/".ToCharArray())[1] + "/" + txtCoordinatorDOB.Text.Split("/".ToCharArray())[0] + "/" + txtCoordinatorDOB.Text.Split("/".ToCharArray())[2]);
                obj.CoordinatorMobileNo = txtCoordinatorMobileNo.Text;
                obj.CoordinatorAltMobileNo = txtCoordinatorAltMobileNo.Text;
                obj.CoordinatorEmailID = txtCoordinatorEmailID.Text;
                obj.CoordinatorPhoneNo = txtCoordinatorPhoneNo.Text;
                obj.SecurityQuestionID = Convert.ToInt16(ddlSecurityQuestion.SelectedValue);
                obj.SecurityAnswer = txtSecurityAnswer.Text;
                obj.ARCPassword = DataEncryption.EncryptDataByHashSHA1(txtPassword.Text);

                if (reg.saveARCProfile(obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    Response.Redirect("../ApplicationPages/WelcomePage.aspx");
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