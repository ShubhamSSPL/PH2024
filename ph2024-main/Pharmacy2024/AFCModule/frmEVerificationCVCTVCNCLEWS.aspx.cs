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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmEVerificationCVCTVCNCLEWS : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public int CurrentDocID;
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["UserTypeID"] == null || Session["UserTypeID"].ToString() == "91")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if ((DateTime.Now < Global.DocumentVerificationStartDateTime || DateTime.Now > Global.DocumentVerificationEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21 && ConfigurationManager.AppSettings["CVCNCLDocumentVerificationStart"].ToString() == "N")
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            
            if (Request.QueryString["PID"] == null)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }

            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

            //  Int32 ApplicationFormStepID = Convert.ToInt32(Request.QueryString["ApplicationFormStepID"].ToString());
            if (PID.ToString().GetHashCode() != Code)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMyDocument));
            ViewState["PID"] = PID;
            ViewState["ApplicationFormStepID"] = 3;
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            CandidateBasicInformation.PID = Convert.ToInt64(ViewState["PID"].ToString());
            if (!IsPostBack)
            {
                try
                {
                    ViewState["CurrentDocID"] = 0;
                    DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplayInOptionForm(PID);
                    if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                    {

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
                        lblCastName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CasteName"].ToString();
                    }



                    DataSet dsDocVerification = reg.GetDocumentListForDocumentVerificationByStepIDCVCTVCNCLEWS(Convert.ToInt64(ViewState["PID"]), 3);
                    dsDocVerification.Tables[0].DefaultView.RowFilter = "(DocumentID = '22' OR DocumentID = '24' OR DocumentID = '36')";
                    if (dsDocVerification.Tables[0].DefaultView.Count > 0)
                    {
                        gvDocuments.DataSource = dsDocVerification.Tables[0].DefaultView;
                        gvDocuments.DataBind();
                    }
                    else
                    {
                        tblDocuments.Visible = false;
                    }

                    DataSet ds = reg.GetDocumentListForDataVerificationByStepIDCVCTVCNCLEWS(Convert.ToInt64(ViewState["PID"]), 3);
                    ds.Tables[0].DefaultView.RowFilter = "(DocumentID = '22' OR DocumentID = '24' OR DocumentID = '36')";
                    //ddlDocumentList.DataSource = ds;
                    //ddlDocumentList.DataTextField = "DocumentName";
                    //ddlDocumentList.DataValueField = "DocumentName";
                    //ddlDocumentList.DataBind();
                    ReadoDocumentList.DataSource = ds.Tables[0].DefaultView;
                    ReadoDocumentList.DataTextField = "DocumentName";
                    ReadoDocumentList.DataValueField = "DocumentName";
                    ReadoDocumentList.SelectedIndex = 0;
                    ReadoDocumentList.DataBind();

                    if (ds.Tables[0].DefaultView.Count > 0)
                    {
                        trdocument.Visible = true;
                        CurrentDocID = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (i == CurrentDocID && ds.Tables[0].Rows[i]["FilePath"].ToString() != "")
                            {
                                string docpath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                                string docName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
                                string docfun = "LoadDocument('" + docpath + "','" + docName + "');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);
                                break;
                            }
                            else
                            {
                                CurrentDocID = CurrentDocID + 1;
                            }
                        }
                    }
                    DataSet dsDiscrepancy = reg.GetDiscrepancyListByStepIDCVCTVCNCLEWS(Convert.ToInt64(ViewState["PID"]), 3); //12
                    dsDiscrepancy.Tables[0].DefaultView.RowFilter = "DiscrepancyID = '9' OR DiscrepancyID = '26' OR DiscrepancyID = '27' ";
                    if (dsDiscrepancy.Tables[0].DefaultView.Count > 0)
                    {
                        gvDiscrepancy.DataSource = dsDiscrepancy.Tables[0].DefaultView;
                        gvDiscrepancy.DataBind();

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "MarkDiscripency();", true);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void gvDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hidFURL = (HiddenField)e.Row.FindControl("hidFURL");
                    if (hidFURL.Value != "")
                    {
                        string ext = System.IO.Path.GetExtension(hidFURL.Value).ToLower();
                        HtmlImage imgDoc = (HtmlImage)e.Row.FindControl("imgDoc");
                        HiddenField hidDID = (HiddenField)e.Row.FindControl("hidDID");
                        HtmlAnchor hrefURL = (HtmlAnchor)e.Row.FindControl("hrefURL");
                        HiddenField hdnImgByteArray = (HiddenField)e.Row.FindControl("hdnImgByteArray");
                        hrefURL.HRef = ConfigurationManager.AppSettings["ApplicationURL"] + "ViewMyDocument.aspx?documentID=" + hidDID.Value;
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
                    }

                    if (((HiddenField)e.Row.Cells[7].FindControl("hdnImgUrl")).Value.Length > 0)
                    {
                        if (((Label)e.Row.Cells[5].FindControl("lblIsSubmitted")).Text == "N")
                        {
                            ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = true;
                            ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = false;
                        }
                        else
                        {
                            ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = true;
                            ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = false;
                        }
                    }
                    else
                    {
                        ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = false;
                        ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = true;
                        ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Enabled = false;
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(ViewState["PID"]);
                //DataSet statusDs = reg.getVerificationFlags(PID);
                //char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                //char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                string varidation = ValidateDiscripancyandDocument();
                if (varidation.Length > 0)
                {
                    shInfo.SetMessage(varidation, ShowMessageType.Information);
                    lblmessage.Visible = true;
                    lblmessage.Text = varidation;
                    btnProceed.Focus();
                }
                else
                {
                    lblmessage.Text = "";
                    int DocumentCounter = 0;
                    int DiscrepancyCounter = 0;
                    bool docverifyed = false;
                    string XMLstring = "<DocumentList>";
                    for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                    {
                        string DocumentID = ((Label)gvDocuments.Rows[i].FindControl("lblDocumentID")).Text;

                        if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                        {
                            XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "Y" + "\"></Document>";
                            docverifyed = true;
                        }
                        else
                        {
                            XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "N" + "\"></Document>";
                            DocumentCounter = DocumentCounter + 1;
                        }
                    }
                    XMLstring += "</DocumentList>";

                    lblmessage.Visible = false;
                    string commentforTfws = string.Empty;
                    string notVerifyList = ValidateRadiobuttonChecked();
                    string CVCStatus = "N";
                    string NCLStatus = "N";
                    string EWSStatus = "N";
                    if (notVerifyList == string.Empty)
                    {
                        string strRemarkAdded = ValidateRemarkAddedForDiscrepnacy();
                        if (strRemarkAdded == string.Empty)
                        {
                            string XMLstringDiscrepancy = "<DiscrepancyList>";
                            for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                            {
                                string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
                                string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

                                if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked)
                                {
                                    XMLstringDiscrepancy += "<Discrepancy DiscrepancyID=\"" + DiscrepancyID + "\" IsVerifiedAtAFC=\"" + "Y" + "\" IsDiscrepancyMarked=\"" + "N" + "\" DiscrepancyRemark=\"" + DiscrepancyRemark + "\"></Discrepancy>";
                                    if (DiscrepancyID == "9")
                                    {
                                        EWSStatus = "Y";
                                    }
                                    if (DiscrepancyID == "26")
                                    {
                                        CVCStatus = "Y";
                                    }
                                    if (DiscrepancyID == "27")
                                    {
                                        NCLStatus = "Y";
                                    }
                                }
                                else
                                {
                                    DiscrepancyCounter = DiscrepancyCounter + 1;
                                    commentforTfws = DiscrepancyRemark;
                                    XMLstringDiscrepancy += "<Discrepancy DiscrepancyID=\"" + DiscrepancyID + "\" IsVerifiedAtAFC=\"" + "N" + "\" IsDiscrepancyMarked=\"" + "Y" + "\" DiscrepancyRemark=\"" + DiscrepancyRemark + "\"></Discrepancy>";
                                    if (DiscrepancyID == "9")
                                    {
                                        EWSStatus = "Y";
                                    }
                                    if (DiscrepancyID == "26")
                                    {
                                        CVCStatus = "N";
                                    }
                                    if (DiscrepancyID == "27")
                                    {
                                        NCLStatus = "N";
                                    }
                                }
                            }
                            XMLstringDiscrepancy += "</DiscrepancyList>";
                            if (DocumentCounter > 0 && DiscrepancyCounter == 0)
                            {
                                btnProceed.Focus();
                                lblmessage.Visible = true;
                                lblmessage.Text = "Please Enter Discrepancy or Verify the Document.";
                            }
                            else
                            {
                                if (ValidateDocumentVerified() == string.Empty)
                                {
                                    SMSTemplate sMSTemplate = new SMSTemplate();
                                    SynCommon synCommon = new SynCommon();
                                    sMSTemplate.PID = PID;
                                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                    sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                    sMSTemplate.RoundNumber = "III";

                                    if (commentforTfws == string.Empty && docverifyed == true)
                                    {
                                        if (reg.updateDocumentSubmission(PID, XMLstring, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                        {
                                            if (reg.UpdateDiscrepancySubmission(Convert.ToInt64(ViewState["PID"]), XMLstringDiscrepancy, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                            {
                                                if (commentforTfws == string.Empty && docverifyed == true)
                                                {
                                                    if (reg.ConfirmCVCNCLEWSApplication(Convert.ToInt64(ViewState["PID"]), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), CVCStatus, NCLStatus, EWSStatus))
                                                        if (Global.SendSMSToCandidate == 1)
                                                            //synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ConvertSucessful); 
                                                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.verifyCVCTVCNCLEWSSucessful);
                                                    Response.Redirect("../AFCModule/frmCVCNCLEWSCandidateListForVerification", true);
                                                }
                                            }
                                            else
                                            {
                                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                            }
                                        }
                                        else
                                        {
                                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                        }
                                    }
                                    else
                                    {
                                        if (reg.updateDocumentSubmission(PID, XMLstring, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                        {
                                            if (reg.UpdateDiscrepancySubmission(Convert.ToInt64(ViewState["PID"]), XMLstringDiscrepancy, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                            {
                                                if (commentforTfws != string.Empty ) //&& docverifyed == false
                                                {
                                                    if (EWSStatus == "Y")
                                                    {
                                                        if (reg.UpdateCategoryEWSConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress())) //, CVCStatus, NCLStatus, EWSStatus))
                                                            if (Global.SendSMSToCandidate == 1)
                                                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EWSConvertNoUpdate);
                                                        Response.Redirect("../AFCModule/frmCVCNCLEWSCandidateListForVerification", true);
                                                    }
                                                    if (CVCStatus == "N" || NCLStatus == "N")
                                                    {
                                                        if (lblCategoryForAdmission.Text.ToString() == "SEBC$#" || lblCategoryForAdmission.Text.ToString() == "OBC$#")
                                                        {
                                                            if (CVCStatus == "N" && NCLStatus == "N")
                                                            {
                                                                if (reg.UpdateCategoryConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))//, CVCStatus, NCLStatus, EWSStatus))
                                                                    if (Global.SendSMSToCandidate == 1)
                                                                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CVCNCLConvertOpenUpdateNew);
                                                            }
                                                            else
                                                            {
                                                                if (reg.ConfirmCVCNCLEWSApplication(Convert.ToInt64(ViewState["PID"]), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), CVCStatus, NCLStatus, EWSStatus))
                                                                    if (Global.SendSMSToCandidate == 1)
                                                                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.verifyCVCTVCNCLEWSSucessful);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (reg.UpdateCategoryConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))//, CVCStatus, NCLStatus, EWSStatus))
                                                                if (Global.SendSMSToCandidate == 1)
                                                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CVCNCLConvertOpenUpdateNew);
                                                        }
                                                        
                                                        Response.Redirect("../AFCModule/frmCVCNCLEWSCandidateListForVerification", true);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                            }
                                        }
                                        else
                                        {
                                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                        }
                                    }
                                }
                                else
                                {
                                    btnProceed.Focus();
                                    lblmessage.Text = "Please verify the Documents";
                                }

                            }

                        }
                        else
                        {
                            btnProceed.Focus();
                            lblmessage.Visible = true;
                            lblmessage.Text = "Please Enter Discrepancy Remark for : " + strRemarkAdded;
                        }
                    }
                    else
                    {
                        btnProceed.Focus();
                        lblmessage.Visible = true;
                        lblmessage.Text = "Please Mark the Verification Status for : " + notVerifyList;
                    }
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private string ValidateDiscripancyandDocument()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string result = string.Empty;
                List<DocumentIDForCheck> NotCheckDiscripancy = new List<DocumentIDForCheck>();
                List<DocumentIDForCheck> CheckDiscripancy = new List<DocumentIDForCheck>();
                List<DocumentIDForCheck> NotCheckDocuments = new List<DocumentIDForCheck>();
                List<DocumentIDForCheck> CheckDocuments = new List<DocumentIDForCheck>();

                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                {
                    string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;
                    int DocumentID = Convert.ToInt32(((Label)gvDiscrepancy.Rows[i].FindControl("lblDocumentId")).Text);

                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked)
                    {
                        DocumentIDForCheck DocID = new DocumentIDForCheck();
                        DocID.DocumentID = DocumentID;
                        CheckDiscripancy.Add(DocID);
                    }
                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        DocumentIDForCheck DocID = new DocumentIDForCheck();
                        DocID.DocumentID = DocumentID;
                        NotCheckDiscripancy.Add(DocID);
                    }
                }
                for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                {
                    int DocumentID = Convert.ToInt32(((Label)gvDiscrepancy.Rows[i].FindControl("lblDocumentId")).Text);
                    //string DiscrepancyID = ((Label)gvDocuments.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    //string DiscrepancyRemark = ((TextBox)gvDocuments.Rows[i].FindControl("txtDiscrepancyRemark")).Text;
                    if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                    {
                        DocumentIDForCheck DocID = new DocumentIDForCheck();
                        DocID.DocumentID = DocumentID;
                        CheckDocuments.Add(DocID);
                    }
                    if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        DocumentIDForCheck DocID = new DocumentIDForCheck();
                        DocID.DocumentID = DocumentID;
                        NotCheckDocuments.Add(DocID);
                    }
                }
                //Logic for discripancy marked are present in verification
                HashSet<int> diffidsCheck = new HashSet<int>(CheckDiscripancy.Select(s => s.DocumentID));
                List<DocumentIDForCheck> resultsCheck = NotCheckDocuments.Where(m => diffidsCheck.Contains(m.DocumentID)).ToList();

                // logic for discripancy not marked are present in not verification of document
                HashSet<int> diffidsNotCheck = new HashSet<int>(NotCheckDiscripancy.Select(s => s.DocumentID));
                List<DocumentIDForCheck> resultsNotCheck = CheckDocuments.Where(m => diffidsNotCheck.Contains(m.DocumentID)).ToList();

                if (resultsCheck.Count > 0 || resultsNotCheck.Count > 0)
                {
                    return "Verify the Discrepancy and Document are marked Correctly!!";
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return null;
            }
        }

        //protected void btnECandidateDashboard_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("../E_FCModule/FCApplicationFormVerificationDashboard?PID=" + ViewState["PID"].ToString() + "&Code=" + ViewState["PID"].ToString().GetHashCode().ToString());
        //}
        protected void gvDiscrepancy_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (((Label)e.Row.FindControl("lblIsVerifiedAtAFC")).Text == "Y")
                    {
                        ((RadioButton)e.Row.FindControl("rbnYes")).Checked = true;
                        ((RadioButton)e.Row.FindControl("rbnNo")).Checked = false;
                        ((Label)e.Row.FindControl("lblStar")).Visible = false;
                    }
                    else if (((Label)e.Row.FindControl("lblIsDiscrepancyMarked")).Text == "Y")
                    {
                        ((RadioButton)e.Row.FindControl("rbnYes")).Checked = false;
                        ((RadioButton)e.Row.FindControl("rbnNo")).Checked = true;
                        ((TextBox)e.Row.FindControl("txtDiscrepancyRemark")).Enabled = true;
                        ((RequiredFieldValidator)e.Row.FindControl("rfvtxtDiscrepancyRemark")).Enabled = true;
                        e.Row.BackColor = System.Drawing.Color.Red;
                        ((Label)e.Row.FindControl("lblStar")).Visible = true;
                    }
                    else
                    {
                        ((RadioButton)e.Row.FindControl("rbnYes")).Checked = false;
                        ((RadioButton)e.Row.FindControl("rbnNo")).Checked = false;
                        ((RequiredFieldValidator)e.Row.FindControl("rfvtxtDiscrepancyRemark")).Enabled = false;
                        ((TextBox)e.Row.FindControl("txtDiscrepancyRemark")).Enabled = false;
                        ((Label)e.Row.FindControl("lblStar")).Visible = false;

                    }

                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void rbnYes_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                RadioButton rbYes = sender as RadioButton;
                GridViewRow parentRow = rbYes.NamingContainer as GridViewRow;
                lblmessage.Text = "";
                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                {
                    TextBox txtDiscrepancyRemark = (TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark");
                    RequiredFieldValidator rfvtxtDiscrepancyRemark = (RequiredFieldValidator)gvDiscrepancy.Rows[i].FindControl("rfvtxtDiscrepancyRemark");
                    Label lblStar = (Label)gvDiscrepancy.Rows[i].FindControl("lblStar");

                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked)
                    {
                        txtDiscrepancyRemark.Text = "";
                        txtDiscrepancyRemark.Enabled = false;
                        rfvtxtDiscrepancyRemark.Enabled = false;
                        lblStar.Visible = false;
                    }
                    //else
                    //{
                    //    txtDiscrepancyRemark.Text = "";
                    //    txtDiscrepancyRemark.Enabled = true;
                    //    rfvtxtDiscrepancyRemark.Enabled = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void rbnNo_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                RadioButton rbnNo = sender as RadioButton;
                GridViewRow parentRow = rbnNo.NamingContainer as GridViewRow;
                lblmessage.Text = "";
                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                {
                    TextBox txtDiscrepancyRemark = (TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark");
                    RequiredFieldValidator rfvtxtDiscrepancyRemark = (RequiredFieldValidator)gvDiscrepancy.Rows[i].FindControl("rfvtxtDiscrepancyRemark");
                    Label lblStar = (Label)gvDiscrepancy.Rows[i].FindControl("lblStar");

                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        txtDiscrepancyRemark.Enabled = true;
                        rfvtxtDiscrepancyRemark.Enabled = true;
                        lblStar.Visible = true;
                    }
                    //else
                    //{
                    //    txtDiscrepancyRemark.Text = "";
                    //    txtDiscrepancyRemark.Enabled = false;
                    //    rfvtxtDiscrepancyRemark.Enabled = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSubmitDiscripancy_Click(object sender, EventArgs e)
        {
            //lblmessage.Visible = false;
            //ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //string notVerifyList = ValidateRadiobuttonChecked();
            //if (notVerifyList == string.Empty)
            //{
            //    string strRemarkAdded = ValidateRemarkAddedForDiscrepnacy();
            //    if (strRemarkAdded == string.Empty)
            //    {
            //        string XMLstring = "<DiscrepancyList>";
            //        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
            //        {
            //            string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
            //            string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

            //            if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked)
            //            {
            //                XMLstring += "<Discrepancy DiscrepancyID=\"" + DiscrepancyID + "\" IsVerifiedAtAFC=\"" + "Y" + "\" IsDiscrepancyMarked=\"" + "N" + "\" DiscrepancyRemark=\"" + DiscrepancyRemark + "\"></Discrepancy>";
            //            }
            //            else
            //            {
            //                XMLstring += "<Discrepancy DiscrepancyID=\"" + DiscrepancyID + "\" IsVerifiedAtAFC=\"" + "N" + "\" IsDiscrepancyMarked=\"" + "Y" + "\" DiscrepancyRemark=\"" + DiscrepancyRemark + "\"></Discrepancy>";
            //            }
            //        }
            //        XMLstring += "</DiscrepancyList>";

            //        if (reg.UpdateDiscrepancySubmission(Convert.ToInt64(ViewState["PID"]), XMLstring, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
            //        {
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "HideMarkDiscripency();", true);
            //            Response.Redirect("../E_FCModule/FCApplicationFormVerificationDashboard?PID=" + Convert.ToInt64(ViewState["PID"]) + "&Code=" + Convert.ToInt64(ViewState["PID"]).ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + (Convert.ToInt32(ViewState["ApplicationFormStepID"]) + 1));
            //        }
            //        else
            //        {
            //            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
            //        }
            //    }
            //    else
            //    {
            //        lblmessage.Visible = true;
            //        lblmessage.Text = "Please Enter Discrepancy Remark for : " + strRemarkAdded;
            //    }
            //}
            //else
            //{
            //    lblmessage.Visible = true;
            //    lblmessage.Text = "Please Mark the Verification Status for : " + notVerifyList;
            //}
        }

        private string ValidateRadiobuttonChecked()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string NotCheckDiscripancy = string.Empty;
                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                {
                    string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

                    if (!((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked && !((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        if (NotCheckDiscripancy == String.Empty)
                        {
                            NotCheckDiscripancy = gvDiscrepancy.Rows[i].Cells[1].Text;
                        }
                        else
                            NotCheckDiscripancy = NotCheckDiscripancy + ", " + gvDiscrepancy.Rows[i].Cells[1].Text;
                    }

                }
                return NotCheckDiscripancy;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return null;
            }
        }

        private string ValidateDocumentVerified()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string NotCheckDiscripancy = string.Empty;
                for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                {
                    //string DiscrepancyID = ((Label)gvDocuments.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    //string DiscrepancyRemark = ((TextBox)gvDocuments.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

                    if (!((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked && !((RadioButton)gvDocuments.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        if (NotCheckDiscripancy == String.Empty)
                        {
                            NotCheckDiscripancy = gvDocuments.Rows[i].Cells[1].Text;
                        }
                        else
                            NotCheckDiscripancy = NotCheckDiscripancy + ", " + gvDocuments.Rows[i].Cells[1].Text;
                    }

                }
                return NotCheckDiscripancy;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return null;
            }
        }
        private string ValidateRemarkAddedForDiscrepnacy()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string NotCheckDiscripancy = string.Empty;
                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                {
                    string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnNo")).Checked && DiscrepancyRemark == "")
                    {

                        if (NotCheckDiscripancy == String.Empty)
                        {
                            NotCheckDiscripancy = gvDiscrepancy.Rows[i].Cells[1].Text;
                        }
                        else
                            NotCheckDiscripancy = NotCheckDiscripancy + "," + gvDiscrepancy.Rows[i].Cells[1].Text;
                    }

                }
                return NotCheckDiscripancy;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return null;
            }
        }
        protected void btnCancelDiscripancy_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                tblSubmit.Visible = true;
                DataSet ds = reg.GetDocumentListForDataVerificationByStepIDCVCTVCNCLEWS(Convert.ToInt64(ViewState["PID"]), Convert.ToInt32(ViewState["ApplicationFormStepID"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i == Convert.ToInt32(ViewState["CurrentDocID"]))
                        {
                            string docpath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                            string docName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
                            string docfun = "HideMarkDiscripencyDoc('" + docpath + "','" + docName + "');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);

                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "HideMarkDiscripency();", true);

                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        //protected void ddlDocumentList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
        //    string selectedvalue = ddlDocumentList.SelectedValue;
        //    DataSet ds = reg.GetDocumentListForDataVerificationByStepID(Convert.ToInt64(ViewState["PID"]), Convert.ToInt32(ViewState["ApplicationFormStepID"]));
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            if (ds.Tables[0].Rows[i]["DocumentName"].ToString() == selectedvalue)
        //            {
        //                if (ds.Tables[0].Rows[i]["FilePath"].ToString() != "")
        //                {
        //                    string docpath = ds.Tables[0].Rows[i]["FilePath"].ToString();
        //                    string docName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
        //                    string docfun = "LoadDocument('" + docpath + "','" + docName + "');";
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);
        //                }
        //                else
        //                {
        //                    shInfo.SetMessage("Candidate has not uploaded the Document :" + selectedvalue, ShowMessageType.Information);
        //                }
        //            }
        //        }
        //    }
        //}
        protected void ReadoDocumentList_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string selectedvalue = ReadoDocumentList.SelectedValue;
                DataSet ds = reg.GetDocumentListForDataVerificationByStepIDCVCTVCNCLEWS(Convert.ToInt64(ViewState["PID"]), Convert.ToInt32(ViewState["ApplicationFormStepID"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["DocumentName"].ToString() == selectedvalue)
                        {
                            if (ds.Tables[0].Rows[i]["FilePath"].ToString() != "")
                            {
                                string docpath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                                string docName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
                                string docfun = "LoadDocument('" + docpath + "','" + docName + "');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);
                            }
                            else
                            {
                                shInfo.SetMessage("Candidate has not uploaded the Document :" + selectedvalue, ShowMessageType.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCVCNCLEWSCandidateListForVerification", true);
        }
        protected void btnConvertoOpen_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(ViewState["PID"]);
                //DataSet statusDs = reg.getVerificationFlags(PID);
                //char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                //char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                string varidation = ValidateDiscripancyandDocument();
                if (varidation.Length > 0)
                {
                    shInfo.SetMessage(varidation, ShowMessageType.Information);
                    lblmessage.Visible = true;
                    lblmessage.Text = varidation;
                    btnProceed.Focus();
                }
                else
                {
                    lblmessage.Text = "";
                    int DocumentCounter = 0;
                    int DiscrepancyCounter = 0;
                    bool docverifyed = false;
                    string XMLstring = "<DocumentList>";
                    for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                    {
                        string DocumentID = ((Label)gvDocuments.Rows[i].FindControl("lblDocumentID")).Text;

                        if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                        {
                            XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "Y" + "\"></Document>";
                            docverifyed = true;
                        }
                        else
                        {
                            XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "N" + "\"></Document>";
                            DocumentCounter = DocumentCounter + 1;
                        }
                    }
                    XMLstring += "</DocumentList>";

                    lblmessage.Visible = false;
                    string commentforTfws = string.Empty;
                    string notVerifyList = ValidateRadiobuttonChecked();
                    string CVCStatus = "N";
                    string NCLStatus = "N";
                    string EWSStatus = "N";
                    if (notVerifyList == string.Empty)
                    {
                        string strRemarkAdded = ValidateRemarkAddedForDiscrepnacy();
                        if (strRemarkAdded == string.Empty)
                        {
                            string XMLstringDiscrepancy = "<DiscrepancyList>";
                            for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                            {
                                string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
                                string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

                                if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked)
                                {
                                    XMLstringDiscrepancy += "<Discrepancy DiscrepancyID=\"" + DiscrepancyID + "\" IsVerifiedAtAFC=\"" + "Y" + "\" IsDiscrepancyMarked=\"" + "N" + "\" DiscrepancyRemark=\"" + DiscrepancyRemark + "\"></Discrepancy>";
                                    if (DiscrepancyID == "9")
                                    {
                                        EWSStatus = "N";
                                    }
                                    if (DiscrepancyID == "26")
                                    {
                                        CVCStatus = "N";
                                    }
                                    if (DiscrepancyID == "27")
                                    {
                                        NCLStatus = "N";
                                    }
                                }
                                else
                                {
                                    DiscrepancyCounter = DiscrepancyCounter + 1;
                                    commentforTfws = DiscrepancyRemark;
                                    XMLstringDiscrepancy += "<Discrepancy DiscrepancyID=\"" + DiscrepancyID + "\" IsVerifiedAtAFC=\"" + "N" + "\" IsDiscrepancyMarked=\"" + "Y" + "\" DiscrepancyRemark=\"" + DiscrepancyRemark + "\"></Discrepancy>";
                                    if (DiscrepancyID == "9")
                                    {
                                        EWSStatus = "Y";
                                    }
                                    if (DiscrepancyID == "26")
                                    {
                                        CVCStatus = "Y";
                                    }
                                    if (DiscrepancyID == "27")
                                    {
                                        NCLStatus = "Y";
                                    }
                                }
                            }
                            XMLstringDiscrepancy += "</DiscrepancyList>";
                            if (DocumentCounter > 0 && DiscrepancyCounter == 0)
                            {
                                btnProceed.Focus();
                                lblmessage.Visible = true;
                                lblmessage.Text = "Please Enter Discrepancy or Verify the Document.";
                            }
                            else
                            {
                                if (ValidateDocumentVerified() == string.Empty)
                                {
                                    SMSTemplate sMSTemplate = new SMSTemplate();
                                    SynCommon synCommon = new SynCommon();
                                    sMSTemplate.PID = PID;
                                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();


                                    if (reg.updateDocumentSubmission(PID, XMLstring, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                    {
                                        if (reg.UpdateDiscrepancySubmission(Convert.ToInt64(ViewState["PID"]), XMLstringDiscrepancy, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                        {
                                            if (commentforTfws == string.Empty && docverifyed == true)
                                            {
                                                if (EWSStatus == "Y")
                                                {
                                                    if (reg.UpdateCategoryEWSConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress())) //, CVCStatus, NCLStatus, EWSStatus))
                                                        if (Global.SendSMSToCandidate == 1)
                                                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.TFWSVerifySucess);
                                                    Response.Redirect("../AFCModule/frmCVCNCLEWSCandidateListForVerification", true);
                                                }
                                                if (CVCStatus == "Y" || NCLStatus == "Y")
                                                {
                                                    if (reg.UpdateCategoryConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))//, CVCStatus, NCLStatus, EWSStatus))
                                                        if (Global.SendSMSToCandidate == 1)
                                                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.TFWSVerifySucess);
                                                    Response.Redirect("../AFCModule/frmCVCNCLEWSCandidateListForVerification", true);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                        }
                                    }
                                    else
                                    {
                                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                    }

                                }
                                else
                                {
                                    btnProceed.Focus();
                                    lblmessage.Text = "Please verify the Documents";
                                }
                            }
                        }
                        else
                        {
                            btnProceed.Focus();
                            lblmessage.Visible = true;
                            lblmessage.Text = "Please Enter Discrepancy Remark for : " + strRemarkAdded;
                        }
                    }
                    else
                    {
                        btnProceed.Focus();
                        lblmessage.Visible = true;
                        lblmessage.Text = "Please Mark the Verification Status for : " + notVerifyList;
                    }
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        public class DocumentIDForCheck
        {
            public int DocumentID { get; set; }
        }
    }
}