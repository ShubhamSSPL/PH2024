using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.OthersAccountRecoveryModule
{
    public partial class frmResetPasswordUsingOTPStep2 : System.Web.UI.Page
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


                    if (this.Context.Items["LoginID"] == null)
                    {
                        Response.Write("<BR /><BR /><center><H1>You are not Authorised to see this page.</H1></center>");
                        Response.End();
                    }
                    else
                    {
                        string LoginID = this.Context.Items["LoginID"].ToString();
                        ViewState["LoginID"] = LoginID;
                        lblMobileNo.Text = reg.verifyOthersMobileNo(LoginID);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                string LoginID = ViewState["LoginID"].ToString();

                if (reg.sendOthersOTPCodeForResetPassword(LoginID))
                {
                    this.Context.Items["LoginID"] = LoginID;
                    Server.Transfer("~/OthersAccountRecoveryModule/frmResetPasswordUsingOTPStep3.aspx");
                }
                else
                {
                    shInfo.SetMessage("New password can not be same as last 3 password, so please choose a diffrent password.", ShowMessageType.Information);
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