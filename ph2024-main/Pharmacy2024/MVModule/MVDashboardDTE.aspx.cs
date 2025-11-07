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
    public partial class MVDashboardDTE : System.Web.UI.Page
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
                string RegionName = "";
                if (Request.QueryString["RegionName"] != null)
                {
                    RegionName = Request.QueryString["RegionName"].ToString();
                }
                else
                {
                    RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                }

                gvDashboard.DataSource = reg.getDTEDashboardForMV('R');
                gvDashboard.DataBind();

                gvDashboardSO.DataSource = reg.getDTEDashboardForMV('S');
                gvDashboardSO.DataBind();

                for (Int32 i = 0; i < gvDashboardSO.Rows.Count; i++)
                {
                    //gvDashboardSO.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    if (Convert.ToInt64(gvDashboardSO.Rows[i].Cells[6].Text) != 0)
                    {
                        Label lblPending = new Label();
                        lblPending = (Label)(gvDashboardSO.Rows[i].FindControl("lblPending"));
                        lblPending.Text = (Convert.ToInt64(gvDashboardSO.Rows[i].Cells[5].Text) * 100 / Convert.ToInt64(gvDashboardSO.Rows[i].Cells[6].Text)).ToString() + "%";
                    }
                    else
                    {
                        Label lblPending = new Label();
                        lblPending = (Label)(gvDashboardSO.Rows[i].FindControl("lblPending"));
                        lblPending.Text = "0%";
                    }
                }
            }
        }
    }
}