using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmAFCProfile : System.Web.UI.Page
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
                    //ddlSecurityQuestion.DataSource = ASP.global_asax.MasterSecurityQuestion;
                    //ddlSecurityQuestion.DataTextField = "SecurityQuestionDetails";
                    //ddlSecurityQuestion.DataValueField = "SecurityQuestionID";
                    //ddlSecurityQuestion.DataBind();
                    //ddlSecurityQuestion.Items.Insert(0, new ListItem("-- Select Security Question --", "0"));

                    AFCProfile obj = reg.getAFCProfile(Session["UserLoginID"].ToString());

                    lblAFCName.Text = obj.AFCName;
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public static string HashSHA1Password(string Password)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(Password);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
            try
            {

                string AFCCode = Session["UserLoginID"].ToString();
                AFCProfile obj = new AFCProfile();

                obj.AFCCode = AFCCode;
                obj.AFCAddress = txtAFCAddress.Text;
                obj.AFCPhoneNo = txtAFCPhoneNo.Text;
                obj.AFCFaxNo = txtAFCFaxNo.Text;
                obj.CoordinatorName = txtCoordinatorName.Text;
                obj.CoordinatorDesignation = txtCoordinatorDesignation.Text;
                obj.CoordinatorDOB = Convert.ToDateTime(txtCoordinatorDOB.Text.Split("/".ToCharArray())[1] + "/" + txtCoordinatorDOB.Text.Split("/".ToCharArray())[0] + "/" + txtCoordinatorDOB.Text.Split("/".ToCharArray())[2]);
                obj.CoordinatorMobileNo = txtCoordinatorMobileNo.Text;
                obj.CoordinatorAltMobileNo = txtCoordinatorAltMobileNo.Text;
                obj.CoordinatorEmailID = txtCoordinatorEmailID.Text;
                obj.CoordinatorPhoneNo = txtCoordinatorPhoneNo.Text;
                obj.SecurityQuestionID = 0;
                obj.SecurityAnswer = "";
                obj.AFCPassword = HashSHA1Password(txtPassword.Text);

                if (reg.saveAFCProfile(obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
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