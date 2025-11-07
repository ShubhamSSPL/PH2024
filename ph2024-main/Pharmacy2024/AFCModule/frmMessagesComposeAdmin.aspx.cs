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
using RestSharp;
using System.Threading.Tasks;

namespace Pharmacy2024.AFCModule
{
    public partial class frmMessagesComposeAdmin : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                

                Page.Form.Attributes.Add("enctype", "multipart/form-data");

                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                string UserLoginID = Session["UserLoginID"].ToString();

                DataSet ds = reg.getROList(UserTypeID, UserLoginID);
                ds.Merge(reg.getAFCList(UserTypeID, UserLoginID));
                ViewState["ds"] = ds;

                gvList.DataSource = ds;
                gvList.DataBind();
            }
        }
        protected void Broadcast_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string strLoginID = "";

                if (chkBroadcastRO.Checked)
                {
                    strLoginID += "ALLRO,";
                }
                if (chkBroadcastAFC.Checked)
                {
                    strLoginID += "ALLAFC,";
                }
                if (chkInsertAddress.Checked)
                {
                    chkBroadcastRO.Checked = false;
                    chkBroadcastAFC.Checked = false;
                    strLoginID = "";
                    tblMessage.Visible = false;
                    tblInsertAddress.Visible = true;
                }
                else
                {
                    tblMessage.Visible = true;
                    tblInsertAddress.Visible = false;
                }

                txtTo.Text = strLoginID;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void SendMessage_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (chkMessage.Checked)
                {
                    trMessage1.Visible = true;
                    //trMessage2.Visible = false;
                    trMessage3.Visible = true;
                }
                else
                {
                    trMessage1.Visible = false;
                    //trMessage2.Visible = false;
                    trMessage3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void SendSMS_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (chkSMS.Checked)
                {
                    trSMS.Visible = true;
                }
                else
                {
                    trSMS.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnInsertAddresses_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 Count = gvList.Rows.Count;
                string strLoginID = "";

                for (int m = 0; m < Count; m++)
                {
                    if (((CheckBox)gvList.Rows[m].Cells[0].FindControl("chkSelect")).Checked == true)
                    {
                        strLoginID += gvList.Rows[m].Cells[1].Text + ",";
                        ((CheckBox)gvList.Rows[m].Cells[0].FindControl("chkSelect")).Checked = false;
                    }
                }
                txtTo.Text = strLoginID;

                ((CheckBox)gvList.HeaderRow.Cells[0].FindControl("chkAll")).Checked = false;
                tblMessage.Visible = true;
                tblInsertAddress.Visible = false;

                if (chkMessage.Checked)
                {
                    trMessage1.Visible = true;
                    // trMessage2.Visible = false;
                    trMessage3.Visible = true;
                }
                else
                {
                    trMessage1.Visible = false;
                    //  trMessage2.Visible = false;
                    trMessage3.Visible = false;
                }

                if (chkSMS.Checked)
                {
                    trSMS.Visible = true;
                }
                else
                {
                    trSMS.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                string LoginID = Session["UserLoginID"].ToString();
                if (txtTo.Text.TrimEnd().TrimStart() != "")
                {
                    if (chkMessage.Checked)
                    {
                        Random random = new Random();
                        string filePath1 = "";
                        string filePath2 = "";

                        if (fileInput1.PostedFile.FileName.Length > 0)
                        {
                            if (fileInput1.PostedFile.ContentLength > 1024)
                            {
                                if (System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".PDF" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".ZIP" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".RAR" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".XLS" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".XLSX")
                                {
                                    filePath1 = saveFile(LoginID + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput1.PostedFile.FileName), 1);
                                }
                                else
                                {
                                    shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                                    return;
                                }
                            }
                            else
                            {
                                shInfo.SetMessage("File size exceeds maximum limit of 1 MB. Please upload Attachement less than 1 MB.", ShowMessageType.UserError);
                                return;
                            }
                        }
                        //string base64 = Request.Form["imgCropped"];
                        //if (base64.Length > 6)
                        //{
                        //    string fileName = LoginID + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString();
                        //    filePath1 = UploadDoc(base64, fileName);
                        //}
                        if (fileInput2.PostedFile.FileName.Length > 0)
                        {
                            if (fileInput2.PostedFile.ContentLength > 1024)
                            {
                                if (System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".PDF")
                                {
                                    filePath2 = saveFile(LoginID + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput2.PostedFile.FileName), 2);
                                }
                                else
                                {
                                    shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                                    return;
                                }
                            }
                            else
                            {
                                shInfo.SetMessage("File size exceeds maximum limit of 1 MB. Please upload Attachement less than 1 MB.", ShowMessageType.UserError);
                                return;
                            }
                        }
                        string strTo = txtTo.Text;
                        string From = "ADMINAFC";
                        string Message = txtMsg.Text.Replace(Environment.NewLine,"<br/>");
                        Int32 Count = (strTo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).Length;

                            for (Int32 i = 0; i < Count; i++)
                            {
                                string To = strTo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[i];
                                reg.adminComposeMessage(To, From, Message, filePath1, filePath2, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                            }
                    }
                    if (chkSMS.Checked)
                    {
                        string strTo = txtTo.Text;
                        string From = "ADMINAFC";
                        string Message = txtSMSContent.Text;
                        Int32 Count = (strTo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).Length;

                        Msg91 msg91 = new Msg91();
                        List<Sm> Sms = new List<Sm>();
                         
                        for (int i = 0; i < Count; i++)
                            {
                                string To = strTo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[i];
                                DataSet ds = reg.adminComposeSMS(To, From, Message, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    Sm sm = new Sm();
                                    SMSTemplate sMSTemplate = new SMSTemplate();
                                    sMSTemplate.ProjectName = Pharmacy2024.Global.ProjectNameSMS;

                                    if (dr["MobileNo"] != null)
                                    {
                                        List<string> mobileno = new List<string>();
                                        mobileno.Add(dr["MobileNo"].ToString());
                                        sm.To = mobileno;
                                    }
                                    sm.Message = Message + " " + sMSTemplate.ProjectName;
                                    if (dr["LoginID"] != null)
                                        sm.PersonalID = dr["LoginID"].ToString();
                                    Sms.Add(sm);
                                }
                            }
                        
                        if (Sms.Count > 0)
                        {
                            msg91.Sms = Sms;
                            SMS sMS = new SMS();
                            Task<string> response = sMS.SendBulkSMS(msg91, "Custom Message");
                        }
                        else
                        {
                            shInfo.SetMessage("You are trying to send SMS are failed Contact to Admin!", ShowMessageType.Information);
                        }
                    }

                    txtMsg.Text = "";
                    txtSMSContent.Text = "";

                    shInfo.SetMessage("Message has been Sent successfully to " + txtTo.Text + ".", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Please Enter To. ", ShowMessageType.Information);
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
        //}
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet ds = (DataSet)ViewState["ds"];
                DataRow[] result = ds.Tables[0].Select("LoginID LIKE '%" + txtSearch.Text + "%' or Name LIKE '%" + txtSearch.Text + "%'");
                DataTable dt = new DataTable();
                dt.Columns.Add("LoginID");
                dt.Columns.Add("Name");

                foreach (DataRow row in result)
                {
                    DataRow dr = dt.NewRow();
                    dr["LoginID"] = row["LoginID"].ToString();
                    dr["Name"] = row["Name"].ToString();
                    dt.Rows.Add(dr);
                }

                gvList.DataSource = dt;
                gvList.DataBind();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
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