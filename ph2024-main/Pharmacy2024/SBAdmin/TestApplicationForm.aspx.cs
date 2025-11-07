using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Linq;
namespace Pharmacy2024.SBAdmin
{
    public partial class TestApplicationForm : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Remove if not need secretkey and in script remove function. and content box contentSecretKey
            //if (Session["SecretKey"] == null)
            //{
            //    ClientScript.RegisterStartupScript(GetType(), "id", "showSecretKey()", true);
            //}
            //else
            {
                //if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime)
                //{
                //    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                //}
                ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                if (!IsPostBack)
                {
                    try
                    {


                        txtCandidateName.Attributes.Add("onBlur", "makeUpper()");
                        txtFatherName.Attributes.Add("onBlur", "makeUpper()");
                        txtMotherName.Attributes.Add("onBlur", "makeUpper()");
                        //ddlSecurityQuestion.Attributes.Add("onChange", "blankSecurityAnswer()");

                        ddlGender.DataSource = Global.MasterGender;
                        ddlGender.DataTextField = "GenderName";
                        ddlGender.DataValueField = "GenderCode";
                        ddlGender.DataBind();
                        ddlGender.Items.Insert(0, new ListItem("-- Select Gender --", "0"));

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

                        //ddlSecurityQuestion.DataSource = Global.MasterSecurityQuestion;
                        //ddlSecurityQuestion.DataTextField = "SecurityQuestionDetails";
                        //ddlSecurityQuestion.DataValueField = "SecurityQuestionID";
                        //ddlSecurityQuestion.DataBind();
                        //ddlSecurityQuestion.Items.Insert(0, new ListItem("-- Select Security Question --", "0"));

                        onPageLoad();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "[Page Level Error]");
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

                    ddlCDistrict.DataSource = Global.AllDistrict.Where(x => x.StateID == StateID); //reg.getMasterDistrictForState(StateID);
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
                Logging.LogException(ex, "[Page Level Error]");
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

                    ddlCTaluka.DataSource = Global.AllTaluka.Where(x => x.DistrictID == DistrictID);//reg.getMasterTalukaForDistrict(DistrictID);
                    ddlCTaluka.DataTextField = "TalukaName";
                    ddlCTaluka.DataValueField = "TalukaID";
                    ddlCTaluka.DataBind();
                    ddlCTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));

                    ddlCVillage.Items.Clear();
                    ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));

                    if (ddlCState.SelectedValue != "21")
                    {
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
                Logging.LogException(ex, "[Page Level Error]");
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

                    ddlCVillage.DataSource = Global.AllVillage.Where(x => x.TalukaID == TalukaID); //reg.getMasterVillageForTaluka(TalukaID);
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
                Logging.LogException(ex, "[Page Level Error]");
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
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                if (Global.IsCaptchaRequired == 1)
                    Captcha1.ValidateCaptcha(txtSecurityPin.Text.Trim());



                if (Captcha1.UserValidated)
                {
                    RegistrationDetails obj = new RegistrationDetails();

                    obj.CandidateName = txtCandidateName.Text;
                    obj.FatherName = txtFatherName.Text;
                    obj.MotherName = txtMotherName.Text;
                    obj.GenderCode = Convert.ToChar(ddlGender.SelectedValue);
                    obj.DOB = Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]);
                    obj.ReligionID = Convert.ToInt16(ddlReligion.SelectedValue);
                    obj.RegionCode = Convert.ToChar(ddlRegion.SelectedValue);
                    obj.MotherTongueID = Convert.ToInt16(ddlMotherTongue.SelectedValue);
                    obj.AnnualFamilyIncomeID = Convert.ToInt16(ddlAnnualFamilyIncome.SelectedValue);
                    obj.AadhaarNumber = DataEncryption.EncryptDataByEncryptionKey(txtAadhaarNumber.Text);
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
                    Int16 SecurityQuestionID = 0;// Convert.ToInt16(ddlSecurityQuestion.SelectedValue);
                    string SecurityAnswer = "0";// txtSecurityAnswer.Text;
                    SynCommon synCommon1 = new SynCommon();
                    Int32 tempOTP = synCommon1.GenerateOTPSixDigit();
                    string OTP = Global.IsOTPVerificationRequired == 1 ? tempOTP.ToString() : "";
                    string IsActive = Global.IsOTPVerificationRequired == 1 ? "N" : "Y";
                    string ModifiedBy = "";
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();

                    if (Global.CheckDuplicateMobileNo == 1 && reg.isApplicationFormConfirmedUsingThisMobileNo(obj.MobileNo))
                    {
                        shInfo.SetMessage("Application Form using mobile number " + txtMobileNo.Text + " is already confirmed. Please register using other mobile number.", ShowMessageType.Information);
                    }
                    else
                    {
                        //string ApplicationID = reg.saveRegistrationDetails(obj, CandidatePassword, SecurityQuestionID, SecurityAnswer, OTP, IsActive, ModifiedBy, ModifiedByIPAddress);
                        //if (ApplicationID.Length == (int)SynCommon.SynSetting.ApplicationIDLength)
                        //{

                        //    SMSTemplate sMSTemplate = new SMSTemplate();
                        //    SynCommon synCommon = new SynCommon();
                        //    sMSTemplate.PID = reg.getPersonalID(ApplicationID);
                        //    System.Web.HttpBrowserCapabilities browser = Request.Browser;
                        //    if (browser.IsMobileDevice)
                        //    {
                        //        reg.UpdateCandidateBrowserOS(sMSTemplate.PID, (synCommon.GetUserEnvironment(Request) + "/" + "Y"));
                        //    }
                        //    else
                        //    {
                        //        reg.UpdateCandidateBrowserOS(sMSTemplate.PID, (synCommon.GetUserEnvironment(Request) + "/" + "N"));
                        //    }

                        //    if (Global.IsOTPVerificationRequired == 1)
                        //    {
                        //        //SMS objSMS = new SMS();
                        //        //string Message = ConfigurationManager.AppSettings["Project_Name"].ToString() + " : Dear " + obj.CandidateName + ", Your One Time Password (OTP) for Verification of Your Mobile Number is " + OTP;
                        //        //objSMS.sendOTPSMS(txtMobileNo.Text, Message, OTP);
                        //        ////objSMS.SendEmail(txtEMailID.Text, "Dear " + obj.CandidateName + ",<br/><br/> Your One Time Password (OTP) for Verification of Your Mobile Number is " + OTP, ConfigurationManager.AppSettings["Project_Name"].ToString() + " : OTP Verification", true);
                        //        if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.OtpRegistration))
                        //            Response.Redirect("~/RegistrationModule/frmVerifyOTP.aspx?ApplicationID=" + ApplicationID + "&Code=" + ApplicationID.GetHashCode() + "&MobileNo=" + Server.UrlEncode(obj.MobileNo), true);
                        //    }
                        //    else
                        //    {
                        //        if (Global.SendSMSToCandidate == 1)
                        //        {
                        //            //Int64 PID = reg.getPersonalID(ApplicationID);
                        //            //DataSet ds = reg.getSMSContent(PID, "Registration");
                        //            //SMS objSMS = new SMS();
                        //            //objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[0].Rows[0]["MobileNo"].ToString()), ConfigurationManager.AppSettings["Project_Name"].ToString() + " : " + ds.Tables[0].Rows[0]["SMSContent"].ToString());

                        //            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.Registration);
                        //        }

                        //        Response.Redirect("~/RegistrationModule/frmInstructionsAfterRegistration.aspx?ApplicationID=" + ApplicationID + "&Code=" + ApplicationID.GetHashCode(), true);
                        //    }
                        //}
                        //else
                        //{
                        //    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                        //}
                    }
                }
                else
                {
                    shInfo.SetMessage("Invalid Security Pin. Please try again.", ShowMessageType.Information);
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
                Response.Redirect("frmRegistrationDetails.aspx");
            }
            else
            {
                lblmsg.Text = "Enter the Correct SecretKey For Filling Form!!";
                lblmsg.Visible = true;
            }
        }
    }
}