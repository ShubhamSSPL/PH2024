using BusinessLayer;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmImportantDates : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        Int32 Flag = 0;
        Int32 FlagJK = 0;
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request.Cookies["Theme"] == null)
            {
                //Page.Theme = "default";
            }
            else
            {
                //Page.Theme = Request.Cookies["Theme"].Value;
            }

            if (Session["UserLoginID"] != null)
            {
                if (Request.QueryString["tms"] != null)
                {
                    this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.master";
                }
                else
                {
                    this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master";
                }
            }
            else
            {
                if (Request.QueryString["tms"] != null)
                {
                    this.Page.MasterPageFile = "~/MasterPages/StaticMasterPageWithOutLeftMenuSB.master";
                }
                else
                {
                    this.Page.MasterPageFile = "~/MasterPages/StaticMasterPageWithOutLeftMenuSB.master";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    if (Global.CurrentDate != DateTime.Now.ToString("dd/MM/yyyy"))
                    {
                        Global.ImportantDates = reg.getImportantDates();
                        Global.CurrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                    }

                    if (Global.ImportantDates.Tables[0].Rows.Count > 0)
                    {
                        gvImportantDatesGeneral.DataSource = Global.ImportantDates.Tables[0];
                        gvImportantDatesGeneral.DataBind();

                        //for (Int32 i = 0; i < gvImportantDatesGeneral.Rows.Count; i++)
                        //{
                        //    gvImportantDatesGeneral.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        //    if (gvImportantDatesGeneral.Rows[i].Cells[2].Text == gvImportantDatesGeneral.Rows[i].Cells[3].Text)
                        //    {
                        //        gvImportantDatesGeneral.Rows[i].Cells[2].ColumnSpan = 2;
                        //        gvImportantDatesGeneral.Rows[i].Cells.RemoveAt(3);
                        //    }
                        //}

                        for (Int32 i = 0; i < gvImportantDatesGeneral.Rows.Count; i++)
                        {
                            if (i <= 2)
                                gvImportantDatesGeneral.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            else
                                gvImportantDatesGeneral.Rows[i].Cells[0].Text = i.ToString() + ".";

                            if (i == 0)
                                gvImportantDatesGeneral.Rows[i].Cells[3].Text = gvImportantDatesGeneral.Rows[i].Cells[3].Text.Replace("21/12/2020", "21*/12/2020");
                            if (i == 1)
                                gvImportantDatesGeneral.Rows[i].Cells[3].Text = gvImportantDatesGeneral.Rows[i].Cells[3].Text.Replace("22/12/2020 Up to 5 P.M.", "22*/12/2020 Up to 5 P.M.");

                            if (i == 2)
                            {
                                gvImportantDatesGeneral.Rows[i].Cells[0].Text = gvImportantDatesGeneral.Rows[i].Cells[1].Text;
                                gvImportantDatesGeneral.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Left;

                                gvImportantDatesGeneral.Rows[i].Cells[0].ColumnSpan = 4;
                                gvImportantDatesGeneral.Rows[i].Cells.RemoveAt(1);
                                gvImportantDatesGeneral.Rows[i].Cells.RemoveAt(2);
                                gvImportantDatesGeneral.Rows[i].Cells.RemoveAt(1);

                            }

                            if (i > 2)
                            {
                                if (gvImportantDatesGeneral.Rows[i].Cells[2].Text == gvImportantDatesGeneral.Rows[i].Cells[3].Text)
                                {
                                    gvImportantDatesGeneral.Rows[i].Cells[2].ColumnSpan = 2;
                                    gvImportantDatesGeneral.Rows[i].Cells.RemoveAt(3);
                                }
                            }

                        }

                    }

                    if (Global.ImportantDates.Tables[1].Rows.Count > 0)
                    {
                        gvImportantDatesJK.DataSource = Global.ImportantDates.Tables[1];
                        gvImportantDatesJK.DataBind();

                        for (Int32 i = 0; i < gvImportantDatesJK.Rows.Count; i++)
                        {
                            gvImportantDatesJK.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                            if (gvImportantDatesJK.Rows[i].Cells[2].Text == gvImportantDatesJK.Rows[i].Cells[3].Text)
                            {
                                gvImportantDatesJK.Rows[i].Cells[2].ColumnSpan = 2;
                                gvImportantDatesJK.Rows[i].Cells.RemoveAt(3);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void gvImportantDatesGeneral_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();

                Cell_Header.Text = "Sr. No.";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 1;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Activity";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 1;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Schedule";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 2;
                Cell_Header.RowSpan = 1;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvImportantDatesGeneral.Controls[0].Controls.AddAt(0, HeaderRow);

                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                Cell_Header = new TableCell();
                Cell_Header.Text = "First Date";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Last Date";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvImportantDatesGeneral.Controls[0].Controls.AddAt(1, HeaderRow);
            }
        }
        protected void gvImportantDatesGeneral_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string ActivityStatus = (string)DataBinder.Eval(e.Row.DataItem, "ActivityStatus");
                if (ActivityStatus.Equals("N"))
                {
                    if (Flag == 0)
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#FFFF46");
                        e.Row.Font.Bold = true;
                        Flag = 1;
                    }
                }
                else if (ActivityStatus.Equals("O"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#C6F6C6");
                    e.Row.Font.Bold = true;
                }
                else if (ActivityStatus.Equals("C"))
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                }
            }
        }
        protected void gvImportantDatesJK_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();

                Cell_Header.Text = "Sr. No.";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 1;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Activity";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 1;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Schedule";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 2;
                Cell_Header.RowSpan = 1;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvImportantDatesJK.Controls[0].Controls.AddAt(0, HeaderRow);

                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                Cell_Header = new TableCell();
                Cell_Header.Text = "First Date";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Last Date";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvImportantDatesJK.Controls[0].Controls.AddAt(1, HeaderRow);
            }
        }
        protected void gvImportantDatesJK_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string ActivityStatus = (string)DataBinder.Eval(e.Row.DataItem, "ActivityStatus");
                if (ActivityStatus.Equals("N"))
                {
                    if (FlagJK == 0)
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#FFFF46");
                        e.Row.Font.Bold = true;
                        FlagJK = 1;
                    }
                }
                else if (ActivityStatus.Equals("O"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#C6F6C6");
                    e.Row.Font.Bold = true;
                }
                else if (ActivityStatus.Equals("C"))
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                }
            }
        }
    }
}