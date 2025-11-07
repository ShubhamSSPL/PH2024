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
    public partial class WelcomePageARC : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    if (Request.Cookies["Theme"] == null)
        //    {
        //        Page.Theme = "default";
        //    }
        //    else
        //    {
        //        Page.Theme = Request.Cookies["Theme"].Value;
        //    }
        //}
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

                    //ddlWebSite.DataSource = Global.MasterWebSite;
                    //ddlWebSite.DataTextField = "WebSiteName";
                    //ddlWebSite.DataValueField = "WebSiteURL";
                    //ddlWebSite.DataGroupField = "WebSiteGroup";
                    //ddlWebSite.DataBind();
                    //ListItem liWebSite = new ListItem("-- Select WebSite --", "0");
                    //liWebSite.Attributes.Add("DataGroupField", "");
                    //ddlWebSite.Items.Insert(0, liWebSite);

                    ddlDate.DataSource = reg.getARCConfirmationDateList();
                    ddlDate.DataTextField = "ReportedDateTime";
                    ddlDate.DataValueField = "ReportedDateTime";
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

                    if (UserTypeID == 21 || UserTypeID == 22 || UserTypeID == 66)
                    {
                        trWebSiteNavigation1.Visible = true;
                        trWebSiteNavigation2.Visible = true;
                    }
                    else if (UserTypeID == 33 || UserTypeID == 34)
                    {
                        ARCProfile objARCProfile = reg.getARCProfile(Session["UserLoginID"].ToString());

                        if (objARCProfile.SecurityQuestionID == 0)
                        {
                            Response.Redirect("../ARCModule/frmARCProfile.aspx", true);
                        }
                    }

                    if (UserTypeID == 21 || UserTypeID == 22 || UserTypeID == 33 || UserTypeID == 34)
                    {
                        tblDashboard.Visible = true;

                        DataSet ds = new DBUtilityWelcomePageARC().getDateWiseConfirmedCandidateCount(UserTypeID, UserLoginID, ddlDate.SelectedValue);

                        lblConfirmed.Text = ds.Tables[0].Rows[0]["TotalConfirmed"].ToString();

                        DataSet dsDashboard = reg.getDashboardARC(UserTypeID, UserLoginID);
                        Int64 Total = 0;

                        gvApplicationStatusReport.DataSource = dsDashboard.Tables[0];
                        gvApplicationStatusReport.DataBind();

                        if (UserTypeID == 21)
                        {
                            tblDashboardAdmin.Visible = true;

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
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        //protected void ddlWebSite_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
        //    try
        //    {
        //        if (ddlWebSite.SelectedValue != "0")
        //        {
        //            Response.Redirect(ddlWebSite.SelectedValue + Session["UserLoginID"].ToString() + "&Code=" + Session["UserLoginID"].ToString().GetHashCode(), true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logging.LogException(ex, "[Page Level Error]");
        //        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
        //    }
        //}
        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                string UserLoginID = Session["UserLoginID"].ToString();

                DataSet ds = new DBUtilityWelcomePageARC().getDateWiseConfirmedCandidateCount(UserTypeID, UserLoginID, ddlDate.SelectedValue);

                lblConfirmed.Text = ds.Tables[0].Rows[0]["TotalConfirmed"].ToString();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
    public class DBUtilityWelcomePageARC
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
                return db.ExecuteDataSet("MHDTE_spGetDateWiseConfirmedCandidateCountARC", parameters);
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}