using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Synthesys.CMS.BusinessLayer;

public partial class CMS_AddHeaderText : System.Web.UI.Page
    {
    private BusinessServiceImp sr = new BusinessServiceImp();
    //protected DropDownList DdlLanguage;
    //protected Button btnSave;
    //protected HtmlTextArea Content;
    //protected ContentBox cbxContentManagement;
    private ShowMessage shInfo;

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    protected HttpApplication ApplicationInstance
    {
        get
        {
            return this.Context.ApplicationInstance;
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        this.OnInit(e);
        if (this.Request.Cookies["Theme"] == null)
            this.Page.Theme = "default";
        else
            this.Page.Theme = this.Request.Cookies["Theme"].Value;
    }

    protected void DdlLanguage_Change(object sender, EventArgs e)
    {
        this.GetData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (this.Session["UserLoginId"] == null)
            this.Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        ((HiddenField)this.Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "4";
        DataSet dataSet = (DataSet)null;
        this.shInfo = (ShowMessage)this.Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        if (this.IsPostBack)
            return;
        try
        {
            dataSet = sr.GetLanguages();
            if (dataSet.Tables.Count > 0)
            {
                this.DdlLanguage.DataSource = (object)dataSet.Tables[0];
                this.DdlLanguage.DataValueField = "LanguageId";
                this.DdlLanguage.DataTextField = "LanguageName";
                this.DdlLanguage.DataBind();
                this.DdlLanguage.Items.Insert(0, new ListItem("-- Select --", "0"));
                this.DdlLanguage.SelectedIndex = 1;
            }
            this.GetData();
        }
        catch (DataException ex)
        {
            this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
        }
        finally
        {
            dataSet?.Dispose();
        }
    }

    private void GetData()
    {
        DataSet dataSet = (DataSet)null;
        try
        {
            dataSet = this.sr.GetHeaderText(Convert.ToInt32(this.DdlLanguage.SelectedValue));
            if (dataSet.Tables[0].Rows.Count > 0)
                this.Content.Value = dataSet.Tables[0].Rows[0][0].ToString();
            else
                this.Content.Value = "";
        }
        catch (DataException ex)
        {
        }
        finally
        {
            dataSet?.Dispose();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.DdlLanguage.SelectedIndex != 0)
            this.sr.SetHeaderText(this.Content.Value.Split(new string[1]
            {
        "<body>"
            }, StringSplitOptions.None)[1].Split(new string[1]
            {
        "</body>"
            }, StringSplitOptions.None)[0].Replace("<p>", "<div>").Replace("</p>", "</div>").Replace("\r", "").Replace("\n", "").Replace("\t", ""), Convert.ToInt32(this.DdlLanguage.SelectedValue));
        else
            this.shInfo.SetMessage("Select Language !!", ShowMessageType.UserError);
    }
}
