using BusinessLayer;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI;


namespace Pharmacy2024.MasterPages
{
    public partial class DynamicMasterPageWithOutLeftMenu : System.Web.UI.MasterPage
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        HttpCookie cookie = null;
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));

            if (Request.QueryString["Flag"] != null)
            {
                div_menubg.Visible = false;
            }
        }
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

                    if (Session["UserTypeID"] != null)
                    {
                        lblUserName.Text = Session["UserLoginID"].ToString();
                    }
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {

            Int64 SessionID = Convert.ToInt64(Session["UserSessionID"]);
            reg.saveLogOutDateTime(SessionID);

            Session.Clear();
            Session.Abandon();

            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"].ToString(), true);
        }
    }
}