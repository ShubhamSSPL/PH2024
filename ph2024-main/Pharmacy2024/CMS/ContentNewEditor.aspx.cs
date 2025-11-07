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
public partial class ContentManagement_ContentEditor : System.Web.UI.Page
{
    ShowMessage showMsg = null;
    int DetailID, ContentId;
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
        if (Session["UserLoginId"] == null)
            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        DetailID = int.Parse(Request.QueryString["did"].ToString());

        ((HiddenField)Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "4";

        showMsg = (ShowMessage)Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        if (!IsPostBack)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.GetLanguages(DetailID);
                if (ds.Tables.Count > 0)
                {
                    DdlLanguage.DataSource = ds.Tables[0];
                    DdlLanguage.DataValueField = "LanguageId";
                    DdlLanguage.DataTextField = "LanguageName";
                    DdlLanguage.DataBind();
                    ListItem li = new ListItem("-- Select --", "0");
                    DdlLanguage.Items.Insert(0, li);

                    if (ds.Tables[1].Rows.Count > 0)
                        DdlLanguage.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
                    else DdlLanguage.SelectedIndex = 1;
                    GetAddedContents();
                }
            }
            catch (DataException dex)
            {

                showMsg.SetMessage(dex);
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                    ds = null;

                }

            }
            LoadData(DetailID);
        }
        else
        {
            // LoadData(DetailID);

        }

    }
    protected void ddlContents_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlLanguage.SelectedIndex = 0;
        Content.Value = "";


    }
    protected void DdlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = null;
        if (ddlContents.SelectedIndex == 0)
            LoadData(DetailID);
        else
        {
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.GetContentsOfAddedContent(Convert.ToInt32(ddlContents.SelectedValue), Convert.ToInt32(DdlLanguage.SelectedValue));
                if (ds.Tables[0].Rows.Count > 0)
                    Content.Value = ds.Tables[0].Rows[0]["Content"].ToString();
                else Content.Value = "";
            }
            catch (DataException ex)
            {
                showMsg.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
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
        // Content.Value = "";
        //LoadData(DetailID);
        //GetAddedContents();
        Literal li = new Literal();
        li.Text = hddSitemap.Value;
        SiteMap.Controls.Clear();
        SiteMap.Controls.AddAt(0, li);
    }

    public void LoadData(int DetailID)
    {
        LblRecordModified.Text = "";
        DataSet ds = null;
        Literal li = new Literal();


        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.GetContent(DetailID, int.Parse(DdlLanguage.SelectedValue));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Content.Value = ds.Tables[0].Rows[0]["Content"].ToString();
                    DdlLanguage.SelectedValue = ds.Tables[0].Rows[0]["ContentLangKey"].ToString();
                    //GetAddedContents(Convert.ToInt32(ds.Tables[0].Rows[0]["ContentLangKey"].ToString()));
                    LblRecordModified.Text = ds.Tables[0].Rows[0]["RecordModifiedOnDate"].ToString();

                    // DdlLanguage.SelectedValue=Session["LanguageId"].ToString();
                }
                else
                {
                    Content.Value = "";
                    //GetAddedContents(1);
                }
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                li.Text = "Manage Content :" + ds.Tables[1].Rows[0][0].ToString();
                hddSitemap.Value = li.Text;
                SiteMap.Controls.Clear();
                SiteMap.Controls.AddAt(0, li);
            }

        }
        catch (DataException dex)
        {

            showMsg.SetMessage(dex);
        }
        finally
        {
            if (ds != null)
            {
                ds.Dispose();
                ds = null;

            }

        }

        //trLingualEditor.Visible = (DdlLanguage.SelectedValue != "1" ? true : false);
    }

    private void GetAddedContents()
    {
        DataSet ds = null;


        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.GetAddedContents();
            if (ds.Tables.Count > 0)
            {
                ddlContents.DataSource = ds.Tables[0];
                ddlContents.DataValueField = "ContentId";
                ddlContents.DataTextField = "ContentName";
                ddlContents.DataBind();
                ListItem ll = new ListItem("--None--", "0");
                ddlContents.Items.Insert(0, ll);
                ddlContents.SelectedIndex = 0;
            }
        }
        catch (DataException dex)
        {

            showMsg.SetMessage(dex);
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

    protected void Btn_Save_Click(object sender, EventArgs e)
    {

        //string editorText = Content.Value;
        string editorText = Content.Value.Split(new string[] { "<body>" }, StringSplitOptions.None)[1].Split(new string[] { "</body>" }, StringSplitOptions.None)[0].Replace("\r", "").Replace("\n", "").Replace("\t", "");
        DataSet ds = null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.SaveContent(DetailID, int.Parse(DdlLanguage.SelectedValue), editorText, Session["UserLoginId"].ToString(), 0);
            LoadData(DetailID);
            showMsg.SetMessage("Your content is saved", ShowMessageType.Information);
        }
        catch (DataException dex)
        {

            showMsg.SetMessage(dex);
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
    protected void Btn_Clear_Click(object sender, EventArgs e)
    {
        Content.Value = "";
    }
}
