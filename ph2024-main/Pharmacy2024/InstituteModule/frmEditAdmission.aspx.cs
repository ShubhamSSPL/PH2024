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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmEditAdmission : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        AzureDocumentUpload objDU = new AzureDocumentUpload();
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
                    lblNameAsPerHSCResult.Text = dsPersonalInformation.Tables[0].Rows[0]["NameAsPerHSCResult"].ToString();
                    lblNameAsPerHSCResult.ForeColor = System.Drawing.Color.Red;
                    lblCETCandidateName.Text = dsPersonalInformation.Tables[0].Rows[0]["CETCandidateName"].ToString();
                    lblCETCandidateName.ForeColor = System.Drawing.Color.Blue;
                    if (dsPersonalInformation.Tables[0].Rows[0]["CETCandidateName"].ToString() == "")
                    {
                        lblCETCandidateName.Text = "-- (Not Appeared for Exam)";
                    }
                    lblNEETName.Text = dsPersonalInformation.Tables[0].Rows[0]["NEETCName"].ToString();
                    lblNEETName.ForeColor = System.Drawing.Color.DarkOrange;
                    if (dsPersonalInformation.Tables[0].Rows[0]["NEETCName"].ToString() == "")
                    {
                        lblNEETName.Text = "-- (Not Appeared for Exam)";
                    }

                    DataSet dsReportingDetails = reg.getReportingDetailsByChoiceCode(PID, ChoiceCode, CAPRound, 'Y');

                    lblMeritNo.Text = dsReportingDetails.Tables[0].Rows[0]["MeritNo"].ToString();
                    lblMeritMarks.Text = dsReportingDetails.Tables[0].Rows[0]["MeritMarks"].ToString();
                    lblInstituteAllotted.Text = dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString() + " - " + dsReportingDetails.Tables[0].Rows[0]["InstituteName"].ToString();
                    lblCourseAllotted.Text = dsReportingDetails.Tables[0].Rows[0]["ChoiceCodeDisplay"].ToString() + " - " + dsReportingDetails.Tables[0].Rows[0]["CourseName"].ToString();
                    lblSeatTypeAllotted.Text = dsReportingDetails.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                    lblPreferenceNoAllotted.Text = dsReportingDetails.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString();
                    txtAdmissionDate.Text = dsReportingDetails.Tables[0].Rows[0]["AdmissionDate"].ToString();
                    txtRemark.Text = dsReportingDetails.Tables[0].Rows[0]["Comments"].ToString();

                    string InstituteCode = dsReportingDetails.Tables[0].Rows[0]["InstituteCode"].ToString();
                    ViewState["InstituteCode"] = InstituteCode;

                    gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Fee", InstituteCode, "CAP");
                    gvFeeList.DataBind();

                    Int64 TotalFeeAmount = 0;
                    for (Int32 i = 0; i < gvFeeList.Rows.Count; i++)
                    {
                        gvFeeList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        TotalFeeAmount += Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text);
                        gvFeeList.Rows[i].Cells[2].Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text)) + "/-";
                    }
                    lblTotalFeeAmount.Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", TotalFeeAmount) + "/-" + "<br />" + "(Rs. " + UserInfo.ConvertNumbertoWords(TotalFeeAmount) + " Only)";

                    gvDocuments.DataSource = reg.getDocumentListForInstitute(PID);
                    gvDocuments.DataBind();

                    for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                    {
                        Int32 j = i + 1;
                        gvDocuments.Rows[i].Cells[0].Text = j.ToString() + ".";
                    }

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
                obj.FeeType = "Fee";
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
                        gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Fee", ViewState["InstituteCode"].ToString(), "CAP");
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
                        gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Fee", ViewState["InstituteCode"].ToString(), "CAP");
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
                    gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Fee", ViewState["InstituteCode"].ToString(), "CAP");
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
        protected void gvDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidFURL = (HiddenField)e.Row.FindControl("hidFURL");
                if (hidFURL.Value != "")
                {
                    string ext = System.IO.Path.GetExtension(hidFURL.Value).ToLower();
                    HtmlImage imgDoc = (HtmlImage)e.Row.FindControl("imgDoc");
                    HiddenField hidDID = (HiddenField)e.Row.FindControl("hidDID");
                    HtmlAnchor hrefURL = (HtmlAnchor)e.Row.FindControl("hrefURL");
                    HiddenField hdnImgByteArray = (HiddenField)e.Row.FindControl("hdnImgByteArray");
                    hrefURL.HRef = ConfigurationManager.AppSettings["ApplicationURL"] + "ViewMyDocument.aspx?documentID=" + hidDID.Value;
                    if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".bmp")
                    {
                        string url = hidFURL.Value;
                        if (hidFURL.Value.Contains("studentdocuments"))
                        {
                            url = hidFURL.Value.Replace("studentdocuments", "studentdocumentsthumbnail");
                            string checkurl = url.Replace(ConfigurationManager.AppSettings["HttpAddress"], "");
                            if (!objDU.Exists(checkurl))
                            {
                                url = hidFURL.Value;
                            }
                        }
                        string base64 = objDU.GetBlobContentAsBase64("studentdocumentsthumbnail", url);//objDU.ConvertImageURLToBase64(url);
                        imgDoc.Src = base64; //"data:image/png;base64," +
                    }
                    else if (ext == ".pdf")
                    {
                        imgDoc.Src = "../images/pdf.gif";
                    }
                    else if (ext == ".zip" || ext == ".rar")
                    {
                        hrefURL.Target = "self";
                        imgDoc.Src = "../images/zip.png";
                    }
                    hdnImgByteArray.Value = objDU.GetBlobContentAsBase64("studentdocuments", hidFURL.Value.ToString());

                }
                if (((Label)e.Row.Cells[4].FindControl("lblIsSubmittedAtinstitute")).Text == "N")
                {
                    ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = false;
                    ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = true;
                }
                else
                {
                    ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = true;
                    ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = false;
                }
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
                DateTime AdmissionDate = Convert.ToDateTime(txtAdmissionDate.Text.Split("/".ToCharArray())[1] + "/" + txtAdmissionDate.Text.Split("/".ToCharArray())[0] + "/" + txtAdmissionDate.Text.Split("/".ToCharArray())[2]);

                string XMLString = "<DocumentList>";
                Int32 Documentnotverified = 0;
                for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                {
                    string DocumentID = ((Label)gvDocuments.Rows[i].FindControl("lblDocumentID")).Text;
                    string FilePath = ((HiddenField)gvDocuments.Rows[i].FindControl("hidFURL")).Value;

                    if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                    {
                        XMLString += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtinstitute=\"" + "Y" + "\"></Document>";
                    }
                    else
                    {
                        XMLString += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtinstitute=\"" + "N" + "\"></Document>";
                        if (FilePath.Length > 0)
                            //Documentnotverified = 1;
                            Documentnotverified = 0;
                    }
                }
                XMLString += "</DocumentList>";

                reg.updateDocumentSubmissionForInstitute(PID, XMLString, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                if (AdmissionDate > DateTime.Now.Date)
                {
                    shInfo.SetMessage("Admission Date should not be greater than Current Date.", ShowMessageType.Information);
                }
                else
                {
                    if (Documentnotverified == 0)
                    {
                        if (reg.editAdmissionByChoiceCode(PID, ChoiceCode, CAPRound, AdmissionDate, txtRemark.Text, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            Response.Redirect("../InstituteModule/frmAdmissionLetter.aspx?PID=" + PID.ToString() + "&ChoiceCode=" + ChoiceCode.ToString() + "&CAPRound=" + CAPRound.ToString() + "&Code=" + PID.ToString().GetHashCode().ToString());
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Submission of all documents is compulsory.", ShowMessageType.Information);
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