using BusinessLayer;
using CCA.Util;
using EntityModel;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using forProjectCustomExceptions;
using Synthesys.DataAcess;
using DataAccess.Implementation;

namespace Pharmacy2024.FeeProcess.Response
{
    public partial class PGResponseUPS : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {
            //UPSCCAvenue();
            //UPSSBIePay();
            UPSEasebuzzPay();
        }

        protected void UPSEasebuzzPay()
        {
            string[] merc_hash_vars_seq;
            string merc_hash_string = string.Empty;
            string merc_hash = string.Empty;
            string order_id = string.Empty;
            string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";
            string paymentId = string.Empty;

            merc_hash_vars_seq = hash_seq.Split('|');
            Array.Reverse(merc_hash_vars_seq);
            merc_hash_string = System.Configuration.ConfigurationSettings.AppSettings["salt"] + "|" + Request.Form["status"];

            foreach (string merc_hash_var in merc_hash_vars_seq)
            {
                merc_hash_string += "|";
                merc_hash_string = merc_hash_string + (Request.Form[merc_hash_var] != null ? Request.Form[merc_hash_var] : "");

            }
            merc_hash = Easebuzz_Generatehash512(merc_hash_string).ToLower();

            if (merc_hash != Request.Form["hash"])
            {
                Response.Write("Hash value did not matched");

            }
            else
            {


                order_id = Request.Form["txnid"];
                paymentId = Request.Form["easepayid"];
                ClientTransaction tranInitiated = new ClientTransaction();
                ClientTransaction tranSaved = null;
                if (Request.Form["status"] == "success") //if (segments[2] == "SUCCESS") //orderStatus
                {
                    tranInitiated.IsReturnStatus_SavedInDB = "Y";
                    tranInitiated.IsLoggedToEgrassServer = "Y";
                    tranInitiated.PaidStatus = "Y";

                    tranInitiated.ReferenceNo = order_id; // Params["order_id"];
                    tranInitiated.PayGateId = paymentId; // Params["tracking_id"]; //"0";
                    tranInitiated.BankReferenceNo = Request.Form["bank_ref_num"]; // Params["bank_ref_no"]; //payResult[0].ToString();
                    tranInitiated.Optional4 = Request.Form["mode"];
                    tranInitiated.Optional5 = Request.Form["bank_name"]; //segments[13]; 

                }
                else
                {
                    tranInitiated.IsReturnStatus_SavedInDB = "Y";
                    tranInitiated.IsLoggedToEgrassServer = "Y";
                    tranInitiated.PaidStatus = "N";

                    tranInitiated.ReferenceNo = order_id; // Params["order_id"];
                    tranInitiated.PayGateId = paymentId; // Params["tracking_id"]; //"0";
                    tranInitiated.BankReferenceNo = Request.Form["bank_ref_num"]; // Params["bank_ref_no"]; //payResult[0].ToString();
                    tranInitiated.Optional4 = Request.Form["mode"];
                    tranInitiated.Optional5 = Request.Form["bank_name"]; //segments[13]; 

                    //string upsStatus = Request.Form["error"];   //Params["order_status"];
                    //string bankStatus = Request.Form["error_Message"];   //Params["status_message"]; 

                    //Response.Redirect(ConfigurationManager.AppSettings["CANCEL_URL"].ToString());
                }

                string upsStatus = Request.Form["error"];   //Params["order_status"];
                string bankStatus = Request.Form["error_Message"];   //Params["status_message"]; 
                ProcessResponse(tranInitiated, upsStatus, bankStatus);
            }
        }

        public void ProcessResponse(ClientTransaction tr, string upsStatus, string bankStatus)
        {
            ClientTransaction tranSaved = null;

            tranSaved = new ClsEgrasChallanResponseDB().SavePaymentDetails(tr, upsStatus, bankStatus);
            string UserID = tr.ApplicationFormNo;
            if (tranSaved != null && tranSaved.ApplicationFormNo.Length > 1)
            {
                UserID = tranSaved.ApplicationFormNo;
            }


            if (Session["UserLoginID"] == null)
            {
                DataSet ds = reg.getLoginData(UserID, HttpContext.Current.Request.Browser.Browser, HttpContext.Current.Request.Browser.Version, UserInfo.GetIPAddress());
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                            {
                                Session["UserLoginID"] = ds.Tables[0].Rows[0]["UserLoginID"].ToString();
                                Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                                Session["UserTypeID"] = ds.Tables[0].Rows[0]["UserTypeID"].ToString();
                                Session["UserSessionID"] = ds.Tables[0].Rows[0]["UserSessionID"].ToString();
                                if (ds.Tables[0].Rows[0]["UserTypeID"].ToString() == "91")
                                {
                                    SessionData objSessionData = (SessionData)Session["SessionData"];
                                    if (objSessionData == null)
                                    {
                                        Session["SessionData"] = reg.getSessionDataForCandidate(Convert.ToInt64(ds.Tables[0].Rows[0]["UserID"].ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (tr.PaidStatus == "Y" && tranSaved.IsReturnStatus_SavedInDB == "Y")
            {
                ClientScript.RegisterStartupScript(GetType(), "id", "SucessPayment()", true);
                Response.Redirect("../AfterPayment.aspx?ReferenceNo=" + tr.ReferenceNo, true);
            }
            else if (tr.PaidStatus == "N" && tranSaved.IsReturnStatus_SavedInDB == "N")
            {
                Response.Redirect("../AfterPayment.aspx?ReferenceNo=" + tr.ReferenceNo, true);
            }
            else
            {
                Response.Redirect(ConfigurationManager.AppSettings["FAIL_URL"].ToString());
            }
        }

        //protected void UPSSBIePay()
        //{
        //    string workingKey = ConfigurationManager.AppSettings["MerchantKey"].ToString();
        //    AES256 aes = new AES256();
        //    string encResponse = aes.Decrypt(Request.Form["encData"], workingKey);
        //    NameValueCollection Params = new NameValueCollection();
        //    string[] segments = encResponse.Split('|');
        //    foreach (string seg in segments)
        //    {
        //        //string[] parts = seg.Split('=');
        //        //if (parts.Length > 0)
        //        //{
        //        //    string Key = parts[0].Trim();
        //        //    string Value = parts[1].Trim();
        //        //    Params.Add(Key, Value);
        //        //}

        //        // 0            1           2          3        4           5           6           7           8           9               10          11        12
        //        //orderReqId | atrn | transStatus | amount | currency | paymode | otherDetails | message | bankCode | bankRefNumber | trascationdate | Country | CIN ||||||||||

        //    }
        //    //if (reg.ValidateDuplicateResponsebyRefNo(segments[0].ToString()) == "No")
        //    //{

        //    if (segments[2] == "SUCCESS") //orderStatus
        //    {
        //        ClientTransaction tranInitiated = new ClientTransaction();
        //        ClientTransaction tranSaved = null;

        //        tranInitiated.IsReturnStatus_SavedInDB = "Y";
        //        tranInitiated.IsLoggedToEgrassServer = "Y";
        //        tranInitiated.PaidStatus = "Y";
        //        tranInitiated.ReferenceNo = segments[0]; // Params["order_id"];
        //        tranInitiated.PayGateId = segments[1]; // Params["tracking_id"]; //"0";
        //        tranInitiated.BankReferenceNo = segments[9]; // Params["bank_ref_no"]; //payResult[0].ToString();
        //        tranInitiated.Optional4 = segments[5];
        //        tranInitiated.Optional5 = "";//segments[13]; 
        //        string upsStatus = segments[2];  //Params["order_status"];
        //        string bankStatus = segments[7];  //Params["status_message"]; 
        //        tranSaved = new ClsEgrasChallanResponseDB().SavePaymentDetails(tranInitiated, upsStatus, bankStatus);

        //        ClientScript.RegisterStartupScript(GetType(), "id", "SucessPayment()", true);
        //        //if (Session["UserLoginID"] == null)
        //        //{
        //        //    //Response.Redirect(ConfigurationManager.AppSettings["FAIL_URL"].ToString() + "?paystatus=" + Params["order_id"] + "&bref=" + Params["bank_ref_no"]);
        //        //    Response.Redirect(ConfigurationManager.AppSettings["FAIL_URL"].ToString() + "?paystatus=" + segments[0] + "&bref=" + segments[9]);
        //        //}
        //        //else
        //        {
        //            //Response.Redirect("../AfterPayment.aspx?ReferenceNo=" + Params["order_id"], true);
        //            Response.Redirect("../AfterPayment.aspx?ReferenceNo=" + segments[0], true);
        //        }
        //    }
        //    else
        //    {
        //        ClientTransaction tranInitiated = new ClientTransaction();
        //        ClientTransaction tranSaved = null;

        //        tranInitiated.IsReturnStatus_SavedInDB = "Y";
        //        tranInitiated.IsLoggedToEgrassServer = "Y";
        //        tranInitiated.PaidStatus = "N";
        //        tranInitiated.ReferenceNo = segments[0]; // Params["order_id"];
        //        tranInitiated.PayGateId = segments[1]; // Params["tracking_id"]; //"0";
        //        tranInitiated.BankReferenceNo = segments[9]; // Params["bank_ref_no"]; //payResult[0].ToString();
        //        tranInitiated.Optional4 = segments[5];
        //        tranInitiated.Optional5 = ""; //segments[13];
        //        string upsStatus = segments[2];  //Params["order_status"];
        //        string bankStatus = segments[7];  //Params["status_message"]; 
        //        tranSaved = new ClsEgrasChallanResponseDB().SavePaymentDetails(tranInitiated, upsStatus, bankStatus);
        //        //Response.Redirect(ConfigurationManager.AppSettings["FAIL_URL"].ToString());
        //        Response.Redirect("PaymentDetails.aspx", true);
        //    }
        //    //}
        //    //else
        //    //{
        //    //    ClientScript.RegisterStartupScript(GetType(), "id", "DuplicateResposeDetected()", true);

        //    //}
        //}
        //protected void UPSCCAvenue()
        //{
        //    string workingKey = ConfigurationManager.AppSettings["WorkingKeyCCA"].ToString();//put in the 32bit alpha numeric key in the quotes provided here
        //    CCACrypto ccaCrypto = new CCACrypto();
        //    string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
        //    NameValueCollection Params = new NameValueCollection();
        //    string[] segments = encResponse.Split('&');
        //    foreach (string seg in segments)
        //    {
        //        string[] parts = seg.Split('=');
        //        if (parts.Length > 0)
        //        {
        //            string Key = parts[0].Trim();
        //            string Value = parts[1].Trim();
        //            Params.Add(Key, Value);
        //        }
        //    }
        //    if (reg.ValidateDuplicateResponsebyRefNo(Params["order_id"].ToString()) == "No")
        //    {

        //        if (Params["order_status"] == "Success")
        //        {
        //            //if (Params["response_code"] != "0")
        //            //{
        //            ClientTransaction tranInitiated = new ClientTransaction();
        //            ClientTransaction tranSaved = null;

        //            tranInitiated.IsReturnStatus_SavedInDB = "Y";
        //            tranInitiated.IsLoggedToEgrassServer = "Y";
        //            tranInitiated.PaidStatus = "Y";
        //            tranInitiated.ReferenceNo = Params["order_id"];
        //            tranInitiated.PayGateId = Params["tracking_id"]; //"0";
        //            tranInitiated.BankReferenceNo = Params["bank_ref_no"]; //payResult[0].ToString();
        //            tranInitiated.Optional4 = "";
        //            tranInitiated.Optional5 = "";
        //            string upsStatus = Params["order_status"];
        //            string bankStatus = Params["status_message"]; // To be added by balaji
        //            tranSaved = new ClsEgrasChallanResponseDB().SavePaymentDetails(tranInitiated, upsStatus, bankStatus);

        //            ClientScript.RegisterStartupScript(GetType(), "id", "SucessPayment()", true);
        //            if (Session["UserLoginID"] == null)
        //            {
        //                Response.Redirect(ConfigurationManager.AppSettings["FAIL_URL"].ToString() + "?paystatus=" + Params["order_id"] + "&bref=" + Params["bank_ref_no"]);
        //            }
        //            else
        //            {
        //                Response.Redirect("../AfterPayment.aspx?ReferenceNo=" + Params["order_id"], true);
        //            }
        //            // }
        //        }
        //        else
        //        {
        //            //if (Params["tracking_id"] != "" && Params["order_id"] != "")
        //            //{
        //            ClientTransaction tranInitiated = new ClientTransaction();
        //            ClientTransaction tranSaved = null;

        //            tranInitiated.IsReturnStatus_SavedInDB = "Y";
        //            tranInitiated.IsLoggedToEgrassServer = "Y";
        //            tranInitiated.PaidStatus = "N";
        //            tranInitiated.ReferenceNo = Params["order_id"];
        //            tranInitiated.PayGateId = Params["tracking_id"]; //"0";
        //            tranInitiated.BankReferenceNo = Params["bank_ref_no"]; //payResult[0].ToString();
        //            tranInitiated.Optional4 = "";
        //            tranInitiated.Optional5 = "";
        //            string upsStatus = Params["order_status"];
        //            string bankStatus = Params["status_message"];
        //            tranSaved = new ClsEgrasChallanResponseDB().SavePaymentDetails(tranInitiated, upsStatus, bankStatus);
        //            //}
        //            Response.Redirect(ConfigurationManager.AppSettings["FAIL_URL"].ToString());
        //        }
        //    }
        //    else
        //    {
        //        ClientScript.RegisterStartupScript(GetType(), "id", "DuplicateResposeDetected()", true);

        //    }
        //}
        public string Easebuzz_Generatehash512(string text)
        {

            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;

        }
        public class ClsEgrasChallanResponseDB
        {

            public ClientTransaction SavePaymentDetails(ClientTransaction obj, string upsStatus, string bankStatus)
            {
                Synthesys.DataAcess.DBConnection db = new Synthesys.DataAcess.DBConnection();
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
                                obs.ApplicationFormNo = ds.Tables[0].Rows[0]["ApplicationFormNo"].ToString();
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