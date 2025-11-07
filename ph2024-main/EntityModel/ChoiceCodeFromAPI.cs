using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class ChoiceCodeFromAPI
    {
        public long InstituteId { get; set; }
        public long InstituteCode { get; set; }
        public string InstituteName { get; set; }
        public string InstituteAddress { get; set; }
        public long RegionId { get; set; }
        public string RegionName { get; set; }
        public string DistrictName { get; set; }
        public string TalukaName { get; set; }
        public string InstituteStatus1 { get; set; }
        public string InstituteStatus2 { get; set; }
        public string InstituteStatus3 { get; set; }
        public string PublicRemark { get; set; }
        public string ApprovedByAicteForCurrentYear { get; set; }
        public long ChoiceCode { get; set; }
        public long ChoiceCodeDisplay { get; set; }
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public string ToBeDisplayedWithCourseName { get; set; }
        public long UniversityId { get; set; }
        public string UniversityName { get; set; }
        public string CourseStatus1 { get; set; }
        public string CourseStatus2 { get; set; }
        public string CourseStatus3 { get; set; }
        public long CourseTypeId { get; set; }
        public string CourseTypeDetails { get; set; }
        public string Shift { get; set; }
        public string FullTimePartTime { get; set; }
        public string Accreditation { get; set; }
        public string AccreditationFrom { get; set; }
        public string AccreditationPeriod { get; set; }
        public string AccreditationDetails { get; set; }
        public string GenderDetails { get; set; }
        public string GenderStatus { get; set; }
        public string IsGov { get; set; }
        public string IsStateLevel { get; set; }
       
        public string IsKonkan { get; set; }
        public string IsNri { get; set; }
        public string IsPio { get; set; }
        public string IsForeignCollaboration { get; set; }
        public string AffilatedToUniversity { get; set; }
        public string ParticipateInCap { get; set; }
        public long TotalIntake { get; set; }
        public long CapSeats { get; set; }
        public long IlSeats { get; set; }
        public long MinoritySeats { get; set; }
        public long IntakeJk { get; set; }
        public long CapSeatsPercentage { get; set; }
        public long IlSeatsPercentage { get; set; }
        public long MinoritySeatsPercentage { get; set; }
        public string CourtCaseRemark { get; set; }
        public long IntakePreviousYear { get; set; }
        public long IntakeCurrentYearAsPerAicteBeforeLastDate { get; set; }
        public long IntakeCurrentYearAsPerAicteAfterLastDate { get; set; }
        public long IntakeCurrentYearAsPerGr { get; set; }
        public long IntakeCurrentYearAsPerUniversity { get; set; }
        public long IntakeCurrentYearAsPerDteForAdmission { get; set; }
        public long IntakeCurrentYearFinalForAdmission { get; set; }
    }
}
