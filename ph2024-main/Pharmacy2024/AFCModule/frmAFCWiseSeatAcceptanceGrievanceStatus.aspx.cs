using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using EntityModel;
using System.Configuration;
using Synthesys.Controls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmAFCWiseSeatAcceptanceGrievanceStatus : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        string strNavigationURL = "";
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
                    Int16 RegionID = 0;
                    string GrievanceStatusFlag = "";
                    if (Request.QueryString["RegionID"] != null)
                    {
                        RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                    }
                    else
                    {
                        RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                    }
                    if (Request.QueryString["GrievanceStatusFlag"] != null)
                    {
                        GrievanceStatusFlag = Request.QueryString["GrievanceStatusFlag"].ToString();
                    }
                    gvAFCWiseReport.DataSource = reg.GetAFCWiseSeatAcceptanceGrievanceStatus(RegionID, GrievanceStatusFlag, Global.CAPRound);
                    gvAFCWiseReport.DataBind();

                    if (GrievanceStatusFlag == "Y")
                    {
                        gvAFCWiseReport.HeaderRow.Cells[2].Text = "Total Grievances<br /> Pending for Verification";
                        ContentTable1.HeaderText = "SC Wise Seat Acceptance Grievances Pending for Verification";
                        strNavigationURL = "frmSubAFCWiseSeatAcceptanceGrievanceListForVerification.aspx";
                    }
                    else if (GrievanceStatusFlag == "P")
                    {
                        gvAFCWiseReport.HeaderRow.Cells[2].Text = "Total Grievances<br />Picked Up";
                        ContentTable1.HeaderText = "SC Wise Seat Acceptance Grievances Picked Up for Verification";
                        strNavigationURL = "frmSubAFCWiseSeatAcceptanceGrievancePickedup.aspx";
                    }
                    else if (GrievanceStatusFlag == "R")
                    {
                        gvAFCWiseReport.HeaderRow.Cells[2].Text = "Total Grievances<br /> Rejected";
                        ContentTable1.HeaderText = "SC Wise Seat Acceptance Grievances Rejected";
                        strNavigationURL = "frmSubAFCWiseSeatAcceptanceGrievanceRejected.aspx";
                    }
                    else if (GrievanceStatusFlag == "A")
                    {
                        gvAFCWiseReport.HeaderRow.Cells[2].Text = "Total Grievances<br /> Approved";
                        ContentTable1.HeaderText = "SC Wise Seat Acceptance Grievances Approved";
                        strNavigationURL = "frmSubAFCWiseSeatAcceptanceGrievanceApproved.aspx";
                    }
                    else
                    {
                        gvAFCWiseReport.HeaderRow.Cells[2].Text = "Total Grievances";
                        ContentTable1.HeaderText = "SC Wise Report";
                    }

                    Int64 TotalApplicationFormsConfirmed = 0;

                    for (Int32 i = 0; i < gvAFCWiseReport.Rows.Count; i++)
                    {
                        gvAFCWiseReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TotalApplicationFormsConfirmed += Convert.ToInt64(gvAFCWiseReport.Rows[i].Cells[2].Text);
                    }

                    HyperLink hpr = new HyperLink();
                    hpr.NavigateUrl = "frmSubAFCWiseSeatAcceptanceGrievanceListForVerification.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=99";
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

        protected void gvAFCWiseReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidRegionID = (HiddenField)e.Row.FindControl("hidRegionID");
                HiddenField hidInstituteID = (HiddenField)e.Row.FindControl("hidInstituteID");
                HiddenField hidGrievanceStatusFlag = (HiddenField)e.Row.FindControl("hidGrievanceStatusFlag");

                if (hidGrievanceStatusFlag.Value == "Y")
                {
                    gvAFCWiseReport.HeaderRow.Cells[2].Text = "Total Grievances<br /> Pending for Verification";
                    ContentTable1.HeaderText = "SC Wise Seat Acceptance Grievances Pending for Verification";
                    strNavigationURL = "frmSubAFCWiseSeatAcceptanceGrievanceListForVerification.aspx";
                }
                else if (hidGrievanceStatusFlag.Value == "P")
                {
                    strNavigationURL = "frmSubAFCWiseSeatAcceptanceGrievancePickedup.aspx";
                }
                else if (hidGrievanceStatusFlag.Value == "R")
                {
                    strNavigationURL = "frmSubAFCWiseSeatAcceptanceGrievanceRejected.aspx";
                }
                else if (hidGrievanceStatusFlag.Value == "A")
                {
                    strNavigationURL = "frmSubAFCWiseSeatAcceptanceGrievanceApproved.aspx";
                }
                else
                {
                }

                HyperLink hprLink = (HyperLink)e.Row.FindControl("hprLink");
                hprLink.NavigateUrl = strNavigationURL+ "?RegionID=" + hidRegionID.Value + "&InstituteID=" +hidInstituteID.Value+ "&GrievanceStatusFlag=" + hidGrievanceStatusFlag.Value;
            }
        }
    }
}