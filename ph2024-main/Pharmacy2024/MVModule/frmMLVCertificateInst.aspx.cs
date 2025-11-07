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
    public partial class frmMLVCertificateInst : System.Web.UI.Page
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
                Int64 InstCode = Convert.ToInt64(Session["UserLoginID"].ToString());
                DataSet ds = new DataSet();
                ds = reg.getVerifiedByInst(InstCode, 'D');
                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    frmCertificate.Visible = true;                    
                    string InstituteName = reg.getInstituteName(InstCode.ToString());
                    string Remark = reg.getCertificateRemarks(InstCode.ToString(), 'D');
                    string usr = reg.getCertificateRemarks(InstCode.ToString(), 'U');
                    string place = reg.getCertificateRemarks(InstCode.ToString(), 'P');
                    string date = reg.getCertificateRemarks(InstCode.ToString(), 'T');
                    string date2 = reg.getCertificateRemarks(InstCode.ToString(), 'F');
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
                    frmMsg.Visible = false;
                    frmCertificate.Visible = true;
                }
                else
                {
                    frmMsg.Visible = true;
                    frmCertificate.Visible = false;
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
    }
}
