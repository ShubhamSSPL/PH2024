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

namespace Pharmacy2024.AFCModule
{
    public partial class frmTransactionReport : System.Web.UI.Page
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

        protected void GetTransactionReport(string ApplicationFormNo, string PaidStatus, string StartDate, string EndDate)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet ds = TransactionReport(ApplicationFormNo, PaidStatus, StartDate, EndDate);

                gvTransactionReport.DataSource = ds;
                gvTransactionReport.DataBind();

                for (Int32 i = 0; i < gvTransactionReport.Rows.Count; i++)
                {
                    DateTime dt = Convert.ToDateTime(gvTransactionReport.Rows[i].Cells[0].Text);
                    gvTransactionReport.Rows[i].Cells[0].Text = dt.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", dt);
                }

                if (ds.Tables[0].Rows.Count > 0)
                    btnexporttoExcel.Visible = true;
                else
                {
                    btnexporttoExcel.Visible = false;
                    shInfo.SetMessage("Record Not Found.", ShowMessageType.Information);
                }

                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
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

                    ddlPaidStatus.Items.Insert(0, new ListItem("-- Select Paid Status --", ""));
                    ddlPaidStatus.Items.Insert(1, new ListItem("Success", "Y"));
                    ddlPaidStatus.Items.Insert(2, new ListItem("Failure", "N"));

                    //string ApplicationFormNo = txtAppID.Text;
                    //if (ApplicationFormNo.Contains("EN18"))
                    //    ApplicationFormNo = ApplicationFormNo.Substring(4);
                    //string PaidStatus = ddlPaidStatus.Text;
                    //string StartDate = txtStartDate.Text;
                    //string EndDate = txtEndDate.Text;

                    //GetTransactionReport(ApplicationFormNo, PaidStatus, StartDate, EndDate);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string ApplicationFormNo = txtAppID.Text;
                if (ApplicationFormNo.Contains("PH19"))
                    ApplicationFormNo = ApplicationFormNo.Substring(4);
                string PaidStatus = ddlPaidStatus.Text;

                string StartDate = "";
                if (txtStartDate.Text != "")
                    StartDate = Convert.ToString(txtStartDate.Text.Split("/".ToCharArray())[1] + "/" + txtStartDate.Text.Split("/".ToCharArray())[0] + "/" + txtStartDate.Text.Split("/".ToCharArray())[2]);

                string EndDate = "";
                if (txtStartDate.Text != "")
                    EndDate = Convert.ToString(txtEndDate.Text.Split("/".ToCharArray())[1] + "/" + txtEndDate.Text.Split("/".ToCharArray())[0] + "/" + txtEndDate.Text.Split("/".ToCharArray())[2]);


                GetTransactionReport(ApplicationFormNo, PaidStatus, StartDate, EndDate);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnexporttoExcel_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=TransactionReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvTransactionReport.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        public DataSet TransactionReport(string ApplicationFormNo, string PaidStatus, string StartDate, string EndDate)
        {
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("sp_GetTransactionReport", new SqlParameter[]
            {
            new SqlParameter("@ApplicationFormNo", ApplicationFormNo),
            new SqlParameter("@PaidStatus", PaidStatus),
            new SqlParameter("@StartDate", StartDate),
            new SqlParameter("@EndDate", EndDate)
            });
            db.Dispose();
            return ds;
        }
    }
}