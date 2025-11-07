using BusinessLayer;
using EntityModel;
using OptionDropDownList;
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
    public partial class frmEditQualificationDetails : System.Web.UI.Page
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

                    //txtSSCMathMarksObtained.Attributes.Add("OnBlur", "sscMathMarksChanged();");
                    //txtSSCMathMarksOutOf.Attributes.Add("OnBlur", "sscMathMarksChanged();");
                    //txtSSCTotalMarksObtained.Attributes.Add("OnBlur", "sscTotalMarksChanged();");
                    //txtSSCTotalMarksOutOf.Attributes.Add("OnBlur", "sscTotalMarksChanged();");
                    txtHSCPhysicsMarksObtained.Attributes.Add("OnBlur", "hscPhysicsMarksChanged();");
                    txtHSCPhysicsMarksOutOf.Attributes.Add("OnBlur", "hscPhysicsMarksChanged();");
                    txtHSCChemistryMarksObtained.Attributes.Add("OnBlur", "hscChemistryMarksChanged();");
                    txtHSCChemistryMarksOutOf.Attributes.Add("OnBlur", "hscChemistryMarksChanged();");
                    txtHSCSubjectMarksObtained.Attributes.Add("OnBlur", "hscSubjectMarksChanged();");
                    txtHSCSubjectMarksOutOf.Attributes.Add("OnBlur", "hscSubjectMarksChanged();");
                    txtHSCEnglishMarksObtained.Attributes.Add("OnBlur", "hscEnglishMarksChanged();");
                    txtHSCEnglishMarksOutOf.Attributes.Add("OnBlur", "hscEnglishMarksChanged();");
                    txtHSCTotalMarksObtained.Attributes.Add("OnBlur", "hscTotalMarksChanged();");
                    txtHSCTotalMarksOutOf.Attributes.Add("OnBlur", "hscTotalMarksChanged();");
                    txtDiplomaTotalMarksObtained.Attributes.Add("OnBlur", "diplomaTotalMarksChanged();");
                    txtDiplomaTotalMarksOutOf.Attributes.Add("OnBlur", "diplomaTotalMarksChanged();");
                    ddlSSCPassingYear.DataSource = Global.MasterSSCPassingYear;
                    ddlSSCPassingYear.DataTextField = "DisplayName";
                    ddlSSCPassingYear.DataValueField = "Value";
                    ddlSSCPassingYear.DataBind();
                    ddlHSCPassingYear.DataSource = Global.MasterHSCPassingYear;
                    ddlHSCPassingYear.DataTextField = "DisplayName";
                    ddlHSCPassingYear.DataValueField = "Value";
                    ddlHSCPassingYear.DataBind();
                    //ddlSSCBoard.DataSource = ddlHSCBoard.DataSource = Global.MasterBoard;
                    //ddlSSCBoard.DataTextField = ddlHSCBoard.DataTextField = "BoardName";
                    //ddlSSCBoard.DataValueField = ddlHSCBoard.DataValueField = "BoardID";
                    //ddlSSCBoard.DataBind();
                    //ddlHSCBoard.DataBind();
                    //ddlSSCBoard.Items.Insert(0, new ListItem("-- SSC Board --", "0"));
                    //ddlHSCBoard.Items.Insert(0, new ListItem("-- HSC Board --", "0"));
                    DataSet ds = Global.MasterBoard;
                    List<OptionGroupItem> lista = new List<OptionGroupItem>();

                    if (ds != null)
                    {
                        OptionGroupItem items = new OptionGroupItem
                        {
                            Text = "-- Select Board --",
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
                    ddlSSCBoard.DataSource = ddlHSCBoard.DataSource = lista;

                    ddlSSCBoard.DataBind();
                    ddlHSCBoard.DataBind();

                    QualificationDetails obj = reg.getQualificationDetails(PID);
                    ddlHSCSubject.DataSource = Global.MasterHSCSubject;
                    //ddlHSCSubject.DataSource = reg.getMasterHSCSubject(obj.HSCBoardID);
                    ddlHSCSubject.DataTextField = "HSCSubjectName";
                    ddlHSCSubject.DataValueField = "HSCSubjectID";
                    ddlHSCSubject.DataBind();
                    ddlHSCSubject.Items.Insert(0, new ListItem("-- Select Subject --", "0"));

                    trHSCMaharashatra.Visible = false;
                    trFetchHSCData.Visible = false;
                    trHSCName.Visible = false;

                    // QualificationDetails obj = reg.getQualificationDetails(PID);

                    ddlSSCBoard.SelectedValue = obj.SSCBoardID.ToString();
                    ddlSSCPassingYear.SelectedValue = obj.SSCPassingYear;
                    txtSSCSeatNo.Text = obj.SSCSeatNo;
                    //txtSSCMathMarksObtained.Text = obj.SSCMathMarksObtained.ToString();
                    //txtSSCMathMarksOutOf.Text = obj.SSCMathMarksOutOf.ToString();
                    //txtSSCTotalMarksObtained.Text = obj.SSCTotalMarksObtained.ToString();
                    //txtSSCTotalMarksOutOf.Text = obj.SSCTotalMarksOutOf.ToString();

                    if (obj.HSCBoardID == 1 && (obj.HSCPassingYear == "2024"))
                    {
                        //txtNameAsPerHSCResult.Text = objReg.CandidateName;
                        txtMotherName.Text = obj.HSCMotherName;//objReg.MotherName;

                        UnVisibleHSCFields();
                        trHSCMaharashatra.Visible = true;
                    }

                    if (obj.HSCPlace == "India")
                    {
                        rbnHSCPlaceIndia.Checked = true;
                    }
                    else if (obj.HSCPlace == "Abroad")
                    {
                        rbnHSCPlaceAbroad.Checked = true;
                    }
                    ddlHSCBoard.SelectedValue = obj.HSCBoardID.ToString();
                    txtOtherHSCBoard.Text = obj.OtherHSCBoard;
                    ddlHSCPassingYear.SelectedValue = obj.HSCPassingYear;
                    txtHSCSeatNo.Text = obj.HSCSeatNo;
                    if (obj.HSCPassingStatus == "Passed")
                    {
                        rbnHSCPassed.Checked = true;
                        rbnHSCFailed.Checked = false;
                    }
                    else if (obj.HSCPassingStatus == "Failed / Compartment")
                    {
                        rbnHSCPassed.Checked = false;
                        rbnHSCFailed.Checked = true;
                    }
                    txtHSCPhysicsMarksObtained.Text = obj.HSCPhysicsMarksObtained.ToString();
                    txtHSCPhysicsMarksOutOf.Text = obj.HSCPhysicsMarksOutOf.ToString();
                    txtHSCChemistryMarksObtained.Text = obj.HSCChemistryMarksObtained.ToString();
                    txtHSCChemistryMarksOutOf.Text = obj.HSCChemistryMarksOutOf.ToString();
                    ddlHSCSubject.SelectedValue = obj.HSCSubjectID.ToString();
                    txtHSCSubjectMarksObtained.Text = obj.HSCSubjectMarksObtained.ToString();
                    txtHSCSubjectMarksOutOf.Text = obj.HSCSubjectMarksOutOf.ToString();
                    txtHSCEnglishMarksObtained.Text = obj.HSCEnglishMarksObtained.ToString();
                    txtHSCEnglishMarksOutOf.Text = obj.HSCEnglishMarksOutOf.ToString();
                    txtHSCTotalMarksObtained.Text = obj.HSCTotalMarksObtained.ToString();
                    txtHSCTotalMarksOutOf.Text = obj.HSCTotalMarksOutOf.ToString();
                    txtNameAsPerHSCResult.Text = obj.NameAsPerHSCResult.ToString();
                    txtIsResultFetched.Text = obj.IsResultFetched.ToString();
                    if (obj.IsResultFetched != "N")
                    {
                        //txtHSCDOB.Text = Convert.ToDateTime(obj.HSCQDDOB).ToString("dd/MM/yyyy");
                        txtMotherName.Text = obj.HSCMotherName;
                    }

                    tblDiplomaMarks.Visible = false;
                    tblDiplomaCGPA.Visible = false;
                    if (obj.AppearedForDiploma == "Yes")
                    {
                        rbnAppearedForDiplomaYes.Checked = true;
                        if (obj.DiplomaMarksType == "CGPA")
                        {
                            rbnCGPA.Checked = true;
                            tblDiplomaCGPA.Visible = true;
                            tblDiplomaMarks.Visible = false;

                            txtDiplomaCGPAObtained.Text = obj.DiplomaTotalMarksObtained.ToString();
                            txtDiplomaCGPAOutOf.Text = obj.DiplomaTotalMarksOutOf.ToString();
                            txtDiplomaCGPAPercentage.Text = obj.DiplomaTotalPercentage.ToString();
                        }
                        else
                        {
                            rbnPercentage.Checked = true;
                            tblDiplomaCGPA.Visible = false;
                            tblDiplomaMarks.Visible = true;

                            txtDiplomaTotalMarksObtained.Text = obj.DiplomaTotalMarksObtained.ToString();
                            txtDiplomaTotalMarksOutOf.Text = obj.DiplomaTotalMarksOutOf.ToString();
                        }
                    }
                    else
                    {
                        rbnAppearedForDiplomaYes.Checked = false;
                        rbnAppearedForDiplomaNo.Checked = true;
                    }

                    if ((UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        string Flag = reg.isCandidateEligibleForEdittingAtARC(PID);

                        if (Flag.Length > 0)
                        {
                            Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                        }
                    }
                    else if ((UserTypeID == 23 || UserTypeID == 24) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                    }
                }

                onPageLoad();
                btnProceed.Enabled = true;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void HSCPlace_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (rbnHSCPlaceAbroad.Checked)
                {
                    ddlHSCBoard.SelectedValue = "99";
                    ddlHSCBoard.Enabled = false;
                    trOtherHSCBoard.Visible = true;
                }
                else
                {
                    ddlHSCBoard.SelectedValue = "0";
                    ddlHSCBoard.Enabled = true;
                    trOtherHSCBoard.Visible = false;
                }

                txtOtherHSCBoard.Text = "";
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
                trHSCMaharashatra.Visible = false;
                if (HSCBoardID == 99)
                {
                    trOtherHSCBoard.Visible = true;
                }
                else
                {
                    trOtherHSCBoard.Visible = false;
                    if (HSCBoardID == 1 && (ddlHSCPassingYear.SelectedValue == "2024"))
                    {
                        //UnVisibleHSCFields();
                        trHSCMaharashatra.Visible = true;
                        btnProceed.Enabled = false;
                        txtMotherName.Text = "";
                        txtHSCSeatNo.Text = "";
                        ClearHSCFields();
                    }
                    else
                    {
                        ClearHSCFields();
                        VisibleHSCFields();
                        trHSCName.Visible = false;
                        trFetchHSCData.Visible = false;
                        btnProceed.Enabled = true;
                        txtMotherName.Text = "";
                        txtHSCSeatNo.Text = "";
                    }
                }

                txtOtherHSCBoard.Text = "";
                txtNameAsPerHSCResult.Text = "";
                ddlHSCPassingYear.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlHSCSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlHSCSubject.SelectedIndex > 0)
                {
                    rfvHSCSubjectMarksObtained.ErrorMessage = "Please Enter HSC " + ddlHSCSubject.SelectedItem.Text + " Marks Obtained.";
                    revHSCSubjectMarksObtained.ErrorMessage = "HSC " + ddlHSCSubject.SelectedItem.Text + " Marks Obtained should be Numeric.";
                    cvHSCSubjectMarksObtained.ErrorMessage = "HSC " + ddlHSCSubject.SelectedItem.Text + " Marks Obtained should be less then or equal to HSC " + ddlHSCSubject.SelectedItem.Text + " Marks OutOf.";
                    cvHSCSubjectMarksObtainedZero.ErrorMessage = "HSC " + ddlHSCSubject.SelectedItem.Text + " Marks Obtained should be greater than Zero.";
                    rfvHSCSubjectMarksOutOf.ErrorMessage = "Please Enter HSC " + ddlHSCSubject.SelectedItem.Text + " Marks OutOf.";
                    revHSCSubjectMarksOutOf.ErrorMessage = "HSC " + ddlHSCSubject.SelectedItem.Text + " Marks OutOf should be Numeric.";
                }
                else
                {
                    rfvHSCSubjectMarksObtained.ErrorMessage = "Please Enter HSC Subject Marks Obtained.";
                    revHSCSubjectMarksObtained.ErrorMessage = "HSC Subject Marks Obtained should be Numeric.";
                    cvHSCSubjectMarksObtained.ErrorMessage = "HSC Subject Marks Obtained should be less then or equal to HSC Subject Marks OutOf.";
                    cvHSCSubjectMarksObtainedZero.ErrorMessage = "HSC Subject Marks Obtained should be greater than Zero.";
                    rfvHSCSubjectMarksOutOf.ErrorMessage = "Please Enter HSC Subject Marks OutOf.";
                    revHSCSubjectMarksOutOf.ErrorMessage = "HSC Subject Marks OutOf should be Numeric.";
                }

                txtHSCSubjectMarksObtained.Text = "";
                txtHSCSubjectMarksOutOf.Text = "";
                txtHSCSubjectPercentage.Text = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void AppearedForDiploma_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (rbnAppearedForDiplomaYes.Checked)
                {
                    trDiplomaMarksType.Visible = true;
                    btnProceed.Enabled = true;
                    tblDiplomaCGPA.Visible = false;
                    tblDiplomaMarks.Visible = false;
                    rbnCGPA.Checked = false;
                    rbnPercentage.Checked = false;
                }
                else
                {
                    trDiplomaMarksType.Visible = false;
                    tblDiplomaCGPA.Visible = false;
                    tblDiplomaMarks.Visible = false;
                    rbnCGPA.Checked = false;
                    rbnPercentage.Checked = false;
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
                if (CandidatureTypeID == 1 || CandidatureTypeID == 5)
                {
                    rbnHSCPlaceAbroad.Checked = false;
                    rbnHSCPlaceAbroad.Enabled = false;
                }

                if (rbnHSCPlaceAbroad.Checked)
                {
                    ddlHSCBoard.Enabled = false;
                    trOtherHSCBoard.Visible = true;
                }
                else
                {
                    ddlHSCBoard.Enabled = true;
                    trOtherHSCBoard.Visible = false;
                }

                if (ddlHSCBoard.SelectedValue == "99")
                {
                    trOtherHSCBoard.Visible = true;
                }
                else
                {
                    trOtherHSCBoard.Visible = false;
                }

                if (ddlHSCSubject.SelectedIndex > 0)
                {
                    rfvHSCSubjectMarksObtained.ErrorMessage = "Please Enter HSC " + ddlHSCSubject.SelectedItem.Text + " Marks Obtained.";
                    revHSCSubjectMarksObtained.ErrorMessage = "HSC " + ddlHSCSubject.SelectedItem.Text + " Marks Obtained should be Numeric.";
                    cvHSCSubjectMarksObtained.ErrorMessage = "HSC " + ddlHSCSubject.SelectedItem.Text + " Marks Obtained should be less then or equal to HSC " + ddlHSCSubject.SelectedItem.Text + " Marks OutOf.";
                    cvHSCSubjectMarksObtainedZero.ErrorMessage = "HSC " + ddlHSCSubject.SelectedItem.Text + " Marks Obtained should be greater than Zero.";
                    rfvHSCSubjectMarksOutOf.ErrorMessage = "Please Enter HSC " + ddlHSCSubject.SelectedItem.Text + " Marks OutOf.";
                    revHSCSubjectMarksOutOf.ErrorMessage = "HSC " + ddlHSCSubject.SelectedItem.Text + " Marks OutOf should be Numeric.";
                }
                else
                {
                    rfvHSCSubjectMarksObtained.ErrorMessage = "Please Enter HSC Subject Marks Obtained.";
                    revHSCSubjectMarksObtained.ErrorMessage = "HSC Subject Marks Obtained should be Numeric.";
                    cvHSCSubjectMarksObtained.ErrorMessage = "HSC Subject Marks Obtained should be less then or equal to HSC Subject Marks OutOf.";
                    cvHSCSubjectMarksObtainedZero.ErrorMessage = "HSC Subject Marks Obtained should be greater than Zero.";
                    rfvHSCSubjectMarksOutOf.ErrorMessage = "Please Enter HSC Subject Marks OutOf.";
                    revHSCSubjectMarksOutOf.ErrorMessage = "HSC Subject Marks OutOf should be Numeric.";
                }

                if (rbnAppearedForDiplomaYes.Checked)
                {
                    trDiplomaMarksType.Visible = true;
                    if (rbnCGPA.Checked)
                    {
                        tblDiplomaMarks.Visible = false;
                        tblDiplomaCGPA.Visible = true;
                    }
                    else
                    {
                        tblDiplomaMarks.Visible = true;
                        tblDiplomaCGPA.Visible = false;
                    }
                }
                else
                {
                    trDiplomaMarksType.Visible = false;
                    tblDiplomaMarks.Visible = false;
                    tblDiplomaCGPA.Visible = false;
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
                QualificationDetails obj = new QualificationDetails();

                obj.PID = PID;
                obj.SSCBoardID = Convert.ToInt16(ddlSSCBoard.SelectedValue);
                obj.SSCPassingYear = ddlSSCPassingYear.SelectedValue;
                obj.SSCSeatNo = txtSSCSeatNo.Text;
                obj.SSCMathMarksObtained = 0;
                obj.SSCMathMarksOutOf = 0;
                obj.SSCMathPercentage = 0;
                obj.SSCTotalMarksObtained = 0;
                obj.SSCTotalMarksOutOf = 0;
                obj.SSCTotalPercentage = 0;
                if (rbnHSCPlaceIndia.Checked)
                {
                    obj.HSCPlace = "India";
                }
                else if (rbnHSCPlaceAbroad.Checked)
                {
                    obj.HSCPlace = "Abroad";
                }
                obj.HSCBoardID = Convert.ToInt16(ddlHSCBoard.SelectedValue);
                obj.OtherHSCBoard = txtOtherHSCBoard.Text;
                obj.HSCPassingYear = ddlHSCPassingYear.SelectedValue;
                obj.HSCSeatNo = txtHSCSeatNo.Text;
                if (rbnHSCPassed.Checked)
                {
                    obj.HSCPassingStatus = "Passed";
                }
                else if (rbnHSCFailed.Checked)
                {
                    obj.HSCPassingStatus = "Failed / Compartment";
                }
                obj.HSCPhysicsMarksObtained = Convert.ToDecimal(txtHSCPhysicsMarksObtained.Text);
                obj.HSCPhysicsMarksOutOf = Convert.ToDecimal(txtHSCPhysicsMarksOutOf.Text);
                obj.HSCPhysicsPercentage = Convert.ToDecimal(obj.HSCPhysicsMarksObtained * 100) / obj.HSCPhysicsMarksOutOf;
                obj.HSCChemistryMarksObtained = Convert.ToDecimal(txtHSCChemistryMarksObtained.Text);
                obj.HSCChemistryMarksOutOf = Convert.ToDecimal(txtHSCChemistryMarksOutOf.Text);
                obj.HSCChemistryPercentage = Convert.ToDecimal(obj.HSCChemistryMarksObtained * 100) / obj.HSCChemistryMarksOutOf;
                obj.HSCSubjectID = Convert.ToInt32(ddlHSCSubject.SelectedValue);
                obj.HSCSubjectMarksObtained = Convert.ToDecimal(txtHSCSubjectMarksObtained.Text);
                obj.HSCSubjectMarksOutOf = Convert.ToDecimal(txtHSCSubjectMarksOutOf.Text);
                obj.HSCSubjectPercentage = Convert.ToDecimal(obj.HSCSubjectMarksObtained * 100) / obj.HSCSubjectMarksOutOf;
                obj.HSCBioTechnologyMarksObtained = 0;
                obj.HSCBioTechnologyMarksOutOf = 0;
                obj.HSCBioTechnologyPercentage = 0;
                obj.HSCEnglishMarksObtained = Convert.ToDecimal(txtHSCEnglishMarksObtained.Text);
                obj.HSCEnglishMarksOutOf = Convert.ToDecimal(txtHSCEnglishMarksOutOf.Text);
                obj.HSCEnglishPercentage = Convert.ToDecimal(obj.HSCEnglishMarksObtained * 100) / obj.HSCEnglishMarksOutOf;
                obj.HSCTotalMarksObtained = Convert.ToDecimal(txtHSCTotalMarksObtained.Text);
                obj.HSCTotalMarksOutOf = Convert.ToDecimal(txtHSCTotalMarksOutOf.Text);
                obj.HSCTotalPercentage = Convert.ToDecimal(obj.HSCTotalMarksObtained * 100) / obj.HSCTotalMarksOutOf;
                obj.HSCPCSPercentage = (obj.HSCPhysicsPercentage + obj.HSCChemistryPercentage + Math.Max(obj.HSCSubjectPercentage, obj.HSCBioTechnologyPercentage)) / 3;
                obj.NameAsPerHSCResult = txtNameAsPerHSCResult.Text.ToUpper().TrimEnd().TrimStart();
                obj.IsResultFetched = txtIsResultFetched.Text;
               
                if (txtMotherName.Text != "")
                {
                    //obj.HSCQDDOB = Convert.ToDateTime(txtHSCDOB.Text.Split("/".ToCharArray())[1] + "/" + txtHSCDOB.Text.Split("/".ToCharArray())[0] + "/" + txtHSCDOB.Text.Split("/".ToCharArray())[2]);
                    obj.HSCMotherName = txtMotherName.Text;
                    obj.IsResultFetched = txtIsResultFetched.Text;
                    obj.HSCQDDOB = null;
                }
                else
                {
                    obj.HSCMotherName = null;
                    obj.HSCQDDOB = null;
                    obj.IsResultFetched = "N";
                }
                if (rbnAppearedForDiplomaYes.Checked)
                {
                    obj.AppearedForDiploma = "Yes";
                    if (rbnCGPA.Checked)
                    {
                        obj.DiplomaMarksType = "CGPA";
                        obj.DiplomaTotalMarksObtained = Convert.ToDecimal(txtDiplomaCGPAObtained.Text);
                        obj.DiplomaTotalMarksOutOf = Convert.ToDecimal(txtDiplomaCGPAOutOf.Text);
                        obj.DiplomaTotalPercentage = Convert.ToDecimal(txtDiplomaCGPAPercentage.Text);
                    }
                    else
                    {
                        obj.DiplomaMarksType = "Percentage";
                        obj.DiplomaTotalMarksObtained = Convert.ToDecimal(txtDiplomaTotalMarksObtained.Text);
                        obj.DiplomaTotalMarksOutOf = Convert.ToDecimal(txtDiplomaTotalMarksOutOf.Text);
                        obj.DiplomaTotalPercentage = Convert.ToDecimal(obj.DiplomaTotalMarksObtained * 100) / obj.DiplomaTotalMarksOutOf;
                    }
                }
                else
                {
                    obj.AppearedForDiploma = "No";
                    obj.DiplomaMarksType = "";
                    obj.DiplomaTotalMarksObtained = 0;
                    obj.DiplomaTotalMarksOutOf = 0;
                    obj.DiplomaTotalPercentage = 0;
                }
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                DataSet DS = reg.GetApplicationIDIsFormRegisteredUsingHSCSeatNo(PID, obj.HSCPassingYear, obj.HSCSeatNo, obj.HSCBoardID);
                string HSCSeatNo = "";
                string GetApplicationID = "";
                if (DS.Tables[0].Rows.Count > 0)
                {
                    HSCSeatNo = DS.Tables[0].Rows[0]["HSCSeatNo"].ToString();
                    GetApplicationID = DS.Tables[0].Rows[0]["ApplicationID"].ToString();
                }
                if (Global.CheckDuplicateHSCSeatNo == 1 && reg.IsApplicationFormRegisteredUsingThisHSCSeatNo(PID, 5, obj.HSCPassingYear, obj.HSCSeatNo, obj.HSCBoardID))
                {
                    shInfo.SetMessage("Application Form using This HSC Seat number " + HSCSeatNo + ", " + "ApplicationID = " + GetApplicationID + "  is already confirmed  Please change HSC Seat number.", ShowMessageType.Information);
                    ContentTable2.Focus();
                }
                else if ((Int32.Parse(ddlSSCPassingYear.SelectedValue)) >= (Int32.Parse(ddlHSCPassingYear.SelectedValue == "2024_1" ? "2024" : ddlHSCPassingYear.SelectedValue == "2024_2" ? "2024" : ddlHSCPassingYear.SelectedValue)))
                {
                    ContentTable2.Focus();
                    shInfo.SetMessage("SSC Passing Year Should be Less Than HSC/ Equivalent Exam Passing Year", ShowMessageType.Information);
                }
                else
                {
                    if (reg.editQualificationDetails(obj, ModifiedBy, ModifiedByIPAddress))
                    {
                        Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
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
        protected void ddlHSCPassingYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                ClearHSCFields();
                trHSCMaharashatra.Visible = false;
                Int16 HSCBoardID = Convert.ToInt16(ddlHSCBoard.SelectedValue);
                if (ddlHSCBoard.SelectedValue == "1" && (ddlHSCPassingYear.SelectedValue == "2024"))
                {
                    trFetchHSCData.Visible = true;
                    trHSCName.Visible = true;
                    btnProceed.Enabled = true;
                    txtMotherName.Text = "";
                    txtHSCSeatNo.Text = "";
                    UnVisibleHSCFields();
                }
                else
                {
                    trOtherHSCBoard.Visible = false;
                    trFetchHSCData.Visible = false;
                    trHSCName.Visible = false;

                    txtHSCPhysicsMarksObtained.Enabled = true;
                    txtHSCPhysicsMarksOutOf.Enabled = true;
                    txtHSCPhysicsPercentage.Enabled = true;
                    txtHSCChemistryMarksObtained.Enabled = true;
                    txtHSCChemistryMarksOutOf.Enabled = true;
                    txtHSCChemistryPercentage.Enabled = true;
                    ddlHSCSubject.Enabled = true;
                    txtHSCSubjectMarksObtained.Enabled = true;
                    txtHSCSubjectMarksOutOf.Enabled = true;
                    txtHSCSubjectPercentage.Enabled = true;
                    txtHSCEnglishMarksObtained.Enabled = true;
                    txtHSCEnglishMarksOutOf.Enabled = true;
                    txtHSCEnglishPercentage.Enabled = true;
                    txtHSCTotalMarksObtained.Enabled = true;
                    txtHSCTotalMarksOutOf.Enabled = true;
                    txtHSCTotalPercentage.Enabled = true;

                    rbnHSCPassed.Enabled = true;
                    rbnHSCFailed.Enabled = true;
                    btnProceed.Enabled = true;
                    txtMotherName.Text = "";
                    txtHSCSeatNo.Text = "";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private int GetoptionalSubjectId(string subjectName)
        {
            int subjectId = 0;
            switch (subjectName)
            {
                case "BIOLOGY":
                    subjectId = 1;
                    break;
                case "INFORMATIONTECHNOLOGY":
                    subjectId = 27;
                    break;
                case "ELECTRICALMAINTENANCE":
                    subjectId = 5;
                    break;

                case "MECHANICALMAINTENANCE":
                    subjectId = 8;
                    break;
                case "SCOOTERMOTORCYCLESERV":
                    subjectId = 9;
                    break;
                case "GENERALCIVILENGINEERING":
                    subjectId = 7;
                    break;
                case "ELECTRONICS":
                    subjectId = 6;
                    break;
                case "COMPUTERSCIENCE":
                    subjectId = 4;
                    break;
                case "MATHEMATICS&STATISTICS":
                    subjectId = 2;
                    break;
                default:
                    subjectId = 0;
                    break;
            }
            return subjectId;
        }
        protected void btnFetchHSCData_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());

            if (ddlHSCBoard.SelectedValue == "1" && (ddlHSCPassingYear.SelectedValue == "2024"))
            {
                //string dobDate = txtHSCDOB.Text;
                //if (dobDate.Contains("-"))
                //{
                //    dobDate = dobDate.Replace("-", "/");
                //}
                //dobDate = dobDate.Split("/".ToCharArray())[0] + dobDate.Split("/".ToCharArray())[1] + dobDate.Split("/".ToCharArray())[2].Substring(2, 2);

                //DataSet dsHSCResult = reg.getHSCResult(txtHSCSeatNo.Text, txtNameAsPerHSCResult.Text, txtMotherName.Text, ddlHSCPassingYear.SelectedValue);
                DataSet dsHSCResult = null;

                if (Global.hSCMarksFetchBy.ToUpper() == "API")
                {
                    dsHSCResult = HSCResultAPIFetch.GetHSCResultData(PID, ddlHSCPassingYear.SelectedValue, txtHSCSeatNo.Text.TrimStart().TrimEnd());

                    if (dsHSCResult.Tables[0].Rows[0]["ResponseStatus"].ToString() != "1")
                    {
                        shInfo.SetMessage("Enter Valid HSC Seat No and Name as on HSC Marksheet.", ShowMessageType.Information);
                        ContentTable2.Focus();
                        btnProceed.Enabled = false;
                        dsHSCResult.Tables[0].Rows.Clear();
                        return;
                    }

                }
                else if (Global.hSCMarksFetchBy.ToUpper() == "DB")
                {
                    dsHSCResult = reg.getHSCResult(txtHSCSeatNo.Text, txtNameAsPerHSCResult.Text, txtMotherName.Text, ddlHSCPassingYear.SelectedValue);
                }
                else
                {
                    shInfo.SetMessage("Some thing went wrong. Please contact to Helpline.", ShowMessageType.Information);
                    ContentTable2.Focus();
                    btnProceed.Enabled = false;
                    return;
                }

                if (dsHSCResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drCurrent in dsHSCResult.Tables[0].Rows)
                    {
                        txtHSCPhysicsMarksObtained.Text = drCurrent["PHYSICS"].ToString();
                        txtHSCPhysicsMarksOutOf.Text = "100";
                        txtHSCPhysicsPercentage.Text = ((Convert.ToDecimal(drCurrent["PHYSICS"].ToString()) * 100) / 100).ToString();

                        txtHSCChemistryMarksObtained.Text = drCurrent["CHEMISTRY"].ToString();
                        txtHSCChemistryMarksOutOf.Text = "100";
                        txtHSCChemistryPercentage.Text = ((Convert.ToDecimal(drCurrent["CHEMISTRY"].ToString()) * 100) / 100).ToString();

                        txtHSCEnglishMarksObtained.Text = drCurrent["ENGLISH"].ToString();
                        txtHSCEnglishMarksOutOf.Text = "100";
                        txtHSCEnglishPercentage.Text = ((Convert.ToDecimal(drCurrent["ENGLISH"].ToString()) * 100) / 100).ToString();

                        if (decimal.Parse(drCurrent["MaxMark"].ToString()) != 0)
                        {
                            ddlHSCSubject.SelectedValue = GetoptionalSubjectId(drCurrent["MaxMarkColumn"].ToString()).ToString();
                            txtHSCSubjectMarksObtained.Text = drCurrent["MaxMark"].ToString();
                            txtHSCSubjectMarksOutOf.Text = GetoptionalSubjectOutOfMarks(drCurrent["MaxMarkColumn"].ToString()).ToString();
                            txtHSCSubjectPercentage.Text = ((Convert.ToDecimal(drCurrent["MaxMark"].ToString()) / GetoptionalSubjectOutOfMarks(drCurrent["MaxMarkColumn"].ToString()) * 100).ToString());
                        }

                        txtHSCTotalMarksObtained.Text = drCurrent["TOTAL"].ToString();
                        //txtHSCTotalMarksOutOf.Text = "650";
                        if (ddlHSCPassingYear.SelectedValue == "2021" || ddlHSCPassingYear.SelectedValue == "2022" || ddlHSCPassingYear.SelectedValue == "2023" || ddlHSCPassingYear.SelectedValue == "2024")
                        {
                            txtHSCTotalMarksOutOf.Text = "600";
                        }
                        else
                        {
                            txtHSCTotalMarksOutOf.Text = "650";
                        }
                        txtHSCTotalPercentage.Text = drCurrent["PERCENT"].ToString().Substring(0, 2) + "." + drCurrent["PERCENT"].ToString().Substring(2, 2);

                        if (drCurrent["PASS_FAIL"].ToString() == "1" || drCurrent["PASS_FAIL"].ToString() == "2" || drCurrent["PASS_FAIL"].ToString() == "PASS")
                        {
                            rbnHSCPassed.Checked = true;
                            rbnHSCFailed.Checked = false;
                        }
                        else
                        {
                            rbnHSCFailed.Checked = true;
                            rbnHSCPassed.Checked = false;
                        }
                        txtNameAsPerHSCResult.Text = drCurrent["NAME"].ToString().ToString().ToUpper().TrimStart().TrimEnd();
                        txtIsResultFetched.Text = "Y";
                    }
                    btnProceed.Enabled = true;
                }
                else
                {
                    shInfo.SetMessage("Enter Valid HSC Seat No, MotherName.", ShowMessageType.Information);
                    //SetFocus(txtSSCMathPercentage);
                    btnProceed.Enabled = false;
                }
            }
        }
        private void ClearHSCFields()
        {
            trFetchHSCData.Visible = true;
            trHSCName.Visible = true;

            txtHSCPhysicsMarksObtained.Text = "";
            txtHSCPhysicsMarksOutOf.Text = "";
            txtHSCPhysicsPercentage.Text = "";
            txtHSCChemistryMarksObtained.Text = "";
            txtHSCChemistryMarksOutOf.Text = "";
            txtHSCChemistryPercentage.Text = "";
            ddlHSCSubject.Enabled = true;
            ddlHSCSubject.SelectedValue = "0";
            txtHSCSubjectMarksObtained.Text = "";
            txtHSCSubjectMarksOutOf.Text = "";
            txtHSCSubjectPercentage.Text = "";
            txtHSCEnglishMarksObtained.Text = "";
            txtHSCEnglishMarksOutOf.Text = "";
            txtHSCEnglishPercentage.Text = "";
            txtHSCTotalMarksObtained.Text = "";
            txtHSCTotalMarksOutOf.Text = "";
            txtHSCTotalPercentage.Text = "";

            rbnHSCPassed.Enabled = true;
            rbnHSCFailed.Enabled = true;
            rbnHSCPassed.Checked = false;
            rbnHSCFailed.Checked = false;
        }
        private void VisibleHSCFields()
        {
            trOtherHSCBoard.Visible = false;
            trFetchHSCData.Visible = false;
            trHSCName.Visible = false;

            txtHSCPhysicsMarksObtained.Enabled = true;
            txtHSCPhysicsMarksOutOf.Enabled = true;
            txtHSCPhysicsPercentage.Enabled = true;
            txtHSCChemistryMarksObtained.Enabled = true;
            txtHSCChemistryMarksOutOf.Enabled = true;
            txtHSCChemistryPercentage.Enabled = true;
            ddlHSCSubject.Enabled = true;
            txtHSCSubjectMarksObtained.Enabled = true;
            txtHSCSubjectMarksOutOf.Enabled = true;
            txtHSCSubjectPercentage.Enabled = true;
            txtHSCEnglishMarksObtained.Enabled = true;
            txtHSCEnglishMarksOutOf.Enabled = true;
            txtHSCEnglishPercentage.Enabled = true;
            txtHSCTotalMarksObtained.Enabled = true;
            txtHSCTotalMarksOutOf.Enabled = true;
            txtHSCTotalPercentage.Enabled = true;

            rbnHSCPassed.Enabled = true;
            rbnHSCFailed.Enabled = true;
            btnProceed.Enabled = true;
        }
        private void UnVisibleHSCFields()
        {
            trFetchHSCData.Visible = true;
            trHSCName.Visible = true;
            txtHSCPhysicsMarksObtained.Enabled = false;
            txtHSCPhysicsMarksOutOf.Enabled = false;
            txtHSCPhysicsPercentage.Enabled = false;
            txtHSCChemistryMarksObtained.Enabled = false;
            txtHSCChemistryMarksOutOf.Enabled = false;
            txtHSCChemistryPercentage.Enabled = false;
            ddlHSCSubject.Enabled = false;
            txtHSCSubjectMarksObtained.Enabled = false;
            txtHSCSubjectMarksOutOf.Enabled = false;
            txtHSCSubjectPercentage.Enabled = false;
            txtHSCEnglishMarksObtained.Enabled = false;
            txtHSCEnglishMarksOutOf.Enabled = false;
            txtHSCEnglishPercentage.Enabled = false;
            txtHSCTotalMarksObtained.Enabled = false;
            txtHSCTotalMarksOutOf.Enabled = false;
            txtHSCTotalPercentage.Enabled = false;

            rbnHSCPassed.Enabled = false;
            rbnHSCFailed.Enabled = false;
            btnProceed.Enabled = false;
        }

        private int GetoptionalSubjectOutOfMarks(string subjectName)
        {
            int outOfMarks = 0;
            switch (subjectName)
            {
                case "BIOLOGY":
                    outOfMarks = 100;
                    break;
                case "INFORMATIONTECHNOLOGY":
                    outOfMarks = 100;
                    break;
                case "ELECTRICALMAINTENANCE":
                    outOfMarks = 200;
                    break;

                case "MECHANICALMAINTENANCE":
                    outOfMarks = 200;
                    break;
                case "SCOOTERMOTORCYCLESERV":
                    outOfMarks = 200;
                    break;
                case "GENERALCIVILENGINEERING":
                    outOfMarks = 200;
                    break;
                case "ELECTRONICS":
                    outOfMarks = 200;
                    break;
                case "COMPUTERSCIENCE":
                    outOfMarks = 200;
                    break;
                case "MATHEMATICS&STATISTICS":
                    outOfMarks = 100;
                    break;
                default:
                    outOfMarks = 0;
                    break;
            }
            return outOfMarks;
        }
        protected void DiplomaMarksType_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (rbnCGPA.Checked)
                {
                    tblDiplomaCGPA.Visible = true;
                    tblDiplomaMarks.Visible = false;
                }
                else
                {
                    tblDiplomaMarks.Visible = true;
                    tblDiplomaCGPA.Visible = false;
                }

                txtDiplomaTotalMarksObtained.Text = "";
                txtDiplomaTotalMarksOutOf.Text = "";
                txtDiplomaTotalPercentage.Text = "";

                txtDiplomaCGPAObtained.Text = "";
                txtDiplomaCGPAOutOf.Text = "";
                txtDiplomaCGPAPercentage.Text = "";

                btnProceed.Enabled = true;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}