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

namespace Pharmacy2024.AFCModule
{
    public partial class frmChangeName : System.Web.UI.Page
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

        private DataSet GetNameChangeRequestDetails(Int64 PID)
        {
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_GetCandidateNameChangeRequestDetails", new SqlParameter[]
                    {
                    new SqlParameter("@PersonalID", PID)
                    });
            db.Dispose();
            return ds;
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

                    DataSet ds = GetNameChangeRequestDetails(PID);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        AzureDocumentUpload azObj = new AzureDocumentUpload();
                        imgPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(PID, "Photograph"));
                        lblOldMobileNo.Text = ds.Tables[0].Rows[0]["OldCandidateName"].ToString();
                        lblNewMobileNo.Text = ds.Tables[0].Rows[0]["NewCandidateName"].ToString();
                        if (ds.Tables[0].Rows[0]["ApprovedStatus"].ToString() == "1")
                        {
                            shInfo.SetMessage("This Request is Already Approved.", ShowMessageType.Information);
                            btnProceed.Visible = false;
                            btnCall.Visible = false;

                        }
                    }
                    else
                    {
                        imgPhotograph.Visible = false;
                        trNewMobileNo.Visible = false;
                        trOldMobileNo.Visible = false;
                        btnProceed.Visible = false;
                        btnCall.Visible = false;
                        shInfo.SetMessage("This Candidate has not given Request for Correction in Name.", ShowMessageType.Information);
                    }




                    //lblOldMobileNo.Text = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(PID));
                    // trNewMobileNo.Visible = false;
                    // trMobileNo.Visible = true;
                    trOTP.Visible = false;
                    btnProceed.Text = "Send OTP";
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                string MobileNo = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(PID));
                if (btnProceed.Text == "Send OTP")
                {
                    //string MobileNo = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(PID));
                    hdnMobileNo.Value = DataEncryption.EncryptDataByEncryptionKey(MobileNo);
                    SMSTemplate sMSTemplate = new SMSTemplate();
                    sMSTemplate.PID = PID;
                    SynCommon synCommon = new SynCommon();
                    if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.ChangeNameOTP))
                        trNewMobileNo.Visible = true;
                    btnCall.Visible = true;
                    //  trMobileNo.Visible = false;
                    trOTP.Visible = true;
                    btnProceed.Text = "Verify OTP";
                    //}
                    shInfo.SetMessage("One Time Password (OTP) for Verification of Your Mobile Number is sent to " + DataEncryption.MaskMobileNo(MobileNo) + ".", ShowMessageType.Information);
                    //}
                    //else
                    //{
                    //    btnCall.Visible = false;
                    //    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                    //}
                }
                else if (btnProceed.Text == "Verify OTP")
                {
                    if (reg.verifyOTP(Global.ApplicationFormPrefix + PID.ToString(), txtOneTimePassword.Text, 7))
                    {
                        // if (verifyOTPForNameChange(PID, txtOneTimePassword.Text))
                        //{
                        shInfo.SetMessage("Your Name has been Corrected from " + lblOldMobileNo.Text + " to " + lblNewMobileNo.Text + " .", ShowMessageType.Information);

                        // lblNewMobileNo.Text = txtMobileNo.Text;
                        trNewMobileNo.Visible = true;
                        //  trMobileNo.Visible = false;
                        trOTP.Visible = false;
                        btnProceed.Visible = false;
                        btnCall.Visible = false;
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
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
            string mobno = DataEncryption.DecryptDataByEncryptionKey(hdnMobileNo.Value);
            SMS objSMS = new SMS();
            objSMS.voiceCallOTP(mobno);
        }
        private bool verifyOTPForNameChange(long PID, string OTP)
        {


            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_verifyOTPForNameChange", new SqlParameter[]
                    {
                    new SqlParameter("@PersonalID", Request["PID"]),new SqlParameter("@OTP", OTP),
                    new SqlParameter("@ApprovedByIPAddress", UserInfo.GetIPAddress()), new SqlParameter("@ApprovedBy", Session["UserLoginID"].ToString() ),
                    new SqlParameter("@NewName", lblNewMobileNo.Text)
                    });
            db.Dispose();
            if (ds.Tables[0].Rows[0]["msg"].ToString() == "susccess")
                return true;
            else
                return false;
        }

        private bool saveOTPForNameChange(long PID, string OTP)
        {
            DBConnection db = new DBConnection();
            db.ExecuteNonQuery("sp_SaveOTPForNameChange", new SqlParameter[]
                    {
                    new SqlParameter("@PersonalID", Request["PID"]),new SqlParameter("@OTP", OTP)
                    });
            db.Dispose();
            return true;
        }

    }
}