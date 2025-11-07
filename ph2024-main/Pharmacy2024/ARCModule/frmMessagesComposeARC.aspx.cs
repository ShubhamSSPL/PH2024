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

namespace Pharmacy2024.ARCModule
{
    public partial class frmMessagesComposeARC : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
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
                string ARCCode = Session["UserLoginID"].ToString();
                Random random = new Random();
                string filePath1 = "";
                string filePath2 = "";

                if (fileInput1.PostedFile.FileName.Length > 0)
                {
                    if (System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".PDF")
                    {
                        filePath1 = saveFile(ARCCode + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput1.PostedFile.FileName), 1);
                    }
                    else
                    {
                        shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                        return;
                    }
                }
                //if (fileInput2.PostedFile.FileName.Length > 0)
                //{
                //    if (System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".PDF")
                //    {
                //        filePath2 = saveFile(ARCCode + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput2.PostedFile.FileName), 2);
                //    }
                //    else
                //    {
                //        shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                //        return;
                //    }
                //}

                string To = "ADMINARC";
                string From = ARCCode;
                string Subject = txtSubject.Text;
                string Message = txtMsg.Text;

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

            string HttpFilePath = "";

            if (FileNo == 1)
            {
                if (fileInput1.PostedFile != null)
                {
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    Stream objFileStream = fileInput1.PostedFile.InputStream;
                    FileInfo objFile = new FileInfo(fileInput1.PostedFile.FileName);
                    string sysfilename = FilePath.ToLower();//+ "_" + DateTime.Now.Ticks.ToString()
                    HttpFilePath = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["Project_Name"].ToLower(), sysfilename, objFileStream, fileInput1.PostedFile.ContentType, "attachment".ToLower());
                }
            }
            //else if (FileNo == 2)
            //{
            //    if (fileInput2.PostedFile != null)
            //    {
            //        Int32 size = fileInput2.PostedFile.ContentLength;
            //        Stream str = getFtpRequestToWrite(FtpFilePath, FtpUserName, FtpUserPassword);
            //        byte[] file = new byte[size];
            //        fileInput2.PostedFile.InputStream.Read(file, 0, size);
            //        str.Write(file, 0, size);

            //        str.Close();
            //    }
            //}

            return HttpFilePath;
        }
    }
}