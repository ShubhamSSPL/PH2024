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
    public partial class frmCancelApplicationForm : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                try
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                    if (reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                    }

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }

                    Int32 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                    PersonalInformation obj = reg.getPersonalInformation(PID);

                    lblApplicationID.Text = obj.ApplicationID;
                    lblCandidateName.Text = obj.CandidateName;
                    lblFatherName.Text = obj.FatherName;
                    lblMotherName.Text = obj.MotherName;
                    lblGender.Text = obj.Gender;
                    lblDOB.Text = obj.DOB;
                    lblCandidatureType.Text = obj.FinalCandidatureType;
                    if (obj.CandidatureType != obj.FinalCandidatureType)
                    {
                        lblCandidatureType.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    lblHomeUniversity.Text = obj.FinalHomeUniversity;
                    if (obj.HomeUniversity != obj.FinalHomeUniversity)
                    {
                        lblHomeUniversity.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    lblOriginalCategory.Text = obj.Category;
                    lblCategoryForAdmission.Text = obj.FinalCategory;
                    if (obj.Category != obj.FinalCategory)
                    {
                        lblCategoryForAdmission.Text = obj.FinalCategory + "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    lblPHType.Text = obj.FinalPHType;
                    if (obj.PHType != obj.FinalPHType)
                    {
                        lblPHType.Text += "<font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                    }
                    if (obj.AppliedForMinoritySeats == "Yes")
                    {
                        if (obj.FinalLinguisticMinorityDetails == "Not Applicable" && obj.FinalReligiousMinorityDetails == "Not Applicable")
                        {
                            lblAppliedForMinoritySeats.Text = "No <font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                        }
                        else if (obj.FinalLinguisticMinorityDetails != "Not Applicable" && obj.FinalReligiousMinorityDetails != "Not Applicable")
                        {
                            lblAppliedForMinoritySeats.Text = obj.AppliedForMinoritySeats + " - " + obj.FinalLinguisticMinorityDetails + ", " + obj.FinalReligiousMinorityDetails;
                        }
                        else if (obj.FinalLinguisticMinorityDetails != "Not Applicable" && obj.FinalReligiousMinorityDetails == "Not Applicable")
                        {
                            lblAppliedForMinoritySeats.Text = obj.AppliedForMinoritySeats + " - " + obj.FinalLinguisticMinorityDetails;
                        }
                        else if (obj.FinalLinguisticMinorityDetails == "Not Applicable" && obj.FinalReligiousMinorityDetails != "Not Applicable")
                        {
                            lblAppliedForMinoritySeats.Text = obj.AppliedForMinoritySeats + " - " + obj.FinalReligiousMinorityDetails;
                        }
                    }
                    else
                    {
                        lblAppliedForMinoritySeats.Text = obj.AppliedForMinoritySeats;
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                if (Global.IsOTPVerificationRequiredForCancelApplicationForm == 1)
                {
                    SMSTemplate sMSTemplate = new SMSTemplate();
                    sMSTemplate.PID = PID;
                    SynCommon synCommon = new SynCommon();
                    if (synCommon.SendOTPSMS(sMSTemplate, SynCommon.TemplateSystemType.CancelApplicationFormOTP))
                    Response.Redirect("~/AFCModule/frmVerifyOTPCancelApplication.aspx?PID=" + PID + "&Code=" + PID.GetHashCode() + "&ReasonForCancellation=" + Server.UrlEncode(txtReasonForCancellation.Text), true);
                }
                else
                {
                    if (reg.cancelConfirmedApplicationForm(PID, txtReasonForCancellation.Text,Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {

                        DataSet ds = reg.getApplicationFormCancellationDetails(PID);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            SMSTemplate sMSTemplate = new SMSTemplate();
                            SynCommon synCommon = new SynCommon();
                            sMSTemplate.PID = PID;
                            sMSTemplate.CancelledBy = ds.Tables[0].Rows[0]["CancelledBy"].ToString();
                            sMSTemplate.CancelledDateTime = ds.Tables[0].Rows[0]["CancelledDateTime"].ToString();
                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CancelApplicationForm);
                        }
                        shInfo.SetMessage("Application Form Cancelled Successfully.", ShowMessageType.Information);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in cancellation. Please try after some time.",
                            ShowMessageType.Information);
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