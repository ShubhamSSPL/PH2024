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

namespace Pharmacy2024.MVModule
{
	public partial class frmAllotedInstituteSO : System.Web.UI.Page
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

                    string SOCode = "";

                    SOCode = Session["UserLoginID"].ToString();

                    gvReport.DataSource = reg.getAllotedInstitutesForSO(SOCode, 3);
                    gvReport.DataBind();
                    
                    Int64 TAdmitted = 0,  TRecomend = 0, TNotRecomend = 0;
                    if (gvReport.Rows.Count > 0)
                    {
                        for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                        {
                            gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                            TAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[3].Text);
                            TRecomend += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                            TNotRecomend += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                        }
                        gvReport.FooterRow.Cells[2].Text = "Total";
                        gvReport.FooterRow.Cells[3].Text = TAdmitted.ToString();
                        gvReport.FooterRow.Cells[4].Text = TRecomend.ToString();
                        gvReport.FooterRow.Cells[5].Text = TNotRecomend.ToString();
                        GetColorCodes();
                    }

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public void GetColorCodes()
        {
            for (int i = 0; i < gvReport.Rows.Count; i++)
            {
                Label txtState = new Label();
                txtState = (Label)(gvReport.Rows[i].FindControl("lblInstStatus"));
                if (txtState.Text == "No")
                {
                    //gvReport.Rows[i].BackColor = System.Drawing.Color.LightGray;
                }
                else
                {
                    gvReport.Rows[i].BackColor = System.Drawing.Color.LightGray;
                }

            }
        }
    }
}