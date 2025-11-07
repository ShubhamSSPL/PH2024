using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class frmRaiseGrievance : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            //if (Request.Cookies["Theme"] == null)
            //{
            //    Page.Theme = "default";
            //}
            //else
            //{
            //    Page.Theme = Request.Cookies["Theme"].Value;
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Global.IsSendGrivanceActive == 1)
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                if (reg.isCandidateNameAppearedInFinalMeritList(objSessionData.PID))
                {
                    shInfo.SetMessage("Your Name is in Final Merit List, So you can not Apply Grievance. ", ShowMessageType.Information);
                    ContentTable2.Visible = false;
                    //Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                }
                else
                {

                    string canidateFCVerificationType = reg.CheckCandidateFCVerificationFor(objSessionData.PID);
                    if (canidateFCVerificationType != "E")
                    {
                        shInfo.SetMessage("You have Not opted e-Verification, So you can not Send Grievance Online. Please Visit to SC Center for your Grievance. ", ShowMessageType.Information);
                        ContentTable2.Visible = false;
                    }
                    else
                    {
                        DBUtility regDB = new DBUtility();
                        DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                        char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                        char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                        if (ApplicationFormStatus == 'I')
                        {
                            shInfo.SetMessage("Your Application Form is Incomplete, You can Send the Grievance Only after Confirmation.", ShowMessageType.Information);
                            ContentTable2.Visible = false;
                        }
                        else
                        {
                            if (FCVerificationStatus == 'N')
                            {
                                shInfo.SetMessage("Your Application Form is Not Confirmed yet, You can not Send the Grievance. You can Send the Grievance Only After Confirmation by SC.", ShowMessageType.Information);
                                ContentTable2.Visible = false;
                            }
                            else if (FCVerificationStatus == 'P')
                            {
                                shInfo.SetMessage("Your Application Form is Picked by SC for e-Verification, Once the Verification Completed then you can Send the Grievance. ", ShowMessageType.Information);
                                ContentTable2.Visible = false;
                            }
                            else if (FCVerificationStatus == 'D')
                            {
                                shInfo.SetMessage("Discrepancy(s) are found in Your Application Form, Please Correct the Discrepancy(s) by making necessary corrections and uploading related Documents and Submit the Application Form.", ShowMessageType.Information);
                                ContentTable2.Visible = false;
                            }
                            else if (FCVerificationStatus == 'U')
                            {
                                shInfo.SetMessage("Your Application Form is already Unlocked/Editable, Please make the necessary corrections and upload the related Documents and Submit the Application Form.", ShowMessageType.Information);
                                ContentTable2.Visible = false;
                            }
                            else
                            {
                                //DBUtility regDB = new DBUtility();
                                if (regDB.CheckActiveGrievance(objSessionData.PID))
                                {
                                    shInfo.SetMessage("Your Grievance is Under Process, You can not Send New Grievance.", ShowMessageType.Information);
                                    ContentTable2.Visible = false;
                                }
                                else
                                {
                                    ContentTable2.Visible = true;
                                }
                            }
                            //else if(!regDB.CheckNEETActiveGrievance(objSessionData.PID))
                            //{
                            //    shInfo.SetMessage("You can not Send New Grievance. Currently Grievances can be raised by only NEET Candidates.", ShowMessageType.Information);
                            //    ContentTable2.Visible = false;
                            //}
                        }
                    }
                    //if (!reg.CheckCandidateValidForMessage(objSessionData.PID))
                    //{
                    //    shInfo.SetMessage("Your Application form is not Confirmed, So you cannot Send Grievance.", ShowMessageType.Information);
                    //}
                    txtSubject.Enabled = false;
                    if (!IsPostBack)
                    {
                        Page.Form.Attributes.Add("enctype", "multipart/form-data");

                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                        string UserLoginID = Session["UserLoginID"].ToString();

                        try
                        {
                            //DBUtility regDB = new DBUtility();
                            //ddlMessageType.DataSource = regDB.GetMasterTicketCategory(Convert.ToInt32(Session["UserTypeID"]));
                            //ddlMessageType.DataTextField = "TicketCategoryName";
                            //ddlMessageType.DataValueField = "TicketCategoryID";
                            //ddlMessageType.DataBind();
                            //ddlMessageType.Items.Insert(0, new ListItem("-- Select Grievance Type --", "0"));

                            DBUtility regDB = new DBUtility();
                            ddlTicketSubCategory.DataSource = regDB.GetMasterTicketSubCategoryForTicketCategory(1);
                            ddlTicketSubCategory.DataTextField = "TicketSubCategoryName";
                            ddlTicketSubCategory.DataValueField = "TicketSubCategoryID";
                            ddlTicketSubCategory.DataBind();
                            //ddlTicketSubCategory.Items.Insert(0, new ListItem("-- Select Message Sub Type --", "0"));
                            ddlTicketSubCategory.Texts.SelectBoxCaption = "-- Select Grievance Sub Type --";
                        }
                        catch (Exception ex)
                        {
                            Logging.LogException(ex, "[Page Level Error]");
                            shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                        }
                    }
                }
            }
            else
            {
                shInfo.SetMessage("Grivance are closed till Merit List Declared, So you can not Apply Grievance. ", ShowMessageType.Information);
                ContentTable2.Visible = false;
            }


        }

        protected void ddlMessageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //try
            //{

            //    if (ddlMessageType.SelectedIndex != 0)
            //    {
            //        Int32 TicketCategoryID = Convert.ToInt32(ddlMessageType.SelectedValue);
            //        DBUtility regDB = new DBUtility();
            //        ddlTicketSubCategory.DataSource = regDB.GetMasterTicketSubCategoryForTicketCategory(TicketCategoryID);
            //        ddlTicketSubCategory.DataTextField = "TicketSubCategoryName";
            //        ddlTicketSubCategory.DataValueField = "TicketSubCategoryID";
            //        ddlTicketSubCategory.DataBind();
            //        //ddlTicketSubCategory.Items.Insert(0, new ListItem("-- Select Message Sub Type --", "0"));
            //        ddlTicketSubCategory.Texts.SelectBoxCaption = "-- Select Grievance Sub Type --";
            //    }
            //    else
            //    {
            //        ddlTicketSubCategory.Items.Clear();
            //        //ddlTicketSubCategory.Items.Insert(0, new ListItem("-- Select Message Sub Type --", "0"));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logging.LogException(ex, "[Page Level Error]");
            //    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            //}
        }

        protected void ddlTicketSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
            try
            {
                List<String> TicketSubCategory_list = new List<string>();

                foreach (System.Web.UI.WebControls.ListItem item in ddlTicketSubCategory.Items)
                {
                    if (item.Selected)
                    {
                        TicketSubCategory_list.Add(item.Text);
                    }

                    ddlTicketSubCategory.Texts.SelectBoxCaption = String.Join(", ", TicketSubCategory_list.ToArray());
                }

                if (ddlTicketSubCategory.Texts.SelectBoxCaption == "")
                {
                    ddlTicketSubCategory.Texts.SelectBoxCaption = "-- Select Grievance Sub Type --";
                }

                txtSubject.Text = String.Join(", ", TicketSubCategory_list.ToArray());
            }
            catch (Exception ex)
            {
                shInfo.Visible = true;
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                DBUtility regDB = new DBUtility();

                string AFCCode = Session["UserLoginID"].ToString();
                Random random = new Random();
                string filePath1 = "";
                string filePath2 = "";

                if (fileInput1.PostedFile.FileName.Length > 0)
                {
                    if (System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput1.PostedFile.FileName).ToUpper() == ".PDF")
                    {
                        filePath1 = saveFile(AFCCode + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput1.PostedFile.FileName), 1);
                    }
                    else
                    {
                        shInfo.Visible = true;
                        shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                        return;
                    }
                }
                if (fileInput2.PostedFile.FileName.Length > 0)
                {
                    if (System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileInput2.PostedFile.FileName).ToUpper() == ".PDF")
                    {
                        filePath2 = saveFile(AFCCode + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next().ToString() + System.IO.Path.GetExtension(fileInput2.PostedFile.FileName), 2);
                    }
                    else
                    {
                        shInfo.Visible = true;
                        shInfo.SetMessage("Only JPEG images and PDF files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                        return;
                    }
                }

                string To = "ADMINAFC";
                DataSet ds = regDB.GetMappedFCForCandidate(objSessionData.PID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    To = ds.Tables[0].Rows[0]["FCID"].ToString();
                }
                else
                {
                    shInfo.Visible = true;
                    shInfo.SetMessage("Your Application Form is not Mapped to Any SC. Please Contact to Administrator.", ShowMessageType.UserError);
                    return;
                }

                string From = AFCCode;
                string Subject = txtSubject.Text;
                string Message = txtMsg.Text;

                string strTicketSubCategoryID = "";
                if (ddlTicketSubCategory.Texts.SelectBoxCaption != "All")
                {
                    List<String> TicketSubCategoryID_list = new List<string>();
                    string strCourseTypeID = "";
                    foreach (System.Web.UI.WebControls.ListItem item in ddlTicketSubCategory.Items)
                    {
                        if (item.Selected)
                        {
                            TicketSubCategoryID_list.Add(item.Value);
                        }
                        strTicketSubCategoryID = String.Join(",", TicketSubCategoryID_list.ToArray());
                    }

                }

                DBUtility checkActiveG = new DBUtility();
                Int64 GrievanceID = 0;
                if (!checkActiveG.CheckActiveGrievance(objSessionData.PID))
                {
                    GrievanceID = regDB.SaveGrievance(objSessionData.PID, To, From, 1, strTicketSubCategoryID, Subject, Message, filePath1, filePath2, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                    if (GrievanceID > 0)
                    {

                        txtSubject.Text = "";
                        txtMsg.Text = "";
                        //ddlMessageType.SelectedIndex = 0;
                        ddlTicketSubCategory.SelectedIndex = 0;
                        ddlTicketSubCategory.Items.Clear();
                        ddlTicketSubCategory.ClearSelection();
                        ddlTicketSubCategory.Texts.SelectBoxCaption = "-- Select Grievance Sub Type --";

                        shInfo.Visible = true;
                        shInfo.SetMessage("Grievance Submitted Successfully. Your Grievance ID : " + GrievanceID.ToString(), ShowMessageType.Information);
                        ContentTable2.Visible = false;
                    }
                    else
                    {
                        shInfo.Visible = true;
                        shInfo.SetMessage("There is some problem in sending Grievance. Please try after some time.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.Visible = true;
                    shInfo.SetMessage("Grievance Submitted Successfully.", ShowMessageType.Information);
                    ContentTable2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.Visible = true;
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private string saveFile(string FilePath, Int32 FileNo)
        {
            string HttpFilePath = "";// HttpAddress + "Attachment/" + FilePath;

            if (FileNo == 1)
            {
                if (fileInput1.PostedFile != null)
                {
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    Stream objFileStream = fileInput1.PostedFile.InputStream;
                    FileInfo objFile = new FileInfo(fileInput1.PostedFile.FileName);
                    string sysfilename = FilePath;//+ "_" + DateTime.Now.Ticks.ToString()
                    HttpFilePath = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename, objFileStream, fileInput1.PostedFile.ContentType, "Attachment".ToLower());
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
                    HttpFilePath = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename, objFileStream, fileInput2.PostedFile.ContentType, "Attachment".ToLower());
                }
            }

            return HttpFilePath;
        }

    }

    public class DBUtility
    {
        public Int64 SaveGrievance(Int64 PID, string To, string From, int GrievanceCategoryID, string GrievanceSubCategoryID, string GrievanceSubject, string GrievanceMessage, string Attachment1, string Attachment2, string SentBy, string SentByIPAddress)
        {
            Int64 GrievanceID = 0;
            DBConnection db = new DBConnection();
            try
            {

                GrievanceID = Convert.ToInt64(db.ExecuteScaler("MHDTE_spSaveGrievance", new SqlParameter[]
                 {
                new SqlParameter("@PID", PID),
                new SqlParameter("@To", To),
                new SqlParameter("@From", From),
                new SqlParameter("@GrievanceCategoryID", GrievanceCategoryID),
                new SqlParameter("@GrievanceSubCategoryID", GrievanceSubCategoryID),
                new SqlParameter("@GrievanceSubject", GrievanceSubject),
                new SqlParameter("@GrievanceMessage", GrievanceMessage),
                new SqlParameter("@Attachment1", Attachment1),
                new SqlParameter("@Attachment2", Attachment2),
                new SqlParameter("@SentBy", SentBy),
                new SqlParameter("@SentByIPAddress", SentByIPAddress)
                 }));
            }
            catch (SqlException ex)
            {
                throw ex;
                //long messageID = ExceptionMessages.GetMessageDetails();
                //throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
            }
            finally
            {
                db.Dispose();
            }
            return GrievanceID;
        }

        public DataSet GetMasterTicketCategory(int UserTypeID)
        {
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetMasterTicketCategory", new SqlParameter[]
                    {
                    new SqlParameter("@UserTypeID", UserTypeID)
                    });
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataSet GetMasterTicketSubCategoryForTicketCategory(int TicketCategoryID)
        {
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetMasterTicketSubCategoryForTicketCategory", new SqlParameter[]
                    {
                    new SqlParameter("@TicketCategoryID", TicketCategoryID)
                    });
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataSet GetMappedFCForCandidate(Int64 PID)
        {
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetMappedFCForCandidate", new SqlParameter[]
                    {
                    new SqlParameter("@PID", PID)
                    });
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool CheckActiveGrievance(Int64 PID)
        {
            DBConnection db = new DBConnection();
            try
            {

                Int32 result = Convert.ToInt32(db.ExecuteScaler("MHDTE_spCheckActiveGrievance", new SqlParameter[]
                 {
                new SqlParameter("@PID", PID)
                 }));

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
                //long messageID = ExceptionMessages.GetMessageDetails();
                //throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataSet GetGrievanceDetailsByID(Int64 GrievanceID)
        {
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetGrievanceDetailsByID", new SqlParameter[]
                    {
                    new SqlParameter("@GrievanceID", GrievanceID)
                    });
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool CheckNEETActiveGrievance(Int64 PID)
        {
            DBConnection db = new DBConnection();
            try
            {

                Int32 result = Convert.ToInt32(db.ExecuteScaler("MHDTE_spCheckNEETActiveGrievance", new SqlParameter[]
                 {
                new SqlParameter("@PID", PID)
                 }));

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
                //long messageID = ExceptionMessages.GetMessageDetails();
                //throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
            }
            finally
            {
                db.Dispose();
            }
        }
    }


}