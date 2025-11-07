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
    public partial class frmSOList : System.Web.UI.Page
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
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                refreshdata();
            }
        }
        public void refreshdata()
        {
            string RegionName = "";
            RegionName = Request.QueryString["RegionName"].ToString();
            //if (Request.QueryString["RegionName"] != null)
            //{
            //    RegionName = Request.QueryString["RegionName"].ToString();
            //}
            //else
            //{
            //    RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
            //}
            DataSet ds = new DataSet();
            ds = reg.getRODashboardForMV(RegionName, 'S');
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            gvReport.DataSource = ds;
            gvReport.DataBind();
            ViewState["dirState"] = dt;
            ViewState["sortdr"] = "Asc";

            Int64 TInstitute = 0, TCandidate = 0, TRecommend = 0, TNotRecommend = 0, TPending =0, PerPending = 0;
            for (Int32 i = 0; i < gvReport.Rows.Count; i++)
            {
                gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                TInstitute += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                TRecommend += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);
                TNotRecommend += Convert.ToInt64(gvReport.Rows[i].Cells[7].Text);
                TPending += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                if(Convert.ToInt64(gvReport.Rows[i].Cells[9].Text)!=0)
                {
                    Label lblPending = new Label();
                    lblPending = (Label)(gvReport.Rows[i].FindControl("lblPending"));
                    lblPending.Text = (Convert.ToInt64(gvReport.Rows[i].Cells[8].Text) * 100 / Convert.ToInt64(gvReport.Rows[i].Cells[9].Text)).ToString();
                }
                else
                {
                    Label lblPending = new Label();
                    lblPending = (Label)(gvReport.Rows[i].FindControl("lblPending"));
                    lblPending.Text = "0%";
                }
                TCandidate += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);
            }

            if (TCandidate != 0)
            {
                PerPending = TPending * 100 / TCandidate;
            }
            
            gvReport.FooterRow.Cells[4].Text = "Total";
            gvReport.FooterRow.Cells[5].Text = TInstitute.ToString();
            gvReport.FooterRow.Cells[6].Text = TRecommend.ToString();
            gvReport.FooterRow.Cells[7].Text = TNotRecommend.ToString();
            gvReport.FooterRow.Cells[8].Text = TPending.ToString();
            gvReport.FooterRow.Cells[9].Text = TCandidate.ToString();
            gvReport.FooterRow.Cells[10].Text = PerPending.ToString()+"%"; 
        }
        protected void gvReport_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                gvReport.DataSource = dtrslt;
                gvReport.DataBind();

                Int64 TInstitute = 0, TCandidate = 0, TRecommend = 0, TNotRecommend = 0, TPending = 0, PerPending = 0;
                for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                {
                    gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    TInstitute += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                    TRecommend += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);
                    TNotRecommend += Convert.ToInt64(gvReport.Rows[i].Cells[7].Text);
                    TPending += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                    if (Convert.ToInt64(gvReport.Rows[i].Cells[9].Text) != 0)
                    {
                        Label lblPending = new Label();
                        lblPending = (Label)(gvReport.Rows[i].FindControl("lblPending"));
                        lblPending.Text = (Convert.ToInt64(gvReport.Rows[i].Cells[8].Text) * 100 / Convert.ToInt64(gvReport.Rows[i].Cells[9].Text)).ToString();
                    }
                    else
                    {
                        Label lblPending = new Label();
                        lblPending = (Label)(gvReport.Rows[i].FindControl("lblPending"));
                        lblPending.Text = "0%";
                    }
                    TCandidate += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);
                }

                if (TCandidate != 0)
                {
                    PerPending = TPending * 100 / TCandidate;
                }
                
                gvReport.FooterRow.Cells[4].Text = "Total";
                gvReport.FooterRow.Cells[5].Text = TInstitute.ToString();
                gvReport.FooterRow.Cells[6].Text = TRecommend.ToString();
                gvReport.FooterRow.Cells[7].Text = TNotRecommend.ToString();
                gvReport.FooterRow.Cells[8].Text = TPending.ToString();
                gvReport.FooterRow.Cells[9].Text = TCandidate.ToString();
                gvReport.FooterRow.Cells[10].Text = PerPending.ToString();
            }
        }
    }
}