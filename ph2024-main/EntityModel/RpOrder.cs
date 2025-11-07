using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EntityModel
{
    public class RpOrder
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("amount_paid")]
        public string AmountPaid { get; set; }

        [JsonProperty("amount_due")]
        public string AmountDue { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("receipt")]

        public string Receipt { get; set; }

        [JsonProperty("offer_id")]
        public object OfferId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("attempts")]
        public string Attempts { get; set; }

        [JsonProperty("notes")]
        public Notes Notes { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        
        public string RPPaymentId { get; set; }
    }
}
