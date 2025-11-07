using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessLayer;
using Synthesys.Controls;
using System.Data;
using EntityModel;
using static Pharmacy2024.E_FCModule.FCApplicationFormVerificationDashboard;

namespace Pharmacy2024.E_FCModule
{
    public partial class VerificationSummary : System.Web.UI.Page
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) == 91 || Convert.ToInt32(Session["UserTypeID"].ToString()) == 43)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if ((DateTime.Now < Global.DocumentVerificationStartDateTime || DateTime.Now > Global.DocumentVerificationEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePage", true);
            }
            if (reg.CheckISEFC(Session["UserLoginId"].ToString()) == "N" && (Convert.ToInt16(Session["UserTypeID"]) == 23 || Convert.ToInt16(Session["UserTypeID"]) == 24))
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
                        Response.Redirect("../ApplicationPages/WelcomePage", true);
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
                    string TFWSFlag = "";
                    string MinorityFlag = "";
                    Int32 CategoryChangeFlag = 0;

                    //string NationalityFlag = "";
                    string NCLReceiptFlag = "";
                    string EWSReceiptFlag = "";

                    //string AppliedForEWSFlag = reg.getOriginalAppliedForEWSFlag(PID);
                    //string AppliedForTFWSFlag = reg.getOriginalAppliedForTFWSFlag(PID);

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
                            BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                            //NationalityFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 2)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 3)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 4)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 5)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 6)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 7)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 8)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 9)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 10)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 11)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 12)
                        {
                            CandidatureTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 20)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 21)
                        {
                            CasteCertificateFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 22)
                        {
                            CasteValidityCertificateFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 23)
                        {
                            CVCReceiptFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 24)
                        {
                            NonCreamyLayerCertificateFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 40)
                        {
                            NCLReceiptFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 25)
                        {
                            PHTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 26)
                        {
                            PHTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 27)
                        {
                            DefenceTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 28)
                        {
                            DefenceTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 29)
                        {
                            DefenceTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 30)
                        {
                            DefenceTypeFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 32)
                        {
                            TFWSFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 33)
                        {
                            MinorityFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 35)
                        {
                            OrphanFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 36)
                        {

                            EWSFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 42)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 43)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        //else if (DocumentID == 45)
                        //{
                        //    IGDFlag += "As candidate has not submitted " + DocumentDetails + "<br />";
                        //}
                        else if (DocumentID == 47)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 50)
                        {
                            BlockFlag += "As candidate has not submitted the " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 81)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 82)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 83)
                        {
                            BlockFlag += "As candidate has not Uploaded  " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 84)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 85)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 86)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 87)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 88)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 89)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 90)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 91)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 92)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 93)
                        {
                            BlockFlag += "As candidate has not Uploaded  " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 94)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 95)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 96)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 97)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 98)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 99)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 100)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 101)
                        {
                            BlockFlag += "As candidate has not Uploaded " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 102)
                        {
                            EWSFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 73)
                        {
                            BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                        }
                        else if (DocumentID == 51)
                        {
                            BlockFlag += "As you have not uploaded the " + DocumentDetails + "<br />";
                        }
                    }

                    for (Int32 i = 0; i < gvDocumentsSubmitted.Rows.Count; i++)
                    {
                        Int32 DocumentID = Int32.Parse(((Label)gvDocumentsSubmitted.Rows[i].FindControl("lblDocumentID")).Text);

                        if (DocumentID == 24)
                        {
                            trNCLIssueDate.Visible = true;
                            trNCLValidUpTo.Visible = true;

                            DataSet dsNCL = reg.getDocumentList(PID, "Y");
                            if (dsNCL.Tables[0].Rows.Count > 0)
                            {

                                foreach (DataRow dr in dsNCL.Tables[0].Rows)
                                {
                                    if (Convert.ToInt16(dr["DocumentID"]) == 24)
                                    {
                                        if (dr["FilePath"].ToString() != "")
                                        {
                                            trNCLDOcument.Visible = true;
                                            hdnNCLURL.Value = dr["FilePath"].ToString();
                                            AzureDocumentUpload objDU = new AzureDocumentUpload();
                                            hdnImgByteArray.Value = objDU.GetBlobContentAsBase64("studentdocuments", dr["FilePath"].ToString());
                                        }
                                    }
                                }
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
                        else if (DocumentID == 32)
                        {
                            TFWSFlag += "NA";
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
                        //else if (DocumentID == 45)
                        //{
                        //    IGDFlag += "NA";
                        //}
                    }

                    if (BlockFlag.Length > 0)
                    {
                        BlockFlag += "And, hence candidate form will revert back to candidate login.";
                        lblDisplayDocumentSubmissionStatus.Text += BlockFlag + "<br /><br />";
                        //btnProceed.Visible = true;
                    }
                    else
                    {
                        if (CandidatureTypeFlag.Length > 0)
                        {
                            CandidatureTypeFlag += "And hence, candidate's Type of Candidature is converted to 'OMS'.<br />";
                            CandidatureTypeFlag += "And hence, candidate's Category has been converted to 'OPEN'.<br />";
                            CategoryChangeFlag = 1;
                            if (PHTypeFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Person with Disability Quota.<br />";
                                PHTypeFlag = "Change";
                            }
                            if (DefenceTypeFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Defence Employee Quota.<br />";
                                DefenceTypeFlag = "Change";
                            }
                            if (EWSFlag.Length > 0 || EWSReceiptFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for EWS Quota.<br />";
                                EWSFlag = "Change";
                            }
                            if (TFWSFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for TFWS Quota.<br />";
                                TFWSFlag = "Change";
                            }
                            if (OrphanFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Orphan Quota.<br />";
                                OrphanFlag = "Change";
                            }
                            if (MinorityFlag.Length > 0)
                            {
                                CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Linguistic / Religious Minority Quota.<br />";
                                MinorityFlag = "Change";
                            }
                            //if (IGDFlag.Length > 0)
                            //{
                            //    CandidatureTypeFlag += "And hence, candidate can not avail the Privilege for Intermediate Grade Drawing.<br />";
                            //    IGDFlag = "Change";
                            //}
                            lblDisplayDocumentSubmissionStatus.Text += CandidatureTypeFlag + "<br /><br />";
                        }
                        else
                        {
                            if (CasteCertificateFlag.Length > 0 || CasteValidityCertificateFlag.Length > 0 || CVCReceiptFlag.Length > 0 || NonCreamyLayerCertificateFlag.Length > 0 || NCLReceiptFlag.Length > 0)
                            {
                                CasteCertificateFlag += CasteValidityCertificateFlag + CVCReceiptFlag + NonCreamyLayerCertificateFlag + NCLReceiptFlag + "And hence, candidate's Category has been converted to 'OPEN'.";
                                lblDisplayDocumentSubmissionStatus.Text += CasteCertificateFlag + "<br /><br />";
                                CategoryChangeFlag = 1;
                            }
                            if (PHTypeFlag.Length > 2)
                            {
                                PHTypeFlag += "And hence, candidate can not avail the Privilege for Person with Disability Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += PHTypeFlag + "<br /><br />";
                            }
                            if (DefenceTypeFlag.Length > 4)
                            {
                                DefenceTypeFlag += "And hence, candidate can not avail the Privilege for Defence Employee Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += DefenceTypeFlag + "<br /><br />";
                            }
                            if (EWSFlag.Length > 2 || EWSReceiptFlag.Length > 0)
                            {
                                EWSFlag += "And hence, candidate can not avail the Privilege for EWS Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += EWSFlag + "<br /><br />";
                            }
                            if (TFWSFlag.Length > 2)
                            {
                                TFWSFlag += "And hence, candidate can not avail the Privilege for TFWS Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += TFWSFlag + "<br /><br />";
                            }
                            if (OrphanFlag.Length > 2)
                            {
                                OrphanFlag += "And hence, candidate can not avail the Privilege for Orphan Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += OrphanFlag + "<br /><br />";
                            }
                            if (MinorityFlag.Length > 2)
                            {
                                MinorityFlag += "And hence, candidate can not avail the Privilege for Linguistic / Religious Minority Quota.";
                                lblDisplayDocumentSubmissionStatus.Text += MinorityFlag + "<br /><br />";
                            }
                            //if (IGDFlag.Length > 2)
                            //{
                            //    IGDFlag += "And hence, candidate can not avail the Privilege for Intermediate Grade Drawing.";
                            //    lblDisplayDocumentSubmissionStatus.Text += IGDFlag + "<br /><br />";
                            //}
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
                        //--SEBC Change Start--
                        //if (reg.GetPreviousCategoryDetailsOFSEBC(PID))
                        //{
                        //    IsEWSChanged = 0;
                        //}
                        //else
                        IsEWSChanged = 1;
                        //--SEBC Change END--
                    }
                    Int32 ProposedApplicationFeeToBePaid = reg.getProposedApplicationFeeToBePaid(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsEWSChanged);

                    if (ProposedApplicationFeeToBePaid > 0)
                    {
                        // btnProceed.Text = "Proceed to Payment >>>";
                        lblDisplayDocumentSubmissionStatus.Text += "<font size='4'><b>Rs. " + ProposedApplicationFeeToBePaid.ToString() + "/- ONLINE as a difference in fee.</b></font><br /><br />";
                    }
                    DataSet ds = reg.GetDiscrepancyDetails(PID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvDiscrepancy.DataSource = ds;
                        gvDiscrepancy.DataBind();
                    }

                    ViewState["BlockFlag"] = BlockFlag;
                    ViewState["CandidatureTypeFlag"] = CandidatureTypeFlag;
                    ViewState["CategoryChangeFlag"] = CategoryChangeFlag;
                    ViewState["EWSFlag"] = EWSFlag;
                    ViewState["PHTypeFlag"] = PHTypeFlag;
                    ViewState["DefenceTypeFlag"] = DefenceTypeFlag;
                    ViewState["OrphanFlag"] = OrphanFlag;
                    ViewState["TFWSFlag"] = TFWSFlag;
                    ViewState["MinorityFlag"] = MinorityFlag;
                    //  ViewState["IGDFlag"] = IGDFlag;
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
            Response.Redirect("../E_FCModule/VerificationAppliction?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);
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
                string EWSFlag = ViewState["EWSFlag"].ToString();
                string PHTypeFlag = ViewState["PHTypeFlag"].ToString();
                string DefenceTypeFlag = ViewState["DefenceTypeFlag"].ToString();
                string OrphanFlag = ViewState["OrphanFlag"].ToString();
                string TFWSFlag = ViewState["TFWSFlag"].ToString();
                string MinorityFlag = ViewState["MinorityFlag"].ToString();
                //string IGDFlag = ViewState["IGDFlag"].ToString();
                Int32 ProposedApplicationFeeToBePaid = Convert.ToInt32(ViewState["ProposedApplicationFeeToBePaid"].ToString());

                string IsNCLReceiptSubmitted = "";
                DateTime NCLIssueDate = Convert.ToDateTime("01/01/2000");
                //if (txtNCLIssueDate.Text.Length > 0)
                //{
                //    NCLIssueDate = Convert.ToDateTime(txtNCLIssueDate.Text.Split("/".ToCharArray())[1] + "/" + txtNCLIssueDate.Text.Split("/".ToCharArray())[0] + "/" + txtNCLIssueDate.Text.Split("/".ToCharArray())[2]);
                //}
                //Int32 NCLValidUpTo = Convert.ToInt32(ddlNCLValidUpTo.SelectedValue);


                Int16 IsNCLValid = 1;
                //if (txtNCLIssueDate.Text.Length > 0 && Convert.ToDateTime("03/31/2021") >= NCLIssueDate.AddYears(NCLValidUpTo))
                //{
                //    IsNCLValid = 0;
                //}

                //DateTime NCLIssueDate = Convert.ToDateTime("01/01/2000");
                //if (txtNCLIssueDate.Text.Length > 0)
                //{
                //    NCLIssueDate = Convert.ToDateTime(txtNCLIssueDate.Text.Split("/".ToCharArray())[1] + "/" + txtNCLIssueDate.Text.Split("/".ToCharArray())[0] + "/" + txtNCLIssueDate.Text.Split("/".ToCharArray())[2]);
                //}
                //Int32 NCLValidUpTo = Convert.ToInt32(ddlNCLValidUpTo.SelectedValue);
                //Int16 IsNCLValid = 1;
                ////if (txtNCLIssueDate.Text.Length > 0 && Convert.ToDateTime("03/31/2021") >= NCLIssueDate.AddYears(NCLValidUpTo))
                ////{
                ////    IsNCLValid = 0;
                ////}
                string SMSForConversion = "by converting ";
                if (IsNCLValid == 1)
                {
                    //if (BlockFlag.Length == 0)
                    {
                        Int32 IsCandidatureTypeChanged = 0;
                        Int32 IsCategoryChanged = 0;
                        Int32 IsEWSChanged = 0;
                        Int32 IsPHTypeChanged = 0;
                        Int32 IsDefenceTypeChanged = 0;
                        Int32 IsOrphanChanged = 0;
                        Int32 IsTFWSChanged = 0;
                        Int32 IsMinorityChanged = 0;
                        Int32 IsIGDChanged = 0;

                        if (CandidatureTypeFlag.Length > 0)
                        {
                            IsCandidatureTypeChanged = 1;
                            SMSForConversion += " Candidature Type to OMS,";
                        }
                        if (CategoryChangeFlag == 1)
                        {
                            IsCategoryChanged = 1;
                            SMSForConversion += " Admission Category to OPEN,";
                        }
                        if (EWSFlag.Length > 2)
                        {
                            //--SEBC Change Start--
                            //if (reg.GetPreviousCategoryDetailsOFSEBC(PID))
                            //{
                            //    IsEWSChanged = 0;
                            //}
                            //else
                            IsEWSChanged = 1;
                            SMSForConversion += " EWS Status to NO,";
                            //--SEBC Change Start--
                        }
                        if (PHTypeFlag.Length > 2)
                        {
                            IsPHTypeChanged = 1;
                            SMSForConversion += " PWD Status to NO,";
                        }
                        if (DefenceTypeFlag.Length > 4)
                        {
                            IsDefenceTypeChanged = 1;
                            SMSForConversion += " Defence Status to NO,";
                        }
                        if (OrphanFlag.Length > 2)
                        {
                            IsOrphanChanged = 1;
                            SMSForConversion += " Orphan Status to NO,";
                        }
                        if (TFWSFlag.Length > 2)
                        {
                            IsTFWSChanged = 1;
                            SMSForConversion += " TFWS Status to NO,";
                        }
                        if (MinorityFlag.Length > 2)
                        {
                            IsMinorityChanged = 1;
                            SMSForConversion += " Minority Status to NO,";
                        }
                        //if (IGDFlag.Length > 2)
                        //{
                        //    IsIGDChanged = 1;
                        //}
                        Int32 res = reg.CheckDiscrepancyExists(PID);
                        if (res == 1)
                        {
                            if (reg.ConfirmApplicationFormWithDiscrepancy(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsTFWSChanged, IsMinorityChanged, IsIGDChanged, IsEWSChanged, IsOrphanChanged, txtComments.Text, NCLIssueDate, 1, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                            {
                                if (Global.SendSMSToCandidate == 1)
                                {

                                    SMSTemplate sMSTemplate = new SMSTemplate();
                                    SynCommon synCommon = new SynCommon();
                                    sMSTemplate.PID = PID;
                                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                    if (Global.SendSMSToCandidate == 1)
                                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationFormDiscrepancy);
                                }
                                Response.Redirect("../E_FCModule/frmDiscrepancyMarkCandidateList", true);
                            }
                        }
                        else if (res == 0)
                        {
                            DataSet ds = reg.GetApplicationFormConfirmationDetailsGrivance(PID);
                            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                            {
                                if (reg.editConfirmedApplicationFormEvrification(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsTFWSChanged, IsMinorityChanged, IsEWSChanged, IsOrphanChanged, txtComments.Text, IsNCLReceiptSubmitted, NCLIssueDate, 1, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                {
                                    string eligibility = string.Empty;
                                    DataSet dsEligibilityRemark = reg.getEligibilityFlag(PID);
                                    if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Length > 0)
                                    {
                                        eligibility = dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString();
                                        if (!eligibility.Contains("NOT ELIGIBLE"))
                                        {
                                            if (Global.SendSMSToCandidate == 1)
                                            {
                                                SMSTemplate sMSTemplate = new SMSTemplate();
                                                SynCommon synCommon = new SynCommon();
                                                sMSTemplate.PID = PID;
                                                sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                                sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                                                sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                                if (SMSForConversion.Length > 14)
                                                    sMSTemplate.ConversionStatus = SMSForConversion;
                                                else
                                                    sMSTemplate.ConversionStatus = "";
                                                if (Global.SendSMSToCandidate == 1)
                                                    synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationForm);
                                            }
                                            Response.Redirect("../E_FCModule/frmConfirmedCandidateList", true);
                                        }
                                        else
                                        {
                                            DBUtility regDB = new DBUtility();
                                            if (regDB.markNotEligibleDiscrepancy(PID, eligibility, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                            {
                                                if (Global.SendSMSToCandidate == 1)
                                                {
                                                    SMSTemplate sMSTemplate = new SMSTemplate();
                                                    SynCommon synCommon = new SynCommon();
                                                    sMSTemplate.PID = PID;
                                                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                                                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                                    if (Global.SendSMSToCandidate == 1)
                                                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationFormDiscrepancy);
                                                }
                                            }
                                            Response.Redirect("../E_FCModule/frmDiscrepancyMarkCandidateList", true);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (ProposedApplicationFeeToBePaid > 0)
                                {
                                    if (reg.confirmApplicationFormProvisionally(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged,
                                        IsDefenceTypeChanged, IsMinorityChanged, IsEWSChanged, IsOrphanChanged, txtComments.Text, IsNCLReceiptSubmitted, NCLIssueDate, 1, IsTFWSChanged, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                    {
                                        string eligibility = string.Empty;
                                        DataSet dsEligibilityRemark = reg.getEligibilityFlag(PID);
                                        if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Length > 0)
                                        {
                                            eligibility = dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString();
                                            if (!eligibility.Contains("NOT ELIGIBLE"))
                                            {
                                                if (Global.SendSMSToCandidate == 1)
                                                {
                                                    SMSTemplate sMSTemplate = new SMSTemplate();
                                                    SynCommon synCommon = new SynCommon();
                                                    sMSTemplate.PID = PID;
                                                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                                                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                                    if (SMSForConversion.Length > 14)
                                                        sMSTemplate.ConversionStatus = SMSForConversion;
                                                    else
                                                        sMSTemplate.ConversionStatus = "";
                                                    if (Global.SendSMSToCandidate == 1)
                                                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationFormProvisionally);
                                                }
                                                Response.Redirect("../E_FCModule/frmConfirmedCandidateList", true);
                                            }
                                            else
                                            {
                                                DBUtility regDB = new DBUtility();
                                                if (regDB.markNotEligibleDiscrepancy(PID, eligibility, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                                {
                                                    if (Global.SendSMSToCandidate == 1)
                                                    {
                                                        SMSTemplate sMSTemplate = new SMSTemplate();
                                                        SynCommon synCommon = new SynCommon();
                                                        sMSTemplate.PID = PID;
                                                        sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                                        sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                                                        sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                                        if (Global.SendSMSToCandidate == 1)
                                                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationFormDiscrepancy);
                                                    }
                                                }
                                                Response.Redirect("../E_FCModule/frmDiscrepancyMarkCandidateList", true);
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
                                    if (reg.confirmApplicationForm(PID, IsCandidatureTypeChanged, IsCategoryChanged,  IsPHTypeChanged, IsDefenceTypeChanged, IsMinorityChanged, IsEWSChanged,   IsOrphanChanged, txtComments.Text, IsNCLReceiptSubmitted, NCLIssueDate, 1, IsTFWSChanged, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                    {
                                        string eligibility = string.Empty;
                                        DataSet dsEligibilityRemark = reg.getEligibilityFlag(PID);
                                        if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString().Length > 0)
                                        {
                                            eligibility = dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString();
                                            if (!eligibility.Contains("NOT ELIGIBLE"))
                                            {
                                                if (Global.SendSMSToCandidate == 1)
                                                {
                                                    SMSTemplate sMSTemplate = new SMSTemplate();
                                                    SynCommon synCommon = new SynCommon();
                                                    sMSTemplate.PID = PID;
                                                    sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                                    sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                                                    sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                                    if (SMSForConversion.Length > 14)
                                                        sMSTemplate.ConversionStatus = SMSForConversion;
                                                    else
                                                        sMSTemplate.ConversionStatus = "";
                                                    if (Global.SendSMSToCandidate == 1)
                                                        synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationForm);
                                                }
                                                Response.Redirect("../E_FCModule/frmConfirmedCandidateList", true);
                                            }
                                            else
                                            {
                                                DBUtility regDB = new DBUtility();
                                                if (regDB.markNotEligibleDiscrepancy(PID, eligibility, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                                {
                                                    if (Global.SendSMSToCandidate == 1)
                                                    {
                                                        SMSTemplate sMSTemplate = new SMSTemplate();
                                                        SynCommon synCommon = new SynCommon();
                                                        sMSTemplate.PID = PID;
                                                        sMSTemplate.ConfirmedBy = Session["UserLoginID"].ToString();
                                                        sMSTemplate.ConfirmedDateTime = DateTime.Now.ToString();
                                                        sMSTemplate.ReportedDateTime = DateTime.Now.ToString();
                                                        if (Global.SendSMSToCandidate == 1)
                                                            synCommon.SendInformationSMS(sMSTemplate, SynCommon.TemplateSystemType.EFCConfirmApplicationFormDiscrepancy);
                                                    }
                                                }
                                                Response.Redirect("../E_FCModule/frmDiscrepancyMarkCandidateList", true);
                                            }
                                        }
                                        else
                                        {
                                            shInfo.SetMessage("Application Form is not Confirmed. Please try after some time.", ShowMessageType.Information);
                                        }
                                    }
                                }
                                }
                            }
                        }
                    }
                else
                {
                    shInfo.SetMessage("NCL Certificate is not valid till 31/03/2025.", ShowMessageType.Information);
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