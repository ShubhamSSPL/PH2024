using BusinessLayer;
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

namespace Pharmacy2024.InstituteModule
{
    public partial class frmUpdateSeatTypeAllotedForAdditionalRound : System.Web.UI.Page
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
                    Response.Redirect("../ApplicationPages/WelcomePageInstitute.aspx");
                    viewSeatDistribution(getChoiceCode());
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
                viewSeatDistribution(getChoiceCode());

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        private void viewSeatDistribution(string ChoiceCode)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            if (ChoiceCode == string.Empty)
            {

                ContentBox1.Visible = false;
                ContentTable2.Visible = false;
                shInfo.SetMessage("This Course is not in Your College", ShowMessageType.Information);
            }
            else
            {
                ContentBox1.Visible = true;
                ContentTable2.Visible = true;

                loadSeatDistribution(ChoiceCode);
                LostACPCandidate();
            }
        }

        private void LostACPCandidate()
        {
            gvACPCandidates.DataSource = reg.getInstitueAllotedCandidateACAP(Session["UserLoginID"].ToString(), getChoiceCode());
            gvACPCandidates.DataBind();

            for (Int32 m = 1; m <= gvACPCandidates.Rows.Count; m++)
            {
                gvACPCandidates.Rows[m - 1].Cells[0].Text = m.ToString() + ".";
            }
        }
        private string getChoiceCode()
        {
            string ChoiceCode = string.Empty;
            DataSet ds = reg.getChoiceCodeListByInstitute(Session["UserLoginID"].ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (ddlCourseType.SelectedValue == "B.Pharmacy")
                    {
                        if (dr["CourseName"].ToString() == "Pharmacy")
                        {
                            ChoiceCode = dr["ChoiceCode"].ToString();
                            break;
                        }
                    }
                    else if (ddlCourseType.SelectedValue == "Pharm.D")
                    {
                        if (dr["CourseName"].ToString() == "Pharm D ( Doctor of Pharmacy)")
                        {
                            ChoiceCode = dr["ChoiceCode"].ToString();
                            break;
                        }
                    }
                }
            }
            hdnChoiceCode.Value = ChoiceCode;
            return ChoiceCode;
        }
        private void loadSeatDistribution(string ChoiceCode)
        {
            DataSet ds = reg.getVacancyForAdditionRoundByFlag(ChoiceCode.ToString(), "Current"); // "AfterR3");//
            lblCourseName.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
            //lblTotalIntake.Text = ds.Tables[0].Rows[0]["TotalIntake"].ToString();
            //lblCAPIntake.Text = ds.Tables[0].Rows[0]["CAPIntake"].ToString();
            lblMIIntake.Text = ds.Tables[0].Rows[0]["MI"].ToString();
            //lblILIntake.Text = ds.Tables[0].Rows[0]["ILIntake"].ToString();
            lblMSIntake.Text = ds.Tables[0].Rows[0]["MS"].ToString();
            lblAIIntake.Text = ds.Tables[0].Rows[0]["AI"].ToString();
            AIH.Text = "0";
            GOPENH.Text = ds.Tables[0].Rows[0]["GOPENH"].ToString();
            LOPENH.Text = ds.Tables[0].Rows[0]["LOPENH"].ToString();
            GSCH.Text = ds.Tables[0].Rows[0]["GSCH"].ToString();
            LSCH.Text = ds.Tables[0].Rows[0]["LSCH"].ToString();
            GSTH.Text = ds.Tables[0].Rows[0]["GSTH"].ToString();
            LSTH.Text = ds.Tables[0].Rows[0]["LSTH"].ToString();
            GVJDTH.Text = ds.Tables[0].Rows[0]["GVJDTH"].ToString();
            LVJDTH.Text = ds.Tables[0].Rows[0]["LVJDTH"].ToString();
            GNTBH.Text = ds.Tables[0].Rows[0]["GNTBH"].ToString();
            LNTBH.Text = ds.Tables[0].Rows[0]["LNTBH"].ToString();
            GNTCH.Text = ds.Tables[0].Rows[0]["GNTCH"].ToString();
            LNTCH.Text = ds.Tables[0].Rows[0]["LNTCH"].ToString();
            GNTDH.Text = ds.Tables[0].Rows[0]["GNTDH"].ToString();
            LNTDH.Text = ds.Tables[0].Rows[0]["LNTDH"].ToString();
            GOBCH.Text = ds.Tables[0].Rows[0]["GOBCH"].ToString();
            LOBCH.Text = ds.Tables[0].Rows[0]["LOBCH"].ToString();
            PHCH.Text = ds.Tables[0].Rows[0]["PWDC"].ToString();
            DEFH.Text = "0";

            TOTALH.Text = ds.Tables[0].Rows[0]["TotalH"].ToString();

            GOPENO.Text = ds.Tables[0].Rows[0]["GOPENO"].ToString();
            LOPENO.Text = ds.Tables[0].Rows[0]["LOPENO"].ToString();
            GSCO.Text = ds.Tables[0].Rows[0]["GSCO"].ToString();
            LSCO.Text = ds.Tables[0].Rows[0]["LSCO"].ToString();
            GSTO.Text = ds.Tables[0].Rows[0]["GSTO"].ToString();
            LSTO.Text = ds.Tables[0].Rows[0]["LSTO"].ToString();
            GVJDTO.Text = ds.Tables[0].Rows[0]["GVJDTO"].ToString();
            LVJDTO.Text = ds.Tables[0].Rows[0]["LVJDTO"].ToString();
            GNTBO.Text = ds.Tables[0].Rows[0]["GNTBO"].ToString();
            LNTBO.Text = ds.Tables[0].Rows[0]["LNTBO"].ToString();
            GNTCO.Text = ds.Tables[0].Rows[0]["GNTCO"].ToString();
            LNTCO.Text = ds.Tables[0].Rows[0]["LNTCO"].ToString();
            GNTDO.Text = ds.Tables[0].Rows[0]["GNTDO"].ToString();
            LNTDO.Text = ds.Tables[0].Rows[0]["LNTDO"].ToString();
            GOBCO.Text = ds.Tables[0].Rows[0]["GOBCO"].ToString();
            LOBCO.Text = ds.Tables[0].Rows[0]["LOBCO"].ToString();
            PHCO.Text = "0";
            //PH1O.Text = ds.Tables[0].Rows[0]["PH1O"].ToString();
            //PH2O.Text = ds.Tables[0].Rows[0]["PH2O"].ToString();
            //PH3O.Text = ds.Tables[0].Rows[0]["PH3O"].ToString();
            DEFO.Text = ds.Tables[0].Rows[0]["DEFS"].ToString();
            TOTALO.Text = ds.Tables[0].Rows[0]["TotalO"].ToString();
        }
        protected void gvACPCandidates_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");

            try
            {
                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 PersonalID = Convert.ToInt64(((Label)gvACPCandidates.Rows[RowID].FindControl("lblPersonalID")).Text);
                string selectedSeatType = ((DropDownList)gvACPCandidates.Rows[RowID].FindControl("ddlSeatType")).SelectedValue;

                //if (e.CommandName == "Updateq")
                //{
                //    if (selectedSeatType.Length > 0)
                //    {
                //        switch (reg.updateInstitueAllotedCandidateACAPSeatType(getChoiceCode(), PersonalID, selectedSeatType, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                //        {
                //            case 1:
                //                shInfo.SetMessage("Seat Type Updated Succesfully.", ShowMessageType.Information);
                //                break;
                //            case 2:
                //                ((DropDownList)gvACPCandidates.Rows[RowID].FindControl("ddlSeatType")).SelectedIndex = 0;
                //                shInfo.SetMessage("Verify the Vacancy for Selected SeatType !!", ShowMessageType.Information);
                //                break;
                //            case 3:
                //                shInfo.SetMessage("Choice Code Does Not Match!! ", ShowMessageType.Information);
                //                break;
                //            default:
                //                shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                //                break;
                //        }
                //        viewSeatDistribution(getChoiceCode());
                //    }
                //    else
                //    {
                //        shInfo.SetMessage("Please Enter Replied Message.", ShowMessageType.Information);
                //    }
                //}
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void gvACPCandidates_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidseattype = (HiddenField)e.Row.FindControl("hidSeatType");
                if (hidseattype.Value != "")
                {

                    DropDownList ddlSeatType = (DropDownList)e.Row.FindControl("ddlSeatType");
                    ddlSeatType.SelectedValue = hidseattype.Value;

                }

            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                dbUtility db = new dbUtility();
                if (db.checkupdatedCompletely(Session["UserLoginID"].ToString()))
                {
                    db.FinalDataSubmitted(Session["UserLoginID"].ToString());
                    shInfo.SetMessage("All Candidate and Courses updated Succesfully.", ShowMessageType.Information);
                    Response.Redirect("../InstituteModule/frmVacancyAfterUpdationForAdditionalRound.aspx", true);
                }
                else
                {
                    shInfo.SetMessage("Update Pending details of Candidates and all Courses.", ShowMessageType.Information);
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        private class dbUtility 
        {
            public bool checkupdatedCompletely(string InstituteCode)
            {
                SqlParameter[] param =
                        {
                    new SqlParameter("@InstituteID", SqlDbType.VarChar)
                };

                param[0].Value = InstituteCode;

               
                DBConnection db = new DBConnection();
                try
                {
                    Int32 result = 0;
                    result = Convert.ToInt32(db.ExecuteScaler("DTEMH_spcheckupdatedCompletelyCandidateACAP", param));
                    if (result == 1)
                        return true;
                    else
                        return false;
                }
                finally
                {
                    db.Dispose();
                }
               
            }
            public void FinalDataSubmitted(string InstituteCode)
            {
                SqlParameter[] param =
                        {
                    new SqlParameter("@InstituteID", SqlDbType.VarChar),
                    new SqlParameter("@Flag", SqlDbType.VarChar)
                };

                param[0].Value = InstituteCode;
                param[1].Value = "1";
                DBConnection db = new DBConnection();
                try
                {
                    db.ExecuteDataSet("DTEMH_spupdateInstitueFinalDataUpdatedAllotedCandidateACAP", param);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}