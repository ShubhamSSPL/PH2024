using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BusinessLayer;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System.Data.SqlClient;
using EntityModel;

namespace Pharmacy2024.AFCModule
{
    public partial class frmReplyGrievance : System.Web.UI.Page
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
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMessageBoxDocument));
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    if (Request.QueryString["From"] == null || Request.QueryString["Sender"] == null)
                    {
                        Response.Redirect("../AFCModule/frmGrievanceNonRepliedAFC.aspx");
                    }
                    else
                    {
                        string From = Request.QueryString["From"].ToString();
                        string Sender = Request.QueryString["Sender"].ToString();

                        ContentTable2.HeaderText = "Reply to Grievance from " + Sender.Replace("<br />", " ");

                        DBUtility regDB = new DBUtility();
                        gvMessages.DataSource = regDB.GetGrievancesList(From);
                        gvMessages.DataBind();

                        Int32 Count = gvMessages.Rows.Count;
                        if (Count == 0)
                        {
                            Response.Redirect("../AFCModule/frmGrievanceNonRepliedAFC.aspx");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void gvMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 GrievanceID = Convert.ToInt64(((Label)gvMessages.Rows[RowID].Cells[5].FindControl("lblGrievanceID")).Text);
                Int64 PID = Convert.ToInt64(((Label)gvMessages.Rows[RowID].Cells[5].FindControl("lblPersonalID")).Text);
                string RepliedMessage = ((TextBox)gvMessages.Rows[RowID].Cells[3].FindControl("txtRepliedMessage")).Text;

                string strStatus = "";
                char ApprovalStatus = ' ';
                if (((RadioButton)gvMessages.Rows[RowID].Cells[4].FindControl("rbnYes")).Checked)
                {
                    ApprovalStatus = 'Y';
                    strStatus = "Approved";
                }
                else if (((RadioButton)gvMessages.Rows[RowID].Cells[4].FindControl("rbnNo")).Checked)
                {
                    ApprovalStatus = 'N';
                    strStatus = "Rejected";
                }
                else
                    ApprovalStatus = ' ';

                if (ApprovalStatus == ' ')
                {
                    shInfo.SetMessage("Please Select Approval Status.", ShowMessageType.Information);
                }
                else
                {
                    DBUtility regDB = new DBUtility();

                    if (e.CommandName == "Reply")
                    {

                        if (Global.IsGrivanceApprovalActive == 0)
                        {
                            shInfo.SetMessage("Grieavance Approval is Closed till Display of Merit List.", ShowMessageType.Information);
                        }
                        else
                        {   //Response.Redirect("../AFCModule/frmGrievanceNonRepliedAFC.aspx");
                            if (!reg.isCandidateNameAppearedInFinalMeritList(PID))
                            {
                                if (RepliedMessage.Length > 0)
                                {
                                    if (regDB.ReplyGrievance(GrievanceID, RepliedMessage, ApprovalStatus, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                    {
                                        SMSTemplate sMSTemplate = new SMSTemplate();
                                        SynCommon synCommon = new SynCommon();
                                        sMSTemplate.PID = PID;
                                        sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                                        sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                        sMSTemplate.GrievanceID = GrievanceID.ToString();

                                        if (ApprovalStatus == 'Y')
                                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.GrievanceApproved);

                                        if (ApprovalStatus == 'N')
                                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.GrievanceRejected);

                                        string From = Request.QueryString["From"].ToString();

                                        gvMessages.DataSource = regDB.GetGrievancesList(From);
                                        gvMessages.DataBind();
                                      

                                        Int32 Count = gvMessages.Rows.Count;
                                        if (Count == 0)
                                        {
                                            Response.Redirect("../AFCModule/frmGrievanceNonRepliedAFC.aspx");
                                        }

                                        shInfo.SetMessage("Grievance " + strStatus + " Successfully.", ShowMessageType.Information);
                                    }
                                    else
                                    {
                                        shInfo.SetMessage("Technical Problem In Saving Data. Please Try After sometime.", ShowMessageType.Information);
                                    }
                                }
                                else
                                {
                                    shInfo.SetMessage("Please Enter Replied Message.", ShowMessageType.Information);
                                }
                            }
                            else
                            {
                                shInfo.SetMessage("Candidate is in Final Merit List Can't Approve the Grievance.", ShowMessageType.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }



    public class DBUtility
    {

        public DataSet GetGrievancesList(string From)
        {
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetGrievancesList", new SqlParameter[]
                    {
                    new SqlParameter("@From", From)
                    });
            }
            finally
            {
                db.Dispose();
            }
        }
        public DataSet GetAFCNonRepliedGrievance(string Flag, string To)
        {
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetAFCNonRepliedGrievance", new SqlParameter[]
                    {
                    new SqlParameter("@Flag", Flag),
                    new SqlParameter("@To", To)
                    });
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool ReplyGrievance(Int64 GrievanceID, string RepliedMessage, char ApprovalStatus, string RepliedBy, string RepliedByIPAddress)
        {
            DBConnection db = new DBConnection();
            try
            {
                Int32 result = Convert.ToInt32(db.ExecuteNonQuery("MHDTE_spReplyGrievance", new SqlParameter[]
                 {
                new SqlParameter("@GrievanceID", GrievanceID),
                new SqlParameter("@RepliedMessage", RepliedMessage),
                new SqlParameter("@ApprovalStatus", ApprovalStatus),
                new SqlParameter("@RepliedBy", RepliedBy),
                new SqlParameter("@RepliedByIPAddress", RepliedByIPAddress),
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
        public DataSet GetAFCApprovedGrievances(string Flag, string To)
        {
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetAFCApprovedGrievances", new SqlParameter[]
                    {
                    new SqlParameter("@Flag", Flag),
                    new SqlParameter("@To", To)
                    });
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataSet GetAFCRejectedGrievances(string Flag, string To)
        {
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetAFCRejectedGrievances", new SqlParameter[]
                    {
                    new SqlParameter("@Flag", Flag),
                    new SqlParameter("@To", To)
                    });
            }
            finally
            {
                db.Dispose();
            }
        }




    }
}