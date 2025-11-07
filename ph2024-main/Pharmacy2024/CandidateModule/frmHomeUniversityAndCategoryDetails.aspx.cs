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
    public partial class frmHomeUniversityAndCategoryDetails : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string NextYear = Global.NextYear;
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
                    if (reg.CheckFCVerificationStatus(objSessionData.PID))
                    {
                        shInfo.SetMessage("Application Form is Confirmed or Has been picked for SC E-Verification", ShowMessageType.Information);
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }
                    DataSet dsCurrentLink = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmHomeUniversityAndCategoryDetails");

                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if ((objSessionData.ApplicationFormStatus == 'A' || objSessionData.StepID < 2) && (FCVerificationStatus == 'C' || FCVerificationStatus == 'P'))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }
                    if (reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "Y")
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }

                    lblAnnualFamilyIncome.Text = reg.getAnnualFamilyIncomeDetails(objSessionData.PID);

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

                    ddlCVCDistrict.DataSource = Global.MasterMHDistrict;
                    ddlCVCDistrict.DataTextField = "DistrictName";
                    ddlCVCDistrict.DataValueField = "DistrictName";
                    ddlCVCDistrict.DataBind();
                    ddlCVCDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));

                    ddlEWSDistrict.DataSource = Global.MasterMHDistrict;
                    ddlEWSDistrict.DataTextField = "DistrictName";
                    ddlEWSDistrict.DataValueField = "DistrictID";
                    ddlEWSDistrict.DataBind();
                    ddlEWSDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));

                    if (objSessionData.CandidatureTypeID == 1 || objSessionData.CandidatureTypeID == 2 || objSessionData.CandidatureTypeID == 3 || objSessionData.CandidatureTypeID == 4)
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

                        ddlEWSDistrict.Items.Remove(ddlEWSDistrict.Items.FindByText("Uttara Kannada (Karwar)"));
                        ddlEWSDistrict.Items.Remove(ddlEWSDistrict.Items.FindByText("Bidar"));
                        ddlEWSDistrict.Items.Remove(ddlEWSDistrict.Items.FindByText("Kalaburagi (Gulbarga)"));
                        ddlEWSDistrict.Items.Remove(ddlEWSDistrict.Items.FindByText("Belagavi (Belgaum)"));
                    }
                    //else if (objSessionData.CandidatureTypeID == 5)//MKB
                    //{
                    //    ddlDistrict2.Items.Clear();
                    //    ddlDistrict2.Items.Insert(0, new ListItem("-- Select District --", "0"));
                    //    ddlDistrict2.Items.Insert(1, new ListItem("Belagavi (Belgaum)", "1227"));
                    //    ddlDistrict2.Items.Insert(2, new ListItem("Bidar", "1229"));
                    //    ddlDistrict2.Items.Insert(3, new ListItem("Kalaburagi (Gulbarga)", "1238"));
                    //    ddlDistrict2.Items.Insert(4, new ListItem("Uttara Kannada (Karwar)", "1250"));

                    //    ddlCVCDistrict.Items.Clear();
                    //    ddlCVCDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
                    //    ddlCVCDistrict.Items.Insert(1, new ListItem("Belagavi (Belgaum)", "1227"));
                    //    ddlCVCDistrict.Items.Insert(2, new ListItem("Bidar", "1229"));
                    //    ddlCVCDistrict.Items.Insert(3, new ListItem("Kalaburagi (Gulbarga)", "1238"));
                    //    ddlCVCDistrict.Items.Insert(4, new ListItem("Uttara Kannada (Karwar)", "1250"));
                    //}

                    ddlTaluka2.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                    ddlEWSTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                    ddlQ31Village.Items.Insert(0, new ListItem("-- Select Village --", "0"));//MKB

                    ddlCategory.DataSource = Global.MasterCategory;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));

                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));

                    if (objSessionData.CandidatureTypeID == 1)
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;

                        lblCandidatureType.Text += "<b>Maharashtra - Type A</b>";
                        lblQ1.Text = "Select District from which Candidate has Passed SSC <br/>उमेदवाराने दहावी उत्तीर्ण केलेला जिल्हा निवडा";
                        lblQ2.Text = "Select District from which Candidate has Passed HSC / Diploma <br/> उमेदवाराने बारावी / अभियांत्रिकी व तंत्रज्ञान पदविका उत्तीर्ण केलेला जिल्हा निवडा";
                        lblQ21.Text = "Select Taluka from which Candidate has Passed HSC / Diploma <br/> उमेदवाराने बारावी / अभियांत्रिकी व तंत्रज्ञान पदविका उत्तीर्ण केलेला तालुका निवडा  ";
                        cvDistrict1.ErrorMessage = "Please Select District from which Candidate has Passed SSC.";
                        cvDistrict2.ErrorMessage = "Please Select District from which Candidate has Passed HSC / Diploma.";
                        cvTaluka2.ErrorMessage = "Please Select Taluka from which Candidate has Passed HSC / Diploma.";
                        lblRequiredDocumentsByCandidatureType.Text = "<p align = 'justify'><font color = 'red'>You are required to Upload the Domicile Certificate / Birth Certificate / School Leaving Certificate of Candidate stating that the Birth Place is in Maharashtra.</font></p>";

                        //lblQ31Village.Text = "Select Village from which Candidate has Passed/Appearing HSC <br/> उमेदवाराने बारावी उत्तीर्ण झालेले/देत असलेला गाव निवडा";//MKB
                        //cvVillage2.ErrorMessage = "Please Select Village from which candidate has Passed/Appearing HSC.";//MKB
                        //ddlQ31Village.Attributes.Add("onmouseover", "ddrivetip('Please Select Village from which Candidate has Passed/Appearing HSC.')");//MKB
                        //ddlQ31Village.Attributes.Add("onmouseout", "hideddrivetip()");//MKB
                        trQ31Village.Visible = false;//MKB
                    }
                    else if (objSessionData.CandidatureTypeID == 2)
                    {
                        trDocumentForTypeA.Visible = false;
                        trMothersName.Visible = false;
                        trQ1.Visible = false;

                        lblCandidatureType.Text += "<b>Maharashtra - Type B</b>";
                        QDocumentOf.Text = "Whose Domicile Certificate You are Uploading Online ? <br/> आपण कोणाचे अधिवास प्रमाणपत्र सादर करत आहात ?";
                        lblQ2.Text = "Select District where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra <br/> उमेदवाराचे किंवा वडीलाचे किंवा आईचे अधिवास प्रमाणपत्र असलेला महाराष्ट्रातील जिल्हा निवडा";
                        lblQ21.Text = "Select Taluka where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra <br/> उमेदवाराचे किंवा वडीलाचे किंवा आईचे अधिवास प्रमाणपत्र असलेला महाराष्ट्रातील तालुका निवडा";
                        cvDocumentOf.ErrorMessage = "Please Select Whose Domicile Certificate You are Uploading Online ?.";
                        cvDistrict2.ErrorMessage = "Please Select District where Candidate / Father / Mother of Candidate is Domiciled in the State of Maharashtra.";
                        cvTaluka2.ErrorMessage = "Please Select Taluka where Candidate / Father or Mother of Candidate is Domiciled in the State of Maharashtra.";
                        lblRequiredDocumentsByCandidatureType.Text = "<p align = 'justify'><font color = 'red'>You are required to Upload the Domicile Certificate clearly indicating the place of 'Permanent Residence' or 'Birth' of Candidate / Father or Mother of Candidate.</font></p>";
                        trQ31Village.Visible = false;//MKB
                    }
                    else if (objSessionData.CandidatureTypeID == 3)
                    {
                        trDocumentForTypeA.Visible = false;
                        trMothersName.Visible = false;
                        trQ1.Visible = false;

                        lblCandidatureType.Text += "<b>Maharashtra - Type C</b>";
                        QDocumentOf.Text = "Whose Proforma - A You are Uploading Online ? <br/> आपण कोणाचा नमुना - अ सुविधा केंद्रावर सादर करणार ?";
                        ddlDocumentOf.Items.Remove(ddlDocumentOf.Items.FindByValue("C"));
                        lblQ2.Text = "Select District where Father or Mother of Candidate is Posted in Maharashtra <br/> उमेदवाराचे वडिल किंवा आई नोकरी करित असलेला महाराष्ट्रातील जिल्हा निवडा.";
                        lblQ21.Text = "Select Taluka where Father or Mother of Candidate is Posted in Maharashtra <br/> उमेदवाराचे वडिल किंवा आई नोकरी करित असलेला महाराष्ट्रातील तालुका निवडा.";
                        cvDocumentOf.ErrorMessage = "Please Select Whose Domicile Cerificate You are Uploading Online ?.";
                        cvDistrict2.ErrorMessage = "Please Select District where Father or Mother of Candidate is Posted in Maharashtra.";
                        cvTaluka2.ErrorMessage = "Please Select Taluka where Father or Mother of Candidate is Posted in Maharashtra.";
                        lblRequiredDocumentsByCandidatureType.Text = "<p align = 'justify'><font color = 'red'>You are required to Upload the Proforma - A .</font></p>";
                        trQ31Village.Visible = false;//MKB
                    }
                    else if (objSessionData.CandidatureTypeID == 4)
                    {
                        lblCandidatureType.Text += "<b>Maharashtra - Type D</b>";
                        trDocumentForTypeA.Visible = false;
                        QDocumentOf.Text = "Whose Proforma - B / Undertaking for Place of Settlement You are Uploading Online ? <br/>आपण कोणाचा नमुना - ब  / निवासी असल्याचा हमी अर्ज सुविधा केंद्रावर सादर करणार ?";
                        ddlDocumentOf.Items.Remove(ddlDocumentOf.Items.FindByValue("C"));
                        trMothersName.Visible = false;
                        trQ1.Visible = false;
                        lblQ2.Text = "Select District where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra <br/> उमेदवाराचे वडिल किंवा आई नोकरी करित असलेला / सेवानिवृत्तीनंतर स्थायीक झालेला महाराष्ट्रातील जिल्हा निवडा";
                        lblQ21.Text = "Select Taluka where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra <br/> उमेदवाराचे वडिल किंवा आई नोकरी करित असलेला / सेवानिवृत्तीनंतर स्थायीक झालेला महाराष्ट्रातील तालुका निवडा";
                        cvDocumentOf.ErrorMessage = "Please Select Whose Domicile Cerificate You are Uploading Online ?";
                        cvDistrict2.ErrorMessage = "Please Select District where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra.";
                        cvTaluka2.ErrorMessage = "Please Select Taluka where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra.";
                        lblRequiredDocumentsByCandidatureType.Text = "<p align = 'justify'><font color = 'red'>You are required to Upload the Proforma - B or Undertaking along with Documentary Evidences from the Retired Employee stating the Place of Settlement.</font></p>";
                        trQ31Village.Visible = false;//MKB
                    }
                    else if (objSessionData.CandidatureTypeID == 5)
                    {
                        ContentTable2.HeaderText = "Home University Details";
                        lblCandidatureType.Text += "<b>Maharashtra - Type E</b>";
                        trDocumentForTypeA.Visible = false;
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;
                        lblQ1.Text = "Select District from which Candidate has Passed SSC <br/>उमेदवाराने दहावी उत्तीर्ण केलेला जिल्हा निवडा";
                        lblQ2.Text = "Select District from which Candidate has Passed HSC / Diploma <br/> उमेदवाराने बारावी / अभियांत्रिकी व तंत्रज्ञान पदविका उत्तीर्ण केलेला जिल्हा निवडा";
                        lblQ21.Text = "Select Taluka from which Candidate has Passed HSC / Diploma <br/> उमेदवाराने बारावी / अभियांत्रिकी व तंत्रज्ञान पदविका उत्तीर्ण केलेला तालुका निवडा ";
                        cvDistrict1.ErrorMessage = "Please Select District from which Candidate has Passed SSC.";
                        cvDistrict2.ErrorMessage = "Please Select District from which Candidate has Passed HSC / Diploma.";
                        cvTaluka2.ErrorMessage = "Please Select Taluka from which Candidate has Passed HSC / Diploma.";
                        lblRequiredDocumentsByCandidatureType.Text = "<p align = 'justify'><font color = 'red'>You are required to submit the Certificate stating that Candidate belongs to border area in proforma-G1 <b>OR</b> Domicile Certificate stating Candidate is residing in Maharashtra Karnataka Border Area at the time of Document Verification at SC.<br /><br />You are required to submit the Certificate stating that the Mother Tongue of the Candidate is Marathi in  Proforma - G2 at the time of Document Verification at SC.</font></p>";
                        lblQ31Village.Text = "Select Village from which Candidate has Passed/ HSC <br/> उमेदवाराने बारावी उत्तीर्ण झालेले/देत असलेला गाव निवडा";//MKB
                        cvVillage2.ErrorMessage = "Please Select Village from which candidate has Passed/HSC.";//MKB
                        ddlQ31Village.Attributes.Add("onmouseover", "ddrivetip('Please Select Village from which Candidate has Passed/ HSC.')");//MKB
                        ddlQ31Village.Attributes.Add("onmouseout", "hideddrivetip()");//MKB
                        trQ31Village.Visible = true;//MKB
                    }
                    else
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }

                    if (objSessionData.StepID >= 3)
                    {
                        HomeUniversityAndCategoryDetails obj = reg.getHomeUniversityAndCategoryDetails(objSessionData.PID);

                        if (obj.HSCDistrictID == 0 || obj.HomeUniversityID == 0)
                        {
                            shInfo.SetMessage("As you have changed your Type of Candidature, so you have to update following details.", ShowMessageType.Information);
                        }

                        ddlDocumentForTypeA.SelectedValue = obj.DocumentForTypeACode.ToString();
                        ddlDocumentOf.SelectedValue = obj.DocumentOfCode.ToString();
                        txtMothersName.Text = obj.MothersName;
                        if (obj.SSCDistrictID != 0)
                        {
                            Int32 i;
                            for (i = 0; i < ddlDistrict1.Items.Count; i++)
                            {
                                if (ddlDistrict1.Items[i].Value.Split(";".ToCharArray())[0] == obj.SSCDistrictID.ToString())
                                {
                                    break;
                                }
                            }
                            ddlDistrict1.SelectedIndex = i;
                        }
                        if (obj.HSCDistrictID != 0)
                        {
                            Int32 i;
                            for (i = 0; i < ddlDistrict2.Items.Count; i++)
                            {
                                if (ddlDistrict2.Items[i].Value.Split(";".ToCharArray())[0] == obj.HSCDistrictID.ToString())
                                {
                                    break;
                                }
                            }
                            ddlDistrict2.SelectedIndex = i;
                        }
                        ddlTaluka2.DataSource = Global.AllMHTaluka.Where(x => x.DistrictID == obj.HSCDistrictID).OrderBy(x => x.TalukaName).ToList(); //reg.getMasterMHTalukaForMHDistrict(obj.HSCDistrictID);
                        ddlTaluka2.DataTextField = "TalukaName";
                        ddlTaluka2.DataValueField = "TalukaID";
                        ddlTaluka2.DataBind();
                        ddlTaluka2.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                        ddlTaluka2.SelectedValue = obj.HSCTalukaID.ToString();
                        if (ddlDistrict2.SelectedIndex > 0)
                        {
                            if (objSessionData.CandidatureTypeID == 5)
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
                        ddlCategory.SelectedValue = obj.CategoryID.ToString();
                        txtCasteNameForOpen.Text = obj.CasteNameForOpen;
                        ddlAppliedForEWS.SelectedValue = obj.AppliedForEWS;
                        ddlCaste.DataSource = reg.getMasterCasteForCategory(obj.CategoryID);
                        ddlCaste.DataTextField = "CasteName";
                        ddlCaste.DataValueField = "CasteID";
                        ddlCaste.DataBind();
                        ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                        ddlCaste.SelectedValue = obj.CasteID.ToString();
                        ddlCasteValidityStatus.SelectedValue = obj.CasteValidityStatus.ToString();
                        txtCVCApplicationNo.Text = obj.CVCApplicationNo;
                        txtAppDate.Text = obj.CVCApplicationDate;
                        txtCVCAuthority.Text = obj.CVCAuthority;
                        txtCVCName.Text = obj.CVCName;
                        txtCCNumber.Text = obj.CCNumber;
                        ddlCVCDistrict.SelectedValue = obj.CVCDistrict;
                        ddlNCLStatus.SelectedValue = obj.NCLStatus.ToString();
                        txtNCLApplicationNo.Text = obj.NCLApplicationNo;
                        txtNCLApplicationDate.Text = obj.NCLApplicationDate;
                        txtNCLAuthority.Text = obj.NCLAuthority;

                        ddlEWSStatus.SelectedValue = obj.EWSStatus.ToString();
                        txtEWSApplicationNo.Text = obj.EWSApplicationNo;
                        txtEWSApplicationDate.Text = obj.EWSApplicationDate;
                        if (obj.EWSDistrict != 0)
                        {
                            Int32 i;
                            for (i = 0; i < ddlEWSDistrict.Items.Count; i++)
                            {
                                if (ddlEWSDistrict.Items[i].Value.Split(";".ToCharArray())[0] == obj.EWSDistrict.ToString())
                                {
                                    break;
                                }
                            }
                            ddlEWSDistrict.SelectedIndex = i;
                        }

                        ddlEWSTaluka.DataSource = Global.AllMHTaluka.Where(x => x.DistrictID == obj.EWSDistrict).OrderBy(x => x.TalukaName).ToList();
                        ddlEWSTaluka.DataTextField = "TalukaName";
                        ddlEWSTaluka.DataValueField = "TalukaID";
                        ddlEWSTaluka.DataBind();
                        ddlEWSTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                        ddlEWSTaluka.SelectedValue = obj.EWSTaluka.ToString();

                        //MKB
                        ddlQ31Village.DataSource = Global.AllVillage.Where(x => x.TalukaID == obj.HSCTalukaID);//reg.getMasterVillageForTaluka(TalukaID);
                        ddlQ31Village.DataTextField = "VillageName";
                        ddlQ31Village.DataValueField = "VillageID";
                        ddlQ31Village.DataBind();
                        ddlQ31Village.Items.Insert(0, new ListItem("-- Select Village --", "0"));
                        ddlQ31Village.SelectedValue = obj.HSCVillageID.ToString();
                    }

                    onPageLoad();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlDocumentOf_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int16 CandidatureTypeID = ((SessionData)Session["SessionData"]).CandidatureTypeID;

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
                ddlTaluka2.Items.Clear();
                if (ddlDistrict2.SelectedIndex != 0)
                {

                    Int32 DistrictID = Convert.ToInt32(ddlDistrict2.SelectedValue.Split(";".ToCharArray())[0]);
                    ddlTaluka2.DataSource = Global.AllMHTaluka.Where(x => x.DistrictID == DistrictID).OrderBy(x => x.TalukaName).ToList();//reg.getMasterMHTalukaForMHDistrict(DistrictID);
                    ddlTaluka2.DataTextField = "TalukaName";
                    ddlTaluka2.DataValueField = "TalukaID";
                    ddlTaluka2.DataBind();
                    ddlTaluka2.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));

                    Int16 CandidatureTypeID = ((SessionData)Session["SessionData"]).CandidatureTypeID;

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

                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int16 CategoryID = Convert.ToInt16(ddlCategory.SelectedValue);
                Int16 AnnualFamilyIncomeID = reg.getAnnualFamilyIncomeID(objSessionData.PID);

                ddlAppliedForEWS.SelectedIndex = 0;
                ddlAppliedForEWS.Enabled = true;
                lblAppliedForEWS.Visible = false;

                if (CategoryID == 2 || CategoryID == 3 || CategoryID == 4 || CategoryID == 5 || CategoryID == 6 || CategoryID == 7 || CategoryID == 9)
                {
                    ddlCasteValidityStatus.Items.Remove(ddlCasteValidityStatus.Items.FindByValue("A"));
                }
                else if (CategoryID == 10 || CategoryID == 8)
                {
                    ddlCasteValidityStatus.Items.Clear();
                    ddlCasteValidityStatus.Items.Insert(0, new ListItem("-- Select --", "0"));
                    ddlCasteValidityStatus.Items.Insert(1, new ListItem("Available", "R"));
                    ddlCasteValidityStatus.Items.Insert(2, new ListItem("Applied but Not Received", "A"));
                }

                if (CategoryID == 0)
                {
                    trOpenCaste.Visible = false;
                    trAppliedForEWS1.Visible = false;
                    trAppliedForEWS2.Visible = false;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;
                    tblCasteValidityApplied.Visible = false;
                    trNCLStatus.Visible = false;
                    tblNCLApplied.Visible = false;
                    trEWSStatus.Visible = false;
                    tblEWSApplied.Visible = false;
                    trInstruction2.Visible = false;
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = false;
                    trInstruction7.Visible = false;
                    trInstruction8.Visible = false;
                    trInstruction9.Visible = false;
                    trInstruction10.Visible = false;

                    if (ddlAppliedForEWS.SelectedValue == "Yes")
                    {
                        hlEWSProforma.Visible = true;
                    }
                    else
                    {
                        hlEWSProforma.Visible = false;
                    }

                    ddlCaste.Items.Clear();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }
                else if (CategoryID == 1)
                {
                    trOpenCaste.Visible = true;
                    trAppliedForEWS1.Visible = true;
                    trAppliedForEWS2.Visible = true;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;
                    tblCasteValidityApplied.Visible = false;
                    trNCLStatus.Visible = false;
                    tblNCLApplied.Visible = false;
                    trEWSStatus.Visible = false;
                    tblEWSApplied.Visible = false;
                    trInstruction2.Visible = false;
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = false;
                    trInstruction7.Visible = false;
                    trInstruction8.Visible = false;
                    trInstruction9.Visible = false;
                    trInstruction10.Visible = false;

                    if (AnnualFamilyIncomeID > 15)
                    {
                        ddlAppliedForEWS.SelectedValue = "No";
                        ddlAppliedForEWS.Enabled = false;
                        lblAppliedForEWS.Visible = true;
                    }

                    ddlCaste.Items.Clear();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }
                else if (CategoryID == 2 || CategoryID == 3)
                {
                    trOpenCaste.Visible = false;
                    trAppliedForEWS1.Visible = false;
                    trAppliedForEWS2.Visible = false;
                    trReservedCaste.Visible = true;
                    trCasteValidityStatus.Visible = true;
                    tblCasteValidityApplied.Visible = false;
                    trNCLStatus.Visible = false;
                    tblNCLApplied.Visible = false;
                    trEWSStatus.Visible = false;
                    tblEWSApplied.Visible = false;
                    trInstruction2.Visible = true;
                    trInstruction3.Visible = true;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = false;
                    trInstruction7.Visible = false;
                    trInstruction8.Visible = false;
                    trInstruction9.Visible = false;
                    trInstruction10.Visible = false;

                    ddlCaste.DataSource = reg.getMasterCasteForCategory(CategoryID);
                    ddlCaste.DataTextField = "CasteName";
                    ddlCaste.DataValueField = "CasteID";
                    ddlCaste.DataBind();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }
                else if (CategoryID == 4 || CategoryID == 5 || CategoryID == 6 || CategoryID == 7 || CategoryID == 8 || CategoryID == 9)
                {
                    trOpenCaste.Visible = false;
                    trAppliedForEWS1.Visible = false;
                    trAppliedForEWS2.Visible = false;
                    trReservedCaste.Visible = true;
                    trCasteValidityStatus.Visible = true;
                    tblCasteValidityApplied.Visible = false;
                    trNCLStatus.Visible = true;
                    tblNCLApplied.Visible = false;
                    trEWSStatus.Visible = false;
                    tblEWSApplied.Visible = false;
                    trInstruction2.Visible = true;
                    trInstruction3.Visible = true;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = true;
                    trInstruction6.Visible = false;
                    trInstruction7.Visible = false;
                    trInstruction8.Visible = false;
                    trInstruction9.Visible = false;
                    trInstruction10.Visible = false;

                    ddlCaste.DataSource = reg.getMasterCasteForCategory(CategoryID);
                    ddlCaste.DataTextField = "CasteName";
                    ddlCaste.DataValueField = "CasteID";
                    ddlCaste.DataBind();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }
                else if (CategoryID == 10)
                {
                    trOpenCaste.Visible = false;
                    trAppliedForEWS1.Visible = false;
                    trAppliedForEWS2.Visible = false;
                    trReservedCaste.Visible = true;
                    trCasteValidityStatus.Visible = true;
                    tblCasteValidityApplied.Visible = false;
                    trNCLStatus.Visible = true;
                    tblNCLApplied.Visible = false;
                    trEWSStatus.Visible = false;
                    tblEWSApplied.Visible = false;
                    trInstruction2.Visible = true;
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = true;
                    trInstruction6.Visible = false;
                    trInstruction7.Visible = false;
                    trInstruction8.Visible = false;
                    trInstruction9.Visible = false;
                    trInstruction10.Visible = false;

                    ddlCaste.DataSource = reg.getMasterCasteForCategory(CategoryID);
                    ddlCaste.DataTextField = "CasteName";
                    ddlCaste.DataValueField = "CasteID";
                    ddlCaste.DataBind();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }
                else
                {
                    trOpenCaste.Visible = false;
                    trAppliedForEWS1.Visible = false;
                    trAppliedForEWS2.Visible = false;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;
                    tblCasteValidityApplied.Visible = false;
                    trNCLStatus.Visible = false;
                    tblNCLApplied.Visible = false;
                    trEWSStatus.Visible = false;
                    tblEWSApplied.Visible = false;
                    trInstruction2.Visible = false;
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = false;
                    trInstruction7.Visible = false;
                    trInstruction8.Visible = false;
                    trInstruction9.Visible = false;
                    trInstruction10.Visible = false;

                    ddlCaste.Items.Clear();
                    ddlCaste.Items.Insert(0, new ListItem("-- Select Caste --", "0"));
                }

                txtCasteNameForOpen.Text = "";
                ddlCasteValidityStatus.SelectedIndex = 0;
                txtCVCApplicationNo.Text = "";
                txtAppDate.Text = "";
                txtCVCAuthority.Text = "";
                txtCVCName.Text = "";
                txtCCNumber.Text = "";
                ddlCVCDistrict.SelectedValue = "0";
                ddlNCLStatus.SelectedIndex = 0;
                txtNCLApplicationNo.Text = "";
                txtNCLApplicationDate.Text = "";
                txtNCLAuthority.Text = "";

                ddlEWSStatus.SelectedIndex = 0;
                txtEWSApplicationNo.Text = "";
                txtEWSApplicationDate.Text = "";
                ddlEWSDistrict.SelectedValue = "0";
                ddlEWSTaluka.SelectedValue = "0";
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

                if (CasteValidityStatus == "R")
                {
                    trInstruction3.Visible = true;
                    trInstruction4.Visible = false;
                    trInstruction8.Visible = false;
                    tblCasteValidityApplied.Visible = false;
                }
                else if (CasteValidityStatus == "A")
                {
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = false;
                    trInstruction8.Visible = true;
                    tblCasteValidityApplied.Visible = true;
                }
                else if (CasteValidityStatus == "N")
                {
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = true;
                    trInstruction8.Visible = false;
                    tblCasteValidityApplied.Visible = false;
                }
                else
                {
                    trInstruction3.Visible = true;
                    trInstruction4.Visible = false;
                    trInstruction8.Visible = false;
                    tblCasteValidityApplied.Visible = false;
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
        protected void ddlNCLStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string NCLStatus = ddlNCLStatus.SelectedValue;

                if (NCLStatus == "R")
                {
                    trInstruction5.Visible = true;
                    trInstruction6.Visible = false;
                    trInstruction9.Visible = false;
                    tblNCLApplied.Visible = false;
                }
                else if (NCLStatus == "A")
                {
                    //trInstruction5.Visible = false;
                    //trInstruction6.Visible = true;
                    //trInstruction9.Visible = false;
                    //tblNCLApplied.Visible = true;

                    trInstruction5.Visible = false;
                    trInstruction6.Visible = false;
                    trInstruction9.Visible = true;
                    tblNCLApplied.Visible = true;
                }
                else if (NCLStatus == "N")
                {
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = true;
                    trInstruction9.Visible = false;
                    tblNCLApplied.Visible = false;
                }
                else
                {
                    trInstruction5.Visible = true;
                    trInstruction6.Visible = false;
                    trInstruction9.Visible = false;
                    tblNCLApplied.Visible = false;
                }

                txtNCLApplicationNo.Text = "";
                txtNCLApplicationDate.Text = "";
                txtNCLAuthority.Text = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlAppliedForEWS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string AppliedForEWS = ddlAppliedForEWS.SelectedValue;

                if (AppliedForEWS == "Yes")
                {
                    trEWSStatus.Visible = true;
                    //tblEWSApplied.Visible = true;
                    hlEWSProforma.Visible = true;
                    trInstruction7.Visible = true;
                }
                else
                {
                    trEWSStatus.Visible = false;
                    tblEWSApplied.Visible = false;
                    trInstruction7.Visible = false;
                    trInstruction10.Visible = false;
                    hlEWSProforma.Visible = false;
                    ddlEWSStatus.SelectedIndex = 0;
                    txtEWSApplicationNo.Text = "";
                    txtEWSApplicationDate.Text = "";
                    ddlEWSDistrict.SelectedValue = "0";
                    ddlEWSTaluka.SelectedValue = "0";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void ddlEWSStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string CasteValidityStatus = ddlEWSStatus.SelectedValue;

                if (CasteValidityStatus == "R")
                {
                    trInstruction7.Visible = true;
                    trInstruction10.Visible = false;
                    tblEWSApplied.Visible = false;
                }
                else if (CasteValidityStatus == "A")
                {
                    trInstruction7.Visible = false;
                    trInstruction10.Visible = true;
                    tblEWSApplied.Visible = true;
                }
                else if (CasteValidityStatus == "N")
                {
                    trInstruction7.Visible = false;
                    trInstruction10.Visible = false;
                    tblEWSApplied.Visible = false;
                }
                else
                {
                    trInstruction7.Visible = true;
                    trInstruction10.Visible = false;
                    tblEWSApplied.Visible = false;
                }

                txtEWSApplicationNo.Text = "";
                txtEWSApplicationDate.Text = "";
                ddlEWSDistrict.SelectedValue = "0";
                ddlEWSTaluka.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void ddlEWSDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                if (ddlEWSDistrict.SelectedIndex != 0)
                {
                    ddlEWSTaluka.Items.Clear();
                    Int32 DistrictID = Convert.ToInt32(ddlEWSDistrict.SelectedValue.Split(";".ToCharArray())[0]);
                    ddlEWSTaluka.DataSource = Global.AllMHTaluka.Where(x => x.DistrictID == DistrictID).OrderBy(x => x.TalukaName).ToList();
                    ddlEWSTaluka.DataTextField = "TalukaName";
                    ddlEWSTaluka.DataValueField = "TalukaID";
                    ddlEWSTaluka.DataBind();
                    ddlEWSTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                }
                else
                {
                    ddlEWSTaluka.Items.Clear();
                    ddlEWSTaluka.Items.Insert(0, new ListItem("-- Select Taluka --", "0"));
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlTaluka2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                if (ddlTaluka2.SelectedIndex != 0)
                {
                    Int32 TalukaID = Convert.ToInt32(ddlTaluka2.SelectedValue);
                    ddlQ31Village.Items.Clear();
                    ddlQ31Village.DataSource = Global.AllVillage.Where(x => x.TalukaID == TalukaID);//reg.getMasterVillageForTaluka(TalukaID);
                    ddlQ31Village.DataTextField = "VillageName";
                    ddlQ31Village.DataValueField = "VillageID";
                    ddlQ31Village.DataBind();
                    ddlQ31Village.Items.Insert(0, new ListItem("-- Select Village --", "0"));
                }
                else
                {
                    ddlQ31Village.Items.Clear();
                    ddlQ31Village.Items.Insert(0, new ListItem("-- Select Village --", "0"));
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

                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int16 CandidatureTypeID = ((SessionData)Session["SessionData"]).CandidatureTypeID;
                Int16 CategoryID = Convert.ToInt16(ddlCategory.SelectedValue);
                Int16 AnnualFamilyIncomeID = reg.getAnnualFamilyIncomeID(objSessionData.PID);

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

                if (CandidatureTypeID == 5)
                {
                    trCategoryHead.Visible = false;
                    trCategory.Visible = false;
                    trOpenCaste.Visible = false;
                    trAppliedForEWS1.Visible = false;
                    trAppliedForEWS2.Visible = false;
                    trReservedCaste.Visible = false;
                    trCasteValidityStatus.Visible = false;
                    tblCasteValidityApplied.Visible = false;
                    trNCLStatus.Visible = false;
                    tblNCLApplied.Visible = false;
                    trEWSStatus.Visible = false;
                    tblEWSApplied.Visible = false;
                    trInstruction2.Visible = false;
                    trInstruction3.Visible = false;
                    trInstruction4.Visible = false;
                    trInstruction5.Visible = false;
                    trInstruction6.Visible = false;
                    trInstruction7.Visible = false;
                    trInstruction8.Visible = false;
                    trInstruction9.Visible = false;
                    trInstruction10.Visible = false;

                    ddlAppliedForEWS.SelectedIndex = 0;
                    ddlAppliedForEWS.Enabled = true;
                    lblAppliedForEWS.Visible = false;
                }
                else
                {
                    if (CategoryID == 0)
                    {
                        trOpenCaste.Visible = false;
                        trAppliedForEWS1.Visible = false;
                        trAppliedForEWS2.Visible = false;
                        trReservedCaste.Visible = false;
                        trCasteValidityStatus.Visible = false;
                        tblCasteValidityApplied.Visible = false;
                        trNCLStatus.Visible = false;
                        tblNCLApplied.Visible = false;
                        trEWSStatus.Visible = false;
                        tblEWSApplied.Visible = false;
                        trInstruction2.Visible = false;
                        trInstruction3.Visible = false;
                        trInstruction4.Visible = false;
                        trInstruction5.Visible = false;
                        trInstruction6.Visible = false;
                        trInstruction7.Visible = false;
                        trInstruction8.Visible = false;
                        trInstruction9.Visible = false;
                        trInstruction10.Visible = false;

                        ddlAppliedForEWS.SelectedIndex = 0;
                        ddlAppliedForEWS.Enabled = true;
                        lblAppliedForEWS.Visible = false;
                    }
                    else if (CategoryID == 1)
                    {
                        trOpenCaste.Visible = true;
                        trAppliedForEWS1.Visible = true;
                        trAppliedForEWS2.Visible = true;
                        trReservedCaste.Visible = false;
                        trCasteValidityStatus.Visible = false;
                        tblCasteValidityApplied.Visible = false;
                        trNCLStatus.Visible = false;
                        tblNCLApplied.Visible = false;
                        trEWSStatus.Visible = false;
                        tblEWSApplied.Visible = false;
                        trInstruction2.Visible = false;
                        trInstruction3.Visible = false;
                        trInstruction4.Visible = false;
                        trInstruction5.Visible = false;
                        trInstruction6.Visible = false;
                        trInstruction7.Visible = false;
                        trInstruction8.Visible = false;
                        trInstruction9.Visible = false;
                        trInstruction10.Visible = false;

                        if (AnnualFamilyIncomeID > 15)
                        {
                            ddlAppliedForEWS.SelectedValue = "No";
                            ddlAppliedForEWS.Enabled = false;
                            lblAppliedForEWS.Visible = true;
                        }
                    }
                    else if (CategoryID == 2 || CategoryID == 3)
                    {
                        trOpenCaste.Visible = false;
                        trAppliedForEWS1.Visible = false;
                        trAppliedForEWS2.Visible = false;
                        trReservedCaste.Visible = true;
                        trCasteValidityStatus.Visible = true;
                        tblCasteValidityApplied.Visible = false;
                        trNCLStatus.Visible = false;
                        tblNCLApplied.Visible = false;
                        trEWSStatus.Visible = false;
                        tblEWSApplied.Visible = false;
                        trInstruction2.Visible = true;
                        trInstruction3.Visible = true;
                        trInstruction4.Visible = false;
                        trInstruction5.Visible = false;
                        trInstruction6.Visible = false;
                        trInstruction7.Visible = false;
                        trInstruction8.Visible = false;
                        trInstruction9.Visible = false;
                        trInstruction10.Visible = false;

                        ddlAppliedForEWS.SelectedIndex = 0;
                        ddlAppliedForEWS.Enabled = true;
                        lblAppliedForEWS.Visible = false;
                    }
                    else if (CategoryID == 4 || CategoryID == 5 || CategoryID == 6 || CategoryID == 7 || CategoryID == 8 || CategoryID == 9)
                    {
                        trOpenCaste.Visible = false;
                        trAppliedForEWS1.Visible = false;
                        trAppliedForEWS2.Visible = false;
                        trReservedCaste.Visible = true;
                        trCasteValidityStatus.Visible = true;
                        tblCasteValidityApplied.Visible = false;
                        trNCLStatus.Visible = true;
                        tblNCLApplied.Visible = false;
                        trEWSStatus.Visible = false;
                        tblEWSApplied.Visible = false;
                        trInstruction2.Visible = true;
                        trInstruction3.Visible = true;
                        trInstruction4.Visible = false;
                        trInstruction5.Visible = true;
                        trInstruction6.Visible = false;
                        trInstruction7.Visible = false;
                        trInstruction8.Visible = false;
                        trInstruction9.Visible = false;
                        trInstruction10.Visible = false;

                        ddlAppliedForEWS.SelectedIndex = 0;
                        ddlAppliedForEWS.Enabled = true;
                        lblAppliedForEWS.Visible = false;
                    }
                    else if (CategoryID == 10)
                    {
                        trOpenCaste.Visible = false;
                        trAppliedForEWS1.Visible = false;
                        trAppliedForEWS2.Visible = false;
                        trReservedCaste.Visible = true;
                        trCasteValidityStatus.Visible = true;
                        tblCasteValidityApplied.Visible = false;
                        trNCLStatus.Visible = true;
                        tblNCLApplied.Visible = false;
                        trEWSStatus.Visible = false;
                        tblEWSApplied.Visible = false;
                        trInstruction2.Visible = true;
                        trInstruction3.Visible = false;
                        trInstruction4.Visible = false;
                        trInstruction5.Visible = true;
                        trInstruction6.Visible = false;
                        trInstruction7.Visible = false;
                        trInstruction8.Visible = false;
                        trInstruction9.Visible = false;
                        trInstruction10.Visible = false;

                        ddlAppliedForEWS.SelectedIndex = 0;
                        ddlAppliedForEWS.Enabled = true;
                        lblAppliedForEWS.Visible = false;
                    }
                    else
                    {
                        trOpenCaste.Visible = false;
                        trAppliedForEWS1.Visible = false;
                        trAppliedForEWS2.Visible = false;
                        trReservedCaste.Visible = false;
                        trCasteValidityStatus.Visible = false;
                        tblCasteValidityApplied.Visible = false;
                        trNCLStatus.Visible = false;
                        tblNCLApplied.Visible = false;
                        trEWSStatus.Visible = false;
                        tblEWSApplied.Visible = false;
                        trInstruction2.Visible = false;
                        trInstruction3.Visible = false;
                        trInstruction4.Visible = false;
                        trInstruction5.Visible = false;
                        trInstruction6.Visible = false;
                        trInstruction7.Visible = false;
                        trInstruction8.Visible = false;
                        trInstruction9.Visible = false;
                        trInstruction10.Visible = false;

                        ddlAppliedForEWS.SelectedIndex = 0;
                        ddlAppliedForEWS.Enabled = true;
                        lblAppliedForEWS.Visible = false;
                    }

                    if (CategoryID == 1)
                    {
                        string AppliedForEWS = ddlAppliedForEWS.SelectedValue;
                        if (AppliedForEWS == "Yes")
                        {
                            string EWSStatus = ddlEWSStatus.SelectedValue;
                            if (EWSStatus == "R")
                            {
                                trInstruction7.Visible = true;
                                trInstruction10.Visible = false;
                                trEWSStatus.Visible = true;
                                tblEWSApplied.Visible = false;
                            }
                            else if (EWSStatus == "A")
                            {
                                trInstruction7.Visible = false;
                                trInstruction10.Visible = true;
                                trEWSStatus.Visible = true;
                                tblEWSApplied.Visible = true;
                            }
                            else if (EWSStatus == "N")
                            {
                                trInstruction7.Visible = false;
                                trInstruction10.Visible = false;
                                trEWSStatus.Visible = true;
                                tblEWSApplied.Visible = false;
                            }
                            else
                            {
                                trInstruction7.Visible = true;
                                trInstruction10.Visible = false;
                                trEWSStatus.Visible = false;
                                tblEWSApplied.Visible = false;
                            }
                        }
                        else
                        {
                            trEWSStatus.Visible = false;
                            tblEWSApplied.Visible = false;
                            trInstruction7.Visible = false;
                            trInstruction10.Visible = false;
                        }
                    }

                    if (CategoryID == 2 || CategoryID == 3 || CategoryID == 4 || CategoryID == 5 || CategoryID == 6 || CategoryID == 7 || CategoryID == 8 || CategoryID == 9 || CategoryID == 10)
                    {
                        string CasteValidityStatus = ddlCasteValidityStatus.SelectedValue;
                        if (CasteValidityStatus == "R")
                        {
                            trInstruction3.Visible = true;
                            trInstruction4.Visible = false;
                            trInstruction8.Visible = false;
                            tblCasteValidityApplied.Visible = false;
                        }
                        else if (CasteValidityStatus == "A")
                        {
                            trInstruction3.Visible = false;
                            trInstruction4.Visible = false;
                            trInstruction8.Visible = true;
                            tblCasteValidityApplied.Visible = true;
                        }
                        else if (CasteValidityStatus == "N")
                        {
                            trInstruction3.Visible = false;
                            trInstruction4.Visible = true;
                            trInstruction8.Visible = false;
                            tblCasteValidityApplied.Visible = false;
                        }
                        else
                        {
                            trInstruction3.Visible = true;
                            trInstruction4.Visible = false;
                            trInstruction8.Visible = false;
                            tblCasteValidityApplied.Visible = false;
                        }
                    }

                    if (CategoryID == 4 || CategoryID == 5 || CategoryID == 6 || CategoryID == 7 || CategoryID == 8 || CategoryID == 9 || CategoryID == 10)
                    {
                        string NCLStatus = ddlNCLStatus.SelectedValue;
                        if (NCLStatus == "R")
                        {
                            trInstruction5.Visible = true;
                            trInstruction6.Visible = false;
                            trInstruction9.Visible = false;
                            tblNCLApplied.Visible = false;
                        }
                        else if (NCLStatus == "A")
                        {
                            trInstruction5.Visible = false;
                            //trInstruction6.Visible = true;
                            trInstruction6.Visible = false;
                            trInstruction9.Visible = true;
                            tblNCLApplied.Visible = true;
                        }
                        else if (NCLStatus == "N")
                        {
                            trInstruction5.Visible = false;
                            trInstruction6.Visible = true;
                            trInstruction9.Visible = false;
                            tblNCLApplied.Visible = false;
                        }
                        else
                        {
                            trInstruction5.Visible = true;
                            trInstruction6.Visible = false;
                            trInstruction9.Visible = false;
                            tblNCLApplied.Visible = false;
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
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];
                HomeUniversityAndCategoryDetails obj = new HomeUniversityAndCategoryDetails();

                obj.PID = objSessionData.PID;
                obj.DocumentForTypeACode = Convert.ToChar(ddlDocumentForTypeA.SelectedValue);
                obj.DocumentOfCode = Convert.ToChar(ddlDocumentOf.SelectedValue);
                obj.MothersName = txtMothersName.Text;
                if (objSessionData.CandidatureTypeID == 1 || objSessionData.CandidatureTypeID == 5)
                {
                    obj.SSCDistrictID = Convert.ToInt32((ddlDistrict1.SelectedValue.Split(";".ToCharArray()))[0].ToString());
                }
                else
                {
                    obj.SSCDistrictID = 0;
                }
                obj.HSCDistrictID = Convert.ToInt32((ddlDistrict2.SelectedValue.Split(";".ToCharArray()))[0].ToString());
                obj.HSCTalukaID = Convert.ToInt32(ddlTaluka2.SelectedValue);
                obj.HomeUniversityID = Convert.ToInt16(hdnHomeUniversityID.Value);
                if (objSessionData.CandidatureTypeID == 5)
                {
                    obj.CategoryID = 0;
                    obj.CasteNameForOpen = "";
                    obj.AppliedForEWS = "N";
                    obj.CasteID = 0;
                    obj.CasteValidityStatus = '0';
                    obj.CVCApplicationNo = "";
                    obj.CVCApplicationDate = "";
                    obj.CVCAuthority = "";
                    obj.CVCName = "";
                    obj.CCNumber = "";
                    obj.CVCDistrict = "";
                    obj.NCLStatus = '0';
                    obj.NCLApplicationNo = "";
                    obj.NCLApplicationDate = "";
                    obj.NCLAuthority = "";

                    obj.EWSStatus = '0';
                    obj.EWSApplicationNo = "";
                    obj.EWSApplicationDate = "";
                    obj.EWSDistrict = 0;
                    obj.EWSTaluka = 0;
                }
                else
                {
                    obj.CategoryID = Convert.ToInt16(ddlCategory.SelectedValue);
                    obj.CasteNameForOpen = txtCasteNameForOpen.Text;
                    //Changesh for EWS Value not Select Cast student
                    if (ddlAppliedForEWS.SelectedValue == "Yes")
                    {
                        obj.AppliedForEWS = ddlAppliedForEWS.SelectedValue;

                    }
                    else
                    {
                        obj.AppliedForEWS = "No";
                    }
                    //obj.AppliedForEWS = ddlAppliedForEWS.SelectedValue;
                    obj.CasteID = Convert.ToInt16(ddlCaste.SelectedValue);
                    obj.CasteValidityStatus = Convert.ToChar(ddlCasteValidityStatus.SelectedValue);
                    obj.CVCApplicationNo = txtCVCApplicationNo.Text;
                    obj.CVCApplicationDate = txtAppDate.Text;
                    obj.CVCAuthority = txtCVCAuthority.Text;
                    obj.CVCName = txtCVCName.Text;
                    obj.CCNumber = txtCCNumber.Text;
                    obj.CVCDistrict = ddlCVCDistrict.SelectedValue;
                    obj.NCLStatus = Convert.ToChar(ddlNCLStatus.SelectedValue);
                    obj.NCLApplicationNo = txtNCLApplicationNo.Text;
                    obj.NCLApplicationDate = txtNCLApplicationDate.Text;
                    obj.NCLAuthority = txtNCLAuthority.Text;

                    obj.EWSStatus = Convert.ToChar(ddlEWSStatus.SelectedValue);
                    obj.EWSApplicationNo = txtEWSApplicationNo.Text;
                    obj.EWSApplicationDate = txtEWSApplicationDate.Text;
                    obj.EWSDistrict = Convert.ToInt32((ddlEWSDistrict.SelectedValue.Split(";".ToCharArray()))[0].ToString());
                    obj.EWSTaluka = Convert.ToInt32(ddlEWSTaluka.SelectedValue);
                }

                //MKB
                if (objSessionData.CandidatureTypeID == 5)
                {
                    obj.HSCVillageID = Convert.ToInt32(ddlQ31Village.SelectedValue);
                }
                else
                {
                    obj.HSCVillageID = 0;
                }
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                Int16 AnnualFamilyIncomeID = reg.getAnnualFamilyIncomeID(objSessionData.PID);
                //bool IsOrphanAndNotEligibleForCategoryReservation = reg.isOrphanAndNotEligibleForCategoryReservation(objSessionData.PID);

                //if (IsOrphanAndNotEligibleForCategoryReservation && obj.CategoryID > 1)
                //{
                //    shInfo.SetMessage("You are Orphan and has No Relatives. So Your Category should be Open.", ShowMessageType.Information);
                //}
                //else 
                string CategoryName = ddlCategory.SelectedItem.Text;
                if (obj.AppliedForEWS == "Yes" && AnnualFamilyIncomeID > 15)
                {
                    shInfo.SetMessage("You have Applied for EWS. So Your Annual Family Income should below 8 Lacs.", ShowMessageType.Information);
                }
                else if (obj.AppliedForEWS == "Yes" && obj.EWSStatus.ToString() == "N")
                {
                    shInfo.SetMessage("You have Applied for EWS, So You Can Not Select EWS Certificate Status as 'Not Applied'.", ShowMessageType.Information);
                }
                else if (obj.CasteValidityStatus.ToString() == "N" && (obj.CategoryID == 2 || obj.CategoryID == 3 || obj.CategoryID == 4 || obj.CategoryID == 5 || obj.CategoryID == 6 || obj.CategoryID == 7 || obj.CategoryID == 8 || obj.CategoryID == 9 || obj.CategoryID == 10))
                {
                    shInfo.SetMessage("You have Applied under " + CategoryName + " Category, So You can not select Caste / Tribe Validity Certificate Status as 'Not Applied'.", ShowMessageType.Information);
                }
                else if (obj.NCLStatus.ToString() == "N" && (obj.CategoryID == 4 || obj.CategoryID == 5 || obj.CategoryID == 6 || obj.CategoryID == 7 || obj.CategoryID == 8 || obj.CategoryID == 9 || obj.CategoryID == 10))
                {
                    shInfo.SetMessage("You have Applied under " + CategoryName + " Category, So You can not select Non-Creamy Layer Certificate Status as 'Not Applied'.", ShowMessageType.Information);
                }
                else
                {
                    if (reg.saveHomeUniversityAndCategoryDetails(obj, ModifiedBy, ModifiedByIPAddress))
                    {
                        if (objSessionData.CandidatureTypeID == 5)
                        {
                            if (objSessionData.StepID < 4)
                            {
                                ((SessionData)Session["SessionData"]).StepID = 4;
                            }
                        }
                        else
                        {
                            if (objSessionData.StepID < 3)
                            {
                                ((SessionData)Session["SessionData"]).StepID = 3;
                            }
                        }

                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
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