using AjaxPro;
using BusinessLayer;
using DataAccess.Implementation;
using EntityModel;
using forProjectCustomExceptions;
using Newtonsoft.Json;
using RestSharp;
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
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmUploadRequiredDocumentsStep : System.Web.UI.Page
    {
        AzureDocumentUpload objDU = new AzureDocumentUpload();
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string NextYear = Global.NextYear; 
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
            if ((DateTime.Now < Global.EdittingOfApplicationFormStartDateTime || DateTime.Now > Global.EdittingOfApplicationFormEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //string _leftMenu = ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"];
            //((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormLinks = true;
            //((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormNumber = false;
            //((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFadingEffect = true; ((ExpanderMenu)Master.FindControl(_leftMenu)).FormType = 1;
            //((ExpanderMenu)Master.FindControl(_leftMenu)).FormNumber = Convert.ToInt64(Session["UserID"]);


            hdnFileUploadURL.Value = ConfigurationManager.AppSettings["FileUploadServiceURL"];
            hdnApplicationURL.Value = ConfigurationManager.AppSettings["ApplicationURL"];
            AjaxPro.Utility.RegisterTypeForAjax(typeof(frmUploadRequiredDocumentsStep));
            if (!IsPostBack)
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                if (PID.ToString().GetHashCode() != Code)
                {
                    Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                }

                if (Global.EdittingOfApplicationForm == 0 && UserTypeID != 21)
                {
                    Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                }

                DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplay(PID);

                if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                {
                    lblApplicationID.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblCandidateName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CandidateName"].ToString();
                }

                LoadDocuments(PID);

                //try
                //{
                //    if (reg.CheckFCVerificationStatus(objSessionData.PID))
                //    {
                //        shInfo.SetMessage("Application Form is Confirmed or Has been picked for SC E-Verification", ShowMessageType.Information);
                //        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                //    }
                //    DataSet dsCurrentLink = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmUploadRequiredDocumentsStep");

                //    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                //    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                //    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                //    hdnCategoryID.Value = reg.getCategoryID(objSessionData.PID).ToString();

                //    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                //    {
                //        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                //    }
                //    if ((ApplicationFormStatus == 'A' || objSessionData.StepID < 6) && (FCVerificationStatus == 'C' || FCVerificationStatus == 'P'))
                //    {
                //        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                //    }
                //    //**For E-Verification
                //    if (reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "Y")
                //    {
                //        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                //    }
                //    LoadDocuments(objSessionData.PID);
                //    //trYesNo.Visible = false;
                //}
                //catch (Exception ex)
                //{
                //    Logging.LogException(ex, "[Page Level Error]");
                //    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                //}

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

                ds = new dbUtility().GetAllDocuments(PID);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "1")
                        {
                            gvDocuments.DataSource = ds.Tables[0];
                            gvDocuments.DataBind();

                            lblFileTypesAllowed.Text = hdnFileTypes.Value = Convert.ToString(ds.Tables[1].Rows[0]["FileExtensions"]);
                            hdnMaxSize.Value = Convert.ToString(ds.Tables[1].Rows[0]["MaxSizeInKB"]);
                            lblMaxFileSize.Text = hdnMaxSize.Value + " KB";
                            string CasteValidityStatus = Convert.ToString(ds.Tables[1].Rows[0]["CasteValidityStatus"]);
                            string NCLStatus = Convert.ToString(ds.Tables[1].Rows[0]["NCLStatus"]);
                            string EWSStatus = Convert.ToString(ds.Tables[1].Rows[0]["EWSStatus"]);

                            if (Convert.ToString(ds.Tables[0].Rows[0]["FormStatus"]) == "A" && Convert.ToString(ds.Tables[0].Rows[0]["FCVerificationStatus"]) == "C")
                            {
                                shInfo.SetMessage("You Can Not Upload/Delete Document(s) now.", ShowMessageType.Information);
                                gvDocuments.Columns[3].Visible = false;
                                gvDocuments.Columns[5].Visible = false;
                            }
                            else
                            {
                                gvDocuments.Columns[3].Visible = true;
                                gvDocuments.Columns[5].Visible = true;

                                for (int i = 0; i < gvDocuments.Rows.Count; i++)
                                {
                                    int DocumentID = Convert.ToInt32(((HiddenField)gvDocuments.Rows[i].FindControl("hdnDocId")).Value);

                                    if (DocumentID == 22 && CasteValidityStatus != "R")
                                    {
                                        gvDocuments.Rows[i].Cells[3].ColumnSpan = 3;
                                        gvDocuments.Rows[i].Cells[4].Visible = false;
                                        gvDocuments.Rows[i].Cells[5].Visible = false;
                                        gvDocuments.Rows[i].Cells[3].Text = CasteValidityStatus == "A" ? "<font color='red'><b>Applied and Not Received</b></font>" : "<font color='red'><b>Not Applied</b></font>";
                                    }
                                    if (DocumentID == 24 && NCLStatus != "R")
                                    {
                                        gvDocuments.Rows[i].Cells[3].ColumnSpan = 3;
                                        gvDocuments.Rows[i].Cells[4].Visible = false;
                                        gvDocuments.Rows[i].Cells[5].Visible = false;
                                        gvDocuments.Rows[i].Cells[3].Text = NCLStatus == "A" ? "<font color='red'><b>Applied and Not Received</b></font>" : "<font color='red'><b>Not Applied</b></font>";
                                    }
                                    if (DocumentID == 36 && EWSStatus != "R")
                                    {
                                        gvDocuments.Rows[i].Cells[3].ColumnSpan = 3;
                                        gvDocuments.Rows[i].Cells[4].Visible = false;
                                        gvDocuments.Rows[i].Cells[5].Visible = false;
                                        gvDocuments.Rows[i].Cells[3].Text = EWSStatus == "A" ? "<font color='red'><b>Applied and Not Received</b></font>" : "<font color='red'><b>Not Applied</b></font>";
                                    }
                                }
                            }

                        }
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "0")
                        {
                            gvDocuments.DataSource = null;
                            gvDocuments.DataBind();
                            shInfo.SetMessage(Convert.ToString(ds.Tables[0].Rows[0]["Message"]), ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("No Data Found!!!", ShowMessageType.Information);
                        }
                    }
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
        protected void gvDocuments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (e.CommandName == "D")
            {
                Int32 DocId = Convert.ToInt32(e.CommandArgument);
                ImageButton img = (ImageButton)e.CommandSource;
                GridViewRow gr = (GridViewRow)(img.Parent.Parent);
                string fileName = ((System.Web.UI.WebControls.HiddenField)(gr.Cells[gr.Cells.Count - 1].Controls[1])).Value;
                DataSet ds = null;

                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                try
                {
                    //SessionData objSessionData = (SessionData)Session["SessionData"];
                    ds = new dbUtility().deleteUploadedDocument(PID, DocId, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

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
        protected void btnSaveUpload_Click(object sender, EventArgs e)
        {
            char checkBarcode = 'N';
            string barcode = "";
            string CandidateBarcode = "";
            if (btnrdYes.Checked)
            {
                checkBarcode = 'Y';
                barcode = txtbarcode.Text;
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (flUpload.HasFile)
            {
                AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                Stream objFileStream = flUpload.PostedFile.InputStream;
                FileInfo objFile = new FileInfo(flUpload.PostedFile.FileName);
                string sysfilename = Session["UserID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + objFile.Extension;
                string fileurl = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, flUpload.PostedFile.ContentType, "studentdocuments");
                //SessionData objSessionData = (SessionData)Session["SessionData"];

                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

                if (fileurl != "")
                {
                    string uploadedFileURL, originalFileName;
                    uploadedFileURL = fileurl; originalFileName = flUpload.PostedFile.FileName;
                    Int64 DocID = hdnCurrentDocId.Value != "" ? Convert.ToInt64(hdnCurrentDocId.Value) : 0;
                    DataSet ds = null;
                    try
                    {
                        int DistrictID = 0;
                        int JuridictionID = 0;
                        int TalukaID = 0;
                        ds = new dbUtility().saveUploadedDocument(PID, DocID, sysfilename, uploadedFileURL, originalFileName, Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress(), checkBarcode, barcode, CandidateBarcode);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                            {
                                if (DocID == 21 || DocID == 22)
                                {
                                    DataSet dsJ = null;
                                    if (DocID == 21)
                                    {
                                        DistrictID = Convert.ToInt32(hidDID.Value);
                                        JuridictionID = Convert.ToInt32(hidJUD.Value);
                                        TalukaID = Convert.ToInt32(hidTID.Value);
                                    }
                                    else
                                    {
                                        DistrictID = Convert.ToInt32(hidDID.Value);
                                        JuridictionID = Convert.ToInt32(hidJUD.Value);
                                    }
                                    dsJ = new dbUtility().saveUploadedDocumentJuridiction(PID, DocID, Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress(), JuridictionID, DistrictID, TalukaID);
                                    if (dsJ != null && dsJ.Tables.Count > 0)
                                    {
                                        if (dsJ.Tables[0].Rows.Count > 0 && dsJ.Tables[0].Rows[0]["Status"].ToString() == "1")
                                        {
                                            shInfo.SetMessage("The File has been uploaded.", ShowMessageType.Information);
                                            LoadDocuments(PID);
                                        }
                                    }
                                    else
                                    {
                                        shInfo.SetMessage("The File Juridiction Details Not Saved, Try Again.", ShowMessageType.Information);
                                        LoadDocuments(PID);
                                    }
                                }
                                else
                                {
                                    shInfo.SetMessage("The File has been uploaded.", ShowMessageType.Information);
                                    LoadDocuments(PID);
                                }
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("The File Details Not Saved, Try Again.", ShowMessageType.Information);
                            LoadDocuments(PID);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "[Page Level Error]");
                        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError);
                        LoadDocuments(PID);
                    }
                    finally
                    {
                        if (ds != null)
                            ds.Dispose();
                    }
                }
                else
                {
                    shInfo.SetMessage("Please Select File.", ShowMessageType.Information);
                    LoadDocuments(PID);
                }
            }
        }

        protected void btnUploadComplete_Click(object sender, EventArgs e)
        {
            //SessionData objSessionData = (SessionData)Session["SessionData"];
            //LoadDocuments(objSessionData.PID);
            LoadDocuments(Convert.ToInt64(Request.QueryString["PID"].ToString()));
        }
        protected void gvDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
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
            }
        }
        [AjaxMethod]
        public DataSet FillJuridiction(string documentID, string SPID)
        {
            DataSet ds = new DataSet();
            try
            {
                //SessionData objSessionData = (SessionData)Session["SessionData"];
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
            //SessionData objSessionData = (SessionData)Session["SessionData"];
            //return reg.getCategoryID(objSessionData.PID).ToString();
            return reg.getCategoryID(Convert.ToInt64(SPID)).ToString();
        }

        [AjaxMethod]
        public string UploadDoc(string base64String, string documentID, string hidJUD, string hidDID, string hidTID, string fileName, string fileExt, char checkBarcode, string barcode, string SPID, string CandidateBarcode)
        {
            //ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (base64String.Length > 7)
            {
                //char checkBarcode = 'N';
                //string barcode = "";
                //if (btnrdYes.Checked)
                //{
                //    checkBarcode = 'Y';
                //    barcode = txtbarcode.Text;
                //}
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
                            ds = new dbUtility().saveUploadedDocument(Convert.ToInt64(SPID), Convert.ToInt16(documentID), sysfilename, uploadedFileURL, originalFileName, Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress(), checkBarcode, barcode, CandidateBarcode);
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
                                        dsJ = new dbUtility().saveUploadedDocumentJuridiction(Convert.ToInt64(SPID), Convert.ToInt16(documentID), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress(), JuridictionID, DistrictID, TalukaID);
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
                                            // shInfo.SetMessage("The File Juridiction Details Not Saved, Try Again.", ShowMessageType.Information);
                                            // LoadDocuments(objSessionData.PID);
                                            return "The File Juridiction Details Not Saved, Try Again.";
                                        }
                                    }
                                    else
                                    {
                                        //  shInfo.SetMessage("The File has been uploaded.", ShowMessageType.Information);
                                        // LoadDocuments(objSessionData.PID);
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
                            txtEnterbarcode.Text = "";
                        }
                        catch (Exception ex)
                        {
                            Logging.LogException(ex, "[Page Level Error]");
                            // shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError);
                            // LoadDocuments(objSessionData.PID);
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
                        // LoadDocuments(objSessionData.PID);
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
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //**For E - Verification
            try
            {
                lblDisplayDocumentSubmissionStatus.Text = "";
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                string BlockFlag = "";
                string NationalityFlag = "";
                string CandidatureTypeFlag = "";
                string CasteCertificateFlag = "";
                string CasteValidityCertificateFlag = "";
                string CVCReceiptFlag = "";
                string NonCreamyLayerCertificateFlag = "";
                string NCLReceiptFlag = "";
                string EWSFlag = "";
                string PHTypeFlag = "";
                string DefenceTypeFlag = "";
                string OrphanFlag = "";
                string TFWSFlag = "";
                string MinorityFlag = "";
                string IGDFlag = "";
                Int32 CategoryChangeFlag = 0;
                string EWSReceiptFlag = "";

                gvDocumentsNotSubmitted.DataSource = reg.GetDocumentListByUploadedFlag(PID, "N");
                gvDocumentsNotSubmitted.DataBind();

                gvDocumentsSubmitted.DataSource = reg.GetDocumentListByUploadedFlag(PID, "Y");
                gvDocumentsSubmitted.DataBind();
                for (Int32 i = 0; i < gvDocumentsNotSubmitted.Rows.Count; i++)
                {

                    Int32 DocumentID = Int32.Parse(((Label)gvDocumentsNotSubmitted.Rows[i].FindControl("lblDocumentID")).Text);
                    string DocumentDetails = gvDocumentsNotSubmitted.Rows[i].Cells[1].Text;

                    if (DocumentID == 1)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                        //NationalityFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 5)
                    {
                        CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 6)
                    {
                        CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 7)
                    {
                        CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 8)
                    {
                        CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 9)
                    {
                        CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 11)
                    {
                        CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 12)
                    {
                        CandidatureTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 20)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 21)
                    {
                        CasteCertificateFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 22)
                    {
                        CasteValidityCertificateFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 23)
                    {
                        CVCReceiptFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 24)
                    {
                        NonCreamyLayerCertificateFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 40)
                    {
                        NCLReceiptFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 25)
                    {
                        PHTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 26)
                    {
                        PHTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 27)
                    {
                        DefenceTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 28)
                    {
                        DefenceTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 29)
                    {
                        DefenceTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 30)
                    {
                        DefenceTypeFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 32)
                    {
                        TFWSFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 33)
                    {
                        MinorityFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 35)
                    {
                        OrphanFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 36)
                    {
                        EWSFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 42)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 43)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 45)
                    {
                        IGDFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 47)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 81)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 82)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 83)
                    {
                        BlockFlag += "As you have not uploaded the  " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 84)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 85)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 86)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 87)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 88)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 89)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 90)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 91)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 92)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 93)
                    {
                        BlockFlag += "As you have not uploaded the  " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 94)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 95)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 96)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 97)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 98)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 99)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 100)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 101)
                    {
                        BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                    else if (DocumentID == 102)
                    {
                        EWSFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                    }
                }

                for (Int32 i = 0; i < gvDocumentsSubmitted.Rows.Count; i++)
                {
                    Int32 DocumentID = Int32.Parse(((Label)gvDocumentsSubmitted.Rows[i].FindControl("lblDocumentID")).Text);

                    if (DocumentID == 24)
                    {
                        // trNCLIssueDate.Visible = true;
                        // trNCLValidUpTo.Visible = true;
                    }
                    else if (DocumentID == 25)
                    {
                        PHTypeFlag += "NA";
                    }
                    else if (DocumentID == 26)
                    {
                        PHTypeFlag += "NA";
                    }
                    else if (DocumentID == 27)
                    {
                        DefenceTypeFlag += "NA";
                    }
                    else if (DocumentID == 28)
                    {
                        DefenceTypeFlag += "NA";
                    }
                    else if (DocumentID == 29)
                    {
                        DefenceTypeFlag += "NA";
                    }
                    else if (DocumentID == 30)
                    {
                        DefenceTypeFlag += "NA";
                    }
                    else if (DocumentID == 32)
                    {
                        TFWSFlag += "NA";
                    }
                    else if (DocumentID == 33)
                    {
                        MinorityFlag += "NA";
                    }
                    else if (DocumentID == 35)
                    {
                        OrphanFlag += "NA";
                    }
                    else if (DocumentID == 36)
                    {
                        EWSFlag += "NA";
                    }
                    else if (DocumentID == 45)
                    {
                        IGDFlag += "NA";
                    }
                }
                if (BlockFlag.Length > 0)
                {
                    SessionData objSessionDat = (SessionData)Session["SessionData"];
                    BlockFlag += "And Hence, Candidate is not Allowed to Submit the Application Form.";
                    lblDisplayDocumentSubmissionStatus.Text += BlockFlag + "<br /><br />";
                    lblDisplayDocumentSubmissionStatus.Visible = true;
                    LoadDocuments(PID);
                    shInfo.SetMessage(BlockFlag + "<br /><br />", ShowMessageType.Information);
                }
                else
                {
                    if (CandidatureTypeFlag.Length > 0)
                    {
                        
                        
                        CandidatureTypeFlag += "And hence, Your Type of Candidature will be converted to 'OMS'.<br />";
                        CandidatureTypeFlag += "And hence, Your Category will be converted to 'OPEN'.<br />";
                        CategoryChangeFlag = 1;
                        if (PHTypeFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, you can not avail the Privilege for Person with Disability Quota.<br />";
                            PHTypeFlag = "Change";
                        }
                        if (DefenceTypeFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, you can not avail the Privilege for Defence Employee Quota.<br />";
                            DefenceTypeFlag = "Change";
                        }
                        if (EWSFlag.Length > 0 || EWSReceiptFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, you can not avail the Privilege for EWS Quota.<br />";
                            EWSFlag = "Change";
                        }
                        if (TFWSFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, you can not avail the Privilege for TFWS Quota.<br />";
                            TFWSFlag = "Change";
                        }
                        if (OrphanFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, you can not avail the Privilege for Orphan Quota.<br />";
                            OrphanFlag = "Change";
                        }
                        if (MinorityFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, you can not avail the Privilege for Linguistic / Religious Minority Quota.<br />";
                            MinorityFlag = "Change";
                        }
                        if (IGDFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, you can not avail the Privilege for Intermediate Grade Drawing.<br />";
                            IGDFlag = "Change";
                        }
                        lblDisplayDocumentSubmissionStatus.Text += CandidatureTypeFlag + "<br /><br />";
                    }
                    else
                    {
                        if (CasteCertificateFlag.Length > 0 || CasteValidityCertificateFlag.Length > 0 || CVCReceiptFlag.Length > 0 || NonCreamyLayerCertificateFlag.Length > 0 || NCLReceiptFlag.Length > 0)
                        {
                            CasteCertificateFlag += CasteValidityCertificateFlag + CVCReceiptFlag + NonCreamyLayerCertificateFlag + NCLReceiptFlag + "And hence, Your Category will be converted to 'OPEN'.";
                            lblDisplayDocumentSubmissionStatus.Text += CasteCertificateFlag + "<br /><br />";
                            CategoryChangeFlag = 1;
                        }
                        if (PHTypeFlag.Length > 2)
                        {
                            PHTypeFlag += "And hence, you can not avail the Privilege for Person with Disability Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += PHTypeFlag + "<br /><br />";
                        }
                        if (DefenceTypeFlag.Length > 4)
                        {
                            DefenceTypeFlag += "And hence, you can not avail the Privilege for Defence Employee Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += DefenceTypeFlag + "<br /><br />";
                        }
                        if (EWSFlag.Length > 2 || EWSReceiptFlag.Length > 0)
                        {
                            EWSFlag += "And hence, you can not avail the Privilege for EWS Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += EWSFlag + "<br /><br />";
                        }
                        if (TFWSFlag.Length > 2)
                        {
                            TFWSFlag += "And hence, you can not avail the Privilege for TFWS Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += TFWSFlag + "<br /><br />";
                        }
                        if (OrphanFlag.Length > 2)
                        {
                            OrphanFlag += "And hence, you can not avail the Privilege for Orphan Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += OrphanFlag + "<br /><br />";
                        }
                        if (MinorityFlag.Length > 2)
                        {
                            MinorityFlag += "And hence, you can not avail the Privilege for Linguistic / Religious Minority Quota.";
                            lblDisplayDocumentSubmissionStatus.Text += MinorityFlag + "<br /><br />";
                        }
                        //if (IGDFlag.Length > 2)
                        //{
                        //    IGDFlag += "And hence, you can not avail the Privilege for Intermediate Grade Drawing.";
                        //    lblDisplayDocumentSubmissionStatus.Text += IGDFlag + "<br /><br />";
                        //}
                    }
                    if (lblDisplayDocumentSubmissionStatus.Text.Length > 0)
                    {
                        Int32 IsCandidatureTypeChanged = 0;
                        Int32 IsCategoryChanged = 0;
                        Int32 IsPHTypeChanged = 0;
                        Int32 IsEWSChanged = 0;

                        if (CandidatureTypeFlag.Length > 0)
                        {
                            IsCandidatureTypeChanged = 1;
                        }
                        if (CategoryChangeFlag == 1)
                        {
                            IsCategoryChanged = 1;
                        }
                        if (PHTypeFlag.Length > 2)
                        {
                            IsPHTypeChanged = 1;
                        }
                        if (EWSFlag.Length > 2)
                        {
                            IsEWSChanged = 1;
                        }
                        Int32 ProposedApplicationFeeToBePaid = reg.getProposedApplicationFeeToBePaid(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsEWSChanged);

                        //if (ProposedApplicationFeeToBePaid > 0)
                        //{
                        //    lblDisplayDocumentSubmissionStatus.Text += "<font size='4'><b>You have to Pay Rs. " + ProposedApplicationFeeToBePaid.ToString() + "/- ONLINE as a difference in fee.</b></font><br /><br />";
                        //}
                        shInfo.SetMessage(lblDisplayDocumentSubmissionStatus.Text, ShowMessageType.Information);
                        contentDocumentConferamtion.Visible = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowConfirmationBox();", true);
                        lblDisplayDocumentSubmissionStatus.Visible = true;
                         trYesNo.Visible = true;
                        btnProceed.Visible = false;
                    }
                    else
                    {
                        if (reg.saveUploadDocumentStepID(PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {

                            //if (objSessionData.StepID < 9)
                            //{
                            //    ((SessionData)Session["SessionData"]).StepID = 9;
                            //}

                            //Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
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
        protected void btnYes_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (reg.saveUploadDocumentStepID(objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {

                    if (objSessionData.StepID < 8)
                    {
                        ((SessionData)Session["SessionData"]).StepID = 8;
                    }
                    if (objSessionData.ApplicationFormStatus == 'I')
                    {
                        objSessionData.ApplicationFormStatus = 'C';
                    }
                    Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
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

        protected void btnNo_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            btnProceed.Visible = true;
            lblDisplayDocumentSubmissionStatus.Text = "";
            LoadDocuments(objSessionData.PID);
            //trYesNo.Visible = false;
        }

        [AjaxMethod]
        public ResponseCommon FetchDocument(int documentId, string barcode)
        {
            ResponseCommon response = new ResponseCommon();
            MahaITDocumentFetch documentFetch = new MahaITDocumentFetch();
            try
            {

                if (documentId > 0 && (barcode != "" || barcode != null))
                {
                    if (documentId == 21)
                    {
                        ResponseCasteCertificate result = documentFetch.FetchDocument<ResponseCasteCertificate>(barcode, "CasteCertificate");
                        response = documentFetch.MapResult(result);
                    }
                    else if (documentId == 32 || documentId == 34)
                    {
                        ResponseIncome result = documentFetch.FetchDocument<ResponseIncome>(barcode, "Income");
                        response = documentFetch.MapResult(result);
                    }
                    else if (documentId == 1 || documentId == 2 || documentId == 11)
                    {
                        ResponseAgeNationalityDomicile result = documentFetch.FetchDocument<ResponseAgeNationalityDomicile>(barcode, "AgeNationalityDomicile");
                        response = documentFetch.MapResult(result);
                    }
                    else if (documentId == 22)
                    {
                        ResponseCasteValidity result = documentFetch.FetchDocument<ResponseCasteValidity>(barcode, "CasteValidity");
                        response = documentFetch.MapResult(result);
                    }
                    else if (documentId == 25)
                    {
                        ResponseDisabilityCertificate result = documentFetch.FetchDocument<ResponseDisabilityCertificate>(barcode, "DisabilityCertificate");
                        response = documentFetch.MapResult(result);
                    }
                    else if (documentId == 24)
                    {
                        ResponseNCL result = documentFetch.FetchDocument<ResponseNCL>(barcode, "NclCertificate");
                        response = documentFetch.MapResult(result);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }


        [AjaxMethod]
        public bool InsertUpdateDocumentFetchData(string responseString, string DocID)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            ResponseCommon response = new ResponseCommon();
            response = JsonConvert.DeserializeObject<ResponseCommon>(responseString);
            response.PersonalID = objSessionData.PID;
            response.DocumentID = Convert.ToInt64(DocID);
            response.CreatedBy = Session["UserLoginID"].ToString();
            response.CreatedByIPAddress = UserInfo.GetIPAddress();
            return reg.InsertUpdateDocumentFetchData(response);
            //  return true;
        }

        [AjaxMethod]
        public ResponseCommon GetDocumentFetchData(Int64 PersonalID, Int64 DocID)
        {
            return reg.GetDocumentFetchData(PersonalID, DocID);
            
        }
        //
        protected void btnFetchDocument_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (txtbarcode.Text.Trim().Length > 0)
            {
                MahaITDocumentFetch documentFetch = new MahaITDocumentFetch();

                documentFetch.FetchDocument<ResponseIncome>("12511806050001366140", "Income");
                documentFetch.FetchDocument<ResponseIncome>("12512008165010133645", "Income");
                documentFetch.FetchDocument<ResponseCasteCertificate>("12852003052009444372", "CasteCertificate");
                documentFetch.FetchDocument<ResponseAgeNationalityDomicile>("12532008271001579839", "AgeNationalityDomicile");
                documentFetch.FetchDocument<ResponseCasteValidity>("15212016008318", "CasteValidity");
                documentFetch.FetchDocument<ResponseDisabilityCertificate>("1000013117101", "DisabilityCertificate");
            }
            else
            {
                shInfo.SetMessage("Please Enter BarCode Id from your Document", ShowMessageType.UserError);
            }
            // documentFetch.FetchDocument<ResponseNclCertificate>("", "NclCertificate");
        }
        protected void btnUploadDocument_Click(object sender, EventArgs e)
        {

        }
        //protected void btnrdYes_CheckedChanged(object sender, EventArgs e)
        //{
        //    trBarcode.Visible = true;
        //    trDocFetchbtn.Visible = true;
        //    trUploadDoc.Visible = false;
        //}

        //protected void btnrdNo_CheckedChanged(object sender, EventArgs e)
        //{
        //    txtbarcode.Text = "";
        //    trBarcode.Visible = false;
        //    trDocFetchbtn.Visible = false;
        //    trUploadDoc.Visible = true;

        //}

        private class dbUtility
        {
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
                    return db.ExecuteDataSet("MHDTE_spGetAllDocuments", param);

                }
                finally
                {
                    db.Dispose();
                }

                //return ExecProcedure("MHDTE_spGetAllDocuments", param, "tbl");
            }
            public DataSet saveUploadedDocument(Int64 PID, Int64 DocumentID, string FileName, string AbsoluteFilePath, string OriginalFileName, string FileUploadedBy, string FileUploadedByIPAddress, char checkbarcode, string barcode, string CandidateBarcode)
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
                    new SqlParameter("@CandidateBarcode", SqlDbType.NVarChar),
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = FileName;
                param[3].Value = AbsoluteFilePath;
                param[4].Value = OriginalFileName;
                param[5].Value = FileUploadedBy;
                param[6].Value = FileUploadedByIPAddress;
                param[7].Value = "A";
                param[8].Value = checkbarcode;
                param[9].Value = barcode;
                param[10].Value = CandidateBarcode;
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