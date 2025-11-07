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
using RestSharp;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AdminModule
{
    public partial class RazorPaySettlement : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request.Cookies["Theme"] == null)
            {
                //  Page.Theme = "default";
            }
            else
            {
                // Page.Theme = Request.Cookies["Theme"].Value;
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

                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    ServicePointManager.CertificatePolicy = new MyPolicys();

                    AllSetelments();


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
        public void AllSetelments()
        {
            try
            {
                //string key = ConfigurationManager.AppSettings["RKey"];
                //string secret = ConfigurationManager.AppSettings["RSecret"];
                //RazorpayClient client = new RazorpayClient(key, secret);

                var client = new RestSharp.RestClient("https://api.razorpay.com/v1/settlements?count=100");
                var request = new RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("Authorization", "Basic cnpwX2xpdmVfaFZsT0FUVzRGdXRsdlk6MGFWdFlxcjRRdWxpSXliRHpFVFVBVnla");
                IRestResponse response = client.Execute(request);
                SettementRazorPay settlements = JsonConvert.DeserializeObject<SettementRazorPay>(response.Content);
                foreach (var item in settlements.items)
                {
                    item.Amount = (Convert.ToInt64(item.Amount) / 100).ToString();
                    item.CreatedAt = UnixTimeStampToDateTime(Convert.ToInt32(item.CreatedAt)).ToString("dd-MM-yyyy");
                    item.Fees = (Convert.ToInt64(item.Fees) / 100).ToString();
                    item.Tax = (Convert.ToInt64(item.Tax) / 100).ToString();
                }
                gvReport.DataSource = settlements.items;
                gvReport.DataBind();
                Int64 TotalAmount = 0;
                Int64 TotalFee = 0;
                Int64 TotalTax = 0;
                for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                {
                    TotalAmount += Convert.ToInt64((gvReport.Rows[i].Cells[5].Text));
                    TotalFee += Convert.ToInt64((gvReport.Rows[i].Cells[6].Text));
                    TotalTax += Convert.ToInt64((gvReport.Rows[i].Cells[7].Text));
                }
                gvReport.FooterRow.Cells[0].ColumnSpan = 5;
                gvReport.FooterRow.Cells.RemoveAt(1);
                gvReport.FooterRow.Cells.RemoveAt(2);
                gvReport.FooterRow.Cells.RemoveAt(3);
                gvReport.FooterRow.Cells.RemoveAt(4);
             

                gvReport.FooterRow.Cells[0].Text = "Total as On " + DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                gvReport.FooterRow.Cells[1].Text = TotalAmount.ToString();
                gvReport.FooterRow.Cells[2].Text = TotalFee.ToString();
                gvReport.FooterRow.Cells[3].Text = TotalTax.ToString();
                gvReport.FooterRow.Cells[0].Font.Bold = true;
                gvReport.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gvReport.FooterRow.Cells[1].Font.Bold = true;
                gvReport.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                gvReport.FooterRow.Cells[2].Font.Bold = true;
                gvReport.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                gvReport.FooterRow.Cells[3].Font.Bold = true;
                gvReport.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;

            }
            catch (Exception ex)
            {
                throw ex;
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
    public class SettementRazorPay
    {
        public List<RpSettlement> items { get; set; }
        public string entity { get; set; }
        public string count { get; set; }
    }
    class MyPolicys : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, Int32 certificateProblem)
        {
            return true;
        }
    }
}