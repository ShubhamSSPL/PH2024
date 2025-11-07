using BusinessLayer;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024
{
    public partial class _Default : Page 
    {
        private readonly IBusinessService _IbusinessService = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect(ConfigurationManager.AppSettings["WebSite_DefaultPage"], true);
            Response.Redirect(ConfigurationManager.AppSettings["WebSite_DefaultPage"], false);
        }
    }
}