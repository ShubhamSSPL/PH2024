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
    public partial class frmControlARC : System.Web.UI.Page
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
                    Int64 InstituteID = Convert.ToInt64(Session["UserID"]);

                    if (reg.isInstituteWorkingAsARC(InstituteID))
                    {
                        ddlARCUpdate.DataSource = ddlARCDelete.DataSource = reg.getARCList(InstituteID);
                        ddlARCUpdate.DataTextField = ddlARCDelete.DataTextField = "ARCOfficerName";
                        ddlARCUpdate.DataValueField = ddlARCDelete.DataValueField = "ARCID";
                        ddlARCDelete.DataBind();
                        ddlARCUpdate.DataBind();
                        ddlARCDelete.Items.Insert(0, "-- Select --");
                        ddlARCUpdate.Items.Insert(0, "-- Select --");
                    }
                    else
                    {
                        ContentBox1.Visible = false;
                        ContentBox2.Visible = false;
                        ContentBox3.Visible = false;
                        shInfo.SetMessage("You are not authorised to Control ARC.", ShowMessageType.Information);
                    }
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
                Int64 InstituteID = Convert.ToInt64(Session["UserID"]);
                string ARCOfficerName = txtARCOfficerName.Text.ToUpper();
                string ARCOfficerMobileNo = txtARCOfficerMobileNo.Text;
                string Password = GeneratePassword(6);

                string LoginID = reg.addARC(InstituteID, ARCOfficerName, ARCOfficerMobileNo, DataEncryption.EncryptDataByHashSHA1(Password), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                if (LoginID.Length == 7)
                {
                    ddlARCUpdate.DataSource = ddlARCDelete.DataSource = reg.getARCList(InstituteID);
                    ddlARCUpdate.DataTextField = ddlARCDelete.DataTextField = "ARCOfficerName";
                    ddlARCUpdate.DataValueField = ddlARCDelete.DataValueField = "ARCID";
                    ddlARCDelete.DataBind();
                    ddlARCUpdate.DataBind();
                    ddlARCDelete.Items.Insert(0, "-- Select --");
                    ddlARCUpdate.Items.Insert(0, "-- Select --");

                    txtARCOfficerName.Text = "";
                    txtARCOfficerMobileNo.Text = "";

                    Global.MasterARC = reg.getMasterARC();

                    shInfo.SetMessage("ARC Added Successfully.<br />LoginID : " + LoginID + "  AND Password : " + Password, ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("You can add only one ARC Officer.", ShowMessageType.Information);
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
                Int64 InstituteID = Convert.ToInt64(Session["UserID"]);
                Int64 ARCID = Convert.ToInt64(ddlARCUpdate.SelectedValue);
                string ARCOfficerName = txtARCOfficerNameUpdate.Text.ToUpper();
                String ARCOfficerMobileNo = txtARCOfficerMobileNoUpdate.Text;

                if (reg.updateARC(ARCID, ARCOfficerName, ARCOfficerMobileNo, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ddlARCUpdate.DataSource = ddlARCDelete.DataSource = reg.getARCList(InstituteID);
                    ddlARCUpdate.DataTextField = ddlARCDelete.DataTextField = "ARCOfficerName";
                    ddlARCUpdate.DataValueField = ddlARCDelete.DataValueField = "ARCID";
                    ddlARCDelete.DataBind();
                    ddlARCUpdate.DataBind();
                    ddlARCDelete.Items.Insert(0, "-- Select --");
                    ddlARCUpdate.Items.Insert(0, "-- Select --");

                    txtARCOfficerNameUpdate.Text = "";
                    txtARCOfficerMobileNoUpdate.Text = "";

                    Global.MasterARC = reg.getMasterARC();

                    shInfo.SetMessage("ARC Updated Successfully.", ShowMessageType.Information);
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
                Int64 InstituteID = Convert.ToInt64(Session["UserID"]);
                Int64 ARCID = Convert.ToInt64(ddlARCDelete.SelectedValue);

                if (reg.deleteARC(ARCID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ddlARCUpdate.DataSource = ddlARCDelete.DataSource = reg.getARCList(InstituteID);
                    ddlARCUpdate.DataTextField = ddlARCDelete.DataTextField = "ARCOfficerName";
                    ddlARCUpdate.DataValueField = ddlARCDelete.DataValueField = "ARCID";
                    ddlARCDelete.DataBind();
                    ddlARCUpdate.DataBind();
                    ddlARCDelete.Items.Insert(0, "-- Select --");
                    ddlARCUpdate.Items.Insert(0, "-- Select --");

                    Global.MasterARC = reg.getMasterARC();

                    shInfo.SetMessage("ARC Deleted Successfully.", ShowMessageType.Information);
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