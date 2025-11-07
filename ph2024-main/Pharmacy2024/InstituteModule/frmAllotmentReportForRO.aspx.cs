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
    public partial class frmAllotmentReportForRO : System.Web.UI.Page
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
                    string RegionName = "";
                    if (Request.QueryString["RegionName"] != null)
                    {
                        RegionName = Request.QueryString["RegionName"].ToString();
                    }
                    else
                    {
                        RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                    }

                    lblRegionName.Text = RegionName + " Region";

                    gvReport.DataSource = reg.getAllotmentReportForRO(RegionName);
                    gvReport.DataBind();

                    Int64 TotalIntake = 0, CAPIntake = 0, MIIntake = 0, ILIntake = 0;
                    Int64 AllottedCAPRound1 = 0, AllottedCAPRound2 = 0, AllottedCAPRound3 = 0, AllottedCAPRound4 = 0;
                    Int64 TotalSASAutoFreeze = 0, TotalSASFreeze = 0, TotalSASFloat = 0, TotalSAS = 0;

                    Int32 Count = gvReport.Rows.Count;
                    for (Int32 i = 0; i < Count; i++)
                    {
                        gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        TotalIntake += Convert.ToInt64(gvReport.Rows[i].Cells[2].Text);
                        CAPIntake += Convert.ToInt64(gvReport.Rows[i].Cells[3].Text);
                        MIIntake += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                        ILIntake += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                        AllottedCAPRound1 += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);
                        AllottedCAPRound2 += Convert.ToInt64(gvReport.Rows[i].Cells[7].Text);
                        AllottedCAPRound3 += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                        AllottedCAPRound4 += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);
                        TotalSASAutoFreeze += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                        TotalSASFreeze += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
                        TotalSASFloat += Convert.ToInt64(gvReport.Rows[i].Cells[12].Text);
                        TotalSAS += Convert.ToInt64(gvReport.Rows[i].Cells[13].Text);
                    }

                    gvReport.FooterRow.Cells[1].Text = "Total";
                    gvReport.FooterRow.Cells[2].Text = TotalIntake.ToString();
                    gvReport.FooterRow.Cells[3].Text = CAPIntake.ToString();
                    gvReport.FooterRow.Cells[4].Text = MIIntake.ToString();
                    gvReport.FooterRow.Cells[5].Text = ILIntake.ToString();
                    gvReport.FooterRow.Cells[6].Text = AllottedCAPRound1.ToString();
                    gvReport.FooterRow.Cells[7].Text = AllottedCAPRound2.ToString();
                    gvReport.FooterRow.Cells[8].Text = AllottedCAPRound3.ToString();
                    gvReport.FooterRow.Cells[9].Text = AllottedCAPRound4.ToString();
                    gvReport.FooterRow.Cells[10].Text = TotalSASAutoFreeze.ToString();
                    gvReport.FooterRow.Cells[11].Text = TotalSASFreeze.ToString();
                    gvReport.FooterRow.Cells[12].Text = TotalSASFloat.ToString();
                    gvReport.FooterRow.Cells[13].Text = TotalSAS.ToString();
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