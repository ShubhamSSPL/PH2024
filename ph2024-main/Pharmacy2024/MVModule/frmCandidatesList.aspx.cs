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
    public partial class frmCandidatesList : System.Web.UI.Page
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
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (!IsPostBack)
            {
                int InstCode = Convert.ToInt32(Session["UserLoginID"].ToString());
                string InstituteName = reg.getInstituteName(Convert.ToString(InstCode));
                lblInstCode.Text = Convert.ToString(InstCode);
                lblInstName.Text = InstituteName;

                Int64 NormalChoiceCode = Convert.ToInt64(Request.QueryString["NormalChoiceCode"].ToString());
                Int64 TfwsChoiceCode = Convert.ToInt64(Request.QueryString["TFWSChoiceCode"].ToString());

                gvReport.DataSource = reg.getCandidateListforMV(NormalChoiceCode, "SI");
                gvReport.DataBind();                
                if (gvReport.Rows.Count > 0)
                {                    
                    ShowingGroupingDataInGridView(gvReport.Rows, 0, 3);
                }
                else
                {
                    
                }

                gvOthers.DataSource = reg.getCandidateListforMV(NormalChoiceCode, "OTH");
                gvOthers.DataBind();
                if (gvOthers.Rows.Count > 0)
                {
                    lblOthers.Visible = true;
                    ShowingGroupingDataInGridView(gvOthers.Rows, 0, 3);
                }
                else
                {
                    lblOthers.Visible = false;
                }

                gvEWS.DataSource = reg.getCandidateListforMV(NormalChoiceCode, "EWS");
                gvEWS.DataBind();
                if (gvEWS.Rows.Count > 0)
                {
                    lblEWS.Visible = true;
                    ShowingGroupingDataInGridView(gvEWS.Rows, 0, 3);
                }
                else
                {
                    lblEWS.Visible = false;
                }
                
                gvTFWS.DataSource = reg.getCandidateListforMV(TfwsChoiceCode, "TFWS");
                gvTFWS.DataBind();
                if (gvTFWS.Rows.Count > 0)
                {
                    lblTFWS.Visible = true;
                    ShowingGroupingDataInGridView(gvTFWS.Rows, 0, 3);
                }
                else
                {
                    lblTFWS.Visible = false;
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
        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdmissionStatus = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=EN21" + PID;
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    lblAdmissionStatus.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }

            }
        }
        protected void gvOthers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdmissionStatus = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=EN21" + PID;
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    lblAdmissionStatus.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }

            }
        }
        protected void gvEWS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdmissionStatus = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=EN21" + PID;
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    lblAdmissionStatus.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }

            }
        }
        protected void gvTFWS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdmissionStatus = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=EN21" + PID;
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    lblAdmissionStatus.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }

            }
        }
    }
}