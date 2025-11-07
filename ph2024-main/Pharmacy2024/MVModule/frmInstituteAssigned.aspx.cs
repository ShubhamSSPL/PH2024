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
    public partial class frmInstituteAssigned : System.Web.UI.Page
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
            DataSet ds = new DataSet();
            ds = reg.getRODashboardForMV(RegionName, 'V');
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            gvReport.DataSource = ds;
            gvReport.DataBind();
            GetColorCodes();
            ViewState["dirState"] = dt;
            ViewState["sortdr"] = "Asc";
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
                GetColorCodes();
            }
        }
        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        public void GetColorCodes()
        {
            for (int i = 0; i < gvReport.Rows.Count; i++)
            {
                Label txtState = new Label();
                txtState = (Label)(gvReport.Rows[i].FindControl("lblInstStatus"));
                if (txtState.Text == "Yes")
                {
                    gvReport.Rows[i].BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    //gvReport.Rows[i].BackColor = System.Drawing.Color.LightGray;
                }

            }
        }
    }
}