using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmviewpdfmock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            else
            {
                Int64 InstId = Convert.ToInt64(Request.QueryString["InstId"].ToString());
                if (Convert.ToString(Session["UserLoginID"]) == Convert.ToString(InstId))
                {
                    if (Convert.ToInt64(Request.QueryString["Rnd"].ToString()) == 1)
                    {
                        string url = "https://ph2024.mahacet.org/CAP-I_Mock/CAPR-I_" + InstId + ".pdf";
                        iframeDiv.Controls.Add(new LiteralControl("<iframe height='700px' width='100%'src=" + url + "></iframe><br />"));
                    }
                    else if (Convert.ToInt64(Request.QueryString["Rnd"].ToString()) == 2)
                    {
                        string url = "https://ph2024.mahacet.org/CAP-II_Mock/CAPR-II_" + InstId + ".pdf";
                        iframeDiv.Controls.Add(new LiteralControl("<iframe height='700px' width='100%'src=" + url + "></iframe><br />"));
                    }
                    else if (Convert.ToInt64(Request.QueryString["Rnd"].ToString()) == 3)
                    {
                        string url = "https://ph2024.mahacet.org/CAP-III_Mock/CAPR-III_" + InstId + ".pdf";
                        iframeDiv.Controls.Add(new LiteralControl("<iframe height='700px' width='100%'src=" + url + "></iframe><br />"));
                    }
                }
                else
                {
                    Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                }
                        
            }
        }
    }
}