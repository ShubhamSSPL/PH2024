using BusinessLayer;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmStatisticCandidatesappliedbasisofReceipt : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
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
            //if (Session["UserLoginID"] == null)
            //{
            //    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            //}
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    // dbUtility reg = new dbUtility();
                    gvReport.DataSource = reg.getCVCNCLEWSReciptStatistic();
                    gvReport.DataBind();
                    //lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                    Int64 NoofCandidatesinFinalMeritList = 0, SubmittedbyCandidateandVerifiedbySCCVC = 0, SubmittedbyCandidatesandnotVerifiedbySCCVC = 0, NotsubmittedbycandidatesCVC = 0,
                        TotalCVC = 0;
                    Int64 SubmittedbyCandidateandVerifiedbySCNCL = 0, SubmittedbyCandidatesandnotVerifiedbySCNCL = 0, NotsubmittedbycandidatesNCL = 0, TotalNCL = 0  ;
                    Int64 SubmittedbyCandidateandVerifiedbySCEWS = 0, SubmittedbyCandidatesandnotVerifiedbySCEWS = 0, NotsubmittedbycandidatesEWS = 0, TotalEWS = 0            ;
                 

                    for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                    {
                        gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        //HyperLink hpr = new HyperLink();
                        //hpr.NavigateUrl = "frmCompositeReportForRO.aspx?RegionName=" + gvReport.Rows[i].Cells[1].Text + "&Flag=" + ddlCourseType.SelectedValue;
                        //hpr.Text = gvReport.Rows[i].Cells[1].Text;
                        //gvReport.Rows[i].Cells[1].Controls.Add(hpr);

                        NoofCandidatesinFinalMeritList += Convert.ToInt64(gvReport.Rows[i].Cells[2].Text);                       
                        SubmittedbyCandidateandVerifiedbySCCVC += Convert.ToInt64(gvReport.Rows[i].Cells[3].Text);
                        SubmittedbyCandidatesandnotVerifiedbySCCVC += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                        TotalCVC += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                        NotsubmittedbycandidatesCVC += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);
                        //ACAPAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);
                        //ACAPAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                        SubmittedbyCandidateandVerifiedbySCNCL += Convert.ToInt64(gvReport.Rows[i].Cells[7].Text);
                        SubmittedbyCandidatesandnotVerifiedbySCNCL += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                        NotsubmittedbycandidatesNCL += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);
                        TotalNCL += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                        //CAPMIAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[15].Text);
                        //CAPMIAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[16].Text);
                        SubmittedbyCandidateandVerifiedbySCEWS += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
                        SubmittedbyCandidatesandnotVerifiedbySCEWS += Convert.ToInt64(gvReport.Rows[i].Cells[12].Text);
                        NotsubmittedbycandidatesEWS += Convert.ToInt64(gvReport.Rows[i].Cells[13].Text);
                        TotalEWS += Convert.ToInt64(gvReport.Rows[i].Cells[14].Text);
                       
                    }

                    gvReport.FooterRow.Cells[1].Text = "Total";
                    gvReport.FooterRow.Cells[2].Text = NoofCandidatesinFinalMeritList.ToString();
                    //gvReport.FooterRow.Cells[3].Text = CAPAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[4].Text = CAPAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[3].Text = SubmittedbyCandidateandVerifiedbySCCVC.ToString();
                    gvReport.FooterRow.Cells[4].Text = SubmittedbyCandidatesandnotVerifiedbySCCVC.ToString();
                    gvReport.FooterRow.Cells[5].Text = TotalCVC.ToString();
                    gvReport.FooterRow.Cells[6].Text = NotsubmittedbycandidatesCVC.ToString();
                    //gvReport.FooterRow.Cells[9].Text = ACAPAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[10].Text = ACAPAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[7].Text = SubmittedbyCandidateandVerifiedbySCNCL.ToString();
                    gvReport.FooterRow.Cells[8].Text = SubmittedbyCandidatesandnotVerifiedbySCNCL.ToString();
                    gvReport.FooterRow.Cells[9].Text = NotsubmittedbycandidatesNCL.ToString();
                    gvReport.FooterRow.Cells[10].Text = TotalNCL.ToString();
                    //gvReport.FooterRow.Cells[15].Text = CAPMIAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[16].Text = CAPMIAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[11].Text = SubmittedbyCandidateandVerifiedbySCEWS.ToString();
                    gvReport.FooterRow.Cells[12].Text = SubmittedbyCandidatesandnotVerifiedbySCEWS.ToString();
                    gvReport.FooterRow.Cells[13].Text = NotsubmittedbycandidatesEWS.ToString();
                    gvReport.FooterRow.Cells[14].Text = TotalEWS.ToString();
                  
                 
                }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
        protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();

                Cell_Header.Text = "Sr. No. <br /> 1";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Category <br /> 2";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);
                Cell_Header = new TableCell();

                Cell_Header.Text = "No of Candidates in Final Merit List <br /> 3";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);




                //Cell_Header = new TableCell();
                //Cell_Header.Text = "No of Candidates in Final Merit List";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.ColumnSpan = 4;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Submitted Receipt for Caste/ Tribe Validity";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Submitted Receipt for NCL";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Submitted Receipt for EWS";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);
                gvReport.Controls[0].Controls.AddAt(0, HeaderRow);

                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Submitted  by Candidate and Verified by SC  <br /> 4";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.ColumnSpan = 3;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Submitted by Candidates and not Verified by SC  <br /> 5";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Not submitted by candidates <br /> 6";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Total <br /> 7 ( 4 + 5 + 6)";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Submitted  by Candidate and Verified by SC  <br /> 8";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.ColumnSpan = 3;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Submitted by Candidates and not Verified by SC  <br /> 9";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Not submitted by candidates <br /> 10";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Total <br /> 11 ( 8 + 9 + 10)";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Submitted  by Candidate and Verified by SC  <br /> 12";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.ColumnSpan = 3;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Submitted by Candidates and not Verified by SC  <br /> 13";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Not submitted by candidates <br />14";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Total <br /> 15 ( 12 +13 + 14)";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);            




                gvReport.Controls[0].Controls.AddAt(1, HeaderRow);

                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

               
                gvReport.Controls[0].Controls.AddAt(2, HeaderRow);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Submitted  by Candidate and Verified by SC";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 1;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                ////Cell_Header = new TableCell();
                ////Cell_Header.Text = "Admitted";
                ////Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                ////Cell_Header.ColumnSpan = 3;
                ////Cell_Header.CssClass = "Header";
                ////Cell_Header.Wrap = false;
                ////HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Submitted by Candidates and not Verified by SC";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 1;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Not submitted by candidates";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 1;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Total";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 1;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);
            }
        }
        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            //string attachment = "attachment; filename=CandidateStatisticReport.xls";
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", attachment);
            //Response.ContentType = "application/ms-excel";
            //StringWriter stw = new StringWriter();
            //HtmlTextWriter htextw = new HtmlTextWriter(stw);
            //gvReport.RenderControl(htextw);
            //Response.Write(stw.ToString());
            //Response.End();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=StatisticCandidatesappliedbasisofReceipt.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            divexport.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void gvReport_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        public class dbUtility
    {
        public DataSet getCVCNCLEWSReciptStatistic()
        {
            DBConnection db = new DBConnection();
            try
            {
                return (db.ExecuteDataSet("[MHDTE_spGetCVCNCLEWSReciptStatistic]", new SqlParameter[]
                {

                }));
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
}