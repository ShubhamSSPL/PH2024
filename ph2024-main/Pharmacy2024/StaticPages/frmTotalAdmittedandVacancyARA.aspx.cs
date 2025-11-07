using Pharmacy2024;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmTotalAdmittedandVacancyARA : System.Web.UI.Page
    {
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
                try
                {

                    // dbUtility db = new dbUtility();


                    ContentBox1.HeaderText = "LIST SHOWING CURRENT SUMMARY (General) OF (B. PHARMACY AND PHARM. D.), (B.E. / B. TECH.), (M.E. / M. TECH) , (POSTHSC Diploma) ADMISSSIONS "+ AdmissionYear + " AS ON " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToShortTimeString();
                    ContentTable1.HeaderText = "LIST SHOWING CURRENT SUMMARY (TFWS) OF (B. PHARMACY AND PHARM. D.), (B.E. / B. TECH.), (M.E. / M. TECH) , (POSTHSC Diploma) ADMISSSIONS "+ AdmissionYear + " AS ON " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToShortTimeString();
                    // Int64 CAPVacancy = 0, CAPAdmitted = 0, CAPCancelled = 0, CAP = 0 ;


                    GridView1.DataSource = getInstituteWiseIntakeList().Tables[0];
                    GridView1.DataBind();
                    GridView2.DataSource = getInstituteWiseIntakeListTFWS().Tables[0];
                    GridView2.DataBind();



                    //for (Int32 i = 0; i < GridView1.Rows.Count; i++)
                    //{
                    //    CAPAdmitted += Convert.ToInt64(GridView1.Rows[i].Cells[2].Text);
                    //    CAPCancelled += Convert.ToInt64(GridView1.Rows[i].Cells[3].Text);
                    //    CAPVacancy += Convert.ToInt64(GridView1.Rows[i].Cells[4].Text);
                    //    CAP += Convert.ToInt64(GridView1.Rows[i].Cells[5].Text);
                    //    GridView1.Rows[i].Cells[6].Text = (System.Math.Round(((Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text) / Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text)) * 100), 2)).ToString() + " %";
                    //}
                    //GridView1.FooterRow.Cells[1].Text = "Total";
                    //GridView1.FooterRow.Cells[2].Text = CAPAdmitted.ToString();
                    //GridView1.FooterRow.Cells[3].Text = CAPCancelled.ToString();
                    //GridView1.FooterRow.Cells[4].Text = CAPVacancy.ToString();
                    //GridView1.FooterRow.Cells[5].Text = CAP.ToString();
                    //GridView1.FooterRow.Cells[6].Text = (System.Math.Round(((Convert.ToDecimal(CAP) / Convert.ToDecimal(CAPCancelled)) * 100), 2)).ToString() + " %";

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                }
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();

                Cell_Header.Text = "Sr. No.";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.White;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "COURSE  LEVEL";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.White;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "GOVERNMENT";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.OrangeRed;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "GOVERNMENT AIDED";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.OrangeRed;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "UNIVERSITY DEPARTMENT / MANAGED";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.OrangeRed;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "UNAIDED";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.OrangeRed;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "TOTAL";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.OrangeRed;
                HeaderRow.Cells.Add(Cell_Header);

                GridView1.Controls[0].Controls.AddAt(0, HeaderRow);

                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Institutes";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);


                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Institutes";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Institutes";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Institutes";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Institutes";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);


                GridView1.Controls[0].Controls.AddAt(1, HeaderRow);
                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            }
        }
        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();

                Cell_Header.Text = "Sr. No.";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.White;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "COURSE  LEVEL";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.White;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "GOVERNMENT";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.OrangeRed;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "GOVERNMENT AIDED";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.OrangeRed;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "UNIVERSITY DEPARTMENT / MANAGED";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.OrangeRed;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "UNAIDED";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.OrangeRed;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "TOTAL";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                //Cell_Header.BackColor = System.Drawing.Color.OrangeRed;
                HeaderRow.Cells.Add(Cell_Header);

                GridView2.Controls[0].Controls.AddAt(0, HeaderRow);

                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Institutes";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);


                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Institutes";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Institutes";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Institutes";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Institutes";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = true;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);


                GridView2.Controls[0].Controls.AddAt(1, HeaderRow);
                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            }
        }

        //public class dbUtility : MKCL.Common.DBUtility
        //{
        //    public DataSet getInstituteWiseIntakeList()
        //    {
        //        SqlParameter[] parameters = 
        //        { 
        //             //new SqlParameter("@District", SqlDbType.VarChar)
        //        };
        //       // parameters[0].Value = DistrictID;
        //        return (ExecProcedure("MHDTE_spGetAllAdmisionReport", parameters, "0"));
        //    }
        //}
        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=CompositeReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            GridView1.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }

        protected void btnExporttoExcel2_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=CompositeReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            GridView2.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }


        public DataSet getInstituteWiseIntakeList()
        {
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetAllAdmisionReport", new SqlParameter[]
                 {

                 });
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataSet getInstituteWiseIntakeListTFWS()
        {
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetAllAdmisionReportTFWS", new SqlParameter[]
                {

                });
            }
            finally
            {
                db.Dispose();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}