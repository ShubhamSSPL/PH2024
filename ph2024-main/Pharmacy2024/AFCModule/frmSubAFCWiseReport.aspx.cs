using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmSubAFCWiseReport : System.Web.UI.Page
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
                    Int16 RegionID = 0;
                    Int32 InstituteID = 0;
                    if (Request.QueryString["InstituteID"] != null)
                    {
                        RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                        InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                    }
                    else
                    {
                        RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                        InstituteID = reg.getInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                    }

                    gvSubAFCWiseReport.DataSource = reg.getSubAFCWiseReport(RegionID, InstituteID);
                    gvSubAFCWiseReport.DataBind();

                    Int64 TotalEScrutinyConfirmed = 0;
                    Int64 TotalPScrutinyConfirmed = 0;
                    Int64 TotalApplicationFormsConfirmed = 0;

                    for (Int32 i = 0; i < gvSubAFCWiseReport.Rows.Count; i++)
                    {
                        gvSubAFCWiseReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        //TotalEScrutinyConfirmed += Convert.ToInt64(gvSubAFCWiseReport.Rows[i].Cells[2].Text);
                        //TotalPScrutinyConfirmed += Convert.ToInt64(gvSubAFCWiseReport.Rows[i].Cells[3].Text);
                        //TotalApplicationFormsConfirmed += Convert.ToInt64(gvSubAFCWiseReport.Rows[i].Cells[4].Text);
                        TotalApplicationFormsConfirmed += Convert.ToInt64(gvSubAFCWiseReport.Rows[i].Cells[4].Text);
                    }

                    HyperLink hpr = new HyperLink();
                    hpr.NavigateUrl = "frmConfirmedCandidateList.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=" + InstituteID.ToString() + "&AFCID=99";
                    hpr.Text = "<b>Total</b>";
                    //gvSubAFCWiseReport.FooterRow.Cells[1].Controls.Add(hpr);
                    //gvSubAFCWiseReport.FooterRow.Cells[2].Text = TotalEScrutinyConfirmed.ToString();
                    //gvSubAFCWiseReport.FooterRow.Cells[3].Text = TotalPScrutinyConfirmed.ToString();
                    //gvSubAFCWiseReport.FooterRow.Cells[4].Text = TotalApplicationFormsConfirmed.ToString();
                    gvSubAFCWiseReport.FooterRow.Cells[4].Text = TotalApplicationFormsConfirmed.ToString();
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