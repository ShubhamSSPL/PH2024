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
using System.Text;
using Synthesys.Controls;
using System.Collections;

namespace Pharmacy2024.MVModule
{
    public partial class ARAInstStats_NotVerified : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        private DataSet ds;
        private ShowMessage shInfo;
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
            Int64 TInst = 0, TInstFeePaid = 0, TRO = 0, TDTE = 0, TProposal = 0;
            Double TAmt = 0;
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (!IsPostBack)
            {
                gvReport.DataSource = reg.ARADashboardReport("P");
                gvReport.DataBind();
                if (gvReport.Rows.Count > 0)
                {
                    TInst = 0;
                    TInstFeePaid = 0;
                    TRO = 0;
                    TDTE = 0;
                    TProposal = 0;
                    TAmt = 0;
                    for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                    {
                        //gvDashboardFE.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TInst += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                        TInstFeePaid += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);
                        TAmt += Convert.ToDouble(gvReport.Rows[i].Cells[7].Text);
                        TRO += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                        TDTE += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);
                        TProposal += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);

                    }
                    gvReport.FooterRow.Cells[4].Text = "Total";
                    gvReport.FooterRow.Cells[5].Text = TInst.ToString();
                    gvReport.FooterRow.Cells[6].Text = TInstFeePaid.ToString();
                    gvReport.FooterRow.Cells[7].Text = TAmt.ToString();
                    gvReport.FooterRow.Cells[8].Text = TRO.ToString();
                    gvReport.FooterRow.Cells[9].Text = TDTE.ToString();
                    gvReport.FooterRow.Cells[10].Text = TProposal.ToString();
                }
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.FindControl("lblRowNumber") as Label).Text = (e.Row.RowIndex + 1).ToString();
            }
        }
    }
}