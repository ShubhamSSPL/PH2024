using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class InstituteSummary
    {
        public Int32 InstituteID { get; set; }
        public string InstituteCode { get; set; }
        public string InstituteName { get; set; }
        public string InstituteAddress { get; set; }
        public string RegionName { get; set; }
        public string DistrictName { get; set; }
        public string InstituteStatus1 { get; set; }
        public string InstituteStatus2 { get; set; }
        public string InstituteStatus3 { get; set; }
        public Int32 BoysHostelCapacityIYear { get; set; }
        public Int32 GirlsHostelCapacityIYear { get; set; }
        public string PublicRemark { get; set; }
    }
}
