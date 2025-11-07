using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class InstituteProfile
    {
        public Int32 InstituteID { get; set; }
        public string InstituteName { get; set; }
        public string InstituteAddress { get; set; }
        public string InstitutePhoneNo { get; set; }
        public string InstituteFaxNo { get; set; }
        public string CoordinatorName { get; set; }
        public string CoordinatorDesignation { get; set; }
        public DateTime CoordinatorDOB { get; set; }
        public string CoordinatorMobileNo { get; set; }
        public string CoordinatorAltMobileNo { get; set; }
        public string CoordinatorEmailID { get; set; }
        public string CoordinatorPhoneNo { get; set; }
        public string InstituteCode { get; set; }
    }
}
