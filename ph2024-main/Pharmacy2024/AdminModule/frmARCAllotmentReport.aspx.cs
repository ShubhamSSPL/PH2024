using BusinessLayer;
using Synthesys.Controls;
using SynthesysDAL;
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

namespace Pharmacy2024.AdminModule
{
    public partial class frmARCAllotmentReport : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {


                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlCAPRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                tblDashboard.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlEntranceExamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                tblDashboard.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void ddlQualifyingExamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                tblDashboard.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                DataSet dsDashboard = new DBUtilityAllotmentReport().getARCCountReport(ddlCAPRound.SelectedValue, ddlEntranceExamType.SelectedValue, ddlQualifyingExamType.SelectedValue, "0", "0", "0", "0");
                if (dsDashboard.Tables.Count > 0)
                {
                    if (dsDashboard.Tables[0].Rows.Count > 0)
                    {
                        tblDashboard.Visible = true;

                        gvApplicationStatusReport.DataSource = dsDashboard.Tables[0];
                        gvApplicationStatusReport.DataBind();
                    }
                    else
                    {
                        tblDashboard.Visible = false;
                        shInfo.SetMessage("No records to display.", ShowMessageType.Information);
                    }
                }
                else
                {
                    tblDashboard.Visible = false;
                    shInfo.SetMessage("No records to display.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string fileName = "ARCAllotmentReport_" + DateTime.Now.ToString() + ".xls";
            string attachment = "attachment; filename=" + fileName;
            //string attachment = "attachment; filename=CompositeReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvApplicationStatusReport.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }

    public class DBUtilityAllotmentReport
    {
        public DataSet getARCCountReport(string cAPRound, string entranceExamType, string qualifyingExam, string seatAcceptanceType, string seatAcceptanceStatus, string documentType, string allotmentCancelledStatus)
        {

            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetARCCountReport", new SqlParameter[]
                  {
                    new SqlParameter("@CAPRound",cAPRound),
                    new SqlParameter("@EntranceExamType",entranceExamType),
                    new SqlParameter("@QualifyingExam",qualifyingExam),
                    new SqlParameter("@SeatAcceptanceType",seatAcceptanceType),
                    new SqlParameter("@SeatAcceptanceStatus",seatAcceptanceStatus),
                    new SqlParameter("@DocumentType",documentType),
                    new SqlParameter("@AllotmentCancelledStatus",allotmentCancelledStatus)
                  });
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}