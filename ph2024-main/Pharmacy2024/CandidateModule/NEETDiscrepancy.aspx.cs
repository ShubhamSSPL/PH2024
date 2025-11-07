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

namespace Pharmacy2024.CandidateModule
{
    public partial class NEETDiscrepancy : System.Web.UI.Page
    {
        private readonly IBusinessService _IbusinessService = new BusinessServiceImp();
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string MHTCETName = Global.MHTCETName;
        public string NEETName = Global.NEETName;
        public string CurrentYear = Global.CurrentYear;
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
            SessionData objSessionData = (SessionData)Session["SessionData"];

            ViewState["PID"] = objSessionData.PID;
            try
            {

                ContentTable2.HeaderText = "NEET " + CurrentYear + "Details";
                rfvNEETRollNo.ErrorMessage = "Please Enter NEET " + CurrentYear + " Roll No.";
                revNEETRollNo.ErrorMessage = "NEET " + CurrentYear + " Roll No. should be numeric and of 10 digits.";
                cvNEETRollNo.ErrorMessage = "NEET " + CurrentYear + " Roll No. should not be zero.";

                rfvNEETPhysicsScore.ErrorMessage = "Please Enter NEET " + CurrentYear + " Physics Percentile.";
                revNEETPhysicsScore.ErrorMessage = "NEET " + CurrentYear + " Physics Percentile Should be Numeric.";
                rvNEETPhysicsScore.ErrorMessage = "NEET " + CurrentYear + " Physics Percentile Should be less than or equal to 100.";

                rfvNEETChemistryScore.ErrorMessage = "Please Enter NEET " + CurrentYear + " Chemistry Percentile.";
                revNEETChemistryScore.ErrorMessage = "NEET " + CurrentYear + " Chemistry Percentile Should be Numeric.";
                rvNEETChemistryScore.ErrorMessage = "NEET " + CurrentYear + " Chemistry Percentile Should be less than or equal to 100.";

                rfvNEETBiologyScore.ErrorMessage = "Please Enter NEET " + CurrentYear + " Biology (Botany & Zoology) Percentile.";
                revNEETBiologyScore.ErrorMessage = "NEET " + CurrentYear + " Biology (Botany & Zoology) Percentile Should be Numeric.";
                rvNEETBiologyScore.ErrorMessage = "NEET " + CurrentYear + " Biology (Botany & Zoology) Percentile Should be less than or equal to 100.";

                rfvNEETTotalScore.ErrorMessage = "Please Enter NEET " + CurrentYear + " Total Percentile.";
                revNEETTotalScore.ErrorMessage = "NEET " + CurrentYear + " Total Percentile Should be Numeric.";
                rvNEETTotalScore.ErrorMessage = "NEET " + CurrentYear + " Total Percentile Should be less than or equal to 100.";

                if (!IsPostBack)
                {
                    if (_IbusinessService.CheckNEETDiscrepancy(objSessionData.PID))
                    {
                        NEETDetails obj = _IbusinessService.getNEETDetails(objSessionData.PID);
                        DataSet dsNEETResult = _IbusinessService.Get_MSNEETDetails(Convert.ToInt64(obj.NEETRollNo.ToString()));

                        if (dsNEETResult.Tables[0].Rows.Count > 0)
                        {
                            tblNEETDetailsold.Visible = true;
                            lblCandidateNameold.Text = dsNEETResult.Tables[0].Rows[0]["CName"].ToString();
                            lblCandidateNameold.ForeColor = System.Drawing.Color.BlueViolet;
                            lblNEETRollNoold.Text = dsNEETResult.Tables[0].Rows[0]["NEETRollNo"].ToString();
                            lblphysicsold.Text = dsNEETResult.Tables[0].Rows[0]["NEETPhysicScoreFinal"].ToString();
                            lblchemistryold.Text = dsNEETResult.Tables[0].Rows[0]["NEETChemistryScoreFinal"].ToString();
                            lblbiologyold.Text = dsNEETResult.Tables[0].Rows[0]["NEETBiologyScoreFinal"].ToString();
                            lbltotalold.Text = dsNEETResult.Tables[0].Rows[0]["NEETTotalFinal"].ToString();

                        }
                        else
                        {
                            tblNEETDetailsold.Visible = false;
                            shInfo.SetMessage("NEET Details not Found !", ShowMessageType.Information);
                        }

                    }
                    else
                    {
                        tblNEETDetailsold.Visible = false;
                        shInfo.SetMessage("No Discrepancy Found  or You have solve the Discrepancy !", ShowMessageType.Information);
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
                NEETDetails obj = new NEETDetails();

                obj.PID = objSessionData.PID;
               
                    obj.AppearedForNEET = "Yes";
                    obj.NEETRollNo = Convert.ToInt64(txtNEETRollNo.Text);
                    obj.NEETPhysicsScore = Convert.ToDecimal(txtNEETPhysicsScore.Text);
                    obj.NEETChemistryScore = Convert.ToDecimal(txtNEETChemistryScore.Text);
                    obj.NEETBiologyScore = Convert.ToDecimal(txtNEETBiologyScore.Text);
                    obj.NEETTotalScore = Convert.ToDecimal(txtNEETTotalScore.Text);
               
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();
                if (Global.CheckNEETResult)
                {

                    DataSet DsJeeCheckRegisterd = _IbusinessService.IsApplicationFormRegisteredUsingThisNEETRollNo(objSessionData.PID, obj.NEETRollNo.ToString(), objSessionData.StepID);
                    DataSet dsChkNEETRollNo = _IbusinessService.isApplicationFormConfirmedUsingThisNEETRollNo(Convert.ToInt64(obj.NEETRollNo.ToString()), objSessionData.PID);
                    if (Global.CheckDuplicateNEETSetNo == 1 && DsJeeCheckRegisterd.Tables[0].Rows[0]["Status"].ToString() == "0" )
                    {
                        string ApplicationID = DsJeeCheckRegisterd.Tables[0].Rows[0]["ApplicationID"].ToString();
                        string NEETRollNo = DsJeeCheckRegisterd.Tables[0].Rows[0]["NEETRollNo"].ToString();
                        shInfo.SetMessage("Application Form using NEET RollNo " + NEETRollNo + " is already Registered for Application ID - " + ApplicationID + " .", ShowMessageType.Information);
                        tblNEETDetailsold.Focus();
                    }
                    else if (dsChkNEETRollNo.Tables[0].Rows[0]["Status"].ToString() != "0")
                    {
                        DataSet dsNEETResult = _IbusinessService.checkNEETDetailsOnSave(obj);

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
                            if (_IbusinessService.saveNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                            {
                                if (objSessionData.StepID < 6)
                                {
                                    ((SessionData)Session["SessionData"]).StepID = 6;
                                }

                                Response.Redirect("../CandidateModule/frmApplicationForm", true);
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
                        tblNEETDetailsold.Focus();
                    }
                       
                }
                else
                {
                    if (_IbusinessService.saveNEETDetails(obj, ModifiedBy, ModifiedByIPAddress))
                    {
                        if (objSessionData.StepID < 6)
                        {
                            ((SessionData)Session["SessionData"]).StepID = 6;
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