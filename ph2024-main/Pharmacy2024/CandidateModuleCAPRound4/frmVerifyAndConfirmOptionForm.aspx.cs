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

namespace Pharmacy2024.CandidateModuleCAPRound4
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
            if (Global.OptionFormFillingCAPRound4 == 0)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=2", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsCurrentLink = reg.getCurrentLinkCAPRound4(objSessionData.PID, "frmConfirmOptionForm.aspx");

                    hdnStepID.Value = (objSessionData.StepIDCAPRound4 + 1).ToString();
                    a_1.HRef = objSessionData.StepIDCAPRound4 + 1 >= Convert.ToInt32(a_1.ID.Split('_')[1]) ? "frmShortListOptions.aspx?tms=101" : "#";
                    a_2.HRef = objSessionData.StepIDCAPRound4 + 1 >= Convert.ToInt32(a_2.ID.Split('_')[1]) ? "frmSetPreferences.aspx?tms=101" : "#";
                    a_3.HRef = objSessionData.StepIDCAPRound4 + 1 >= Convert.ToInt32(a_3.ID.Split('_')[1]) ? "frmOptionFormSummary.aspx?tms=101" : "#";
                    a_4.HRef = objSessionData.StepIDCAPRound4 + 1 >= Convert.ToInt32(a_4.ID.Split('_')[1]) ? "frmConfirmOptionForm.aspx?tms=101" : "#";

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if (objSessionData.EligibleForCAPRound4 == 0)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                    }
                    if (objSessionData.OptionFormStatusCAPRound4 == 'A' || objSessionData.StepIDCAPRound4 < 3)
                    {
                        Response.Redirect("../CandidateModuleCAPRound4/frmOptionForm.aspx?tms=101", true);
                    }

                    if (!reg.checkPreferenceNoCAPRound4(objSessionData.PID))
                    {
                        Response.Redirect("../CandidateModuleCAPRound4/frmSetPreferences.aspx?tms=101");
                    }

                    if (!reg.isCandidateSelectedOptionsCAPRound4(objSessionData.PID))
                    {
                        Response.Redirect("../CandidateModuleCAPRound4/frmSetPreferences.aspx?tms=101");
                    }

                    string strInvalidChoiceCodes = reg.getInvalidChoiceCodeListCAPRound4(objSessionData.PID);
                    if (strInvalidChoiceCodes.Length > 6)
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = false;
                        shInfo.SetMessage("List of Invalid Choice Codes : <br />" + strInvalidChoiceCodes + "<br />Please remove these Choice Codes from your Preferences and then Confirm your Option Form.", ShowMessageType.Information);
                    }

                    //DataSet ds = reg.getPreferancedOptionsListCAPRound4(objSessionData.PID);
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

                    //if (gvPreferencedOptionsList.Rows.Count == 0)
                    //{
                    //    Response.Redirect("../CandidateModuleCAPRound4/frmSetPreferences.aspx?tms=101");
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

                if (verifyOTPForCapI(objSessionData.PID, txtOneTimePassword.Text))
                {
                    switch (reg.confirmOptionFormCAPRound4(objSessionData.PID, DataEncryption.EncryptDataByHashSHA1(hdnPassword.Value), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        case 0:
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                            break;
                        case 1:
                            shInfo.SetMessage("Invalid Password.", ShowMessageType.Information);
                            break;
                        case 2:
                            objSessionData.StepIDCAPRound4 = 4;
                            objSessionData.OptionFormStatusCAPRound4 = 'A';
                            Session["SessionData"] = objSessionData;
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = objSessionData.PID;
                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.OptionFormStartCAPI);
                            Response.Redirect("../CandidateModuleCAPRound4/frmOptionForm.aspx?tms=101");
                            break;
                        case 3:
                            if (objSessionData.StepIDCAPRound4 < 4)
                            {
                                objSessionData.StepIDCAPRound4 = 4;
                            }

                            if (objSessionData.OptionFormStatusCAPRound4 == 'C')
                            {
                                objSessionData.OptionFormStatusCAPRound4 = 'A';
                            }
                            SMSTemplate sMSTemplate1 = new SMSTemplate();
                            SynCommon synCommon1 = new SynCommon();
                            sMSTemplate1.PID = objSessionData.PID;
                            Session["SessionData"] = objSessionData;
                            sMSTemplate1.MobileNo= DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID));
                            synCommon1.SendInformationSMS(sMSTemplate1, SynCommon.TemplateSystemType.OptionFormStartCAPI);
                            Response.Redirect("../CandidateModuleCAPRound4/frmOptionForm.aspx?tms=101");
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

                Int64 result = reg.authenticateCandidateLogin(Session["UserLoginID"].ToString(), DataEncryption.EncryptDataByHashSHA1(txtPassword.Text));
                if (result > 0)
                {
                    tblPasword.Visible = false;
                    tblOtp.Visible = true;
                    string MobileNo = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID));
                    string OTP = UserInfo.GenerateOTP();

                    SMSTemplate sMSTemplate = new SMSTemplate();
                    sMSTemplate.PID = objSessionData.PID;
                    SynCommon synCommon = new SynCommon();
                    SMS objSMS = new SMS();
                    if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OtpMobileChange))
                    {
                        hdnPassword.Value = txtPassword.Text;
                        btnCall.Visible = true;
                        this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
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