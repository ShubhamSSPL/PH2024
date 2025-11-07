using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace Pharmacy2024.StaticPages
{
    public partial class frmConsolatedAlladmissionCvcTvcReport : System.Web.UI.Page
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
            
            DataSet dsDashboard = reg.GetCvcTvcReport();

            ContentTable1.HeaderText = "First Year B.E. / B. Tech  : Statistics of Candidates who have submitted Receipt of CVC/TVC at Scrutiny Center " + DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
            ContentBoxPH.HeaderText = "First Year B.Pharmacy. / Pharm. D.   : Statistics of Candidates who have submitted Receipt of CVC/TVC at Scrutiny Center " + DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
            gvReportEN.DataSource = dsDashboard.Tables[0];
            gvReportEN.DataBind();

            gvReportPH.DataSource = dsDashboard.Tables[1];
            gvReportPH.DataBind();
            {
                //decimal AdmissionCategory = dsDashboard.Tables[0].AsEnumerable().Sum(row => row.Field<int>("AdmissionCategory"));
                decimal FinalMeritTotal = dsDashboard.Tables[0].AsEnumerable().Sum(row => row.Field<int>("FinalMeritTotal"));
                decimal AllotedSum_IN_CAP1 = dsDashboard.Tables[0].AsEnumerable().Sum(row => row.Field<int>("AllotedSum_IN_CAP1"));
                decimal Alloted_NotSubInCAP1 = dsDashboard.Tables[0].AsEnumerable().Sum(row => row.Field<int>("Alloted_NotSubInCAP1"));
                decimal NOAllot_Submitted = dsDashboard.Tables[0].AsEnumerable().Sum(row => row.Field<int>("NOAllot_Submitted"));
                decimal NOAllot_NotSubmitted = dsDashboard.Tables[0].AsEnumerable().Sum(row => row.Field<int>("NOAllot_NotSubmitted"));
                decimal ConvertToOpen = dsDashboard.Tables[0].AsEnumerable().Sum(row => row.Field<int>("ConvertToOpen"));
                decimal NotEligible = dsDashboard.Tables[0].AsEnumerable().Sum(row => row.Field<int>("NotEligible"));
                //decimal IntakApproved = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("IntakApproved"));
                //decimal IntakPartialPending = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("IntakPartialPending"));
                //decimal IntakPending = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("IntakPending"));
                gvReportEN.FooterRow.Cells[0].Text = "Total";
                gvReportEN.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                // gvReport.FooterRow.Cells[1].Text = AdmissionCategory.ToString();
                gvReportEN.FooterRow.Cells[2].Text = FinalMeritTotal.ToString();
                gvReportEN.FooterRow.Cells[3].Text = AllotedSum_IN_CAP1.ToString();
                gvReportEN.FooterRow.Cells[4].Text = Alloted_NotSubInCAP1.ToString();
                gvReportEN.FooterRow.Cells[5].Text = NOAllot_Submitted.ToString();
                gvReportEN.FooterRow.Cells[6].Text = NOAllot_NotSubmitted.ToString();
                gvReportEN.FooterRow.Cells[7].Text = ConvertToOpen.ToString();
                gvReportEN.FooterRow.Cells[8].Text = NotEligible.ToString();
                //gvReport.FooterRow.Cells[8].Text = IntakApproved.ToString();
                //gvReport.FooterRow.Cells[9].Text = IntakPartialPending.ToString();
                //gvReport.FooterRow.Cells[10].Text = IntakPending.ToString();
                gvReportEN.FooterStyle.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            }


            {

                //decimal AdmissionCategory = dsDashboard.Tables[0].AsEnumerable().Sum(row => row.Field<int>("AdmissionCategory"));
                decimal FinalMeritTotal = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("FinalMeritTotal"));
                decimal AllotedSum_IN_CAP1 = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("AllotedSum_IN_CAP1"));
                decimal Alloted_NotSubInCAP1 = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("Alloted_NotSubInCAP1"));
                decimal NOAllot_Submitted = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("NOAllot_Submitted"));
                decimal NOAllot_NotSubmitted = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("NOAllot_NotSubmitted"));
                decimal ConvertToOpen = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("ConvertToOpen"));
                decimal NotEligible = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("NotEligible"));

                //decimal IntakApproved = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("IntakApproved"));
                //decimal IntakPartialPending = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("IntakPartialPending"));
                //decimal IntakPending = dsDashboard.Tables[1].AsEnumerable().Sum(row => row.Field<int>("IntakPending"));
                gvReportPH.FooterRow.Cells[0].Text = "Total";
                gvReportPH.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                // gvReport.FooterRow.Cells[1].Text = AdmissionCategory.ToString();
                gvReportPH.FooterRow.Cells[2].Text = FinalMeritTotal.ToString();
                gvReportPH.FooterRow.Cells[3].Text = AllotedSum_IN_CAP1.ToString();
                gvReportPH.FooterRow.Cells[4].Text = Alloted_NotSubInCAP1.ToString();
                gvReportPH.FooterRow.Cells[5].Text = NOAllot_Submitted.ToString();
                gvReportPH.FooterRow.Cells[6].Text = NOAllot_NotSubmitted.ToString();
                gvReportPH.FooterRow.Cells[7].Text = ConvertToOpen.ToString();
                gvReportPH.FooterRow.Cells[8].Text = NotEligible.ToString();
                //gvReport.FooterRow.Cells[8].Text = IntakApproved.ToString();
                //gvReport.FooterRow.Cells[9].Text = IntakPartialPending.ToString();
                //gvReport.FooterRow.Cells[10].Text = IntakPending.ToString();
                gvReportPH.FooterStyle.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            }

        }

        protected void gvReportEN_DataBound(object sender, EventArgs e)
        {

            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "";

            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Text = "Allotment in CAP 1";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Text = "No Allotment in CAP 1";
            row.Controls.Add(cell);
            //cell = new TableHeaderCell();
            //cell.ColumnSpan = 3;
            //cell.Text = "No Of Intake For admissions";


            row.BackColor = ColorTranslator.FromHtml("#fff");
            row.Controls.Add(cell);
            gvReportEN.HeaderRow.Parent.Controls.AddAt(0, row);
        }
        protected void gvReportPH_DataBound(object sender, EventArgs e)
        {

            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "";

            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Text = "Allotment in CAP 1";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Text = "No Allotment in CAP 1";
            row.Controls.Add(cell);
            //cell = new TableHeaderCell();
            //cell.ColumnSpan = 3;
            //cell.Text = "No Of Intake For admissions";


            row.BackColor = ColorTranslator.FromHtml("#fff");
            row.Controls.Add(cell);
            gvReportPH.HeaderRow.Parent.Controls.AddAt(0, row);
        }
    }
}