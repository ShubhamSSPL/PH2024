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
    public partial class frmEditNEETDetails : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string CurrentYear = Global.CurrentYear; 
        public string NEETName = Global.NEETName;
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

                    Int16 CandidatureTypeID = reg.getCandidatureTypeID(PID);
                    Int64 CETApplicationFormNo = reg.getCETApplicationFormNo(PID);

                    NEETDetails obj = reg.getNEETDetails(PID);

                    if (obj.AppearedForNEET == "Yes")
                    {
                        rbnAppearedForNEETYes.Checked = true;

                        txtNEETRollNo.Text = obj.NEETRollNo.ToString();
                        txtNEETPhysicsScore.Text = obj.NEETPhysicsScore.ToString();
                        txtNEETChemistryScore.Text = obj.NEETChemistryScore.ToString();
                        txtNEETBiologyScore.Text = obj.NEETBiologyScore.ToString();
                        txtNEETTotalScore.Text = obj.NEETTotalScore.ToString();

                        
                        string strFrom = "";
                        if (Request.QueryString["From"] != null)
                        {
                            strFrom = Request.QueryString["From"].ToString();
                        }

                        if (strFrom == "Correction")
                        {
                            DataSet dsNCL = reg.getDocumentList(PID, "Y");
                            if (dsNCL.Tables[0].Rows.Count > 0)
                            {

                                foreach (DataRow dr in dsNCL.Tables[0].Rows)
                                {
                                    if (Convert.ToInt16(dr["DocumentID"]) == 51)
                                    {
                                        if (dr["FilePath"].ToString() != "")
                                        {
                                            trNEETDocument.Visible = true;
                                            hdnNCLURL.Value = dr["FilePath"].ToString();
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        rbnAppearedForNEETNo.Checked = true;
                    }

                    if (CandidatureTypeID < 11 && CETApplicationFormNo == 0)
                    {
                        shInfo.SetMessage("As you have not appeared for MHT-CET " + CurrentYear + ". So you have to fill NEET " + CurrentYear  + " Details.", ShowMessageType.Information);

                        rbnAppearedForNEETYes.Checked = true;
                        rbnAppearedForNEETNo.Checked = false;
                        rbnAppearedForNEETNo.Enabled = false;
                    }

                    onPageLoad();

                    if ((UserTypeID == 22 || UserTypeID == 31 || UserTypeID == 33 || UserTypeID == 34) && reg.isCandidateNameAppearedInFinalMeritList(PID))
                    {
                        string Flag = reg.isCandidateEligibleForEdittingAtARC(PID);

                        if (Flag.Length > 0)
                        {
                            Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
                        }

                        rbnAppearedForNEETYes.Enabled = false;
                        rbnAppearedForNEETNo.Enabled = false;
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
        protected void AppearedForNEET_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (rbnAppearedForNEETYes.Checked)
                {
                    trNEETRollNo.Visible = true;
                    trNEETScore1.Visible = true;
                    trNEETScore2.Visible = true;
                    trNEETScore3.Visible = true;
                    trNEETScore4.Visible = true;
                }
                else
                {
                    trNEETRollNo.Visible = false;
                    trNEETScore1.Visible = false;
                    trNEETScore2.Visible = false;
                    trNEETScore3.Visible = false;
                    trNEETScore4.Visible = false;
                }

                txtNEETRollNo.Text = "";
                txtNEETPhysicsScore.Text = "";
                txtNEETChemistryScore.Text = "";
                txtNEETBiologyScore.Text = "";
                txtNEETTotalScore.Text = "";
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
                if (rbnAppearedForNEETYes.Checked)
                {
                    trNEETRollNo.Visible = true;
                    trNEETScore1.Visible = true;
                    trNEETScore2.Visible = true;
                    trNEETScore3.Visible = true;
                    trNEETScore4.Visible = true;

                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    string strFrom = "";
                    if (Request.QueryString["From"] != null)
                    {
                        strFrom = Request.QueryString["From"].ToString();
                    }

                    if (strFrom == "Correction")
                    {
                        DataSet dsNCL = reg.getDocumentList(PID, "Y");
                        if (dsNCL.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow dr in dsNCL.Tables[0].Rows)
                            {
                                if (Convert.ToInt16(dr["DocumentID"]) == 51)
                                {
                                    if (dr["FilePath"].ToString() != "")
                                    {
                                        trNEETDocument.Visible = true;
                                        hdnNCLURL.Value = dr["FilePath"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    trNEETRollNo.Visible = false;
                    trNEETScore1.Visible = false;
                    trNEETScore2.Visible = false;
                    trNEETScore3.Visible = false;
                    trNEETScore4.Visible = false;
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
                string strFrom = "";
                if ( Request.QueryString["From"] != null)
                {
                    strFrom = Request.QueryString["From"].ToString();
                }
                
                NEETDetails obj = new NEETDetails();

                obj.PID = PID;
                if (rbnAppearedForNEETYes.Checked)
                {
                    obj.AppearedForNEET = "Yes";
                    obj.NEETRollNo = Convert.ToInt64(txtNEETRollNo.Text);
                    obj.NEETPhysicsScore = Convert.ToDecimal(txtNEETPhysicsScore.Text);
                    obj.NEETChemistryScore = Convert.ToDecimal(txtNEETChemistryScore.Text);
                    obj.NEETBiologyScore = Convert.ToDecimal(txtNEETBiologyScore.Text);
                    obj.NEETTotalScore = Convert.ToDecimal(txtNEETTotalScore.Text);
                    obj.NameAsPerNEET = "";
                    obj.NameMatchingFlag = "N";
                }
                else
                {
                    obj.AppearedForNEET = "No";
                    obj.NEETRollNo = 0;
                    obj.NEETPhysicsScore = 0;
                    obj.NEETChemistryScore = 0;
                    obj.NEETBiologyScore = 0;
                    obj.NEETTotalScore = 0;
                    obj.NameAsPerNEET = "";
                    obj.NameMatchingFlag = "N";
                }
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();


                if (obj.AppearedForNEET == "Yes")
                {
                    DataSet DsJEETCheckRegisterd = reg.IsApplicationFormRegisteredUsingThisNEETRollNo(PID, obj.NEETRollNo.ToString(), 6);
                    DataSet dsChkNEETRollNo = reg.isApplicationFormConfirmedUsingThisNEETRollNo(Convert.ToInt64(obj.NEETRollNo.ToString()), PID);
                    if (Global.CheckDuplicateNEETSetNo == 1 && DsJEETCheckRegisterd.Tables[0].Rows[0]["Status"].ToString() == "0" && rbnAppearedForNEETYes.Checked)
                    {
                        string ApplicationID = DsJEETCheckRegisterd.Tables[0].Rows[0]["ApplicationID"].ToString();
                        string NEETRollNo = DsJEETCheckRegisterd.Tables[0].Rows[0]["NEETRollNo"].ToString();
                        shInfo.SetMessage("Application Form using NEET RollNo " + NEETRollNo + " is already Registered for Application ID - " + ApplicationID + " .", ShowMessageType.Information);
                        ContentTable2.Focus();
                    }
                    else if (dsChkNEETRollNo.Tables[0].Rows[0]["Status"].ToString() != "0" || strFrom != "")
                    {
                        if (Global.CheckNEETResult)
                        {
                            DataSet dsNEETResult = reg.checkNEETDetailsOnSave(obj);

                            if (dsNEETResult.Tables.Count > 0 && dsNEETResult.Tables[0].Rows.Count > 0)
                            {
                                string neetMsg = "";
                                if (dsNEETResult.Tables[0].Rows.Count > 0)
                                {
                                    if (dsNEETResult.Tables[0].Rows[0]["Status"].ToString() == "0")
                                    {
                                        neetMsg = dsNEETResult.Tables[0].Rows[0]["Msg"].ToString();
                                        shInfo.SetMessage(neetMsg, ShowMessageType.Information);
                                        //btnProceed.Visible = false;
                                    }
                                    else if (dsNEETResult.Tables[0].Rows[0]["Status"].ToString() == "1")
                                    {
                                        neetMsg = "Wrong " + NEETName + ". Please verify the Score. It should be <br/>";
                                        neetMsg = neetMsg + "Physics : " + dsNEETResult.Tables[0].Rows[0]["NEETPhysicScoreFinal"].ToString() + " | ";
                                        neetMsg = neetMsg + "Chemistry : " + dsNEETResult.Tables[0].Rows[0]["NEETChemistryScoreFinal"].ToString() + " | ";
                                        neetMsg = neetMsg + "Biology : " + dsNEETResult.Tables[0].Rows[0]["NEETBiologyScoreFinal"].ToString() + " | ";
                                        neetMsg = neetMsg + "Total : " + dsNEETResult.Tables[0].Rows[0]["NEETTotalFinal"].ToString();

                                        shInfo.SetMessage(neetMsg, ShowMessageType.Information);
                                        //btnProceed.Visible = false;
                                    }
                                }
                            }
                            else
                            {
                                if (reg.editNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                                {
                                    if (strFrom == "Correction")
                                    {
                                        Response.Redirect("../E_FCModule/frmNEETConfirmedCandidateList.aspx", true);
                                    }
                                    else
                                    {
                                        Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
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
                            if (reg.editNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                            {
                                if (strFrom == "Correction")
                                {
                                    Response.Redirect("../E_FCModule/frmNEETConfirmedCandidateList.aspx", true);
                                }
                                else
                                {
                                    Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
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
                          string sApplicationID = dsChkNEETRollNo.Tables[0].Rows[0]["ApplicationID"].ToString();
                          string sConfirmedBy = dsChkNEETRollNo.Tables[0].Rows[0]["ConfirmedBy"].ToString();
                          shInfo.SetMessage("Application Form using NEETRollNo " + obj.NEETRollNo.ToString() + " is already confirmed for Application ID - " + sApplicationID + " by " + sConfirmedBy + " .", ShowMessageType.Information);
                          ContentTable2.Focus();
                    }
                }
                else
                {
                    if (reg.editNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                    {
                        if (strFrom == "Correction")
                        {
                            Response.Redirect("../E_FCModule/frmNEETConfirmedCandidateList.aspx", true);
                        }
                        else
                        {
                            Response.Redirect("../AFCModule/frmEditApplicationForm.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                    }
                }
               


                //================================================================================
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}