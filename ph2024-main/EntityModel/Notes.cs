using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class Notes
    {
        [JsonProperty("referenceNo")]
        public string FeepayFeeID { get; set; }

        [JsonProperty("pid")]
        public string PersonalID { get; set; }

        [JsonProperty("feefor")]
        public string FeeFor { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("CustomerID")]
        public string CustomerID { get; set; }

        [JsonProperty("ItemName")]
        public string ItemName { get; set; }

        [JsonProperty("ReferenceNo")]
        public string ReferenceNo { get; set; }

        [JsonProperty("PID")]
        public string PID { get; set; }

    }
}
