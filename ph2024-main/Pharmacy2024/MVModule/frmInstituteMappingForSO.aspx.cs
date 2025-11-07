using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityModel;
using System.Data;
using System.Configuration;
using BusinessLayer;
using System.Text;
using Synthesys.Controls;

namespace Pharmacy2024.MVModule
{
    public partial class frmInstituteMappingForSO : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        private DataSet ds;
        private ShowMessage shInfo;
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    string RegionName = "";
                    if (Request.QueryString["RegionName"] != null)
                    {
                        RegionName = Request.QueryString["RegionName"].ToString();
                        //ddlCourseType.SelectedValue = Request.QueryString["Flag"].ToString();
                        // ddlTNA.SelectedValue = Request.QueryString["Flag2"].ToString();
                    }
                    else
                    {
                        RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                    }

                    //ContentTable2.HeaderText = "Institute Wise Composite Report for " + RegionName + " Region";
                    Int16 RegionID = 0;
                    RegionID = reg.getRORegionID(RegionName);

                    ddlSOSELECT.DataSource =  reg.getMVSOList(RegionID);
                    ddlSOSELECT.DataTextField =  "SOOfficerName";
                    ddlSOSELECT.DataValueField =  "SOID";
                    ddlSOSELECT.DataBind();
                    ddlSOSELECT.Items.Insert(0, "-- Select --");

                    ddlInstitute.DataSource = reg.getInstituteList(RegionID);
                    ddlInstitute.DataTextField = "InstituteName";
                    ddlInstitute.DataValueField = "InstituteCode";
                    ddlInstitute.DataBind();
                    ddlInstitute.Items.Insert(0, "-- Select --");

                    //gvReport.DataSource = reg.getInstitutelistSOMappingForRO(RegionName,'P');
                    //gvReport.DataBind();
                    refreshdata_gvassignInstbySO();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public void refreshdata_gvassignInstbySO()
        {
            string RegionName = "";
            if (Request.QueryString["RegionName"] != null)
            {
                RegionName = Request.QueryString["RegionName"].ToString();
            }
            else
            {
                RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
            }
            DataSet ds = new DataSet();
            ds = reg.getRODashboardForMV(RegionName, 'S');
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            gvassignInstbySO.DataSource = ds;
            gvassignInstbySO.DataBind();
            ViewState["dirState"] = dt;
            ViewState["sortdr"] = "Asc";

            for (Int32 i = 0; i < gvassignInstbySO.Rows.Count; i++)
            {
                gvassignInstbySO.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                if (Convert.ToInt64(gvassignInstbySO.Rows[i].Cells[9].Text) != 0)
                {
                    Label lblPending = new Label();
                    lblPending = (Label)(gvassignInstbySO.Rows[i].FindControl("lblPending"));
                    lblPending.Text = (Convert.ToInt64(gvassignInstbySO.Rows[i].Cells[8].Text) * 100 / Convert.ToInt64(gvassignInstbySO.Rows[i].Cells[9].Text)).ToString();
                }
                else
                {
                    Label lblPending = new Label();
                    lblPending = (Label)(gvassignInstbySO.Rows[i].FindControl("lblPending"));
                    lblPending.Text = "0%";
                }
            }
        }
        protected void gvassignInstbySO_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                gvassignInstbySO.DataSource = dtrslt;
                gvassignInstbySO.DataBind();

                for (Int32 i = 0; i < gvassignInstbySO.Rows.Count; i++)
                {
                    gvassignInstbySO.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    if (Convert.ToInt64(gvassignInstbySO.Rows[i].Cells[9].Text) != 0)
                    {
                        Label lblPending = new Label();
                        lblPending = (Label)(gvassignInstbySO.Rows[i].FindControl("lblPending"));
                        lblPending.Text = (Convert.ToInt64(gvassignInstbySO.Rows[i].Cells[8].Text) * 100 / Convert.ToInt64(gvassignInstbySO.Rows[i].Cells[9].Text)).ToString();
                    }
                    else
                    {
                        Label lblPending = new Label();
                        lblPending = (Label)(gvassignInstbySO.Rows[i].FindControl("lblPending"));
                        lblPending.Text = "0%";
                    }
                }
            }
        }
        protected void chkAssign_CheckChanged(object sender, EventArgs e)
        {
            Int64 newCnt = 0;
            int i;
            for (i = 0; i < gvReport.Rows.Count; i++)
            {
                CheckBox chkAssign = new CheckBox();
                chkAssign = (CheckBox)(gvReport.Rows[i].FindControl("chkAssign"));

                if (chkAssign.Checked == true)
                {
                    newCnt += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                }
            }
            lblNewAssigned.Text = newCnt.ToString();
            if(lblAssigned.Text !="" || lblAssigned.Text != null)
            {
                lblNewPending.Text = (Convert.ToInt64(lblAssigned.Text) + newCnt).ToString();
            }
            
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int InstituteId;
                Int64 ChoiceCode, ChoiceTFWS;
                Int64 SOID = Convert.ToInt64(ddlSOSELECT.SelectedValue);
                foreach (GridViewRow row in gvReport.Rows)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkAssign") as CheckBox);
                    Label lblInstituteId = (Label)row.FindControl("lblinstituteid");
                    InstituteId = Convert.ToInt32(lblInstituteId.Text);
                    Label lblChoiceCode = (Label)row.FindControl("lblChoiceCode");
                    ChoiceCode = Convert.ToInt64(lblChoiceCode.Text);
                    Label lblChoiceCodeTFWS = (Label)row.FindControl("lblChoiceCodeTFWS");
                    ChoiceTFWS = Convert.ToInt64(lblChoiceCodeTFWS.Text);
                    if (chkRow.Checked == true && chkRow != null)
                    {
                        this.ds = reg.SaveInstituteMappingforSO(SOID, InstituteId, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), ChoiceCode, ChoiceTFWS);
                        //   DataSet ds = reg.UpdateCetInstituteChoiceCodeList((Session["UserLoginID"].ToString()), InstituteId, MainCourseId, ChoiceCode, "Y");
                        //chkRow.Checked = false;

                    }

                    else
                    {

                        //shInfo.Visible = true;
                        //shInfo.SetMessage("Data is Freeze so, you Can't Approve.", ShowMessageType.Information);
                    }

                    chkRow.Checked = false;
                }
            }
            catch (DataException ex)
            {
                this.shInfo.SetMessage(ex.ToString(), ShowMessageType.TechnicalError);
            }
            finally
            {
                if (this.ds != null)
                {
                    this.ds.Dispose();
                    this.ds = (DataSet)null;
                }
                string RegionName = "";
                if (Request.QueryString["RegionName"] != null)
                {
                    RegionName = Request.QueryString["RegionName"].ToString();
                    //ddlCourseType.SelectedValue = Request.QueryString["Flag"].ToString();
                    // ddlTNA.SelectedValue = Request.QueryString["Flag2"].ToString();
                }
                else
                {
                    RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                }

                //ContentTable2.HeaderText = "Institute Wise Composite Report for " + RegionName + " Region";
                Int16 RegionID = 0;
                RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));

                ddlSOSELECT.DataSource = reg.getMVSOList(RegionID);
                ddlSOSELECT.DataTextField = "SOOfficerName";
                ddlSOSELECT.DataValueField = "SOID";
                ddlSOSELECT.DataBind();
                ddlSOSELECT.Items.Insert(0, "-- Select --");

                ddlInstitute.DataSource = reg.getInstituteList(RegionID);
                ddlInstitute.DataTextField = "InstituteName";
                ddlInstitute.DataValueField = "InstituteCode";
                ddlInstitute.DataBind();
                ddlInstitute.Items.Insert(0, "-- Select --");
                DataSet ds = null;
                gvReport.DataSource = ds;
                gvReport.DataBind();
                gvassignInstbySO.DataSource = reg.getRODashboardForMV(RegionName, 'S');
                gvassignInstbySO.DataBind();
                lblAssigned.Text = "";
                lblNewAssigned.Text = "";
                lblNewPending.Text = "";
                lblPending.Text = "";
                lblSOProfile.Text = "";
                //gvReport.DataSource = reg.getInstitutelistSOMappingForRO(RegionName, 'P');
                //gvReport.DataBind();               
            }           
        }
        protected void gvReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReport.PageIndex = e.NewPageIndex;
            //string  RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
            string RegionName = ddlInstitute.SelectedValue.ToString();
            gvReport.DataSource = reg.getInstitutelistSOMappingForRO(RegionName,'P');
            gvReport.DataBind();
            //Search(e.NewPageIndex + 1);
        }
        protected void ddlSOSELECT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                if (ddlSOSELECT.SelectedIndex != 0)
                {
                    Int64 SOID = Convert.ToInt64(ddlSOSELECT.SelectedValue);
                    MVSOProfile obj = reg.getMVSOProfile(SOID);
                    lblSOProfile.Text = "Designation: " + obj.Designation + ", Mobile No.: " + obj.SOMobile + ", Email: " + obj.Email;


                    DataSet dsmvload = reg.getMVSOLoad(SOID);
                    // char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                    //  DataSet dsCheckDocumentUploaded = reg.getRequiredDocumentsUploadStatusReportForCandidate(PID);
                    if (dsmvload.Tables[0].Rows.Count > 0)
                    {
                        lblAssigned.Text = Convert.ToString(dsmvload.Tables[0].Rows[0]["NoOfCandidates"]);
                        lblPending.Text = Convert.ToString(dsmvload.Tables[0].Rows[0]["CandidatesNotVerified"]);
                    }
                    else
                    {
                        lblAssigned.Text = "";
                        lblPending.Text = "";
                    }
                }
                else
                {
                    lblSOProfile.Text = "";
                }
                
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                if (ddlInstitute.SelectedIndex != 0)
                {
                    //string RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                    string RegionName = ddlInstitute.SelectedValue.ToString();
                    gvReport.DataSource = reg.getInstitutelistSOMappingForRO(RegionName, 'P');
                    gvReport.DataBind();
                }
                else
                {
                    
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
