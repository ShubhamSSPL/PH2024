using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmChoiceCodeListHavingCourtCaseRemark : System.Web.UI.Page
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

            if (Session["UserLoginId"] != null)
            {
                this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPage.master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
            if (!IsPostBack)
            {


                DataSet dsInstitute = reg.getInstituteListHavingCourtCaseRemark();

                if (dsInstitute.Tables[0].Rows.Count > 0)
                {
                    for (Int32 i = 0; i < dsInstitute.Tables[0].Rows.Count; i++)
                    {
                        string InstituteCode = dsInstitute.Tables[0].Rows[i]["InstituteCode"].ToString();
                        string InstituteName = dsInstitute.Tables[0].Rows[i]["InstituteName"].ToString();

                        Table tblInstitute = new Table();
                        tblInstitute.CssClass = "AppFormTable";
                        tblInstitute.Width = Unit.Percentage(100);

                        TableRow trInstituteCode = new TableRow();
                        TableRow trInstituteName = new TableRow();

                        TableCell tdInstituteCode1 = new TableCell();
                        tdInstituteCode1.Width = Unit.Percentage(17);
                        tdInstituteCode1.HorizontalAlign = HorizontalAlign.Right;
                        tdInstituteCode1.Text = "Institute Code";

                        TableCell tdInstituteCode2 = new TableCell();
                        tdInstituteCode2.Width = Unit.Percentage(83);
                        tdInstituteCode2.HorizontalAlign = HorizontalAlign.Left;
                        tdInstituteCode2.Text = "<b>" + InstituteCode + "</b>";

                        TableCell tdInstituteName1 = new TableCell();
                        tdInstituteName1.Width = Unit.Percentage(20);
                        tdInstituteName1.HorizontalAlign = HorizontalAlign.Right;
                        tdInstituteName1.Text = "Institute Name";

                        TableCell tdInstituteName2 = new TableCell();
                        tdInstituteName2.Width = Unit.Percentage(80);
                        tdInstituteName2.HorizontalAlign = HorizontalAlign.Left;
                        tdInstituteName2.Text = "<b>" + InstituteName + "</b>";

                        trInstituteCode.Cells.Add(tdInstituteCode1);
                        trInstituteCode.Cells.Add(tdInstituteCode2);
                        trInstituteName.Cells.Add(tdInstituteName1);
                        trInstituteName.Cells.Add(tdInstituteName2);

                        tblInstitute.Rows.Add(trInstituteCode);
                        tblInstitute.Rows.Add(trInstituteName);

                        plcTable.Controls.Add(tblInstitute);

                        GridView gvChoiceCode = new GridView();
                        gvChoiceCode.Width = Unit.Percentage(100);
                        gvChoiceCode.CssClass = "DataGrid";
                        gvChoiceCode.AutoGenerateColumns = false;
                        gvChoiceCode.ShowFooter = false;

                        BoundField BoundFieldChoiceCode = new BoundField();

                        BoundFieldChoiceCode.HeaderStyle.CssClass = "Header";
                        BoundFieldChoiceCode.HeaderStyle.VerticalAlign = VerticalAlign.Top;
                        BoundFieldChoiceCode.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        BoundFieldChoiceCode.HeaderStyle.Font.Size = 7;
                        BoundFieldChoiceCode.HeaderStyle.Width = Unit.Percentage(12);

                        BoundFieldChoiceCode.ItemStyle.CssClass = "Item";
                        BoundFieldChoiceCode.ItemStyle.VerticalAlign = VerticalAlign.Middle;
                        BoundFieldChoiceCode.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        BoundFieldChoiceCode.ItemStyle.Font.Size = 7;

                        BoundFieldChoiceCode.DataField = "ChoiceCodeDisplay";
                        BoundFieldChoiceCode.HeaderText = "Choice Code";

                        gvChoiceCode.Columns.Add(BoundFieldChoiceCode);

                        BoundField BoundFieldCourseName = new BoundField();

                        BoundFieldCourseName.HeaderStyle.CssClass = "Header";
                        BoundFieldCourseName.HeaderStyle.VerticalAlign = VerticalAlign.Top;
                        BoundFieldCourseName.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        BoundFieldCourseName.HeaderStyle.Font.Size = 7;
                        BoundFieldCourseName.HeaderStyle.Width = Unit.Percentage(18);

                        BoundFieldCourseName.ItemStyle.CssClass = "Item";
                        BoundFieldCourseName.ItemStyle.VerticalAlign = VerticalAlign.Middle;
                        BoundFieldCourseName.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                        BoundFieldCourseName.ItemStyle.Font.Size = 7;

                        BoundFieldCourseName.DataField = "CourseName";
                        BoundFieldCourseName.HeaderText = "Course Name";

                        gvChoiceCode.Columns.Add(BoundFieldCourseName);

                        BoundField BoundFieldCourtCaseRemark = new BoundField();

                        BoundFieldCourtCaseRemark.HeaderStyle.CssClass = "Header";
                        BoundFieldCourtCaseRemark.HeaderStyle.VerticalAlign = VerticalAlign.Top;
                        BoundFieldCourtCaseRemark.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        BoundFieldCourtCaseRemark.HeaderStyle.Font.Size = 7;
                        BoundFieldCourtCaseRemark.HeaderStyle.Width = Unit.Percentage(70);

                        BoundFieldCourtCaseRemark.ItemStyle.CssClass = "Item";
                        BoundFieldCourtCaseRemark.ItemStyle.VerticalAlign = VerticalAlign.Middle;
                        BoundFieldCourtCaseRemark.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                        BoundFieldCourtCaseRemark.ItemStyle.Font.Size = 7;

                        BoundFieldCourtCaseRemark.DataField = "CourtCaseRemark";
                        BoundFieldCourtCaseRemark.HeaderText = "Remark";

                        gvChoiceCode.Columns.Add(BoundFieldCourtCaseRemark);

                        gvChoiceCode.DataSource = reg.getChoiceCodeListByInstituteHavingCourtCaseRemark(InstituteCode);
                        gvChoiceCode.DataBind();

                        plcTable.Controls.Add(gvChoiceCode);

                        plcTable.Controls.Add(new LiteralControl("<br />"));
                    }
                }
            }
        }
    }
}