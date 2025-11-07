using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmCandidateInstituteMinorityMapping : System.Web.UI.Page
    {
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    gvList.DataSource = Global.MasterCandidateInstituteMinorityMapping;
                    gvList.DataBind();

                    for (Int32 i = 0; i < gvList.Rows.Count; i++)
                    {
                        gvList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void gvList_DataBound(object sender, EventArgs e)
        {
            for (Int32 rowIndex = gvList.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow gvRow = gvList.Rows[rowIndex];
                GridViewRow gvPreviousRow = gvList.Rows[rowIndex + 1];

                if (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text)
                {
                    if (gvPreviousRow.Cells[1].RowSpan < 2)
                    {
                        gvRow.Cells[1].RowSpan = 2;
                    }
                    else
                    {
                        gvRow.Cells[1].RowSpan = gvPreviousRow.Cells[1].RowSpan + 1;
                    }
                    gvPreviousRow.Cells[1].Visible = false;
                }
            }
        }
    }
}