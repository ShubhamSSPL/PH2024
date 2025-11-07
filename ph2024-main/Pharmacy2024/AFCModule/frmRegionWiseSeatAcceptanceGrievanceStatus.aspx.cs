using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BusinessLayer;
using Synthesys.Controls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmRegionWiseSeatAcceptanceGrievanceStatus : System.Web.UI.Page
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
                    string GrievanceStatusFlag = "";
                    if (Request.QueryString["GrievanceStatusFlag"] != null)
                    {
                        GrievanceStatusFlag = Request.QueryString["GrievanceStatusFlag"].ToString();
                    }
                    

                    gvRegionWiseReport.DataSource = reg.GetRegionWiseSeatAcceptanceGrievanceStatus(GrievanceStatusFlag, Global.CAPRound);
                    gvRegionWiseReport.DataBind();

                    if (GrievanceStatusFlag == "Y")
                    {
                        gvRegionWiseReport.HeaderRow.Cells[2].Text = "Total Grievances<br /> Pending for Verification";
                        ContentTable1.HeaderText = "Region Wise Seat Acceptance Grievances Pending for Verification";
                    }
                    else if (GrievanceStatusFlag == "P")
                    {
                        gvRegionWiseReport.HeaderRow.Cells[2].Text = "Total Grievances<br />Picked Up";
                        ContentTable1.HeaderText = "Region Wise Seat Acceptance Grievances Picked Up for Verification";
                    }
                    else if (GrievanceStatusFlag == "R")
                    {
                        gvRegionWiseReport.HeaderRow.Cells[2].Text = "Total Grievances<br /> Rejected";
                        ContentTable1.HeaderText = "Region Wise Seat Acceptance Grievances Rejected";
                    }
                    else if (GrievanceStatusFlag == "A")
                    {
                        gvRegionWiseReport.HeaderRow.Cells[2].Text = "Total Grievances<br /> Approved";
                        ContentTable1.HeaderText = "Region Wise Seat Acceptance Grievances Approved";
                    }
                    else
                    {
                        gvRegionWiseReport.HeaderRow.Cells[2].Text = "Total Grievances";
                        ContentTable1.HeaderText = "Region Wise Report";
                    }

                    Int64 TotalApplicationFormsConfirmed = 0;

                    for (Int32 i = 0; i < gvRegionWiseReport.Rows.Count; i++)
                    {
                        gvRegionWiseReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TotalApplicationFormsConfirmed += Convert.ToInt64(gvRegionWiseReport.Rows[i].Cells[2].Text);
                    }

                    HyperLink hpr = new HyperLink();
                    hpr.NavigateUrl = "frmAFCWiseSeatAcceptanceGrievanceStatus.aspx?RegionID=99";
                    hpr.Text = "<b>Total</b>";
                    gvRegionWiseReport.FooterRow.Cells[1].Controls.Add(hpr);
                    gvRegionWiseReport.FooterRow.Cells[2].Text = TotalApplicationFormsConfirmed.ToString();
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
}