using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmAskApplicationIDAtIL : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    txtApplicationID.Text = Global.ApplicationFormPrefix;
                    cbSelectAdmission.Visible = false;

                    switch (Request.QueryString["Flag"])
                    {
                        case "ConfirmAdmission":
                            if (Global.InstituteReporting == 0 && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
                            {
                                ContentTable2.Visible = false;

                                shInfo.Visible = true;
                                shInfo.SetMessage("Admission of Candidate at Institute Level is Closed.", ShowMessageType.Information);
                            }
                            else
                            {
                                //if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["CutOffDate"]) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
                                if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["UploadingDate"]) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
                                {
                                    ContentTable2.Visible = false;
                                    shInfo.Visible = true;
                                    shInfo.SetMessage("Admission of Candidate at Institute Level is Closed.", ShowMessageType.Information);
                                }
                                else
                                {
                                    ContentTable2.HeaderText = "Admit Candidate at Institute Level";
                                    tblInstructions.Visible = true;
                                }
                            }
                            break;
                        case "EditAdmission":
                            ContentTable2.HeaderText = "Edit Candidate Admission at Institute Level";
                            break;
                        case "CancelAdmission":
                            ContentTable2.HeaderText = "Cancel Candidate Admission at Institute Level";
                            break;
                        case "EditCancelAdmission":
                            ContentTable2.HeaderText = "Edit Candidate Admission Cancellation Details at Institute Level";
                            break;
                        case "PrintAdmissionLetter":
                            ContentTable2.HeaderText = "Print Admission Letter at Institute Level";
                            break;
                        case "PrintAdmissionCancellationLetter":
                            ContentTable2.HeaderText = "Print Admission Cancellation Letter at Institute Level";
                            break;
                        case "PaySeatAcceptanceFee":
                            ContentTable2.HeaderText = "Pay Seat Acceptance Fee";
                            break;
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

                if (ApplicationID.Length == 10)
                {
                    Int64 PID = Convert.ToInt64(ApplicationID.Substring(4).ToString());
                    Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(PID);
                    cbSelectAdmission.Visible = false;
                    reg.updateUserAction(Session["UserLoginID"].ToString(), txtApplicationID.Text, Request.QueryString["Flag"].ToString(), "Institute", UserInfo.GetIPAddress());

                    switch (Request.QueryString["Flag"])
                    {
                        case "ConfirmAdmission":
                            if (ApplicationFeeToBePaid > 0)
                            {
                                shInfo.SetMessage("Pay the remaining Application Fee difference of Rs. 200/ Through Candidate Login.", ShowMessageType.Information);
                            }
                            else
                            {
                                ConfirmAdmission();
                            }
                            break;
                        case "EditAdmission":
                            EditAdmission();
                            break;
                        case "CancelAdmission":
                            CancelAdmission();
                            break;
                        case "EditCancelAdmission":
                            EditCancelAdmission();
                            break;
                        case "PrintAdmissionLetter":
                            PrintAdmissionLetter();
                            break;
                        case "PrintAdmissionCancellationLetter":
                            PrintAdmissionCancellationLetter();
                            break;
                        case "PaySeatAcceptanceFee":
                            PaySeatAcceptanceFee();
                            break;

                    }
                }
                else
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }                   
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ConfirmAdmission()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isCandidateEligibleForAdmissionAtIL(PID))
                    {
                        string strAdmissionDetails = reg.getAdmissionDetails(PID);

                        if (strAdmissionDetails.Length == 0)
                        {
                            Response.Redirect("../InstituteModule/frmConfirmAdmissionAtIL.aspx?PID=" + PID.ToString() + "&Code=" + PID.ToString().GetHashCode().ToString());
                        }
                        else
                        {
                            shInfo.SetMessage(strAdmissionDetails, ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("This Candidate is not Eligible for Admission.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void EditAdmission()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();
                    string Flag = "EditAdmission";

                    DataSet dsReportingDetails = reg.getReportingDetailsAtIL(PID, 'Y', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

                    if (dsReportingDetails.Tables[0].Rows.Count == 0)
                    {
                        if (UserTypeID == 21)
                        {
                            shInfo.SetMessage("This candidate is not admitted in any institute. So you can not edit it.", ShowMessageType.Information);
                        }
                        else if (UserTypeID == 22)
                        {
                            shInfo.SetMessage("This candidate is not admitted in any institute in your region. So you can not edit it.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("This candidate is not admitted in your institute. So you can not edit it.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        cbSelectAdmission.Visible = true;

                        lblApplicationID.Text = txtApplicationID.Text;
                        lblCandidateName.Text = reg.getCandidateName(PID);

                        gvList.DataSource = dsReportingDetails;
                        gvList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void CancelAdmission()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();
                    string Flag = "CancelAdmission";

                    DataSet dsReportingDetails = reg.getReportingDetailsAtIL(PID, 'Y', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

                    if (dsReportingDetails.Tables[0].Rows.Count == 0)
                    {
                        if (UserTypeID == 21)
                        {
                            shInfo.SetMessage("This candidate is not admitted in any institute. So you can not cancel it.", ShowMessageType.Information);
                        }
                        else if (UserTypeID == 22)
                        {
                            shInfo.SetMessage("This candidate is not admitted in any institute in your region. So you can not cancel it.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("This candidate is not admitted in your institute. So you can not cancel it.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        cbSelectAdmission.Visible = true;

                        lblApplicationID.Text = txtApplicationID.Text;
                        lblCandidateName.Text = reg.getCandidateName(PID);

                        gvList.DataSource = dsReportingDetails;
                        gvList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void EditCancelAdmission()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();
                    string Flag = "EditCancelAdmission";

                    DataSet dsReportingDetails = reg.getReportingDetailsAtIL(PID, 'C', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

                    if (dsReportingDetails.Tables[0].Rows.Count == 0)
                    {
                        if (UserTypeID == 21)
                        {
                            shInfo.SetMessage("This candidate is not cancelled in any institute. So you can not edit it.", ShowMessageType.Information);
                        }
                        else if (UserTypeID == 22)
                        {
                            shInfo.SetMessage("This candidate is not cancelled in any institute in your region. So you can not edit it.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("This candidate is not cancelled in your institute. So you can not edit it.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        cbSelectAdmission.Visible = true;

                        lblApplicationID.Text = txtApplicationID.Text;
                        lblCandidateName.Text = reg.getCandidateName(PID);

                        gvList.DataSource = dsReportingDetails;
                        gvList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintAdmissionLetter()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();
                    string Flag = "PrintAdmissionLetter";

                    DataSet dsReportingDetails = reg.getReportingDetailsAtIL(PID, 'Y', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

                    if (dsReportingDetails.Tables[0].Rows.Count == 0)
                    {
                        if (UserTypeID == 21)
                        {
                            shInfo.SetMessage("This candidate is not admitted in any institute. So you can not print admission letter.", ShowMessageType.Information);
                        }
                        else if (UserTypeID == 22)
                        {
                            shInfo.SetMessage("This candidate is not admitted in any institute in your region. So you can not print admission letter.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("This candidate is not admitted in your institute. So you can not print admission letter.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        cbSelectAdmission.Visible = true;

                        lblApplicationID.Text = txtApplicationID.Text;
                        lblCandidateName.Text = reg.getCandidateName(PID);

                        gvList.DataSource = dsReportingDetails;
                        gvList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintAdmissionCancellationLetter()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();
                    string Flag = "PrintAdmissionCancellationLetter";

                    DataSet dsReportingDetails = reg.getReportingDetailsAtIL(PID, 'C', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

                    if (dsReportingDetails.Tables[0].Rows.Count == 0)
                    {
                        if (UserTypeID == 21)
                        {
                            shInfo.SetMessage("This candidate is not cancelled in any institute. So you can not print admission cancellation letter.", ShowMessageType.Information);
                        }
                        else if (UserTypeID == 22)
                        {
                            shInfo.SetMessage("This candidate is not cancelled in any institute in your region. So you can not print admission cancellation letter.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("This candidate is not cancelled in your institute. So you can not print admission cancellation letter.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        cbSelectAdmission.Visible = true;

                        lblApplicationID.Text = txtApplicationID.Text;
                        lblCandidateName.Text = reg.getCandidateName(PID);

                        gvList.DataSource = dsReportingDetails;
                        gvList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PaySeatAcceptanceFee()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.isApplicationFormConfirmed(PID))
                    {
                        if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["UploadingDate"]))
                        {
                            shInfo.SetMessage("Admission of Candidate at Institute Level is Closed.", ShowMessageType.Information);
                        }
                        else
                        {
                            DataSet ds = reg.getApplicationFormConfirmationDetails(PID);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Response.Redirect("../InstituteModule/frmEditSeatAcceptanceFeeDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                            }
                            else
                            {
                                shInfo.SetMessage("Please confirm candidate application form before pay seat acceptance fee.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Application Form is not Confirmed yet. You can not Pay Seat Acceptance Fee.", ShowMessageType.Information);
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
}