using BusinessLayer;
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

namespace Pharmacy2024.FeeProcess.Generator
{
    public partial class PGRequestRpay : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string action1 = string.Empty;
        public string hash1 = string.Empty;
        public string txnid1 = string.Empty;
        public string strEncRequest = "";
        public string strAccessCode = ConfigurationManager.AppSettings["AccessCodeCCA"].ToString();// put the access key in the quotes provided here.
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
                if (Session["UserLoginID"] == null && Session["UserLoginID"].ToString().Trim() != "")
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
        }
        protected void SetPaymentReference(long cartId, string modeId, string clientIP, string UserLoginId)
        {

            string status = "";
            DataSet ds = null;
            ClsGeneratEgrassSBIChallanUPSDB cls = null;
            try
            {
                cls = new ClsGeneratEgrassSBIChallanUPSDB();
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


                                //New Payment Code
                                if (ConfigurationManager.AppSettings["PaymentBy"] == "Razorpay")
                                {
                                    // LogWriterService.WriteErrorLog("Inside Razorpay", "Creating Payment " + Session["UserLoginID"].ToString());
                                    RazorpayClient client = new RazorpayClient(ConfigurationManager.AppSettings["Rkey"], ConfigurationManager.AppSettings["Rsecret"]);
                                    //    LogWriterService.WriteErrorLog("Inside Razorpay", "Client Generated" + Session["UserLoginID"].ToString());

                                    string rCustID = reg.getRazorpayCustormerID(Convert.ToInt64(ctObj.ApplicationFormNo));
                                    if (rCustID == "")
                                    {
                                        Dictionary<string, object> objCustormer = new Dictionary<string, object>();
                                        string name = "";
                                        if (ctObj.ApplicantName.Length > 49)
                                        {
                                            name = ctObj.ApplicantName.Substring(0, 49);
                                        }
                                        else
                                            name = ctObj.ApplicantName;
                                        objCustormer.Add("name", name);
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

                                    System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();

                                    // LogWriterService.WriteErrorLog("Inside Razorpay", "Order Creating Order " + Session["UserLoginID"].ToString());
                                    Order order = client.Order.Create(objOrder);
                                    //  LogWriterService.WriteErrorLog("Inside Razorpay", "Order Created" + Session["UserLoginID"].ToString());
                                    orderID.Value = order["id"].ToString();
                                    cls.UpdateOrderID(Convert.ToInt64(ctObj.ReferenceNo.ToString()), order["id"].ToString());
                                    payamount.Value = amount.ToString();
                                    nameofpayment.Value = "DTE";
                                    purpose.Value = ctObj.Purpose;
                                    prefilname.Value = ctObj.ApplicantName;
                                    prefilemail.Value = ctObj.EmailId;
                                    prefilmobile.Value = DataEncryption.DecryptDataByEncryptionKey(ctObj.MobileNo);
                                    referenceNo.Value = ctObj.ReferenceNo;
                                    pid.Value = ctObj.ApplicationFormNo;
                                    rzkey.Value = ConfigurationManager.AppSettings["Rkey"];
                                    //LogWriterService.WriteErrorLog("Inside Razorpay", "Call  RazorPay" + Session["UserLoginID"].ToString());
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
        class MyPolicy : ICertificatePolicy
        {
            public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, Int32 certificateProblem)
            {
                return true;
            }
        }
        public class ClsGeneratEgrassSBIChallanUPSDB
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
}