using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmCompositeReportByReligion : System.Web.UI.Page
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
                    gvReport.DataSource = reg.getCompositeReportByReligion(ddlCourseType.SelectedValue);
                    gvReport.DataBind();

                    Int64 totalCAPAdmitted = 0, totalACAPAdmitted = 0, totalCAPMIAdmitted = 0, totalACAPMIAdmitted = 0, totalILAdmitted = 0, totalAdmitted = 0, totalJKAdmitted = 0, totalOthersAdmitted = 0;

                    for (Int32 m = 1; m <= gvReport.Rows.Count; m++)
                    {
                        gvReport.Rows[m - 1].Cells[0].Text = m.ToString() + ".";

                        Int64 CAPAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[2].Text);
                        Int64 ACAPAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[3].Text);
                        Int64 CAPMIAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[4].Text);
                        Int64 ACAPMIAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[5].Text);
                        Int64 ILAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[6].Text);
                        gvReport.Rows[m - 1].Cells[7].Text = (CAPAdmitted + ACAPAdmitted + CAPMIAdmitted + ACAPMIAdmitted + ILAdmitted).ToString();
                        Int64 JKAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[8].Text);
                        Int64 OthersAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[9].Text);

                        totalCAPAdmitted += CAPAdmitted;
                        totalACAPAdmitted += ACAPAdmitted;
                        totalCAPMIAdmitted += CAPMIAdmitted;
                        totalACAPMIAdmitted += ACAPMIAdmitted;
                        totalILAdmitted += ILAdmitted;
                        totalAdmitted += CAPAdmitted + ACAPAdmitted + CAPMIAdmitted + ACAPMIAdmitted + ILAdmitted;
                        totalJKAdmitted += JKAdmitted;
                        totalOthersAdmitted += OthersAdmitted;
                    }

                    gvReport.FooterRow.Cells[1].Text = "Total";
                    gvReport.FooterRow.Cells[2].Text = totalCAPAdmitted.ToString();
                    gvReport.FooterRow.Cells[3].Text = totalACAPAdmitted.ToString();
                    gvReport.FooterRow.Cells[4].Text = totalCAPMIAdmitted.ToString();
                    gvReport.FooterRow.Cells[5].Text = totalACAPMIAdmitted.ToString();
                    gvReport.FooterRow.Cells[6].Text = totalILAdmitted.ToString();
                    gvReport.FooterRow.Cells[7].Text = totalAdmitted.ToString();
                    gvReport.FooterRow.Cells[8].Text = totalJKAdmitted.ToString();
                    gvReport.FooterRow.Cells[9].Text = totalOthersAdmitted.ToString();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlCourseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                gvReport.DataSource = reg.getCompositeReportByReligion(ddlCourseType.SelectedValue);
                gvReport.DataBind();

                Int64 totalCAPAdmitted = 0, totalACAPAdmitted = 0, totalCAPMIAdmitted = 0, totalACAPMIAdmitted = 0, totalILAdmitted = 0, totalAdmitted = 0, totalJKAdmitted = 0, totalOthersAdmitted = 0;

                for (Int32 m = 1; m <= gvReport.Rows.Count; m++)
                {
                    gvReport.Rows[m - 1].Cells[0].Text = m.ToString() + ".";

                    Int64 CAPAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[2].Text);
                    Int64 ACAPAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[3].Text);
                    Int64 CAPMIAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[4].Text);
                    Int64 ACAPMIAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[5].Text);
                    Int64 ILAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[6].Text);
                    gvReport.Rows[m - 1].Cells[7].Text = (CAPAdmitted + ACAPAdmitted + CAPMIAdmitted + ACAPMIAdmitted + ILAdmitted).ToString();
                    Int64 JKAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[8].Text);
                    Int64 OthersAdmitted = Convert.ToInt64(gvReport.Rows[m - 1].Cells[9].Text);

                    totalCAPAdmitted += CAPAdmitted;
                    totalACAPAdmitted += ACAPAdmitted;
                    totalCAPMIAdmitted += CAPMIAdmitted;
                    totalACAPMIAdmitted += ACAPMIAdmitted;
                    totalILAdmitted += ILAdmitted;
                    totalAdmitted += CAPAdmitted + ACAPAdmitted + CAPMIAdmitted + ACAPMIAdmitted + ILAdmitted;
                    totalJKAdmitted += JKAdmitted;
                    totalOthersAdmitted += OthersAdmitted;
                }

                gvReport.FooterRow.Cells[1].Text = "Total";
                gvReport.FooterRow.Cells[2].Text = totalCAPAdmitted.ToString();
                gvReport.FooterRow.Cells[3].Text = totalACAPAdmitted.ToString();
                gvReport.FooterRow.Cells[4].Text = totalCAPMIAdmitted.ToString();
                gvReport.FooterRow.Cells[5].Text = totalACAPMIAdmitted.ToString();
                gvReport.FooterRow.Cells[6].Text = totalILAdmitted.ToString();
                gvReport.FooterRow.Cells[7].Text = totalAdmitted.ToString();
                gvReport.FooterRow.Cells[8].Text = totalJKAdmitted.ToString();
                gvReport.FooterRow.Cells[9].Text = totalOthersAdmitted.ToString();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}