using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmUpdateParticipationInAditionalRoundDetails : System.Web.UI.Page
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
                    Response.Redirect("../ApplicationPages/WelcomePageInstitute.aspx");
                    if (Convert.ToInt32(Session["UserTypeID"]) != 43)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePage.aspx");
                    }
                    else
                    {
                        Int64 InstituteID = Convert.ToInt64(Session["UserID"]);

                        if (reg.getInstitueParticipationInAditionalRound(InstituteID))
                        {
                            rbnYes.Checked = true;
                            rbnNo.Checked = false;
                        }
                        else
                        {
                            rbnNo.Checked = true;
                            rbnYes.Checked = false;
                        }
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
                Int64 InstituteID = Convert.ToInt64(Session["UserID"]);
                string ParticipationinAditionalRound = string.Empty;

                if (rbnYes.Checked)
                {
                    ParticipationinAditionalRound = "Y";
                }
                else
                {
                    ParticipationinAditionalRound = "N";
                }

                if (reg.updateInstitueParticipationInAditionalRound(InstituteID, ParticipationinAditionalRound, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    if (ParticipationinAditionalRound == "Y")
                    {
                        Response.Redirect("../InstituteModule/frmUpdateSeatTypeAllotedForAdditionalRound.aspx");
                    }
                    else
                    {
                        shInfo.SetMessage("Your Institute is not willing to Participate in Additional Round.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
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