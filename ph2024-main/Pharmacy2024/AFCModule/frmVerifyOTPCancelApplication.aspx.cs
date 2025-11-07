using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmVerifyOTPCancelApplication : System.Web.UI.Page
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) == 91 || Convert.ToInt32(Session["UserTypeID"].ToString()) == 43)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if ((DateTime.Now < Global.DocumentVerificationStartDateTime || DateTime.Now > Global.DocumentVerificationEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                    shInfo.SetMessage("The OTP for cancel Application Form is Sent on registered mobile number  " + DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey((reg.getMobileNo(PID)))).ToString() + " OTP is valid for 20 mins.", ShowMessageType.Information);
                    if (PID.GetHashCode() != Convert.ToInt32(Code))
                    {
                        Response.Write("<BR /><BR /><center><H1>You are not Authorised to see the login details.</H1></center>");
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            if ((DateTime.Now < Global.DocumentVerificationStartDateTime || DateTime.Now > Global.DocumentVerificationEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                string ApplicationID = "PH19" + PID.ToString();

                if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, 3))
                {
                    string reasonForCancellation = Request.QueryString["ReasonForCancellation"].ToString();

                    if (reg.cancelConfirmedApplicationForm(PID, reasonForCancellation, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        if (Global.SendSMSToCandidate == 1)
                        {
                            DataSet ds = reg.getApplicationFormCancellationDetails(PID);
                            if (ds != null && ds.Tables.Count > 0)
                            {
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = PID;
                                sMSTemplate.CancelledBy = ds.Tables[0].Rows[0]["CancelledBy"].ToString();
                                sMSTemplate.CancelledDateTime = ds.Tables[0].Rows[0]["CancelledDateTime"].ToString();
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CancelApplicationForm);
                            }
                            //DataSet ds = reg.getSMSContent(PID, "CancelConfirmedApplicationForm");
                            //SMS objSMS = new SMS();
                            //objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[0].Rows[0]["MobileNo"].ToString()), ConfigurationManager.AppSettings["Project_Name"].ToString() + " : " + ds.Tables[0].Rows[0]["SMSContent"].ToString());
                        }

                        ContentTable1.Visible = false;
                        shInfo.SetMessage("Application Form Cancelled Successfully.", ShowMessageType.Information);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in cancellation. Please try after some time.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("You have Entered Wrong One Time Password. Please Try Again.", ShowMessageType.Information);
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
            if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

                ClientScript.RegisterStartupScript(GetType(), "id", "showRetryTiemout()", true);
                string MobileNo = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(PID));

                SMS objSMS = new SMS();
                objSMS.voiceCallOTP(MobileNo);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}