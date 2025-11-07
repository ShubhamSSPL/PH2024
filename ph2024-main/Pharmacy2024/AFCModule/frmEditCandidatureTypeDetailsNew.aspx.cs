using BusinessLayer;
using DataAccess.Implementation;
using EntityModel;
using forProjectCustomExceptions;
using Newtonsoft.Json;
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

namespace Pharmacy2024.AFCModule
{
    public partial class frmEditCandidatureTypeDetailsNew : System.Web.UI.Page
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

                    Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                    ddlCandidatureType.SelectedValue = CandidatureTypeID.ToString();

                    if ((UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        string Flag = reg.isCandidateEligibleForEdittingAtARC(PID);

                        if (Flag.Length > 0)
                        {
                            Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                        }

                        if (CandidatureTypeID >= 7)
                        {
                            ddlCandidatureType.Enabled = false;
                        }
                        else
                        {
                            ddlCandidatureType.Items.Remove(ddlCandidatureType.Items.FindByValue("8"));
                            ddlCandidatureType.Items.Remove(ddlCandidatureType.Items.FindByValue("9"));
                            ddlCandidatureType.Items.Remove(ddlCandidatureType.Items.FindByValue("10"));
                            ddlCandidatureType.Items.Remove(ddlCandidatureType.Items.FindByValue("11"));
                            ddlCandidatureType.Items.Remove(ddlCandidatureType.Items.FindByValue("12"));
                            ddlCandidatureType.Items.Remove(ddlCandidatureType.Items.FindByValue("13"));
                            ddlCandidatureType.Items.Remove(ddlCandidatureType.Items.FindByValue("14"));
                            ddlCandidatureType.Items.Remove(ddlCandidatureType.Items.FindByValue("15"));
                            ddlCandidatureType.Items.Remove(ddlCandidatureType.Items.FindByValue("16"));
                            ddlCandidatureType.Items.Remove(ddlCandidatureType.Items.FindByValue("17"));
                        }
                    }
                    else if ((UserTypeID == 23 || UserTypeID == 24) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                    }
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int16 CandidatureTypeID = Convert.ToInt16(ddlCandidatureType.SelectedValue);
                string MotherTongue = reg.getMotherTongue(PID);
                string Nationality = reg.getNationality(PID);
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                if ((CandidatureTypeID == 11 || CandidatureTypeID == 12 || CandidatureTypeID == 13 || CandidatureTypeID == 14) && !reg.GetFCRApplicationID(PID))
                {
                    //btnProceed.Visible = false;
                    tblCheckFCRDetails.Visible = true;
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
                    //btnProceed.Visible = true;
                    tblCheckFCRDetails.Visible = false;
                    trCheckFCRDetails.Visible = false;
                    trCheckFCRDOB.Visible = false;
                    trFCRGetData.Visible = false;
                    if (MotherTongue != "Marathi" && CandidatureTypeID == 5)
                    {
                        shInfo.SetMessage("Your Mother Tongue is not Marathi. So You can not select this Type of Candidature.", ShowMessageType.Information);
                    }
                    else if (Nationality != "Indian" && (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4 || CandidatureTypeID == 5 || CandidatureTypeID == 7 || CandidatureTypeID == 8 || CandidatureTypeID == 9 || CandidatureTypeID == 10 || CandidatureTypeID == 15 || CandidatureTypeID == 16))
                    {
                        shInfo.SetMessage("Your Nationality is not Indian. So You can not select this Type of Candidature.", ShowMessageType.Information);
                    }
                    else if (Nationality == "Indian" && (CandidatureTypeID == 11 || CandidatureTypeID == 13 || CandidatureTypeID == 17))
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
                            if (reg.getCandidatureTypeID(PID) != CandidatureTypeID)
                            {
                                if (reg.editCandidatureTypeDetailsForARC(PID, CandidatureTypeID, ModifiedBy, ModifiedByIPAddress))
                                {
                                    Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                                }
                                else
                                {
                                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                }
                            }
                            else
                            {
                                Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
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
        protected void ddlCandidatureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 CandidatureTypeID = Convert.ToInt16(ddlCandidatureType.SelectedValue);
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            //btnProceed.Visible = false;
            if ((CandidatureTypeID == 11 || CandidatureTypeID == 12 || CandidatureTypeID == 13 || CandidatureTypeID == 14) && !reg.GetFCRApplicationID(PID))
            {
                //btnProceed.Visible = false;
                tblCheckFCRDetails.Visible = true;
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
                //btnProceed.Visible = true;
                tblCheckFCRDetails.Visible = false;
                trCheckFCRDetails.Visible = false;
                trCheckFCRDOB.Visible = false;
                trFCRGetData.Visible = false;
            }
        }

        protected void btnCheckFCRGetData_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
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
                    //btnProceed.Visible = true;
                    FCRApplicationID = lblFCRApplicationNo.Text = FCRds.Tables[0].Rows[0]["ApplicationID"].ToString();
                    FCRCandidateName = lblFCRCandidateName.Text = FCRds.Tables[0].Rows[0]["CandidateName"].ToString();
                    FCRCandidatureTypeName = lblFCRCandidatureTypeName.Text = FCRds.Tables[0].Rows[0]["CandidatureTypeName"].ToString();
                    FCRMotherName = lblFCRMotherName.Text = FCRds.Tables[0].Rows[0]["MotherName"].ToString();
                    FCRGender = lblFCRGender.Text = FCRds.Tables[0].Rows[0]["Gender"].ToString();
                    lblFCRDOB.Text = FCRds.Tables[0].Rows[0]["DOB"].ToString();

                    FCRDOB = Convert.ToDateTime(lblFCRDOB.Text.Split("/".ToCharArray())[1] + "/" + lblFCRDOB.Text.Split("/".ToCharArray())[0] + "/" + lblFCRDOB.Text.Split("/".ToCharArray())[2]);
                    if (!reg.UpdateFCRDetails(PID, FCRApplicationID, FCRCandidateName, FCRCandidatureTypeName, FCRMotherName, FCRGender, FCRDOB))
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