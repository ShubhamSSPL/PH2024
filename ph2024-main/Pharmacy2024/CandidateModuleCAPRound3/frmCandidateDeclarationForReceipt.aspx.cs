using AjaxPro;
using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModuleCAPRound3
{
    public partial class frmCandidateDeclarationForReceipt : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        AzureDocumentUpload objDU = new AzureDocumentUpload();

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
            // Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx");
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["UserTypeID"].ToString() != "91")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(frmCandidateDeclarationForReceipt));
            if (!IsPostBack)
            {

                Int64 PID = Convert.ToInt64(reg.getPersonalID(Session["UserLoginID"].ToString()));
                ViewState["PID"] = PID;
                DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplayInOptionForm(PID);

                if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                {
                    btnNo.Visible = true;
                    btnEWSNo.Visible = true;

                    lblApplicationID.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblCandidateName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CandidateName"].ToString();
                    lblGender.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["Gender"].ToString();
                    lblDOB.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["DOB"].ToString();
                    lblCandidatureType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                    lblHomeUniversity.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                    lblCategoryForAdmission.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalCategory"].ToString();
                    lblPHType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalPHType"].ToString();
                    lblDefenceType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                    lblAppliedForTFWS.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                    lblMinorityCandidatureType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
                    lblAppliedforEWS.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                    lblAppliedforOrphan.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                }
                PageLoad(1);
                //fillDropdown();
            }
        }




        private void PageLoad(int status)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            DataSet ds = reg.CheckCandidateValid(Convert.ToInt64(ViewState["PID"]));
            tblPasword.Visible = false;
            tblOtp.Visible = false;
            cbPassword.Visible = false;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["DocType"].ToString() == "CVC" || dr["DocType"].ToString() == "NCL")
                        {

                            ContentBox1.Visible = true;

                        }

                        if (dr["DocType"].ToString() == "EWS")
                        {

                            ContentBoxEWS.Visible = true;
                            ContentBoxEWSOpen.Visible = false;
                        }
                    }

                }
                else
                {
                    if (status == 1)
                        shInfo.SetMessage("you have uploaded all the required document you are not required to do anything.", ShowMessageType.Information);

                    ContentBox1.Visible = false;
                    ContentBoxEWS.Visible = false;
                    ContentBoxEWSOpen.Visible = false;
                }
            }
            else
            {
                if (status == 1)
                    shInfo.SetMessage("you have uploaded all the required document you are not required to do anything.", ShowMessageType.Information);

                ContentBox1.Visible = false;
                ContentBoxEWS.Visible = false;
                ContentBoxEWSOpen.Visible = false;
            }
        }



        protected void btnYes_Click(object sender, EventArgs e)
        {
            contentDocumentConferamtion.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowConfirmationBox();", true);
        }
        protected void btnYesR_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                DataSet dsC = null;
                if (chkIAgree.Checked)
                {
                    dsC = new dbUtilitySEBC().SaveContinueWithReceiptCandidate(objSessionData.PID, "Y", Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress());

                    Response.Redirect("../CandidateModuleCAPRound3/frmOptionForm.aspx", true);
                    //shInfo.SetMessage("Registration for ACAP / Non-CAP admissions will be start on 26 Nov 2021.", ShowMessageType.Information);
                }
                else
                {
                    lblDisplayDocumentSubmissionStatus.Text = "Please accept that you have read all Important Instructions";
                    contentDocumentConferamtion.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowConfirmationBox();", true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnNoR_Click(object sender, EventArgs e)
        {

        }
        protected void btnYesRC_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                if (chkIAgreeCON.Checked)
                {
                    ContentBox2.Visible = true;
                    ContentBox1.Visible = false;
                    ContentBox2.Focus();
                }
                else
                {
                    lblDisplayDocumentSubmissionStatusCON.Text = "Please accept that you have read all Important Instructions";
                    contentDocumentConferamtion.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowConfirmationBoxCON();", true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnNoRCEWS_Click(object sender, EventArgs e)
        {

        }
        protected void btnYesRCEWS_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                if (chkIAgreeEWS.Checked)
                {
                    ContentBoxEWSOpen.Visible = true;
                    ContentBoxEWS.Visible = false;
                    ContentBoxEWSOpen.Focus();
                }
                else
                {
                    lblDisplayDocumentSubmissionStatusEWS.Text = "Please accept that you have read all Important Instructions";
                    contentDocumentConferamtionEWS.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowConfirmationBoxEWS();", true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnNoRC_Click(object sender, EventArgs e)
        {

        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            contentDocumentConferamtion.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowConfirmationBoxCON();", true);
        }
        protected void btnConvertToOpen_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            tblPasword.Visible = true;
            tblOtp.Visible = false;
            cbPassword.Visible = true;
            ViewState["DocType"] = "CVCNCL";
            cbPassword.HeaderText = "CVC/TVC/NCL OTP";
            cbPassword.Focus();

        }

        protected void btnEWSNo_Click(object sender, EventArgs e)
        {
            //ContentBoxEWSOpen.Visible = true;
            // ContentBoxEWS.Visible = false;
            contentDocumentConferamtionEWS.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowConfirmationBoxEWS();", true);
        }
        protected void btnEWSConvertToOpen_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            tblPasword.Visible = true;
            tblOtp.Visible = false;
            cbPassword.Visible = true;
            ViewState["DocType"] = "EWS";
            cbPassword.HeaderText = "EWS OTP";
            cbPassword.Focus();

        }


        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                DataSet dsCOE = null;
                string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();
                if (reg.CheckCandidateCVCTVCEWSStatus(objSessionData.PID))
                {
                    if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, (int)SynCommon.TemplateSystemType.CategoryConversionOTP))
                    {

                        if (ViewState["DocType"].ToString() == "CVCNCL")
                        {
                            if (reg.CategoryConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
                            {
                                ContentBox1.Visible = false;
                                ContentBox2.Visible = false;
                                //ContentBox3.Visible = true;
                                Session["SessionData"] = objSessionData;
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = objSessionData.PID;
                                sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CVCNCLConvertOpen);
                                dsCOE = new dbUtilitySEBC().SaveContinueWithReceiptCandidate(objSessionData.PID, "O", Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress());

                                Response.Redirect("../CandidateModuleCAPRound3/frmOptionForm.aspx", true);
                            }
                            else
                            {
                                shInfo.SetMessage("There is some problem in Category Conversion Please try again.", ShowMessageType.Information);
                            }
                        }
                        else if (ViewState["DocType"].ToString() == "EWS")
                        {
                            if (reg.CategoryEWSConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
                            {
                                ContentBoxEWS.Visible = false;
                                ContentBoxEWSOpen.Visible = false;
                                Session["SessionData"] = objSessionData;
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = objSessionData.PID;
                                sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EWSConvertNo);

                                dsCOE = new dbUtilitySEBC().SaveContinueWithReceiptCandidate(objSessionData.PID, "E", Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress());

                                Response.Redirect("../CandidateModuleCAPRound3/frmOptionForm.aspx", true);
                            }
                            else
                            {
                                shInfo.SetMessage("There is some problem in Category Conversion Please try again.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Conversion Please try again.", ShowMessageType.Information);
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
                    shInfo.SetMessage("Candidate is  not Eligible to upload CVC / TVC or CVC / TVC already uploaded Please check the Documents.", ShowMessageType.Information);
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
                    if (Global.IsOTPCategoryConversion == 1)
                    {
                        tblPasword.Visible = false;
                        tblOtp.Visible = true;

                        hdnPassword.Value = txtPassword.Text;
                        btnCall.Visible = true;
                        long PID = objSessionData.PID;
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        sMSTemplate.PID = PID;
                        SynCommon synCommon = new SynCommon();
                        if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.CategoryConversionOTP))
                        {
                            trMobileNo.Visible = true;
                            lblMaskMobileno.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(objSessionData.PID).ToString())).ToString();
                            lblMaskMobileno.Visible = true;
                        }
                        this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                    }
                    else
                    {
                        //if (ViewState["DocType"].ToString() == "CVCNCL")
                        //{
                        //    if (reg.CategoryConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
                        //    {
                        //        ContentBox1.Visible = false;
                        //        ContentBox2.Visible = false;
                        //        //ContentBox3.Visible = true;
                        //        Session["SessionData"] = objSessionData;
                        //        SMSTemplate sMSTemplate = new SMSTemplate();
                        //        SynCommon synCommon = new SynCommon();
                        //        sMSTemplate.PID = objSessionData.PID;
                        //        sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                        //        sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                        //        if (Global.SendSMSToCandidate == 1)
                        //            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CVCNCLConvertOpen);
                        //        PageLoad(0);
                        //        shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
                        //    }
                        //    else
                        //    {
                        //        shInfo.SetMessage("There is some problem in Category Conversion Please try again.", ShowMessageType.Information);
                        //    }
                        //}
                        //else if (ViewState["DocType"].ToString() == "EWS")
                        //{
                        //    if (reg.CategoryEWSConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
                        //    {
                        //        ContentBoxEWS.Visible = false;
                        //        ContentBoxEWSOpen.Visible = false;
                        //        //ContentBox3.Visible = true;
                        //        Session["SessionData"] = objSessionData;
                        //        SMSTemplate sMSTemplate = new SMSTemplate();
                        //        SynCommon synCommon = new SynCommon();
                        //        sMSTemplate.PID = objSessionData.PID;
                        //        sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                        //        sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                        //        if (Global.SendSMSToCandidate == 1)
                        //            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EWSConvertNo);
                        //        PageLoad(0);
                        //        shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
                        //    }
                        //    else
                        //    {
                        //        shInfo.SetMessage("There is some problem in Category Conversion Please try again.", ShowMessageType.Information);
                        //    }
                        //}
                        //else
                        // {
                        shInfo.SetMessage("There is some problem in Conversion Please try again.", ShowMessageType.Information);
                        // }

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


        private class dbUtilitySEBC
        {
            public DataSet SaveContinueWithReceiptCandidate(Int64 PID, string IsContinueWithR, string FileUploadedBy, string FileUploadedByIPAddress)
            {
                SqlParameter[] param =
                   {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@IsContinueWithR",SqlDbType.Char),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),

                };

                param[0].Value = PID;
                param[1].Value = IsContinueWithR;
                param[2].Value = FileUploadedBy;
                param[3].Value = FileUploadedByIPAddress;

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spSaveContinueWithReceiptCandidate", param);

                }
                finally
                {
                    db.Dispose();
                }
            }

        }
    }
}