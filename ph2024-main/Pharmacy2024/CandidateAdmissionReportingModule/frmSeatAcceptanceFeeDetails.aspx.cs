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

namespace Pharmacy2024.CandidateAdmissionReportingModule
{
    public partial class frmSeatAcceptanceFeeDetails : System.Web.UI.Page
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
            if (Global.ARCReporting == 0)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx");
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    //PayuGateway objPay = new PayuGateway();
                    //DataSet ds1 = objPay.GetFailedPaymentDetails(Session["UserID"].ToString());
                    //if (ds1.Tables[0].Rows.Count > 0)
                    //{
                    //    string transectionId = string.Empty;
                    //    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    //    {
                    //        transectionId += ds1.Tables[0].Rows[i]["ReferenceNo"] + "|";
                    //    }
                    //    if (transectionId != string.Empty)
                    //    {
                    //        List<TransacionDetils> objList = objPay.GetTransactionsStatus(transectionId.TrimEnd('|'));
                    //        if (objList.Count > 0)
                    //        {
                    //            foreach (var txn in objList)
                    //            {
                    //                if (txn.TransactionStatus == "success")
                    //                    objPay.UpdateTransaction(long.Parse(txn.TransactionID), "Y", txn.BankRefNumber, "Y", true);
                    //                else
                    //                    objPay.UpdateTransaction(long.Parse(txn.TransactionID), "N", "", "Y", false);
                    //            }
                    //        }
                    //    }

                    //}

                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    string SeatAcceptanceConfirmationStatus = reg.getSeatAcceptanceConfirmationStatus(objSessionData.PID);

                    if (SeatAcceptanceConfirmationStatus == "Y")
                    {
                        shInfo.SetMessage("Seat Acceptance Status is Already Confirmed.", ShowMessageType.Information);
                        ContentTable2.Visible = false;
                    }
                    else
                    {
                        if (reg.isEligibleForSeatAcceptance(objSessionData.PID, Global.CAPRound))
                        {
                            if (reg.CheckSelfVerificationIsDone(objSessionData.PID))
                            {
                                DataSet dsAllotmentDetails = reg.getAllotmentDetails(objSessionData.PID);
                                if (Global.CAPRound >= 1)
                                {
                                    if (dsAllotmentDetails.Tables[0].Rows.Count > 0)
                                    {
                                        Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx", true);
                                    }
                                }
                                if (Global.CAPRound >= 2)
                                {
                                    if (dsAllotmentDetails.Tables[1].Rows.Count > 0)
                                    {
                                        Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx", true);
                                    }
                                }
                            }
                            DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(objSessionData.PID);
                            if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                            {
                                tblSeatAcceptanceStatusDetails.Visible = true;
                                // lblVersionNo.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["VersionNo"].ToString();
                                lblSeatAcceptanceStatus.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["SeatAcceptanceStatus"].ToString();
                                lblSeatAcceptanceConfirmationDetails.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["ReportingStatus"].ToString();
                            }
                            else
                            {
                                Response.Redirect("../CandidateAdmissionReportingModule/frmAllotmentDetails.aspx");
                            }
                            Int32 ApplicationFeeToBePaid = 0, FeesPaid = 0;
                            ApplicationFeeToBePaid = 1000;
                            txtDDAmount.Text = "1000";
                            FeesPaid = reg.getSeatAcceptanceFeePaidAmount(objSessionData.PID);

                            if (FeesPaid >= ApplicationFeeToBePaid)
                            {
                                shInfo.SetMessage("Seat Acceptance Fee is Already Paid Online.", ShowMessageType.Information);
                                ContentTable2.Visible = false;
                            }
                            else
                            {
                                ddlBankName.DataSource = Global.MasterBank;
                                ddlBankName.DataTextField = "BankName";
                                ddlBankName.DataValueField = "BankID";
                                ddlBankName.DataBind();
                                ddlBankName.Items.Insert(0, new ListItem("-- Select Bank --", "0"));

                                DataSet ds = reg.getSeatAcceptanceFeeDetails(objSessionData.PID, "Seat Acceptance Fee", "Unlocked");

                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    hdnFeeID.Value = ds.Tables[0].Rows[0]["FeeID"].ToString();
                                    if (ds.Tables[0].Rows[0]["PaymentMode"].ToString() == "Demand Draft")
                                    {
                                        rbnDD.Checked = true;

                                        txtDDNumber.Text = ds.Tables[0].Rows[0]["DDNumber"].ToString();
                                        txtDDDate.Text = ds.Tables[0].Rows[0]["DDDate"].ToString();
                                        ddlBankName.SelectedValue = ds.Tables[0].Rows[0]["BankID"].ToString();
                                        txtOtherBankName.Text = ds.Tables[0].Rows[0]["OtherBankName"].ToString();
                                        txtBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                                    }
                                    else
                                    {
                                        rbnOnline.Checked = true;
                                    }
                                }
                                else
                                {
                                    hdnFeeID.Value = "0";
                                }

                                onPageLoad();
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("Not Allotted in CAP Round " + Global.CAPRound.ToString() + ".", ShowMessageType.Information);
                            ContentTable2.Visible = false;
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
        protected void PaymentMode_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (rbnDD.Checked)
                {
                    tblDDDetails.Visible = true;
                }
                else
                {
                    tblDDDetails.Visible = false;
                }

                txtDDNumber.Text = "";
                txtDDDate.Text = "";
                ddlBankName.SelectedIndex = 0;
                txtOtherBankName.Text = "";
                txtBranchName.Text = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string BankName = ddlBankName.SelectedItem.Text;

                if (BankName == "[Other Bank]")
                {
                    trOtherBankName.Visible = true;
                }
                else
                {
                    trOtherBankName.Visible = false;
                }

                txtOtherBankName.Text = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void onPageLoad()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (rbnDD.Checked)
                {
                    tblDDDetails.Visible = true;
                }
                else
                {
                    tblDDDetails.Visible = false;
                }

                string BankName = ddlBankName.SelectedItem.Text;
                if (BankName == "[Other Bank]")
                {
                    trOtherBankName.Visible = true;
                }
                else
                {
                    trOtherBankName.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                SeatAcceptanceFeeDetails obj = new SeatAcceptanceFeeDetails();

                obj.FeeID = Convert.ToInt64(hdnFeeID.Value);
                obj.FeeType = "Seat Acceptance Fee";
                if (rbnOnline.Checked)
                {
                    obj.PaymentMode = "Online";
                }
                else if (rbnDD.Checked)
                {
                    obj.PaymentMode = "Demand Draft";
                }
                obj.DDAmount = Convert.ToInt64(txtDDAmount.Text);
                obj.DDNumber = txtDDNumber.Text;
                if (rbnDD.Checked)
                {
                    obj.DDDate = Convert.ToDateTime(txtDDDate.Text.Split("/".ToCharArray())[1] + "/" + txtDDDate.Text.Split("/".ToCharArray())[0] + "/" + txtDDDate.Text.Split("/".ToCharArray())[2]);
                }
                else
                {
                    obj.DDDate = DateTime.Now.Date;
                }
                obj.BankID = Convert.ToInt16(ddlBankName.SelectedValue);
                if (ddlBankName.SelectedItem.ToString() == "[Other Bank]")
                {
                    obj.OtherBankName = txtOtherBankName.Text;
                }
                else
                {
                    obj.OtherBankName = "";
                }
                obj.BranchName = txtBranchName.Text;

                if (reg.saveSeatAcceptanceFeeDetails(objSessionData.PID, obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    if (obj.PaymentMode == "Online")
                    {
                        Session["FeeGroupId"] = null;
                        Session["PhaseId"] = null;
                        Session["PayeeUserTypeId"] = null;
                        Session["PayeeId"] = null;

                        Session["FeeGroupId"] = "3";
                        Session["PhaseId"] = "1";
                        Session["PayeeUserTypeId"] = Session["UserTypeID"].ToString();
                        Session["PayeeId"] = Session["UserID"].ToString();

                        Response.Redirect("../FeeProcess/PaymentDetails.aspx", true);
                    }
                    else
                    {
                        Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceForm.aspx");
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