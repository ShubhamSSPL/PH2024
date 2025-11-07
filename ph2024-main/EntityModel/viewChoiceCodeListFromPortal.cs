using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class viewChoiceCodeListFromPortal
    {
        public int InstituteID { get; set; }
        public string InstituteCode { get; set; }
        public string InstituteName { get; set; }
        public string InstituteAddress { get; set; }
        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public string DistrictName { get; set; }
        public string TalukaName { get; set; }
        public string InstituteStatus1 { get; set; }
        public string InstituteStatus2 { get; set; }
        public string InstituteStatus3 { get; set; }
        public string PublicRemark { get; set; }
        public char ApprovedByAICTEForCurrentYear { get; set; }
        public long ChoiceCode { get; set; }
        public string ChoiceCodeDisplay { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string ToBeDisplayedWithCourseName { get; set; }
        public int UniversityID { get; set; }
        public string UniversityName { get; set; }
        public string CourseStatus1 { get; set; }
        public string CourseStatus2 { get; set; }
        public string CourseStatus3 { get; set; }
        public int CourseTypeID { get; set; }
        public string CourseTypeDetails { get; set; }
        public string Shift { get; set; }
        public string Full_Time_Part_Time { get; set; }
        public char Accreditation { get; set; }
        public string AccreditationFrom { get; set; }
        public string AccreditationPeriod { get; set; }
        public string AccreditationDetails { get; set; }
        public string GenderDetails { get; set; }
        public char GenderStatus { get; set; }
        public char IsGov { get; set; }
        public char IsStateLevel { get; set; }
        public char IsTFWS { get; set; }
        public char IsKonkan { get; set; }
        public char IsNRI { get; set; }
        public char IsPIO { get; set; }
        public char IsForeignCollaboration { get; set; }
        public string AffilatedToUniversity { get; set; }
        public char ParticipateInCAP { get; set; }
        public int TotalIntake { get; set; }
        public int CAPSeats { get; set; }
        public int ILSeats { get; set; }
        public int MinoritySeats { get; set; }
        public int IntakeJK { get; set; }
        public decimal CAPSeatsPercentage { get; set; }
        public decimal ILSeatsPercentage { get; set; }
        public decimal MinoritySeatsPercentage { get; set; }
        public string CourtCaseRemark { get; set; }
        public int IntakePreviousYear { get; set; }
        public int IntakeCurrentYear_AsPerAICTEBeforeLastDate { get; set; }
        public int IntakeCurrentYear_AsPerAICTEAfterLastDate { get; set; }
        public int IntakeCurrentYear_AsPerGR { get; set; }
        public int IntakeCurrentYear_AsPerUniversity { get; set; }
        public int IntakeCurrentYear_AsPerDTEForAdmission { get; set; }
        public int IntakeCurrentYear_FinalForAdmission { get; set; }

    }
}
