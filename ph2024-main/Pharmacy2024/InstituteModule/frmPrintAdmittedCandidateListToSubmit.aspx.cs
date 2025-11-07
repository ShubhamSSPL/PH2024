using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmPrintAdmittedCandidateListToSubmit : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.FilePath.Contains("StaticPages/HomePage"))
            {
                string strPreviousPage = "";
                if (Request.UrlReferrer != null)
                {
                    strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                }
                if (strPreviousPage == "")
                {
                    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                }
                if (Session["UserLoginID"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
                }
                if (!IsPostBack)
                {
                    try
                    {
                        Int32 Limit = 12;
                        string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();

                        string InstituteName = "";
                        string ChoiceCodeD = "";

                        //if (ChoiceCode.Length > 11)
                        //{
                        //     InstituteName = reg.getInstituteName(ChoiceCode.Substring(0, 5));
                        //    ChoiceCodeD = ChoiceCode.Substring(0, 5);
                        //}
                        //else
                        //{
                        //    InstituteName = reg.getInstituteName(ChoiceCode.Substring(0, 4));
                        //    ChoiceCodeD = ChoiceCode.Substring(0, 4);
                        //}

                        string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();
                        string CourseName = reg.getCourseName(ChoiceCode);

                        
                        InstituteName = reg.getInstituteName(ChoiceCodeDisplay.Substring(0, 5));
                        ChoiceCodeD = ChoiceCodeDisplay.Substring(0, 5);
                        

                        string[] Intake = reg.getIntakeForChoiceCode(ChoiceCode).Split(";".ToCharArray());
                        DataSet dsAdmittedCandidateList = reg.getAdmittedCandidateListToSubmit(ChoiceCode);
                        Int32 SrNo = 0;
                        Int32 CurrentPage = 1;
                        Int32 TotalPages = 0;

                        for (Int32 l = 0; l < dsAdmittedCandidateList.Tables.Count; l++)
                        {
                            TotalPages += (dsAdmittedCandidateList.Tables[l].Rows.Count % Limit == 0) ? (int)(dsAdmittedCandidateList.Tables[l].Rows.Count / Limit) : (int)(dsAdmittedCandidateList.Tables[l].Rows.Count / Limit + 1);
                        }

                        for (Int32 l = 0; l < dsAdmittedCandidateList.Tables.Count; l++)
                        {
                            if (l > 4)
                            {
                                SrNo = 0;
                            }

                            for (Int32 j = 1; j <= (dsAdmittedCandidateList.Tables[l].Rows.Count / Limit) + 1; j++)
                            {
                                if (j == (dsAdmittedCandidateList.Tables[l].Rows.Count / Limit) + 1 && dsAdmittedCandidateList.Tables[l].Rows.Count % Limit == 0)
                                    continue;
                                HtmlTable tblInstituteReportForInstitute = new HtmlTable();
                                tblInstituteReportForInstitute.CellSpacing = 0;
                                tblInstituteReportForInstitute.Attributes.Add("class", "AppFormTable");
                                tblInstituteReportForInstitute.Rows.Add(createTableRow(new string[] { "Sr. No.", "CAP Round", "Merit No", "Merit Marks", "Entrance Exam", "Application ID", "Candidate Name", "Gender", "Candidature Type", "Home University", "Category / Orphan", "PH Type / Defence Type", "Eligibility Percentage", "Seat Type", "Fees Paid (<span class='rupee'>Rs.</span>)", "Admission Date", "Uploaded Date" }, "Header"));

                                tblInstituteReportForInstitute.Rows[0].Cells[0].Width = "4%";
                                tblInstituteReportForInstitute.Rows[0].Cells[1].Width = "6%";
                                tblInstituteReportForInstitute.Rows[0].Cells[2].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[3].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[4].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[5].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[6].Width = "15%";
                                tblInstituteReportForInstitute.Rows[0].Cells[7].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[8].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[9].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[10].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[11].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[12].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[13].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[14].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[15].Width = "5%";
                                tblInstituteReportForInstitute.Rows[0].Cells[16].Width = "5%";

                                tblInstituteReportForInstitute.Rows[0].Cells[0].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[1].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[2].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[3].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[4].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[5].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[6].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[7].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[8].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[9].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[10].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[11].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[12].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[13].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[14].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[15].Align = "Center";
                                tblInstituteReportForInstitute.Rows[0].Cells[16].Align = "Center";

                                for (Int32 i = (j - 1) * Limit + 1; i <= dsAdmittedCandidateList.Tables[l].Rows.Count && i <= j * Limit; i++)
                                {
                                    SrNo = SrNo + 1;

                                    tblInstituteReportForInstitute.Rows.Add(createTableRow(new string[] { SrNo.ToString() + ".", dsAdmittedCandidateList.Tables[l].Rows[i - 1]["CAPRoundAdmitted"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["MeritNo"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["MeritMarks"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["AdmissionDoneOn"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["ApplicationID"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["CandidateName"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["Gender"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["FinalCandidatureType"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["FinalHomeUniversity"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["AdmissionCategory"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["FinalPHType_FinalDefenceType"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["EligibilityPercentage"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["SeatTypeAdmitted"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["FeesPaid"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["AdmissionDate"].ToString(), dsAdmittedCandidateList.Tables[l].Rows[i - 1]["ReportingDate"].ToString() }, "InnerText"));
                                    int m = i % Limit;
                                    if (m == 0)
                                    {
                                        m = Limit;
                                    }
                                    tblInstituteReportForInstitute.Rows[m].Cells[0].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[1].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[2].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[3].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[4].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[5].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[6].Align = "Left";
                                    tblInstituteReportForInstitute.Rows[m].Cells[7].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[8].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[9].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[10].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[11].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[12].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[13].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[14].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[15].Align = "Center";
                                    tblInstituteReportForInstitute.Rows[m].Cells[16].Align = "Center";
                                }

                                divCandidateReportHolder.Controls.Add(new LiteralControl("<table class='AppFormTableWithOutBorder'><tr><td style='width:7%;' align='center'><img src='../Images/dtelogo.jpg' /></td><td style='width:93%;' align='center'><b><font size='4'>S</font><font size='2'>TATE</font> <font size='4'>C</font><font size='2'>OMMON</font> <font size='4'>E</font><font size='2'>NTRANCE</font> <font size='4'>T</font><font size='2'>EST</font> <font size='4'>C</font><font size='2'>ELL,</font> <font size='4'>M</font><font size='2'>AHARASHTRA</font> <font size='4'>S</font><font size='2'>TATE</font></b><br /><font size = '1'><b>8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</b></font><br /><br /><font size = '2'><b>List of Candidates Admitted to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year 2024-25</b></font><br /><br /><font size = '2' color='red'><b>Institution Name [Code] :- " + InstituteName + " [" + ChoiceCodeD + "]<br />Course Name [Choice Code] :- " + CourseName + " [" + ChoiceCodeDisplay + "]</font></b><br /><br /><font size = '2'><b>" +
                                    (
                                        l == 0 ? "List of Candidates Admitted Under CAP (Excluding Minority) Seats" :
                                        l == 1 ? "List of Candidates Admitted Under CAP (Minority) Seats" :
                                        l == 2 ? "List of Candidates Admitted Under Against CAP (Excluding Minority) Vacant Seats" :
                                        l == 3 ? "List of Candidates Admitted Under Against CAP (Minority) Vacant Seats" :
                                        l == 4 ? "List of Candidates Admitted Under Institutional Seats" :
                                        l == 5 ? "List of Candidates Admitted Under EWS Seats" :
                                        "List of Candidates Admitted Under Supernumerary / Over and Above Seats [NRI / PIO / CIWGC / FN / PMSSS / NEUT / J&K Migrant]") + "</b></font></td></tr><tr><td colspan='2'><font size = '2'><b>&nbsp;&nbsp;Number of Seats : " + Intake[l] + "</b></td></tr></table>"));
                                divCandidateReportHolder.Controls.Add(tblInstituteReportForInstitute);
                                divCandidateReportHolder.Controls.Add(new LiteralControl("<br /><br /><table style='font-family:Verdana;color:#000000' width='100%'><tr><td align='left' style='font-weight:bold;font-size:12px'>Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now) + "</td><td align='center' style='font-weight:bold;font-size:12px;'>Seal of the Institute&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Signature of the Director/Principal</td><td align='right' style='font-weight:bold;font-size:12px;'>Page No : " + CurrentPage.ToString() + "/" + TotalPages.ToString() + "</td></tr></table><div style='PAGE-BREAK-AFTER: always'></div>"));
                                CurrentPage = CurrentPage + 1;
                            }
                        }

                        DataSet ds = reg.getCompositeReportByChoiceCode(ChoiceCode);

                        HtmlTable tblInstituteSummary = new HtmlTable();
                        tblInstituteSummary.CellSpacing = 0;
                        tblInstituteSummary.Attributes.Add("class", "AppFormTable");

                        tblInstituteSummary.Rows.Add(createTableRow(new string[] { "Sr. No.", "Admission Details", "Intake", "Admitted", "Vacancy", "", "Sr. No.", "Admission Details", "Intake", "Admitted", "Vacancy" }, "Header"));

                        tblInstituteSummary.Rows[0].Cells[0].Width = "5%";
                        tblInstituteSummary.Rows[0].Cells[1].Width = "20%";
                        tblInstituteSummary.Rows[0].Cells[2].Width = "10%";
                        tblInstituteSummary.Rows[0].Cells[3].Width = "10%";
                        tblInstituteSummary.Rows[0].Cells[4].Width = "5%";
                        tblInstituteSummary.Rows[0].Cells[5].Width = "5%";
                        tblInstituteSummary.Rows[0].Cells[6].Width = "20%";
                        tblInstituteSummary.Rows[0].Cells[7].Width = "10%";
                        tblInstituteSummary.Rows[0].Cells[8].Width = "10%";
                        tblInstituteSummary.Rows[0].Cells[9].Width = "10%";

                        tblInstituteSummary.Rows[0].Cells[0].Align = "Center";
                        tblInstituteSummary.Rows[0].Cells[1].Align = "Center";
                        tblInstituteSummary.Rows[0].Cells[2].Align = "Center";
                        tblInstituteSummary.Rows[0].Cells[3].Align = "Center";

                        tblInstituteSummary.Rows[0].Cells[4].Align = "Center";
                        tblInstituteSummary.Rows[0].Cells[5].Align = "Center";
                        tblInstituteSummary.Rows[0].Cells[6].Align = "Center";
                        tblInstituteSummary.Rows[0].Cells[7].Align = "Center";
                        tblInstituteSummary.Rows[0].Cells[8].Align = "Center";
                        tblInstituteSummary.Rows[0].Cells[9].Align = "Center";

                        tblInstituteSummary.Rows[0].Cells[5].RowSpan = 8;
                        tblInstituteSummary.Rows[0].Cells[5].BgColor = "White";
                        tblInstituteSummary.Rows.Add(createTableRow(new string[] { "1.", "CAP (Excluding Minority)", ds.Tables[0].Rows[0]["CAPIntake"].ToString(), ds.Tables[0].Rows[0]["CAPAdmitted"].ToString(), ds.Tables[0].Rows[0]["CAPVacancy1"].ToString(), "1.", "EWS", ds.Tables[0].Rows[0]["EWSIntake"].ToString(), ds.Tables[0].Rows[0]["EWSAdmitted"].ToString(), ds.Tables[0].Rows[0]["EWSVacancy"].ToString() }, "InnerText"));

                        tblInstituteSummary.Rows[1].Cells[0].Align = "Center";
                        tblInstituteSummary.Rows[1].Cells[1].Align = "Right";
                        tblInstituteSummary.Rows[1].Cells[2].Align = "Center";
                        tblInstituteSummary.Rows[1].Cells[3].Align = "Center";
                        tblInstituteSummary.Rows[1].Cells[4].Align = "Center";
                        tblInstituteSummary.Rows[1].Cells[5].Align = "Center";
                        tblInstituteSummary.Rows[1].Cells[6].Align = "Right";
                        tblInstituteSummary.Rows[1].Cells[7].Align = "Center";
                        tblInstituteSummary.Rows[1].Cells[8].Align = "Center";
                        tblInstituteSummary.Rows[1].Cells[9].Align = "Center";

                        tblInstituteSummary.Rows[1].Cells[2].RowSpan = 2;
                        tblInstituteSummary.Rows[1].Cells[4].RowSpan = 2;

                        tblInstituteSummary.Rows.Add(createTableRow(new string[] { "2.", "Against CAP (Excluding Minority)", ds.Tables[0].Rows[0]["ACAPAdmitted"].ToString(), "2.", "J&K Migrant", ds.Tables[0].Rows[0]["JKIntake"].ToString(), ds.Tables[0].Rows[0]["JKAdmitted"].ToString(), ds.Tables[0].Rows[0]["JKVacancy"].ToString() }, "InnerText"));

                        tblInstituteSummary.Rows[2].Cells[0].Align = "Center";
                        tblInstituteSummary.Rows[2].Cells[1].Align = "Right";
                        tblInstituteSummary.Rows[2].Cells[2].Align = "Center";
                        tblInstituteSummary.Rows[2].Cells[3].Align = "Center";
                        tblInstituteSummary.Rows[2].Cells[4].Align = "Right";
                        tblInstituteSummary.Rows[2].Cells[5].Align = "Center";
                        tblInstituteSummary.Rows[2].Cells[6].Align = "Center";
                        tblInstituteSummary.Rows[2].Cells[7].Align = "Center";


                        tblInstituteSummary.Rows.Add(createTableRow(new string[] { "3.", "CAP (Minority)", ds.Tables[0].Rows[0]["CAPMIIntake"].ToString(), ds.Tables[0].Rows[0]["CAPMIAdmitted"].ToString(), ds.Tables[0].Rows[0]["CAPMIVacancy1"].ToString(), "3.", "NRI/OCI/PIO/FNS/CIWGC/JKSSS/NEUT", "", ds.Tables[0].Rows[0]["OthersAdmitted"].ToString(), "" }, "InnerText"));

                        tblInstituteSummary.Rows[3].Cells[0].Align = "Center";
                        tblInstituteSummary.Rows[3].Cells[1].Align = "Right";
                        tblInstituteSummary.Rows[3].Cells[2].Align = "Center";
                        tblInstituteSummary.Rows[3].Cells[3].Align = "Center";
                        tblInstituteSummary.Rows[3].Cells[4].Align = "Center";
                        tblInstituteSummary.Rows[3].Cells[5].Align = "Center";
                        tblInstituteSummary.Rows[3].Cells[6].Align = "Right";
                        tblInstituteSummary.Rows[3].Cells[7].Align = "Center";
                        tblInstituteSummary.Rows[3].Cells[8].Align = "Center";
                        tblInstituteSummary.Rows[3].Cells[2].RowSpan = 2;
                        tblInstituteSummary.Rows[3].Cells[4].RowSpan = 2;

                        tblInstituteSummary.Rows.Add(createTableRow(new string[] { "4.", "Against CAP (Minority)", ds.Tables[0].Rows[0]["ACAPMIAdmitted"].ToString(), "" }, "InnerText"));

                        tblInstituteSummary.Rows[4].Cells[0].Align = "Center";
                        tblInstituteSummary.Rows[4].Cells[1].Align = "Right";
                        tblInstituteSummary.Rows[4].Cells[2].Align = "Center";
                        //  tblInstituteSummary.Rows[4].Cells[3].Align = "Center";
                        //  tblInstituteSummary.Rows[4].Cells[4].Align = "Center";
                        tblInstituteSummary.Rows[4].Cells[3].RowSpan = 2;
                        tblInstituteSummary.Rows[4].Cells[3].ColSpan = 5;
                        tblInstituteSummary.Rows.Add(createTableRow(new string[] { "5.", "Institute Level", ds.Tables[0].Rows[0]["ILIntake"].ToString(), ds.Tables[0].Rows[0]["ILAdmitted"].ToString(), ds.Tables[0].Rows[0]["ILVacancy"].ToString() }, "InnerText"));

                        tblInstituteSummary.Rows[5].Cells[0].Align = "Center";
                        tblInstituteSummary.Rows[5].Cells[1].Align = "Right";
                        tblInstituteSummary.Rows[5].Cells[2].Align = "Center";
                        tblInstituteSummary.Rows[5].Cells[3].Align = "Center";
                        tblInstituteSummary.Rows[5].Cells[4].Align = "Center";



                        Int32 totalIntake = Convert.ToInt32(ds.Tables[0].Rows[0]["CAPIntake"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["CAPMIIntake"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["ILIntake"]);
                        Int32 totalAdmitted = Convert.ToInt32(ds.Tables[0].Rows[0]["CAPAdmitted"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["ACAPAdmitted"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["CAPMIAdmitted"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["ACAPMIAdmitted"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["ILAdmitted"]);
                        Int32 totalVacancy = Convert.ToInt32(ds.Tables[0].Rows[0]["CAPVacancy1"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["CAPMIVacancy1"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["ILVacancy"]);

                        Int32 totalIntake1 = Convert.ToInt32(ds.Tables[0].Rows[0]["EWSIntake"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["JKIntake"]);
                        Int32 totalAdmitted1 = Convert.ToInt32(ds.Tables[0].Rows[0]["EWSAdmitted"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["JKAdmitted"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["OthersAdmitted"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["OAAAdmitted"]);

                        Int32 totalVacancy1 = Convert.ToInt32(ds.Tables[0].Rows[0]["JKVacancy"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["EWSVacancy"]);

                        tblInstituteSummary.Rows.Add(createTableRow(new string[] { "", "Total", totalIntake.ToString(), totalAdmitted.ToString(), totalVacancy.ToString(), "", "Total", totalIntake1.ToString(), totalAdmitted1.ToString(), totalVacancy1.ToString() }, "Header"));

                        tblInstituteSummary.Rows[6].Cells[0].Align = "Center";
                        tblInstituteSummary.Rows[6].Cells[1].Align = "Right";
                        tblInstituteSummary.Rows[6].Cells[2].Align = "Center";
                        tblInstituteSummary.Rows[6].Cells[3].Align = "Center";
                        tblInstituteSummary.Rows[6].Cells[4].Align = "Center";
                        tblInstituteSummary.Rows[6].Cells[5].Align = "Center";
                        tblInstituteSummary.Rows[6].Cells[6].Align = "Center";
                        tblInstituteSummary.Rows[6].Cells[7].Align = "Center";
                        tblInstituteSummary.Rows[6].Cells[8].Align = "Center";
                        tblInstituteSummary.Rows[6].Cells[9].Align = "Center";

                        divCandidateReportHolder.Controls.Add(new LiteralControl("<table class='AppFormTableWithOutBorder'><tr><td style='width:7%;' align='center'><img src='../Images/dtelogo.jpg' /></td><td style='width:93%;' align='center'><b><font size='4'>S</font><font size='2'>TATE</font> <font size='4'>C</font><font size='2'>OMMON</font> <font size='4'>E</font><font size='2'>NTRANCE</font> <font size='4'>T</font><font size='2'>EST</font> <font size='4'>C</font><font size='2'>ELL,</font> <font size='4'>M</font><font size='2'>AHARASHTRA</font> <font size='4'>S</font><font size='2'>TATE</font><br /><font size = '1'>8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font><br /><br /><font size = '2'>Summary of Admitted Candidates for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year 2024-25</font></b><br /><br /><font size = '2' color='red'><b>Institution Name [Code] :- " + InstituteName + " [" + ChoiceCodeD + "]<br />Course Name [Choice Code] :- " + CourseName + " [" + ChoiceCodeDisplay + "]</b></font><br /><br /></td></tr></table>"));
                        divCandidateReportHolder.Controls.Add(tblInstituteSummary);
                        divCandidateReportHolder.Controls.Add(new LiteralControl("<font size = '1' color='#000000'><b>Seat Type used for Institute Level Admissions :</b> ACAP-Against CAP (Excluding Minority), IL-Institute Level, ILNRI-Institute Level NRI (5% of SI if AICTE Permission), MI-Minority, NRI-NRI (15% of SI if AICTE Permission), PIO-PIO (15% of SI if AICTE Permission), FNS-FNS (15% of SI if AICTE Permission), CIWGC-Children's of Indian Workers in Gulf Countries (15% of SI if AICTE Permission), JKSSS - Prime Minister Special Scholarship Scheme, NEUT - North Eastern States and UTs, EWS-Economically Weaker Section, OAA-Over and Above</font><br />"));
                        divCandidateReportHolder.Controls.Add(new LiteralControl("<font size = '1' color='#000000'><b>Home University used for Admissions :</b> DBAMU - Dr. B. A. Marathwada University, GU	- Gondwana University, MU -	Mumbai University, NMU - Kavayitri Bahinabai Chaudhari North Maharashtra University, Jalgaon, RTMNU - Rashtrasant Tukadoji Maharaj Nagpur University, SGBAU - Sant Gadge Baba Amravati University, SOLU - Punyashlok Ahilyadevi Holkar Solapur University, SPPU - Savitribai Phule Pune University, SRTMU - S. R. T. Marathwada University, SVJU - Shivaji University, NA - Not Applicable</font><br /><br />"));

                        divCandidateReportHolder.Controls.Add(new LiteralControl("<font size = '2' color='#000000' style='font-family:Verdana;'><b>Admisions Cancelled after Cut-Off Date : " + ds.Tables[0].Rows[0]["CancelledAfterCutOffDate"].ToString() + "</b></font><br /><br />"));

                        divCandidateReportHolder.Controls.Add(new LiteralControl("<font size = '2' color='#000000' style='font-family:Verdana;'><b>Cut-Off Date for Admission : 23/12/2024<br />Cut-Off Date for Uploading : 23/12/2024</b></font><br /><br />"));
                        divCandidateReportHolder.Controls.Add(new LiteralControl("<br /><br /><table style='font-family:Verdana;color:#000000' width='100%'><tr><td align='left' style='font-weight:bold;font-size:12px'>Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now) + "</td><td align='center' style='font-weight:bold;font-size:12px;'>Seal of the Institute</td><td align='right' style='font-weight:bold;font-size:12px;'>Signature of the Director/Principal</td><td align='center' style='font-weight:bold;font-size:12px'>Submitted On : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr></table>"));
                        divCandidateReportHolder.Controls.Add(new LiteralControl("<hr style ='color:#000000' />"));
                        divCandidateReportHolder.Controls.Add(new LiteralControl("<center><table style='font-family:Verdana;color:#000000' width='50%'><tr><td align='center' colspan = '3' style='font-weight:bold;font-size:12px'>For Regional Office Use Only<br /><br /><br /><br /></td></tr><tr><td align='left' style='font-weight:bold;font-size:12px;'>Seal of the Regional Office</td><td align='right' style='font-weight:bold;font-size:12px;'>Signature of the Regional Officer</td></tr></table></center>"));
                    }
                    catch (Exception ex)
                    {
                        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                    }
                }
            }
        }
        protected HtmlTableCell createTableCell(string data, string className)
        {
            HtmlTableCell cell = new HtmlTableCell();
            if (className == "Header")
            {
                cell.InnerHtml = "<b>" + data + "</b>";
                cell.BgColor = "#d8d8d8";
            }
            else
            {
                cell.InnerText = data;
            }
            return cell;
        }
        protected HtmlTableRow createTableRow(string[] cellData, string className)
        {
            HtmlTableRow row = new HtmlTableRow();
            for (Int32 i = 0; i < cellData.Length; i++)
            {
                row.Cells.Add(createTableCell(cellData[i], className));
            }
            return row;
        }
    }
}