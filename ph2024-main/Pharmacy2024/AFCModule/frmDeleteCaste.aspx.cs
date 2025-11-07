using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmDeleteCaste : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
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
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    ddlCategory.DataSource = Global.MasterCategory;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, "-- Select Category --");

                    CasteDelete.Visible = false;
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlCategory.SelectedIndex != 0)
                {
                    Int16 CategoryID = Int16.Parse(ddlCategory.SelectedValue);
                    ddlCasteDelete.DataSource = reg.getMasterCasteForCategory(CategoryID);
                    ddlCasteDelete.DataTextField = "CasteName";
                    ddlCasteDelete.DataValueField = "CasteID";
                    ddlCasteDelete.DataBind();
                    ddlCasteDelete.Visible = true;
                    ddlCasteDelete.Items.Insert(0, "-- Select Caste --");

                    CasteDelete.Visible = true;
                }
                else
                {
                    CasteDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlCasteDelete.SelectedValue != "" && ddlCasteDelete.SelectedIndex != 0)
                {
                    if (reg.deleteCaste(Convert.ToInt32(ddlCasteDelete.SelectedValue)))
                    {
                        ddlCasteDelete.Items.Remove(ddlCasteDelete.SelectedItem);
                        shInfo.SetMessage("Caste Deleted Successfully.", ShowMessageType.Information);
                    }
                    else
                    {
                        shInfo.SetMessage("There is a Technical Error. Please try after sometime.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}