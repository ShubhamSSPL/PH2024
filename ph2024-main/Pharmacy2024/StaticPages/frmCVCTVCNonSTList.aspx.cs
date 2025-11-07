using BusinessLayer;
using Pharmacy2024;
using Synthesys.Controls;
using SynthesysDAL;
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
    public partial class frmCVCTVCNonSTList : System.Web.UI.Page
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
                   
                    ddlCDistrict.DataSource = reg.getMasterDistrictForState(21);
                    ddlCDistrict.DataTextField = "DistrictName";
                    ddlCDistrict.DataValueField = "DistrictID";
                    ddlCDistrict.DataBind();

                    ddlCDistrict.Items.Insert(0, new ListItem("All ", "0"));

                    dbUtility db = new dbUtility();

                    gvCVCTVCNonSTList.DataSource = db.getInstituteWiseIntakeList(ddlCDistrict.SelectedValue).Tables[0];
                    gvCVCTVCNonSTList.DataBind();
                    ContentTable1.HeaderText = "List Showing  Current Status of CVC / TVC  of Candidate in (B. PHARMACY AND PHARM. D.), (B.E. / B. Tech.), (M.E. / M. Tech) For District " + ddlCDistrict.SelectedItem + " AS ON " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToShortTimeString();
                    ContentBox1.HeaderText = "LIST SHOWING CURRENT SUMMARY OF CASTE VALIDITY CERTIFICTE CANDIDATE IN (B. PHARMACY AND PHARM. D.), (B.E. / B. TECH.), (M.E. / M. TECH) ADMISSSIONS "+ AdmissionYear + " For District " + ddlCDistrict.SelectedItem + " AS ON " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToShortTimeString();
                    Int64 BETotal = 0, PharmTotal = 0, METotal = 0;
                    Int64 BESumbmit = 0, PharmSumbmit = 0, MESumbmit = 0, BENotSumbmit = 0, PharmNotSumbmit = 0, MENotSumbmit = 0;
                    for (Int32 i = 0; i < gvCVCTVCNonSTList.Rows.Count; i++)
                    {
                        gvCVCTVCNonSTList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        gvCVCTVCNonSTList.Rows[i].Cells[13].ForeColor = System.Drawing.ColorTranslator.FromHtml("#e20e06");
                    }

                    GridView1.DataSource = db.getInstituteWiseIntakeList(ddlCDistrict.SelectedValue).Tables[1];
                    GridView1.DataBind();

                    for (Int32 i = 0; i < GridView1.Rows.Count; i++)
                    {
                        GridView1.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        BETotal += Convert.ToInt64(GridView1.Rows[i].Cells[2].Text);
                        BESumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[3].Text);
                        BENotSumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[4].Text);
                        PharmTotal += Convert.ToInt64(GridView1.Rows[i].Cells[5].Text);
                        PharmSumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[6].Text);
                        PharmNotSumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[7].Text);
                        METotal += Convert.ToInt64(GridView1.Rows[i].Cells[8].Text);
                        MESumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[9].Text);
                        MENotSumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[10].Text);
                    }
                    GridView1.FooterRow.Cells[1].Text = "Total";
                    GridView1.FooterRow.Cells[2].Text = BETotal.ToString();
                    GridView1.FooterRow.Cells[3].Text = BESumbmit.ToString();
                    GridView1.FooterRow.Cells[4].Text = BENotSumbmit.ToString();
                    GridView1.FooterRow.Cells[5].Text = PharmTotal.ToString();
                    GridView1.FooterRow.Cells[6].Text = PharmSumbmit.ToString();
                    GridView1.FooterRow.Cells[7].Text = PharmNotSumbmit.ToString();
                    GridView1.FooterRow.Cells[8].Text = METotal.ToString();
                    GridView1.FooterRow.Cells[9].Text = MESumbmit.ToString();
                    GridView1.FooterRow.Cells[10].Text = MENotSumbmit.ToString();

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    //shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
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
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Category Name";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "प्रथम वर्ष अभियांत्रिकी पदवी";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "प्रथम वर्ष औषध निर्माणशास्त्र व फार्म डी पदवी";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "प्रथम वर्ष एम.ई./एम.टेक. पदव्युत्तर पदवी";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                GridView1.Controls[0].Controls.AddAt(0, HeaderRow);

                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Students applied ";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                // Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "CVC Submitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                // Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "CVC Not Submitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Students applied ";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "CVC Submitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "CVC Not Submitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);


                Cell_Header = new TableCell();
                Cell_Header.Text = "No. of Students applied ";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "CVC Submitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "CVC Not Submitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                GridView1.Controls[0].Controls.AddAt(1, HeaderRow);
                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            }
        }
        protected void ddlCDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbUtility db = new dbUtility();

            gvCVCTVCNonSTList.DataSource = db.getInstituteWiseIntakeList(ddlCDistrict.SelectedValue).Tables[0];
            gvCVCTVCNonSTList.DataBind();
            ContentBox1.HeaderText = "LIST SHOWING CURRENT SUMMARY OF CASTE VALIDITY CERTIFICTE CANDIDATE IN (B. PHARMACY AND PHARM. D.), (B.E. / B. TECH.), (M.E. / M. TECH) ADMISSSIONS "+ AdmissionYear + " For District " + ddlCDistrict.SelectedItem + " AS ON " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToShortTimeString();
            ContentTable1.HeaderText = "List Showing  Current Status of CVC / TVC  of Candidate in (B. PHARMACY AND PHARM. D.), (B.E. / B. Tech.), (M.E. / M. Tech) For District " + ddlCDistrict.SelectedItem + " AS ON " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToShortTimeString();
            Int64 BETotal = 0, PharmTotal = 0, METotal = 0;
            Int64 BESumbmit = 0, PharmSumbmit = 0, MESumbmit = 0, BENotSumbmit = 0, PharmNotSumbmit = 0, MENotSumbmit = 0;
            for (Int32 i = 0; i < gvCVCTVCNonSTList.Rows.Count; i++)
            {
                gvCVCTVCNonSTList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                gvCVCTVCNonSTList.Rows[i].Cells[13].ForeColor = System.Drawing.ColorTranslator.FromHtml("#e20e06");
            }

            GridView1.DataSource = db.getInstituteWiseIntakeList(ddlCDistrict.SelectedValue).Tables[1];
            GridView1.DataBind();

            for (Int32 i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                BETotal += Convert.ToInt64(GridView1.Rows[i].Cells[2].Text);
                BESumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[3].Text);
                BENotSumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[4].Text);
                PharmTotal += Convert.ToInt64(GridView1.Rows[i].Cells[5].Text);
                PharmSumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[6].Text);
                PharmNotSumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[7].Text);
                METotal += Convert.ToInt64(GridView1.Rows[i].Cells[8].Text);
                MESumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[9].Text);
                MENotSumbmit += Convert.ToInt64(GridView1.Rows[i].Cells[10].Text);
            }
            GridView1.FooterRow.Cells[1].Text = "Total";
            GridView1.FooterRow.Cells[2].Text = BETotal.ToString();
            GridView1.FooterRow.Cells[3].Text = BESumbmit.ToString();
            GridView1.FooterRow.Cells[4].Text = BENotSumbmit.ToString();
            GridView1.FooterRow.Cells[5].Text = PharmTotal.ToString();
            GridView1.FooterRow.Cells[6].Text = PharmSumbmit.ToString();
            GridView1.FooterRow.Cells[7].Text = PharmNotSumbmit.ToString();
            GridView1.FooterRow.Cells[8].Text = METotal.ToString();
            GridView1.FooterRow.Cells[9].Text = MESumbmit.ToString();
            GridView1.FooterRow.Cells[10].Text = MENotSumbmit.ToString();
        }
        public class dbUtility
        {
            public DataSet getInstituteWiseIntakeList(string DistrictID)
            {
                SqlParameter[] parameters =
            {
                 new SqlParameter("@District", SqlDbType.VarChar)
            };
                parameters[0].Value = DistrictID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetCVCTVCNonSTCandidates", parameters);
                }
                finally
                {
                    db.Dispose();
                }


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
            gvCVCTVCNonSTList.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
        protected void btnexport_Click(object sender, EventArgs e)
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

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}