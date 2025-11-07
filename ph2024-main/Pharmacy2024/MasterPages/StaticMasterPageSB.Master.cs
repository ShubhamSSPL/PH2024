using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.MasterPages
{
    public partial class StaticMasterPageSB : System.Web.UI.MasterPage
    {
        HttpCookie cookie = null;
        public string AdmissionYear = Global.AdmissionYear;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.Header.Title = ConfigurationManager.AppSettings["WebSite_Title"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!IsPostBack)
                {
                    Session.Clear();
                    Session.Abandon();
                }
        }
    }
}