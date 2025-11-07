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

namespace Pharmacy2024.ARCModule
{
    public partial class frmGetARCProfile : System.Web.UI.Page
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

                    ddlUser.Items.Insert(0, "-- Select --");

                    if (UserTypeID == 33)
                    {
                        ddlUserType.Items.Remove(ddlUserType.Items.FindByValue("33"));
                    }
                    else if (UserTypeID == 34)
                    {
                        ddlUserType.Items.Remove(ddlUserType.Items.FindByValue("33"));
                        ddlUserType.Items.Remove(ddlUserType.Items.FindByValue("34"));
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                string UserLoginID = Session["UserLoginID"].ToString();

                if (ddlUserType.SelectedIndex != 0)
                {
                    if (ddlUserType.SelectedValue == "33")
                    {
                        ddlUser.DataSource = reg.getARCList(UserTypeID, UserLoginID);
                        ddlUser.DataTextField = "UserName";
                        ddlUser.DataValueField = "LoginID";
                        ddlUser.DataBind();
                        ddlUser.Items.Insert(0, "-- Select --");
                    }
                    else if (ddlUserType.SelectedValue == "34")
                    {
                        ddlUser.DataSource = reg.getSubARCList(UserTypeID, UserLoginID);
                        ddlUser.DataTextField = "UserName";
                        ddlUser.DataValueField = "LoginID";
                        ddlUser.DataBind();
                        ddlUser.Items.Insert(0, "-- Select --");
                    }
                }
                else
                {
                    ddlUser.Items.Clear();
                    ddlUser.Items.Insert(0, "-- Select --");
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlUser.SelectedIndex != 0)
                {
                    string ARCCode = ddlUser.SelectedValue;
                    ARCProfile obj = reg.getARCProfile(ARCCode);
                    tblARCProfile.Visible = true;

                    lblARCName.Text = obj.ARCName;
                    lblARCAddress.Text = obj.ARCAddress;
                    lblARCPhoneNo.Text = obj.ARCPhoneNo;
                    lblARCFaxNo.Text = obj.ARCFaxNo;
                    lblCoordinatorName.Text = obj.CoordinatorName;
                    lblCoordinatorDesignation.Text = obj.CoordinatorDesignation;
                    lblCoordinatorMobileNo.Text = obj.CoordinatorMobileNo;
                    lblCoordinatorAltMobileNo.Text = obj.CoordinatorAltMobileNo;
                    lblCoordinatorEmailID.Text = obj.CoordinatorEmailID;
                    lblCoordinatorPhoneNo.Text = obj.CoordinatorPhoneNo;
                    lblSecurityQuestion.Text = obj.SecurityQuestion;
                    lblSecurityAnswer.Text = obj.SecurityAnswer;
                }
                else
                {
                    tblARCProfile.Visible = false;

                    lblARCName.Text = "";
                    lblARCAddress.Text = "";
                    lblARCPhoneNo.Text = "";
                    lblARCFaxNo.Text = "";
                    lblCoordinatorName.Text = "";
                    lblCoordinatorDesignation.Text = "";
                    lblCoordinatorMobileNo.Text = "";
                    lblCoordinatorAltMobileNo.Text = "";
                    lblCoordinatorEmailID.Text = "";
                    lblCoordinatorPhoneNo.Text = "";
                    lblSecurityQuestion.Text = "";
                    lblSecurityAnswer.Text = "";
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