using BusinessLayer;
using EntityModel;
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
    public partial class frmUpdateCaste : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    ddlCategoryEdit.DataSource = Global.MasterCategory;
                    ddlCategoryEdit.DataTextField = "CategoryName";
                    ddlCategoryEdit.DataValueField = "CategoryID";
                    ddlCategoryEdit.DataBind();
                    ddlCategoryEdit.Items.Insert(0, "-- Select Category --");

                    CasteEdit.Visible = false;
                    ContentTableControlEditVenue.Visible = false;
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlCategoryEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlCategoryEdit.SelectedIndex != 0)
                {
                    Int16 CategoryID = Int16.Parse(ddlCategoryEdit.SelectedValue);
                    ddlCasteEdit.DataSource = reg.getMasterCasteForCategory(CategoryID);
                    ddlCasteEdit.DataTextField = "CasteName";
                    ddlCasteEdit.DataValueField = "CasteID";
                    ddlCasteEdit.DataBind();
                    ddlCasteEdit.Visible = true;
                    ddlCasteEdit.Items.Insert(0, "-- Select Caste --");
                    CasteEdit.Visible = true;
                }
                else
                {
                    CasteEdit.Visible = false;
                }
                ContentTableControlEditVenue.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlCasteEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlCasteEdit.SelectedIndex != 0)
                {
                    CasteList obj = new CasteList();
                    int CasteID = int.Parse(ddlCasteEdit.SelectedValue);
                    obj = reg.getCaste(CasteID);

                    txtCasteName.Text = obj.CasteName;
                    txtCasteSerialNumber.Text = obj.CasteSrNo;

                    ContentTableControlEditVenue.Visible = true;
                }
                else
                {
                    ContentTableControlEditVenue.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                CasteList obj = new CasteList();

                obj.CasteName = txtCasteName.Text;
                obj.CasteID = int.Parse(ddlCasteEdit.SelectedValue);
                obj.CasteSrNo = txtCasteSerialNumber.Text;

                if (reg.updateCaste(obj))
                {
                    shInfo.SetMessage("Caste Updated Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
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