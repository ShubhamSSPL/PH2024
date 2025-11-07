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

namespace Pharmacy2024.ARCModule
{
    public partial class frmAskApplicationID : System.Web.UI.Page
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
                    txtApplicationID.Text = Global.ApplicationFormPrefix;
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                    switch (Request.QueryString["Flag"])
                    {
                        case "ConfirmSeatAcceptanceForm":
                            if (Global.ARCReporting == 0 && UserTypeID != 21)
                            {
                                ContentTable2.Visible = false;
                                shInfo.SetMessage("Confirmation of Seat Acceptance Form is Closed.", ShowMessageType.Information);
                            }
                            else
                            {
                                ContentTable2.HeaderText = "Confirm Seat Acceptance Form";
                                trVersionNo.Visible = true;
                            }
                            break;
                        case "CancelSeatAcceptanceForm":
                            if (Global.ARCReporting == 0 && UserTypeID != 21)
                            {
                                ContentTable2.Visible = false;
                                shInfo.SetMessage("Cancellation of Seat Acceptance Form is Closed.", ShowMessageType.Information);
                            }
                            else
                            {
                                trNote.Visible = true;
                                ContentTable2.HeaderText = "Cancel Seat Acceptance Form";
                            }
                            break;
                        case "EditSeatAcceptanceStatus":
                            if (Global.ARCReporting == 0 && UserTypeID != 21)
                            {
                                ContentTable2.Visible = false;
                                shInfo.SetMessage("Editting of Seat Acceptance Status is Closed.", ShowMessageType.Information);
                            }
                            else
                            {
                                ContentTable2.HeaderText = "Edit Seat Acceptance Status";
                            }
                            break;
                        case "PaySeatAcceptanceFee":
                            if (Global.ARCReporting == 0 && UserTypeID != 21)
                            {
                                ContentTable2.Visible = false;
                                shInfo.SetMessage("Pay Seat Acceptance Fee is Closed.", ShowMessageType.Information);
                            }
                            else
                            {
                                ContentTable2.HeaderText = "Pay Seat Acceptance Fee";
                            }
                            break;
                        case "EditDDDetails":
                            ContentTable2.HeaderText = "Edit DD Details";
                            break;
                        case "PrintSeatAcceptanceForm":
                            ContentTable2.HeaderText = "Print Seat Acceptance Form";
                            break;
                        case "PrintSeatAcceptanceAcknowledgement":
                            ContentTable2.HeaderText = "Print Seat Acceptance Acknowledgement";
                            break;
                        case "PrintSeatAcceptanceCancellationAcknowledgement":
                            ContentTable2.HeaderText = "Print Seat Acceptance Cancellation Acknowledgement";
                            break;
                        case "AllotmentCancellationRemark":
                            ContentTable2.HeaderText = "Update Allotment Cancellation Remark";
                            break;
                        case "EditAccountDetails":
                            ContentTable2.HeaderText = "Edit Candidate's Account Details";
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
                reg.updateUserAction(Session["UserLoginID"].ToString(), txtApplicationID.Text, ContentTable2.HeaderText, "AFCModule", UserInfo.GetIPAddress());

                switch (Request.QueryString["Flag"])
                {
                    case "ConfirmSeatAcceptanceForm":
                        ConfirmSeatAcceptanceForm();
                        break;
                    case "CancelSeatAcceptanceForm":
                        CancelSeatAcceptanceForm();
                        break;
                    case "EditSeatAcceptanceStatus":
                        EditSeatAcceptanceStatus();
                        break;
                    case "PaySeatAcceptanceFee":
                        PaySeatAcceptanceFee();
                        break;
                    case "EditDDDetails":
                        EditDDDetails();
                        break;
                    case "PrintSeatAcceptanceForm":
                        PrintSeatAcceptanceForm();
                        break;
                    case "PrintSeatAcceptanceAcknowledgement":
                        PrintSeatAcceptanceAcknowledgement();
                        break;
                    case "PrintSeatAcceptanceCancellationAcknowledgement":
                        PrintSeatAcceptanceCancellationAcknowledgement();
                        break;
                    case "AllotmentCancellationRemark":
                        AllotmentCancellationRemark();
                        break;
                    case "EditAccountDetails":
                        EditAccountDetails();
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ConfirmSeatAcceptanceForm()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.checkSeatAcceptanceStatus(txtApplicationID.Text, Convert.ToInt32(txtVersionNo.Text), Global.CAPRound);
                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else if (PID == 1)
                {
                    shInfo.SetMessage("Seat Acceptance Form is Already Confirmed.", ShowMessageType.Information);
                }
                else if (PID == 2)
                {
                    shInfo.SetMessage("Seat Acceptance Form is Cancelled.", ShowMessageType.Information);
                }
                else if (PID == 3)
                {
                    shInfo.SetMessage("This Candidate is not Allotted any Institute. So You can not Confirm his/her Seat Acceptance Form.", ShowMessageType.Information);
                }
                else if (PID == 4)
                {
                    shInfo.SetMessage("Seat Acceptance Form is not Filled by this Candidate. Please ask the Candidate to Fill Seat Acceptance Form First.", ShowMessageType.Information);
                }
                else if (PID == 5)
                {
                    shInfo.SetMessage("Version No is not Correct. Please take fresh PrintOut of Seat Acceptance Form and Confirm again using new Version No.", ShowMessageType.Information);
                }
                else
                {
                    string AllotmentCancellationRemark = reg.getAllotmentCancellationRemark(PID, Global.CAPRound);

                    if (AllotmentCancellationRemark.Length > 0)
                    {
                        shInfo.SetMessage("Allotment of this Candidate is Cancelled. Reason : " + AllotmentCancellationRemark, ShowMessageType.Information);
                    }
                    else
                    {
                        if (reg.CheckCandidateCVCStatus(PID))
                        {
                            shInfo.SetMessage("This Candidate has not uploded CVC / TVC Certificate. Please First upload CVC/TVC then Confirm the Seat Acceptance Status.", ShowMessageType.Information);
                        }
                        else
                        {
                            Response.Redirect("../ARCModule/frmConfirmSeatAcceptanceForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
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
        protected void CancelSeatAcceptanceForm()
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
                    if (reg.isSeatAcceptanceFormConfirmed(PID))
                    {
                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                        string UserLoginID = Session["UserLoginID"].ToString();

                        if (reg.checkSeatAcceptanceFormConfirmationDetails(PID, UserTypeID, UserLoginID))
                        {
                            if (!reg.IsAdmissionConfirmedAtInstitute(PID))
                            {
                                Response.Redirect("../ARCModule/frmCancelSeatAcceptanceForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                            }
                            else
                            {
                                shInfo.SetMessage("Admission of this Candidate is Confirmed / Cancelled at Institute, You can not Cancel it.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            if (UserTypeID == 22)
                            {
                                shInfo.SetMessage("As this Seat Acceptance Form is not Confirmed by ARC under your Region, Hence you can not Cancel it.", ShowMessageType.Information);
                            }
                            else
                            {
                                shInfo.SetMessage("As this Application Form is not Confirmed by You, Hence you can not Cancel it.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Seat Acceptance Form is not Confirmed yet. You can Cancel Seat Acceptance Form after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void EditSeatAcceptanceStatus()
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
                    if (reg.isSeatAcceptanceFormConfirmed(PID))
                    {
                        Response.Redirect("../ARCModule/frmEditSeatAcceptanceStatusDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Seat Acceptance Form is not Confirmed yet. You can Edit Seat Acceptance Status after Confirmation Only.", ShowMessageType.Information);
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
                    Response.Redirect("../ARCModule/frmEditSeatAcceptanceFeeDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void EditDDDetails()
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
                    Response.Redirect("../ARCModule/frmEditDDDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintSeatAcceptanceForm()
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
                    DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(PID);

                    if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect("../ARCModule/frmSeatAcceptanceForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Seat Acceptance Status is Not Filled by Candidate. So you can not Print Seat Acceptance Form.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintSeatAcceptanceAcknowledgement()
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
                    if (reg.isSeatAcceptanceFormConfirmed(PID))
                    {
                        Response.Redirect("../ARCModule/frmSeatAcceptanceAcknowledgement.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Seat Acceptance Form is not Confirmed yet. You can Print Seat Acceptance Acknowledgement after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void PrintSeatAcceptanceCancellationAcknowledgement()
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
                    if (reg.isSeatAcceptanceFormCancelled(PID))
                    {
                        Response.Redirect("../ARCModule/frmSeatAcceptanceCancellationAcknowledgement.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Seat Acceptance Form is not Confirmed yet. You can Print Seat Acceptance Acknowledgement after Confirmation Only.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void AllotmentCancellationRemark()
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
                    if (reg.isSeatAcceptanceFormConfirmed(PID))
                    {
                        shInfo.SetMessage("Seat Acceptance Form is Confirmed. So You can not Update Allotment Cancellation Remark.", ShowMessageType.Information);
                    }
                    else
                    {
                        Response.Redirect("../ARCModule/frmAllotmentCancellationRemark.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void EditAccountDetails()
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
                        Response.Redirect("../ARCModule/frmEditAccountDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("Application Form is Not Confirmed at SC.", ShowMessageType.Information);
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