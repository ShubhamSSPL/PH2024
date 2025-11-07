using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmControlActivityStatus : System.Web.UI.Page
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
            if (Session["UserTypeID"].ToString() != "21")
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    onPageLoad();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void onPageLoad()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                gvActivityStatusList.DataSource = reg.getActivityStatusList();
                gvActivityStatusList.DataBind();

                for (Int32 i = 0; i < gvActivityStatusList.Rows.Count; i++)
                {
                    gvActivityStatusList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    if (!string.IsNullOrEmpty(gvActivityStatusList.Rows[i].Cells[2].Text) && gvActivityStatusList.Rows[i].Cells[2].Text != "&nbsp;")
                    {
                        DateTime ActivityStartDateTime = Convert.ToDateTime(gvActivityStatusList.Rows[i].Cells[2].Text);
                        gvActivityStatusList.Rows[i].Cells[2].Text = ActivityStartDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ActivityStartDateTime);
                    }
                    if (!string.IsNullOrEmpty(gvActivityStatusList.Rows[i].Cells[3].Text) && gvActivityStatusList.Rows[i].Cells[3].Text != "&nbsp;")
                    {
                        DateTime ActivityEndDateTime = Convert.ToDateTime(gvActivityStatusList.Rows[i].Cells[3].Text);
                        gvActivityStatusList.Rows[i].Cells[3].Text = ActivityEndDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ActivityEndDateTime);
                    }
                }

                cbActivityStatusDetails.Visible = false;

                lblActivity.Text = "";
                txtActivityStartDateTime.Text = "";
                txtActivityEndDateTime.Text = "";
                hdnActivityName.Value = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                IFormatProvider culture = new CultureInfo("en-US", true);
                string ActivityName = hdnActivityName.Value;
                DateTime? ActivityStartDateTime = null;
                if (txtActivityStartDateTime.Text.Length > 0)
                {
                    ActivityStartDateTime = DateTime.ParseExact(txtActivityStartDateTime.Text, "dd/MM/yyyy HH:mm", culture);
                }
                DateTime? ActivityEndDateTime = null;
                if (txtActivityEndDateTime.Text.Length > 0)
                {
                    ActivityEndDateTime = DateTime.ParseExact(txtActivityEndDateTime.Text, "dd/MM/yyyy HH:mm", culture);
                }
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                if (reg.saveActivityStatusDetails(ActivityName, ActivityStartDateTime, ActivityEndDateTime, ModifiedBy, ModifiedByIPAddress))
                {
                    Global g = new Global();
                    g.setGlobalVariables();

                    onPageLoad();

                    shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                onPageLoad();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvActivityStatusList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string ActivityName = ((Label)gvActivityStatusList.Rows[e.NewSelectedIndex].FindControl("lblActivityName")).Text;
                DataSet ds = reg.getActivityStatusDetails(ActivityName);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbActivityStatusDetails.Visible = true;

                    hdnActivityName.Value = ActivityName;

                    lblActivity.Text = ds.Tables[0].Rows[0]["ActivityDetails"].ToString();

                    //DateTime ActivityStartDateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
                    //txtActivityStartDateTime.Text = ActivityStartDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ActivityStartDateTime);
                    //DateTime ActivitySEndDateTimes = Convert.ToDateTime(ds.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());
                    //txtActivityEndDateTime.Text = ActivitySEndDateTimes.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ActivitySEndDateTimes);

                    txtActivityStartDateTime.Text = ds.Tables[0].Rows[0]["ActivityStartDateTime"].ToString();
                    txtActivityEndDateTime.Text = ds.Tables[0].Rows[0]["ActivityEndDateTime"].ToString();
                }
                else
                {
                    cbActivityStatusDetails.Visible = false;
                    shInfo.SetMessage("No Record Found.", ShowMessageType.Information);
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