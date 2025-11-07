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
    public partial class frmGetAFCProfile : System.Web.UI.Page
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
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();

                    ddlUser.Items.Insert(0, "-- Select --");

                    if (UserTypeID == 23)
                    {
                        ddlUserType.Items.Remove(ddlUserType.Items.FindByValue("23"));
                    }
                    else if (UserTypeID == 24)
                    {
                        ddlUserType.Items.Remove(ddlUserType.Items.FindByValue("23"));
                        ddlUserType.Items.Remove(ddlUserType.Items.FindByValue("24"));
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
                    if (ddlUserType.SelectedValue == "23")
                    {
                        ddlUser.DataSource = reg.getAFCList(UserTypeID, UserLoginID);
                        ddlUser.DataTextField = "UserName";
                        ddlUser.DataValueField = "LoginID";
                        ddlUser.DataBind();
                        ddlUser.Items.Insert(0, "-- Select --");
                    }
                    else if (ddlUserType.SelectedValue == "24")
                    {
                        ddlUser.DataSource = reg.getSubAFCList(UserTypeID, UserLoginID);
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
                    string AFCCode = ddlUser.SelectedValue;
                    AFCProfile obj = reg.getAFCProfile(AFCCode);
                    tblAFCProfile.Visible = true;

                    lblAFCName.Text = obj.AFCName;
                    lblAFCAddress.Text = obj.AFCAddress;
                    lblAFCPhoneNo.Text = obj.AFCPhoneNo;
                    lblAFCFaxNo.Text = obj.AFCFaxNo;
                    lblCoordinatorName.Text = obj.CoordinatorName;
                    lblCoordinatorDesignation.Text = obj.CoordinatorDesignation;
                    lblCoordinatorMobileNo.Text = obj.CoordinatorMobileNo;
                    lblCoordinatorAltMobileNo.Text = obj.CoordinatorAltMobileNo;
                    lblCoordinatorEmailID.Text = obj.CoordinatorEmailID;
                    lblCoordinatorPhoneNo.Text = obj.CoordinatorPhoneNo;
                    //lblSecurityQuestion.Text = obj.SecurityQuestion;
                    //lblSecurityAnswer.Text = obj.SecurityAnswer;
                }
                else
                {
                    tblAFCProfile.Visible = false;

                    lblAFCName.Text = "";
                    lblAFCAddress.Text = "";
                    lblAFCPhoneNo.Text = "";
                    lblAFCFaxNo.Text = "";
                    lblCoordinatorName.Text = "";
                    lblCoordinatorDesignation.Text = "";
                    lblCoordinatorMobileNo.Text = "";
                    lblCoordinatorAltMobileNo.Text = "";
                    lblCoordinatorEmailID.Text = "";
                    lblCoordinatorPhoneNo.Text = "";
                    //lblSecurityQuestion.Text = "";
                    //lblSecurityAnswer.Text = "";
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