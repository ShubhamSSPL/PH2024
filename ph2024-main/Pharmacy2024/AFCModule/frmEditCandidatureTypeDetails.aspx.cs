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
    public partial class frmEditCandidatureTypeDetails : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }

                    if (Global.EdittingOfApplicationForm == 0 && UserTypeID != 21)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }

                    DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplay(PID);

                    if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                    {
                        lblApplicationID.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["ApplicationID"].ToString();
                        lblCandidateName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CandidateName"].ToString();
                    }

                    ddlCandidatureType.DataSource = Global.MasterCandidatureType;
                    ddlCandidatureType.DataTextField = "CandidatureTypeName";
                    ddlCandidatureType.DataValueField = "CandidatureTypeID";
                    ddlCandidatureType.DataBind();
                    ddlCandidatureType.Items.Insert(0, new ListItem("-- Select Candidature Type --", "0"));

                    ddlDocumentForTypeA.DataSource = Global.MasterDocumentForTypeA;
                    ddlDocumentForTypeA.DataTextField = "DocumentForTypeAName";
                    ddlDocumentForTypeA.DataValueField = "DocumentForTypeACode";
                    ddlDocumentForTypeA.DataBind();
                    ddlDocumentForTypeA.Items.Insert(0, new ListItem("-- Select Document --", "N"));

                    ddlDocumentOf.DataSource = Global.MasterDocumentOf;
                    ddlDocumentOf.DataTextField = "DocumentOfName";
                    ddlDocumentOf.DataValueField = "DocumentOfCode";
                    ddlDocumentOf.DataBind();
                    ddlDocumentOf.Items.Insert(0, new ListItem("-- Select Document Of --", "N"));

                    ddlDistrict1.DataSource = ddlDistrict2.DataSource = Global.MasterMHDistrict;
                    ddlDistrict1.DataTextField = ddlDistrict2.DataTextField = "DistrictName";
                    ddlDistrict1.DataValueField = ddlDistrict2.DataValueField = "DistrictID";
                    ddlDistrict1.DataBind();
                    ddlDistrict2.DataBind();
                    ddlDistrict1.Items.Insert(0, new ListItem("-- Select District --", "0"));
                    ddlDistrict2.Items.Insert(0, new ListItem("-- Select District --", "0"));

                    ddlTaluka2.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));

                    ddlCategory.DataSource = Global.MasterCategory;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));

                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));

                    ddlCVCDistrict.DataSource = Global.MasterMHDistrict;
                    ddlCVCDistrict.DataTextField = "DistrictName";
                    ddlCVCDistrict.DataValueField = "DistrictName";
                    ddlCVCDistrict.DataBind();
                    ddlCVCDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));

                    ddlPHType.DataSource = Global.MasterPHType;
                    ddlPHType.DataTextField = "PHTypeDetails";
                    ddlPHType.DataValueField = "PHTypeID";
                    ddlPHType.DataBind();

                    ddlDefenceType.DataSource = Global.MasterDefenceType;
                    ddlDefenceType.DataTextField = "DefenceTypeDetails";
                    ddlDefenceType.DataValueField = "DefenceTypeID";
                    ddlDefenceType.DataBind();

                    ddlLinguisticMinority.DataSource = Global.MasterLinguisticMinority;
                    ddlLinguisticMinority.DataTextField = "MinorityName";
                    ddlLinguisticMinority.DataValueField = "MinorityID";
                    ddlLinguisticMinority.DataBind();
                    ddlLinguisticMinority.Items.Insert(0, new ListItem("-- Select --", "0"));

                    ddlReligiousMinority.DataSource = Global.MasterReligiousMinority;
                    ddlReligiousMinority.DataTextField = "MinorityName";
                    ddlReligiousMinority.DataValueField = "MinorityID";
                    ddlReligiousMinority.DataBind();
                    ddlReligiousMinority.Items.Insert(0, new ListItem("-- Select --", "0"));

                    Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                    HomeUniversityAndCategoryDetails objHUC = reg.getHomeUniversityAndCategoryDetails(PID);
                    SpecialReservationDetails objSR = reg.getSpecialReservationDetails(PID);

                    if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4)
                    {
                        ddlDistrict1.Items.Remove(ddlDistrict1.Items.FindByText("Uttara Kannada (Karwar)"));
                        ddlDistrict1.Items.Remove(ddlDistrict1.Items.FindByText("Bidar"));
                        ddlDistrict1.Items.Remove(ddlDistrict1.Items.FindByText("Kalaburagi (Gulbarga)"));
                        ddlDistrict1.Items.Remove(ddlDistrict1.Items.FindByText("Belagavi (Belgaum)"));

                        ddlDistrict2.Items.Remove(ddlDistrict2.Items.FindByText("Uttara Kannada (Karwar)"));
                        ddlDistrict2.Items.Remove(ddlDistrict2.Items.FindByText("Bidar"));
                        ddlDistrict2.Items.Remove(ddlDistrict2.Items.FindByText("Kalaburagi (Gulbarga)"));
                        ddlDistrict2.Items.Remove(ddlDistrict2.Items.FindByText("Belagavi (Belgaum)"));

                        ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Uttara Kannada (Karwar)"));
                        ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Bidar"));
                        ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Kalaburagi (Gulbarga)"));
                        ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Belagavi (Belgaum)"));
                    }

                    ddlCandidatureType.SelectedValue = CandidatureTypeID.ToString();

                    ddlDocumentForTypeA.SelectedValue = objHUC.DocumentForTypeACode.ToString();
                    ddlDocumentOf.SelectedValue = objHUC.DocumentOfCode.ToString();
                    txtMothersName.Text = objHUC.MothersName;
                    if (objHUC.SSCDistrictID != 0)
                    {
                        Int32 i;
                        for (i = 0; i < ddlDistrict1.Items.Count; i++)
                        {
                            if (ddlDistrict1.Items[i].Value.Split(";".ToCharArray())[0] == objHUC.SSCDistrictID.ToString())
                            {
                                break;
                            }
                        }
                        ddlDistrict1.SelectedIndex = i;
                    }
                    if (objHUC.HSCDistrictID != 0)
                    {
                        Int32 i;
                        for (i = 0; i < ddlDistrict2.Items.Count; i++)
                        {
                            if (ddlDistrict2.Items[i].Value.Split(";".ToCharArray())[0] == objHUC.HSCDistrictID.ToString())
                            {
                                break;
                            }
                        }
                        ddlDistrict2.SelectedIndex = i;
                    }
                    ddlTaluka2.DataSource = reg.getMasterMHTalukaForMHDistrict(objHUC.HSCDistrictID);
                    ddlTaluka2.DataTextField = "TalukaName";
                    ddlTaluka2.DataValueField = "TalukaID";
                    ddlTaluka2.DataBind();
                    ddlTaluka2.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                    ddlTaluka2.SelectedValue = objHUC.HSCTalukaID.ToString();
                    if (ddlDistrict2.SelectedIndex > 0)
                    {
                        if (CandidatureTypeID == 5)
                        {
                            lblHomeUniversity.Text = "Other Than Home University";
                            hdnHomeUniversityID.Value = "99";
                        }
                        else
                        {
                            lblHomeUniversity.Text = ddlDistrict2.SelectedValue.Split(";".ToCharArray())[2].ToString();
                            hdnHomeUniversityID.Value = ddlDistrict2.SelectedValue.Split(";".ToCharArray())[1].ToString();
                        }
                    }
                    ddlCategory.SelectedValue = objHUC.CategoryID.ToString();
                    txtCasteNameForOpen.Text = objHUC.CasteNameForOpen;
                    ddlCaste.DataSource = reg.getMasterCasteForCategory(objHUC.CategoryID);
                    ddlCaste.DataTextField = "CasteName";
                    ddlCaste.DataValueField = "CasteID";
                    ddlCaste.DataBind();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                    ddlCaste.SelectedValue = objHUC.CasteID.ToString();
                    ddlCasteValidityStatus.SelectedValue = objHUC.CasteValidityStatus.ToString();
                    txtCVCApplicationNo.Text = objHUC.CVCApplicationNo;
                    txtAppDate.Text = objHUC.CVCApplicationDate;
                    txtCVCAuthority.Text = objHUC.CVCAuthority;
                    txtCVCName.Text = objHUC.CVCName;
                    txtCCNumber.Text = objHUC.CCNumber;
                    ddlCVCDistrict.SelectedValue = objHUC.CVCDistrict;

                    ddlPHType.SelectedValue = objSR.PHTypeID.ToString();
                    ddlDefenceType.SelectedValue = objSR.DefenceTypeID.ToString();
                    ddlIsOrphan.SelectedValue = objSR.IsOrphan;
                    if (CandidatureTypeID <= 2)
                    {
                        ddlAppliedForMinoritySeats.SelectedValue = objSR.AppliedForMinoritySeats;
                        if (objSR.LinguisticMinorityID > 0)
                        {
                            chkLinguisticMinority.Checked = true;
                            ddlLinguisticMinority.SelectedValue = objSR.LinguisticMinorityID.ToString();
                        }
                        if (objSR.ReligiousMinorityID > 0)
                        {
                            chkReligiousMinority.Checked = true;
                            ddlReligiousMinority.SelectedValue = objSR.ReligiousMinorityID.ToString();
                        }
                    }

                    onPageLoad();

                    if ((UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {

                    }
                    else if ((UserTypeID == 23 || UserTypeID == 24) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }
                    else if (UserTypeID == 43 || UserTypeID == 91)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlIsOrphan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int16 CandidatureTypeID = Convert.ToInt16(ddlCandidatureType.SelectedValue);
                Int16 CategoryID = Convert.ToInt16(ddlCategory.SelectedValue);
                string CasteValidityStatus = ddlCasteValidityStatus.SelectedValue;
                string AppliedForMinoritySeats = ddlAppliedForMinoritySeats.SelectedValue;

                ddlDistrict1.DataSource = ddlDistrict2.DataSource = Global.MasterMHDistrict;
                ddlDistrict1.DataTextField = ddlDistrict2.DataTextField = "DistrictName";
                ddlDistrict1.DataValueField = ddlDistrict2.DataValueField = "DistrictID";
                ddlDistrict1.DataBind();
                ddlDistrict2.DataBind();
                ddlDistrict1.Items.Insert(0, new ListItem("-- Select District --", "0"));
                ddlDistrict2.Items.Insert(0, new ListItem("-- Select District --", "0"));

                if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4)
                {
                    ddlDistrict1.Items.Remove(ddlDistrict1.Items.FindByText("Uttara Kannada (Karwar)"));
                    ddlDistrict1.Items.Remove(ddlDistrict1.Items.FindByText("Bidar"));
                    ddlDistrict1.Items.Remove(ddlDistrict1.Items.FindByText("Kalaburagi (Gulbarga)"));
                    ddlDistrict1.Items.Remove(ddlDistrict1.Items.FindByText("Belagavi (Belgaum)"));

                    ddlDistrict2.Items.Remove(ddlDistrict2.Items.FindByText("Uttara Kannada (Karwar)"));
                    ddlDistrict2.Items.Remove(ddlDistrict2.Items.FindByText("Bidar"));
                    ddlDistrict2.Items.Remove(ddlDistrict2.Items.FindByText("Kalaburagi (Gulbarga)"));
                    ddlDistrict2.Items.Remove(ddlDistrict2.Items.FindByText("Belagavi (Belgaum)"));

                    ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Uttara Kannada (Karwar)"));
                    ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Bidar"));
                    ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Kalaburagi (Gulbarga)"));
                    ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Belagavi (Belgaum)"));
                }

                trDocumentForTypeA.Visible = true;
                trDocumentOf.Visible = true;
                trMothersName.Visible = true;
                trQ1.Visible = true;

                if (CandidatureTypeID == 1)
                {
                    trDocumentOf.Visible = false;
                    trMothersName.Visible = false;
                    lblQ1.Text = "Select District from which Candidate has Passed SSC";
                    lblQ2.Text = "Select District from which Candidate has Passed HSC / Diploma";
                    lblQ21.Text = "Select Taluka from which Candidate has Passed HSC / Diploma";
                    cvDistrict1.ErrorMessage = "Please Select District from which Candidate has Passed SSC.";
                    cvDistrict2.ErrorMessage = "Please Select District from which Candidate has Passed HSC / Diploma.";
                    cvTaluka2.ErrorMessage = "Please Select Taluka from which Candidate has Passed HSC / Diploma.";

                    ddlDistrict1.Attributes.Add("onmouseover", "ddrivetip('Please Select District from which Candidate has Passed SSC.')");
                    ddlDistrict1.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlDistrict2.Attributes.Add("onmouseover", "ddrivetip('Please Select District from which Candidate has Passed HSC / Diploma.')");
                    ddlDistrict2.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlTaluka2.Attributes.Add("onmouseover", "ddrivetip('Please Select Taluka from which Candidate has Passed HSC / Diploma.')");
                    ddlTaluka2.Attributes.Add("onmouseout", "hideddrivetip()");
                }
                else if (CandidatureTypeID == 2)
                {
                    trDocumentForTypeA.Visible = false;
                    QDocumentOf.Text = "Whose Domicile Cerificate You are Submitting at SC ?";
                    trMothersName.Visible = false;
                    trQ1.Visible = false;
                    lblQ2.Text = "Select District where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra";
                    lblQ21.Text = "Select Taluka where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra";
                    cvDistrict2.ErrorMessage = "Please Select District where Candidate / Father / Mother of Candidate is Domiciled in the State of Maharashtra.";
                    cvTaluka2.ErrorMessage = "Please Select Taluka where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra.";

                    ddlDocumentOf.Attributes.Add("onmouseover", "ddrivetip('Please select whose Domicile Cerificate You are Submitting at SC.')");
                    ddlDocumentOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlDistrict2.Attributes.Add("onmouseover", "ddrivetip('Please Select District where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra.')");
                    ddlDistrict2.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlTaluka2.Attributes.Add("onmouseover", "ddrivetip('Please Select Taluka where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra.')");
                    ddlTaluka2.Attributes.Add("onmouseout", "hideddrivetip()");
                }
                else if (CandidatureTypeID == 3)
                {
                    trDocumentForTypeA.Visible = false;
                    QDocumentOf.Text = "Whose Proforma - A You are Submitting at SC ?";
                    ddlDocumentOf.Items.Remove(ddlDocumentOf.Items.FindByValue("C"));
                    trMothersName.Visible = false;
                    trQ1.Visible = false;
                    lblQ2.Text = "Select District where Father or Mother of Candidate is Posted in Maharashtra";
                    lblQ21.Text = "Select Taluka where Father or Mother of Candidate is Posted in Maharashtra";
                    cvDistrict2.ErrorMessage = "Please Select District where Father or Mother of Candidate is Posted in Maharashtra.";
                    cvTaluka2.ErrorMessage = "Please Select Taluka where Father or Mother of Candidate is Posted in Maharashtra.";

                    ddlDocumentOf.Attributes.Add("onmouseover", "ddrivetip('Please select whose Proforma - A You are Submitting at SC.')");
                    ddlDocumentOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlDistrict2.Attributes.Add("onmouseover", "ddrivetip('Please Select District where Father or Mother of Candidate is Posted in Maharashtra.')");
                    ddlDistrict2.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlTaluka2.Attributes.Add("onmouseover", "ddrivetip('Please Select Taluka where Father or Mother of Candidate is Posted in Maharashtra.')");
                    ddlTaluka2.Attributes.Add("onmouseout", "hideddrivetip()");
                }
                else if (CandidatureTypeID == 4)
                {
                    trDocumentForTypeA.Visible = false;
                    QDocumentOf.Text = "Whose Proforma - B / Undertaking for Place of Settlement You are Submitting at SC ?";
                    ddlDocumentOf.Items.Remove(ddlDocumentOf.Items.FindByValue("C"));
                    trMothersName.Visible = false;
                    trQ1.Visible = false;
                    lblQ2.Text = "Select District where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra";
                    lblQ21.Text = "Select Taluka where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra";
                    cvDistrict2.ErrorMessage = "Please Select District where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra.";
                    cvTaluka2.ErrorMessage = "Please Select Taluka where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra.";

                    ddlDocumentOf.Attributes.Add("onmouseover", "ddrivetip('Please select whose Proforma - B / Undertaking for Place of Settlement You are Submitting at SC.')");
                    ddlDocumentOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlDistrict2.Attributes.Add("onmouseover", "ddrivetip('Please Select District where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra.')");
                    ddlDistrict2.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlTaluka2.Attributes.Add("onmouseover", "ddrivetip('Please Select Taluka where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra.')");
                    ddlTaluka2.Attributes.Add("onmouseout", "hideddrivetip()");
                }
                else if (CandidatureTypeID == 5)
                {
                    trDocumentForTypeA.Visible = false;
                    trDocumentOf.Visible = false;
                    trMothersName.Visible = false;
                    lblQ1.Text = "Select District from which Candidate has Passed SSC";
                    lblQ2.Text = "Select District from which Candidate has Passed HSC / Diploma";
                    lblQ21.Text = "Select Taluka from which Candidate has Passed HSC / Diploma";
                    cvDistrict1.ErrorMessage = "Please Select District from which Candidate has Passed SSC.";
                    cvDistrict2.ErrorMessage = "Please Select District from which Candidate has Passed HSC / Diploma.";
                    cvTaluka2.ErrorMessage = "Please Select Taluka from which Candidate has Passed HSC / Diploma.";

                    ddlDistrict1.Attributes.Add("onmouseover", "ddrivetip('Please Select District from which Candidate has Passed SSC.')");
                    ddlDistrict1.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlDistrict2.Attributes.Add("onmouseover", "ddrivetip('Please Select District from which Candidate has Passed HSC / Diploma.')");
                    ddlDistrict2.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlTaluka2.Attributes.Add("onmouseover", "ddrivetip('Please Select Taluka from which Candidate has Passed HSC / Diploma.')");
                    ddlTaluka2.Attributes.Add("onmouseout", "hideddrivetip()");
                }

                if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4)
                {
                    tblHomeUniversity.Visible = true;
                    tblCategory.Visible = true;
                    tblSpecialReservation.Visible = true;
                }
                else if (CandidatureTypeID == 5)
                {
                    tblHomeUniversity.Visible = true;
                    tblCategory.Visible = false;
                    tblSpecialReservation.Visible = false;
                }
                else
                {
                    tblHomeUniversity.Visible = false;
                    tblCategory.Visible = false;
                    tblSpecialReservation.Visible = false;
                }

                ddlDocumentForTypeA.SelectedIndex = 0;
                ddlDocumentOf.SelectedIndex = 0;
                txtMothersName.Text = "";
                ddlDistrict1.SelectedIndex = 0;
                ddlDistrict2.SelectedIndex = 0;
                ddlTaluka2.Items.Clear();
                ddlTaluka2.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                lblHomeUniversity.Text = "";
                hdnHomeUniversityID.Value = "";

                if (CandidatureTypeID > 4)
                {
                    ddlCategory.SelectedIndex = 0;
                    txtCasteNameForOpen.Text = "";
                    ddlCaste.SelectedIndex = 0;
                    ddlCasteValidityStatus.SelectedIndex = 0;
                    txtCVCApplicationNo.Text = "";
                    txtAppDate.Text = "";
                    txtCVCAuthority.Text = "";
                    txtCVCName.Text = "";
                    txtCCNumber.Text = "";
                    ddlCVCDistrict.SelectedValue = "0";
                    ddlPHType.SelectedIndex = 0;
                    ddlDefenceType.SelectedIndex = 0;
                }

                if (CandidatureTypeID > 2)
                {
                    ddlAppliedForMinoritySeats.SelectedIndex = 0;
                    chkLinguisticMinority.Checked = false;
                    chkReligiousMinority.Checked = false;
                    ddlLinguisticMinority.SelectedValue = "0";
                    ddlReligiousMinority.SelectedValue = "0";
                }

                if (CandidatureTypeID == 2)
                {
                    if (ddlDocumentOf.SelectedValue == "M")
                    {
                        trMothersName.Visible = true;
                    }
                    else
                    {
                        trMothersName.Visible = false;
                    }
                }
                else
                {
                    trMothersName.Visible = false;
                }

                if (CategoryID == 0)
                {
                    trOpenCaste.Visible = false;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;
                }
                else if (CategoryID == 1)
                {
                    trOpenCaste.Visible = true;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;
                }
                else if (CategoryID >= 2)
                {
                    trOpenCaste.Visible = false;
                    trReservedCaste.Visible = true;
                    trCasteValidityStatus.Visible = true;
                }
                else
                {
                    trOpenCaste.Visible = false;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;
                }

                if (CasteValidityStatus == "A")
                {
                    trCasteValidityApplied1.Visible = true;
                    trCasteValidityApplied2.Visible = true;
                    trCasteValidityApplied3.Visible = true;
                    trCasteValidityApplied4.Visible = true;
                    trCasteValidityApplied5.Visible = true;
                    trCasteValidityApplied6.Visible = true;
                }
                else
                {
                    trCasteValidityApplied1.Visible = false;
                    trCasteValidityApplied2.Visible = false;
                    trCasteValidityApplied3.Visible = false;
                    trCasteValidityApplied4.Visible = false;
                    trCasteValidityApplied5.Visible = false;
                    trCasteValidityApplied6.Visible = false;
                }

                if (CandidatureTypeID > 2)
                {
                    trMinority.Visible = false;
                    trMinorityStatus.Visible = false;
                    trLinguisticMinority.Visible = false;
                    trReligiousMinority.Visible = false;
                }
                else
                {
                    trMinority.Visible = true;

                    if (AppliedForMinoritySeats == "Yes")
                    {
                        trMinorityStatus.Visible = true;
                        if (chkLinguisticMinority.Checked)
                        {
                            trLinguisticMinority.Visible = true;
                        }
                        else
                        {
                            trLinguisticMinority.Visible = false;
                        }
                        if (chkReligiousMinority.Checked)
                        {
                            trReligiousMinority.Visible = true;
                        }
                        else
                        {
                            trReligiousMinority.Visible = false;
                        }
                    }
                    else
                    {
                        trMinorityStatus.Visible = false;
                        trLinguisticMinority.Visible = false;
                        trReligiousMinority.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlDocumentOf_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int16 CandidatureTypeID = Convert.ToInt16(ddlCandidatureType.SelectedValue);

                if (CandidatureTypeID == 2)
                {
                    if (ddlDocumentOf.SelectedValue == "M")
                    {
                        trMothersName.Visible = true;
                    }
                    else
                    {
                        trMothersName.Visible = false;
                    }
                }
                else
                {
                    trMothersName.Visible = false;
                }

                txtMothersName.Text = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlDistrict2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int16 CandidatureTypeID = Convert.ToInt16(ddlCandidatureType.SelectedValue);

                if (ddlDistrict2.SelectedIndex != 0)
                {
                    Int32 DistrictID = Convert.ToInt32(ddlDistrict2.SelectedValue.Split(";".ToCharArray())[0]);
                    ddlTaluka2.DataSource = reg.getMasterMHTalukaForMHDistrict(DistrictID);
                    ddlTaluka2.DataTextField = "TalukaName";
                    ddlTaluka2.DataValueField = "TalukaID";
                    ddlTaluka2.DataBind();
                    ddlTaluka2.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));

                    if (CandidatureTypeID == 5)
                    {
                        lblHomeUniversity.Text = "Other Than Home University";
                        hdnHomeUniversityID.Value = "99";
                    }
                    else
                    {
                        lblHomeUniversity.Text = ddlDistrict2.SelectedValue.Split(";".ToCharArray())[2].ToString();
                        hdnHomeUniversityID.Value = ddlDistrict2.SelectedValue.Split(";".ToCharArray())[1].ToString();
                    }
                }
                else
                {
                    ddlTaluka2.Items.Clear();
                    ddlTaluka2.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                    lblHomeUniversity.Text = "";
                    hdnHomeUniversityID.Value = "";
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int16 CategoryID = Convert.ToInt16(ddlCategory.SelectedValue);

                if (CategoryID == 0)
                {
                    trOpenCaste.Visible = false;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;

                    ddlCaste.Items.Clear();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }
                else if (CategoryID == 1)
                {
                    trOpenCaste.Visible = true;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;

                    ddlCaste.Items.Clear();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }
                else if (CategoryID == 2 || CategoryID == 3)
                {
                    trOpenCaste.Visible = false;
                    trReservedCaste.Visible = true;
                    trCasteValidityStatus.Visible = true;

                    ddlCaste.DataSource = reg.getMasterCasteForCategory(CategoryID);
                    ddlCaste.DataTextField = "CasteName";
                    ddlCaste.DataValueField = "CasteID";
                    ddlCaste.DataBind();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }
                else if (CategoryID == 4 || CategoryID == 5 || CategoryID == 6 || CategoryID == 7 || CategoryID == 8 || CategoryID == 9)
                {
                    trOpenCaste.Visible = false;
                    trReservedCaste.Visible = true;
                    trCasteValidityStatus.Visible = true;

                    ddlCaste.DataSource = reg.getMasterCasteForCategory(CategoryID);
                    ddlCaste.DataTextField = "CasteName";
                    ddlCaste.DataValueField = "CasteID";
                    ddlCaste.DataBind();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }
                else
                {
                    trOpenCaste.Visible = false;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;

                    ddlCaste.Items.Clear();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }

                trCasteValidityApplied1.Visible = false;
                trCasteValidityApplied2.Visible = false;
                trCasteValidityApplied3.Visible = false;
                trCasteValidityApplied4.Visible = false;
                trCasteValidityApplied5.Visible = false;
                trCasteValidityApplied6.Visible = false;

                txtCasteNameForOpen.Text = "";
                ddlCasteValidityStatus.SelectedIndex = 0;
                txtCVCApplicationNo.Text = "";
                txtAppDate.Text = "";
                txtCVCAuthority.Text = "";
                txtCVCName.Text = "";
                txtCCNumber.Text = "";
                ddlCVCDistrict.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlCasteValidityStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string CasteValidityStatus = ddlCasteValidityStatus.SelectedValue;

                if (CasteValidityStatus == "A")
                {
                    trCasteValidityApplied1.Visible = true;
                    trCasteValidityApplied2.Visible = true;
                    trCasteValidityApplied3.Visible = true;
                    trCasteValidityApplied4.Visible = true;
                    trCasteValidityApplied5.Visible = true;
                    trCasteValidityApplied6.Visible = true;
                }
                else
                {
                    trCasteValidityApplied1.Visible = false;
                    trCasteValidityApplied2.Visible = false;
                    trCasteValidityApplied3.Visible = false;
                    trCasteValidityApplied4.Visible = false;
                    trCasteValidityApplied5.Visible = false;
                    trCasteValidityApplied6.Visible = false;
                }

                txtCVCApplicationNo.Text = "";
                txtAppDate.Text = "";
                txtCVCAuthority.Text = "";
                txtCVCName.Text = "";
                txtCCNumber.Text = "";
                ddlCVCDistrict.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlAppliedForMinoritySeats_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string AppliedForMinoritySeats = ddlAppliedForMinoritySeats.SelectedValue;

                if (AppliedForMinoritySeats == "Yes")
                {
                    trMinorityStatus.Visible = true;
                }
                else
                {
                    trMinorityStatus.Visible = false;

                }
                trLinguisticMinority.Visible = false;
                trReligiousMinority.Visible = false;

                chkLinguisticMinority.Checked = false;
                chkReligiousMinority.Checked = false;
                ddlLinguisticMinority.SelectedValue = "0";
                ddlReligiousMinority.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void LinguisticMinorityStatus_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (chkLinguisticMinority.Checked)
                {
                    trLinguisticMinority.Visible = true;
                }
                else
                {
                    trLinguisticMinority.Visible = false;
                }

                ddlLinguisticMinority.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ReligiousMinorityStatus_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (chkReligiousMinority.Checked)
                {
                    trReligiousMinority.Visible = true;
                }
                else
                {
                    trReligiousMinority.Visible = false;
                }

                ddlReligiousMinority.SelectedValue = "0";
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
                Int16 CandidatureTypeID = Convert.ToInt16(ddlCandidatureType.SelectedValue);
                Int16 CategoryID = Convert.ToInt16(ddlCategory.SelectedValue);
                string CasteValidityStatus = ddlCasteValidityStatus.SelectedValue;
                string AppliedForMinoritySeats = ddlAppliedForMinoritySeats.SelectedValue;

                if (CandidatureTypeID == 1)
                {
                    trDocumentOf.Visible = false;
                    trMothersName.Visible = false;
                    lblQ1.Text = "Select District from which Candidate has Passed SSC";
                    lblQ2.Text = "Select District from which Candidate has Passed HSC / Diploma";
                    lblQ21.Text = "Select Taluka from which Candidate has Passed HSC / Diploma";
                    cvDistrict1.ErrorMessage = "Please Select District from which Candidate has Passed SSC.";
                    cvDistrict2.ErrorMessage = "Please Select District from which Candidate has Passed HSC / Diploma.";
                    cvTaluka2.ErrorMessage = "Please Select Taluka from which Candidate has Passed HSC / Diploma.";

                    ddlDistrict1.Attributes.Add("onmouseover", "ddrivetip('Please Select District from which Candidate has Passed SSC.')");
                    ddlDistrict1.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlDistrict2.Attributes.Add("onmouseover", "ddrivetip('Please Select District from which Candidate has Passed HSC / Diploma.')");
                    ddlDistrict2.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlTaluka2.Attributes.Add("onmouseover", "ddrivetip('Please Select Taluka from which Candidate has Passed HSC / Diploma.')");
                    ddlTaluka2.Attributes.Add("onmouseout", "hideddrivetip()");
                }
                else if (CandidatureTypeID == 2)
                {
                    trDocumentForTypeA.Visible = false;
                    QDocumentOf.Text = "Whose Domicile Cerificate You are Submitting at SC ?";
                    trMothersName.Visible = false;
                    trQ1.Visible = false;
                    lblQ2.Text = "Select District where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra";
                    lblQ21.Text = "Select Taluka where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra";
                    cvDistrict2.ErrorMessage = "Please Select District where Candidate / Father / Mother of Candidate is Domiciled in the State of Maharashtra.";
                    cvTaluka2.ErrorMessage = "Please Select Taluka where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra.";

                    ddlDocumentOf.Attributes.Add("onmouseover", "ddrivetip('Please select whose Domicile Cerificate You are Submitting at SC.')");
                    ddlDocumentOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlDistrict2.Attributes.Add("onmouseover", "ddrivetip('Please Select District where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra.')");
                    ddlDistrict2.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlTaluka2.Attributes.Add("onmouseover", "ddrivetip('Please Select Taluka where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra.')");
                    ddlTaluka2.Attributes.Add("onmouseout", "hideddrivetip()");
                }
                else if (CandidatureTypeID == 3)
                {
                    trDocumentForTypeA.Visible = false;
                    QDocumentOf.Text = "Whose Proforma - A You are Submitting at SC ?";
                    ddlDocumentOf.Items.Remove(ddlDocumentOf.Items.FindByValue("C"));
                    trMothersName.Visible = false;
                    trQ1.Visible = false;
                    lblQ2.Text = "Select District where Father or Mother of Candidate is Posted in Maharashtra";
                    lblQ21.Text = "Select Taluka where Father or Mother of Candidate is Posted in Maharashtra";
                    cvDistrict2.ErrorMessage = "Please Select District where Father or Mother of Candidate is Posted in Maharashtra.";
                    cvTaluka2.ErrorMessage = "Please Select Taluka where Father or Mother of Candidate is Posted in Maharashtra.";

                    ddlDocumentOf.Attributes.Add("onmouseover", "ddrivetip('Please select whose Proforma - A You are Submitting at SC.')");
                    ddlDocumentOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlDistrict2.Attributes.Add("onmouseover", "ddrivetip('Please Select District where Father or Mother of Candidate is Posted in Maharashtra.')");
                    ddlDistrict2.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlTaluka2.Attributes.Add("onmouseover", "ddrivetip('Please Select Taluka where Father or Mother of Candidate is Posted in Maharashtra.')");
                    ddlTaluka2.Attributes.Add("onmouseout", "hideddrivetip()");
                }
                else if (CandidatureTypeID == 4)
                {
                    trDocumentForTypeA.Visible = false;
                    QDocumentOf.Text = "Whose Proforma - B / Undertaking for Place of Settlement You are Submitting at SC ?";
                    ddlDocumentOf.Items.Remove(ddlDocumentOf.Items.FindByValue("C"));
                    trMothersName.Visible = false;
                    trQ1.Visible = false;
                    lblQ2.Text = "Select District where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra";
                    lblQ21.Text = "Select Taluka where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra";
                    cvDistrict2.ErrorMessage = "Please Select District where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra.";
                    cvTaluka2.ErrorMessage = "Please Select Taluka where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra.";

                    ddlDocumentOf.Attributes.Add("onmouseover", "ddrivetip('Please select whose Proforma - B / Undertaking for Place of Settlement You are Submitting at SC.')");
                    ddlDocumentOf.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlDistrict2.Attributes.Add("onmouseover", "ddrivetip('Please Select District where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra.')");
                    ddlDistrict2.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlTaluka2.Attributes.Add("onmouseover", "ddrivetip('Please Select Taluka where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra.')");
                    ddlTaluka2.Attributes.Add("onmouseout", "hideddrivetip()");
                }
                else if (CandidatureTypeID == 5)
                {
                    trDocumentForTypeA.Visible = false;
                    trDocumentOf.Visible = false;
                    trMothersName.Visible = false;
                    lblQ1.Text = "Select District from which Candidate has Passed SSC";
                    lblQ2.Text = "Select District from which Candidate has Passed HSC / Diploma.";
                    lblQ21.Text = "Select Taluka from which Candidate has Passed HSC / Diploma.";
                    cvDistrict1.ErrorMessage = "Please Select District from which Candidate has Passed SSC.";
                    cvDistrict2.ErrorMessage = "Please Select District from which Candidate has Passed HSC / Diploma.";
                    cvTaluka2.ErrorMessage = "Please Select Taluka from which Candidate has Passed HSC / Diploma.";

                    ddlDistrict1.Attributes.Add("onmouseover", "ddrivetip('Please Select District from which Candidate has Passed SSC.')");
                    ddlDistrict1.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlDistrict2.Attributes.Add("onmouseover", "ddrivetip('Please Select District from which Candidate has Passed HSC / Diploma.')");
                    ddlDistrict2.Attributes.Add("onmouseout", "hideddrivetip()");
                    ddlTaluka2.Attributes.Add("onmouseover", "ddrivetip('Please Select Taluka from which Candidate has Passed HSC / Diploma.')");
                    ddlTaluka2.Attributes.Add("onmouseout", "hideddrivetip()");
                }

                if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4)
                {
                    tblHomeUniversity.Visible = true;
                    tblCategory.Visible = true;
                    tblSpecialReservation.Visible = true;
                }
                else if (CandidatureTypeID == 5)
                {
                    tblHomeUniversity.Visible = true;
                    tblCategory.Visible = false;
                    tblSpecialReservation.Visible = false;
                }
                else
                {
                    tblHomeUniversity.Visible = false;
                    tblCategory.Visible = false;
                    tblSpecialReservation.Visible = false;
                }

                if (CandidatureTypeID == 2)
                {
                    if (ddlDocumentOf.SelectedValue == "M")
                    {
                        trMothersName.Visible = true;
                    }
                    else
                    {
                        trMothersName.Visible = false;
                    }
                }
                else
                {
                    trMothersName.Visible = false;
                }

                if (CategoryID == 0)
                {
                    trOpenCaste.Visible = false;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;
                }
                else if (CategoryID == 1)
                {
                    trOpenCaste.Visible = true;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;
                }
                else if (CategoryID >= 2)
                {
                    trOpenCaste.Visible = false;
                    trReservedCaste.Visible = true;
                    trCasteValidityStatus.Visible = true;
                }
                else
                {
                    trOpenCaste.Visible = false;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;
                }

                if (CasteValidityStatus == "A")
                {
                    trCasteValidityApplied1.Visible = true;
                    trCasteValidityApplied2.Visible = true;
                    trCasteValidityApplied3.Visible = true;
                    trCasteValidityApplied4.Visible = true;
                    trCasteValidityApplied5.Visible = true;
                    trCasteValidityApplied6.Visible = true;
                }
                else
                {
                    trCasteValidityApplied1.Visible = false;
                    trCasteValidityApplied2.Visible = false;
                    trCasteValidityApplied3.Visible = false;
                    trCasteValidityApplied4.Visible = false;
                    trCasteValidityApplied5.Visible = false;
                    trCasteValidityApplied6.Visible = false;
                }

                if (CandidatureTypeID > 2)
                {
                    trMinority.Visible = false;
                    trMinorityStatus.Visible = false;
                    trLinguisticMinority.Visible = false;
                    trReligiousMinority.Visible = false;
                }
                else
                {
                    if (AppliedForMinoritySeats == "Yes")
                    {
                        trMinorityStatus.Visible = true;
                        if (chkLinguisticMinority.Checked)
                        {
                            trLinguisticMinority.Visible = true;
                        }
                        else
                        {
                            trLinguisticMinority.Visible = false;
                        }
                        if (chkReligiousMinority.Checked)
                        {
                            trReligiousMinority.Visible = true;
                        }
                        else
                        {
                            trReligiousMinority.Visible = false;
                        }
                    }
                    else
                    {
                        trMinorityStatus.Visible = false;
                        trLinguisticMinority.Visible = false;
                        trReligiousMinority.Visible = false;
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                HomeUniversityAndCategoryDetails objHUC = new HomeUniversityAndCategoryDetails();
                SpecialReservationDetails objSR = new SpecialReservationDetails();

                Int16 CandidatureTypeID = Convert.ToInt16(ddlCandidatureType.SelectedValue);

                if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4)
                {
                    objHUC.DocumentForTypeACode = Convert.ToChar(ddlDocumentForTypeA.SelectedValue);
                    objHUC.DocumentOfCode = Convert.ToChar(ddlDocumentOf.SelectedValue);
                    objHUC.MothersName = txtMothersName.Text;
                    if (CandidatureTypeID == 1)
                    {
                        objHUC.SSCDistrictID = Convert.ToInt32((ddlDistrict1.SelectedValue.Split(";".ToCharArray()))[0].ToString());
                    }
                    else
                    {
                        objHUC.SSCDistrictID = 0;
                    }
                    objHUC.HSCDistrictID = Convert.ToInt32((ddlDistrict2.SelectedValue.Split(";".ToCharArray()))[0].ToString());
                    objHUC.HSCTalukaID = Convert.ToInt32(ddlTaluka2.SelectedValue);
                    objHUC.HomeUniversityID = Convert.ToInt16(hdnHomeUniversityID.Value);
                    objHUC.CategoryID = Convert.ToInt16(ddlCategory.SelectedValue);
                    objHUC.CasteNameForOpen = txtCasteNameForOpen.Text;
                    objHUC.CasteID = Convert.ToInt16(ddlCaste.SelectedValue);
                    objHUC.CasteValidityStatus = Convert.ToChar(ddlCasteValidityStatus.SelectedValue);
                    objHUC.CVCApplicationNo = txtCVCApplicationNo.Text;
                    objHUC.CVCApplicationDate = txtAppDate.Text;
                    objHUC.CVCAuthority = txtCVCAuthority.Text;
                    objHUC.CVCName = txtCVCName.Text;
                    objHUC.CCNumber = txtCCNumber.Text;
                    objHUC.CVCDistrict = ddlCVCDistrict.SelectedValue;

                    objSR.PHTypeID = Convert.ToInt16(ddlPHType.SelectedValue);
                    objSR.DefenceTypeID = Convert.ToInt16(ddlDefenceType.SelectedValue);
                    objSR.IsOrphan = ddlIsOrphan.SelectedValue;
                    if (CandidatureTypeID == 1 || CandidatureTypeID == 2)
                    {
                        objSR.AppliedForMinoritySeats = ddlAppliedForMinoritySeats.SelectedValue;
                        objSR.LinguisticMinorityID = Convert.ToInt16(ddlLinguisticMinority.SelectedValue);
                        objSR.ReligiousMinorityID = Convert.ToInt16(ddlReligiousMinority.SelectedValue);
                    }
                    else
                    {
                        objSR.AppliedForMinoritySeats = "Not Applicable";
                        objSR.LinguisticMinorityID = 0;
                        objSR.ReligiousMinorityID = 0;
                    }
                }
                else if (CandidatureTypeID == 5)
                {
                    objHUC.DocumentForTypeACode = 'N';
                    objHUC.DocumentOfCode = 'N';
                    objHUC.MothersName = "";
                    objHUC.SSCDistrictID = Convert.ToInt32((ddlDistrict1.SelectedValue.Split(";".ToCharArray()))[0].ToString());
                    objHUC.HSCDistrictID = Convert.ToInt32((ddlDistrict2.SelectedValue.Split(";".ToCharArray()))[0].ToString());
                    objHUC.HSCTalukaID = Convert.ToInt32(ddlTaluka2.SelectedValue);
                    objHUC.HomeUniversityID = Convert.ToInt16(hdnHomeUniversityID.Value);
                    objHUC.CategoryID = 0;
                    objHUC.CasteNameForOpen = "";
                    objHUC.CasteID = 0;
                    objHUC.CasteValidityStatus = '0';
                    objHUC.CVCApplicationNo = "";
                    objHUC.CVCApplicationDate = "";
                    objHUC.CVCAuthority = "";
                    objHUC.CVCName = "";
                    objHUC.CCNumber = "";
                    objHUC.CVCDistrict = "";

                    objSR.PHTypeID = 0;
                    objSR.DefenceTypeID = 0;
                    objSR.IsOrphan = "0";
                    objSR.AppliedForMinoritySeats = "Not Applicable";
                    objSR.LinguisticMinorityID = 0;
                    objSR.ReligiousMinorityID = 0;
                }
                else
                {
                    objHUC.DocumentForTypeACode = 'N';
                    objHUC.DocumentOfCode = 'N';
                    objHUC.MothersName = "";
                    objHUC.SSCDistrictID = 0;
                    objHUC.HSCDistrictID = 0;
                    objHUC.HSCTalukaID = 0;
                    objHUC.HomeUniversityID = 99;
                    objHUC.CategoryID = 0;
                    objHUC.CasteNameForOpen = "";
                    objHUC.CasteID = 0;
                    objHUC.CasteValidityStatus = '0';
                    objHUC.CVCApplicationNo = "";
                    objHUC.CVCApplicationDate = "";
                    objHUC.CVCAuthority = "";
                    objHUC.CVCName = "";
                    objHUC.CCNumber = "";
                    objHUC.CVCDistrict = "";

                    objSR.PHTypeID = 0;
                    objSR.DefenceTypeID = 0;
                    objSR.IsOrphan = "0";
                    objSR.AppliedForMinoritySeats = "Not Applicable";
                    objSR.LinguisticMinorityID = 0;
                    objSR.ReligiousMinorityID = 0;
                }
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                string MotherTongue = reg.getMotherTongue(PID);
                string Nationality = reg.getNationality(PID);

                if (MotherTongue != "Marathi" && CandidatureTypeID == 5)
                {
                    shInfo.SetMessage("Your Mother Tongue is not Marathi. So You can not select this Type of Candidature.", ShowMessageType.Information);
                }
                else if (Nationality != "India" && (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4 || CandidatureTypeID == 5 || CandidatureTypeID == 7 || CandidatureTypeID == 8 || CandidatureTypeID == 9 || CandidatureTypeID == 10 || CandidatureTypeID == 15 || CandidatureTypeID == 16))
                {
                    shInfo.SetMessage("Your Nationality is not Indian. So You can not select this Type of Candidature.", ShowMessageType.Information);
                }
                else if (Nationality == "India" && (CandidatureTypeID == 11 || CandidatureTypeID == 13 || CandidatureTypeID == 17))
                {
                    shInfo.SetMessage("Your Nationality is Indian. So You can not select this Type of Candidature.", ShowMessageType.Information);
                }
                else
                {
                    DataSet dsChkCETApplicationNo = reg.EditApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp(PID, CandidatureTypeID);

                    if (dsChkCETApplicationNo.Tables[0].Rows[0]["Status"].ToString() == "0" && dsChkCETApplicationNo.Tables[0].Rows.Count > 0)
                    {
                        string CETApplicationFormNo = dsChkCETApplicationNo.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();
                        string sApplicationID = dsChkCETApplicationNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                        string sConfirmedBy = dsChkCETApplicationNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                        shInfo.SetMessage("Application Form using CET Application Number " + CETApplicationFormNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
                    }
                    else
                    {
                        if (reg.editCandidatureTypeDetails(PID, CandidatureTypeID, objHUC, objSR, ModifiedBy, ModifiedByIPAddress))
                        {
                            Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
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
}