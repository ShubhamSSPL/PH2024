using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ApplicationPages
{
    public partial class WelcomePageAFC : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
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
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                    string UserLoginID = Session["UserLoginID"].ToString();

                    ddlWebSite.DataSource = Global.MasterWebSite;
                    ddlWebSite.DataTextField = "WebSiteName";
                    ddlWebSite.DataValueField = "WebSiteURL";
                    ddlWebSite.OptionGroupField = "WebSiteGroup";
                    ddlWebSite.DataBind();
                    ListItem liWebSite = new ListItem("-- Select WebSite --", "0");
                    liWebSite.Attributes.Add("DataGroupField", "");
                    //ddlWebSite.Items.Insert(0, liWebSite);

                    ddlDate.DataSource = reg.getConfirmationDateList();
                    ddlDate.DataTextField = "ConfirmedDateTime";
                    ddlDate.DataValueField = "ConfirmedDateTime";
                    ddlDate.DataBind();
                    ddlDate.Items.Insert(0, new ListItem("ALL", "ALL"));

                    DataSet dsLoginDetails = reg.getLoginDetails(UserLoginID, UserTypeID);
                    if (dsLoginDetails.Tables[0].Rows.Count > 0)
                    {
                        lblLoginID.Text = dsLoginDetails.Tables[0].Rows[0]["LoginID"].ToString();
                        lblUserName.Text = dsLoginDetails.Tables[0].Rows[0]["UserName"].ToString();
                        lblUserType.Text = dsLoginDetails.Tables[0].Rows[0]["UserTypeName"].ToString();
                        DateTime CurrentLoginDateTime = Convert.ToDateTime(dsLoginDetails.Tables[0].Rows[0]["CurrentLoginDateTime"].ToString());
                        lblCurrentLoginTime.Text = CurrentLoginDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", CurrentLoginDateTime);
                        DateTime LastLoginDateTime = Convert.ToDateTime(dsLoginDetails.Tables[0].Rows[0]["LastLoginDateTime"].ToString());
                        lblPreviousLoginTime.Text = LastLoginDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", LastLoginDateTime);
                        lblIPAddress.Text = UserInfo.GetIPAddress();
                    }
                    trDashboardType.Visible = false;
                    tblDocVerification.Visible = false;
                    if (UserTypeID == 21)
                    {
                        trDashboardType.Visible = true;
                    }
                    char isEFC = ' ';
                    bool isARCReportingStarted = false;
                    if
                            (
                                (Global.CurrentCAPRoundForARCReporting == 1 &&
                                 DateTime.Now >= Global.ARCReportingCAPRound1StartDateTime &&
                                 DateTime.Now <= Global.ARCReportingCAPRound1EndDateTime) ||
                                (Global.CurrentCAPRoundForARCReporting == 2 &&
                                 DateTime.Now >= Global.ARCReportingCAPRound2StartDateTime &&
                                 DateTime.Now <= Global.ARCReportingCAPRound2EndDateTime) ||
                                (Global.CurrentCAPRoundForARCReporting == 3 &&
                                 DateTime.Now >= Global.ARCReportingCAPRound3StartDateTime &&
                                 DateTime.Now <= Global.ARCReportingCAPRound3EndDateTime) ||
                                (Global.CurrentCAPRoundForARCReporting == 4 &&
                                 DateTime.Now >= Global.ARCReportingCAPRound4StartDateTime &&
                                 DateTime.Now <= Global.ARCReportingCAPRound4EndDateTime)
                            )
                    {
                        isARCReportingStarted = true;
                    }

                    if (Global.CurrentScrutinyMode == "P" || Global.CurrentScrutinyMode == "Both")
                    {
                        trInstrForPMode.Visible = true;
                    }
                    else
                    {
                        trInstrForPMode.Visible = false;
                    }

                        if (UserTypeID == 21 || UserTypeID == 22 || UserTypeID == 66)
                    {
                        trWebSiteNavigation1.Visible = true;
                        trWebSiteNavigation2.Visible = true;
                    }
                    else if (UserTypeID == 23 || UserTypeID == 24)
                    {
                        AFCProfile objAFCProfile = reg.getAFCProfile(Session["UserLoginID"].ToString());

                        if (objAFCProfile.CoordinatorDesignation.Length == 0)
                        {
                            Response.Redirect("../AFCModule/frmAFCProfile.aspx", true);
                        }
                        isEFC = objAFCProfile.IsEFC;

                        ////--------------------------------------------------------------------------------------------
                        //// Uncomment the following code whne CVC/TVC NCL and EWS document approval Starts( for Receipt Candidates)
                        //tblDocVerification.Visible = true;
                        //tblSAGrievanceDashBoardLinks.Visible = true;
                        //DataSet ds = new DBUtilityWelcomePageAFC().GetCVCNCLEWSVerificationPendingList(UserTypeID, Session["UserLoginID"].ToString());
                        //if (ds.Tables[0].Rows.Count > 0)
                        //    lblCVCTVCCount.Text = ds.Tables[0].Rows.Count.ToString();
                        //else
                        //    lblCVCTVCCount.Text = "0";

                        //DataSet ds1 = new DBUtilityWelcomePageAFC().GetCandidateListForApproval(UserTypeID, Session["UserLoginID"].ToString());
                        //if (ds1.Tables[0].Rows.Count > 0)
                        //    lblCorrectDocument.Text = ds1.Tables[0].Rows.Count.ToString();
                        //else
                        //    lblCorrectDocument.Text = "0";
                        ////--------------------------------------------------------------------------------------------
                    }

                    if (UserTypeID == 21 || UserTypeID == 22 || UserTypeID == 23 || UserTypeID == 24)
                    {
                        if (isEFC == 'Y')// || UserTypeID == 21 || UserTypeID == 22)
                        {
                            tblEFCDashBoardLinks.Visible = true;
                            //tblSAGrievanceDashBoardLinks.Visible = true;
                            if (isARCReportingStarted)
                                tblSAGrievanceDashBoardLinks.Visible = true;
                        }
                        else
                        {
                            tblEFCDashBoardLinks.Visible = false;
                            //tblSAGrievanceDashBoardLinks.Visible = false; //Commint by sharad Seat Acceptance Grievance Status Dashboard Show all FC/SC
                        }
                        tblDashboard.Visible = true;


                        int FCCode = 0;
                        if (UserTypeID != 21)
                        {
                            FCCode = int.Parse(UserLoginID.ToString().Substring(2, 1));
                        }

                        if ((FCCode < 7 && FCCode > 0))
                        {

                            DataSet ds = new DBUtilityWelcomePageAFC().getDateWiseConfirmedCandidateCount(UserTypeID, UserLoginID, ddlDate.SelectedValue);

                            lblCAPConfirmed.Text = ds.Tables[0].Rows[0]["CAP"].ToString();
                            lblNonCAPConfirmed.Text = ds.Tables[0].Rows[0]["NonCAP"].ToString();

                            DataSet dsDashboard = reg.getDashboardAFC(UserTypeID, UserLoginID, ddlDashboard.SelectedValue);
                            Int64 Total = 0;

                            gvApplicationStatusReport.DataSource = dsDashboard.Tables[0];
                            gvApplicationStatusReport.DataBind();

                            gvCandidatureTypeWiseReport.DataSource = dsDashboard.Tables[1];
                            gvCandidatureTypeWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvCandidatureTypeWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvCandidatureTypeWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvCandidatureTypeWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvCandidatureTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvHomeUniversityWiseReport.DataSource = dsDashboard.Tables[2];
                            gvHomeUniversityWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvHomeUniversityWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvHomeUniversityWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvHomeUniversityWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvHomeUniversityWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvCategoryWiseReport.DataSource = dsDashboard.Tables[3];
                            gvCategoryWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvCategoryWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvCategoryWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvCategoryWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvCategoryWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvPHTypeWiseReport.DataSource = dsDashboard.Tables[4];
                            gvPHTypeWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvPHTypeWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvPHTypeWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvPHTypeWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvPHTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvDefenceTypeWiseReport.DataSource = dsDashboard.Tables[5];
                            gvDefenceTypeWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvDefenceTypeWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvDefenceTypeWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvDefenceTypeWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvDefenceTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvGenderWiseReport.DataSource = dsDashboard.Tables[6];
                            gvGenderWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvGenderWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvGenderWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvGenderWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvGenderWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvReligionWiseReport.DataSource = dsDashboard.Tables[7];
                            gvReligionWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvReligionWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvReligionWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvReligionWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvReligionWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvRegionWiseReport.DataSource = dsDashboard.Tables[8];
                            gvRegionWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvRegionWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvRegionWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvRegionWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvRegionWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvMotherTongueWiseReport.DataSource = dsDashboard.Tables[9];
                            gvMotherTongueWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvMotherTongueWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvMotherTongueWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvMotherTongueWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvMotherTongueWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvAnnualFamilyIncomeWiseReport.DataSource = dsDashboard.Tables[10];
                            gvAnnualFamilyIncomeWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvAnnualFamilyIncomeWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvAnnualFamilyIncomeWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvAnnualFamilyIncomeWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvAnnualFamilyIncomeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvHSCBoardWiseReport.DataSource = dsDashboard.Tables[11];
                            gvHSCBoardWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvHSCBoardWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvHSCBoardWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvHSCBoardWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvHSCBoardWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            if (dsDashboard.Tables[12].Rows.Count > 0)
                            {
                                gvHSCPassingYearWiseReport.DataSource = dsDashboard.Tables[12];
                                gvHSCPassingYearWiseReport.DataBind();
                                Total = 0;
                                for (Int32 i = 0; i < gvHSCPassingYearWiseReport.Rows.Count; i++)
                                {
                                    Total += Convert.ToInt64((gvHSCPassingYearWiseReport.Rows[i].Cells[1].Text));
                                }
                                gvHSCPassingYearWiseReport.FooterRow.Cells[0].Text = "Total";
                                gvHSCPassingYearWiseReport.FooterRow.Cells[1].Text = Total.ToString();
                            }

                            gvMinorityReport.DataSource = dsDashboard.Tables[13];
                            gvMinorityReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvMinorityReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvMinorityReport.Rows[i].Cells[1].Text));
                            }
                            gvMinorityReport.FooterRow.Cells[0].Text = "Total";
                            gvMinorityReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvEWSStatusWiseReport.DataSource = dsDashboard.Tables[14];
                            gvEWSStatusWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvEWSStatusWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvEWSStatusWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvEWSStatusWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvEWSStatusWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                            gvOrphanStatusWiseReport.DataSource = dsDashboard.Tables[15];
                            gvOrphanStatusWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvOrphanStatusWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvOrphanStatusWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvOrphanStatusWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvOrphanStatusWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        }
                        else
                        {
                            tblDashboard.Visible = false;
                        }

                        trWebSiteNavigation2.Visible = false;
                        trWebSiteNavigation1.Visible = false;
                        Int16 RegionID = 0;
                        Int32 InstituteID = 0;
                        Int32 AFCID = 0;
                        Int64 TotalApplicationFormsPending = 0;
                        Int64 TotalRevertedBack = 0;
                        Int64 TotalApplicationFormsConfirmed = 0;

                        Int64 TotalSAGNew = 0;
                        Int64 TotalSAGPickedup = 0;
                        Int64 TotalSAGRejected = 0;
                        Int64 TotalSAGApproved = 0;

                        if (UserTypeID == 21) //Admin
                        {
                            DataSet dsBlue = reg.getRegionWiseApplicationFormListForFCVerification();
                            for (Int32 i = 0; i < dsBlue.Tables[0].Rows.Count; i++)
                            {
                                TotalApplicationFormsPending += Convert.ToInt64(dsBlue.Tables[0].Rows[i]["TotalApplicationFormsConfirmed"].ToString());
                            }

                            lblBlueCount.Text = TotalApplicationFormsPending.ToString();
                            if (isARCReportingStarted)
                            {
                                //For SeatAcceptance Grievance Status Dashboard
                                RegionID = 99;
                                InstituteID = 99;

                                DataSet dsSAGNew = reg.GetRegionWiseSeatAcceptanceGrievanceStatus("Y", Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGNew.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGNew += Convert.ToInt64(dsSAGNew.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblNewGrievances.Text = TotalSAGNew.ToString();

                                DataSet dsSAGPickedup = reg.GetRegionWiseSeatAcceptanceGrievanceStatus("P", Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGPickedup.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGPickedup += Convert.ToInt64(dsSAGPickedup.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblPickedupGrievances.Text = TotalSAGPickedup.ToString();

                                DataSet dsSAGRejected = reg.GetRegionWiseSeatAcceptanceGrievanceStatus("R", Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGRejected.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGRejected += Convert.ToInt64(dsSAGRejected.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblRejectedGrievances.Text = TotalSAGRejected.ToString();

                                DataSet dsSAGApproved = reg.GetRegionWiseSeatAcceptanceGrievanceStatus("A", Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGApproved.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGApproved += Convert.ToInt64(dsSAGApproved.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblApprovedGrievances.Text = TotalSAGApproved.ToString();
                            }
                        }
                        else if (UserTypeID == 22) //RO
                        {
                            if (Request.QueryString["RegionID"] != null)
                            {
                                RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                            }
                            else
                            {
                                RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                            }

                            DataSet dsBlue = reg.getAFCWiseApplicationFormListForFCVerification(RegionID);
                            for (Int32 i = 0; i < dsBlue.Tables[0].Rows.Count; i++)
                            {
                                TotalApplicationFormsPending += Convert.ToInt64(dsBlue.Tables[0].Rows[i]["TotalApplicationFormsConfirmed"].ToString());
                            }

                            lblBlueCount.Text = TotalApplicationFormsPending.ToString();
                            if (isARCReportingStarted)
                            {
                                //For SeatAcceptance Grievance Status Dashboard
                                //RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                                InstituteID = 99;

                                DataSet dsSAGNew = reg.GetAFCWiseSeatAcceptanceGrievanceStatus(RegionID, "Y", Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGNew.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGNew += Convert.ToInt64(dsSAGNew.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblNewGrievances.Text = TotalSAGNew.ToString();

                                DataSet dsSAGPickedup = reg.GetAFCWiseSeatAcceptanceGrievanceStatus(RegionID, "P", Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGPickedup.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGPickedup += Convert.ToInt64(dsSAGPickedup.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblPickedupGrievances.Text = TotalSAGPickedup.ToString();

                                DataSet dsSAGRejected = reg.GetAFCWiseSeatAcceptanceGrievanceStatus(RegionID, "R", Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGRejected.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGRejected += Convert.ToInt64(dsSAGRejected.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblRejectedGrievances.Text = TotalSAGRejected.ToString();

                                DataSet dsSAGApproved = reg.GetAFCWiseSeatAcceptanceGrievanceStatus(RegionID, "A", Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGApproved.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGApproved += Convert.ToInt64(dsSAGApproved.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblApprovedGrievances.Text = TotalSAGApproved.ToString();
                            }
                        }

                        else if (UserTypeID == 23) //AFC
                        {
                            lblBlueCount.Text = reg.GetApplicationFormListForFCVerification(Session["UserLoginId"].ToString(), Convert.ToInt16(Session["UserTypeID"].ToString())).Tables[0].Rows.Count.ToString();
                            lblPurpalCount.Text = reg.GetApplicationFormListForPartialFCVerification(Session["UserLoginId"].ToString(), Convert.ToInt16(Session["UserTypeID"].ToString())).Tables[0].Rows.Count.ToString();

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


                            DataSet dsRed = reg.GetSubAFCDiscrepancyMarkedCount(RegionID, InstituteID);
                            for (Int32 i = 0; i < dsRed.Tables[0].Rows.Count; i++)
                            {
                                TotalRevertedBack += Convert.ToInt64(dsRed.Tables[0].Rows[i]["TotalDiscrepancyMarked"].ToString());
                            }
                            lblRedCount.Text = TotalRevertedBack.ToString();


                            DataSet dsGreen = reg.GetSubAFCEConfirmedCount(RegionID, InstituteID);
                            for (Int32 i = 0; i < dsGreen.Tables[0].Rows.Count; i++)
                            {
                                TotalApplicationFormsConfirmed += Convert.ToInt64(dsGreen.Tables[0].Rows[i]["TotalDiscrepancyMarked"].ToString());
                            }
                            lblGreenCount.Text = TotalApplicationFormsConfirmed.ToString();

                            if (isARCReportingStarted)
                            {
                                //For SeatAcceptance Grievance Status Dashboard
                                //RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                                //InstituteID = reg.getInstituteID(Convert.ToInt32(Session["UserID"].ToString()));

                                DataSet dsSAGNew = reg.GetSubAFCWiseSeatAcceptanceGrievanceVerifcationCount(RegionID, InstituteID, Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGNew.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGNew += Convert.ToInt64(dsSAGNew.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblNewGrievances.Text = TotalSAGNew.ToString();

                                DataSet dsSAGPickedup = reg.GetSubAFCWiseSeatAcceptanceGrievancePickedupCount(RegionID, InstituteID, Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGPickedup.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGPickedup += Convert.ToInt64(dsSAGPickedup.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblPickedupGrievances.Text = TotalSAGPickedup.ToString();

                                DataSet dsSAGRejected = reg.GetSubAFCWiseSeatAcceptanceGrievanceRejectedCount(RegionID, InstituteID, Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGRejected.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGRejected += Convert.ToInt64(dsSAGRejected.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblRejectedGrievances.Text = TotalSAGRejected.ToString();

                                DataSet dsSAGApproved = reg.GetSubAFCWiseSeatAcceptanceGrievanceApprovedCount(RegionID, InstituteID, Global.CAPRound);
                                for (Int32 i = 0; i < dsSAGApproved.Tables[0].Rows.Count; i++)
                                {
                                    TotalSAGApproved += Convert.ToInt64(dsSAGApproved.Tables[0].Rows[i]["Cnt"].ToString());
                                }

                                lblApprovedGrievances.Text = TotalSAGApproved.ToString();
                            }
                        }

                        else if (UserTypeID == 24) //Sub SC
                        {
                            lblBlueCount.Text = reg.GetApplicationFormListForFCVerification(Session["UserLoginId"].ToString(), Convert.ToInt16(Session["UserTypeID"].ToString())).Tables[0].Rows.Count.ToString();
                            lblPurpalCount.Text = reg.GetApplicationFormListForPartialFCVerification(Session["UserLoginId"].ToString(), Convert.ToInt16(Session["UserTypeID"].ToString())).Tables[0].Rows.Count.ToString();

                            if (Request.QueryString["AFCID"] != null)
                            {
                                RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                                InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                                AFCID = Convert.ToInt32(Request.QueryString["AFCID"].ToString());
                            }
                            else
                            {
                                RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                                InstituteID = reg.getInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                                AFCID = Convert.ToInt32(Session["UserID"].ToString());
                            }

                            lblRedCount.Text = reg.GetDiscrepancyMarkedCandidateList(RegionID, InstituteID, AFCID, "ALL").Tables[0].Rows.Count.ToString();
                            lblGreenCount.Text = reg.GetEFCConfiredCandidateList(RegionID, InstituteID, AFCID, "ALL").Tables[0].Rows.Count.ToString();

                            if (isARCReportingStarted)
                            {
                                //For SeatAcceptance Grievance Status Dashboard
                                //RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                                //InstituteID = reg.getInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                                lblNewGrievances.Text = reg.GetSeatAcceptanceGrievanceListForVerification(RegionID, InstituteID, 99, Global.CAPRound).Tables[0].Rows.Count.ToString();
                                lblPickedupGrievances.Text = reg.GetSeatAcceptancePickedupGrievanceList(RegionID, InstituteID, 99, Global.CAPRound).Tables[0].Rows.Count.ToString();
                                lblRejectedGrievances.Text = reg.GetSeatAcceptanceRejectedGrievanceList(RegionID, InstituteID, 99, Global.CAPRound).Tables[0].Rows.Count.ToString();
                                lblApprovedGrievances.Text = reg.GetSeatAcceptanceApprovedGrievanceList(RegionID, InstituteID, 99, Global.CAPRound).Tables[0].Rows.Count.ToString();
                            }
                        }

                        lblYellowCount.Text = reg.GetApplicationFormListForFCReVerificationofGrievance(Session["UserLoginId"].ToString(), Convert.ToInt16(Session["UserTypeID"].ToString())).Tables[0].Rows.Count.ToString();

                        string AFCCode = Session["UserLoginID"].ToString().Substring(0, 6);
                        lblBrownCount.Text = reg.GetAFCNonRepliedGrievance("AFC", AFCCode).Tables[0].Rows.Count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlWebSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlWebSite.SelectedValue != "0")
                {
                    Response.Redirect(ddlWebSite.SelectedValue + Session["UserLoginID"].ToString() + "&Code=" + Session["UserLoginID"].ToString().GetHashCode(), true);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                string UserLoginID = Session["UserLoginID"].ToString();

                DataSet ds = new DBUtilityWelcomePageAFC().getDateWiseConfirmedCandidateCount(UserTypeID, UserLoginID, ddlDate.SelectedValue);

                lblCAPConfirmed.Text = ds.Tables[0].Rows[0]["CAP"].ToString();
                lblNonCAPConfirmed.Text = ds.Tables[0].Rows[0]["NonCAP"].ToString();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlDashboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                string UserLoginID = Session["UserLoginID"].ToString();

                DataSet dsDashboard = reg.getDashboardAFC(UserTypeID, UserLoginID, ddlDashboard.SelectedValue);
                Int64 Total = 0;

                gvApplicationStatusReport.DataSource = dsDashboard.Tables[0];
                gvApplicationStatusReport.DataBind();

                gvCandidatureTypeWiseReport.DataSource = dsDashboard.Tables[1];
                gvCandidatureTypeWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvCandidatureTypeWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvCandidatureTypeWiseReport.Rows[i].Cells[1].Text));
                }
                gvCandidatureTypeWiseReport.FooterRow.Cells[0].Text = "Total";
                gvCandidatureTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                gvHomeUniversityWiseReport.DataSource = dsDashboard.Tables[2];
                gvHomeUniversityWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvHomeUniversityWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvHomeUniversityWiseReport.Rows[i].Cells[1].Text));
                }
                gvHomeUniversityWiseReport.FooterRow.Cells[0].Text = "Total";
                gvHomeUniversityWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                gvCategoryWiseReport.DataSource = dsDashboard.Tables[3];
                gvCategoryWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvCategoryWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvCategoryWiseReport.Rows[i].Cells[1].Text));
                }
                gvCategoryWiseReport.FooterRow.Cells[0].Text = "Total";
                gvCategoryWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                gvPHTypeWiseReport.DataSource = dsDashboard.Tables[4];
                gvPHTypeWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvPHTypeWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvPHTypeWiseReport.Rows[i].Cells[1].Text));
                }
                gvPHTypeWiseReport.FooterRow.Cells[0].Text = "Total";
                gvPHTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                gvDefenceTypeWiseReport.DataSource = dsDashboard.Tables[5];
                gvDefenceTypeWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvDefenceTypeWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvDefenceTypeWiseReport.Rows[i].Cells[1].Text));
                }
                gvDefenceTypeWiseReport.FooterRow.Cells[0].Text = "Total";
                gvDefenceTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                gvGenderWiseReport.DataSource = dsDashboard.Tables[6];
                gvGenderWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvGenderWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvGenderWiseReport.Rows[i].Cells[1].Text));
                }
                gvGenderWiseReport.FooterRow.Cells[0].Text = "Total";
                gvGenderWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                gvReligionWiseReport.DataSource = dsDashboard.Tables[7];
                gvReligionWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvReligionWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvReligionWiseReport.Rows[i].Cells[1].Text));
                }
                gvReligionWiseReport.FooterRow.Cells[0].Text = "Total";
                gvReligionWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                gvRegionWiseReport.DataSource = dsDashboard.Tables[8];
                gvRegionWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvRegionWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvRegionWiseReport.Rows[i].Cells[1].Text));
                }
                gvRegionWiseReport.FooterRow.Cells[0].Text = "Total";
                gvRegionWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                gvMotherTongueWiseReport.DataSource = dsDashboard.Tables[9];
                gvMotherTongueWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvMotherTongueWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvMotherTongueWiseReport.Rows[i].Cells[1].Text));
                }
                gvMotherTongueWiseReport.FooterRow.Cells[0].Text = "Total";
                gvMotherTongueWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                gvAnnualFamilyIncomeWiseReport.DataSource = dsDashboard.Tables[10];
                gvAnnualFamilyIncomeWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvAnnualFamilyIncomeWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvAnnualFamilyIncomeWiseReport.Rows[i].Cells[1].Text));
                }
                gvAnnualFamilyIncomeWiseReport.FooterRow.Cells[0].Text = "Total";
                gvAnnualFamilyIncomeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                gvHSCBoardWiseReport.DataSource = dsDashboard.Tables[11];
                gvHSCBoardWiseReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvHSCBoardWiseReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvHSCBoardWiseReport.Rows[i].Cells[1].Text));
                }
                gvHSCBoardWiseReport.FooterRow.Cells[0].Text = "Total";
                gvHSCBoardWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                if (dsDashboard.Tables[12].Rows.Count > 0)
                {
                    gvHSCPassingYearWiseReport.DataSource = dsDashboard.Tables[12];
                    gvHSCPassingYearWiseReport.DataBind();
                    Total = 0;
                    for (Int32 i = 0; i < gvHSCPassingYearWiseReport.Rows.Count; i++)
                    {
                        Total += Convert.ToInt64((gvHSCPassingYearWiseReport.Rows[i].Cells[1].Text));
                    }
                    gvHSCPassingYearWiseReport.FooterRow.Cells[0].Text = "Total";
                    gvHSCPassingYearWiseReport.FooterRow.Cells[1].Text = Total.ToString();
                }

                gvMinorityReport.DataSource = dsDashboard.Tables[13];
                gvMinorityReport.DataBind();
                Total = 0;
                for (Int32 i = 0; i < gvMinorityReport.Rows.Count; i++)
                {
                    Total += Convert.ToInt64((gvMinorityReport.Rows[i].Cells[1].Text));
                }
                gvMinorityReport.FooterRow.Cells[0].Text = "Total";
                gvMinorityReport.FooterRow.Cells[1].Text = Total.ToString();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnBlue_Click(Object sender, EventArgs e)
        {
            Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

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
            if (UserTypeID == 21)
            {
                Response.Redirect("../E_FCModule/frmRegionWiseApplicationFormListForFCVerificationReport.aspx", true);
            }
            if (UserTypeID == 22)
            {
                Response.Redirect("../E_FCModule/frmAFCWiseApplicationFormListForFCVerificationReport.aspx? RegionID = 99", true);
            }
            if (UserTypeID == 23)
            {
                Response.Redirect("../E_FCModule/PendingApplicatonVerification.aspx", true);
            }
            if (UserTypeID == 24)
            {
                Response.Redirect("../E_FCModule/PendingApplicatonVerification.aspx", true);
            }

        }
        protected void btnPurpal_Click(Object sender, EventArgs e)
        {
            Response.Redirect("../E_FCModule/PartialApplicatonVerification.aspx", true);
        }
        protected void btnRed_Click(Object sender, EventArgs e)
        {
            Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

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

            if (UserTypeID == 23)
            {
                Response.Redirect("../E_FCModule/frmSubAFCWiseDiscrepancyReport.aspx", true);
            }
            if (UserTypeID == 24)
            {
                Response.Redirect("../E_FCModule/frmDiscrepancyMarkCandidateList.aspx? RegionID = " + RegionID.ToString() + " & InstituteID = " + InstituteID.ToString() + " & AFCID = 99", true);
            }
        }
        protected void btnYellow_Click(Object sender, EventArgs e)
        {
            Response.Redirect("../E_FCModule/GrivenceApplicatonForm.aspx", true);
        }

        protected void btnBrown_Click(Object sender, EventArgs e)
        {
            Response.Redirect("../AFCModule/frmGrievanceNonRepliedAFC.aspx", true);
        }
        protected void btnGreen_Click(Object sender, EventArgs e)
        {
            //Response.Redirect("../E_FCModule/frmConfirmedCandidateList.aspx", true);

            Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

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

            if (UserTypeID == 23)
            {
                Response.Redirect("../E_FCModule/frmSubAFCCandidateConfirmedReport.aspx", true);
            }
            if (UserTypeID == 24)
            {
                Response.Redirect("../E_FCModule/frmConfirmedCandidateList.aspx? RegionID = " + RegionID.ToString() + " & InstituteID = " + InstituteID.ToString() + " & AFCID = 99", true);
            }
        }

        protected void btnNewGrievances_Click(Object sender, EventArgs e)
        {

            Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

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
            if (UserTypeID == 21)
            {
                Response.Redirect("../AFCModule/frmRegionWiseSeatAcceptanceGrievanceStatus.aspx?GrievanceStatusFlag=Y", true);
            }
            if (UserTypeID == 22)
            {
                Response.Redirect("../AFCModule/frmAFCWiseSeatAcceptanceGrievanceStatus.aspx?GrievanceStatusFlag=Y&RegionID=99", true);
            }
            if (UserTypeID == 23)
            {
                Response.Redirect("../AFCModule/frmSubAFCWiseSeatAcceptanceGrievanceListForVerification.aspx?RegionID=" + RegionID.ToString() + " &InstituteID=" + InstituteID.ToString(), true);
            }
            if (UserTypeID == 24)
            {
                Response.Redirect("../AFCModule/frmSeatAcceptanceGrievanceCandidateListVerification.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=" + InstituteID.ToString() + "&AFCID=99", true);
            }
        }
        protected void btnPickedupGrievances_Click(Object sender, EventArgs e)
        {
            Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

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
            if (UserTypeID == 21)
            {
                Response.Redirect("../AFCModule/frmRegionWiseSeatAcceptanceGrievanceStatus.aspx?GrievanceStatusFlag=P", true);
            }
            if (UserTypeID == 22)
            {
                Response.Redirect("../AFCModule/frmAFCWiseSeatAcceptanceGrievanceStatus.aspx?GrievanceStatusFlag=P&RegionID=99", true);
            }
            if (UserTypeID == 23)
            {
                Response.Redirect("../AFCModule/frmSubAFCWiseSeatAcceptanceGrievancePickedup.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=" + InstituteID.ToString(), true);
            }
            if (UserTypeID == 24)
            {
                Response.Redirect("../AFCModule/frmSeatAcceptanceGrievanceCandidateListPickedup.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=" + InstituteID.ToString() + "&AFCID=99", true);
            }
        }
        protected void btnRejectedGrievances_Click(Object sender, EventArgs e)
        {
            Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

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
            if (UserTypeID == 21)
            {
                Response.Redirect("../AFCModule/frmRegionWiseSeatAcceptanceGrievanceStatus.aspx?GrievanceStatusFlag=R", true);
            }
            if (UserTypeID == 22)
            {
                Response.Redirect("../AFCModule/frmAFCWiseSeatAcceptanceGrievanceStatus.aspx?GrievanceStatusFlag=R&RegionID=99", true);
            }
            if (UserTypeID == 23)
            {
                Response.Redirect("../AFCModule/frmSubAFCWiseSeatAcceptanceGrievanceRejected.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=" + InstituteID.ToString(), true);
            }
            if (UserTypeID == 24)
            {
                Response.Redirect("../AFCModule/frmSeatAcceptanceGrievanceCandidateListRejected.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=" + InstituteID.ToString() + "&AFCID=99", true);
            }
        }
        protected void btnApprovedGrievances_Click(Object sender, EventArgs e)
        {
            Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());

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
            if (UserTypeID == 21)
            {
                Response.Redirect("../AFCModule/frmRegionWiseSeatAcceptanceGrievanceStatus.aspx?GrievanceStatusFlag=A", true);
            }
            if (UserTypeID == 22)
            {
                Response.Redirect("../AFCModule/frmAFCWiseSeatAcceptanceGrievanceStatus.aspx?GrievanceStatusFlag=A&RegionID=99", true);
            }
            if (UserTypeID == 23)
            {
                Response.Redirect("../AFCModule/frmSubAFCWiseSeatAcceptanceGrievanceApproved.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=" + InstituteID.ToString(), true);
            }
            if (UserTypeID == 24)
            {
                Response.Redirect("../AFCModule/frmSeatAcceptanceGrievanceCandidateListApproved.aspx?RegionID=" + RegionID.ToString() + "&InstituteID=" + InstituteID.ToString() + "&AFCID=99", true);
            }
        }
        protected void btnNewCVCEWSNCL_Click(Object sender, EventArgs e)
        {
            Response.Redirect("../AFCModule/frmCVCNCLEWSCandidateListForVerification", true);
        }
        protected void btnCorrectDocument_Click(Object sender, EventArgs e)
        {
            Response.Redirect("../AFCModule/frmDocumentForApproval", true);
        }
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
                return db.ExecuteDataSet("MHDTE_spGetDateWiseConfirmedCandidateCount", parameters);
            }
            finally
            {
                db.Dispose();
            }
        }
        public DataSet GetCVCNCLEWSVerificationPendingList(int UserTypeID, string UserLoginID)
        {
            SqlParameter[] param =
                {
                    new SqlParameter("@UserTypeID", SqlDbType.Int),
                     new SqlParameter("@UserLoginID", SqlDbType.VarChar)
                };

            param[0].Value = UserTypeID;
            param[1].Value = UserLoginID;

            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetCVCNCLEWSVerificationPendingList", param);

            }
            finally
            {
                db.Dispose();
            }

            //return ExecProcedure("MHDTE_spGetAllDocuments", param, "tbl");
        }

        public DataSet GetCandidateListForApproval(int UserTypeID, string UserLoginID)
        {
            SqlParameter[] param =
                {
                    new SqlParameter("@UserTypeID", SqlDbType.Int),
                     new SqlParameter("@UserLoginID", SqlDbType.VarChar)
                };

            param[0].Value = UserTypeID;
            param[1].Value = UserLoginID;

            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetCorrectDocumentVerificationPendingList", param);

            }
            finally
            {
                db.Dispose();
            }

        }
    }
}