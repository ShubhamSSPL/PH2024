using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityModel;
using System.Data;
using System.Configuration;
using BusinessLayer;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmDocumentForApproval : System.Web.UI.Page
    {
        AzureDocumentUpload objDU = new AzureDocumentUpload();
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
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            //if (reg.CheckISEFC(Session["UserLoginId"].ToString()) == "N" && (Convert.ToInt16(Session["UserTypeID"]) == 23 || Convert.ToInt16(Session["UserTypeID"]) == 24))
            //{
            //    Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            //}
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    LoadData();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        private void LoadData()
        {
            Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
            dbUtilityCorrectDoc regDB = new dbUtilityCorrectDoc();
            gvMessages.DataSource = regDB.GetCandidateListForApproval(UserTypeID, Session["UserLoginID"].ToString());
            gvMessages.DataBind();

            Int32 Count = gvMessages.Rows.Count;
            if (Count == 0)
            {
                gvMessages.Visible = false;
                tblMsg.Visible = true;
            }
            else
            {
                Int32 j = 1;
                for (Int32 m = 0; m < Count; m++)
                {
                    //DateTime tempSentDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[4].Text);
                    //string SentDate = tempSentDate.Day.ToString() + "/" + tempSentDate.Month.ToString() + "/" + tempSentDate.Year.ToString() + " " + String.Format("{0:T}", tempSentDate);
                    //gvMessages.Rows[m].Cells[4].Text = SentDate;

                    gvMessages.Rows[m].Cells[0].Text = j.ToString() + ".";
                    j++;
                }
            }
        }
        protected void gvMessages_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string From = ((Label)gvMessages.Rows[e.NewSelectedIndex].Cells[6].FindControl("lblFrom")).Text;
                string Sender = gvMessages.Rows[e.NewSelectedIndex].Cells[1].Text;

                Response.Redirect("../AFCModule/frmReplyGrievance.aspx?From=" + From + "&Sender=" + From);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void gvMessages_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidFURL = (HiddenField)e.Row.FindControl("hidFURL");
                if (hidFURL.Value != "")
                {
                    string ext = System.IO.Path.GetExtension(hidFURL.Value).ToLower();
                    HtmlImage imgDoc = (HtmlImage)e.Row.FindControl("imgDoc");
                    
                    HtmlAnchor hrefURL = (HtmlAnchor)e.Row.FindControl("hrefURL");
                    HiddenField hdnImgByteArray = (HiddenField)e.Row.FindControl("hdnImgByteArray");

                    if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".bmp")
                    {
                        string url = hidFURL.Value;
                        if (hidFURL.Value.Contains("studentdocuments"))
                        {
                            url = hidFURL.Value.Replace("studentdocuments", "studentdocumentsthumbnail");
                            string checkurl = url.Replace(ConfigurationManager.AppSettings["HttpAddress"], "");
                            if (!objDU.Exists(checkurl))
                            {
                                url = hidFURL.Value;
                            }
                        }
                        string base64 = objDU.GetBlobContentAsBase64("studentdocumentsthumbnail", url);//objDU.ConvertImageURLToBase64(url);
                        imgDoc.Src = base64; //"data:image/png;base64," +
                    }
                    else if (ext == ".pdf")
                    {
                        imgDoc.Src = "../images/pdf.gif";
                    }
                    else if (ext == ".zip" || ext == ".rar")
                    {
                        hrefURL.Target = "self";
                        imgDoc.Src = "../images/zip.png";
                    }   
                    hdnImgByteArray.Value = objDU.GetBlobContentAsBase64("studentdocuments", hidFURL.Value.ToString());
                }
            }
        }
        protected void gvMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int32 DocumentID = Convert.ToInt32(((Label)gvMessages.Rows[RowID].Cells[11].FindControl("lblDocumentID")).Text);
                Int64 PID = Convert.ToInt64(((Label)gvMessages.Rows[RowID].Cells[11].FindControl("lblPersonalID")).Text);
                string RepliedMessage = ((TextBox)gvMessages.Rows[RowID].Cells[9].FindControl("txtRepliedMessage")).Text;

                string strStatus = "";
                string ApprovalStatus = "";
                if (((RadioButton)gvMessages.Rows[RowID].Cells[8].FindControl("rbnYes")).Checked)
                {
                    ApprovalStatus = "A";
                    strStatus = "Approved";
                }
                else if (((RadioButton)gvMessages.Rows[RowID].Cells[8].FindControl("rbnNo")).Checked)
                {
                    ApprovalStatus = "R";
                    strStatus = "Rejected";
                }
                else
                    ApprovalStatus = "";

                if (ApprovalStatus == "")
                {
                    shInfo.SetMessage("Please Select Approval Status.", ShowMessageType.Information);
                }
                else
                {
                    dbUtilityCorrectDoc regDB = new dbUtilityCorrectDoc();

                    if (e.CommandName == "Reply")
                    {
                        //if (Global.IsGrivanceApprovalActive == 0)
                        //{
                        //    shInfo.SetMessage("Grieavance Approval is Closed till Display of Merit List.", ShowMessageType.Information);
                        //}
                        //else
                        //{
                        if (reg.isCandidateNameAppearedInFinalMeritList(PID))
                        {
                            if (RepliedMessage.Length > 0)
                            {

                                DataSet ds = regDB.UpdateCorrectDocument(PID, DocumentID, ApprovalStatus, RepliedMessage, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                                if (ds != null && ds.Tables.Count > 0)
                                {
                                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                                    {
                                        //SMSTemplate sMSTemplate = new SMSTemplate();
                                        //SynCommon synCommon = new SynCommon();
                                        //sMSTemplate.PID = PID;
                                        //sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                                        //sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                        //sMSTemplate.GrievanceID = GrievanceID.ToString();

                                        //if (ApprovalStatus == 'A')
                                        //    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.GrievanceApproved);

                                        //if (ApprovalStatus == 'N')
                                        //    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.GrievanceRejected);

                                        LoadData();

                                        shInfo.SetMessage("Document " + strStatus + " Successfully.", ShowMessageType.Information);
                                    }
                                }
                                else
                                {
                                    shInfo.SetMessage("Technical Problem In Saving Data. Please Try After sometime.", ShowMessageType.Information);
                                }
                            }
                            else
                            {
                                shInfo.SetMessage("Please Enter Remark.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("Candidate is Not in Final Merit List, Can't Approve the Document.", ShowMessageType.Information);
                        }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        private class dbUtilityCorrectDoc
        {
            public DataSet GetCandidateListForApproval(int UserTypeID, string UserLoginID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@UserTypeID", SqlDbType.Int),
                     new SqlParameter("@UserLoginID", SqlDbType.VarChar)
                };

                param[0].Value = UserTypeID;
                param[1].Value = UserLoginID;

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetCorrectDocumentVerificationPendingList", param);

                }
                finally
                {
                    db.Dispose();
                }

            }

            public DataSet UpdateCorrectDocument(Int64 PID, Int32 DocumentID, string DocumentStatus, string Remark, string FileUploadedBy, string FileUploadedByIPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.BigInt),
                     new SqlParameter("@DocumentID", SqlDbType.Int),
                     new SqlParameter("@DocumentStatus", SqlDbType.VarChar),
                     new SqlParameter("@Remark", SqlDbType.VarChar),
                     new SqlParameter("@FileUploadedBy", SqlDbType.VarChar),
                     new SqlParameter("@FileUploadedByIPAddress", SqlDbType.VarChar)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = DocumentStatus;
                param[3].Value = Remark;
                param[4].Value = FileUploadedBy;
                param[5].Value = FileUploadedByIPAddress;

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUpdateCorrectDocument", param);

                }
                finally
                {
                    db.Dispose();
                }

            }

            public int UpdateFlag(Int64 PersonalID, string UserLoginID, string IPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PersonalID", SqlDbType.Int),
                     new SqlParameter("@UserLoginID", SqlDbType.VarChar),
                       new SqlParameter("@IPAddress", SqlDbType.VarChar)
                };

                param[0].Value = PersonalID;
                param[1].Value = UserLoginID;
                param[2].Value = IPAddress;

                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteNonQuery("MHDTE_spUpdateCVCNCLFlag", param);

                }
                finally
                {
                    db.Dispose();
                }

                //return ExecProcedure("MHDTE_spGetAllDocuments", param, "tbl");
            }
        }
    }





   
}