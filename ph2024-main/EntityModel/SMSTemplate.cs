using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class SMSTemplate
    {
        public long PID { get; set; }
        public string ProjectName { get; set; }
        public string EmailID { get; set; }
        public string ApplicationID { get; set; }
        public string CandidateName { get; set; }
        public string OTPCode { get; set; }
        public string MobileNo { get; set; }
        public string ValidTill { get; set; }
        public string IPAddress { get; set; }
        public string CancelledBy { get; set; }
        public string CancelledDateTime { get; set; }
        public string ConfirmedDateTime { get; set; }
        public string ConfirmedBy { get; set; }
        public string ReportedBy { get; set; }
        public string ReportedDateTime { get; set; }
        public string SeatAcceptanceStatus { get; set; }
        public string UserLoginID { get; set; }
        public string CurrentDateTime { get; set; }
        public string ChoiceCodeDisplay { get; set; }
        public string InstituteAdmitted { get; set; }
        public string SeatTypeAdmitted { get; set; }
        public string CurrentYear { get; set; }
        public string OldMobileNo { get; set; }
        public string NewMobileNo { get; set; }

        public string InstituteID { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }

        public string AllotmentCancellationRemark { get; set; }
        public string TemplateSMS { get; set; }
        public string GrievanceID { get; set; }
        public string OldMode { get; set; }
        public string NewMode { get; set; }
        public string ConversionStatus { get; set; }
        public string RoundNumber { get; set; }
        public string LastDateofSubmission { get; set; }

    }
}
