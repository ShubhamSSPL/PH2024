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
    public partial class frmUpdateARCProfile : System.Web.UI.Page
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

                    string ARCCode = Session["UserLoginID"].ToString();
                    ARCProfile obj = reg.getARCProfile(ARCCode);

                    lblARCName.Text = obj.ARCName;
                    txtARCAddress.Text = obj.ARCAddress;
                    txtARCPhoneNo.Text = obj.ARCPhoneNo;
                    txtARCFaxNo.Text = obj.ARCFaxNo;
                    txtCoordinatorName.Text = obj.CoordinatorName;
                    txtCoordinatorDesignation.Text = obj.CoordinatorDesignation;
                    txtCoordinatorDOB.Text = obj.CoordinatorDOB.ToString("dd/MM/yyyy");
                    txtCoordinatorMobileNo.Text = obj.CoordinatorMobileNo;
                    txtCoordinatorAltMobileNo.Text = obj.CoordinatorAltMobileNo;
                    txtCoordinatorEmailID.Text = obj.CoordinatorEmailID;
                    txtCoordinatorPhoneNo.Text = obj.CoordinatorPhoneNo;
                    ddlSecurityQuestion.SelectedValue = obj.SecurityQuestionID.ToString();
                    txtSecurityAnswer.Text = txtConfirmSecurityAnswer.Text = obj.SecurityAnswer;
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

                if (reg.updateARCProfile(obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
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