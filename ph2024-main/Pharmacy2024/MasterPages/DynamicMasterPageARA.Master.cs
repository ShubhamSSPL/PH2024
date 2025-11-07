using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.MasterPages
{
    public partial class DynamicMasterPageARA : System.Web.UI.MasterPage
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        HttpCookie cookie = null;
        public string AdmissionYear = Global.AdmissionYear;
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.Header.Title = ConfigurationManager.AppSettings["WebSite_Title"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.FilePath.Contains("StaticPages/HomePage"))
            {
                string strPreviousPage = "";
                if (Request.UrlReferrer != null)
                {
                    strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                }
                if (strPreviousPage == "")
                {
                    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                }
                if (hdnFormType.Value.Trim() != string.Empty)
                {
                    GetHiddenFieldFormTypeValue();
                }

                if (Global.IsOTPVerificationRequiredForLogin == 1 && Session["UserOTPVerificationDone"].ToString() == "N" && Session["UserTypeID"].ToString() == "91")
                {
                    Response.Redirect("../ApplicationPages/frmSendOTP.aspx");
                }
                //if (Session["UserTypeID"].ToString() == "91")
                //{
                //    Int32 msgCnt = 10;

                //    btnMessage.Visible = true;
                //    string btnText = "<i class='fa fa-envelope'></i><span class='badge badge-light'>" + msgCnt + "</span>";
                //    btnMessage.Text = btnText;

                //}
                if (!IsPostBack)
                {
                    if (Session["UserTypeID"] != null)
                    {
                        lblUserName.Text = Session["UserLoginID"].ToString();
                    }
                }
            }
        }
        private void GetHiddenFieldFormTypeValue()
        {
            LeftMenu.ShowFormLinks = true;
            int _formType = Convert.ToInt16(hdnFormType.Value.Trim());
            LeftMenu.ShowFormNumber = (_formType >= 3 && _formType <= 4 ? false : false);
            LeftMenu.FormNumber = Convert.ToInt64((Session["ApplicationFormNo"] != null ? Session["ApplicationFormNo"] : 0));
            LeftMenu.ShowFadingEffect = true;
            LeftMenu.FormType = _formType;
            hdnFormType.Value = string.Empty;
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {


            Int64 SessionID = Convert.ToInt64(Session["UserSessionID"]);
            reg.saveLogOutDateTime(SessionID);

            Session.Clear();
            Session.Abandon();

            Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"].ToString(), true);
        }
        //protected void btnMessage_Click(object sender, EventArgs e)
        //{


        //    if (Session["UserTypeID"] != null)
        //    {
        //        if (Session["UserTypeID"].ToString() == "91")
        //        {
        //            string UserLoginID = Session["UserLoginID"].ToString();

        //        }
        //    }

        //}
    }
}