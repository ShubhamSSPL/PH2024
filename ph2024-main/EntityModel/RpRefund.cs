using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class RpRefund
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        [JsonProperty("notes")]
        public Notes Notes { get; set; }

        [JsonProperty("receipt")]
        public object Receipt { get; set; }

        [JsonProperty("acquirer_data")]
        public AcquirerData AcquirerData { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("speed_processed")]
        public string SpeedProcessed { get; set; }

        [JsonProperty("speed_requested")]
        public string SpeedRequested { get; set; }
    }
    public partial class AcquirerData
    {
        [JsonProperty("rrn")]
        public string Rrn { get; set; }
    }
}
