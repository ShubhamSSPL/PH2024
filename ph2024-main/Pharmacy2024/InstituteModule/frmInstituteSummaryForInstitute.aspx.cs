using BusinessLayer;
using EntityModel;
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
    public partial class frmInstituteSummaryForInstitute : System.Web.UI.Page
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
                    string InstituteCode = Session["UserLoginID"].ToString();
                    InstituteSummary obj = reg.getInstituteSummary(InstituteCode);

                    lblInstituteCode.Text = obj.InstituteCode;
                    lblInstituteName.Text = obj.InstituteName;
                    lblInstituteAddress.Text = obj.InstituteAddress;
                    lblRegion.Text = obj.RegionName;
                    lblDistrict.Text = obj.DistrictName;
                    lblStatus1.Text = obj.InstituteStatus1;
                    lblStatus2.Text = obj.InstituteStatus2;
                    lblStatus3.Text = obj.InstituteStatus3;
                    lblBoysHostelCapacityIYear.Text = obj.BoysHostelCapacityIYear.ToString();
                    lblGirlsHostelCapacityIYear.Text = obj.GirlsHostelCapacityIYear.ToString();
                    lblPublicRemark.Text = obj.PublicRemark;

                    gvChoiceCodeList.DataSource = reg.getChoiceCodeListByInstitute(InstituteCode);
                    gvChoiceCodeList.DataBind();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    ContentBox1.Visible = false;
                    ContentBox7.Visible = false;
                    shInfo.SetMessage("You are not authorised to view Choice Code List.", ShowMessageType.Information);
                }
            }
        }
        protected void gvChoiceCodeList_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 ChoiceCode = Convert.ToInt64(e.CommandArgument.ToString());
                CourseInformation obj = reg.getCourseInformation(ChoiceCode.ToString());

                lblCourseName.Text = obj.CourseName;
                lblTotalIntake.Text = obj.TotalIntake.ToString();
                lblCAPIntake.Text = obj.CAPIntake.ToString();
                lblMIIntake.Text = obj.MIIntake.ToString();
                lblILIntake.Text = obj.ILIntake.ToString();
                lblMSIntake.Text = obj.MSIntake.ToString();
                lblAIIntake.Text = obj.AIIntake.ToString();

                GOPENH.Text = obj.GOPENH.ToString();
                GSCH.Text = obj.GSCH.ToString();
                GSTH.Text = obj.GSTH.ToString();
                GVJH.Text = obj.GVJH.ToString();
                GNT1H.Text = obj.GNT1H.ToString();
                GNT2H.Text = obj.GNT2H.ToString();
                GNT3H.Text = obj.GNT3H.ToString();
                GOBCH.Text = obj.GOBCH.ToString();
                GSEBCH.Text = obj.GSEBCH.ToString();
                LOPENH.Text = obj.LOPENH.ToString();
                LSCH.Text = obj.LSCH.ToString();
                LSTH.Text = obj.LSTH.ToString();
                LVJH.Text = obj.LVJH.ToString();
                LNT1H.Text = obj.LNT1H.ToString();
                LNT2H.Text = obj.LNT2H.ToString();
                LNT3H.Text = obj.LNT3H.ToString();
                LOBCH.Text = obj.LOBCH.ToString();
                LSEBCH.Text = obj.LSEBCH.ToString();
                PHCH.Text = obj.PHCH.ToString();
                PHCSCH.Text = obj.PHCSCH.ToString();
                PHCSTH.Text = obj.PHCSTH.ToString();
                PHCVJH.Text = obj.PHCVJH.ToString();
                PHCNT1H.Text = obj.PHCNT1H.ToString();
                PHCNT2H.Text = obj.PHCNT2H.ToString();
                PHCNT3H.Text = obj.PHCNT3H.ToString();
                PHCOBCH.Text = obj.PHCOBCH.ToString();
                PHCSEBCH.Text = obj.PHCSEBCH.ToString();
                GOPENO.Text = obj.GOPENO.ToString();
                GSCO.Text = obj.GSCO.ToString();
                GSTO.Text = obj.GSTO.ToString();
                GVJO.Text = obj.GVJO.ToString();
                GNT1O.Text = obj.GNT1O.ToString();
                GNT2O.Text = obj.GNT2O.ToString();
                GNT3O.Text = obj.GNT3O.ToString();
                GOBCO.Text = obj.GOBCO.ToString();
                GSEBCO.Text = obj.GSEBCO.ToString();
                LOPENO.Text = obj.LOPENO.ToString();
                LSCO.Text = obj.LSCO.ToString();
                LSTO.Text = obj.LSTO.ToString();
                LVJO.Text = obj.LVJO.ToString();
                LNT1O.Text = obj.LNT1O.ToString();
                LNT2O.Text = obj.LNT2O.ToString();
                LNT3O.Text = obj.LNT3O.ToString();
                LOBCO.Text = obj.LOBCO.ToString();
                LSEBCO.Text = obj.LSEBCO.ToString();
                PHCO.Text = obj.PHCO.ToString();
                PHCSCO.Text = obj.PHCSCO.ToString();
                PHCSTO.Text = obj.PHCSTO.ToString();
                PHCVJO.Text = obj.PHCVJO.ToString();
                PHCNT1O.Text = obj.PHCNT1O.ToString();
                PHCNT2O.Text = obj.PHCNT2O.ToString();
                PHCNT3O.Text = obj.PHCNT3O.ToString();
                PHCOBCO.Text = obj.PHCOBCO.ToString();
                PHCSEBCO.Text = obj.PHCSEBCO.ToString();
                DEFO.Text = obj.DEFO.ToString();
                DEFSCO.Text = obj.DEFSCO.ToString();
                DEFSTO.Text = obj.DEFSTO.ToString();
                DEFVJO.Text = obj.DEFVJO.ToString();
                DEFNT1O.Text = obj.DEFNT1O.ToString();
                DEFNT2O.Text = obj.DEFNT2O.ToString();
                DEFNT3O.Text = obj.DEFNT3O.ToString();
                DEFOBCO.Text = obj.DEFOBCO.ToString();
                DEFSEBCO.Text = obj.DEFSEBCO.ToString();
                EWS.Text = obj.EWS.ToString();
                ORPHAN.Text = obj.ORPHAN.ToString();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}