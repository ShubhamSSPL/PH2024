using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.MVModule
{
    public partial class frmAllotedChoiceCodeList : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                try
                {
                    string ChoiceCode = Request.QueryString["InstituteCode"].ToString();
                    string SOCode = ChoiceCode;

                    
                    
                    gvReport.DataSource = reg.getAllotedInstitutesForSO(SOCode,1);
                    gvReport.DataBind();
                    if(gvReport.Rows.Count==0)
                    {
                        cbChoiceCD.Visible = false;
                    }

                    gvVarified.DataSource = reg.getAllotedInstitutesForSO(SOCode,2);
                    gvVarified.DataBind();
                    if (gvVarified.Rows.Count == 0)
                    {
                        cbVerified.Visible = false;
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