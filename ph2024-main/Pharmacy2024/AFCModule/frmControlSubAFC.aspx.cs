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
    public partial class frmControlSubAFC : System.Web.UI.Page
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
                    Int64 AFCID = Convert.ToInt64(Session["UserID"]);
                    ddlSubAFCUpdate.DataSource = ddlSubAFCDelete.DataSource = reg.getSubAFCList(AFCID);
                    ddlSubAFCUpdate.DataTextField = ddlSubAFCDelete.DataTextField = "SubAFCOfficerName";
                    ddlSubAFCUpdate.DataValueField = ddlSubAFCDelete.DataValueField = "SubAFCID";
                    ddlSubAFCDelete.DataBind();
                    ddlSubAFCUpdate.DataBind();
                    ddlSubAFCDelete.Items.Insert(0, "-- Select --");
                    ddlSubAFCUpdate.Items.Insert(0, "-- Select --");
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        private string GeneratePassword(Int16 PasswordLength)
        {
            string allowedChars = "A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z,2,3,4,5,6,7,8,9";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (Int16 i = 0; i < PasswordLength; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }
            return passwordString;
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 AFCID = Convert.ToInt64(Session["UserID"]);
                String SubAFCOfficerName = txtSubAFCOfficerName.Text.ToUpper();
                string SubAFCOfficerMobileNo = txtSubAFCOfficerMobileNo.Text;
                string Password = GeneratePassword(6);

                string LoginID = reg.addSubAFC(AFCID, SubAFCOfficerName, SubAFCOfficerMobileNo, HashSHA1Password(Password), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                if (LoginID.Length > 6)
                {
                    ddlSubAFCUpdate.DataSource = ddlSubAFCDelete.DataSource = reg.getSubAFCList(AFCID);
                    ddlSubAFCUpdate.DataTextField = ddlSubAFCDelete.DataTextField = "SubAFCOfficerName";
                    ddlSubAFCUpdate.DataValueField = ddlSubAFCDelete.DataValueField = "SubAFCID";
                    ddlSubAFCDelete.DataBind();
                    ddlSubAFCUpdate.DataBind();
                    ddlSubAFCDelete.Items.Insert(0, "-- Select --");
                    ddlSubAFCUpdate.Items.Insert(0, "-- Select --");

                    txtSubAFCOfficerName.Text = "";
                    txtSubAFCOfficerMobileNo.Text = "";

                    shInfo.SetMessage("Sub-SC Added Successfully.<br />LoginID : " + LoginID + "  AND Password : " + Password, ShowMessageType.Information);
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 AFCID = Convert.ToInt64(Session["UserID"]);
                Int64 SubAFCID = Convert.ToInt64(ddlSubAFCUpdate.SelectedValue);
                string SubAFCOfficerName = txtSubAFCOfficerNameUpdate.Text.ToUpper();
                string SubAFCOfficerMobileNo = txtSubAFCOfficerMobileNoUpdate.Text;

                if (reg.updateSubAFC(SubAFCID, SubAFCOfficerName, SubAFCOfficerMobileNo, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ddlSubAFCUpdate.DataSource = ddlSubAFCDelete.DataSource = reg.getSubAFCList(AFCID);
                    ddlSubAFCUpdate.DataTextField = ddlSubAFCDelete.DataTextField = "SubAFCOfficerName";
                    ddlSubAFCUpdate.DataValueField = ddlSubAFCDelete.DataValueField = "SubAFCID";
                    ddlSubAFCDelete.DataBind();
                    ddlSubAFCUpdate.DataBind();
                    ddlSubAFCDelete.Items.Insert(0, "-- Select --");
                    ddlSubAFCUpdate.Items.Insert(0, "-- Select --");

                    txtSubAFCOfficerNameUpdate.Text = "";
                    txtSubAFCOfficerMobileNoUpdate.Text = "";

                    shInfo.SetMessage("Sub-SC Updated Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Can not update Record.", ShowMessageType.Information);
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
                Int64 AFCID = Convert.ToInt64(Session["UserID"]);
                Int64 SubAFCID = Convert.ToInt64(ddlSubAFCDelete.SelectedValue);

                if (reg.deleteSubAFC(SubAFCID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ddlSubAFCUpdate.DataSource = ddlSubAFCDelete.DataSource = reg.getSubAFCList(AFCID);
                    ddlSubAFCUpdate.DataTextField = ddlSubAFCDelete.DataTextField = "SubAFCOfficerName";
                    ddlSubAFCUpdate.DataValueField = ddlSubAFCDelete.DataValueField = "SubAFCID";
                    ddlSubAFCDelete.DataBind();
                    ddlSubAFCUpdate.DataBind();
                    ddlSubAFCDelete.Items.Insert(0, "-- Select --");
                    ddlSubAFCUpdate.Items.Insert(0, "-- Select --");

                    shInfo.SetMessage("Sub-SC Deleted Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Can not Delete Record.", ShowMessageType.Information);
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