using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ApplicationPages
{
    public partial class WelcomePage : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        private bool _refreshState, _isRefresh;
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
            string guid = Guid.NewGuid().ToString();
            Session["AuthToken"] = guid;
            // now create a new cookie with this guid value  
            Response.Cookies.Add(new HttpCookie("AuthToken", guid));

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                    Int64 UserID = Convert.ToInt64(Session["UserID"].ToString());
                    string UserLoginID = Session["UserLoginID"].ToString();

                    if (Session["UserLoginID"] == null)
                    {
                        FormsAuthentication.RedirectFromLoginPage(UserLoginID, false);
                    }
                    else
                    {
                        //add key to session to detect if there is anybody trying to login with the same credentials as that of logged in user
                        string key = UserLoginID + UserID;
                        TimeSpan TimeOut = new TimeSpan(0, 0, HttpContext.Current.Session.Timeout, 0, 0);
                        HttpContext.Current.Cache.Insert(key, Session.SessionID, null, DateTime.MaxValue,
                            TimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                        Session["keyUserName"] = key;
                        FormsAuthentication.SetAuthCookie(UserLoginID, false);
                    }

                    if (UserTypeID == 91)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
                    }
                    else if (UserTypeID == 21)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }
                    else if (UserTypeID == 22)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }
                    else if (UserTypeID == 23)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }
                    else if (UserTypeID == 24)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }
                    else if (UserTypeID == 31)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }
                    else if (UserTypeID == 33)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageARC.aspx", true);
                    }
                    else if (UserTypeID == 34)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageARC.aspx", true);
                    }
                    else if (UserTypeID == 43)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageInstitute.aspx", true);
                    }
                    else if (UserTypeID == 66)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageHelpDesk.aspx", true);
                    }
                    else if (UserTypeID == 32)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageMVSO.aspx", true);
                    }
                    else if (UserTypeID == 26)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageMVDTE.aspx", true);
                    }
                    else if (UserTypeID == 27)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageARA.aspx", true);
                    }
                    else if (UserTypeID == 45)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageDocumentVerification.aspx", true);
                    }

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
                }
                catch (Exception ex)
                {
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
    }
}