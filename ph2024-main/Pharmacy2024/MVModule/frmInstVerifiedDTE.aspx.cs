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
    public partial class frmInstVerifiedDTE : System.Web.UI.Page
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
                RegionName = Request.QueryString["RegionName"].ToString();

                gvReport.DataSource = reg.getRODashboardForMV(RegionName, 'E');
                gvReport.DataBind();

                if (gvReport.Rows.Count == 0)
                {
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('No Institute pending for RO verification or No institute verified by SO.');", true);
                    lblMsg.Text = "Institutes verified by DTE not found.";
                }
            }
        }
    }
}