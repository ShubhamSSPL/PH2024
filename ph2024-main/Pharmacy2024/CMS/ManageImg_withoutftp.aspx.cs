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
public partial class ContentManagement_ManageImg_withoutftp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Session["UserTypeId"] == null)
        {
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">parent.window.location.href = '" + ConfigurationManager.AppSettings["WebSite_HomePage"] + "';</script>");
            Response.End();
        }
        if (!IsPostBack)
        {
            hdnCurrentPageIndex.Value = "0";
            try
            {
                DiplayImages();
            }
            catch (Exception ex)
            { showMsg.SetMessage(ex); }
        }
    }

    private void DiplayImages()
    {
        DataTable table = new DataTable();
        BusinessServiceImp obj = new BusinessServiceImp();
        table = obj.GetAllImages().Tables[0];
        bool flag = table.Rows.Count > 0;
        this.tblPhotoes.Visible = flag;
        if (flag)
        {
            PagedDataSource source = new PagedDataSource();
            source.DataSource = table.DefaultView;
            source.AllowPaging = true;
            source.PageSize = 9;
            source.CurrentPageIndex = Convert.ToInt32(this.hdnCurrentPageIndex.Value);
            this.repeaterPhotoes.DataSource = source;
            this.repeaterPhotoes.DataBind();
            this.prevImgBtn.Visible = !source.IsFirstPage;
            this.nxtImgBtn.Visible = !source.IsLastPage;
            this.hdnCurrentPageIndex.Value = source.IsLastPage ? ((source.PageCount - 1)).ToString() : source.CurrentPageIndex.ToString();
        }
        table.Dispose();
    }

    protected void btnSaveImage_Click(object sender, System.EventArgs e)
    {
        try
        {
            SaveImg();
            DiplayImages();
        }
        catch (Exception ex)
        { showMsg.SetMessage(ex); }
    }
    private void SaveImg()
    {
        if (this.imgUpload.PostedFile != null)
        {
            int contentLength = this.imgUpload.PostedFile.ContentLength;
            string path = AppDomain.CurrentDomain.BaseDirectory + "/SynthesysModules_Files/Images";
            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                info.Create();
            }
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(this.imgUpload.PostedFile.FileName);
            string extension = Path.GetExtension(this.imgUpload.PostedFile.FileName);
            DataTable table = new DataTable();
            BusinessServiceImp obj = new BusinessServiceImp();
            table = obj.SaveImage(fileNameWithoutExtension, extension, this.Session["UserLoginId"].ToString()).Tables[0];
            byte[] buffer = new byte[contentLength];
            this.imgUpload.PostedFile.InputStream.Read(buffer, 0, contentLength);
            FileStream stream = new FileStream(path + "/" + Convert.ToString(table.Rows[0]["ImageId"]) + extension, FileMode.Create);
            stream.Write(buffer, 0, contentLength);
            table.Dispose();
            stream.Close();
            stream.Dispose();
        }
    }

    protected void btnDelete_Click(object sender, System.EventArgs e)
    {
        try
        {
            DeleteImg();
            DiplayImages();
        }
        catch (Exception ex)
        { showMsg.SetMessage(ex); }
    }
    private void DeleteImg()
    {
        if (this.hdnImageID.Value != "")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Ids>");
            string[] strArray = this.hdnImageID.Value.Split(new string[] { "," }, StringSplitOptions.None);
            for (int i = 0; i < strArray.Length; i++)
            {
                builder.Append("<Id No=\"" + strArray[i] + "\" />");
            }
            builder.Append("</Ids>");
            DataTable table = new DataTable();
            BusinessServiceImp obj = new BusinessServiceImp();
            table = obj.DeleteImage(builder.ToString()).Tables[0];
            if (Convert.ToString(table.Rows[0]["Status"]) == "Y")
            {
                this.showMsg.SetMessage("Image(s) Deleted Successfully.", ShowMessageType.Information);
                this.chkSelectAll.Checked = false;
                this.hdnImageID.Value = "";
            }
            table.Dispose();
        }
    }

    protected void prevImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        this.chkSelectAll.Checked = false;
        this.hdnCurrentPageIndex.Value = Convert.ToString((int)(Convert.ToInt32(this.hdnCurrentPageIndex.Value) - 1));
        try
        {
            this.DiplayImages();
        }
        catch (Exception exception)
        {
            this.showMsg.SetMessage(exception);
        }
    }


    protected void nxtImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        this.chkSelectAll.Checked = false;
        this.hdnCurrentPageIndex.Value = Convert.ToString((int)(Convert.ToInt32(this.hdnCurrentPageIndex.Value) + 1));
        try
        {
            this.DiplayImages();
        }
        catch (Exception exception)
        {
            this.showMsg.SetMessage(exception);
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
