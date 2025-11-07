using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.FeeProcess.Receipt
{
    public partial class OnlinePaymentReceipt : System.Web.UI.Page
    {
        protected string referenceNo;
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
                    if (Request.QueryString["RefNo"] != null && Request.QueryString["RefNo"].ToString().Trim() != "")
                    {
                        referenceNo = Request.QueryString["RefNo"].ToString().Trim();
                        LoadData(Convert.ToInt64(Request.QueryString["RefNo"].ToString()));
                    }
                }
            }
        }
        protected void LoadData(long ReferenceNo)
        {
            DataSet ds = null;
            try
            {
                ds = new FeeProcess_OnlinePaymentReceiptDB().GetGroupPaymentReceiptDetailsDB(ReferenceNo, "");
                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    DataRow DR = null;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DR = ds.Tables[0].Rows[0];

                        lblApplicationID.Text = DR["ApplicationID"].ToString();
                        lblCandidateName.Text = DR["CandidateName"].ToString();
                       // lblMobileNo.Text = DataEncryption.DecryptDataByEncryptionKey(DR["MobileNo"].ToString());
                        lblReferenceNo.Text = DR["ReferenceNo"].ToString();
                        lblTransactionAmount.Text = DR["TransactionAmount"].ToString();
                        lblPaymentInitiationDate.Text = DR["PaymentInitiationDate"].ToString();
                        lblPaymentStatus.Text = DR["PaymentStatus"].ToString();
                        lblPaymentMode.Text = DR["PaymentMode"].ToString();
                        lblPurpose.Text = DR["Purpose"].ToString();
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
    public class FeeProcess_OnlinePaymentReceiptDB
    {

        public DataSet GetGroupPaymentReceiptDetailsDB(long referenceNO, string userLoginId)
        {
            SqlParameter[] param =
            {
            new SqlParameter("@ReferenceNo", SqlDbType.BigInt),
            new SqlParameter("@UserLoginId", SqlDbType.VarChar,50)
        };

            param[0].Value = referenceNO;
            param[1].Value = userLoginId;
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("Fee_Client_GetOnlineReceipt", param);

            }
            finally
            {
                db.Dispose();
            }

        }
    }
}