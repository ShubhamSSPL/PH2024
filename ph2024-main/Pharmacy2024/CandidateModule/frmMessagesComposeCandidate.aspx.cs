using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class frmMessagesComposeCandidate : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            //if (Request.Cookies["Theme"] == null)
            //{
            //    Page.Theme = "default";
            //}
            //else
            //{
            //    Page.Theme = Request.Cookies["Theme"].Value;
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            var ss = Session["UserLoginID"].ToString().Substring(4);
            Int64 PersonalID = Convert.ToInt64(ss);
            if (!reg.CheckCandidateValidForMessage(PersonalID))
            {
                Session["Error"] = "Your Application form is not confirmed So you are not able to send Message to Admin.";
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
            }
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

                if (fileInput1.PostedFile.FileName.Length > 0)
                {
                    if (System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".PDF")
                    {
                        filePath1 = saveFile(AFCCode + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput1.PostedFile.FileName), 1);
                    }
                    else
                    {
                        shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                        return;
                    }
                }
                if (fileInput2.PostedFile.FileName.Length > 0)
                {
                    if (System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".PDF")
                    {
                        filePath2 = saveFile(AFCCode + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput2.PostedFile.FileName), 2);
                    }
                    else
                    {
                        shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                        return;
                    }
                }

                string To = "ADMINAFC";
                string From = AFCCode;
                string Subject = txtSubject.Text;
                string Message = txtMsg.Text;

                if (reg.CandidateComposeMessage(To, From, Subject, Message, filePath1, filePath2, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
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
                    HttpFilePath = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename, objFileStream, fileInput1.PostedFile.ContentType, "Attachment".ToLower());
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
                    HttpFilePath = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename, objFileStream, fileInput2.PostedFile.ContentType, "Attachment".ToLower());
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
        //}
    }
}