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

namespace Pharmacy2024.CandidateAdmissionReportingModule
{
    public partial class frmUploadNCLCertificate : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["UserTypeID"].ToString() != "91")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(frmUploadNCLCertificate));
            if (!IsPostBack)
            {
                //Content1.Visable = false;
                Int64 PID = Convert.ToInt64(reg.getPersonalID(Session["UserLoginID"].ToString()));
                ViewState["PID"] = PID;
                DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplayInOptionForm(PID);
                int Step = 1;

                DataSet dsCurrentAllotmentDetails = reg.getCurrentAllotmentDetails(PID);
                if
                        (Step == 1 ||
                            (Global.CurrentCAPRoundForARCReporting == 1 &&
                             DateTime.Now >= Global.ARCReportingCAPRound1StartDateTime &&
                             DateTime.Now <= Global.ARCReportingCAPRound1EndDateTime) ||
                            (Global.CurrentCAPRoundForARCReporting == 2 &&
                             DateTime.Now >= Global.ARCReportingCAPRound2StartDateTime &&
                             DateTime.Now <= Global.ARCReportingCAPRound2EndDateTime) ||
                            (Global.CurrentCAPRoundForARCReporting == 3 &&
                             DateTime.Now >= Global.ARCReportingCAPRound3StartDateTime &&
                             DateTime.Now <= Global.ARCReportingCAPRound3EndDateTime) ||
                            (Global.CurrentCAPRoundForARCReporting == 4 &&
                             DateTime.Now >= Global.ARCReportingCAPRound4StartDateTime &&
                             DateTime.Now <= Global.ARCReportingCAPRound4EndDateTime)
                        )
                {
                    if (dsCurrentAllotmentDetails.Tables[0].Rows.Count > 0)
                    {
                        if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["Category_Benifited"].ToString() == "Yes")
                        {
                            btnNo.Visible = false;
                            btnEWSConvertToOpen.Visible = false;
                        }
                        else
                        {
                            btnNo.Visible = false;
                        }
                        if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["EWS_Benifited"].ToString() == "Yes")
                        {
                            btnEWSNo.Visible = false;
                            btnNCLConvertToOpen.Visible = false;
                        }
                        else
                        {
                            btnEWSNo.Visible = false;
                        }
                    }
                    if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                    {
                        if (dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalCategoryID"].ToString() == "10" /*|| dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalCategoryID"].ToString() == "8"*/)
                        {
                            btnNo.Visible = false;
                            btnEWSNo.Visible = false;

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
                            PageLoad(1);
                        }
                        else
                        {
                            ContentTable2.Visible = false;
                            ContentBox1.Visible = false;
                            ContentBox2.Visible = false;
                            ContentTableNCL.Visible = false;
                            ContentBoxNCL.Visible = false;
                            ContentBoxNCL.Visible = false;
                            ContentTableEWS.Visible = false;
                            ContentBoxEWS.Visible = false;
                            ContentBoxEWSOpen.Visible = false;
                            tblPersonalInfo.Visible = false;
                            upQualification.Visible = false;
                            tblnote.Visible = false;
                            contentFileTest.Visible = false;
                            contentViewDocument.Visible = false;
                            cbPassword.Visible = false;
                            shInfo.SetMessage("The Link has been closed to Upload Original document of CVC/TVC/NCL/EWS against the Receipt of CVC/TVC/NCL/EWS(except SEBC Candidates).", ShowMessageType.Information);
                        }

                    }

                    //fillDropdown();
                }
                else
                {
                    //ContentBox1.Visible = false;
                    //ContentTable2.Visible = false;
                    //ContentBox2.Visible = false;
                    //ContentBox3.Visible = false;
                    //ContentBoxNCL.Visible = false;
                    //ContentTableNCL.Visible = false;
                    //ContentBoxNCLOpen.Visible = false;
                    //ContentBoxEWS.Visible = false;
                    //ContentTableEWS.Visible = false;
                    //ContentBoxEWSOpen.Visible = false;
                    //contentFileTest.Visible = false;
                    ContentPlaceHolder mpContentPlaceHolder = new ContentPlaceHolder();
                    mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("rightContainer");
                    mpContentPlaceHolder.Visible = false;
                    shInfo.SetMessage("Link Is Closed .", ShowMessageType.Information);
                }


            }
        }
        protected void ddlDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string doctype = "";// ddlDocumentType.SelectedValue.ToString();
                if (doctype == "1")
                {
                    ContentTable2.Visible = false;
                    ContentBox1.Visible = true;
                    ContentBox2.Visible = false;
                }
                else if (doctype == "2")
                {
                    ContentTableNCL.Visible = false;
                    ContentBoxNCL.Visible = true;
                    ContentBoxNCLOpen.Visible = false;
                }
                else if (doctype == "3")
                {
                    ContentTableEWS.Visible = false;
                    ContentBoxEWS.Visible = true;
                    ContentBoxEWSOpen.Visible = false;
                }
                else
                {
                    ContentTable2.Visible = false;
                    ContentBox1.Visible = false;
                    ContentBox2.Visible = false;
                    ContentTableNCL.Visible = false;
                    ContentBoxNCL.Visible = false;
                    ContentBoxNCL.Visible = false;
                    ContentTableEWS.Visible = false;
                    ContentBoxEWS.Visible = false;
                    ContentBoxEWS.Visible = false;

                }


            }
            catch (Exception ex)
            {

            }
        }

        private void fillDropdown()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            //ddlDocumentType.Items.Clear();


            DataSet ds = reg.CheckCandidateValid(Convert.ToInt64(ViewState["PID"]));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["DocType"].ToString() == "CVC")
                        {
                            //  ddlDocumentType.Items.Insert(0, new ListItem("Cast Validity Certificate", "1"));
                        }
                        if (dr["DocType"].ToString() == "NCL")
                        {
                            // ddlDocumentType.Items.Insert(0, new ListItem("Non-Creamy Layer Certificate", "2"));
                        }
                        if (dr["DocType"].ToString() == "EWS")
                        {
                            // ddlDocumentType.Items.Insert(0, new ListItem("Economically Weaker Section In Proforma - V ", "3"));
                        }
                    }

                }
                else
                {
                    shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate , Non-Creamy Layer Certificate or Economically Weaker Section In Proforma - V you can't upload the Document.", ShowMessageType.Information);
                    ContentTable2.Visible = false;
                    ContentBox1.Visible = false;
                    ContentBox2.Visible = false;
                    ContentTableNCL.Visible = false;
                    ContentBoxNCL.Visible = false;
                    ContentBoxNCL.Visible = false;
                    ContentTableEWS.Visible = false;
                    ContentBoxEWS.Visible = false;
                    ContentBoxEWS.Visible = false;
                }
            }
            else
            {
                shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate , Non-Creamy Layer Certificate or Economically Weaker Section In Proforma - V you can't upload the Document.", ShowMessageType.Information);
                ContentTable2.Visible = false;
                ContentBox1.Visible = false;
                ContentBox2.Visible = false;
                ContentTableNCL.Visible = false;
                ContentBoxNCL.Visible = false;
                ContentBoxNCL.Visible = false;
                ContentTableEWS.Visible = false;
                ContentBoxEWS.Visible = false;
                ContentBoxEWS.Visible = false;
            }
            //ddlDocumentType.Items.Insert(0, new ListItem("-- Select Document --", "0"));
        }

        private void PageLoad(int status)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            tblPasword.Visible = false;
            tblOtp.Visible = false;
            cbPassword.Visible = false;
            DataSet ds = reg.CheckCandidateValid(Convert.ToInt64(ViewState["PID"]));
            ds.Tables[0].DefaultView.RowFilter = "DocType = 'NCL'";
            DataTable dt = (ds.Tables[0].DefaultView).ToTable();
            DataSet dst = new DataSet();
            dst.Tables.Add(dt);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dst.Tables[0].Rows)
                    {
                        if (dr["DocType"].ToString() == "NCL" /*|| dr["DocType"].ToString() == "NCL"*/)
                        {
                            ContentTable2.Visible = false;
                            ContentBox1.Visible = true;
                            ContentBox2.Visible = false;
                        }

                        //if (dr["DocType"].ToString() == "EWS")
                        //{
                        //    ContentTableEWS.Visible = false;
                        //    ContentBoxEWS.Visible = true;
                        //    ContentBoxEWSOpen.Visible = false;
                        //}

                        else
                        {
                            shInfo.SetMessage("you have uploaded all the required document you are not required to do anything.", ShowMessageType.Information);
                            ContentTable2.Visible = false;
                            ContentBox1.Visible = false;
                            ContentBox2.Visible = false;
                            ContentTableNCL.Visible = false;
                            ContentBoxNCL.Visible = false;
                            ContentBoxNCL.Visible = false;
                            ContentTableEWS.Visible = false;
                            ContentBoxEWS.Visible = false;
                            ContentBoxEWSOpen.Visible = false;
                        }
                    }

                }
                else
                {
                    if (status == 1)
                        //shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate , Non - Creamy Layer Certificate or Economically Weaker Section In Proforma - V you can't upload the Document.", ShowMessageType.Information);
                        shInfo.SetMessage("you have uploaded all the required document you are not required to do anything.", ShowMessageType.Information);
                    ContentTable2.Visible = false;
                    ContentBox1.Visible = false;
                    ContentBox2.Visible = false;
                    ContentTableNCL.Visible = false;
                    ContentBoxNCL.Visible = false;
                    ContentBoxNCL.Visible = false;
                    ContentTableEWS.Visible = false;
                    ContentBoxEWS.Visible = false;
                    ContentBoxEWSOpen.Visible = false;
                }
            }
            else
            {
                if (status == 1)
                    //shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate , Non - Creamy Layer Certificate or Economically Weaker Section In Proforma - V you can't upload the Document.", ShowMessageType.Information);
                    // commited by snehdeep
                    shInfo.SetMessage("you have uploaded all the required document you are not required to do anything.", ShowMessageType.Information);
                ContentTable2.Visible = false;
                ContentBox1.Visible = false;
                ContentBox2.Visible = false;
                ContentTableNCL.Visible = false;
                ContentBoxNCL.Visible = false;
                ContentBoxNCL.Visible = false;
                ContentTableEWS.Visible = false;
                ContentBoxEWS.Visible = false;
                ContentBoxEWSOpen.Visible = false;
            }
        }

        private void PageLodFalse()
        {
            ContentTable2.Visible = false;
            ContentBox1.Visible = false;
            ContentBox2.Visible = false;
            ContentTableNCL.Visible = false;
            ContentBoxNCL.Visible = false;
            ContentBoxNCL.Visible = false;
            ContentTableEWS.Visible = false;
            ContentBoxEWS.Visible = false;
            ContentBoxEWSOpen.Visible = false;
        }
        protected void btnSubmite_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                char CVCStatus = 'N';
                char NCLStatus = 'N';
                char EWSStatus = 'N';
                DataSet ds = new dbUtilitySEBC().GetAllDocuments(Convert.ToInt64(ViewState["PID"]));
                ds.Tables[0].DefaultView.RowFilter = "DocumentID = '24'";
                DataTable dt = (ds.Tables[0].DefaultView).ToTable();
                DataSet dst = new DataSet();
                dst.Tables.Add(dt);
                //ds.Tables[0].DefaultView.RowFilter = "(DocumentID = '24')"; //OR DocumentID = '24') AND IsSubmittedAtAFC='N'";
                if (dst.Tables[0].DefaultView.Count > 0)
                {
                    foreach (DataRow dr in dst.Tables[0].Rows)
                    {
                        if (dr["DocumentID"].ToString() == "22" && dr["FilePath1"].ToString() != "" && dr["IsSubmittedAtAFC"].ToString() == "N")
                        {
                            CVCStatus = 'Y';
                        }
                        if (dr["DocumentID"].ToString() == "24" && dr["FilePath1"].ToString() != "" && dr["IsSubmittedAtAFC"].ToString() == "N")
                        {
                            NCLStatus = 'Y';
                        }
                    }
                }
                int verifycnt = 0;
                for (Int32 i = 0; i < gvCVCNCL.Rows.Count; i++)
                {
                    if (gvCVCNCL.Rows[i].Cells[2].Text == "Yes")
                    {
                        verifycnt = verifycnt + 1;
                    }
                }
                if (verifycnt > 0)
                {
                    if (gvCVCNCL.Rows.Count == 2 && (verifycnt == 2 || (lblCategoryForAdmission.Text.ToString() == "SEBC$#" || lblCategoryForAdmission.Text.ToString() == "OBC$#"))) //NCL CVC
                    {
                        if (UploadCVCNCLCertificate(CVCStatus, NCLStatus, EWSStatus))
                        {
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();

                            sMSTemplate.PID = 0;

                            DataSet dsFCDetails = reg.getApplicationFormConfirmationDetails(Convert.ToInt64(ViewState["PID"]));

                            sMSTemplate.MobileNo = reg.getAFCProfile(dsFCDetails.Tables[0].Rows[0]["ConfirmedBy"].ToString().Substring(0, 6)).CoordinatorMobileNo.ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.DocumentVerificationRequest);


                            ContentTable2.Visible = false;
                            ContentBox1.Visible = false;
                            ContentBox2.Visible = false;
                            shInfo.SetMessage("Your CVC/TVC and / NCL Certificate has been Uploaded and e-SC will verify soon. You will be able to do your Self Verification and Seat Acceptance after Scrutiny by the eSC officer.", ShowMessageType.Information);
                        }
                    }
                    else if (gvCVCNCL.Rows.Count == 1 && verifycnt == 1)
                    {
                        if (UploadCVCNCLCertificate(CVCStatus, NCLStatus, EWSStatus))
                        {
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();

                            sMSTemplate.PID = 0;

                            DataSet dsFCDetails = reg.getApplicationFormConfirmationDetails(Convert.ToInt64(ViewState["PID"]));

                            sMSTemplate.MobileNo = reg.getAFCProfile(dsFCDetails.Tables[0].Rows[0]["ConfirmedBy"].ToString().Substring(0, 6)).CoordinatorMobileNo.ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.DocumentVerificationRequest);

                            ContentTable2.Visible = false;
                            ContentBox1.Visible = false;
                            ContentBox2.Visible = false;
                            shInfo.SetMessage("Your CVC/TVC and / NCL or EWS Certificate has been Uploaded and e-SC will verify soon. You will be able to do your Self Verification and Seat Acceptance after Scrutiny by the eSC officer.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        //shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                        shInfo.SetMessage("Please upload all the documents given in bellow List.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("You have not uploaded the Document.", ShowMessageType.Information);
                }
                //if (flUpload.HasFile)
                //{
                //    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                //    Stream objFileStream = flUpload.PostedFile.InputStream;
                //    FileInfo objFile = new FileInfo(flUpload.PostedFile.FileName);
                //    string sysfilename = (Session["UserID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + objFile.Extension).ToLower();
                //    fileurl = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, flUpload.PostedFile.ContentType);

                //    UploadCVCNCLCertificate(22, fileurl);
                //    fillDropdown();
                //    ContentTable2.Visible = false;
                //    shInfo.SetMessage("Document Uploaded Successfully. Please take fresh Acknowledgement.", ShowMessageType.Information);
                //}
                //else
                //{
                //    shInfo.SetMessage("Please Select File.", ShowMessageType.Information);
                //}
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            ContentTable2.Visible = true;
            ContentBox1.Visible = false;
            ContentBox2.Visible = false;
            LoadDocuments(Convert.ToInt64(ViewState["PID"]));
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            ContentBox2.Visible = true;
            ContentTable2.Visible = false;
            ContentBox1.Visible = false;
            ContentBox2.Focus();
        }
        protected void btnConvertToOpen_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //Check Extra Fees.
            tblPasword.Visible = true;
            tblOtp.Visible = false;
            cbPassword.Visible = true;
            ViewState["DocType"] = "CVCNCL";
            cbPassword.HeaderText = "CVC/TVC NCL OTP";
            cbPassword.Focus();
            //if (reg.CategoryConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
            //{
            //    ContentTable2.Visible = false;
            //    ContentBox1.Visible = false;
            //    ContentBox2.Visible = false;
            //    //ContentBox3.Visible = true;
            //    shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
            //}
            //else
            //{
            //    shInfo.SetMessage("There is some problem in Category Conversion Please try again.", ShowMessageType.Information);
            //}
        }
        protected void btnPayApplictionFormFee_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");


            Int64 PID = Convert.ToInt64(ViewState["PID"]);

            string EligibilityRemark = Convert.ToString(reg.getEligibilityFlag(PID));
            if (EligibilityRemark.Length > 0)
            {
                ContentTable2.Visible = false;
                shInfo.SetMessage(EligibilityRemark, ShowMessageType.Information);
            }
            else
            {
                Session["FeeGroupId"] = null;
                Session["PhaseId"] = null;
                Session["PayeeUserTypeId"] = null;
                Session["PayeeId"] = null;

                Session["FeeGroupId"] = "2";
                Session["PhaseId"] = "1";
                Session["PayeeUserTypeId"] = "91";
                Session["PayeeId"] = PID.ToString();

                Response.Redirect("../FeeProcess/PaymentDetails.aspx", true);
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void LoadDocuments(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            DataSet ds = null;
            //DocumentJWT docJWT = new DocumentJWT();
            try
            {
                //var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                //var expiryTime = Math.Round((DateTime.UtcNow.AddMinutes(5) - unixEpoch).TotalSeconds);
                //hdnFileTypes.Value = "0";
                //hdnFileTypesCode.Value = "0";
                //hdnMaxSize.Value = "0";
                //hdnMaxSizeCode.Value = "0";

                ds = new dbUtilitySEBC().GetAllDocuments(PID);
                ds.Tables[0].DefaultView.RowFilter = "DocumentID = '24'";  //OR DocumentID = '24' OR DocumentID = '36'";
                if (ds.Tables[0].DefaultView.Count > 0)
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "1")
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[0]["DocumentID"]) == "36")
                                {
                                    gvEWS.DataSource = ds.Tables[0].DefaultView;
                                    gvEWS.DataBind();
                                    gvEWS.Columns[3].Visible = true;
                                    gvEWS.Columns[5].Visible = true;

                                    for (int i = 0; i < gvEWS.Rows.Count; i++)
                                    {
                                        int DocumentID = Convert.ToInt32(((HiddenField)gvEWS.Rows[i].FindControl("hdnDocId")).Value);
                                    }
                                }
                                else
                                {
                                    gvCVCNCL.DataSource = ds.Tables[0].DefaultView;
                                    gvCVCNCL.DataBind();

                                    gvCVCNCL.Columns[3].Visible = true;
                                    gvCVCNCL.Columns[5].Visible = true;

                                    for (int i = 0; i < gvCVCNCL.Rows.Count; i++)
                                    {
                                        int DocumentID = Convert.ToInt32(((HiddenField)gvCVCNCL.Rows[i].FindControl("hdnDocId")).Value);
                                    }
                                }
                            }
                        }
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "0")
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[0]["DocumentID"]) == "36")
                            {
                                gvEWS.DataSource = null;
                                gvEWS.DataBind();
                                shInfo.SetMessage(Convert.ToString(ds.Tables[0].Rows[0]["Message"]), ShowMessageType.Information);
                            }
                            else
                            {
                                gvCVCNCL.DataSource = null;
                                gvCVCNCL.DataBind();
                                shInfo.SetMessage(Convert.ToString(ds.Tables[0].Rows[0]["Message"]), ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("No Data Found!!!", ShowMessageType.Information);
                        }
                    }
                }
                else
                {
                    // Create new DataTable and DataSource objects.
                    shInfo.SetMessage("No Data Found Eror !!!", ShowMessageType.Information);
                    //lblFileTypesAllowed.Text = hdnFileTypes.Value = Convert.ToString(ds.Tables[1].Rows[0]["FileExtensions"]);
                    // hdnMaxSize.Value = Convert.ToString(500);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError);
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
        }
        protected void gvCVCNCL_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (e.CommandName == "D")
            {
                Int32 DocId = Convert.ToInt32(e.CommandArgument);
                ImageButton img = (ImageButton)e.CommandSource;
                GridViewRow gr = (GridViewRow)(img.Parent.Parent);
                string fileName = ((System.Web.UI.WebControls.HiddenField)(gr.Cells[gr.Cells.Count - 1].Controls[1])).Value;
                DataSet ds = null;
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    ds = new dbUtilitySEBC().deleteUploadedDocument(objSessionData.PID, DocId, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                    {
                        LoadDocuments(objSessionData.PID);
                    }
                    else
                    {
                        shInfo.SetMessage("Unable To Delete File, Try Again Later.", ShowMessageType.Information);
                        LoadDocuments(objSessionData.PID);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.Information);
                }
                finally
                {
                    if (ds != null)
                    {
                        ds.Dispose();
                    }
                }
            }
        }
        protected void gvCVCNCL_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidFURL = (HiddenField)e.Row.FindControl("hidFURL");
                if (hidFURL.Value != "")
                {
                    string ext = System.IO.Path.GetExtension(hidFURL.Value).ToLower();
                    HtmlImage imgDoc = (HtmlImage)e.Row.FindControl("imgDoc");
                    HiddenField hidDID = (HiddenField)e.Row.FindControl("hidDID");
                    HiddenField hdnDocId = (HiddenField)e.Row.FindControl("hdnDocId");
                    HtmlAnchor hrefURL = (HtmlAnchor)e.Row.FindControl("hrefURL");
                    Label lblStatus = (Label)e.Row.FindControl("lblIsSubmittedAtAFC");
                    ImageButton imageButton = (ImageButton)e.Row.FindControl("btndelete");
                    hrefURL.HRef = ConfigurationManager.AppSettings["ApplicationURL"] + "ViewMyDocument.aspx?documentID=" + hidDID.Value;
                    HiddenField hdnImgByteArray = (HiddenField)e.Row.FindControl("hdnImgByteArray");
                    string[] docID = { "22", "24" };
                    if (Array.Exists(docID, elem => elem == hdnDocId.Value))
                    {
                        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".bmp")
                        {
                            string url = hidFURL.Value;
                            if (hidFURL.Value.Contains("studentdocuments"))
                            {
                                url = hidFURL.Value.Replace("studentdocuments", "studentdocumentsthumbnail");
                                string checkurl = url.Replace(ConfigurationManager.AppSettings["HttpAddress"], "");
                                if (!objDU.Exists(checkurl))
                                {
                                    url = hidFURL.Value;
                                }
                            }
                            string base64 = objDU.GetBlobContentAsBase64("studentdocumentsthumbnail", url);//objDU.ConvertImageURLToBase64(url);
                            imgDoc.Src = base64; //"data:image/png;base64," +
                        }
                        else if (ext == ".pdf")
                        {
                            imgDoc.Src = "../images/pdf.gif";
                        }
                        else if (ext == ".zip" || ext == ".rar")
                        {
                            hrefURL.Target = "self";
                            imgDoc.Src = "../images/zip.png";
                        }
                        hdnImgByteArray.Value = objDU.GetBlobContentAsBase64("studentdocuments", hidFURL.Value.ToString());
                        if (lblStatus.Text == "Y")
                        {
                            imageButton.Visible = false;
                            lblStatus.Text = "Verified by eSC";
                            lblStatus.BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblStatus.Text = "Not Verified by eSC";
                            lblStatus.BackColor = System.Drawing.Color.LightPink;
                        }

                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                }
            }
        }



        private DataSet CheckCVCNCLDocumentsStatus(Int64 PID)
        {
            DBConnection db = new DBConnection();
            DataSet ds;
            try
            {
                ds = db.ExecuteDataSet("sp_CheckCVC_NCL_DocumentsStatus", new SqlParameter[]
                {
                new SqlParameter("@PID", PID)
                });
            }
            finally
            {
                db.Dispose();
            }
            return ds;
        }

        protected void btnUploadComplete_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            LoadDocuments(objSessionData.PID);
        }

        private bool UploadCVCNCLCertificate(char CVCStatus, char NCLStatus, char EWSStatus)
        {
            DBConnection db = new DBConnection();
            try
            {
                int result = Convert.ToInt32(db.ExecuteScaler("MHDTE_spUploadCVCNCLDocument", new SqlParameter[]
                  {
                new SqlParameter("@PID", Convert.ToInt64(ViewState["PID"])),
               // new SqlParameter("@DocumentID", DocumentID),
                //new SqlParameter("@FilePath", FilePath),
                new SqlParameter("@ModifiedBy", Convert.ToString(Session["UserLoginID"])),
                new SqlParameter("@ModifiedByIPAddress", UserInfo.GetIPAddress()),
                 new SqlParameter("@CVC", CVCStatus),
                  new SqlParameter("@NCL", NCLStatus),
                   new SqlParameter("@EWS", EWSStatus)
                  }));
                if (result > 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                db.Dispose();
            }
        }



        protected void btnNCLYes_Click(object sender, EventArgs e)
        {
            ContentTableNCL.Visible = true;
            ContentBoxNCL.Visible = false;
            ContentBoxNCLOpen.Visible = false;
            LoadDocuments(Convert.ToInt64(ViewState["PID"]));
        }
        protected void btnNCLNo_Click(object sender, EventArgs e)
        {
            ContentBoxNCLOpen.Visible = true;
            ContentTableNCL.Visible = false;
            ContentBoxNCL.Visible = false;
        }
        protected void btnNCLConvertToOpen_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //Check Extra Fees.

            if (reg.CategoryConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
            {
                ContentTable2.Visible = false;
                ContentBox1.Visible = false;
                ContentBox2.Visible = false;
                //ContentBox3.Visible = true;
                fillDropdown();
                shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
            }
            else
            {
                shInfo.SetMessage("There is some problem in Category Conversion Please try again.", ShowMessageType.Information);
            }
        }


        protected void btnEWSYes_Click(object sender, EventArgs e)
        {
            ContentTableEWS.Visible = true;
            ContentBoxEWS.Visible = false;
            ContentBoxEWSOpen.Visible = false;
            LoadDocuments(Convert.ToInt64(ViewState["PID"]));
        }
        protected void btnEWSNo_Click(object sender, EventArgs e)
        {
            ContentBoxEWSOpen.Visible = true;
            ContentTableEWS.Visible = false;
            ContentBoxEWS.Visible = false;
        }
        protected void btnEWSConvertToOpen_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //Check Extra Fees.
            tblPasword.Visible = true;
            tblOtp.Visible = false;
            cbPassword.Visible = true;
            ViewState["DocType"] = "EWS";
            cbPassword.HeaderText = "EWS OTP";
            cbPassword.Focus();
            //if (reg.CategoryEWSConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
            //{
            //    ContentTable2.Visible = false;
            //    ContentBox1.Visible = false;
            //    ContentBox2.Visible = false;
            //    //ContentBox3.Visible = true;
            //    fillDropdown();
            //    shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
            //}
            //else
            //{
            //    shInfo.SetMessage("There is some problem in Category Conversion Please try again.", ShowMessageType.Information);
            //}
        }

        protected void gvEWS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (e.CommandName == "D")
            {
                Int32 DocId = Convert.ToInt32(e.CommandArgument);
                ImageButton img = (ImageButton)e.CommandSource;
                GridViewRow gr = (GridViewRow)(img.Parent.Parent);
                string fileName = ((System.Web.UI.WebControls.HiddenField)(gr.Cells[gr.Cells.Count - 1].Controls[1])).Value;
                DataSet ds = null;
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    ds = new dbUtilitySEBC().deleteUploadedDocument(objSessionData.PID, DocId, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                    {
                        LoadDocuments(objSessionData.PID);
                    }
                    else
                    {
                        shInfo.SetMessage("Unable To Delete File, Try Again Later.", ShowMessageType.Information);
                        LoadDocuments(objSessionData.PID);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.Information);
                }
                finally
                {
                    if (ds != null)
                    {
                        ds.Dispose();
                    }
                }
            }
        }
        protected void gvEWS_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidFURL = (HiddenField)e.Row.FindControl("hidFURL");
                if (hidFURL.Value != "")
                {
                    string ext = System.IO.Path.GetExtension(hidFURL.Value).ToLower();
                    HtmlImage imgDoc = (HtmlImage)e.Row.FindControl("imgDoc");
                    HiddenField hidDID = (HiddenField)e.Row.FindControl("hidDID");
                    HiddenField hdnDocId = (HiddenField)e.Row.FindControl("hdnDocId");
                    HtmlAnchor hrefURL = (HtmlAnchor)e.Row.FindControl("hrefURL");
                    Label lblStatus = (Label)e.Row.FindControl("lblIsSubmittedAtAFC");
                    ImageButton imageButton = (ImageButton)e.Row.FindControl("btndelete");
                    hrefURL.HRef = ConfigurationManager.AppSettings["ApplicationURL"] + "ViewMyDocument.aspx?documentID=" + hidDID.Value;
                    HiddenField hdnImgByteArray = (HiddenField)e.Row.FindControl("hdnImgByteArray");
                    string[] docID = { "22", "24", "36" };
                    if (Array.Exists(docID, elem => elem == hdnDocId.Value))
                    {
                        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".bmp")
                        {
                            string url = hidFURL.Value;
                            if (hidFURL.Value.Contains("studentdocuments"))
                            {
                                url = hidFURL.Value.Replace("studentdocuments", "studentdocumentsthumbnail");
                                string checkurl = url.Replace(ConfigurationManager.AppSettings["HttpAddress"], "");
                                if (!objDU.Exists(checkurl))
                                {
                                    url = hidFURL.Value;
                                }
                            }
                            string base64 = objDU.GetBlobContentAsBase64("studentdocumentsthumbnail", url);//objDU.ConvertImageURLToBase64(url);
                            imgDoc.Src = base64; //"data:image/png;base64," +
                        }
                        else if (ext == ".pdf")
                        {
                            imgDoc.Src = "../images/pdf.gif";
                        }
                        else if (ext == ".zip" || ext == ".rar")
                        {
                            hrefURL.Target = "self";
                            imgDoc.Src = "../images/zip.png";
                        }
                        hdnImgByteArray.Value = objDU.GetBlobContentAsBase64("studentdocuments", hidFURL.Value.ToString());
                        if (lblStatus.Text == "Y")
                        {
                            imageButton.Visible = false;
                            lblStatus.Text = "Verified by SC";
                            lblStatus.BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblStatus.Text = "Not Verified by SC";
                            lblStatus.BackColor = System.Drawing.Color.Red;
                        }

                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                }
            }
        }
        protected void btnSubmiteNCL_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                string fileurl = "";

                if (flUploadNCL.HasFile)
                {
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    Stream objFileStream = flUploadNCL.PostedFile.InputStream;
                    FileInfo objFile = new FileInfo(flUploadNCL.PostedFile.FileName);
                    string sysfilename = (Session["UserID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + objFile.Extension).ToLower();
                    fileurl = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, flUploadNCL.PostedFile.ContentType);

                    //UploadCVCNCLCertificate(24, fileurl);
                    fillDropdown();
                    ContentTableNCL.Visible = false;
                    shInfo.SetMessage("Document Uploaded Successfully. Please check Latest Acknowledgement.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Please Select File.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSubmiteEWS_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                char CVCStatus = 'N';
                char NCLStatus = 'N';
                char EWSStatus = 'N';
                DataSet ds = new dbUtilitySEBC().GetAllDocuments(Convert.ToInt64(ViewState["PID"]));
                ds.Tables[0].DefaultView.RowFilter = "(DocumentID = '36' AND IsSubmittedAtAFC='N')";
                if (ds.Tables[0].DefaultView.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["DocumentID"].ToString() == "36" && dr["FilePath1"].ToString() != "" && dr["IsSubmittedAtAFC"].ToString() == "N")
                        {
                            EWSStatus = 'Y';
                        }
                    }
                }
                int verifycnt = 0;
                for (Int32 i = 0; i < gvEWS.Rows.Count; i++)
                {
                    if (gvEWS.Rows[i].Cells[2].Text == "Yes")
                    {
                        verifycnt = verifycnt + 1;
                    }
                }
                if (verifycnt > 0)
                {
                    if (EWSStatus == 'Y')
                    {
                        if (UploadCVCNCLCertificate(CVCStatus, NCLStatus, EWSStatus))
                        {

                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();

                            sMSTemplate.PID = 0;

                            DataSet dsFCDetails = reg.getApplicationFormConfirmationDetails(Convert.ToInt64(ViewState["PID"]));

                            sMSTemplate.MobileNo = reg.getAFCProfile(dsFCDetails.Tables[0].Rows[0]["ConfirmedBy"].ToString().Substring(0, 6)).CoordinatorMobileNo.ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.DocumentVerificationRequest);


                            ContentTableEWS.Visible = false;
                            ContentBoxEWS.Visible = false;
                            ContentBoxEWSOpen.Visible = false;
                            shInfo.SetMessage("Your CVC/TVC, NCL or EWS Certificate has been Uploaded and e-SC will verify Soon. You are able to do your Self Verification and Seat Acceptance after Scrutiny done by e-SC.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving or your Document is Verified. Please try again.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("You have not uploaded the Document.", ShowMessageType.Information);
                }
                //SessionData objSessionData = (SessionData)Session["SessionData"];
                //string fileurl = "";

                //if (flUploadEWS.HasFile)
                //{
                //    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                //    Stream objFileStream = flUploadEWS.PostedFile.InputStream;
                //    FileInfo objFile = new FileInfo(flUploadEWS.PostedFile.FileName);
                //    string sysfilename = (Session["UserID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + objFile.Extension).ToLower();
                //    fileurl = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, flUploadEWS.PostedFile.ContentType);

                //    UploadCVCNCLCertificate(36, fileurl);
                //    fillDropdown();
                //    ContentTableEWS.Visible = false;
                //    shInfo.SetMessage("Document Uploaded Successfully. Please check Latest Acknowledgement.", ShowMessageType.Information);
                //}
                //else
                //{
                //    shInfo.SetMessage("Please Select File.", ShowMessageType.Information);
                //}
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }


        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                string ApplicationID = Global.ApplicationFormPrefix + objSessionData.PID.ToString();

                if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, (int)SynCommon.TemplateSystemType.CategoryConversionOTP))
                {
                    DataSet dsCurrentAllotmentDetails = reg.getCurrentAllotmentDetails(Convert.ToInt64(ViewState["PID"]));

                    if (ViewState["DocType"].ToString() == "CVCNCL")
                    {
                        if (reg.CategoryConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
                        {
                            ContentTable2.Visible = false;
                            ContentBox1.Visible = false;
                            ContentBox2.Visible = false;
                            tblOtp.Visible = false;
                            //ContentBox3.Visible = true;
                            Session["SessionData"] = objSessionData;
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = objSessionData.PID;
                            sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                            sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CVCNCLConvertOpen);
                            PageLoad(0);
                            PageLodFalse();

                            if (dsCurrentAllotmentDetails.Tables[0].Rows.Count > 0)
                            {
                                if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["Category_Benifited"].ToString() == "Yes")
                                {
                                    shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted Category seat.", ShowMessageType.Information);
                                }
                                else
                                {
                                    shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Continue with Seat Acceptance if allotted any seat.", ShowMessageType.Information);
                                }
                            }
                            else
                            {
                                shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
                            }

                            ContentBox1.Focus();
                            cbPassword.Visible = false;
                            Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
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
                            ContentTableEWS.Visible = false;
                            ContentBoxEWS.Visible = false;
                            ContentBoxEWSOpen.Visible = false;
                            //ContentBox3.Visible = true;
                            Session["SessionData"] = objSessionData;
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = objSessionData.PID;
                            sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                            sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EWSConvertNo);
                            PageLoad(0);
                            PageLodFalse();
                            if (dsCurrentAllotmentDetails.Tables[0].Rows.Count > 0)
                            {

                                if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["EWS_Benifited"].ToString() == "Yes")
                                {
                                    shInfo.SetMessage("Candidate is converted into OPEN Non-EWS Successfully. Allotment is also Cancelled if allotted EWS seat.", ShowMessageType.Information);
                                }
                                else
                                {
                                    shInfo.SetMessage("Candidate is converted into OPEN Non-EWS Successfully. Continue with Seat Acceptance if allotted any seat.", ShowMessageType.Information);
                                }
                            }
                            else
                            {
                                shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
                            }
                            ContentBox1.Focus();
                            cbPassword.Visible = false;
                            Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
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
                        if (ViewState["DocType"].ToString() == "CVCNCL")
                        {
                            if (reg.CategoryConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
                            {
                                ContentTable2.Visible = false;
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
                                PageLoad(0);
                                shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
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
                                ContentTableEWS.Visible = false;
                                ContentBoxEWS.Visible = false;
                                ContentBoxEWSOpen.Visible = false;
                                //ContentBox3.Visible = true;
                                Session["SessionData"] = objSessionData;
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = objSessionData.PID;
                                sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EWSConvertNo);
                                PageLoad(0);
                                shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
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



        [AjaxMethod]
        public string UploadDoc(string base64String, string documentID, string hidJUD, string hidDID, string hidTID, string fileName, string fileExt)
        {
            //ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (base64String.Length > 6)
            {

                Stream objFileStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(base64String));
                AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                // Stream objFileStream = flUpload.PostedFile.InputStream;
                // FileInfo objFile = new FileInfo(flUpload.PostedFile.FileName);

                string[] strings = base64String.Split(',');
                var bytes = Convert.FromBase64String(strings[1]);
                string extension = fileExt;
                string contenttype = string.Empty;
                switch (strings[0])
                {//check image's extension
                    case "data:image/jpeg;base64":
                        extension = ".jpeg";
                        contenttype = "image/jpeg";
                        break;
                    case "data:image/png;base64":
                        extension = ".png";
                        contenttype = "image/jpeg";
                        break;
                    case "data:application/pdf;base64":
                        extension = ".pdf";
                        contenttype = "application/pdf";
                        break;
                    default://should write cases for more images types
                        extension = string.Empty;
                        break;
                }
                if (extension != string.Empty)
                {
                    string sysfilename = Session["UserID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + extension;
                    string fileurl = azureDocumentUpload.UploadDocumentFromByteArrayWithContentType(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), bytes, contenttype, "studentdocuments");

                    if (extension != ".pdf")
                    {
                        byte[] data = default(byte[]);
                        data = CreateThumbnel(bytes);
                        string thumbnailUrl = azureDocumentUpload.UploadDocumentFromByteArrayWithContentType(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), data, contenttype, "studentdocumentsthumbnail");
                    }
                    //string fileurl = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, contenttype, "studentdocuments");



                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    if (fileurl != "")
                    {
                        string uploadedFileURL, originalFileName;
                        uploadedFileURL = fileurl; originalFileName = fileName;

                        DataSet ds = null;
                        try
                        {
                            int DistrictID = 0;
                            int JuridictionID = 0;
                            int TalukaID = 0;
                            ViewState["documentID"] = documentID;
                            ViewState["sysfilename"] = sysfilename;
                            ViewState["uploadedFileURL"] = uploadedFileURL;
                            ViewState["originalFileName"] = originalFileName;
                            ds = new dbUtilitySEBC().saveUploadedDocument(objSessionData.PID, Convert.ToInt16(documentID), sysfilename, uploadedFileURL, originalFileName, Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress());
                            if (ds != null && ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                                {
                                    if (Convert.ToInt16(documentID) == 21 || Convert.ToInt16(documentID) == 22)
                                    {
                                        DataSet dsJ = null;
                                        if (Convert.ToInt16(documentID) == 21)
                                        {
                                            DistrictID = Convert.ToInt32(hidDID);
                                            JuridictionID = Convert.ToInt32(hidJUD);
                                            TalukaID = Convert.ToInt32(hidTID);
                                        }
                                        else
                                        {
                                            DistrictID = Convert.ToInt32(hidDID);
                                            JuridictionID = Convert.ToInt32(hidJUD);
                                        }
                                        dsJ = new dbUtilitySEBC().saveUploadedDocumentJuridiction(objSessionData.PID, Convert.ToInt16(documentID), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress(), JuridictionID, DistrictID, TalukaID);
                                        if (dsJ != null && dsJ.Tables.Count > 0)
                                        {
                                            if (dsJ.Tables[0].Rows.Count > 0 && dsJ.Tables[0].Rows[0]["Status"].ToString() == "1")
                                            {
                                                //shInfo.SetMessage("The File has been uploaded.", ShowMessageType.Information);
                                                // LoadDocuments(objSessionData.PID);
                                                return "The File has been uploaded.";
                                            }
                                        }
                                        else
                                        {
                                            //shInfo.SetMessage("The File Juridiction Details Not Saved, Try Again.", ShowMessageType.Information);
                                            //LoadDocuments(objSessionData.PID);
                                            return "The File Juridiction Details Not Saved, Try Again.";
                                        }
                                    }
                                    else
                                    {
                                        //shInfo.SetMessage("The File has been uploaded.", ShowMessageType.Information);
                                        //LoadDocuments(objSessionData.PID);
                                        return "The File has been uploaded.";
                                    }
                                }
                                else
                                {
                                    //shInfo.SetMessage("The File Details Not Saved, Try Again.", ShowMessageType.Information);
                                    //LoadDocuments(objSessionData.PID);
                                    return "The File Details Not Saved, Try Again.";
                                }
                            }
                            else
                            {
                                //shInfo.SetMessage("The File Details Not Saved, Try Again.", ShowMessageType.Information);
                                //LoadDocuments(objSessionData.PID);
                                return "The File Details Not Saved, Try Again.";
                            }
                        }
                        catch (Exception ex)
                        {
                            Logging.LogException(ex, "[Page Level Error]");
                            // shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError);
                            ///LoadDocuments(objSessionData.PID);
                            return ex.Message;
                        }
                        finally
                        {
                            if (ds != null)
                                ds.Dispose();
                        }
                    }
                    else
                    {
                        //shInfo.SetMessage("Please Select File.", ShowMessageType.Information);
                        //LoadDocuments(objSessionData.PID);
                        return "Please Select File.";
                    }
                }
                return "";
            }
            else
            {
                return "Invalid File";
            }
        }
        [AjaxMethod]
        public DataSet FillJuridiction(string documentID)
        {
            DataSet ds = new DataSet();
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                if (documentID == "22")
                {
                    if (reg.getCategoryID(objSessionData.PID) == 3)
                    {
                        ds = reg.getMasterJuridiction("CT");
                    }
                    else
                    {
                        ds = reg.getMasterJuridiction("CV");
                    }
                }
                else
                {
                    ds = reg.getMasterJuridiction("CC");
                }
            }
            catch (Exception ex)
            {
            }
            return ds;
        }
        [AjaxMethod]
        public DataSet getDistrictForJuridiction(string JurisdictionID)
        {
            DataSet ds = new DataSet();
            try
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];

                ds = reg.getMasterDistrictForJuridiction(Convert.ToInt32(JurisdictionID));
            }
            catch (Exception ex)
            {
            }

            return ds;
        }
        [AjaxMethod]
        public DataSet getTalukaForDistrict(string DistrictID)
        {
            DataSet ds = new DataSet();
            try
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];

                ds = reg.getMasterTalukaForDistrict(Convert.ToInt32(DistrictID));
            }
            catch (Exception ex)
            {
            }

            return ds;
        }
        [AjaxMethod]
        public string getCategoryID()
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            return reg.getCategoryID(objSessionData.PID).ToString();
        }

        protected byte[] CreateThumbnel(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Bitmap thumb = new Bitmap(48, 69);
                using (System.Drawing.Image bmp = System.Drawing.Image.FromStream(ms))
                {
                    using (Graphics g = Graphics.FromImage(thumb))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawImage(bmp, 0, 0, 48, 69);
                    }
                }
                // a picturebox to show/test the result
                byte[] data = default(byte[]);
                using (System.IO.MemoryStream sampleStream = new System.IO.MemoryStream())
                {
                    thumb.Save(sampleStream, System.Drawing.Imaging.ImageFormat.Bmp);
                    data = sampleStream.ToArray();
                }
                return data;
            }
        }
        private class dbUtilitySEBC
        {
            public DataSet GetTFWSDefaultDocument(Int64 PID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.BigInt)
                };

                param[0].Value = PID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetTFWSDefaultDocument", param);

                }
                finally
                {
                    db.Dispose();
                }

            }
            public DataSet GetAllDocuments(Int64 PID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.BigInt)
                };

                param[0].Value = PID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetAllDocumentsCVCNCLEWS", param);

                }
                finally
                {
                    db.Dispose();
                }

                //return ExecProcedure("MHDTE_spGetAllDocuments", param, "tbl");
            }
            public DataSet saveUploadedDocument(Int64 PID, Int64 DocumentID, string FileName, string AbsoluteFilePath, string OriginalFileName, string FileUploadedBy, string FileUploadedByIPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@DocumentID",SqlDbType.BigInt),
                    new SqlParameter("@FileName",SqlDbType.VarChar),
                    new SqlParameter("@AbsoluteFilePath",SqlDbType.VarChar),
                    new SqlParameter("@OriginalFileName",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),
                    new SqlParameter("@DocumentStatus",SqlDbType.VarChar),
                          new SqlParameter("@checkbarcode",SqlDbType.VarChar),
                    new SqlParameter("@barcode",SqlDbType.VarChar),
                    new SqlParameter("@CandidateBarcode", SqlDbType.NVarChar)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = FileName;
                param[3].Value = AbsoluteFilePath;
                param[4].Value = OriginalFileName;
                param[5].Value = FileUploadedBy;
                param[6].Value = FileUploadedByIPAddress;
                param[7].Value = "A";
                param[8].Value = "N";
                param[9].Value = "";
                param[10].Value = "";
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUpdateDocumentUploadStatus", param);

                }
                finally
                {
                    db.Dispose();
                }
                // return ExecProcedure("MHDTE_spUpdateDocumentUploadStatus", param, "tbl");
            }

            public DataSet saveUploadedDocumentTFWS(Int64 PID, Int64 DocumentID, string FileName, string AbsoluteFilePath, string OriginalFileName, string FileUploadedBy, string FileUploadedByIPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@DocumentID",SqlDbType.BigInt),
                    new SqlParameter("@FileName",SqlDbType.VarChar),
                    new SqlParameter("@AbsoluteFilePath",SqlDbType.VarChar),
                    new SqlParameter("@OriginalFileName",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),
                    new SqlParameter("@DocumentStatus",SqlDbType.VarChar)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = FileName;
                param[3].Value = AbsoluteFilePath;
                param[4].Value = OriginalFileName;
                param[5].Value = FileUploadedBy;
                param[6].Value = FileUploadedByIPAddress;
                param[7].Value = "A";
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUpdateDocumentUploadStatusTWS", param);

                }
                finally
                {
                    db.Dispose();
                }
                // return ExecProcedure("MHDTE_spUpdateDocumentUploadStatus", param, "tbl");
            }
            public DataSet deleteUploadedDocument(Int64 PID, Int64 DocumentID, string FileUploadedBy, string FileUploadedByIPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@DocumentID",SqlDbType.BigInt),
                    new SqlParameter("@FileName",SqlDbType.VarChar),
                    new SqlParameter("@AbsoluteFilePath",SqlDbType.VarChar),
                    new SqlParameter("@OriginalFileName",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),
                    new SqlParameter("@DocumentStatus",SqlDbType.VarChar),
                      new SqlParameter("@checkbarcode",SqlDbType.VarChar),
                    new SqlParameter("@barcode",SqlDbType.VarChar),
                    new SqlParameter("@CandidateBarcode", SqlDbType.NVarChar)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = "";
                param[3].Value = "";
                param[4].Value = "";
                param[5].Value = FileUploadedBy;
                param[6].Value = FileUploadedByIPAddress;
                param[7].Value = "D";
                param[8].Value = 'N';
                param[9].Value = "";
                param[10].Value = "";
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUpdateDocumentUploadStatus", param);

                }
                finally
                {
                    db.Dispose();
                }

                // return ExecProcedure("MHDTE_spUpdateDocumentUploadStatus", param, "tbl");
            }
            public DataSet saveUploadedDocumentJuridiction(Int64 PID, Int64 DocumentID, string FileUploadedBy, string FileUploadedByIPAddress, int JuridictionID, int DistrictID, int TalukaID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@DocumentID",SqlDbType.BigInt),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),
                    new SqlParameter("@JuridictionID",SqlDbType.Int),
                    new SqlParameter("@DistrictID",SqlDbType.Int),
                    new SqlParameter("@TalukaID",SqlDbType.Int)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = FileUploadedBy;
                param[3].Value = FileUploadedByIPAddress;
                param[4].Value = JuridictionID;
                param[5].Value = DistrictID;
                param[6].Value = TalukaID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUpdateJuridictionDocumentUpload", param);

                }
                finally
                {
                    db.Dispose();
                }

                //return ExecProcedure("MHDTE_spUpdateJuridictionDocumentUpload", param, "tbl");
            }


        }
    }
}