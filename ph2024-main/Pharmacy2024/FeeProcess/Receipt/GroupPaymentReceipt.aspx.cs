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

namespace Pharmacy2024.FeeProcess.Receipt
{
    public partial class GroupPaymentReceipt : System.Web.UI.Page
    {
        public string referenceNo;
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
                    Response.Redirect("../../StaticPages/HomePage.aspx", true);
                }
                if (!IsPostBack)
                {
                    if (Session["UserLoginId"] == null)
                        Response.Redirect(ConfigurationManager.AppSettings["WebSite_LoginHomePage"], true);

                    if (Request.QueryString["TxID"] != null && Request.QueryString["TxID"].ToString().Trim() != "")
                    {
                        referenceNo = Request.QueryString["TxID"].ToString().Trim();

                        LoadData(Convert.ToInt64(Request.QueryString["TxID"].ToString()));
                    }
                }
            }

        }
        protected void LoadData(long ReferenceNo)
        {
            DataSet ds = null;

            try
            {
                ds = new EGrassery_clsGroupPaymentReceiptDB().GetGroupPaymentReceiptDetailsDB(ReferenceNo, Session["UserloginId"].ToString());
                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    DataRow DR = null;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DR = ds.Tables[0].Rows[0];

                        lblApplicationFormNo.Text = DR["ApplicationFormNo"].ToString();
                        lblApplicantName.Text = DR["ApplicantName"].ToString();
                        lblMobileNo.Text = DR["MobileNo"].ToString();

                        lblReferenceNo.Text = DR["ReferenceNo"].ToString();
                        lblCrDate.Text = DR["CrDate"].ToString();
                        lblPaidStatus.Text = DR["PaidStatus"].ToString();
                        lblMode.Text = DR["PaymentMode"].ToString();
                        lblAmount.Text = DR["Amount"].ToString();



                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVApplicantList.DataSource = ds.Tables[1];
                        GVApplicantList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
        }
    }

    public class EGrassery_clsGroupPaymentReceiptDB
    {

        public DataSet GetGroupPaymentReceiptDetailsDB(long referenceNO, string userLoginId)
        {
            SqlParameter[] param = {
                                   new SqlParameter("@ReferenceNo", SqlDbType.BigInt),
                                   new SqlParameter("@UserLoginId", SqlDbType.VarChar,50)
                               };

            param[0].Value = referenceNO;
            param[1].Value = userLoginId;
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("Fee_Client_GetGroupPaymentReceiptDetails", param);

            }
            finally
            {
                db.Dispose();
            }
        }


    }
}