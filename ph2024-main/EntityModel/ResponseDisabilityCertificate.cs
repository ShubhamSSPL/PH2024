using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class ResponseDisabilityCertificate
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DistrictName")]
        public string DistrictName { get; set; }

        [JsonProperty("PercentageOfDisability")]
        public string PercentageOfDisability { get; set; }

        [JsonProperty("DisabilityType")]
        public string DisabilityType { get; set; }

        [JsonProperty("Date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("Barcode")]
        public string Barcode { get; set; }
    }
    public class ResponseNCL
    {
        [JsonProperty("ApplicantName")]
        public string ApplicantName { get; set; }

        [JsonProperty("Years")]
        public string Years { get; set; }

        [JsonProperty("FirstYearIncome")]
        public string FirstYearIncome { get; set; }

        [JsonProperty("SecondYearIncome")]
        public string SecondYearIncome { get; set; }

        [JsonProperty("ThirdYearIncome")]
        public string ThirdYearIncome { get; set; }

        [JsonProperty("Barcode")]
        public string Barcode { get; set; }

        [JsonProperty("BenfiName")]
        public string BenfiName { get; set; }
    }
}
