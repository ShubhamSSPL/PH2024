using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.FeeProcess
{
    public partial class BeforePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }

            Session["FeeGroupId"] = null;
            Session["PhaseId"] = null;
            Session["PayeeUserTypeId"] = null;
            Session["PayeeId"] = null;

            Session["FeeGroupId"] = "1";
            Session["PhaseId"] = "99";
            Session["PayeeUserTypeId"] = Session["UserTypeID"].ToString();
            Session["PayeeId"] = Session["UserID"].ToString();

            Response.Redirect("PaymentDetails.aspx", true);
        }
    }
}