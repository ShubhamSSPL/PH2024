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

namespace Pharmacy2024.InstituteModule
{
    public partial class frmCancelAdmission : System.Web.UI.Page
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
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageInstitute.aspx", true);
                    }

                    Int64 ChoiceCode = Convert.ToInt64(Request.QueryString["ChoiceCode"].ToString());
                    Int32 CAPRound = Convert.ToInt32(Request.QueryString["CAPRound"].ToString());

                    ddlBankName.DataSource = Global.MasterBank;
                    ddlBankName.DataTextField = "BankName";
                    ddlBankName.DataValueField = "BankID";
                    ddlBankName.DataBind();
                    ddlBankName.Items.Insert(0, new ListItem("-- Select Bank --", "0"));

                    DataSet dsPersonalInformation = reg.getPersonalInformationForInstitute(PID);

                    lblApplicationID.Text = dsPersonalInformation.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblCandidateName.Text = dsPersonalInformation.Tables[0].Rows[0]["CandidateName"].ToString().ToUpper();
                    lblGender.Text = dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString();
                    lblDOB.Text = dsPersonalInformation.Tables[0].Rows[0]["DOB"].ToString();
                    lblCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                    lblHomeUniversity.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                    lblOriginalCategory.Text = dsPersonalInformation.Tables[0].Rows[0]["Category"].ToString();
                    lblCategoryForAdmission.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCategory"].ToString();
                    lblAppliedForEWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                    lblAppliedForOrphan.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                    lblPHType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString();
                    lblDefenceType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                    lblLinguisticMinority.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalLinguisticMinority"].ToString();
                    lblReligiousMinority.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalReligiousMinority"].ToString();
                    lblAppliedForTFWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();

                    DataSet dsReportingDetails = reg.getReportingDetailsByChoiceCode(PID, ChoiceCode, CAPRound, 'Y');

                    lblMeritNo.Text = dsReportingDetails.Tables[0].Rows[0]["MeritNo"].ToString();
                    lblMeritMarks.Text = dsReportingDetails.Tables[0].Rows[0]["MeritMarks"].ToString();
                    lblInstituteAllotted.Text = dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString() + " - " + dsReportingDetails.Tables[0].Rows[0]["InstituteName"].ToString();
                    lblCourseAllotted.Text = dsReportingDetails.Tables[0].Rows[0]["ChoiceCodeDisplay"].ToString() + " - " + dsReportingDetails.Tables[0].Rows[0]["CourseName"].ToString();
                    lblSeatTypeAllotted.Text = dsReportingDetails.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                    lblPreferenceNoAllotted.Text = dsReportingDetails.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString();

                    string InstituteCode = dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString();
                    ViewState["InstituteCode"] = InstituteCode;

                    gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Refund", InstituteCode, "CAP");
                    gvFeeList.DataBind();

                    Int64 TotalFeeAmount = 0;
                    for (Int32 i = 0; i < gvFeeList.Rows.Count; i++)
                    {
                        gvFeeList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        TotalFeeAmount += Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text);
                        gvFeeList.Rows[i].Cells[2].Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text)) + "/-";
                    }
                    lblTotalFeeAmount.Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", TotalFeeAmount) + "/-" + "<br />" + "(Rs. " + UserInfo.ConvertNumbertoWords(TotalFeeAmount) + " Only)";

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;

                    onPageLoad();
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
                if (rbnPaymentModeDD.Checked)
                {
                    trDD1.Visible = true;
                    trDD2.Visible = true;
                    trDD3.Visible = true;
                    trDD4.Visible = true;
                    trDD5.Visible = true;
                    trDD6.Visible = true;
                    trCash.Visible = false;
                    trFeeButtons.Visible = true;
                }
                else if (rbnPaymentModeCash.Checked || rbnPaymentModeOnline.Checked)
                {
                    trDD1.Visible = false;
                    trDD2.Visible = false;
                    trDD3.Visible = false;
                    trDD4.Visible = false;
                    trDD5.Visible = false;
                    trDD6.Visible = false;
                    trCash.Visible = true;
                    trFeeButtons.Visible = true;
                }
                else
                {
                    trDD1.Visible = false;
                    trDD2.Visible = false;
                    trDD3.Visible = false;
                    trDD4.Visible = false;
                    trDD5.Visible = false;
                    trDD6.Visible = false;
                    trCash.Visible = false;
                    trFeeButtons.Visible = false;
                }

                if (ddlBankName.SelectedItem.Text == "[Other Bank]")
                {
                    trDD5.Visible = true;
                }
                else
                {
                    trDD5.Visible = false;
                }

                txtDDNumber.Text = "";
                txtDDAmount.Text = "";
                txtDDDate.Text = "";
                ddlBankName.SelectedIndex = 0;
                txtOtherBankName.Text = "";
                txtBranchName.Text = "";
                txtCashAmount.Text = "";
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
                if (ddlBankName.SelectedItem.Text == "[Other Bank]")
                {
                    trDD5.Visible = true;
                }
                else
                {
                    trDD5.Visible = false;
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
                if (rbnPaymentModeDD.Checked)
                {
                    trDD1.Visible = true;
                    trDD2.Visible = true;
                    trDD3.Visible = true;
                    trDD4.Visible = true;
                    trDD5.Visible = true;
                    trDD6.Visible = true;
                    trCash.Visible = false;
                    trFeeButtons.Visible = true;
                }
                else if (rbnPaymentModeCash.Checked || rbnPaymentModeOnline.Checked)
                {
                    trDD1.Visible = false;
                    trDD2.Visible = false;
                    trDD3.Visible = false;
                    trDD4.Visible = false;
                    trDD5.Visible = false;
                    trDD6.Visible = false;
                    trCash.Visible = true;
                    trFeeButtons.Visible = true;
                }
                else
                {
                    trDD1.Visible = false;
                    trDD2.Visible = false;
                    trDD3.Visible = false;
                    trDD4.Visible = false;
                    trDD5.Visible = false;
                    trDD6.Visible = false;
                    trCash.Visible = false;
                    trFeeButtons.Visible = false;
                }

                if (ddlBankName.SelectedItem.Text == "[Other Bank]")
                {
                    trDD5.Visible = true;
                }
                else
                {
                    trDD5.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                InstituteFeeDetails obj = new InstituteFeeDetails();

                obj.PID = PID;
                obj.FeeType = "Refund";
                if (rbnPaymentModeDD.Checked)
                {
                    obj.PaymentMode = "DD / Cheque";
                    obj.FeeAmount = Convert.ToInt64(txtDDAmount.Text);
                    obj.DDNumber = txtDDNumber.Text;
                    obj.DDDate = Convert.ToDateTime(txtDDDate.Text.Split("/".ToCharArray())[1] + "/" + txtDDDate.Text.Split("/".ToCharArray())[0] + "/" + txtDDDate.Text.Split("/".ToCharArray())[2]);
                    obj.BankID = Convert.ToInt16(ddlBankName.SelectedValue);
                    obj.OtherBankName = txtOtherBankName.Text;
                    obj.BranchName = txtBranchName.Text;
                }
                else
                {
                    if (rbnPaymentModeCash.Checked)
                    {
                        obj.PaymentMode = "Cash";
                    }
                    else if (rbnPaymentModeOnline.Checked)
                    {
                        obj.PaymentMode = "Online";
                    }
                    obj.FeeAmount = Convert.ToInt64(txtCashAmount.Text);
                    obj.DDNumber = "";
                    obj.DDDate = DateTime.Now.Date;
                    obj.BankID = Convert.ToInt16("0");
                    obj.OtherBankName = "";
                    obj.BranchName = "";
                }
                obj.InstituteCode = ViewState["InstituteCode"].ToString();

                if (obj.DDDate > DateTime.Now.Date)
                {
                    shInfo.SetMessage("DD Date should not be greater than Current Date.", ShowMessageType.Information);
                }
                else
                {
                    Int32 Result = reg.saveInstituteFeeDetails(obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), "CAP");
                    if (Result == 1)
                    {
                        shInfo.SetMessage("Demand Draft / Cheque Number - <b>" + txtDDNumber.Text + "</b> is Already added for this Candidate.", ShowMessageType.Information);
                    }
                    else if (Result == 2)
                    {
                        gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Refund", ViewState["InstituteCode"].ToString(), "CAP");
                        gvFeeList.DataBind();

                        Int64 TotalFeeAmount = 0;
                        for (Int32 i = 0; i < gvFeeList.Rows.Count; i++)
                        {
                            gvFeeList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            TotalFeeAmount += Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text);
                            gvFeeList.Rows[i].Cells[2].Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text)) + "/-";
                        }
                        lblTotalFeeAmount.Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", TotalFeeAmount) + "/-" + "<br />" + "(Rs. " + UserInfo.ConvertNumbertoWords(TotalFeeAmount) + " Only)";

                        rbnPaymentModeDD.Checked = false;
                        rbnPaymentModeCash.Checked = false;
                        rbnPaymentModeOnline.Checked = false;
                        txtDDNumber.Text = "";
                        txtDDAmount.Text = "";
                        txtDDDate.Text = "";
                        ddlBankName.SelectedIndex = 0;
                        txtOtherBankName.Text = "";
                        txtBranchName.Text = "";
                        txtCashAmount.Text = "";

                        btnAdd.Visible = true;
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnCancel.Visible = true;

                        trDD1.Visible = false;
                        trDD2.Visible = false;
                        trDD3.Visible = false;
                        trDD4.Visible = false;
                        trDD5.Visible = false;
                        trDD6.Visible = false;
                        trCash.Visible = false;
                        trFeeButtons.Visible = false;

                        shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                InstituteFeeDetails obj = new InstituteFeeDetails();

                obj.FeeID = Convert.ToInt64(hdnFeeID.Value);
                obj.PID = PID;
                if (rbnPaymentModeDD.Checked)
                {
                    obj.PaymentMode = "DD / Cheque";
                    obj.FeeAmount = Convert.ToInt64(txtDDAmount.Text);
                    obj.DDNumber = txtDDNumber.Text;
                    obj.DDDate = Convert.ToDateTime(txtDDDate.Text.Split("/".ToCharArray())[1] + "/" + txtDDDate.Text.Split("/".ToCharArray())[0] + "/" + txtDDDate.Text.Split("/".ToCharArray())[2]);
                    obj.BankID = Convert.ToInt16(ddlBankName.SelectedValue);
                    obj.OtherBankName = txtOtherBankName.Text;
                    obj.BranchName = txtBranchName.Text;
                }
                else
                {
                    if (rbnPaymentModeCash.Checked)
                    {
                        obj.PaymentMode = "Cash";
                    }
                    else if (rbnPaymentModeOnline.Checked)
                    {
                        obj.PaymentMode = "Online";
                    }
                    obj.FeeAmount = Convert.ToInt64(txtCashAmount.Text);
                    obj.DDNumber = "";
                    obj.DDDate = DateTime.Now.Date;
                    obj.BankID = Convert.ToInt16("0");
                    obj.OtherBankName = "";
                    obj.BranchName = "";
                }
                obj.InstituteCode = ViewState["InstituteCode"].ToString();

                if (obj.DDDate > DateTime.Now.Date)
                {
                    shInfo.SetMessage("DD Date should not be greater than Current Date.", ShowMessageType.Information);
                }
                else
                {
                    Int32 Result = reg.editInstituteFeeDetails(obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                    if (Result == 1)
                    {
                        shInfo.Visible = true;
                        shInfo.SetMessage("Demand Draft / Cheque Number - <b>" + txtDDNumber.Text + "</b> is Already added for this Candidate.", ShowMessageType.Information);
                    }
                    else if (Result == 2)
                    {
                        gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Refund", ViewState["InstituteCode"].ToString(), "CAP");
                        gvFeeList.DataBind();

                        Int64 TotalFeeAmount = 0;
                        for (Int32 i = 0; i < gvFeeList.Rows.Count; i++)
                        {
                            gvFeeList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            TotalFeeAmount += Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text);
                            gvFeeList.Rows[i].Cells[2].Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text)) + "/-";
                        }
                        lblTotalFeeAmount.Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", TotalFeeAmount) + "/-" + "<br />" + "(Rs. " + UserInfo.ConvertNumbertoWords(TotalFeeAmount) + " Only)";

                        rbnPaymentModeDD.Checked = false;
                        rbnPaymentModeCash.Checked = false;
                        rbnPaymentModeOnline.Checked = false;
                        txtDDNumber.Text = "";
                        txtDDAmount.Text = "";
                        txtDDDate.Text = "";
                        ddlBankName.SelectedIndex = 0;
                        txtOtherBankName.Text = "";
                        txtBranchName.Text = "";
                        txtCashAmount.Text = "";

                        btnAdd.Visible = true;
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnCancel.Visible = true;

                        trDD1.Visible = false;
                        trDD2.Visible = false;
                        trDD3.Visible = false;
                        trDD4.Visible = false;
                        trDD5.Visible = false;
                        trDD6.Visible = false;
                        trCash.Visible = false;
                        trFeeButtons.Visible = false;

                        shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int64 FeeID = Convert.ToInt64(hdnFeeID.Value);

                if (reg.deleteInstituteFeeDetails(FeeID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Refund", ViewState["InstituteCode"].ToString(), "CAP");
                    gvFeeList.DataBind();

                    Int64 TotalFeeAmount = 0;
                    for (Int32 i = 0; i < gvFeeList.Rows.Count; i++)
                    {
                        gvFeeList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        TotalFeeAmount += Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text);
                        gvFeeList.Rows[i].Cells[2].Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text)) + "/-";
                    }
                    lblTotalFeeAmount.Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", TotalFeeAmount) + "/-" + "<br />" + "(Rs. " + UserInfo.ConvertNumbertoWords(TotalFeeAmount) + " Only)";

                    rbnPaymentModeDD.Checked = false;
                    rbnPaymentModeCash.Checked = false;
                    rbnPaymentModeOnline.Checked = false;
                    txtDDNumber.Text = "";
                    txtDDAmount.Text = "";
                    txtDDDate.Text = "";
                    ddlBankName.SelectedIndex = 0;
                    txtOtherBankName.Text = "";
                    txtBranchName.Text = "";
                    txtCashAmount.Text = "";

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;

                    trDD1.Visible = false;
                    trDD2.Visible = false;
                    trDD3.Visible = false;
                    trDD4.Visible = false;
                    trDD5.Visible = false;
                    trDD6.Visible = false;
                    trCash.Visible = false;
                    trFeeButtons.Visible = false;

                    shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                rbnPaymentModeDD.Checked = false;
                rbnPaymentModeCash.Checked = false;
                rbnPaymentModeOnline.Checked = false;
                txtDDNumber.Text = "";
                txtDDAmount.Text = "";
                txtDDDate.Text = "";
                ddlBankName.SelectedIndex = 0;
                txtOtherBankName.Text = "";
                txtBranchName.Text = "";
                txtCashAmount.Text = "";

                btnAdd.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                trDD1.Visible = false;
                trDD2.Visible = false;
                trDD3.Visible = false;
                trDD4.Visible = false;
                trDD5.Visible = false;
                trDD6.Visible = false;
                trCash.Visible = false;
                trFeeButtons.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvFeeList_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 FeeID = Convert.ToInt64(e.CommandArgument.ToString());
                DataSet ds = reg.getInstituteFeeDetails(FeeID);

                hdnFeeID.Value = FeeID.ToString();
                if (ds.Tables[0].Rows[0]["PaymentMode"].ToString() == "DD / Cheque")
                {
                    rbnPaymentModeDD.Checked = true;
                    txtDDNumber.Text = ds.Tables[0].Rows[0]["DDNumber"].ToString();
                    txtDDAmount.Text = ds.Tables[0].Rows[0]["FeeAmount"].ToString();
                    txtDDDate.Text = ds.Tables[0].Rows[0]["DDDate"].ToString();
                    ddlBankName.SelectedValue = ds.Tables[0].Rows[0]["BankID"].ToString();
                    txtOtherBankName.Text = ds.Tables[0].Rows[0]["OtherBankName"].ToString();
                    txtBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();

                    trDD1.Visible = true;
                    trDD2.Visible = true;
                    trDD3.Visible = true;
                    trDD4.Visible = true;
                    trDD5.Visible = true;
                    trDD6.Visible = true;
                    trCash.Visible = false;
                    trFeeButtons.Visible = true;

                    if (ddlBankName.SelectedItem.Text == "[Other Bank]")
                    {
                        trDD5.Visible = true;
                    }
                    else
                    {
                        trDD5.Visible = false;
                    }
                }
                else
                {
                    if (ds.Tables[0].Rows[0]["PaymentMode"].ToString() == "Cash")
                    {
                        rbnPaymentModeCash.Checked = true;
                    }
                    else if (ds.Tables[0].Rows[0]["PaymentMode"].ToString() == "Online")
                    {
                        rbnPaymentModeOnline.Checked = true;
                    }
                    txtCashAmount.Text = ds.Tables[0].Rows[0]["FeeAmount"].ToString();

                    trDD1.Visible = false;
                    trDD2.Visible = false;
                    trDD3.Visible = false;
                    trDD4.Visible = false;
                    trDD5.Visible = false;
                    trDD6.Visible = false;
                    trCash.Visible = true;
                    trFeeButtons.Visible = true;
                }

                if (e.CommandName == "EditFee")
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                }
                else if (e.CommandName == "DeleteFee")
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                Int64 ChoiceCode = Convert.ToInt64(Request.QueryString["ChoiceCode"].ToString());
                Int32 CAPRound = Convert.ToInt32(Request.QueryString["CAPRound"].ToString());
                string ChoiceCodeD = reg.getChoiceCodeDisplayByChoiceCode(ChoiceCode);

                if (reg.cancelAdmissionByChoiceCode(PID, ChoiceCode, CAPRound, Convert.ToInt64(txtCancellationCharge.Text), txtRemark.Text, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    SMSTemplate sMSTemplate = new SMSTemplate();
                    SynCommon synCommon = new SynCommon();
                    sMSTemplate.PID = PID;
                    sMSTemplate.ChoiceCodeDisplay = ChoiceCodeD;
                    sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                    sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                    sMSTemplate.IPAddress = UserInfo.GetIPAddress();
                    if (Global.SendSMSToCandidate == 1)
                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CanceledAdmissionInstitue);
                    Response.Redirect("../InstituteModule/frmAdmissionCancellationLetter.aspx?PID=" + PID.ToString() + "&ChoiceCode=" + ChoiceCode.ToString() + "&CAPRound=" + CAPRound.ToString() + "&Code=" + PID.ToString().GetHashCode().ToString());
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
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