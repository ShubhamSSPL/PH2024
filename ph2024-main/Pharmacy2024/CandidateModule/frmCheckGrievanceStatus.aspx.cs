using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class frmCheckGrievanceStatus : System.Web.UI.Page
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
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMessageBoxDocument));
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                try
                {
                    DBUtility regDB = new DBUtility();
                    gvMessages.Attributes.Add("style", "word-break:break-all; word-wrap:break-word");
                    gvMessages.DataSource = regDB.GetCandidateSendGrievances("CANDIDATE", objSessionData.PID);
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
                            DateTime tempSentDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[4].Text);
                            string SentDate = tempSentDate.Day.ToString() + "/" + tempSentDate.Month.ToString() + "/" + tempSentDate.Year.ToString() + " " + String.Format("{0:T}", tempSentDate);
                            gvMessages.Rows[m].Cells[4].Text = SentDate;

                            //DateTime tempReplyDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[7].Text);
                            //string ReplyDate = tempReplyDate.Day.ToString() + "/" + tempReplyDate.Month.ToString() + "/" + tempReplyDate.Year.ToString() + " " + String.Format("{0:T}", tempReplyDate);
                            //gvMessages.Rows[m].Cells[7].Text = ReplyDate;

                            gvMessages.Rows[m].Cells[0].Text = j.ToString() + ".";
                            j++;
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

        protected void gvMessages_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string GrievanceID = gvMessages.Rows[e.NewSelectedIndex].Cells[1].Text;

                Response.Redirect("../CandidateModule/frmViewGrievance.aspx?GrievanceID=" + GrievanceID, true);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        private class DBUtility
        {
            public DataSet GetCandidateSendGrievances(string Flag, Int64 PID)
            {
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetCandidateSendGrievances", new SqlParameter[]
                        {
                            new SqlParameter("@Flag", Flag),
                            new SqlParameter("@PID", PID)
                        });
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }

}