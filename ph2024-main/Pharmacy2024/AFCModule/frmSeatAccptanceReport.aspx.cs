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
    public partial class frmSeatAccptanceReport : System.Web.UI.Page
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
                    DataSet ds = GetSeatAccptanceReport();
                    gvSeatAccptanceReport.DataSource = ds;
                    gvSeatAccptanceReport.DataBind();

                    if (ds.Tables[0].Rows.Count > 0)
                        btnexporttoExcel.Visible = true;
                    else
                    {
                        btnexporttoExcel.Visible = false;
                        shInfo.SetMessage("Record Not Found.", ShowMessageType.Information);
                    }

                    lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void btnexporttoExcel_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=HSCMarkChangeReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvSeatAccptanceReport.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        public DataSet GetSeatAccptanceReport()
        {
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_SeatAccptanceReport", new SqlParameter[] { });
            db.Dispose();
            return ds;
        }
    }
}