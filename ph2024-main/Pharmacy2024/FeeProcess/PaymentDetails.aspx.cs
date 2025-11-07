using BusinessLayer;
using EntityModel;
using Newtonsoft.Json.Linq;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.FeeProcess
{
    public partial class PaymentDetails : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        ShowMessage shInfo = null;
        private bool _refreshState, _isRefresh;
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["FeeGroupId"] == null || Session["FeeGroupId"].ToString().Trim() == "" || Convert.ToInt64(Session["FeeGroupId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["PhaseId"] == null || Session["PhaseId"].ToString().Trim() == "" || Convert.ToInt64(Session["PhaseId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["PayeeUserTypeId"] == null || Session["PayeeUserTypeId"].ToString().Trim() == "" || Convert.ToInt64(Session["PayeeUserTypeId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["PayeeId"] == null || Session["PayeeId"].ToString().Trim() == "" || Convert.ToInt64(Session["PayeeId"]) <= 0)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {

                if (Convert.ToInt32(Session["UserTypeID"]) == 91 && !reg.isApplicationFormConfirmed(Convert.ToInt64(Session["UserID"])))
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];

                    //PayuGateway objPay = new PayuGateway();
                    //DataSet ds = objPay.GetFailedPaymentDetails(Session["UserID"].ToString());
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    string transectionId = string.Empty;
                    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //    {
                    //        transectionId += ds.Tables[0].Rows[i]["ReferenceNo"] + "|";
                    //    }
                    //    if (transectionId != string.Empty)
                    //    {
                    //        List<TransacionDetils> objList = objPay.GetTransactionsStatus(transectionId.TrimEnd('|'));
                    //        if (objList.Count > 0)
                    //        {
                    //            foreach (var txn in objList)
                    //            {
                    //                if (txn.TransactionStatus == "success")
                    //                    objPay.UpdateTransaction(long.Parse(txn.TransactionID), "Y", txn.BankRefNumber, "Y", true);
                    //                else
                    //                    objPay.UpdateTransaction(long.Parse(txn.TransactionID), "N", "", "Y", false);
                    //            }

                    //        }
                    //    }

                    //}

                    if (objSessionData.ApplicationFormStatus != 'A' && objSessionData.StepID >= 7)
                    {
                        string _leftMenu = ConfigurationManager.AppSettings["LeftMenu_DynamicMaster"];
                        ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormLinks = true;
                        ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFormNumber = false;
                        ((ExpanderMenu)Master.FindControl(_leftMenu)).ShowFadingEffect = true; ((ExpanderMenu)Master.FindControl(_leftMenu)).FormType = 1;
                        ((ExpanderMenu)Master.FindControl(_leftMenu)).FormNumber = Convert.ToInt64(Session["UserID"]);
                    }
                }

                cntPrev.Visible = false;
                cntFail.Visible = false;

                ViewState["Code"] = "";
                if (Request.QueryString["source"] != null && Request.QueryString["source"].ToString() != "")
                {
                    ViewState["Code"] = Request.QueryString["source"].ToString();

                    shInfo.SendMessage("Your  transaction has been made successful. Please take print out of reciept.", ShowMessageType.Information);
                }
                if (Request.QueryString["Code"] != null && Request.QueryString["Code"].ToString() != "")
                {
                    ViewState["Code"] = Request.QueryString["Code"].ToString().Trim();
                }

                //UPSPaymentReconcilation obj = new UPSPaymentReconcilation();
                //obj.CheckPayment(Convert.ToInt64(Session["PayeeId"]), Convert.ToInt32(Session["PayeeUserTypeId"]));
                if (Session["FeeGroupId"].ToString().Trim() == "4")
                {
                    bool ispaidFromAPI = CheckFailedTransactionEasebuzz(Convert.ToInt64(Session["PayeeId"]));
                    if (ispaidFromAPI)
                    {
                        Response.Redirect("../ARAModule/frmInstitute_AdmissionApprovalFeeDetails.aspx", true);
                    }
                }
                loadData(Convert.ToInt32(Session["FeeGroupId"]), Convert.ToInt32(Session["PhaseId"]), Convert.ToInt32(Session["PayeeUserTypeId"]), Convert.ToInt64(Session["PayeeId"]));
            }
        }
        protected void loadData(Int32 FeeGroupId, Int32 PhaseId, Int32 PayeeUserTypeId, Int64 AppFormNo)
        {
            if ((_isRefresh == _refreshState && !IsPostBack) || ((_isRefresh != _refreshState && IsPostBack)))
            {
                DataSet ds = null;
                EGrassery_PaymentDetailsDB cls = null;
                try
                {
                    cls = new EGrassery_PaymentDetailsDB();
                    ds = cls.GetAllPaidTxDB(FeeGroupId, PhaseId, PayeeUserTypeId, AppFormNo);
                    GetAllPaidTx(ds);
                }
                catch (Exception ex)
                {
                    shInfo.SetMessage(ex);
                }
                finally
                {
                    ds = null;
                }
            }
        }
        protected void GetAllPaidTx(DataSet ds)
        {
            bool firsttable = false;
            bool secondtable = false;
            btnPay.Visible = false;

            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdPrevData.DataSource = ds.Tables[0];
                    grdPrevData.DataBind();
                    cntPrev.Visible = true;
                    firsttable = true;
                }
                else
                {
                    cntPrev.Visible = false;
                }

                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    grdFail.DataSource = ds.Tables[1];
                    grdFail.DataBind();
                    cntFail.Visible = true;
                    secondtable = true;
                }
                else
                {
                    cntFail.Visible = false;
                }

                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(ds.Tables[2].Rows[0]["IsPaid"]))
                    {
                        btnPay.Visible = true;
                    }
                    else
                    {
                        btnPay.Visible = true;
                    }
                }

                if (firsttable == false && secondtable == false)
                {
                    if (ConfigurationManager.AppSettings["PaymentGetwayInTest"] != "Yes")
                        Response.Redirect("FeeCart.aspx", true);
                }
            }
        }
        protected void grdPrevData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() != String.Empty)
            {
                DataSet ds = null;
                long TxID = Convert.ToInt64(e.CommandArgument.ToString());

                if (e.CommandName.ToString() == "Cancel")
                {
                    ds = new EGrassery_PaymentDetailsDB().MakeGroupTx_Invalid(TxID, Session["UserLoginId"].ToString());

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["DataSaved"].ToString() == "Y")
                        {
                            shInfo.SetMessage("Transaction " + TxID.ToString() + " has been canceled.", ShowMessageType.Information);
                            ds.Tables.RemoveAt(0);
                            GetAllPaidTx(ds);
                        }
                        else
                        {
                            shInfo.SetMessage("Unable to cancel transaction,Please try again.", ShowMessageType.Information);
                        }
                    }
                }
            }
        }
        protected void grdPrevData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPrevData.EditIndex = -1;
        }
        //protected bool CheckPaymentWITHUPS(int paymentModeId, long referenceNo , double amount, int upsTransactionID)
        //{
        //    bool isDBUpdated = false;
        //    UPSIntegrationHelper oUPSIntegrationHelper1 = null;
        //    UPSClientTransactionInformation oUPSClientTransaction1 = null;
        //    ClientTransaction tranInitiated = null;
        //    EGrassery_PaymentDetailsDB ebc = null;

        //    NameValueCollection data = null;
        //    int purposeId = Convert.ToInt32(ConfigurationManager.AppSettings["TransactionPurposeId"].ToString());
        //    int clientId = Convert.ToInt32(ConfigurationManager.AppSettings["ClientApplicationId"].ToString());

        //    Encryption.UPSClientTransactionInformation transaction = new Encryption.UPSClientTransactionInformation();

        //    transaction.amount = amount;
        //    transaction.clientApplicationId = clientId; 
        //    transaction.clientTranscationRefNumber = referenceNo.ToString();
        //    transaction.transactionPurposeId = purposeId;
        //    transaction.paymentModeId = paymentModeId;
        //    if (upsTransactionID != 0)
        //    {
        //        transaction.upsTransactionID = upsTransactionID;
        //    }

        //    Encryption.UPSIntegrationHelper upsImpl = new Encryption.UPSIntegrationHelper();

        //    string upsString = upsImpl.convertToUPSRequest(transaction);

        //    data = new NameValueCollection();
        //    data.Add("upsString", upsString);        

        //    string host = ConfigurationManager.AppSettings["PGVerify_URL"].ToString();        
        //     try                
        //     {
        //         using (WebClient client = new WebClient())
        //         {
        //             Byte[] response = client.UploadValues(host, "POST", data);
        //             string responseString = Encoding.Default.GetString(response);
        //             oUPSIntegrationHelper1 = new UPSIntegrationHelper();
        //             oUPSClientTransaction1 = new UPSClientTransactionInformation();
        //             oUPSClientTransaction1 = oUPSIntegrationHelper1.convertFromUPSResponse(responseString);
        //             if (oUPSClientTransaction1 != null)
        //             {
        //                 if (String.Compare(oUPSClientTransaction1.bankStatus.ToLower(), "success", true) == 0)
        //                 {
        //                     tranInitiated = new ClientTransaction();

        //                     tranInitiated.IsReturnStatus_SavedInDB = (oUPSClientTransaction1.errorMessage != null && oUPSClientTransaction1.errorMessage.ToLower().Contains("e000")) ? "Y" : "N";
        //                     tranInitiated.IsLoggedToEgrassServer = "Y";
        //                     tranInitiated.PaidStatus = "Y";
        //                     tranInitiated.ReferenceNo = oUPSClientTransaction1.clientTranscationRefNumber;
        //                     tranInitiated.PayGateId = oUPSClientTransaction1.upsTransactionID.ToString();
        //                     tranInitiated.BankReferenceNo = oUPSClientTransaction1.transactionReferenceNumber;
        //                     tranInitiated.Optional4 = oUPSClientTransaction1.errorCode.ToString();
        //                     tranInitiated.Optional5 = oUPSClientTransaction1.errorMessage + " " + oUPSClientTransaction1.status;
        //                     string upsStatus = oUPSClientTransaction1.status;
        //                     string bankStatus = oUPSClientTransaction1.bankStatus;
        //                     ebc = new EGrassery_PaymentDetailsDB();
        //                     isDBUpdated = ebc.SavePaymentDetails(tranInitiated, upsStatus, bankStatus);
        //                 }
        //             }
        //         }
        //     }
        //    catch(Exception ex)
        //    {
        //    }
        //    finally
        //     {
        //         oUPSIntegrationHelper1 = null;
        //         oUPSClientTransaction1 = null;
        //         transaction = null;
        //         data = null;
        //     }
        //     return isDBUpdated;
        //}
        #region Check Refresh
        protected override void LoadViewState(object savedState)
        {
            if (Session["__ISREFRESH"] != null)
            {
                object[] allStates = (object[])savedState;
                base.LoadViewState(allStates[0]);
                _refreshState = (bool)allStates[1];
                _isRefresh = (bool)Session["__ISREFRESH"];
            }

        }
        protected override object SaveViewState()
        {
            Session["__ISREFRESH"] = !_refreshState;
            object[] allStates = new object[2];
            allStates[0] = base.SaveViewState();
            allStates[1] = !_refreshState;
            return allStates;
        }
        #endregion
        protected void btnPay_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["PaymentGetwayInTest"] != "Yes")
                Response.Redirect("FeeCart.aspx", true);
            else
                Response.Redirect("TestFeePage", true);
        }
        protected bool CheckFailedTransactionEasebuzz(Int64 AppformNo)
        {
            DataSet ds = null;
            bool isPaidFromAPI = false;
            string referenceNO = "";
            string feeAmount = "0.0";
            string EmailId = "";
            string MobileNo = "";
            try
            {
                ds = new EGrassery_PaymentDetailsDB().Get_Failed_TransactionToCheckInAPI(AppformNo);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        isPaidFromAPI = false;
                        referenceNO = dr["ReferenceNo"].ToString();
                        feeAmount = dr["FeeAmount"].ToString();
                        EmailId = dr["EmailId"].ToString();
                        MobileNo = dr["MobileNo"].ToString();
                        try
                        {
                            isPaidFromAPI = new EasebuzzHelper().CheckFailedTransactions(referenceNO, feeAmount, EmailId, MobileNo);
                            if (isPaidFromAPI)
                                break;
                        }
                        catch (Exception ex)
                        {
                            Logging.LogException(ex, " API Check for " + referenceNO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, " API Check for " + referenceNO);
            }
            return isPaidFromAPI;
        }
    }
    public class EasebuzzHelper
    {
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
        public bool CheckFailedTransactions(string referenceNo, string feeAmount, string EmailId, string MobileNo)
        {
            bool isPaidFromAPI = false;
            try
            {
                ClientTransaction ft = null;

                string gen_hash;
                string txnid = String.Empty;
                string easebuzz_merchant_key = string.Empty;
                string salt = System.Configuration.ConfigurationSettings.AppSettings["salt"];
                string Key = System.Configuration.ConfigurationSettings.AppSettings["key"];
                string env = System.Configuration.ConfigurationSettings.AppSettings["env"]; //"test";//"prod";

                try
                {
                    System.Collections.Hashtable data = new System.Collections.Hashtable();
                    data.Add("key", Key);
                    data.Add("txnid", referenceNo);
                    data.Add("amount", feeAmount);
                    data.Add("email", EmailId);
                    data.Add("phone", MobileNo);

                    // generate hash
                    string[] hashVarsSeq = "key|txnid|amount|email|phone".Split('|'); // spliting hash sequence from config
                    string hash_string = "";
                    foreach (string hash_var in hashVarsSeq)
                    {
                        hash_string = hash_string + (data.ContainsKey(hash_var) ? data[hash_var].ToString() : "");
                        hash_string = hash_string + '|';
                    }
                    hash_string += salt;// appending SALT
                    Console.WriteLine(hash_string);
                    gen_hash = Easebuzz_Generatehash512(hash_string).ToLower();        //generating hash
                    data.Add("hash", gen_hash);

                    string url = "https://dashboard.easebuzz.in/transaction/v1/retrieve";
                    var request = (HttpWebRequest)WebRequest.Create(url);

                    var postData = "key=" + Key;
                    postData += "&txnid=" + referenceNo;
                    postData += "&amount=" + feeAmount;
                    postData += "&email=" + EmailId;
                    postData += "&phone=" + MobileNo;

                    postData += "&hash=" + gen_hash;

                    var Ndata = Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = Ndata.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(Ndata, 0, Ndata.Length);
                    }

                    var response = (HttpWebResponse)request.GetResponse();

                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    //Response.Write(responseString);
                    //string testResponse = "take it or leave it </br>";

                    /*******************************************************/
                    dynamic jsonData = JObject.Parse(responseString);


                    bool txnStatusFlag = (bool)jsonData.status;
                    if (txnStatusFlag)
                    {
                        string trnStatus = jsonData.msg.status.ToString();

                        if (trnStatus == "success")
                        { // Process only if paid.
                            ft = new ClientTransaction();

                            ft.ReferenceNo = jsonData.msg.txnid.ToString();
                            ft.ApplicationFormNo = jsonData.msg.firstname.ToString();
                            ft.TotalFee = jsonData.msg.amount.ToString();
                            ///*Payment Mode */
                            ft.PaymentMode = jsonData.msg.mode.ToString();
                            ft.PayGateId = jsonData.msg.easepayid.ToString();
                            ft.BankReferenceNo = jsonData.msg.bank_ref_num.ToString();
                            ft.OrderStatus = jsonData.msg.status.ToString();
                            ft.Optional4 = jsonData.msg.mode.ToString();

                            ///*Error Desc */
                            ft.ErrorMessage = jsonData.msg.error.ToString();
                            ft.PaymentGatewayResponse = responseString.ToString();
                            ft.ResponseType = "QAPI";

                            string upsStatus = jsonData.msg.error.ToString();
                            string bankStatus = jsonData.msg.error_Message.ToString();

                            if (trnStatus == "success") // Success
                            {
                                ft.PaidStatus = "Y";
                            }
                            else
                            {
                                ft.PaidStatus = "N";
                            }

                            new EGrassery_PaymentDetailsDB().SavePaymentDetails(ft, upsStatus, bankStatus);

                            if (ft.PaidStatus == "Y")
                            {
                                isPaidFromAPI = true;
                            }
                            ////break;
                        }

                    }
                    request = null;
                    response = null;


                    /*********************************************************************************************/
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "CheckFailedTransactionsNSDL");
                    //Helper.ShowMessage(ex.Message, Helper.WarningType.Danger, this.Page);
                }


            }
            catch (System.Threading.ThreadAbortException t)
            {
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "GetFeeToPay");
            }
            finally
            {

            }

            return isPaidFromAPI;
        }



    }
    public class EGrassery_PaymentDetailsDB
    {
        public DataSet GetAllPaidTxDB(Int32 FeeGroupId, Int32 PhaseId, Int32 UserTypeId, Int64 AppFormNo)
        {
            SqlParameter[] param =
            {
            new SqlParameter("@FeeGroupId", FeeGroupId),
            new SqlParameter("@PhaseId", PhaseId),
            new SqlParameter("@UserTypeId", UserTypeId),
            new SqlParameter("@AppFormNo", AppFormNo)
        };

            //param[0].Value = ;
            //param[1].Value = ;
            //param[2].Value = ;
            //param[3].Value = ;
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("Fee_Client_GetPaymentHistory", param);

            }
            finally
            {
                db.Dispose();
            }
        }
        public bool SavePaymentDetails(ClientTransaction obj, string upsStatus, string bankStatus)
        {
            DataSet ds = null;
            DBConnection db = new DBConnection();
            bool isDBUpdated = false;
            try
            {
                SqlParameter[] param =
                {
                new SqlParameter("@ReferenceNo", SqlDbType.BigInt),
                new SqlParameter("@PayGateId", SqlDbType.VarChar,200),
                new SqlParameter("@BankReferenceNo", SqlDbType.VarChar,50),
                new SqlParameter("@PaidStatus", SqlDbType.Char,1)  ,
                new SqlParameter("@IsValid", SqlDbType.Bit),
                new SqlParameter("@IsReturnRequired",SqlDbType.Bit),	//BIT =1, ---- This parameter will be used , if this procedure will return the value or not
                new SqlParameter("@Option1",SqlDbType.VarChar,200),
                new SqlParameter("@Option2",SqlDbType.VarChar,200),
                new SqlParameter("@Option3",SqlDbType.VarChar,200),
                new SqlParameter("@Option4",SqlDbType.VarChar,200),
                new SqlParameter("@Option5",SqlDbType.VarChar,200),
                new SqlParameter("@UpsStatus",SqlDbType.VarChar,200),
                new SqlParameter("@BankStatus",SqlDbType.VarChar,200)
            };

                param[0].Value = Convert.ToInt64(obj.ReferenceNo);
                param[1].Value = Convert.ToString(obj.PayGateId);  // This given Paygate Id is the TxId of Own Payment gateway : do not confuse with the column paygateId in Own payment gateway.
                param[2].Value = obj.BankReferenceNo;
                param[3].Value = obj.PaidStatus;
                param[4].Value = 0;// obj.IsReturnStatus_SavedInDB == "Y" ? 1 : 0;
                param[5].Value = 1;
                param[6].Value = obj.Optional1;
                param[7].Value = obj.Optional2;
                param[8].Value = obj.Optional3;
                param[9].Value = obj.Optional4;
                param[10].Value = obj.Optional5;
                param[11].Value = upsStatus;
                param[12].Value = bankStatus;

                ds = db.ExecuteDataSet("Fee_Client_SetPaymentResponse", param);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["DataSaved"].ToString().ToUpper().Trim() == "Y")
                    {
                        isDBUpdated = true;
                    }
                }
                param = null;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                db.Dispose();
                ds = null;
            }
            return isDBUpdated;
        }
        public DataSet MakeGroupTx_Invalid(long TxID, string userLoginId)
        {
            SqlParameter[] param =
            {
            new SqlParameter("@TxId", SqlDbType.BigInt),
            new SqlParameter("@UserLoginId", SqlDbType.VarChar,50)
        };

            param[0].Value = TxID;
            param[1].Value = userLoginId;
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("Fee_Client_MakeGroupTx_Invalid", param);

            }
            finally
            {
                db.Dispose();
            }
        }
        public DataSet Get_Failed_TransactionToCheckInAPI(Int64 AppFormNo)
        {
            SqlParameter[] param =
                        {
            new SqlParameter("@AppFormNo", AppFormNo)
        };

            param[0].Value = AppFormNo;

            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("Fee_Get_Failed_TransactionToCheckInAPI", param);
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}