using AjaxPro;
using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;




namespace Pharmacy2024.CandidateAdmissionReportingModule
{
    public partial class frmUploadCorrectDocument : System.Web.UI.Page
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
            if (Session["UserTypeID"].ToString() != "91")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(frmUploadCorrectDocument));
            if (!IsPostBack)
            {
                Int64 PID1 = Convert.ToInt64(reg.getPersonalID(Session["UserLoginID"].ToString()));
               // ViewState["PID"] = PID;
              //  DataSet dsCheckCandEligibleForCorrectDoc = reg.CheckCandidateeligibleforUpload(PID1);
                DataSet dsCheckCandEligibleForCorrectDoc = new dbUtilitySEBC().CheckCandidateeligibleforUpload(PID1);
                if (dsCheckCandEligibleForCorrectDoc.Tables[0].Rows.Count > 0)
                {
                    //}
                    //else
                    //{


                    Int64 PID = Convert.ToInt64(reg.getPersonalID(Session["UserLoginID"].ToString()));
                    ViewState["PID"] = PID;
                    DataSet dsCandidateDetailsForDisplay = reg.getCandidateDetailsForDisplayInOptionForm(PID);

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
                        lblAppliedForTFWS.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalAppliedForTFWS"].ToString();
                        lblMinorityCandidatureType.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["MinorityCandidatureType"].ToString();
                        lblAppliedforEWS.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalAppliedForEWS"].ToString();
                        lblAppliedforOrphan.Text = dsCandidateDetailsForDisplay.Tables[0].Rows[0]["FinalIsOrphan"].ToString();
                    }
                    // PageLoad(1);
                    fillDropdown();
                    divDocType.Visible = true;
                    tblPersonalInfo.Visible = true;
                }
                else
                {
                    divDocType.Visible = false;
                    tblPersonalInfo.Visible = false;
                    shInfo.SetMessage("You have uploaded all the required documents, you are not required to do anything.", ShowMessageType.Information);


                }
            }
        }
        protected void ddlDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string doctype = ddlDocumentType.SelectedValue.ToString();
                if (doctype == "22")
                {
                    //  ContentTableEWS.Visible = false;
                    //ContentBoxEWS.Visible = true;
                    ContentTable2.Visible = true;
                    //ContentTable2.Visible = true;
                    //ContentBox1.Visible = false;
                    LoadDocuments(Convert.ToInt64(ViewState["PID"]),22);

                }
                else if (doctype == "24")
                {
                    ContentTable2.Visible = true;
                    //ContentTableNCL.Visible = false;
                    //ContentBoxNCL.Visible = true;
                    //ContentBoxNCLOpen.Visible = false;
                   // ContentTableEWS.Visible = false;
                  //  ContentBoxEWS.Visible = true;
                    LoadDocuments(Convert.ToInt64(ViewState["PID"]),24);

                }
                else if (doctype == "36")
                {
                    ContentTable2.Visible = true;
                   // ContentTableEWS.Visible = false;
                 //   ContentBoxEWS.Visible = true;
                   
                    LoadDocuments(Convert.ToInt64(ViewState["PID"]),36);

                }
                else
                {
                    ContentTable2.Visible = false;
                    LoadDocuments(Convert.ToInt64(ViewState["PID"]), 0);
                    //ContentTable2.Visible = false;
                    //ContentBox1.Visible = false;
                    //ContentTableNCL.Visible = false;
                    //ContentBoxNCL.Visible = false;
                    //ContentBoxNCL.Visible = false;
                    //ContentTableEWS.Visible = false;
                    //ContentBoxEWS.Visible = false;
                    //ContentBoxEWS.Visible = false;

                }
                
               
            }
            catch (Exception ex)
            {

            }
        }

        private void fillDropdown()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            //ddlDocumentType.Items.Clear();

            DataSet ds = new dbUtilitySEBC().getUploadedDocumentlist(Convert.ToInt64(ViewState["PID"]));
           // DataSet ds = reg.CheckCandidateValid(Convert.ToInt64(ViewState["PID"]));
            if (ds.Tables.Count > 0)
            {
                ddlDocumentType.Items.Insert(0, new ListItem("-- Select Certificate --", "0"));
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                       
                        if (dr["DocType"].ToString() == "CVC")
                        {
                              ddlDocumentType.Items.Insert(1, new ListItem("Cast Validity Certificate", "22"));
                        }
                        if (dr["DocType"].ToString() == "NCL")
                        {
                             ddlDocumentType.Items.Insert(1, new ListItem("Non-Creamy Layer Certificate", "24"));
                        }
                        if (dr["DocType"].ToString() == "EWS")
                        {
                             ddlDocumentType.Items.Insert(1, new ListItem("Economically Weaker Section In Proforma - V ", "36"));
                        }
                    }

                }
                else
                {
                    shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate , Non-Creamy Layer Certificate or Economically Weaker Section In Proforma - V you can't upload the Document.", ShowMessageType.Information);
                    ContentTable2.Visible = false;
                    ContentBox1.Visible = true;
                    //ContentBox2.Visible = false;
                    ContentTableNCL.Visible = false;
                    ContentBoxNCL.Visible = false;
                    ContentBoxNCL.Visible = false;
                    //ContentTableEWS.Visible = true;
                   // ContentBoxEWS.Visible = false;
                  //  ContentBoxEWS.Visible = false;
                }
            }
            else
            {
                shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate , Non-Creamy Layer Certificate or Economically Weaker Section In Proforma - V you can't upload the Document.", ShowMessageType.Information);
                ContentTable2.Visible = false;
                ContentBox1.Visible = true;
                //ContentBox2.Visible = false;
                ContentTableNCL.Visible = false;
                ContentBoxNCL.Visible = false;
                ContentBoxNCL.Visible = false;
                ContentTableEWS.Visible = true;
               // ContentBoxEWS.Visible = false;
               // ContentBoxEWS.Visible = false;
            }
            //ddlDocumentType.Items.Insert(0, new ListItem("-- Select Document --", "0"));
        }

        private void PageLoad(int status)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            
            DataSet ds = reg.CheckCandidateValid(Convert.ToInt64(ViewState["PID"]));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["DocType"].ToString() == "CVC" || dr["DocType"].ToString() == "NCL")
                        {
                            ContentTable2.Visible = false;
                            ContentBox1.Visible = true;
                            //ContentBox2.Visible = false;
                        }

                        if (dr["DocType"].ToString() == "EWS")
                        {
                            ContentTableEWS.Visible = false;
                            //ContentBoxEWS.Visible = true;
                            
                        }
                    }

                }
                else
                {
                    if (status == 1)
                        //shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate , Non - Creamy Layer Certificate or Economically Weaker Section In Proforma - V you can't upload the Document.", ShowMessageType.Information);
                    shInfo.SetMessage("you have uploaded all the required document you are not required to do anything.", ShowMessageType.Information);
                    ContentTable2.Visible = false;
                    ContentBox1.Visible = false;
                    //ContentBox2.Visible = false;
                    ContentTableNCL.Visible = false;
                    ContentBoxNCL.Visible = false;
                    ContentBoxNCL.Visible = false;
                    ContentTableEWS.Visible = false;
                   // ContentBoxEWS.Visible = false;
                  
                }
            }
            else
            {
                if (status == 1)
                    //shInfo.SetMessage("You have Not Submitted the Recipt for Caste/Tribe Validity Certificate , Non - Creamy Layer Certificate or Economically Weaker Section In Proforma - V you can't upload the Document.", ShowMessageType.Information);
                    // commited by snehdeep
                    shInfo.SetMessage("you have uploaded all the required document you are not required to do anything.", ShowMessageType.Information);
                    ContentTable2.Visible = false;
                ContentBox1.Visible = false;
                //ContentBox2.Visible = false;
                ContentTableNCL.Visible = false;
                ContentBoxNCL.Visible = false;
                ContentBoxNCL.Visible = false;
                ContentTableEWS.Visible = false;
                //ContentBoxEWS.Visible = false;
               
            }
        }

        protected void btnSubmite_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                //char CVCStatus = 'N';
                //char NCLStatus = 'N';
                //char EWSStatus = 'N';
                //DataSet ds = new dbUtilitySEBC().GetAllDocuments(Convert.ToInt64(ViewState["PID"]));
                //ds.Tables[0].DefaultView.RowFilter = "(DocumentID = '22' OR DocumentID = '24') AND IsSubmittedAtAFC='N'";
                //if (ds.Tables[0].DefaultView.Count > 0)
                //{
                //    foreach (DataRow dr in ds.Tables[0].Rows)
                //    {
                //        if (dr["DocumentID"].ToString() == "22" && dr["FilePath1"].ToString() != "" && dr["IsSubmittedAtAFC"].ToString() == "N")
                //        {
                //            CVCStatus = 'Y';
                //        }
                //        if (dr["DocumentID"].ToString() == "24" && dr["FilePath1"].ToString() != "" && dr["IsSubmittedAtAFC"].ToString() == "N")
                //        {
                //            NCLStatus = 'Y';
                //        }
                //    }
                //}
                //int verifycnt = 0;
                //for (Int32 i = 0; i < gvCVCNCL.Rows.Count; i++)
                //{
                //    if (gvCVCNCL.Rows[i].Cells[2].Text == "Yes")
                //    {
                //        verifycnt = verifycnt + 1;
                //    }
                //}
                //if (verifycnt > 0)
                //{
                //    if (gvCVCNCL.Rows.Count == 2 && verifycnt == 2) //NCL CVC
                //    {
                //        if (UploadCVCNCLCertificate(CVCStatus, NCLStatus, EWSStatus))
                //        {
                //            ContentTable2.Visible = false;
                //            ContentBox1.Visible = false;
                //            //ContentBox2.Visible = false;
                //            shInfo.SetMessage("Your CVC/TVC and / NCL Certificate has been Uploaded and eSC will verify soon. You will be able to do your Self Verification and Seat Acceptance after Scrutiny by the eSC officer.", ShowMessageType.Information);
                //        }
                //    }
                //    else if (gvCVCNCL.Rows.Count == 1 && verifycnt == 1)
                //    {
                //        if (UploadCVCNCLCertificate(CVCStatus, NCLStatus, EWSStatus))
                //        {
                //            ContentTable2.Visible = false;
                //            ContentBox1.Visible = false;
                //            //ContentBox2.Visible = false;
                //            shInfo.SetMessage("Your CVC/TVC and / NCL or EWS Certificate has been Uploaded and eSC will verify soon. You will be able to do your Self Verification and Seat Acceptance after Scrutiny by the eSC officer.", ShowMessageType.Information);
                //        }
                //    }
                //    else
                //    {
                //        //shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                //        shInfo.SetMessage("Please upload all the documents given in bellow List.", ShowMessageType.Information);
                //    }
                //}
                //else
                //{
                //    shInfo.SetMessage("You have not uploaded the Document.", ShowMessageType.Information);
                //}
            
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            //ContentTable2.Visible = true;
            //ContentBox1.Visible = false;
            ////ContentBox2.Visible = false;
            //LoadDocuments(Convert.ToInt64(ViewState["PID"]));
        } 
        
        
    

        protected void LoadDocuments(Int64 PID, Int32 SelectedDocumentID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            DataSet ds = null;
            //DocumentJWT docJWT = new DocumentJWT();
            try
            { 

                ds = new dbUtilitySEBC().GetAllDocuments(PID, SelectedDocumentID);
                // ds.Tables[0].DefaultView.RowFilter = "DocumentID = '22' OR DocumentID = '24' OR DocumentID = '36'";
                ds.Tables[0].DefaultView.RowFilter = "DocumentID = '" + SelectedDocumentID.ToString() + "'";

                if (ds.Tables[0].DefaultView.Count > 0)
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "1")
                            {
                                //if (Convert.ToString(ds.Tables[0].Rows[0]["DocumentID"]) == "36")
                                //{
                                    //gvEWS.DataSource = ds.Tables[0];
                                    //gvEWS.DataBind();
                                    //gvEWS.Columns[3].Visible = true;
                                    //gvEWS.Columns[5].Visible = true;
                                    gvCVCNCL.DataSource = ds.Tables[0]; 
                                    gvCVCNCL.DataBind();

                                    gvCVCNCL.Columns[3].Visible = true;
                                //gvCVCNCL.Columns[4].Visible = true;
                                gvCVCNCL.Columns[5].Visible = true;

                                for (int i = 0; i < gvCVCNCL.Rows.Count; i++)
                                    {
                                        int DocumentID = Convert.ToInt32(((HiddenField)gvCVCNCL.Rows[i].FindControl("hdnDocId")).Value);
                                    }
                                //}
                                //else if (Convert.ToString(ds.Tables[0].Rows[0]["DocumentID"]) == "22")
                                //{
                                //    ds.Tables[0].DefaultView.RowFilter = "DocumentID = '22'";

                                //    gvCVCNCL.DataSource = ds.Tables[0].DefaultView;
                                //    gvCVCNCL.DataBind();

                                //    gvCVCNCL.Columns[3].Visible = true;
                                //    gvCVCNCL.Columns[5].Visible = true;

                                //    for (int i = 0; i < gvCVCNCL.Rows.Count; i++)
                                //    {
                                //        int DocumentID = Convert.ToInt32(((HiddenField)gvCVCNCL.Rows[i].FindControl("hdnDocId")).Value);
                                //    }
                                //}
                                //else if (Convert.ToString(ds.Tables[0].Rows[0]["DocumentID"]) == "24")
                                //{
                                //    ds.Tables[0].DefaultView.RowFilter = "DocumentID = '24' ";
                                //    gvCVCNCL.DataSource = ds.Tables[0].DefaultView;
                                //    gvCVCNCL.DataBind();

                                //    gvCVCNCL.Columns[3].Visible = true;
                                //    gvCVCNCL.Columns[5].Visible = true;

                                //    for (int i = 0; i < gvCVCNCL.Rows.Count; i++)
                                //    {
                                //        int DocumentID = Convert.ToInt32(((HiddenField)gvCVCNCL.Rows[i].FindControl("hdnDocId")).Value);
                                //    }
                                //}
                                //else
                                //{
                                //    gvCVCNCL.DataSource = ds.Tables[0].DefaultView;
                                //    gvCVCNCL.DataBind();

                                //    gvCVCNCL.Columns[3].Visible = true;
                                //    gvCVCNCL.Columns[5].Visible = true;

                                //    for (int i = 0; i < gvCVCNCL.Rows.Count; i++)
                                //    {
                                //        int DocumentID = Convert.ToInt32(((HiddenField)gvCVCNCL.Rows[i].FindControl("hdnDocId")).Value);
                                //    }
                                //}
                            }
                        }
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "0")
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[0]["DocumentID"]) == "36")
                            {
                                gvCVCNCL.DataSource = null;
                                gvCVCNCL.DataBind();
                                shInfo.SetMessage(Convert.ToString(ds.Tables[0].Rows[0]["Message"]), ShowMessageType.Information);
                            }
                            else
                            {
                                gvCVCNCL.DataSource = null;
                                gvCVCNCL.DataBind();
                                shInfo.SetMessage(Convert.ToString(ds.Tables[0].Rows[0]["Message"]), ShowMessageType.Information);
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("No Data Found!!!", ShowMessageType.Information);
                        }
                    }
                }

                else
                {
                    // Create new DataTable and DataSource objects.
                    shInfo.SetMessage("No Data Found Eror !!!", ShowMessageType.Information);
                    //lblFileTypesAllowed.Text = hdnFileTypes.Value = Convert.ToString(ds.Tables[1].Rows[0]["FileExtensions"]);
                    // hdnMaxSize.Value = Convert.ToString(500);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError);
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
        }
        protected void gvCVCNCL_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (e.CommandName == "D")
            {
                Int32 DocId = Convert.ToInt32(e.CommandArgument);
                ImageButton img = (ImageButton)e.CommandSource;
                GridViewRow gr = (GridViewRow)(img.Parent.Parent);
                string fileName = ((System.Web.UI.WebControls.HiddenField)(gr.Cells[gr.Cells.Count - 2].Controls[1])).Value;
                DataSet ds = null;
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    ds = new dbUtilitySEBC().deleteUploadedDocument(objSessionData.PID, DocId, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                    {
                        LoadDocuments(objSessionData.PID, Convert.ToInt32( ddlDocumentType.SelectedValue.ToString()));
                    }
                    else
                    {
                        shInfo.SetMessage("Unable To Delete File, Try Again Later.", ShowMessageType.Information);
                        LoadDocuments(objSessionData.PID,Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.Information);
                }
                finally
                {
                    if (ds != null)
                    {
                        ds.Dispose();
                    }
                }
            }
        }
        protected void gvCVCNCL_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidFURL = (HiddenField)e.Row.FindControl("hidFURL");
                if (hidFURL.Value != "")
                {
                    string ext = System.IO.Path.GetExtension(hidFURL.Value).ToLower();
                    HtmlImage imgDoc = (HtmlImage)e.Row.FindControl("imgDoc");
                    HiddenField hidDID = (HiddenField)e.Row.FindControl("hidDID");
                    HiddenField hdnDocId = (HiddenField)e.Row.FindControl("hdnDocId");
                    HtmlAnchor hrefURL = (HtmlAnchor)e.Row.FindControl("hrefURL");
                    Label lblStatus = (Label)e.Row.FindControl("lblIsSubmittedAtAFC");

                    Label lblRemark = (Label)e.Row.FindControl("lblRemark");
                    ImageButton imageButton = (ImageButton)e.Row.FindControl("btndelete");
                    hrefURL.HRef = ConfigurationManager.AppSettings["ApplicationURL"] + "ViewMyDocument.aspx?documentID=" + hidDID.Value;
                    string[] docID = { "22", "24","36" };
                    if (Array.Exists(docID, elem => elem == hdnDocId.Value))
                    {
                        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".bmp")
                        {
                            string url = hidFURL.Value;
                            if (hidFURL.Value.Contains("studentdocuments"))
                            {
                                url = hidFURL.Value.Replace("studentdocuments", "studentdocumentsthumbnail");
                                string checkurl = url.Replace(ConfigurationManager.AppSettings["HttpAddress"], "");
                                if (!objDU.Exists(checkurl))
                                {
                                    url = hidFURL.Value;
                                }
                            }
                            string base64 = objDU.ConvertImageURLToBase64(url);
                            imgDoc.Src = "data:image/png;base64," + base64;
                        }
                        else if (ext == ".pdf")
                        {
                            imgDoc.Src = "../images/pdf.gif";
                        }
                        else if (ext == ".zip" || ext == ".rar")
                        {
                            hrefURL.Target = "self";
                            imgDoc.Src = "../images/zip.png";
                        }
                        if (lblStatus.Text == "Approved")
                        {
                            imageButton.Visible = false;
                           // lblStatus.Text = "Verified by eSC";
                            //lblStatus.BackColor = System.Drawing.Color.Green;
                        }
                        //else if (lblStatus.Text == "Rejected")
                        //{
                        //    lblRemark.Text=
                        //}
                        else
                        {
                           // lblStatus.Text = "Not Verified by eSC";
                            lblStatus.BackColor = System.Drawing.Color.LightPink;
                        }

                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                }
            }
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

        protected void btnUploadComplete_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            LoadDocuments(objSessionData.PID,Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()));
        }

        private bool UploadCVCNCLCertificate(char CVCStatus, char NCLStatus, char EWSStatus)
        {
            DBConnection db = new DBConnection();
            try
            {
                int result = Convert.ToInt32(db.ExecuteScaler("MHDTE_spUploadCVCNCLDocument", new SqlParameter[]
                  {
                new SqlParameter("@PID", Convert.ToInt64(ViewState["PID"])),
               // new SqlParameter("@DocumentID", DocumentID),
                //new SqlParameter("@FilePath", FilePath),
                new SqlParameter("@ModifiedBy", Convert.ToString(Session["UserLoginID"])),
                new SqlParameter("@ModifiedByIPAddress", UserInfo.GetIPAddress()),
                 new SqlParameter("@CVC", CVCStatus),
                  new SqlParameter("@NCL", NCLStatus),
                   new SqlParameter("@EWS", EWSStatus)
                  }));
                if (result > 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                db.Dispose();
            }
        }



        
        //protected void btnNCLConvertToOpen_Click(object sender, EventArgs e)
        //{
        //    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
        //    //Check Extra Fees.

        //    if (reg.CategoryConverttoOPEN(Convert.ToInt64(ViewState["PID"]), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress()))
        //    {
        //        ContentTable2.Visible = false;
        //        ContentBox1.Visible = false;
        //        //ContentBox2.Visible = false;
        //        //ContentBox3.Visible = true;
        //        fillDropdown();
        //        shInfo.SetMessage("Category of this Candidate is converted into OPEN Successfully. Allotment is also Cancelled if allotted any seat.", ShowMessageType.Information);
        //    }
        //    else
        //    {
        //        shInfo.SetMessage("There is some problem in Category Conversion Please try again.", ShowMessageType.Information);
        //    }
        //}


        //protected void btnEWSYes_Click(object sender, EventArgs e)
        //{
        //    ContentTableEWS.Visible = true;
        //    ContentBoxEWS.Visible = false;
        //    LoadDocuments(Convert.ToInt64(ViewState["PID"]), Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()));
        //}
        //protected void btnEWSNo_Click(object sender, EventArgs e)
        //{
        //    ContentTableEWS.Visible = false;
        //    ContentBoxEWS.Visible = false;
        //}
      

        protected void gvEWS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (e.CommandName == "D")
            {
                Int32 DocId = Convert.ToInt32(e.CommandArgument);
                ImageButton img = (ImageButton)e.CommandSource;
                GridViewRow gr = (GridViewRow)(img.Parent.Parent);
                string fileName = ((System.Web.UI.WebControls.HiddenField)(gr.Cells[gr.Cells.Count - 1].Controls[1])).Value;
                DataSet ds = null;
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    ds = new dbUtilitySEBC().deleteUploadedDocument(objSessionData.PID, DocId, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                    {
                        LoadDocuments(objSessionData.PID, Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()));
                    }
                    else
                    {
                        shInfo.SetMessage("Unable To Delete File, Try Again Later.", ShowMessageType.Information);
                        LoadDocuments(objSessionData.PID, Convert.ToInt32(ddlDocumentType.SelectedValue.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.Information);
                }
                finally
                {
                    if (ds != null)
                    {
                        ds.Dispose();
                    }
                }
            }
        }
        protected void gvEWS_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidFURL = (HiddenField)e.Row.FindControl("hidFURL");
                if (hidFURL.Value != "")
                {
                    string ext = System.IO.Path.GetExtension(hidFURL.Value).ToLower();
                    HtmlImage imgDoc = (HtmlImage)e.Row.FindControl("imgDoc");
                    HiddenField hidDID = (HiddenField)e.Row.FindControl("hidDID");
                    HiddenField hdnDocId = (HiddenField)e.Row.FindControl("hdnDocId");
                    HtmlAnchor hrefURL = (HtmlAnchor)e.Row.FindControl("hrefURL");
                    Label lblStatus = (Label)e.Row.FindControl("lblIsSubmittedAtAFC");
                    ImageButton imageButton = (ImageButton)e.Row.FindControl("btndelete");
                    hrefURL.HRef = ConfigurationManager.AppSettings["ApplicationURL"] + "ViewMyDocument.aspx?documentID=" + hidDID.Value;
                    string[] docID = { "22", "24", "36" };
                    if (Array.Exists(docID, elem => elem == hdnDocId.Value))
                    {
                        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".bmp")
                        {
                            string url = hidFURL.Value;
                            if (hidFURL.Value.Contains("studentdocuments"))
                            {
                                url = hidFURL.Value.Replace("studentdocuments", "studentdocumentsthumbnail");
                                string checkurl = url.Replace(ConfigurationManager.AppSettings["HttpAddress"], "");
                                if (!objDU.Exists(checkurl))
                                {
                                    url = hidFURL.Value;
                                }
                            }
                            string base64 = objDU.ConvertImageURLToBase64(url);
                            imgDoc.Src = "data:image/png;base64," + base64;
                        }
                        else if (ext == ".pdf")
                        {
                            imgDoc.Src = "../images/pdf.gif";
                        }
                        else if (ext == ".zip" || ext == ".rar")
                        {
                            hrefURL.Target = "self";
                            imgDoc.Src = "../images/zip.png";
                        }
                        if (lblStatus.Text == "Y")
                        {
                            imageButton.Visible = false;
                            lblStatus.Text = "Verified by SC";
                            lblStatus.BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblStatus.Text = "Not Verified by SC";
                            lblStatus.BackColor = System.Drawing.Color.Red;
                        }

                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                }
            }
        }
        protected void btnSubmiteNCL_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                string fileurl = "";

                if (flUploadNCL.HasFile)
                {
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    Stream objFileStream = flUploadNCL.PostedFile.InputStream;
                    FileInfo objFile = new FileInfo(flUploadNCL.PostedFile.FileName);
                    string sysfilename = (Session["UserID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + objFile.Extension).ToLower();
                    fileurl = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, flUploadNCL.PostedFile.ContentType);

                    //UploadCVCNCLCertificate(24, fileurl);
                    fillDropdown();
                    ContentTableNCL.Visible = false;
                    shInfo.SetMessage("Document Uploaded Successfully. Please check Latest Acknowledgement.", ShowMessageType.Information);
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
        protected void btnSubmiteEWS_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                //char CVCStatus = 'N';
                //char NCLStatus = 'N';
                //char EWSStatus = 'N';
                //DataSet ds = new dbUtilitySEBC().GetAllDocuments(Convert.ToInt64(ViewState["PID"]));
                //ds.Tables[0].DefaultView.RowFilter = "(DocumentID = '36' AND IsSubmittedAtAFC='N')";
                //if (ds.Tables[0].DefaultView.Count > 0)
                //{
                //    foreach (DataRow dr in ds.Tables[0].Rows)
                //    {
                //        if (dr["DocumentID"].ToString() == "36" && dr["FilePath1"].ToString() != "" && dr["IsSubmittedAtAFC"].ToString() == "N")
                //        {
                //            EWSStatus = 'Y';
                //        }
                //    }
                //}
                //int verifycnt = 0;
                //for (Int32 i = 0; i < gvEWS.Rows.Count; i++)
                //{
                //    if (gvEWS.Rows[i].Cells[2].Text == "Yes")
                //    {
                //        verifycnt = verifycnt + 1;
                //    }
                //}
                //if (verifycnt > 0)
                //{
                //    if (EWSStatus == 'Y')
                //    {
                //        if (UploadCVCNCLCertificate(CVCStatus, NCLStatus, EWSStatus))
                //        {
                //            ContentTableEWS.Visible = false;
                //            ContentBoxEWS.Visible = false;
                //            shInfo.SetMessage("Your CVC/TVC, NCL or EWS Certificate has been Uploaded and eSC will verify Soon. You are able to do your Self Verification and Seat Acceptance after Scrutiny done by eSC.", ShowMessageType.Information);
                //        }
                //        else
                //        {
                //            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                //        }
                //    }
                //    else
                //    {
                //        shInfo.SetMessage("There is some problem in Data Saving or your Document is Verified. Please try again.", ShowMessageType.Information);
                //    }
                //}
                //else
                //{
                //    shInfo.SetMessage("You have not uploaded the Document.", ShowMessageType.Information);
                //}
                 
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }


        
        

       

        [AjaxMethod]
        public string UploadDoc(string base64String, string documentID, string hidJUD, string hidDID, string hidTID, string fileName, string fileExt)
        {
            //ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (base64String.Length > 6)
            {

                Stream objFileStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(base64String));
                AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                // Stream objFileStream = flUpload.PostedFile.InputStream;
                // FileInfo objFile = new FileInfo(flUpload.PostedFile.FileName);

                string[] strings = base64String.Split(',');
                var bytes = Convert.FromBase64String(strings[1]);
                string extension = fileExt;
                string contenttype = string.Empty;
                switch (strings[0])
                {//check image's extension
                    case "data:image/jpeg;base64":
                        extension = ".jpeg";
                        contenttype = "image/jpeg";
                        break;
                    case "data:image/png;base64":
                        extension = ".png";
                        contenttype = "image/jpeg";
                        break;
                    case "data:application/pdf;base64":
                        extension = ".pdf";
                        contenttype = "application/pdf";
                        break;
                    default://should write cases for more images types
                        extension = string.Empty;
                        break;
                }
                if (extension != string.Empty)
                {
                    string sysfilename = Session["UserID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + extension;
                    string fileurl = azureDocumentUpload.UploadDocumentFromByteArrayWithContentType(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), bytes, contenttype, "studentdocuments");

                    if (extension != ".pdf")
                    {
                        byte[] data = default(byte[]);
                        data = CreateThumbnel(bytes);
                        string thumbnailUrl = azureDocumentUpload.UploadDocumentFromByteArrayWithContentType(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), data, contenttype, "studentdocumentsthumbnail");
                    }
                    //string fileurl = azureDocumentUpload.UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), sysfilename.ToLower(), objFileStream, contenttype, "studentdocuments");



                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    if (fileurl != "")
                    {
                        string uploadedFileURL, originalFileName;
                        uploadedFileURL = fileurl; originalFileName = fileName;

                        DataSet ds = null;
                        try
                        {
                            int DistrictID = 0;
                            int JuridictionID = 0;
                            int TalukaID = 0;
                            ViewState["documentID"] = documentID;
                            ViewState["sysfilename"] = sysfilename;
                            ViewState["uploadedFileURL"] = uploadedFileURL;
                            ViewState["originalFileName"] = originalFileName;
                            ds = new dbUtilitySEBC().saveUploadedDocument(objSessionData.PID, Convert.ToInt16(documentID), sysfilename, uploadedFileURL, originalFileName, Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress());
                            if (ds != null && ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                                {
                                    if (Convert.ToInt16(documentID) == 21 || Convert.ToInt16(documentID) == 22)
                                    {
                                        DataSet dsJ = null;
                                        if (Convert.ToInt16(documentID) == 21)
                                        {
                                            DistrictID = Convert.ToInt32(hidDID);
                                            JuridictionID = Convert.ToInt32(hidJUD);
                                            TalukaID = Convert.ToInt32(hidTID);
                                        }
                                        else
                                        {
                                            DistrictID = Convert.ToInt32(hidDID);
                                            JuridictionID = Convert.ToInt32(hidJUD);
                                        }
                                        dsJ = new dbUtilitySEBC().saveUploadedDocumentJuridiction(objSessionData.PID, Convert.ToInt16(documentID), Convert.ToString(Session["UserLoginID"]), UserInfo.GetIPAddress(), JuridictionID, DistrictID, TalukaID);
                                        if (dsJ != null && dsJ.Tables.Count > 0)
                                        {
                                            if (dsJ.Tables[0].Rows.Count > 0 && dsJ.Tables[0].Rows[0]["Status"].ToString() == "1")
                                            {
                                                //shInfo.SetMessage("The File has been uploaded.", ShowMessageType.Information);
                                                // LoadDocuments(objSessionData.PID);
                                                return "The File has been uploaded.";
                                            }
                                        }
                                        else
                                        {
                                            //shInfo.SetMessage("The File Juridiction Details Not Saved, Try Again.", ShowMessageType.Information);
                                            //LoadDocuments(objSessionData.PID);
                                            return "The File Juridiction Details Not Saved, Try Again.";
                                        }
                                    }
                                    else
                                    {
                                        //shInfo.SetMessage("The File has been uploaded.", ShowMessageType.Information);
                                        //LoadDocuments(objSessionData.PID);
                                        return "The File has been uploaded.";
                                    }
                                }
                                else
                                {
                                    //shInfo.SetMessage("The File Details Not Saved, Try Again.", ShowMessageType.Information);
                                    //LoadDocuments(objSessionData.PID);
                                    return "The File Details Not Saved, Try Again.";
                                }
                            }
                            else
                            {
                                //shInfo.SetMessage("The File Details Not Saved, Try Again.", ShowMessageType.Information);
                                //LoadDocuments(objSessionData.PID);
                                return "The File Details Not Saved, Try Again.";
                            }
                        }
                        catch (Exception ex)
                        {
                            Logging.LogException(ex, "[Page Level Error]");
                            // shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError);
                            ///LoadDocuments(objSessionData.PID);
                            return ex.Message;
                        }
                        finally
                        {
                            if (ds != null)
                                ds.Dispose();
                        }
                    }
                    else
                    {
                        //shInfo.SetMessage("Please Select File.", ShowMessageType.Information);
                        //LoadDocuments(objSessionData.PID);
                        return "Please Select File.";
                    }
                }
                return "";
            }
            else
            {
                return "Invalid File";
            }
        }
        [AjaxMethod]
        public DataSet FillJuridiction(string documentID)
        {
            DataSet ds = new DataSet();
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                if (documentID == "22")
                {
                    if (reg.getCategoryID(objSessionData.PID) == 3)
                    {
                        ds = reg.getMasterJuridiction("CT");
                    }
                    else
                    {
                        ds = reg.getMasterJuridiction("CV");
                    }
                }
                else
                {
                    ds = reg.getMasterJuridiction("CC");
                }
            }
            catch (Exception ex)
            {
            }
            return ds;
        }
        [AjaxMethod]
        public DataSet getDistrictForJuridiction(string JurisdictionID)
        {
            DataSet ds = new DataSet();
            try
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];

                ds = reg.getMasterDistrictForJuridiction(Convert.ToInt32(JurisdictionID));
            }
            catch (Exception ex)
            {
            }

            return ds;
        }
        [AjaxMethod]
        public DataSet getTalukaForDistrict(string DistrictID)
        {
            DataSet ds = new DataSet();
            try
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];

                ds = reg.getMasterTalukaForDistrict(Convert.ToInt32(DistrictID));
            }
            catch (Exception ex)
            {
            }

            return ds;
        }
        [AjaxMethod]
        public string getCategoryID()
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            return reg.getCategoryID(objSessionData.PID).ToString();
        }

        protected byte[] CreateThumbnel(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Bitmap thumb = new Bitmap(48, 69);
                using (System.Drawing.Image bmp = System.Drawing.Image.FromStream(ms))
                {
                    using (Graphics g = Graphics.FromImage(thumb))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawImage(bmp, 0, 0, 48, 69);
                    }
                }
                // a picturebox to show/test the result
                byte[] data = default(byte[]);
                using (System.IO.MemoryStream sampleStream = new System.IO.MemoryStream())
                {
                    thumb.Save(sampleStream, System.Drawing.Imaging.ImageFormat.Bmp);
                    data = sampleStream.ToArray();
                }
                return data;
            }
        }

        private class dbUtilitySEBC
        {
            public DataSet getUploadedDocumentlist(Int64 PID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PersonalID", SqlDbType.BigInt)
                };

                param[0].Value = PID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetDocumentToUpload", param);

                }
                finally
                {
                    db.Dispose();
                }

            }
            public DataSet GetAllDocuments(Int64 PID, Int32 DocumentID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.BigInt),
                    new SqlParameter("@DocumentID", SqlDbType.Int)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetAllCorrectDocuments", param);

                }
                finally
                {
                    db.Dispose();
                }

                //return ExecProcedure("MHDTE_spGetAllDocuments", param, "tbl");
            }
            public DataSet saveUploadedDocument(Int64 PID, Int64 DocumentID, string FileName, string AbsoluteFilePath, string OriginalFileName, string FileUploadedBy, string FileUploadedByIPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@DocumentID",SqlDbType.BigInt),
                    new SqlParameter("@FileName",SqlDbType.VarChar),
                    new SqlParameter("@AbsoluteFilePath",SqlDbType.VarChar),
                    new SqlParameter("@OriginalFileName",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),
                    new SqlParameter("@DocumentStatus",SqlDbType.VarChar),
                          new SqlParameter("@checkbarcode",SqlDbType.VarChar),
                    new SqlParameter("@barcode",SqlDbType.VarChar)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = FileName;
                param[3].Value = AbsoluteFilePath;
                param[4].Value = OriginalFileName;
                param[5].Value = FileUploadedBy;
                param[6].Value = FileUploadedByIPAddress;
                param[7].Value = "A";
                param[8].Value = "N";
                param[9].Value = "";
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUploadCorrectDocument", param);

                }
                finally
                {
                    db.Dispose();
                }
                // return ExecProcedure("MHDTE_spUpdateDocumentUploadStatus", param, "tbl");
            }

             
            public DataSet deleteUploadedDocument(Int64 PID, Int64 DocumentID, string FileUploadedBy, string FileUploadedByIPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@DocumentID",SqlDbType.BigInt),
                    new SqlParameter("@FileName",SqlDbType.VarChar),
                    new SqlParameter("@AbsoluteFilePath",SqlDbType.VarChar),
                    new SqlParameter("@OriginalFileName",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),
                    new SqlParameter("@DocumentStatus",SqlDbType.VarChar),
                      new SqlParameter("@checkbarcode",SqlDbType.VarChar),
                    new SqlParameter("@barcode",SqlDbType.VarChar)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = "";
                param[3].Value = "";
                param[4].Value = "";
                param[5].Value = FileUploadedBy;
                param[6].Value = FileUploadedByIPAddress;
                param[7].Value = "D";
                param[8].Value = 'N';
                param[9].Value = "";
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUploadCorrectDocument", param);

                }
                finally
                {
                    db.Dispose();
                }

                // return ExecProcedure("MHDTE_spUpdateDocumentUploadStatus", param, "tbl");
            }
            public DataSet saveUploadedDocumentJuridiction(Int64 PID, Int64 DocumentID, string FileUploadedBy, string FileUploadedByIPAddress, int JuridictionID, int DistrictID, int TalukaID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID",SqlDbType.BigInt),
                    new SqlParameter("@DocumentID",SqlDbType.BigInt),
                    new SqlParameter("@FileUploadedBy",SqlDbType.VarChar),
                    new SqlParameter("@FileUploadedByIPAddress",SqlDbType.VarChar),
                    new SqlParameter("@JuridictionID",SqlDbType.Int),
                    new SqlParameter("@DistrictID",SqlDbType.Int),
                    new SqlParameter("@TalukaID",SqlDbType.Int)
                };

                param[0].Value = PID;
                param[1].Value = DocumentID;
                param[2].Value = FileUploadedBy;
                param[3].Value = FileUploadedByIPAddress;
                param[4].Value = JuridictionID;
                param[5].Value = DistrictID;
                param[6].Value = TalukaID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spUpdateJuridictionDocumentUpload", param);

                }
                finally
                {
                    db.Dispose();
                }

                //return ExecProcedure("MHDTE_spUpdateJuridictionDocumentUpload", param, "tbl");
            }
            public DataSet CheckCandidateeligibleforUpload(Int64 PID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.BigInt)
                };

                param[0].Value = PID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spcheckCandidateEligibleforUploadCorrectDocument", param);

                }
                finally
                {
                    db.Dispose();
                }

            }
        }


        }
}