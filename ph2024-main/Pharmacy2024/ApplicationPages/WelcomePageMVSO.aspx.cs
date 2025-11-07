using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ApplicationPages
{
    public partial class WelcomePageMVSO : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
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
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);

                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                    string UserLoginID = Session["UserLoginID"].ToString();



                    DataSet dsLoginDetails = reg.getLoginDetails(UserLoginID, UserTypeID);
                    if (dsLoginDetails.Tables[0].Rows.Count > 0)
                    {
                        lblLoginID.Text = dsLoginDetails.Tables[0].Rows[0]["LoginID"].ToString();
                        lblUserName.Text = dsLoginDetails.Tables[0].Rows[0]["UserName"].ToString();
                        lblUserType.Text = dsLoginDetails.Tables[0].Rows[0]["UserTypeName"].ToString();
                        DateTime CurrentLoginDateTime = Convert.ToDateTime(dsLoginDetails.Tables[0].Rows[0]["CurrentLoginDateTime"].ToString());
                        lblCurrentLoginTime.Text = CurrentLoginDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", CurrentLoginDateTime);
                        DateTime LastLoginDateTime = Convert.ToDateTime(dsLoginDetails.Tables[0].Rows[0]["LastLoginDateTime"].ToString());
                        lblPreviousLoginTime.Text = LastLoginDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", LastLoginDateTime);
                        lblIPAddress.Text = UserInfo.GetIPAddress();
                    }
                    string SOCode = Session["UserLoginID"].ToString();
                    DataSet dsSOStats = reg.getSOStats(SOCode);
                    if (dsSOStats.Tables[0].Rows.Count > 0)
                    {
                        hlInst.Text = dsSOStats.Tables[0].Rows[0]["NoOfinstAssigned"].ToString();
                        hlCandidate.Text = dsSOStats.Tables[0].Rows[0]["NoOfCandidates"].ToString();
                        lblCndVerified.Text = dsSOStats.Tables[0].Rows[0]["CandidatesVerified"].ToString();
                        lblCndPending.Text = dsSOStats.Tables[0].Rows[0]["CandidatesPending"].ToString();                        
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
}