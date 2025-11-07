using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class CETDetails : System.Web.UI.Page
    {
        private readonly IBusinessService _IbusinessService = new BusinessServiceImp();
        public string MHTCETPercentile = Global.MHTCETPercentile;
        public string MHTCETName = Global.MHTCETName;
        public string NEETName = Global.NEETName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime || Convert.ToInt32(Session["UserTypeID"].ToString()) != 91)
            {
                Response.Redirect("../ApplicationPages/WelcomePageCandidate", true);
            }

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            SessionData objSessionData = (SessionData)Session["SessionData"];
            ViewState["PID"] = objSessionData.PID;
            ContentTable2.HeaderText = MHTCETName + " Details";
            rfvCETApplicationFormNo.ErrorMessage = "Please Enter " + MHTCETName + " Application Number.";
            revCETApplicationFormNo.ErrorMessage = MHTCETName + " Application Number Should be Numeric and of 9 Digits.";
            rfvCETRollNo.ErrorMessage = "Please Enter " + MHTCETName + " Roll Number.";
            rfvCETDOB.ErrorMessage = "Please Enter " + MHTCETName + " DOB.";
            revCETRollNo.ErrorMessage = MHTCETName + " Roll Number Should be Numeric and of 14 Digits.";
            {
                if (!IsPostBack)
                {
                    try
                    {
                        //if (_IbusinessService.CheckCETDiscrepancy(objSessionData.PID))
                        //{
                        DataSet dsCETResult = _IbusinessService.getCETDetails(objSessionData.CETApplicationFormNo);
                        if (dsCETResult.Tables[0].Rows.Count > 0)
                        {
                            if (dsCETResult.Tables[0].Rows[0]["IsCandidateGivenCET"].ToString() == "Y")
                            {
                                tblCETDetailsold.Visible = true;
                                tblNewCETDetails.Visible = true;
                                tblCETDetails.Visible = false;
                                lblCandidateNameold.Text = dsCETResult.Tables[0].Rows[0]["CandidateName"].ToString(); ;
                                lblCETApplicationFormNoold.Text = dsCETResult.Tables[0].Rows[0]["CETApplicationFormNo"].ToString();
                                lblCETRollNoold.Text = dsCETResult.Tables[0].Rows[0]["CETRollNo"].ToString();
                                lblCETPhysicsMarksold.Text = dsCETResult.Tables[0].Rows[0]["CETPhysicsMarks"].ToString();
                                lblCETChemistryMarksold.Text = dsCETResult.Tables[0].Rows[0]["CETChemistryMarks"].ToString();
                                lblCETMathMarksold.Text = dsCETResult.Tables[0].Rows[0]["CETMathMarks"].ToString();
                                lblCETPCMTotalMarksold.Text = dsCETResult.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString();
                            }
                            else
                            {
                                tblCETDetailsold.Visible = false;
                                tblNewCETDetails.Visible = false;
                                tblCETDetails.Visible = false;
                                shInfo.SetMessage("CET Details not Found !", ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            tblCETDetailsold.Visible = false;
                            tblNewCETDetails.Visible = true;
                            tblCETDetails.Visible = false;
                            //shInfo.SetMessage("CET Details not Found !", ShowMessageType.Information);
                        }
                        //}
                        //else
                        //{
                        //    tblCETDetailsold.Visible = false;
                        //    tblNewCETDetails.Visible = false;
                        //    tblCETDetails.Visible = false;
                        //    shInfo.SetMessage("No Discrepancy Found  or You have solve the Discrepancy !", ShowMessageType.Information);
                        //}
                    }

                    catch (Exception ex)
                    {
                        //Logging.LogException(ex, "[Page Level Error]");
                        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                    }
                }
            }
        }
        protected void btnCheckCETDetails_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 CETApplicationFormNo = Convert.ToInt64(txtCETApplicationFormNo.Text);
                string CETRollNo = txtCETRollNo.Text;
                string DOB = txtCETDOB.Text;
                DataSet ds = _IbusinessService.checkCETDetails(CETApplicationFormNo, CETRollNo, DOB);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    tblCETDetails.Visible = true;
                    btnProceed.Visible = true;
                    tblNewCETDetails.Visible = false;
                    tblCETDetailsold.Visible = false;

                    lblCandidateName.Text = ds.Tables[0].Rows[0]["CandidateName"].ToString();
                    lblCandidateName.ForeColor = System.Drawing.Color.BlueViolet;
                    if (ds.Tables[0].Rows[0]["IsCandidateGivenCET"].ToString() == "Y")
                    {
                        trCET1.Visible = true;
                        trCET2.Visible = true;
                        trCET3.Visible = true;
                        trCET4.Visible = true;

                        trCET5.Visible = false;

                        lblCETPhysicsMarks.Text = ds.Tables[0].Rows[0]["CETPhysicsMarks"].ToString();
                        lblCETChemistryMarks.Text = ds.Tables[0].Rows[0]["CETChemistryMarks"].ToString();
                        lblCETMathMarks.Text = ds.Tables[0].Rows[0]["CETMathMarks"].ToString();
                        lblCETPCMTotalMarks.Text = ds.Tables[0].Rows[0]["CETPCMTotalMarks"].ToString();
                    }
                    else
                    {
                        trCET1.Visible = false;
                        trCET2.Visible = false;
                        trCET3.Visible = false;
                        trCET4.Visible = false;

                        trCET5.Visible = true;

                        lblNoCET.Text = "Absent in " + MHTCETName + ". You are ELIGIBLE for Admission on the basis of " + NEETName + ".";
                    }
                }
                else
                {
                    tblNewCETDetails.Visible = true;
                    tblCETDetailsold.Visible = false;
                    tblCETDetails.Visible = false;
                    btnProceed.Visible = false;
                    shInfo.SetMessage("Mismatched " + MHTCETName + " Details.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                // Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 CETApplicationFormNo = 0;
                CETApplicationFormNo = Convert.ToInt64(txtCETApplicationFormNo.Text);
                if (CETApplicationFormNo > 0)
                {
                    DataSet DSchkRegistred = _IbusinessService.ISApplicationFormRegisteredUsingThisCETApplicationNo(Convert.ToInt64(CETApplicationFormNo), 6, Convert.ToInt64(ViewState["PID"]));
                    if (Global.CheckDuplicateCETApplicationNo == 1 && DSchkRegistred.Tables[0].Rows[0]["Status"].ToString() == "0")
                    {
                        string ApplicationID = DSchkRegistred.Tables[0].Rows[0]["ApplicationID"].ToString();
                        shInfo.SetMessage("Application Form using CET Application Number " + CETApplicationFormNo.ToString() + " is already registered for Application ID - " + ApplicationID + " .", ShowMessageType.Information);
                        ContentTable2.Focus();
                    }
                    else
                    {
                        if (ViewState["PID"] != null)
                        {
                            ((SessionData)Session["SessionData"]).CETApplicationFormNo = CETApplicationFormNo;
                            if (_IbusinessService.saveCETDetails(Convert.ToInt64(ViewState["PID"]), CETApplicationFormNo, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                            {
                                tblNewCETDetails.Visible = false;
                                tblCETDetailsold.Visible = false;
                                tblCETDetails.Visible = false;
                                btnProceed.Visible = false;
                                shInfo.SetMessage("Your CET Details are updated Successfully.", ShowMessageType.Information);
                                Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                            }
                        }
                        else
                        {
                            tblNewCETDetails.Visible = false;
                            tblCETDetailsold.Visible = true;
                            tblCETDetails.Visible = true;
                            btnProceed.Visible = false;
                            shInfo.SetMessage("Invalid Application ID", ShowMessageType.Information);
                        }
                    }

                }
                else
                {
                    tblNewCETDetails.Visible = false;
                    tblCETDetailsold.Visible = true;
                    tblCETDetails.Visible = true;
                    btnProceed.Visible = false;
                    shInfo.SetMessage("Invalid CET Application FormNo", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}