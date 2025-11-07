using BusinessLayer;
using EntityModel;
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

namespace Pharmacy2024.InstituteModule
{
    public partial class frmConfirmAdmissionAtIL : System.Web.UI.Page
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
            if (Global.InstituteReporting == 0 && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePageInstitute.aspx", true);
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

                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();

                    ddlBankName.DataSource = Global.MasterBank;
                    ddlBankName.DataTextField = "BankName";
                    ddlBankName.DataValueField = "BankID";
                    ddlBankName.DataBind();
                    ddlBankName.Items.Insert(0, new ListItem("-- Select Bank --", "0"));

                    if (UserTypeID == 43)
                    {
                        trInstitute.Visible = false;

                        ddlCourse.DataSource = reg.getChoiceCodeListByInstituteForAdmissionAtIL(PID, UserLoginID);
                        ddlCourse.DataTextField = "CourseName";
                        ddlCourse.DataValueField = "ChoiceCode";
                        ddlCourse.DataBind();
                        ddlCourse.Items.Insert(0, new ListItem("-- Select Course --", "0"));


                        ddlSeatType.DataSource = reg.getSeatTypeListForAdmissionAtIL(UserLoginID);
                        ddlSeatType.DataTextField = "SeatTypeDetails";
                        ddlSeatType.DataValueField = "SeatTypeCode";
                        ddlSeatType.DataBind();
                        ddlSeatType.Items.Insert(0, new ListItem("-- Select Seat Type --", "0"));
                        //if (new dbUtility().FinalDataSubmitted(Session["UserLoginID"].ToString()))
                        //{
                        //    ddlSeatType.Items.Remove(ddlSeatType.Items.FindByText("Against CAP (Excluding Minority)"));
                        //    ddlSeatType.Items.Remove(ddlSeatType.Items.FindByText("Against CAP (Minority) (Minority Candidate)"));
                        //    ddlSeatType.Items.Remove(ddlSeatType.Items.FindByText("Against CAP (Minority) (Non-Minority Candidate)"));
                        //}
                        Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                        if (CandidatureTypeID == 15)
                        {
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("ACAP"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("MI"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("AMIN"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("IL"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("ILNRI"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("NRI"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("PIO"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("FNS"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("CIWGC"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("JKSSS"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("OAA"));
                        }
                        else if (CandidatureTypeID == 16)
                        {
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("ACAP"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("MI"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("AMIN"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("IL"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("ILNRI"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("NRI"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("PIO"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("FNS"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("CIWGC"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("NEUT"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("OAA"));
                        }
                        else
                        {
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("JKSSS"));
                            ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("NEUT"));
                        }
                    }
                    else
                    {
                        ddlInstitute.DataSource = reg.getInstituteListForAdmissionAtIL(UserTypeID, UserLoginID);
                        ddlInstitute.DataTextField = "InstituteName";
                        ddlInstitute.DataValueField = "InstituteCode";
                        ddlInstitute.DataBind();
                        ddlInstitute.Items.Insert(0, new ListItem("-- Select Institute --", "0"));

                        ddlCourse.Items.Insert(0, new ListItem("-- Select Course --", "0"));
                        ddlSeatType.Items.Insert(0, new ListItem("-- Select Seat Type --", "0"));
                    }

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
                    lblHSCEligibilityPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCEligibilityPercentage"].ToString() + " %";
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
                    if (dsPersonalInformation.Tables[0].Rows[0]["CETPCMBMAX"].ToString() == "0")
                    {
                        lblCETPCMBMAX.Text = "-";
                    }
                    else
                    {
                        lblCETPCMBMAX.Text = dsPersonalInformation.Tables[0].Rows[0]["CETPCMBMAX"].ToString();
                    }

                    if (dsPersonalInformation.Tables[0].Rows[0]["NEETTotalScore"].ToString() == "0.0000000")
                    {
                        lblNEETTotal.Text = "-";
                    }
                    else
                    {
                        lblNEETTotal.Text = dsPersonalInformation.Tables[0].Rows[0]["NEETTotalScore"].ToString();
                    }

                    if (dsPersonalInformation.Tables[0].Rows[0]["StateGeneralMeritNo"].ToString() == "0")
                    {
                        lblStateGeneralMeritNo.Text = "-";
                    }
                    else
                    {
                        lblStateGeneralMeritNo.Text = dsPersonalInformation.Tables[0].Rows[0]["StateGeneralMeritNo"].ToString();
                    }

                    if (dsPersonalInformation.Tables[0].Rows[0]["AIMeritNo"].ToString() == "0")
                    {
                        lblAIMertiNo.Text = "-";
                    }
                    else
                    {
                        lblAIMertiNo.Text = dsPersonalInformation.Tables[0].Rows[0]["AIMeritNo"].ToString();
                    }


                    lblMobileNo.Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(dsPersonalInformation.Tables[0].Rows[0]["MobileNo"].ToString()));
                    if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["DiplomaEligibilityPercentage"].ToString()) > 0)
                    {
                        lblDiplomaEligibilityPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["DiplomaEligibilityPercentage"].ToString() + " %";
                    }
                    else
                    {
                        lblDiplomaEligibilityPercentage.Text = "--";
                    }

                    string InstituteCode = Session["UserLoginID"].ToString();
                    ViewState["InstituteCode"] = InstituteCode;

                    gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Fee", InstituteCode, "IL");
                    gvFeeList.DataBind();

                    Int64 TotalFeeAmount = 0;
                    for (Int32 i = 0; i < gvFeeList.Rows.Count; i++)
                    {
                        gvFeeList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        TotalFeeAmount += Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text);
                        gvFeeList.Rows[i].Cells[2].Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", Convert.ToInt64(gvFeeList.Rows[i].Cells[2].Text)) + "/-";
                    }
                    lblTotalFeeAmount.Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:0,0}", TotalFeeAmount) + "/-" + "<br />" + "(Rs. " + UserInfo.ConvertNumbertoWords(TotalFeeAmount) + " Only)";

                    txtAdmissionDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

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
                    Int32 Result = reg.saveInstituteFeeDetails(obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), "IL");
                    if (Result == 1)
                    {
                        shInfo.SetMessage("Demand Draft / Cheque Number - <b>" + txtDDNumber.Text + "</b> is Already added for this Candidate.", ShowMessageType.Information);
                    }
                    else if (Result == 2)
                    {
                        gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Fee", ViewState["InstituteCode"].ToString(), "IL");
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
                        gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Fee", ViewState["InstituteCode"].ToString(), "IL");
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
                    gvFeeList.DataSource = reg.getInstituteFeeList(PID, "Fee", ViewState["InstituteCode"].ToString(), "IL");
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
        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlInstitute.SelectedIndex != 0)
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                    string InstituteCode = ddlInstitute.SelectedValue;

                    ddlCourse.DataSource = reg.getChoiceCodeListByInstituteForAdmissionAtIL(PID, InstituteCode);
                    ddlCourse.DataTextField = "CourseName";
                    ddlCourse.DataValueField = "ChoiceCode";
                    ddlCourse.DataBind();
                    ddlCourse.Items.Insert(0, new ListItem("-- Select Course --", "0"));

                    ddlSeatType.DataSource = reg.getSeatTypeListForAdmissionAtIL(InstituteCode);
                    ddlSeatType.DataTextField = "SeatTypeDetails";
                    ddlSeatType.DataValueField = "SeatTypeCode";
                    ddlSeatType.DataBind();
                    ddlSeatType.Items.Insert(0, new ListItem("-- Select Seat Type --", "0"));

                    //if (new dbUtility().FinalDataSubmitted(Session["UserLoginID"].ToString()))
                    //{
                    //    ddlSeatType.Items.Remove(ddlSeatType.Items.FindByText("Against CAP (Excluding Minority)"));
                    //    ddlSeatType.Items.Remove(ddlSeatType.Items.FindByText("Against CAP (Minority) (Minority Candidate)"));
                    //    ddlSeatType.Items.Remove(ddlSeatType.Items.FindByText("Against CAP (Minority) (Non-Minority Candidate)"));
                    //}

                    Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                    if (CandidatureTypeID == 15)
                    {
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("ACAP"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("MI"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("AMIN"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("IL"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("ILNRI"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("NRI"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("PIO"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("FNS"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("CIWGC"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("JKSSS"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("OAA"));
                    }
                    else if (CandidatureTypeID == 16)
                    {
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("ACAP"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("MI"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("AMIN"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("IL"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("ILNRI"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("NRI"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("PIO"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("FNS"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("CIWGC"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("NEUT"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("OAA"));
                    }
                    else
                    {
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("JKSSS"));
                        ddlSeatType.Items.Remove(ddlSeatType.Items.FindByValue("NEUT"));
                    }
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
                //if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["CutOffDate"]) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
                if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["UploadingDate"]) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
                {
                    shInfo.Visible = true;
                    shInfo.SetMessage("Admission of Candidate at Institute Level is Closed.", ShowMessageType.Information);
                }
                else
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    if (ddlSeatType.SelectedValue == "PIO" || ddlSeatType.SelectedValue == "FNS")
                    {
                        ConfirmSeat(PID);
                    }
                    else
                    {
                        if (Global.IsOTPVerificationRequiredForAdmissionConfirmatIL == 1)
                        {
                            tblOtp.Visible = true;
                            trotpbtn.Visible = true;

                            SMSTemplate sMSTemplate = new SMSTemplate();
                            sMSTemplate.PID = PID;
                            SynCommon synCommon = new SynCommon();
                            if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.InstituteILOTP))
                            {
                                btnCall.Visible = true;
                                this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                                txtOneTimePassword.Focus();
                                btnProceed.Visible = false;
                            }
                        }
                        else
                        {
                            ConfirmSeat(PID);
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


        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                //if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["CutOffDate"]) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
                if (DateTime.Now > Convert.ToDateTime(ConfigurationManager.AppSettings["UploadingDate"]) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
                {
                    shInfo.Visible = true;
                    shInfo.SetMessage("Admission of Candidate at Institute Level is Closed.", ShowMessageType.Information);
                }
                else
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                    string ApplicationID = Global.ApplicationFormPrefix + PID.ToString();
                    if (reg.verifyOTP(ApplicationID, txtOneTimePassword.Text, 13))
                    {
                        ConfirmSeat(PID);
                    }
                    else
                    {
                        shInfo.SetMessage("OTP is Invalid.", ShowMessageType.Information);
                        this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemout();</script>"));
                    }
                }
            }

            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnCall_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            string mobno = DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(PID));
            SMS objSMS = new SMS();
            objSMS.voiceCallOTP(mobno);
            this.Controls.Add(new LiteralControl("<script type='text/javascript'>showRetryTiemouts();</script>"));
        }

        private bool verifyOTPForCapI(long PID, string OTP)
        {
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_verifyOTPForCapI", new SqlParameter[]
            {
            new SqlParameter("@PersonalID",PID),new SqlParameter("@OTPForCapI", OTP)

            });
            db.Dispose();
            if (ds.Tables[0].Rows[0]["msg"].ToString() == "susccess")
                return true;
            else
                return false;
        }
        private bool saveOTPForCapI(long PID, string OTP)
        {
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_saveOTPForCapI", new SqlParameter[]
            {
            new SqlParameter("@PersonalID", PID),
            new SqlParameter("@OTPForCapI", OTP)
            });


            db.Dispose();
            if (ds.Tables[0].Rows[0]["result"].ToString() == "1")
                return true;
            else
                return false;
        }
        private DataSet getPreviousOTPForCapI(long PID)
        {
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_getOTPForCapI", new SqlParameter[]
            {
            new SqlParameter("@PersonalID", PID)
            });


            db.Dispose();
            return ds;
        }


        private void ConfirmSeat(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 ChoiceCode = Convert.ToInt64(ddlCourse.SelectedValue);
                string ChoiceCodeDisplay = ddlCourse.SelectedItem.Text;
                string SeatType = ddlSeatType.SelectedValue;
                Int32 MeritNo = Convert.ToInt32(txtMeritNo.Text);
                DateTime AdmissionDate = Convert.ToDateTime(txtAdmissionDate.Text.Split("/".ToCharArray())[1] + "/" + txtAdmissionDate.Text.Split("/".ToCharArray())[0] + "/" + txtAdmissionDate.Text.Split("/".ToCharArray())[2]);
                string InstituteRemark = txtRemark.Text;
                string InstituteCode = "";
                if (Convert.ToInt32(Session["UserTypeID"]) == 43)
                {
                    InstituteCode = Session["UserLoginID"].ToString();
                }
                else
                {
                    InstituteCode = ddlInstitute.SelectedValue;
                }

                if (AdmissionDate > DateTime.Now.Date)
                {
                    shInfo.SetMessage("Admission Date should not be greater than Current Date.", ShowMessageType.Information);
                }
                else if (AdmissionDate >= Convert.ToDateTime(ConfigurationManager.AppSettings["CutOffDate"]))
                {
                    shInfo.SetMessage("Admission Date should not be greater than Cutoff Date.", ShowMessageType.Information);
                }
                else if (AdmissionDate >= Convert.ToDateTime(ConfigurationManager.AppSettings["UploadingDate"]).AddDays(0))
                {
                     shInfo.SetMessage("Admission Date should not be greater than Cutoff Date.", ShowMessageType.Information);
                }
                //else if (AdmissionDate < Convert.ToDateTime("06/26/2019"))
                //{
                //    shInfo.SetMessage("Admission Date should be greater than 26 June 2019.", ShowMessageType.Information);
                //}
                else
                {
                    Int32 ApplicationFeeToBePaid = 0, FeesPaid = 0;
                    ApplicationFeeToBePaid = 1000;
                    txtDDAmount.Text = "1000";
                    FeesPaid = reg.getSeatAcceptanceFeePaidAmount(PID);
                    //|| SeatType == "NRI" || SeatType == "PIO" || SeatType == "FNS" || SeatType == "CIWGC" || lblCandidatureType.Text == "FN-ICCR"
                    if (SeatType == "JKSSS" || SeatType == "NEUT" )
                    {
                        if (reg.confirmAdmissionAtIL(PID, ChoiceCode, SeatType, MeritNo, AdmissionDate, InstituteRemark,
                            Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = PID;
                            sMSTemplate.ChoiceCodeDisplay = ChoiceCodeDisplay;//ChoiceCode.ToString();
                            sMSTemplate.SeatTypeAdmitted = SeatType;
                            sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                            sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                            if (Global.SendSMSToCandidate == 1)
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ConfirmAdmissionAtIL);
                            Response.Redirect("../InstituteModule/frmAdmissionLetterAtIL.aspx?PID=" + PID.ToString() + "&ChoiceCode=" + ChoiceCode.ToString() + "&Code=" + PID.ToString().GetHashCode().ToString());
                        }
                        else
                        {
                            shInfo.SetMessage("There is No Vacancies under this Seat Type in this Course OR Admission is Closed.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        if (FeesPaid >= ApplicationFeeToBePaid)
                        {
                            if (reg.confirmAdmissionAtIL(PID, ChoiceCode, SeatType, MeritNo, AdmissionDate, InstituteRemark,
                                Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                            {
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = PID;
                                sMSTemplate.ChoiceCodeDisplay = ChoiceCodeDisplay; //ChoiceCode.ToString();
                                sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                                sMSTemplate.SeatTypeAdmitted = SeatType;
                                sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                                if (Global.SendSMSToCandidate == 1)
                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.ConfirmAdmissionAtIL);
                                Response.Redirect("../InstituteModule/frmAdmissionLetterAtIL.aspx?PID=" + PID.ToString() + "&ChoiceCode=" + ChoiceCode.ToString() + "&Code=" + PID.ToString().GetHashCode().ToString());
                            }
                            else
                            {
                                shInfo.SetMessage("There is No Vacancies under this Seat Type in this Course OR Admission is Closed.", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("Seat Acceptance Fee is Not Paid Please Pay the Seat Acceptance Fee of Candidate Using the Link Pay SeatAcceptance Fee.", ShowMessageType.Information);

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

        private class dbUtility
        {
            public bool FinalDataSubmitted(string InstituteCode)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@InstituteID", SqlDbType.VarChar),
                    new SqlParameter("@Flag", SqlDbType.VarChar)
                };

                param[0].Value = InstituteCode;
                param[1].Value = "3";
                DBConnection db = new DBConnection();
                try
                {
                    Int32 result = 0;
                    result = Convert.ToInt32(db.ExecuteScaler("DTEMH_spupdateInstitueFinalDataUpdatedAllotedCandidateACAP", param));
                    if (result == 1)
                        return true;
                    else
                        return false;
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}