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

namespace Pharmacy2024.MVModule
{
    public partial class MVDashboardARA : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                gvDashboardFE.DataSource = reg.getARADashboardForMV('F');
                gvDashboardFE.DataBind();
                if (gvDashboardFE.Rows.Count > 0)
                {
                    TInst = 0;
                    TInstFeePaid = 0;
                    TRO = 0;
                    TDTE = 0;
                    TProposal = 0;
                    TAmt = 0;
                    for (Int32 i = 0; i < gvDashboardFE.Rows.Count-1; i++)
                    {
                        //gvDashboardFE.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TInst += Convert.ToInt64(gvDashboardFE.Rows[i].Cells[1].Text);
                        TInstFeePaid += Convert.ToInt64(gvDashboardFE.Rows[i].Cells[2].Text);
                        TAmt += Convert.ToDouble(gvDashboardFE.Rows[i].Cells[3].Text);
                        TRO += Convert.ToInt64(gvDashboardFE.Rows[i].Cells[4].Text);
                        TDTE += Convert.ToInt64(gvDashboardFE.Rows[i].Cells[5].Text);
                        TProposal += Convert.ToInt64(gvDashboardFE.Rows[i].Cells[6].Text);

                    }
                    gvDashboardFE.FooterRow.Cells[0].Text = "Total";
                    gvDashboardFE.FooterRow.Cells[1].Text = TInst.ToString();
                    gvDashboardFE.FooterRow.Cells[2].Text = TInstFeePaid.ToString();
                    gvDashboardFE.FooterRow.Cells[3].Text = TAmt.ToString();
                    gvDashboardFE.FooterRow.Cells[4].Text = TRO.ToString();
                    gvDashboardFE.FooterRow.Cells[5].Text = TDTE.ToString();
                    gvDashboardFE.FooterRow.Cells[6].Text = TProposal.ToString();
                }

                gvDashboardPH.DataSource = reg.getARADashboardForMV('P');
                gvDashboardPH.DataBind();
                DataSet ds = reg.getARADashboardForMV('P');
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TInst = Convert.ToInt64(ds.Tables[0].Rows[6][1].ToString());
                    TInstFeePaid = Convert.ToInt64(ds.Tables[0].Rows[6][2].ToString());
                    TAmt = Convert.ToDouble(ds.Tables[0].Rows[6][3].ToString());
                    TRO = Convert.ToInt64(ds.Tables[0].Rows[6][4].ToString());
                    TDTE = Convert.ToInt64(ds.Tables[0].Rows[6][5].ToString());
                    TProposal = Convert.ToInt64(ds.Tables[0].Rows[6][6].ToString());

                    gvDashboardPH.FooterRow.Cells[0].Text = "Total";
                    gvDashboardPH.FooterRow.Cells[1].Text = TInst.ToString();
                    gvDashboardPH.FooterRow.Cells[2].Text = TInstFeePaid.ToString();
                    gvDashboardPH.FooterRow.Cells[3].Text = TAmt.ToString();
                    gvDashboardPH.FooterRow.Cells[4].Text = TRO.ToString();
                    gvDashboardPH.FooterRow.Cells[5].Text = TDTE.ToString();
                    gvDashboardPH.FooterRow.Cells[6].Text = TProposal.ToString();
                }
              
                gvDashboardME.DataSource = reg.getARADashboardForMV('M');
                gvDashboardME.DataBind();
                if (gvDashboardME.Rows.Count > 0)
                {
                    TInst = 0;
                    TInstFeePaid = 0;
                    TRO = 0;
                    TDTE = 0;
                    TProposal = 0;
                    TAmt = 0;
                    for (Int32 i = 0; i < gvDashboardME.Rows.Count-1; i++)
                    {
                        //gvDashboardME.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TInst += Convert.ToInt64(gvDashboardME.Rows[i].Cells[1].Text);
                        TInstFeePaid += Convert.ToInt64(gvDashboardME.Rows[i].Cells[2].Text);
                        TAmt += Convert.ToDouble(gvDashboardME.Rows[i].Cells[3].Text);
                        TRO += Convert.ToInt64(gvDashboardME.Rows[i].Cells[4].Text);
                        TDTE += Convert.ToInt64(gvDashboardME.Rows[i].Cells[5].Text);
                        TProposal += Convert.ToInt64(gvDashboardME.Rows[i].Cells[6].Text);

                    }
                    gvDashboardME.FooterRow.Cells[0].Text = "Total";
                    gvDashboardME.FooterRow.Cells[1].Text = TInst.ToString();
                    gvDashboardME.FooterRow.Cells[2].Text = TInstFeePaid.ToString();
                    gvDashboardME.FooterRow.Cells[3].Text = TAmt.ToString();
                    gvDashboardME.FooterRow.Cells[4].Text = TRO.ToString();
                    gvDashboardME.FooterRow.Cells[5].Text = TDTE.ToString();
                    gvDashboardME.FooterRow.Cells[6].Text = TProposal.ToString();
                }
            }
        }

        protected void gvDashboardPH_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "Total")
                    e.Row.Visible = false;
            }
        }

        protected void gvDashboardFE_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "Total")
                    e.Row.Visible = false;
            }
        }

        protected void gvDashboardME_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "Total")
                    e.Row.Visible = false;
            }
        }
    }
}