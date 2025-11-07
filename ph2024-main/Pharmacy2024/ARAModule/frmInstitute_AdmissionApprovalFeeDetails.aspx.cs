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

namespace Pharmacy2024.ARAModule
{
    public partial class frmInstitute_AdmissionApprovalFeeDetails : System.Web.UI.Page
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) != 43)
            {
                Response.Redirect("../ApplicationPages/WelcomePageInstitute", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (Session["SecretKey"] == null && ConfigurationManager.AppSettings["IsARATestKeyRequired"] == "Y")
            {
                ClientScript.RegisterStartupScript(GetType(), "id", "showSecretKey()", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    try
                    {
                        Int64 PID = Convert.ToInt64(Session["UserLoginID"].ToString()); //Convert.ToInt64(Request.QueryString["PID"].ToString());
                                                                                        //Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                        //if (PID.ToString().GetHashCode() != Code)
                        //{
                        //    Response.Redirect("../ApplicationPages/WelcomePageARC.aspx", true);
                        //}

                        string fromPage = "";
                        if (Request.QueryString["From"] != null)
                            fromPage = Request.QueryString["From"].ToString();
                        else
                            fromPage = "";

                        DataSet dsDashboard = reg.getAdmissionApprovalFeeDetailsTable(4, 1, Convert.ToInt32(Session["UserTypeID"].ToString()), PID);
                        if (dsDashboard.Tables[0].Rows.Count > 0)
                        {
                            gvDashboardInstitute.DataSource = dsDashboard.Tables[0];
                            gvDashboardInstitute.DataBind();

                            gvDashboardInstitute1.DataSource = dsDashboard.Tables[0];
                            gvDashboardInstitute1.DataBind();

                            Int32 TotalCAPIntake = 0;
                            Int32 TotalTFWSIntake = 0;
                            Int32 TotalDSEIntake = 0;
                            Int32 TotalAnyOtherSchemeIntake = 0;
                            Int32 TotalTotalNoofSeatsIntake = 0;
                            Int32 TotalIntakeAmount = 0;
                            Int32 TotalILIntake = 0;
                            Int32 TotalNRIIntake = 0;
                            Int32 TotalILAmount = 0;
                            Int32 TotalNRIAmount = 0;
                            Int32 TotalTotalAmount = 0;

                            int isGovt = 0;
                            int isUnAided = 0;

                            for (Int32 k = 0; k < gvDashboardInstitute.Rows.Count; k++)
                            {
                                TotalCAPIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[2].Text);
                                //TotalTFWSIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[3].Text);
                                TotalDSEIntake += 0;// Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[4].Text);
                                TotalAnyOtherSchemeIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[5].Text);
                                TotalTotalNoofSeatsIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[6].Text);
                                TotalILIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[8].Text);
                                TotalNRIIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[9].Text);
                                TotalILAmount += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[10].Text);
                                TotalNRIAmount += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[11].Text);
                                TotalTotalAmount += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[12].Text);

                                if (gvDashboardInstitute.Rows[k].Cells[1].Text == "Government" || gvDashboardInstitute.Rows[k].Cells[1].Text == "Government-Aided")
                                    //|| gvDashboardInstitute.Rows[k].Cells[1].Text == "University Department" || gvDashboardInstitute.Rows[k].Cells[1].Text == "University Managed"
                                    //|| gvDashboardInstitute.Rows[k].Cells[1].Text == "Deemed University")
                                {
                                    isGovt += 1;
                                    TotalIntakeAmount += 0;
                                }
                                else
                                {
                                    isUnAided += 1;
                                    TotalIntakeAmount += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[7].Text);
                                }
                            }

                            if (TotalIntakeAmount < 20000 && isUnAided > 0)
                            {
                                TotalIntakeAmount = 20000;
                                TotalTotalAmount = TotalIntakeAmount + TotalILAmount + TotalNRIAmount;

                                for (Int32 i = 0; i < gvDashboardInstitute.Rows.Count; i++)
                                {
                                    gvDashboardInstitute.Rows[i].Cells[7].Text = " - ";
                                    //gvDashboardInstitute.Rows[i].Cells[9].Text = " - ";
                                    gvDashboardInstitute.Rows[i].Cells[10].Text = " - ";
                                    gvDashboardInstitute.Rows[i].Cells[11].Text = " - ";
                                    gvDashboardInstitute.Rows[i].Cells[12].Text = " - ";
                                }

                                for (Int32 i = 0; i < gvDashboardInstitute1.Rows.Count; i++)
                                {
                                    gvDashboardInstitute1.Rows[i].Cells[7].Text = " - ";
                                    //gvDashboardInstitute1.Rows[i].Cells[9].Text = " - ";
                                    gvDashboardInstitute1.Rows[i].Cells[10].Text = " - ";
                                    gvDashboardInstitute1.Rows[i].Cells[11].Text = " - ";
                                    gvDashboardInstitute1.Rows[i].Cells[12].Text = " - ";
                                }
                            }

                            if (isGovt > 0 && isUnAided < 1)
                            {
                                TotalIntakeAmount = 0;
                                TotalTotalAmount = 0;

                                for (Int32 i = 0; i < gvDashboardInstitute.Rows.Count; i++)
                                {
                                    gvDashboardInstitute.Rows[i].Cells[7].Text = " - ";
                                    //gvDashboardInstitute.Rows[i].Cells[9].Text = " - ";
                                    gvDashboardInstitute.Rows[i].Cells[10].Text = " - ";
                                    gvDashboardInstitute.Rows[i].Cells[11].Text = " - ";
                                    gvDashboardInstitute.Rows[i].Cells[12].Text = " - ";
                                }

                                for (Int32 i = 0; i < gvDashboardInstitute1.Rows.Count; i++)
                                {
                                    gvDashboardInstitute1.Rows[i].Cells[7].Text = " - ";
                                    //gvDashboardInstitute1.Rows[i].Cells[9].Text = " - ";
                                    gvDashboardInstitute1.Rows[i].Cells[10].Text = " - ";
                                    gvDashboardInstitute1.Rows[i].Cells[11].Text = " - ";
                                    gvDashboardInstitute1.Rows[i].Cells[12].Text = " - ";
                                }
                            }

                            gvDashboardInstitute.FooterRow.Cells[0].Text = "";
                            gvDashboardInstitute.FooterRow.Cells[1].Text = "Total";
                            gvDashboardInstitute.FooterRow.Cells[2].Text = TotalCAPIntake.ToString();
                            gvDashboardInstitute.FooterRow.Cells[3].Text = TotalTFWSIntake.ToString();
                            gvDashboardInstitute.FooterRow.Cells[4].Text = TotalDSEIntake.ToString();
                            gvDashboardInstitute.FooterRow.Cells[5].Text = TotalAnyOtherSchemeIntake.ToString();
                            gvDashboardInstitute.FooterRow.Cells[6].Text = TotalTotalNoofSeatsIntake.ToString();
                            gvDashboardInstitute.FooterRow.Cells[7].Text = TotalIntakeAmount.ToString();
                            gvDashboardInstitute.FooterRow.Cells[8].Text = TotalILIntake.ToString();
                            gvDashboardInstitute.FooterRow.Cells[9].Text = TotalNRIIntake.ToString();
                            gvDashboardInstitute.FooterRow.Cells[10].Text = TotalILAmount.ToString();
                            gvDashboardInstitute.FooterRow.Cells[11].Text = TotalNRIAmount.ToString();
                            gvDashboardInstitute.FooterRow.Cells[12].Text = TotalTotalAmount.ToString();

                            /**************************************/


                            //Int32 TotalCAPIntake = 0;
                            //Int32 TotalTFWSIntake = 0;
                            //Int32 TotalDSEIntake = 0;
                            //Int32 TotalAnyOtherSchemeIntake = 0;
                            //Int32 TotalTotalNoofSeatsIntake = 0;
                            //Int32 TotalIntakeAmount = 0;
                            //Int32 TotalILNRIIntake = 0;
                            //Int32 TotalILNRIAmount = 0;
                            //Int32 TotalTotalAmount = 0;

                            //for (Int32 k = 0; k < gvDashboardInstitute1.Rows.Count; k++)
                            //{
                            //    TotalCAPIntake += Convert.ToInt32(gvDashboardInstitute1.Rows[k].Cells[1].Text);
                            //    TotalTFWSIntake += Convert.ToInt32(gvDashboardInstitute1.Rows[k].Cells[2].Text);
                            //    TotalDSEIntake += Convert.ToInt32(gvDashboardInstitute1.Rows[k].Cells[3].Text);
                            //    TotalAnyOtherSchemeIntake += Convert.ToInt32(gvDashboardInstitute1.Rows[k].Cells[4].Text);
                            //    TotalTotalNoofSeatsIntake += Convert.ToInt32(gvDashboardInstitute1.Rows[k].Cells[5].Text);
                            //    TotalIntakeAmount += Convert.ToInt32(gvDashboardInstitute1.Rows[k].Cells[6].Text);
                            //    TotalILNRIIntake += Convert.ToInt32(gvDashboardInstitute1.Rows[k].Cells[7].Text);
                            //    TotalILNRIAmount += Convert.ToInt32(gvDashboardInstitute1.Rows[k].Cells[8].Text);
                            //    TotalTotalAmount += Convert.ToInt32(gvDashboardInstitute1.Rows[k].Cells[9].Text);
                            //}
                            gvDashboardInstitute1.FooterRow.Cells[0].Text = "";
                            gvDashboardInstitute1.FooterRow.Cells[1].Text = "Total";
                            gvDashboardInstitute1.FooterRow.Cells[2].Text = TotalCAPIntake.ToString();
                            gvDashboardInstitute1.FooterRow.Cells[3].Text = TotalTFWSIntake.ToString();
                            gvDashboardInstitute1.FooterRow.Cells[4].Text = TotalDSEIntake.ToString();
                            gvDashboardInstitute1.FooterRow.Cells[5].Text = TotalAnyOtherSchemeIntake.ToString();
                            gvDashboardInstitute1.FooterRow.Cells[6].Text = TotalTotalNoofSeatsIntake.ToString();
                            gvDashboardInstitute1.FooterRow.Cells[7].Text = TotalIntakeAmount.ToString();
                            gvDashboardInstitute1.FooterRow.Cells[8].Text = TotalILIntake.ToString();
                            gvDashboardInstitute1.FooterRow.Cells[9].Text = TotalNRIIntake.ToString();
                            gvDashboardInstitute1.FooterRow.Cells[10].Text = TotalILAmount.ToString();
                            gvDashboardInstitute1.FooterRow.Cells[11].Text = TotalNRIAmount.ToString();
                            gvDashboardInstitute1.FooterRow.Cells[12].Text = TotalTotalAmount.ToString();
                        }

                        Int32 ApplicationFeeToBePaid = 0, FeesPaid = 0;
                        ApplicationFeeToBePaid = reg.getAdmissionApprovalFeeToBePaid(4, 1, Convert.ToInt32(Session["UserTypeID"].ToString()), PID); // Get Institute Admission Approval Fees
                        lblApplicationFeeToBePaid.Text = ApplicationFeeToBePaid.ToString() + "/-";

                        txtDDAmount.Text = ApplicationFeeToBePaid.ToString();
                        FeesPaid = reg.getAdmissionApprovalFeePaidAmount(PID);
                        lblAdmissionApprovalFeePaid.Text = FeesPaid.ToString() + "/-";

                        ApplicationFeeToBePaid = ApplicationFeeToBePaid - FeesPaid;
                        lblApplicationFeeToBePaid.Text = ApplicationFeeToBePaid.ToString() + "/-";

                        //if (FeesPaid >= ApplicationFeeToBePaid && fromPage == "" && ApplicationFeeToBePaid != 0)
                        if (FeesPaid >= ApplicationFeeToBePaid && fromPage == "" && ApplicationFeeToBePaid == 0 && FeesPaid != 0)
                        {
                            shInfo.SetMessage("You have Already Paid Admission Approval Fee Online.", ShowMessageType.Information);
                            ContentTable2.Visible = false;
                        }
                        else if (FeesPaid >= ApplicationFeeToBePaid && fromPage == "PaymentSuccess" && ApplicationFeeToBePaid == 0 && FeesPaid != 0)
                        {
                            shInfo.SetMessage("Admission Approval Fee Paid Successfully.", ShowMessageType.Information);
                            ContentTable2.Visible = false;
                        }
                        else
                        {
                            ContentTable3.Visible = false;

                            ddlBankName.DataSource = Global.MasterBank;
                            ddlBankName.DataTextField = "BankName";
                            ddlBankName.DataValueField = "BankID";
                            ddlBankName.DataBind();
                            ddlBankName.Items.Insert(0, new ListItem("-- Select Bank --", "0"));

                            DataSet ds = reg.getAdmissionApprovalFeeDetails(PID, "Admission Approval Fee", "Unlocked");

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

                            if (FeesPaid == 0 && ApplicationFeeToBePaid == 0)
                            {
                                lblAdmissionApprovalFeePaid.Text = "Nil/-";
                                //trPaymentMode.Visible = false;
                                rbnOnline.Checked = true;
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
                //Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int64 PID = Convert.ToInt64(Session["UserLoginID"].ToString());
                AdmissionApprovalFeeDetails obj = new AdmissionApprovalFeeDetails();

                obj.FeeID = Convert.ToInt64(hdnFeeID.Value);
                obj.FeeType = "Admission Approval Fee";
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

                if (reg.saveAdmissionApprovalFeeDetails(PID, obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    if (lblAdmissionApprovalFeePaid.Text == "Nil/-")
                    {
                        Response.Redirect("frmPrintAdmissionApprovalFeeReceipt.aspx", true);
                    }
                    else if (obj.PaymentMode == "Online")
                    {
                        Session["FeeGroupId"] = null;
                        Session["PhaseId"] = null;
                        Session["PayeeUserTypeId"] = null;
                        Session["PayeeId"] = null;

                        Session["FeeGroupId"] = "4";
                        Session["PhaseId"] = "1";
                        Session["PayeeUserTypeId"] = "43";
                        Session["PayeeId"] = PID.ToString();

                        Response.Redirect("../FeeProcess/PaymentDetails.aspx", true);
                    }
                    //else
                    //{
                    //    Response.Redirect("../ARCModule/frmSeatAcceptanceForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    //}
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


        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSecretKey_Click(object sender, EventArgs e)
        {
            if (txtkey.Text == Application["SecretKey"].ToString())
            {
                Session["SecretKey"] = Application["SecretKey"].ToString();
                Response.Redirect("../ARAModule/frmInstitute_AdmissionApprovalFeeDetails");
            }
            else
            {
                lblmsg.Text = "Enter the Correct SecretKey!!";
                lblmsg.Visible = true;
                //Response.Redirect(ConfigurationManager.AppSettings["ApplicationURL"]);
            }
        }
    }
}