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

//namespace Synthesys.MenuManagement.MenuManagement
//{
    public partial class MenuManagement_UserTypeMgt : System.Web.UI.Page
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
            AjaxPro.Utility.RegisterTypeForAjax(typeof(MenuManagement_UserTypeMgt));

            ((HiddenField)Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "3";
            for (int i = 0; i < Page.Application.Keys.Count; i++)
                if (Page.Application.Keys[i].StartsWith("ExpanderMenuHtml_"))
                    Page.Application[Page.Application.Keys[i]] = null;
            //
        }
        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            try
            {
                BusinessServiceImp obj = new BusinessServiceImp();
                ds = obj.AddNewUserType(TxtUserTypeName.Text);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["UserTypeCreated"].ToString() == "N")
                        {
                            showMsg.SetMessage("The user type was not created", ShowMessageType.UserError);
                        }
                        else if (ds.Tables[0].Rows[0]["UserTypeCreated"].ToString() == "Y")
                        {
                            showMsg.SetMessage("The user type is created", ShowMessageType.Information);
                        }
                    }
                }
                TxtUserTypeName.Text = "";

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



        [AjaxMethod]
        public DataSet GetUserType()
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            return obj.GetUserType();
        }
        [AjaxMethod]
        public DataSet GetSpecificUserType(string UserTypeId)
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            return obj.GetSpecificUserTypeDetails(int.Parse(UserTypeId));
        }
        [AjaxMethod]
        public DataSet DeleteUserType(string UserTypeId)
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            return obj.DeleteUserType(int.Parse(UserTypeId));
        }
        [AjaxMethod]
        public DataSet UpdateUserType(string UserTypeId, string UserTypeName)
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            return obj.UpdateUserType(int.Parse(UserTypeId), UserTypeName);
        }
    }
//}