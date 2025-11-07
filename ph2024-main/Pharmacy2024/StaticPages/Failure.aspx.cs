using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class Failure : System.Web.UI.Page
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
            if (Request["paystatus"] != null && Request["bref"] != null)
            {
                //PayuGateway objPay = new PayuGateway();
                //DataSet ds = objPay.GetPaymentDetails(Request["paystatus"], Request["bref"]);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    lblResult.Text = "Your transaction has been successful, please login to continue.";
                //    lblResult.ForeColor = System.Drawing.Color.Green;
                //}
                //else
                //{
                //    lblResult.Text = "Your transaction has been failed, please try again later.";
                //    lblResult.ForeColor = System.Drawing.Color.Red;
                //}

            }
            else
            {
                lblResult.Text = "Your transaction has been failed, please try again later.";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}