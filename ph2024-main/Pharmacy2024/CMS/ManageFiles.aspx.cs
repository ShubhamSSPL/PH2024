using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Synthesys.Controls;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Text;
using System.Web.Profile;
using Synthesys.CMS.BusinessLayer;

public partial class ManageFiles : System.Web.UI.Page
{
    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    protected HttpApplication ApplicationInstance
    {
        get
        {
            return this.Context.ApplicationInstance;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["UserTypeId"] == null)
        {
            this.Response.Write("<script language=\"javascript\" type=\"text/javascript\">parent.window.location.href = '" + ConfigurationManager.AppSettings["WebSite_HomePage"] + "';</script>");
            this.Response.End();
        }
        if (this.IsPostBack)
            return;
        try
        {
            this.DisplayFiles();
        }
        catch (Exception ex)
        {
            showMsg.SetMessage(ex.Message, ShowMessageType.Information);
        }
    }

    private void DisplayFiles()
    {
        DataTable dataTable = new DataTable();
        BusinessServiceImp obj = new BusinessServiceImp();
        DataTable table = obj.GetAllFiles().Tables[0];
        bool flag = table.Rows.Count > 0;
        this.trDelete.Visible = flag;
        this.gvFiles.Visible = flag;

        if (flag)
        {
            this.gvFiles.DataSource = (object)table;
            this.gvFiles.DataBind();
            for (int index = 0; index < this.gvFiles.Rows.Count; ++index)
                ((Label)this.gvFiles.Rows[index].Cells[3].Controls[1]).Text = ConfigurationManager.AppSettings["HttpAddress"] + "SynthesysModules_Files/Files/" + this.gvFiles.Rows[index].Cells[4].Text + "." + this.gvFiles.Rows[index].Cells[1].Text.Split(new string[1]
                {
          "."
                }, StringSplitOptions.None)[1];
        }
        table.Dispose();
    }

    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.fileUpload.PostedFile == null)
                return;
            if (this.fileUpload != null)
            {
                Stream objFileStream = fileUpload.PostedFile.InputStream;
                FileInfo objFile = new FileInfo(fileUpload.PostedFile.FileName);
                string flExtension = objFile.Extension.ToLower();
                string flName = Path.GetFileNameWithoutExtension(objFile.Name).ToLower();
                string CreatedBy = Session["UserLoginID"].ToString();

                DBConnection db = new DBConnection();
                DataSet ds = db.ExecuteDataSet("Content_Mgt_SaveFile", new SqlParameter[]{
                new SqlParameter ("@FileName",flName),
                new SqlParameter ("@Extension",flExtension),
                new SqlParameter ("@LoginId",CreatedBy)
        });
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["FileId"].ToString() != "")
                    {
                        string sysfilename = ds.Tables[0].Rows[0]["FileId"].ToString() + flExtension;
                        AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                        string fileurl = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename, objFileStream, fileUpload.PostedFile.ContentType, "dtefiles/files".ToLower());
                        if (fileurl != "")
                            this.showMsg.SetMessage("The File has been uploaded.", ShowMessageType.Information);
                        else
                            this.showMsg.SetMessage("The File Details Not Saved, Try Again.", ShowMessageType.Information);

                    }
                }
            }
            this.DisplayFiles();
        }
        catch (Exception ex)
        {
            showMsg.SetMessage(ex.Message, ShowMessageType.Information);
        }
        //try
        //{
        //    this.SaveFile();
        //    this.DisplayFiles();
        //}
        //catch (Exception ex)
        //{
        //    showMsg.SetMessage(ex.Message, ShowMessageType.Information);
        //}
    }

    private void SaveFile()
    {
        //if (this.fileUpload.PostedFile == null)
        //    return;
        //int contentLength = this.fileUpload.PostedFile.ContentLength;
        //string str = ConfigurationManager.AppSettings["FtpAddress"] + "SynthesysModules_Files/Files";
        //string withoutExtension = Path.GetFileNameWithoutExtension(this.fileUpload.PostedFile.FileName);
        //string extension = Path.GetExtension(this.fileUpload.PostedFile.FileName);
        //DataTable dataTable = new DataTable();
        //BusinessServiceImp obj = new BusinessServiceImp();
        //DataTable table = obj.SaveFile(withoutExtension, extension, this.Session["UserLoginId"].ToString()).Tables[0];
        //Stream ftpRequestToWrite = this.GetFtpRequestToWrite(str + "/" + Convert.ToString(table.Rows[0]["FileId"]) + extension);
        //byte[] buffer = new byte[contentLength];
        //this.fileUpload.PostedFile.InputStream.Read(buffer, 0, contentLength);
        //ftpRequestToWrite.Write(buffer, 0, contentLength);
        //table.Dispose();
        //ftpRequestToWrite.Close();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            this.DeleteFile();
            this.DisplayFiles();
        }
        catch (Exception ex)
        {
            showMsg.SetMessage(ex.Message, ShowMessageType.Information);
        }
    }

    private void DeleteFile()
    {
        if (!(this.hdnFileID.Value != ""))
            return;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("<Ids>");
        string str1 = this.hdnFileID.Value;
        string[] separator = new string[1] { "," };
        foreach (string str2 in str1.Split(separator, StringSplitOptions.None))
        stringBuilder.Append("<Id No=\"" + str2 + "\" />");
        stringBuilder.Append("</Ids>");
        DataTable dataTable = new DataTable();
        BusinessServiceImp obj = new BusinessServiceImp();
        DataTable table = obj.DeleteFile(stringBuilder.ToString()).Tables[0];
        if (Convert.ToString(table.Rows[0]["Status"]) == "Y")
        {
            this.showMsg.SetMessage("File Deleted Successfully.", ShowMessageType.Information);
            this.hdnFileID.Value = "";
        }
        table.Dispose();
    }

    private Stream GetFtpRequestToWrite(string filePath)
    {
        FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(filePath);
        ftpWebRequest.Credentials = (ICredentials)new NetworkCredential(ConfigurationManager.AppSettings["FtpUserName"], ConfigurationManager.AppSettings["FtpUserPassword"]);
        ftpWebRequest.Method = "STOR";
        ftpWebRequest.UseBinary = true;
        return ftpWebRequest.GetRequestStream();
    }
}
