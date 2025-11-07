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

namespace Synthesys.MenuManagement.MenuManagement
{
    public partial class MapModuleUserType : System.Web.UI.Page
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
            AjaxPro.Utility.RegisterTypeForAjax(typeof(MapModuleUserType));

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
                    ds = obj.GetMapModules();
                    if (ds.Tables[0].Rows.Count > 1)
                    {
                        GvModuleList.DataSource = ds.Tables[0];
                        GvModuleList.DataBind();
                        Btn_SaveModules.Attributes.Add("Style", "display:''");
                        LblNoModule.Visible = false;
                        BindDropDown(ds.Tables[1]);
                    }
                    else
                    {
                        LblNoModule.Visible = true;
                        Btn_SaveModules.Attributes.Add("Style", "display: none");
                        BindDropDown(ds.Tables[0]);
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

        private void BindDropDown(DataTable dataTable)
        {
            ChkAddUserType.Items.Clear();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ListItem li = new ListItem(dataTable.Rows[i]["UserTypeName"].ToString(), dataTable.Rows[i]["UserTypeId"].ToString());
                li.Attributes.Add("onclick", "changeColor(this);");
                ChkAddUserType.Items.Add(li);
            }
            ddlEditUserType.DataSource = dataTable;
            ddlEditUserType.DataTextField = "UserTypeName";
            ddlEditUserType.DataValueField = "UserTypeId";
            ddlEditUserType.DataBind();
            ddlEditUserType.Items.Insert(0, "-- Select --");
        }
        protected void Btn_SaveModules_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                string XML = CreateXML();
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.SaveMapModules(XML);
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
                CheckBox cb = (CheckBox)GvModuleList.Rows[i].Cells[5].Controls[1];
                string IsActive = cb.Checked == true ? "Y" : "N";
                XmlModule = XmlModule + @"<Module ModuleName=""" + GvModuleList.Rows[i].Cells[3].Text + @""" UserTypeId=""" + GvModuleList.Rows[i].Cells[1].Text + @""" IsActive=""" + IsActive + @""" ></Module>";
            }
            XmlModule = XmlModule + "</Modules>";
            return XmlModule;
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                string UserTypeXML = CreateUserTypeXML();
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.AddNewMapModule(TxtModuleName.Text, rbtIsActive.Items[0].Selected ? "Y" : "N", UserTypeXML);
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
                //if (ds.Tables[0].Rows[0]["MapModuleExits"].ToString() == "Y")
                //{
                //    showMsg.SetMessage("A module with the same name for the a usertype already exists,please enter a new module with a different name",ShowMessageType.UserError);
                //}
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

        private string CreateUserTypeXML()
        {
            string XmlUserType = "<UserTypeIds>";
            for (int i = 0; i < ChkAddUserType.Items.Count; i++)
            {
                if (ChkAddUserType.Items[i].Selected)
                {
                    XmlUserType = XmlUserType + @"<UserTypeId ID=""" + ChkAddUserType.Items[i].Value + @""" ></UserTypeId>";
                }
            }
            XmlUserType = XmlUserType + "</UserTypeIds>";
            return XmlUserType;
        }
        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                string[] ModuleUser = HdnModuleId.Value.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.UpdateMapModule(TxtEditModuleName.Text, int.Parse(ddlEditUserType.SelectedValue), rbtEditIsActive.Items[0].Selected ? "Y" : "N", ModuleUser[0], int.Parse(ModuleUser[1]));
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
                if (ds.Tables[0].Rows[0]["MapModuleExits"].ToString() == "Y")
                {
                    showMsg.SetMessage("A module with the same name already exists for the user type you specified,please enter a new module with a different name", ShowMessageType.UserError);
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
                string[] ModuleUser = HdnModuleId.Value.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.DeleteMapModule(ModuleUser[0], int.Parse(ModuleUser[1]));
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
        protected void DeleteButton_Command(object sender, CommandEventArgs e)
        {
            DataSet ds = null;
            try
            {
                string ModuleID = Server.HtmlDecode(e.CommandArgument.ToString());
                HdnModuleId.Value = ModuleID;
                string[] ModuleUser = HdnModuleId.Value.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);

                LblDeleteModuleName.Text = ModuleUser[0];
                //ds = new Data_Layer_MapModuleUserType().GetSpecificModuleDetails(int.Parse(ModuleID));
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    LblDeleteModuleName.Text = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                //}
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
                string ModuleDetails = Server.HtmlDecode(e.CommandArgument.ToString());
                HdnModuleId.Value = ModuleDetails;
                string[] ModuleUser = ModuleDetails.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.GetSpecificMapModuleDetails(ModuleUser[0], int.Parse(ModuleUser[1]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TxtEditModuleName.Text = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                    if (ds.Tables[0].Rows[0]["IsActive"].ToString() == "Y")
                    {
                        rbtEditIsActive.Items[0].Selected = true;
                    }
                    else
                    {
                        rbtEditIsActive.Items[1].Selected = true;
                    }
                    ddlEditUserType.SelectedValue = ds.Tables[0].Rows[0]["UserTypeId"].ToString();
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
            tcc[2].Attributes.Add("style", "display:none");
        }
    }
}