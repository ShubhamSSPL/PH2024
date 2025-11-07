using BusinessLayer;
using ClosedXML.Excel;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmGenerateMeritList : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public static string Master_Table = "";
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
            ltScripts.Text = "";
            if (!IsPostBack)
            {
                try
                {
                    getPageLoadData();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public void getPageLoadData()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet ds = new DynamicMeritListGeneration().getMeritListGenerationPageLoadData();

                lblTotalCandidatesCount.Text = ds.Tables[0].Rows[0]["TotalCandidates"].ToString();
                lblEligibleCandidateCount.Text = ds.Tables[1].Rows[0]["EligibleCandidates"].ToString();
                lblNotEligibleCandidateCount.Text = ds.Tables[2].Rows[0]["NotEligibleCandidates"].ToString();

                if (ds.Tables[3].Rows[0]["ProvisionalMeritListLastModifiedOn"].ToString() != "0")
                {
                    DateTime ProvisionalMeritListLastModifiedOn = Convert.ToDateTime(ds.Tables[3].Rows[0]["ProvisionalMeritListLastModifiedOn"].ToString());
                    lblProvisionalMeritListLastModifiedOn.Text = ProvisionalMeritListLastModifiedOn.Day.ToString() + "/" + ProvisionalMeritListLastModifiedOn.Month.ToString() + "/" + ProvisionalMeritListLastModifiedOn.Year.ToString() + " " + String.Format("{0:T}", ProvisionalMeritListLastModifiedOn);
                }
                if (ds.Tables[4].Rows[0]["ProvisionalMeritListCount"].ToString() != "0")
                {
                    lnkbtnProvisionalMeritListExcel.Enabled = true;
                }

                if (ds.Tables[5].Rows[0]["FinalMeritListLastModifiedOn"].ToString() != "0")
                {
                    DateTime FinalMeritListLastModifiedOn = Convert.ToDateTime(ds.Tables[5].Rows[0]["FinalMeritListLastModifiedOn"].ToString());
                    lblFinalMeritListLastModifiedOn.Text = FinalMeritListLastModifiedOn.Day.ToString() + "/" + FinalMeritListLastModifiedOn.Month.ToString() + "/" + FinalMeritListLastModifiedOn.Year.ToString() + " " + String.Format("{0:T}", FinalMeritListLastModifiedOn);
                }
                if (ds.Tables[6].Rows[0]["FinalMeritListCount"].ToString() != "0")
                {
                    lnkbtnFinalMeritListExcel.Enabled = true;
                }

                if (ds.Tables[7].Rows[0]["AllotmentMeritListLastModifiedOn"].ToString() != "0")
                {
                    DateTime AllotmentMeritListLastModifiedOn = Convert.ToDateTime(ds.Tables[7].Rows[0]["AllotmentMeritListLastModifiedOn"].ToString());
                    lblAllotmentMeritListLastModifiedOn.Text = AllotmentMeritListLastModifiedOn.Day.ToString() + "/" + AllotmentMeritListLastModifiedOn.Month.ToString() + "/" + AllotmentMeritListLastModifiedOn.Year.ToString() + " " + String.Format("{0:T}", AllotmentMeritListLastModifiedOn);
                }
                if (ds.Tables[8].Rows[0]["AllotmentMeritListCount"].ToString() != "0")
                {
                    lnkbtnAllotmentMeritListExcel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnGenerateMeritList_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string Master_Table = "";
                if (rbnProvisionalMeritList.Checked)
                {
                    Master_Table = "Master_ProvisionalMeritList";
                }
                else if (rbnFinalMeritList.Checked)
                {
                    Master_Table = "Master_FinalMeritList";
                }
                else if (rbnAllotmentMeritList.Checked)
                {
                    Master_Table = "Master_AllotmentMeritList";
                }
                String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                Int32 i = new DynamicMeritListGeneration().generateMeritList(Master_Table, "PrimaryKeyConstraint_" + timeStamp);

                if (i > 0)
                {
                    getPageLoadData();

                    shInfo.Visible = true;
                    shInfo.SetMessage("Merit List Generated Successfully.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void lnkbtnTotalCandidateCountExcel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string FileName = "TotalCandidates";
                DataSet ds = new DynamicMeritListGeneration().downloadCandidateData("TotalCandidates");

                exportToExcel(FileName, ds);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void lnkbtnEligibleCandidateCountExcel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string FileName = "EligibleCandidates";
                DataSet ds = new DynamicMeritListGeneration().downloadCandidateData("EligibleCandidates");

                exportToExcel(FileName, ds);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void lnkbtnNotEligibleCandidateCountExcel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string FileName = "NotEligibleCandidates";
                DataSet ds = new DynamicMeritListGeneration().downloadCandidateData("NotEligibleCandidates");

                exportToExcel(FileName, ds);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void lnkbtnProvisionalMeritListExcel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string FileName = "ProvisionalMeritList";
                DataSet ds = new DynamicMeritListGeneration().downloadMeritList("ProvisionalMeritList");

                exportToExcel(FileName, ds);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void lnkbtnFinalMeritListExcel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string FileName = "FinalMeritList";
                DataSet ds = new DynamicMeritListGeneration().downloadMeritList("FinalMeritList");

                exportToExcel(FileName, ds);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void lnkbtnAllotmentMeritListExcel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string FileName = "AllotmentMeritList";
                DataSet ds = new DynamicMeritListGeneration().downloadMeritList("AllotmentMeritList");

                exportToExcel(FileName, ds);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        public void exportToExcel(string FileName, DataSet ds)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(ds.Tables[0], FileName);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        public class DynamicMeritListGeneration
        {
            public DataSet getMeritListGenerationPageLoadData()
            {
                SqlParameter[] parameters = { };
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetMeritListGenerationPageLoadData", parameters);
                }
                finally
                {
                    db.Dispose();
                }

            }
            public DataSet downloadCandidateData(string Flag)
            {
                SqlParameter[] parameters = {
                                            new SqlParameter("@Flag",SqlDbType.VarChar,100),
                                        };
                parameters[0].Value = Flag;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spDownloadCandidateData", parameters);
                }
                finally
                {
                    db.Dispose();
                }
            }
            public DataSet downloadMeritList(string Flag)
            {
                SqlParameter[] parameters = {
                                            new SqlParameter("@Flag",SqlDbType.VarChar,100),
                                        };
                parameters[0].Value = Flag;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spDownloadMeritList", parameters);
                }
                finally
                {
                    db.Dispose();
                }
            }
            public Int32 generateMeritList(string Master_Table, string PrimaryKeyConstraintName)
            {
                SqlParameter[] parameters = {
                                            new SqlParameter("@Master_Table",SqlDbType.VarChar,50),
                                            new SqlParameter("@PrimaryKeyConstraintName",SqlDbType.VarChar,100),
                                         };
                parameters[0].Value = Master_Table;
                parameters[1].Value = PrimaryKeyConstraintName;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteNonQuery("MHDTE_spGenerateMeritList", parameters);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}