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
    public partial class frmVerifyAndConfirmOptionForm : System.Web.UI.Page
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

                    hdnStepID.Value = (objSessionData.StepIDCAPRound2 + 1).ToString();
                    a_1.HRef = objSessionData.StepIDCAPRound2 + 1 >= Convert.ToInt32(a_1.ID.Split('_')[1]) ? "frmShortListOptions.aspx?tms=101" : "#";
                    a_2.HRef = objSessionData.StepIDCAPRound2 + 1 >= Convert.ToInt32(a_2.ID.Split('_')[1]) ? "frmSetPreferences.aspx?tms=101" : "#";
                    a_3.HRef = objSessionData.StepIDCAPRound2 + 1 >= Convert.ToInt32(a_3.ID.Split('_')[1]) ? "frmOptionFormSummary.aspx?tms=101" : "#";
                    a_4.HRef = objSessionData.StepIDCAPRound2 + 1 >= Convert.ToInt32(a_4.ID.Split('_')[1]) ? "frmConfirmOptionForm.aspx?tms=101" : "#";

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if (objSessionData.EligibleForCAPRound2 == 0)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                    }
                    if (objSessionData.OptionFormStatusCAPRound2 == 'A' || objSessionData.StepIDCAPRound2 < 3)
                    {
                        Response.Redirect("../CandidateModuleCAPRound2/frmOptionForm.aspx?tms=101", true);
                    }

                    if (!reg.checkPreferenceNoCAPRound2(objSessionData.PID))
                    {
                        Response.Redirect("../CandidateModuleCAPRound2/frmSetPreferences.aspx?tms=101");
                    }

                    if (!reg.isCandidateSelectedOptionsCAPRound2(objSessionData.PID))
                    {
                        Response.Redirect("../CandidateModuleCAPRound2/frmSetPreferences.aspx?tms=101");
                    }

                    Int32 PreferenceCount = reg.getPreferencesCountCAPRound2(objSessionData.PID);
                    if (PreferenceCount > 300)
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = false;
                        Response.Redirect("../CandidateModuleCAPRound2/frmShortListOptions?tms=101");
                        shInfo.SetMessage("You Can Not Add More Than 300 Options. You Can Add Only  " + "(" + (300) + ")" + "  Option(s) Now.", ShowMessageType.Information);
                    }

                    string strInvalidChoiceCodes = reg.getInvalidChoiceCodeListCAPRound2(objSessionData.PID);
                    if (strInvalidChoiceCodes.Length > 6)
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = false;
                        shInfo.SetMessage("List of Invalid Choice Codes : <br />" + strInvalidChoiceCodes + "<br />Please remove these Choice Codes from your Preferences and then Confirm your Option Form.", ShowMessageType.Information);
                    }

                    //DataSet ds = reg.getPreferancedOptionsListCAPRound2(objSessionData.PID);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    DataSet Nds = new DataSet();
                    //    Nds = ds.Copy();
                    //    DataRow[] dr = Nds.Tables[0].Select("PreferenceNo=" + "1");
                    //    ds.Clear();
                    //    ds.Tables[0].Rows.Add(dr[0].ItemArray);

                    //    gvPreferencedOptionsList.DataSource = ds;
                    //    gvPreferencedOptionsList.DataBind();
                    //}

                    tblPasword.Visible = true;
                    tblOtp.Visible = false;
                    lblMaskMobileno1.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID).ToString())).ToString();

                    //if (gvPreferencedOptionsList.Rows.Count == 0)
                    //{
                    //    Response.Redirect("../CandidateModuleCAPRound2/frmSetPreferences.aspx?tms=101");
                    //}
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
                if (!reg.checkPreferenceNoCAPRound2(objSessionData.PID))
                {
                    Response.Redirect("../CandidateModuleCAPRound2/frmSetPreferences.aspx?tms=101");
                }

                string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();
                if (Global.IsCaptchaRequired == 1)
                    Captcha1.ValidateCaptcha(txtSecurityPin.Text.Trim());
                if (Captcha1.UserValidated)
                {
                    if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, 11))
                    {
                        switch (reg.confirmOptionFormCAPRound2(objSessionData.PID, DataEncryption.EncryptDataByHashSHA1(hdnPassword.Value), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            case 0:
                                shInfo.SetMessage("Please set your preference numbers correctly by resetting and assigning proper preference numbers.", ShowMessageType.Information);
                                break;
                            case 1:
                                shInfo.SetMessage("Invalid Password.", ShowMessageType.Information);
                                break;
                            case 2:
                                objSessionData.StepIDCAPRound2 = 4;
                                objSessionData.OptionFormStatusCAPRound2 = 'A';
                                Session["SessionData"] = objSessionData;
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = objSessionData.PID;
                                sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                sMSTemplate.RoundNumber = "II";
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.OptionFormConfirmCAP);
                                //DataSet ds = reg.GetSMSEmailContent(reg.getPersonalID(ApplicationID), "OptionFormConfirmCAPII", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                                //SMS objSMS = new SMS();
                                //if (ds.Tables[1] != null)
                                //{
                                //    if (ds.Tables[1].Rows.Count > 0)
                                //    {
                                //        objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[1].Rows[0]["MobileNo"].ToString()), ds.Tables[1].Rows[0]["SMSContent"].ToString());
                                //        if (Global.IsEmailSend == 1)
                                //        {
                                //            objSMS.SendEmail(ds.Tables[1].Rows[0]["EmailID"].ToString(), ds.Tables[1].Rows[0]["EmailBody"].ToString(), ds.Tables[1].Rows[0]["EmailSubject"].ToString(), true);
                                //        }
                                //    }
                                //}
                                Response.Redirect("../CandidateModuleCAPRound2/frmOptionForm.aspx?tms=101");
                                break;

                            case 3:
                                if (objSessionData.StepIDCAPRound2 < 4)
                                {
                                    objSessionData.StepIDCAPRound2 = 4;
                                }

                                if (objSessionData.OptionFormStatusCAPRound2 == 'C')
                                {
                                    objSessionData.OptionFormStatusCAPRound2 = 'A';
                                }

                                Session["SessionData"] = objSessionData;
                                SMSTemplate sMSTemplate1 = new SMSTemplate();
                                SynCommon synCommon1 = new SynCommon();
                                sMSTemplate1.PID = objSessionData.PID;
                                sMSTemplate1.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate1.CurrentDateTime = DateTime.Now.ToString();
                                sMSTemplate1.RoundNumber = "II";
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon1.SendInformationSMS(sMSTemplate1, SynCommon.TemplateSystemType.OptionFormConfirmCAP);
                                //SMS objSMS1 = new SMS();
                                //string MobileNo = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID));
                                //string Message = "FE19" + objSessionData.PID.ToString() + ", Your Option Form for CAPRound 1 is Confirmed  by " + Session["UserLoginID"].ToString() + " on " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " for Post HSC Diploma Admissions. DTE, MH";
                                //objSMS.sendSingleSMS(MobileNo, Message);
                                //DataSet ds1 = reg.GetSMSEmailContent(objSessionData.PID, "OptionFormConfirmCAPII", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                                //if (ds1.Tables[0] != null)
                                //{
                                //    if (ds1.Tables[0].Rows.Count > 0)
                                //    {
                                //        objSMS1.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds1.Tables[0].Rows[0]["MobileNo"].ToString()), ds1.Tables[0].Rows[0]["SMSContent"].ToString());
                                //        if (Global.IsEmailSend == 1)
                                //        {
                                //            objSMS1.SendEmail(ds1.Tables[0].Rows[0]["EmailID"].ToString(), ds1.Tables[0].Rows[0]["EmailBody"].ToString(), ds1.Tables[0].Rows[0]["EmailSubject"].ToString(), true);
                                //        }
                                //    }
                                //}
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
                else
                {
                    shInfo.SetMessage("Invalid Captcha. Please try again.", ShowMessageType.Information);
                }
                txtOneTimePassword.Text = "";
                txtSecurityPin.Text = "";
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

        private bool verifyOTPForCapI(long PID, string OTP)
        {
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_verifyOTPForCapI", new SqlParameter[]
            {
            new SqlParameter("@PersonalID",PID),new SqlParameter("@OTPForCapI", OTP)

            });
            db.Dispose();
            if (ds.Tables[0].Rows[0]["msg"].ToString() == "susccess")
                return true;
            else
                return false;
        }

        private bool saveOTPForCapI(long PID, string OTP)
        {
            DBConnection db = new DBConnection();
            db.ExecuteNonQuery("sp_saveOTPForCapI", new SqlParameter[]
            {
            new SqlParameter("@PersonalID", PID),
            new SqlParameter("@OTPForCapI", OTP)
            });
            db.Dispose();
            return true;
        }
        protected void btnpassword_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                if (!reg.checkPreferenceNoCAPRound2(objSessionData.PID))
                {
                    Response.Redirect("../CandidateModuleCAPRound2/frmSetPreferences.aspx?tms=101");
                }

                Int64 result = reg.authenticateCandidateLogin(Session["UserLoginID"].ToString(), DataEncryption.EncryptDataByHashSHA1(txtPassword.Text));
                if (result > 0)
                {
                    if (Global.IsOTPVerificationRequiredForOptionForm2 == 1)
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = true;

                        hdnPassword.Value = txtPassword.Text;
                        btnCall.Visible = true;
                        long PID = objSessionData.PID;
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        sMSTemplate.PID = PID;
                        SynCommon synCommon = new SynCommon();
                        if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.CAPOptionFormIIOTP))
                        {
                            trMobileNo.Visible = true;
                            lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID).ToString())).ToString();
                        }

                        //SMS objSMS = new SMS();
                        //DataSet ds = reg.GetSMSEmailContent(objSessionData.PID, "CAPOptionFormII", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                        //if (ds.Tables[1] != null)
                        //{
                        //    if (ds.Tables[1].Rows.Count > 0)
                        //    {
                        //        hdnPassword.Value = txtPassword.Text;
                        //        btnCall.Visible = true;
                        //        lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[1].Rows[0]["MobileNo"].ToString())).ToString();
                        //        trMobileNo.Visible = true;
                        //        objSMS.sendOTPSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[1].Rows[0]["MobileNo"].ToString()), ds.Tables[1].Rows[0]["SMSContent"].ToString(), ds.Tables[1].Rows[0]["OTP"].ToString());
                        //        if (Global.IsEmailSend == 1)
                        //        {
                        //            objSMS.SendEmail(ds.Tables[1].Rows[0]["EmailID"].ToString(),
                        //                ds.Tables[1].Rows[0]["EmailBody"].ToString(),
                        //                ds.Tables[1].Rows[0]["EmailSubject"].ToString(), true);
                        //        }
                        //    }
                        //}
                        this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                    }
                    else
                    {
                        switch (reg.confirmOptionFormCAPRound2(objSessionData.PID, DataEncryption.EncryptDataByHashSHA1(hdnPassword.Value), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            case 0:
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                break;
                            case 1:
                                shInfo.SetMessage("Invalid Password.", ShowMessageType.Information);
                                break;
                            case 2:
                                objSessionData.StepIDCAPRound2 = 4;
                                objSessionData.OptionFormStatusCAPRound2 = 'A';
                                Session["SessionData"] = objSessionData;
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = objSessionData.PID;
                                sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.OptionFormConfirmCAPII);
                                //SMS objSMS = new SMS();
                                //string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();
                                //DataSet ds = reg.GetSMSEmailContent(reg.getPersonalID(ApplicationID), "OptionFormConfirmCAPII", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                                //if (ds.Tables[1] != null)
                                //{
                                //    if (ds.Tables[1].Rows.Count > 0)
                                //    {
                                //        objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[1].Rows[0]["MobileNo"].ToString()), ds.Tables[1].Rows[0]["SMSContent"].ToString());
                                //        if (Global.IsEmailSend == 1)
                                //        {
                                //            objSMS.SendEmail(ds.Tables[1].Rows[0]["EmailID"].ToString(), ds.Tables[1].Rows[0]["EmailBody"].ToString(), ds.Tables[1].Rows[0]["EmailSubject"].ToString(), true);
                                //        }
                                //    }
                                //}
                                Response.Redirect("../CandidateModuleCAPRound2/frmOptionForm.aspx?tms=101");
                                break;

                            case 3:
                                if (objSessionData.StepIDCAPRound2 < 4)
                                {
                                    objSessionData.StepIDCAPRound2 = 4;
                                }

                                if (objSessionData.OptionFormStatusCAPRound2 == 'C')
                                {
                                    objSessionData.OptionFormStatusCAPRound2 = 'A';
                                }

                                Session["SessionData"] = objSessionData;
                                SMSTemplate sMSTemplate1 = new SMSTemplate();
                                SynCommon synCommon1 = new SynCommon();
                                sMSTemplate1.PID = objSessionData.PID;
                                sMSTemplate1.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate1.CurrentDateTime = DateTime.Now.ToString();
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon1.SendInformationSMS(sMSTemplate1, SynCommon.TemplateSystemType.OptionFormConfirmCAPII);
                                //SMS objSMS1 = new SMS();
                                //DataSet ds1 = reg.GetSMSEmailContent(objSessionData.PID, "OptionFormConfirmCAPII", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                                //if (ds1.Tables[0] != null)
                                //{
                                //    if (ds1.Tables[0].Rows.Count > 0)
                                //    {
                                //        objSMS1.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds1.Tables[0].Rows[0]["MobileNo"].ToString()), ds1.Tables[0].Rows[0]["SMSContent"].ToString());
                                //        if (Global.IsEmailSend == 1)
                                //        {
                                //            objSMS1.SendEmail(ds1.Tables[0].Rows[0]["EmailID"].ToString(), ds1.Tables[0].Rows[0]["EmailBody"].ToString(), ds1.Tables[0].Rows[0]["EmailSubject"].ToString(), true);
                                //        }
                                //    }
                                //}
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