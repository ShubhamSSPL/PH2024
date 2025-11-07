using BusinessLayer;
using DataAccess.Implementation;
using EntityModel;
using forProjectCustomExceptions;
using Newtonsoft.Json;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class frmCandidatureTypeDetails : System.Web.UI.Page
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
                    DataSet dsCurrentLink = reg.getCurrentLink(objSessionData.PID, "../CandidateModule/frmCandidatureTypeDetails");

                    if (reg.CheckFCVerificationStatus(objSessionData.PID))
                    {
                        shInfo.SetMessage("Application Form is Confirmed or Has been picked for SC E-Verification", ShowMessageType.Information);
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }


                    DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                    char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());

                    if (dsCurrentLink.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(dsCurrentLink.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    if ((objSessionData.ApplicationFormStatus == 'A' || objSessionData.StepID < 1) && (FCVerificationStatus == 'C' || FCVerificationStatus == 'P'))
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                    }
                    if (reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "Y")
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }

                    gvCandidatureType.DataSource = Global.MasterCandidatureType;
                    gvCandidatureType.DataBind();

                    if (objSessionData.StepID >= 2)
                    {
                        Int16 CandidatureTypeID = reg.getCandidatureTypeID(objSessionData.PID);

                        for (Int32 i = 0; i < gvCandidatureType.Rows.Count; i++)
                        {
                            if (((HiddenField)gvCandidatureType.Rows[i].Cells[1].FindControl("hdnCandidatureTypeID")).Value == CandidatureTypeID.ToString())
                            {
                                ((RadioButton)gvCandidatureType.Rows[i].Cells[1].FindControl("rbnCandidatureType")).Checked = true;
                            }
                        }
                    }
                    trCheckFCRDetails.Visible = false;
                    trCheckFCRDOB.Visible = false;
                    trFCRGetData.Visible = false;
                    tblFRNoDetails.Visible = false;
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int16 CandidatureTypeID = 0;

                for (Int32 i = 0; i < gvCandidatureType.Rows.Count; i++)
                {
                    if (((RadioButton)gvCandidatureType.Rows[i].Cells[1].FindControl("rbnCandidatureType")).Checked)
                    {
                        CandidatureTypeID = Convert.ToInt16(((HiddenField)gvCandidatureType.Rows[i].Cells[1].FindControl("hdnCandidatureTypeID")).Value);
                    }
                }

                if ((CandidatureTypeID == 11 || CandidatureTypeID == 12 || CandidatureTypeID == 13 || CandidatureTypeID == 14) && !reg.GetFCRApplicationID(objSessionData.PID))
                {
                    btnProceed.Visible = true;
                    trCheckFCRDetails.Visible = true;
                    trCheckFCRDOB.Visible = true;
                    trFCRGetData.Visible = true;
                    string FCRURL = "https://fn.mahacet.org/StaticPages/HomePage";
                    lblNote.Text = "Note: Candidates those who want to apply under the candidature type Foreign National / NRI / PIO / OCI / CIWGC must register on the FCR Portal as per the proposed rules.To Register use the following Link -" + "<a href=\"https://fn.mahacet.org/StaticPages/HomePage\" >https://fn.mahacet.org/StaticPages/HomePage</a>";
                    lblNote.ForeColor = System.Drawing.Color.Red;
                    trCheckFCRDetails.Focus();
                    btnFCRGetData.Focus();

                }
                else
                {
                    btnProceed.Visible = true;
                    trCheckFCRDetails.Visible = false;
                    trCheckFCRDOB.Visible = false;
                    trFCRGetData.Visible = false;
                    string MotherTongue = reg.getMotherTongue(objSessionData.PID);
                    string Nationality = reg.getNationality(objSessionData.PID);

                    if (MotherTongue != "Marathi" && CandidatureTypeID == 5)
                    {
                        shInfo.SetMessage("Your Mother Tongue is not Marathi. So You can not select this Type of Candidature.", ShowMessageType.Information);
                    }
                    else if (Nationality != "Indian" && (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4 || CandidatureTypeID == 5 || CandidatureTypeID == 7 || CandidatureTypeID == 8 || CandidatureTypeID == 9 || CandidatureTypeID == 10 || CandidatureTypeID == 15 || CandidatureTypeID == 16))
                    {
                        shInfo.SetMessage("Your Nationality is not Indian. So You can not select this Type of Candidature.", ShowMessageType.Information);
                    }
                    else if (Nationality == "Indian" && (CandidatureTypeID == 11 || CandidatureTypeID == 17))
                    {
                        shInfo.SetMessage("Your Nationality is Indian. So You can not select this Type of Candidature.", ShowMessageType.Information);
                    }
                    else
                    {
                        if (objSessionData.CandidatureTypeID != CandidatureTypeID)
                        {
                            string ModifiedBy = Session["UserLoginID"].ToString();
                            string ModifiedByIPAddress = UserInfo.GetIPAddress();
                            DataSet dsChkCETApplicationNo = reg.IsApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp(objSessionData.PID, CandidatureTypeID);

                            if (dsChkCETApplicationNo.Tables[0].Rows[0]["Status"].ToString() == "0" && dsChkCETApplicationNo.Tables[0].Rows.Count > 0)
                            {
                                string CETApplicationFormNo = dsChkCETApplicationNo.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();
                                string sApplicationID = dsChkCETApplicationNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                                string sConfirmedBy = dsChkCETApplicationNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();

                                shInfo.SetMessage("Application Form using CET Application Number " + CETApplicationFormNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);

                            }
                            else
                            {
                                if (reg.saveCandidatureTypeDetails(objSessionData.PID, CandidatureTypeID, ModifiedBy, ModifiedByIPAddress))
                                {
                                    objSessionData.CandidatureTypeID = CandidatureTypeID;

                                    if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4 || CandidatureTypeID == 5)
                                    {
                                        if (objSessionData.StepID < 2)
                                        {
                                            objSessionData.StepID = 2;
                                        }

                                        Session["SessionData"] = objSessionData;

                                        Response.Redirect("../CandidateModule/frmHomeUniversityAndCategoryDetails", true);
                                    }
                                    else
                                    {
                                        if (objSessionData.StepID < 4)
                                        {
                                            objSessionData.StepID = 4;
                                        }

                                        Session["SessionData"] = objSessionData;

                                        Response.Redirect("../CandidateModule/frmApplicationForm", true);
                                    }
                                }
                                else
                                {
                                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                }
                            }
                        }
                        else
                        {
                            DataSet dsDiscrepancy = reg.GetDiscrepancyDetails(objSessionData.PID);
                            dsDiscrepancy.Tables[0].DefaultView.RowFilter = "ApplicationFormStepID = '2'";
                            // DataTable dt = (dsDiscrepancy.Tables[0].DefaultView).ToTable();

                            if (dsDiscrepancy.Tables[0].DefaultView.Count > 0)
                            {
                                shInfo.SetMessage("You have not solve the Discripancy or Change the Candidature Type.", ShowMessageType.Information);
                            }
                            else
                            {
                                Response.Redirect("../CandidateModule/frmApplicationForm", true);

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
        protected void btnCheckFCRGetData_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string FRN_No = txtFCRApplicationFormNo.Value;
                string DOB = txtDOB.Value;
                //DateTime DOB = Convert.ToDateTime(txtDOB.Text.Split("/".ToCharArray())[1] + "/" + txtDOB.Text.Split("/".ToCharArray())[0] + "/" + txtDOB.Text.Split("/".ToCharArray())[2]);
                DataSet FCRds = GetFromAPI(FRN_No, DOB);


                string FCRApplicationID = "";
                string FCRCandidateName = "";
                string FCRCandidatureTypeName = "";
                string FCRMotherName = "";
                string FCRGender = "";
                DateTime FCRDOB = Convert.ToDateTime(("01/01/1990").ToString());


                if (FCRds.Tables[0].Rows.Count > 0)
                {

                    tblFRNoDetails.Visible = true;
                    btnProceed.Visible = true;
                    FCRApplicationID = lblFCRApplicationNo.Text = FCRds.Tables[0].Rows[0]["ApplicationID"].ToString();
                    FCRCandidateName = lblFCRCandidateName.Text = FCRds.Tables[0].Rows[0]["CandidateName"].ToString();
                    FCRCandidatureTypeName = lblFCRCandidatureTypeName.Text = FCRds.Tables[0].Rows[0]["CandidatureTypeName"].ToString();
                    FCRMotherName = lblFCRMotherName.Text = FCRds.Tables[0].Rows[0]["MotherName"].ToString();
                    FCRGender = lblFCRGender.Text = FCRds.Tables[0].Rows[0]["Gender"].ToString();
                    lblFCRDOB.Text = FCRds.Tables[0].Rows[0]["DOB"].ToString();

                    FCRDOB = Convert.ToDateTime(lblFCRDOB.Text.Split("/".ToCharArray())[1] + "/" + lblFCRDOB.Text.Split("/".ToCharArray())[0] + "/" + lblFCRDOB.Text.Split("/".ToCharArray())[2]);
                    if (!reg.UpdateFCRDetails(objSessionData.PID, FCRApplicationID, FCRCandidateName, FCRCandidatureTypeName, FCRMotherName, FCRGender, FCRDOB))
                    {
                        shInfo.SetMessage("Mismatched FCR Application Number/ DOB Details", ShowMessageType.Information);
                    }
                    trCheckFCRDetails.Focus();
                    btnFCRGetData.Focus();
                    btnProceed.Focus();

                }
                else
                {
                    shInfo.SetMessage("Mismatched FCR Application Number/ DOB Details", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                // Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        public DataSet GetFromAPI(string FRN_No, string DOB)
        {
            //List<Table> lstchoiceCode = new List<Table>();
            DataSet myDataSet = new DataSet();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["FCRBaseURL"]);
                    client.DefaultRequestHeaders.Add("token", "FCRAPIdatashare2024_");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("api/FCR/FCRCandidateData?ApplicationID=" + FRN_No + "&DOB=" + DOB).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseString);
                        DataTable DTIMPORT = ReadRootData(myDeserializedClass);
                        myDataSet.Tables.Add(DTIMPORT);
                    }
                }
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "api/InstDataForAdmission?degreeLevel=UG&degreeName=ENGG", "");
            }
            return myDataSet;
        }

        public class Datum
        {
            public string ApplicationID { get; set; }
            public string CandidateName { get; set; }
            public string CandidatureTypeName { get; set; }
            public string MotherName { get; set; }
            public string Gender { get; set; }
            public string DOB { get; set; }
        }

        public class Root
        {
            public string Responsecode { get; set; }
            public List<Datum> Data { get; set; }
            public string Message { get; set; }
            public string NumberofRecords { get; set; }
        }
        private static DataTable ReadRootData(Root myDeserializedClass)
        {
            DataTable DTIMPORT = new DataTable();

            DTIMPORT.Columns.Add("ApplicationID");
            DTIMPORT.Columns.Add("CandidateName");
            DTIMPORT.Columns.Add("CandidatureTypeName");
            DTIMPORT.Columns.Add("MotherName");
            DTIMPORT.Columns.Add("Gender");
            DTIMPORT.Columns.Add("DOB");

            foreach (var item in myDeserializedClass.Data)
            {
                var row = DTIMPORT.NewRow();
                row["ApplicationID"] = item.ApplicationID;
                row["CandidateName"] = item.CandidateName;
                row["CandidatureTypeName"] = item.CandidatureTypeName;
                row["MotherName"] = item.MotherName;
                row["Gender"] = item.Gender;
                row["DOB"] = item.DOB;

                DTIMPORT.Rows.Add(row);
            }

            return DTIMPORT;

        }
    }
}