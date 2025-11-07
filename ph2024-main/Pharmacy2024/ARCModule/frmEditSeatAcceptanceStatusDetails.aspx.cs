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

namespace Pharmacy2024.ARCModule
{
    public partial class frmEditSeatAcceptanceStatusDetails : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageARC.aspx", true);
                    }

                    DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplay(PID);
                    Int32 PreferenceNoAllotted = reg.getPreferenceNoAllotted(PID, Global.CAPRound);
                    DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(PID);

                    if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                    {
                        lblApplicationID.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["ApplicationID"].ToString();
                        lblCandidateName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CandidateName"].ToString();
                    }

                    if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                    {
                        string SeatAcceptanceStatus = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["SeatAcceptanceStatus"].ToString();

                        if (SeatAcceptanceStatus == "Auto Freeze" || SeatAcceptanceStatus == "Freeze")
                        {
                            rbnFreeze.Checked = true;
                            rbnFloat.Enabled = false;
                            btnProceed.Visible = false;
                        }
                        else if (SeatAcceptanceStatus == "Betterment (Not Freeze)")
                        {
                            rbnFloat.Checked = true;
                        }
                    }

                    if (PreferenceNoAllotted == 0)
                    {
                        rbnFreeze.Enabled = false;
                        rbnFloat.Enabled = false;
                        btnProceed.Visible = false;

                        trMessage.Visible = true;
                        lblMessage.Text = "<b>Note : </b> You have not got any Allotment. So You can not give Seat Acceptance Status.";
                    }
                    else if (PreferenceNoAllotted == 1)
                    {
                        rbnFloat.Enabled = false;
                        rbnFloat.Checked = false;

                        trMessage.Visible = true;
                        lblMessage.Text = "<b>Note : </b> You have got the First Preference. So Your Offered Seat is Auto Freezed.";
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                Int32 PreferenceNoAllotted = reg.getPreferenceNoAllotted(PID, Global.CAPRound);
                string SeatAcceptanceStatus = "";

                if (rbnFreeze.Checked)
                {
                    if (PreferenceNoAllotted == 1)
                    {
                        SeatAcceptanceStatus = "Auto Freeze";
                    }
                    else
                    {
                        SeatAcceptanceStatus = "Freeze";
                    }
                }
                else if (rbnFloat.Checked)
                {
                    SeatAcceptanceStatus = "Betterment (Not Freeze)";
                }

                if (SeatAcceptanceStatus.Length > 0)
                {
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                    if (UserTypeID == 21 || UserTypeID == 22 || UserTypeID == 33 || UserTypeID == 34)
                    {
                        if (reg.editSeatAcceptanceStatusDetails(PID, SeatAcceptanceStatus, Global.CAPRound, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = PID;
                            sMSTemplate.SeatAcceptanceStatus = SeatAcceptanceStatus;
                            sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                            sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.SeatAcceptanceStatusChange);
                            Response.Redirect("../ARCModule/frmSeatAcceptanceAcknowledgement.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageARC.aspx");
                    }
                }
                else
                {
                    shInfo.SetMessage("Please Select Seat Acceptance Status.", ShowMessageType.Information);
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