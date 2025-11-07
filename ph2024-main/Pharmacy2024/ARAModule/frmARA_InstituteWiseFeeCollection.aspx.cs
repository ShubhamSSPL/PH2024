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
    public partial class frmARA_InstituteWiseFeeCollection : System.Web.UI.Page
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
                    string RegionName = "";
                    if (Request.QueryString["RegionName"] != null)
                    {
                        RegionName = Request.QueryString["RegionName"].ToString();
                        //ddlCourseType.SelectedValue = Request.QueryString["Flag"].ToString();
                    }
                    else
                    {
                        RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                    }

                    ContentTable2.HeaderText = "Institute wise Fee Collection List for " + RegionName + " Region";

                    gvReport.DataSource = reg.getInstitutewiseAdmissionApprovalFeePaidDetails(RegionName, "ALL");
                    gvReport.DataBind();

                    Decimal FeeToBePaid = 0;
                    Decimal FeePaid = 0;
                    Decimal BalanceFee = 0;


                    for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                    {
                        gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        //HyperLink hpr = new HyperLink();
                        //hpr.NavigateUrl = "frmInstitute_ChoiceCodeList.aspx?InstituteCode=" + gvReport.Rows[i].Cells[1].Text + "&Flag=" + ddlCourseType.SelectedValue;
                        //hpr.Text = gvReport.Rows[i].Cells[1].Text;
                        //gvReport.Rows[i].Cells[1].Controls.Add(hpr);

                        FeeToBePaid += Convert.ToDecimal(gvReport.Rows[i].Cells[3].Text);
                        FeePaid += Convert.ToDecimal(gvReport.Rows[i].Cells[4].Text);
                        BalanceFee += Convert.ToDecimal(gvReport.Rows[i].Cells[5].Text); 
                    }

                    gvReport.FooterRow.Cells[2].Text = "Total";
                    gvReport.FooterRow.Cells[3].Text = FeeToBePaid.ToString();

                    gvReport.FooterRow.Cells[4].Text = FeePaid.ToString();
                    gvReport.FooterRow.Cells[5].Text = BalanceFee.ToString(); 
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        //protected void ddlCourseType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
        //    try
        //    {
        //        string RegionName = "";
        //        if (Request.QueryString["RegionName"] != null)
        //        {
        //            RegionName = Request.QueryString["RegionName"].ToString();
        //        }
        //        else
        //        {
        //            RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
        //        }

        //        ContentTable2.HeaderText = "Institute List for " + RegionName + " Region";

        //        gvReport.DataSource = reg.getARADashBoardForRO(RegionName, ddlCourseType.SelectedValue);
        //        gvReport.DataBind();

        //        Int64 CAPAdmitted = 0;
        //        Int64 InstApproved = 0, InstRejected = 0, PendingAtInst = 0;
        //        Int64 ROApproved = 0, RORejected = 0, PendingAtRO = 0;
        //        Int64 ARAApproved = 0, ARARejected = 0, PendingAtARA = 0;

        //        for (Int32 i = 0; i < gvReport.Rows.Count; i++)
        //        {
        //            gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

        //            HyperLink hpr = new HyperLink();
        //            hpr.NavigateUrl = "frmInstitute_ChoiceCodeList.aspx?InstituteCode=" + gvReport.Rows[i].Cells[1].Text + "&Flag=" + ddlCourseType.SelectedValue;
        //            hpr.Text = gvReport.Rows[i].Cells[1].Text;
        //            gvReport.Rows[i].Cells[1].Controls.Add(hpr);

        //            CAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[3].Text);

        //            InstApproved += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
        //            InstRejected += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
        //            PendingAtInst += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);

        //            ROApproved += Convert.ToInt64(gvReport.Rows[i].Cells[7].Text);
        //            RORejected += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
        //            PendingAtRO += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);

        //            ARAApproved += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
        //            ARARejected += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
        //            PendingAtARA += Convert.ToInt64(gvReport.Rows[i].Cells[12].Text);
        //        }

        //        gvReport.FooterRow.Cells[2].Text = "Total";
        //        gvReport.FooterRow.Cells[3].Text = CAPAdmitted.ToString();

        //        gvReport.FooterRow.Cells[4].Text = InstApproved.ToString();
        //        gvReport.FooterRow.Cells[5].Text = InstRejected.ToString();
        //        gvReport.FooterRow.Cells[6].Text = PendingAtInst.ToString();

        //        gvReport.FooterRow.Cells[7].Text = ROApproved.ToString();
        //        gvReport.FooterRow.Cells[8].Text = RORejected.ToString();
        //        gvReport.FooterRow.Cells[9].Text = PendingAtRO.ToString();

        //        gvReport.FooterRow.Cells[10].Text = ARAApproved.ToString();
        //        gvReport.FooterRow.Cells[11].Text = ARARejected.ToString();
        //        gvReport.FooterRow.Cells[12].Text = PendingAtARA.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logging.LogException(ex, "[Page Level Error]");
        //        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
        //    }
        //}
        //protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        GridView HeaderGrid = (GridView)sender;
        //        GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //        TableCell Cell_Header = new TableCell();

        //        Cell_Header.Text = "Sr. No.";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Institute Code";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Institute Name";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Admitted";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Institute Verification Status";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.ColumnSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "RO Verification Status";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.ColumnSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "ARA Verification Status";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.ColumnSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        gvReport.Controls[0].Controls.AddAt(0, HeaderRow);
        //        HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Approved";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 2;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Rejected";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 2;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Pending";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 2;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Approved";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 2;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Rejected";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 2;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Pending";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 2;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Approved";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 2;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Rejected";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 2;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Pending";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        Cell_Header.RowSpan = 2;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        gvReport.Controls[0].Controls.AddAt(1, HeaderRow);

        //        HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                

        //        gvReport.Controls[0].Controls.AddAt(2, HeaderRow);

                
        //    }
        //}
        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=InstituteWiseFeeCollectionReport.xls";
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