using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmCompositeReportForRO : System.Web.UI.Page
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
                    string RegionName = "";
                    if (Request.QueryString["RegionName"] != null)
                    {
                        RegionName = Request.QueryString["RegionName"].ToString();
                        ddlCourseType.SelectedValue = Request.QueryString["Flag"].ToString();
                        ddlTNA.SelectedValue = Request.QueryString["Flag2"].ToString();
                    }
                    else
                    {
                        RegionName = Session["UserLoginID"].ToString().Substring(2, Session["UserLoginID"].ToString().Length - 2);
                    }

                    ContentTable2.HeaderText = "Institute Wise Composite Report for " + RegionName + " Region";

                    gvReport.DataSource = reg.getCompositeReportForRO(RegionName, ddlCourseType.SelectedValue, ddlTNA.SelectedValue);
                    gvReport.DataBind();

                    Int64 CAPIntake = 0, CAPAdmittedBefore = 0, CAPAdmittedAfter = 0, CAPAdmitted = 0, CAPCancelled = 0, CAPVacancy = 0;
                    Int64 ACAPIntake = 0, ACAPAdmittedBefore = 0, ACAPAdmittedAfter = 0, ACAPAdmitted = 0, ACAPCancelled = 0, ACAPVacancy = 0;
                    Int64 CAPMIIntake = 0, CAPMIAdmittedBefore = 0, CAPMIAdmittedAfter = 0, CAPMIAdmitted = 0, CAPMICancelled = 0, CAPMIVacancy = 0;
                    Int64 ACAPMIIntake = 0, ACAPMIAdmittedBefore = 0, ACAPMIAdmittedAfter = 0, ACAPMIAdmitted = 0, ACAPMICancelled = 0, ACAPMIVacancy = 0;
                    Int64 ILIntake = 0, ILAdmittedBefore = 0, ILAdmittedAfter = 0, ILAdmitted = 0, ILCancelled = 0, ILVacancy = 0;
                    Int64 TotalIntake = 0, TotalAdmittedBefore = 0, TotalAdmittedAfter = 0, TotalAdmitted = 0, TotalCancelled = 0, TotalVacancy = 0;
                    Int64 JKIntake = 0, JKAdmittedBefore = 0, JKAdmittedAfter = 0, JKAdmitted = 0, JKCancelled = 0, JKVacancy = 0;
                    Int64 OAAAdmittedBefore = 0, OAAAdmittedAfter = 0, OAAAdmitted = 0, OAACancelled = 0;
                    Int64 TotalEWSIntake = 0, TotalEWSAdmittedBefore = 0, TotalEWSAdmittedAfter = 0, TotalEWSAdmitted = 0, TotalEWSCancelled = 0, TotalEWSVacancy = 0;
                    for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                    {
                        gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        HyperLink hpr = new HyperLink();
                        hpr.NavigateUrl = "frmCompositeReportForInstitute.aspx?InstituteCode=" + gvReport.Rows[i].Cells[1].Text + "&Flag=" + ddlCourseType.SelectedValue + "&Flag2=" + ddlTNA.SelectedValue;
                        hpr.Text = gvReport.Rows[i].Cells[1].Text;
                        gvReport.Rows[i].Cells[1].Controls.Add(hpr);

                        CAPIntake += Convert.ToInt64(gvReport.Rows[i].Cells[3].Text);
                        //CAPAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                        //CAPAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                        CAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                        CAPCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                        CAPVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);
                        ACAPIntake += Convert.ToInt64(gvReport.Rows[i].Cells[7].Text);
                        //ACAPAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                        //ACAPAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
                        ACAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                        ACAPCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);
                        ACAPVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                        CAPMIIntake += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
                        //CAPMIAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[16].Text);
                        //CAPMIAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[17].Text);
                        CAPMIAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[12].Text);
                        CAPMICancelled += Convert.ToInt64(gvReport.Rows[i].Cells[13].Text);
                        CAPMIVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[14].Text);
                        ACAPMIIntake += Convert.ToInt64(gvReport.Rows[i].Cells[15].Text);
                        //ACAPMIAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[22].Text);
                        //ACAPMIAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[23].Text);
                        ACAPMIAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[16].Text);
                        ACAPMICancelled += Convert.ToInt64(gvReport.Rows[i].Cells[17].Text);
                        ACAPMIVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[18].Text);
                        ILIntake += Convert.ToInt64(gvReport.Rows[i].Cells[19].Text);
                        //ILAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[28].Text);
                        //ILAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[29].Text);
                        ILAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[20].Text);
                        ILCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[21].Text);
                        ILVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[22].Text);
                        TotalIntake += Convert.ToInt64(gvReport.Rows[i].Cells[23].Text);
                        //TotalAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[34].Text);
                        //TotalAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[35].Text);
                        TotalAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[24].Text);
                        TotalCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[25].Text);
                        TotalVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[26].Text);
                        JKIntake += Convert.ToInt64(gvReport.Rows[i].Cells[27].Text);
                        //JKAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[40].Text);
                        //JKAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[41].Text);
                        JKAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[28].Text);
                        JKCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[29].Text);
                        JKVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[30].Text);
                        //OAAAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[45].Text);
                        //OAAAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[46].Text);
                        OAAAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[31].Text);
                        OAACancelled += Convert.ToInt64(gvReport.Rows[i].Cells[32].Text);

                        TotalEWSIntake += Convert.ToInt64(gvReport.Rows[i].Cells[33].Text);
                        //TotalEWSAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[33].Text);
                        //TotalEWSAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[34].Text);
                        TotalEWSAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[34].Text);
                        TotalEWSCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[35].Text);
                        TotalEWSVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[36].Text);
                    }

                    gvReport.FooterRow.Cells[2].Text = "Total";
                    gvReport.FooterRow.Cells[3].Text = CAPIntake.ToString();
                    //gvReport.FooterRow.Cells[4].Text = CAPAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[5].Text = CAPAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[4].Text = CAPAdmitted.ToString();
                    gvReport.FooterRow.Cells[5].Text = CAPCancelled.ToString();
                    gvReport.FooterRow.Cells[6].Text = CAPVacancy.ToString();
                    gvReport.FooterRow.Cells[7].Text = ACAPIntake.ToString();
                    //gvReport.FooterRow.Cells[10].Text = ACAPAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[11].Text = ACAPAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[8].Text = ACAPAdmitted.ToString();
                    gvReport.FooterRow.Cells[9].Text = ACAPCancelled.ToString();
                    gvReport.FooterRow.Cells[10].Text = ACAPVacancy.ToString();
                    gvReport.FooterRow.Cells[11].Text = CAPMIIntake.ToString();
                    //gvReport.FooterRow.Cells[16].Text = CAPMIAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[17].Text = CAPMIAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[12].Text = CAPMIAdmitted.ToString();
                    gvReport.FooterRow.Cells[13].Text = CAPMICancelled.ToString();
                    gvReport.FooterRow.Cells[14].Text = CAPMIVacancy.ToString();
                    gvReport.FooterRow.Cells[15].Text = ACAPMIIntake.ToString();
                    //gvReport.FooterRow.Cells[22].Text = ACAPMIAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[23].Text = ACAPMIAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[16].Text = ACAPMIAdmitted.ToString();
                    gvReport.FooterRow.Cells[17].Text = ACAPMICancelled.ToString();
                    gvReport.FooterRow.Cells[18].Text = ACAPMIVacancy.ToString();
                    gvReport.FooterRow.Cells[19].Text = ILIntake.ToString();
                    //gvReport.FooterRow.Cells[28].Text = ILAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[29].Text = ILAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[20].Text = ILAdmitted.ToString();
                    gvReport.FooterRow.Cells[21].Text = ILCancelled.ToString();
                    gvReport.FooterRow.Cells[22].Text = ILVacancy.ToString();
                    gvReport.FooterRow.Cells[23].Text = TotalIntake.ToString();
                    //gvReport.FooterRow.Cells[34].Text = TotalAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[35].Text = TotalAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[24].Text = TotalAdmitted.ToString();
                    gvReport.FooterRow.Cells[25].Text = TotalCancelled.ToString();
                    gvReport.FooterRow.Cells[26].Text = TotalVacancy.ToString();
                    gvReport.FooterRow.Cells[27].Text = JKIntake.ToString();
                    //gvReport.FooterRow.Cells[40].Text = JKAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[41].Text = JKAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[28].Text = JKAdmitted.ToString();
                    gvReport.FooterRow.Cells[29].Text = JKCancelled.ToString();
                    gvReport.FooterRow.Cells[30].Text = JKVacancy.ToString();
                    //gvReport.FooterRow.Cells[45].Text = OAAAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[46].Text = OAAAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[31].Text = OAAAdmitted.ToString();
                    gvReport.FooterRow.Cells[32].Text = OAACancelled.ToString();

                    gvReport.FooterRow.Cells[33].Text = TotalEWSIntake.ToString();
                    //gvReport.FooterRow.Cells[34].Text = TotalAdmittedBefore.ToString();
                    //gvReport.FooterRow.Cells[34].Text = TotalAdmittedAfter.ToString();
                    gvReport.FooterRow.Cells[34].Text = TotalEWSAdmitted.ToString();
                    gvReport.FooterRow.Cells[35].Text = TotalEWSCancelled.ToString();
                    gvReport.FooterRow.Cells[36].Text = TotalEWSVacancy.ToString();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlCourseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
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

                ContentTable2.HeaderText = "Institute Wise Composite Report for " + RegionName + " Region";

                gvReport.DataSource = reg.getCompositeReportForRO(RegionName, ddlCourseType.SelectedValue, ddlTNA.SelectedValue);
                gvReport.DataBind();

                Int64 CAPIntake = 0, CAPAdmittedBefore = 0, CAPAdmittedAfter = 0, CAPAdmitted = 0, CAPCancelled = 0, CAPVacancy = 0;
                Int64 ACAPIntake = 0, ACAPAdmittedBefore = 0, ACAPAdmittedAfter = 0, ACAPAdmitted = 0, ACAPCancelled = 0, ACAPVacancy = 0;
                Int64 CAPMIIntake = 0, CAPMIAdmittedBefore = 0, CAPMIAdmittedAfter = 0, CAPMIAdmitted = 0, CAPMICancelled = 0, CAPMIVacancy = 0;
                Int64 ACAPMIIntake = 0, ACAPMIAdmittedBefore = 0, ACAPMIAdmittedAfter = 0, ACAPMIAdmitted = 0, ACAPMICancelled = 0, ACAPMIVacancy = 0;
                Int64 ILIntake = 0, ILAdmittedBefore = 0, ILAdmittedAfter = 0, ILAdmitted = 0, ILCancelled = 0, ILVacancy = 0;
                Int64 TotalIntake = 0, TotalAdmittedBefore = 0, TotalAdmittedAfter = 0, TotalAdmitted = 0, TotalCancelled = 0, TotalVacancy = 0;
                Int64 JKIntake = 0, JKAdmittedBefore = 0, JKAdmittedAfter = 0, JKAdmitted = 0, JKCancelled = 0, JKVacancy = 0;
                Int64 OAAAdmittedBefore = 0, OAAAdmittedAfter = 0, OAAAdmitted = 0, OAACancelled = 0;
                Int64 TotalEWSIntake = 0, TotalEWSAdmittedBefore = 0, TotalEWSAdmittedAfter = 0, TotalEWSAdmitted = 0, TotalEWSCancelled = 0, TotalEWSVacancy = 0;
                for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                {
                    gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    HyperLink hpr = new HyperLink();
                    hpr.NavigateUrl = "frmCompositeReportForInstitute.aspx?InstituteCode=" + gvReport.Rows[i].Cells[1].Text + "&Flag=" + ddlCourseType.SelectedValue + "&Flag2=" + ddlTNA.SelectedValue;
                    hpr.Text = gvReport.Rows[i].Cells[1].Text;
                    gvReport.Rows[i].Cells[1].Controls.Add(hpr);

                    CAPIntake += Convert.ToInt64(gvReport.Rows[i].Cells[3].Text);
                    //CAPAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                    //CAPAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                    CAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                    CAPCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                    CAPVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);
                    ACAPIntake += Convert.ToInt64(gvReport.Rows[i].Cells[7].Text);
                    //ACAPAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                    //ACAPAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
                    ACAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                    ACAPCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);
                    ACAPVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                    CAPMIIntake += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
                    //CAPMIAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[16].Text);
                    //CAPMIAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[17].Text);
                    CAPMIAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[12].Text);
                    CAPMICancelled += Convert.ToInt64(gvReport.Rows[i].Cells[13].Text);
                    CAPMIVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[14].Text);
                    ACAPMIIntake += Convert.ToInt64(gvReport.Rows[i].Cells[15].Text);
                    //ACAPMIAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[22].Text);
                    //ACAPMIAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[23].Text);
                    ACAPMIAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[16].Text);
                    ACAPMICancelled += Convert.ToInt64(gvReport.Rows[i].Cells[17].Text);
                    ACAPMIVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[18].Text);
                    ILIntake += Convert.ToInt64(gvReport.Rows[i].Cells[19].Text);
                    //ILAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[28].Text);
                    //ILAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[29].Text);
                    ILAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[20].Text);
                    ILCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[21].Text);
                    ILVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[22].Text);
                    TotalIntake += Convert.ToInt64(gvReport.Rows[i].Cells[23].Text);
                    //TotalAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[34].Text);
                    //TotalAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[35].Text);
                    TotalAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[24].Text);
                    TotalCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[25].Text);
                    TotalVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[26].Text);
                    JKIntake += Convert.ToInt64(gvReport.Rows[i].Cells[27].Text);
                    //JKAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[40].Text);
                    //JKAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[41].Text);
                    JKAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[28].Text);
                    JKCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[29].Text);
                    JKVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[30].Text);
                    //OAAAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[45].Text);
                    //OAAAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[46].Text);
                    OAAAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[31].Text);
                    OAACancelled += Convert.ToInt64(gvReport.Rows[i].Cells[32].Text);

                    TotalEWSIntake += Convert.ToInt64(gvReport.Rows[i].Cells[33].Text);
                    //TotalEWSAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[33].Text);
                    //TotalEWSAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[34].Text);
                    TotalEWSAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[34].Text);
                    TotalEWSCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[35].Text);
                    TotalEWSVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[36].Text);
                }

                gvReport.FooterRow.Cells[2].Text = "Total";
                gvReport.FooterRow.Cells[3].Text = CAPIntake.ToString();
                //gvReport.FooterRow.Cells[4].Text = CAPAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[5].Text = CAPAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[4].Text = CAPAdmitted.ToString();
                gvReport.FooterRow.Cells[5].Text = CAPCancelled.ToString();
                gvReport.FooterRow.Cells[6].Text = CAPVacancy.ToString();
                gvReport.FooterRow.Cells[7].Text = ACAPIntake.ToString();
                //gvReport.FooterRow.Cells[10].Text = ACAPAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[11].Text = ACAPAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[8].Text = ACAPAdmitted.ToString();
                gvReport.FooterRow.Cells[9].Text = ACAPCancelled.ToString();
                gvReport.FooterRow.Cells[10].Text = ACAPVacancy.ToString();
                gvReport.FooterRow.Cells[11].Text = CAPMIIntake.ToString();
                //gvReport.FooterRow.Cells[16].Text = CAPMIAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[17].Text = CAPMIAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[12].Text = CAPMIAdmitted.ToString();
                gvReport.FooterRow.Cells[13].Text = CAPMICancelled.ToString();
                gvReport.FooterRow.Cells[14].Text = CAPMIVacancy.ToString();
                gvReport.FooterRow.Cells[15].Text = ACAPMIIntake.ToString();
                //gvReport.FooterRow.Cells[22].Text = ACAPMIAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[23].Text = ACAPMIAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[16].Text = ACAPMIAdmitted.ToString();
                gvReport.FooterRow.Cells[17].Text = ACAPMICancelled.ToString();
                gvReport.FooterRow.Cells[18].Text = ACAPMIVacancy.ToString();
                gvReport.FooterRow.Cells[19].Text = ILIntake.ToString();
                //gvReport.FooterRow.Cells[28].Text = ILAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[29].Text = ILAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[20].Text = ILAdmitted.ToString();
                gvReport.FooterRow.Cells[21].Text = ILCancelled.ToString();
                gvReport.FooterRow.Cells[22].Text = ILVacancy.ToString();
                gvReport.FooterRow.Cells[23].Text = TotalIntake.ToString();
                //gvReport.FooterRow.Cells[34].Text = TotalAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[35].Text = TotalAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[24].Text = TotalAdmitted.ToString();
                gvReport.FooterRow.Cells[25].Text = TotalCancelled.ToString();
                gvReport.FooterRow.Cells[26].Text = TotalVacancy.ToString();
                gvReport.FooterRow.Cells[27].Text = JKIntake.ToString();
                //gvReport.FooterRow.Cells[40].Text = JKAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[41].Text = JKAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[28].Text = JKAdmitted.ToString();
                gvReport.FooterRow.Cells[29].Text = JKCancelled.ToString();
                gvReport.FooterRow.Cells[30].Text = JKVacancy.ToString();
                //gvReport.FooterRow.Cells[45].Text = OAAAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[46].Text = OAAAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[31].Text = OAAAdmitted.ToString();
                gvReport.FooterRow.Cells[32].Text = OAACancelled.ToString();

                gvReport.FooterRow.Cells[33].Text = TotalEWSIntake.ToString();
                //gvReport.FooterRow.Cells[34].Text = TotalAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[34].Text = TotalAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[34].Text = TotalEWSAdmitted.ToString();
                gvReport.FooterRow.Cells[35].Text = TotalEWSCancelled.ToString();
                gvReport.FooterRow.Cells[36].Text = TotalEWSVacancy.ToString();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlTNA_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
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

                ContentTable2.HeaderText = "Institute Wise Composite Report for " + RegionName + " Region";

                gvReport.DataSource = reg.getCompositeReportForRO(RegionName, ddlCourseType.SelectedValue, ddlTNA.SelectedValue);
                gvReport.DataBind();

                Int64 CAPIntake = 0, CAPAdmittedBefore = 0, CAPAdmittedAfter = 0, CAPAdmitted = 0, CAPCancelled = 0, CAPVacancy = 0;
                Int64 ACAPIntake = 0, ACAPAdmittedBefore = 0, ACAPAdmittedAfter = 0, ACAPAdmitted = 0, ACAPCancelled = 0, ACAPVacancy = 0;
                Int64 CAPMIIntake = 0, CAPMIAdmittedBefore = 0, CAPMIAdmittedAfter = 0, CAPMIAdmitted = 0, CAPMICancelled = 0, CAPMIVacancy = 0;
                Int64 ACAPMIIntake = 0, ACAPMIAdmittedBefore = 0, ACAPMIAdmittedAfter = 0, ACAPMIAdmitted = 0, ACAPMICancelled = 0, ACAPMIVacancy = 0;
                Int64 ILIntake = 0, ILAdmittedBefore = 0, ILAdmittedAfter = 0, ILAdmitted = 0, ILCancelled = 0, ILVacancy = 0;
                Int64 TotalIntake = 0, TotalAdmittedBefore = 0, TotalAdmittedAfter = 0, TotalAdmitted = 0, TotalCancelled = 0, TotalVacancy = 0;
                Int64 JKIntake = 0, JKAdmittedBefore = 0, JKAdmittedAfter = 0, JKAdmitted = 0, JKCancelled = 0, JKVacancy = 0;
                Int64 OAAAdmittedBefore = 0, OAAAdmittedAfter = 0, OAAAdmitted = 0, OAACancelled = 0;
                Int64 TotalEWSIntake = 0, TotalEWSAdmittedBefore = 0, TotalEWSAdmittedAfter = 0, TotalEWSAdmitted = 0, TotalEWSCancelled = 0, TotalEWSVacancy = 0;
                for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                {
                    gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    HyperLink hpr = new HyperLink();
                    hpr.NavigateUrl = "frmCompositeReportForInstitute.aspx?InstituteCode=" + gvReport.Rows[i].Cells[1].Text + "&Flag=" + ddlCourseType.SelectedValue + "&Flag2=" + ddlTNA.SelectedValue;
                    hpr.Text = gvReport.Rows[i].Cells[1].Text;
                    gvReport.Rows[i].Cells[1].Controls.Add(hpr);

                    CAPIntake += Convert.ToInt64(gvReport.Rows[i].Cells[3].Text);
                    //CAPAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                    //CAPAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                    CAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[4].Text);
                    CAPCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[5].Text);
                    CAPVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[6].Text);
                    ACAPIntake += Convert.ToInt64(gvReport.Rows[i].Cells[7].Text);
                    //ACAPAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                    //ACAPAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
                    ACAPAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[8].Text);
                    ACAPCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[9].Text);
                    ACAPVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[10].Text);
                    CAPMIIntake += Convert.ToInt64(gvReport.Rows[i].Cells[11].Text);
                    //CAPMIAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[16].Text);
                    //CAPMIAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[17].Text);
                    CAPMIAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[12].Text);
                    CAPMICancelled += Convert.ToInt64(gvReport.Rows[i].Cells[13].Text);
                    CAPMIVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[14].Text);
                    ACAPMIIntake += Convert.ToInt64(gvReport.Rows[i].Cells[15].Text);
                    //ACAPMIAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[22].Text);
                    //ACAPMIAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[23].Text);
                    ACAPMIAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[16].Text);
                    ACAPMICancelled += Convert.ToInt64(gvReport.Rows[i].Cells[17].Text);
                    ACAPMIVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[18].Text);
                    ILIntake += Convert.ToInt64(gvReport.Rows[i].Cells[19].Text);
                    //ILAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[28].Text);
                    //ILAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[29].Text);
                    ILAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[20].Text);
                    ILCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[21].Text);
                    ILVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[22].Text);
                    TotalIntake += Convert.ToInt64(gvReport.Rows[i].Cells[23].Text);
                    //TotalAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[34].Text);
                    //TotalAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[35].Text);
                    TotalAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[24].Text);
                    TotalCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[25].Text);
                    TotalVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[26].Text);
                    JKIntake += Convert.ToInt64(gvReport.Rows[i].Cells[27].Text);
                    //JKAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[40].Text);
                    //JKAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[41].Text);
                    JKAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[28].Text);
                    JKCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[29].Text);
                    JKVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[30].Text);
                    //OAAAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[45].Text);
                    //OAAAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[46].Text);
                    OAAAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[31].Text);
                    OAACancelled += Convert.ToInt64(gvReport.Rows[i].Cells[32].Text);

                    TotalEWSIntake += Convert.ToInt64(gvReport.Rows[i].Cells[33].Text);
                    //TotalEWSAdmittedBefore += Convert.ToInt64(gvReport.Rows[i].Cells[33].Text);
                    //TotalEWSAdmittedAfter += Convert.ToInt64(gvReport.Rows[i].Cells[34].Text);
                    TotalEWSAdmitted += Convert.ToInt64(gvReport.Rows[i].Cells[34].Text);
                    TotalEWSCancelled += Convert.ToInt64(gvReport.Rows[i].Cells[35].Text);
                    TotalEWSVacancy += Convert.ToInt64(gvReport.Rows[i].Cells[36].Text);
                }

                gvReport.FooterRow.Cells[2].Text = "Total";
                gvReport.FooterRow.Cells[3].Text = CAPIntake.ToString();
                //gvReport.FooterRow.Cells[4].Text = CAPAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[5].Text = CAPAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[4].Text = CAPAdmitted.ToString();
                gvReport.FooterRow.Cells[5].Text = CAPCancelled.ToString();
                gvReport.FooterRow.Cells[6].Text = CAPVacancy.ToString();
                gvReport.FooterRow.Cells[7].Text = ACAPIntake.ToString();
                //gvReport.FooterRow.Cells[10].Text = ACAPAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[11].Text = ACAPAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[8].Text = ACAPAdmitted.ToString();
                gvReport.FooterRow.Cells[9].Text = ACAPCancelled.ToString();
                gvReport.FooterRow.Cells[10].Text = ACAPVacancy.ToString();
                gvReport.FooterRow.Cells[11].Text = CAPMIIntake.ToString();
                //gvReport.FooterRow.Cells[16].Text = CAPMIAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[17].Text = CAPMIAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[12].Text = CAPMIAdmitted.ToString();
                gvReport.FooterRow.Cells[13].Text = CAPMICancelled.ToString();
                gvReport.FooterRow.Cells[14].Text = CAPMIVacancy.ToString();
                gvReport.FooterRow.Cells[15].Text = ACAPMIIntake.ToString();
                //gvReport.FooterRow.Cells[22].Text = ACAPMIAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[23].Text = ACAPMIAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[16].Text = ACAPMIAdmitted.ToString();
                gvReport.FooterRow.Cells[17].Text = ACAPMICancelled.ToString();
                gvReport.FooterRow.Cells[18].Text = ACAPMIVacancy.ToString();
                gvReport.FooterRow.Cells[19].Text = ILIntake.ToString();
                //gvReport.FooterRow.Cells[28].Text = ILAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[29].Text = ILAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[20].Text = ILAdmitted.ToString();
                gvReport.FooterRow.Cells[21].Text = ILCancelled.ToString();
                gvReport.FooterRow.Cells[22].Text = ILVacancy.ToString();
                gvReport.FooterRow.Cells[23].Text = TotalIntake.ToString();
                //gvReport.FooterRow.Cells[34].Text = TotalAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[35].Text = TotalAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[24].Text = TotalAdmitted.ToString();
                gvReport.FooterRow.Cells[25].Text = TotalCancelled.ToString();
                gvReport.FooterRow.Cells[26].Text = TotalVacancy.ToString();
                gvReport.FooterRow.Cells[27].Text = JKIntake.ToString();
                //gvReport.FooterRow.Cells[40].Text = JKAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[41].Text = JKAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[28].Text = JKAdmitted.ToString();
                gvReport.FooterRow.Cells[29].Text = JKCancelled.ToString();
                gvReport.FooterRow.Cells[30].Text = JKVacancy.ToString();
                //gvReport.FooterRow.Cells[45].Text = OAAAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[46].Text = OAAAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[31].Text = OAAAdmitted.ToString();
                gvReport.FooterRow.Cells[32].Text = OAACancelled.ToString();

                gvReport.FooterRow.Cells[33].Text = TotalEWSIntake.ToString();
                //gvReport.FooterRow.Cells[34].Text = TotalAdmittedBefore.ToString();
                //gvReport.FooterRow.Cells[34].Text = TotalAdmittedAfter.ToString();
                gvReport.FooterRow.Cells[34].Text = TotalEWSAdmitted.ToString();
                gvReport.FooterRow.Cells[35].Text = TotalEWSCancelled.ToString();
                gvReport.FooterRow.Cells[36].Text = TotalEWSVacancy.ToString();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();

                Cell_Header.Text = "Sr. No.";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Institute Code";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Institute Name";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "CAP (Excluding Minority) Quota";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Against CAP (Excluding Minority) Quota";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "CAP (Minority) Quota";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Against CAP (Minority) Quota";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Institute Level Quota";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Total";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "J&K Quota";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Others Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvReport.Controls[0].Controls.AddAt(0, HeaderRow);

                Cell_Header = new TableCell();
                Cell_Header.Text = "EWS Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 4;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvReport.Controls[0].Controls.AddAt(0, HeaderRow);
                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.ColumnSpan = 3;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cancelled";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cancelled";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cancelled";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cancelled";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cancelled";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cancelled";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cancelled";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cancelled";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvReport.Controls[0].Controls.AddAt(1, HeaderRow);

                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                ////Cell_Header = new TableCell();
                ////Cell_Header.Text = "Before<br />Cut-Off";
                ////Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                ////Cell_Header.CssClass = "Header";
                ////Cell_Header.Wrap = false;
                ////HeaderRow.Cells.Add(Cell_Header);

                ////Cell_Header = new TableCell();
                ////Cell_Header.Text = "After<br />Cut-Off";
                ////Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                ////Cell_Header.CssClass = "Header";
                ////Cell_Header.Wrap = false;
                ////HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Total<br />Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Before<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "After<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Total<br />Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Before<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "After<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Total<br />Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Before<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "After<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Total<br />Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Before<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "After<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Total<br />Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Before<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "After<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Total<br />Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Before<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "After<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Total<br />Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Before<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "After<br />Cut-Off";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Total<br />Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                gvReport.Controls[0].Controls.AddAt(2, HeaderRow);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 1;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.ColumnSpan = 3;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Admitted";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 1;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Cancelled";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 1;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Vacancy";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 1;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);
            }
        }
        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=CompositeReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvReport.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}