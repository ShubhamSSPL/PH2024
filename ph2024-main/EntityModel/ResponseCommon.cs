using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class ResponseCommon
    {
        public Int64 PersonalID { get; set; }
        public Int64 DocumentID { get; set; }
        public string Barcode { get; set; }
        public string ApplicantName { get; set; }
        public string Caste { get; set; }
        public string BenfiName { get; set; }
        public string ClosedOn { get; set; }
        public string DistrictName { get; set; }
        public string PaymentDate { get; set; }
        public string YearsOfResidency { get; set; }
        public string CertificateDate { get; set; }
        public string TribeName { get; set; }
        public string ApplicationType { get; set; }
        public string CommitteeName { get; set; }
        public string CertificateIssuedById { get; set; }
        
        [JsonProperty("Date")]
        public string AllottedDate { get; set; }
        public string PercentageOfDisability { get; set; }
        public string DisabilityType { get; set; }
        public string Years { get; set; }
        public string FirstYearIncome { get; set; }
        public string SecondYearIncome { get; set; }
        public string ThirdYearIncome { get; set; }
        public string CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIPAddress { get; set; }

    }
    public partial class ClosedOn
    {
        [JsonProperty("DateTime")]
        public string DateTime { get; set; }

        [JsonProperty("UtcDateTime")]
        public string UtcDateTime { get; set; }

        [JsonProperty("LocalDateTime")]
        public string LocalDateTime { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Day")]
        public long Day { get; set; }

        [JsonProperty("DayOfWeek")]
        public long DayOfWeek { get; set; }

        [JsonProperty("DayOfYear")]
        public long DayOfYear { get; set; }

        [JsonProperty("Hour")]
        public long Hour { get; set; }

        [JsonProperty("Millisecond")]
        public long Millisecond { get; set; }

        [JsonProperty("Minute")]
        public long Minute { get; set; }

        [JsonProperty("Month")]
        public long Month { get; set; }

        [JsonProperty("Offset")]
        public Dictionary<string, double> Offset { get; set; }

        [JsonProperty("Second")]
        public long Second { get; set; }

        [JsonProperty("Ticks")]
        public double Ticks { get; set; }

        [JsonProperty("UtcTicks")]
        public double UtcTicks { get; set; }

        [JsonProperty("TimeOfDay")]
        public Dictionary<string, double> TimeOfDay { get; set; }

        [JsonProperty("Year")]
        public long Year { get; set; }
    }
}
