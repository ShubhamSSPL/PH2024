using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.MVModule
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
            if (Session["SecretKey"] == null && ConfigurationManager.AppSettings["IsARATestKeyRequired"] == "Y")
            {
                ClientScript.RegisterStartupScript(GetType(), "id", "showSecretKey()", true);
            }
            else
            {
                if (!IsPostBack)
                {
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


                        gvReport.DataSource = reg.getARADashBoardForInstitute(InstituteCode, "");
                        gvReport.DataBind();

                        Int64 CAPAdmitted = 0;

                        for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                        {
                            gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                            CAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                        }

                        gvReport.FooterRow.Cells[3].Text = "Total";
                        gvReport.FooterRow.Cells[4].Text = CAPAdmitted.ToString();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "[Page Level Error]");
                        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                    }
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
               
                gvReport.DataSource = reg.getARADashBoardForInstitute(InstituteCode, "");
                gvReport.DataBind();

                Int64 CAPAdmitted = 0;
               

                for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                {
                    gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    CAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);

                }

                gvReport.FooterRow.Cells[3].Text = "Total";
                gvReport.FooterRow.Cells[4].Text = CAPAdmitted.ToString();

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        //protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        GridView HeaderGrid = (GridView)sender;
        //        GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //        TableCell Cell_Header = new TableCell();

        //        Cell_Header.Text = "Sr. No.";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        //Cell_Header.RowSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        //Cell_Header = new TableCell();
        //        //Cell_Header.Text = "Choice Code";
        //        //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        ////Cell_Header.RowSpan = 3;
        //        //Cell_Header.CssClass = "Header";
        //        //Cell_Header.Wrap = false;
        //        //HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Course Name";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        //Cell_Header.RowSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Admitted";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        //Cell_Header.RowSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Print Candidate List";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        //Cell_Header.RowSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        Cell_Header = new TableCell();
        //        Cell_Header.Text = "Submit Candidate List";
        //        Cell_Header.HorizontalAlign = HorizontalAlign.Center;
        //        //Cell_Header.RowSpan = 3;
        //        Cell_Header.CssClass = "Header";
        //        Cell_Header.Wrap = false;
        //        HeaderRow.Cells.Add(Cell_Header);

        //        gvReport.Controls[0].Controls.AddAt(0, HeaderRow);
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
            gvReport.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblVerified = (e.Row.FindControl("lblVerified") as Label);
                
                string Verified = (e.Row.FindControl("lblVerified") as Label).Text;

                //  LinkButton lbtn = (LinkButton)(GridView1.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("linkBtnName"));

                //Change the Color of LnkBtn Blue to Red


                // lbtn.ForeColor = "RED"
               // HyperLink hl = (HyperLink)e.Row.Cells[3].Controls[0];     //suppose the second column is HyperLinkField
               // hl.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.color='red';");
               // hl.Attributes.Add("onmouseout", "this.style.color='';");
                if (Verified == "Y")
                {
                    HyperLink hl = (HyperLink)e.Row.Cells[6].Controls[0];     //suppose the second column is HyperLinkField
                   // hl.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.color='red'; this.style.tooltip ='snehdeep'");
                   // hl.Attributes.Add("onmouseout", "this.style.color='';");
                   // e.Row.BackColor = System.Drawing.Color.LightGray;
                    hl.ForeColor = System.Drawing.Color.LightGray;
                    hl.Text = "Submitted";
                    hl.ToolTip = "Already Submitted";
                    // hl.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                   
                    HyperLink hl = (HyperLink)e.Row.Cells[6].Controls[0];     //suppose the second column is HyperLinkField
                   // hl.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.color='green'; this.style.tooltip ='snehdeep'");
                   // hl.Attributes.Add("onmouseout", "this.style.color='';");
                    hl.ForeColor= System.Drawing.Color.Green;
                    hl.ToolTip = "Please click here for Submit";
                }

            }
        }

        protected void btnSecretKey_Click(object sender, EventArgs e)
        {
            if (txtkey.Text == Application["SecretKey"].ToString())
            {
                Session["SecretKey"] = Application["SecretKey"].ToString();
                Response.Redirect("../MVModule/frmInstitute_ChoiceCodeList");
            }
            else
            {
                lblmsg.Text = "Enter the Correct SecretKey!!";
                lblmsg.Visible = true;
                //Response.Redirect(ConfigurationManager.AppSettings["ApplicationURL"]);
            }
        }
    }
}