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
public partial class ContentManagement_ManageImg : System.Web.UI.Page
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
        DataTable dt = new DataTable();
        BusinessServiceImp obj = new BusinessServiceImp();
        dt = obj.GetAllImages().Tables[0];

        bool flag = (dt.Rows.Count > 0 ? true : false);
        tblPhotoes.Visible = flag;

        if (flag)
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 9;

            pds.CurrentPageIndex = Convert.ToInt32(hdnCurrentPageIndex.Value);
            repeaterPhotoes.DataSource = pds;
            repeaterPhotoes.DataBind();

            prevImgBtn.Visible = !pds.IsFirstPage;
            nxtImgBtn.Visible = !pds.IsLastPage;

            hdnCurrentPageIndex.Value = (pds.IsLastPage ? (pds.PageCount - 1).ToString() : pds.CurrentPageIndex.ToString());
        }

        dt.Dispose();
    }
    private bool CheckFoldersStructure()
    {
        if (baseExists(ConfigurationManager.AppSettings["FtpAddress"] + @"SynthesysModules_Files"))
        {
            if (baseExists(ConfigurationManager.AppSettings["FtpAddress"] + @"SynthesysModules_Files/Images"))
            {
                return true;
            }
            else
            {
                if (CreateFolder(ConfigurationManager.AppSettings["FtpAddress"] + @"SynthesysModules_Files/Images"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            if (CreateFolder(ConfigurationManager.AppSettings["FtpAddress"] + @"SynthesysModules_Files"))
            {
                if (CreateFolder(ConfigurationManager.AppSettings["FtpAddress"] + @"SynthesysModules_Files/Images"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }

    private bool baseExists(string _path)
    {
        bool directoryExists = false;
        //string _path = ConfigurationManager.AppSettings["FtpAddress"] + @"SynthesysModules_Files";

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_path);
        request.UseBinary = true;
        request.KeepAlive = true;
        request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FtpUserName"], ConfigurationManager.AppSettings["FtpUserPassword"]); ;
        request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;
        try
        {
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                directoryExists = true;
            }
        }
        catch (WebException)
        {
            directoryExists = false;
        }
        return directoryExists;


    }
    private bool CreateFolder(string _path)
    {

        try
        {
            //create the directory
            //string _path = ConfigurationManager.AppSettings["FtpAddress"] + @"SynthesysModules_Files";
            WebRequest request = WebRequest.Create(_path);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FtpUserName"], ConfigurationManager.AppSettings["FtpUserPassword"]);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream ftpStream = response.GetResponseStream();

            ftpStream.Close();
            response.Close();

            return true;
        }
        catch (WebException ex)
        {
            FtpWebResponse response = (FtpWebResponse)ex.Response;
            response.Close();
            return false;
        }

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
        if (imgUpload.PostedFile != null)
        {
            int size = imgUpload.PostedFile.ContentLength;
            //if (size < 2097152)
            //{
            if (CheckFoldersStructure())
            {
                string _path = ConfigurationManager.AppSettings["FtpAddress"] + @"SynthesysModules_Files/Images";
                string fileName = Path.GetFileNameWithoutExtension(imgUpload.PostedFile.FileName);
                string extension = Path.GetExtension(imgUpload.PostedFile.FileName);
                DataTable dt = new DataTable();
                BusinessServiceImp obj = new BusinessServiceImp();
                dt = obj.SaveImage(fileName, extension, Session["UserLoginId"].ToString()).Tables[0];
                //

                Stream str = GetFtpRequestToWrite(_path + "/" + Convert.ToString(dt.Rows[0]["ImageId"]) + extension);
                byte[] img = new byte[size];
                imgUpload.PostedFile.InputStream.Read(img, 0, size);

                str.Write(img, 0, size);
                dt.Dispose();
                str.Close();
            }
            //}
            //else
            //    showMsg.SetMessage("File size is more than 2MB, cannot be uploaded.", ShowMessageType.UserError);
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
        if (hdnImageID.Value != "")
        {
            //
            StringBuilder sb = new StringBuilder();
            sb.Append("<Ids>");
            string[] ids = hdnImageID.Value.Split(new string[] { "," }, StringSplitOptions.None);
            for (int i = 0; i < ids.Length; i++)
                sb.Append("<Id No=\"" + ids[i] + "\" />");
            sb.Append("</Ids>");
            //

            DataTable dt = new DataTable();
            BusinessServiceImp obj = new BusinessServiceImp();
            dt = obj.DeleteImage(sb.ToString()).Tables[0];
            if (Convert.ToString(dt.Rows[0]["Status"]) == "Y")
            {
                showMsg.SetMessage("Image(s) Deleted Successfully.", ShowMessageType.Information);
                chkSelectAll.Checked = false;
                hdnImageID.Value = "";
            }
            dt.Dispose();
        }
    }

    protected void prevImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        chkSelectAll.Checked = false;
        hdnCurrentPageIndex.Value = Convert.ToString(Convert.ToInt32(hdnCurrentPageIndex.Value) - 1);
        try
        {
            DiplayImages();
        }
        catch (Exception ex)
        { showMsg.SetMessage(ex); }
    }

    protected void nxtImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        chkSelectAll.Checked = false;
        hdnCurrentPageIndex.Value = Convert.ToString(Convert.ToInt32(hdnCurrentPageIndex.Value) + 1);
        try
        {
            DiplayImages();
        }
        catch (Exception ex)
        { showMsg.SetMessage(ex); }
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
