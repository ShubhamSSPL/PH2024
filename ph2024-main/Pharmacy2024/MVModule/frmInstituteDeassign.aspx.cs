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
    public partial class frmInstituteDeassign : System.Web.UI.Page
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
                    }
                    else
                    {
                        RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                    }

                    Int16 RegionID = 0;
                    RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));

                    ddlSOSELECT.DataSource = reg.getMVSOList(RegionID);
                    ddlSOSELECT.DataTextField = "SOOfficerName";
                    ddlSOSELECT.DataValueField = "SOID";
                    ddlSOSELECT.DataBind();

                    ddlSOSELECT.Items.Insert(0, "-- Select --");
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
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
                    gvReport.DataSource = reg.getInstitutelistSOMappingForRO(SOID.ToString(), 'D');
                    gvReport.DataBind();
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int InstituteId;
                string InstCode;
                Int64 SOID = Convert.ToInt64(ddlSOSELECT.SelectedValue);
                foreach (GridViewRow row in gvReport.Rows)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkAssign") as CheckBox);
                    Label lblInstituteId = (Label)row.FindControl("lblinstituteid");
                    InstituteId = Convert.ToInt32(lblInstituteId.Text);
                    InstCode = lblInstituteId.Text;
                    if (chkRow.Checked == true && chkRow != null)
                    {                        
                        DataSet ds = new DataSet();
                        ds = reg.getCandidateVerifiedBySO(SOID, InstCode);
                        DataTable dt = new DataTable();
                        dt = ds.Tables[0];

                        if (dt.Rows.Count > 0)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('SO has already worked on selected institute's merit list.');", true);
                        }
                        else
                        {
                            this.ds = reg.UpdateInstituteMappingforSO(SOID, InstituteId, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Institute Deassigned.');", true);
                        }                           
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please select institute to deassign.');", true);
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
                }
                else
                {
                    RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                }
                Int16 RegionID = 0;
                RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));

                ddlSOSELECT.DataSource = reg.getMVSOList(RegionID);
                ddlSOSELECT.DataTextField = "SOOfficerName";
                ddlSOSELECT.DataValueField = "SOID";
                ddlSOSELECT.DataBind();

                ddlSOSELECT.Items.Insert(0, "-- Select --");                
                gvReport.DataSource = null;
                gvReport.DataBind();

            }
        }

    }
}