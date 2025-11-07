using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Synthesys.Controls;
using AjaxPro;
using Synthesys.MenuManagement.BusinessLayer;
using System.Data;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.UI.HtmlControls;
using System.Web.Profile;
using System.Text;

//namespace Synthesys.MenuManagement.MenuManagement
//{
public partial class MenuManagement_MenuMgt_New : System.Web.UI.Page
    {
    protected DropDownList ddlUserType;
    protected DropDownList ddlGroup;
    protected Button btnSaveAll;
    protected ContentBox ccbMenu;
    protected RadioButtonList rbOptions;
    protected DropDownList ddlModule;
    protected DropDownList ddlMenu;
    protected HtmlInputText txtLinkName;
    protected HtmlInputCheckBox chkAddEditIsActive;
    protected HtmlInputCheckBox chkAddEditNewLink;
    protected HtmlInputCheckBox chkScheduleLink;
    protected HtmlInputText txtStartDt;
    protected HtmlInputText txtEndDt;
    protected HtmlInputCheckBox chkmultiLingualLink;
    protected Label lblAddEditOrder;
    protected Button btnLinkSave;
    protected HtmlInputText txtContentMenuName;
    protected HtmlInputCheckBox ContentIsActive;
    protected HtmlInputCheckBox ContentIsNew;
    protected HtmlInputCheckBox chkScheduleContent;
    protected HtmlInputText txtContentStartDate;
    protected HtmlInputText txtContentEndDate;
    protected HtmlInputCheckBox chkmultiLingualContent;
    protected Label lblContentOrder;
    protected Button btnContentSave;
    protected Button BbtnContentSave2;
    protected TextBox txtText;
    protected HtmlInputCheckBox chkTextIsActive;
    protected HtmlInputCheckBox chkTextIsNew;
    protected HtmlInputCheckBox chkScheduleText;
    protected HtmlInputText TextStartDt;
    protected HtmlInputText TextEndDt;
    protected HtmlInputCheckBox chkmultilingualText;
    protected Label lblTextOrder;
    protected Button Button1;
    protected TextBox txtHyperlinkName;
    protected TextBox txtHyperlink;
    protected HtmlInputCheckBox chkHyperlinkIsActive;
    protected HtmlInputCheckBox chkHyperlinkIsNew;
    protected HtmlInputCheckBox chkSchedulehyperlink;
    protected HtmlInputText HyperlinkStartDt;
    protected HtmlInputText HyperlinkEndDt;
    protected HtmlInputCheckBox chkmultilingualHyperlink;
    protected Label lblHyperlinkOrder;
    protected Button Button3;
    protected TextBox txtFilelinkName;
    protected DropDownList ddlFileList;
    protected HtmlInputCheckBox chkFilelinkIsActive;
    protected HtmlInputCheckBox chkFilelinkIsNew;
    protected HtmlInputCheckBox chkSchedulefilelink;
    protected HtmlInputText FilelinkStartDt;
    protected HtmlInputText FilelinkEndDt;
    protected HtmlInputCheckBox chkmultilingualFilelink;
    protected Label lblFilelinkOrder;
    protected Button Button4;
    protected GridView gvLanguage;
    protected ContentBox ccbAddEdit;
    protected CheckBox chkByName;
    protected CheckBox chkByLogin;
    protected TextBox txtSearchbox;
    protected ContentBox ccbUser;
    protected ContentBox ccbSpecificUser;
    protected ContentBox cbLingualEditor;
    protected HiddenField hddText;
    protected HiddenField hddUserType;
    protected HiddenField hddGroup;
    protected HiddenField hddMultilingual;
    protected HiddenField hddAddEditIndex;
    private ShowMessage shInfo;
    private DataSet ds;
    private DataSet dsLang;
    private FileStream fs;
    private XmlTextReader tr;
    private XmlTextReader trLocal;

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    //protected global_asax ApplicationInstance
    //{
    //    get
    //    {
    //        return (global_asax)this.Context.ApplicationInstance;
    //    }
    //}

    protected override void OnPreInit(EventArgs e)
    {
        this.OnInit(e);
        if (this.Request.Cookies["Theme"] == null)
            this.Page.Theme = "default";
        else
            this.Page.Theme = this.Request.Cookies["Theme"].Value;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (this.Session["UserLoginId"] == null)
            this.Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        if (Session["UserTypeID"].ToString() != "21")
        {
            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        }
        this.shInfo = (ShowMessage)this.Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        Utility.RegisterTypeForAjax(typeof(MenuManagement_MenuMgt_New));
        this.ddlGroup.Enabled = false;
        ((HiddenField)this.Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "3";
        for (int index = 0; index < this.Page.Application.Keys.Count; ++index)
        {
            if (this.Page.Application.Keys[index].StartsWith("ExpanderMenuHtml_"))
                this.Page.Application[this.Page.Application.Keys[index]] = (object)null;
        }
        if (this.Session["UserLoginId"] != null)
        {
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                this.ds = obj.GetUserTypes();
                if (this.ds.Tables.Count > 0)
                {
                    if (this.ds.Tables[0].Rows.Count > 0)
                    {
                        this.ddlUserType.DataSource = (object)this.ds.Tables[0].DefaultView;
                        this.ddlUserType.DataTextField = "UserTypeName";
                        this.ddlUserType.DataValueField = "UserTypeID";
                        this.ddlUserType.DataBind();
                        this.ddlUserType.Items.Insert(0, "-- Select --");
                        if (this.hddUserType.Value != "")
                            this.ddlUserType.SelectedValue = this.hddUserType.Value;
                    }
                    else
                        this.shInfo.SetMessage("There are no UserTypes in the database !! ", ShowMessageType.UserError);
                }
                else
                    this.shInfo.SetMessage("There are no UserTypes in the database !! ", ShowMessageType.UserError);
                
                this.dsLang = obj.GetLanguages();
                if (this.dsLang.Tables.Count > 0)
                {
                    this.gvLanguage.DataSource = (object)this.dsLang.Tables[0].DefaultView;
                    this.gvLanguage.DataBind();
                }
            }
            catch (DataException ex)
            {
                this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
            }
            finally
            {
                if (this.ds != null)
                {
                    this.ds.Dispose();
                    this.ds = (DataSet)null;
                }
                if (this.dsLang != null)
                {
                    this.dsLang.Dispose();
                    this.dsLang = (DataSet)null;
                }
            }
        }
        else
            this.shInfo.SetMessage("UserLoginId is null", ShowMessageType.UserError);
        if (this.IsPostBack)
            return;
        this.ddlUserType.SelectedValue = "0";
        this.hddUserType.Value = "0";
    }

    protected void gvLanguage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TableCellCollection cells = e.Row.Cells;
        cells[1].Attributes.Add("style", "display:none");
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.Footer)
            return;
        cells[3].Text = "<input type=\"checkbox\" id=\"chkLang" + (object)(e.Row.RowIndex + 1) + "\" onclick=\"EnableLanguageTextBox(this," + (object)(e.Row.RowIndex + 1) + ")\"/>";
        cells[4].Text = "<input type=\"text\"  disabled id=\"txtLang" + (object)(e.Row.RowIndex + 1) + "\"/>";
    }

    protected void btnFilelink_Save(object sender, EventArgs e)
    {
        try
        {
            string HttpAddress = ConfigurationManager.AppSettings["HttpAddress"] != null ? ConfigurationManager.AppSettings["HttpAddress"].ToString() : "";
            BusinessServiceImp obj = new BusinessServiceImp();
            this.ds = obj.SaveNewFilelink(this.txtFilelinkName.Text, this.chkFilelinkIsActive.Checked, this.chkFilelinkIsNew.Checked, this.chkSchedulefilelink.Checked ? this.FilelinkStartDt.Value : "", this.chkSchedulefilelink.Checked ? this.FilelinkEndDt.Value : "", Regex.Replace(this.hddText.Value, ".*@FileId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@UserTypeId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@Order=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@GroupId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@DetailId=(.*?)@.*", "$1"), this.Session["UserLoginId"].ToString(), HttpAddress);
            XmlDocument doc = new XmlDocument();
            doc.Load(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"));
            if (this.hddMultilingual.Value != "")
            {
                MatchCollection mcollLang = Regex.Matches(this.hddMultilingual.Value, "@Language name=(.*?)#", RegexOptions.IgnoreCase);
                string key = "";
                if (this.ds.Tables.Count > 0)
                {
                    if (this.ds.Tables[0].Rows.Count > 0)
                        key = 'D'.ToString() + this.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                    key = Regex.Match(this.hddMultilingual.Value, ".*@Language.*?" + mcollLang[0].Groups[1].Value + ".*?key=\"(.*?)\"").Groups[1].Value;
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"" + key + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                this.SetLanguageId(doc, mcollLang, key);
            }
            else
            {
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"D" + this.hddAddEditIndex.Value + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"), (Encoding)null);
                xmlTextWriter.Formatting = Formatting.Indented;
                doc.WriteContentTo((XmlWriter)xmlTextWriter);
                xmlTextWriter.Close();
            }
        }
        catch (DataException ex)
        {
            this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
        }
        finally
        {
            if (this.ds != null)
            {
                this.ds.Dispose();
                this.ds = (DataSet)null;
            }
        }
    }

    protected void btnHyperlink_Save(object sender, EventArgs e)
    {
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            this.ds = obj.SaveNewHyperlink(this.txtHyperlinkName.Text, this.txtHyperlink.Text, this.chkHyperlinkIsActive.Checked, this.chkHyperlinkIsNew.Checked, this.chkSchedulehyperlink.Checked ? this.HyperlinkStartDt.Value : "", this.chkSchedulehyperlink.Checked ? this.HyperlinkEndDt.Value : "", Regex.Replace(this.hddText.Value, ".*@UserTypeId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@Order=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@GroupId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@DetailId=(.*?)@.*", "$1"), this.Session["UserLoginId"].ToString());
            XmlDocument doc = new XmlDocument();
            doc.Load(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"));
            if (this.hddMultilingual.Value != "")
            {
                MatchCollection mcollLang = Regex.Matches(this.hddMultilingual.Value, "@Language name=(.*?)#", RegexOptions.IgnoreCase);
                string key = "";
                if (this.ds.Tables.Count > 0)
                {
                    if (this.ds.Tables[0].Rows.Count > 0)
                        key = 'D'.ToString() + this.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                    key = Regex.Match(this.hddMultilingual.Value, ".*@Language.*?" + mcollLang[0].Groups[1].Value + ".*?key=\"(.*?)\"").Groups[1].Value;
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"" + key + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                this.SetLanguageId(doc, mcollLang, key);
            }
            else
            {
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"D" + this.hddAddEditIndex.Value + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"), (Encoding)null);
                xmlTextWriter.Formatting = Formatting.Indented;
                doc.WriteContentTo((XmlWriter)xmlTextWriter);
                xmlTextWriter.Close();
            }
        }
        catch (DataException ex)
        {
            this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
        }
        finally
        {
            if (this.ds != null)
            {
                this.ds.Dispose();
                this.ds = (DataSet)null;
            }
        }
    }

    protected void btnText_Save(object sender, EventArgs e)
    {
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            this.ds = obj.SaveNewText(this.txtText.Text, this.chkTextIsActive.Checked, this.chkTextIsNew.Checked, this.chkScheduleText.Checked ? this.TextStartDt.Value : "", this.chkScheduleText.Checked ? this.TextEndDt.Value : "", Regex.Replace(this.hddText.Value, ".*@UserTypeId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@Order=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@GroupId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@DetailId=(.*?)@.*", "$1"), this.Session["UserLoginId"].ToString());
            XmlDocument doc = new XmlDocument();
            doc.Load(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"));
            if (this.hddMultilingual.Value != "")
            {
                MatchCollection mcollLang = Regex.Matches(this.hddMultilingual.Value, "@Language name=(.*?)#", RegexOptions.IgnoreCase);
                string key = "";
                if (this.ds.Tables.Count > 0)
                {
                    if (this.ds.Tables[0].Rows.Count > 0)
                        key = 'D'.ToString() + this.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                    key = Regex.Match(this.hddMultilingual.Value, ".*@Language.*?" + mcollLang[0].Groups[1].Value + ".*?key=\"(.*?)\"").Groups[1].Value;
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"" + key + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                this.SetLanguageId(doc, mcollLang, key);
            }
            else
            {
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"D" + this.hddAddEditIndex.Value + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"), (Encoding)null);
                xmlTextWriter.Formatting = Formatting.Indented;
                doc.WriteContentTo((XmlWriter)xmlTextWriter);
                xmlTextWriter.Close();
            }
        }
        catch (DataException ex)
        {
            this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
        }
        finally
        {
            if (this.ds != null)
            {
                this.ds.Dispose();
                this.ds = (DataSet)null;
            }
        }
    }

    protected void btnContent_SavenRedirect(object sender, EventArgs e)
    {
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            this.ds = obj.SaveNewContent(this.txtContentMenuName.Value, this.ContentIsActive.Checked, this.ContentIsNew.Checked, this.chkScheduleContent.Checked ? this.txtContentStartDate.Value : "", this.chkScheduleContent.Checked ? this.txtContentEndDate.Value : "", Regex.Replace(this.hddText.Value, ".*@UserTypeId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@Order=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@GroupId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@DetailId=(.*?)@.*", "$1"), this.Session["UserLoginId"].ToString());
            XmlDocument doc = new XmlDocument();
            doc.Load(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"));
            if (this.hddMultilingual.Value != "")
            {
                MatchCollection mcollLang = Regex.Matches(this.hddMultilingual.Value, "@Language name=(.*?)#", RegexOptions.IgnoreCase);
                string key = "";
                if (this.ds.Tables.Count > 0)
                {
                    if (this.ds.Tables[0].Rows.Count > 0)
                        key = 'D'.ToString() + this.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                    key = Regex.Match(this.hddMultilingual.Value, ".*@Language.*?" + mcollLang[0].Groups[1].Value + ".*?key=\"(.*?)\"").Groups[1].Value;
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"" + key + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                this.SetLanguageId(doc, mcollLang, key);
            }
            else
            {
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"D" + this.hddAddEditIndex.Value + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"), (Encoding)null);
                xmlTextWriter.Formatting = Formatting.Indented;
                doc.WriteContentTo((XmlWriter)xmlTextWriter);
                xmlTextWriter.Close();
            }
            this.Response.Redirect("../CMS/ContentNewEditor.aspx?did=" + this.ds.Tables[0].Rows[0][0].ToString());
        }
        catch (DataException ex)
        {
            this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
        }
        finally
        {
            if (this.ds != null)
            {
                this.ds.Dispose();
                this.ds = (DataSet)null;
            }
        }
    }

    protected void btnContent_Save(object sender, EventArgs e)
    {
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            this.ds = obj.SaveNewContent(this.txtContentMenuName.Value, this.ContentIsActive.Checked, this.ContentIsNew.Checked, this.chkScheduleContent.Checked ? this.txtContentStartDate.Value : "", this.chkScheduleContent.Checked ? this.txtContentEndDate.Value : "", Regex.Replace(this.hddText.Value, ".*@UserTypeId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@Order=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@GroupId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@DetailId=(.*?)@.*", "$1"), this.Session["UserLoginId"].ToString());
            XmlDocument doc = new XmlDocument();
            doc.Load(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"));
            if (this.hddMultilingual.Value != "")
            {
                MatchCollection mcollLang = Regex.Matches(this.hddMultilingual.Value, "@Language name=(.*?)#", RegexOptions.IgnoreCase);
                string key = "";
                if (this.ds.Tables.Count > 0)
                {
                    if (this.ds.Tables[0].Rows.Count > 0)
                        key = 'D'.ToString() + this.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                    key = Regex.Match(this.hddMultilingual.Value, ".*@Language.*?" + mcollLang[0].Groups[1].Value + ".*?key=\"(.*?)\"").Groups[1].Value;
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"" + key + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                this.SetLanguageId(doc, mcollLang, key);
            }
            else
            {
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"D" + this.hddAddEditIndex.Value + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"), (Encoding)null);
                xmlTextWriter.Formatting = Formatting.Indented;
                doc.WriteContentTo((XmlWriter)xmlTextWriter);
                xmlTextWriter.Close();
            }
        }
        catch (DataException ex)
        {
            this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
        }
        finally
        {
            if (this.ds != null)
            {
                this.ds.Dispose();
                this.ds = (DataSet)null;
            }
        }
    }

    protected void btnSaveAll_Click(object sender, EventArgs e)
    {
        try
        {
            this.hddText.Value = Regex.Replace(Regex.Replace(this.hddText.Value, "@", "<"), "#", ">");
            BusinessServiceImp obj = new BusinessServiceImp();
            this.ds = obj.SaveAll(this.hddText.Value, this.Session["UserLoginId"].ToString());
        }
        catch (DataException ex)
        {
            this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
        }
        finally
        {
            if (this.ds != null)
            {
                this.ds.Dispose();
                this.ds = (DataSet)null;
            }
        }
    }

    protected void btnLink_Save(object sender, EventArgs e)
    {
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            this.ds = obj.SaveNewLink(this.txtLinkName.Value, Regex.Replace(this.hddText.Value, ".*@ModuleId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@MenuId=(.*?)@.*", "$1"), this.chkAddEditIsActive.Checked, this.chkAddEditNewLink.Checked, this.chkScheduleLink.Checked ? this.txtStartDt.Value : "", this.chkScheduleLink.Checked ? this.txtEndDt.Value : "", Regex.Replace(this.hddText.Value, ".*@UserTypeId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@Order=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@GroupId=(.*?)@.*", "$1"), Regex.Replace(this.hddText.Value, ".*@DetailId=(.*?)@.*", "$1"), this.Session["UserLoginId"].ToString());
            XmlDocument doc = new XmlDocument();
            doc.Load(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"));
            if (this.hddMultilingual.Value != "")
            {
                MatchCollection mcollLang = Regex.Matches(this.hddMultilingual.Value, "@Language name=(.*?)#", RegexOptions.IgnoreCase);
                string key = "";
                if (this.ds.Tables.Count > 0)
                {
                    if (this.ds.Tables[0].Rows.Count > 0)
                        key = 'D'.ToString() + this.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                    key = Regex.Match(this.hddMultilingual.Value, ".*@Language.*?" + mcollLang[0].Groups[1].Value + ".*?key=\"(.*?)\"").Groups[1].Value;
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"" + key + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                this.SetLanguageId(doc, mcollLang, key);
            }
            else
            {
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"D" + this.hddAddEditIndex.Value + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"), (Encoding)null);
                xmlTextWriter.Formatting = Formatting.Indented;
                doc.WriteContentTo((XmlWriter)xmlTextWriter);
                xmlTextWriter.Close();
            }
        }
        catch (DataException ex)
        {
            this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
        }
        finally
        {
            if (this.ds != null)
            {
                this.ds.Dispose();
                this.ds = (DataSet)null;
            }
        }
    }

    private void Synchronise_AppVar()
    {
        try
        {
            string appSetting = ConfigurationManager.AppSettings["WebFarmServerIP"];
            char[] chArray = new char[1] { ';' };
            foreach (string str in appSetting.Split(chArray))
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + str + "/" + ConfigurationManager.AppSettings["WebSiteName_AfterHosting"] + "/SynchApplicationVar.syn");
                httpWebRequest.UseDefaultCredentials = true;
                httpWebRequest.PreAuthenticate = true;
                httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream());
            }
        }
        catch (DataException ex)
        {
            this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
        }
    }

    private void SetLanguageId(XmlDocument doc, MatchCollection mcollLang, string key)
    {
        foreach (Match match in mcollLang)
        {
            XmlNode xmlNode1 = doc.SelectSingleNode("/Root/Language[@name=" + match.Groups[1].Value + "]");
            if (xmlNode1 == null)
            {
                XmlElement element1 = doc.CreateElement("Language");
                XmlElement element2 = doc.CreateElement("Page");
                XmlElement element3 = doc.CreateElement("data");
                element1.SetAttribute("name", Regex.Replace(match.Groups[1].Value, "\"", ""));
                element2.SetAttribute("name", "commonlanguagetexts");
                element3.SetAttribute(nameof(key), key);
                element3.SetAttribute("value", Regex.Match(this.hddMultilingual.Value, ".*@Language.*?" + match.Groups[1].Value + ".*?value=\"(.*?)\"").Groups[1].Value);
                element2.AppendChild((XmlNode)element3);
                element1.AppendChild((XmlNode)element2);
                doc.DocumentElement.AppendChild((XmlNode)element1);
            }
            else
            {
                XmlNode xmlNode2 = doc.SelectSingleNode("/Root/Language[@name=" + match.Groups[1].Value + "]/Page[@name=\"commonlanguagetexts\"]");
                if (xmlNode2 == null)
                {
                    XmlElement element1 = doc.CreateElement("Page");
                    XmlElement element2 = doc.CreateElement("data");
                    element1.SetAttribute("name", "commonlanguagetexts");
                    element2.SetAttribute(nameof(key), key);
                    element2.SetAttribute("value", Regex.Match(this.hddMultilingual.Value, ".*@Language.*?" + match.Groups[1].Value + ".*?value=\"(.*?)\"").Groups[1].Value);
                    element1.AppendChild((XmlNode)element2);
                    xmlNode1.AppendChild((XmlNode)element1);
                }
                else
                {
                    XmlNode oldChild = doc.SelectSingleNode("/Root/Language[@name=" + match.Groups[1].Value + "]/Page[@name=\"commonlanguagetexts\"]/data[@key=\"" + key + "\"]");
                    oldChild?.ParentNode.RemoveChild(oldChild);
                    XmlElement element = doc.CreateElement("data");
                    element.SetAttribute(nameof(key), key);
                    element.SetAttribute("value", Regex.Match(this.hddMultilingual.Value, ".*@Language.*?" + match.Groups[1].Value + ".*?value=\"(.*?)\"").Groups[1].Value);
                    xmlNode2.AppendChild((XmlNode)element);
                }
            }
        }
        XmlTextWriter xmlTextWriter = new XmlTextWriter(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"), (Encoding)null);
        xmlTextWriter.Formatting = Formatting.Indented;
        doc.WriteContentTo((XmlWriter)xmlTextWriter);
        xmlTextWriter.Close();
    }

    private byte[] GetFtpFileData()
    {
        return new WebClient()
        {
            Credentials = ((ICredentials)new NetworkCredential(ConfigurationManager.AppSettings["FtpUserName"], ConfigurationManager.AppSettings["FtpUserPassword"]))
        }.DownloadData(ConfigurationManager.AppSettings["FtpAddress"] + ConfigurationManager.AppSettings["FtpFilePath"]);
    }

    private Stream GetFtpRequestToWrite()
    {
        FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["FtpAddress"] + ConfigurationManager.AppSettings["FtpFilePath"]);
        ftpWebRequest.Credentials = (ICredentials)new NetworkCredential(ConfigurationManager.AppSettings["FtpUserName"], ConfigurationManager.AppSettings["FtpUserPassword"]);
        ftpWebRequest.Method = "STOR";
        ftpWebRequest.UseBinary = true;
        ftpWebRequest.ReadWriteTimeout = 10000000;
        return ftpWebRequest.GetRequestStream();
    }

    [AjaxMethod]
    public string Getkeys(string DetailId)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"));
        XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//data[@key=\"D" + DetailId + "\"]");
        string str = "";
        foreach (XmlNode xmlNode in xmlNodeList)
            str = str + "," + xmlNode.ParentNode.ParentNode.Attributes[0].Value + "#" + xmlNode.Attributes[1].Value;
        return str;
    }

    [AjaxMethod]
    public DataSet FillGroup(string UserTypeID)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetGroups(Convert.ToInt32(UserTypeID));
    }

    [AjaxMethod]
    public DataSet GetMenus(string GroupId, string UserTypeID)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetMenus(Convert.ToInt32(GroupId), Convert.ToInt32(UserTypeID));
    }

    [AjaxMethod]
    public DataSet FillModule(int id)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetModule();
    }

    [AjaxMethod]
    public DataSet FillFileList(int id)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetFileList();
    }

    [AjaxMethod]
    public DataSet MenusModuleWise(string ModuleId)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetMenusModuleWise(ModuleId);
    }

    [AjaxMethod]
    public DataSet DeleteLink(string DetailId)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"));
        foreach (XmlNode selectNode in xmlDocument.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"D" + DetailId + "\"]"))
            selectNode.ParentNode.RemoveChild(selectNode);
        XmlTextWriter xmlTextWriter = new XmlTextWriter(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"), (Encoding)null);
        xmlTextWriter.Formatting = Formatting.Indented;
        xmlDocument.WriteContentTo((XmlWriter)xmlTextWriter);
        xmlTextWriter.Close();
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.DeleteLinks(DetailId);
    }

    [AjaxMethod]
    public DataSet GetUsers(string KeyWord, string ColumnType, string UserType)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetUsers(KeyWord, ColumnType, UserType);
    }

    [AjaxMethod]
    public DataSet SaveUserSpecificMenus(string xml)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.SaveUserSpecificMenus(xml);
    }

    [AjaxMethod]
    public DataSet GetSpecificMenuUser(string DetailId)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetSpecificMenuUser(DetailId);
    }

    [AjaxMethod]
    public DataSet DeleteUser(string UserId, string DetailId)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.DeleteUser(UserId, DetailId);
    }
}
//}