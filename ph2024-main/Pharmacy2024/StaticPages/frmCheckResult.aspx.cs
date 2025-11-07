using BusinessLayer;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmCheckResult : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string CurrentYear = Global.CurrentYear;
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

            if (Session["UserLoginID"] != null)
            {
                if (Request.QueryString["tms"] != null)
                {
                    this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageWithOutLeftMenu.master";
                }
                else
                {
                    this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPage.master";
                }
            }
            else
            {
                if (Request.QueryString["tms"] != null)
                {
                    this.Page.MasterPageFile = "~/MasterPages/StaticMasterPageWithOutLeftMenu.master";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cbCheckResult.Visible = true;
                cbDisplayResult.Visible = false;
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
               
                Int64 ApplicationID = Convert.ToInt64(txtRegistrationNo.Text);
                DataSet ds = reg.getResult(ApplicationID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbCheckResult.Visible = false;
                    cbDisplayResult.Visible = true;

                    lblApplicationID.Text = ds.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblSeatNo.Text = ds.Tables[0].Rows[0]["SeatNo"].ToString();
                    lblCandidateName.Text = ds.Tables[0].Rows[0]["CandidateName"].ToString().ToUpper();
                    lblCETScore.Text = ds.Tables[0].Rows[0]["CETScore"].ToString();
                    lblCETPercentile.Text = ds.Tables[0].Rows[0]["CETPercentile"].ToString();
                }
                else
                {
                    cbCheckResult.Visible = true;
                    cbDisplayResult.Visible = false;

                    shInfo.SetMessage("Invalid Application ID OR Roll Number OR You have not Appeared for MAH-MBA/MMS-CET." + CurrentYear, ShowMessageType.Information);
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