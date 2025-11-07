using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class frmPayApplicationFeeDifference : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    if (Request.Cookies["Theme"] == null)
        //    {
        //        Page.Theme = "default";
        //    }
        //    else
        //    {
        //        Page.Theme = Request.Cookies["Theme"].Value;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            //if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime || Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            //{
            //    Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
            //}
            if (Session["UserTypeID"].ToString() != "91")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //string _leftMenu = ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"];
            //((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormLinks = true;
            //((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormNumber = false;
            //((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFadingEffect = true; ((ExpanderMenu)Master.FindControl(_leftMenu)).FormType = 1;
            //((ExpanderMenu)Master.FindControl(_leftMenu)).FormNumber = Convert.ToInt64(Session["UserID"]);
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    //DataSet dsCurrentLink = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmPayApplicationFee");
                   
                    //DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    //char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    //char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());


                    //if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    //{
                    //    Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    //}
                    //if ((ApplicationFormStatus == 'A' || objSessionData.StepID < 8) && (FCVerificationStatus == 'C' || FCVerificationStatus == 'P'))
                    //{
                    //    Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    //}

                    Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(objSessionData.PID);
                    lblApplicationFeeToBePaid.Text = "₹ " + ApplicationFeeToBePaid.ToString();

                    if (ApplicationFeeToBePaid > 0)
                    {
                        Session["FeeGroupId"] = null;
                        Session["PhaseId"] = null;
                        Session["PayeeUserTypeId"] = null;
                        Session["PayeeId"] = null;

                        Session["FeeGroupId"] = "2";
                        Session["PhaseId"] = "1";
                        Session["PayeeUserTypeId"] = Session["UserTypeID"].ToString();
                        Session["PayeeId"] = Session["UserID"].ToString();

                       // Response.Redirect("../FeeProcess/PaymentDetails.aspx", true);
                    }
                    else
                    {
                        lblApplicationFeeToBePaid.Text = "NIL/-";
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(objSessionData.PID);
                if (ApplicationFeeToBePaid > 0)
                {
                    Session["FeeGroupId"] = null;
                    Session["PhaseId"] = null;
                    Session["PayeeUserTypeId"] = null;
                    Session["PayeeId"] = null;

                    Session["FeeGroupId"] = "2";
                    Session["PhaseId"] = "1";
                    Session["PayeeUserTypeId"] = Session["UserTypeID"].ToString();
                    Session["PayeeId"] = Session["UserID"].ToString();

                    Response.Redirect("../FeeProcess/PaymentDetails.aspx", true);
                }
                else
                Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}