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
    public partial class frmControlSubARC : System.Web.UI.Page
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

                    ddlSubARCUpdate.DataSource = ddlSubARCDelete.DataSource = reg.getSubARCList(AFCID);
                    ddlSubARCUpdate.DataTextField = ddlSubARCDelete.DataTextField = "SubARCOfficerName";
                    ddlSubARCUpdate.DataValueField = ddlSubARCDelete.DataValueField = "SubARCID";
                    ddlSubARCDelete.DataBind();
                    ddlSubARCUpdate.DataBind();
                    ddlSubARCDelete.Items.Insert(0, "-- Select --");
                    ddlSubARCUpdate.Items.Insert(0, "-- Select --");
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 AFCID = Convert.ToInt64(Session["UserID"]);
                String SubARCOfficerName = txtSubARCOfficerName.Text.ToUpper();
                string SubARCOfficerMobileNo = txtSubARCOfficerMobileNo.Text;
                string Password = GeneratePassword(6);

                string LoginID = reg.addSubARC(AFCID, SubARCOfficerName, SubARCOfficerMobileNo, DataEncryption.EncryptDataByHashSHA1(Password), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                if (LoginID.Length > 7)
                {
                    ddlSubARCUpdate.DataSource = ddlSubARCDelete.DataSource = reg.getSubARCList(AFCID);
                    ddlSubARCUpdate.DataTextField = ddlSubARCDelete.DataTextField = "SubARCOfficerName";
                    ddlSubARCUpdate.DataValueField = ddlSubARCDelete.DataValueField = "SubARCID";
                    ddlSubARCDelete.DataBind();
                    ddlSubARCUpdate.DataBind();
                    ddlSubARCDelete.Items.Insert(0, "-- Select --");
                    ddlSubARCUpdate.Items.Insert(0, "-- Select --");

                    txtSubARCOfficerName.Text = "";
                    txtSubARCOfficerMobileNo.Text = "";

                    shInfo.SetMessage("Sub-ARC Added Successfully.<br />LoginID : " + LoginID + "  AND Password : " + Password, ShowMessageType.Information);
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
                Int64 SubARCID = Convert.ToInt64(ddlSubARCUpdate.SelectedValue);
                string SubARCOfficerName = txtSubARCOfficerNameUpdate.Text.ToUpper();
                string SubARCOfficerMobileNo = txtSubARCOfficerMobileNoUpdate.Text;

                if (reg.updateSubARC(SubARCID, SubARCOfficerName, SubARCOfficerMobileNo, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ddlSubARCUpdate.DataSource = ddlSubARCDelete.DataSource = reg.getSubARCList(AFCID);
                    ddlSubARCUpdate.DataTextField = ddlSubARCDelete.DataTextField = "SubARCOfficerName";
                    ddlSubARCUpdate.DataValueField = ddlSubARCDelete.DataValueField = "SubARCID";
                    ddlSubARCDelete.DataBind();
                    ddlSubARCUpdate.DataBind();
                    ddlSubARCDelete.Items.Insert(0, "-- Select --");
                    ddlSubARCUpdate.Items.Insert(0, "-- Select --");

                    txtSubARCOfficerNameUpdate.Text = "";
                    txtSubARCOfficerMobileNoUpdate.Text = "";

                    shInfo.SetMessage("Sub-ARC Updated Successfully.", ShowMessageType.Information);
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
                Int64 SubARCID = Convert.ToInt64(ddlSubARCDelete.SelectedValue);

                if (reg.deleteSubARC(SubARCID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ddlSubARCUpdate.DataSource = ddlSubARCDelete.DataSource = reg.getSubARCList(AFCID);
                    ddlSubARCUpdate.DataTextField = ddlSubARCDelete.DataTextField = "SubARCOfficerName";
                    ddlSubARCUpdate.DataValueField = ddlSubARCDelete.DataValueField = "SubARCID";
                    ddlSubARCDelete.DataBind();
                    ddlSubARCUpdate.DataBind();
                    ddlSubARCDelete.Items.Insert(0, "-- Select --");
                    ddlSubARCUpdate.Items.Insert(0, "-- Select --");

                    shInfo.SetMessage("Sub-ARC Deleted Successfully.", ShowMessageType.Information);
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