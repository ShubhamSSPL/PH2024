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

namespace Pharmacy2024.CandidateModuleCAPRound1
{
    public partial class frmShortListOptions : System.Web.UI.Page
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (DateTime.Now < Global.OptionFormFillingCAPRound1StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound1EndDateTime)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=2", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    string AppliedForTFWS = reg.getAppliedForTFWSFlag(objSessionData.PID);
                    DataSet dsCurrentLink = reg.getCurrentLinkCAPRound1(objSessionData.PID, "frmShortListOptions.aspx");

                    hdnStepID.Value = (objSessionData.StepIDCAPRound1 + 1).ToString();
                    a_1.HRef = objSessionData.StepIDCAPRound1 + 1 >= Convert.ToInt32(a_1.ID.Split('_')[1]) ? "frmShortListOptions.aspx?tms=101" : "#";
                    a_2.HRef = objSessionData.StepIDCAPRound1 + 1 >= Convert.ToInt32(a_2.ID.Split('_')[1]) ? "frmSetPreferences.aspx?tms=101" : "#";
                    a_3.HRef = objSessionData.StepIDCAPRound1 + 1 >= Convert.ToInt32(a_3.ID.Split('_')[1]) ? "frmOptionFormSummary.aspx?tms=101" : "#";
                    a_4.HRef = objSessionData.StepIDCAPRound1 + 1 >= Convert.ToInt32(a_4.ID.Split('_')[1]) ? "frmConfirmOptionForm.aspx?tms=101" : "#";

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if (objSessionData.EligibleForCAPRound1 == 0)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                    }
                    if (objSessionData.OptionFormStatusCAPRound1 == 'A' || objSessionData.StepIDCAPRound1 < 0)
                    {
                        Response.Redirect("../CandidateModuleCAPRound1/frmOptionForm.aspx?tms=101", true);
                    }

                    ddlCourse.DataSource = reg.getCourseListByPID(1, objSessionData.PID);
                    ddlCourse.DataTextField = "CourseName";
                    ddlCourse.DataValueField = "CourseCode";
                    ddlCourse.DataBind();
                    ddlCourse.Items.Insert(0, new ListItem("-- Select Course --", "0"));

                    ddlUniversity.DataSource = Global.MasterUniversityCAPRound1;
                    ddlUniversity.DataTextField = "HomeUniversityName";
                    ddlUniversity.DataValueField = "HomeUniversityID";
                    ddlUniversity.DataBind();
                    ddlUniversity.Items.Insert(0, new ListItem("All", "0"));

                    ddlDistrict.DataSource = reg.getMasterDistrictForUniversity(1, 0);
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataValueField = "DistrictName";
                    ddlDistrict.DataBind();
                    ddlDistrict.Items.Insert(0, new ListItem("All", "All"));

                    ddlCourseStatus1.DataSource = Global.MasterCourseStatus1CAPRound1;
                    ddlCourseStatus1.DataTextField = "CourseStatus1";
                    ddlCourseStatus1.DataValueField = "CourseStatus1";
                    ddlCourseStatus1.DataBind();
                    ddlCourseStatus1.Items.Insert(0, new ListItem("All", "All"));

                    ddlCourseStatus2.DataSource = Global.MasterCourseStatus2CAPRound1;
                    ddlCourseStatus2.DataTextField = "CourseStatus2";
                    ddlCourseStatus2.DataValueField = "CourseStatus2";
                    ddlCourseStatus2.DataBind();
                    ddlCourseStatus2.Items.Insert(0, new ListItem("All", "All"));

                    ddlCourseStatus3.DataSource = Global.MasterCourseStatus3CAPRound1;
                    ddlCourseStatus3.DataTextField = "CourseStatus3";
                    ddlCourseStatus3.DataValueField = "CourseStatus3";
                    ddlCourseStatus3.DataBind();
                    ddlCourseStatus3.Items.Insert(0, new ListItem("All", "All"));

                    if (objSessionData.CandidatureTypeID >= 7)
                    {
                        ddlCourseStatus1.Items.Remove(ddlCourseStatus1.Items.FindByValue("All"));
                        ddlCourseStatus1.Items.Remove(ddlCourseStatus1.Items.FindByValue("Government"));
                        ddlCourseStatus1.Items.Remove(ddlCourseStatus1.Items.FindByValue("Government-Aided"));
                        ddlCourseStatus1.Items.Remove(ddlCourseStatus1.Items.FindByValue("University Department"));
                        ddlCourseStatus1.Items.Remove(ddlCourseStatus1.Items.FindByValue("University Managed"));
                        ddlCourseStatus1.Items.Remove(ddlCourseStatus1.Items.FindByValue("University Managed (Un-Aided)"));
                        ddlCourseStatus1.SelectedValue = "Un-Aided";
                        //ddlCourseStatus1.Enabled = false;
                    }
                    if (AppliedForTFWS != "Yes")
                    {
                        ddlTFWSStatus.SelectedValue = "N";
                        ddlTFWSStatus.Enabled = false;
                        TFSWNOT.Visible = false;
                    }
                    getSelectedOptionsList();

                    tblSelectOptions.Visible = false;
                    tblMsg.Visible = false;
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int16 UniversityID = Convert.ToInt16(ddlUniversity.SelectedValue);

                ddlDistrict.DataSource = reg.getMasterDistrictForUniversity(1, UniversityID);
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictName";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("All", "All"));
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void getSelectedOptionsList()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                gvSelectedOptionsList.DataSource = reg.getSelectedOptionsListCAPRound1(objSessionData.PID);
                gvSelectedOptionsList.DataBind();

                if (gvSelectedOptionsList.Rows.Count > 0)
                {
                    tblSelectedOptions.Visible = true;

                    for (Int32 i = 0; i < gvSelectedOptionsList.Rows.Count; i++)
                    {
                        gvSelectedOptionsList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        ((CheckBox)gvSelectedOptionsList.Rows[i].FindControl("chkDeleteOptions")).Attributes.Add("onclick", "highlightRow()");
                    }
                }
                else
                {
                    tblSelectedOptions.Visible = false;
                    if (Global.SendSMSToCandidate == 1)
                    {
                        SMSTemplate sMSTemplate = new SMSTemplate();
                        SynCommon synCommon = new SynCommon();
                        sMSTemplate.PID = objSessionData.PID;
                        sMSTemplate.RoundNumber = "I";
                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.OptionFormStartCAP);
                    }
                    //DataSet ds1 = reg.GetSMSEmailContent(objSessionData.PID, "OptionFormStartCAPI", UserInfo.GetIPAddress(), Global.IsOTPVerificationRequired);
                    //SMS objSMS1 = new SMS();
                    //if (ds1.Tables[0] != null)
                    //{
                    //    if (ds1.Tables[0].Rows.Count > 0)
                    //    {
                    //        objSMS1.sendSingleSMS(DataEncryption.DecryptDataByEncryptionKey(ds1.Tables[0].Rows[0]["MobileNo"].ToString()), ds1.Tables[0].Rows[0]["SMSContent"].ToString());
                    //        if (Global.IsEmailSend == 1)
                    //        {
                    //            objSMS1.SendEmail(ds1.Tables[0].Rows[0]["EmailID"].ToString(), ds1.Tables[0].Rows[0]["EmailBody"].ToString(), ds1.Tables[0].Rows[0]["EmailSubject"].ToString(), true);
                    //        }
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
        protected void getOptionsList()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                if (ddlCourse.SelectedValue != "0")
                {
                    string CourseCode = ddlCourse.SelectedValue;
                    Int16 UniversityID = Convert.ToInt16(ddlUniversity.SelectedValue);
                    string DistrictName = ddlDistrict.SelectedValue;
                    string CourseStatus1 = ddlCourseStatus1.SelectedValue;
                    string CourseStatus2 = ddlCourseStatus2.SelectedValue;
                    string CourseStatus3 = ddlCourseStatus3.SelectedValue;
                    string TFWSStatus = ddlTFWSStatus.SelectedValue;

                    if (TFWSStatus == "Y")
                    {
                        TFSWNOT.Visible = true;
                    }

                    gvOptionsList.DataSource = reg.getOptionsListCAPRound1(objSessionData.PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3, TFWSStatus);
                    gvOptionsList.DataBind();

                    if (gvOptionsList.Rows.Count > 0)
                    {
                        tblSelectOptions.Visible = true;
                        tblMsg.Visible = false;

                        for (Int32 i = 0; i < gvOptionsList.Rows.Count; i++)
                        {
                            gvOptionsList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            ((CheckBox)gvOptionsList.Rows[i].FindControl("chkAddOptions")).Attributes.Add("onclick", "highlightRow()");
                        }
                    }
                    else
                    {
                        tblSelectOptions.Visible = false;
                        tblMsg.Visible = true;
                    }
                }
                else
                {
                    tblSelectOptions.Visible = false;
                    tblMsg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSearch_click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                getOptionsList();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        public void btnAddSelectedOptions_click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                string OptionsList = "<OptionsList>";
                int src = 0;
                for (Int32 i = 0; i < gvOptionsList.Rows.Count; i++)
                {
                    if (((CheckBox)gvOptionsList.Rows[i].FindControl("chkAddOptions")).Checked)
                    {
                        string ChoiceCode = ((Label)gvOptionsList.Rows[i].FindControl("lblChoiceCode")).Text;
                        OptionsList += "<Option ChoiceCode='" + ChoiceCode + "'></Option>";
                        src++;
                    }
                }
                OptionsList += "</OptionsList>";
                if (OptionsList.Length > 27)
                {
                    if (300 - gvSelectedOptionsList.Rows.Count >= src)
                    {
                        switch (reg.saveOptionsCAPRound1(objSessionData.PID, OptionsList, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            case 0:
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                                break;
                            case 1:
                                getSelectedOptionsList();
                                getOptionsList();
                                ContentTable1.Focus();
                                shInfo.SetMessage("Selected Options Added. Check Your Shortlisted Options Below.", ShowMessageType.Information);
                                break;
                            case 2:
                                objSessionData.StepIDCAPRound1 = 4;
                                objSessionData.OptionFormStatusCAPRound1 = 'A';
                                Session["SessionData"] = objSessionData;

                                Response.Redirect("../CandidateModuleCAPRound1/frmOptionForm.aspx?tms=101");
                                break;
                            default:
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                                break;
                        }
                    }
                    else
                    {
                        ContentTable1.Focus();
                        shInfo.SetMessage("You Can Not Add More Than 300 Options. You Can Add Only  " + "(" + (300 - gvSelectedOptionsList.Rows.Count) + ")" + "  More Option(s) Now.", ShowMessageType.Information);
                    }
                }

                else
                {
                    ContentTable1.Focus();
                    shInfo.SetMessage("Please Select At least one Choice Code.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        public void btnDeleteSelectedOptions_click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];

                string OptionsList = "<OptionsList>";
                for (Int32 i = 0; i < gvSelectedOptionsList.Rows.Count; i++)
                {
                    if (((CheckBox)gvSelectedOptionsList.Rows[i].FindControl("chkDeleteOptions")).Checked)
                    {
                        string ChoiceCode = ((Label)gvSelectedOptionsList.Rows[i].FindControl("lblChoiceCode")).Text;
                        OptionsList += "<Option ChoiceCode='" + ChoiceCode + "'></Option>";
                    }
                }
                OptionsList += "</OptionsList>";

                if (OptionsList.Length > 27)
                {
                   switch (reg.deleteOptionsCAPRound1(objSessionData.PID, OptionsList, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            case 0:
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                                break;
                            case 1:
                                getSelectedOptionsList();
                                getOptionsList();
                                ContentTable1.Focus();
                                shInfo.SetMessage("Selected Options Deleted", ShowMessageType.Information);
                                break;
                            case 2:
                                objSessionData.StepIDCAPRound1 = 4;
                                objSessionData.OptionFormStatusCAPRound1 = 'A';
                                Session["SessionData"] = objSessionData;

                                Response.Redirect("../CandidateModuleCAPRound1/frmOptionForm.aspx?tms=101");
                                break;
                            default:
                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                                break;
                        }
                }
                else
                {
                    ContentTable1.Focus();
                    shInfo.SetMessage("Please Select At least one Choice Code for delete.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnViewInformation_click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplayInOptionForm(objSessionData.PID);

                if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                {
                    lblApplicationID.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblCandidateName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CandidateName"].ToString();
                    lblGender.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["Gender"].ToString();
                    lblDOB.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["DOB"].ToString();
                    lblCandidatureType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                    lblHomeUniversity.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                    lblCategoryForAdmission.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalCategory"].ToString();
                    lblPHType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalPHType"].ToString();
                    lblDefenceType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                    lblMinorityCandidatureType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
                    lblAppliedforEWS.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                    lblAppliedForTFWS.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                    lblAppliedforOrphan.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                }

                if (Global.MasterChoiceCodeStatusCAPRound1.Tables[0].Rows.Count > 0)
                {
                    lblChoiceCodeStatus.Text = "";
                    for (Int32 i = 0; i < Global.MasterChoiceCodeStatusCAPRound1.Tables[0].Rows.Count; i++)
                    {
                        lblChoiceCodeStatus.Text += Global.MasterChoiceCodeStatusCAPRound1.Tables[0].Rows[i]["ChoiceCodeStatusInstructions"].ToString();
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
                SessionData objSessionData = (SessionData)Session["SessionData"];

                switch (reg.saveShortlistedOptionsCAPRound1(objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    case 0:
                        shInfo.SetMessage("Please Shortlist Atleast One Institute.", ShowMessageType.Information);
                        break;
                    case 1:
                        if (objSessionData.StepIDCAPRound1 < 1)
                        {
                            ((SessionData)Session["SessionData"]).StepIDCAPRound1 = 1;
                        }

                        Response.Redirect("../CandidateModuleCAPRound1/frmSetPreferences.aspx?tms=101");
                        break;
                    default:
                        Response.Redirect("../CandidateModuleCAPRound1/frmOptionForm.aspx?tms=101");
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlTFWSStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TFWSStatus = ddlTFWSStatus.SelectedValue;
            if (TFWSStatus == "Y")
            {
                TFSWNOT.Visible = true;
            }
            else
            {
                TFSWNOT.Visible = false;
            }
        }
    }
}