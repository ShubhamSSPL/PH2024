using BusinessLayer;
using EntityModel;
using Razorpay.Api;
using Razorpay.Api.Errors;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using Pharmacy2024.FeeProcess;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AdminModule
{
    public partial class RazorPayCheckPayment : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        //private string AccessUserNew = "";
        
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
                    txtApplicationID.Text = Global.ApplicationFormPrefix;
                    ContentTable2.Visible = true;
                    ContentBox1.Visible = false;
                    cntPrev.Visible = false;
                    cntFail.Visible = false;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    ServicePointManager.CertificatePolicy = new MyPolicy();

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        private void LoadPage(Int64 PID)
        {

            List<Fee_PaidFee> fee_PaidFees = new List<Fee_PaidFee>();

            List<Order> lstOrder = new List<Order>();
            fee_PaidFees = reg.GetAllTransectionByPersonalID(PID.ToString());
            foreach (var item in fee_PaidFees)
            {
                if (item.RefundOption5 != null)
                    lstOrder.Add(GetOrder(item.RefundOption5));

            }
            List<RpOrder> lstrpOrder = new List<RpOrder>();
            foreach (Order item in lstOrder)
            {

                RpOrder rpOrder = JsonConvert.DeserializeObject<RpOrder>(item.Attributes.ToString());
                rpOrder.Amount = (Convert.ToInt64(rpOrder.Amount) / 100).ToString();
                rpOrder.AmountPaid = (Convert.ToInt64(rpOrder.AmountPaid) / 100).ToString();
                rpOrder.AmountDue = (Convert.ToInt64(rpOrder.AmountDue) / 100).ToString();
                rpOrder.CreatedAt = UnixTimeStampToDateTime(Convert.ToInt32(rpOrder.CreatedAt)).ToString("dd-MM-yyyy hh:mm tt");
                if (rpOrder.Status == "paid")
                {
                    List<Payment> payments = item.Payments();
                    foreach (var pitem in payments)
                    {
                        RpPayment rpPayment = JsonConvert.DeserializeObject<RpPayment>(pitem.Attributes.ToString());
                        if (rpPayment.Status == "captured")
                        {
                            rpOrder.RPPaymentId = rpPayment.Id;
                        }
                        rpPayment.Amount = (Convert.ToInt64(rpPayment.Amount) / 100).ToString();
                        rpPayment.CreatedAt = UnixTimeStampToDateTime(Convert.ToInt32(rpPayment.CreatedAt)).ToString("dd-MM-yyyy hh:mm tt");
                    }
                }
                lstrpOrder.Add(rpOrder);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(CreateNestedDataTable<RpOrder, Notes>(lstrpOrder, "Notes"));
            gvPaymentStatus.DataSource = ds.Tables[0];
            gvPaymentStatus.DataBind();
            ContentBox1.Visible = true;

            EGrassery_PaymentHistoryDB eGrassery_PaymentHistoryDB = new EGrassery_PaymentHistoryDB();
            DataSet dssystemFee = eGrassery_PaymentHistoryDB.checkPaymentHistory(PID);
            cntFail.Visible = true;
            cntPrev.Visible = true;
            grdPrevData.DataSource = dssystemFee.Tables[0];
            grdPrevData.DataBind();

            grdFail.DataSource = dssystemFee.Tables[1];
            grdFail.DataBind();

            DataSet dsAccess = reg.getMasterUserForReconciliation();
            string AccessUserNew = (string)dsAccess.Tables[0].Rows[0].ItemArray[0];

            for (Int32 i = 0; i < gvPaymentStatus.Rows.Count; i++)
            {
                if (AccessUserNew.Contains(Session["UserLoginId"].ToString()))
                {
                    Int64 RefNo = Convert.ToInt64(gvPaymentStatus.Rows[i].Cells[2].Text);
                    string payid = gvPaymentStatus.Rows[i].Cells[3].Text;
                    string paymentStatus = gvPaymentStatus.Rows[i].Cells[7].Text;
                    Int32 paidAmount = Convert.ToInt32(gvPaymentStatus.Rows[i].Cells[6].Text);

                    if (paymentStatus == "paid" && paidAmount > 0)
                    {
                        dssystemFee.Tables[0].DefaultView.RowFilter = "ReferenceNo ='" + RefNo + "' and Amount = '" + paidAmount + ".00'";
                        if (dssystemFee.Tables[0].DefaultView.Count == 0)
                        {
                            dssystemFee.Tables[0].DefaultView.RowFilter = "Amount = '" + paidAmount + ".00'";
                            if (dssystemFee.Tables[0].DefaultView.Count > 0)
                            {
                                dssystemFee.Tables[1].DefaultView.RowFilter = "ReferenceNo ='" + RefNo + "' and Amount = '" + paidAmount + ".00' and RefundStatus=''";
                                if (dssystemFee.Tables[1].DefaultView.Count > 0)
                                {
                                    gvPaymentStatus.Rows[i].Cells[9].Controls[0].Visible = true;
                                    gvPaymentStatus.Rows[i].BackColor = System.Drawing.Color.Red;
                                }
                                else
                                    gvPaymentStatus.Rows[i].Cells[9].Controls[0].Visible = false;
                            }
                            else
                                gvPaymentStatus.Rows[i].Cells[9].Controls[0].Visible = true;
                        }
                        else
                            gvPaymentStatus.Rows[i].Cells[9].Controls[0].Visible = false;
                    }
                    else
                        gvPaymentStatus.Rows[i].Cells[9].Controls[0].Visible = false;
                }
                else
                {
                    gvPaymentStatus.Rows[i].Cells[9].Controls[0].Visible = false;
                }
            }

        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            lblApplicationID.Text += txtApplicationID.Text;
            Int64 PID = reg.getPersonalID(txtApplicationID.Text);
            lblPersonalID.Text += PID.ToString();
            ContentTable2.Visible = false;
            LoadPage(PID);


        }
        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        private static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
            return (double)unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }

        private List<RpPayment> GetAllPayments()
        {
            string key = ConfigurationManager.AppSettings["RKey"];
            string secret = ConfigurationManager.AppSettings["RSecret"];
            RazorpayClient client = new RazorpayClient(key, secret);
            List<RpPayment> lstrpPayments = new List<RpPayment>();
            for (int i = 0; i < 100000; i++)
            {
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("count", 100);
                options.Add("skip", (i * 100));
                List<Payment> payments = client.Payment.All(options);
                if (payments.Count == 0)
                    break;
                foreach (Payment item in payments)
                {
                    RpPayment rpPayment = JsonConvert.DeserializeObject<RpPayment>(item.Attributes.ToString());
                    rpPayment.Amount = (Convert.ToInt64(rpPayment.Amount) / 100).ToString();
                    rpPayment.CreatedAt = UnixTimeStampToDateTime(Convert.ToInt32(rpPayment.CreatedAt)).ToString("dd-MM-yyyy hh:mm tt");
                    //  if (rpPayment.Status == "captured")
                    lstrpPayments.Add(rpPayment);
                }
            }
            return lstrpPayments;

        }
        private List<RpOrder> GetAllOrders(DateTime from, DateTime to)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            List<RpOrder> lstrpOrder = new List<RpOrder>();
            try
            {
                RazorpayClient client = new RazorpayClient(ConfigurationManager.AppSettings["RKey"], ConfigurationManager.AppSettings["RSecret"]);

                for (int i = 0; i < 100000; i++)
                {
                    Dictionary<string, object> options = new Dictionary<string, object>();
                    options.Add("count", 100);
                    options.Add("skip", (i * 100));
                    options.Add("from", DateTimeToUnixTimestamp(from));
                    options.Add("to", DateTimeToUnixTimestamp(to));
                    //options.Add("notes", txtApplicationID.Text);
                    List<Order> orders = client.Order.All(options);
                    // List<string> lstpersonalID = new List<string>();
                    if (orders.Count == 0)
                        break;
                    foreach (Order item in orders)
                    {

                        RpOrder rpOrder = JsonConvert.DeserializeObject<RpOrder>(item.Attributes.ToString());
                        rpOrder.Amount = (Convert.ToInt64(rpOrder.Amount) / 100).ToString();
                        rpOrder.AmountPaid = (Convert.ToInt64(rpOrder.AmountPaid) / 100).ToString();
                        rpOrder.AmountDue = (Convert.ToInt64(rpOrder.AmountDue) / 100).ToString();
                        rpOrder.CreatedAt = UnixTimeStampToDateTime(Convert.ToInt32(rpOrder.CreatedAt)).ToString("dd-MM-yyyy hh:mm tt");
                        lstrpOrder.Add(rpOrder);
                    }
                }
            }
            catch (GatewayError e)
            {
                Logging.LogException(e, "[Page Level Error]");
                shInfo.SetMessage(e.Message, ShowMessageType.TechnicalError, e.StackTrace);
            }

            return lstrpOrder;
        }

        protected void gvPaymentsStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string payid = e.Row.Cells[3].Text;
                string paymentStatus = e.Row.Cells[7].Text;
                if (paymentStatus == "paid")
                {

                    e.Row.Cells[9].Controls[0].Visible = true;
                }
                else
                    e.Row.Cells[9].Controls[0].Visible = false;
            }
        }
        protected void gvPaymentStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = true;
            try
            {
                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 PID = Convert.ToInt64(gvPaymentStatus.Rows[RowID].Cells[1].Text);
                Int64 ReferenceNo = Convert.ToInt64(gvPaymentStatus.Rows[RowID].Cells[2].Text);
                string PayGateId = gvPaymentStatus.Rows[RowID].Cells[3].Text;

                DataSet dsAccess = reg.getMasterUserForReconciliation();
                string AccessUserNew = (string)dsAccess.Tables[0].Rows[0].ItemArray[0];

                if (e.CommandName == "Reconcile")
                {
                    if (AccessUserNew.Contains(Session["UserLoginId"].ToString()))
                    {

                        if (reg.UpdatePaymentReconcelation(ReferenceNo, PID, PayGateId, Session["UserLoginId"].ToString()))
                        {
                            LoadPage(PID);
                            shInfo.SetMessage("Reconcelation Done.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("Error on Update Reconcelation", ShowMessageType.TechnicalError);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Invalid User Account.", ShowMessageType.Information);
                    }

                }
                else
                {
                    shInfo.SetMessage("Erro on Command.", ShowMessageType.Information);
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        private Order GetOrder(string OrderId)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            Order order = new Order();
            try
            {
                RazorpayClient client = new RazorpayClient(ConfigurationManager.AppSettings["RKey"], ConfigurationManager.AppSettings["RSecret"]);

                order = client.Order.Fetch(OrderId);
            }
            catch (GatewayError e)
            {
                Logging.LogException(e, "[Page Level Error]");
                shInfo.SetMessage(e.Message, ShowMessageType.TechnicalError, e.StackTrace);
            }
            return order;
        }
        public DataTable CreateNestedDataTable<TOuter, TInner>(IEnumerable<TOuter> list, string innerListPropertyName)
        {
            PropertyInfo[] outerProperties = typeof(TOuter).GetProperties().Where(pi => pi.Name != innerListPropertyName).ToArray();
            PropertyInfo[] innerProperties = typeof(TInner).GetProperties();
            MethodInfo innerListGetter = typeof(TOuter).GetProperty(innerListPropertyName).GetMethod;

            // set up columns
            DataTable table = new DataTable();
            foreach (PropertyInfo pi in outerProperties)
                table.Columns.Add(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType);
            foreach (PropertyInfo pi in innerProperties)
                table.Columns.Add(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType);

            // iterate through outer items
            foreach (TOuter outerItem in list)
            {
                var innerList = innerListGetter.Invoke(outerItem, null);//  as IEnumerable<TInner>;
                if (innerList == null)
                {
                    // outer item has no inner items
                    DataRow row = table.NewRow();
                    foreach (PropertyInfo pi in outerProperties)
                        row[pi.Name] = pi.GetValue(outerItem) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                else
                {
                    // iterate through inner items

                    DataRow row = table.NewRow();
                    foreach (PropertyInfo pi in outerProperties)
                        row[pi.Name] = pi.GetValue(outerItem) ?? DBNull.Value;
                    foreach (PropertyInfo pi in innerProperties)
                        row[pi.Name] = pi.GetValue(innerList) ?? DBNull.Value;
                    table.Rows.Add(row);

                }
            }

            return table;
        }
    }
    class MyPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, Int32 certificateProblem)
        {
            return true;
        }
    }
}