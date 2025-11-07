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

namespace Pharmacy2024.AFCModule
{
    public partial class frmEditRegistrationDetails : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) == 91 || Convert.ToInt32(Session["UserTypeID"].ToString()) == 43)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if ((DateTime.Now < Global.EdittingOfApplicationFormStartDateTime || DateTime.Now > Global.EdittingOfApplicationFormEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }

                    DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplay(PID);

                    if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                    {
                        lblApplicationID.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["ApplicationID"].ToString();
                        lblCandidateName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CandidateName"].ToString();
                    }

                    Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);

                    txtCandidateName.Attributes.Add("onBlur", "makeUpper()");
                    txtFatherName.Attributes.Add("onBlur", "makeUpper()");
                    txtMotherName.Attributes.Add("onBlur", "makeUpper()");

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

                    RegistrationDetails obj = reg.getRegistrationDetails(PID);

                    txtCandidateName.Text = obj.CandidateName.ToString();
                    txtFatherName.Text = obj.FatherName.ToString();
                    txtMotherName.Text = obj.MotherName.ToString();
                    ddlGender.SelectedValue = obj.GenderCode.ToString();
                    txtDOB.Text = obj.DOB.ToString("dd/MM/yyyy");
                    ddlReligion.SelectedValue = obj.ReligionID.ToString();
                    ddlRegion.SelectedValue = obj.RegionCode.ToString();
                    ddlMotherTongue.SelectedValue = obj.MotherTongueID.ToString();
                    ddlAnnualFamilyIncome.SelectedValue = obj.AnnualFamilyIncomeID.ToString();
                    ddlNationality.SelectedValue = obj.NationalityID.ToString();

                    if ((UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        string Flag = reg.isCandidateEligibleForEdittingAtARC(PID);

                        if (Flag.Length > 0)
                        {
                            Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                        }

                        txtCandidateName.Enabled = false;
                        txtFatherName.Enabled = false;
                        txtMotherName.Enabled = false;
                        txtDOB.Enabled = false;
                        ddlReligion.Enabled = false;
                        ddlRegion.Enabled = false;
                        ddlMotherTongue.Enabled = false;
                        ddlAnnualFamilyIncome.Enabled = false;
                        ddlNationality.Enabled = false;
                    }
                    else if ((UserTypeID == 23 || UserTypeID == 24) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                RegistrationDetails obj = new RegistrationDetails();

                obj.PID = PID;
                obj.CandidateName = txtCandidateName.Text;
                obj.FatherName = txtFatherName.Text;
                obj.MotherName = txtMotherName.Text;
                obj.GenderCode = Convert.ToChar(ddlGender.SelectedValue);
                obj.DOB = Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]);
                obj.ReligionID = Convert.ToInt16(ddlReligion.SelectedValue);
                obj.RegionCode = Convert.ToChar(ddlRegion.SelectedValue);
                obj.MotherTongueID = Convert.ToInt16(ddlMotherTongue.SelectedValue);
                obj.AnnualFamilyIncomeID = Convert.ToInt16(ddlAnnualFamilyIncome.SelectedValue);
                obj.NationalityID = Convert.ToInt32(ddlNationality.SelectedValue);
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                StringMatching stringMatching = new StringMatching();
                NEETDetails objNEETDetail = new NEETDetails();
                objNEETDetail = reg.getNEETDetails(PID);

                int matchingPercentage = 0;
                if (objNEETDetail.AppearedForNEET == "Yes")
                {
                    matchingPercentage = stringMatching.CheckString(txtCandidateName.Text, objNEETDetail.NameAsPerNEET);
                }
                else
                {
                    matchingPercentage = 50; //
                }

                if (CandidatureTypeID == 5 && ddlMotherTongue.SelectedItem.Text != "Marathi")
                {
                    shInfo.SetMessage("Your Type of Candidature is " + Global.MasterCandidatureType.Tables[0].Select("CandidatureTypeID = " + CandidatureTypeID.ToString()).CopyToDataTable().Rows[0]["CandidatureTypeName"].ToString() + ". So Your Mother Tongue should be Marathi.", ShowMessageType.Information);
                }
                else if (ddlNationality.SelectedItem.Text != "Indian" && (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4 || CandidatureTypeID == 5 || CandidatureTypeID == 7 || CandidatureTypeID == 8 || CandidatureTypeID == 9 || CandidatureTypeID == 10 || CandidatureTypeID == 15 || CandidatureTypeID == 16))
                {
                    shInfo.SetMessage("Your Type of Candidature is " + Global.MasterCandidatureType.Tables[0].Select("CandidatureTypeID = " + CandidatureTypeID.ToString()).CopyToDataTable().Rows[0]["CandidatureTypeName"].ToString() + ". So Your Nationality should be Indian.", ShowMessageType.Information);
                }
                else if (ddlNationality.SelectedItem.Text == "Indian" && (CandidatureTypeID == 11 || CandidatureTypeID == 13 || CandidatureTypeID == 17))
                {
                    shInfo.SetMessage("Your Type of Candidature is " + Global.MasterCandidatureType.Tables[0].Select("CandidatureTypeID = " + CandidatureTypeID.ToString()).CopyToDataTable().Rows[0]["CandidatureTypeName"].ToString() + ". So Your Nationality should not be Indian.", ShowMessageType.Information);
                }
                else if (reg.getAppliedForTFWSFlag(PID) == "Yes" && obj.AnnualFamilyIncomeID > 15)
                {
                    shInfo.SetMessage("You have Applied for TFWS. So Your Annual Family Income should below 8 Lacs.", ShowMessageType.Information);
                }
                else if (reg.getAppliedForEWSFlag(PID) == "Yes" && obj.AnnualFamilyIncomeID > 15)
                {
                    shInfo.SetMessage("You have Applied for EWS. So Your Annual Family Income should below 8 Lacs.", ShowMessageType.Information);
                }
                else if (obj.MotherTongueID == 8 && reg.getLinguisticMinorityID(PID) > 0)
                {
                    shInfo.SetMessage("You have Applied for Linguistic Minority. So Your Mother Tongue should not be Marathi.", ShowMessageType.Information);
                }
                else if (obj.ReligionID == 1 && reg.getReligiousMinorityID(PID) > 0)
                {
                    shInfo.SetMessage("You have Applied for Religious Minority. So Your Religion should not be Hindu.", ShowMessageType.Information);
                }
                else if (objNEETDetail.AppearedForNEET == "Yes" && matchingPercentage == 0 && Global.CheckNEETResult)
                {
                   shInfo.SetMessage("Your name as per CAP Registration and name as per NEET Result Data is not matching. You are not allowed to continue.", ShowMessageType.Information);
                }
                else if (Global.CheckDuplicateEmailID == 1 && reg.isApplicationFormConfirmedUsingThisEMailID(obj.EMailID, PID))
                {
                    shInfo.SetMessage("Application Form using E-Mail ID- " + obj.EMailID + " is already registered. Please register using other E-Mail ID.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.editRegistrationDetails(obj, ModifiedBy, ModifiedByIPAddress))
                    {
                        Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
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