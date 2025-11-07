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
    public partial class frmSpecialReservationDetails : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string NextYear = Global.NextYear;
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
            try
            {
                if (!IsPostBack)
                {

                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    DataSet dsCurrentLink = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmSpecialReservationDetails");

                    if (reg.CheckFCVerificationStatus(objSessionData.PID))
                    {
                        shInfo.SetMessage("Application Form is Confirmed or Has been picked for SC E-Verification", ShowMessageType.Information);
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }


                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if ((objSessionData.ApplicationFormStatus == 'A' || objSessionData.StepID < 3) && (FCVerificationStatus == 'C' || FCVerificationStatus == 'P'))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }
                    if (reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "Y")
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }
                    Int16 AnnualFamilyIncomeID = reg.getAnnualFamilyIncomeID(objSessionData.PID);
                    lblAnnualFamilyIncome.Text = reg.getAnnualFamilyIncomeDetails(objSessionData.PID);

                    ddlPHType.DataSource = Global.MasterPHType;
                    ddlPHType.DataTextField = "PHTypeDetails";
                    ddlPHType.DataValueField = "PHTypeID";
                    ddlPHType.DataBind();

                    ddlDefenceType.DataSource = Global.MasterDefenceType;
                    ddlDefenceType.DataTextField = "DefenceTypeDetails";
                    ddlDefenceType.DataValueField = "DefenceTypeID";
                    ddlDefenceType.DataBind();

                    ddlLinguisticMinority.DataSource = Global.MasterLinguisticMinority;
                    ddlLinguisticMinority.DataTextField = "MinorityName";
                    ddlLinguisticMinority.DataValueField = "MinorityID";
                    ddlLinguisticMinority.DataBind();
                    ddlLinguisticMinority.Items.Insert(0, new ListItem("-- Select --", "0"));

                    ddlReligiousMinority.DataSource = Global.MasterReligiousMinority;
                    ddlReligiousMinority.DataTextField = "MinorityName";
                    ddlReligiousMinority.DataValueField = "MinorityID";
                    ddlReligiousMinority.DataBind();
                    ddlReligiousMinority.Items.Insert(0, new ListItem("-- Select --", "0"));

                    if (objSessionData.CandidatureTypeID >= 5)
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }

                    if (objSessionData.StepID >= 4)
                    {
                        SpecialReservationDetails obj = reg.getSpecialReservationDetails(objSessionData.PID);

                        ddlPHType.SelectedValue = obj.PHTypeID.ToString();
                        ddlDefenceType.SelectedValue = obj.DefenceTypeID.ToString();
                        ddlIsOrphan.SelectedValue = obj.IsOrphan;
                        txtOrphanRegistrationNo.Text = obj.OrphanRegistrationNo;
                        ddlOrphanHasRelative.SelectedValue = obj.OrphanHasRelative;
                        ddlAppliedForTFWS.SelectedValue = obj.AppliedForTFWS;
                        if (objSessionData.CandidatureTypeID <= 2)
                        {
                            ddlAppliedForMinoritySeats.SelectedValue = obj.AppliedForMinoritySeats;
                            if (obj.LinguisticMinorityID > 0)
                            {
                                chkLinguisticMinority.Checked = true;
                                lblMotherTongue.Text = reg.getMotherTongue(objSessionData.PID);
                                ddlLinguisticMinority.SelectedValue = obj.LinguisticMinorityID.ToString();
                            }
                            if (obj.ReligiousMinorityID > 0)
                            {
                                chkReligiousMinority.Checked = true;
                                lblReligion.Text = reg.getReligion(objSessionData.PID);
                                ddlReligiousMinority.SelectedValue = obj.ReligiousMinorityID.ToString();
                            }
                        }
                    }

                    if (AnnualFamilyIncomeID > 15)
                    {
                        ddlAppliedForTFWS.SelectedValue = "No";
                        ddlAppliedForTFWS.Enabled = false;
                        lblAppliedForTFWS.Visible = true;
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
        protected void ddlPHType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int16 PHTypeID = Convert.ToInt16(ddlPHType.SelectedValue);

                if (PHTypeID > 0)
                {
                    trInstruction1.Visible = true;
                    lblPHType.Text = "Minimum 40% benchmark disability required.";
                }
                else
                {
                    trInstruction1.Visible = false;
                    lblPHType.Text = "";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlDefenceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int16 DefenceTypeID = Convert.ToInt16(ddlDefenceType.SelectedValue);

                if (DefenceTypeID == 0)
                {
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = false;
                    h1DefenceProformaC.Visible = false;
                    h1DefenceProformaDorE.Visible = false;                    
                }
                else if (DefenceTypeID == 1)
                {
                    trInstruction3.Visible = true;
                    trInstruction4.Visible = true;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = false;
                    h1DefenceProformaC.Visible = true;
                    h1DefenceProformaDorE.Visible = false;
                    
                }
                else if (DefenceTypeID == 2)
                {
                    trInstruction3.Visible = true;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = true;
                    trInstruction6.Visible = false;
                    h1DefenceProformaC.Visible = true;
                    h1DefenceProformaDorE.Visible = false;
                    
                }
                else if (DefenceTypeID == 3)
                {
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = true;
                    h1DefenceProformaC.Visible = true;
                    h1DefenceProformaDorE.Visible = true;
                    
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlIsOrphan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string IsOrphan = ddlIsOrphan.SelectedValue;

                if (IsOrphan == "Yes")
                {
                    trOrphan1.Visible = false;
                    trOrphan2.Visible = false;
                    trInstruction2.Visible = true;
                    h1OrphanProformaU.Visible = true;
                }
                else
                {
                    trOrphan1.Visible = false;
                    trOrphan2.Visible = false;
                    trInstruction2.Visible = false;
                    h1OrphanProformaU.Visible = false;
                }

                txtOrphanRegistrationNo.Text = "";
                ddlOrphanHasRelative.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        
        protected void ddlAppliedForMinoritySeats_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string AppliedForMinoritySeats = ddlAppliedForMinoritySeats.SelectedValue;

                if (AppliedForMinoritySeats == "Yes")
                {
                    trMinorityStatus.Visible = true;
                    trInstruction8.Visible = true;
                    hlMinorityProformaOGR.Visible = true;
                    hlMinorityProformaInstruction.Visible = true;
                }
                else
                {
                    trMinorityStatus.Visible = false;
                    trInstruction8.Visible = false;
                    hlMinorityProformaOGR.Visible = false;
                    hlMinorityProformaInstruction.Visible = false;
                }

                trMotherTongue.Visible = false;
                trLinguisticMinority.Visible = false;
                lblLinguisticMinority.Visible = false;

                trReligion.Visible = false;
                trReligiousMinority.Visible = false;
                lblReligiousMinority.Visible = false;

                ddlLinguisticMinority.Enabled = true;
                ddlReligiousMinority.Enabled = true;

                chkLinguisticMinority.Checked = false;
                chkReligiousMinority.Checked = false;

                ddlLinguisticMinority.SelectedValue = "0";
                ddlReligiousMinority.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void LinguisticMinorityStatus_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                Int64 PID = ((SessionData)Session["SessionData"]).PID;

                if (chkLinguisticMinority.Checked)
                {
                    lblMotherTongue.Text = reg.getMotherTongue(PID);

                    trMotherTongue.Visible = true;
                    trLinguisticMinority.Visible = true;

                    if (lblMotherTongue.Text == "Marathi")
                    {
                        lblLinguisticMinority.Visible = true;
                        ddlLinguisticMinority.Enabled = false;
                    }
                    else
                    {
                        lblLinguisticMinority.Visible = false;
                        ddlLinguisticMinority.Enabled = true;
                    }
                }
                else
                {
                    trMotherTongue.Visible = false;
                    trLinguisticMinority.Visible = false;
                    lblLinguisticMinority.Visible = false;
                    ddlLinguisticMinority.Enabled = true;
                }

                ddlLinguisticMinority.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ReligiousMinorityStatus_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                Int64 PID = ((SessionData)Session["SessionData"]).PID;

                if (chkReligiousMinority.Checked)
                {
                    lblReligion.Text = reg.getReligion(PID);

                    trReligion.Visible = true;
                    trReligiousMinority.Visible = true;

                    if (lblReligion.Text == "Hindu")
                    {
                        lblReligiousMinority.Visible = true;
                        ddlReligiousMinority.Enabled = false;
                    }
                    else
                    {
                        lblReligiousMinority.Visible = false;
                        ddlReligiousMinority.Enabled = true;
                    }
                }
                else
                {
                    trReligion.Visible = false;
                    trReligiousMinority.Visible = false;
                    lblReligiousMinority.Visible = false;
                    ddlReligiousMinority.Enabled = true;
                }

                ddlReligiousMinority.SelectedValue = "0";
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
                Int16 PHTypeID = Convert.ToInt16(ddlPHType.SelectedValue);
                if (PHTypeID > 0)
                {
                    trInstruction1.Visible = true;
                    lblPHType.Text = "Minimum 40% benchmark disability rquired.";
                }
                else
                {
                    trInstruction1.Visible = false;
                    lblPHType.Text = "";
                }

                Int16 DefenceTypeID = Convert.ToInt16(ddlDefenceType.SelectedValue);
                if (DefenceTypeID == 0)
                {
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = false;
                }
                else if (DefenceTypeID == 1)
                {
                    trInstruction3.Visible = true;
                    trInstruction4.Visible = true;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = false;
                }
                else if (DefenceTypeID == 2)
                {
                    trInstruction3.Visible = true;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = true;
                    trInstruction6.Visible = false;
                }
                else if (DefenceTypeID == 3)
                {
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = true;
                }

                string IsOrphan = ddlIsOrphan.SelectedValue;
                if (IsOrphan == "Yes")
                {
                    trOrphan1.Visible = false;
                    trOrphan2.Visible = false;
                    trInstruction2.Visible = true;
                }
                else
                {
                    trOrphan1.Visible = false;
                    trOrphan2.Visible = false;
                    trInstruction2.Visible = false;
                }
                string AppliedForTFWS = ddlAppliedForTFWS.SelectedValue;
                if (AppliedForTFWS == "Yes")
                {
                    trInstruction7.Visible = true;
                }
                else
                {
                    trInstruction7.Visible = false;
                }



                if (((SessionData)Session["SessionData"]).CandidatureTypeID > 2)
                {
                    trMinorityHeader.Visible = false;
                    trMinority.Visible = false;
                    trMinorityStatus.Visible = false;
                    trMotherTongue.Visible = false;
                    trLinguisticMinority.Visible = false;
                    trReligion.Visible = false;
                    trReligiousMinority.Visible = false;
                    trInstruction8.Visible = false;
                }
                else
                {
                    string AppliedForMinoritySeats = ddlAppliedForMinoritySeats.SelectedValue;
                    if (AppliedForMinoritySeats == "Yes")
                    {
                        trMinorityStatus.Visible = true;
                        trInstruction8.Visible = true;

                        if (chkLinguisticMinority.Checked)
                        {
                            trMotherTongue.Visible = true;
                            trLinguisticMinority.Visible = true;

                            if (lblMotherTongue.Text == "Marathi")
                            {
                                lblLinguisticMinority.Visible = true;
                                ddlLinguisticMinority.Enabled = false;
                            }
                            else
                            {
                                lblLinguisticMinority.Visible = false;
                                ddlLinguisticMinority.Enabled = true;
                            }
                        }
                        else
                        {
                            trMotherTongue.Visible = false;
                            trLinguisticMinority.Visible = false;
                            lblLinguisticMinority.Visible = false;
                            ddlLinguisticMinority.Enabled = true;
                        }

                        if (chkReligiousMinority.Checked)
                        {
                            trReligion.Visible = true;
                            trReligiousMinority.Visible = true;
                            if (lblReligion.Text == "Hindu")
                            {
                                lblReligiousMinority.Visible = true;
                                ddlReligiousMinority.Enabled = false;
                            }
                            else
                            {
                                lblReligiousMinority.Visible = false;
                                ddlReligiousMinority.Enabled = true;
                            }
                        }
                        else
                        {
                            trReligion.Visible = false;
                            trReligiousMinority.Visible = false;
                            lblReligiousMinority.Visible = false;
                            ddlReligiousMinority.Enabled = true;
                        }
                    }
                    else
                    {
                        trMinorityStatus.Visible = false;
                        trInstruction8.Visible = false;

                        trMotherTongue.Visible = false;
                        trLinguisticMinority.Visible = false;
                        lblLinguisticMinority.Visible = false;
                        ddlLinguisticMinority.Enabled = true;

                        trReligion.Visible = false;
                        trReligiousMinority.Visible = false;
                        lblReligiousMinority.Visible = false;
                        ddlReligiousMinority.Enabled = true;
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

                SessionData objSessionData = (SessionData)Session["SessionData"];
                SpecialReservationDetails obj = new SpecialReservationDetails();

                obj.PID = objSessionData.PID;
                obj.PHTypeID = Convert.ToInt16(ddlPHType.SelectedValue);
                obj.DefenceTypeID = Convert.ToInt16(ddlDefenceType.SelectedValue);
                obj.IsOrphan = ddlIsOrphan.SelectedValue;
                obj.OrphanRegistrationNo = txtOrphanRegistrationNo.Text;
                obj.OrphanHasRelative = ddlOrphanHasRelative.SelectedValue;
                obj.AppliedForTFWS = ddlAppliedForTFWS.SelectedValue;
                obj.AppliedForMinoritySeats = ddlAppliedForMinoritySeats.SelectedValue;
                obj.LinguisticMinorityID = Convert.ToInt16(ddlLinguisticMinority.SelectedValue);
                obj.ReligiousMinorityID = Convert.ToInt16(ddlReligiousMinority.SelectedValue);
                Int16 AnnualFamilyIncomeID = reg.getAnnualFamilyIncomeID(objSessionData.PID);
                Int16 CategoryID = reg.getCategoryID(objSessionData.PID);
                string MotherTongue = reg.getMotherTongue(objSessionData.PID);
                string Religion = reg.getReligion(objSessionData.PID);

                //if (obj.IsOrphan == "Yes" && obj.OrphanHasRelative != "Yes" && CategoryID > 1)
                //{
                //    shInfo.SetMessage("You are Orphan and has No Relatives. So Your Category should be Open.", ShowMessageType.Information);
                //}
                //else 
                if (obj.AppliedForTFWS == "Yes" && AnnualFamilyIncomeID > 15)
                {
                    shInfo.SetMessage("You have Applied for TFWS. So Your Annual Family Income should below 8 Lacs.", ShowMessageType.Information);
                }
                else if (MotherTongue == "Marathi" && obj.LinguisticMinorityID > 0)
                {
                    shInfo.SetMessage("Your Mother Tongue is Marathi. So You are Not Eligible for Linguistic Minority.", ShowMessageType.Information);
                }
                else if (Religion == "Hindu" && obj.ReligiousMinorityID > 0)
                {
                    shInfo.SetMessage("Your Religion is Hindu. So You are Not Eligible for Religious Minority.", ShowMessageType.Information);
                }
                else
                {
                    string ModifiedBy = Session["UserLoginID"].ToString();
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();

                    if (reg.saveSpecialReservationDetails(obj, ModifiedBy, ModifiedByIPAddress))
                    {
                        if (objSessionData.StepID < 4)
                        {
                            ((SessionData)Session["SessionData"]).StepID = 4;
                        }

                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.",
                            ShowMessageType.UserError);
                    }
                }
            
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlAppliedForTFWS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string AppliedForTFWS = ddlAppliedForTFWS.SelectedValue;

                if (AppliedForTFWS == "Yes")
                {
                    trInstruction7.Visible = true;
                }
                else
                {
                    trInstruction7.Visible = false;
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