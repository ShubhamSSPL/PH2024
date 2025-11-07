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

namespace Pharmacy2024.E_FCModule
{
    public partial class frmRegionWiseApplicationFormListForFCVerificationReport : System.Web.UI.Page
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

                    gvRegionWiseReport.DataSource = reg.getRegionWiseApplicationFormListForFCVerification();
                    gvRegionWiseReport.DataBind();

                    Int64 TotalApplicationFormsConfirmed = 0;

                    for (Int32 i = 0; i < gvRegionWiseReport.Rows.Count; i++)
                    {
                        gvRegionWiseReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TotalApplicationFormsConfirmed += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[2].Text);
                    }

                    HyperLink hpr = new HyperLink();
                    hpr.NavigateUrl = "frmAFCWiseApplicationFormListForFCVerificationReport.aspx?RegionID=99";
                    hpr.Text = "<b>Total</b>";
                    gvRegionWiseReport.FooterRow.Cells[1].Controls.Add(hpr);
                    gvRegionWiseReport.FooterRow.Cells[2].Text = TotalApplicationFormsConfirmed.ToString();
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