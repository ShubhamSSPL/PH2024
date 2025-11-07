using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using MKCL.Common;
using AjaxPro;
using System.Configuration;
using Synthesys.MenuManagement.BusinessLayer;
using Synthesys.Controls;
using System.IO;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.Profile;

//namespace Synthesys.MenuManagement.MenuManagement
//{
public partial class MenuManagement_AddMenu : System.Web.UI.Page
    {
    protected HiddenField HdnSelectedUrl;
    protected HiddenField HdnEditedUrl;
    protected HiddenField HdnRefreshPage;
    protected HiddenField HdnMenuId;
    protected HiddenField HdnXML;
    protected HiddenField HdnUserLogin;
    protected DropDownList DdlModule;
    protected HtmlInputButton Btn_AddNewMenu;
    protected Button Btn_SaveMenus;
    protected Label LblNoModuleMsg;
    protected ContentBox CbAddMenu;
    protected TextBox TxtMenuName;
    protected DropDownList DdlUrl;
    protected RadioButtonList rbtIsActive;
    protected TextBox TxtQueryString;
    protected DropDownList DdlAuthenticationMode;
    protected ContentBox CbAddNewMenu;
    protected TextBox TxtEditMenuName;
    protected DropDownList DdlEditUrl;
    protected RadioButtonList rbtEditIsActive;
    protected TextBox TxtEditQueryString;
    protected DropDownList DdlEditAuthenticationMode;
    protected ContentBox CBEditMenu;
    protected Label LblDeleteMenuName;
    protected ContentBox CBDeleteMenu;
    private ShowMessage showMsg;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (this.Session["UserLoginId"] == null)
            this.Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        if (Session["UserTypeID"].ToString() != "21")
        {
            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        }
        this.showMsg = (ShowMessage)this.Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        Utility.RegisterTypeForAjax(typeof(MenuManagement_AddMenu));
        ((HiddenField)this.Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "3";
        for (int index = 0; index < this.Page.Application.Keys.Count; ++index)
        {
            if (this.Page.Application.Keys[index].StartsWith("ExpanderMenuHtml_"))
                this.Page.Application[this.Page.Application.Keys[index]] = (object)null;
        }
        if (this.IsPostBack)
            return;
        DataSet dataSet = (DataSet)null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            dataSet = obj.GetModules();
            if (dataSet.Tables.Count > 0)
            {
                this.DdlModule.DataSource = (object)dataSet.Tables[0];
                this.DdlModule.DataValueField = "ModuleId";
                this.DdlModule.DataTextField = "ModuleName";
                this.DdlModule.DataBind();
                this.DdlModule.Items.Insert(0, "-- Select --");
            }
        }
        catch (DataException ex)
        {
            this.showMsg.SetMessage((Exception)ex);
        }
        finally
        {
            dataSet?.Dispose();
        }
        this.HdnUserLogin.Value = this.Session["UserLoginId"].ToString();
    }

    protected void Btn_SaveMenus_Click(object sender, EventArgs e)
    {
        DataSet dataSet = (DataSet)null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            dataSet = obj.SaveMenus(int.Parse(this.DdlModule.SelectedValue), this.HdnXML.Value, this.Session["UserLoginId"].ToString());
            this.HdnRefreshPage.Value = "Y";
        }
        catch (DataException ex)
        {
            this.showMsg.SetMessage((Exception)ex);
        }
        finally
        {
            dataSet?.Dispose();
        }
    }

    [AjaxMethod]
    public DataSet UpdateMenu(
      string ModuleId,
      string MenuID,
      string MenuName,
      string MenuUrl,
      string IsActive,
      string AuthenticationMode,
      string RecordModifiedById,
      string QueryString,
      string ModuleName)
    {
        DataSet pagesFromDirectory = this.GetListOfPagesFromDirectory(ModuleName);
        BusinessServiceImp obj = new BusinessServiceImp();
        DataSet dataSet = obj.UpdateMenu(int.Parse(ModuleId), int.Parse(MenuID), MenuName, MenuUrl, IsActive, int.Parse(AuthenticationMode), RecordModifiedById, QueryString);
        if (dataSet != null)
        {
            pagesFromDirectory.Tables.Add(dataSet.Tables[0].Copy());
            dataSet.Dispose();
        }
        return pagesFromDirectory;
    }

    [AjaxMethod]
    public DataSet AddNewMenu(
      string ModuleId,
      string MenuName,
      string MenuUrl,
      string IsActive,
      string AuthenticationMode,
      string RecordCreatedById,
      string QueryString,
      string ModuleName)
    {
        DataSet pagesFromDirectory = this.GetListOfPagesFromDirectory(ModuleName);
        BusinessServiceImp obj = new BusinessServiceImp();
        DataSet dataSet = obj.AddNewMenu(int.Parse(ModuleId), MenuName, MenuUrl, IsActive, int.Parse(AuthenticationMode), RecordCreatedById, QueryString);
        if (dataSet != null)
        {
            pagesFromDirectory.Tables.Add(dataSet.Tables[0].Copy());
            dataSet.Dispose();
        }
        return pagesFromDirectory;
    }

    [AjaxMethod]
    public DataSet GetExistingMenuList(string ModuleId)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetListOfMenuModuleWise(int.Parse(ModuleId));
    }

    [AjaxMethod]
    public DataSet DeleteMenu(string ModuleId, string ModuleName, string MenuId)
    {
        DataSet pagesFromDirectory = this.GetListOfPagesFromDirectory(ModuleName);
        BusinessServiceImp obj = new BusinessServiceImp();
        DataSet dataSet = obj.DeleteMenu(int.Parse(ModuleId), int.Parse(MenuId));
        if (dataSet != null)
        {
            pagesFromDirectory.Tables.Add(dataSet.Tables[0].Copy());
            dataSet.Dispose();
        }
        return pagesFromDirectory;
    }

    [AjaxMethod]
    public DataSet GetSpecificMenuDetails(int MenuId, string ModuleName)
    {
        DataSet pagesFromDirectory = this.GetListOfPagesFromDirectory(ModuleName);
        BusinessServiceImp obj = new BusinessServiceImp();
        DataSet specificMenuDetail = obj.GetSpecificMenuDetail(MenuId);
        if (specificMenuDetail != null)
        {
            pagesFromDirectory.Tables.Add(specificMenuDetail.Tables[0].Copy());
            specificMenuDetail.Dispose();
        }
        return pagesFromDirectory;
    }

    [AjaxMethod]
    public DataSet GetUrlModuleWise(string ModuleName, string ModuleId)
    {
        DataSet pagesFromDirectory = this.GetListOfPagesFromDirectory(ModuleName);
        BusinessServiceImp obj = new BusinessServiceImp();
        DataSet ofMenuModuleWise = obj.GetListOfMenuModuleWise(int.Parse(ModuleId));
        if (ofMenuModuleWise != null)
        {
            pagesFromDirectory.Tables.Add(ofMenuModuleWise.Tables[0].Copy());
            ofMenuModuleWise.Dispose();
        }
        return pagesFromDirectory;
    }

    public DataSet GetListOfPagesFromDirectory(string ModuleName)
    {
        string str = AppDomain.CurrentDomain.BaseDirectory + ModuleName + "\\";
        DataSet dataSet = new DataSet();
        if (Directory.Exists(str))
        {
            ArrayList arrayList = new ArrayList((ICollection)Directory.GetFiles(str, "*.aspx", SearchOption.AllDirectories));
            arrayList.AddRange((ICollection)Directory.GetFiles(str, "*.htm", SearchOption.AllDirectories));
            arrayList.Sort();
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn()
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Text"
            });
            table.Columns.Add(new DataColumn()
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Value"
            });
            if (arrayList.Count > 0)
            {
                DataRow row1 = table.NewRow();
                row1["Text"] = (object)"--Select--";
                row1["Value"] = (object)"--Select--";
                table.Rows.Add(row1);
                for (int index = 0; index < arrayList.Count; ++index)
                {
                    DataRow row2 = table.NewRow();
                    row2["Text"] = (object)arrayList[index].ToString().Replace(str, "").Replace('\\', '/');
                    row2["Value"] = (object)arrayList[index].ToString().Replace(str, "../" + ModuleName + "/").Replace('\\', '/');
                    table.Rows.Add(row2);
                }
            }
            dataSet.Tables.Add(table);
            return dataSet;
        }
        dataSet.Tables.Add(new DataTable()
        {
            Columns = {
        new DataColumn()
        {
          DataType = Type.GetType("System.String"),
          ColumnName = "Text"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.String"),
          ColumnName = "Value"
        }
      }
        });
        return dataSet;
    }
}
//}