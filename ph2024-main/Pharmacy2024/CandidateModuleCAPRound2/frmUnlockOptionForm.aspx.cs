using BusinessLayer;
using EntityModel;
using Pharmacy2024;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModuleCAPRound2
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
            if (DateTime.Now < Global.OptionFormFillingCAPRound2StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound2EndDateTime)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=2", true);
            }

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsCurrentLink = reg.getCurrentLinkCAPRound2(objSessionData.PID, "frmConfirmOptionForm.aspx");

                    if (reg.CheckUnlockOptionFormCAPRound2(objSessionData.PID) == 0)
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = false;
                        shInfo.SetMessage("This facility is only for the candidates who has confrimed the Option Form CAP Round II.", ShowMessageType.Information);
                    }
                    else if (reg.CheckUnlockOptionFormCAPRound2(objSessionData.PID) == 2)
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = false;
                        shInfo.SetMessage("You have already used Unlock Option Form CAP Round II.", ShowMessageType.Information);
                    }
                    else
                    {
                        if (objSessionData.EligibleForCAPRound2 == 0)
                        {
                            Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                        }
                        if (objSessionData.OptionFormStatusCAPRound2 != 'A' || objSessionData.StepIDCAPRound2 < 4)
                        {
                            Response.Redirect("../CandidateModuleCAPRound2/frmOptionForm.aspx?tms=101", true);
                        }
                        tblPasword.Visible = true;
                        tblOtp.Visible = false;
                    }


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

                if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, (int)SynCommon.TemplateSystemType.CAPOptionFormIIUnlockOTP))
                {
                    switch (reg.UnlockOptionFormCAPRound2(objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        case 0:
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                            break;
                        case 1:
                            objSessionData.StepIDCAPRound2 = 3;
                            objSessionData.OptionFormStatusCAPRound2 = 'C';
                            Session["SessionData"] = objSessionData;
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = objSessionData.PID;
                            sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                            sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CAPOptionFormIIUnlock);
                            Response.Redirect("../CandidateModuleCAPRound2/frmOptionForm.aspx?tms=101");
                            break;
                        default:
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                            break;
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


        protected void btnpassword_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                Int64 result = reg.authenticateCandidateLogin(Session["UserLoginID"].ToString(), DataEncryption.EncryptDataByHashSHA1(txtPassword.Text));
                if (result > 0)
                {
                    if (Global.IsOTPVerificationRequiredForUnlockOptionForm2 == 1)
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = true;

                        hdnPassword.Value = txtPassword.Text;
                        btnCall.Visible = true;
                        long PID = objSessionData.PID;
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        sMSTemplate.PID = PID;
                        SynCommon synCommon = new SynCommon();
                        if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.CAPOptionFormIIUnlockOTP))
                        {
                            trMobileNo.Visible = true;
                            lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID).ToString())).ToString();
                        }

                        this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                    }
                    else
                    {
                        switch (reg.UnlockOptionFormCAPRound2(objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            case 0:
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                break;
                            case 1:
                                objSessionData.StepIDCAPRound2 = 3;
                                objSessionData.OptionFormStatusCAPRound2 = 'C';
                                Session["SessionData"] = objSessionData;
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = objSessionData.PID;
                                sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CAPOptionFormIIUnlock);
                                Response.Redirect("../CandidateModuleCAPRound2/frmOptionForm.aspx?tms=101");
                                break;
                            default:
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                break;
                        }

                        btnCall.Visible = false;
                    }

                }
                else
                {
                    shInfo.SetMessage("Password does not Match.", ShowMessageType.Information);
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