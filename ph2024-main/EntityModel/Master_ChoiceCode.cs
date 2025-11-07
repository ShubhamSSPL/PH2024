using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class Master_ChoiceCode
    {
        public long ChoiceCode { get; set; }
        public string ChoiceCodeDisplay { get; set; }
        public int ChoiceCodeStatusID { get; set; }
        public int InstituteID { get; set; }
        public int UniversityID { get; set; }
        public string CourseCode { get; set; }
        public string CourseStatus1 { get; set; }
        public string CourseStatus2 { get; set; }
        public string CourseStatus3 { get; set; }
        public string CourseShift { get; set; }
        public char Accreditation { get; set; }
        public string AccreditationFrom { get; set; }
        public int AccreditationPeriod { get; set; }
        public char Gender { get; set; }
        public char IsGov { get; set; }
        public char IsStateLevel { get; set; }
        public char IsKonkan { get; set; }
        public char IsNRI { get; set; }
        public char IsPIO { get; set; }
        public int TotalIntake { get; set; }
        public int CAPIntake { get; set; }
        public int ILIntake { get; set; }
        public int MIIntake { get; set; }
        public int JKIntake { get; set; }
        public int CounselingIntake { get; set; }
        public string CourseRemarkToBeDisplayedWithCourseName { get; set; }
        public string CourtCaseRemark { get; set; }
        public char ParticipateInCAP { get; set; }
        public char IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIPAddress { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public String ModifiedByIPAddress { get; set; }

    }
}
