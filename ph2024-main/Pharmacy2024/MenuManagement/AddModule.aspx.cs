using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using Synthesys.MenuManagement.BusinessLayer;
using System.Data;

namespace Synthesys.MenuManagement.MenuManagement
{
    public partial class AddModule : System.Web.UI.Page
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
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AddModule));

            ((HiddenField)Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "3";
            for (int i = 0; i < Page.Application.Keys.Count; i++)
                if (Page.Application.Keys[i].StartsWith("ExpanderMenuHtml_"))
                    Page.Application[Page.Application.Keys[i]] = null;
            //
            if (!IsPostBack)
            {
                DataSet ds = null;
                try
                {
                    BusinessServiceImp obj = new BusinessServiceImp();
                    ds = obj.GetModules();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GvModuleList.DataSource = ds.Tables[0];
                        GvModuleList.DataBind();
                        Btn_SaveModules.Attributes.Add("Style", "display:''");
                        LblNoModule.Visible = false;
                    }
                    else
                    {
                        LblNoModule.Visible = true;
                        Btn_SaveModules.Attributes.Add("Style", "display: none");
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
        protected void Btn_SaveModules_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                string XML = CreateXML();
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.SaveModules(XML, Session["UserLoginId"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GvModuleList.DataSource = ds.Tables[0];
                    GvModuleList.DataBind();
                    Btn_SaveModules.Attributes.Add("Style", "display:''");
                    LblNoModule.Visible = false;
                }
                else
                {
                    LblNoModule.Visible = true;
                    Btn_SaveModules.Attributes.Add("Style", "display: none");
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
            string XmlModule = "<Modules>";
            for (int i = 0; i < GvModuleList.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GvModuleList.Rows[i].Cells[3].Controls[1];
                string IsActive = cb.Checked == true ? "1" : "0";
                XmlModule = XmlModule + @"<Module ModuleId=""" + GvModuleList.Rows[i].Cells[1].Text + @""" IsActive=""" + IsActive + @""" ></Module>";
            }
            XmlModule = XmlModule + "</Modules>";
            return XmlModule;
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.AddNewModule(TxtModuleName.Text, rbtIsActive.Items[0].Selected ? "1" : "0", Session["UserLoginId"].ToString());
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GvModuleList.DataSource = ds.Tables[1];
                    GvModuleList.DataBind();
                    Btn_SaveModules.Attributes.Add("Style", "display:''");
                    LblNoModule.Visible = false;
                }
                else
                {
                    LblNoModule.Visible = true;
                    Btn_SaveModules.Attributes.Add("Style", "display: none");
                }
                if (ds.Tables[0].Rows[0]["ModuleExits"].ToString() == "Y")
                {
                    showMsg.SetMessage("A module with the same name already exists,please enter a new module with a different name", ShowMessageType.UserError);
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
                ds = obj.UpdateModule(TxtEditModuleName.Text, rbtEditIsActive.Items[0].Selected ? "1" : "0", Session["UserLoginId"].ToString(), int.Parse(HdnModuleId.Value));
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GvModuleList.DataSource = ds.Tables[1];
                    GvModuleList.DataBind();
                    Btn_SaveModules.Attributes.Add("Style", "display:''");
                    LblNoModule.Visible = false;
                }
                else
                {
                    LblNoModule.Visible = true;
                    Btn_SaveModules.Attributes.Add("Style", "display: none");
                }
                if (ds.Tables[0].Rows[0]["ModuleExits"].ToString() == "Y")
                {
                    showMsg.SetMessage("A module with the same name already exists,please enter a new module with a different name", ShowMessageType.UserError);
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

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.DeleteModule(int.Parse(HdnModuleId.Value));
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GvModuleList.DataSource = ds.Tables[1];
                    GvModuleList.DataBind();
                    Btn_SaveModules.Attributes.Add("Style", "display:''");
                    LblNoModule.Visible = false;
                }
                else
                {
                    LblNoModule.Visible = true;
                    Btn_SaveModules.Attributes.Add("Style", "display: none");
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
                string ModuleID = Server.HtmlDecode(e.CommandArgument.ToString());
                HdnModuleId.Value = ModuleID;
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.GetSpecificModuleDetails(int.Parse(ModuleID));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LblDeleteModuleName.Text = ds.Tables[0].Rows[0]["ModuleName"].ToString();
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

        protected void EditButton_Command(object sender, CommandEventArgs e)
        {
            DataSet ds = null;
            try
            {
                string ModuleID = Server.HtmlDecode(e.CommandArgument.ToString());
                HdnModuleId.Value = ModuleID;
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.GetSpecificModuleDetails(int.Parse(ModuleID));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TxtEditModuleName.Text = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                    if (bool.Parse(ds.Tables[0].Rows[0]["IsActive"].ToString()))
                    {
                        rbtEditIsActive.Items[0].Selected = true;
                    }
                    else
                    {
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
        protected void GvModuleList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TableCellCollection tcc = e.Row.Cells;
            tcc[1].Attributes.Add("style", "display:none");
        }
    }
}