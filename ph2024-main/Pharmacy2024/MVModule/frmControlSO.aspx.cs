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

namespace Pharmacy2024.MVModule
{
    public partial class frmControlSO : System.Web.UI.Page
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

                    string RegionName = "";
                    if (Request.QueryString["RegionName"] != null)
                    {
                        RegionName = Request.QueryString["RegionName"].ToString();
                    }
                    else
                    {
                        RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                    }

                    Int16 RegionID;
                    RegionID = reg.getRORegionID(RegionName);

                    ddlSOUpdate.DataSource = ddlSODelete.DataSource = reg.getMVSOList(RegionID);
                    ddlSOUpdate.DataTextField = ddlSODelete.DataTextField = "SOOfficerName";
                    ddlSOUpdate.DataValueField = ddlSODelete.DataValueField = "SOID";
                    ddlSODelete.DataBind();
                    ddlSOUpdate.DataBind();
                    ddlSODelete.Items.Insert(0, "-- Select --");
                    ddlSOUpdate.Items.Insert(0, "-- Select --");
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

               // Int64 AFCID = Convert.ToInt64(Session["UserID"]);
                String ScrutinyOfficerName = txtSOName.Text.ToUpper();
                string ScrutinyOfficerMobileNo = txtSOMobileNo.Text;
                string ScrutinyOfficerEmailID = txtSOEmailId.Text;
                string ScrutinyOfficerDesignation = txtSODesignation.Text;

                string Password = GeneratePassword(6);

                string RegionName = "";
                if (Request.QueryString["RegionName"] != null)
                {
                    RegionName = Request.QueryString["RegionName"].ToString();
                }
                else
                {
                    RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                }

                Int16 RegionID;
                RegionID = reg.getRORegionID(RegionName);
                //string LoginID = reg.addSubAFC(AFCID, SubAFCOfficerName, SubAFCOfficerMobileNo, HashSHA1Password(Password), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                string LoginID = reg.addMVSO( ScrutinyOfficerName,  ScrutinyOfficerMobileNo, ScrutinyOfficerEmailID, ScrutinyOfficerDesignation, HashSHA1Password(Password), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(),  RegionID, Password);
                if (LoginID.Length > 3)
                {
                    ddlSOUpdate.DataSource = ddlSODelete.DataSource = reg.getMVSOList(RegionID);
                    ddlSOUpdate.DataTextField = ddlSODelete.DataTextField = "SOOfficerName";
                    ddlSOUpdate.DataValueField = ddlSODelete.DataValueField = "SOID";
                    ddlSODelete.DataBind();
                    ddlSOUpdate.DataBind();
                    ddlSODelete.Items.Insert(0, "-- Select --");
                    ddlSOUpdate.Items.Insert(0, "-- Select --");

                    //txtSOName.Text = "";
                    //txtSOMobileNo.Text = "";

                    //SMS objSMS = new SMS();
                    //string Message = ConfigurationManager.AppSettings["Project_Name"].ToString() + " : Dear " + AFCID + ", Your SubFC has been Created LoginID: " + LoginID + "Password : " + Password;
                    //objSMS.sendSingleSMS(SOOfficerMobileNo, Message);

                    SMSTemplate sMSTemplate = new SMSTemplate();
                    SynCommon synCommon = new SynCommon();
                    //sMSTemplate.InstituteID = LoginID.ToString();
                    sMSTemplate.InstituteID = txtSOName.Text;
                    sMSTemplate.LoginID = LoginID;
                    sMSTemplate.Password = Password;
                    sMSTemplate.IPAddress = UserInfo.GetIPAddress();
                    sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                    sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                    sMSTemplate.PID = 0;
                    sMSTemplate.MobileNo = ScrutinyOfficerMobileNo;

                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.AddSO);
                    
                    shInfo.SetMessage("Scrutiny Officer Added Successfully.<br />LoginID : " + LoginID + "  AND Password : " + Password, ShowMessageType.Information);
                    
                    txtSOName.Text = "";
                    txtSOMobileNo.Text = "";
                    txtSOEmailId.Text = "";
                    txtSODesignation.Text = "";
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

                string RegionName = "";
                if (Request.QueryString["RegionName"] != null)
                {
                    RegionName = Request.QueryString["RegionName"].ToString();
                }
                else
                {
                    RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                }

                Int16 RegionID;
                RegionID = reg.getRORegionID(RegionName);
                Int64 SOID = Convert.ToInt64(ddlSOUpdate.SelectedValue);
                string ScrutinyOfficerName = txtScrutinyOfficerNameUpdate.Text.ToUpper();
                string ScrutinyOfficerMobileNo = txtScrutinyOfficerMobileNoUpdate.Text;
                string ScrutinyOfficerEmailId = txtScrutinyOfficerEmailIDUpdate.Text;
                string ScrutinyOfficerDesignation = txtScrutinyOfficerDesignationUpdate.Text;

                if (reg.updateMVSO(SOID, ScrutinyOfficerName, ScrutinyOfficerMobileNo, ScrutinyOfficerEmailId, ScrutinyOfficerDesignation, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ddlSOUpdate.DataSource = ddlSODelete.DataSource = reg.getMVSOList(RegionID);
                    ddlSOUpdate.DataTextField = ddlSODelete.DataTextField = "SOOfficerName";
                    ddlSOUpdate.DataValueField = ddlSODelete.DataValueField = "SOID";
                    ddlSODelete.DataBind();
                    ddlSOUpdate.DataBind();
                    ddlSODelete.Items.Insert(0, "-- Select --");
                    ddlSOUpdate.Items.Insert(0, "-- Select --");

                    txtScrutinyOfficerNameUpdate.Text = "";
                    txtScrutinyOfficerMobileNoUpdate.Text = "";
                    txtScrutinyOfficerEmailIDUpdate.Text = "";
                    txtScrutinyOfficerDesignationUpdate.Text = ""; 

                    shInfo.SetMessage("Scrutiny Officer Updated Successfully.", ShowMessageType.Information);
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
                string RegionName = "";
                if (Request.QueryString["RegionName"] != null)
                {
                    RegionName = Request.QueryString["RegionName"].ToString();
                }
                else
                {
                    RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                }

                Int16 RegionID;
                RegionID = reg.getRORegionID(RegionName);

                // Int64 AFCID = Convert.ToInt64(Session["UserID"]);
                Int64 SOID = Convert.ToInt64(ddlSODelete.SelectedValue);

                if (reg.deleteMVSO(SOID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ddlSOUpdate.DataSource = ddlSODelete.DataSource = reg.getMVSOList(RegionID);
                    ddlSOUpdate.DataTextField = ddlSODelete.DataTextField = "SOOfficerName";
                    ddlSOUpdate.DataValueField = ddlSODelete.DataValueField = "SOID";
                    ddlSODelete.DataBind();
                    ddlSOUpdate.DataBind();
                    ddlSODelete.Items.Insert(0, "-- Select --");
                    ddlSOUpdate.Items.Insert(0, "-- Select --");

                    shInfo.SetMessage("Scrutiny Officer Deleted Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("This ID cannot be deleted as scrutiny officer has already used it for merit list verification.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlSOUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                if (ddlSOUpdate.SelectedIndex != 0)
                {
                    Int64 SOID = Convert.ToInt64(ddlSOUpdate.SelectedValue);
                    DataSet ds = new DataSet();
                    ds = reg.getVerifiedBySO(SOID);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    
                    if(dt.Rows.Count > 0)
                    {
                        txtScrutinyOfficerNameUpdate.Enabled = false;
                    }
                    else
                    {
                        txtScrutinyOfficerNameUpdate.Enabled = true;
                    }

                    MVSOProfile obj = reg.getMVSOProfile(SOID);
                                
                    txtScrutinyOfficerNameUpdate.Text = obj.SOName;
                    txtScrutinyOfficerMobileNoUpdate.Text = obj.SOMobile;
                    txtScrutinyOfficerEmailIDUpdate.Text = obj.Email;
                    txtScrutinyOfficerDesignationUpdate.Text = obj.Designation;                   
                }
                else
                {                   
                    txtScrutinyOfficerNameUpdate.Text = "";
                    txtScrutinyOfficerMobileNoUpdate.Text = "";
                    txtScrutinyOfficerEmailIDUpdate.Text = "";
                    txtScrutinyOfficerDesignationUpdate.Text = "";
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