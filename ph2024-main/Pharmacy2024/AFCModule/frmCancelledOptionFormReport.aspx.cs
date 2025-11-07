using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmCancelledOptionFormReport : System.Web.UI.Page
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
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                string UserLoginID = Session["UserLoginID"].ToString();
                Int32 CAPRound = Convert.ToInt32(Request.QueryString["CAPRound"].ToString());

                if (CAPRound == 1)
                {
                    ContentTable1.HeaderText = "Cancelled Option Form Report (CAP Round-I)";
                }
                else if (CAPRound == 2)
                {
                    ContentTable1.HeaderText = "Cancelled Option Form Report (CAP Round-II)";
                }
                else if (CAPRound == 3)
                {
                    ContentTable1.HeaderText = "Cancelled Option Form Report (CAP Round-III)";
                }
                else if (CAPRound == 4)
                {
                    ContentTable1.HeaderText = "Cancelled Option Form Report (CAP Round-IV)";
                }

                gvReport.DataSource = reg.getCancelledOptionFormReport(UserTypeID, UserLoginID, CAPRound);
                gvReport.DataBind();

                for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                {
                    gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                }

                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
            }
        }
    }
}