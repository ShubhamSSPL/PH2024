using Synthesys.CMS.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class CMS_ListOfLinks : System.Web.UI.Page
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
        /* if (Session["UserLoginId"] == null)
             Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);*/
        int GroupId = int.Parse(Request.QueryString["gid"].ToString());
        DataSet ds = null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.GetListOfLinksOfaPanel(GroupId);
            if (ds.Tables.Count > 0)
            {
                tblLinks.Rows.Clear();
                HtmlTableRow tr;
                HtmlTableCell td;
                HyperLink hp;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Image img = new Image();
                        img.ImageUrl = "~/Images/brownbullet12.gif";
                        tr = new HtmlTableRow();
                        td = new HtmlTableCell();
                        td.VAlign = "top";
                        td.Controls.Add(img);
                        tr.Cells.Add(td);
                        td = new HtmlTableCell();
                        td.Align = "left";
                        if (int.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                        {
                            hp = new HyperLink();
                            hp.Text = ds.Tables[0].Rows[i]["MenuName"].ToString();
                            hp.NavigateUrl = ds.Tables[0].Rows[i]["MenuUrl"].ToString();
                            td.Controls.Add(hp);
                        }
                        else
                        {
                            td.InnerHtml = ds.Tables[0].Rows[i]["MenuName"].ToString();
                            td.Attributes.Add("class", "text");
                        }
                        td.VAlign = "top";
                        tr.Cells.Add(td);
                        tblLinks.Rows.Add(tr);

                        CBLinks.HeaderText = ds.Tables[0].Rows[i]["GroupDisplayText"].ToString();
                    }
                }
            }
        }
        catch (DataException dex)
        {
        }
        finally
        {
            if (ds != null)
            {
                ds.Dispose();
                ds = null;

            }

        }

    }
}
