using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class ResponseCasteCertificate
    {
        [JsonProperty("ApplicantName")]
        public string ApplicantName { get; set; }

        [JsonProperty("Caste")]
        public string Caste { get; set; }

        [JsonProperty("ClosedOn")]
        public DateTimeOffset ClosedOn { get; set; }

        [JsonProperty("Barcode")]
        public string Barcode { get; set; }

        [JsonProperty("BenfiName")]
        public string BenfiName { get; set; }
    }
}
