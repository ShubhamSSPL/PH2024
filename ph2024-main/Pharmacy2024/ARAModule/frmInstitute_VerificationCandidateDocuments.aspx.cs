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

namespace Pharmacy2024.ARAModule
{
    public partial class frmInstitute_VerificationCandidateDocuments : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string JEEName = Global.NEETName;
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string MHTCETName = Global.MHTCETName;
        AzureDocumentUpload objDU = new AzureDocumentUpload();
       
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    AzureDocumentUpload azObj = new AzureDocumentUpload();
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                    hdnApplicationURL.Value = ConfigurationManager.AppSettings["ApplicationURL"];
                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }
                    PersonalInformation obj = reg.getPersonalInformation(PID);
                    Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(PID);
                    //Int32 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                    //Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);
                    //Int32 ApplicationFeePaid = reg.getApplicationFeePaidAmount(PID);
                    Int32 CandidatureTypeID = 1;//-- obj.FinalCandidatureTypeID;
                    Int64 CETApplicationFormNo = obj.CETApplicationFormNo;
                    Int32 ApplicationFeePaid = obj.CETApplicationFee + obj.OnlineApplicationFee;

                    string EligibilityRemark = "";//-- reg.getEligibilityFlag(PID);
                    if (EligibilityRemark.Length > 0)
                    {
                        shInfo.SetMessage(EligibilityRemark, ShowMessageType.Information);
                        btnProceed.Visible = false;
                    }
                    AjaxPro.Utility.RegisterTypeForAjax(typeof(frmInstitute_VerificationCandidateDocuments));
                    lblApplicationID.Text = obj.ApplicationID;
                    //lblVersionNo.Text = obj.VersionNo.ToString();
                    //lblLastModifiedOn.Text = obj.LastModifiedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", obj.LastModifiedOn);

                    imgPhotograph.ImageUrl = azObj.GetBlobContentAsBase64("Photograph", UserInfo.GetImageURL(PID, "Photograph"));

                    lblCandidateName.Text = obj.CandidateName;
                    lblFatherName.Text = obj.FatherName;
                    lblMotherName.Text = obj.MotherName;
                    lblGender.Text = obj.Gender;
                    lblDOB.Text = obj.DOB;
                    lblCandidatureType.Text = obj.FinalCandidatureType;
                    lblHomeUniversity.Text = obj.FinalHomeUniversity;
                    lblOriginalCategory.Text = obj.Category;
                    lblCategoryForAdmission.Text = obj.FinalCategory;
                    lblAppliedForEWS.Text = obj.FinalAppliedForEWS;
                    lblPHType.Text = obj.FinalPHType;
                    lblDefenceType.Text = obj.FinalDefenceType;
                    lblIsOrphan.Text = obj.FinalIsOrphan;
                    lblAppliedForTFWS.Text = obj.FinalAppliedForTFWS;
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
                    if (CandidatureTypeID == 1)
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;

                        lblQ1.Text = "District from which Candidate has Passed SSC";
                        lblQ2.Text = "District from which Candidate has Passed HSC / Diploma in Pharmacy";
                        lblDistrict1.Text = obj.SSCDistrict;
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (CandidatureTypeID == 2)
                    {
                        trDistrict1.Visible = false;

                        lblDocumentOfHead.Text = "Whose Domicile Cerificate You are Submitting at SC?";
                        lblDocumentOf.Text = obj.DocumentOf;
                        if (obj.DocumentOf == "Mother")
                        {
                            lblMothersName.Text = obj.MothersName;
                        }
                        else
                        {
                            trMothersName.Visible = false;
                        }
                        lblQ2.Text = "District where Candidate / Father or Mother of Candidate is Domiciled";
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (CandidatureTypeID == 3)
                    {
                        trDistrict1.Visible = false;
                        trMothersName.Visible = false;

                        lblDocumentOfHead.Text = "Whose Proforma - A You are Submitting at SC?";
                        lblDocumentOf.Text = obj.DocumentOf;
                        lblQ2.Text = "District where Father or Mother of Candidate is Posted";
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (CandidatureTypeID == 4)
                    {
                        trDistrict1.Visible = false;
                        trMothersName.Visible = false;

                        lblDocumentOfHead.Text = "Whose Proforma - B / Undertaking for Place of Settlement You are Submitting at SC?";
                        lblDocumentOf.Text = obj.DocumentOf;
                        lblQ2.Text = "District where Father or Mother of Candidate is Posted / Settled after Retirement";
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else if (CandidatureTypeID == 5)
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;

                        lblQ1.Text = "District from which Candidate has Passed SSC";
                        lblQ2.Text = "District from which Candidate has Passed HSC / Diploma in Pharmacy";
                        lblDistrict1.Text = obj.SSCDistrict;
                        lblDistrict2.Text = obj.HSCDistrict;
                    }
                    else
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;
                        trDistrict1.Visible = false;
                        trDistrict2.Visible = false;
                    }
                    lblApplicationFeePaidAmount.Text = obj.CETApplicationFee.ToString() + "/-";
                    lblOnlineApplicationFee.Text = obj.OnlineApplicationFee.ToString() + "/-";
                    lblNationality.Text = obj.Nationality;
                    if (obj.QualifyingExam == "Diploma" || obj.QualifyingExam == "B.Sc.")
                    {
                        if (obj.SSCMathMarksObtained > 0)
                        {
                            lblSSCMathMarksObtained.Text = obj.SSCMathMarksObtained.ToString();
                            lblSSCMathMarksOutOf.Text = obj.SSCMathMarksOutOf.ToString();
                            lblSSCMathPercentage.Text = obj.SSCMathPercentage.ToString();
                        }
                        else
                        {
                            lblSSCMathMarksObtained.Text = "-";
                            lblSSCMathMarksOutOf.Text = "-";
                            lblSSCMathPercentage.Text = "-";
                        }
                        if (obj.SSCScienceMarksObtained > 0)
                        {
                            lblSSCScienceMarksObtained.Text = obj.SSCScienceMarksObtained.ToString();
                            lblSSCScienceMarksOutOf.Text = obj.SSCScienceMarksOutOf.ToString();
                            lblSSCSciencePercentage.Text = obj.SSCSciencePercentage.ToString();
                        }
                        else
                        {
                            lblSSCScienceMarksObtained.Text = "-";
                            lblSSCScienceMarksOutOf.Text = "-";
                            lblSSCSciencePercentage.Text = "-";
                        }
                        if (obj.SSCEnglishMarksObtained > 0)
                        {
                            lblSSCEnglishMarksObtained.Text = obj.SSCEnglishMarksObtained.ToString();
                            lblSSCEnglishMarksOutOf.Text = obj.SSCEnglishMarksOutOf.ToString();
                            lblSSCEnglishPercentage.Text = obj.SSCEnglishPercentage.ToString();
                        }
                        else
                        {
                            lblSSCEnglishMarksObtained.Text = "-";
                            lblSSCEnglishMarksOutOf.Text = "-";
                            lblSSCEnglishPercentage.Text = "-";
                        }
                        lblSSCTotalMarksObtained.Text = obj.SSCTotalMarksObtained.ToString();
                        lblSSCTotalMarksOutOf.Text = obj.SSCTotalMarksOutOf.ToString();
                        lblSSCTotalPercentage.Text = obj.SSCTotalPercentage.ToString();
                    }
                    else
                    {
                        trSSCMathematicsMarks.Visible = false;
                        trSSCScienceMarks.Visible = false;
                        trSSCEnglishMarks.Visible = false;
                        trSSCTotalMarks.Visible = false;
                    }
                    lblHSCPhysicsMarksObtained.Text = obj.HSCPhysicsMarksObtained.ToString();
                    lblHSCPhysicsMarksOutOf.Text = obj.HSCPhysicsMarksOutOf.ToString();
                    lblHSCPhysicsPercentage.Text = obj.HSCPhysicsPercentage.ToString();
                    lblHSCChemistryMarksObtained.Text = obj.HSCChemistryMarksObtained.ToString();
                    lblHSCChemistryMarksOutOf.Text = obj.HSCChemistryMarksOutOf.ToString();
                    lblHSCChemistryPercentage.Text = obj.HSCChemistryPercentage.ToString();
                    lblHSCMathMarksObtained.Text = obj.HSCMathMarksObtained.ToString();
                    lblHSCMathMarksOutOf.Text = obj.HSCMathMarksOutOf.ToString();
                    lblHSCMathPercentage.Text = obj.HSCMathPercentage.ToString();
                    lblHSCSubject.Text = obj.HSCSubject;
                    lblHSCSubjectMarksObtained.Text = obj.HSCSubjectMarksObtained.ToString();
                    lblHSCSubjectMarksOutOf.Text = obj.HSCSubjectMarksOutOf.ToString();
                    lblHSCSubjectPercentage.Text = obj.HSCSubjectPercentage.ToString();
                    lblHSCEnglishMarksObtained.Text = obj.HSCEnglishMarksObtained.ToString();
                    lblHSCEnglishMarksOutOf.Text = obj.HSCEnglishMarksOutOf.ToString();
                    lblHSCEnglishPercentage.Text = obj.HSCEnglishPercentage.ToString();
                    lblHSCTotalMarksObtained.Text = obj.HSCTotalMarksObtained.ToString();
                    lblHSCTotalMarksOutOf.Text = obj.HSCTotalMarksOutOf.ToString();
                    lblHSCTotalPercentage.Text = obj.HSCTotalPercentage.ToString();
                    lblSSCBoard.Text = obj.SSCBoard;
                    lblSSCPassingYear.Text = obj.SSCPassingYear;
                    lblSSCSeatNo.Text = obj.SSCSeatNo;
                    lblQualifyingExam.Text = obj.QualifyingExam;
                    lblNameAsPerHSCResult.Text = obj.NameAsPerHSCResult + " " + "<font color = 'red' size='2'>(Name As Per HSC Result)</font>";
                    if (obj.QualifyingExam == "Diploma")
                    {
                        lblQualifyingExam.Text = "Diploma in Pharmacy";
                        lblNameAsPerHSCResult.Visible = false;
                    }
                    lblHSCPassingStatus.Text = obj.HSCPassingStatus;
                    lblHSCBoard.Text = obj.HSCBoard;
                    lblHSCPassingYear.Text = SynCommon.GetPassingYear(obj.HSCPassingYear);
                    lblHSCSeatNo.Text = obj.HSCSeatNo;

                    if (obj.QualifyingExam == "Diploma" || obj.QualifyingExam == "B.Sc.")
                    {
                        trHSCPhysicsMarks.Visible = false;
                        trHSCChemistryMarks.Visible = false;
                        trHSCMathMarks.Visible = false;
                        trHSCSubjectMarks.Visible = false;
                        trHSCEnglishMarks.Visible = false;

                        if (obj.DiplomaMarksType == "CGPA")
                        {
                            lblHSCTotalMarks.Text = obj.QualifyingExam + " CGPA";
                        }
                        else
                        {
                            lblHSCTotalMarks.Text = obj.QualifyingExam + " Aggregate Marks";
                        }
                        lblHSCPassingStatusHeader.Text = obj.QualifyingExam + " Passing Status";
                        lblHSCBoardHeader.Text = obj.QualifyingExam + " Board / University";
                        lblHSCPassingYearHeader.Text = obj.QualifyingExam + " Passing Year";
                        lblHSCSeatNoHeader.Text = obj.QualifyingExam + " Seat Number";
                    }
                    else
                    {
                        if (obj.HSCSubject == "Not Applicable")
                        {
                            trHSCSubjectMarks.Visible = false;
                        }
                    }
                    DataSet dsCETResult = reg.getCETDetails(CETApplicationFormNo);
                    if (dsCETResult.Tables[0].Rows.Count > 0)
                    {
                        if (dsCETResult.Tables[0].Rows[0]["IsCandidateGivenCET"].ToString() == "Y")
                        {
                            lblAppearedForCETHeader.Text = "Application Number";
                            lblAppearedForCET.Text = dsCETResult.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();

                            lblCETRollNo.Text = dsCETResult.Tables[0].Rows[0]["CETRollNo"].ToString();
                            lblCETPhysicsScore.Text = dsCETResult.Tables[0].Rows[0]["CETPhysicsMarks"].ToString();
                            lblCETChemistryScore.Text = dsCETResult.Tables[0].Rows[0]["CETChemistryMarks"].ToString();
                            lblCETMathScore.Text = dsCETResult.Tables[0].Rows[0]["CETMathMarks"].ToString();
                            lblCETTotalScore.Text = dsCETResult.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString();

                            StringMatching stringMatching = new StringMatching();
                            int matchingPercentage = stringMatching.CheckString(obj.CandidateName, obj.CETCandidateName);

                            if (matchingPercentage == 0)
                            {
                                lblCETCandidateName.Text = obj.CETCandidateName + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result) [Not Matching]</font>";
                            }
                            else if (matchingPercentage == 50 && matchingPercentage < 100)
                            {
                                lblCETCandidateName.Text = obj.CETCandidateName + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result) [Partially Matching]</font>";
                            }
                            else
                            {
                                lblCETCandidateName.Text = obj.CETCandidateName + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result)</font>";
                            }
                            //lblCETCandidateName.Text = dsCETResult.Tables[0].Rows[0]["CandidateName"].ToString() + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result)</font>";
                            lblCETCandidateName.ForeColor = System.Drawing.Color.Blue;
                        }
                        else
                        {
                            lblAppearedForCET.Text = "No";
                            lblCETRollNoHeader.Text = "";
                            trCETScore1.Visible = false;
                            trCETScore2.Visible = false;
                            lblCETCandidateName.Visible = false;
                        }
                    }
                    else
                    {
                        lblAppearedForCET.Text = "No";
                        lblCETRollNoHeader.Text = "";
                        trCETScore1.Visible = false;
                        trCETScore2.Visible = false;
                    }
                     lblAppearedForJEE.Text = obj.AppearedForJEE;
                    if (obj.AppearedForJEE == "Yes")
                    {
                        lblJEERollNo.Text = obj.JEERollNo.ToString();
                        lblJEEPhysicsScore.Text = obj.JEEPhysicsScore.ToString();
                        lblJEEChemistryScore.Text = obj.JEEChemistryScore.ToString();
                        lblJEEMathScore.Text = obj.JEEMathScore.ToString();
                        lblJEETotalScore.Text = obj.JEETotalScore.ToString();

                        StringMatching stringMatching = new StringMatching();
                        int matchingPercentage = stringMatching.CheckString(obj.CandidateName, obj.NEETCName);

                        if (matchingPercentage == 0)
                        {
                            lblJEEName.Text = obj.NEETCName + " " + "<font color = 'red' size='2'>(Name As Per NEET Result) [Not Matching]</font>";
                        }
                        else if (matchingPercentage == 50 && matchingPercentage < 100)
                        {
                            lblJEEName.Text = obj.NEETCName + " " + "<font color = 'red' size='2'>(Name As Per NEET Result) [Partially Matching]</font>";
                        }
                        else
                        {
                            lblJEEName.Text = obj.NEETCName + " " + "<font color = 'red' size='2'>(Name As Per NEET Result)</font>";
                        }

                        lblJEEName.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        lblJEEName.Visible = false;
                        lblJEERollNoHeader.Text = "";
                        trJEEScore1.Visible = false;
                        trJEEScore2.Visible = false;
                    }

                    if (Session["UserTypeID"].ToString() == "22" || Session["UserTypeID"].ToString() == "31")
                    {
                        gvDocuments.DataSource = reg.GetDocumentListForInstituteToRo(PID);
                        gvDocuments.DataBind();
                        btnProceed.Text = "Send To ARA";
                    }
                    else if (Session["UserTypeID"].ToString() == "61" || Session["UserTypeID"].ToString() == "62")
                    {
                        gvDocuments.DataSource = reg.GetDocumentListForInstituteToRo(PID);
                        gvDocuments.DataBind();
                        btnProceed.Text = "Verify Confirmed";
                    }
                    else
                    {
                        gvDocuments.DataSource = reg.GetDocumentListForInstituteToRo(PID);
                        gvDocuments.DataBind();
                    }
                       

                    for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                    {
                        gvDocuments.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    }

                    showDataInPopUp(PID);// Newly Added for PopUp Info Display
                }
                catch(Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
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

                if (((HiddenField)e.Row.Cells[7].FindControl("hdnImgUrl")).Value.Length > 0)
                {
                    if (Session["UserTypeID"].ToString() == "22" || Session["UserTypeID"].ToString() == "31")
                    {
                        if (((Label)e.Row.Cells[6].FindControl("lblROIsSubmitted")).Text == "N")
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
                    else if (Session["UserTypeID"].ToString() == "61" || Session["UserTypeID"].ToString() == "62")
                    {
                        if (((Label)e.Row.Cells[7].FindControl("lblARAIsSubmitted")).Text == "N")
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
                    else
                    {
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
                else
                {
                    ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = false;
                    ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = true;
                    ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Enabled = false;
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                string InstituteByRemark = txtRemark.Text;
                string XMLstring = "<DocumentList>";
                for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                {
                    string DocumentID = ((Label)gvDocuments.Rows[i].FindControl("lblDocumentID")).Text;

                    if (Session["UserTypeID"].ToString() == "22" || Session["UserTypeID"].ToString() == "31")
                    {
                        if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                        {
                            XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedByRo=\"" + "Y" + "\"></Document>";
                        }
                        else
                        {
                            XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedByRo=\"" + "N" + "\"></Document>";
                        }
                    }
                    else if (Session["UserTypeID"].ToString() == "61" || Session["UserTypeID"].ToString() == "62")
                    {
                        if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                        {
                            XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsVerifyByAra=\"" + "Y" + "\"></Document>";
                        }
                        else
                        {
                            XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsVerifyByAra=\"" + "N" + "\"></Document>";
                        }
                    }
                    else
                    {
                        if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                        {
                            XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedByInstituteForRo=\"" + "Y" + "\"></Document>";
                        }
                        else
                        {
                            XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedByInstituteForRo=\"" + "N" + "\"></Document>";
                        }
                    }
                        
                }
                XMLstring += "</DocumentList>";
                

                if (reg.UpdateDocumentSubmissionForInstituteToRo(PID, XMLstring, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), InstituteByRemark))
                {
                    Response.Redirect("../ARAModule/frmInstitute_ChoiceCodWiseCandidateList?ChoiceCode="+ChoiceCode + "&ChoiceCodeDisplay=" + ChoiceCodeDisplay, true);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        private void showDataInPopUp(Int64 PID)
        {
            PersonalInformation obj = reg.getPersonalInformation(PID);
            Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(PID);
            //Int32 CandidatureTypeID = reg.getCandidatureTypeID(PID);
            //Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);
            //Int32 ApplicationFeePaid = reg.getApplicationFeePaidAmount(PID);
            Int32 CandidatureTypeID = 1;//-- obj.FinalCandidatureTypeID;
            Int64 CETApplicationFormNo = obj.CETApplicationFormNo;
            Int32 ApplicationFeePaid = obj.CETApplicationFee + obj.OnlineApplicationFee;

            //string EligibilityRemark = reg.getEligibilityFlag(PID);
            //if (EligibilityRemark.Length > 0)
            //{
            //    shInfo.SetMessage(EligibilityRemark, ShowMessageType.Information);
            //    btnProceed.Visible = false;
            //}
            //AjaxPro.Utility.RegisterTypeForAjax(typeof(frmInstitute_VerificationCandidateDocuments));
            //lblApplicationID.Text = obj.ApplicationID;
            //lblVersionNo.Text = obj.VersionNo.ToString();
            //lblLastModifiedOn.Text = obj.LastModifiedOn.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", obj.LastModifiedOn);

            //imgPhotograph.ImageUrl = UserInfo.GetImageURL(PID, "Photograph");

            lblCandidateNamePopUp.Text = obj.CandidateName;
            lblFatherNamePopUp.Text = obj.FatherName;
            lblMotherNamePopUp.Text = obj.MotherName;
            lblGenderPopUp.Text = obj.Gender;
            lblDOBPopUp.Text = obj.DOB;
            lblCandidatureTypePopUp.Text = obj.FinalCandidatureType;
            lblHomeUniversityPopUp.Text = obj.FinalHomeUniversity;
            lblOriginalCategoryPopUp.Text = obj.Category;
            lblCategoryForAdmissionPopUp.Text = obj.FinalCategory;
            lblAppliedForEWSPopUp.Text = obj.FinalAppliedForEWS;
            lblPHTypePopUp.Text = obj.FinalPHType;
            lblDefenceTypePopUp.Text = obj.FinalDefenceType;
            lblIsOrphanPopUp.Text = obj.FinalIsOrphan;
            lblAppliedForTFWSPopUp.Text = obj.FinalAppliedForTFWS;
            if (obj.AppliedForMinoritySeats == "Yes")
            {
                if (obj.FinalLinguisticMinorityDetails == "Not Applicable" && obj.FinalReligiousMinorityDetails == "Not Applicable")
                {
                    lblAppliedForMinoritySeatsPopUp.Text = "No <font color='red' size='0.7'><sup> (As you have not submitted required documents.)</sup></font>";
                }
                else if (obj.FinalLinguisticMinorityDetails != "Not Applicable" && obj.FinalReligiousMinorityDetails != "Not Applicable")
                {
                    lblAppliedForMinoritySeatsPopUp.Text = obj.AppliedForMinoritySeats + " - " + obj.FinalLinguisticMinorityDetails + ", " + obj.FinalReligiousMinorityDetails;
                }
                else if (obj.FinalLinguisticMinorityDetails != "Not Applicable" && obj.FinalReligiousMinorityDetails == "Not Applicable")
                {
                    lblAppliedForMinoritySeatsPopUp.Text = obj.AppliedForMinoritySeats + " - " + obj.FinalLinguisticMinorityDetails;
                }
                else if (obj.FinalLinguisticMinorityDetails == "Not Applicable" && obj.FinalReligiousMinorityDetails != "Not Applicable")
                {
                    lblAppliedForMinoritySeatsPopUp.Text = obj.AppliedForMinoritySeats + " - " + obj.FinalReligiousMinorityDetails;
                }
            }
            else
            {
                lblAppliedForMinoritySeatsPopUp.Text = obj.AppliedForMinoritySeats;
            }
            if (CandidatureTypeID == 1)
            {
                trDocumentOfPopUp.Visible = false;
                trMothersNamePopUp.Visible = false;

                lblQ1PopUp.Text = "District from which Candidate has Passed SSC";
                lblQ2PopUp.Text = "District from which Candidate has Passed HSC / Diploma in Pharmacy";
                lblDistrict1PopUp.Text = obj.SSCDistrict;
                lblDistrict2PopUp.Text = obj.HSCDistrict;
            }
            else if (CandidatureTypeID == 2)
            {
                trDistrict1PopUp.Visible = false;

                lblDocumentOfHeadPopUp.Text = "Whose Domicile Cerificate You are Submitting at SC?";
                lblDocumentOfPopUp.Text = obj.DocumentOf;
                if (obj.DocumentOf == "Mother")
                {
                    lblMothersNamePopUp.Text = obj.MothersName;
                }
                else
                {
                    trMothersNamePopUp.Visible = false;
                }
                lblQ2PopUp.Text = "District where Candidate / Father or Mother of Candidate is Domiciled";
                lblDistrict2PopUp.Text = obj.HSCDistrict;
            }
            else if (CandidatureTypeID == 3)
            {
                trDistrict1PopUp.Visible = false;
                trMothersNamePopUp.Visible = false;

                lblDocumentOfHeadPopUp.Text = "Whose Proforma - A You are Submitting at SC?";
                lblDocumentOfPopUp.Text = obj.DocumentOf;
                lblQ2PopUp.Text = "District where Father or Mother of Candidate is Posted";
                lblDistrict2PopUp.Text = obj.HSCDistrict;
            }
            else if (CandidatureTypeID == 4)
            {
                trDistrict1PopUp.Visible = false;
                trMothersNamePopUp.Visible = false;

                lblDocumentOfHeadPopUp.Text = "Whose Proforma - B / Undertaking for Place of Settlement You are Submitting at SC?";
                lblDocumentOfPopUp.Text = obj.DocumentOf;
                lblQ2PopUp.Text = "District where Father or Mother of Candidate is Posted / Settled after Retirement";
                lblDistrict2PopUp.Text = obj.HSCDistrict;
            }
            else if (CandidatureTypeID == 5)
            {
                trDocumentOfPopUp.Visible = false;
                trMothersNamePopUp.Visible = false;

                lblQ1PopUp.Text = "District from which Candidate has Passed SSC";
                lblQ2PopUp.Text = "District from which Candidate has Passed HSC / Diploma in Pharmacy";
                lblDistrict1PopUp.Text = obj.SSCDistrict;
                lblDistrict2PopUp.Text = obj.HSCDistrict;
            }
            else
            {
                trDocumentOfPopUp.Visible = false;
                trMothersNamePopUp.Visible = false;
                trDistrict1PopUp.Visible = false;
                trDistrict2PopUp.Visible = false;
            }
            lblApplicationFeePaidAmountPopUp.Text = obj.CETApplicationFee.ToString() + "/-";
            lblOnlineApplicationFeePopUp.Text = obj.OnlineApplicationFee.ToString() + "/-";
            lblNationalityPopUp.Text = obj.Nationality;

            if (obj.QualifyingExam == "Diploma" || obj.QualifyingExam == "B.Sc.")
            {
                if (obj.SSCMathMarksObtained > 0)
                {
                    lblSSCMathMarksObtainedPopUp.Text = obj.SSCMathMarksObtained.ToString();
                    lblSSCMathMarksOutOfPopUp.Text = obj.SSCMathMarksOutOf.ToString();
                    lblSSCMathPercentagePopUp.Text = obj.SSCMathPercentage.ToString();
                }
                else
                {
                    lblSSCMathMarksObtainedPopUp.Text = "-";
                    lblSSCMathMarksOutOfPopUp.Text = "-";
                    lblSSCMathPercentagePopUp.Text = "-";
                }
                if (obj.SSCScienceMarksObtained > 0)
                {
                    lblSSCScienceMarksObtainedPopUp.Text = obj.SSCScienceMarksObtained.ToString();
                    lblSSCScienceMarksOutOfPopUp.Text = obj.SSCScienceMarksOutOf.ToString();
                    lblSSCSciencePercentagePopUp.Text = obj.SSCSciencePercentage.ToString();
                }
                else
                {
                    lblSSCScienceMarksObtainedPopUp.Text = "-";
                    lblSSCScienceMarksOutOfPopUp.Text = "-";
                    lblSSCSciencePercentagePopUp.Text = "-";
                }
                if (obj.SSCEnglishMarksObtained > 0)
                {
                    lblSSCEnglishMarksObtainedPopUp.Text = obj.SSCEnglishMarksObtained.ToString();
                    lblSSCEnglishMarksOutOfPopUp.Text = obj.SSCEnglishMarksOutOf.ToString();
                    lblSSCEnglishPercentagePopUp.Text = obj.SSCEnglishPercentage.ToString();
                }
                else
                {
                    lblSSCEnglishMarksObtainedPopUp.Text = "-";
                    lblSSCEnglishMarksOutOfPopUp.Text = "-";
                    lblSSCEnglishPercentagePopUp.Text = "-";
                }
                lblSSCTotalMarksObtainedPopUp.Text = obj.SSCTotalMarksObtained.ToString();
                lblSSCTotalMarksOutOfPopUp.Text = obj.SSCTotalMarksOutOf.ToString();
                lblSSCTotalPercentagePopUp.Text = obj.SSCTotalPercentage.ToString();
            }
            else
            {
                trSSCMathematicsMarksPopUp.Visible = false;
                trSSCScienceMarksPopUp.Visible = false;
                trSSCEnglishMarksPopUp.Visible = false;
                trSSCTotalMarksPopUp.Visible = false;
            }
            lblHSCPhysicsMarksObtainedPopUp.Text = obj.HSCPhysicsMarksObtained.ToString();
            lblHSCPhysicsMarksOutOfPopUp.Text = obj.HSCPhysicsMarksOutOf.ToString();
            lblHSCPhysicsPercentagePopUp.Text = obj.HSCPhysicsPercentage.ToString();
            lblHSCChemistryMarksObtainedPopUp.Text = obj.HSCChemistryMarksObtained.ToString();
            lblHSCChemistryMarksOutOfPopUp.Text = obj.HSCChemistryMarksOutOf.ToString();
            lblHSCChemistryPercentagePopUp.Text = obj.HSCChemistryPercentage.ToString();
            lblHSCMathMarksObtainedPopUp.Text = obj.HSCMathMarksObtained.ToString();
            lblHSCMathMarksOutOfPopUp.Text = obj.HSCMathMarksOutOf.ToString();
            lblHSCMathPercentagePopUp.Text = obj.HSCMathPercentage.ToString();
            lblHSCSubjectPopUp.Text = obj.HSCSubject;
            lblHSCSubjectMarksObtainedPopUp.Text = obj.HSCSubjectMarksObtained.ToString();
            lblHSCSubjectMarksOutOfPopUp.Text = obj.HSCSubjectMarksOutOf.ToString();
            lblHSCSubjectPercentagePopUp.Text = obj.HSCSubjectPercentage.ToString();
            lblHSCEnglishMarksObtainedPopUp.Text = obj.HSCEnglishMarksObtained.ToString();
            lblHSCEnglishMarksOutOfPopUp.Text = obj.HSCEnglishMarksOutOf.ToString();
            lblHSCEnglishPercentagePopUp.Text = obj.HSCEnglishPercentage.ToString();
            lblHSCTotalMarksObtainedPopUp.Text = obj.HSCTotalMarksObtained.ToString();
            lblHSCTotalMarksOutOfPopUp.Text = obj.HSCTotalMarksOutOf.ToString();
            lblHSCTotalPercentagePopUp.Text = obj.HSCTotalPercentage.ToString();
            lblSSCBoardPopUp.Text = obj.SSCBoard;
            lblSSCPassingYearPopUp.Text = obj.SSCPassingYear;
            lblSSCSeatNoPopUp.Text = obj.SSCSeatNo;
            lblQualifyingExamPopUp.Text = obj.QualifyingExam;
            lblNameAsPerHSCResultPopUp.Text = obj.NameAsPerHSCResult + " " + "<font color = 'red' size='2'>(Name As Per HSC Result)</font>";
            if (obj.QualifyingExam == "Diploma")
            {
                lblQualifyingExamPopUp.Text = "Diploma in Pharmacy";
                lblNameAsPerHSCResultPopUp.Visible = false;
            }
            lblHSCPassingStatusPopUp.Text = obj.HSCPassingStatus;
            lblHSCBoardPopUp.Text = obj.HSCBoard;
            lblHSCPassingYear.Text = SynCommon.GetPassingYear(obj.HSCPassingYear);
            lblHSCSeatNoPopUp.Text = obj.HSCSeatNo;

            if (obj.QualifyingExam == "Diploma" || obj.QualifyingExam == "B.Sc.")
            {
                trHSCPhysicsMarksPopUp.Visible = false;
                trHSCChemistryMarksPopUp.Visible = false;
                trHSCMathMarksPopUp.Visible = false;
                trHSCSubjectMarksPopUp.Visible = false;
                trHSCEnglishMarksPopUp.Visible = false;

                if (obj.DiplomaMarksType == "CGPA")
                {
                    lblHSCTotalMarksPopUp.Text = obj.QualifyingExam + " CGPA";
                }
                else
                {
                    lblHSCTotalMarksPopUp.Text = obj.QualifyingExam + " Aggregate Marks";
                }
                lblHSCPassingStatusHeaderPopUp.Text = obj.QualifyingExam + " Passing Status";
                lblHSCBoardHeaderPopUp.Text = obj.QualifyingExam + " Board / University";
                lblHSCPassingYearHeaderPopUp.Text = obj.QualifyingExam + " Passing Year";
                lblHSCSeatNoHeaderPopUp.Text = obj.QualifyingExam + " Seat Number";
            }
            else
            {
                if (obj.HSCSubject == "Not Applicable")
                {
                    trHSCSubjectMarksPopUp.Visible = false;
                }
            }

            DataSet dsCETResult = reg.getCETDetails(CETApplicationFormNo);
            if (dsCETResult.Tables[0].Rows.Count > 0)
            {
                if (dsCETResult.Tables[0].Rows[0]["IsCandidateGivenCET"].ToString() == "Y")
                {
                    lblAppearedForCETHeaderPopUp.Text = "Application Number";
                    lblAppearedForCETPopUp.Text = dsCETResult.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();

                    lblCETRollNoPopUp.Text = dsCETResult.Tables[0].Rows[0]["CETRollNo"].ToString();
                    lblCETPhysicsScorePopUp.Text = dsCETResult.Tables[0].Rows[0]["CETPhysicsMarks"].ToString();
                    lblCETChemistryScorePopUp.Text = dsCETResult.Tables[0].Rows[0]["CETChemistryMarks"].ToString();
                    lblCETMathScorePopUp.Text = dsCETResult.Tables[0].Rows[0]["CETMathMarks"].ToString();
                    lblCETTotalScorePopUp.Text = dsCETResult.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString();

                    StringMatching stringMatching = new StringMatching();
                    int matchingPercentage = stringMatching.CheckString(obj.CandidateName, obj.CETCandidateName);

                    if (matchingPercentage == 0)
                    {
                        lblCETCandidateName.Text = obj.CETCandidateName + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result) [Not Matching]</font>";
                    }
                    else if (matchingPercentage == 50 && matchingPercentage < 100)
                    {
                        lblCETCandidateName.Text = obj.CETCandidateName + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result) [Partially Matching]</font>";
                    }
                    else
                    {
                        lblCETCandidateName.Text = obj.CETCandidateName + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result)</font>";
                    }
                    //lblCETCandidateNamePopUp.Text = dsCETResult.Tables[0].Rows[0]["CandidateName"].ToString() + " " + "<font color = 'red' size='2'>(Name As Per MHTCET Result)</font>";
                    lblCETCandidateNamePopUp.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    lblAppearedForCETPopUp.Text = "No";
                    lblCETRollNoHeaderPopUp.Text = "";
                    trCETScore1PopUp.Visible = false;
                    trCETScore2PopUp.Visible = false;
                    lblCETCandidateNamePopUp.Visible = false;
                }
            }
            else
            {
                lblAppearedForCETPopUp.Text = "No";
                lblCETRollNoHeaderPopUp.Text = "";
                trCETScore1PopUp.Visible = false;
                trCETScore2PopUp.Visible = false;
            }
            lblAppearedForJEEPopUp.Text = obj.AppearedForJEE;
            if (obj.AppearedForJEE == "Yes")
            {
                lblJEERollNoPopUp.Text = obj.JEERollNo.ToString();
                lblJEEPhysicsScorePopUp.Text = obj.JEEPhysicsScore.ToString();
                lblJEEChemistryScorePopUp.Text = obj.JEEChemistryScore.ToString();
                lblJEEMathScorePopUp.Text = obj.JEEMathScore.ToString();
                lblJEETotalScorePopUp.Text = obj.JEETotalScore.ToString();
                lblJEENamePopUp.Text = obj.NEETCName.ToString() + " " + "<font color = 'red' size='2'>(Name As Per NEET Result)</font>";
                lblJEENamePopUp.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblJEENamePopUp.Visible = false;
                lblJEERollNoHeaderPopUp.Text = "";
                trJEEScore1PopUp.Visible = false;
                trJEEScore2PopUp.Visible = false;
            }
        }
    }
}