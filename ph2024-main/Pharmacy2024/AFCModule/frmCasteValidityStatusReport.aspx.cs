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

namespace Pharmacy2024.AFCModule
{
    public partial class frmCasteValidityStatusReport : System.Web.UI.Page
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

        protected void GetTransactionReport(string Status)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet ds = GetCasteValidityStatusReport(Status);

                gvCasteValidityStatusReport.DataSource = ds;
                gvCasteValidityStatusReport.DataBind();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    long NotATotal = 0;
                    long Applied = 0;
                    long AvilableTotal = 0;
                    long FTotal = 0;
                    for (Int32 i = 0; i < gvCasteValidityStatusReport.Rows.Count; i++)
                    {
                        AvilableTotal += Convert.ToInt64((gvCasteValidityStatusReport.Rows[i].Cells[1].Text));
                        Applied += Convert.ToInt64((gvCasteValidityStatusReport.Rows[i].Cells[2].Text));
                        NotATotal += Convert.ToInt64((gvCasteValidityStatusReport.Rows[i].Cells[3].Text));
                        FTotal += Convert.ToInt64((gvCasteValidityStatusReport.Rows[i].Cells[4].Text));
                    }
                    gvCasteValidityStatusReport.FooterRow.Cells[0].Text = "Total";
                    gvCasteValidityStatusReport.FooterRow.Cells[1].Text = AvilableTotal.ToString();
                    gvCasteValidityStatusReport.FooterRow.Cells[2].Text = Applied.ToString();
                    gvCasteValidityStatusReport.FooterRow.Cells[3].Text = NotATotal.ToString();
                    gvCasteValidityStatusReport.FooterRow.Cells[4].Text = FTotal.ToString();
                }
                else
                {
                    shInfo.SetMessage("Record Not Found.", ShowMessageType.Information);
                }
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
                    GetTransactionReport(ddlApplicationStatus.SelectedValue);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void ddlApplicationStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                GetTransactionReport(ddlApplicationStatus.SelectedValue);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        public DataSet GetCasteValidityStatusReport(string Status)
        {
            DBConnection db = new DBConnection();
            DataSet ds = db.ExecuteDataSet("MHDTE_spGetCasteValidityStatusReport", new SqlParameter[]
            {
            new SqlParameter("@Status", Status)
            });
            db.Dispose();
            return ds;
        }
    }
}