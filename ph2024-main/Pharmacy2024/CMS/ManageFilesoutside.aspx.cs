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

public partial class ContentManagement_ManageFilesoutside : System.Web.UI.Page
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
        DataTable dt = new DataTable();
        BusinessServiceImp obj = new BusinessServiceImp();
        dt = obj.GetAllFiles().Tables[0];

        bool flag = (dt.Rows.Count > 0 ? true : false);
        trDelete.Visible = flag;
        gvFiles.Visible = flag;

        if (flag)
        {
            gvFiles.DataSource = dt;
            gvFiles.DataBind();
            for (int i = 0; i < gvFiles.Rows.Count; i++)
                ((Label)gvFiles.Rows[i].Cells[3].Controls[1]).Text = ConfigurationManager.AppSettings["HttpAddress"].ToLower() + @"SynthesysModules_Files/Files/" + gvFiles.Rows[i].Cells[4].Text + "." +
                    gvFiles.Rows[i].Cells[1].Text.Split(new string[] { "." }, StringSplitOptions.None)[1];
        }
        dt.Dispose();
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
        if (fileUpload.PostedFile != null)
        {
            int size = fileUpload.PostedFile.ContentLength;
            //if (size < 2097152)
            //{

            string _path = ConfigurationManager.AppSettings["FtpAddress"] + @"SynthesysModules_Files/Files";
            string fileName = Path.GetFileNameWithoutExtension(fileUpload.PostedFile.FileName);
            string extension = Path.GetExtension(fileUpload.PostedFile.FileName);
            DataTable dt = new DataTable();
            BusinessServiceImp obj = new BusinessServiceImp();
            dt = obj.SaveFile(fileName, extension, Session["UserLoginId"].ToString()).Tables[0];
            //

            Stream str = GetFtpRequestToWrite(_path + "/" + Convert.ToString(dt.Rows[0]["FileId"]) + extension);
            byte[] file = new byte[size];
            fileUpload.PostedFile.InputStream.Read(file, 0, size);
            str.Write(file, 0, size);

            dt.Dispose();
            str.Close();
            //    fs.Dispose();
            //}
            //else
            //    showMsg.SetMessage("File size is more than 2MB, cannot be uploaded.", ShowMessageType.UserError);
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
        if (hdnFileID.Value != "")
        {
            //
            StringBuilder sb = new StringBuilder();
            sb.Append("<Ids>");
            string[] ids = hdnFileID.Value.Split(new string[] { "," }, StringSplitOptions.None);
            for (int i = 0; i < ids.Length; i++)
                sb.Append("<Id No=\"" + ids[i] + "\" />");
            sb.Append("</Ids>");
            //

            DataTable dt = new DataTable();
            BusinessServiceImp obj = new BusinessServiceImp();
            dt = obj.DeleteFile(sb.ToString()).Tables[0];
            if (Convert.ToString(dt.Rows[0]["Status"]) == "Y")
            {
                showMsg.SetMessage("File(s) Deleted Successfully.", ShowMessageType.Information);
                hdnFileID.Value = "";
            }
            dt.Dispose();
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
