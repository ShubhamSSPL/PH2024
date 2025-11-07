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

public partial class CMS_AddNewContent : System.Web.UI.Page
{
    ShowMessage showMsg = null;
    int ContentId;
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
        if (Session["UserTypeID"].ToString() != "21")
        {
            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        }
        ContentId = int.Parse(Request.QueryString["cid"].ToString());

        ((HiddenField)Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "4";

        showMsg = (ShowMessage)Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        if (!IsPostBack)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.GetLanguages();
                if (ds.Tables.Count > 0)
                {
                    DdlLanguage.DataSource = ds.Tables[0];
                    DdlLanguage.DataValueField = "LanguageId";
                    DdlLanguage.DataTextField = "LanguageName";
                    DdlLanguage.DataBind();
                    DdlLanguage.Items.Insert(0, "-- Select --");
                    DdlLanguage.SelectedIndex = 1;
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
            LoadContent(ContentId, DdlLanguage.SelectedValue);
        }
    }

    private void LoadContent(int ContentId, string LanguageKey)
    {
        DataSet ds = null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.LoadContent(ContentId, int.Parse(LanguageKey));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Content.Value = ds.Tables[0].Rows[0]["Content"].ToString();
                    LblRecordModified.Text = ds.Tables[0].Rows[0]["RecordModifiedOnDate"].ToString();
                    TxtContentName.Text = ds.Tables[0].Rows[0]["ContentName"].ToString();
                }
                else
                {
                    Content.Value = "";
                }
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

        // trLingualEditor.Visible = (LanguageKey != "1" ? true : false);
    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        //string editorText = Content.Value;
        string editorText = Content.Value.Split(new string[] { "<body>" }, StringSplitOptions.None)[1].Split(new string[] { "</body>" }, StringSplitOptions.None)[0].Replace("\r", "").Replace("\n", "").Replace("\t", "");
        DataSet ds = null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.SaveContentByContentId(ContentId, int.Parse(DdlLanguage.SelectedValue), editorText, Session["UserLoginId"].ToString(), TxtContentName.Text);
            LoadContent(ContentId, DdlLanguage.SelectedValue);

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
    protected void DdlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadContent(ContentId, DdlLanguage.SelectedValue);

    }
}
