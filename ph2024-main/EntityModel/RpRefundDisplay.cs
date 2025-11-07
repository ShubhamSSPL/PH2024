using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class RpRefundDisplay
    {
        [JsonProperty("id")]
        public string Id { get; set; }

       

        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        

        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        [JsonProperty("notes")]
        public List<Notes> Notes { get; set; }

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
        public string PaidAmount { get; set; }
        public object Bank { get; set; }
        public object Wallet { get; set; }
        public string Vpa { get; set; }
        public string PaymentStatus { get; set; }
        public string Fee { get; set; }
        public string Tax { get; set; }
        public string TransectionDate { get; set; }
        public string FeepayFeeID { get; set; }
        public string PersonalID { get; set; }
        public string FeeFor { get; set; }
        public string Comment { get; set; }
        public string ItemName { get; set; }
        public string ReferenceNo { get; set; }
        public string PID { get; set; }
        public string OrderId { get; set; }
    }
    
}
