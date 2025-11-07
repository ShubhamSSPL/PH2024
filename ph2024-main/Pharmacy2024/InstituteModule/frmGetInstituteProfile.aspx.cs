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

namespace Pharmacy2024.InstituteModule
{
    public partial class frmGetInstituteProfile : System.Web.UI.Page
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

                    ddlInstitute.DataSource = reg.getInstituteList(UserTypeID, UserLoginID);
                    ddlInstitute.DataTextField = "Name";
                    ddlInstitute.DataValueField = "LoginID";
                    ddlInstitute.DataBind();
                    ddlInstitute.Items.Insert(0, new ListItem("-- Select --", "0"));
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlInstitute.SelectedIndex != 0)
                {
                    tblInstituteProfile.Visible = true;

                    InstituteProfile obj = reg.getInstituteProfile(Convert.ToInt32(ddlInstitute.SelectedValue));

                    lblInstituteName.Text = obj.InstituteName;
                    lblInstituteAddress.Text = obj.InstituteAddress;
                    lblInstitutePhoneNo.Text = obj.InstitutePhoneNo;
                    lblInstituteFaxNo.Text = obj.InstituteFaxNo;
                    lblCoordinatorName.Text = obj.CoordinatorName;
                    lblCoordinatorDesignation.Text = obj.CoordinatorDesignation;
                    lblCoordinatorMobileNo.Text = obj.CoordinatorMobileNo;
                    lblCoordinatorAltMobileNo.Text = obj.CoordinatorAltMobileNo;
                    lblCoordinatorEmailID.Text = obj.CoordinatorEmailID;
                    lblCoordinatorPhoneNo.Text = obj.CoordinatorPhoneNo;
                }
                else
                {
                    tblInstituteProfile.Visible = false;

                    lblInstituteName.Text = "";
                    lblInstituteAddress.Text = "";
                    lblInstitutePhoneNo.Text = "";
                    lblInstituteFaxNo.Text = "";
                    lblCoordinatorName.Text = "";
                    lblCoordinatorDesignation.Text = "";
                    lblCoordinatorMobileNo.Text = "";
                    lblCoordinatorAltMobileNo.Text = "";
                    lblCoordinatorEmailID.Text = "";
                    lblCoordinatorPhoneNo.Text = "";
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