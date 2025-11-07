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
                    if (Request.QueryString["EMailVerificationCode"] == null || Request.QueryString["PID"] == null)
                    {
                        Response.Write("<BR /><BR /><center><H1>You are not Authorised to see this page.</H1></center>");
                        Response.End();
                    }
                    else
                    {
                        Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                        string EMailVerificationCode = Request.QueryString["EMailVerificationCode"].ToString();

                        if (reg.verifyCandidateEMailVerificationCode(PID, EMailVerificationCode))
                        {
                            this.Context.Items["PID"] = PID;
                            Server.Transfer("~/CandidateAccountRecoveryModule/frmResetPasswordUsingEMailVerificationStep5.aspx");
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