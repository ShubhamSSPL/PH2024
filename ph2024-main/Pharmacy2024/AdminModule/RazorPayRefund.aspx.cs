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
    public partial class RazorPayRefund : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    if (Request.Cookies["Theme"] == null)
        //    {
        //        Page.Theme = "default";
        //    }
        //    else
        //    {
        //        Page.Theme = Request.Cookies["Theme"].Value;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserLoginID"] == null)
            //{
            //    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            //}
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    ServicePointManager.CertificatePolicy = new MyPolicyRefund();
                    List<RpRefundDisplay> lstrpRefundDisplays = new List<RpRefundDisplay>();
                    lstrpRefundDisplays = GetRefund(GetAllRefunds());
                    gvReport.DataSource = lstrpRefundDisplays;
                    gvReport.DataBind();

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
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

        private List<RpRefund> GetAllRefunds()
        {
            List<RpRefund> lstrpPayments = new List<RpRefund>();
            try
            {
                string key = ConfigurationManager.AppSettings["RKey"];
                string secret = ConfigurationManager.AppSettings["RSecret"];
                RazorpayClient client = new RazorpayClient(key, secret);
                for (int i = 0; i < 100000; i++)
                {
                    Dictionary<string, object> options = new Dictionary<string, object>();
                    options.Add("count", 100);
                    options.Add("skip", (i * 100));
                    List<Refund> lstrefunds = client.Refund.All(options);
                    if (lstrefunds.Count == 0)
                        break;
                 
                    foreach (Refund item in lstrefunds)
                    {
                        RpRefund rpPayment = JsonConvert.DeserializeObject<RpRefund>(item.Attributes.ToString());
                        rpPayment.Amount = (Convert.ToInt64(rpPayment.Amount) / 100).ToString();
                        rpPayment.CreatedAt = UnixTimeStampToDateTime(Convert.ToInt32(rpPayment.CreatedAt)).ToString("dd-MM-yyyy hh:mm tt");
                        //  if (rpPayment.Status == "captured")
                        lstrpPayments.Add(rpPayment);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return lstrpPayments;

        }
        public class RefTransactions
        {
            public List<Refund> reftransactions { get; set; }
        }


        private List<RpRefundDisplay> GetRefund(List<RpRefund> lstrefund)
        {
            string key = ConfigurationManager.AppSettings["RKey"];
            string secret = ConfigurationManager.AppSettings["RSecret"];
            RazorpayClient client = new RazorpayClient(key, secret);
            List<RpRefund> lstrpPayments = new List<RpRefund>();

            List<RpRefundDisplay> lstrpRefundDisplays = new List<RpRefundDisplay>();

            foreach (RpRefund item in lstrefund)
            {
                RpRefundDisplay rpRefundDisplay = new RpRefundDisplay();
                Payment payment = client.Payment.Fetch(item.PaymentId);
                RpPayment rpPayment = JsonConvert.DeserializeObject<RpPayment>(payment.Attributes.ToString());
                rpRefundDisplay.Amount =  item.Amount ;
                rpRefundDisplay.CreatedAt =  item.CreatedAt ;
                rpRefundDisplay.Bank = rpPayment.Bank;
                rpRefundDisplay.FeeFor = rpPayment.Notes.FeeFor;
                rpRefundDisplay.PersonalID = rpPayment.Notes.PersonalID;
                rpRefundDisplay.ReferenceNo = rpPayment.Notes.ReferenceNo;
                rpRefundDisplay.OrderId = rpPayment.OrderId;
                rpRefundDisplay.TransectionDate = UnixTimeStampToDateTime(Convert.ToInt32(rpPayment.CreatedAt)).ToString("dd-MM-yyyy hh:mm tt");
                rpRefundDisplay.PaidAmount = (Convert.ToInt64(rpPayment.Amount) / 100).ToString();
                rpRefundDisplay.Fee = (Convert.ToInt64(rpPayment.Fee) / 100).ToString();
                rpRefundDisplay.Tax = (Convert.ToInt64(rpPayment.Tax) / 100).ToString();
                rpRefundDisplay.PaymentId = item.PaymentId;
                rpRefundDisplay.Id = item.Id;
                rpRefundDisplay.PaymentStatus = rpPayment.Status;
                lstrpRefundDisplays.Add(rpRefundDisplay);
            }

            return lstrpRefundDisplays;

        }

        protected void gvReport_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
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
    class MyPolicyRefund : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, Int32 certificateProblem)
        {
            return true;
        }
    }
}