using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmUploadCVCNCLCertificate : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        AzureDocumentUpload objDU = new AzureDocumentUpload();

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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }

            if (!IsPostBack)
            {
                DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplayInOptionForm(Convert.ToInt64(Request.QueryString["PID"]));
                if (dsCandidateDetailsForDisplay.Tables[0].Rows.Count > 0)
                {

                    lblApplicationID.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblCandidateName.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["CandidateName"].ToString();
                    lblGender.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["Gender"].ToString();
                    lblDOB.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["DOB"].ToString();
                    lblCandidatureType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalCandidatureType"].ToString();
                    lblHomeUniversity.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalHomeUniversity"].ToString();
                    lblCategoryForAdmission.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalCategory"].ToString();
                    lblPHType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalPHType"].ToString();
                    lblDefenceType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalDefenceType"].ToString();
                    //lblAppliedForTFWS.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                    lblMinorityCandidatureType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
                    lblAppliedforEWS.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                    lblAppliedforOrphan.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                }

                ContentTable2.Visible = false;
                ContentBox1.Visible = true;
                ContentBox2.Visible = false;
                //fillDropdown();
            }
        }

        //private void fillDropdown()
        //{
        //    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

        //    //ddlDocumentID.Items.Clear();
        //    //ddlDocumentID.Items.Remove(ddlDocumentID.Items.FindByText("Bidar"));

        //    ddlDocumentID.Items.Insert(0, new ListItem("-- Select Document --", "0"));
        //    int flag = 0;

        //    DataSet ds = CheckCVCNCLDocumentsStatus(Convert.ToInt64(Request.QueryString["PID"]));

        //    IApplicationContext ctx = ContextRegistry.GetContext();
        //    IServices reg = (IServices)ctx.GetObject("Services");

        //    if (reg.isCandidateNameAppearedInFinalMeritList(Convert.ToInt64(Request.QueryString["PID"])))
        //    {
        //        if (reg.CheckCandidateCVCStatus(PID))
        //        {

        //        }

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            if (Convert.ToString(ds.Tables[0].Rows[0]["IsNCLReceiptSubmitted"]) == "Yes")
        //            {
        //                ddlDocumentID.Items.Insert(ddlDocumentID.Items.Count, new ListItem("Non-Creamy Layer Certificate", "24"));
        //                flag = 1;
        //            }

        //            if (Convert.ToString(ds.Tables[0].Rows[0]["CasteValidityReceiptSubmittedAtAFC"]) == "Yes")
        //            {
        //                ddlDocumentID.Items.Insert(ddlDocumentID.Items.Count, new ListItem("Caste/Tribe Validity Certificate", "22"));
        //                flag = 1;
        //            }
        //        }
        //        if (flag == 0)
        //        {
        //            ContentTable2.Visible = false;
        //            shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate or Non-Creamy Layer Certificate you can't updload the Document.", ShowMessageType.Information);
        //        }
        //    }
        //    else
        //    {
        //        ContentTable2.Visible = false;
        //        shInfo.SetMessage("Candidate is not in Final Merit List. You can't upload the Documents.", ShowMessageType.Information);
        //    }
        //}

        protected void btnSubmite_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                string fileurl = "";

                if (flUpload.HasFile)
                {
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    Stream objFileStream = flUpload.PostedFile.InputStream;
                    FileInfo objFile = new FileInfo(flUpload.PostedFile.FileName);
                    string sysfilename = (Session["UserID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + objFile.Extension).ToLower();
                    fileurl = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["Project_Name"].ToLower(), sysfilename.ToLower(), objFileStream, flUpload.PostedFile.FileName);

                    UploadCVCNCLCertificate(22, fileurl);
                    //fillDropdown();
                    ContentTable2.Visible = false;
                    shInfo.SetMessage("Document Uploaded Successfully. Please take fresh Acknowledgement.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Please Select File.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            ContentTable2.Visible = true;
            ContentBox1.Visible = false;
            ContentBox2.Visible = false;
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            ContentBox2.Visible = true;
            ContentTable2.Visible = false;
            ContentBox1.Visible = false;
        }
        protected void btnConvertToOpen_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            if (reg.CategoryConverttoOPEN(Convert.ToInt64(Request.QueryString["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
            {
                ContentTable2.Visible = false;
                ContentBox1.Visible = false;
                ContentBox2.Visible = false;
                //ContentBox3.Visible = true;
                shInfo.SetMessage("Category of this Candidate is converted into OPEN Sucessfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
            }
            else
            {
                shInfo.SetMessage("There is some problem in Category Conversion Please try again.", ShowMessageType.Information);
            }
        }
        protected void btnPayApplictionFormFee_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);

            string EligibilityRemark = string.Empty;

            DataSet dsEligibilityRemark = reg.getEligibilityFlag(PID);
            if (dsEligibilityRemark.Tables[0].Rows.Count > 0 && dsEligibilityRemark.Tables[0].Rows[0]["BPharmacyEligibilityFlag"].ToString() == "0" && dsEligibilityRemark.Tables[0].Rows[0]["PharmDEligibilityFlag"].ToString() == "0")
            {
                EligibilityRemark = dsEligibilityRemark.Tables[0].Rows[0]["EligibilityMsg"].ToString();
            }

            if (EligibilityRemark.Length > 0)
            {
                ContentTable2.Visible = false;
                shInfo.SetMessage(EligibilityRemark, ShowMessageType.Information);
            }
            else
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

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
        private DataSet CheckCVCNCLDocumentsStatus(Int64 PID)
        {
            DBConnection db = new DBConnection();
            DataSet ds;
            try
            {
                ds = db.ExecuteDataSet("sp_CheckCVC_NCL_DocumentsStatus", new SqlParameter[]
                {
                new SqlParameter("@PID", PID)
                });
            }
            finally
            {
                db.Dispose();
            }
            return ds;
        }

        private void UploadCVCNCLCertificate(int DocumentID, string FilePath)
        {
            DBConnection db = new DBConnection();
            try
            {
                db.ExecuteNonQuery("MHDTE_spUploadCVCNCLDocument", new SqlParameter[]
                {
                new SqlParameter("@PID", Convert.ToInt64(Request.QueryString["PID"])),
                new SqlParameter("@DocumentID", DocumentID),
                new SqlParameter("@FilePath", FilePath),
                new SqlParameter("@ModifiedBy", Convert.ToString(Session["UserLoginID"])),
                new SqlParameter("@ModifiedByIPAddress", UserInfo.GetIPAddress())
                });
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}