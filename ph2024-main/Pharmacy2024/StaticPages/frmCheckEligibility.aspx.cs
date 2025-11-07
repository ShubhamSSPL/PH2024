using BusinessLayer;
using EntityModel;
using OptionDropDownList;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmCheckEligibility : System.Web.UI.Page
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

            if (Session["UserLoginId"] != null)
            {
                this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPage.master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (!IsPostBack)
                {


                    txtHSCPhysicsMarksObtained.Attributes.Add("OnBlur", "hscPhysicsMarksChanged();");
                    txtHSCPhysicsMarksOutOf.Attributes.Add("OnBlur", "hscPhysicsMarksChanged();");
                    txtHSCChemistryMarksObtained.Attributes.Add("OnBlur", "hscChemistryMarksChanged();");
                    txtHSCChemistryMarksOutOf.Attributes.Add("OnBlur", "hscChemistryMarksChanged();");
                    //txtHSCMathMarksObtained.Attributes.Add("OnBlur", "hscMathMarksChanged();");
                    //txtHSCMathMarksOutOf.Attributes.Add("OnBlur", "hscMathMarksChanged();");
                    txtHSCSubjectMarksObtained.Attributes.Add("OnBlur", "hscSubjectMarksChanged();");
                    txtHSCSubjectMarksOutOf.Attributes.Add("OnBlur", "hscSubjectMarksChanged();");
                    txtHSCEnglishMarksObtained.Attributes.Add("OnBlur", "hscEnglishMarksChanged();");
                    txtHSCEnglishMarksOutOf.Attributes.Add("OnBlur", "hscEnglishMarksChanged();");
                    txtHSCTotalMarksObtained.Attributes.Add("OnBlur", "hscTotalMarksChanged();");
                    txtHSCTotalMarksOutOf.Attributes.Add("OnBlur", "hscTotalMarksChanged();");
                    ddlHSCSubject.Attributes.Add("onChange", "hscSubjectChanged()");

                    ddlCandidatureType.DataSource = Global.MasterCandidatureType;
                    ddlCandidatureType.DataTextField = "CandidatureTypeName";
                    ddlCandidatureType.DataValueField = "CandidatureTypeID";
                    ddlCandidatureType.DataBind();
                    ddlCandidatureType.Items.Insert(0, new ListItem("-- Select Candidature Type --", "0"));


                    ddlCategory.DataSource = Global.MasterCategory;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));

                    ddlPHType.DataSource = Global.MasterPHType;
                    ddlPHType.DataTextField = "PHTypeDetails";
                    ddlPHType.DataValueField = "PHTypeID";
                    ddlPHType.DataBind();

                    ddlCourse.DataSource = Global.MasterCourse;             //by Akshay
                    ddlCourse.DataTextField = "CourseName";
                    ddlCourse.DataValueField = "CourseCode";
                    ddlCourse.DataBind();
                    ddlCourse.Items.Insert(0, new ListItem("-- Select Course --", "0"));

                    DataSet ds = Global.MasterBoard;
                    //ddlHSCBoard.DataTextField = "BoardName";
                    //ddlHSCBoard.DataValueField = "BoardID";
                    //ddlHSCBoard.DataGroupField = "BoardState";
                    //ddlHSCBoard.DataBind();
                    //ListItem liHSCBoard = new ListItem("-- HSC Board --", "0");
                    //liHSCBoard.Attributes.Add("DataGroupField", "");
                    //ddlHSCBoard.Items.Insert(0, liHSCBoard);
                    List<OptionGroupItem> lista = new List<OptionGroupItem>();

                    if (ds != null)
                    {
                        OptionGroupItem items = new OptionGroupItem
                        {
                            Text = "-- HSC Board --",
                            Value = "0"
                        };
                        lista.Add(items);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                OptionGroupItem item = new OptionGroupItem
                                {
                                    Value = dr[0].ToString(),
                                    Text = dr[2].ToString(),
                                    OptionGroup = dr[1].ToString()
                                };
                                lista.Add(item);
                            }
                        }
                    }
                    ddlHSCBoard.DataSource = lista;

                    ddlHSCBoard.DataBind();
                    ContentTable2.Visible = true;
                    ContentBox1.Visible = false;

                    ddlHSCSubject.DataSource = Global.MasterHSCSubject;
                    ddlHSCSubject.DataTextField = "HSCSubjectName";
                    ddlHSCSubject.DataValueField = "HSCSubjectID";
                    ddlHSCSubject.DataBind();
                    ddlHSCSubject.Items.Insert(0, new ListItem("-- Select Subject --", "0"));

                    onPageLoad();
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlCandidatureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 CandidatureTypeID = Convert.ToInt32(ddlCandidatureType.SelectedValue);

                if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4)
                {
                    trCategory.Visible = true;
                    trAppliedForEWS2.Visible = false;
                    trPH.Visible = true;
                }
                else
                {
                    trCategory.Visible = false;
                    trAppliedForEWS2.Visible = false;
                    trPH.Visible = false;
                }

                ddlCategory.SelectedIndex = 0;
                ddlPHType.SelectedIndex = 0;
                ddlAppliedForEWS.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void QualifyingExam_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (rbnQualifyingExamDiploma.Checked)
                {
                    trHSCBoard.Visible = false;
                    trHSCMarksHeader.Visible = true;
                    trHSCPhysicsMarks.Visible = false;
                    trHSCChemistryMarks.Visible = false;
                    //trHSCMathMarks.Visible = false;
                    trHSCSubjectMarks.Visible = false;
                    trHSCEnglishMarks.Visible = false;
                    trHSCTotalMarks.Visible = true;

                    txtHSCTotalMarksObtained.Attributes.Add("onmouseover", "ddrivetip('Please Enter Diploma Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')");
                    txtHSCTotalMarksObtained.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksObtained.ErrorMessage = "Please Enter Diploma Aggregate Marks Obtained.";
                    revHSCTotalMarksObtained.ErrorMessage = "Diploma Aggregate Marks Obtained should be Numeric.";
                    cvHSCTotalMarksObtained.ErrorMessage = "Diploma Aggregate Marks Obtained should be less then or equal to Diploma Aggregate Marks OutOf.";
                    cvHSCTotalMarksObtainedZero.ErrorMessage = "Diploma Aggregate Marks Obtained should be greater than Zero.";

                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseover", "ddrivetip('Please Enter Diploma Aggregate Marks OutOf.')");
                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksOutOf.ErrorMessage = "Please Enter Diploma Aggregate Marks OutOf.";
                    revHSCTotalMarksOutOf.ErrorMessage = "Diploma Aggregate Marks OutOf should be Numeric.";
                }
                else if (rbnQualifyingExamBSc.Checked)
                {
                    trHSCBoard.Visible = false;
                    trHSCMarksHeader.Visible = true;
                    trHSCPhysicsMarks.Visible = false;
                    trHSCChemistryMarks.Visible = false;
                    //trHSCMathMarks.Visible = false;
                    trHSCSubjectMarks.Visible = false;
                    trHSCEnglishMarks.Visible = false;
                    trHSCTotalMarks.Visible = true;

                    txtHSCTotalMarksObtained.Attributes.Add("onmouseover", "ddrivetip('Please Enter B.Sc. Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')");
                    txtHSCTotalMarksObtained.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksObtained.ErrorMessage = "Please Enter B.Sc. Aggregate Marks Obtained.";
                    revHSCTotalMarksObtained.ErrorMessage = "B.Sc. Aggregate Marks Obtained should be Numeric.";
                    cvHSCTotalMarksObtained.ErrorMessage = "B.Sc. Aggregate Marks Obtained should be less then or equal to B.Sc. Aggregate Marks OutOf.";
                    cvHSCTotalMarksObtainedZero.ErrorMessage = "B.Sc. Aggregate Marks Obtained should be greater than Zero.";

                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseover", "ddrivetip('Please Enter B.Sc. Aggregate Marks OutOf.')");
                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksOutOf.ErrorMessage = "Please Enter B.Sc. Aggregate Marks OutOf.";
                    revHSCTotalMarksOutOf.ErrorMessage = "B.Sc. Aggregate Marks OutOf should be Numeric.";
                }
                else if (rbnQualifyingExamHSC.Checked)
                {
                    trHSCBoard.Visible = true;
                    trHSCMarksHeader.Visible = true;
                    trHSCPhysicsMarks.Visible = true;
                    trHSCChemistryMarks.Visible = true;
                    //trHSCMathMarks.Visible = true;
                    trHSCSubjectMarks.Visible = true;
                    trHSCEnglishMarks.Visible = true;
                    trHSCTotalMarks.Visible = true;

                    txtHSCTotalMarksObtained.Attributes.Add("onmouseover", "ddrivetip('Please Enter HSC Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')");
                    txtHSCTotalMarksObtained.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksObtained.ErrorMessage = "Please Enter HSC Aggregate Marks Obtained.";
                    revHSCTotalMarksObtained.ErrorMessage = "HSC Aggregate Marks Obtained should be Numeric.";
                    cvHSCTotalMarksObtained.ErrorMessage = "HSC Aggregate Marks Obtained should be less then or equal to HSC Aggregate Marks OutOf.";
                    cvHSCTotalMarksObtainedZero.ErrorMessage = "HSC Aggregate Marks Obtained should be greater than Zero.";

                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseover", "ddrivetip('Please Enter HSC Aggregate Marks OutOf.')");
                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksOutOf.ErrorMessage = "Please Enter HSC Aggregate Marks OutOf.";
                    revHSCTotalMarksOutOf.ErrorMessage = "HSC Aggregate Marks OutOf should be Numeric.";
                }
                else
                {
                    trHSCBoard.Visible = false;
                    trHSCMarksHeader.Visible = false;
                    trHSCPhysicsMarks.Visible = false;
                    trHSCChemistryMarks.Visible = false;
                    //trHSCMathMarks.Visible = false;
                    trHSCSubjectMarks.Visible = false;
                    trHSCEnglishMarks.Visible = false;
                    trHSCTotalMarks.Visible = false;
                }

                ddlHSCBoard.SelectedValue = "0";
                txtHSCPhysicsMarksObtained.Text = "";
                txtHSCPhysicsMarksOutOf.Text = "";
                txtHSCChemistryMarksObtained.Text = "";
                txtHSCChemistryMarksOutOf.Text = "";
                //txtHSCMathMarksObtained.Text = "";
                //txtHSCMathMarksOutOf.Text = "";
                txtHSCSubjectMarksObtained.Text = "";
                txtHSCSubjectMarksOutOf.Text = "";
                txtHSCEnglishMarksObtained.Text = "";
                txtHSCEnglishMarksOutOf.Text = "";
                txtHSCTotalMarksObtained.Text = "";
                txtHSCTotalMarksOutOf.Text = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlHSCBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                Int16 HSCBoardID = Convert.ToInt16(ddlHSCBoard.SelectedValue);

                //ddlHSCSubject.DataSource = reg.getMasterHSCSubject(HSCBoardID);
                //ddlHSCSubject.DataTextField = "HSCSubjectName";
                //ddlHSCSubject.DataValueField = "HSCSubjectID";
                //ddlHSCSubject.DataBind();

                ddlHSCSubject.DataSource = Global.MasterHSCSubject;
                ddlHSCSubject.DataTextField = "HSCSubjectName";
                ddlHSCSubject.DataValueField = "HSCSubjectID";
                ddlHSCSubject.DataBind();
                ddlHSCSubject.Items.Insert(0, new ListItem("-- Select Subject --", "0"));
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


                Int32 CandidatureTypeID = Convert.ToInt32(ddlCandidatureType.SelectedValue);
                if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4)
                {
                    trCategory.Visible = true;
                    trPH.Visible = true;
                    trAppliedForEWS2.Visible = false;
                }
                else
                {
                    trCategory.Visible = false;
                    trPH.Visible = false;
                    trAppliedForEWS2.Visible = false;
                }

                if (rbnQualifyingExamDiploma.Checked)
                {
                    trHSCBoard.Visible = false;
                    trHSCMarksHeader.Visible = true;
                    trHSCPhysicsMarks.Visible = false;
                    trHSCChemistryMarks.Visible = false;
                    //trHSCMathMarks.Visible = false;
                    trHSCSubjectMarks.Visible = false;
                    trHSCEnglishMarks.Visible = false;
                    trHSCTotalMarks.Visible = true;

                    txtHSCTotalMarksObtained.Attributes.Add("onmouseover", "ddrivetip('Please Enter Diploma Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')");
                    txtHSCTotalMarksObtained.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksObtained.ErrorMessage = "Please Enter Diploma Aggregate Marks Obtained.";
                    revHSCTotalMarksObtained.ErrorMessage = "Diploma Aggregate Marks Obtained should be Numeric.";
                    cvHSCTotalMarksObtained.ErrorMessage = "Diploma Aggregate Marks Obtained should be less then or equal to Diploma Aggregate Marks OutOf.";
                    cvHSCTotalMarksObtainedZero.ErrorMessage = "Diploma Aggregate Marks Obtained should be greater than Zero.";

                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseover", "ddrivetip('Please Enter Diploma Aggregate Marks OutOf.')");
                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksOutOf.ErrorMessage = "Please Enter Diploma Aggregate Marks OutOf.";
                    revHSCTotalMarksOutOf.ErrorMessage = "Diploma Aggregate Marks OutOf should be Numeric.";
                }
                else if (rbnQualifyingExamBSc.Checked)
                {
                    trHSCBoard.Visible = false;
                    trHSCMarksHeader.Visible = true;
                    trHSCPhysicsMarks.Visible = false;
                    trHSCChemistryMarks.Visible = false;
                    //trHSCMathMarks.Visible = false;
                    trHSCSubjectMarks.Visible = false;
                    trHSCEnglishMarks.Visible = false;
                    trHSCTotalMarks.Visible = true;

                    txtHSCTotalMarksObtained.Attributes.Add("onmouseover", "ddrivetip('Please Enter B.Sc. Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')");
                    txtHSCTotalMarksObtained.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksObtained.ErrorMessage = "Please Enter B.Sc. Aggregate Marks Obtained.";
                    revHSCTotalMarksObtained.ErrorMessage = "B.Sc. Aggregate Marks Obtained should be Numeric.";
                    cvHSCTotalMarksObtained.ErrorMessage = "B.Sc. Aggregate Marks Obtained should be less then or equal to B.Sc. Aggregate Marks OutOf.";
                    cvHSCTotalMarksObtainedZero.ErrorMessage = "B.Sc. Aggregate Marks Obtained should be greater than Zero.";

                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseover", "ddrivetip('Please Enter B.Sc. Aggregate Marks OutOf.')");
                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksOutOf.ErrorMessage = "Please Enter B.Sc. Aggregate Marks OutOf.";
                    revHSCTotalMarksOutOf.ErrorMessage = "B.Sc. Aggregate Marks OutOf should be Numeric.";
                }
                else if (rbnQualifyingExamHSC.Checked)
                {
                    trHSCBoard.Visible = true;
                    trHSCMarksHeader.Visible = true;
                    trHSCPhysicsMarks.Visible = true;
                    trHSCChemistryMarks.Visible = true;
                    //trHSCMathMarks.Visible = true;
                    trHSCSubjectMarks.Visible = true;
                    trHSCEnglishMarks.Visible = true;
                    trHSCTotalMarks.Visible = true;

                    txtHSCTotalMarksObtained.Attributes.Add("onmouseover", "ddrivetip('Please Enter HSC Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')");
                    txtHSCTotalMarksObtained.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksObtained.ErrorMessage = "Please Enter HSC Aggregate Marks Obtained.";
                    revHSCTotalMarksObtained.ErrorMessage = "HSC Aggregate Marks Obtained should be Numeric.";
                    cvHSCTotalMarksObtained.ErrorMessage = "HSC Aggregate Marks Obtained should be less then or equal to HSC Aggregate Marks OutOf.";
                    cvHSCTotalMarksObtainedZero.ErrorMessage = "HSC Aggregate Marks Obtained should be greater than Zero.";

                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseover", "ddrivetip('Please Enter HSC Aggregate Marks OutOf.')");
                    txtHSCTotalMarksOutOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    rfvHSCTotalMarksOutOf.ErrorMessage = "Please Enter HSC Aggregate Marks OutOf.";
                    revHSCTotalMarksOutOf.ErrorMessage = "HSC Aggregate Marks OutOf should be Numeric.";
                }
                else
                {
                    trHSCBoard.Visible = false;
                    trHSCMarksHeader.Visible = false;
                    trHSCPhysicsMarks.Visible = false;
                    trHSCChemistryMarks.Visible = false;
                    //trHSCMathMarks.Visible = false;
                    trHSCSubjectMarks.Visible = false;
                    trHSCEnglishMarks.Visible = false;
                    trHSCTotalMarks.Visible = false;
                }

                //Int16 HSCBoardID = Convert.ToInt16(ddlHSCBoard.SelectedValue);
                //ddlHSCSubject.DataSource = reg.getMasterHSCSubject(HSCBoardID);
                //ddlHSCSubject.DataTextField = "HSCSubjectName";
                //ddlHSCSubject.DataValueField = "HSCSubjectID";
                //ddlHSCSubject.DataBind();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            ContentTable2.Visible = true;
            ContentBox1.Visible = false;
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                ContentTable2.Visible = false;
                ContentBox1.Visible = true;

                Int32 CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                Int32 PHTypeID = Convert.ToInt32(ddlPHType.SelectedValue);
                Int32 CourseCode = Convert.ToInt32(ddlCourse.SelectedValue);
                Int32 AppliedForEWS = 0;
                if (ddlAppliedForEWS.SelectedValue == "Yes")
                {
                    AppliedForEWS = 1;
                }
                else
                {
                    AppliedForEWS = 0;
                }
                QualificationDetails obj = new QualificationDetails();
                if (rbnQualifyingExamHSC.Checked)
                {
                    obj.QualifyingExam = "HSC";
                }
                else if (rbnQualifyingExamDiploma.Checked)
                {
                    obj.QualifyingExam = "Diploma";
                }
                else if (rbnQualifyingExamBSc.Checked)
                {
                    obj.QualifyingExam = "B.Sc.";
                }
                if (rbnQualifyingExamDiploma.Checked || rbnQualifyingExamBSc.Checked)
                {
                    obj.HSCPhysicsMarksObtained = 0;
                    obj.HSCPhysicsMarksOutOf = 0;
                    obj.HSCPhysicsPercentage = 0;
                    obj.HSCChemistryMarksObtained = 0;
                    obj.HSCChemistryMarksOutOf = 0;
                    obj.HSCChemistryPercentage = 0;
                    //obj.HSCMathMarksObtained = 0;
                    //obj.HSCMathMarksOutOf = 0;
                    //obj.HSCMathPercentage = 0;
                    obj.HSCSubjectID = 0;
                    obj.HSCSubjectMarksObtained = 0;
                    obj.HSCSubjectMarksOutOf = 0;
                    obj.HSCSubjectPercentage = 0;
                    obj.HSCEnglishMarksObtained = 0;
                    obj.HSCEnglishMarksOutOf = 0;
                    obj.HSCEnglishPercentage = 0;
                }
                else
                {
                    obj.HSCPhysicsMarksObtained = Convert.ToDecimal(txtHSCPhysicsMarksObtained.Text);
                    obj.HSCPhysicsMarksOutOf = Convert.ToDecimal(txtHSCPhysicsMarksOutOf.Text);
                    obj.HSCPhysicsPercentage = Convert.ToDecimal(obj.HSCPhysicsMarksObtained * 100) / obj.HSCPhysicsMarksOutOf;
                    obj.HSCChemistryMarksObtained = Convert.ToDecimal(txtHSCChemistryMarksObtained.Text);
                    obj.HSCChemistryMarksOutOf = Convert.ToDecimal(txtHSCChemistryMarksOutOf.Text);
                    obj.HSCChemistryPercentage = Convert.ToDecimal(obj.HSCChemistryMarksObtained * 100) / obj.HSCChemistryMarksOutOf;
                    //obj.HSCMathMarksObtained = Convert.ToDecimal(txtHSCMathMarksObtained.Text);
                    //obj.HSCMathMarksOutOf = Convert.ToDecimal(txtHSCMathMarksOutOf.Text);
                    //obj.HSCMathPercentage = Convert.ToDecimal(obj.HSCMathMarksObtained * 100) / obj.HSCMathMarksOutOf;
                    obj.HSCSubjectID = Convert.ToInt32(ddlHSCSubject.SelectedValue);
                    if (obj.HSCSubjectID > 0)
                    {
                        obj.HSCSubjectMarksObtained = Convert.ToDecimal(txtHSCSubjectMarksObtained.Text);
                        obj.HSCSubjectMarksOutOf = Convert.ToDecimal(txtHSCSubjectMarksOutOf.Text);
                        obj.HSCSubjectPercentage = Convert.ToDecimal(obj.HSCSubjectMarksObtained * 100) / obj.HSCSubjectMarksOutOf;
                    }
                    else
                    {
                        obj.HSCSubjectMarksObtained = 0;
                        obj.HSCSubjectMarksOutOf = 0;
                        obj.HSCSubjectPercentage = 0;
                    }
                    obj.HSCEnglishMarksObtained = Convert.ToDecimal(txtHSCEnglishMarksObtained.Text);
                    obj.HSCEnglishMarksOutOf = Convert.ToDecimal(txtHSCEnglishMarksOutOf.Text);
                    obj.HSCEnglishPercentage = Convert.ToDecimal(obj.HSCEnglishMarksObtained * 100) / obj.HSCEnglishMarksOutOf;
                }
                obj.HSCTotalMarksObtained = Convert.ToDecimal(txtHSCTotalMarksObtained.Text);
                obj.HSCTotalMarksOutOf = Convert.ToDecimal(txtHSCTotalMarksOutOf.Text);
                obj.HSCTotalPercentage = Convert.ToDecimal(obj.HSCTotalMarksObtained * 100) / obj.HSCTotalMarksOutOf;
                //obj.HSCPCMPercentage = (obj.HSCPhysicsPercentage + obj.HSCChemistryPercentage + obj.HSCMathPercentage) / 3;
                obj.HSCPMSPercentage = (obj.HSCPhysicsPercentage + obj.HSCChemistryPercentage + obj.HSCSubjectPercentage) / 3;

                lblCandidatureType.Text = ddlCandidatureType.SelectedItem.Text;
                lblCategory.Text = ddlCategory.SelectedItem.Text;
                lblEws.Text = ddlAppliedForEWS.SelectedItem.Text;
                if (CategoryID == 0)
                {
                    lblCategory.Text = "Not Applicable";
                }
                if (AppliedForEWS == 0)
                {
                    lblEws.Text = "Not Applicable";
                }
                lblPHType.Text = ddlPHType.SelectedItem.Text;
                lblCourse.Text = ddlCourse.SelectedItem.Text;
                lblQualifyingExam.Text = obj.QualifyingExam;
                if (obj.QualifyingExam == "Diploma")
                {
                    lblQualifyingExam.Text = "Diploma in Pharmacy";
                }
                lblHSCBoard.Text = ddlHSCBoard.SelectedItem.Text;
                if (obj.QualifyingExam == "HSC")
                {
                    trHSCBoardDisplay.Visible = true;
                    trHSCPhysicsMarksDisplay.Visible = true;
                    trHSCChemistryMarksDisplay.Visible = true;
                    //trHSCMathMarksDisplay.Visible = true;
                    trHSCSubjectMarksDisplay.Visible = true;
                    trHSCEnglishMarksDisplay.Visible = true;

                    lblHSCPhysicsMarksObtained.Text = txtHSCPhysicsMarksObtained.Text;
                    lblHSCPhysicsMarksOutOf.Text = txtHSCPhysicsMarksOutOf.Text;
                    lblHSCPhysicsPercentage.Text = String.Format("{0:0.00}", obj.HSCPhysicsPercentage);
                    lblHSCChemistryMarksObtained.Text = txtHSCChemistryMarksObtained.Text;
                    lblHSCChemistryMarksOutOf.Text = txtHSCChemistryMarksOutOf.Text;
                    lblHSCChemistryPercentage.Text = String.Format("{0:0.00}", obj.HSCChemistryPercentage);
                    //lblHSCMathMarksObtained.Text = txtHSCMathMarksObtained.Text;
                    //lblHSCMathMarksOutOf.Text = txtHSCMathMarksOutOf.Text;
                    //lblHSCMathPercentage.Text = String.Format("{0:0.00}", obj.HSCMathPercentage);
                    lblHSCSubject.Text = ddlHSCSubject.SelectedItem.Text;
                    lblHSCSubjectMarksObtained.Text = txtHSCSubjectMarksObtained.Text;
                    lblHSCSubjectMarksOutOf.Text = txtHSCSubjectMarksOutOf.Text;
                    lblHSCSubjectPercentage.Text = String.Format("{0:0.00}", obj.HSCSubjectPercentage);
                    if (obj.HSCSubjectID == 0)
                    {
                        trHSCSubjectMarksDisplay.Visible = false;
                    }
                    lblHSCEnglishMarksObtained.Text = txtHSCEnglishMarksObtained.Text;
                    lblHSCEnglishMarksOutOf.Text = txtHSCEnglishMarksOutOf.Text;
                    lblHSCEnglishPercentage.Text = String.Format("{0:0.00}", obj.HSCEnglishPercentage);
                }
                else
                {
                    trHSCBoardDisplay.Visible = false;
                    trHSCPhysicsMarksDisplay.Visible = false;
                    trHSCChemistryMarksDisplay.Visible = false;
                    //trHSCMathMarksDisplay.Visible = false;
                    trHSCSubjectMarksDisplay.Visible = false;
                    trHSCEnglishMarksDisplay.Visible = false;
                }
                lblHSCTotalMarksObtained.Text = txtHSCTotalMarksObtained.Text;
                lblHSCTotalMarksOutOf.Text = txtHSCTotalMarksOutOf.Text;
                lblHSCTotalPercentage.Text = String.Format("{0:0.00}", obj.HSCTotalPercentage);
                //ddlAppliedForEWS.SelectedValue == "Yes"
                //&& ddlAppliedForEWS.SelectedValue == "No"

                if (obj.QualifyingExam == "Diploma" || obj.QualifyingExam == "B.Sc.")
                {
                    if (CourseCode == 823)
                    {
                        if ((CategoryID == 0 || CategoryID == 1) && PHTypeID == 0 && AppliedForEWS == 0)
                        {
                            if (obj.HSCTotalPercentage < Convert.ToDecimal(44.50))
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 44.50% marks in " + obj.QualifyingExam + ". So you are NOT ELIGIBLE for Admission.</font></p>";
                            }
                            else
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'green'>You are ELIGIBLE for Admission.</font></p>";
                            }
                        }
                        else
                        {
                            if (obj.HSCTotalPercentage < Convert.ToDecimal(39.50))
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 39.50% marks in " + obj.QualifyingExam + ". So you are NOT ELIGIBLE for Admission.</font></p>";
                            }
                            else
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'green'>You are ELIGIBLE for Admission.</font></p>";
                            }
                        }
                    }
                    else
                    {
                        if ((CategoryID == 0 || CategoryID == 1) && PHTypeID == 0 && AppliedForEWS == 0)
                        {
                            if (obj.HSCTotalPercentage < Convert.ToDecimal(49.50))
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 49.50% marks in " + obj.QualifyingExam + ". So you are NOT ELIGIBLE for Admission.</font></p>";
                            }
                            else
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'green'>You are ELIGIBLE for Admission.</font></p>";
                            }
                        }
                        else
                        {
                            if (obj.HSCTotalPercentage < Convert.ToDecimal(44.50))
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 44.50% marks in " + obj.QualifyingExam + ". So you are NOT ELIGIBLE for Admission.</font></p>";
                            }
                            else
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'green'>You are ELIGIBLE for Admission.</font></p>";
                            }
                        }
                    }

                }
                else
                {
                    if (CourseCode == 823)
                    {
                        if ((CategoryID == 0 || CategoryID == 1) && PHTypeID == 0 && AppliedForEWS == 0)
                        {
                            if (/*obj.HSCPCMPercentage < Convert.ToDecimal(44.50) &&*/ obj.HSCPMSPercentage < Convert.ToDecimal(44.50))
                            {
                                if (obj.HSCSubjectID == 0)
                                {
                                    lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 44.50% marks in the subjects Physics, Chemistry, Mathematics added together in HSC. So you are NOT ELIGIBLE for Admission.</font></p>";
                                }
                                else
                                {
                                    lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 44.50% marks in the subjects Physics, Chemistry, " + ddlHSCSubject.SelectedItem.Text + " added together in HSC. So you are NOT ELIGIBLE for Admission.</font></p>";
                                }
                            }
                            else
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'green'>You are ELIGIBLE for Admission.</font></p>";
                            }
                        }
                        else
                        {
                            if (/*obj.HSCPCMPercentage < Convert.ToDecimal(39.50) &&*/ obj.HSCPMSPercentage < Convert.ToDecimal(39.50))
                            {
                                if (obj.HSCSubjectID == 0)
                                {
                                    lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 39.50% marks in the subjects Physics, Chemistry, Mathematics added together in HSC. So you are NOT ELIGIBLE for Admission.</font></p>";
                                }
                                else
                                {
                                    lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 39.50% marks in the subjects Physics, Chemistry, " + ddlHSCSubject.SelectedItem.Text + " added together in HSC. So you are NOT ELIGIBLE for Admission.</font></p>";
                                }
                            }
                            else
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'green'>You are ELIGIBLE for Admission.</font></p>";
                            }
                        }
                    }
                    else
                    {
                        if ((CategoryID == 0 || CategoryID == 1) && PHTypeID == 0 && AppliedForEWS == 0)
                        {
                            if (/*obj.HSCPCMPercentage < Convert.ToDecimal(44.50) &&*/ obj.HSCPMSPercentage < Convert.ToDecimal(49.50))
                            {
                                if (obj.HSCSubjectID == 0)
                                {
                                    lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 49.50% marks in the subjects Physics, Chemistry, Mathematics added together in HSC. So you are NOT ELIGIBLE for Admission.</font></p>";
                                }
                                else
                                {
                                    lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 49.50% marks in the subjects Physics, Chemistry, " + ddlHSCSubject.SelectedItem.Text + " added together in HSC. So you are NOT ELIGIBLE for Admission.</font></p>";
                                }
                            }
                            else
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'green'>You are ELIGIBLE for Admission.</font></p>";
                            }
                        }
                        else
                        {
                            if (/*obj.HSCPCMPercentage < Convert.ToDecimal(39.50) &&*/ obj.HSCPMSPercentage < Convert.ToDecimal(44.50))
                            {
                                if (obj.HSCSubjectID == 0)
                                {
                                    lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 44.50% marks in the subjects Physics, Chemistry, Mathematics added together in HSC. So you are NOT ELIGIBLE for Admission.</font></p>";
                                }
                                else
                                {
                                    lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'red'>As you have less than 44.50% marks in the subjects Physics, Chemistry, " + ddlHSCSubject.SelectedItem.Text + " added together in HSC. So you are NOT ELIGIBLE for Admission.</font></p>";
                                }
                            }
                            else
                            {
                                lblEligibilityStatus.Text = "<p align = 'justify'><font color = 'green'>You are ELIGIBLE for Admission.</font></p>";
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

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            if (CategoryID == 1)
            {
                trAppliedForEWS2.Visible = true;
                ddlAppliedForEWS.SelectedIndex = 0;
            }
            else
            {
                trAppliedForEWS2.Visible = false;
                ddlAppliedForEWS.SelectedIndex = 0;
            }
        }
    }
}