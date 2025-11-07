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
public partial class CMS_ListOfContents : System.Web.UI.Page
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
        if (Session["UserTypeID"].ToString() != "21")
        {
            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        }
        showMsg = (ShowMessage)Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        showMsg = (ShowMessage)Master.FindControl(ConfigurationManager.AppSettings["ShowMessage_DynamicMaster"]);
        // set expander menu properties
        ((HiddenField)Master.FindControl(ConfigurationManager.AppSettings["HiddenFormType_DynamicMaster"])).Value = "4";
        //
        if (!IsPostBack)
        {
            try
            {
                GetContent();
            }
            catch (Exception ex)
            { showMsg.SetMessage(ex); }
        }
    }
    private void GetContent()
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        DataSet ds = null;
        ds = obj.GetListOfContents();

        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvContentList.DataSource = ds.Tables[0];
                GvContentList.DataBind();
            }
        }
    }
    protected void DeleteButton_Command(object sender, CommandEventArgs e)
    {
        DataSet ds = null;
        try
        {
            HdnContentId.Value = Server.HtmlDecode(e.CommandArgument.ToString());
            HdnShowPopUp.Value = "Y";
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

        try
        {
            string ContentId = Server.HtmlDecode(e.CommandArgument.ToString());
            Response.Redirect("AddNewContent.aspx?cid=" + ContentId);

        }
        catch (Exception ms)
        {
            showMsg.SetMessage(ms.Message, ShowMessageType.TechnicalError);
        }

    }
    protected void Btn_Save_click(object sender, EventArgs e)
    {
        DataSet ds = null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.AddNewContentName(TxtContentName.Text, Session["UserLoginId"].ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string ContentId = ds.Tables[0].Rows[0]["ContentId"].ToString();
                    Response.Redirect("AddNewContent.aspx?cid=" + ContentId);
                }
            }


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
    protected void Btn_Delete_Click(object sender, EventArgs e)
    {
        DataSet ds = null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.DeleteContentByContentId(int.Parse(HdnContentId.Value));
            GetContent();
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
}
