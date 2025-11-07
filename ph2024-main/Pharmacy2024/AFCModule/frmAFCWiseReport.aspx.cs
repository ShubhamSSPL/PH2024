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
    public partial class frmAFCWiseReport : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    ddlDate.DataSource = reg.getConfirmationDateList();
                    ddlDate.DataTextField = "ConfirmedDateTime";
                    ddlDate.DataValueField = "ConfirmedDateTime";
                    ddlDate.DataBind();
                    ddlDate.Items.Insert(0, new ListItem("ALL", "ALL"));

                    string ConfirmationDate = ddlDate.SelectedValue;

                    Int16 RegionID = 0;
                    if (Request.QueryString["RegionID"] != null)
                    {
                        RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                    }
                    else
                    {
                        RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                    }

                    gvAFCWiseReport.DataSource = reg.getAFCWiseReport(RegionID, ConfirmationDate);
                    gvAFCWiseReport.DataBind();

                    Int64 TotalApplicationFormsConfirmed = 0;

                    for (Int32 i = 0; i < gvAFCWiseReport.Rows.Count; i++)
                    {
                        gvAFCWiseReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TotalApplicationFormsConfirmed += Convert.ToInt64(gvAFCWiseReport.Rows[i].Cells[2].Text);
                    }

                    HyperLink hpr = new HyperLink();
                    hpr.NavigateUrl = "frmSubAFCWiseReport.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=99";
                    hpr.Text = "<b>Total</b>";
                    if (gvAFCWiseReport.Rows.Count > 0)
                    {
                        gvAFCWiseReport.FooterRow.Cells[1].Controls.Add(hpr);
                        gvAFCWiseReport.FooterRow.Cells[2].Text = TotalApplicationFormsConfirmed.ToString();
                    }
                    lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string ConfirmationDate = ddlDate.SelectedValue;

                Int16 RegionID = 0;
                if (Request.QueryString["RegionID"] != null)
                {
                    RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                }
                else
                {
                    RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                }

                gvAFCWiseReport.DataSource = reg.getAFCWiseReport(RegionID, ConfirmationDate);
                gvAFCWiseReport.DataBind();

                Int64 TotalApplicationFormsConfirmed = 0;

                for (Int32 i = 0; i < gvAFCWiseReport.Rows.Count; i++)
                {
                    gvAFCWiseReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    TotalApplicationFormsConfirmed += Convert.ToInt64(gvAFCWiseReport.Rows[i].Cells[2].Text);
                }

                HyperLink hpr = new HyperLink();
                hpr.NavigateUrl = "frmSubAFCWiseReport.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=99";
                hpr.Text = "<b>Total</b>";
                if (gvAFCWiseReport.Rows.Count > 0)
                {
                    gvAFCWiseReport.FooterRow.Cells[1].Controls.Add(hpr);
                    gvAFCWiseReport.FooterRow.Cells[2].Text = TotalApplicationFormsConfirmed.ToString();
                }
                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}