using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MSCaptcha;
using System.Linq;
using Pharmacy2024;

namespace Pharmacy2024.RegistrationModule
{
    public partial class frmRegistrationDetails : System.Web.UI.Page
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
            if (Session["SecretKey"] == null && ConfigurationManager.AppSettings["IsTestKeyRequired"] == "Y")
            {
                ClientScript.RegisterStartupScript(GetType(), "id", "showSecretKey()", true);
            }
            else
            {
                if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                }

                ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                if (!IsPostBack)
                {
                    try
                    {
                        
                        string Code = Request.QueryString["Code"].ToString();
                        Int64 CETApplicationFormNo = Convert.ToInt64(Request.QueryString["CETApplicationFormNo"].ToString());
                        string FCRApplicationID = (Request.QueryString["FCRApplicationID"].ToString());
                        string FCRCandidateName = (Request.QueryString["FCRCandidateName"].ToString());
                        string FCRCandidatureTypeName = (Request.QueryString["FCRCandidatureTypeName"].ToString());
                        string FCRMotherName = (Request.QueryString["FCRMotherName"].ToString());
                        string FCRGender = (Request.QueryString["FCRGender"].ToString());
                        DateTime FCRDOB = Convert.ToDateTime(Request.QueryString["FCRDOB"].ToString());

                        if (FCRApplicationID.Length > 0 && FCRApplicationID.ToString().GetHashCode().ToString() != Code)
                        {
                            Response.Write(
                                "<BR /><BR /><center><H1>You are not authorised to see this page.</H1></center>");
                            Response.End();
                        }
                        else if (CETApplicationFormNo.ToString().GetHashCode().ToString() != Code && CETApplicationFormNo > 0)
                        {
                            Response.Write(
                                "<BR /><BR /><center><H1>You are not authorised to see this page.</H1></center>");
                            Response.End();
                        }

                        txtCandidateName.Attributes.Add("onBlur", "makeUpper()");
                        txtFatherName.Attributes.Add("onBlur", "makeUpper()");
                        txtMotherName.Attributes.Add("onBlur", "makeUpper()");
                        txtDOB.Attributes.Add("readonly", "readonly");
                        txtDOBC.Attributes.Add("readonly", "readonly");
                        //ddlSecurityQuestion.Attributes.Add("onChange", "blankSecurityAnswer()");

                        ddlGender.DataSource = Global.MasterGender;
                        ddlGender.DataTextField = "GenderName";
                        ddlGender.DataValueField = "GenderCode";
                        ddlGender.DataBind();
                        ddlGender.Items.Insert(0, new ListItem("-- Select Gender --", "0"));

                        ddlGenderre.DataSource = Global.MasterGender;
                        ddlGenderre.DataTextField = "GenderName";
                        ddlGenderre.DataValueField = "GenderCode";
                        ddlGenderre.DataBind();
                        ddlGenderre.Items.Insert(0, new ListItem("-- Select Gender --", "0"));

                        ddlReligion.DataSource = Global.MasterReligion;
                        ddlReligion.DataTextField = "ReligionName";
                        ddlReligion.DataValueField = "ReligionID";
                        ddlReligion.DataBind();
                        ddlReligion.Items.Insert(0, new ListItem("-- Select Religion --", "0"));

                        ddlRegion.DataSource = Global.MasterRegionType;
                        ddlRegion.DataTextField = "RegionName";
                        ddlRegion.DataValueField = "RegionCode";
                        ddlRegion.DataBind();
                        ddlRegion.Items.Insert(0, new ListItem("-- Select Region --", "0"));

                        ddlMotherTongue.DataSource = Global.MasterMotherTongue;
                        ddlMotherTongue.DataTextField = "MotherTongueName";
                        ddlMotherTongue.DataValueField = "MotherTongueID";
                        ddlMotherTongue.DataBind();
                        ddlMotherTongue.Items.Insert(0, new ListItem("-- Select Mother Tongue --", "0"));

                        ddlAnnualFamilyIncome.DataSource = Global.MasterAnnualFamilyIncome;
                        ddlAnnualFamilyIncome.DataTextField = "AnnualFamilyIncomeDetails";
                        ddlAnnualFamilyIncome.DataValueField = "AnnualFamilyIncomeID";
                        ddlAnnualFamilyIncome.DataBind();
                        ddlAnnualFamilyIncome.Items.Insert(0, new ListItem("-- Select Annual Family Income --", "0"));

                        ddlNationality.DataSource = Global.MasterNationality;
                        ddlNationality.DataTextField = "CountryName";
                        ddlNationality.DataValueField = "CountryID";
                        ddlNationality.DataBind();
                        ddlNationality.Items.Insert(0, new ListItem("-- Select Nationality --", "0"));
                        ddlNationality.SelectedValue = "96";

                        ddlCState.DataSource = Global.MasterState;
                        ddlCState.DataTextField = "StateName";
                        ddlCState.DataValueField = "StateID";
                        ddlCState.DataBind();
                        ddlCState.Items.Insert(0, new ListItem("-- Select State --", "0"));

                        ddlCDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
                        ddlCTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                        ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));

                        //ddlSecurityQuestion.DataSource = ASP.global_asax.MasterSecurityQuestion;
                        //ddlSecurityQuestion.DataTextField = "SecurityQuestionDetails";
                        //ddlSecurityQuestion.DataValueField = "SecurityQuestionID";
                        //ddlSecurityQuestion.DataBind();
                        //ddlSecurityQuestion.Items.Insert(0, new ListItem("-- Select Security Question --", "0"));

                        //if (CETApplicationFormNo > 0)
                        //{
                        //    DataSet ds = reg.getCETDetails(CETApplicationFormNo);

                        //    if (ds.Tables[0].Rows.Count > 0)
                        //    {
                        //        txtCandidateName.Text = ds.Tables[0].Rows[0]["CandidateName"].ToString();
                        //        txtCandidateName.Enabled = false;
                        //        txtDOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString())
                        //            .ToString("dd/MM/yyyy");
                        //    }
                        //}


                        onPageLoad();
                    }
                    catch (Exception ex)
                    {
                        //Logging.LogException(ex, "[Page Level Error]");
                        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                    }
                }
            }
        }
        protected void ddlCState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                if (ddlCState.SelectedIndex != 0)
                {
                    Int32 StateID = Convert.ToInt32(ddlCState.SelectedValue);
                    if (Global.AllDistrict.Count > 0)
                        ddlCDistrict.DataSource = Global.AllDistrict.Where(x => x.StateID == StateID).ToList();   //reg.getMasterDistrictForState(StateID);
                    else
                        ddlCDistrict.DataSource = reg.getMasterDistrictForState(StateID);

                    ddlCDistrict.DataTextField = "DistrictName";
                    ddlCDistrict.DataValueField = "DistrictID";
                    ddlCDistrict.DataBind();
                    ddlCDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));

                    ddlCTaluka.Items.Clear();
                    ddlCTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                    ddlCVillage.Items.Clear();
                    ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));
                }
                else
                {
                    ddlCDistrict.Items.Clear();
                    ddlCDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
                    ddlCTaluka.Items.Clear();
                    ddlCTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                    ddlCVillage.Items.Clear();
                    ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));
                }

                if (ddlCState.SelectedValue == "21")
                {
                    ddlCTaluka.Enabled = true;
                    ddlCVillage.Enabled = true;
                }
                else
                {
                    ddlCTaluka.Enabled = false;
                    ddlCVillage.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlCDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                if (ddlCDistrict.SelectedIndex != 0)
                {
                    Int32 DistrictID = Convert.ToInt32(ddlCDistrict.SelectedValue);
                    if (Global.AllTaluka.Count > 0)
                        ddlCTaluka.DataSource = Global.AllTaluka.Where(x => x.DistrictID == DistrictID).ToList();
                    else
                        ddlCTaluka.DataSource = reg.getMasterTalukaForDistrict(DistrictID);

                    ddlCTaluka.DataTextField = "TalukaName";
                    ddlCTaluka.DataValueField = "TalukaID";
                    ddlCTaluka.DataBind();
                    ddlCTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));

                    ddlCVillage.Items.Clear();
                    ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));

                    //if (ddlCState.SelectedValue != "21" && ddlCState.SelectedValue != "17")
                    //{
                    //    ddlCTaluka.SelectedIndex = 1;
                    //    if (Global.AllVillage.Count > 0)
                    //        ddlCVillage.DataSource = Global.AllVillage.Where(x => x.TalukaID == Convert.ToInt32(ddlCTaluka.SelectedValue)).ToList(); //reg.getMasterVillageForTaluka(TalukaID);
                    //    else
                    //        ddlCVillage.DataSource = reg.getMasterVillageForTaluka(Convert.ToInt32(ddlCTaluka.SelectedValue));

                    //    ddlCVillage.DataTextField = "VillageName";
                    //    ddlCVillage.DataValueField = "VillageID";
                    //    ddlCVillage.DataBind();
                    //    ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));

                    //    ddlCVillage.SelectedIndex = 1;
                    //}

                    //ADDED FOR MKB District, TALUKA, Villages
                    if (ddlCDistrict.SelectedValue == "1227" || ddlCDistrict.SelectedValue == "1229" || ddlCDistrict.SelectedValue == "1238" || ddlCDistrict.SelectedValue == "1250")
                    {
                        ddlCTaluka.Enabled = true;
                        ddlCVillage.Enabled = true;

                        //ddlCTaluka.Items.Remove("Not Applicable");
                        //ddlCVillage.Items.Remove("Not Applicable");
                    }
                    else if (ddlCState.SelectedValue != "21")
                    {
                        ddlCTaluka.Enabled = false;
                        ddlCVillage.Enabled = false;

                        ddlCTaluka.SelectedIndex = 1;

                        ddlCVillage.DataSource = Global.AllVillage.Where(x => x.TalukaID == Convert.ToInt32(ddlCTaluka.SelectedValue));// reg.getMasterVillageForTaluka(Convert.ToInt32(ddlCTaluka.SelectedValue));
                        ddlCVillage.DataTextField = "VillageName";
                        ddlCVillage.DataValueField = "VillageID";
                        ddlCVillage.DataBind();
                        ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));

                        ddlCVillage.SelectedIndex = 1;
                    }
                    else if (ddlCState.SelectedValue == "17" && (ddlCDistrict.SelectedValue != "1227" || ddlCDistrict.SelectedValue != "1229" || ddlCDistrict.SelectedValue != "1238" || ddlCDistrict.SelectedValue != "1250"))
                    {
                        ddlCTaluka.Enabled = false;
                        ddlCVillage.Enabled = false;

                        ddlCTaluka.SelectedIndex = 1;

                        ddlCVillage.DataSource = Global.AllVillage.Where(x => x.TalukaID == Convert.ToInt32(ddlCTaluka.SelectedValue));// reg.getMasterVillageForTaluka(Convert.ToInt32(ddlCTaluka.SelectedValue));
                        ddlCVillage.DataTextField = "VillageName";
                        ddlCVillage.DataValueField = "VillageID";
                        ddlCVillage.DataBind();
                        ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));

                        ddlCVillage.SelectedIndex = 1;
                    }
                }
                else
                {
                    ddlCTaluka.Items.Clear();
                    ddlCTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                    ddlCVillage.Items.Clear();
                    ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));
                }
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlCTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                if (ddlCTaluka.SelectedIndex != 0)
                {
                    Int32 TalukaID = Convert.ToInt32(ddlCTaluka.SelectedValue);
                    if (Global.AllVillage.Count > 0)
                        ddlCVillage.DataSource = Global.AllVillage.Where(x => x.TalukaID == TalukaID).ToList(); //reg.getMasterVillageForTaluka(TalukaID);
                    else
                        ddlCVillage.DataSource = reg.getMasterVillageForTaluka(TalukaID);
                    ddlCVillage.DataTextField = "VillageName";
                    ddlCVillage.DataValueField = "VillageID";
                    ddlCVillage.DataBind();
                    ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));
                }
                else
                {
                    ddlCVillage.Items.Clear();
                    ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));
                }
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void onPageLoad()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                upSecurityPin.Visible = Convert.ToBoolean(Global.IsCaptchaRequired);
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                Captcha1.ValidateCaptcha(txtSecurityPin.Text.Trim());

                if (Captcha1.UserValidated)
                {
                    RegistrationDetails obj = new RegistrationDetails();

                    obj.CandidateName = txtCandidateName.Text.TrimStart().TrimEnd();
                    obj.FatherName = txtFatherName.Text.TrimStart().TrimEnd(); 
                    obj.MotherName = txtMotherName.Text.TrimStart().TrimEnd(); 
                    obj.GenderCode = Convert.ToChar(ddlGender.SelectedValue);
                    if (txtDOB.Text.Contains("-"))
                    {
                        txtDOB.Text = txtDOB.Text.Replace('-', '/');
                    }
                    obj.DOB = Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]);
                    obj.ReligionID = Convert.ToInt16(ddlReligion.SelectedValue);
                    obj.RegionCode = Convert.ToChar(ddlRegion.SelectedValue);
                    obj.MotherTongueID = Convert.ToInt16(ddlMotherTongue.SelectedValue);
                    obj.AnnualFamilyIncomeID = Convert.ToInt16(ddlAnnualFamilyIncome.SelectedValue);
                    obj.AadhaarNumber = "";// DataEncryption.EncryptDataByEncryptionKey(txtAadhaarNumber.Text);
                    obj.NationalityID = Convert.ToInt32(ddlNationality.SelectedValue);
                    obj.CAddressLine1 = txtCAdressLine1.Text;
                    obj.CAddressLine2 = txtCAdressLine2.Text;
                    obj.CAddressLine3 = txtCAdressLine3.Text;
                    obj.CAddress = txtCAdressLine1.Text + "<br />" + txtCAdressLine2.Text + "<br />" + txtCAdressLine3.Text;
                    obj.CStateID = Convert.ToInt32(ddlCState.SelectedValue);
                    obj.CDistrictID = Convert.ToInt32(ddlCDistrict.SelectedValue);
                    obj.CTalukaID = Convert.ToInt32(ddlCTaluka.SelectedValue);
                    obj.CVillageID = Convert.ToInt32(ddlCVillage.SelectedValue);
                    obj.CPincode = txtCPincode.Text;
                    obj.STDCode = txtSTDCode.Text;
                    obj.PhoneNo = txtPhoneNo.Text;
                    obj.MobileNo = DataEncryption.EncryptDataByEncryptionKey(txtMobileNo.Text);
                    obj.EMailID = txtEMailID.Text;
                    obj.HasBankAccount = "No";
                    obj.AccountNumber = "";
                    obj.IFSCCode = "";
                    string CandidatePassword = DataEncryption.EncryptDataByHashSHA1(txtPassword.Text);
                    Int16 SecurityQuestionID = 0; // Convert.ToInt16(ddlSecurityQuestion.SelectedValue);
                    string SecurityAnswer = ""; // txtSecurityAnswer.Text;

                    Int64 CETApplicationFormNo = Convert.ToInt64(Request.QueryString["CETApplicationFormNo"].ToString());
                    string FCRApplicationID = (Request.QueryString["FCRApplicationID"].ToString());
                    string FCRCandidateName = (Request.QueryString["FCRCandidateName"].ToString());
                    string FCRCandidatureTypeName = (Request.QueryString["FCRCandidatureTypeName"].ToString());
                    string FCRMotherName = (Request.QueryString["FCRMotherName"].ToString());
                    string FCRGender = (Request.QueryString["FCRGender"].ToString());
                    DateTime FCRDOB = Convert.ToDateTime(Request.QueryString["FCRDOB"].ToString());

                    string OTP = Global.IsOTPVerificationRequired == 1 ? UserInfo.GenerateOTP() : "";
                    string IsActive = Global.IsOTPVerificationRequired == 1 ? "N" : "Y";
                    string ModifiedBy = "";
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();


                    string AppID = reg.isApplicationFormRegisteredUsingThisMobileNo(obj.MobileNo, 0);

                    if (Global.CheckDuplicateMobileNo == 1 && AppID.Length > 0)
                    {
                        shInfo.SetMessage("Application Form with Application ID - " + AppID + " is already Registered using mobile number " + txtMobileNo.Text + ". Please use other mobile number for Registration.", ShowMessageType.Information);
                    }
                    if (Global.CheckDuplicateMobileNo == 1 && reg.isApplicationFormConfirmedUsingThisMobileNo(obj.MobileNo))
                    {
                        shInfo.SetMessage("Application Form using mobile number " + txtMobileNo.Text + " is already confirmed. Please register using other mobile number.", ShowMessageType.Information);
                    }
                    else if (Global.CheckDuplicateEmailID == 1 && reg.isApplicationFormConfirmedUsingThisEMailID(obj.EMailID, 0))
                    {
                        shInfo.SetMessage("Application Form using E-Mail ID- " + txtEMailID.Text + " is already registered. Please register using other E-Mail ID.", ShowMessageType.Information);
                    }
                    else
                    {
                        string ApplicationID = reg.saveRegistrationDetails(obj, CandidatePassword, SecurityQuestionID, SecurityAnswer, CETApplicationFormNo, OTP, IsActive, ModifiedBy, ModifiedByIPAddress, FCRApplicationID, FCRCandidateName, FCRCandidatureTypeName, FCRMotherName, FCRGender, FCRDOB);
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        SynCommon synCommon = new SynCommon();
                        sMSTemplate.PID = reg.getPersonalID(ApplicationID);
                        System.Web.HttpBrowserCapabilities browser = Request.Browser;
                        if (browser.IsMobileDevice)
                        {
                            reg.UpdateCandidateBrowserOS(sMSTemplate.PID, (synCommon.GetUserEnvironment(Request) + "/" + "Y"));
                        }
                        else
                        {
                            reg.UpdateCandidateBrowserOS(sMSTemplate.PID, (synCommon.GetUserEnvironment(Request) + "/" + "N"));
                        }
                        if (ApplicationID.Length == (int)SynCommon.SynSetting.ApplicationIDLength)
                        {
                            if (Global.IsOTPVerificationRequired == 1)
                            {

                                if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OtpRegistration))
                                    //OLD CODe
                                    //DataSet ds = reg.GetSMSEmailContent(reg.getPersonalID(ApplicationID), "Registration OTP", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                                    //if (ds.Tables[1] != null)
                                    //{
                                    //    if (ds.Tables[1].Rows.Count > 0)
                                    //    {
                                    //        objSMS.sendOTPSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[1].Rows[0]["MobileNo"].ToString()), ds.Tables[1].Rows[0]["SMSContent"].ToString(), ds.Tables[1].Rows[0]["OTP"].ToString());
                                    //        if (Global.IsEmailSend == 1)
                                    //        {
                                    //            //objSMS.SendEmail(ds.Tables[1].Rows[0]["EmailID"].ToString(),ds.Tables[1].Rows[0]["EmailBody"].ToString(),ds.Tables[1].Rows[0]["EmailSubject"].ToString(), true);
                                    //        }
                                    //    }
                                    //}
                                    Response.Redirect("~/RegistrationModule/frmVerifyOTP?ApplicationID=" + ApplicationID + "&Code=" + ApplicationID.GetHashCode() + "&MobileNo=" + Server.UrlEncode(obj.MobileNo), true);
                            }
                            else
                            {
                                if (Global.SendSMSToCandidate == 1)
                                {

                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.Registration);
                                    //SMS objSMS = new SMS();
                                    //DataSet ds = reg.GetSMSEmailContent(reg.getPersonalID(ApplicationID), "Registration", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                                    //if (ds.Tables[1] != null)
                                    //{
                                    //    if (ds.Tables[1].Rows.Count > 0)
                                    //    {
                                    //        objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[1].Rows[0]["MobileNo"].ToString()), ds.Tables[1].Rows[0]["SMSContent"].ToString());
                                    //        if (Global.IsEmailSend == 1)
                                    //        {
                                    //            //objSMS.SendEmail(ds.Tables[1].Rows[0]["EmailID"].ToString(), ds.Tables[1].Rows[0]["EmailBody"].ToString(), ds.Tables[1].Rows[0]["EmailSubject"].ToString(), true);
                                    //        }
                                    //    }
                                    //}
                                    //Int64 PID = reg.getPersonalID(ApplicationID);
                                    //DataSet ds = reg.getSMSContent(PID, "Registration");
                                    //objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[0].Rows[0]["MobileNo"].ToString()), ConfigurationManager.AppSettings["Project_Name"].ToString() + " : " + ds.Tables[0].Rows[0]["SMSContent"].ToString());
                                }
                                Response.Redirect("~/RegistrationModule/frmInstructionsAfterRegistration?ApplicationID=" + ApplicationID + "&Code=" + ApplicationID.GetHashCode(), true);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                        }
                    }
                }
                else
                {
                    shInfo.SetMessage("Invalid Captcha. Please try again.", ShowMessageType.Information);
                }
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
                Int64 CETApplicationFormNo = Convert.ToInt64(Request.QueryString["CETApplicationFormNo"].ToString());
                string Code = Request.QueryString["Code"].ToString();

                string FCRApplicationID = (Request.QueryString["FCRApplicationID"].ToString());
                string FCRCandidateName = (Request.QueryString["FCRCandidateName"].ToString());
                string FCRCandidatureTypeName = (Request.QueryString["FCRCandidatureTypeName"].ToString());
                string FCRMotherName = (Request.QueryString["FCRMotherName"].ToString());
                string FCRGender = (Request.QueryString["FCRGender"].ToString());
                DateTime FCRDOB = Convert.ToDateTime(Request.QueryString["FCRDOB"].ToString());

                //Response.Redirect("frmRegistrationDetails?CETApplicationFormNo=" + CETApplicationFormNo.ToString() + "&Code=" + Code);
                Response.Redirect("~/RegistrationModule/frmRegistrationDetails?CETApplicationFormNo=" + CETApplicationFormNo + "&Code=" + CETApplicationFormNo.ToString().GetHashCode() + "&FCRApplicationID=" + FCRApplicationID + "&FCRCandidateName=" + FCRCandidateName + "&FCRCandidatureTypeName=" + FCRCandidatureTypeName + "&FCRMotherName=" + FCRMotherName + "&FCRGender=" + FCRGender + "&FCRDOB=" + FCRDOB, true);
            }
            else
            {
                lblmsg.Text = "Enter the Correct SecretKey For Filling Form!!";
                lblmsg.Visible = true;
                //Response.Redirect(ConfigurationManager.AppSettings["ApplicationURL"]);
            }
        }
    }
}