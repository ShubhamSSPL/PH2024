using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class RpSettlement
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("fees")]
        public string Fees { get; set; }

        [JsonProperty("tax")]
        public string Tax { get; set; }

        [JsonProperty("utr")]
        public string Utr { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
  
    }
}
