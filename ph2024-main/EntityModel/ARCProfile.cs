using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class ARCProfile
    {
        public string ARCCode { get; set; }
        public string ARCName { get; set; }
        public string ARCAddress { get; set; }
        public string ARCPhoneNo { get; set; }
        public string ARCFaxNo { get; set; }
        public string CoordinatorName { get; set; }
        public string CoordinatorDesignation { get; set; }
        public DateTime CoordinatorDOB { get; set; }
        public string CoordinatorMobileNo { get; set; }
        public string CoordinatorAltMobileNo { get; set; }
        public string CoordinatorEmailID { get; set; }
        public string CoordinatorPhoneNo { get; set; }
        public Int16 SecurityQuestionID { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string ARCPassword { get; set; }
    }
}
