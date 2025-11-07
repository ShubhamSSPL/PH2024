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
    public partial class frmAllotmentReport : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                    string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();

                    lblInstituteName.Text = "[" + ChoiceCodeDisplay.Substring(0, 5) + "]" + " " + reg.getInstituteName(ChoiceCodeDisplay.Substring(0, 5)) + "<br /><br />" + Request.QueryString["ChoiceCodeDisplay"].ToString() + " - " + reg.getCourseName(ChoiceCode);

                    gvReport.DataSource = reg.getAllotmentReport(ChoiceCode);
                    gvReport.DataBind();

                    for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                    {
                        gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        //gvReport.Rows[i].Cells[3].Text = DataEncryption.DecryptDataByEncryptionKey(gvReport.Rows[i].Cells[3].Text);
                    }
                }
                catch (Exception ex)
                {
                    shInfo.Visible = true;
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
    }
}