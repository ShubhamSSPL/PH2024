using BusinessLayer;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmCheckPayUTransections : System.Web.UI.Page
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
        protected TimeSpan HeartbeatInterval { get; set; }
        private Thread _ServiceMonitorThread;
        private Thread _SMSChannelThread;
        private readonly ManualResetEvent _ServiceStopEvent = new ManualResetEvent(false);


        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    //HeartbeatInterval = new TimeSpan(0, 0, 1, 0);
                    //_ServiceMonitorThread = new Thread(ServiceMonitorThread);
                    //_ServiceMonitorThread.Start();
                    dbUtility db = new dbUtility();

                    //gvCounts.DataSource = db.GetStatus();
                    //gvCounts.DataBind();
                    DataSet ds = db.GetStatus();
                    int count = ds.Tables[0].Rows.Count;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dr["MobileNo"] = DataEncryption.DecryptDataByEncryptionKey(dr["MobileNo"].ToString());
                        count--;
                    }

                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GridView gvReport = new GridView();
                    gvReport.DataSource = ds;
                    gvReport.DataBind();

                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=fe.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    gvReport.RenderControl(hw);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                    //_ServiceMonitorThread.Abort();
                }
            }
        }
        private void ServiceMonitorThread()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                do
                {
                    if (_SMSChannelThread != null && _SMSChannelThread.IsAlive)
                    {
                        _SMSChannelThread.Join(10 * 1000);
                    }
                    else
                    {
                        _SMSChannelThread = new Thread(vefifyPayment) { Name = "vefifyPayment" };
                        _SMSChannelThread.Start();
                    }

                }
                while (!_ServiceStopEvent.WaitOne(10 * 1000));
            }
            catch (Exception ex)
            {
                _SMSChannelThread.Abort();
                _ServiceMonitorThread.Abort();
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);



            }
        }

        private void vefifyPayment()
        {

            
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            //PayuGateway objPay = new PayuGateway();


            //DataSet ds1 = objPay.GetPaymentDetailsNotVerifyed();
            //if (ds1.Tables[0].Rows.Count > 0)
            //{
            //    string transectionId = string.Empty;
            //    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            //    {
            //        transectionId += ds1.Tables[0].Rows[i]["ReferenceNo"] + "|";
            //    }
            //    if (transectionId != string.Empty)
            //    {
            //        List<TransacionDetils> objList = objPay.GetTransactionsStatus(transectionId.TrimEnd('|'));
            //        if (objList.Count > 0)
            //        {
            //            foreach (var txn in objList)
            //            {
            //                if (txn.TransactionStatus == "success")
            //                    objPay.UpdateBulkVerifyTransaction(long.Parse(txn.TransactionID), "Y", (txn.TransactionID + "|" + txn.TransactionStatus + "|" + txn.BankRefNumber + "|" + txn.Transaction_Amount + "|" + txn.Error_Message).ToString(), DateTime.Parse(txn.PaymentDate), txn.Transaction_Amount);
            //                else
            //                    if (txn.TransactionID != null)
            //                        objPay.UpdateBulkVerifyTransaction(long.Parse(txn.TransactionID), "N", (txn.TransactionID + "|" + txn.TransactionStatus + "|" + txn.BankRefNumber + "|" + txn.Transaction_Amount + "|" + txn.Error_Message).ToString(), DateTime.Parse(txn.PaymentDate), txn.Transaction_Amount);
            //            }
            //        }
            //    }

            //}


            shInfo.SetMessage("PayU Transections Checkd successfully.", ShowMessageType.Information);
        }

        public class dbUtility 
        {
            public DataSet GetStatus()
            {
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("sp_GetVerifyCnt", new SqlParameter[] { });
                }
                finally
                {
                    db.Dispose();
                }

            }
        }

        protected void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            dbUtility db = new dbUtility();
            gvCounts.DataSource = db.GetStatus();
            gvCounts.DataBind();
        }
    }
}