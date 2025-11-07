using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class DashboardROAdminInstitute
    {
        public int CourseStatusID1 { get; set; }
        public string CourseStatus1 { get; set; }
        public int CourseStatusID2 { get; set; }
        public string CourseStatus2 { get; set; }
        public int CourseStatusID3 { get; set; }
        public string CourseStatus3 { get; set; }
        public int TotalInstitutes { get; set; }
        public int IntakeCurrentYear_AsPerAICTEBeforeLastDate { get; set; }
        public int IntakeCurrentYear_AsPerAICTEAfterLastDate { get; set; }
        public int IntakeCurrentYear_AsPerGR { get; set; }
        public int IntakeCurrentYear_AsPerUniversity { get; set; }
        public int IntakeCurrentYear_AsPerDTEForAdmission { get; set; }
        public int IntakeCurrentYear_FinalForAdmission { get; set; }
        public int RegionID { get; set; }

    }
}
