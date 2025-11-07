using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System.IO;
using Synthesys.DataAcess;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using AjaxPro;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Pharmacy2024.MVModule
{
    public partial class frmUploadRequiredDocuments : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();

        AzureDocumentUpload objDU = new AzureDocumentUpload();
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
            if (Session["UserLoginId"] == null)
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
            hdnFileUploadURL.Value = ConfigurationManager.AppSettings["FileUploadServiceURL"];
            hdnApplicationURL.Value = ConfigurationManager.AppSettings["ApplicationURL"];
            AjaxPro.Utility.RegisterTypeForAjax(typeof(frmUploadRequiredDocuments));
            if (!IsPostBack)
            {

                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                if (PID.ToString().GetHashCode() != Code)
                {
                    Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                }

                DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplay(PID);

                if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                {
                    lblApplicationID.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblCandidateName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CandidateName"].ToString();
                }

                LoadDocuments(PID);
            }
        }
        protected void LoadDocuments(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            DataSet ds = null;
            // DocumentJWT docJWT = new DocumentJWT();
            try
            {
                hdnFileTypes.Value = "0";
                hdnFileTypesCode.Value = "0";
                hdnMaxSize.Value = "0";
                hdnMaxSizeCode.Value = "0";

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
                            }


                            Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                            if ((UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                            {
                                for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                                {
                                    gvDocuments.Rows[i].Cells[5].Text = "";
                                }
                            }
                            else if ((UserTypeID == 23 || UserTypeID == 24) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                            {
                                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
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
                try
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (flUpload.HasFile)
            {
                AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                Stream objFileStream =  flUpload.PostedFile.InputStream;
                FileInfo objFile = new FileInfo(flUpload.PostedFile.FileName);
                string sysfilename = Session["UserID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + objFile.Extension;
                string fileurl = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, flUpload.PostedFile.ContentType, "studentdocuments");
                if (objFile.Extension != ".pdf")
                {
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(objFileStream))
                    {
                        fileData = binaryReader.ReadBytes(flUpload.PostedFile.ContentLength);
                    }
                    if (fileData.Length > 0)
                    {
                        byte[] data = default(byte[]);
                        data = CreateThumbnel(fileData);
                        string thumbnailUrl = azureDocumentUpload.UploadDocumentFromByteArrayWithContentType(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), data, flUpload.PostedFile.ContentType, "studentdocumentsthumbnail");
                    }
                }
                
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

                        if (originalFileName != "" && DocID > 0)
                        {
                            ds = new dbUtility().saveUploadedDocument(PID, DocID, sysfilename, uploadedFileURL, originalFileName, Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress());

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
                                        dsJ = new dbUtility().saveUploadedDocumentJuridiction(Convert.ToInt64(hidPID.Value), DocID, Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress(), JuridictionID, DistrictID, TalukaID);
                                        if (dsJ != null && dsJ.Tables.Count > 0)
                                        {
                                            if (dsJ.Tables[0].Rows.Count > 0 && dsJ.Tables[0].Rows[0]["Status"].ToString() == "1")
                                            {
                                                shInfo.SetMessage("The File has been uploaded.", ShowMessageType.Information);
                                                LoadDocuments(Convert.ToInt64(hidPID.Value));
                                            }
                                        }
                                        else
                                        {
                                            shInfo.SetMessage("The File Juridiction Details Not Saved, Try Again.", ShowMessageType.Information);
                                            LoadDocuments(Convert.ToInt64(hidPID.Value));
                                        }
                                    }
                                    else
                                    {
                                        shInfo.SetMessage("The File has been uploaded.", ShowMessageType.Information);
                                        LoadDocuments(Convert.ToInt64(hidPID.Value));
                                    }
                                }
                                else
                                {
                                    shInfo.SetMessage("The File Details Not Saved, Try Again.", ShowMessageType.Information);
                                    LoadDocuments(Convert.ToInt64(hidPID.Value));
                                }
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("Please Select File.", ShowMessageType.Information);
                            LoadDocuments(Convert.ToInt64(hidPID.Value));
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
            }
            else
            {
                shInfo.SetMessage("Please Select File.", ShowMessageType.Information);
                LoadDocuments(Convert.ToInt64(hidPID.Value));
            }
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
                SessionData objSessionData = (SessionData)Session["SessionData"];
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
        private class dbUtility// : DBUtility
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
                    // return ExecProcedure("MHDTE_spGetAllDocuments", param, "tbl");
                }
                finally
                {
                    db.Dispose();
                }



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
                    return db.ExecuteDataSet("MHDTE_spUpdateDocumentUploadStatus", param);
                    // return ExecProcedure("MHDTE_spUpdateDocumentUploadStatus", param, "tbl");
                }
                finally
                {
                    db.Dispose();
                }


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
                new SqlParameter("@DocumentStatus",SqlDbType.VarChar)
            };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = "";
                param[3].Value = "";
                param[4].Value = "";
                param[5].Value = FileUploadedBy;
                param[6].Value = FileUploadedByIPAddress;
                param[7].Value = "D";

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUpdateDocumentUploadStatus", param);
                    //return ExecProcedure("MHDTE_spUpdateDocumentUploadStatus", param, "tbl");
                }
                finally
                {
                    db.Dispose();
                }


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
                    //return ExecProcedure("MHDTE_spUpdateJuridictionDocumentUpload", param, "tbl");
                }
                finally
                {
                    db.Dispose();
                }


            }
        }
    }
}