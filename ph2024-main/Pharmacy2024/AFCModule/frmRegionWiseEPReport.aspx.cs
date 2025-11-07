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

namespace Pharmacy2024.AFCModule
{
    public partial class frmRegionWiseEPReport : System.Web.UI.Page
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

                    gvRegionWiseReport.DataSource = reg.GetRegionWiseConfirmationReport();
                    gvRegionWiseReport.DataBind();

                    Int64 TotalApplicationFormsConfirmed = 0;
                    Int64 TotalApplicationFormsPConfirmed = 0;
                    Int64 TotalApplicationFormsEAssign = 0;
                    Int64 TotalApplicationFormsEConfirmed = 0;
                    Int64 TotalApplicationFormsPending = 0;
                    Int64 TotalApplicationFormsPicked = 0;
                    Int64 TotalApplicationFormsReverted = 0;
                    Int64 TotalApplicationFormsGrivance = 0;
                    Int64 TotalApplicationFormsReSubmitted = 0;
                    Int64 TotalApplicationFormsNotResubmitted = 0;



                    for (Int32 i = 0; i < gvRegionWiseReport.Rows.Count; i++)
                    {
                        gvRegionWiseReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TotalApplicationFormsConfirmed += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[2].Text);
                        TotalApplicationFormsPConfirmed += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[3].Text);
                        TotalApplicationFormsEAssign += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[4].Text);
                        TotalApplicationFormsEConfirmed += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[5].Text);
                        TotalApplicationFormsPending += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[6].Text);
                        TotalApplicationFormsPicked += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[7].Text);
                        TotalApplicationFormsReverted += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[8].Text);
                        TotalApplicationFormsGrivance += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[9].Text);
                        TotalApplicationFormsReSubmitted += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[10].Text);
                        TotalApplicationFormsNotResubmitted += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[11].Text);
                    }

                    HyperLink hpr = new HyperLink();
                    hpr.NavigateUrl = "frmAFCWiseEPReport.aspx?RegionID=99";
                    hpr.Text = "<b>Total</b>";
                    gvRegionWiseReport.FooterRow.Cells[1].Controls.Add(hpr);
                    gvRegionWiseReport.FooterRow.Cells[2].Text = TotalApplicationFormsConfirmed.ToString();
                    gvRegionWiseReport.FooterRow.Cells[3].Text = TotalApplicationFormsPConfirmed.ToString();
                    gvRegionWiseReport.FooterRow.Cells[4].Text = TotalApplicationFormsEAssign.ToString();
                    gvRegionWiseReport.FooterRow.Cells[5].Text = TotalApplicationFormsEConfirmed.ToString();
                    gvRegionWiseReport.FooterRow.Cells[6].Text = TotalApplicationFormsPending.ToString();
                    gvRegionWiseReport.FooterRow.Cells[7].Text = TotalApplicationFormsPicked.ToString();
                    gvRegionWiseReport.FooterRow.Cells[8].Text = TotalApplicationFormsReverted.ToString();
                    gvRegionWiseReport.FooterRow.Cells[9].Text = TotalApplicationFormsGrivance.ToString();
                    gvRegionWiseReport.FooterRow.Cells[10].Text = TotalApplicationFormsReSubmitted.ToString();
                    gvRegionWiseReport.FooterRow.Cells[11].Text = TotalApplicationFormsNotResubmitted.ToString();
                    lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
    }
}