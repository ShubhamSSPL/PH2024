using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using Synthesys.DataAcess;
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

namespace Pharmacy2024.MVModule
{
    public partial class frmMLVProposal : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
            if (!IsPostBack)
            {
                ddlProposal.Items.Add("Yes");
                ddlProposal.Items.Add("No");
            }            
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int InstCode = Convert.ToInt32(txtInstCode.Text.ToString());
            string InstituteName = reg.getInstituteName(Convert.ToString(InstCode));            
            lblInstName.Text = InstituteName;
            hlViewDetails.NavigateUrl = "frmAllotedChoiceCodeList.aspx?InstituteCode=" + InstCode;
            DataSet ds = new DataSet();
            ds = reg.getVerifiedByInst(InstCode, 'D');
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                lblDTEStatus.Text = "Yes";
            }
            else
            {
                lblDTEStatus.Text = "No";
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProposalDate.Text != "")
                {
                    string CreatedBy = Session["UserLoginID"].ToString();
                    string CreatedByIPAddress = UserInfo.GetIPAddress();
                    string strProposalDate = txtProposalDate.Text.Split("/".ToCharArray())[1] + "/" + txtProposalDate.Text.Split("/".ToCharArray())[0] + "/" + txtProposalDate.Text.Split("/".ToCharArray())[2];

                    if (txtInstCode.Text != "" && lblInstName.Text != "")
                    {
                        string InstCD = txtInstCode.Text.ToString();
                        string Status = ddlProposal.SelectedValue.ToString();
                        reg.saveProposalStatus(InstCD, Status, CreatedBy, CreatedByIPAddress, Convert.ToDateTime(strProposalDate));
                        string Msg = "Physical proposal submission status for Institute: " + InstCD + " - " + lblInstName.Text + " is saved as " + Status + ".";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + "Physical proposal submission status saved.');", true);
                        clear();
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + "Please select institute.');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + "Please select proposal submission date.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Error saving Records.');", true);
            }
        }        
        public void clear()
        {
            txtInstCode.Text = "";
            lblInstName.Text = "";
            txtProposalDate.Text = "";
            ddlProposal.SelectedIndex = 0;
        }
    }
}