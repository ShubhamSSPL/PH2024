using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class CMS_UploadImages : System.Web.UI.Page
{
    ShowMessage showMsg = null;
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
            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        showMsg = (ShowMessage)Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        // set expander menu properties
        ((HiddenField)Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "4";
        //
    }
    protected void btnSaveImage_Click(object sender, EventArgs e)
    {
        SaveImg();
    }
    private void SaveImg()
    {
        if (imgLogo.PostedFile != null && imgLogo.PostedFile.ContentLength > 0)
        {
            int sizeLogo = imgLogo.PostedFile.ContentLength;
            if (sizeLogo > 5120)
                showMsg.SetMessage("Logo image size is more than 5KB, cannot be uploaded.", ShowMessageType.UserError);
            else
            {
                string _path = ConfigurationManager.AppSettings["FtpAddress"] + @"SynthesysModules_Files/Images";
                string fileName = Path.GetFileNameWithoutExtension(imgLogo.PostedFile.FileName);
                string extension = Path.GetExtension(imgLogo.PostedFile.FileName);

                Stream str = GetFtpRequestToWrite(_path + "/Website_Logo.gif");
                byte[] img = new byte[sizeLogo];
                imgLogo.PostedFile.InputStream.Read(img, 0, sizeLogo);

                str.Write(img, 0, sizeLogo);
                str.Close();

                showMsg.SetMessage("Site Logo uploaded successfully !!", ShowMessageType.Information);
            }
        }
        /*if (imgHeader.PostedFile != null && imgHeader.PostedFile.ContentLength>0)
        {
            int sizeHeader = imgHeader.PostedFile.ContentLength;
            if (sizeHeader > 61440)
                showMsg.SetMessage("Center image size is more than 60KB, cannot be uploaded.", ShowMessageType.UserError);
            else
            {
                string _path = AppDomain.CurrentDomain.BaseDirectory + "/SynthesysModules_Files/Images";
                DirectoryInfo dirInfo = new DirectoryInfo(_path);
                if (!dirInfo.Exists)
                    dirInfo.Create();
                
                string fileName = Path.GetFileNameWithoutExtension(imgHeader.PostedFile.FileName);
                string extension = Path.GetExtension(imgHeader.PostedFile.FileName);
                byte[] img1 = new byte[sizeHeader];
                imgHeader.PostedFile.InputStream.Read(img1, 0, sizeHeader);
                FileStream fs = null;
                fs = new FileStream(_path + "/Website_CenterImage.jpeg", FileMode.Create);
                fs.Write(img1, 0, sizeHeader);
                fs.Close();
                fs.Dispose();
                fs = null;
                showMsg.SetMessage("Center image uploaded successfully !!", ShowMessageType.Information);
            }
        }*/
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
