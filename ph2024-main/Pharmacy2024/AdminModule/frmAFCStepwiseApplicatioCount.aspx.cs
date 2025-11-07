using BusinessLayer;
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

namespace Pharmacy2024.AdminModule
{
    public partial class frmAFCStepwiseApplicatioCount : System.Web.UI.Page
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
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();


                    DataSet dsDashboard = new DBUtilityAFCStepwiseApplicatioCount().getStepwiseApplicatioCount("");
                    if (dsDashboard.Tables.Count > 0)
                    {
                        tblDashboard.Visible = true;

                        gvApplicationStatusReport.DataSource = dsDashboard.Tables[0];
                        gvApplicationStatusReport.DataBind();

                    }

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        //protected void ddlDashboard_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
        //    try
        //    {
        //        Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
        //        string UserLoginID = Session["UserLoginID"].ToString();

        //        DataSet dsDashboard = new DBUtilityAFCStepwiseApplicatioCount().getStepwiseApplicatioCount("");
        //        if (dsDashboard.Tables.Count > 0)
        //        {
        //            tblDashboard.Visible = true;

        //            gvApplicationStatusReport.DataSource = dsDashboard.Tables[0];
        //            gvApplicationStatusReport.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logging.LogException(ex, "[Page Level Error]");
        //        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
        //    }
        //}

        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string fileName = "StepwiseReport_" + DateTime.Now.ToString() + ".xls";
            string attachment = "attachment; filename=" + fileName;
            //string attachment = "attachment; filename=CompositeReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvApplicationStatusReport.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
    public class DBUtilityAFCStepwiseApplicatioCount
    {
        public DataSet getStepwiseApplicatioCount(string Flag)
        {

            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetStepwiseApplicatioCount", new SqlParameter[]
                  {
                    new SqlParameter("@Flag",Flag)
                  });
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}