using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityModel;
using System.Data;
using System.Configuration;
using BusinessLayer;
using System.Text;
using Synthesys.Controls;
using System.Collections;

namespace Pharmacy2024.MVModule
{
    public partial class frmMLVCertificate : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        private DataSet ds;
        private ShowMessage shInfo;
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
            Int64 TIntake = 0, TAdm = 0, TAcc = 0;
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
           // ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                int  InstCode = 0;
                if (Request.QueryString["InstituteCode"] != null)
                {
                    InstCode = Convert.ToInt32( Request.QueryString["InstituteCode"].ToString());
                    string InstituteName = reg.getInstituteName(Request.QueryString["InstituteCode"].ToString());
                    string Remark = reg.getCertificateRemarks(Request.QueryString["InstituteCode"].ToString(), 'D');
                    string usr = reg.getCertificateRemarks(Request.QueryString["InstituteCode"].ToString(), 'U');
                    string place = reg.getCertificateRemarks(Request.QueryString["InstituteCode"].ToString(), 'P');
                    string date = reg.getCertificateRemarks(Request.QueryString["InstituteCode"].ToString(), 'T');
                    string date2 = reg.getCertificateRemarks(Request.QueryString["InstituteCode"].ToString(), 'F');
                    lblInstCode.Text = Convert.ToString(InstCode);
                    lblInstName.Text = InstituteName;
                    lblUsr.Text = usr;
                    lblPlace.Text = place;
                    lblDt.Text = date;
                    if (date2 == "NULL")
                    {
                        lblDTEDate.Text = "";
                    }
                    else
                    {
                        lblDTEDate.Text = date2;
                    }
                    if (Remark == "NULL")
                    {
                        txtRemarks.Text = "";
                    }
                    else
                    {
                        txtRemarks.Text = Remark;
                    }
                }
                else
                {
                    //InstCode = 3253;
                }

                gvReport.DataSource = reg.getMLVCertificate(InstCode);
                gvReport.DataBind();
                if (gvReport.Rows.Count > 0)
                {
                    TIntake = 0;
                    TAdm = 0;
                    TAcc = 0;
                    for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                    {
                        //gvDashboardFE.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TIntake += Convert.ToInt64(gvReport.Rows[i].Cells[2].Text);
                        TAdm += Convert.ToInt64(gvReport.Rows[i].Cells[3].Text);
                        TAcc += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                    }
                    gvReport.FooterRow.Cells[1].Text = "Total";
                    gvReport.FooterRow.Cells[2].Text = TIntake.ToString();
                    gvReport.FooterRow.Cells[3].Text = TAdm.ToString();
                    gvReport.FooterRow.Cells[4].Text = TAcc.ToString();
                }
                    ShowingGroupingDataInGridView(gvReport.Rows, 0, 3);
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
    }
}
