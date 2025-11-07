using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ARAModule
{
    public partial class frmInstitute_ChoiceCodeList : System.Web.UI.Page
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
                    string InstituteCode = "";
                    if (Request.QueryString["InstituteCode"] != null)
                    {
                        InstituteCode = Request.QueryString["InstituteCode"].ToString();
                        ddlCourseType.SelectedValue = Request.QueryString["Flag"].ToString();
                    }
                    else
                    {
                        InstituteCode = Session["UserLoginID"].ToString();
                    }

                    ContentTable2.HeaderText = "Choice Code List for " + reg.getInstituteName(InstituteCode);

                    gvReport.DataSource = reg.getARADashBoardForInstitute(InstituteCode, ddlCourseType.SelectedValue);
                    gvReport.DataBind();

                    //Int64 CAPIntake = 0, CAPAdmittedBefore = 0, CAPAdmittedAfter = 0, CAPAdmitted = 0, CAPCancelled = 0, CAPVacancy = 0;
                    //Int64 ACAPIntake = 0, ACAPAdmittedBefore = 0, ACAPAdmittedAfter = 0, ACAPAdmitted = 0, ACAPCancelled = 0, ACAPVacancy = 0;
                    //Int64 CAPMIIntake = 0, CAPMIAdmittedBefore = 0, CAPMIAdmittedAfter = 0, CAPMIAdmitted = 0, CAPMICancelled = 0, CAPMIVacancy = 0;
                    //Int64 ACAPMIIntake = 0, ACAPMIAdmittedBefore = 0, ACAPMIAdmittedAfter = 0, ACAPMIAdmitted = 0, ACAPMICancelled = 0, ACAPMIVacancy = 0;
                    //Int64 ILIntake = 0, ILAdmittedBefore = 0, ILAdmittedAfter = 0, ILAdmitted = 0, ILCancelled = 0, ILVacancy = 0;
                    //Int64 TotalIntake = 0, TotalAdmittedBefore = 0, TotalAdmittedAfter = 0, TotalAdmitted = 0, TotalCancelled = 0, TotalVacancy = 0;
                    //Int64 JKIntake = 0, JKAdmittedBefore = 0, JKAdmittedAfter = 0, JKAdmitted = 0, JKCancelled = 0, JKVacancy = 0;
                    //Int64 OAAAdmittedBefore = 0, OAAAdmittedAfter = 0, OAAAdmitted = 0, OAACancelled = 0;
                    //Int64 TotalEWSIntake = 0, TotalEWSAdmittedBefore = 0, TotalEWSAdmittedAfter = 0, TotalEWSAdmitted = 0, TotalEWSCancelled = 0, TotalEWSVacancy = 0;

                    Int64 CAPAdmitted = 0;
                    Int64 InstApproved = 0, InstRejected = 0, PendingAtInst = 0;
                    Int64 ROApproved = 0, RORejected = 0, PendingAtRO = 0;
                    Int64 ARAApproved = 0, ARARejected = 0, PendingAtARA = 0;


                    for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                    {
                        gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        CAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[3].Text);

                        InstApproved += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                        InstRejected += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                        PendingAtInst += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);

                        ROApproved += Convert.ToInt64(gvReport.Rows[i].Cells[7].Text);
                        RORejected += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                        PendingAtRO += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);

                        ARAApproved += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                        ARARejected += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
                        PendingAtARA += Convert.ToInt64(gvReport.Rows[i].Cells[12].Text);
                        
                    }

                    gvReport.FooterRow.Cells[2].Text = "Total";
                    gvReport.FooterRow.Cells[3].Text = CAPAdmitted.ToString();

                    gvReport.FooterRow.Cells[4].Text = InstApproved.ToString();
                    gvReport.FooterRow.Cells[5].Text = InstRejected.ToString();
                    gvReport.FooterRow.Cells[6].Text = PendingAtInst.ToString();

                    gvReport.FooterRow.Cells[7].Text = ROApproved.ToString();
                    gvReport.FooterRow.Cells[8].Text = RORejected.ToString();
                    gvReport.FooterRow.Cells[9].Text = PendingAtRO.ToString();

                    gvReport.FooterRow.Cells[10].Text = ARAApproved.ToString();
                    gvReport.FooterRow.Cells[11].Text = ARARejected.ToString();
                    gvReport.FooterRow.Cells[12].Text = PendingAtARA.ToString();

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
                string InstituteCode = "";
                if (Request.QueryString["InstituteCode"] != null)
                {
                    InstituteCode = Request.QueryString["InstituteCode"].ToString();
                }
                else
                {
                    InstituteCode = Session["UserLoginID"].ToString();
                }

                ContentTable2.HeaderText = "Choice Code List for " + reg.getInstituteName(InstituteCode);

                gvReport.DataSource = reg.getARADashBoardForInstitute(InstituteCode, ddlCourseType.SelectedValue);
                gvReport.DataBind();

                //Int64 CAPIntake = 0, CAPAdmittedBefore = 0, CAPAdmittedAfter = 0, CAPAdmitted = 0, CAPCancelled = 0, CAPVacancy = 0;
                //Int64 ACAPIntake = 0, ACAPAdmittedBefore = 0, ACAPAdmittedAfter = 0, ACAPAdmitted = 0, ACAPCancelled = 0, ACAPVacancy = 0;
                //Int64 CAPMIIntake = 0, CAPMIAdmittedBefore = 0, CAPMIAdmittedAfter = 0, CAPMIAdmitted = 0, CAPMICancelled = 0, CAPMIVacancy = 0;
                //Int64 ACAPMIIntake = 0, ACAPMIAdmittedBefore = 0, ACAPMIAdmittedAfter = 0, ACAPMIAdmitted = 0, ACAPMICancelled = 0, ACAPMIVacancy = 0;
                //Int64 ILIntake = 0, ILAdmittedBefore = 0, ILAdmittedAfter = 0, ILAdmitted = 0, ILCancelled = 0, ILVacancy = 0;
                //Int64 TotalIntake = 0, TotalAdmittedBefore = 0, TotalAdmittedAfter = 0, TotalAdmitted = 0, TotalCancelled = 0, TotalVacancy = 0;
                //Int64 JKIntake = 0, JKAdmittedBefore = 0, JKAdmittedAfter = 0, JKAdmitted = 0, JKCancelled = 0, JKVacancy = 0;
                //Int64 OAAAdmittedBefore = 0, OAAAdmittedAfter = 0, OAAAdmitted = 0, OAACancelled = 0;
                //Int64 TotalEWSIntake = 0, TotalEWSAdmittedBefore = 0, TotalEWSAdmittedAfter = 0, TotalEWSAdmitted = 0, TotalEWSCancelled = 0, TotalEWSVacancy = 0;

                Int64 CAPAdmitted = 0;
                Int64 InstApproved = 0, InstRejected = 0, PendingAtInst = 0;
                Int64 ROApproved = 0, RORejected = 0, PendingAtRO = 0;
                Int64 ARAApproved = 0, ARARejected = 0, PendingAtARA = 0;

                for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                {
                    gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    CAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[3].Text);

                    InstApproved += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                    InstRejected += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                    PendingAtInst += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);

                    ROApproved += Convert.ToInt64(gvReport.Rows[i].Cells[7].Text);
                    RORejected += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                    PendingAtRO += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);

                    ARAApproved += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                    ARARejected += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
                    PendingAtARA += Convert.ToInt64(gvReport.Rows[i].Cells[12].Text);
                }

                gvReport.FooterRow.Cells[2].Text = "Total";
                gvReport.FooterRow.Cells[3].Text = CAPAdmitted.ToString();

                gvReport.FooterRow.Cells[4].Text = InstApproved.ToString();
                gvReport.FooterRow.Cells[5].Text = InstRejected.ToString();
                gvReport.FooterRow.Cells[6].Text = PendingAtInst.ToString();

                gvReport.FooterRow.Cells[7].Text = ROApproved.ToString();
                gvReport.FooterRow.Cells[8].Text = RORejected.ToString();
                gvReport.FooterRow.Cells[9].Text = PendingAtRO.ToString();

                gvReport.FooterRow.Cells[10].Text = ARAApproved.ToString();
                gvReport.FooterRow.Cells[11].Text = ARARejected.ToString();
                gvReport.FooterRow.Cells[12].Text = PendingAtARA.ToString();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();

                Cell_Header.Text = "Sr. No.";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Choice Code";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Course Name";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Institute Verification Status";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "RO Verification Status";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "ARA Verification Status";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvReport.Controls[0].Controls.AddAt(0, HeaderRow);
                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Approved";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Rejected";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Pending";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Approved";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Rejected";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Pending";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Approved";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Rejected";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Pending";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvReport.Controls[0].Controls.AddAt(1, HeaderRow);

                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

               

                gvReport.Controls[0].Controls.AddAt(2, HeaderRow);

                
            }
        }
        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=CompositeReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvReport.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}