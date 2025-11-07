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

namespace Pharmacy2024.FeeProcess
{
    public partial class PaymentHistory : System.Web.UI.Page
    {
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
                    EGrassery_PaymentHistoryDB reg = new EGrassery_PaymentHistoryDB();

                    Int64 PayeeID = 0;
                    if (Request.QueryString["PID"] != null)
                    {
                        PayeeID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    }
                    else
                    {
                        PayeeID = Convert.ToInt64(Session["UserID"].ToString());
                    }

                    DataSet ds = reg.checkPaymentHistory(PayeeID);

                    grdPrevData.DataSource = ds.Tables[0];
                    grdPrevData.DataBind();

                    if (grdPrevData.Rows.Count == 0)
                    {
                        cntPrev.Visible = false;
                        shInfo.SetMessage("No Records Found.", ShowMessageType.Information);
                    }

                    grdFail.DataSource = ds.Tables[1];
                    grdFail.DataBind();

                    if (grdFail.Rows.Count == 0)
                    {
                        cntFail.Visible = false;
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
    public class EGrassery_PaymentHistoryDB
    {

        public DataSet checkPaymentHistory(Int64 PayeeID)
        {
            SqlParameter[] param =
            {
            new SqlParameter("@PayeeID", SqlDbType.BigInt)
        };

            param[0].Value = PayeeID;

            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("Fee_Client_CheckPaymentHistory", param);

            }
            finally
            {
                db.Dispose();
            }
        }
    }
}