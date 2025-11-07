using AjaxPro;
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.E_FCModule
{
    public partial class EVerificationUniversityAndCategoryDetails : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public int CurrentDocID;
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["UserTypeID"] == null || Session["UserTypeID"].ToString() == "91")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (reg.CheckISEFC(Session["UserLoginId"].ToString()) == "N" && (Convert.ToInt16(Session["UserTypeID"]) == 23 || Convert.ToInt16(Session["UserTypeID"]) == 24))
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            if ((DateTime.Now < Global.DocumentVerificationStartDateTime || DateTime.Now > Global.DocumentVerificationEndDateTime) && Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
            Int32 ApplicationFormStepID = Convert.ToInt32(Request.QueryString["ApplicationFormStepID"].ToString());
            if (PID.ToString().GetHashCode() != Code)
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }

            if (Request.QueryString["ForSEBC"] != null)
            {
                ViewState["ForSEBC"] = "N";
            }
            else
            {
                ViewState["ForSEBC"] = "N";
            }

            ViewState["PID"] = PID;
            ViewState["ApplicationFormStepID"] = ApplicationFormStepID;
            CandidateBasicInformation.PID = Convert.ToInt64(ViewState["PID"].ToString());
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            int CandidatureTypeID = reg.getCandidatureTypeID(PID);
            AjaxPro.Utility.RegisterTypeForAjax(typeof(EVerificationUniversityAndCategoryDetails));
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMyDocument));
            if (!IsPostBack)
            {
                try
                {
                    ViewState["CurrentDocID"] = 0;
                    PersonalInformation obj = reg.getPersonalInformation(PID);
                    HomeUniversityAndCategoryDetails objHDC = reg.getHomeUniversityAndCategoryDetails(PID);
                    lblCandidatureType.Text += obj.FinalCandidatureType;
                    lblAnnualFamilyIncome.Text = obj.AnnualFamilyIncome;
                    lblDocumentOf.Text = objHDC.DocumentOfCode.ToString() == "C" ? "Candidate" : objHDC.DocumentOfCode.ToString() == "F" ? "Father" : objHDC.DocumentOfCode.ToString() == "M" ? "Mother" : "Not Applicable";
                    lblMothersName.Text = obj.MothersName;
                    lblDistrict2.Text = obj.HSCDistrict;//.ToString();
                    tblNCLApplied.Visible = false;
                    lblTaluka2.Text = obj.HSCTaluka; // objHDC.HSCTalukaID.ToString();
                    lblCategory.Text = obj.FinalCategory;//objHDC.CategoryID.ToString();

                    trAppliedForEWS1.Visible = false;
                    trAppliedForEWS2.Visible = false;
                    trMothersName.Visible = false;
                    trOpenCaste.Visible = false;
                    if (objHDC.CategoryID == 1)
                    {
                        trAppliedForEWS1.Visible = true;
                        trAppliedForEWS2.Visible = true;
                        trOpenCaste.Visible = true;
                        trReservedCaste.Visible = false;
                        lblCasteNameForOpen.Text = obj.CasteNameForOpen;
                        lblNCLStatus.Text = "NA";
                    }
                    lblAppliedForEWS.Text = obj.AppliedForEWS;
                    if (objHDC.CategoryID > 1)
                    {

                        lblCaste.Text = obj.CasteName;//.CasteID.ToString();

                    }
                    if (objHDC.CategoryID > 4)
                    {

                        lblNCLStatus.Text = objHDC.NCLStatus.ToString() == "R" ? "Available" : objHDC.NCLStatus.ToString() == "A" ? "Applied and Not Received" : objHDC.NCLStatus.ToString() == "N" ? "Not Applied" : "";
                        if (objHDC.NCLStatus.ToString() == "R" || objHDC.NCLStatus.ToString() == "N")
                        {
                            tblNCLApplied.Visible = false;
                        }
                        lblNCLApplicationNo.Text = objHDC.NCLApplicationNo;
                        lblNCLApplicationDate.Text = objHDC.NCLApplicationDate;
                        lblNCLAuthority.Text = objHDC.NCLAuthority;
                    }
                    if (objHDC.CategoryID == 2 || objHDC.CategoryID == 3)
                    {
                        trOpenCaste.Visible = false;
                        trAppliedForEWS1.Visible = false;
                        trAppliedForEWS2.Visible = false;
                        trReservedCaste.Visible = true;
                        //trNCLStatus.Visible = false;
                        tblNCLApplied.Visible = false;
                        lblAppliedForEWS.Visible = false;
                        lblNCLStatus.Text = "NA";
                    }
                    if (CandidatureTypeID == 1)
                    {
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;

                        lblQ2.Text = "District from which Candidate has Passed HSC";
                        lblQ21.Text = "Taluka from which Candidate has Passed HSC";

                    }
                    else if (CandidatureTypeID == 2)
                    {
                        if (objHDC.DocumentOfCode.ToString() == "M")
                        {
                            trMothersName.Visible = true;
                        }
                        else
                        {
                            trMothersName.Visible = false;
                        }

                        QDocumentOf.Text = "Whose Domicile Certificate You are Submitting at SC ?";
                        lblQ2.Text = "District where Candidate / Father or Mother of Candidate is Domiciled in Maharashtra";
                        lblQ21.Text = "Taluka where Candidate / Father or Mother of Candidate is Domiciled in Maharashtra";
                    }
                    else if (CandidatureTypeID == 3)
                    {
                        trMothersName.Visible = false;


                        QDocumentOf.Text = "Whose Proforma - A You are Submitting at SC ?";
                        lblQ2.Text = "District where Father or Mother of Candidate is Posted in Maharashtra";
                        lblQ21.Text = "Taluka where Father or Mother of Candidate is Posted in Maharashtra";
                    }
                    else if (CandidatureTypeID == 4)
                    {
                        trMothersName.Visible = false;


                        QDocumentOf.Text = "Whose Proforma - B You are Submitting at SC ?";
                        lblQ2.Text = "District where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra";
                        lblQ21.Text = "Taluka where Father or Mother of Candidate is Posted / Settled after Retirement in Maharashtra";
                    }
                    else if (CandidatureTypeID == 5)
                    {
                        trCategoryHead.Visible = false;
                        trCategory.Visible = false;
                        trOpenCaste.Visible = false;
                        trAppliedForEWS1.Visible = false;
                        trAppliedForEWS2.Visible = false;
                        trReservedCaste.Visible = false;
                        trNCLStatus.Visible = false;
                        tblNCLApplied.Visible = false;
                        trDocumentOf.Visible = false;
                        trMothersName.Visible = false;
                        lblAppliedForEWS.Visible = false;
                        ContentTable2.HeaderText = "Home District Details";
                        lblQ2.Text = "District from which Candidate has Passed HSC";
                        lblQ21.Text = "Taluka from which Candidate has Passed HSC";
                    }

                    //Document 
                    DataSet dsDocVerification = reg.GetDocumentListForDocumentVerificationByStepID(Convert.ToInt64(ViewState["PID"]), Convert.ToInt32(ViewState["ApplicationFormStepID"]));
                    if (dsDocVerification.Tables[0].Rows.Count > 0)
                    {
                        gvDocuments.DataSource = dsDocVerification;
                        gvDocuments.DataBind();
                    }
                    else
                    {
                        tblDocuments.Visible = false;
                    }

                    DataSet ds = reg.GetDocumentListForDataVerificationByStepID(Convert.ToInt64(ViewState["PID"]), Convert.ToInt32(ViewState["ApplicationFormStepID"]));
                    //ddlDocumentList.DataSource = ds;
                    //ddlDocumentList.DataTextField = "DocumentName";
                    //ddlDocumentList.DataValueField = "DocumentName";
                    //ddlDocumentList.DataBind();
                    if (ds.Tables.Count > 0)
                    {
                        ReadoDocumentList.DataSource = ds;
                    ReadoDocumentList.DataTextField = "DocumentName";
                    ReadoDocumentList.DataValueField = "DocumentName";
                    ReadoDocumentList.SelectedIndex = 0;
                    ReadoDocumentList.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        trdocument.Visible = true;
                        CurrentDocID = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (i == CurrentDocID && ds.Tables[0].Rows[i]["FilePath"].ToString() != "")
                            {
                                string docpath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                                string docName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
                                string IsBarcodeFetch = ds.Tables[0].Rows[i]["IsBarcodeFetch"].ToString();
                                string documentID = ds.Tables[0].Rows[i]["DocumentID"].ToString();
                                string personalID = ds.Tables[0].Rows[i]["PersonalID"].ToString();
                                string docfun = "LoadDocument('" + docpath + "','" + docName + "','" + personalID + "','" + documentID + "','" + IsBarcodeFetch + "');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);
                                break;
                            }
                            else
                            {
                                CurrentDocID = CurrentDocID + 1;
                            }
                        }
                    }
                }
                    DataSet dsDiscrepancy = reg.GetDiscrepancyListByStepID(Convert.ToInt64(ViewState["PID"]), Convert.ToInt32(ViewState["ApplicationFormStepID"]));
                    if (dsDiscrepancy.Tables[0].Rows.Count > 0)
                    {
                        gvDiscrepancy.DataSource = dsDiscrepancy;
                        gvDiscrepancy.DataBind();

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "MarkDiscripency();", true);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void gvDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hidFURL = (HiddenField)e.Row.FindControl("hidFURL");
                    if (hidFURL.Value != "")
                    {
                        string ext = System.IO.Path.GetExtension(hidFURL.Value).ToLower();
                        HtmlImage imgDoc = (HtmlImage)e.Row.FindControl("imgDoc");
                        HiddenField hidDID = (HiddenField)e.Row.FindControl("hidDID");
                        HtmlAnchor hrefURL = (HtmlAnchor)e.Row.FindControl("hrefURL");
                        HiddenField hdnImgByteArray = (HiddenField)e.Row.FindControl("hdnImgByteArray");
                        hrefURL.HRef = ConfigurationManager.AppSettings["ApplicationURL"] + "ViewMyDocument.aspx?documentID=" + hidDID.Value;
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
                            string base64 = objDU.GetBlobContentAsBase64("studentdocumentsthumbnail", url);//objDU.ConvertImageURLToBase64(url);
                            imgDoc.Src = base64; //"data:image/png;base64," +
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
                        hdnImgByteArray.Value = objDU.GetBlobContentAsBase64("studentdocuments", hidFURL.Value.ToString());
                    }

                    if (((HiddenField)e.Row.Cells[7].FindControl("hdnImgUrl")).Value.Length > 0)
                    {
                        if (((Label)e.Row.Cells[5].FindControl("lblIsSubmitted")).Text == "N")
                        {
                            ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = false;
                            ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = false;
                        }
                        else
                        {
                            ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = true;
                            ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = false;
                        }
                    }
                    else
                    {
                        ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Checked = false;
                        ((RadioButton)e.Row.Cells[3].FindControl("rbnNo")).Checked = true;
                        ((RadioButton)e.Row.Cells[2].FindControl("rbnYes")).Enabled = false;
                        e.Row.BackColor = System.Drawing.Color.Red;
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
                Int64 PID = Convert.ToInt64(ViewState["PID"]);
                DataSet statusDs = reg.getVerificationFlags(PID);
                char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                //char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());

                if (FCVerificationStatus != 'P' && ViewState["ForSEBC"].ToString() == "N")
                {
                    shInfo.SetMessage("Due to Multiple Logins Application Form is Already confirmed or Not Picked.", ShowMessageType.Information);
                }
                else
                {
                    string varidation = ValidateDiscripancyandDocument();
                    if (varidation.Length > 0)
                    {
                        shInfo.SetMessage(varidation, ShowMessageType.Information);
                        lblmessage.Visible = true;
                        lblmessage.Text = varidation;
                        btnProceed.Focus();
                    }
                    else
                    {
                        lblmessage.Text = "";
                        int DocumentCounter = 0;
                        int DiscrepancyCounter = 0;
                        string XMLstring = "<DocumentList>";
                        for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                        {
                            string DocumentID = ((Label)gvDocuments.Rows[i].FindControl("lblDocumentID")).Text;

                            if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                            {
                                XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "Y" + "\"></Document>";
                            }
                            else
                            {
                                XMLstring += "<Document DocumentID=\"" + DocumentID + "\" IsSubmittedAtAFC=\"" + "N" + "\"></Document>";
                                DocumentCounter = DocumentCounter + 1;
                            }
                        }
                        XMLstring += "</DocumentList>";

                        lblmessage.Visible = false;

                        string notVerifyList = ValidateRadiobuttonChecked();
                        if (notVerifyList == string.Empty)
                        {
                            string strRemarkAdded = ValidateRemarkAddedForDiscrepnacy();
                            if (strRemarkAdded == string.Empty)
                            {
                                string XMLstringDiscrepancy = "<DiscrepancyList>";
                                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                                {
                                    string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
                                    string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

                                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked)
                                    {
                                        XMLstringDiscrepancy += "<Discrepancy DiscrepancyID=\"" + DiscrepancyID + "\" IsVerifiedAtAFC=\"" + "Y" + "\" IsDiscrepancyMarked=\"" + "N" + "\" DiscrepancyRemark=\"" + DiscrepancyRemark + "\"></Discrepancy>";
                                    }
                                    else
                                    {
                                        DiscrepancyCounter = DiscrepancyCounter + 1;
                                        XMLstringDiscrepancy += "<Discrepancy DiscrepancyID=\"" + DiscrepancyID + "\" IsVerifiedAtAFC=\"" + "N" + "\" IsDiscrepancyMarked=\"" + "Y" + "\" DiscrepancyRemark=\"" + DiscrepancyRemark + "\"></Discrepancy>";
                                    }
                                }
                                XMLstringDiscrepancy += "</DiscrepancyList>";
                                if (DocumentCounter > 0 && DiscrepancyCounter == 0)
                                {
                                    btnProceed.Focus();
                                    lblmessage.Visible = true;
                                    lblmessage.Text = "Please Enter Discrepancy or Verify the Document.";
                                }
                                else
                                {
                                    if (ValidateDocumentVerified() == string.Empty)
                                    {
                                        if (reg.updateDocumentSubmission(PID, XMLstring, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                        {
                                            if (reg.UpdateDiscrepancySubmission(Convert.ToInt64(ViewState["PID"]), XMLstringDiscrepancy, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                                            {
                                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "HideMarkDiscripency();", true);
                                                // if (ViewState["ForSEBC"].ToString() == "N")
                                                Response.Redirect("../E_FCModule/FCApplicationFormVerificationDashboard?PID=" + Convert.ToInt64(ViewState["PID"]) + "&Code=" + Convert.ToInt64(ViewState["PID"]).ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + (Convert.ToInt32(ViewState["ApplicationFormStepID"]) + 1));
                                                //  else
                                                //     if (ViewState["ForSEBC"].ToString() == "Y")
                                                //Response.Redirect("../E_FCModule/VerificationAppliction?PID=" + Convert.ToInt64(ViewState["PID"]) + "&Code=" + Convert.ToInt64(ViewState["PID"]).ToString().GetHashCode().ToString() + "&ApplicationFormStepID=8&ForSEBC=Y");

                                            }
                                            else
                                            {
                                                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                            }

                                        }
                                        else
                                        {
                                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                                        }
                                    }
                                    else
                                    {
                                        btnProceed.Focus();
                                        lblmessage.Text = "Please verify the Documents";
                                    }

                                }

                            }
                            else
                            {
                                btnProceed.Focus();
                                lblmessage.Visible = true;
                                lblmessage.Text = "Please Enter Discrepancy Remark for : " + strRemarkAdded;
                            }
                        }
                        else
                        {
                            btnProceed.Focus();
                            lblmessage.Visible = true;
                            lblmessage.Text = "Please Mark the Verification Status for : " + notVerifyList;
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
        protected void btnECandidateDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("../E_FCModule/FCApplicationFormVerificationDashboard?PID=" + ViewState["PID"].ToString() + "&Code=" + ViewState["PID"].ToString().GetHashCode().ToString());
        }
        protected void gvDiscrepancy_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (((Label)e.Row.FindControl("lblIsVerifiedAtAFC")).Text == "Y")
                    {
                        ((RadioButton)e.Row.FindControl("rbnYes")).Checked = true;
                        ((RadioButton)e.Row.FindControl("rbnNo")).Checked = false;
                        ((Label)e.Row.FindControl("lblStar")).Visible = false;
                    }
                    else if (((Label)e.Row.FindControl("lblIsDiscrepancyMarked")).Text == "Y")
                    {
                        ((RadioButton)e.Row.FindControl("rbnYes")).Checked = false;
                        ((RadioButton)e.Row.FindControl("rbnNo")).Checked = true;
                        ((TextBox)e.Row.FindControl("txtDiscrepancyRemark")).Enabled = true;
                        ((RequiredFieldValidator)e.Row.FindControl("rfvtxtDiscrepancyRemark")).Enabled = true;
                        e.Row.BackColor = System.Drawing.Color.Red;
                        ((Label)e.Row.FindControl("lblStar")).Visible = true;
                    }
                    else
                    {
                        ((RadioButton)e.Row.FindControl("rbnYes")).Checked = false;
                        ((RadioButton)e.Row.FindControl("rbnNo")).Checked = false;
                        ((RequiredFieldValidator)e.Row.FindControl("rfvtxtDiscrepancyRemark")).Enabled = false;
                        ((TextBox)e.Row.FindControl("txtDiscrepancyRemark")).Enabled = false;
                        ((Label)e.Row.FindControl("lblStar")).Visible = false;

                    }

                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void rbnYes_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                RadioButton rbYes = sender as RadioButton;
                GridViewRow parentRow = rbYes.NamingContainer as GridViewRow;
                lblmessage.Text = "";
                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                {
                    TextBox txtDiscrepancyRemark = (TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark");
                    RequiredFieldValidator rfvtxtDiscrepancyRemark = (RequiredFieldValidator)gvDiscrepancy.Rows[i].FindControl("rfvtxtDiscrepancyRemark");
                    Label lblStar = (Label)gvDiscrepancy.Rows[i].FindControl("lblStar");

                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked)
                    {
                        txtDiscrepancyRemark.Text = "";
                        txtDiscrepancyRemark.Enabled = false;
                        rfvtxtDiscrepancyRemark.Enabled = false;
                        lblStar.Visible = false;
                    }
                    //else
                    //{
                    //    txtDiscrepancyRemark.Text = "";
                    //    txtDiscrepancyRemark.Enabled = true;
                    //    rfvtxtDiscrepancyRemark.Enabled = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void rbnNo_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                RadioButton rbnNo = sender as RadioButton;
                GridViewRow parentRow = rbnNo.NamingContainer as GridViewRow;
                lblmessage.Text = "";
                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                {
                    TextBox txtDiscrepancyRemark = (TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark");
                    RequiredFieldValidator rfvtxtDiscrepancyRemark = (RequiredFieldValidator)gvDiscrepancy.Rows[i].FindControl("rfvtxtDiscrepancyRemark");
                    Label lblStar = (Label)gvDiscrepancy.Rows[i].FindControl("lblStar");

                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        txtDiscrepancyRemark.Enabled = true;
                        rfvtxtDiscrepancyRemark.Enabled = true;
                        lblStar.Visible = true;
                    }
                    //else
                    //{
                    //    txtDiscrepancyRemark.Text = "";
                    //    txtDiscrepancyRemark.Enabled = false;
                    //    rfvtxtDiscrepancyRemark.Enabled = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSubmitDiscripancy_Click(object sender, EventArgs e)
        {
            //lblmessage.Visible = false;
            //ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //string notVerifyList = ValidateRadiobuttonChecked();
            //if (notVerifyList == string.Empty)
            //{
            //    string strRemarkAdded = ValidateRemarkAddedForDiscrepnacy();
            //    if (strRemarkAdded == string.Empty)
            //    {
            //        string XMLstring = "<DiscrepancyList>";
            //        for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
            //        {
            //            string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
            //            string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

            //            if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked)
            //            {
            //                XMLstring += "<Discrepancy DiscrepancyID=\"" + DiscrepancyID + "\" IsVerifiedAtAFC=\"" + "Y" + "\" IsDiscrepancyMarked=\"" + "N" + "\" DiscrepancyRemark=\"" + DiscrepancyRemark + "\"></Discrepancy>";
            //            }
            //            else
            //            {
            //                XMLstring += "<Discrepancy DiscrepancyID=\"" + DiscrepancyID + "\" IsVerifiedAtAFC=\"" + "N" + "\" IsDiscrepancyMarked=\"" + "Y" + "\" DiscrepancyRemark=\"" + DiscrepancyRemark + "\"></Discrepancy>";
            //            }
            //        }
            //        XMLstring += "</DiscrepancyList>";

            //        if (reg.UpdateDiscrepancySubmission(Convert.ToInt64(ViewState["PID"]), XMLstring, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
            //        {
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "HideMarkDiscripency();", true);
            //            Response.Redirect("../E_FCModule/FCApplicationFormVerificationDashboard?PID=" + Convert.ToInt64(ViewState["PID"]) + "&Code=" + Convert.ToInt64(ViewState["PID"]).ToString().GetHashCode().ToString() + "&ApplicationFormStepID=" + (Convert.ToInt32(ViewState["ApplicationFormStepID"]) + 1));
            //        }
            //        else
            //        {
            //            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
            //        }
            //    }
            //    else
            //    {
            //        lblmessage.Visible = true;
            //        lblmessage.Text = "Please Enter Discrepancy Remark for : " + strRemarkAdded;
            //    }
            //}
            //else
            //{
            //    lblmessage.Visible = true;
            //    lblmessage.Text = "Please Mark the Verification Status for : " + notVerifyList;
            //}
        }
        private class DocumentIDForCheck
        {
            public int DocumentID { get; set; }
        }
        private string ValidateDiscripancyandDocument()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string result = string.Empty;
                List<DocumentIDForCheck> NotCheckDiscripancy = new List<DocumentIDForCheck>();
                List<DocumentIDForCheck> CheckDiscripancy = new List<DocumentIDForCheck>();
                List<DocumentIDForCheck> NotCheckDocuments = new List<DocumentIDForCheck>();
                List<DocumentIDForCheck> CheckDocuments = new List<DocumentIDForCheck>();

                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                {
                    string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;
                    int DocumentID = Convert.ToInt32(((Label)gvDiscrepancy.Rows[i].FindControl("lblDocumentId")).Text);

                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked)
                    {
                        DocumentIDForCheck DocID = new DocumentIDForCheck();
                        DocID.DocumentID = DocumentID;
                        CheckDiscripancy.Add(DocID);
                    }
                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        DocumentIDForCheck DocID = new DocumentIDForCheck();
                        DocID.DocumentID = DocumentID;
                        NotCheckDiscripancy.Add(DocID);
                    }
                }
                for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                {
                    int DocumentID = Convert.ToInt32(((HiddenField)gvDocuments.Rows[i].FindControl("hdnDocId")).Value);
                    //string DiscrepancyID = ((Label)gvDocuments.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    //string DiscrepancyRemark = ((TextBox)gvDocuments.Rows[i].FindControl("txtDiscrepancyRemark")).Text;
                    if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked)
                    {
                        DocumentIDForCheck DocID = new DocumentIDForCheck();
                        DocID.DocumentID = DocumentID;
                        CheckDocuments.Add(DocID);
                    }
                    if (((RadioButton)gvDocuments.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        DocumentIDForCheck DocID = new DocumentIDForCheck();
                        DocID.DocumentID = DocumentID;
                        NotCheckDocuments.Add(DocID);
                    }
                }
                //Logic for discripancy marked are present in verification
                HashSet<int> diffidsCheck = new HashSet<int>(CheckDiscripancy.Select(s => s.DocumentID));
                List<DocumentIDForCheck> resultsCheck = NotCheckDocuments.Where(m => diffidsCheck.Contains(m.DocumentID)).ToList();

                // logic for discripancy not marked are present in not verification of document
                HashSet<int> diffidsNotCheck = new HashSet<int>(NotCheckDiscripancy.Select(s => s.DocumentID));
                List<DocumentIDForCheck> resultsNotCheck = CheckDocuments.Where(m => diffidsNotCheck.Contains(m.DocumentID)).ToList();

                if (resultsCheck.Count > 0 || resultsNotCheck.Count > 0)
                {
                    return "Verify the Discrepancy and Document are marked Correctly!!";
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return null;
            }
        }
        private string ValidateRadiobuttonChecked()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string NotCheckDiscripancy = string.Empty;
                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                {
                    string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

                    if (!((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnYes")).Checked && !((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        if (NotCheckDiscripancy == String.Empty)
                        {
                            NotCheckDiscripancy = gvDiscrepancy.Rows[i].Cells[1].Text;
                        }
                        else
                            NotCheckDiscripancy = NotCheckDiscripancy + ", " + gvDiscrepancy.Rows[i].Cells[1].Text;
                    }

                }
                return NotCheckDiscripancy;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return null;
            }
        }

        private string ValidateDocumentVerified()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string NotCheckDiscripancy = string.Empty;
                for (Int32 i = 0; i < gvDocuments.Rows.Count; i++)
                {
                    //string DiscrepancyID = ((Label)gvDocuments.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    //string DiscrepancyRemark = ((TextBox)gvDocuments.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

                    if (!((RadioButton)gvDocuments.Rows[i].FindControl("rbnYes")).Checked && !((RadioButton)gvDocuments.Rows[i].FindControl("rbnNo")).Checked)
                    {
                        if (NotCheckDiscripancy == String.Empty)
                        {
                            NotCheckDiscripancy = gvDocuments.Rows[i].Cells[1].Text;
                        }
                        else
                            NotCheckDiscripancy = NotCheckDiscripancy + ", " + gvDocuments.Rows[i].Cells[1].Text;
                    }

                }
                return NotCheckDiscripancy;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return null;
            }
        }
        private string ValidateRemarkAddedForDiscrepnacy()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string NotCheckDiscripancy = string.Empty;
                for (Int32 i = 0; i < gvDiscrepancy.Rows.Count; i++)
                {
                    string DiscrepancyID = ((Label)gvDiscrepancy.Rows[i].FindControl("lblDiscrepancyID")).Text;
                    string DiscrepancyRemark = ((TextBox)gvDiscrepancy.Rows[i].FindControl("txtDiscrepancyRemark")).Text;

                    if (((RadioButton)gvDiscrepancy.Rows[i].FindControl("rbnNo")).Checked && DiscrepancyRemark == "")
                    {

                        if (NotCheckDiscripancy == String.Empty)
                        {
                            NotCheckDiscripancy = gvDiscrepancy.Rows[i].Cells[1].Text;
                        }
                        else
                            NotCheckDiscripancy = NotCheckDiscripancy + "," + gvDiscrepancy.Rows[i].Cells[1].Text;
                    }

                }
                return NotCheckDiscripancy;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                return null;
            }
        }
        protected void btnCancelDiscripancy_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                tblSubmit.Visible = true;
                DataSet ds = reg.GetDocumentListForDataVerificationByStepID(Convert.ToInt64(ViewState["PID"]), Convert.ToInt32(ViewState["ApplicationFormStepID"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i == Convert.ToInt32(ViewState["CurrentDocID"]))
                        {
                            string docpath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                            string docName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
                            string docfun = "HideMarkDiscripencyDoc('" + docpath + "','" + docName + "');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);

                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "HideMarkDiscripency();", true);

                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        //protected void ddlDocumentList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
        //    string selectedvalue = ddlDocumentList.SelectedValue;
        //    DataSet ds = reg.GetDocumentListForDataVerificationByStepID(Convert.ToInt64(ViewState["PID"]), Convert.ToInt32(ViewState["ApplicationFormStepID"]));
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            if (ds.Tables[0].Rows[i]["DocumentName"].ToString() == selectedvalue)
        //            {
        //                if (ds.Tables[0].Rows[i]["FilePath"].ToString() != "")
        //                {
        //                    string docpath = ds.Tables[0].Rows[i]["FilePath"].ToString();
        //                    string docName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
        //                    string docfun = "LoadDocument('" + docpath + "','" + docName + "');";
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);
        //                }
        //                else
        //                {
        //                    shInfo.SetMessage("Candidate has not uploaded the Document :" + selectedvalue, ShowMessageType.Information);
        //                }
        //            }
        //        }
        //    }
        //}
        protected void ReadoDocumentList_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string selectedvalue = ReadoDocumentList.SelectedValue;
                DataSet ds = reg.GetDocumentListForDataVerificationByStepID(Convert.ToInt64(ViewState["PID"]), Convert.ToInt32(ViewState["ApplicationFormStepID"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["DocumentName"].ToString() == selectedvalue)
                        {
                            if (ds.Tables[0].Rows[i]["FilePath"].ToString() != "")
                            {
                                string docpath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                                string docName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
                                string IsBarcodeFetch = ds.Tables[0].Rows[i]["IsBarcodeFetch"].ToString();
                                string documentID = ds.Tables[0].Rows[i]["DocumentID"].ToString();
                                string personalID = ds.Tables[0].Rows[i]["PersonalID"].ToString();
                                string docfun = "LoadDocument('" + docpath + "','" + docName + "','" + personalID + "','" + documentID + "','" + IsBarcodeFetch + "');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", docfun, true);
                            }
                            else
                            {
                                shInfo.SetMessage("Candidate has not uploaded the Document :" + selectedvalue, ShowMessageType.Information);
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

        [AjaxMethod]
        public ResponseCommon GetDocumentFetchData(Int64 PersonalID, Int64 DocID)
        {
            return reg.GetDocumentFetchData(PersonalID, DocID);

        }
    }
}