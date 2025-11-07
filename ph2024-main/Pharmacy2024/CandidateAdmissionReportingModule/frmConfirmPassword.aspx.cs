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

namespace Pharmacy2024.CandidateAdmissionReportingModule
{
    public partial class frmConfirmPassword : System.Web.UI.Page
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
                    DataSet ds = reg.getAdmittedChoiceCodeListForCancellation(objSessionData.PID);

                    lblApplicationID.Text = Session["UserLoginID"].ToString();
                    lblCandidateName.Text = reg.getCandidateName(objSessionData.PID);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ContentTable2.Visible = false;
                        shInfo.SetMessage("You are NOT ADMITTED in any Institute till Now. So you can not give Willingness for Cancellation of Admission.", ShowMessageType.Information);
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
                Int64 PID = reg.authenticateCandidateLogin(lblApplicationID.Text, DataEncryption.EncryptDataByHashSHA1(txtCandidatePassword.Text));
                if (PID == 0)
                {
                    shInfo.SetMessage("Wrong Password.", ShowMessageType.Information);
                }
                else
                {
                    //DataSet ds = reg.getSMSContent(PID, "Request for Admission Cancellation");
                    //SMS objSMS = new SMS();
                    //objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[0].Rows[0]["MobileNo"].ToString()), ConfigurationManager.AppSettings["Project_Name"].ToString() + " : " + ds.Tables[0].Rows[0]["SMSContent"].ToString());

                    Response.Redirect("../CandidateAdmissionReportingModule/frmSelectChoiceCodeForAdmissionCancellation.aspx");
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