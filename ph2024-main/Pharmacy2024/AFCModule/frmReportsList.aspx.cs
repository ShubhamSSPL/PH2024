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

namespace Pharmacy2024.AFCModule
{
    public partial class frmReportsList : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                try
                {
                    gvList.DataSource = reg.getReportsList();
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
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 ReportID = Convert.ToInt64(((Label)gvList.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].FindControl("lblReportID")).Text);
                string FileName = gvList.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                FileName = FileName.Trim().Replace(' ', '_');
                DataSet ds = reg.executeReport(ReportID);
                if (e.CommandName == "Excel")
                {
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GridView gvReport = new GridView();
                    gvReport.DataSource = ds;
                    gvReport.DataBind();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    gvReport.RenderControl(hw);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string strQuery = "";

                if (txtReportName.Text.Length > 0)
                {
                    for (Int32 i = 0; i < txtReportName.Text.Split(" ".ToCharArray()).Length; i++)
                    {
                        if (strQuery.Length == 0)
                        {
                            strQuery = "ReportName LIKE '%" + txtReportName.Text.Split(" ".ToCharArray())[i] + "%'";
                        }
                        else
                        {
                            strQuery += " AND ReportName LIKE '%" + txtReportName.Text.Split(" ".ToCharArray())[i] + "%'";
                        }
                    }
                }

                if (strQuery.Length > 0)
                {
                    gvList.DataSource = reg.searchReport(strQuery);
                    gvList.DataBind();

                    for (Int32 i = 0; i < gvList.Rows.Count; i++)
                    {
                        gvList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    }
                }
                else
                {
                    gvList.DataSource = reg.getReportsList();
                    gvList.DataBind();

                    for (Int32 i = 0; i < gvList.Rows.Count; i++)
                    {
                        gvList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}