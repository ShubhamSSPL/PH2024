using Microsoft.Reporting.WebForms;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.Report
{
    public partial class MeritListReport : System.Web.UI.Page
    {
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

        }
        protected void ddlMeritType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection dBConnection = new DBConnection();
            DataSet reportData = dBConnection.ExecuteDataSet("sp_GetMeritListDATA", new SqlParameter[] { new SqlParameter("@MeritType", ddlMeritType.SelectedValue) });
            dBConnection.Dispose();
            if (ddlMeritType.SelectedValue == "MH")
            {
                reportViewer.LocalReport.ReportPath = Server.MapPath("~/reports/" + "MHMeritList.rdlc");
            }
            else
            {
                reportViewer.LocalReport.ReportPath = Server.MapPath("~/reports/" + "AIMeritList.rdlc");
            }

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", reportData.Tables[0]));
            reportViewer.Visible = true;
            this.reportViewer.LocalReport.Refresh();
        }
    }
}