using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmResetPassword : System.Web.UI.Page
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

                    lblLoginID.Text = "";
                }
                else
                {
                    ddlUser.Items.Clear();
                    ddlUser.Items.Insert(0, "-- Select --");
                    lblLoginID.Text = "";
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
                    string strLoginDetails = reg.getPassword(Convert.ToInt32(ddlUserType.SelectedValue), ddlUser.SelectedValue);

                    lblLoginID.Text = strLoginDetails.Split(";".ToCharArray())[0];
                }
                else
                {
                    lblLoginID.Text = "";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        public static string HashSHA1Password(string Password)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(Password);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (reg.resetPassword(Convert.ToInt32(ddlUserType.SelectedValue), ddlUser.SelectedValue, HashSHA1Password(txtPassword.Text), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    if (ddlUser.SelectedIndex != 0)
                    {
                        string strLoginDetails = reg.getPassword(Convert.ToInt32(ddlUserType.SelectedValue), ddlUser.SelectedValue);

                        lblLoginID.Text = strLoginDetails.Split(";".ToCharArray())[0];
                    }
                    else
                    {
                        lblLoginID.Text = "";
                    }

                    shInfo.SetMessage("Password Changed Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Can Not Change Password.", ShowMessageType.Information);
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