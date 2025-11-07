using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class AFCProfile
    {
        public string AFCCode { get; set; }
        public string AFCName { get; set; }
        public string AFCAddress { get; set; }
        public string AFCPhoneNo { get; set; }
        public string AFCFaxNo { get; set; }
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
        public string AFCPassword { get; set; }
        public char IsEFC { get; set; }
        public int EFCCapacity { get; set; }
    }
}
