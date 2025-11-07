using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.FeeProcess
{
    public partial class OfflineAfterResponse : System.Web.UI.Page
    {
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
            if (!IsPostBack)
            {
                try
                {

                    string errCode = Request.QueryString["err"].ToString();
                    lblPaymentStatus.Text = "";

                    if (errCode == "E00327")
                    {
                        lblPaymentStatus.Text = "Cash Challan has been generated";
                    }
                    else if (errCode == "E00328")
                    {
                        lblPaymentStatus.Text = "Cheque Challan has been generated";
                    }
                    else if (errCode == "E00329")
                    {
                        lblPaymentStatus.Text = "NEFT Challan has been generated";
                    }

                }
                catch
                {
                    lblPaymentStatus.Text = "Challan has been generated";
                    ///lblSessionStatus.Text = "You session has been expired. Please login again.";
                    //blSessionStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["WebSite_LoginHomePage"].ToString(), true);
        }
    }
}