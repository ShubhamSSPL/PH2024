using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using Synthesys.Controls;
using Synthesys.DataAcess;

namespace Pharmacy2024.StaticPages
{
    public partial class frmSeatAcceptanceAndInstituteReportingCummulativeReport : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            {
                ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                if (!IsPostBack)
                {
                    try
                    {
                        if (Session["SecretKey"] == null)
                        {
                           
                            ClientScript.RegisterStartupScript(GetType(), "id", "showSecretKey()", true);
                        }
                        else
                        {
                           // if (Session["SecreteKey"].ToString() == Application["SecretKey"].ToString())
                                LoadDashboard();
                            //else
                            //{
                              //  ClientScript.RegisterStartupScript(GetType(), "id", "showSecretKey()", true);
                            //}
                        }

                        //gvApplicationFormStatus.DataSource = reg.GetApplicationStatusReport().Tables[1];
                        //gvApplicationFormStatus.DataBind();

                        //for (Int32 i = 0; i < gvApplicationStatusReport.Rows.Count; i++)
                        //{
                        //    //if (i < 4)
                        //    //    gvApplicationStatusReport.Rows[i].BackColor = System.Drawing.Color.Green;
                        //    //if (i > 3 && i < 8)
                        //    //    gvApplicationStatusReport.Rows[i].BackColor = System.Drawing.Color.Yellow;
                        //    if (gvApplicationStatusReport.Rows[i].Cells[0].Text == "Total")
                        //    {
                        //        gvApplicationStatusReport.Rows[i].Cells[1].Text = "( " + gvApplicationStatusReport.Rows[i - 2].Cells[1].Text + " (A) + " + gvApplicationStatusReport.Rows[i - 1].Cells[1].Text + " (B) = " +
                        //            gvApplicationStatusReport.Rows[i].Cells[1].Text + " )";
                        //    }
                        //}
                        //for (Int32 i = 0; i < gvApplicationFormStatus.Rows.Count; i++)
                        //{
                        //    gvApplicationFormStatus.Rows[i].BackColor = System.Drawing.Color.LightYellow;
                        //}
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "[Page Level Error]");
                        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                    }
                }
            }
            

        }

        protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();
                 
                Cell_Header = new TableCell();
                Cell_Header.Text = "Sr. No.";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Date";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);
               
                Cell_Header = new TableCell();
                Cell_Header.Text = "Seat Acceptance";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Institute Reporting";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvAll.Controls[0].Controls.AddAt(0, HeaderRow);
                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Acceptance";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cumulative";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Reporting";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cumulative";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);
                 

                gvAll.Controls[0].Controls.AddAt(1, HeaderRow);
                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                gvAll.Controls[0].Controls.AddAt(2, HeaderRow);


            }
        }
        public void LoadDashboard()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);

            DataSet dsDashboard = new dbUtilityOptionForm().GetStatus();

            //gvApplicationStatusReportPH.DataSource = dsDashboard.Tables[0];
            //gvApplicationStatusReportPH.DataBind();

            //gvApplicationStatusReportHMCT.DataSource = dsDashboard.Tables[1];
            //gvApplicationStatusReportHMCT.DataBind();

            //gvApplicationStatusReportSCT.DataSource = dsDashboard.Tables[2];
            //gvApplicationStatusReportSCT.DataBind();

            gvAll.DataSource = dsDashboard.Tables[0];
            gvAll.DataBind();

            Int32 Count = gvAll.Rows.Count;
            if (Count == 0)
            {
                gvAll.Visible = false; 
            }
            else
            {
                Int32 j = 1;
                for (Int32 m = 0; m < Count; m++)
                {
                    gvAll.Rows[m].Cells[0].Text = j.ToString() + ".";
                    j++;
                }
            }

        }
        protected void btnSecretKey_Click(object sender, EventArgs e)
        {
            if (txtkey.Text == Application["SecretKey"].ToString())
            {
                Session["SecretKey"] = Application["SecretKey"].ToString();
                Response.Redirect("frmSeatAcceptanceAndInstituteReportingCummulativeReport");
            }
            else
            {
                lblmsg.Text = "Enter the Correct SecretKey !!";
                lblmsg.Visible = true;
                Label2.Text = "Enter the Correct SecretKey !!";
                Label2.Visible = true;
            }
        }
        public class dbUtilityOptionForm
        {
            public DataSet GetStatus()
            {
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("sp_GetSeatAcceptanceAndInstituteReportingCummulativeReport", new SqlParameter[] { });
                }
                finally
                {
                    db.Dispose();
                }

            }
        }
    }
}