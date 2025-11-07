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
    public partial class frmChangeMobileNo : System.Web.UI.Page
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
        private string oldMoNo = "";
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
                    SessionData objSessionData = (SessionData)Session["SessionData"];

                    lblOldMobileNo.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID)));
                    trNewMobileNo.Visible = false;
                    trMobileNo.Visible = true;
                    trOTP.Visible = false;
                    trOTPNew.Visible = false;
                    btnProceed.Text = "Send OTP";
                    btnCall.Visible = false;
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

                SessionData objSessionData = (SessionData)Session["SessionData"];

                if (btnProceed.Text == "Send OTP")
                {
                    string MobileNo = DataEncryption.EncryptDataByEncryptionKey(txtMobileNo.Text);
                    string AppID = reg.isApplicationFormRegisteredUsingThisMobileNo(MobileNo, objSessionData.PID);

                    if (Global.CheckDuplicateMobileNo == 1 && AppID.Length > 0)
                    {
                        shInfo.SetMessage("Application Form with Application ID - " + AppID + " is already Registered using mobile number " + txtMobileNo.Text + ". Please use other mobile number for Registration.", ShowMessageType.Information);
                    }
                    if (reg.isApplicationFormConfirmedUsingThisMobileNo(MobileNo))
                    {
                        shInfo.SetMessage("Application Form using mobile number " + txtMobileNo.Text + " is already confirmed. Please enter other mobile number.", ShowMessageType.Information);
                    }
                    else
                    {
                        if (reg.getMobileNo(objSessionData.PID) == MobileNo)
                        {
                            shInfo.SetMessage("New Mobile Number should be different from Old Mobile Number.", ShowMessageType.Information);
                        }
                        else
                        {
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = objSessionData.PID;
                            synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OtpMobileChange);
                            if (Global.IsVerifyNewMobileOTP == 1)
                            {
                                sMSTemplate.MobileNo = txtMobileNo.Text;
                                synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OtpMobileChangeNewMobile);
                                trOTPNew.Visible = true;
                            }
                            btnCall.Visible = true;
                            lblNewMobileNo.Text = DataEncryption.MaskMobileNo(txtMobileNo.Text);
                            trNewMobileNo.Visible = true;
                            trMobileNo.Visible = false;
                            trOTP.Visible = true;
                            btnProceed.Text = "Verify OTP";
                            ViewState["NewMobileNo"] = txtMobileNo.Text;
                        }
                    }
                }
                else if (btnProceed.Text == "Verify OTP")
                {

                    if (reg.verifyOTP(Global.ApplicationFormPrefix + objSessionData.PID.ToString(), txtOneTimePassword.Text, (int)SynCommon.TemplateSystemType.OtpMobileChange))
                    {
                        if (Global.IsVerifyNewMobileOTP == 1)
                        {
                            if (reg.verifyOTP(Global.ApplicationFormPrefix + objSessionData.PID.ToString(), txtOneTimePasswordNew.Text, (int)SynCommon.TemplateSystemType.OtpMobileChangeNewMobile))
                            {
                                if (reg.verifyOTPForMobileNoChange(objSessionData.PID, "", DataEncryption.EncryptDataByEncryptionKey(ViewState["NewMobileNo"].ToString()), UserInfo.GetIPAddress(), Session["UserLoginID"].ToString()))
                                {
                                    reg.verifyOTPForMobileNoChange(objSessionData.PID, "", DataEncryption.EncryptDataByEncryptionKey(ViewState["NewMobileNo"].ToString()), UserInfo.GetIPAddress(), Session["UserLoginID"].ToString());
                                    shInfo.SetMessage("Your Mobile Number has been changed successfully.", ShowMessageType.Information);
                                    lblNewMobileNo.Text = DataEncryption.MaskMobileNo(txtMobileNo.Text);
                                    trNewMobileNo.Visible = true;
                                    trMobileNo.Visible = false;
                                    trOTP.Visible = false;
                                    btnProceed.Visible = false;
                                    trOTPNew.Visible = false;
                                    btnCall.Visible = false;
                                }
                                else
                                {
                                    shInfo.SetMessage("There is some problem in sending Message. Please try after some time.", ShowMessageType.UserError);
                                }
                            }
                            else
                            {
                                shInfo.SetMessage("Enter both Valid OTP or OTP is Expired, Try again !", ShowMessageType.UserError);
                            }
                        }
                        else
                        {
                            if (reg.verifyOTPForMobileNoChange(objSessionData.PID, "", DataEncryption.EncryptDataByEncryptionKey(ViewState["NewMobileNo"].ToString()), UserInfo.GetIPAddress(), Session["UserLoginID"].ToString()))
                            {
                                //reg.verifyOTPForMobileNoChange(objSessionData.PID, "", DataEncryption.EncryptDataByEncryptionKey(ViewState["NewMobileNo"].ToString()), UserInfo.GetIPAddress(), Session["UserLoginID"].ToString());
                                shInfo.SetMessage("Your Mobile Number has been changed successfully.", ShowMessageType.Information);
                                lblNewMobileNo.Text = DataEncryption.MaskMobileNo(txtMobileNo.Text);
                                trNewMobileNo.Visible = true;
                                trMobileNo.Visible = false;
                                trOTP.Visible = false;
                                btnProceed.Visible = false;
                                trOTPNew.Visible = false;
                                btnCall.Visible = false;
                            }
                            else
                            {
                                shInfo.SetMessage("There is some problem in sending Message. Please try after some time.", ShowMessageType.UserError);
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Enter both Valid OTP or OTP is Expired, Try again !", ShowMessageType.UserError);
                    }
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
            SMS objSMS = new SMS();
            objSMS.voiceCallOTP(txtMobileNo.Text);
            SessionData objSessionData = (SessionData)Session["SessionData"];
            objSMS.voiceCallOTP(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID)));
        }
    }
}