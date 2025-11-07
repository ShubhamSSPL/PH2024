using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AdminModule
{
    public partial class SMSEmailTemplate : System.Web.UI.Page
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) == 21)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (!Page.IsPostBack)
            {
                TemplateDataBind();
            }

        }
        public void TemplateDataBind()
        {
            dltemplatekey.DataSource = reg.getGetMaster_TemplateFields();
            dltemplatekey.DataBind();
            GridSmsEmailTemplate.DataSource = reg.getAllSMSEmailTemplates();
            GridSmsEmailTemplate.DataBind();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridSmsEmailTemplate.PageIndex = e.NewPageIndex;
            GridSmsEmailTemplate.DataSource = reg.getAllSMSEmailTemplates();
            GridSmsEmailTemplate.DataBind();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridSmsEmailTemplate.SelectedRow;
            Hid.Value = (row.FindControl("lbl_ID") as Label).Text;
            txtname.Text = (row.FindControl("lbl_Name") as Label).Text;

            txttemplate.Text = (row.FindControl("lbl_Template") as Label).Text;
            ddltemplateType.SelectedValue = (row.FindControl("lbl_Type") as Label).Text;
            txtSystemName.Text = (row.FindControl("lbl_SystemName") as Label).Text;
            btnsave.Text = "Update Template";

        }

        protected void btnSaveTemplateField_Click(object sender, EventArgs e)
        {
            bool result = reg.SaveMasterTemplateFiled(txtTemplateName.Text);
            txtTemplateName.Text = "";
            if (result)
                lblmessage.Visible = false;
            if (!result)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "Template Filed Name already exist!";
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            //Check the Duplicate System Name in if block
            if (reg.chkDuplicateSMSEmailTemplateSystemName(txtSystemName.Text))
            {
                if (Hid.Value != "")
                {
                    Int64 ID = Convert.ToInt64(Hid.Value);
                    reg.updateSMSEmailTemplates(ID, txtname.Text, txttemplate.Text, ddltemplateType.SelectedValue, txtSystemName.Text, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                    TemplateDataBind();
                    txtname.Text = "";
                    txttemplate.Text = "";
                    ddltemplateType.SelectedValue = "0";
                    txtSystemName.Text = "";
                }
                else
                {
                    reg.getSaveSMSEmailTemplates(txtname.Text, txttemplate.Text, ddltemplateType.SelectedValue, txtSystemName.Text, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                    TemplateDataBind();
                    txtname.Text = "";
                    txttemplate.Text = "";
                    ddltemplateType.SelectedValue = "";
                    txtSystemName.Text = "";
                }
            }
            else
            {
                lblmessage.Visible = true;
                lblmessage.Text = "Template System Name already exist!";
            }
        }
    }
}