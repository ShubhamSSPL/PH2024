using BusinessLayer;
using EntityModel;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmEditScannedImages : System.Web.UI.Page
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) == 91 || Convert.ToInt32(Session["UserTypeID"].ToString()) == 43)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if ((DateTime.Now < Global.EdittingOfApplicationFormStartDateTime || DateTime.Now > Global.EdittingOfApplicationFormEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    AzureDocumentUpload azObj = new AzureDocumentUpload();
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }

                    DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplay(PID);

                    if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                    {
                        lblApplicationID.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["ApplicationID"].ToString();
                        lblCandidateName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CandidateName"].ToString();
                    }

                    //Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);

                    //if (CETApplicationFormNo > 0)
                    //{
                    //    cbUploadedScannedImages.Visible = true;
                    //    cbUploadScannedImages.Visible = false;
                    //    divInstructionsForChange.Visible = false;

                    //    btnPhotograph.ImageUrl = UserInfo.GetImageURL(PID, "Photograph");
                    //    //btnSignature.ImageUrl = UserInfo.GetImageURL(PID, "Signature");

                    //    btnPhotograph.Enabled = false;
                    //    //btnSignature.Enabled = false;
                    //}
                    //else
                    {
                        cbUploadedScannedImages.Visible = true;
                        cbUploadScannedImages.Visible = false;

                        imgPhotograph.Visible = true;
                        imgSignature.Visible = true;

                        imgPhotograph.ImageUrl = btnPhotograph.ImageUrl= azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(PID, "Photograph"));
                        imgSignature.ImageUrl =btnSignature.ImageUrl= azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(PID, "Signature"));
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void Upload(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                AzureDocumentUpload azObj = new AzureDocumentUpload();
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                string strError = getErrorMessage();

                if (strError.Length > 0)
                {
                    shInfo.SetMessage(strError, ShowMessageType.Information);
                }
                else
                {

                    if (Request.Form["imgCropped"] != "")
                    {
                        string base64 = Request.Form["imgCropped"];
                        byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);

                        imgPhotograph.ImageUrl = saveCroppedFile(PID, "Photograph", bytes);
                        imgPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(PID, "Photograph"));
                        cbProceed.Visible = true;
                        divCropping.Style.Add("display", "none");
                    }
                    if (Request.Form["imgSignCropped"] != "")
                    {
                        string base64Sign = Request.Form["imgSignCropped"];
                        byte[] bytesSign = Convert.FromBase64String(base64Sign.Split(',')[1]);

                        imgSignature.ImageUrl = saveCroppedFile(PID, "Signature", bytesSign);
                        imgSignature.ImageUrl = azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(PID, "Signature"));
                        cbProceed.Visible = true;

                    }



                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private string saveCroppedFile(Int64 PID, string ImageType, byte[] bytes)
        {
            string fileurl = "";
            if (ImageType == "Photograph")
            {
                if (bytes != null && bytes.Length > 0)
                {
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    string sysfilename = PID.ToString() + ".jpg";//+ "_" + DateTime.Now.Ticks.ToString()
                    fileurl = azureDocumentUpload.UploadDocumentFromByteArray(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename, bytes, "Photograph".ToLower());
                }
            }
            if (ImageType == "Signature")
            {
                if (bytes != null && bytes.Length > 0)
                {
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    string sysfilename = PID.ToString() + ".jpg";//+ "_" + DateTime.Now.Ticks.ToString()
                    fileurl = azureDocumentUpload.UploadDocumentFromByteArray(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename, bytes, "Signature".ToLower());
                }
            }
            ////else if (ImageType == "Signature")
            ////{
            ////    if (fileSignature.PostedFile != null)
            ////    {
            ////        AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
            ////        Stream objFileStream = fileSignature.PostedFile.InputStream;
            ////        FileInfo objFile = new FileInfo(fileSignature.PostedFile.FileName);
            ////        string sysfilename = PID.ToString() + ".jpg";// + "_" + DateTime.Now.Ticks.ToString()
            ////        fileurl = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename, objFileStream, "Signature");
            ////        //Int32 size = fileSignature.PostedFile.ContentLength;
            ////        //Stream str = getFtpRequestToWrite(FtpAddress + "ScannedImages/Signature/" + PID.ToString() + ".jpg", FtpUserName, FtpUserPassword);
            ////        //byte[] file = new byte[size];
            ////        //fileSignature.PostedFile.InputStream.Read(file, 0, size);
            ////        //str.Write(file, 0, size);
            ////        //str.Close();

            ////    }
            ////}
            return fileurl;
        }
        protected string getErrorMessage()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string strError = "";

                //if (filePhotograph.HasFile)
                //{
                //    if (filePhotograph.PostedFile.FileName.Length > 0)
                //    {
                //        if (System.IO.Path.GetExtension(filePhotograph.PostedFile.FileName).ToUpper() != ".JPG" && System.IO.Path.GetExtension(filePhotograph.PostedFile.FileName).ToUpper() != ".JPEG" && System.IO.Path.GetExtension(filePhotograph.PostedFile.FileName).ToUpper() != ".PNG")
                //        {
                //            strError += "Photograph Image should be in jpg/jpeg/png format.<br />";
                //        }
                //        if (filePhotograph.PostedFile.ContentLength < 4096 || filePhotograph.PostedFile.ContentLength > 102400)
                //        {
                //            strError += "Photograph Image Size must be greater than 4 KB and less than 100 KB.<br />";
                //        }
                //    }
                //}
                ////if (fileSignature.HasFile)
                ////{
                ////    if (fileSignature.PostedFile.FileName.Length > 0)
                ////    {
                ////        if (System.IO.Path.GetExtension(fileSignature.PostedFile.FileName).ToUpper() != ".JPG" && System.IO.Path.GetExtension(fileSignature.PostedFile.FileName).ToUpper() != ".JPEG" && System.IO.Path.GetExtension(fileSignature.PostedFile.FileName).ToUpper() != ".PNG")
                ////        {
                ////            strError += "Signature Image should be in jpg/jpeg/png format.<br />";
                ////        }
                ////        if (fileSignature.PostedFile.ContentLength < 1024 || fileSignature.PostedFile.ContentLength > 30720)
                ////        {
                ////            strError += "Signature Image Size must be greater than 1 KB and less than 30 KB.<br />";
                ////        }
                ////    }
                ////}

                return strError;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return "";
            }
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                //Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                //Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);
                //string strError = getErrorMessage();

                //if (strError.Length > 0)
                //{
                //    shInfo.SetMessage(strError, ShowMessageType.Information);
                //}
                //else
                //{
                //    if (filePhotograph.HasFile)
                //    {
                //        if (filePhotograph.PostedFile.FileName.Length > 0)
                //        {
                //            imgPhotograph.ImageUrl = saveFile(PID, "Photograph");
                //            imgPhotograph.ImageUrl = UserInfo.GetImageURL(PID, "Photograph");
                //            cbProceed.Visible = true;
                //        }
                //    }
                //    //if (fileSignature.HasFile)
                //    //{
                //    //    if (fileSignature.PostedFile.FileName.Length > 0)
                //    //    {
                //    //        imgSignature.ImageUrl = saveFile(PID, "Signature");
                //    //        //imgSignature.ImageUrl = UserInfo.GetImageURL(PID, "Signature");
                //    //        cbProceed.Visible = true;
                //    //    }
                //    //}
                //}
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnPhotograph_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                cbUploadedScannedImages.Visible = false;
                cbUploadScannedImages.Visible = true;
                cbProceed.Visible = false;

                trPhotograph.Visible = true;
                trSignature.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSignature_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                cbUploadedScannedImages.Visible = false;
                cbUploadScannedImages.Visible = true;
                cbProceed.Visible = false;

                trPhotograph.Visible = false;
                trSignature.Visible = true;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private string saveFile(Int64 PID, string ImageType)
        {
            ////string FtpAddress = ConfigurationManager.AppSettings["FtpAddress"].ToString();
            ////string FtpUserName = ConfigurationManager.AppSettings["FtpUserName"].ToString();
            ////string FtpUserPassword = ConfigurationManager.AppSettings["FtpUserPassword"].ToString();
            string fileurl = "";
            //if (ImageType == "Photograph")
            //{
            //    if (filePhotograph.PostedFile != null)
            //    {
            //        AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
            //        Stream objFileStream = filePhotograph.PostedFile.InputStream;
            //        FileInfo objFile = new FileInfo(filePhotograph.PostedFile.FileName);
            //        string sysfilename = PID.ToString() + ".jpg";//+ "_" + DateTime.Now.Ticks.ToString()
            //        fileurl = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename, objFileStream, "Photograph");
            //        //Int32 size = filePhotograph.PostedFile.ContentLength;
            //        //Stream str = getFtpRequestToWrite(FtpAddress + "ScannedImages/Photograph/" + PID.ToString() + ".jpg", FtpUserName, FtpUserPassword);
            //        //byte[] file = new byte[size];
            //        //filePhotograph.PostedFile.InputStream.Read(file, 0, size);
            //        //str.Write(file, 0, size);

            //        //str.Close();
            //    }
            //}
            ////else if (ImageType == "Signature")
            ////{
            ////    if (fileSignature.PostedFile != null)
            ////    {
            ////        AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
            ////        Stream objFileStream = fileSignature.PostedFile.InputStream;
            ////        FileInfo objFile = new FileInfo(fileSignature.PostedFile.FileName);
            ////        string sysfilename = PID.ToString() + ".jpg";// + "_" + DateTime.Now.Ticks.ToString()
            ////        fileurl = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename, objFileStream, "Signature");
            ////        //Int32 size = fileSignature.PostedFile.ContentLength;
            ////        //Stream str = getFtpRequestToWrite(FtpAddress + "ScannedImages/Signature/" + PID.ToString() + ".jpg", FtpUserName, FtpUserPassword);
            ////        //byte[] file = new byte[size];
            ////        //fileSignature.PostedFile.InputStream.Read(file, 0, size);
            ////        //str.Write(file, 0, size);

            ////        //str.Close();
            ////    }
            ////}
            return fileurl;
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
    public static class Utils
    {
        // update : 5/April/2018
        static Regex MobileCheck = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
        static Regex MobileVersionCheck = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

        public static bool fBrowserIsMobile()
        {
            Debug.Assert(HttpContext.Current != null);

            if (HttpContext.Current.Request != null && HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                var u = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToString();

                if (u.Length < 4)
                    return false;

                if (MobileCheck.IsMatch(u) || MobileVersionCheck.IsMatch(u.Substring(0, 4)))
                    return true;
            }

            return false;
        }
    }
}