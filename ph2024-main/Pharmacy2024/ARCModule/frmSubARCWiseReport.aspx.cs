using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ARCModule
{
    public partial class frmSubARCWiseReport : System.Web.UI.Page
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
                    Int16 RegionID = 0;
                    Int32 InstituteID = 0;
                    if (Request.QueryString["InstituteID"] != null)
                    {
                        RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                        InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                    }
                    else
                    {
                        RegionID = reg.getARCRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                        InstituteID = reg.getARCInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                    }

                    gvSubARCWiseReport.DataSource = reg.getSubARCWiseReport(RegionID, InstituteID);
                    gvSubARCWiseReport.DataBind();

                    Int64 TotalConfirmed = 0;
                    Int64 TotalCancelled = 0;

                    for (Int32 i = 0; i < gvSubARCWiseReport.Rows.Count; i++)
                    {
                        gvSubARCWiseReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TotalConfirmed += Convert.ToInt64(gvSubARCWiseReport.Rows[i].Cells[2].Text);
                        TotalCancelled += Convert.ToInt64(gvSubARCWiseReport.Rows[i].Cells[3].Text);
                    }

                    HyperLink hpr = new HyperLink();
                    hpr.NavigateUrl = "frmConfirmedCandidateList.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=" + InstituteID.ToString() + "&ARCID=99";
                    hpr.Text = "<b>Total</b>";
                    gvSubARCWiseReport.FooterRow.Cells[1].Controls.Add(hpr);
                    gvSubARCWiseReport.FooterRow.Cells[2].Text = TotalConfirmed.ToString();
                    gvSubARCWiseReport.FooterRow.Cells[3].Text = TotalCancelled.ToString();
                    lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
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