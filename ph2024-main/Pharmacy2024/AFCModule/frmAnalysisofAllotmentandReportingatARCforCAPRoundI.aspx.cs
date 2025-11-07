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

namespace Pharmacy2024.AFCModule
{
    public partial class frmAnalysisofAllotmentandReportingatARCforCAPRoundI : System.Web.UI.Page
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
                    gvAnalysisofAllotmentandReportingatARCforCAPRoundI.Visible = false;
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
                if (ddlCAPRound.SelectedValue != "0")
                {
                    AnalysisofAllotmentandReportingatARCforCAPRoundI(Convert.ToInt32(ddlCAPRound.SelectedValue));
                }
                else
                {
                    gvAnalysisofAllotmentandReportingatARCforCAPRoundI.Visible = false;
                    btnexporttoExcel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void AnalysisofAllotmentandReportingatARCforCAPRoundI(int CAPRoundNo)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet ds = GetAnalysisofAllotmentandReportingatARCforCAPRoundI(CAPRoundNo);

                gvAnalysisofAllotmentandReportingatARCforCAPRoundI.DataSource = ds.Tables[0];
                gvAnalysisofAllotmentandReportingatARCforCAPRoundI.DataBind();
                gvAnalysisofAllotmentandReportingatARCforCAPRoundI.Visible = true;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnexporttoExcel.Visible = true;
                }
                else
                {
                    btnexporttoExcel.Visible = false;
                    shInfo.SetMessage("Record Not Found.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnexporttoExcel_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=AnalysisofAllotmentandReportingatARCforCAPRoundI.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvAnalysisofAllotmentandReportingatARCforCAPRoundI.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        public DataSet GetAnalysisofAllotmentandReportingatARCforCAPRoundI(int CapRound)
        {
            DBConnection db = new DBConnection();
            DataSet ds;
            try
            {
                ds = db.ExecuteDataSet("MHDTE_spAnalysisofAllotmentandReportingatARC", new SqlParameter[]
                {
                new SqlParameter("@CapRound", CapRound)
                });
            }
            finally
            {
                db.Dispose();
            }
            return ds;
        }
    }
}