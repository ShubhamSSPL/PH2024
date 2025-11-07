using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ARCModule
{
    public partial class frmCancelSeatAcceptanceForm : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    if (Request.Cookies["Theme"] == null)
        //    {
        //        Page.Theme = "default";
        //    }
        //    else
        //    {
        //        Page.Theme = Request.Cookies["Theme"].Value;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (!IsPostBack)
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageARC.aspx", true);
                    }

                    DataSet dsPersonalInformation = reg.getPersonalInformationForAllotmentDisplay(PID);
                    DataSet dsAllotmentDetails = reg.getAllotmentDetails(PID);
                    DataSet dsSeatAcceptanceStatusDetails = reg.getSeatAcceptanceStatusDetails(PID);

                    if (dsPersonalInformation.Tables[0].Rows.Count > 0)
                    {
                        lblCandidateName.Text = dsPersonalInformation.Tables[0].Rows[0]["CandidateName"].ToString();
                        lblGender.Text = dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString();
                        lblDOB.Text = dsPersonalInformation.Tables[0].Rows[0]["DOB"].ToString();
                        lblCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                        lblHomeUniversity.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                        lblOriginalCategory.Text = dsPersonalInformation.Tables[0].Rows[0]["OriginalCategory"].ToString();
                        lblCategoryForAdmission.Text = dsPersonalInformation.Tables[0].Rows[0]["AdmissionCategory"].ToString();
                        lblAppliedForEWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                        lblAppliedForOrphan.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                        lblPHType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString();
                        lblDefenceType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                        lblMinorityCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
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

                    if (dsSeatAcceptanceStatusDetails.Tables[0].Rows.Count > 0)
                    {
                        tblSeatAcceptanceStatusDetails.Visible = true;
                        lblSeatAcceptanceStatus.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["SeatAcceptanceStatus"].ToString();
                        lblSeatAcceptanceConfirmationDetails.Text = dsSeatAcceptanceStatusDetails.Tables[0].Rows[0]["ReportingStatus"].ToString();
                    }

                    //DataSet ds = reg.getSeatAcceptanceFeeDetails(PID, "Seat Acceptance Fee", "Locked");
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    if (ds.Tables[0].Rows[0]["PaymentMode"].ToString() == "Demand Draft")
                    //    {
                    //        tblUploadCancelledCheque.Visible = true;
                    //    }
                    //}
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                if (UserTypeID == 21 || UserTypeID == 22 || UserTypeID == 33 || UserTypeID == 34)
                {
                    string CancelledChequeFilePath = "";
                    string AccountNumber = "";
                    string IFSCCode = "";

                    //if (fileCancelledCheque.PostedFile != null)
                    //{
                    //    if (fileCancelledCheque.PostedFile.FileName.Length > 0)
                    //    {
                    //        if (System.IO.Path.GetExtension(fileCancelledCheque.PostedFile.FileName).ToUpper() == ".JPG" || System.IO.Path.GetExtension(fileCancelledCheque.PostedFile.FileName).ToUpper() == ".JPEG" || System.IO.Path.GetExtension(fileCancelledCheque.PostedFile.FileName).ToUpper() == ".PNG")
                    //        {
                    //            CancelledChequeFilePath = saveFile(PID.ToString() + System.IO.Path.GetExtension(fileCancelledCheque.PostedFile.FileName));
                    //        }
                    //        else
                    //        {
                    //            shInfo.SetMessage("Only JPG, JPEG and PNG files are accepted as an Attachment! File not uploaded!!", ShowMessageType.UserError);
                    //            return;
                    //        }
                    //    }
                    //}

                    if (reg.cancelSeatAcceptanceForm(PID, txtComments.Text, CancelledChequeFilePath, AccountNumber, IFSCCode, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                    {
                        if (Global.SendSMSToCandidate == 1)
                        {
                            DataSet ds = reg.getSeatAcceptanceStatusDetails(PID);
                            if (ds != null && ds.Tables.Count > 0)
                            {
                                SMSTemplate sMSTemplate = new SMSTemplate();
                                SynCommon synCommon = new SynCommon();
                                sMSTemplate.PID = PID;
                                sMSTemplate.ConfirmedBy = ds.Tables[0].Rows[0]["CancelledBy"].ToString();
                                sMSTemplate.ConfirmedDateTime = ds.Tables[0].Rows[0]["CancelledDateTime"].ToString();
                                synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CancelSeatAcceptance);
                            }
                            //SMS objSMS = new SMS();
                            //DataSet ds = reg.GetSMSEmailContent(PID, "Cancel Seat Acceptance", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                            //if (ds.Tables[0] != null)
                            //{
                            //    if (ds.Tables[0].Rows.Count > 0)
                            //    {
                            //        objSMS.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds.Tables[0].Rows[0]["MobileNo"].ToString()), ds.Tables[0].Rows[0]["SMSContent"].ToString());
                            //        if (Global.IsEmailSend == 1)
                            //        {
                            //            //objSMS.SendEmail(ds.Tables[1].Rows[0]["EmailID"].ToString(), ds.Tables[1].Rows[0]["EmailBody"].ToString(), ds.Tables[1].Rows[0]["EmailSubject"].ToString(), true);
                            //        }
                            //    }
                            //}
                        }
                        Response.Redirect("../ARCModule/frmSeatAcceptanceCancellationAcknowledgement.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                    }
                }
                else
                {
                    Response.Redirect("../ApplicationPages/WelcomePageARC.aspx");
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private string saveFile(string FilePath)
        {
            string FtpAddress = ConfigurationManager.AppSettings["FtpAddress"].ToString();
            string FtpUserName = ConfigurationManager.AppSettings["FtpUserName"].ToString();
            string FtpUserPassword = ConfigurationManager.AppSettings["FtpUserPassword"].ToString();
            string HttpAddress = ConfigurationManager.AppSettings["HttpAddress"].ToString();
            string FtpFilePath = FtpAddress + "CancelledCheque/" + FilePath;
            string HttpFilePath = HttpAddress + "CancelledCheque/" + FilePath;

            //if (fileCancelledCheque.PostedFile != null)
            //{
            //    Int32 size = fileCancelledCheque.PostedFile.ContentLength;
            //    Stream str = getFtpRequestToWrite(FtpFilePath, FtpUserName, FtpUserPassword);
            //    byte[] file = new byte[size];
            //    fileCancelledCheque.PostedFile.InputStream.Read(file, 0, size);
            //    str.Write(file, 0, size);

            //    str.Close();
            //}

            return HttpFilePath;
        }
        private Stream getFtpRequestToWrite(string FilePath, string FtpUserName, string FtpUserPassword)
        {
            FtpWebRequest RequestTowrite = (FtpWebRequest)WebRequest.Create(FilePath);
            RequestTowrite.Credentials = new NetworkCredential(FtpUserName, FtpUserPassword);
            RequestTowrite.Method = WebRequestMethods.Ftp.UploadFile;
            RequestTowrite.UseBinary = true;
            return (RequestTowrite.GetRequestStream());
        }
    }
}