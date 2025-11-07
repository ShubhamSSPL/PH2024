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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ARCModule
{
    public partial class frmConfirmSeatAcceptanceForm : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        AzureDocumentUpload objDU = new AzureDocumentUpload();
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
                    DataSet dsSeatAcceptanceFeeList = reg.getSeatAcceptanceFeeList(PID, "Seat Acceptance Fee");
                    DataSet dsDocumentList = reg.getDocumentList(PID, "Y");

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
                    else
                    {
                        shInfo.SetMessage("This Candidate has not given Seat Acceptance Status. Please ask the Candidate to give Seat Acceptance Status.", ShowMessageType.Information);
                        btnProceed.Visible = false;
                    }

                    if (dsSeatAcceptanceFeeList.Tables[0].Rows.Count > 0)
                    {
                        tblSeatAcceptanceFeeDetails.Visible = true;

                        gvFeeDetails.DataSource = dsSeatAcceptanceFeeList;
                        gvFeeDetails.DataBind();
                    }
                    else
                    {
                        shInfo.SetMessage("This Candidate has not paid Seat Acceptance Fee. Please ask the Candidate to Pay Seat Acceptance Fee.", ShowMessageType.Information);
                        btnProceed.Visible = false;
                    }

                    gvDocuments.DataSource = dsDocumentList;
                    gvDocuments.DataBind();

                    for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                    {
                        gvDocuments.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidFURL = (HiddenField)e.Row.FindControl("hidFURL");
                if (hidFURL.Value != "")
                {
                    string ext = System.IO.Path.GetExtension(hidFURL.Value).ToLower();
                    HtmlImage imgDoc = (HtmlImage)e.Row.FindControl("imgDoc");
                    HiddenField hidDID = (HiddenField)e.Row.FindControl("hidDID");
                    HtmlAnchor hrefURL = (HtmlAnchor)e.Row.FindControl("hrefURL");
                    HiddenField hdnImgByteArray = (HiddenField)e.Row.FindControl("hdnImgByteArray");
                    hrefURL.HRef = ConfigurationManager.AppSettings["ApplicationURL"] + "ViewMyDocument.aspx?documentID=" + hidDID.Value;
                    if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".bmp")
                    {
                        string url = hidFURL.Value;
                        if (hidFURL.Value.Contains("studentdocuments"))
                        {
                            url = hidFURL.Value.Replace("studentdocuments", "studentdocumentsthumbnail");
                            string checkurl = url.Replace(ConfigurationManager.AppSettings["HttpAddress"], "");
                            if (!objDU.Exists(checkurl))
                            {
                                url = hidFURL.Value;
                            }
                        }
                        string base64 = objDU.GetBlobContentAsBase64("studentdocumentsthumbnail", url);//objDU.ConvertImageURLToBase64(url);
                        imgDoc.Src = base64; //"data:image/png;base64," +
                    }
                    else if (ext == ".pdf")
                    {
                        imgDoc.Src = "../images/pdf.gif";
                    }
                    else if (ext == ".zip" || ext == ".rar")
                    {
                        hrefURL.Target = "self";
                        imgDoc.Src = "../images/zip.png";
                    }
                    hdnImgByteArray.Value = objDU.GetBlobContentAsBase64("studentdocuments", hidFURL.Value.ToString());

                }
                if (((Label)e.Row.Cells[5].FindControl("lblIsSubmitted")).Text == "N")
                {
                    ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = false;
                    ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = true;
                }
                else
                {
                    ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = true;
                    ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = false;
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                Int32 IsAllDocumentsSubmitted = 1;

                string XMLstring = "<DocumentList>";
                for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                {
                    string DocumentID = ((Label)gvDocuments.Rows[i].FindControl("lblDocumentID")).Text;

                    if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                    {
                        XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtARC=\"" + "Y" + "\"></Document>";
                    }
                    else
                    {
                        XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtARC=\"" + "N" + "\"></Document>";
                        IsAllDocumentsSubmitted = 0;
                    }
                }
                XMLstring += "</DocumentList>";

                if (IsAllDocumentsSubmitted == 1)
                {
                    if (Session["UserTypeID"].ToString() == "91")
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageARC.aspx");
                    }
                    else
                    {
                        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                        if (UserTypeID == 21 || UserTypeID == 22 || UserTypeID == 33 || UserTypeID == 34)
                        {
                            if (reg.confirmSeatAcceptanceForm(PID, XMLstring, txtComments.Text, Global.CAPRound, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                            {
                                if (Global.SendSMSToCandidate == 1)
                                {
                                    DataSet ds = reg.getSeatAcceptanceStatusDetails(PID);
                                    if (ds != null && ds.Tables.Count > 0)
                                    {
                                        SMSTemplate sMSTemplate = new SMSTemplate();
                                        SynCommon synCommon = new SynCommon();
                                        sMSTemplate.PID = PID;
                                        sMSTemplate.ReportedBy = ds.Tables[0].Rows[0]["ReportedBy"].ToString();
                                        sMSTemplate.ReportedDateTime = ds.Tables[0].Rows[0]["ReportedDateTime"].ToString();
                                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.CancelSeatAcceptance);
                                    }
                                }
                                Response.Redirect("../ARCModule/frmSeatAcceptanceAcknowledgement.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
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
                }
                else
                {
                    shInfo.SetMessage("All Documents Shown in the List is Not Verified. Please verify All Documents.", ShowMessageType.Information);
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