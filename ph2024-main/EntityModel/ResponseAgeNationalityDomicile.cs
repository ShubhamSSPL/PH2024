using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class ResponseAgeNationalityDomicile
    {
        [JsonProperty("ApplicantName")]
        public string ApplicantName { get; set; }

        [JsonProperty("Districtname")]
        public string Districtname { get; set; }

        [JsonProperty("YearsOfResidency")]
        public string YearsOfResidency { get; set; }

        [JsonProperty("PaymentDate")]
        public DateTimeOffset PaymentDate { get; set; }

        [JsonProperty("Barcode")]
        public string Barcode { get; set; }

        [JsonProperty("BenfiName")]
        public string BenfiName { get; set; }
    }
}
