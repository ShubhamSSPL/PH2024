using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using Synthesys.DataAcess;
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

namespace Pharmacy2024.MVModule
{
    public partial class ARAReportSelection : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string ftrCode = "";
            if (rbtFilterA.Checked == true)
                ftrCode = "A";
            else if (rbtFilterB.Checked == true)
                ftrCode = "B";
            else if (rbtFilterC.Checked == true)
                ftrCode = "C";
            else if (rbtFilterD.Checked == true)
                ftrCode = "D";
            else if (rbtFilterE.Checked == true)
                ftrCode = "E";
            else if (rbtFilterG.Checked == true)
                ftrCode = "G";
            else 
                ftrCode = "H";

            Response.Write("<script>");
            Response.Write("window.open('ARAReports.aspx?FilterCode=" + ftrCode + "','_blank')");
            Response.Write("</script>");
        }
    }
}