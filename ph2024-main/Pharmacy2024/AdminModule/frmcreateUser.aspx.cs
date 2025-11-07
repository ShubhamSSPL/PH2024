using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityModel;
using System.Data;
using System.Configuration;
using BusinessLayer;
using System.Text;
using Synthesys.Controls;

namespace Pharmacy2024.AdminModule
{
    public partial class frmcreateUser : System.Web.UI.Page
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

                //    Int16 RegionID = 0;
                  //  RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));                

                    ddlUserType.DataSource = reg.getMasterUserType();
                    ddlUserType.DataTextField = "UserTypeName";
                    ddlUserType.DataValueField = "UserTypeID";
                    ddlUserType.DataBind();
                    ddlUserType.Items.Insert(0, "-- Select --");
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

                // Int64 AFCID = Convert.ToInt64(Session["UserID"]);
                string LoginId = txtLoginId.Text;
                string UserName = txtUserName.Text;
                string UserMobNo = txtuserMobileNo.Text;
                string UserEmailId = txtuserEmailId.Text;
                string UserPassword = txtPassword.Text;

                // string Password = GeneratePassword(6);
                Int64 UserTypeId = Convert.ToInt64(ddlUserType.SelectedValue);
                if (reg.chkDuplicateMasterUserName(txtLoginId.Text))
                {


                    //  RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                    //string LoginID = reg.addSubAFC(AFCID, SubAFCOfficerName, SubAFCOfficerMobileNo, HashSHA1Password(Password), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                    // addMasterUser(string UserName,string LoginId,string UserPassword,string EncryptedPassword,int UserTypeId,string UserMobNo,string UserEmailId,string CreatedBy,string CreatedByIPAddress)
                    if (reg.addMasterUser(UserName, LoginId, UserPassword, HashSHA1Password(UserPassword), UserTypeId, UserMobNo, UserEmailId, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))

                    {


                        shInfo.SetMessage("User Added Successfully.<br />LoginID : " + LoginId + "  AND Password : " + UserPassword, ShowMessageType.Information);

                        txtLoginId.Text = "";
                        txtUserName.Text = "";
                        txtuserMobileNo.Text = "";
                        txtPassword.Text = "";
                        txtuserEmailId.Text = "";
                        ddlUserType.ClearSelection();
                    }
                     else
                    {
                        shInfo.SetMessage("Can not add Record.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("Can not add Duplicate Login Id ", ShowMessageType.Information);
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

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}