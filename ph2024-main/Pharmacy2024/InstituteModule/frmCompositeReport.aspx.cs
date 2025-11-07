using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmCompositeReport : System.Web.UI.Page
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
                    string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                    string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();
                    string Flag = Request.QueryString["Flag"].ToString();

                    lblInstituteName.Text = "[" + ChoiceCodeDisplay.Substring(0, 5) + "]" + " " + reg.getInstituteName(ChoiceCodeDisplay.Substring(0, 5)) + "<br /><br />" + Request.QueryString["ChoiceCodeDisplay"].ToString() + " - " + reg.getCourseName(ChoiceCode);

                    gvReport.DataSource = reg.getCompositeReport(ChoiceCode, Flag);
                    gvReport.DataBind();

                    for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                    {
                        gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        //gvReport.Rows[i].Cells[6].Text = DataEncryption.DecryptDataByEncryptionKey(gvReport.Rows[i].Cells[6].Text);

                        DateTime ReportingDateTime = Convert.ToDateTime(gvReport.Rows[i].Cells[7].Text);
                        string strReportingDateTime = "";
                        if (ReportingDateTime.Year != 1900)
                        {
                            strReportingDateTime = ReportingDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ReportingDateTime);
                        }
                        gvReport.Rows[i].Cells[7].Text = strReportingDateTime;
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
}