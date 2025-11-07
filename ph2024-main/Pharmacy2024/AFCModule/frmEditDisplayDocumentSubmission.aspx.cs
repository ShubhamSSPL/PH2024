using BusinessLayer;
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
    public partial class frmEditDisplayDocumentSubmission : System.Web.UI.Page
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

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageAFC.aspx", true);
                    }

                    DataSet ds1 = reg.getApplicationFormConfirmationDetails(PID);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        txtComments.Text = ds1.Tables[0].Rows[0]["Comments"].ToString();
                    }

                    string BlockFlag = "";
                    string CandidatureTypeFlag = "";
                    string CasteCertificateFlag = "";
                    string CasteValidityCertificateFlag = "";
                    string CVCReceiptFlag = "";
                    string NonCreamyLayerCertificateFlag = "";
                    string EWSFlag = "";
                    string PHTypeFlag = "";
                    string DefenceTypeFlag = "";
                    string OrphanFlag = "";
                    string MinorityFlag = "";
                    Int32 CategoryChangeFlag = 0;

                    gvDocumentsSubmitted.DataSource = reg.getDocumentList(PID, "Y");
                    gvDocumentsSubmitted.DataBind();

                    if (gvDocumentsSubmitted.Rows.Count > 0)
                    {
                        for (Int32 i = 0; i < gvDocumentsSubmitted.Rows.Count; i++)
                        {
                            gvDocumentsSubmitted.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        }
                    }
                    else
                    {
                        lblDocumentsSubmittedHead.Visible = false;
                    }

                    gvDocumentsNotSubmitted.DataSource = reg.getDocumentList(PID, "N");
                    gvDocumentsNotSubmitted.DataBind();

                    if (gvDocumentsNotSubmitted.Rows.Count > 0)
                    {
                        for (Int32 i = 0; i < gvDocumentsNotSubmitted.Rows.Count; i++)
                        {
                            gvDocumentsNotSubmitted.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        }
                    }
                    else
                    {
                        lblDocumentsNotSubmittedHead.Visible = false;
                    }

                    for (Int32 i = 0; i < gvDocumentsNotSubmitted.Rows.Count; i++)
                    {
                        Int32 DocumentID = Int32.Parse(((Label)gvDocumentsNotSubmitted.Rows[i].FindControl("lblDocumentID")).Text);
                        string DocumentDetails = gvDocumentsNotSubmitted.Rows[i].Cells[1].Text;

                        if (DocumentID == 1)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 2)
                        {
                            CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 3)
                        {
                            CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 4)
                        {
                            CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 5)
                        {
                            CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 6)
                        {
                            CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 7)
                        {
                            CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 8)
                        {
                            CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 9)
                        {
                            CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 10)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 11)
                        {
                            CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 12)
                        {
                            CandidatureTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 20)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 21)
                        {
                            CasteCertificateFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 22)
                        {
                            CasteValidityCertificateFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 23)
                        {
                            CVCReceiptFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 24)
                        {
                            NonCreamyLayerCertificateFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 25)
                        {
                            PHTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 26)
                        {
                            PHTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 27)
                        {
                            DefenceTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 28)
                        {
                            DefenceTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 29)
                        {
                            DefenceTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 30)
                        {
                            DefenceTypeFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 33)
                        {
                            MinorityFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 35)
                        {
                            OrphanFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 36)
                        {
                            EWSFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 40)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 42)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 43)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 51)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 81)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 82)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 83)
                        {
                            BlockFlag += "As candidate has not submitted  " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 84)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 85)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 86)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 87)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 88)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 89)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 90)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 91)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 92)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 93)
                        {
                            BlockFlag += "As candidate has not submitted  " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 94)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 95)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 96)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 97)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 98)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 99)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 100)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 101)
                        {
                            BlockFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        }
                    }

                    for (Int32 i = 0; i < gvDocumentsSubmitted.Rows.Count; i++)
                    {
                        Int32 DocumentID = Int32.Parse(((Label)gvDocumentsSubmitted.Rows[i].FindControl("lblDocumentID")).Text);

                        if (DocumentID == 24)
                        {
                            trNCLIssueDate.Visible = true;
                            trNCLValidUpTo.Visible = true;

                            DataSet ds = reg.getNCLDocumentDetails(PID);
                            if (ds.Tables[0].Rows[0]["NCLValidUpto"].ToString() != "0")
                            {
                                txtNCLIssueDate.Text = ds.Tables[0].Rows[0]["NCLIssueDate"].ToString();
                                ddlNCLValidUpTo.SelectedValue = ds.Tables[0].Rows[0]["NCLValidUpto"].ToString();
                            }
                        }
                        else if (DocumentID == 25)
                        {
                            PHTypeFlag += "NA";
                        }
                        else if (DocumentID == 26)
                        {
                            PHTypeFlag += "NA";
                        }
                        else if (DocumentID == 27)
                        {
                            DefenceTypeFlag += "NA";
                        }
                        else if (DocumentID == 28)
                        {
                            DefenceTypeFlag += "NA";
                        }
                        else if (DocumentID == 29)
                        {
                            DefenceTypeFlag += "NA";
                        }
                        else if (DocumentID == 30)
                        {
                            DefenceTypeFlag += "NA";
                        }
                        else if (DocumentID == 33)
                        {
                            MinorityFlag += "NA";
                        }
                        else if (DocumentID == 35)
                        {
                            OrphanFlag += "NA";
                        }
                        else if (DocumentID == 36)
                        {
                            EWSFlag += "NA";
                        }
                    }

                    if (BlockFlag.Length > 0)
                    {
                        BlockFlag += "And Hence, Candidate is not Allowed to Submit the Application Form.";
                        lblDisplayDocumentSubmissionStatus.Text += BlockFlag + "<br /><br />";
                        btnProceed.Visible = false;
                    }
                    else
                    {
                        if (CandidatureTypeFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And Hence, Candidate's Type of Candidature is Converted to 'OMS'.<br />";
                            CandidatureTypeFlag += "And Hence, Candidate's Category has been Converted to 'OPEN'.<br />";
                            CategoryChangeFlag = 1;
                            if (PHTypeFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And Hence, Candidate can not avail the Privilege for Person with Disability Quota.<br />";
                                PHTypeFlag = "Change";
                            }
                            if (DefenceTypeFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Defence Employee Quota.<br />";
                                DefenceTypeFlag = "Change";
                            }
                            if (MinorityFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And Hence, Candidate can not avail the Privilege for Linguistic / Religious Minority Quota.<br />";
                                MinorityFlag = "Change";
                            }
                            if (EWSFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for EWS Quota.<br />";
                                EWSFlag = "Change";
                            }
                            if (OrphanFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Orphan Quota.<br />";
                                OrphanFlag = "Change";
                            }
                            lblDisplayDocumentSubmissionStatus.Text += CandidatureTypeFlag + "<br /><br />";
                        }
                        else
                        {
                            if (CasteCertificateFlag.Length > 0 || CasteValidityCertificateFlag.Length > 0 || CVCReceiptFlag.Length > 0 || NonCreamyLayerCertificateFlag.Length > 0)
                            {
                                CasteCertificateFlag += CasteValidityCertificateFlag + CVCReceiptFlag + NonCreamyLayerCertificateFlag + "And Hence, Candidate's Category has been Converted to 'OPEN'.";
                                lblDisplayDocumentSubmissionStatus.Text += CasteCertificateFlag + "<br /><br />";
                                CategoryChangeFlag = 1;
                            }
                            if (PHTypeFlag.Length > 2)
                            {
                                PHTypeFlag += "And Hence, Candidate can not avail the Privilege for Person with Disability Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += PHTypeFlag + "<br /><br />";
                            }
                            if (DefenceTypeFlag.Length > 4)
                            {
                                DefenceTypeFlag += "And hence, candidate can not avail the Privilege for Defence Employee Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += DefenceTypeFlag + "<br /><br />";
                            }
                            if (MinorityFlag.Length > 2)
                            {
                                MinorityFlag += "And Hence, Candidate can not avail the Privilege for Linguistic / Religious Minority Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += MinorityFlag + "<br /><br />";
                            }
                            if (EWSFlag.Length > 2)
                            {
                                EWSFlag += "And hence, candidate can not avail the Privilege for EWS Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += EWSFlag + "<br /><br />";
                            }
                            if (OrphanFlag.Length > 2)
                            {
                                OrphanFlag += "And hence, candidate can not avail the Privilege for Orphan Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += OrphanFlag + "<br /><br />";
                            }
                        }
                    }

                    Int32 IsCandidatureTypeChanged = 0;
                    Int32 IsCategoryChanged = 0;
                    Int32 IsPHTypeChanged = 0;
                    Int32 IsEWSChanged = 0;

                    if (CandidatureTypeFlag.Length > 0)
                    {
                        IsCandidatureTypeChanged = 1;
                    }
                    if (CategoryChangeFlag == 1)
                    {
                        IsCategoryChanged = 1;
                    }
                    if (PHTypeFlag.Length > 2)
                    {
                        IsPHTypeChanged = 1;
                    }
                    if (EWSFlag.Length > 2)
                    {
                        IsEWSChanged = 1;
                    }

                    Int32 ProposedApplicationFeeToBePaid = 0;// reg.getProposedApplicationFeeToBePaid(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsEWSChanged);

                    if (ProposedApplicationFeeToBePaid > 0)
                    {
                        btnProceed.Text = "Proceed to Payment >>>";
                        lblDisplayDocumentSubmissionStatus.Text += "<font size='4'><b>Please collect Rs. " + ProposedApplicationFeeToBePaid.ToString() + "/- ONLINE as a difference in fee.</b></font><br /><br />";
                    }

                    ViewState["BlockFlag"] = BlockFlag;
                    ViewState["CandidatureTypeFlag"] = CandidatureTypeFlag;
                    ViewState["CategoryChangeFlag"] = CategoryChangeFlag;
                    ViewState["PHTypeFlag"] = PHTypeFlag;
                    ViewState["DefenceTypeFlag"] = DefenceTypeFlag;
                    ViewState["MinorityFlag"] = MinorityFlag;
                    ViewState["EWSFlag"] = EWSFlag;
                    ViewState["OrphanFlag"] = OrphanFlag;
                    ViewState["ProposedApplicationFeeToBePaid"] = ProposedApplicationFeeToBePaid;
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Response.Redirect("../AFCModule/frmEditRequiredDocuments.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                string BlockFlag = ViewState["BlockFlag"].ToString();
                string CandidatureTypeFlag = ViewState["CandidatureTypeFlag"].ToString();
                Int32 CategoryChangeFlag = Convert.ToInt32(ViewState["CategoryChangeFlag"].ToString());
                string PHTypeFlag = ViewState["PHTypeFlag"].ToString();
                string DefenceTypeFlag = ViewState["DefenceTypeFlag"].ToString();
                string MinorityFlag = ViewState["MinorityFlag"].ToString();
                string EWSFlag = ViewState["EWSFlag"].ToString();
                string OrphanFlag = ViewState["OrphanFlag"].ToString();
                Int32 ProposedApplicationFeeToBePaid = Convert.ToInt32(ViewState["ProposedApplicationFeeToBePaid"].ToString());
                string IsNCLReceiptSubmitted = "";
                DateTime NCLIssueDate = Convert.ToDateTime("01/01/2000");
                if (txtNCLIssueDate.Text.Length > 0)
                {
                    NCLIssueDate = Convert.ToDateTime(txtNCLIssueDate.Text.Split("/".ToCharArray())[1] + "/" + txtNCLIssueDate.Text.Split("/".ToCharArray())[0] + "/" + txtNCLIssueDate.Text.Split("/".ToCharArray())[2]);
                }
                Int32 NCLValidUpTo = Convert.ToInt32(ddlNCLValidUpTo.SelectedValue);
                Int16 IsNCLValid = 1;
                if (txtNCLIssueDate.Text.Length > 0 && Convert.ToDateTime("03/31/2020") >= NCLIssueDate.AddYears(NCLValidUpTo))
                {
                    IsNCLValid = 0;
                }

                if (IsNCLValid == 1)
                {
                    if (BlockFlag.Length == 0)
                    {
                        Int32 IsCandidatureTypeChanged = 0;
                        Int32 IsCategoryChanged = 0;
                        Int32 IsPHTypeChanged = 0;
                        Int32 IsDefenceTypeChanged = 0;
                        Int32 IsMinorityChanged = 0;
                        Int32 IsEWSChanged = 0;
                        Int32 IsOrphanChanged = 0;

                        if (CandidatureTypeFlag.Length > 0)
                        {
                            IsCandidatureTypeChanged = 1;
                        }
                        if (CategoryChangeFlag == 1)
                        {
                            IsCategoryChanged = 1;
                        }
                        if (PHTypeFlag.Length > 2)
                        {
                            IsPHTypeChanged = 1;
                        }
                        if (DefenceTypeFlag.Length > 4)
                        {
                            IsDefenceTypeChanged = 1;
                        }
                        if (MinorityFlag.Length > 2)
                        {
                            IsMinorityChanged = 1;
                        }
                        if (EWSFlag.Length > 2)
                        {
                            IsEWSChanged = 1;
                        }
                        if (OrphanFlag.Length > 2)
                        {
                            IsOrphanChanged = 1;
                        }

                        if (reg.editConfirmedApplicationForm(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsMinorityChanged, IsEWSChanged, IsOrphanChanged, txtComments.Text, IsNCLReceiptSubmitted, NCLIssueDate, NCLValidUpTo, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            if (ProposedApplicationFeeToBePaid > 0)
                            {
                                Session["FeeGroupId"] = null;
                                Session["PhaseId"] = null;
                                Session["PayeeUserTypeId"] = null;
                                Session["PayeeId"] = null;

                                Session["FeeGroupId"] = "2";
                                Session["PhaseId"] = "1";
                                Session["PayeeUserTypeId"] = "91";
                                Session["PayeeId"] = PID.ToString();

                                Response.Redirect("../FeeProcess/PaymentDetails.aspx", true);
                            }
                            else
                            {
                                Response.Redirect("../AFCModule/frmAcknowledgement.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("Application Form is not Confirmed. Please try after some time.", ShowMessageType.Information);
                        }
                    }
                }
                else
                {
                    shInfo.SetMessage("NCL Certificate is not valid till 31/03/2020.", ShowMessageType.Information);
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