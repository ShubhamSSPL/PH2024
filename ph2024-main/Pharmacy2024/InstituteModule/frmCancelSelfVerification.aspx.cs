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

namespace Pharmacy2024.InstituteModule
{
    public partial class frmCancelSelfVerification : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;
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
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

            if (PID.ToString().GetHashCode() != Code)
            {
                Response.Redirect("../ApplicationPages/WelcomePageInstitute.aspx", true);
            }

            Int64 ChoiceCode = Convert.ToInt64(Request.QueryString["ChoiceCode"].ToString());
            Int32 CAPRound = Convert.ToInt32(Request.QueryString["CAPRound"].ToString());
            DataSet ds = reg.getSeatAcceptanceFeeList(PID, "Seat Acceptance Fee");

            if (ds.Tables[0].Rows.Count == 0)
            {
                trFeeDetails1.Visible = false;
            }
            else
            {
                trFeeDetails2.Visible = false;
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (!IsPostBack)
                {

                    DataSet dsPersonalInformation = reg.getPersonalInformationForAllotmentDisplay(PID);
                    DataSet dsAllotmentDetails = reg.getAllotmentDetails(PID);

                    string selfVerificationStatus = "";
                    Int16 IsAllotmentCancellationRequired = 0;
                    DataSet dsstatus = reg.GetSelfVerificationstatus(PID);
                    if (dsstatus.Tables.Count > 0)
                    {
                        if (dsstatus.Tables[0].Rows.Count > 0)
                        {
                            selfVerificationStatus = dsstatus.Tables[0].Rows[0]["IsGrivanceRaised"].ToString();
                            IsAllotmentCancellationRequired = Convert.ToInt16(dsstatus.Tables[0].Rows[0]["IsAllotmentCancellationRequired"].ToString());
                        }
                    }


                    if (dsPersonalInformation.Tables[0].Rows.Count > 0)
                    {
                        lblApplicationID.Text = dsPersonalInformation.Tables[0].Rows[0]["ApplicationID"].ToString();
                        lblCandidateName.Text = dsPersonalInformation.Tables[0].Rows[0]["CandidateName"].ToString();
                        lblGender.Text = dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString();
                        lblDOB.Text = dsPersonalInformation.Tables[0].Rows[0]["DOB"].ToString();
                        lblCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                        lblHomeUniversity.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                        lblOriginalCategory.Text = dsPersonalInformation.Tables[0].Rows[0]["OriginalCategory"].ToString();
                        lblCategoryForAdmission.Text = dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString();
                        //if (dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString().Contains("$"))
                        //    trCVC.Visible = true;
                        //if (dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString().Contains("#"))
                        //    trNCL.Visible = true;
                        lblAppliedForEWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                        lblAppliedForOrphan.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                        lblPHType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString();
                        lblDefenceType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                        lblMinorityCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
                        lblAppliedForTFWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                        lblHSCPhysicsPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCPhysicsPercentage"].ToString() + " %";
                        lblHSCChemistryPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCChemistryPercentage"].ToString() + " %";
                        lblHSCSubject.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubject"].ToString();
                        lblHSCSubjectPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCSubjectPercentage"].ToString() + " %";
                        //if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["HSCBioTechnologyPercentage"].ToString()) > 0)
                        //{
                        //    lblHSCBioTechnologyPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCBioTechnologyPercentage"].ToString() + " %";
                        //}
                        //else
                        //{
                        //    lblHSCBioTechnologyPercentage.Text = "--";
                        //}
                        lblHSCTotalPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["HSCTotalPercentage"].ToString() + " %";
                        if (Convert.ToDecimal(dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalPercentage"].ToString()) > 0)
                        {
                            lblDiplomaTotalPercentage.Text = dsPersonalInformation.Tables[0].Rows[0]["DiplomaTotalPercentage"].ToString() + " %";
                        }
                        else
                        {
                            lblDiplomaTotalPercentage.Text = "--";
                        }
                        lblMHMeritNo.Text = dsPersonalInformation.Tables[0].Rows[0]["MHMeritNo"].ToString();
                        lblMHMeritScore.Text = dsPersonalInformation.Tables[0].Rows[0]["MHMeritScore"].ToString();
                        lblAIMeritNo.Text = dsPersonalInformation.Tables[0].Rows[0]["AIMeritNo"].ToString();
                        lblAIMeritScore.Text = dsPersonalInformation.Tables[0].Rows[0]["AIMeritScore"].ToString();
                    }

                    //if (Convert.ToInt16(dsAllotmentDetails.Tables[0].Rows[0]["PreferenceNoAllotted"]) == 1)
                    //{
                    //    lifirstprefcap1.Visible = true;
                    //    lisecondprefcap1.Visible = false;
                    //    lithirdprefcap1.Visible = false;
                    //}
                    //else
                    //{
                    //    lifirstprefcap1.Visible = false;
                    //    lisecondprefcap1.Visible = true;
                    //    lithirdprefcap1.Visible = true;
                    //}

                    if (Global.CAPRound >= 1)
                    {
                        if (dsAllotmentDetails.Tables[0].Rows.Count > 0)
                        {
                            tblAllotmentDetailsCAPRound1.Visible = true;
                            lblInstituteAllottedCAPRound1.Text = dsAllotmentDetails.Tables[0].Rows[0]["InstituteAllotted"].ToString();
                            lblCourseAllottedCAPRound1.Text = dsAllotmentDetails.Tables[0].Rows[0]["CourseAllotted"].ToString();
                            lblSeatTypeAllottedCAPRound1.Text = dsAllotmentDetails.Tables[0].Rows[0]["SeatTypeAllotted"].ToString();
                            lblPreferenceNoAllottedCAPRound1.Text = dsAllotmentDetails.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString();
                            if (dsAllotmentDetails.Tables[0].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                            {
                                trCommentsCAPRound1.Visible = true;
                                lblCommentsCAPRound1.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[0].Rows[0]["ReasonForCancellation"].ToString();
                            }
                            else
                            {
                                trCommentsCAPRound1.Visible = false;
                            }
                        }
                        else
                        {
                            tblNoAllotmentDetailsCAPRound1.Visible = true;
                            lblAllotmentStatusCAPRound1.Text = "Not Allotted in CAP Round-I";
                        }
                    }
                    if (Global.CAPRound >= 2)
                    {
                        if (dsAllotmentDetails.Tables[1].Rows.Count > 0)
                        {
                            tblAllotmentDetailsCAPRound2.Visible = true;
                            lblInstituteAllottedCAPRound2.Text = dsAllotmentDetails.Tables[1].Rows[0]["InstituteAllotted"].ToString();
                            lblCourseAllottedCAPRound2.Text = dsAllotmentDetails.Tables[1].Rows[0]["CourseAllotted"].ToString();
                            lblSeatTypeAllottedCAPRound2.Text = dsAllotmentDetails.Tables[1].Rows[0]["SeatTypeAllotted"].ToString();
                            lblPreferenceNoAllottedCAPRound2.Text = dsAllotmentDetails.Tables[1].Rows[0]["PreferenceNoAllotted"].ToString();
                            if (dsAllotmentDetails.Tables[1].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                            {
                                trCommentsCAPRound2.Visible = true;
                                lblCommentsCAPRound2.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[1].Rows[0]["ReasonForCancellation"].ToString();
                            }
                            else
                            {
                                trCommentsCAPRound2.Visible = false;
                            }
                        }
                        else
                        {
                            tblNoAllotmentDetailsCAPRound2.Visible = true;
                            lblAllotmentStatusCAPRound2.Text = "Not Allotted in CAP Round-II / Not Allotted New Choice Code in CAP Round-II";
                        }
                    }

                    if (Global.CAPRound >= 3)
                    {
                        if (dsAllotmentDetails.Tables[2].Rows.Count > 0)
                        {
                            tblAllotmentDetailsCAPRound3.Visible = true;
                            lblInstituteAllottedCAPRound3.Text = dsAllotmentDetails.Tables[2].Rows[0]["InstituteAllotted"].ToString();
                            lblCourseAllottedCAPRound3.Text = dsAllotmentDetails.Tables[2].Rows[0]["CourseAllotted"].ToString();
                            lblSeatTypeAllottedCAPRound3.Text = dsAllotmentDetails.Tables[2].Rows[0]["SeatTypeAllotted"].ToString();
                            lblPreferenceNoAllottedCAPRound3.Text = dsAllotmentDetails.Tables[2].Rows[0]["PreferenceNoAllotted"].ToString();
                            if (dsAllotmentDetails.Tables[2].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                            {
                                trCommentsCAPRound3.Visible = true;
                                lblCommentsCAPRound3.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[2].Rows[0]["ReasonForCancellation"].ToString();
                            }
                            else
                            {
                                trCommentsCAPRound3.Visible = false;
                            }
                        }
                        else
                        {
                            tblNoAllotmentDetailsCAPRound3.Visible = true;
                            lblAllotmentStatusCAPRound3.Text = "Not Allotted in CAP Round-III / Not Allotted New Choice Code in CAP Round-III";
                        }
                    }

                    if (Global.CAPRound >= 4)
                    {
                        if (dsAllotmentDetails.Tables[3].Rows.Count > 0)
                        {
                            tblAllotmentDetailsCAPRound4.Visible = true;
                            lblInstituteAllottedCAPRound4.Text = dsAllotmentDetails.Tables[3].Rows[0]["InstituteAllotted"].ToString();
                            lblCourseAllottedCAPRound4.Text = dsAllotmentDetails.Tables[3].Rows[0]["CourseAllotted"].ToString();
                            lblSeatTypeAllottedCAPRound4.Text = dsAllotmentDetails.Tables[3].Rows[0]["SeatTypeAllotted"].ToString();
                            lblPreferenceNoAllottedCAPRound4.Text = dsAllotmentDetails.Tables[3].Rows[0]["PreferenceNoAllotted"].ToString();
                            if (dsAllotmentDetails.Tables[3].Rows[0]["ReasonForCancellation"].ToString().Length > 0)
                            {
                                trCommentsCAPRound4.Visible = true;
                                lblCommentsCAPRound4.Text = "<b>Remark : </b>" + dsAllotmentDetails.Tables[3].Rows[0]["ReasonForCancellation"].ToString();
                            }
                            else
                            {
                                trCommentsCAPRound4.Visible = false;
                            }
                        }
                        else
                        {
                            tblNoAllotmentDetailsCAPRound4.Visible = true;
                            lblAllotmentStatusCAPRound4.Text = "Not Allotted in Additional Admission Round / Not Allotted New Choice Code in Additional Admission Round";
                        }
                    }

                    gvFeeDetails.DataSource = reg.getSeatAcceptanceFeeList(PID, "Seat Acceptance Fee");
                    gvFeeDetails.DataBind();



                    DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(PID);
                    if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                    {
                        tblSeatAcceptanceStatusDetails.Visible = true;
                        lblVersionNo.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["VersionNo"].ToString();
                        lblSeatAcceptanceStatus.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["SeatAcceptanceStatus"].ToString();
                        lblSeatAcceptanceConfirmationDetails.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["ReportingStatus"].ToString();
                    }



                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceFeeDetails.aspx", true);
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (reg.CancelSelfVerificationSeatAcceptanceForm(Convert.ToInt64(Request.QueryString["PID"].ToString()), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), txtComment.Text))
                {

                    SMSTemplate sMSTemplate = new SMSTemplate();
                    SynCommon synCommon = new SynCommon();
                    sMSTemplate.PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    //sMSTemplate.ChoiceCodeDisplay = ChoiceCode.ToString();
                    sMSTemplate.CurrentDateTime = DateTime.Now.ToString();
                    sMSTemplate.UserLoginID = Session["UserLoginID"].ToString();
                    sMSTemplate.CancelledBy = Session["UserLoginID"].ToString();
                    sMSTemplate.CancelledDateTime = DateTime.Now.ToString();
                    if (Global.SendSMSToCandidate == 1)
                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CancelSeatAcceptance);
                    ContentTable2.Visible = false;
                    shInfo.SetMessage("Seat Acceptance Status Reset Successfully!", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Problem in Data saving Contact to Help Line numbers or send Message through Message Box !", ShowMessageType.Information);
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