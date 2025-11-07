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

namespace Pharmacy2024.AFCModule
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
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }

                    lblOldMobileNo.Text = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(PID));
                    trNewMobileNo.Visible = false;
                    trMobileNo.Visible = true;
                    trOTP.Visible = false;
                    if(Session["UserLoginID"].ToString() == "adminmahendra" || Session["UserLoginID"].ToString() == "adminlaxman")
                    {
                        btnProceed.Text = "Save";
                    }
                    else
                    {
                        btnProceed.Text = "Send OTP";
                    }
                    
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

                if (btnProceed.Text == "Save" && (Session["UserLoginID"].ToString() == "adminmahendra" || Session["UserLoginID"].ToString() == "adminlaxman"))
                {
                    string MobileNo = DataEncryption.EncryptDataByEncryptionKey(txtMobileNo.Text);

                    if (reg.isApplicationFormConfirmedUsingThisMobileNo(MobileNo))
                    {
                        shInfo.SetMessage("Application Form using mobile number " + txtMobileNo.Text + " is already confirmed. Please enter other mobile number.", ShowMessageType.Information);
                    }
                    else
                    {
                        if (lblOldMobileNo.Text == txtMobileNo.Text)
                        {
                            shInfo.SetMessage("New Mobile Number should be different from " + lblOldMobileNo.Text + ".", ShowMessageType.Information);
                        }
                        else
                        {
                            //SMSTemplate sMSTemplate = new SMSTemplate();
                            //sMSTemplate.PID = PID;
                            //SynCommon synCommon = new SynCommon();
                            //if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OtpMobileChange))
                            //{
                            //    lblNewMobileNo.Text = DataEncryption.MaskMobileNo(txtMobileNo.Text);
                            //    trNewMobileNo.Visible = true;
                            //    trMobileNo.Visible = false;
                            //    trOTP.Visible = true;
                            //    btnProceed.Text = "Verify OTP";
                            //    ViewState["NewMobileNo"] = txtMobileNo.Text;
                            //}
                            lblNewMobileNo.Text = DataEncryption.MaskMobileNo(txtMobileNo.Text);
                            ViewState["NewMobileNo"] = txtMobileNo.Text;
                            reg.verifyOTPForMobileNoChange(PID, "", DataEncryption.EncryptDataByEncryptionKey(ViewState["NewMobileNo"].ToString()), UserInfo.GetIPAddress(), Session["UserLoginID"].ToString());
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            //SynCommon synCommon = new SynCommon();
                            //sMSTemplate.PID = PID;
                            //sMSTemplate.OldMobileNo = lblOldMobileNo.Text;
                            //sMSTemplate.NewMobileNo = txtMobileNo.Text;
                            // synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.MobileChange);
                            shInfo.SetMessage("Your Mobile Number has been changed from " + lblOldMobileNo.Text + " to " + txtMobileNo.Text + ".", ShowMessageType.Information);

                            lblNewMobileNo.Text = txtMobileNo.Text;
                            trNewMobileNo.Visible = true;
                            trMobileNo.Visible = false;
                            trOTP.Visible = false;
                            btnProceed.Visible = false;
                            btnCall.Visible = false;
                        }
                    }
                }
                else if (btnProceed.Text == "Verify OTP")
                {
                    if (reg.verifyOTP(Global.ApplicationFormPrefix + PID.ToString(), txtOneTimePassword.Text, 2))
                    {
                        reg.verifyOTPForMobileNoChange(PID, "", DataEncryption.EncryptDataByEncryptionKey(ViewState["NewMobileNo"].ToString()), UserInfo.GetIPAddress(), Session["UserLoginID"].ToString());
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        //SynCommon synCommon = new SynCommon();
                        //sMSTemplate.PID = PID;
                        //sMSTemplate.OldMobileNo = lblOldMobileNo.Text;
                        //sMSTemplate.NewMobileNo = txtMobileNo.Text;
                        // synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.MobileChange);
                        shInfo.SetMessage("Your Mobile Number has been changed from " + lblOldMobileNo.Text + " to " + txtMobileNo.Text + ".", ShowMessageType.Information);

                        lblNewMobileNo.Text = txtMobileNo.Text;
                        trNewMobileNo.Visible = true;
                        trMobileNo.Visible = false;
                        trOTP.Visible = false;
                        btnProceed.Visible = false;
                        btnCall.Visible = false;
                    }
                    else
                    {
                        shInfo.SetMessage("Enter Valid OTP or OTP is Expired!", ShowMessageType.UserError);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        //protected void btnProceed_Click(object sender, EventArgs e)
        //{
        //    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
        //    try
        //    {
        //        Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

        //        if (btnProceed.Text == "Send OTP")
        //        {
        //            string MobileNo = DataEncryption.EncryptDataByEncryptionKey(txtMobileNo.Text);

        //            if (reg.isApplicationFormConfirmedUsingThisMobileNo(MobileNo))
        //            {
        //                shInfo.SetMessage("Application Form using mobile number " + txtMobileNo.Text + " is already confirmed. Please enter other mobile number.", ShowMessageType.Information);
        //            }
        //            else
        //            {
        //                if (lblOldMobileNo.Text == txtMobileNo.Text)
        //                {
        //                    shInfo.SetMessage("New Mobile Number should be different from " + lblOldMobileNo.Text + ".", ShowMessageType.Information);
        //                }
        //                else
        //                {
        //                    SMSTemplate sMSTemplate = new SMSTemplate();
        //                    sMSTemplate.PID = PID;
        //                    SynCommon synCommon = new SynCommon();
        //                    if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OtpMobileChange))
        //                    {
        //                        lblNewMobileNo.Text = DataEncryption.MaskMobileNo(txtMobileNo.Text);
        //                        trNewMobileNo.Visible = true;
        //                        trMobileNo.Visible = false;
        //                        trOTP.Visible = true;
        //                        btnProceed.Text = "Verify OTP";
        //                        ViewState["NewMobileNo"] = txtMobileNo.Text;
        //                    }
        //                }
        //            }
        //        }
        //        else if (btnProceed.Text == "Verify OTP")
        //        {
        //            if (reg.verifyOTP(Global.ApplicationFormPrefix + PID.ToString(), txtOneTimePassword.Text, 2))
        //            {
        //                reg.verifyOTPForMobileNoChange(PID, "", DataEncryption.EncryptDataByEncryptionKey(ViewState["NewMobileNo"].ToString()), UserInfo.GetIPAddress(), Session["UserLoginID"].ToString());
        //                SMSTemplate sMSTemplate = new SMSTemplate();
        //                shInfo.SetMessage("Your Mobile Number has been changed from " + lblOldMobileNo.Text + " to " + txtMobileNo.Text + ".", ShowMessageType.Information);

        //                lblNewMobileNo.Text = txtMobileNo.Text;
        //                trNewMobileNo.Visible = true;
        //                trMobileNo.Visible = false;
        //                trOTP.Visible = false;
        //                btnProceed.Visible = false;
        //                btnCall.Visible = false;
        //            }
        //            else
        //            {
        //                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logging.LogException(ex, "[Page Level Error]");
        //        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
        //    }
        //}
        protected void btnCall_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SMS objSMS = new SMS();
                objSMS.voiceCallOTP(txtMobileNo.Text);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}