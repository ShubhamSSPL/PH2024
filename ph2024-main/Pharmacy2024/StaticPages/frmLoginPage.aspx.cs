using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmLoginPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);

            HttpCookie cookie = new HttpCookie("Theme", "default");
            cookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(cookie);

            Page.Theme = "default";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}