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
public partial class ContentManagement_ContentMgt : System.Web.UI.Page
{
    private ShowMessage showMsg;
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
        showMsg = (ShowMessage)Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        // set expander menu properties
        ((HiddenField)Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "4";
        //
        if (!IsPostBack)
        {
            try
            {
                GetMenuData();
            }
            catch (Exception ex)
            { showMsg.SetMessage(ex); }
        }
    }

    private void GetMenuData()
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        DataSet ds = null;
        ds = obj.GetMenues();

        if (ds.Tables[0].Rows.Count != 0)
        {
            //
            int i = 0, userTypeId, groupId, detailId;
            bool flag = false;
            while (i < ds.Tables[0].Rows.Count)      // user type wise
            {
                //
                userTypeId = Convert.ToInt32(ds.Tables[0].Rows[i]["UserTypeId"]);
                TreeNode userTypeNode = new TreeNode(Convert.ToString(ds.Tables[0].Rows[i]["UserTypeName"]));
                userTypeNode.NavigateUrl = "#";

                while (i < ds.Tables[0].Rows.Count &&
                    userTypeId == Convert.ToInt32(ds.Tables[0].Rows[i]["UserTypeId"]))   // group wise
                {
                    //
                    groupId = Convert.ToInt32(ds.Tables[0].Rows[i]["GroupId"]);
                    detailId = Convert.ToInt32(ds.Tables[0].Rows[i]["DetailId"]);
                    TreeNode menuGroupNode = new TreeNode(Convert.ToString(ds.Tables[0].Rows[i]["GroupName"]));
                    menuGroupNode.NavigateUrl = "#";
                    flag = false;
                    while (i < ds.Tables[0].Rows.Count &&
                        groupId == Convert.ToInt32(ds.Tables[0].Rows[i]["GroupId"]) && groupId != 0 && detailId != 0)   // menu wise
                    {
                        //
                        TreeNode menuNode = new TreeNode(Convert.ToString(ds.Tables[0].Rows[i]["MenuName"]));
                        //menuNode.NavigateUrl = "../ContentManagement/ContentEditor.aspx?utid=" + userTypeId.ToString()
                        //    + "&gid=" + groupId.ToString() + "&mid" + Convert.ToString(ds.Tables[0].Rows[i]["MenuId"])
                        //    + "&did" + Convert.ToString(ds.Tables[0].Rows[i]["DetailId"]);
                        menuNode.NavigateUrl = "../CMS/ContentNewEditor.aspx?did=" + Convert.ToString(ds.Tables[0].Rows[i]["DetailId"]);
                        menuGroupNode.ChildNodes.Add(menuNode);
                        i++;
                        flag = true;
                        //
                    }
                    userTypeNode.ChildNodes.Add(menuGroupNode);
                    if (!flag)
                        i++;
                    //
                }
                tvContentManagement.Nodes.Add(userTypeNode);
                //
            }
            //
        }

        if (ds != null)
            ds.Dispose();
    }
}
