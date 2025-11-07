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

namespace Pharmacy2024.InstituteModule
{
    public partial class frmMessagesComposeRO : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                try
                {
                    Page.Form.Attributes.Add("enctype", "multipart/form-data");

                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();

                    gvList.DataSource = reg.getInstituteList(UserTypeID, UserLoginID);
                    gvList.DataBind();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void Broadcast_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string strLoginID = "";

                if (rbnAdmin.Checked)
                {
                    strLoginID = "ADMININSTITUTE";
                    tblMessage.Visible = true;
                    tblInsertAddress.Visible = false;
                }
                else if (rbnInstitute.Checked)
                {
                    strLoginID = "";
                    tblMessage.Visible = false;
                    tblInsertAddress.Visible = true;
                }
                else
                {
                    strLoginID = "";
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
                Random random = new Random();
                string filePath1 = "";
                string filePath2 = "";

                if (fileInput1.PostedFile.FileName.Length > 0)
                {
                    if (System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".PDF" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".ZIP" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".RAR" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".XLS" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".XLSX")
                    {

                        filePath1 = SaveFile(LoginID + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput1.PostedFile.FileName), 1);
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
                //        filePath2 = LoginID + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput2.PostedFile.FileName);
                //        SaveFile(filePath2, 2);
                //    }
                //    else
                //    {
                //        shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                //        return;
                //    }
                //}

                if (rbnInstitute.Checked)
                {
                    string strTo = txtTo.Text;
                    string From = "ADMININSTITUTE";
                    string Message = txtMsg.Text;
                    Int32 Count = (strTo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).Length;

                    for (Int32 i = 0; i < Count; i++)
                    {
                        string To = strTo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[i];
                        reg.roComposeMessage(To, From, Message, filePath1, filePath2, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                    }

                    txtMsg.Text = "";

                    shInfo.SetMessage("Message has been Sent successfully to " + txtTo.Text + ".", ShowMessageType.Information);
                }
                else if (rbnAdmin.Checked)
                {
                    string To = "ADMININSTITUTE";
                    string From = LoginID;
                    string Subject = "";
                    string Message = txtMsg.Text;

                    if (reg.instituteComposeMessage(To, From, Subject, Message, filePath1, filePath2, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        txtMsg.Text = "";
                        shInfo.SetMessage("Message has been sent successfully to ADMIN.", ShowMessageType.Information);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in sending Message. Please try after some time.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private string SaveFile(string filePath, Int32 FileNo)
        {
            string HttpFilePath = "";
            if (FileNo == 1)
            {
                if (fileInput1.PostedFile != null)
                {
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    Stream objFileStream = fileInput1.PostedFile.InputStream;
                    FileInfo objFile = new FileInfo(fileInput1.PostedFile.FileName);
                    string sysfilename = filePath.ToLower();//+ "_" + DateTime.Now.Ticks.ToString()
                    HttpFilePath = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["Project_Name"].ToLower(), sysfilename, objFileStream, fileInput1.PostedFile.ContentType, "attachment".ToLower());
                }
            }
            //else if (FileNo == 2)
            //{
            //    if (fileInput2.PostedFile != null)
            //    {
            //        Int32 size = fileInput2.PostedFile.ContentLength;
            //        Stream str = GetFtpRequestToWrite(FtpAddress + "Attachment/" + filePath, FtpUserName, FtpUserPassword);
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