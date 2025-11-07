using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateAccountRecoveryModule
{
    public partial class frmForgotApplicationID : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    txtCandidateName.Attributes.Add("onBlur", "makeUpper()");
                    txtFatherName.Attributes.Add("onBlur", "makeUpper()");
                    txtMotherName.Attributes.Add("onBlur", "makeUpper()");
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (Global.IsCaptchaRequired == 1)
                    Captcha1.ValidateCaptcha(txtSecurityPin.Text.Trim());
                if (Captcha1.UserValidated)
                {
                    string CandidateName = txtCandidateName.Text;
                    string FatherName = txtFatherName.Text;
                    string MotherName = txtMotherName.Text;
                    DateTime DOB = Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]);

                    string ApplicationID = reg.forgotApplicationID(CandidateName, FatherName, MotherName, DOB);

                    if (ApplicationID.Length == 10)
                    {
                        this.Context.Items["ApplicationID"] = ApplicationID;
                        //Server.Transfer("~/CandidateAccountRecoveryModule/frmShowApplicationID.aspx");
                        Response.Redirect("~/CandidateAccountRecoveryModule/frmShowApplicationID.aspx?ApplicationID=" + DataEncryption.URLParamEncrypt(ApplicationID));
                    }
                    else
                    {
                        shInfo.SetMessage("There is no Application Form Filled with this details. Kindly try with the correct Inputs Details.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("Invalid Captcha. Please try again.", ShowMessageType.Information);
                }
                txtCandidateName.Text = "";
                txtFatherName.Text = "";
                txtMotherName.Text = "";
                txtDOB.Text = "";
                txtSecurityPin.Text = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}