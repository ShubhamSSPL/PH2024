using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmEditApplicationStatus : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["UserTypeID"].ToString() != "21")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    ddlApplication.DataSource = reg.getMasterApplicationBlockStatus();
                    ddlApplication.DataTextField = "ApplicationDetails";
                    ddlApplication.DataValueField = "ApplicationName";
                    ddlApplication.DataBind();
                    ddlApplication.Items.Insert(0, new ListItem("-- Select --", "0"));
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 Status = reg.getApplicationStatus(ddlApplication.SelectedValue);

                if (Status == 1)
                {
                    rbnBlock.Checked = false;
                    rbnUnBlock.Checked = true;
                }
                else
                {
                    rbnBlock.Checked = true;
                    rbnUnBlock.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string Application = ddlApplication.SelectedValue;
                Int32 Status = 0;

                if (rbnUnBlock.Checked)
                {
                    Status = 1;
                }

                if (reg.editApplicationStatus(Application, Status, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    Global.ApplicationFormFilling = reg.getApplicationStatus("ApplicationFormFilling");
                    Global.DocumentVerification = reg.getApplicationStatus("DocumentVerification");
                    Global.EdittingOfApplicationForm = reg.getApplicationStatus("EdittingOfApplicationForm");
                    Global.ARCReporting = reg.getApplicationStatus("ARCReporting");
                    Global.InstituteCAPReporting = reg.getApplicationStatus("InstituteCAPReporting");
                    Global.InstituteReporting = reg.getApplicationStatus("InstituteReporting");
                    Global.OptionFormFillingCAPRound1 = reg.getApplicationStatus("OptionFormFillingCAPRound1");
                    Global.OptionFormFillingCAPRound2 = reg.getApplicationStatus("OptionFormFillingCAPRound2");
                    Global.OptionFormFillingCAPRound3 = reg.getApplicationStatus("OptionFormFillingCAPRound3");
                    Global.OptionFormFillingCAPRound4 = reg.getApplicationStatus("OptionFormFillingCAPRound4");
                    //Global.DisplayProvisionalMeritList = reg.getApplicationStatus("DisplayProvisionalMeritList");
                    //Global.DisplayFinalMeritList = reg.getApplicationStatus("DisplayFinalMeritList");
                    //Global.DisplayProvisionalAllotmentListCAPRound1 = reg.getApplicationStatus("DisplayProvisionalAllotmentListCAPRound1");
                    //Global.DisplayProvisionalAllotmentListCAPRound2 = reg.getApplicationStatus("DisplayProvisionalAllotmentListCAPRound2");
                    //Global.DisplayProvisionalAllotmentListCAPRound3 = reg.getApplicationStatus("DisplayProvisionalAllotmentListCAPRound3");
                    //Global.DisplayProvisionalAllotmentListCAPRound4 = reg.getApplicationStatus("DisplayProvisionalAllotmentListCAPRound4");
                    shInfo.SetMessage("Application Status Saved Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Can't Save Application Status.", ShowMessageType.Information);
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