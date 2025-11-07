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
    public partial class frmEditCourseInformation : System.Web.UI.Page
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
                    string InstituteCode = Request.QueryString["InstituteCode"].ToString();
                    string ChoiceCode = "";

                    if (Request.QueryString["ChoiceCode"] != null)
                    {
                        ChoiceCode = Request.QueryString["ChoiceCode"].ToString();

                        CourseInformation obj = reg.getCourseInformation(ChoiceCode);

                        lblCourseName.Text = obj.ChoiceCodeDisplay + " - " + obj.CourseName;
                        lblUniversityName.Text = obj.UniversityName;
                        lblCourseStatus1.Text = obj.CourseStatus1;
                        lblCourseStatus2.Text = obj.CourseStatus2;
                        lblCourseStatus3.Text = obj.CourseStatus3;
                        lblCourseShift.Text = obj.CourseShift;
                        lblAccreditation.Text = obj.Accreditation;
                        lblGender.Text = obj.Gender;
                        lblIsGov.Text = obj.IsGov;
                        lblIsStateLevel.Text = obj.IsStateLevel;
                        lblIsTFWS.Text = obj.IsTFWS;
                        lblIsKonkan.Text = obj.IsKonkan;
                        lblIsNRI.Text = obj.IsNRI;
                        lblIsPIO.Text = obj.IsPIO;
                        lblParticipateInCAP.Text = obj.ParticipateInCAP;
                        lblCourtCaseRemark.Text = obj.CourtCaseRemark;
                        txtTotalIntake.Text = obj.TotalIntake.ToString();
                        txtCAPIntake.Text = obj.CAPIntake.ToString();
                        txtMIIntake.Text = obj.MIIntake.ToString();
                        txtILIntake.Text = obj.ILIntake.ToString();
                        txtMSIntake.Text = obj.MSIntake.ToString();
                        txtAIIntake.Text = obj.AIIntake.ToString();
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
                        txtDEFCommon.Text = obj.DEFT.ToString();
                        if (obj.IsStateLevel == "Yes")
                            txtPHCommon.Text = obj.PHOT.ToString();
                        else
                            txtPHCommon.Text = obj.PHHT.ToString();

                        if (obj.IsStateLevel == "Yes")
                        {
                            GOPENH.Enabled = false;
                            GSCH.Enabled = false;
                            GSTH.Enabled = false;
                            GVJH.Enabled = false;
                            GNT1H.Enabled = false;
                            GNT2H.Enabled = false;
                            GNT3H.Enabled = false;
                            GOBCH.Enabled = false;
                            GSEBCH.Enabled = false;
                            LOPENH.Enabled = false;
                            LSCH.Enabled = false;
                            LSTH.Enabled = false;
                            LVJH.Enabled = false;
                            LNT1H.Enabled = false;
                            LNT2H.Enabled = false;
                            LNT3H.Enabled = false;
                            LOBCH.Enabled = false;
                            LSEBCH.Enabled = false;
                            PHCH.Enabled = false;
                            PHCSCH.Enabled = false;
                            PHCSTH.Enabled = false;
                            PHCVJH.Enabled = false;
                            PHCNT1H.Enabled = false;
                            PHCNT2H.Enabled = false;
                            PHCNT3H.Enabled = false;
                            PHCOBCH.Enabled = false;
                            PHCSEBCH.Enabled = false;
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
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                CourseInformation obj = new CourseInformation();

                obj.ChoiceCode = Convert.ToInt64(Request.QueryString["ChoiceCode"].ToString());
                obj.TotalIntake = Convert.ToInt32(txtTotalIntake.Text);
                obj.CAPIntake = Convert.ToInt32(txtCAPIntake.Text);
                obj.ILIntake = Convert.ToInt32(txtILIntake.Text);
                obj.MIIntake = Convert.ToInt32(txtMIIntake.Text);
                obj.MSIntake = Convert.ToInt32(txtMSIntake.Text);
                obj.AIIntake = Convert.ToInt32(txtAIIntake.Text);
                obj.GOPENH = Convert.ToInt32(GOPENH.Text);
                obj.GSCH = Convert.ToInt32(GSCH.Text);
                obj.GSTH = Convert.ToInt32(GSTH.Text);
                obj.GVJH = Convert.ToInt32(GVJH.Text);
                obj.GNT1H = Convert.ToInt32(GNT1H.Text);
                obj.GNT2H = Convert.ToInt32(GNT2H.Text);
                obj.GNT3H = Convert.ToInt32(GNT3H.Text);
                obj.GOBCH = Convert.ToInt32(GOBCH.Text);
                obj.GSEBCH = Convert.ToInt32(GSEBCH.Text);
                obj.LOPENH = Convert.ToInt32(LOPENH.Text);
                obj.LSCH = Convert.ToInt32(LSCH.Text);
                obj.LSTH = Convert.ToInt32(LSTH.Text);
                obj.LVJH = Convert.ToInt32(LVJH.Text);
                obj.LNT1H = Convert.ToInt32(LNT1H.Text);
                obj.LNT2H = Convert.ToInt32(LNT2H.Text);
                obj.LNT3H = Convert.ToInt32(LNT3H.Text);
                obj.LOBCH = Convert.ToInt32(LOBCH.Text);
                obj.LSEBCH = Convert.ToInt32(LSEBCH.Text);
                obj.PHCH = Convert.ToInt32(PHCH.Text);
                obj.PHCSCH = Convert.ToInt32(PHCSCH.Text);
                obj.PHCSTH = Convert.ToInt32(PHCSTH.Text);
                obj.PHCVJH = Convert.ToInt32(PHCVJH.Text);
                obj.PHCNT1H = Convert.ToInt32(PHCNT1H.Text);
                obj.PHCNT2H = Convert.ToInt32(PHCNT2H.Text);
                obj.PHCNT3H = Convert.ToInt32(PHCNT3H.Text);
                obj.PHCOBCH = Convert.ToInt32(PHCOBCH.Text);
                obj.PHCSEBCH = Convert.ToInt32(PHCSEBCH.Text);
                obj.GOPENO = Convert.ToInt32(GOPENO.Text);
                obj.GSCO = Convert.ToInt32(GSCO.Text);
                obj.GSTO = Convert.ToInt32(GSTO.Text);
                obj.GVJO = Convert.ToInt32(GVJO.Text);
                obj.GNT1O = Convert.ToInt32(GNT1O.Text);
                obj.GNT2O = Convert.ToInt32(GNT2O.Text);
                obj.GNT3O = Convert.ToInt32(GNT3O.Text);
                obj.GOBCO = Convert.ToInt32(GOBCO.Text);
                obj.GSEBCO = Convert.ToInt32(GSEBCO.Text);
                obj.LOPENO = Convert.ToInt32(LOPENO.Text);
                obj.LSCO = Convert.ToInt32(LSCO.Text);
                obj.LSTO = Convert.ToInt32(LSTO.Text);
                obj.LVJO = Convert.ToInt32(LVJO.Text);
                obj.LNT1O = Convert.ToInt32(LNT1O.Text);
                obj.LNT2O = Convert.ToInt32(LNT2O.Text);
                obj.LNT3O = Convert.ToInt32(LNT3O.Text);
                obj.LOBCO = Convert.ToInt32(LOBCO.Text);
                obj.LSEBCO = Convert.ToInt32(LSEBCO.Text);
                obj.PHCO = Convert.ToInt32(PHCO.Text);
                obj.PHCSCO = Convert.ToInt32(PHCSCO.Text);
                obj.PHCSTO = Convert.ToInt32(PHCSTO.Text);
                obj.PHCVJO = Convert.ToInt32(PHCVJO.Text);
                obj.PHCNT1O = Convert.ToInt32(PHCNT1O.Text);
                obj.PHCNT2O = Convert.ToInt32(PHCNT2O.Text);
                obj.PHCNT3O = Convert.ToInt32(PHCNT3O.Text);
                obj.PHCOBCO = Convert.ToInt32(PHCOBCO.Text);
                obj.PHCSEBCO = Convert.ToInt32(PHCSEBCO.Text);
                obj.DEFO = Convert.ToInt32(DEFO.Text);
                obj.DEFSCO = Convert.ToInt32(DEFSCO.Text);
                obj.DEFSTO = Convert.ToInt32(DEFSTO.Text);
                obj.DEFVJO = Convert.ToInt32(DEFVJO.Text);
                obj.DEFNT1O = Convert.ToInt32(DEFNT1O.Text);
                obj.DEFNT2O = Convert.ToInt32(DEFNT2O.Text);
                obj.DEFNT3O = Convert.ToInt32(DEFNT3O.Text);
                obj.DEFOBCO = Convert.ToInt32(DEFOBCO.Text);
                obj.DEFSEBCO = Convert.ToInt32(DEFSEBCO.Text);
                obj.EWS = Convert.ToInt32(EWS.Text);
                obj.ORPHAN = Convert.ToInt32(ORPHAN.Text);

                obj.DEFT = Convert.ToInt32(txtDEFCommon.Text);
                obj.PHHT = Convert.ToInt32(txtPHCommon.Text);

                //if (obj.IsStateLevel == "Yes")
                //{
                //    obj.PHOT = Convert.ToInt32(txtPHCommon.Text);
                //    obj.PHHT = 0;
                //}
                //else
                //{
                //    obj.PHOT = 0;
                //    obj.PHHT = Convert.ToInt32(txtPHCommon.Text);
                //}

                if (reg.saveCourseInformation(obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    Response.Redirect("../InstituteModule/frmInstituteSummary.aspx?InstituteCode=" + Request.QueryString["InstituteCode"].ToString());
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
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