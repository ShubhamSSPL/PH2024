using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Synthesys.Controls;
using System.Data;
using System.Data.SqlClient;
//using MKCL.Common;
using AjaxPro;
using System.Configuration;
using Synthesys.MenuManagement.BusinessLayer;

namespace Synthesys.MenuManagement.MenuManagement
{
    public partial class AddLanguage : System.Web.UI.Page
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
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AddLanguage));

            ((HiddenField)Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "3";
            for (int i = 0; i < Page.Application.Keys.Count; i++)
                if (Page.Application.Keys[i].StartsWith("ExpanderMenuHtml_"))
                    Page.Application[Page.Application.Keys[i]] = null;
            //ketan
            if (!IsPostBack)
            {
                DataSet ds = null;
                try
                {
                    BusinessServiceImp obj = new BusinessServiceImp();
                    ds = obj.GetLanguages();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GvLangaugeList.DataSource = ds.Tables[0];
                        GvLangaugeList.DataBind();
                        Btn_SaveLanguages.Attributes.Add("Style", "display:''");
                        LblNoLanguage.Visible = false;
                    }
                    else
                    {
                        LblNoLanguage.Visible = true;
                        Btn_SaveLanguages.Attributes.Add("Style", "display: none");
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


        }
        protected void Btn_SaveLanguages_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                string XML = CreateXML();
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.SaveLanguages(XML, Session["UserLoginId"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GvLangaugeList.DataSource = ds.Tables[0];
                    GvLangaugeList.DataBind();
                    Btn_SaveLanguages.Attributes.Add("Style", "display:''");
                    LblNoLanguage.Visible = false;
                }
                else
                {
                    LblNoLanguage.Visible = true;
                    LblNoLanguage.Attributes.Add("Style", "display: none");
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

        private string CreateXML()
        {
            string XmlModule = "<Languages>";
            for (int i = 0; i < GvLangaugeList.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GvLangaugeList.Rows[i].Cells[4].Controls[1];
                string IsActive = cb.Checked == true ? "Y" : "N";
                XmlModule = XmlModule + @"<Language LanguageId=""" + GvLangaugeList.Rows[i].Cells[1].Text + @""" IsActive=""" + IsActive + @""" ></Language>";
            }
            XmlModule = XmlModule + "</Languages>";
            return XmlModule;
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.AddNewLanguage(TxtLanguageName.Text, rbtIsActive.Items[0].Selected ? "Y" : "N", Session["UserLoginId"].ToString(), TxtLanguageDispText.Text);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GvLangaugeList.DataSource = ds.Tables[1];
                    GvLangaugeList.DataBind();
                    Btn_SaveLanguages.Attributes.Add("Style", "display:''");
                    LblNoLanguage.Visible = false;
                }
                else
                {
                    LblNoLanguage.Visible = true;
                    Btn_SaveLanguages.Attributes.Add("Style", "display: none");
                }
                if (ds.Tables[0].Rows[0]["LanguageExits"].ToString() == "Y")
                {
                    showMsg.SetMessage("A language with the same name already exists,please enter a new language with a different name", ShowMessageType.UserError);
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
        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.UpdateLanguage(TxtEditLanguageName.Text, rbtEditIsActive.Items[0].Selected ? "Y" : "N", Session["UserLoginId"].ToString(), int.Parse(HdnLanguageId.Value), TxtEditLanguageDispText.Text);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GvLangaugeList.DataSource = ds.Tables[1];
                    GvLangaugeList.DataBind();
                    Btn_SaveLanguages.Attributes.Add("Style", "display:''");
                    LblNoLanguage.Visible = false;
                }
                else
                {
                    LblNoLanguage.Visible = true;
                    Btn_SaveLanguages.Attributes.Add("Style", "display: none");
                }
                if (ds.Tables[0].Rows[0]["LanguageExits"].ToString() == "Y")
                {
                    showMsg.SetMessage("A language with the same name already exists,please enter a new language with a different name", ShowMessageType.UserError);
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
        /*
        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                ds = new Data_Layer_Language().DeleteModule(int.Parse(HdnLanguageId.Value));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GvLangaugeList.DataSource = ds.Tables[0];
                    GvLangaugeList.DataBind();
                    Btn_SaveLanguages.Attributes.Add("Style", "display:''");
                    LblNoLanguage.Visible = false;
                }
                else
                {
                    LblNoLanguage.Visible = true;
                    Btn_SaveLanguages.Attributes.Add("Style", "display: none");
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
        protected void DeleteButton_Command(object sender, CommandEventArgs e)
        {
            DataSet ds = null;
            try
            {
                    string LanguageId = Server.HtmlDecode(e.CommandArgument.ToString());
                    HdnLanguageId.Value = LanguageId;
                    ds = new Data_Layer_Language().GetSpecificLanguageDetails(int.Parse(LanguageId));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        LblDeleteLanguageName.Text = ds.Tables[0].Rows[0]["LanguageName"].ToString();
                    }
                    HdnShowDeleteBox.Value = "Y";

            }
            catch (Exception ms)
            {
                showMsg.SetMessage(ms.Message, ShowMessageType.TechnicalError);
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
        */
        protected void EditButton_Command(object sender, CommandEventArgs e)
        {
            DataSet ds = null;
            try
            {
                string LanguageId = Server.HtmlDecode(e.CommandArgument.ToString());
                HdnLanguageId.Value = LanguageId;
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.GetSpecificLanguageDetails(int.Parse(LanguageId));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TxtEditLanguageName.Text = ds.Tables[0].Rows[0]["LanguageName"].ToString();
                    TxtEditLanguageDispText.Text = ds.Tables[0].Rows[0]["LanguageDisplayText"].ToString();
                    if (ds.Tables[0].Rows[0]["IsActive"].ToString() == "Y")
                    {
                        rbtEditIsActive.Items[0].Selected = true;
                        rbtEditIsActive.Items[1].Selected = false;
                    }
                    else
                    {
                        rbtEditIsActive.Items[0].Selected = false;
                        rbtEditIsActive.Items[1].Selected = true;
                    }
                }
                HdnShowEditBox.Value = "Y";

            }
            catch (Exception ms)
            {
                showMsg.SetMessage(ms.Message, ShowMessageType.TechnicalError);
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
        protected void GvLangaugeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TableCellCollection tcc = e.Row.Cells;
            tcc[1].Attributes.Add("style", "display:none");
        }

    }
    
}