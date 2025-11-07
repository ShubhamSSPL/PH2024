using BusinessLayer;
using Pharmacy2024;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class ApplicationStatestics : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            Int32 UserTypeID = 21;
            string UserLoginID = "Devendra";

            tblDashboard.Visible = true;

            //DataSet ds = new DBUtilityWelcomePageAFC().getDateWiseConfirmedCandidateCount(UserTypeID, UserLoginID,"ALL");

            //lblCAPConfirmed.Text = ds.Tables[0].Rows[0]["CAP"].ToString();
            //lblNonCAPConfirmed.Text = ds.Tables[0].Rows[0]["NonCAP"].ToString();
            lblHeader1.Text = "Statistics for the Academic Year" + AdmissionYear;
            btnFE.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
            btnPH.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
            LoadData("ALL");

            trAll.Visible = true;
            trFC.Visible = false;
            trCategory.Visible = false;
            trCVC.Visible = false;
            trNCL.Visible = false;

            //trWebSiteNavigation2.Visible = false;
            //trWebSiteNavigation1.Visible = false;
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {

            btnAll.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            btnAll.BackColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");

            btnFE.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
            btnFE.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            btnPH.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
            btnPH.BackColor = System.Drawing.ColorTranslator.FromHtml("white");

            lblHeader1.Text = "Statistics for the Academic Year "+ AdmissionYear;

            LoadData("ALL");
            trAll.Visible = true;
            trFC.Visible = false;
            trCategory.Visible = false;
            trCVC.Visible = false;
            trNCL.Visible = false;
        }

        protected void btnFE_Click(object sender, EventArgs e)
        {
            btnFE.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            btnFE.BackColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
            btnPH.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
            btnPH.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            btnAll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
            btnAll.BackColor = System.Drawing.ColorTranslator.FromHtml("white");

            lblHeader1.Text = "Statistics for Engineering and Technology for the Academic Year "+ AdmissionYear;

            LoadData("FE");

            trAll.Visible = false;
            trFC.Visible = true;
            trCategory.Visible = true;
            trCVC.Visible = true;
            trNCL.Visible = true;
        }

        protected void btnPH_Click(object sender, EventArgs e)
        {
            btnFE.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
            btnFE.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            btnPH.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
            btnPH.BackColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
            btnAll.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
            btnAll.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            lblHeader1.Text = "Statistics for B.Pharmacy & Post Graduate Pharm.D for the Academic Year " + AdmissionYear;

            LoadData("PH");

            trAll.Visible = false;
            trFC.Visible = true;
            trCategory.Visible = true;
            trCVC.Visible = true;
            trNCL.Visible = true;
        }

        protected void LoadData(string Degree)
        {
            DataSet ds = new DBUtilityWelcomePageAFC().getCVCNCLCount(Degree);
            Int64 Total = 0;

            if (Degree == "ALL")
            {
                gvApplicationStatusReportAll.DataSource = ds.Tables[0];
                gvApplicationStatusReportAll.DataBind();
            }
            else
            {
                gvApplicationStatusReport.DataSource = ds.Tables[0];
                gvApplicationStatusReport.DataBind();

                gvCategoryWiseReport.DataSource = ds.Tables[1];
                gvCategoryWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvCategoryWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvCategoryWiseReport.Rows[i].Cells[1].Text));
                }
                gvCategoryWiseReport.FooterRow.Cells[0].Text = "Total";
                gvCategoryWiseReport.FooterRow.Cells[1].Text = Total.ToString();


                gvCVCStatus.DataSource = ds.Tables[2];
                gvCVCStatus.DataBind();

                Int64 Total1 = 0;
                Int64 Total2 = 0;
                Int64 Total3 = 0;
                Int64 Total4 = 0;
                Int64 Total5 = 0;
                Int64 Total6 = 0;
                Int64 Total7 = 0;
                Int64 Total8 = 0;
                Int64 Total9 = 0;
                Int64 Total10 = 0;

                for (Int32 i = 0; i < gvCVCStatus.Rows.Count; i++)
                {
                    Total1 += Convert.ToInt64((gvCVCStatus.Rows[i].Cells[1].Text));
                    Total2 += Convert.ToInt64((gvCVCStatus.Rows[i].Cells[2].Text));
                    Total3 += Convert.ToInt64((gvCVCStatus.Rows[i].Cells[3].Text));
                    //Total4 += Convert.ToInt64((gvCVCStatus.Rows[i].Cells[4].Text));
                    //Total5 += Convert.ToInt64((gvCVCStatus.Rows[i].Cells[5].Text));
                    //Total6 += Convert.ToInt64((gvCVCStatus.Rows[i].Cells[6].Text));
                    //Total7 += Convert.ToInt64((gvCVCStatus.Rows[i].Cells[7].Text));
                    //Total8 += Convert.ToInt64((gvCVCStatus.Rows[i].Cells[8].Text));
                    //Total9 += Convert.ToInt64((gvCVCStatus.Rows[i].Cells[9].Text));
                    //Total10 += Convert.ToInt64((gvCVCStatus.Rows[i].Cells[10].Text));
                }
                gvCVCStatus.FooterRow.Cells[0].Text = "Total";
                gvCVCStatus.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gvCVCStatus.FooterRow.Cells[1].Text = Total1.ToString();
                gvCVCStatus.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                gvCVCStatus.FooterRow.Cells[2].Text = Total2.ToString();
                gvCVCStatus.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                gvCVCStatus.FooterRow.Cells[3].Text = Total3.ToString();
                gvCVCStatus.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                //gvCVCStatus.FooterRow.Cells[4].Text = Total4.ToString();
                //gvCVCStatus.FooterRow.Cells[5].Text = Total5.ToString();
                //gvCVCStatus.FooterRow.Cells[6].Text = Total6.ToString();
                //gvCVCStatus.FooterRow.Cells[7].Text = Total7.ToString();
                //gvCVCStatus.FooterRow.Cells[8].Text = Total8.ToString();
                //gvCVCStatus.FooterRow.Cells[9].Text = Total9.ToString();
                //gvCVCStatus.FooterRow.Cells[10].Text = Total10.ToString();


                gvNCLStatus.DataSource = ds.Tables[3];
                gvNCLStatus.DataBind();

                Int64 nTotal1 = 0;
                Int64 nTotal2 = 0;
                Int64 nTotal3 = 0;
                Int64 nTotal4 = 0;
                Int64 nTotal5 = 0;
                Int64 nTotal6 = 0;
                Int64 nTotal7 = 0;
                Int64 nTotal8 = 0;

                for (Int32 i = 0; i < gvNCLStatus.Rows.Count; i++)
                {
                    nTotal1 += Convert.ToInt64((gvNCLStatus.Rows[i].Cells[1].Text));
                    nTotal2 += Convert.ToInt64((gvNCLStatus.Rows[i].Cells[2].Text));
                    nTotal3 += Convert.ToInt64((gvNCLStatus.Rows[i].Cells[3].Text));
                    //nTotal4 += Convert.ToInt64((gvNCLStatus.Rows[i].Cells[4].Text));
                    //nTotal5 += Convert.ToInt64((gvNCLStatus.Rows[i].Cells[5].Text));
                    //nTotal6 += Convert.ToInt64((gvNCLStatus.Rows[i].Cells[6].Text));
                    //nTotal7 += Convert.ToInt64((gvNCLStatus.Rows[i].Cells[7].Text));
                    //nTotal8 += Convert.ToInt64((gvNCLStatus.Rows[i].Cells[8].Text));
                }
                gvNCLStatus.FooterRow.Cells[0].Text = "Total";
                gvNCLStatus.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gvNCLStatus.FooterRow.Cells[1].Text = nTotal1.ToString();
                gvNCLStatus.FooterRow.Cells[2].Text = nTotal2.ToString();
                gvNCLStatus.FooterRow.Cells[3].Text = nTotal3.ToString();
                //gvNCLStatus.FooterRow.Cells[4].Text = nTotal4.ToString();
                //gvNCLStatus.FooterRow.Cells[5].Text = nTotal5.ToString();
                //gvNCLStatus.FooterRow.Cells[6].Text = nTotal6.ToString();
                //gvNCLStatus.FooterRow.Cells[7].Text = nTotal7.ToString();
                //gvNCLStatus.FooterRow.Cells[8].Text = nTotal8.ToString();
                gvNCLStatus.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                gvNCLStatus.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                gvNCLStatus.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        //protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        IApplicationContext ctx = ContextRegistry.GetContext();
        //        IServices reg = (IServices)ctx.GetObject("Services");

        //        Int32 UserTypeID = 21;
        //        string UserLoginID = "100";

        //        DataSet ds = new DBUtilityWelcomePageAFC().getDateWiseConfirmedCandidateCount(UserTypeID, UserLoginID, ddlDate.SelectedValue);

        //        lblCAPConfirmed.Text = ds.Tables[0].Rows[0]["CAP"].ToString();
        //        lblNonCAPConfirmed.Text = ds.Tables[0].Rows[0]["NonCAP"].ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
        //protected void ddlDashboard_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        IApplicationContext ctx = ContextRegistry.GetContext();
        //        IServices reg = (IServices)ctx.GetObject("Services");

        //        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
        //        string UserLoginID = Session["UserLoginID"].ToString();

        //        DataSet dsDashboard = reg.getDashboardAFC(UserTypeID, UserLoginID, ddlDashboard.SelectedValue);
        //        Int64 Total = 0;

        //        gvApplicationStatusReport.DataSource = dsDashboard.Tables[0];
        //        gvApplicationStatusReport.DataBind();

        //        gvCandidatureTypeWiseReport.DataSource = dsDashboard.Tables[1];
        //        gvCandidatureTypeWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvCandidatureTypeWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvCandidatureTypeWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvCandidatureTypeWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvCandidatureTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        gvHomeUniversityWiseReport.DataSource = dsDashboard.Tables[2];
        //        gvHomeUniversityWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvHomeUniversityWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvHomeUniversityWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvHomeUniversityWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvHomeUniversityWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        gvCategoryWiseReport.DataSource = dsDashboard.Tables[3];
        //        gvCategoryWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvCategoryWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvCategoryWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvCategoryWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvCategoryWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        gvPHTypeWiseReport.DataSource = dsDashboard.Tables[4];
        //        gvPHTypeWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvPHTypeWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvPHTypeWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvPHTypeWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvPHTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        gvDefenceTypeWiseReport.DataSource = dsDashboard.Tables[5];
        //        gvDefenceTypeWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvDefenceTypeWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvDefenceTypeWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvDefenceTypeWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvDefenceTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        gvGenderWiseReport.DataSource = dsDashboard.Tables[6];
        //        gvGenderWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvGenderWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvGenderWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvGenderWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvGenderWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        gvReligionWiseReport.DataSource = dsDashboard.Tables[7];
        //        gvReligionWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvReligionWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvReligionWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvReligionWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvReligionWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        gvRegionWiseReport.DataSource = dsDashboard.Tables[8];
        //        gvRegionWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvRegionWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvRegionWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvRegionWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvRegionWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        gvMotherTongueWiseReport.DataSource = dsDashboard.Tables[9];
        //        gvMotherTongueWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvMotherTongueWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvMotherTongueWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvMotherTongueWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvMotherTongueWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        gvAnnualFamilyIncomeWiseReport.DataSource = dsDashboard.Tables[10];
        //        gvAnnualFamilyIncomeWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvAnnualFamilyIncomeWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvAnnualFamilyIncomeWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvAnnualFamilyIncomeWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvAnnualFamilyIncomeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        gvHSCBoardWiseReport.DataSource = dsDashboard.Tables[11];
        //        gvHSCBoardWiseReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvHSCBoardWiseReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvHSCBoardWiseReport.Rows[i].Cells[1].Text));
        //        }
        //        gvHSCBoardWiseReport.FooterRow.Cells[0].Text = "Total";
        //        gvHSCBoardWiseReport.FooterRow.Cells[1].Text = Total.ToString();

        //        if (dsDashboard.Tables[12].Rows.Count > 0)
        //        {
        //            gvHSCPassingYearWiseReport.DataSource = dsDashboard.Tables[12];
        //            gvHSCPassingYearWiseReport.DataBind();
        //            Total = 0;
        //            for (Int32 i = 0; i < gvHSCPassingYearWiseReport.Rows.Count; i++)
        //            {
        //                Total += Convert.ToInt64((gvHSCPassingYearWiseReport.Rows[i].Cells[1].Text));
        //            }
        //            gvHSCPassingYearWiseReport.FooterRow.Cells[0].Text = "Total";
        //            gvHSCPassingYearWiseReport.FooterRow.Cells[1].Text = Total.ToString();
        //        }

        //        gvMinorityReport.DataSource = dsDashboard.Tables[13];
        //        gvMinorityReport.DataBind();
        //        Total = 0;
        //        for (Int32 i = 0; i < gvMinorityReport.Rows.Count; i++)
        //        {
        //            Total += Convert.ToInt64((gvMinorityReport.Rows[i].Cells[1].Text));
        //        }
        //        gvMinorityReport.FooterRow.Cells[0].Text = "Total";
        //        gvMinorityReport.FooterRow.Cells[1].Text = Total.ToString();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }

    public class DBUtilityWelcomePageAFC 
    {
        public DataSet getDateWiseConfirmedCandidateCount(Int32 UserTypeID, string UserLoginID, string Date)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@UserTypeID",SqlDbType.Int),
            new SqlParameter("@UserLoginID",SqlDbType.VarChar,50),
            new SqlParameter("@Date",SqlDbType.VarChar,50),
        };
            parameters[0].Value = UserTypeID;
            parameters[1].Value = UserLoginID;
            parameters[2].Value = Date;
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetDateWiseConfirmedCandidateCount_ForDashBoard", new SqlParameter[]
                {

                });
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataSet getCVCNCLCount(string Degree)
        {
            SqlParameter[] parameters =
            {

            new SqlParameter("@Degree",SqlDbType.VarChar,50),
        };
            parameters[0].Value = Degree;
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetCVCNCLCount_ForDashBoard", new SqlParameter[]
                {

                });
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}