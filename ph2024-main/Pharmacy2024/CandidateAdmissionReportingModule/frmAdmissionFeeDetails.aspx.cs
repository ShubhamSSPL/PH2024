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
    public partial class frmAdmissionFeeDetails : System.Web.UI.Page
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
                    SessionData objSessionData = (SessionData)Session["SessionData"];

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