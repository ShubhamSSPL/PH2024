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

//namespace Synthesys.MenuManagement.MenuManagement
//{
    public partial class MenuManagement_GroupMgt : System.Web.UI.Page
    {
        ShowMessage showMsg = null;
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
        showMsg = (ShowMessage)Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
            AjaxPro.Utility.RegisterTypeForAjax(typeof(MenuManagement_GroupMgt));

            ((HiddenField)Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "3";
            for (int i = 0; i < Page.Application.Keys.Count; i++)
                if (Page.Application.Keys[i].StartsWith("ExpanderMenuHtml_"))
                    Page.Application[Page.Application.Keys[i]] = null;
            //

            if (!IsPostBack)
            {
                DataSet ds = null;
                DataSet dsLanguages = null;
                try
                {
                    BusinessServiceImp obj = new BusinessServiceImp();
                    ds = obj.GetUserType();
                    if (ds.Tables.Count > 0)
                    {
                        DdlUserType.DataSource = ds.Tables[0];
                        DdlUserType.DataValueField = "UserTypeID";
                        DdlUserType.DataTextField = "UserTypeName";
                        DdlUserType.DataBind();
                        DdlUserType.Items.Insert(0, "-- Select --");
                    }
                    
                    dsLanguages = obj.GetLanguages();
                    if (dsLanguages.Tables.Count > 0)
                    {
                        GvLanguageList.DataSource = dsLanguages.Tables[0];
                        GvLanguageList.DataBind();
                        GvEditLanguageList.DataSource = dsLanguages.Tables[0];
                        GvEditLanguageList.DataBind();
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
                    if (dsLanguages != null)
                    {
                        dsLanguages.Dispose();
                        dsLanguages = null;

                    }

                }
                HdnUserId.Value = Session["UserLoginId"].ToString();
            }

        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.AddNewGroup(int.Parse(DdlUserType.SelectedValue), TxtGroupName.Text, rbtIsActive.Items[0].Selected ? "1" : "0", Session["UserLoginId"].ToString(), rbtIsStatic.Items[0].Selected ? "1" : "0", TxtGroupDisplayName.Text);
                if (ds.Tables.Count > 0)
                {
                    string GroupId = ds.Tables[0].Rows[0]["GroupId"].ToString();

                    WriteDataToXMLFile(GroupId, HdnXMLLanguage.Value);
                }
                HdnRefreshPage.Value = "Y";
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

        private void WriteDataToXMLFile(string GroupId, string LanguageXML)
        {

            byte[] filedata = GetFtpFileData();
            Stream stream = new MemoryStream(filedata);


            XmlDocument Xdoc = new XmlDocument();
            XmlNode xmlNode;
            Xdoc.Load(stream);
            NameTable nt = new NameTable();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
            nsmgr.AddNamespace("", "");
            XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
            string tempXML = "";
            tempXML = LanguageXML;
            XmlTextReader xr = new XmlTextReader(tempXML, XmlNodeType.Document, context);
            while (xr.Read())
            {
                if (xr.Name == "Language")
                {
                    if (xr.HasAttributes)
                    {
                        string Language = xr.GetAttribute("LanguageName");
                        string LanguageText = xr.GetAttribute("Text");
                        string PageName = "commonlanguagetexts";

                        xmlNode = Xdoc.SelectSingleNode("//Root/Language[@name=\"" + Language + "\"]/Page[@name=\"" + PageName + "\"]");

                        if (xmlNode == null)
                        {
                            Stream writeData = GetFtpRequestToWrite();


                            XmlElement language = Xdoc.CreateElement("Language");
                            language.SetAttribute("name", Language);

                            XmlElement page = Xdoc.CreateElement("Page");
                            page.SetAttribute("name", "commonlanguagetexts");
                            XmlElement data = Xdoc.CreateElement("data");
                            data.SetAttribute("key", "G" + GroupId);
                            data.SetAttribute("value", LanguageText);
                            page.AppendChild(data);
                            language.AppendChild(page);
                            Xdoc.DocumentElement.InsertAfter(language,
                                                               Xdoc.DocumentElement.LastChild);

                            XmlTextWriter XTW = new XmlTextWriter(writeData, null);
                            XTW.Formatting = Formatting.Indented;
                            Xdoc.WriteContentTo(XTW);
                            XTW.Close();
                            writeData.Close();
                        }
                        else
                        {
                            XmlNode InnerXmlNode = Xdoc.SelectSingleNode("//Root/Language[@name=\"" + Language + "\"]/Page[@name=\"" + PageName + "\"]/data[@key=\"" + "G" + GroupId + "\"]");
                            if (InnerXmlNode == null)
                            {
                                Stream writeData = GetFtpRequestToWrite();

                                XmlElement data = Xdoc.CreateElement("data");
                                data.SetAttribute("key", "G" + GroupId);
                                data.SetAttribute("value", LanguageText);
                                Xdoc.SelectSingleNode("//Root/Language[@name=\"" + Language + "\"]/Page[@name=\"" + PageName + "\"]").AppendChild(data);
                                XmlTextWriter XTW = new XmlTextWriter(writeData, null);
                                XTW.Formatting = Formatting.Indented;
                                Xdoc.WriteContentTo(XTW);
                                XTW.Close();
                                writeData.Close();
                            }

                        }

                    }
                }
            }
            stream.Close();
        }
        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.DeleteGroup(int.Parse(DdlUserType.SelectedValue), int.Parse(HdnGroupId.Value));
                HdnRefreshPage.Value = "Y";
                string languageList = "";
                for (int i = 0; i < GvLanguageList.Rows.Count; i++)
                {
                    languageList = languageList + GvLanguageList.Rows[i].Cells[2].Text + "_";
                }
                string[] languageListArray = languageList.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                //RemoveEntriesFromFile(HdnGroupId.Value, languageListArray);
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

        private void RemoveEntriesFromFile(string GroupId, string[] LanguageList)
        {

            string PageName = "commonlanguagetexts";
            for (int i = 0; i < LanguageList.Length; i++)
            {

                byte[] filedata = GetFtpFileData();
                Stream stream = new MemoryStream(filedata);


                Stream writeData = GetFtpRequestToWrite();


                string Language = LanguageList[i];
                XmlNode xmlNode;
                XmlDocument Xdoc = new XmlDocument();
                Xdoc.Load(stream);
                xmlNode = Xdoc.SelectSingleNode("//Root/Language[@name=\"" + Language + "\"]/Page[@name=\"" + PageName + "\"]/data[@key=\"" + "G" + GroupId + "\"]");
                if (xmlNode != null)
                {
                    xmlNode.ParentNode.RemoveChild(xmlNode);
                }

                XmlTextWriter XTW = new XmlTextWriter(writeData, null);
                XTW.Formatting = Formatting.Indented;
                Xdoc.WriteContentTo(XTW);
                XTW.Close();
                writeData.Close();
                stream.Close();
            }
        }

        private byte[] GetFtpFileData()
        {
            WebClient request = new WebClient();
            request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FtpUserName"], ConfigurationManager.AppSettings["FtpUserPassword"]);
        //return (request.DownloadData(ConfigurationManager.AppSettings["FtpAddress"] + ConfigurationManager.AppSettings["FtpFilePath"]));
        return (request.DownloadData(Server.MapPath(ConfigurationManager.AppSettings["FtpFilePath"])));
    }

        private Stream GetFtpRequestToWrite()
        {
            FtpWebRequest RequestTowrite = (FtpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["FtpAddress"] + ConfigurationManager.AppSettings["FtpFilePath"]);
            RequestTowrite.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FtpUserName"], ConfigurationManager.AppSettings["FtpUserPassword"]);
            RequestTowrite.Method = WebRequestMethods.Ftp.UploadFile;
            RequestTowrite.UseBinary = true;
            RequestTowrite.KeepAlive = false;
            RequestTowrite.ReadWriteTimeout = 10000000;
            return (RequestTowrite.GetRequestStream());
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.UpdateGroup(int.Parse(DdlUserType.SelectedValue), TxtEditGroupName.Text,
                    rbtEditIsActive.Items[0].Selected ? "1" : "0", TxtEditGroupOrder.Text,
                    int.Parse(HdnGroupId.Value), Session["UserLoginId"].ToString(), rbtEditIsStatic.Items[0].Selected ? "1" : "0", TxtEditGroupDisplayName.Text);
                HdnRefreshPage.Value = "Y";

                string languageList = "";
                for (int i = 0; i < GvLanguageList.Rows.Count; i++)
                {
                    languageList = languageList + GvLanguageList.Rows[i].Cells[2].Text + "_";
                }
                string[] languageListArray = languageList.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                if (chkEditMultilingual.Checked)
                {
                    RemoveEntriesFromFile(HdnGroupId.Value, languageListArray);
                    UpdateDataToXmlFile(HdnGroupId.Value, HdnEditXMLLanguage.Value);
                }
                else
                {
                    //RemoveEntriesFromFile(HdnGroupId.Value, languageListArray);
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
        private void UpdateDataToXmlFile(string GroupId, string LanguageXML)
        {

            byte[] filedata = GetFtpFileData();
            Stream stream = new MemoryStream(filedata);


            XmlDocument Xdoc = new XmlDocument();
            XmlNode xmlNode;
            Xdoc.Load(stream);


            NameTable nt = new NameTable();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
            nsmgr.AddNamespace("", "");
            XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
            string tempXML = "";
            tempXML = LanguageXML;
            XmlTextReader xr = new XmlTextReader(tempXML, XmlNodeType.Document, context);
            while (xr.Read())
            {
                if (xr.Name == "Language")
                {
                    if (xr.HasAttributes)
                    {
                        string Language = xr.GetAttribute("LanguageName");
                        string LanguageText = xr.GetAttribute("Text");
                        string PageName = "commonlanguagetexts";

                        Stream writeData = GetFtpRequestToWrite();

                        xmlNode = Xdoc.SelectSingleNode("//Root/Language[@name=\"" + Language + "\"]/Page[@name=\"" + PageName + "\"]");

                        if (xmlNode == null)
                        {
                            XmlElement language = Xdoc.CreateElement("Language");
                            language.SetAttribute("name", Language);

                            XmlElement page = Xdoc.CreateElement("Page");
                            page.SetAttribute("name", "commonlanguagetexts");
                            XmlElement data = Xdoc.CreateElement("data");
                            data.SetAttribute("key", "G" + GroupId);
                            data.SetAttribute("value", LanguageText);
                            page.AppendChild(data);
                            language.AppendChild(page);
                            Xdoc.DocumentElement.InsertAfter(language,
                                                               Xdoc.DocumentElement.LastChild);

                            XmlTextWriter XTW = new XmlTextWriter(writeData, null);

                            XTW.Formatting = Formatting.Indented;
                            Xdoc.WriteContentTo(XTW);
                            XTW.Close();
                        }
                        else
                        {
                            XmlNode InnerXmlNode = Xdoc.SelectSingleNode("//Root/Language[@name=\"" + Language + "\"]/Page[@name=\"" + PageName + "\"]/data[@key=\"" + "G" + GroupId + "\"]");
                            if (InnerXmlNode == null)
                            {
                                XmlElement data = Xdoc.CreateElement("data");
                                data.SetAttribute("key", "G" + GroupId);
                                data.SetAttribute("value", LanguageText);
                                Xdoc.SelectSingleNode("//Root/Language[@name=\"" + Language + "\"]/Page[@name=\"" + PageName + "\"]").AppendChild(data);
                                XmlTextWriter XTW = new XmlTextWriter(writeData, null);
                                XTW.Formatting = Formatting.Indented;
                                Xdoc.WriteContentTo(XTW);
                                XTW.Close();
                            }
                            else
                            {
                                InnerXmlNode.Attributes.Item(1).Value = LanguageText;
                                XmlTextWriter XTW = new XmlTextWriter(writeData, null);
                                XTW.Formatting = Formatting.Indented;
                                Xdoc.WriteContentTo(XTW);
                                XTW.Close();
                            }

                        }
                        writeData.Close();
                    }
                }
            }

            stream.Close();
        }
        protected void Btn_SaveGroups_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.SaveGroups(int.Parse(DdlUserType.SelectedValue), HdnXML.Value, Session["UserLoginId"].ToString());

                HdnRefreshPage.Value = "Y";
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
        protected void GvLanguageList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TableCellCollection tcc = e.Row.Cells;
            tcc[1].Attributes.Add("style", "display:none");
        }


        [AjaxMethod]
        public DataSet GetGroupsUserTypeWise(string UserTypeID)
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            return obj.GetGroupsByUserType(int.Parse(UserTypeID));
        }
        [AjaxMethod]
        public DataSet GetSpecificGroupDetailsForUpdate(int GroupId, string LanguageList)
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            string[] languageListArray = LanguageList.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
            DataSet dsLangDetailsFromFile = GetEntriesFromFile(GroupId, languageListArray);
            DataSet ds = obj.GetSpecificGroupDetails(GroupId);
            if (dsLangDetailsFromFile != null)
            {
                ds.Tables.Add(dsLangDetailsFromFile.Tables[0].Copy());
                dsLangDetailsFromFile.Dispose();
                dsLangDetailsFromFile = null;
            }
            return ds;
        }
        [AjaxMethod]
        public DataSet GetSpecificGroupDetails(int GroupId)
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            return obj.GetSpecificGroupDetails(GroupId);
        }
        private DataSet GetEntriesFromFile(int GroupId, string[] languageListArray)
        {
            byte[] filedata = GetFtpFileData();

            Stream stream = new MemoryStream(filedata);
            DataSet ds = new DataSet();
            string PageName = "commonlanguagetexts";
            DataTable dt = new DataTable("LanguageTable");
            DataColumn dc;
            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "Language";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "LanguageText";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            XmlDocument Xdoc = new XmlDocument();
            Xdoc.Load(stream);
            for (int i = 0; i < languageListArray.Length; i++)
            {
                string Language = languageListArray[i];
                XmlNode xmlNode;
                xmlNode = Xdoc.SelectSingleNode("//Root/Language[@name=\"" + Language + "\"]/Page[@name=\"" + PageName + "\"]/data[@key=\"" + "G" + GroupId.ToString() + "\"]");
                if (xmlNode != null)
                {
                    dr = dt.NewRow();
                    dr["Language"] = Language;
                    dr["LanguageText"] = xmlNode.Attributes.Item(1).Value;
                    dt.Rows.Add(dr);
                }
            }
            ds.Tables.Add(dt);
            stream.Close();
            return ds;

        }
        //[AjaxMethod]
        //public DataSet DeleteGroup(string UserTypeId,int GroupId)
        //{
        //    return new Data_Layer_GroupMgt().DeleteGroup(int.Parse(UserTypeId), GroupId);
        //}
        //[AjaxMethod]
        //public DataSet AddNewGroup(string UserTypeId, string GroupName, string IsActive, string UserId, string IsStatic, string GroupDisplayText)
        //{
        //    return new Data_Layer_GroupMgt().AddNewGroup(int.Parse(UserTypeId), GroupName, IsActive, UserId, IsStatic, GroupDisplayText);
        //}
        //[AjaxMethod]
        //public DataSet UpdateGroup(string UserTypeId, string GroupName, string IsActive, string GroupOrder, string GroupId, string UserId, string IsStatic, string GroupDisplayText)
        //{
        //    return new Data_Layer_GroupMgt().UpdateGroup(int.Parse(UserTypeId), GroupName, IsActive, GroupOrder, int.Parse(GroupId), UserId, IsStatic, GroupDisplayText);                        
        //}
    }
//}