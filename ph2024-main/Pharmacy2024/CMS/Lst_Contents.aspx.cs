using AjaxPro;
using Synthesys.CMS.BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class CMS_Lst_Contents : System.Web.UI.Page
{
    ShowMessage shInfo = null;
    DataSet ds = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        shInfo = (ShowMessage)Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        AjaxPro.Utility.RegisterTypeForAjax(typeof(CMS_Lst_Contents));
        ((ExpanderMenu)Master.FindControl(ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"])).ShowFormLinks = true;
        ((ExpanderMenu)Master.FindControl(ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"])).ShowFormNumber = false;
        ((ExpanderMenu)Master.FindControl(ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"])).ShowFadingEffect = true;
        ((ExpanderMenu)Master.FindControl(ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"])).FormType = 3;
        if (!IsPostBack)
        {
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.GetLanguages();
                if (ds.Tables.Count > 0)
                {
                    ddlLanguage.DataSource = ds.Tables[0];
                    ddlLanguage.DataValueField = "LanguageId";
                    ddlLanguage.DataTextField = "LanguageName";
                    ddlLanguage.DataBind();
                    ddlLanguage.Items.Insert(0, "-- Select --");
                    ddlLanguage.SelectedIndex = 0;
                }
            }
            catch (DataException dex)
            {

                shInfo.SetMessage(dex);
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

    [AjaxMethod]
    public DataSet FillContent(string LanguageID)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetContents(Convert.ToInt32(LanguageID));
    }
}
