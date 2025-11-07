using Synthesys.CMS.BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContentManagement_ManageFilesoutside_withoutftp : System.Web.UI.Page
{
    protected ShowMessage showMsg;
    protected override void OnPreInit(EventArgs e)
    {
        base.OnInit(e);
        if (Request.Cookies["Theme"] == null)
            Page.Theme = "default";
        else
            Page.Theme = Request.Cookies["Theme"].Value;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLoginId"] == null)
            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        // set expander menu properties
        ((HiddenField)Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "4";
        showMsg = (ShowMessage)Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);


        if (!IsPostBack)
        {
            try
            {
                DisplayFiles();
            }
            catch (Exception ex)
            { showMsg.SetMessage(ex); }
        }
    }

    private void DisplayFiles()
    {
        DataTable table = new DataTable();
        BusinessServiceImp obj = new BusinessServiceImp();
        table = obj.GetAllFiles().Tables[0];
        bool flag = table.Rows.Count > 0;
        this.trDelete.Visible = flag;
        this.gvFiles.Visible = flag;
        if (flag)
        {
            this.gvFiles.DataSource = table;
            this.gvFiles.DataBind();
            for (int i = 0; i < this.gvFiles.Rows.Count; i++)
            {
                ((Label)this.gvFiles.Rows[i].Cells[3].Controls[1]).Text = "../SynthesysModules_Files/Files/" + this.gvFiles.Rows[i].Cells[4].Text + "." + this.gvFiles.Rows[i].Cells[1].Text.Split(new string[] { "." }, StringSplitOptions.None)[1];
            }
        }
        table.Dispose();
    }

    protected void btnSaveFile_Click(object sender, System.EventArgs e)
    {
        try
        {
            SaveFile();
            DisplayFiles();
        }
        catch (Exception ex)
        { showMsg.SetMessage(ex); }
    }
    private void SaveFile()
    {
        if (this.fileUpload.PostedFile != null)
        {
            int contentLength = this.fileUpload.PostedFile.ContentLength;
            string path = AppDomain.CurrentDomain.BaseDirectory + "/SynthesysModules_Files/Files";
            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                info.Create();
            }
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(this.fileUpload.PostedFile.FileName);
            string extension = Path.GetExtension(this.fileUpload.PostedFile.FileName);
            DataTable table = new DataTable();
            BusinessServiceImp obj = new BusinessServiceImp();
            table = obj.SaveFile(fileNameWithoutExtension, extension, this.Session["UserLoginId"].ToString()).Tables[0];
            byte[] buffer = new byte[contentLength];
            this.fileUpload.PostedFile.InputStream.Read(buffer, 0, contentLength);
            FileStream stream = new FileStream(path + "/" + Convert.ToString(table.Rows[0]["FileId"]) + extension, FileMode.Create);
            stream.Write(buffer, 0, contentLength);
            table.Dispose();
            stream.Close();
        }
    }

    protected void btnDelete_Click(object sender, System.EventArgs e)
    {
        try
        {
            DeleteFile();
            DisplayFiles();
        }
        catch (Exception ex)
        { showMsg.SetMessage(ex); }
    }
    private void DeleteFile()
    {
        if (this.hdnFileID.Value != "")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Ids>");
            string[] strArray = this.hdnFileID.Value.Split(new string[] { "," }, StringSplitOptions.None);
            for (int i = 0; i < strArray.Length; i++)
            {
                builder.Append("<Id No=\"" + strArray[i] + "\" />");
            }
            builder.Append("</Ids>");
            DataTable table = new DataTable();
            BusinessServiceImp obj = new BusinessServiceImp();
            table = obj.DeleteFile(builder.ToString()).Tables[0];
            if (Convert.ToString(table.Rows[0]["Status"]) == "Y")
            {
                this.showMsg.SetMessage("File(s) Deleted Successfully.", ShowMessageType.Information);
                this.hdnFileID.Value = "";
            }
            table.Dispose();
        }
    }

    private Stream GetFtpRequestToWrite(string filePath)
    {
        FtpWebRequest RequestTowrite = (FtpWebRequest)WebRequest.Create(filePath);
        RequestTowrite.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FtpUserName"], ConfigurationManager.AppSettings["FtpUserPassword"]);
        RequestTowrite.Method = WebRequestMethods.Ftp.UploadFile;
        RequestTowrite.UseBinary = true;
        return (RequestTowrite.GetRequestStream());
    }
}
