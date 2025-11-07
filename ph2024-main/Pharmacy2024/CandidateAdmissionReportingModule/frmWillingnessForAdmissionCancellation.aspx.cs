using BusinessLayer;
using EntityModel;
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

namespace Pharmacy2024.CandidateAdmissionReportingModule
{
    public partial class frmWillingnessForAdmissionCancellation : System.Web.UI.Page
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
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    Int64 ChoiceCode = Convert.ToInt64(Request.QueryString["ChoiceCode"]);
                    Int32 CAPRound = Convert.ToInt32(Request.QueryString["CAPRound"]);
                    DataSet ds = reg.getAdmittedChoiceCodeDetailsForCancellation(objSessionData.PID, ChoiceCode, CAPRound);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ContentTable2.Visible = false;
                        shInfo.SetMessage("You are NOT ADMITTED in this Choice Code till Now. So you can not give Willingness for Cancellation of Admission.", ShowMessageType.Information);
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[0]["IsCandidateInterestedInAdmissionCancellation"].ToString() == "Y")
                        {
                            ContentTable2.Visible = false;
                            shInfo.SetMessage("You have already Applied for Cancellation of Admission. Your seat has been Provisionally Cancelled. Please go to the Admitted Institute and Complete the Admission Cancellation Process.", ShowMessageType.Information);
                        }
                        else
                        {
                            lblInstituteAdmitted.Text = ds.Tables[0].Rows[0]["InstituteCode"].ToString() + " - " + ds.Tables[0].Rows[0]["InstituteName"].ToString();
                            lblCourseAdmitted.Text = ds.Tables[0].Rows[0]["ChoiceCodeDisplay"].ToString() + " - " + ds.Tables[0].Rows[0]["CourseName"].ToString();
                            lblSeatTypeAdmitted.Text = ds.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                            lblAdmissionDate.Text = ds.Tables[0].Rows[0]["AdmissionDate"].ToString();
                            lblAdmittedThrough.Text = ds.Tables[0].Rows[0]["AdmittedThrough"].ToString();
                            hdnchoiceCode.Value = ds.Tables[0].Rows[0]["ChoiceCodeDisplay"].ToString();
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
        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int64 ChoiceCode = Convert.ToInt64(Request.QueryString["ChoiceCode"]);
                Int32 CAPRound = Convert.ToInt32(Request.QueryString["CAPRound"]);
                string CandidatePassword = DataEncryption.EncryptDataByHashSHA1(hdnPassword.Value);
                string ApplicationID = "EN24" + objSessionData.PID.ToString();

                string ChoiceCodeD = "";
                if (ChoiceCode.ToString().Length > 11)
                {
                    
                    ChoiceCodeD = ChoiceCode.ToString().Substring(0, 5);
                }
                else
                {

                    ChoiceCodeD = ChoiceCode.ToString().Substring(0, 4);
                }

                if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, 12))
                {
                    if (rbnYes.Checked)
                    {
                        if (reg.saveWillingnessForAdmissionCancellation(objSessionData.PID, ChoiceCode, CAPRound, CandidatePassword, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = objSessionData.PID;
                            sMSTemplate.InstituteAdmitted = lblInstituteAdmitted.Text;
                            sMSTemplate.ChoiceCodeDisplay = hdnchoiceCode.Value;
                            sMSTemplate.SeatTypeAdmitted = lblSeatTypeAdmitted.Text;
                            sMSTemplate.IPAddress = UserInfo.GetIPAddress();
                            sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                            sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ConfirmationofRequestforAdmissionCancellation);

                            sMSTemplate.PID = 0;
                            sMSTemplate.MobileNo = reg.getInstituteProfile(Convert.ToInt32(ChoiceCodeD)).CoordinatorMobileNo.ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.AdmissionCancellationRequesttoCoordinator);



                            Response.Redirect("../CandidateAdmissionReportingModule/frmProformaO.aspx?ChoiceCode=" + ChoiceCode.ToString() + "&CAPRound=" + CAPRound.ToString());
                        }
                        else
                        {
                            shInfo.SetMessage("Wrong Password. Please try again.", ShowMessageType.Information);
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
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                Int64 result = reg.authenticateCandidateLogin(Session["UserLoginID"].ToString(), DataEncryption.EncryptDataByHashSHA1(txtPassword.Text));
                if (result > 0)
                {
                    trPasword.Visible = false;
                    trpasswordbtn.Visible = false;
                    tblOtp.Visible = true;
                    trotpbtn.Visible = true;
                    tryesno.Visible = false;

                    long PID = reg.getPersonalID(Session["UserLoginID"].ToString());
                    SMSTemplate sMSTemplate = new SMSTemplate();
                    sMSTemplate.PID = PID;
                    SynCommon synCommon = new SynCommon();
                    if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.AdmissionCancelOTP))
                    {
                        lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(PID).ToString()));
                        trMobileNo.Visible = true;
                        btnCall.Visible = true;
                        hdnPassword.Value = txtPassword.Text;
                        btnCall.Visible = true;
                        txtOneTimePassword.Focus();
                        btnProceed.Visible = false;
                    }
                    //SMS objSMS = new SMS();
                    //DataSet ds = reg.GetSMSEmailContent(objSessionData.PID, "Admission Cancel OTP", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                    //if (ds.Tables[1] != null)
                    //{
                    //    if (ds.Tables[1].Rows.Count > 0)
                    //    {
                    //        lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[1].Rows[0]["MobileNo"].ToString())).ToString();
                    //        trMobileNo.Visible = true;
                    //        btnCall.Visible = true;
                    //        hdnPassword.Value = txtPassword.Text;
                    //        btnCall.Visible = true;
                    //        txtOneTimePassword.Focus();
                    //        btnProceed.Visible = false;
                    //        string smsTemplate = ConfigurationManager.AppSettings["Project_Name"].ToString() + " : Dear " + Session["UserLoginID"].ToString() + ", Your OTP for Admission Cancellation is " + ds.Tables[1].Rows[0]["OTP"].ToString() + " for " + lblInstituteAdmitted.Text + " ChoiceCode -" + hdnchoiceCode.Value + " - " + lblSeatTypeAdmitted.Text + " IP " + UserInfo.GetIPAddress() + " at " + DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                    //        objSMS.sendOTPSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[1].Rows[0]["MobileNo"].ToString()), smsTemplate, ds.Tables[1].Rows[0]["OTP"].ToString());
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
                    shInfo.SetMessage("Password does not Match.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
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
        private DataSet getPreviousOTPForCapI(long PID)
        {
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_getOTPForCapI", new SqlParameter[]
            {
            new SqlParameter("@PersonalID", PID)
            });


            db.Dispose();
            return ds;
        }
        private bool saveOTPForCapI(long PID, string OTP)
        {
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_saveOTPForCapI", new SqlParameter[]
            {
            new SqlParameter("@PersonalID", PID),
            new SqlParameter("@OTPForCapI", OTP)
            });


            db.Dispose();
            if (ds.Tables[0].Rows[0]["result"].ToString() == "1")
                return true;
            else
                return false;
        }
    }
}