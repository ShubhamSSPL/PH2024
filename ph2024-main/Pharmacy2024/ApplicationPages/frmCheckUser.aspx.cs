using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ApplicationPages
{
    public partial class frmCheckUser : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string UserLoginID = Request.QueryString["UserLoginID"].ToString();
                string Code = Request.QueryString["Code"].ToString();

                if (UserLoginID.GetHashCode().ToString() == Code)
                {
                    DataSet ds = reg.checkUser(UserLoginID);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                        {
                            Session["UserTypeID"] = ds.Tables[0].Rows[0]["UserTypeID"].ToString();
                            Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                            Session["UserLoginID"] = ds.Tables[0].Rows[0]["UserLoginID"].ToString();
                            Session["UserSessionID"] = ds.Tables[0].Rows[0]["UserSessionID"].ToString();

                            Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                        }
                        else
                        {
                            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                        }
                    }
                }
                else
                {
                    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}