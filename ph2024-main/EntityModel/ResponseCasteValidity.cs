using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class ResponseCasteValidity
    {
        [JsonProperty("ApplicantName")]
        public string ApplicantName { get; set; }

        [JsonProperty("DistrictName")]
        public string DistrictName { get; set; }

        [JsonProperty("CertificateDate")]
        public string CertificateDate { get; set; }

        [JsonProperty("TribeName")]
        public string TribeName { get; set; }

        [JsonProperty("ApplicationType")]
        public string ApplicationType { get; set; }

        [JsonProperty("Barcode")]
        public string Barcode { get; set; }

        [JsonProperty("CommitteeName")]
        public string CommitteeName { get; set; }

        [JsonProperty("CertificateIssuedById")]
        public string CertificateIssuedById { get; set; }
    }
}
