using AjaxPro;
using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using Synthesys.DataAcess;
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

namespace Pharmacy2024.AFCModule
{
    public partial class frmVerificationforCVCTVCNCLEWSDocument : System.Web.UI.Page
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
            ////Commited by sharad ARC closed than uplode cvc and tvc and ews  closed
            //tblPersonalInfo.Visible = false;
            //ContentTable2.Visible = false;
            //contentFileTest.Visible = false;
            //contentViewDocument.Visible = false;
            ////Commited by sharad ARC closed than uplode cvc and tvc and ews  closed

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["UserTypeID"].ToString() == "91")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            //if (Session["UserTypeID"].ToString() != "21")
            //{
            //    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            //}
            AjaxPro.Utility.RegisterTypeForAjax(typeof(frmVerificationforCVCTVCNCLEWSDocument));
            if (!IsPostBack)
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                ViewState["PID"] = PID;

                if (PID.ToString().GetHashCode() != Code)
                {
                    Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                }
                DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplayInOptionForm(PID);
                Int32 Step = 1;
                DataSet dsCurrentAllotmentDetails = reg.getCurrentAllotmentDetails(PID);
                if
                        (
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
                             DateTime.Now <= Global.ARCReportingCAPRound4EndDateTime) || Step == 1
                        )
                {
                    if (dsCurrentAllotmentDetails.Tables[0].Rows.Count > 0)
                    {
                        if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["Category_Benifited"].ToString() == "Yes")
                        {

                        }
                        else
                        {

                        }
                        if (dsCurrentAllotmentDetails.Tables[0].Rows[0]["EWS_Benifited"].ToString() == "Yes")
                        {

                        }
                        else
                        {

                        }
                    }
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
                    }
                    PageLoad(1);

                }
                else
                {

                    ContentPlaceHolder mpContentPlaceHolder = new ContentPlaceHolder();
                    mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("rightContainer");
                    mpContentPlaceHolder.Visible = false;
                    shInfo.SetMessage("Link Is Closed .", ShowMessageType.Information);
                }


            }
        }
        private void PageLoad(int status)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            DataSet ds = reg.CheckCandidateValid(Convert.ToInt64(ViewState["PID"]));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["DocType"].ToString() == "CVC" || dr["DocType"].ToString() == "NCL")
                        {

                        }

                        if (dr["DocType"].ToString() == "EWS")
                        {

                        }
                        ContentTable2.Visible = true;
                        LoadDocuments(Convert.ToInt64(ViewState["PID"]));
                    }

                }
                else
                {
                    if (status == 1)
                        //shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate , Non - Creamy Layer Certificate or Economically Weaker Section In Proforma - V you can't upload the Document.", ShowMessageType.Information);
                        shInfo.SetMessage("you have uploaded all the required document you are not required to do anything.", ShowMessageType.Information);

                }
            }
            else
            {
                if (status == 1)
                    //shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate , Non - Creamy Layer Certificate or Economically Weaker Section In Proforma - V you can't upload the Document.", ShowMessageType.Information);
                    // commited by snehdeep
                    shInfo.SetMessage("you have uploaded all the required document you are not required to do anything.", ShowMessageType.Information);

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
                    Int64 PID = Convert.ToInt64(ViewState["PID"].ToString());
                    ds = new dbUtilitySEBC().deleteUploadedDocument(PID, DocId, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                    {
                        LoadDocuments(PID);
                    }
                    else
                    {
                        shInfo.SetMessage("Unable To Delete File, Try Again Later.", ShowMessageType.Information);
                        LoadDocuments(PID);
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
                    HiddenField hdnImgByteArray = (HiddenField)e.Row.FindControl("hdnImgByteArray");
                    hrefURL.HRef = ConfigurationManager.AppSettings["ApplicationURL"] + "ViewMyDocument.aspx?documentID=" + hidDID.Value;
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
                        hdnImgByteArray.Value = objDU.GetBlobContentAsBase64("studentdocuments", hidFURL.Value.ToString());

                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                }
            }
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
                ds.Tables[0].DefaultView.RowFilter = "DocumentID = '22' OR DocumentID = '24' OR DocumentID = '36'";
                if (ds.Tables[0].DefaultView.Count > 0)
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "1")
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
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "0")
                        {

                            gvCVCNCL.DataSource = null;
                            gvCVCNCL.DataBind();
                            shInfo.SetMessage(Convert.ToString(ds.Tables[0].Rows[0]["Message"]), ShowMessageType.Information);

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

        protected void btnUploadComplete_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(ViewState["PID"].ToString());
            LoadDocuments(PID);
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(ViewState["PID"]);
                string CVCStatus = "N";
                string NCLStatus = "N";
                string EWSStatus = "N";
                int DocumentCounter = 0;
                int DiscrepancyCounter = 0;
                bool docverifyed = false;
                string XMLstring = "<DocumentList>";
                for (Int32 i = 0; i < gvCVCNCL.Rows.Count; i++)
                {
                    string DocumentID = ((Label)gvCVCNCL.Rows[i].FindControl("lblDocumentID")).Text;

                    if (((RadioButton)gvCVCNCL.Rows[i].FindControl("rbnYes")).Checked)
                    {
                        XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "Y" + "\"></Document>";
                        docverifyed = true;
                        if (DocumentID == "22")
                        {
                            CVCStatus = "Y";
                        }
                        if (DocumentID == "24")
                        {
                            NCLStatus = "Y";
                        }
                        if (DocumentID == "36")
                        {
                            EWSStatus = "Y";
                        }
                    }
                    else
                    {
                        XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "N" + "\"></Document>";
                        DocumentCounter = DocumentCounter + 1;
                    }
                }
                XMLstring += "</DocumentList>";

                string commentforTfws = string.Empty;

                if (DocumentCounter > 0)
                {
                    btnProceed.Focus();
                    shInfo.SetMessage("Please Verify All Documents", ShowMessageType.Information);
                    ContentTable2.Focus();
                    tblPersonalInfo.Focus();
                }
                else
                {

                    SMSTemplate sMSTemplate = new SMSTemplate();
                    SynCommon synCommon = new SynCommon();
                    sMSTemplate.PID = PID;
                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                    sMSTemplate.CurrentDateTime = DateTime.Now.ToString();

                    if (reg.CheckCandidateCVCTVCEWSStatus(PID))
                    {
                        if (commentforTfws == string.Empty && docverifyed == true)
                        {
                            if (reg.updateDocumentSubmission(PID, XMLstring, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                            {
                                if (commentforTfws == string.Empty && docverifyed == true)
                                {
                                    if (reg.ConfirmFCCVCNCLEWSApplication(Convert.ToInt64(ViewState["PID"]), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), CVCStatus, NCLStatus, EWSStatus))
                                        if (Global.SendSMSToCandidate == 1)
                                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.verifyCVCTVCNCLEWSSucessful);
                                    Response.Redirect("../AFCModule/frmAcknowledgement?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                                }
                            }
                            else
                            {
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Candidate is  not Eligible to upload CVC / TVC or CVC / TVC already uploaded Please check the Documents.", ShowMessageType.Information);
                    }

                }


            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        [AjaxMethod]
        public string UploadDoc(string base64String, string documentID, string hidJUD, string hidDID, string hidTID, string fileName, string fileExt, string SPID)
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
                    string sysfilename = Convert.ToInt64(SPID) + "_" + DateTime.Now.Ticks.ToString() + extension;
                    string fileurl = azureDocumentUpload.UploadDocumentFromByteArrayWithContentType(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), bytes, contenttype, "studentdocuments");

                    if (extension != ".pdf")
                    {
                        byte[] data = default(byte[]);
                        data = CreateThumbnel(bytes);
                        string thumbnailUrl = azureDocumentUpload.UploadDocumentFromByteArrayWithContentType(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), data, contenttype, "studentdocumentsthumbnail");
                    }
                    //string fileurl = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, contenttype, "studentdocuments");


                    //Int64 PID = Convert.ToInt64(ViewState["PID"].ToString());
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
                            ds = new dbUtilitySEBC().saveUploadedDocument(Convert.ToInt64(SPID), Convert.ToInt16(documentID), sysfilename, uploadedFileURL, originalFileName, Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress());
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
                                        dsJ = new dbUtilitySEBC().saveUploadedDocumentJuridiction(Convert.ToInt64(SPID), Convert.ToInt16(documentID), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress(), JuridictionID, DistrictID, TalukaID);
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
        public DataSet FillJuridiction(string documentID, string SPID)
        {
            DataSet ds = new DataSet();
            try
            {

                if (documentID == "22")
                {
                    if (reg.getCategoryID(Convert.ToInt64(SPID)) == 3)
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
        public string getCategoryID(string SPID)
        {

            return reg.getCategoryID(Convert.ToInt64(SPID)).ToString();
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