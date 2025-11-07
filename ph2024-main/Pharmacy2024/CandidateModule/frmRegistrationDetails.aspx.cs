using BusinessLayer;
using EntityModel;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
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
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime || Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            string _leftMenu = ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"];
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormLinks = true;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormNumber = false;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFadingEffect = true; ((ExpanderMenu)Master.FindControl(_leftMenu)).FormType = 1;
            ((ExpanderMenu)Master.FindControl(_leftMenu)).FormNumber = Convert.ToInt64(Session["UserID"]);
            if (!IsPostBack)
            {
                try
                {

                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsCurrentLink = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmRegistrationDetails");
                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                    if (reg.CheckFCVerificationStatus(objSessionData.PID))
                    {
                        shInfo.SetMessage("Application Form is Confirmed or Has been picked for SC E-Verification", ShowMessageType.Information);
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if ((objSessionData.ApplicationFormStatus == 'A' || objSessionData.StepID < 0) && (FCVerificationStatus == 'C' || FCVerificationStatus == 'P'))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }
                    if (reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "Y")
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }

                    txtCandidateName.Attributes.Add("onBlur", "makeUpper()");
                    txtFatherName.Attributes.Add("onBlur", "makeUpper()");
                    txtMotherName.Attributes.Add("onBlur", "makeUpper()");
                    txtDOB.Attributes.Add("readonly", "readonly");
                    txtDOBC.Attributes.Add("readonly", "readonly");

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

                    ddlCState.DataSource = Global.MasterState;
                    ddlCState.DataTextField = "StateName";
                    ddlCState.DataValueField = "StateID";
                    ddlCState.DataBind();
                    ddlCState.Items.Insert(0, new ListItem("-- Select State --", "0"));

                    ddlCDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
                    ddlCTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                    ddlCVillage.Items.Insert(0, new ListItem("-- Select Village --", "0"));

                    RegistrationDetails obj = reg.getRegistrationDetails(objSessionData.PID);

                    txtCandidateName.Text = obj.CandidateName.ToString();
                    txtFatherName.Text = obj.FatherName.ToString();
                    txtMotherName.Text = obj.MotherName.ToString();
                    ddlGender.SelectedValue = obj.GenderCode.ToString();
                    ddlGenderre.SelectedValue = obj.GenderCode.ToString();
                    txtDOB.Text = obj.DOB.ToString("dd/MM/yyyy");
                    txtDOBC.Text = obj.DOB.ToString("dd/MM/yyyy");
                    ddlReligion.SelectedValue = obj.ReligionID.ToString();
                    ddlRegion.SelectedValue = obj.RegionCode.ToString();
                    ddlMotherTongue.SelectedValue = obj.MotherTongueID.ToString();
                    ddlAnnualFamilyIncome.SelectedValue = obj.AnnualFamilyIncomeID.ToString();
                    //txtAadhaarNumber.Text = DataEncryption.DecryptDataByEncryptionKey(obj.AadhaarNumber);
                    ddlNationality.SelectedValue = obj.NationalityID.ToString();
                    txtCAdressLine1.Text = obj.CAddressLine1;
                    txtCAdressLine2.Text = obj.CAddressLine2;
                    txtCAdressLine3.Text = obj.CAddressLine3;
                    ddlCState.SelectedValue = obj.CStateID.ToString();
                    ddlCDistrict.DataSource = reg.getMasterDistrictForState(obj.CStateID);
                    ddlCDistrict.DataTextField = "DistrictName";
                    ddlCDistrict.DataValueField = "DistrictID";
                    ddlCDistrict.DataBind();
                    ddlCDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
                    ddlCDistrict.SelectedValue = obj.CDistrictID.ToString();
                    ddlCTaluka.DataSource = reg.getMasterTalukaForDistrict(obj.CDistrictID);
                    ddlCTaluka.DataTextField = "TalukaName";
                    ddlCTaluka.DataValueField = "TalukaID";
                    ddlCTaluka.DataBind();
                    ddlCTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                    ddlCTaluka.SelectedValue = obj.CTalukaID.ToString();
                    ddlCVillage.DataSource = reg.getMasterVillageForTaluka(obj.CTalukaID);
                    ddlCVillage.DataTextField = "VillageName";
                    ddlCVillage.DataValueField = "VillageID";
                    ddlCVillage.DataBind();
                    ddlCVillage.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                    ddlCVillage.SelectedValue = obj.CVillageID.ToString();
                    txtCPincode.Text = obj.CPincode;
                    txtSTDCode.Text = obj.STDCode;
                    txtPhoneNo.Text = obj.PhoneNo;
                    txtMobileNo.Text = DataEncryption.DecryptDataByEncryptionKey(obj.MobileNo);
                    txtEMailID.Text = obj.EMailID;

                    //if (objSessionData.CETApplicationFormNo > 0)
                    //{
                    //    txtCandidateName.Enabled = false;
                    //}

                    if (obj.CStateID != 21 && ddlCState.SelectedValue != "17")
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
                        ddlCTaluka.SelectedIndex = 1;

                        if (Global.AllVillage.Count > 0)
                            ddlCVillage.DataSource = Global.AllVillage.Where(x => x.TalukaID == Convert.ToInt32(ddlCTaluka.SelectedValue)).ToList(); //reg.getMasterVillageForTaluka(TalukaID);
                        else
                            ddlCVillage.DataSource = reg.getMasterVillageForTaluka(Convert.ToInt32(ddlCTaluka.SelectedValue));
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
                RegistrationDetails obj = new RegistrationDetails();

                obj.PID = objSessionData.PID;
                obj.CandidateName = txtCandidateName.Text.TrimStart().TrimEnd();
                obj.FatherName = txtFatherName.Text.TrimStart().TrimEnd();
                obj.MotherName = txtMotherName.Text.TrimStart().TrimEnd();
                obj.GenderCode = Convert.ToChar(ddlGender.SelectedValue);
                obj.DOB = Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]);
                obj.ReligionID = Convert.ToInt16(ddlReligion.SelectedValue);
                obj.RegionCode = Convert.ToChar(ddlRegion.SelectedValue);
                obj.MotherTongueID = Convert.ToInt16(ddlMotherTongue.SelectedValue);
                obj.AnnualFamilyIncomeID = Convert.ToInt16(ddlAnnualFamilyIncome.SelectedValue);
                obj.AadhaarNumber = ""; // DataEncryption.EncryptDataByEncryptionKey(txtAadhaarNumber.Text);
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
                obj.EMailID = txtEMailID.Text;
                obj.HasBankAccount = "No";
                obj.AccountNumber = "";
                obj.IFSCCode = "";
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                StringMatching stringMatching = new StringMatching();
                NEETDetails objNEETDetail = new NEETDetails();
                objNEETDetail = reg.getNEETDetails(objSessionData.PID);

                int matchingPercentage = 0;
                if (objNEETDetail.AppearedForNEET == "Yes")
                {
                    matchingPercentage = stringMatching.CheckString(txtCandidateName.Text, objNEETDetail.NameAsPerNEET);
                }
                else
                {
                    matchingPercentage = 50; //
                }

                if (objSessionData.CandidatureTypeID == 5 && ddlMotherTongue.SelectedItem.Text != "Marathi")
                {
                    shInfo.SetMessage("Your Type of Candidature is " + Global.MasterCandidatureType.Tables[0].Select("CandidatureTypeID = " + objSessionData.CandidatureTypeID.ToString()).CopyToDataTable().Rows[0]["CandidatureTypeName"].ToString() + ". So Your Mother Tongue should be Marathi.", ShowMessageType.Information);
                }
                else if (ddlNationality.SelectedItem.Text != "Indian" && (objSessionData.CandidatureTypeID == 1 || objSessionData.CandidatureTypeID == 2 || objSessionData.CandidatureTypeID == 3 || objSessionData.CandidatureTypeID == 4 || objSessionData.CandidatureTypeID == 5 || objSessionData.CandidatureTypeID == 7 || objSessionData.CandidatureTypeID == 8 || objSessionData.CandidatureTypeID == 9 || objSessionData.CandidatureTypeID == 10 || objSessionData.CandidatureTypeID == 15 || objSessionData.CandidatureTypeID == 16))
                {
                    shInfo.SetMessage("Your Type of Candidature is " + Global.MasterCandidatureType.Tables[0].Select("CandidatureTypeID = " + objSessionData.CandidatureTypeID.ToString()).CopyToDataTable().Rows[0]["CandidatureTypeName"].ToString() + ". So Your Nationality should be Indian.", ShowMessageType.Information);
                }
                else if (ddlNationality.SelectedItem.Text == "Indian" && (objSessionData.CandidatureTypeID == 11 || objSessionData.CandidatureTypeID == 17))
                {
                    shInfo.SetMessage("Your Type of Candidature is " + Global.MasterCandidatureType.Tables[0].Select("CandidatureTypeID = " + objSessionData.CandidatureTypeID.ToString()).CopyToDataTable().Rows[0]["CandidatureTypeName"].ToString() + ". So Your Nationality should not be Indian.", ShowMessageType.Information);
                }
                else if (reg.getAppliedForTFWSFlag(objSessionData.PID) == "Yes" && obj.AnnualFamilyIncomeID > 15)
                {
                    shInfo.SetMessage("You have Applied for TFWS. So Your Annual Family Income should below 8 Lacs.", ShowMessageType.Information);
                }
                else if (reg.getAppliedForEWSFlag(objSessionData.PID) == "Yes" && obj.AnnualFamilyIncomeID > 15)
                {
                    shInfo.SetMessage("You have Applied for EWS. So Your Annual Family Income should below 8 Lacs.", ShowMessageType.Information);
                }
                else if (obj.MotherTongueID == 8 && reg.getLinguisticMinorityID(objSessionData.PID) > 0)
                {
                    shInfo.SetMessage("You have Applied for Linguistic Minority. So Your Mother Tongue should not be Marathi.", ShowMessageType.Information);
                }
                else if (obj.ReligionID == 1 && reg.getReligiousMinorityID(objSessionData.PID) > 0)
                {
                    shInfo.SetMessage("You have Applied for Religious Minority. So Your Religion should not be Hindu.", ShowMessageType.Information);
                }
                else if (objNEETDetail.AppearedForNEET == "Yes" && matchingPercentage == 0 && Global.CheckNEETResult)
                {
                    shInfo.SetMessage("Your name as per CAP Registration and name as per NEET Result Data is not matching. You are not allowed to continue.", ShowMessageType.Information);
                }
                else if (Global.CheckDuplicateEmailID == 1 && reg.isApplicationFormConfirmedUsingThisEMailID(obj.EMailID, obj.PID))
                {
                    shInfo.SetMessage("Application Form using E-Mail ID- " + txtEMailID.Text + " is already registered. Please register using other E-Mail ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.updateRegistrationDetails(obj, ModifiedBy, ModifiedByIPAddress))
                    {
                        if (objSessionData.StepID < 1)
                        {
                            ((SessionData)Session["SessionData"]).StepID = 1;
                        }

                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
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