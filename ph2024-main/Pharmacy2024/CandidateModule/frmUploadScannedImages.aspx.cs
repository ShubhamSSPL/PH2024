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

namespace Pharmacy2024.CandidateModule
{
    public partial class frmUploadScannedImages : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        AzureDocumentUpload azObj = new AzureDocumentUpload();
        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    if (Request.Cookies["Theme"] == null)
        //    {
        //        Page.Theme = "default";
        //    }
        //    else
        //    {
        //        Page.Theme = Request.Cookies["Theme"].Value;
        //    }
        //}
        protected void Upload(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                AzureDocumentUpload azObj = new AzureDocumentUpload();
                SessionData objSessionData = (SessionData)Session["SessionData"];
                if (reg.isCandidateNameAppearedInFinalMeritList(objSessionData.PID))
                {
                    Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                }
                string strError = getErrorMessage();

                if (strError.Length > 0)
                {
                    shInfo.SetMessage(strError, ShowMessageType.Information);
                }
                else
                {
                    if (objSessionData.StepID >= 7)
                    {
                        string ModifiedBy = Session["UserLoginID"].ToString();
                        string ModifiedByIPAddress = UserInfo.GetIPAddress();

                        if (Request.Form["imgCropped"] != "")
                        {
                            string base64 = Request.Form["imgCropped"];
                            byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);

                            imgPhotograph.ImageUrl = saveCroppedFile(objSessionData.PID, "Photograph", bytes);
                            imgPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(objSessionData.PID, "Photograph"));

                        }
                        if (Request.Form["imgSignCropped"] != "")
                        {
                            string base64Sign = Request.Form["imgSignCropped"];
                            byte[] bytesSign = Convert.FromBase64String(base64Sign.Split(',')[1]);

                            imgSignature.ImageUrl = saveCroppedFile(objSessionData.PID, "Signature", bytesSign);
                            imgSignature.ImageUrl = azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(objSessionData.PID, "Signature"));
                            imgSignature.Visible = true;


                        }
                        if (checkIfFileExistsOnServer(("Photograph/".ToLower() + objSessionData.PID.ToString() + ".jpg")) && checkIfFileExistsOnServer(("Signature/".ToLower() + objSessionData.PID.ToString() + ".jpg")))
                        {
                            cbProceed.Visible = true;
                            //cropContainer.Visible = false;
                        }
                    }
                    else
                    {
                        string ModifiedBy = Session["UserLoginID"].ToString();
                        string ModifiedByIPAddress = UserInfo.GetIPAddress();
                        if (Request.Form["imgCropped"] != "")
                        {
                            string base64 = Request.Form["imgCropped"];
                            byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);
                            ViewState["Photobyte"] = bytes;
                            imgPhotograph.ImageUrl = saveCroppedFile(objSessionData.PID, "Photograph", bytes);
                            imgPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(objSessionData.PID, "Photograph"));
                            imgPhotograph.Visible = true;

                        }
                        if (Request.Form["imgSignCropped"] != "")
                        {
                            string base64Sign = Request.Form["imgSignCropped"];
                            byte[] bytesSign = Convert.FromBase64String(base64Sign.Split(',')[1]);
                            ViewState["Signbyte"] = bytesSign;
                            imgSignature.ImageUrl = saveCroppedFile(objSessionData.PID, "Signature", bytesSign);
                            imgSignature.ImageUrl = azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(objSessionData.PID, "Signature"));
                            imgSignature.Visible = true;


                        }
                        if (checkIfFileExistsOnServer(("Photograph/".ToLower() + objSessionData.PID.ToString() + ".jpg")) && checkIfFileExistsOnServer(("Signature/".ToLower() + objSessionData.PID.ToString() + ".jpg")))
                        {
                            byte[] Photobyte = (byte[])ViewState["Photobyte"];

                            if (objSessionData.StepID < 7)
                            {
                                ((SessionData)Session["SessionData"]).StepID = 7;
                            }
                            cbProceed.Visible = true;

                        }
                    }
                    //divCroppingSign.Style.Add("display", "none");
                    //divCropping.Style.Add("display", "none");
                    //}
                    //else
                    //{
                    //    if (Request.Form["imgCropped"] == "" || Request.Form["imgSignCropped"] == "")
                    //    {
                    //        shInfo.SetMessage("Please Attach Photo and Signature then Upload.", ShowMessageType.Information);
                    //    }
                    //    else
                    //    {
                    //        string base64 = Request.Form["imgCropped"];
                    //        byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);

                    //        string base64Sign = Request.Form["imgSignCropped"];
                    //        byte[] bytesSign = Convert.FromBase64String(base64Sign.Split(',')[1]);

                    //        imgPhotograph.ImageUrl = saveCroppedFile(objSessionData.PID, "Photograph", bytes);
                    //        imgSignature.ImageUrl = saveCroppedFile(objSessionData.PID, "Signature", bytesSign);

                    //        if (checkIfFileExistsOnServer(("Photograph/".ToLower() + objSessionData.PID.ToString() + ".jpg")) && checkIfFileExistsOnServer(("Signature/".ToLower() + objSessionData.PID.ToString() + ".jpg")))
                    //        {
                    //            string ModifiedBy = Session["UserLoginID"].ToString();
                    //            string ModifiedByIPAddress = UserInfo.GetIPAddress();

                    //            if (reg.saveScannedImages(objSessionData.PID, bytes, bytesSign, ModifiedBy, ModifiedByIPAddress))
                    //            {
                    //                if (objSessionData.StepID < 7)
                    //                {
                    //                    ((SessionData)Session["SessionData"]).StepID = 7;
                    //                }
                    //                imgPhotograph.ImageUrl = (UserInfo.GetImageURL(objSessionData.PID, "Photograph")).ToLower();
                    //                imgPhotograph.Visible = true;
                    //                cbProceed.Visible = true;
                    //                //divCropping.Style.Add("display", "none");

                    //                imgSignature.ImageUrl = (UserInfo.GetImageURL(objSessionData.PID, "Signature")).ToLower();
                    //                imgSignature.Visible = true;
                    //                //divCroppingSign.Style.Add("display", "none");
                    //            }
                    //            else
                    //            {
                    //                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                    //            }
                    //        }
                    //    }
                    //}
                }
                ddlPhotoSign.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime || Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            string _leftMenu = ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"];
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormLinks = true;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormNumber = false;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFadingEffect = true; ((ExpanderMenu)Master.FindControl(_leftMenu)).FormType = 1;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).FormNumber = Convert.ToInt64(Session["UserID"]);
            if (!IsPostBack)
            {
                try

                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    //if (reg.isCandidateNameAppearedInFinalMeritList(objSessionData.PID))
                    //{
                    //    Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    //}
                    if (reg.CheckFCVerificationStatus(objSessionData.PID))
                    {
                        shInfo.SetMessage("Application Form is Confirmed or Has been picked for SC E-Verification", ShowMessageType.Information);
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }
                    DataSet dsCurrentLink = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmUploadScannedImages");

                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());


                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if ((ApplicationFormStatus == 'A' || objSessionData.StepID < 6) && (FCVerificationStatus == 'C' || FCVerificationStatus == 'P'))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }
                    if (reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "Y")
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }

                    if (objSessionData.StepID >= 7)
                    {
                        cbUploadedScannedImages.Visible = false;
                        cbUploadScannedImages.Visible = true;

                        imgPhotograph.Visible = true;
                        imgSignature.Visible = true;

                        AzureDocumentUpload azObj = new AzureDocumentUpload();
                        imgPhotograph.ImageUrl = btnPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(objSessionData.PID, "Photograph"));
                        imgSignature.ImageUrl = btnSignature.ImageUrl = azObj.GetBlobContentAsBase64("Signature", UserInfo.GetImageURL(objSessionData.PID, "Signature"));

                        if (!checkIfFileExistsOnServer(("Photograph/".ToLower() + objSessionData.PID.ToString() + ".jpg")))
                        {
                            cbProceed.Visible = false;
                        }
                        else if (!checkIfFileExistsOnServer(("Signature/".ToLower() + objSessionData.PID.ToString() + ".jpg")))
                        {
                            cbProceed.Visible = false;
                        }
                        else
                        {

                            cbProceed.Visible = true;
                        }
                    }
                    else
                    {
                        cbUploadedScannedImages.Visible = false;
                        cbUploadScannedImages.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected string getErrorMessage()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                string strError = "";

                if (objSessionData.StepID >= 7)
                {
                    //if (filePhotograph.HasFile)
                    //{
                    //    if (filePhotograph.PostedFile.FileName.Length > 0)
                    //    {
                    //        if (System.IO.Path.GetExtension(filePhotograph.PostedFile.FileName).ToUpper() != ".JPG" && System.IO.Path.GetExtension(filePhotograph.PostedFile.FileName).ToUpper() != ".JPEG")
                    //        {
                    //            strError += "Photograph Image should be in jpg/jpeg format.<br />";
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
                    ////        if (System.IO.Path.GetExtension(fileSignature.PostedFile.FileName).ToUpper() != ".JPG" && System.IO.Path.GetExtension(fileSignature.PostedFile.FileName).ToUpper() != ".JPEG")
                    ////        {
                    ////            strError += "Signature Image should be in jpg/jpeg format.<br />";
                    ////        }
                    ////        if (fileSignature.PostedFile.ContentLength < 1024 || fileSignature.PostedFile.ContentLength > 30720)
                    ////        {
                    ////            strError += "Signature Image Size must be greater than 1 KB and less than 30 KB.<br />";
                    ////        }
                    ////    }
                    ////}
                }
                else
                {
                    //if (filePhotograph.PostedFile.FileName.Length == 0)
                    //{
                    //    strError += "Photograph Image not found.<br />";
                    //}
                    //if (System.IO.Path.GetExtension(filePhotograph.PostedFile.FileName).ToUpper() != ".JPG" && System.IO.Path.GetExtension(filePhotograph.PostedFile.FileName).ToUpper() != ".JPEG")
                    //{
                    //    strError += "Photograph Image should be in jpg/jpeg format.<br />";
                    //}
                    //if (filePhotograph.PostedFile.ContentLength < 4096 || filePhotograph.PostedFile.ContentLength > 102400)
                    //{
                    //    strError += "Photograph Image Size must be greater than 4 KB and less than 100 KB.<br />";
                    //}
                    ////if (fileSignature.PostedFile.FileName.Length == 0)
                    ////{
                    ////    strError += "Signature Image not found.<br />";
                    ////}
                    ////if (System.IO.Path.GetExtension(fileSignature.PostedFile.FileName).ToUpper() != ".JPG" && System.IO.Path.GetExtension(fileSignature.PostedFile.FileName).ToUpper() != ".JPEG")
                    ////{
                    ////    strError += "Signature Image should be in jpg/jpeg format.<br />";
                    ////}
                    ////if (fileSignature.PostedFile.ContentLength < 1024 || fileSignature.PostedFile.ContentLength > 30720)
                    ////{
                    ////    strError += "Signature Image Size must be greater than 1 KB and less than 30 KB.<br />";
                    ////}
                }

                return strError;
            }
            catch (Exception ex)
            {
                shInfo.Visible = true;
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return "";
            }
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            //ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //try
            //{
            //    SessionData objSessionData = (SessionData)Session["SessionData"];
            //    string strError = getErrorMessage();

            //    if (strError.Length > 0)
            //    {
            //        shInfo.SetMessage(strError, ShowMessageType.Information);
            //    }
            //    else
            //    {
            //        if (objSessionData.StepID >= 7)
            //        {
            //            if (filePhotograph.HasFile)
            //            {
            //                if (filePhotograph.PostedFile.FileName.Length > 0)
            //                {
            //                    Byte[] bytePhotograph = new byte[filePhotograph.PostedFile.ContentLength];
            //                    filePhotograph.PostedFile.InputStream.Read(bytePhotograph, 0, filePhotograph.PostedFile.ContentLength);
            //                    string ModifiedBy = Session["UserLoginID"].ToString();
            //                    string ModifiedByIPAddress = UserInfo.GetIPAddress();

            //                    if (reg.updateScannedImages(objSessionData.PID, bytePhotograph, "Photograph", ModifiedBy, ModifiedByIPAddress))
            //                    {
            //                        SaveFile(objSessionData.PID, "Photograph");
            //                        imgPhotograph.ImageUrl = "../CandidateModule/frmGetScannedImages.aspx?PID=" + objSessionData.PID.ToString() + "&ImageType=Photograph";
            //                        cbProceed.Visible = true;
            //                    }
            //                }
            //            }
            //            //if (fileSignature.HasFile)
            //            //{
            //            //    if (fileSignature.PostedFile.FileName.Length > 0)
            //            //    {
            //            //        Byte[] byteSignature = new byte[fileSignature.PostedFile.ContentLength];
            //            //        fileSignature.PostedFile.InputStream.Read(byteSignature, 0, fileSignature.PostedFile.ContentLength);
            //            //        string ModifiedBy = Session["UserLoginID"].ToString();
            //            //        string ModifiedByIPAddress = UserInfo.GetIPAddress();

            //            //        if (reg.updateScannedImages(objSessionData.PID, byteSignature, "Signature", ModifiedBy, ModifiedByIPAddress))
            //            //        {
            //            //            SaveFile(objSessionData.PID,  "Signature");
            //            //            imgSignature.ImageUrl = "../CandidateModule/frmGetScannedImages.aspx?PID=" + objSessionData.PID.ToString() + "&ImageType=Signature";
            //            //            cbProceed.Visible = true;
            //            //        }
            //            //    }
            //            //}
            //        }
            //        else
            //        {
            //            Byte[] bytePhotograph = new byte[filePhotograph.PostedFile.ContentLength];
            //            filePhotograph.PostedFile.InputStream.Read(bytePhotograph, 0, filePhotograph.PostedFile.ContentLength);
            //            //Byte[] byteSignature = new byte[fileSignature.PostedFile.ContentLength];
            //            //fileSignature.PostedFile.InputStream.Read(byteSignature, 0, fileSignature.PostedFile.ContentLength);
            //            string ModifiedBy = Session["UserLoginID"].ToString();
            //            string ModifiedByIPAddress = UserInfo.GetIPAddress();

            //            if (reg.saveScannedImages(objSessionData.PID, bytePhotograph, null, ModifiedBy, ModifiedByIPAddress))
            //            {
            //                if (objSessionData.StepID < 7)
            //                {
            //                    ((SessionData)Session["SessionData"]).StepID = 7;
            //                }

            //                SaveFile(objSessionData.PID, "Photograph");
            //                //SaveFile(objSessionData.PID, "Signature");

            //                imgPhotograph.Visible = true;
            //                //imgSignature.Visible = true;

            //                imgPhotograph.ImageUrl = "../CandidateModule/frmGetScannedImages.aspx?PID=" + objSessionData.PID.ToString() + "&ImageType=Photograph";
            //                //imgSignature.ImageUrl = "../CandidateModule/frmGetScannedImages.aspx?PID=" + objSessionData.PID.ToString() + "&ImageType=Signature";

            //                cbProceed.Visible = true;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logging.LogException(ex, "[Page Level Error]");
            //    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            //}
        }
        protected void btnPhotograph_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                cbUploadedScannedImages.Visible = false;
                cbUploadScannedImages.Visible = true;

                trPhotograph.Visible = true;
                //trSignature.Visible = false;
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

                trPhotograph.Visible = false;
                //trSignature.Visible = true;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        //protected void btnProceed_Click(object sender, EventArgs e)
        //{
        //    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
        //    SessionData objSessionData = (SessionData)Session["SessionData"];

        //    if (!checkIfFileExistsOnServer(("Photograph/".ToLower() + objSessionData.PID.ToString() + ".jpg")))
        //    {
        //        shInfo.SetMessage("Please Upload the Photograph.", ShowMessageType.Information);
        //    }
        //    else if (!checkIfFileExistsOnServer(("Signature/".ToLower() + objSessionData.PID.ToString() + ".jpg")))
        //    {
        //        shInfo.SetMessage("Please Upload the Signature.", ShowMessageType.Information);
        //    }
        //    else
        //    {

        //        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
        //    }
        //}
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];


                bool isUploadedPhoto = false;
                if (checkIfFileExistsOnServer("Photograph/" + objSessionData.PID.ToString() + ".jpg"))
                {
                    isUploadedPhoto = true;
                }
                else if (checkIfFileExistsOnServer("Signature/" + objSessionData.PID.ToString() + ".jpg"))
                {
                    isUploadedPhoto = true;
                }


                if (isUploadedPhoto)
                {
                    string ModifiedBy = Session["UserLoginID"].ToString();
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();

                    if (reg.saveScannedImagesStepID(objSessionData.PID, ModifiedBy, ModifiedByIPAddress))
                    {
                        if (objSessionData.StepID < 7)
                        {
                            ((SessionData)Session["SessionData"]).StepID = 7;
                        }

                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                    }
                }
                // }
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
            ////        fileurl = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename, objFileStream, "Signature");
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

        private void SaveFile(Int64 PID, string FileName)
        {
            //if (FileName == "Photograph")
            //{
            //    if (filePhotograph.PostedFile != null)
            //    {
            //        AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
            //        Stream objFileStream = filePhotograph.PostedFile.InputStream;
            //        FileInfo objFile = new FileInfo(filePhotograph.PostedFile.FileName);
            //        string sysFileName = PID.ToString() + ".jpg";
            //        azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"], sysFileName, objFileStream, filePhotograph.PostedFile.ContentType, "Photograph");
            //    }
            //}
            ////else if (FileName == "Signature")
            ////{
            ////    if (fileSignature.PostedFile != null)
            ////    {
            ////        AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
            ////        Stream objFileStream = fileSignature.PostedFile.InputStream;
            ////        FileInfo objFile = new FileInfo(fileSignature.PostedFile.FileName);
            ////        string sysFileName = PID.ToString() + ".jpg";
            ////        azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"], sysFileName, objFileStream, "Signature");
            ////    }
            ////}
        }

        private bool checkIfFileExistsOnServer(string FileName)
        {
            AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
            return azureDocumentUpload.Exists(FileName.ToLower());
            ////string FtpAddress = ConfigurationManager.AppSettings["FtpAddress"].ToString();
            ////string FtpUserName = ConfigurationManager.AppSettings["FtpUserName"].ToString();
            ////string FtpUserPassword = ConfigurationManager.AppSettings["FtpUserPassword"].ToString();

            ////var request = (FtpWebRequest)WebRequest.Create(FtpAddress + FileName);
            ////request.Credentials = new NetworkCredential(FtpUserName, FtpUserPassword);
            ////request.Method = WebRequestMethods.Ftp.GetFileSize;

            ////try
            ////{
            ////    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            ////    return true;
            ////}
            ////catch (WebException ex)
            ////{
            ////    FtpWebResponse response = (FtpWebResponse)ex.Response;
            ////    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
            ////    {
            ////        return false;
            ////    }
            ////}

            ////return false;
        }
    }
}