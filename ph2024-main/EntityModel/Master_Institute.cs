using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class Master_Institute
    {
        public int InstituteID { get; set; }
        public string InstituteCode { get; set; }
        public string InstituteName { get; set; }
        public string InstituteAddress { get; set; }
        public int RegionID { get; set; }
        public string DistrictName { get; set; }
        public string TalukaName { get; set; }
        public string InstituteStatus1 { get; set; }
        public string InstituteStatus2 { get; set; }
        public string InstituteStatus3 { get; set; }
        public int BoysHostelCapacityIYear { get; set; }
        public int GirlsHostelCapacityIYear { get; set; }
        public string PublicRemark { get; set; }
        public char IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIPAddress { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIPAddress { get; set; }
        public string SubROAllotted { get; set; }

    }
}
