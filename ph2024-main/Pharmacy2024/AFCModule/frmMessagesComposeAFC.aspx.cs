using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityModel;
using System.Data;
using System.Configuration;
using BusinessLayer;
using System.IO;
using Synthesys.Controls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmMessagesComposeAFC : System.Web.UI.Page
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
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                string AFCCode = Session["UserLoginID"].ToString();
                Random random = new Random();
                string filePath1 = "";
                string filePath2 = "";

                //if (fileInput1.PostedFile.FileName.Length > 0)
                //{
                //    if (System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".PDF")
                //    {
                //        filePath1 = saveFile(AFCCode + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput1.PostedFile.FileName), 1);
                //    }
                //    else
                //    {
                //        shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                //        return;
                //    }
                //}
                string base64 = Request.Form["imgCropped"];
                if (base64.Length > 6)
                {
                    string fileName = AFCCode + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString();
                    filePath1 = UploadDoc(base64, fileName);
                }
                //if (fileInput2.PostedFile.FileName.Length > 0)
                //{
                //    if (System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".PDF")
                //    {
                //        filePath2 = saveFile(AFCCode + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput2.PostedFile.FileName), 2);
                //    }
                //    else
                //    {
                //        shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                //        return;
                //    }
                //}

                string To = "ADMINAFC";
                string From = AFCCode;
                string Subject = txtSubject.Text;
                string Message = txtMsg.Text.Replace(Environment.NewLine,"<br/>");

                if (reg.afcComposeMessage(To, From, Subject, Message, filePath1, filePath2, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    shInfo.SetMessage("Message has been sent successfully to ADMIN.", ShowMessageType.Information);
                    txtSubject.Text = "";
                    txtMsg.Text = "";
                }
                else
                {
                    shInfo.SetMessage("There is some problem in sending Message. Please try after some time.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private string saveFile(string FilePath, Int32 FileNo)
        {
            //string FtpAddress = ConfigurationManager.AppSettings["FtpAddress"].ToString();
            //string FtpUserName = ConfigurationManager.AppSettings["FtpUserName"].ToString();
            //string FtpUserPassword = ConfigurationManager.AppSettings["FtpUserPassword"].ToString();
            //string HttpAddress = ConfigurationManager.AppSettings["HttpAddress"].ToString();
            //string FtpFilePath = FtpAddress + "Attachment/" + FilePath;
            string HttpFilePath = "";// HttpAddress + "Attachment/" + FilePath;

            if (FileNo == 1)
            {
                if (fileInput1.PostedFile != null)
                {
                    //Int32 size = fileInput1.PostedFile.ContentLength;
                    //Stream str = getFtpRequestToWrite(FtpFilePath, FtpUserName, FtpUserPassword);
                    //byte[] file = new byte[size];
                    //fileInput1.PostedFile.InputStream.Read(file, 0, size);
                    //str.Write(file, 0, size);

                    //str.Close();
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    Stream objFileStream = fileInput1.PostedFile.InputStream;
                    FileInfo objFile = new FileInfo(fileInput1.PostedFile.FileName);
                    string sysfilename = FilePath;//+ "_" + DateTime.Now.Ticks.ToString()
                    HttpFilePath = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, fileInput1.PostedFile.ContentType, "Attachment".ToLower());
                }
            }
            else if (FileNo == 2)
            {
                if (fileInput2.PostedFile != null)
                {
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    Stream objFileStream = fileInput2.PostedFile.InputStream;
                    FileInfo objFile = new FileInfo(fileInput2.PostedFile.FileName);
                    string sysfilename = FilePath;//+ "_" + DateTime.Now.Ticks.ToString()
                    HttpFilePath = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, fileInput2.PostedFile.ContentType, "Attachment".ToLower());
                }
            }

            return HttpFilePath;
        }
        //private Stream getFtpRequestToWrite(string FilePath, string FtpUserName, string FtpUserPassword)
        //{
        //    FtpWebRequest RequestTowrite = (FtpWebRequest)WebRequest.Create(FilePath);
        //    RequestTowrite.Credentials = new NetworkCredential(FtpUserName, FtpUserPassword);
        //    RequestTowrite.Method = WebRequestMethods.Ftp.UploadFile;
        //    RequestTowrite.UseBinary = true;
        //    return (RequestTowrite.GetRequestStream());
        //} protected void Page_Load(object sender, EventArgs e)
        //{

        //}
        protected void btnUploadComplete_Click(object sender, EventArgs e)
        {

        }

        public string UploadDoc(string base64String, string fileName)
        {
            if (base64String.Length > 0)
            {
                Stream objFileStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(base64String));
                AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();

                string[] strings = base64String.Split(',');
                var bytes = Convert.FromBase64String(strings[1]);
                string extension = "";
                string contenttype = string.Empty;
                string fileurl = "";
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
                    string sysfilename = fileName + extension;// Session["UserID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + extension;
                    fileurl = azureDocumentUpload.UploadDocumentFromByteArrayWithContentType(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), bytes, contenttype, "Attachment");

                    if (extension != ".pdf")
                    {
                        byte[] data = default(byte[]);
                        //data = CreateThumbnel(bytes);
                        //string thumbnailUrl = azureDocumentUpload.UploadDocumentFromByteArrayWithContentType(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), data, contenttype, "studentAttachmentthumbnail");
                    }
                }
                return fileurl;
            }
            else
            {
                return "Invalid File";
            }
        }
    }
}