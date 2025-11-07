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

namespace Pharmacy2024.CandidateModuleCAPRound1
{
    public partial class frmUnlockOptionForm : System.Web.UI.Page
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (DateTime.Now < Global.OptionFormFillingCAPRound1StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound1EndDateTime)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=2", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsCurrentLink = reg.getCurrentLinkCAPRound1(objSessionData.PID, "frmConfirmOptionForm.aspx");

                    //if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    //{
                    //    Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    //}
                    //if (objSessionData.EligibleForCAPRound1 == 0)
                    //{
                    //    Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                    //}
                    //if (objSessionData.OptionFormStatusCAPRound1 == 'A' || objSessionData.StepIDCAPRound1 < 3)
                    //{
                    //    Response.Redirect("../CandidateModuleCAPRound1/frmOptionForm.aspx?tms=101", true);
                    //}

                    //if (!reg.checkPreferenceNoCAPRound1(objSessionData.PID))
                    //{
                    //    Response.Redirect("../CandidateModuleCAPRound1/frmSetPreferences.aspx?tms=101");
                    //}

                    //if (!reg.isCandidateSelectedOptionsCAPRound1(objSessionData.PID))
                    //{
                    //    Response.Redirect("../CandidateModuleCAPRound1/frmSetPreferences.aspx?tms=101");
                    //}
                    tblOtp.Visible = true;
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();

                if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, 8))
                {
                    if (Global.CurrentCAPRoundForOptionFormFilling == 1 && DateTime.Now >= Global.OptionFormFillingCAPRound1StartDateTime && DateTime.Now <= Global.OptionFormFillingCAPRound1EndDateTime)
                    {
                        if (reg.cancelOptionFormCAPRound1(objSessionData.PID, "Confirmed Before SeatMatrix Display", Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            objSessionData.StepIDCAPRound1 = 3;
                            objSessionData.OptionFormStatusCAPRound1 = 'C';
                            Session["SessionData"] = objSessionData;
                            Response.Redirect("../CandidateModuleCAPRound1/frmOptionForm.aspx");
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in cancellation. Please try after some time.", ShowMessageType.Information);
                        }

                    }
                    btnCall.Visible = false;
                }
                else
                {
                    shInfo.SetMessage("OTP is Invalid.", ShowMessageType.Information);
                    this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnCall_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            string mobno = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID));
            SMS objSMS = new SMS();
            objSMS.voiceCallOTP(mobno);
            this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemouts();</script>"));
        }
    }
}