using Synthesys.CMS.BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContentManagement_Content_Static : System.Web.UI.Page
{
    protected string PageTitle = string.Empty;
    string DetailID = string.Empty;
    string LangKey = string.Empty;
    DataSet ds = null;
    ShowMessage shInfo = null;
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
    private void Page_Load(object sender, System.EventArgs e)
    {

        shInfo = (ShowMessage)Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        #region Menu Related
        if (Request.QueryString["did"] != null &&
            (!Regex.IsMatch(Request.QueryString["did"].ToString(), @"\D")))
        {
            DetailID = Request.QueryString["did"].ToString();
        }
        else
        {
            DetailID = "0";
        }

        if (Request.Cookies["MultiLingual_Language"] == null)
        {
            LangKey = "English";
        }
        else
        {
            LangKey = Request.Cookies["MultiLingual_Language"].Value;
        }

        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.getContent(DetailID, LangKey);
            lblUpdationDate.Text = "";
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tdllblContentTitle.InnerHtml = ds.Tables[0].Rows[0]["MenuName"].ToString();
                    cbxContent.HeaderText = ":: " + ds.Tables[0].Rows[0]["MenuName"].ToString() + " ::";
                    InnerContent.Text = Convert.ToString(ds.Tables[0].Rows[0]["Content"]);
                    PageTitle = cbxContent.HeaderText;
                    lblUpdationDate.Text = ds.Tables[0].Rows[0]["ModifiedDate"].ToString();
                }
                else
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        tdllblContentTitle.InnerHtml = ds.Tables[1].Rows[0]["MenuName"].ToString();
                        cbxContent.HeaderText = ":: " + ds.Tables[1].Rows[0]["MenuName"].ToString() + " ::";
                        InnerContent.Text = Convert.ToString(ds.Tables[1].Rows[0]["Content"]);
                        PageTitle = cbxContent.HeaderText;
                        lblUpdationDate.Text = ds.Tables[1].Rows[0]["ModifiedDate"].ToString();
                    }
                }
            }
        }
        catch (DataException dex)
        {
            shInfo.SetMessage(dex.ToString(), ShowMessageType.TechnicalError);
        }
        finally
        {
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }
        }




        #endregion
    }
}
