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
    public partial class frmResetPasswordUsingEMailVerificationStep4 : System.Web.UI.Page
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


                    if (Request.QueryString["EMailVerificationCode"] == null || Request.QueryString["LoginID"] == null)
                    {
                        Response.Write("<BR /><BR /><center><H1>You are not Authorised to see this page.</H1></center>");
                        Response.End();
                    }
                    else
                    {
                        string LoginID = Request.QueryString["LoginID"].ToString();
                        string EMailVerificationCode = Request.QueryString["EMailVerificationCode"].ToString();

                        if (reg.verifyOthersEMailVerificationCode(LoginID, EMailVerificationCode))
                        {
                            this.Context.Items["LoginID"] = LoginID;
                            Server.Transfer("~/OthersAccountRecoveryModule/frmResetPasswordUsingEMailVerificationStep5.aspx");
                        }
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
}