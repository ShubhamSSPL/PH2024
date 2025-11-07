using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BusinessLayer;
using System.Text;
using Synthesys.Controls;
using System.Collections;

namespace Pharmacy2024.ARAModule
{
    public partial class frmPrintARAApprovalLetterInst : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        private DataSet ds;
        private ShowMessage shInfo;
        public string AdmissionYear = Global.AdmissionYear;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            // ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                int InstCode = 0;
                DataSet ds;
                if (Request.QueryString["InstituteCode"] != null)
                {
                    InstCode = Convert.ToInt32(Request.QueryString["InstituteCode"].ToString());
                    string InstituteName = reg.getInstituteName(Request.QueryString["InstituteCode"].ToString());
                    ds = reg.ARAVerificationDate(InstCode);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblProposalDt.Text = Convert.ToString(ds.Tables[0].Rows[0].Field<string>(1));
                        lblAprovalDt1.Text = Convert.ToString(ds.Tables[0].Rows[0].Field<string>(2));
                        lblAprovalDt2.Text = Convert.ToString(ds.Tables[0].Rows[0].Field<string>(2));
                        lblAprovalDt3.Text = Convert.ToString(ds.Tables[0].Rows[0].Field<string>(2));
                        lblUniversity.Text = Convert.ToString(ds.Tables[1].Rows[0].Field<string>(1));
                    }
                    lblInstCode.Text = Convert.ToString(InstCode);
                    lblInstCode1.Text = Convert.ToString(InstCode);
                    lblInstCode2.Text = Convert.ToString(InstCode);
                    lblinstName.Text = InstituteName;
                    lblInstName1.Text = InstituteName;
                    lblIntake.Text = Request.QueryString["TIn"].ToString();
                    lblTAdm.Text = Request.QueryString["TAdm"].ToString();
                    lblAAdm.Text = Request.QueryString["AAdm"].ToString();
                    lblRAdm.Text = Request.QueryString["RAdm"].ToString();
                    lblCAdm.Text = Request.QueryString["CAdm"].ToString();

                    string course = Request.QueryString["Course"].ToString();
                    if (course == "B")
                    {
                        lblCourse.Text = "B.Pharmacy";
                        gvReport.DataSource = reg.CandidateApprovalReport(InstCode, "B");
                        gvReport.DataBind();
                    }

                    if (course == "D")
                    {
                        lblCourse.Text = "Post Graduate Pharm.D";
                        gvReport.DataSource = reg.CandidateApprovalReport(InstCode, "D");
                        gvReport.DataBind();
                    }

                    DataSet dsPenalty;
                    dsPenalty = reg.CheckARAPenaltyStatus(InstCode);
                    if (dsPenalty.Tables[0].Rows.Count > 0)
                    {
                        lblPenalty.Visible = true;
                    }
                    else
                    {
                        lblPenalty.Visible = false;
                    }

                    gvReport.DataSource = reg.CandidateApprovalReport(InstCode);
                    gvReport.DataBind();
                    //Response.Redirect("frmAllotedCCLDTE.aspx?InstituteCode=" + InstCode, true);
                    //Response.Write("<script>");
                    //Response.Write("window.open('/MVModule/CandidateApprovalStatus.aspx?InstituteCode=" + InstCode + "' ,'_blank')");
                    //Response.Write("</script>");
                }
            }
        }
        void ShowingGroupingDataInGridView(GridViewRowCollection gridViewRows, int startIndex, int totalColumns)
        {
            if (totalColumns == 0) return;
            int i, count = 1;
            ArrayList lst = new ArrayList();
            lst.Add(gridViewRows[0]);
            var ctrl = gridViewRows[0].Cells[startIndex];
            for (i = 1; i < gridViewRows.Count; i++)
            {
                TableCell nextTbCell = gridViewRows[i].Cells[startIndex];
                if (ctrl.Text == nextTbCell.Text)
                {
                    count++;
                    nextTbCell.Visible = false;
                    lst.Add(gridViewRows[i]);
                }
                else
                {
                    if (count > 1)
                    {
                        ctrl.RowSpan = count;
                        ShowingGroupingDataInGridView(new GridViewRowCollection(lst), startIndex + 1, totalColumns - 1);
                    }
                    count = 1;
                    lst.Clear();
                    ctrl = gridViewRows[i].Cells[startIndex];
                    lst.Add(gridViewRows[i]);
                }
            }
            if (count > 1)
            {
                ctrl.RowSpan = count;
                ShowingGroupingDataInGridView(new GridViewRowCollection(lst), startIndex + 1, totalColumns - 1);
            }
            count = 1;
            lst.Clear();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.FindControl("lblRowNumber") as Label).Text = (e.Row.RowIndex + 1).ToString();
            }
        }
    }
}