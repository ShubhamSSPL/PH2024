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
    public partial class frmViewGrievance : System.Web.UI.Page
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
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMessageBoxDocument));
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    Int64 GrievanceID = Convert.ToInt64(Request.QueryString["GrievanceID"]);
                    DBUtility regDB = new DBUtility();
                    DataSet ds = regDB.GetGrievanceDetailsByID(GrievanceID);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblGrievanceID.Text = ds.Tables[0].Rows[0]["GrievanceID"].ToString();
                        lblSubject.Text = ds.Tables[0].Rows[0]["GrievanceSubject"].ToString();
                        lblGrievanceMessage.Text = ds.Tables[0].Rows[0]["GrievanceMessage"].ToString();
                        lblSentTime.Text = ds.Tables[0].Rows[0]["SentDateTime"].ToString();
                        lblApprovalStatus.Text = ds.Tables[0].Rows[0]["ApprovalStatus"].ToString();

                        if (ds.Tables[0].Rows[0]["ApprovedDatetime"].ToString() != "")
                        {
                            trReplyRemark.Visible = true;
                            trReplyBy.Visible = true;
                            trReplyDate.Visible = true;
                            lblReplyRemark.Text = ds.Tables[0].Rows[0]["ApprovedRemark"].ToString();
                            lblReplyBy.Text = ds.Tables[0].Rows[0]["ApprovedBy"].ToString();
                            lblReplyDate.Text = ds.Tables[0].Rows[0]["ApprovedDatetime"].ToString();
                        }
                        else
                        {
                            trReplyRemark.Visible = false;
                                trReplyBy.Visible = false;
                            trReplyDate.Visible = false;
                        }
                        ContentTable2.Visible = true;
                    }
                    else
                    {
                        shInfo.SetMessage("No Details Available. Please contact to Administrator.", ShowMessageType.Information);
                        ContentTable2.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateModule/frmCheckGrievanceStatus.aspx?tms=101");
        }



    }

}