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
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Net;
using System.Web.UI.HtmlControls;
using System.Web.Profile;
using System.Text;
using AspNet;

//namespace Synthesys.MenuManagement.MenuManagement
//{
public partial class MenuManagement_AddTopMenu : System.Web.UI.Page
    {
        private string groupIds = "";
        private int count = 1;
        protected DropDownList ddlUserType;
        protected Button btnSaveAll;
        protected ContentBox ccbMenu;
        protected HtmlInputText txtMenuName;
        protected HtmlInputCheckBox chkAddEditIsActive;
        protected Label lblAddEditOrder;
        protected HtmlInputCheckBox chkmultiLingualLink;
        protected GridView gvLanguage;
        protected Button btnLinkSave;
        protected ContentBox ccbAddEdit;
        protected ContentBox cbLingualEditor;
        protected HiddenField hddText;
        protected HiddenField hddMultilingual;
        protected HiddenField hddAddEditIndex;
        protected HiddenField hddUserType;
        private ShowMessage shInfo;
        private DataSet ds;
        private DataSet dsLang;
        private string[] mcoll;

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
        
        if (this.Session["UserLoginId"] == null)
            this.Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        if (Session["UserTypeID"].ToString() != "21")
        {
            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        }
        this.shInfo = (ShowMessage)this.Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        AjaxPro.Utility.RegisterTypeForAjax(typeof(MenuManagement_AddTopMenu));
        //Utility.RegisterTypeForAjax(typeof(MenuManagement_AddTopMenu));
        ((HiddenField)this.Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "3";
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
        if (!this.IsPostBack)
        {
            this.ddlUserType.SelectedValue = "0";
            this.hddUserType.Value = "0";
        }
        this.GetData();
    }

    private void GetData()
    {
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            this.dsLang = obj.GetMultilingualLanguages();
            if (this.dsLang.Tables.Count <= 0)
                return;
            this.gvLanguage.DataSource = (object)this.dsLang.Tables[0].DefaultView;
            this.gvLanguage.DataBind();
        }
        catch (DataException ex)
        {
            this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
        }
        finally
        {
            if (this.dsLang != null)
            {
                this.dsLang.Dispose();
                this.dsLang = (DataSet)null;
            }
        }
    }

    protected void btnAddEdit_Save(object sender, EventArgs e)
    {
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            this.ds = obj.AddUpdateTopMenu(Regex.Replace(this.hddText.Value, ".*MenuId=(.*?)@.*", "$1"), this.txtMenuName.Value, Regex.Replace(this.hddText.Value, ".*GroupIds=(.*?)@.*", "$1"), this.chkAddEditIsActive.Checked, Regex.Replace(this.hddText.Value, ".*MenuOrder=(.*?)@.*", "$1"), this.Session["UserLoginId"].ToString(), Regex.Replace(this.hddText.Value, ".*UserTypeId=(.*?)@.*", "$1"), !(Regex.Replace(this.hddText.Value, ".*UserTypeId=(.*?)@.*", "$1") != "0") ? ConfigurationManager.AppSettings["WebSite_HomePage"] : ConfigurationManager.AppSettings["WebSite_LoginHomePage"]);
            this.hddText.Value = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"));
            if (this.hddMultilingual.Value != "")
            {
                MatchCollection mcollLang = Regex.Matches(this.hddMultilingual.Value, "@Language name=(.*?)#", RegexOptions.IgnoreCase);
                string key = "";
                if (this.ds.Tables.Count > 0)
                {
                    if (this.ds.Tables[0].Rows.Count > 0)
                        key = "T" + this.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                    key = Regex.Match(this.hddMultilingual.Value, ".*@Language.*?" + mcollLang[0].Groups[1].Value + ".*?key=\"(.*?)\"").Groups[1].Value;
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"" + key + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                this.SetLanguageId(doc, mcollLang, key);
            }
            else
            {
                foreach (XmlNode selectNode in doc.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"T" + this.hddAddEditIndex.Value + "\"]"))
                    selectNode.ParentNode.RemoveChild(selectNode);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"), (Encoding)null);
                xmlTextWriter.Formatting = Formatting.Indented;
                doc.WriteContentTo((XmlWriter)xmlTextWriter);
                xmlTextWriter.Close();
            }
            this.Page.Application["ExpanderMenuHtml_TopMenu_" + Regex.Replace(this.hddText.Value, ".*UserTypeId=(.*?)@.*", "$1")] = (object)null;
            for (int index = 0; index < this.Page.Application.Keys.Count; ++index)
            {
                if (this.Page.Application.Keys[index].StartsWith("ExpanderMenuHtml_" + Regex.Replace(this.hddText.Value, ".*UserTypeId=(.*?)@.*", "$1")))
                    this.Page.Application[this.Page.Application.Keys[index]] = (object)null;
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

    private void Synchronise_AppVar(string UserTypeId)
    {
        try
        {
            string appSetting = ConfigurationManager.AppSettings["WebFarmServerIP"];
            char[] chArray = new char[1] { ';' };
            foreach (string str in appSetting.Split(chArray))
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + str + "/" + ConfigurationManager.AppSettings["WebSiteName_AfterHosting"] + "/SynchTopApplicationVar.synT?usrTyp=" + UserTypeId);
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

    protected void gvLanguage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TableCellCollection cells = e.Row.Cells;
        cells[1].Attributes.Add("style", "display:none");
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.Footer)
            return;
        cells[3].Text = "<input type=\"checkbox\" id=\"chkLang" + (object)(e.Row.RowIndex + 1) + "\" onclick=\"EnableLanguageTextBox(this," + (object)(e.Row.RowIndex + 1) + ")\"/>";
        cells[4].Text = "<input type=\"text\"  disabled id=\"txtLang" + (object)(e.Row.RowIndex + 1) + "\"/>";
    }

    protected void btnSaveAll_Click(object sender, EventArgs e)
    {
        try
        {
            this.hddText.Value = Regex.Replace(Regex.Replace(this.hddText.Value, "@", "<"), "#", ">");
            BusinessServiceImp obj = new BusinessServiceImp();
            this.ds = obj.SaveAll(this.hddText.Value);
            this.Page.Application["ExpanderMenuHtml_TopMenu_" + this.ddlUserType.SelectedValue] = (object)null;
            for (int index = 0; index < this.Page.Application.Keys.Count; ++index)
            {
                if (this.Page.Application.Keys[index].StartsWith("ExpanderMenuHtml_" + this.ddlUserType.SelectedValue))
                    this.Page.Application[this.Page.Application.Keys[index]] = (object)null;
            }
            this.hddText.Value = "";
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
        XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//data[@key=\"T" + DetailId + "\"]");
        string str = "";
        foreach (XmlNode xmlNode in xmlNodeList)
            str = str + "," + xmlNode.ParentNode.ParentNode.Attributes[0].Value + "#" + xmlNode.Attributes[1].Value;
        return str;
    }

    [AjaxMethod]
    public DataSet DeleteLink(string MenuId)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"));
        foreach (XmlNode selectNode in xmlDocument.SelectNodes("//Page[@name=\"commonlanguagetexts\"]/data[@key=\"T" + MenuId + "\"]"))
            selectNode.ParentNode.RemoveChild(selectNode);
        XmlTextWriter xmlTextWriter = new XmlTextWriter(this.Server.MapPath("~/SynthesysModules_Files/Resources/MultiLingual_LanguageTexts.xml"), (Encoding)null);
        xmlTextWriter.Formatting = Formatting.Indented;
        xmlDocument.WriteContentTo((XmlWriter)xmlTextWriter);
        xmlTextWriter.Close();
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.DeleteLink(MenuId);
    }

    [AjaxMethod]
    public DataSet GetMenus(string UserTypeId)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        DataSet ds = obj.LoadMenu(UserTypeId);
        ds.Tables[0].TableName= "tblInfo";
        return ds;
    }
}
//}