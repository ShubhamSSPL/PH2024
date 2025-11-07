using BusinessLayer;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ARCModule
{
    public partial class frmRestorePreviousAllotmentToCAPRound3 : System.Web.UI.Page
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
                    if (Convert.ToInt32(Session["UserTypeID"].ToString()) != 21 && Convert.ToInt32(Session["UserTypeID"].ToString()) != 22)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageARC.aspx", true);
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
                string ApplicationID = txtApplicationID.Text;
                string ChoiceCodeDisplay = txtChoiceCode.Text;
                Int64 PID = reg.getPersonalID(ApplicationID);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(PID);

                    if (SeatAcceptanceConfirmationStatus == "Y")
                    {
                        shInfo.SetMessage("Seat Acceptance Status is Already Confirmed at Admission Reporting Center.", ShowMessageType.Information);
                    }
                    else
                    {
                        if (reg.isEligibleForSeatAcceptance(PID, Global.CAPRound))
                        {
                            shInfo.SetMessage("Seat is Already Allotted in CAP Round " + Global.CAPRound.ToString() + ".", ShowMessageType.Information);
                        }
                        else
                        {
                            Int32 Result = new dbUtility().restorePreviousAllotmentToCAPRound3(ApplicationID, ChoiceCodeDisplay, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                            if (Result == 1)
                            {
                                shInfo.SetMessage("Invalid Application ID or ChoiceCode.", ShowMessageType.Information);
                            }
                            else if (Result == 2)
                            {
                                shInfo.SetMessage("Already Allotted in CAP Round - III.", ShowMessageType.Information);
                            }
                            else if (Result == 3)
                            {
                                shInfo.SetMessage("Not Allotted this Choice Code in CAP Round - I/II.", ShowMessageType.Information);
                            }
                            else if (Result == 4)
                            {
                                shInfo.SetMessage("Previous Allotment for CAP Round-III is Restored Successfully.", ShowMessageType.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        public class dbUtility
        {
            public Int32 restorePreviousAllotmentToCAPRound3(string ApplicationID, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
            {
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@ApplicationID", SqlDbType.VarChar, 11),
                    new SqlParameter("@ChoiceCodeDisplay", SqlDbType.VarChar, 12),
                    new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50),
                    new SqlParameter("@CreatedByIPAddress", SqlDbType.VarChar, 50)
                };

                parameters[0].Value = ApplicationID;
                parameters[1].Value = ChoiceCodeDisplay;
                parameters[2].Value = CreatedBy;
                parameters[3].Value = CreatedByIPAddress;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteNonQuery("MHDTE_spRestorePreviousAllotmentToCAPRound3", parameters);
                }
                finally
                {
                    db.Dispose();
                }

            }
        }
    }
}