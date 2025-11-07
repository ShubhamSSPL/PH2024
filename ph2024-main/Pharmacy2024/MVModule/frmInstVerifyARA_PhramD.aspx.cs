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
using System.IO;

namespace Pharmacy2024.MVModule
{
    public partial class frmInstVerifyARA_PhramD : System.Web.UI.Page
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
                fillGrid();
            }
        }
        public void fillGrid()
        {
            //string RegionName = "";
            //RegionName = Request.QueryString["RegionName"].ToString();
            gvExcel.DataSource = reg.ARAReportforMV("I");
            gvExcel.DataBind();
            gvReport.DataSource = reg.ARAReportforMV("I");
            gvReport.DataBind();
            if (gvReport.Rows.Count == 0)
            {
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('No Institute pending for RO verification or No institute verified by SO.');", true);
                lblMsg.Text = "Institutes not found for pending for ARA verification.";
                btnSubmit.Visible = false;
                btnSubmit.Enabled = false;
            }
        }
        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            gvExcel.Visible = true;
            string attachment = "attachment; filename=CompositeReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvExcel.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
            gvExcel.Visible = false;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 InstCode;
                string CreatedBy = Session["UserLoginID"].ToString();
                string CreatedIPAddress = UserInfo.GetIPAddress();
                string strARADate = "";
                if (txtApprovalDate.Text != "")
                {
                    strARADate = txtApprovalDate.Text.Split("/".ToCharArray())[1] + "/" + txtApprovalDate.Text.Split("/".ToCharArray())[0] + "/" + txtApprovalDate.Text.Split("/".ToCharArray())[2];


                    int i = 0, n = 0, cnt = 0;

                    for (n = 0; n < gvReport.Rows.Count; n++)
                    {
                        CheckBox chkVerify = new CheckBox();
                        chkVerify = (CheckBox)(gvReport.Rows[n].FindControl("chkVerify"));

                        if (chkVerify.Checked == true)
                        {
                            cnt++;
                        }
                    }
                    if (cnt != 0)
                    {
                        for (i = 0; i < gvReport.Rows.Count; i++)
                        {
                            CheckBox chkVerify = new CheckBox();
                            chkVerify = (CheckBox)(gvReport.Rows[i].FindControl("chkVerify"));

                            if (chkVerify.Checked == true)
                            {
                                Label lbl = new Label();
                                lbl = (Label)(gvReport.Rows[i].FindControl("lblInstCode"));
                                InstCode = Convert.ToInt64(lbl.Text);

                                reg.saveInstituteVarificationARA(InstCode, 'Y', CreatedBy, CreatedIPAddress, Convert.ToDateTime(strARADate));
                            }
                        }
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Record Saved.');", true);
                        fillGrid();
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please select institute to verify.');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please select ARA Approval Date.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Error saving Records.');", true);
            }
        }
    }
}