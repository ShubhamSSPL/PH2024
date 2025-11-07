using BusinessLayer;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmApplicationFees : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {


                    ddlCandidatureType.DataSource = Global.MasterCandidatureType;
                    ddlCandidatureType.DataTextField = "CandidatureTypeName";
                    ddlCandidatureType.DataValueField = "CandidatureTypeID";
                    ddlCandidatureType.DataBind();
                    ddlCandidatureType.Items.Insert(0, new ListItem("-- Select Candidature Type --", "0"));

                    ddlCategory.DataSource = Global.MasterCategory;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));

                    ddlPHType.DataSource = Global.MasterPHType;
                    ddlPHType.DataTextField = "PHTypeDetails";
                    ddlPHType.DataValueField = "PHTypeID";
                    ddlPHType.DataBind();

                    cbDisplayApplicationFee.Visible = false;

                    onPageLoad();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlCandidatureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 CandidatureTypeID = Convert.ToInt32(ddlCandidatureType.SelectedValue);
                Int32 CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);

                if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4)
                {
                    trCategory.Visible = true;
                    trPH.Visible = true;
                    if (CategoryID == 1)
                        trAppliedForEWS2.Visible = true;
                    else
                        trAppliedForEWS2.Visible = false;
                }
                else
                {
                    trCategory.Visible = false;
                    trPH.Visible = false;
                    trAppliedForEWS2.Visible = false;
                }

                ddlCategory.SelectedIndex = 0;
                ddlPHType.SelectedIndex = 0;
                ddlAppliedForEWS.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void onPageLoad()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                Int32 CandidatureTypeID = Convert.ToInt32(ddlCandidatureType.SelectedValue);
                Int32 CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);

                if (CandidatureTypeID == 1 || CandidatureTypeID == 2 || CandidatureTypeID == 3 || CandidatureTypeID == 4)
                {
                    trCategory.Visible = true;
                    trPH.Visible = true;
                    if (CategoryID == 1)
                        trAppliedForEWS2.Visible = true;
                    else
                        trAppliedForEWS2.Visible = false;

                }
                else
                {
                    trCategory.Visible = false;
                    trPH.Visible = false;
                    trAppliedForEWS2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            cbCalculateApplicationFee.Visible = true;
            cbDisplayApplicationFee.Visible = false;
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            Int32 CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);

            if (CategoryID == 1)
                trAppliedForEWS2.Visible = true;
            else
                trAppliedForEWS2.Visible = false;

            ddlAppliedForEWS.SelectedIndex = 0;
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {


                cbCalculateApplicationFee.Visible = false;
                cbDisplayApplicationFee.Visible = true;

                Int32 CandidatureTypeID = Convert.ToInt32(ddlCandidatureType.SelectedValue);
                Int32 CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                Int32 PHTypeID = Convert.ToInt32(ddlPHType.SelectedValue);
                string isEWS = ddlAppliedForEWS.SelectedValue.ToString();

                Int32 ApplicationFee = reg.getApplicationFeeDetails(CandidatureTypeID, CategoryID, PHTypeID, isEWS);

                lblCandidatureType.Text = ddlCandidatureType.SelectedItem.Text;
                if (CategoryID > 0)
                {
                    lblCategory.Text = ddlCategory.SelectedItem.Text;
                    if (CategoryID == 1)
                        lblCategory.Text += " (Belong to EWS : " + isEWS + ")";
                }
                else
                {
                    lblCategory.Text = "Not Applicable";
                }
                lblPHType.Text = ddlPHType.SelectedItem.Text;
                lblApplicationFee.Text = ApplicationFee.ToString() + "/-";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}
