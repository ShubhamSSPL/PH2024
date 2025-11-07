using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DataAccess.Implementation;
using EntityModel;
using forProjectCustomExceptions;
using Razorpay.Api;
using Synthesys.DataAcess;

namespace Pharmacy2024.FeeProcess.Response
{
    public partial class Charge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UPSProcessing();
        }
        protected void UPSProcessing()
        {
            if (Request.QueryString["razorpay_payment_id"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["FAIL_URL"].ToString());
            }
            string paymentId = Request.QueryString["razorpay_payment_id"];
            string order_id = string.Empty;


            RazorpayClient client = new RazorpayClient(ConfigurationManager.AppSettings["Rkey"], ConfigurationManager.AppSettings["Rsecret"]);

            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("razorpay_payment_id", paymentId);
            attributes.Add("razorpay_order_id", Request.QueryString["razorpay_order_id"]);
            attributes.Add("razorpay_signature", Request.QueryString["razorpay_signature"]);
            Utils.verifyPaymentSignature(attributes);

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", Request.QueryString["amount"]); // this amount should be same as transaction amount
            Payment payment = client.Payment.Fetch(paymentId);

            if (payment["status"] == "captured")
            {
                order_id = Request.QueryString["refno"];
                //string[] payResult = merc_hash_string.Split('|');
                ClientTransaction tranInitiated = new ClientTransaction();
                ClientTransaction tranSaved = null;

                tranInitiated.IsReturnStatus_SavedInDB = "Y";
                tranInitiated.IsLoggedToEgrassServer = "Y";
                tranInitiated.PaidStatus = "Y";
                tranInitiated.ReferenceNo = order_id;
                tranInitiated.PayGateId = paymentId; //"0";
                tranInitiated.BankReferenceNo = payment["bank_ref_num"];//payResult[0].ToString();
                tranInitiated.Optional4 = payment["method"];
                tranInitiated.Optional5 = Request.QueryString["razorpay_order_id"];
                string bankStatus = "";
                if (payment["bank"] == null)
                {
                    if (payment["wallet"] == null)
                    {
                        if (payment["card_id"] == null)
                        {
                            if (payment["vpa"] == null)
                            {
                                bankStatus = "";
                            }
                            else
                            {
                                bankStatus = payment["vpa"];
                            }
                        }
                        else
                        {
                            bankStatus = payment["card_id"];
                        }
                    }
                    else
                    {
                        bankStatus = payment["wallet"];
                    }
                }
                else
                {
                    bankStatus = payment["bank"];
                }


                string upsStatus = payment["status"];


                tranSaved = new ClsEgrasChallanResponseDB().SavePaymentDetails(tranInitiated, upsStatus, bankStatus);

                if (Session["UserLoginID"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["FAIL_URL"].ToString() + "?paystatus=" + paymentId + "&bref=" + Request.QueryString["bank_ref_num"]);
                }
                else
                {
                    Response.Redirect("../AfterPayment.aspx?ReferenceNo=" + order_id, true);
                }
            }
            else
            {
                Response.Redirect(ConfigurationManager.AppSettings["FAIL_URL"].ToString());
            }
        }
        public class ClsEgrasChallanResponseDB

        {
            public ClientTransaction SavePaymentDetails(ClientTransaction obj, string upsStatus, string bankStatus)
            {
                DBConnection db = new DBConnection();
                try
                {
                    ClientTransaction obs = null;
                    DataSet ds = null;


                    //param[0].Value = Convert.ToInt64(obj.ReferenceNo);
                    //param[1].Value = obj.PayGateId;
                    //param[2].Value = obj.BankReferenceNo;
                    //param[3].Value = obj.PaidStatus;
                    //param[4].Value = 0;
                    //param[5].Value = 1;
                    //param[6].Value = obj.Optional1;
                    //param[7].Value = obj.Optional2;
                    //param[8].Value = obj.Optional3;
                    //param[9].Value = obj.Optional4;
                    //param[10].Value = obj.Optional5;
                    //param[11].Value = upsStatus;
                    //param[12].Value = bankStatus;


                    ds = db.ExecuteDataSet("Fee_Client_SetPaymentResponse", new SqlParameter[]
                    {
                        new SqlParameter("@ReferenceNo", Convert.ToInt64(obj.ReferenceNo)),
                new SqlParameter("@PayGateId", obj.PayGateId),
                new SqlParameter("@BankReferenceNo", obj.BankReferenceNo),
                new SqlParameter("@PaidStatus", obj.PaidStatus)  ,
                new SqlParameter("@IsValid", false),
                new SqlParameter("@IsReturnRequired", 1),
                new SqlParameter("@Option1", obj.Optional1),
                new SqlParameter("@Option2", obj.Optional2),
                new SqlParameter("@Option3", obj.Optional3),
                new SqlParameter("@Option4", obj.Optional4),
                new SqlParameter("@Option5", obj.Optional5),
                new SqlParameter("@UpsStatus", upsStatus),
                new SqlParameter("@BankStatus", bankStatus)
            });

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            obs = new ClientTransaction();

                            if (ds.Tables[0].Rows[0]["DataSaved"].ToString().ToUpper().Trim() == "Y")
                            {
                                obs.ApplicationFormNo = ds.Tables[0].Rows[0]["ApplicationFormNo"].ToString();
                                obs.IsReturnStatus_SavedInDB = "Y";
                            }
                            else
                            {
                                obs.IsReturnStatus_SavedInDB = "N";
                            }
                        }
                    }

                    return obs;
                }
                catch (SqlException ex)
                {
                    long messageID = ExceptionMessages.GetMessageDetails();
                    throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, ExceptionMessages.GetExceptionMessage(ex, messageID), "SavePaymentDetails()", "PayGateId: " + obj.PayGateId + " ReferenceNo: " + obj.ReferenceNo);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}