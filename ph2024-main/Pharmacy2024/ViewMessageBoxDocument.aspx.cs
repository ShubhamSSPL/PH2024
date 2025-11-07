using AjaxPro;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024
{
    public partial class ViewMessageBoxDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["ApplicationURL"], true);
            }
            if (!IsPostBack)
            {
                ShowDocument();
            }
        }
           
        private void ShowDocument()
        {
            AzureDocumentUpload objDU = new AzureDocumentUpload();
            int DocID = int.Parse(Request["documentID"]);
            //From documentid get document detailsfrom
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_GetMessageBoxDocumentDetails", new SqlParameter[] { new SqlParameter("@DocumentID", DocID) });
            db.Dispose();


            if (ds.Tables[0].Rows.Count > 0)
            {
                string dURL = string.Empty;
                string dName = string.Empty;
                if (Request["Attachment"] == "1")
                {
                    dURL = ds.Tables[0].Rows[0]["Attachment1"].ToString().ToLower();
                    dName = ds.Tables[0].Rows[0]["SentBy"].ToString();
                }
                else
                {

                    dURL = ds.Tables[0].Rows[0]["Attachment2"].ToString().ToLower();
                    dName = ds.Tables[0].Rows[0]["SentBy"].ToString();
                }
                string ext = System.IO.Path.GetExtension(dURL).ToLower();
                string base64 = objDU.ConvertImageURLToBase64(dURL);
                if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".bmp")
                {
                    Response.Write("<img src='data:image/png;base64," + base64 + "'/>");
                }
                else if (ext == ".pdf")
                {
                    //Response.AddHeader("Content-Type", "application/pdf");
                    //Response.AddHeader("Content-Length", base64.Length.ToString());
                    //Response.AddHeader("Content-Disposition", "inline;");
                    //Response.AddHeader("Cache-Control", "private, max-age=0, must-revalidate");
                    //Response.AddHeader("Pragma", "public");
                    //Response.BinaryWrite(Convert.FromBase64String(base64));
                    WebClient webClient = new WebClient();
                    Byte[] buffer = webClient.DownloadData(dURL);
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.AddHeader("Content-Disposition", "inline;");
                    Response.AddHeader("Cache-Control", "private, max-age=0, must-revalidate");
                    Response.AddHeader("Pragma", "public");
                    Response.BinaryWrite(buffer);
                }
                else if (ext == ".zip" || ext == ".rar")
                {
                    Response.AddHeader("Content-Type", "application/x-compressed");
                    Response.AddHeader("Content-Length", base64.Length.ToString());
                    Response.AddHeader("Content-Disposition", "attachment; filename=document.zip;");
                    Response.AddHeader("Cache-Control", "private, max-age=0, must-revalidate");
                    Response.AddHeader("Pragma", "public");
                    Response.BinaryWrite(Convert.FromBase64String(base64));
                }
            }

        }
        [AjaxMethod]
        public string GetBlobContentAsBase64(string blobFilePath)
        {
            AzureDocumentUpload objDU = new AzureDocumentUpload();
            string base64 = objDU.GetBlobContentAsBase64("Attachment", blobFilePath);
            return base64;
        }
        [AjaxMethod]
        public string GetCandidateGrievanceDocumentAsBase64(string blobFilePath)
        {
            AzureDocumentUpload objDU = new AzureDocumentUpload();
            string base64 = objDU.GetBlobContentAsBase64("grievance", blobFilePath);
            return base64;
        }
    }
}