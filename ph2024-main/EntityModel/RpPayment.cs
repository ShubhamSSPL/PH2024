using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class RpPayment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("invoice_id")]
        public object InvoiceId { get; set; }

        [JsonProperty("international")]
        public bool International { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("amount_refunded")]
        public long AmountRefunded { get; set; }

        [JsonProperty("refund_status")]
        public object RefundStatus { get; set; }

        [JsonProperty("captured")]
        public bool Captured { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("card_id")]
        public object CardId { get; set; }

        [JsonProperty("bank")]
        public object Bank { get; set; }

        [JsonProperty("wallet")]
        public object Wallet { get; set; }

        [JsonProperty("vpa")]
        public string Vpa { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("contact")]
        public string Contact { get; set; }

        [JsonProperty("notes")]
        public Notes Notes { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("tax")]
        public string Tax { get; set; }

        [JsonProperty("error_code")]
        public object ErrorCode { get; set; }

        [JsonProperty("error_description")]
        public object ErrorDescription { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }
}
