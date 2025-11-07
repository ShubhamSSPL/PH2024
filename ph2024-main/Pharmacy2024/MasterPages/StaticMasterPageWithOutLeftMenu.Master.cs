using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.MasterPages
{
    public partial class StaticMasterPageWithOutLeftMenu : System.Web.UI.MasterPage
    {
        HttpCookie cookie = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.Header.Title = ConfigurationManager.AppSettings["WebSite_Title"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.FilePath.Contains("StaticPages/HomePage"))
            {
                string strPreviousPage = "";
                if (Request.UrlReferrer != null)
                {
                    strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                }
                if (strPreviousPage == "")
                {
                    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                }
                if (!IsPostBack)
                {
                    lblIPAddress.Text = UserInfo.GetServerIPAddress();

                    Session.Clear();
                    Session.Abandon();
                }
            }
        }
    }
}