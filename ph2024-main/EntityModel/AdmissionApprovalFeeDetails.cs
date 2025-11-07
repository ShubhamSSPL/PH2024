using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class AdmissionApprovalFeeDetails
    {
        public Int64 FeeID { get; set; }
        public string FeeType { get; set; }
        public string PaymentMode { get; set; }
        public Int64 DDAmount { get; set; }
        public string DDNumber { get; set; }
        public DateTime DDDate { get; set; }
        public Int16 BankID { get; set; }
        public string OtherBankName { get; set; }
        public string BranchName { get; set; }
    }
}
