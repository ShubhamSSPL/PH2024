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

namespace Pharmacy2024.CandidateModuleCAPRound2
{
    public partial class frmOptionForm : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request.Cookies["Theme"] == null)
            {
                //Page.Theme = "default";
            }
            else
            {
               // Page.Theme = Request.Cookies["Theme"].Value;
            }

            if (Request.QueryString["tms"] != null)
            {
                this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.master";
            }
            else
            {
                this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (!IsPostBack)
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    Int32 ApplicationFeeToBePaid = reg.getApplicationFeeToBePaid(objSessionData.PID);
                    //DataSet dsCVC = reg.CheckCandidateValid(objSessionData.PID);
                    DataSet ds = reg.getCurrentLinkCAPRound2(objSessionData.PID, "frmOptionForm");

                    //if (dsCVC.Tables[0].Rows.Count > 0 && !reg.isContinueWithReceiptCandidateExist(objSessionData.PID))
                    //{
                    //    Response.Redirect("../CandidateModuleCAPRound2/frmCandidateDeclarationForReceipt.aspx", true);
                    //}

                    DataSet EligibilityRemark = reg.getEligibilityFlag(objSessionData.PID);
                    if (EligibilityRemark.Tables[0].Rows.Count > 0 && EligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && EligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
                    {
                        Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                    }

                    if (ApplicationFeeToBePaid > 0)
                    {
                        Session["FeeGroupId"] = null;
                        Session["PhaseId"] = null;
                        Session["PayeeUserTypeId"] = null;
                        Session["PayeeId"] = null;

                        Session["FeeGroupId"] = "2";
                        Session["PhaseId"] = "1";
                        Session["PayeeUserTypeId"] = "91";
                        Session["PayeeId"] = objSessionData.PID.ToString();

                        Response.Redirect("../FeeProcess/PaymentDetails.aspx", true);
                    }

                    if (objSessionData.EligibleForCAPRound2 == 0)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?Err=1");
                    }

                    if (objSessionData.StepIDCAPRound2 == 0 && reg.isOptionFormConfirmedCAPRound1(objSessionData.PID) && reg.getSelectedOptionsListCAPRound2(objSessionData.PID).Tables[0].Rows.Count == 0)
                    {
                        Response.Redirect("../CandidateModuleCAPRound2/frmImportChoiceCodesFromCAPRound1.aspx");
                    }

                    if (ds.Tables[0].Rows[0]["IsRightURL"].ToString() != "1")
                    {
                        Response.Redirect(ds.Tables[0].Rows[0]["LinkUrl"].ToString(), true);
                    }
                    else
                    {
                        DataSet dsPersonalInformation = reg.getPersonalInformationCAPRound2(objSessionData.PID);

                        lblApplicationID.Text += dsPersonalInformation.Tables[0].Rows[0]["ApplicationID"].ToString();
                        lblVersionNo.Text += dsPersonalInformation.Tables[0].Rows[0]["VersionNoCAPRound2"].ToString();

                        lblCandidateName.Text = lblDeclarationName.Text = dsPersonalInformation.Tables[0].Rows[0]["CandidateName"].ToString();
                        lblFatherName.Text = dsPersonalInformation.Tables[0].Rows[0]["FatherName"].ToString();
                        lblMotherName.Text = dsPersonalInformation.Tables[0].Rows[0]["MotherName"].ToString();
                        lblGender.Text = dsPersonalInformation.Tables[0].Rows[0]["Gender"].ToString();
                        lblDOB.Text = dsPersonalInformation.Tables[0].Rows[0]["DOB"].ToString();
                        lblCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                        lblHomeUniversity.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                        lblOriginalCategory.Text = dsPersonalInformation.Tables[0].Rows[0]["OriginalCategory"].ToString();
                        lblCategoryForAdmission.Text = dsPersonalInformation.Tables[0].Rows[0]["CategoryForAdmission"].ToString();
                        lblPHType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalPHType"].ToString();
                        lblDefenceType.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                        lblMinorityCandidatureType.Text = dsPersonalInformation.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
                        lblAppliedforEWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                        lblAppliedForTFWS.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                        lblAppliedforOrphan.Text = dsPersonalInformation.Tables[0].Rows[0]["FinalIsOrphan"].ToString();

                        DataSet Getreceiptcandidate = reg.Getreceiptcandidates(objSessionData.PID);
                        if(Getreceiptcandidate.Tables[0].Rows.Count>0)
                        {
                            receiptcandidates.Visible = true;
                        }

                        DataSet dsPreferancedOptionsList = reg.getPreferancedOptionsListForDisplayCAPRound2(objSessionData.PID);
                        if (dsPreferancedOptionsList.Tables[0].Rows.Count > 0)
                        {
                            gvPreferencedOptionsList1.DataSource = dsPreferancedOptionsList.Tables[0];
                            gvPreferencedOptionsList1.DataBind();
                        }
                        if (dsPreferancedOptionsList.Tables[1].Rows.Count > 0)
                        {
                            gvPreferencedOptionsList2.DataSource = dsPreferancedOptionsList.Tables[1];
                            gvPreferencedOptionsList2.DataBind();
                        }
                        if (dsPreferancedOptionsList.Tables[2].Rows.Count > 0)
                        {
                            gvPreferencedOptionsList3.DataSource = dsPreferancedOptionsList.Tables[2];
                            gvPreferencedOptionsList3.DataBind();
                        }
                        if (dsPreferancedOptionsList.Tables[3].Rows.Count > 0)
                        {
                            gvPreferencedOptionsList4.DataSource = dsPreferancedOptionsList.Tables[3];
                            gvPreferencedOptionsList4.DataBind();
                        }

                        DataSet dsInstructions = reg.getInstructionsCAPRound2(objSessionData.PID);
                        if (dsInstructions.Tables[0].Rows.Count > 0)
                        {
                            lblInstructions.Text = "<b>Instructions :</b><ol class='list-text'>";
                            for (int i = 0; i < dsInstructions.Tables[0].Rows.Count; i++)
                            {
                                lblInstructions.Text += dsInstructions.Tables[0].Rows[i]["ChoiceCodeStatusInstructions"].ToString();
                            }
                            lblInstructions.Text += "</ol>";
                        }
                        else
                        {
                            trInstructions.Visible = false;
                        }

                        lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                        DateTime LastModifiedOn = Convert.ToDateTime(dsPersonalInformation.Tables[0].Rows[0]["LastModifiedOnCAPRound2"].ToString());
                        lblLastModifiedOn.Text = LastModifiedOn.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", LastModifiedOn);
                        lblLastModifiedBy.Text = dsPersonalInformation.Tables[0].Rows[0]["LastModifiedByCAPRound2"].ToString() + ", " + dsPersonalInformation.Tables[0].Rows[0]["LastModifiedByIPAddressCAPRound2"].ToString();

                        DataSet dsOptionFormConfirmationDetails = reg.getOptionFormConfirmationDetailsCAPRound2(objSessionData.PID);
                        DateTime ConfirmedDateTime = Convert.ToDateTime(dsOptionFormConfirmationDetails.Tables[0].Rows[0]["ConfirmedDateTime"].ToString());
                        lblConfirmedOn.Text = ConfirmedDateTime.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", ConfirmedDateTime);
                        lblConfirmedBy.Text = dsOptionFormConfirmationDetails.Tables[0].Rows[0]["ConfirmedBy"].ToString() + ", " + dsOptionFormConfirmationDetails.Tables[0].Rows[0]["ConfirmedByIPAddress"].ToString();
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