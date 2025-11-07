using BusinessLayer;
using CCA.Util;
using EntityModel;
using Razorpay.Api;
using SynthesysDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace Pharmacy2024.FeeProcess.Generator
{
    public partial class PGRequestEasebuzz : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string action1 = string.Empty;
        public string hash1 = string.Empty;
        public string txnid1 = string.Empty;
        public string strEncRequest = "";
        public string strAccessCode = ConfigurationManager.AppSettings["AccessCodeCCA"].ToString();// put the access key in the quotes provided here.

        public string easebuzz_action_url = string.Empty;
        public string gen_hash;
        public string txnid = String.Empty;
        public string easebuzz_merchant_key = string.Empty;
        public string salt = System.Configuration.ConfigurationSettings.AppSettings["salt"];
        public string Key = System.Configuration.ConfigurationSettings.AppSettings["key"];
        public string env = System.Configuration.ConfigurationSettings.AppSettings["env"]; //"test";//"prod";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null && Session["UserLoginID"] != null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["PayeeId"] == null || Session["PayeeId"].ToString().Trim() == "" || Convert.ToInt64(Session["PayeeId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["PayeeUserTypeId"] == null || Session["PayeeUserTypeId"].ToString().Trim() == "" || Convert.ToInt64(Session["PayeeUserTypeId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            try
            {
                if (IsValidRequest())
                {
                    long cartid;
                    int modeId = 0;

                    cartid = Convert.ToInt64(Page.Request.QueryString["CartId"].Length > 0 ? Page.Request.QueryString["CartId"] : "0");
                    modeId = Convert.ToInt32(Page.Request.QueryString["ModeId"]);


                    if (cartid > 0 && modeId > 0)
                    {
                        SetPaymentReference(cartid, modeId.ToString(), UserInfo.GetIPAddress(), Session["UserLoginID"].ToString());
                    }
                    else
                    {
                        LogWriterService.WriteNormalLog("Invalid Request: Received Invalid Cart ID ");
                        Response.Redirect(ConfigurationManager.AppSettings["ErrorURL"].ToString(), true);
                    }
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception ex)
            {
                LogWriterService.WriteErrorLog(ex.Message, "Generate Egrass Challan");
                Response.Redirect(ConfigurationManager.AppSettings["ErrorURL"].ToString(), true);
            }
        }
        protected void SetPaymentReference(long cartId, string modeId, string clientIP, string UserLoginId)
        {
            string status = "";
            DataSet ds = null;
            ClsGeneratEgrassEasebuzz cls = null;
            try
            {
                cls = new ClsGeneratEgrassEasebuzz();
                ds = cls.SetEgrassPaymentRefNoBZ(cartId, modeId, clientIP, UserLoginId);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["ErrorMsg"].ToString() == "" && Convert.ToInt64(ds.Tables[0].Rows[0]["ReferenceNo"]) > 0 && Convert.ToBoolean(ds.Tables[0].Rows[0]["DataSaved"]))
                        {
                            status = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);

                            if (status.ToUpper().Trim() == "N")
                            {
                                ClientTransaction ctObj = BindModel(ds);
                                DataRow dr = ds.Tables[0].Rows[0];

                                if (ConfigurationManager.AppSettings["PaymentBy"] == "CCAvenue")
                                {
                                    CCACrypto ccaCrypto = new CCACrypto();
                                    string workingKey = ConfigurationManager.AppSettings["WorkingKeyCCA"].ToString();//put in the 32bit alpha numeric key in the quotes provided here 	
                                    string ccaRequest = "tid=" + ctObj.ReferenceNo //ConfigurationManager.AppSettings["HDFCTIN"].ToString()
                                                               + "&merchant_id=" + ConfigurationManager.AppSettings["MerchantIDCCA"].ToString()
                                                               + "&order_id=" + ctObj.ReferenceNo
                                                               + "&amount=" + ctObj.TotalFee
                                                               + "&currency=INR"
                                                               + "&redirect_url=" + ConfigurationManager.AppSettings["SUCCESS_URL"]
                                                               + "&cancel_url=" + ConfigurationManager.AppSettings["CANCEL_URL"]
                                                               + "&merchant_param1=" + Global.ApplicationFormPrefix + ctObj.ApplicationFormNo
                                                               + "&merchant_param2=" + ctObj.ApplicantName
                                                               + "&merchant_param3=" + ctObj.Purpose
                                                               + "&merchant_param4=" + (ctObj.Optional1 + " : " + ctObj.Optional2 + " : " + ctObj.Optional3).ToString()
                                                               + "&merchant_param5=" + ctObj.ItemId;
                                    //billing_name=//billing_address=//billing_city=//    billing_state=//billing_zip=//    billing_country=//billing_tel=//    billing_email=//delivery_name=
                                    //    delivery_address=//delivery_city=//    delivery_state=//delivery_zip=//    delivery_country=//delivery_tel=
                                    // //customer_identifier=

                                    strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);
                                    // Page.Controls.Add(new LiteralControl(strEncRequest));
                                }
                                //New Payment Code
                                else if (ConfigurationManager.AppSettings["PaymentBy"] == "Razorpay")
                                {
                                    // LogWriterService.WriteErrorLog("Inside Razorpay", "Creating Payment " + Session["UserLoginID"].ToString());
                                    RazorpayClient client = new RazorpayClient(ConfigurationManager.AppSettings["Rkey"], ConfigurationManager.AppSettings["Rsecret"]);
                                    //    LogWriterService.WriteErrorLog("Inside Razorpay", "Client Generated" + Session["UserLoginID"].ToString());

                                    string rCustID = reg.getRazorpayCustormerID(Convert.ToInt64(ctObj.ApplicationFormNo));
                                    if (rCustID == "")
                                    {
                                        Dictionary<string, object> objCustormer = new Dictionary<string, object>();
                                        objCustormer.Add("name", ctObj.ApplicantName);
                                        objCustormer.Add("email", ctObj.EmailId);
                                        objCustormer.Add("fail_existing", "0");
                                        objCustormer.Add("contact", DataEncryption.DecryptDataByEncryptionKey(ctObj.MobileNo));
                                        Dictionary<string, object> objCustormerNotes = new Dictionary<string, object>();
                                        objCustormerNotes.Add("PID", ctObj.ApplicationFormNo);
                                        objCustormer.Add("notes", objCustormerNotes);
                                        Customer customer = client.Customer.Create(objCustormer);
                                        rCustID = customer["id"].ToString();
                                        reg.updateRazorpayCustormerID(Convert.ToInt64(ctObj.ApplicationFormNo), rCustID);
                                    }
                                    // LogWriterService.WriteErrorLog("Inside Razorpay", "Creat Order " + Session["UserLoginID"].ToString());
                                    Dictionary<string, object> objOrder = new Dictionary<string, object>();
                                    decimal orderAmount = decimal.Parse(ctObj.FeeAmount) * 100;
                                    long amount = Convert.ToInt64(orderAmount);
                                    //  LogWriterService.WriteErrorLog("Inside Razorpay", "Amount : "+ amount +" " + Session["UserLoginID"].ToString());
                                    Dictionary<string, string> objOrderNote = new Dictionary<string, string>();
                                    objOrderNote.Add("PID", ctObj.ApplicationFormNo);
                                    objOrderNote.Add("Purpose", ctObj.Purpose);
                                    objOrderNote.Add("ItemId", ctObj.ItemId);
                                    objOrderNote.Add("ReferenceNo", ctObj.ReferenceNo);
                                    objOrderNote.Add("ItemName", ctObj.ItemName);
                                    objOrderNote.Add("CustomerID", rCustID);
                                    objOrder.Add("amount", amount);
                                    objOrder.Add("currency", "INR");
                                    objOrder.Add("receipt", ctObj.ReferenceNo);
                                    objOrder.Add("notes", objOrderNote);
                                    objOrder.Add("payment_capture", "1");





                                    // LogWriterService.WriteErrorLog("Inside Razorpay", "Order Creating Order " + Session["UserLoginID"].ToString());
                                    Order order = client.Order.Create(objOrder);
                                    //  LogWriterService.WriteErrorLog("Inside Razorpay", "Order Created" + Session["UserLoginID"].ToString());
                                    //orderID.Value = order["id"].ToString();
                                    cls.UpdateOrderID(Convert.ToInt64(ctObj.ReferenceNo.ToString()), order["id"].ToString());
                                    //payamount.Value = amount.ToString();
                                    //nameofpayment.Value = "DTE";
                                    //purpose.Value = ctObj.Purpose;
                                    //prefilname.Value = ctObj.ApplicantName;
                                    //prefilemail.Value = ctObj.EmailId;
                                    //prefilmobile.Value = DataEncryption.DecryptDataByEncryptionKey(ctObj.MobileNo);
                                    //referenceNo.Value = ctObj.ReferenceNo;
                                    //pid.Value = ctObj.ApplicationFormNo;
                                    //rzkey.Value = ConfigurationManager.AppSettings["Rkey"];
                                    // LogWriterService.WriteErrorLog("Inside Razorpay", "Call  RazorPay" + Session["UserLoginID"].ToString());
                                }
                                else if (ConfigurationManager.AppSettings["PaymentBy"] == "SBI")
                                {
                                    AES256 aes = new AES256();
                                    string strForm = "";
                                    string MerchantId = ConfigurationManager.AppSettings["MerchantId"].ToString();
                                    string MerchantKey = ConfigurationManager.AppSettings["MerchantKey"].ToString();
                                    string RequestUrl = ConfigurationManager.AppSettings["RequestUrl"].ToString();

                                    string MID = MerchantId;
                                    string Collaborator_Id = "SBIEPAY";
                                    string Operating_Mode = "DOM";
                                    string Country = "IN";
                                    string Currency = "INR";
                                    string Amount = ctObj.TotalFee;
                                    string Order_Number = ctObj.ReferenceNo;
                                    string Other_Details = ctObj.Purpose + "^" + Global.ApplicationFormPrefix + ctObj.ApplicationFormNo + "^" + ctObj.ApplicantName + "^" + ctObj.TotalFee + "^" + ctObj.ReferenceNo;
                                    string Success_URL = ConfigurationManager.AppSettings["SUCCESS_URL"]; //"https://test.sbiepay.sbi/secure/success3.jsp";
                                    string Failure_URL = ConfigurationManager.AppSettings["FAIL_URL"].ToString(); //"https://test.sbiepay.sbi/secure/fail3.jsp";
                                    string CustomerId = Global.ApplicationFormPrefix + ctObj.ApplicationFormNo;
                                    string Requestparameter = MID + "|" + Operating_Mode + "|" + Country + "|" + Currency + "|" + Amount + "|" + Other_Details + "|" + Success_URL + "|" + Failure_URL + "|" + Collaborator_Id + "|" + Order_Number + "|" + CustomerId + "|" + "NB" + "|" + "ONLINE" + "|" + "ONLINE";

                                    string EncryptedParam = aes.Encrypt(Requestparameter, MerchantKey);

                                    //merchantId.Value = MerchantId;
                                    //requestUrl.Value = ConfigurationManager.AppSettings["RequestUrl"].ToString();
                                    //requestparams.Value = EncryptedParam;


                                    strForm = "<form id=\"" + "UPSForm" + "\" name=\"" + "UPSForm" + "\" action=\"" + ConfigurationManager.AppSettings["RequestUrl"].ToString() + "\" method=\"POST\">"
                                        + "<input type=\"hidden\" name=\"EncryptTrans\" value=\"" + EncryptedParam + "\" />" +
                                        "<input type=\"hidden\" name=\"merchIdVal\" value=\"" + MerchantId + "\" />" +
                                             "</form><script language=\"javascript\">document.UPSForm.submit();</script>";
                                    Page.Controls.Add(new LiteralControl(strForm));

                                }

                                else if (ConfigurationManager.AppSettings["PaymentBy"] == "Easebuzz")
                                {
                                    string CandidateCount = "";
                                    DataSet dsDashboard = reg.getARAProcessFeeCandidateCount(4, 1, Convert.ToInt32(Session["UserTypeID"].ToString()), Convert.ToInt64(Session["UserLoginID"].ToString()));
                                    if (dsDashboard.Tables[0].Rows.Count > 0)
                                    {
                                        CandidateCount = Convert.ToString(dsDashboard.Tables[0].Rows[0]["CandidateCount"]);
                                    }
                                    string[] hashVarsSeq;
                                    string hash_string = string.Empty;
                                    string saltvalue = salt;
                                    string amount = ctObj.TotalFee;
                                    string firstname = ctObj.ApplicantName;
                                    string email = ctObj.EmailId;
                                    string phone = ctObj.MobileNo;
                                    string productinfo = ctObj.Purpose;
                                    string surl = ConfigurationManager.AppSettings["SUCCESS_URL"];
                                    string furl = ConfigurationManager.AppSettings["CANCEL_URL"];
                                    string InstCode = Session["UserLoginID"].ToString();
                                    string udf1 = ctObj.AdvertiseName; //Udf1;
                                    string udf2 = "B.Pharm / Pharm.D"; //Udf2;
                                    string udf3 = InstCode; //Udf3;
                                    string udf4 = ""; //Udf4;
                                    string udf5 = CandidateCount; //Udf5;
                                    string udf6 = "ARA Processing FEE"; //Udf6;
                                    string udf7 = ""; //Udf7;
                                    string ShowPaymentMode = "";

                                    txnid = ctObj.ReferenceNo;

                                    string paymentUrl = getURL();
                                    // Get configs from web config
                                    easebuzz_action_url = paymentUrl + "/pay/secure";

                                    // generate hash table
                                    System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                                    data.Add("txnid", txnid);
                                    data.Add("key", Key);

                                    amount = amount;
                                    data.Add("amount", amount);
                                    data.Add("firstname", firstname.Trim());
                                    data.Add("email", email.Trim());
                                    data.Add("phone", phone.Trim());
                                    data.Add("productinfo", productinfo.Trim());
                                    data.Add("surl", surl.Trim());
                                    data.Add("furl", furl.Trim());
                                    data.Add("udf1", udf1.Trim());
                                    data.Add("udf2", udf2.Trim());
                                    data.Add("udf3", udf3.Trim());
                                    data.Add("udf4", udf4.Trim());
                                    data.Add("udf5", udf5.Trim());
                                    data.Add("udf6", udf6.Trim());
                                    data.Add("udf7", udf7.Trim());

                                    // generate hash
                                    hashVarsSeq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10".Split('|'); // spliting hash sequence from config
                                    hash_string = "";
                                    foreach (string hash_var in hashVarsSeq)
                                    {
                                        hash_string = hash_string + (data.ContainsKey(hash_var) ? data[hash_var].ToString() : "");
                                        hash_string = hash_string + '|';
                                    }
                                    hash_string += salt;// appending SALT
                                    gen_hash = Easebuzz_Generatehash512(hash_string).ToLower();        //generating hash
                                    data.Add("hash", gen_hash);
                                    data.Add("show_payment_mode", ShowPaymentMode.Trim());

                                    string strForm = Easebuzz_PreparePOSTForm(easebuzz_action_url, data);
                                    Page.Controls.Add(new LiteralControl(strForm));
                                }

                                else
                                {

                                    //PayuGateway objPay = new PayuGateway();

                                    //key.Value = ConfigurationManager.AppSettings["MERCHANT_KEY"];
                                    //string[] hashVarsSeq;
                                    //string hash_string = string.Empty;

                                    //hash1 = objPay.GenerateShashString(ctObj.ReferenceNo, ctObj.FeeAmount, Session["UserLoginID"].ToString() + "-" + ctObj.Optional1 + "-" + ctObj.Optional2 + "-" + ctObj.Optional3 + "-" + ctObj.ItemName, ctObj.ApplicantName, ctObj.EmailId, DataEncryption.DecryptDataByEncryptionKey(ctObj.MobileNo));

                                    //action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment"; // setting URL



                                    //hash.Value = hash1;
                                    //txnid.Value = ctObj.ReferenceNo;


                                    //System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                                    //data.Add("hash", hash.Value);
                                    //data.Add("txnid", txnid.Value);
                                    //data.Add("key", key.Value);
                                    //string AmountForm = Convert.ToDecimal(ctObj.FeeAmount).ToString("g29");// eliminating trailing zeros
                                    ////amount.Text = AmountForm;
                                    //data.Add("amount", AmountForm);
                                    //data.Add("firstname", ctObj.ApplicantName);
                                    //data.Add("email", ctObj.EmailId);
                                    //data.Add("phone", DataEncryption.DecryptDataByEncryptionKey(ctObj.MobileNo));
                                    //data.Add("productinfo", Session["UserLoginID"].ToString() + "-" + ctObj.Optional1 + "-" + ctObj.Optional2 + "-" + ctObj.Optional3 + "-" + ctObj.ItemName);
                                    //data.Add("surl", ConfigurationManager.AppSettings["SUCCESS_URL"]);
                                    //data.Add("furl", ConfigurationManager.AppSettings["FAIL_URL"]);
                                    //data.Add("lastname", "");
                                    //data.Add("curl", ConfigurationManager.AppSettings["CANCEL_URL"]);
                                    //data.Add("address1", "");
                                    //data.Add("address2", "");
                                    //data.Add("city", "");
                                    //data.Add("state", "");
                                    //data.Add("country", "");
                                    //data.Add("zipcode", "");
                                    //data.Add("udf1", "");
                                    //data.Add("udf2", "");
                                    //data.Add("udf3", "");
                                    //data.Add("udf4", "");
                                    //data.Add("udf5", "");
                                    //data.Add("pg", ""); 


                                    //string strForm = objPay.PreparePOSTForm(action1, data);
                                    //Page.Controls.Add(new LiteralControl(strForm));

                                    //End New Payment Code
                                    //Response.Redirect("../../PaymentTest.aspx?ReferenceNo=" + ctObj.ReferenceNo.ToString());
                                    //SendToUPSOnline(ctObj, dr["UPSRequestURL"].ToString(), Convert.ToInt32( dr["UPSClientId"]), Convert.ToInt32(dr["UPSPurposeID"]), Convert.ToInt32(dr["UPSPaymentModeId"]));
                                }

                            }
                            else
                            {
                                Response.Write("Your one payment is in process. Please pay them first");
                            }
                        }
                        else
                        {
                            Response.Write(ds.Tables[0].Rows[0]["ErrorMsg"].ToString());
                        }
                    }
                    else
                    {
                        Response.Write("Please try again.");
                    }
                }
                else
                {
                    Response.Write("Please try again.");
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception ex)
            {
                LogWriterService.WriteErrorLog(ex.Message, "Set payment Ref no.");
                Response.Redirect(ConfigurationManager.AppSettings["ErrorURL"].ToString(), true);
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                }
                cls = null;
            }
        }

        //prepare a postform for redirection to payment gateway
        public string Easebuzz_PreparePOSTForm(string url, System.Collections.Hashtable data)
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (System.Collections.DictionaryEntry key in data)
            {

                strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                               "\" value=\"" + key.Value + "\">");
            }
            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }

        // hashcode generation
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


        //get url using env varibale
        public string getURL()
        {
            if (env == "test")
            {
                string paymentUrl = "https://testpay.easebuzz.in";
                return paymentUrl;
            }
            else
            {
                string paymentUrl = "https://pay.easebuzz.in";
                return paymentUrl;
            }
        }
        protected ClientTransaction BindModel(DataSet ds)
        {
            ClientTransaction ctObj = new ClientTransaction();
            DataRow dr = ds.Tables[0].Rows[0];
            try
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    switch (dc.ColumnName)
                    {
                        case "ApplicantName": ctObj.ApplicantName = dr["ApplicantName"].ToString(); break;
                        case "ApplicationFormNo": ctObj.ApplicationFormNo = dr["ApplicationFormNo"].ToString(); break;
                        case "BankCode": ctObj.BankCode = dr["BankCode"].ToString(); break;
                        case "BankReferenceNo": ctObj.BankReferenceNo = dr["BankReferenceNo"].ToString(); break;
                        case "CandidateAddress": ctObj.CandidateAddress = dr["CandidateAddress"].ToString(); break;
                        case "City": ctObj.City = dr["City"].ToString(); break;
                        case "DOB": ctObj.DOB = dr["DOB"].ToString(); break;
                        case "EmailId": ctObj.EmailId = dr["EmailId"].ToString(); break;
                        case "FatherName": ctObj.FatherName = dr["FatherName"].ToString(); break;
                        case "FeeAmount": ctObj.FeeAmount = dr["FeeAmount"].ToString(); break;
                        case "ItemId": ctObj.ItemId = dr["ItemId"].ToString(); break;
                        case "ItemName": ctObj.ItemName = dr["ItemName"].ToString(); break;
                        case "LastPaymentDate": ctObj.LastPaymentDate = dr["LastPaymentDate"].ToString(); break;
                        case "MobileNo": ctObj.MobileNo = dr["MobileNo"].ToString(); break;
                        case "Optional1": ctObj.Optional1 = dr["Optional1"].ToString(); break;
                        case "Optional2": ctObj.Optional2 = dr["Optional2"].ToString(); break;
                        case "Optional3": ctObj.Optional3 = dr["Optional3"].ToString(); break;
                        case "Optional4": ctObj.Optional4 = dr["Optional4"].ToString(); break;
                        case "Optional5": ctObj.Optional5 = dr["Optional5"].ToString(); break;
                        case "PaidStatus": ctObj.PaidStatus = dr["PaidStatus"].ToString(); break;
                        case "PayGateId": ctObj.PayGateId = dr["PayGateId"].ToString(); break;
                        case "PaymentAccountCode": ctObj.PaymentAccountCode = dr["PaymentAccountCode"].ToString(); break;
                        case "PhaseId": ctObj.PhaseId = dr["PhaseId"].ToString(); break;
                        case "Pincode": ctObj.Pincode = dr["Pincode"].ToString(); break;
                        case "ProjectId": ctObj.ProjectId = dr["ProjectId"].ToString(); break;
                        case "Purpose": ctObj.Purpose = dr["Purpose"].ToString(); break;
                        case "ReferenceNo": ctObj.ReferenceNo = dr["ReferenceNo"].ToString(); break;
                        case "ServiceCharge": ctObj.ServiceCharge = dr["ServiceCharge"].ToString(); break;
                        case "TotalFee": ctObj.TotalFee = dr["TotalFee"].ToString(); break;
                        case "VendorCode": ctObj.VendorCode = dr["VendorCode"].ToString(); break;
                        case "FeeGroupId": ctObj.FeeGroupId = dr["FeeGroupId"].ToString(); break;
                    }
                }
                ctObj.ResponseURL = ""; ///ConfigurationManager.AppSettings["Resoponse_URL"].ToString(); 
            }
            catch (Exception ex)
            {

                LogWriterService.WriteErrorLog(ex.Message, "Binding Transaction Model");
                Response.Redirect(ConfigurationManager.AppSettings["ErrorURL"].ToString(), true);
            }
            return ctObj;
        }
        //protected void SendToUPSOnline(ClientTransaction ct, string actionURL , int upsClientId , int upsPurposeId, int upsPaymentModeId )
        //{        

        //    Encryption.UPSClientTransactionInformation transaction = new Encryption.UPSClientTransactionInformation();

        //    transaction.amount = Convert.ToDouble(ct.TotalFee);
        //    transaction.clientApplicationId = upsClientId;
        //    transaction.clientTranscationRefNumber = ct.ReferenceNo.ToString();
        //    transaction.clientAppTranscationDate = DateTime.Now.ToString().Replace('-','/');
        //    transaction.loginId = Session["UserLoginID"].ToString();
        //    transaction.multipleTransaction = false;
        //    transaction.transactionPurposeId = upsPurposeId;
        //    transaction.paymentModeId = upsPaymentModeId;
        //    transaction.billingCustName = ct.ApplicantName;
        //    transaction.description = ct.Purpose;
        //    transaction.ref1 = ct.ApplicationFormNo.ToString();   // ref1 has been used for AppFormNo
        //    transaction.ref2 = ct.Optional1;        // ref2  sending advt no
        //    transaction.ref3 = ct.Optional2;  // ref3 Postname
        //    transaction.ref4 = ct.LastPaymentDate; // ref4 lastpaymentdate
        //    transaction.ref5 = ct.DOB;  //ref5 Date of birth
        //    transaction.billingCustEmail = ct.EmailId;
        //    transaction.billingCustTel = ct.MobileNo;
        //    transaction.billingCustAddress = ct.CandidateAddress;
        //    transaction.billingZipCode = ct.Pincode;
        //    transaction.billingCustCity = ct.City;

        //    Encryption.UPSIntegrationHelper upsImpl = new Encryption.UPSIntegrationHelper();
        //    string upsString = upsImpl.convertToUPSRequest(transaction);
        //    NameValueCollection data = new NameValueCollection();
        //    data.Add("upsString", upsString);
        //    string strForm = "<form id=\"" + "UPSForm" + "\" name=\"" + "UPSForm" + "\" action=\"" + actionURL + "\" method=\"POST\">" + "<input type=\"hidden\" name=\"upsString\" value=\"" + upsString + "\" /></form><script language=\"javascript\">document.UPSForm.submit();</script>";

        //    Page.Controls.Add(new LiteralControl(strForm));
        //}
        private string MakePOST(string url, System.Collections.SortedList data)      // post form string Postdata
        {
            string formID = "PostForm";
            StringBuilder strForm = new StringBuilder();

            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"POST\">");
            foreach (System.Collections.DictionaryEntry key in data)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + key.Key + "\" value=\"" + key.Value + "\">");
            }
            strForm.Append("</form>");

            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." + formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");

            return strForm.ToString() + strScript.ToString();
        }
        private bool IsValidRequest()
        {
            string signature = "";
            bool isValid = false;//for test purpose only otherwise false
            string SECURE_SECRET = ConfigurationManager.AppSettings["Oasis_SecureHashSecret"].ToString();
            string rawHashData = SECURE_SECRET;
            try
            {
                if (Page.Request.QueryString["vpc_SecureHash"].Length > 0)
                {
                    if (SECURE_SECRET.Length > 0)
                    {
                        foreach (string item in Page.Request.QueryString)
                        {
                            if (!item.Equals("vpc_SecureHash"))
                            {
                                rawHashData += Page.Request.QueryString[item];
                            }
                        }
                    }
                }
                if (SECURE_SECRET.Length > 0)
                {
                    signature = CreateMD5Signature(rawHashData);
                    if (Page.Request.QueryString["vpc_SecureHash"].Equals(signature))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }
            }
            catch (Exception ex)
            {
                LogWriterService.WriteErrorLog(ex.Message, "Validating Request(Client)");
                Response.Redirect(ConfigurationManager.AppSettings["ErrorURL"].ToString(), true);
            }
            return isValid;
        }
        private class VPCStringComparer : IComparer
        {
            public int Compare(Object a, Object b)
            {
                if (a == b) return 0;
                if (a == null) return -1;
                if (b == null) return 1;

                string sa = a as string;
                string sb = b as string;

                System.Globalization.CompareInfo myComparer = System.Globalization.CompareInfo.GetCompareInfo("en-US");
                if (sa != null && sb != null)
                {
                    return myComparer.Compare(sa, sb, System.Globalization.CompareOptions.Ordinal);
                }
                throw new ArgumentException("a and b should be strings.");
            }
        }
        private string CreateMD5Signature(string RawData)
        {
            System.Security.Cryptography.MD5 hasher = System.Security.Cryptography.MD5CryptoServiceProvider.Create();
            byte[] HashValue = hasher.ComputeHash(Encoding.ASCII.GetBytes(RawData));

            string strHex = "";
            foreach (byte b in HashValue)
            {
                strHex += b.ToString("x2");
            }
            return strHex.ToUpper();
        }
        protected string GetIPAddress()
        {
            HttpContext context = HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }

    public class ClsGeneratEgrassEasebuzz
    {

        public DataSet SetEgrassPaymentRefNoBZ(long CartId, string modeId, string clientIP, string UserLoginId)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@CartId", SqlDbType.BigInt)  ,
            new SqlParameter("@PaymentModeId", SqlDbType.VarChar,20),
            new SqlParameter("@ClientIP", SqlDbType.VarChar,50),
            new SqlParameter("@UserLoginId", SqlDbType.VarChar,50)
        };

            parameters[0].Value = CartId;
            parameters[1].Value = modeId;
            parameters[2].Value = clientIP;
            parameters[3].Value = UserLoginId;

            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("Fee_Client_SetPaymentRefNo", parameters);

            }
            finally
            {
                db.Dispose();
            }
        }
        public int UpdateOrderID(long RefrenceNo, string orderId)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@ReferenceNo", SqlDbType.BigInt)  ,
            new SqlParameter("@OrderID", SqlDbType.VarChar,50)
        };

            parameters[0].Value = RefrenceNo;
            parameters[1].Value = orderId;
            DBConnection db = new DBConnection();
            try
            {
                return Convert.ToInt32(db.ExecuteScaler("Fee_Client_SetOrderID", parameters));

            }
            finally
            {
                db.Dispose();
            }
        }
    }
}