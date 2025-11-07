using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class frmVerifyScrutinyModeChange : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    if (Request.Cookies["Theme"] == null)
        //    {
        //        Page.Theme = "default";
        //    }
        //    else
        //    {
        //        Page.Theme = Request.Cookies["Theme"].Value;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime || Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
            }

            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];

                    if (Request.QueryString["ScrutinyMode"] != null)
                    {
                        ViewState["ScrutinyMode"] = Request.QueryString["ScrutinyMode"].ToString();
                        tblPasword.Visible = true;
                        tblOtp.Visible = false;
                        lblMaskMobileno1.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID).ToString())).ToString();
                    }
                    else
                    {
                        shInfo.SetMessage("Invalid Page Request.", ShowMessageType.TechnicalError);
                        tblPasword.Visible = false;
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
                LOTP.Visible = false;
                SessionData objSessionData = (SessionData)Session["SessionData"];
                string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();

                if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, (int)SynCommon.TemplateSystemType.OTPModeChange))
                {
                    DBUtilityChangeMode regDB = new DBUtilityChangeMode(); //P
                    if (regDB.ChangeFCVerificationMode(objSessionData.PID, ViewState["ScrutinyMode"].ToString(), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        SynCommon synCommon = new SynCommon();
                        sMSTemplate.PID = objSessionData.PID;
                        sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                        sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                        sMSTemplate.ReportedDateTime = DateTime.Now.ToString();

                        if (ViewState["ScrutinyMode"].ToString() == "P")
                        {
                            sMSTemplate.OldMode = "E-Scrutiny";
                            sMSTemplate.NewMode = "P-Scrutiny";
                        }
                        if (ViewState["ScrutinyMode"].ToString() == "E")
                        {
                            sMSTemplate.OldMode = "P-Scrutiny";
                            sMSTemplate.NewMode = "E-Scrutiny";
                        }
                        if (Global.SendSMSToCandidate == 1)
                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ModeChange);

                        if (ViewState["ScrutinyMode"].ToString() == "P")
                            Response.Redirect("../CandidateModule/FCSlotBooking.aspx?From=ModeChange", true);
                        if (ViewState["ScrutinyMode"].ToString() == "E")
                            Response.Redirect("../CandidateModule/frmChangeScrutinyMode.aspx?From=ModeChangeVerification", true);

                        shInfo.SetMessage("Your SC Verification Mode Changed Successfully!!!", ShowMessageType.Information);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in sending Message. Please try after some time.", ShowMessageType.Information);
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
        protected void btnpassword_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int64 result = reg.authenticateCandidateLogin(Session["UserLoginID"].ToString(), DataEncryption.EncryptDataByHashSHA1(txtPassword.Text));

                if (result > 0)
                {
                    LOTP.Visible = true;
                    tblPasword.Visible = false;
                    tblOtp.Visible = true;
                    hdnPassword.Value = txtPassword.Text;
                    btnCall.Visible = true;
                    btnVerifyOtp.Text = "Verify OTP For Scrutiny Mode Change";
                    long PID = objSessionData.PID;
                    SMSTemplate sMSTemplate = new SMSTemplate();
                    sMSTemplate.PID = PID;
                    SynCommon synCommon = new SynCommon();
                    if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OTPModeChange))
                    {
                        trMobileNo.Visible = true;
                        lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID).ToString())).ToString();
                    }
                    this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
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
        protected void btnCall_Click(object sender, EventArgs e)
        {

            SessionData objSessionData = (SessionData)Session["SessionData"];
            string mobno = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID));
            LOTP.Visible = true;
            SMS objSMS = new SMS();
            objSMS.voiceCallOTP(mobno);
            this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemouts();</script>"));
        }

        private class DBUtilityChangeMode
        {
            public bool ChangeFCVerificationMode(Int64 PID, string Flag, string ModifiedBy, string ModifiedByIPAddress)
            {
                DBConnection db = new DBConnection();
                try
                {
                    Int32 result = Convert.ToInt32(db.ExecuteNonQuery("MHDTE_spChangeFCVerificationMode", new SqlParameter[]
                        {
                            new SqlParameter("@PID", PID),
                            new SqlParameter("@Flag", Flag),
                            new SqlParameter("@ModifiedBy", ModifiedBy),
                            new SqlParameter("@ModifiedByIPAddress", ModifiedByIPAddress)
                        }));

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}