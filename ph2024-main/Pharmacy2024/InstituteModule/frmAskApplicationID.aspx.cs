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
    public partial class frmAskApplicationID : System.Web.UI.Page
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
                            if (Global.InstituteCAPReporting == 0 && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
                            {
                                ContentTable2.Visible = false;
                                shInfo.SetMessage("Confirmation of Admission is Closed.", ShowMessageType.Information);
                            }
                            else
                            {
                                ContentTable2.HeaderText = "Confirm Admission";
                            }
                            break;
                        case "EditAdmission":
                            ContentTable2.HeaderText = "Edit Admission";
                            break;
                        case "CancelAdmission":
                            ContentTable2.HeaderText = "Cancel Admission";
                            break;
                        case "EditCancelAdmission":
                            ContentTable2.HeaderText = "Edit Admission Cancellation Details";
                            break;
                        case "PrintAdmissionLetter":
                            ContentTable2.HeaderText = "Print Admission Letter";
                            break;
                        case "PrintAdmissionCancellationLetter":
                            ContentTable2.HeaderText = "Print Admission Cancellation Letter";
                            break;
                        case "UploadCVCTVCNCL":
                            ContentTable2.HeaderText = "Upload CVC / TVC / NCL";
                            break;
                        case "CancelAdmissionForCVCTVCNCL":
                            ContentTable2.HeaderText = "Cancel Admission of Candidate Not Submitted CVC / TVC / NCL";
                            break;
                        case "EditCategory":
                            ContentTable2.HeaderText = "Edit Category Details";
                            break;
                        case "ResetSelfSeatAcceptance":
                            ContentTable2.HeaderText = "Reset of Self Verification and Seat Acceptance";
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
                cbSelectAdmission.Visible = false;
                reg.updateUserAction(Session["UserLoginID"].ToString(), txtApplicationID.Text, Request.QueryString["Flag"].ToString(), "Institute", UserInfo.GetIPAddress());

                switch (Request.QueryString["Flag"])
                {
                    case "ConfirmAdmission":
                        ConfirmAdmission();
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
                    case "UploadCVCTVCNCL":
                        UploadCVCTVCNCL();
                        break;
                    case "CancelAdmissionForCVCTVCNCL":
                        CancelAdmissionForCVCTVCNCL();
                        break;
                    case "EditCategory":
                        EditCategory();
                        break;
                    case "ResetSelfSeatAcceptance":
                        ResetSelfSeatAcceptance();
                        break;

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
                    if (reg.getAllotmentCancellationRemark(PID, Global.CAPRound).Length > 0)
                    {
                        shInfo.SetMessage("The Allotment made to candidate is already cancelled hence you cannot Confirm the Admission.", ShowMessageType.Information);
                    }
                    else
                    {
                        if (reg.isCandidateEligibleForAdmission(PID))
                        {
                            Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                            string UserLoginID = Session["UserLoginID"].ToString();
                            string Flag = "ConfirmAdmission";

                            string AdmissionCategory = reg.GetAdmissionCategory(PID);
                            if (AdmissionCategory.Contains("$") || AdmissionCategory.Contains("#") || AdmissionCategory.Contains("@"))
                            {
                                trCVCMsg.Visible = true;
                            }
                            else
                            {
                                trCVCMsg.Visible = false;
                            }

                            DataSet dsReportingDetails = reg.getReportingDetailsAtCAP(PID, 'N', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

                            if (dsReportingDetails.Tables[0].Rows.Count == 0)
                            {
                                if (UserTypeID == 21)
                                {
                                    shInfo.SetMessage("This candidate is not allotted in any institute. So you can not admit it.", ShowMessageType.Information);
                                }
                                else if (UserTypeID == 22)
                                {
                                    shInfo.SetMessage("This candidate is not allotted in any institute in your region. So you can not admit it.", ShowMessageType.Information);
                                }
                                else
                                {
                                    shInfo.SetMessage("This candidate is not allotted in your institute. So you can not admit it.", ShowMessageType.Information);
                                }
                            }
                            else
                            {
                                string strAdmissionDetails = reg.getAdmissionDetails(PID);

                                if (strAdmissionDetails.Length == 0)
                                {
                                    cbSelectAdmission.Visible = true;

                                    lblApplicationID.Text = txtApplicationID.Text;
                                    lblCandidateName.Text = reg.getCandidateName(PID);

                                    gvList.DataSource = dsReportingDetails;
                                    gvList.DataBind();
                                }
                                else
                                {
                                    shInfo.SetMessage(strAdmissionDetails, ShowMessageType.Information);
                                }
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("This Candidate is not Eligible for Admission.", ShowMessageType.Information);
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

                    DataSet dsReportingDetails = reg.getReportingDetailsAtCAP(PID, 'Y', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

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

                    DataSet dsReportingDetails = reg.getReportingDetailsAtCAP(PID, 'Y', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

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

                    DataSet dsReportingDetails = reg.getReportingDetailsAtCAP(PID, 'C', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

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

                    DataSet dsReportingDetails = reg.getReportingDetailsAtCAP(PID, 'Y', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

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

                    DataSet dsReportingDetails = reg.getReportingDetailsAtCAP(PID, 'C', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

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
        protected void UploadCVCTVCNCL()
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
                    string Flag = "UploadCVCTVCNCL";

                    DataSet dsReportingDetails = reg.getReportingDetailsAtCAP(PID, 'N', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

                    if (dsReportingDetails.Tables[0].Rows.Count == 0)
                    {
                        if (UserTypeID == 21)
                        {
                            shInfo.SetMessage("This candidate is not allotted in any institute. So you can not Upload the Documents.", ShowMessageType.Information);
                        }
                        else if (UserTypeID == 22)
                        {
                            shInfo.SetMessage("This candidate is not allotted in any institute in your region. So you can not Upload the Documents.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("This candidate is not allotted in your institute. So you can not Upload the Documents.", ShowMessageType.Information);
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
        protected void CancelAdmissionForCVCTVCNCL()
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
                    string Flag = "CancelAdmissionForCVCTVCNCL";

                    DataSet dsReportingDetails = reg.getReportingDetailsAtCAP(PID, 'Y', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

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

        protected void EditCategory()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = reg.getPersonalID(txtApplicationID.Text);
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                string UserLoginID = Session["UserLoginID"].ToString();

                if (PID == 0)
                {
                    shInfo.SetMessage("Invalid Application ID.", ShowMessageType.Information);
                }
                else
                {
                    string strAdmissionDetails = reg.getAdmissionDetails(PID);

                    if (strAdmissionDetails.Length == 0)
                    {
                        shInfo.SetMessage("Admission of this Candidate is Not Confirmed. So you can not edit it.", ShowMessageType.Information);
                    }
                    else
                    {
                        DataSet dsCAD = reg.getCurrentAdmissionDetails(PID);

                        if (dsCAD.Tables[0].Rows[0]["InstituteCode"].ToString() == UserLoginID)
                        {
                            if (dsCAD.Tables[0].Rows[0]["EditCategory"].ToString() == "Y")
                            {
                                Response.Redirect("../InstituteModule/frmEditCategoryDetails.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                            }
                            else
                            {
                                shInfo.SetMessage("Edit Category is Not Allowed for this Candidate.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("This Candidate is Not Admitted in this Institute. So you can not edit it.", ShowMessageType.Information);
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
        protected void ResetSelfSeatAcceptance()
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
                    DataSet DSAdmissionRequest = reg.getAdmictionCancellationandAdmitedDetails(PID);
                    if (reg.getAllotmentCancellationRemark(PID, Global.CAPRound).Length > 0)
                    {
                        shInfo.SetMessage("The Allotment made to candidate is already cancelled hence you cannot reset the self-verification of the candidate.", ShowMessageType.Information);
                    }
                    else if(DSAdmissionRequest.Tables[0].Rows.Count > 0)
                    {
                        shInfo.SetMessage("Candidate Already Admitted/Requested for Admission Cancellation you cannot reset the self-verification .", ShowMessageType.Information);
                    }
                    else
                    {
                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                        string UserLoginID = Session["UserLoginID"].ToString();
                        string Flag = "CancelSelfVerification";

                        DataSet dsReportingDetails = reg.getReportingDetailsAtCAP(PID, 'N', UserTypeID, UserLoginID, Flag, PID.ToString().GetHashCode().ToString());

                        if (dsReportingDetails.Tables[0].Rows.Count == 0)
                        {
                            if (UserTypeID == 21)
                            {
                                shInfo.SetMessage("This candidate is not allotted in any institute. So you can not Reset the Self verification and Seat Acceptance.", ShowMessageType.Information);
                            }
                            else if (UserTypeID == 22)
                            {
                                shInfo.SetMessage("This candidate is not allotted in any institute in your region. So you can not Reset the Self verification and Seat Acceptance.", ShowMessageType.Information);
                            }
                            else
                            {
                                shInfo.SetMessage("This candidate is not allotted in your institute. So you can not Reset the Self verification and Seat Acceptance.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            string strAdmissionDetails = reg.getAdmissionDetails(PID);

                            if (strAdmissionDetails.Length == 0)
                            {
                                cbSelectAdmission.Visible = true;

                                lblApplicationID.Text = txtApplicationID.Text;
                                lblCandidateName.Text = reg.getCandidateName(PID);

                                gvList.DataSource = dsReportingDetails;
                                gvList.DataBind();
                            }
                            else
                            {
                                shInfo.SetMessage(strAdmissionDetails, ShowMessageType.Information);
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
    }
}