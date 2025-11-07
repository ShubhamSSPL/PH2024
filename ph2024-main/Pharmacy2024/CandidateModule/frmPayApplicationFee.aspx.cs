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
    public partial class frmPayApplicationFee : System.Web.UI.Page
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
                    DataSet dsCurrentLink = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmPayApplicationFee");

                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());


                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if ((ApplicationFormStatus == 'A' || objSessionData.StepID < 7) && (FCVerificationStatus == 'C' || FCVerificationStatus == 'P'))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }
                    if (reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "Y")
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }
                    DataSet dsEligibilityRemark = reg.getEligibilityFlag(objSessionData.PID);
                    if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && dsEligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                    {
                        shInfo.SetMessage(dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString(), ShowMessageType.Information);
                        ContentTable2.Visible = false;
                    }
                    else
                    {
                        Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(objSessionData.PID);
                        lblApplicationFeeToBePaid.Text = ApplicationFeeToBePaid.ToString();

                        if (ApplicationFeeToBePaid > 0)
                        {
                            Session["FeeGroupId"] = null;
                            Session["PhaseId"] = null;
                            Session["PayeeUserTypeId"] = null;
                            Session["PayeeId"] = null;

                            Session["FeeGroupId"] = "2";
                            Session["PhaseId"] = "1";
                            Session["PayeeUserTypeId"] = Session["UserTypeID"].ToString();
                            Session["PayeeId"] = Session["UserID"].ToString();

                            Response.Redirect("../FeeProcess/PaymentDetails", true);
                        }
                        else
                        {
                            DataSet ds = reg.getApplicationFeePaymentDetails(objSessionData.PID);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblMHTCETApplicationFeePaid.Text = ds.Tables[0].Rows[0]["MHTCETApplicationFeePaid"].ToString() + "/-";
                                lblOnlineApplicationFeePaid.Text = ds.Tables[0].Rows[0]["OnlineApplicationFeePaid"].ToString() + "/-";
                            }
                            lblApplicationFeeToBePaid.Text = "NIL/-";
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
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                if (reg.savePayApplicationFeeStepID(objSessionData.PID, ModifiedBy, ModifiedByIPAddress))
                {
                    if (objSessionData.StepID < 9)
                    {
                        objSessionData.StepID = 9;
                    }

                    if (objSessionData.ApplicationFormStatus == 'I')
                    {
                        objSessionData.ApplicationFormStatus = 'C';
                    }

                    Session["SessionData"] = objSessionData;
                    //DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    //char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    //char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                    //char IsLockedByCandidate = Convert.ToChar(statusDs.Tables[0].Rows[0]["IsLockedByCandidate"].ToString());
                    //if (reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "N" && ApplicationFormStatus == 'C')
                    //{
                    //    PersonalInformation obj = reg.getPersonalInformation(objSessionData.PID);

                    //    if (obj.FinalHomeUniversity == "NA")
                    //    {
                    //        if (objSessionData.CandidatureTypeID == 1 || objSessionData.CandidatureTypeID == 2 || objSessionData.CandidatureTypeID == 3 || objSessionData.CandidatureTypeID == 4 || objSessionData.CandidatureTypeID == 5)
                    //        {
                    //            Response.Redirect("../CandidateModule/frmHomeUniversityAndCategoryDetails.aspx");
                    //        }
                    //    }
                    //    else if (obj.HSCTotalMarksObtained == 0)
                    //    {
                    //        Response.Redirect("../CandidateModule/frmQualificationDetails.aspx", true);
                    //    }
                    //    else
                    //        Response.Redirect("../CandidateModule/frmVerifyAndConfirmApplicationForm.aspx", true);
                    //}
                    //else
                    Response.Redirect("../CandidateModule/frmApplicationForm", true);
                }
                else
                {
                    if (lblApplicationFeeToBePaid.Text == "NIL/-")
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
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
    }
}