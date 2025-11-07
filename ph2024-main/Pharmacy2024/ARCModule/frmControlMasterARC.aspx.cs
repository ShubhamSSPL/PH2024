using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ARCModule
{
    public partial class frmControlMasterARC : System.Web.UI.Page
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
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();

                    ddlInstituteAdd.DataSource = reg.getNonARCInstituteList(UserTypeID, UserLoginID);
                    ddlInstituteAdd.DataTextField = "InstituteName";
                    ddlInstituteAdd.DataValueField = "InstituteID";
                    ddlInstituteAdd.DataBind();
                    ddlInstituteAdd.Items.Insert(0, "-- Select --");

                    ddlInstituteDelete.DataSource = reg.getMasterARCList(UserTypeID, UserLoginID);
                    ddlInstituteDelete.DataTextField = "InstituteName";
                    ddlInstituteDelete.DataValueField = "InstituteID";
                    ddlInstituteDelete.DataBind();
                    ddlInstituteDelete.Items.Insert(0, "-- Select --");
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                string UserLoginID = Session["UserLoginID"].ToString();

                if (reg.addMasterARC(Convert.ToInt64(ddlInstituteAdd.SelectedValue), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ddlInstituteAdd.DataSource = reg.getNonARCInstituteList(UserTypeID, UserLoginID);
                    ddlInstituteAdd.DataTextField = "InstituteName";
                    ddlInstituteAdd.DataValueField = "InstituteID";
                    ddlInstituteAdd.DataBind();
                    ddlInstituteAdd.Items.Insert(0, "-- Select --");

                    ddlInstituteDelete.DataSource = reg.getMasterARCList(UserTypeID, UserLoginID);
                    ddlInstituteDelete.DataTextField = "InstituteName";
                    ddlInstituteDelete.DataValueField = "InstituteID";
                    ddlInstituteDelete.DataBind();
                    ddlInstituteDelete.Items.Insert(0, "-- Select --");

                    Global.MasterARC = reg.getMasterARC();

                    shInfo.SetMessage("Master ARC Added Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Can not add Record.", ShowMessageType.Information);
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
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                string UserLoginID = Session["UserLoginID"].ToString();

                if (reg.deleteMasterARC(Convert.ToInt64(ddlInstituteDelete.SelectedValue), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ddlInstituteAdd.DataSource = reg.getNonARCInstituteList(UserTypeID, UserLoginID);
                    ddlInstituteAdd.DataTextField = "InstituteName";
                    ddlInstituteAdd.DataValueField = "InstituteID";
                    ddlInstituteAdd.DataBind();
                    ddlInstituteAdd.Items.Insert(0, "-- Select --");

                    ddlInstituteDelete.DataSource = reg.getMasterARCList(UserTypeID, UserLoginID);
                    ddlInstituteDelete.DataTextField = "InstituteName";
                    ddlInstituteDelete.DataValueField = "InstituteID";
                    ddlInstituteDelete.DataBind();
                    ddlInstituteDelete.Items.Insert(0, "-- Select --");

                    Global.MasterARC = reg.getMasterARC();

                    shInfo.SetMessage("Master ARC Deleted Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Can not delete record.", ShowMessageType.Information);
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