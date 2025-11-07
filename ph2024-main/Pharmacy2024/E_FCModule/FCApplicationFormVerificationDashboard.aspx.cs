using BusinessLayer;
using EntityModel;
using Pharmacy2024.CandidateAccountRecoveryModule;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.E_FCModule
{
    public partial class FCApplicationFormVerificationDashboard : System.Web.UI.Page
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
            if (Session["UserTypeID"] == null || Session["UserTypeID"].ToString() == "91")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

            if (PID.ToString().GetHashCode() != Code)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            if (reg.CheckISEFC(Session["UserLoginId"].ToString()) == "N" && (Convert.ToInt16(Session["UserTypeID"]) == 23 || Convert.ToInt16(Session["UserTypeID"]) == 24))
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            ViewState["PID"] = PID;
            CandidateBasicInformation.PID = Convert.ToInt64(ViewState["PID"].ToString());
            if (Request.QueryString["ApplicationFormStepID"] != null)
            {
                Int32 ApplicationFormStepID = Convert.ToInt32(Request.QueryString["ApplicationFormStepID"].ToString());
                ApplicationFormVerificationStep(ApplicationFormStepID, PID);

            }
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["FromSEBCUpdation"] != null)
                    {
                        if (Request.QueryString["FromSEBCUpdation"].ToString() == "1")
                            BindGrid();
                    }
                    else
                    {
                        DataSet ds1 = reg.getApplicationFormConfirmationDetails(PID);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            DateTime ConfirmedDateTime = Convert.ToDateTime(ds1.Tables[0].Rows[0]["ConfirmedDateTime"]);
                            string ConfirmedOn = ConfirmedDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ConfirmedDateTime);
                            string ConfirmedBy = ds1.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                            shInfo.SetMessage("Application Form is Already Verified and Confirmed By " + ConfirmedBy + " on " + ConfirmedOn + ".", ShowMessageType.Information);

                            gvApplicationFormLinksStatus.Visible = false;
                            tblDuplicateMobile.Visible = false;
                        }
                        else
                        {
                            DataSet ds = reg.GetApplicationFormConfirmationDetailsGrivance(PID);
                            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                            {
                                BindGrid();
                            }
                            else
                            {
                                Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);
                                DataSet dsChkCETApplicationNo = reg.isApplicationFormConfirmedUsingThisCETApplicationNo(CETApplicationFormNo, PID);
                                NEETDetails obj = reg.getNEETDetails(PID);
                                DataSet dsChkNEETRollNo = reg.isApplicationFormConfirmedUsingThisNEETRollNo(Convert.ToInt64(obj.NEETRollNo.ToString()), PID);

                                if (Global.CheckDuplicateMobileNo == 1 && reg.isApplicationFormConfirmedUsingThisMobileNo(reg.getMobileNo(PID)))
                                {
                                    shInfo.SetMessage("Application Form using mobile number " + DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(PID)) + " is already confirmed. Please change mobile number.", ShowMessageType.Information);
                                    gvApplicationFormLinksStatus.Visible = false;
                                    tblDuplicateHSCSeatNo.Visible = false;
                                    tblDuplicateMobile.Visible = true;
                                }
                                else if (reg.IsApplicationFormConfirmedUsingThisHSCSeatNo(PID))
                                {
                                    DataSet dsHScSeatno = reg.getHSCSeatNo(PID);
                                    DataSet GetApplicationID = reg.GetApplicationIDIsFormConfirmedUsingHSCSeatNo(PID);
                                    ViewState["GetApplicationID"] = GetApplicationID.Tables[0].Rows[0]["ApplicationID"].ToString();
                                    shInfo.SetMessage("Application Form using This HSC Seat number " + dsHScSeatno.Tables[0].Rows[0]["HSCSeatNo"].ToString() + "," + "ApplicationID-" + GetApplicationID.Tables[0].Rows[0]["ApplicationID"].ToString() + "  is already confirmed. Please change HSC Seat number.", ShowMessageType.Information);
                                    gvApplicationFormLinksStatus.Visible = false;
                                    tblDuplicateMobile.Visible = false;
                                    tblDuplicateHSCSeatNo.Visible = false;
                                    tblDuplicateHSCSeatNo.Visible = true;
                                }
                                else if (dsChkCETApplicationNo.Tables[0].Rows.Count > 0)
                                {
                                    if (dsChkCETApplicationNo.Tables[0].Rows[0]["Status"].ToString() == "0")
                                    {
                                        //string sCETApplicationNumber = dsChkCETApplicationNo.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();
                                        string sApplicationID = dsChkCETApplicationNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                                        string sConfirmedBy = dsChkCETApplicationNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                                        shInfo.SetMessage("Application Form using CET Application Number " + CETApplicationFormNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
                                        gvApplicationFormLinksStatus.Visible = false;
                                        tblDuplicateHSCSeatNo.Visible = false;
                                        tblDuplicateNEETRollNo.Visible = false;
                                        tblDuplicateCETApplicationFormNo.Visible = true;
                                    }
                                    else
                                    {
                                        if (reg.GetApplicationLockStatus(PID) == "N")
                                        {
                                            shInfo.SetMessage("Application Form is unlocked by Candidate.", ShowMessageType.Information);
                                            gvApplicationFormLinksStatus.Visible = false;
                                        }
                                        else
                                        {
                                            BindGrid();
                                        }
                                    }
                                }
                                if (dsChkNEETRollNo.Tables[0].Rows.Count > 0)
                                {
                                    if (dsChkNEETRollNo.Tables[0].Rows[0]["Status"].ToString() == "0" && dsChkCETApplicationNo.Tables[0].Rows[0]["Status"].ToString() != "0")
                                    {
                                        string sApplicationID = dsChkNEETRollNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                                        string sConfirmedBy = dsChkNEETRollNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                                        shInfo.SetMessage("Application Form using NEETRollNo " + obj.NEETRollNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
                                        gvApplicationFormLinksStatus.Visible = false;
                                        tblDuplicateNEETRollNo.Visible = true;
                                    }
                                    else
                                    {
                                        if (reg.GetApplicationLockStatus(PID) == "N")
                                        {
                                            shInfo.SetMessage("Application Form is unlocked by Candidate.", ShowMessageType.Information);
                                            gvApplicationFormLinksStatus.Visible = false;
                                        }
                                        else
                                        {
                                            BindGrid();
                                        }

                                    }
                                }
                                else
                                {
                                    DataSet dsEligibilityRemark = reg.getEligibilityFlag(PID);
                                    if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Length > 0)
                                    {
                                        shInfo.SetMessage(dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString(), ShowMessageType.Information);
                                        gvApplicationFormLinksStatus.Visible = false;
                                    }
                                    //string EligibilityRemark = reg.getEligibilityFlag(PID);
                                    //if (EligibilityRemark.Length > 0)
                                    //{

                                    //}
                                    else
                                    {
                                        if (reg.GetApplicationLockStatus(PID) == "N")
                                        {
                                            shInfo.SetMessage("Application Form is unlocked by Candidate.", ShowMessageType.Information);
                                            gvApplicationFormLinksStatus.Visible = false;
                                        }
                                        else
                                        {
                                            BindGrid();
                                        }
                                    }
                                }
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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

            DBUtility regDB = new DBUtility();
            if (regDB.markDuplicateMobileNoDiscrepancy(PID, DataEncryption.DecryptDataByEncryptionKey(reg.getMobileNo(PID)), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
            {
                if (Global.SendSMSToCandidate == 1)
                {

                    SMSTemplate sMSTemplate = new SMSTemplate();
                    SynCommon synCommon = new SynCommon();
                    sMSTemplate.PID = PID;
                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                    if (Global.SendSMSToCandidate == 1)
                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationFormDiscrepancy);
                }
                Response.Redirect("../E_FCModule/frmDiscrepancyMarkCandidateList", true);
            }
            else
            {
                shInfo.SetMessage("Technical Problem In Saving Data. Please Try After sometime.", ShowMessageType.Information);
            }
        }
        protected void btnMarkDuplicateCETApplicationNo_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);
            DataSet dsChkCETApplicationNo = reg.isApplicationFormConfirmedUsingThisCETApplicationNo(CETApplicationFormNo, PID);
            string sApplicationID = string.Empty;
            if (dsChkCETApplicationNo.Tables[0].Rows[0]["Status"].ToString() == "0")
            {
                //string sCETApplicationNumber = dsChkCETApplicationNo.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();
                sApplicationID = dsChkCETApplicationNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                string sConfirmedBy = dsChkCETApplicationNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                shInfo.SetMessage("Application Form using CET Application Number " + CETApplicationFormNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
            }
            DBUtility regDB = new DBUtility();
            if (regDB.markDuplicateCETApplicationDiscrepancy(PID, CETApplicationFormNo.ToString() + "/" + sApplicationID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
            {
                if (Global.SendSMSToCandidate == 1)
                {

                    SMSTemplate sMSTemplate = new SMSTemplate();
                    SynCommon synCommon = new SynCommon();
                    sMSTemplate.PID = PID;
                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                    if (Global.SendSMSToCandidate == 1)
                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationFormDiscrepancy);
                }
                Response.Redirect("../E_FCModule/frmDiscrepancyMarkCandidateList", true);
            }
            else
            {
                shInfo.SetMessage("Technical Problem In Saving Data. Please Try After sometime.", ShowMessageType.Information);
            }
        }
        protected void btnMarkDuplicateNEETRollNo_Click(object sender,EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            NEETDetails obj = reg.getNEETDetails(PID);
            DataSet dsChkNEETRollNo = reg.isApplicationFormConfirmedUsingThisNEETRollNo(Convert.ToInt64(obj.NEETRollNo.ToString()), PID);
            string sApplicationID = string.Empty;
            if (dsChkNEETRollNo.Tables[0].Rows[0]["Status"].ToString() == "0")
            {
                //string sCETApplicationNumber = dsChkCETApplicationNo.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();
                sApplicationID = dsChkNEETRollNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                string sConfirmedBy = dsChkNEETRollNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                shInfo.SetMessage("Application Form using CET Application Number " + obj.NEETRollNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
            }
            DBUtility regDB = new DBUtility();
            if (regDB.markDuplicateNEETRollNoDiscrepancy(PID, obj.NEETRollNo.ToString() + "/" + sApplicationID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
            {
                if (Global.SendSMSToCandidate == 1)
                {

                    SMSTemplate sMSTemplate = new SMSTemplate();
                    SynCommon synCommon = new SynCommon();
                    sMSTemplate.PID = PID;
                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                    if (Global.SendSMSToCandidate == 1)
                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationFormDiscrepancy);
                }
                Response.Redirect("../E_FCModule/frmDiscrepancyMarkCandidateList", true);
            }
            else
            {
                shInfo.SetMessage("Technical Problem In Saving Data. Please Try After sometime.", ShowMessageType.Information);
            }
        }
        protected void btnHSCSeatNoSubmit_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            try
            {
                DataSet dsHScSeatno = reg.getHSCSeatNo(PID);
                string HSCSeatNo = dsHScSeatno.Tables[0].Rows[0]["HSCSeatNo"].ToString();
                string ApplicationID = ViewState["GetApplicationID"].ToString();

                DBUtility regDB = new DBUtility();
                if (regDB.markDuplicateHSCSeatNoDiscrepancy(PID, HSCSeatNo +"/"+ ApplicationID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    if (Global.SendSMSToCandidate == 1)
                    {
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        SynCommon synCommon = new SynCommon();
                        sMSTemplate.PID = PID;
                        sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                        sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                        sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                        if (Global.SendSMSToCandidate == 1)
                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationFormDiscrepancy);
                    }
                    Response.Redirect("../E_FCModule/frmDiscrepancyMarkCandidateList", true);
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private void BindGrid()
        {
            gvApplicationFormLinksStatus.DataSource = reg.GetCandidateVerificationStepwiseStatusForAFC(Convert.ToInt64(ViewState["PID"]));
            gvApplicationFormLinksStatus.DataBind();

        }

        protected void gvApplicationFormLinksStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.Cells[2].Text == "VERIFIED")
                    {
                        e.Row.BackColor = System.Drawing.Color.Cyan;
                    }
                    else if (e.Row.Cells[2].Text == "DISCREPANCY")
                    {
                        e.Row.BackColor = System.Drawing.Color.LightCoral;
                    }
                    else if (e.Row.Cells[2].Text == "PARTIALLY VERIFIED")
                    {
                        e.Row.BackColor = System.Drawing.Color.Bisque;
                    }
                    else if (e.Row.Cells[2].Text == "PARTIALLY VERIFIED AND FOUND DISCREPANCY")
                    {
                        e.Row.BackColor = System.Drawing.Color.Coral;
                    }


                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }

        }
        protected void gvApplicationFormLinksStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
            try
            {
                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 PersonalId = Convert.ToInt64(((Label)gvApplicationFormLinksStatus.Rows[RowID].FindControl("lblPersonalID")).Text);
                Int32 ApplicationFormStepID = Convert.ToInt32(((Label)gvApplicationFormLinksStatus.Rows[RowID].FindControl("lblApplicationFormStepID")).Text);
                if (e.CommandName == "Verify")
                {
                    ApplicationFormVerificationStep(ApplicationFormStepID, PersonalId);
                }
                else
                {
                    shInfo.Visible = false;
                    shInfo.SetMessage("Please Enter Replied Message.", ShowMessageType.Information);
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private void ApplicationFormVerificationStep(int ApplicationFormStepID, Int64 PersonalId)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string Usedby = new DBUtility().GetCandidatePickedFC(PersonalId);
                if (Usedby == Session["UserLoginID"].ToString() || Usedby == "")
                {
                    Int32 CandidatureTypeID = reg.getCandidatureTypeID(PersonalId);
                    if (CandidatureTypeID > 5 && ApplicationFormStepID == 3)
                    {
                        ApplicationFormStepID = ApplicationFormStepID + 2;
                    }

                    if (ApplicationFormStepID == 1)
                    {
                        Response.Redirect("../E_FCModule/EVerificationPersonalDetails?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + ApplicationFormStepID);
                    }
                    else if (ApplicationFormStepID == 2)
                    {
                        Response.Redirect("../E_FCModule/EVerificationCandidatureType?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + ApplicationFormStepID);
                    }
                    else if (ApplicationFormStepID == 3)
                    {
                        Response.Redirect("../E_FCModule/EVerificationUniversityAndCategoryDetails?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + ApplicationFormStepID);
                    }
                    else if (ApplicationFormStepID == 4)
                    {
                        Response.Redirect("../E_FCModule/EVerificationSpecialReservation?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + ApplicationFormStepID);
                    }
                    else if (ApplicationFormStepID == 5)
                    {
                        Response.Redirect("../E_FCModule/EVerificationQualificationDetails?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + ApplicationFormStepID);
                    }
                    else if (ApplicationFormStepID == 6)
                    {
                        Response.Redirect("../E_FCModule/EVerificationNEETDetails?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + ApplicationFormStepID);
                    }
                    else if (ApplicationFormStepID == 7)
                    {
                        Response.Redirect("../E_FCModule/EVerificationScannedImages?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + ApplicationFormStepID);
                    }
                    else if (ApplicationFormStepID == 8)
                    {
                        Response.Redirect("../E_FCModule/VerificationAppliction?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + ApplicationFormStepID);
                    }
                }
                else
                {
                    shInfo.SetMessage("Application form is Picked By SC :-" + Usedby, ShowMessageType.Information);
                    shInfo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        public class DBUtility
        {
            public bool markDuplicateMobileNoDiscrepancy(Int64 PID, string MobileNo, string ModifiedBy, string ModifiedByIPAddress)
            {
                DBConnection db = new DBConnection();
                try
                {
                    Int32 result = Convert.ToInt32(db.ExecuteNonQuery("MHDTE_spMarkDuplicateMobileNoDiscrepancy", new SqlParameter[]
                     {
                new SqlParameter("@PID", PID),
                new SqlParameter("@MobileNo", MobileNo),
                new SqlParameter("@ModifiedBy", ModifiedBy),
                new SqlParameter("@ModifiedByIPAddress", ModifiedByIPAddress),
                     }));

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                    //long messageID = ExceptionMessages.GetMessageDetails();
                    //throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
                }
                finally
                {
                    db.Dispose();
                }
            }
            public bool markDuplicateCETApplicationDiscrepancy(Int64 PID, string CETApplicationFormNo, string ModifiedBy, string ModifiedByIPAddress)
            {
                DBConnection db = new DBConnection();
                try
                {
                    Int32 result = Convert.ToInt32(db.ExecuteNonQuery("MHDTE_spMarkDuplicateCETApplicationDiscrepancy", new SqlParameter[]
                     {
                new SqlParameter("@PID", PID),
                new SqlParameter("@CETApplicationFormNo", CETApplicationFormNo),
                new SqlParameter("@ModifiedBy", ModifiedBy),
                new SqlParameter("@ModifiedByIPAddress", ModifiedByIPAddress),
                     }));

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                    //long messageID = ExceptionMessages.GetMessageDetails();
                    //throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
                }
                finally
                {
                    db.Dispose();
                }
            }
            public bool markNotEligibleDiscrepancy(Int64 PID, string DiscrepancyRemark, string ModifiedBy, string ModifiedByIPAddress)
            {
                DBConnection db = new DBConnection();
                try
                {
                    Int32 result = Convert.ToInt32(db.ExecuteNonQuery("MHDTE_spMarkNotEligibleDiscrepancy", new SqlParameter[]
                     {
                new SqlParameter("@PID", PID),
                new SqlParameter("@DiscrepancyRemark", DiscrepancyRemark),
                new SqlParameter("@ModifiedBy", ModifiedBy),
                new SqlParameter("@ModifiedByIPAddress", ModifiedByIPAddress),
                     }));

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                    //long messageID = ExceptionMessages.GetMessageDetails();
                    //throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
                }
                finally
                {
                    db.Dispose();
                }
            }
            public bool markDuplicateHSCSeatNoDiscrepancy(Int64 PID, string HSCSeatNo, string ModifiedBy, string ModifiedByIPAddress)
            {
                DBConnection db = new DBConnection();
                try
                {
                    Int32 result = Convert.ToInt32(db.ExecuteNonQuery("MHDTE_spMarkDuplicateHSCSeatNoDiscrepancy", new SqlParameter[]
                     {
                        new SqlParameter("@PID", PID),
                        new SqlParameter("@HSCSeatNo", HSCSeatNo),
                        new SqlParameter("@ModifiedBy", ModifiedBy),
                        new SqlParameter("@ModifiedByIPAddress", ModifiedByIPAddress),
                     }));

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                    //long messageID = ExceptionMessages.GetMessageDetails();
                    //throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
                }
                finally
                {
                    db.Dispose();
                }
            }

            public string GetCandidatePickedFC(Int64 PID)
            {
                DBConnection db = new DBConnection();
                try
                {
                    string result = Convert.ToString(db.ExecuteScaler("MHDTE_spGetMappedSCForCandidate", new SqlParameter[]
                     {
                new SqlParameter("@PID", PID),

                     }));

                    return result;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    //long messageID = ExceptionMessages.GetMessageDetails();
                    //throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
                }
                finally
                {
                    db.Dispose();
                }

            }

            public bool markDuplicateNEETRollNoDiscrepancy(Int64 PID, string NEETRollNo, string ModifiedBy, string ModifiedByIPAddress)
            {
                DBConnection db = new DBConnection();
                try
                {
                    Int32 result = Convert.ToInt32(db.ExecuteNonQuery("MHDTE_spMarkDuplicateNEETRollNo", new SqlParameter[]
                     {
                new SqlParameter("@PID", PID),
                new SqlParameter("@NEETRollNo", NEETRollNo),
                new SqlParameter("@ModifiedBy", ModifiedBy),
                new SqlParameter("@ModifiedByIPAddress", ModifiedByIPAddress),
                     }));

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                    //long messageID = ExceptionMessages.GetMessageDetails();
                    //throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}