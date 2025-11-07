using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmCheckCasteValidityCertificate : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        CasteValidityRequest objReq = new CasteValidityRequest();
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
            if (!IsPostBack)
            {
                ddlCVCDistrict.DataSource = Global.MasterMHDistrict;
                ddlCVCDistrict.DataTextField = "DistrictName";
                ddlCVCDistrict.DataValueField = "DistrictName";
                ddlCVCDistrict.DataBind();
                ddlCVCDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));

                ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Uttara Kannada (Karwar)"));
                ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Bidar"));
                ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Kalaburagi (Gulbarga)"));
                ddlCVCDistrict.Items.Remove(ddlCVCDistrict.Items.FindByText("Belagavi (Belgaum)"));

                BindData();
            }
        }

        private void BindData()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
            Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
            try
            {


                DataSet ds = objReq.CheckCandidateCasteValidityRequestStatus(PID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    hidStatus.Value = ds.Tables[0].Rows[0]["CasteValidityStatus"].ToString();
                    ddlCasteValidityStatus.SelectedValue = ds.Tables[0].Rows[0]["CasteValidityStatus"].ToString();
                    lblCandidateName.Value = ds.Tables[0].Rows[0]["CandidateName"].ToString();
                    if (ds.Tables[0].Rows[0]["CasteValidityStatus"].ToString() == "N")
                        lblOldStatus.Text = "Not Applied";
                    else if (ds.Tables[0].Rows[0]["CasteValidityStatus"].ToString() == "A")
                        lblOldStatus.Text = "Applied and Not Received";
                    else if (ds.Tables[0].Rows[0]["CasteValidityStatus"].ToString() == "R")
                        lblOldStatus.Text = "Available";

                    txtAppDate.Text = ds.Tables[0].Rows[0]["CVCApplicationDate"].ToString();
                    txtCCNumber.Text = ds.Tables[0].Rows[0]["CCNumber"].ToString();
                    txtCVCApplicationNo.Text = ds.Tables[0].Rows[0]["CVCApplicationNo"].ToString();
                    txtCVCAuthority.Text = ds.Tables[0].Rows[0]["CVCAuthority"].ToString();
                    ddlCVCDistrict.SelectedValue = ds.Tables[0].Rows[0]["CVCDistrict"].ToString();
                    txtCVCName.Text = ds.Tables[0].Rows[0]["CVCName"].ToString();
                    if (ds.Tables[0].Rows[0]["CasteValidityStatus"].ToString() == "A" || ds.Tables[0].Rows[0]["CasteValidityStatus"].ToString() == "R")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            thumimg.ImageUrl = ds.Tables[1].Rows[0]["AbsoluteFilePath"].ToString();
                        }
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        tblReqDetails.Visible = true;
                        if (ds.Tables[0].Rows[0]["CasteValidityStatus"].ToString() == "A")
                        {
                            lblCVS.Text = "Applied and Not Received";
                            tr7.Visible = true; tr8.Visible = true; tr9.Visible = true; tr10.Visible = true; tr11.Visible = true; tr12.Visible = true;
                            lblCVCApplicationNo.Text = ds.Tables[0].Rows[0]["CVCApplicationNo"].ToString();
                            lblCVCApplicationDate.Text = ds.Tables[0].Rows[0]["CVCApplicationDate"].ToString();
                            lblCVCAuthority.Text = ds.Tables[0].Rows[0]["CVCAuthority"].ToString();
                            lblCVCDistrict.Text = ds.Tables[0].Rows[0]["CVCDistrict"].ToString();
                            lblCVCName.Text = ds.Tables[0].Rows[0]["CVCName"].ToString();
                            lblCCNumber.Text = ds.Tables[0].Rows[0]["CCNumber"].ToString();
                        }
                        else
                        {
                            lblCVS.Text = "Available";
                            tr7.Visible = false; tr8.Visible = false; tr9.Visible = false; tr10.Visible = false; tr11.Visible = false; tr12.Visible = false;
                        }
                        if (ds.Tables[1].Rows[0]["IsSubmittedAtAFC"].ToString() == "Y")
                        {
                            lblRStatus.Text = "Confirmed";
                            lblRStatus.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblRStatus.Text = "Pending (Please contact nearest SC to verify the document)";
                            lblRStatus.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                }
                else if (ds.Tables.Count > 1)
                {
                    tblReqDetails.Visible = true;
                    if (ds.Tables[1].Rows[0]["CasteValidityStatus"].ToString() == "A")
                    {
                        lblCVS.Text = "Applied and Not Received";
                        tr7.Visible = true; tr8.Visible = true; tr9.Visible = true; tr10.Visible = true; tr11.Visible = true; tr12.Visible = true;
                        lblCVCApplicationNo.Text = ds.Tables[0].Rows[0]["CVCApplicationNo"].ToString();
                        lblCVCApplicationDate.Text = ds.Tables[0].Rows[0]["CVCApplicationDate"].ToString();
                        lblCVCAuthority.Text = ds.Tables[0].Rows[0]["CVCAuthority"].ToString();
                        lblCVCDistrict.Text = ds.Tables[0].Rows[0]["CVCDistrict"].ToString();
                        lblCVCName.Text = ds.Tables[0].Rows[0]["CVCName"].ToString();
                        lblCCNumber.Text = ds.Tables[0].Rows[0]["CCNumber"].ToString();
                    }
                    else
                    {
                        lblCVS.Text = "Available";
                        tr7.Visible = false; tr8.Visible = false; tr9.Visible = false; tr10.Visible = false; tr11.Visible = false; tr12.Visible = false;
                    }
                    if (ds.Tables[1].Rows[0]["IsSubmittedAtAFC"].ToString() == "Y")
                    {
                        lblRStatus.Text = "Confirmed";
                        lblRStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblRStatus.Text = "Pending (Please contact nearest SC to verify the document)";
                        lblRStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    ContentTable2.Visible = false;
                    shInfo.SetMessage("You are not allowed to change caste validity status!", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSubmite_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());
                string fileurl = ""; int docid = 0;

                if (flUpload.HasFile)
                {
                    AzureDocumentUpload azureDocumentUpload = new AzureDocumentUpload();
                    Stream objFileStream = flUpload.PostedFile.InputStream;
                    FileInfo objFile = new FileInfo(flUpload.PostedFile.FileName);
                    string sysfilename = Request["PID"] + "_" + DateTime.Now.Ticks.ToString() + objFile.Extension;
                    fileurl = azureDocumentUpload.UploadDocument(ConfigurationSettings.AppSettings["Project_Name"].ToLower(), sysfilename, objFileStream, flUpload.PostedFile.ContentType);
                    if (ddlCasteValidityStatus.SelectedValue == "R")
                        docid = 22;
                    else if (ddlCasteValidityStatus.SelectedValue == "A")
                        docid = 23;
                }




                if (ddlCasteValidityStatus.Text != "0")
                {
                    objReq.CandidateCasteValidityRequestStatus(PID, ddlCasteValidityStatus.SelectedValue, txtCVCApplicationNo.Text, txtAppDate.Text, txtCVCAuthority.Text, txtCVCName.Text, txtCCNumber.Text, lblCandidateName.Value, lblCandidateName.Value, fileurl, docid, ddlCVCDistrict.SelectedValue);

                    Response.Redirect("../AFCModule/frmEditRequiredDocuments.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode() + "&ApplicationID=EN18" + Request["PID"], true);
                }
                else
                {
                    shInfo.SetMessage("Please Enter Caste / Tribe Validity Certificate Status.", ShowMessageType.Information);
                }
                // BindData();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }

        }
    }
}