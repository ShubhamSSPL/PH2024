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
    public partial class frmEditSpecialReservationDetails : System.Web.UI.Page
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) == 91 || Convert.ToInt32(Session["UserTypeID"].ToString()) == 43)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if ((DateTime.Now < Global.EdittingOfApplicationFormStartDateTime || DateTime.Now > Global.EdittingOfApplicationFormEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (!IsPostBack)
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
                    Int16 AnnualFamilyIncomeID = reg.getAnnualFamilyIncomeID(PID);
                    Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                    lblAnnualFamilyIncome.Text = reg.getAnnualFamilyIncomeDetails(PID);
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

                    if (CandidatureTypeID >= 5)
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }

                    SpecialReservationDetails obj = reg.getSpecialReservationDetails(PID);

                    ddlPHType.SelectedValue = obj.PHTypeID.ToString();
                    ddlDefenceType.SelectedValue = obj.DefenceTypeID.ToString();
                    ddlIsOrphan.SelectedValue = obj.IsOrphan;
                    ddlAppliedForTFWS.SelectedValue = obj.AppliedForTFWS;
                    if (CandidatureTypeID <= 2)
                    {
                        ddlAppliedForMinoritySeats.SelectedValue = obj.AppliedForMinoritySeats;
                        if (obj.LinguisticMinorityID > 0)
                        {
                            chkLinguisticMinority.Checked = true;
                            lblMotherTongue.Text = reg.getMotherTongue(PID);
                            ddlLinguisticMinority.SelectedValue = obj.LinguisticMinorityID.ToString();
                        }
                        if (obj.ReligiousMinorityID > 0)
                        {
                            chkReligiousMinority.Checked = true;
                            lblReligion.Text = reg.getReligion(PID);
                            ddlReligiousMinority.SelectedValue = obj.ReligiousMinorityID.ToString();
                        }
                    }
                    if (AnnualFamilyIncomeID > 15)
                    {
                        ddlAppliedForTFWS.SelectedValue = "No";
                        ddlAppliedForTFWS.Enabled = false;
                        lblAppliedForTFWS.Visible = true;
                    }

                    onPageLoad();

                    if ((UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        string Flag = reg.isCandidateEligibleForEdittingAtARC(PID);

                        if (Flag.Length > 0)
                        {
                            Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                        }

                        if (obj.PHTypeID == 0)
                        {
                            ddlPHType.Enabled = false;
                        }
                        if (obj.DefenceTypeID == 0)
                        {
                            ddlDefenceType.Enabled = false;
                        }
                        if (ddlAppliedForTFWS.SelectedValue != "Yes")
                        {
                            ddlAppliedForTFWS.Enabled = false;
                        }
                        if (ddlIsOrphan.SelectedValue != "Yes")
                        {
                            ddlIsOrphan.Enabled = false;
                        }
                        if (ddlAppliedForMinoritySeats.SelectedValue != "Yes")
                        {
                            ddlAppliedForMinoritySeats.Enabled = false;
                        }
                        else
                        {
                            chkLinguisticMinority.Enabled = false;
                            chkReligiousMinority.Enabled = false;
                            ddlLinguisticMinority.Enabled = false;
                            ddlReligiousMinority.Enabled = false;
                        }
                    }
                    else if ((UserTypeID == 23 || UserTypeID == 24) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                    }
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
                    trInstruction2.Visible = true;
                }
                else
                {
                    trInstruction2.Visible = false;
                }
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
                }
                else
                {
                    trMinorityStatus.Visible = false;
                    trInstruction8.Visible = false;
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

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
        protected void onPageLoad()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);

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
                    trInstruction2.Visible = true;
                }
                else
                {
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

                if (CandidatureTypeID > 2)
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                SpecialReservationDetails obj = new SpecialReservationDetails();

                obj.PID = PID;
                obj.PHTypeID = Convert.ToInt16(ddlPHType.SelectedValue);
                obj.DefenceTypeID = Convert.ToInt16(ddlDefenceType.SelectedValue);
                obj.IsOrphan = ddlIsOrphan.SelectedValue;
                obj.AppliedForTFWS = ddlAppliedForTFWS.SelectedValue;
                obj.AppliedForMinoritySeats = ddlAppliedForMinoritySeats.SelectedValue;
                obj.LinguisticMinorityID = Convert.ToInt16(ddlLinguisticMinority.SelectedValue);
                obj.ReligiousMinorityID = Convert.ToInt16(ddlReligiousMinority.SelectedValue);
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                Int16 AnnualFamilyIncomeID = reg.getAnnualFamilyIncomeID(PID);
                string MotherTongue = reg.getMotherTongue(PID);
                string Religion = reg.getReligion(PID);

                if (MotherTongue == "Marathi" && obj.LinguisticMinorityID > 0)
                {
                    shInfo.SetMessage("Your Mother Tongue is Marathi. So You are Not Eligible for Linguistic Minority.", ShowMessageType.Information);
                }
                else if (Religion == "Hindu" && obj.ReligiousMinorityID > 0)
                {
                    shInfo.SetMessage("Your Religion is Hindu. So You are Not Eligible for Religious Minority.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.editSpecialReservationDetails(obj, ModifiedBy, ModifiedByIPAddress))
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