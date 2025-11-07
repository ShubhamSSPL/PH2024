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
using System.Web.Profile;

//namespace Synthesys.MenuManagement.MenuManagement
//{
public partial class MenuManagement_UserMgt : System.Web.UI.Page
    {
    protected HiddenField HdnRefreshPage;
    protected HiddenField HdnLoginId;
    protected HiddenField HdnXML;
    protected HiddenField HdnPassword;
    protected DropDownList DdlUserType;
    protected Button Btn_Add;
    protected Button Btn_SaveUsers;
    protected ContentBox CbAddUser;
    protected TextBox TxtUserName;
    protected TextBox TxtLoginId;
    protected TextBox TxtPassword;
    protected RadioButtonList rbtIsActive;
    protected Button Btn_Save;
    protected ContentBox CbNewAddUser;
    protected TextBox TxtEditUserName;
    protected TextBox TxtEditLogin;
    protected TextBox TxtEditPassword;
    protected RadioButtonList rbtEditIsActive;
    protected Button Btn_Update;
    protected ContentBox CbEditUser;
    protected Label LblDeleteUserName;
    protected ContentBox CBDeleteUser;
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
        Utility.RegisterTypeForAjax(typeof(MenuManagement_UserMgt));
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
            dataSet = obj.GetUserType();
            if (dataSet.Tables.Count <= 0)
                return;
            this.DdlUserType.DataSource = (object)dataSet.Tables[0];
            this.DdlUserType.DataValueField = "UserTypeID";
            this.DdlUserType.DataTextField = "UserTypeName";
            this.DdlUserType.DataBind();
            this.DdlUserType.Items.Insert(0, "-- Select --");
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

    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        DataSet dataSet = (DataSet)null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            dataSet = obj.AddNewUser(int.Parse(this.DdlUserType.SelectedValue), this.TxtUserName.Text, this.TxtLoginId.Text, this.TxtPassword.Text, this.rbtIsActive.Items[0].Selected ? "Y" : "N");
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["userExists"].ToString() == "Y")
                this.showMsg.SetMessage("A user with this login id and password already exist .Please enter different login id and password values", ShowMessageType.Information);
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

    protected void Btn_Update_Click(object sender, EventArgs e)
    {
        DataSet dataSet = (DataSet)null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            dataSet = obj.UpdateUser(int.Parse(this.DdlUserType.SelectedValue), this.TxtEditUserName.Text, this.TxtEditLogin.Text, this.TxtEditPassword.Text, this.rbtEditIsActive.Items[0].Selected ? "Y" : "N", this.HdnLoginId.Value, this.HdnPassword.Value);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["userExists"].ToString() == "Y")
                this.showMsg.SetMessage("A user with this login id and password already exist .Please enter different login id and password values", ShowMessageType.Information);
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

    protected void Btn_SaveUsers_Click(object sender, EventArgs e)
    {
        DataSet dataSet = (DataSet)null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            dataSet = obj.SaveUsers(int.Parse(this.DdlUserType.SelectedValue), this.HdnXML.Value);
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
    public DataSet GetUsersUserTypeWise(string UserTypeID)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetUsersUserTypeWise(int.Parse(UserTypeID));
    }

    [AjaxMethod]
    public DataSet GetSpecificUserDetails(int UserTypeID, string LoginId, string Password)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.GetSpecificUserDetails(UserTypeID, LoginId, Password);
    }

    [AjaxMethod]
    public DataSet DeleteUser(int UserTypeID, string LoginId, string Password)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        return obj.DeleteUser(UserTypeID, LoginId, Password);
    }
}
//}