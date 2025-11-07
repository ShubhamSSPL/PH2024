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
    public partial class frmChangeScrutinyMode : System.Web.UI.Page
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
            if (Convert.ToInt16(Session["UserTypeID"]) != 91)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["From"] != null)
                    {
                        if (Request.QueryString["From"].ToString() == "ModeChangeVerification")
                        {
                            shInfo.SetMessage("Your SC Verification Mode Changed Successfully!!!", ShowMessageType.Information);
                            ContentTableFCVerification.Visible = false;
                        }
                        else
                        {
                            ContentTableFCVerification.Visible = true;
                        }
                    }
                    else
                    {
                        ContentTableFCVerification.Visible = true;
                    }

                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    string strVerificationMode = reg.CheckCandidateFCVerificationFor(objSessionData.PID);
                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());

                    if (FCVerificationStatus == 'C')
                    {
                        shInfo.SetMessage("Your Application Form is Verified and Confirmed by SC, so You cannot change Verification Mode.", ShowMessageType.Information);
                        showcurrentMode(strVerificationMode);
                    }
                    else if (FCVerificationStatus == 'P')
                    {
                        shInfo.SetMessage("Your Application Form is Picked by SC for e-Verification, so You cannot change Verification Mode.", ShowMessageType.Information);
                        showcurrentMode(strVerificationMode);
                    }
                    else if (ApplicationFormStatus == 'A')
                    {
                        shInfo.SetMessage("Your Application Form is Confirmed by SC, so You cannot change Verification Mode.", ShowMessageType.Information);
                        showcurrentMode(strVerificationMode);
                    }
                    else if(Global.CurrentScrutinyMode=="Both")
                    {
                        tblChnageTo.Visible = true;
                        if (strVerificationMode == "E")
                        {
                            btnPScrutiny.Text = "Change to Physical Scrutiny Mode";
                            btnEScrutiny.Visible = false;
                            SelectdPScrutiny.Visible = false;
                            ChooseEScrutiny.Visible = false;
                        }
                        else if (strVerificationMode == " " || strVerificationMode == "")
                        {
                        }
                        else if (strVerificationMode == "P")
                        {
                            btnEScrutiny.Text = "Change to E-Scrutiny Mode";
                            btnPScrutiny.Visible = false;
                            SelectedEScrutiny.Visible = false;
                            ChoosePScrutiny.Visible = false;

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        shInfo.SetMessage("You are not allowed to change Scrutiny Mode.", ShowMessageType.Information);
                        showcurrentMode(strVerificationMode);
                        //ContentTableFCVerification.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void showcurrentMode(string Mode)
        {
            tblChnageTo.Visible = false;
            if (Mode == "E")
            {
                SelectdPScrutiny.Visible = false;
                SelectedEScrutiny.Visible = true;
            }
            else if (Mode == "P")
            {
                SelectdPScrutiny.Visible = true;
                SelectedEScrutiny.Visible = false;
            }
        }

        protected void btnPScrutiny_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                Response.Redirect("../CandidateModule/frmVerifyScrutinyModeChange.aspx?ScrutinyMode=P", true);
            }


        }
        protected void btnEScrutiny_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);

                Response.Redirect("../CandidateModule/frmVerifyScrutinyModeChange.aspx?ScrutinyMode=E", true);
            }
        }
    }
}