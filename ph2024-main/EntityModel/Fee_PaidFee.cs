using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class Fee_PaidFee
    {

        public long ReferenceNo { get; set; }
        public long ApplicationFormNo { get; set; }
        public long CartId { get; set; }
        public string ApplicantName { get; set; }
        public string CandidateAddress { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public decimal FeeAmount { get; set; }
        public long ServiceCharge { get; set; }
        public long TotalAmount { get; set; }
        public bool IsValid { get; set; }
        public bool IsReconciled { get; set; }
        public DateTime TxDate { get; set; }
        public string VendorCode { get; set; }
        public string PaidStatus { get; set; }
        public string Purpose { get; set; }
        public long ProjectId { get; set; }
        public string LastPaymentDate { get; set; }
        public int PhaseId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime RefundDate { get; set; }
        public DateTime ReconciledDate { get; set; }
        public string Remarks { get; set; }
        public string PayGateId { get; set; }
        public string BankReferenceNo { get; set; }
        public string Optional1 { get; set; }
        public string Optional2 { get; set; }
        public string Optional3 { get; set; }
        public string Optional4 { get; set; }
        public string Optional5 { get; set; }
        public string PaymentAccountCode { get; set; }
        public string ClientIP { get; set; }
        public string UPSStatus { get; set; }
        public string BankStatus { get; set; }
        public int FeeGroupId { get; set; }
        public int ClientId { get; set; }
        public int PurposeId { get; set; }
        public int UserTypeId { get; set; }
        public long RefundAmount { get; set; }
        public string RefundStatus { get; set; }
        public string RefundStatusDetails { get; set; }
        public string RefundRRN { get; set; }
        public string RefundOption1 { get; set; }
        public string RefundOption2 { get; set; }
        public string RefundOption3 { get; set; }
        public string RefundOption4 { get; set; }
        public string RefundOption5 { get; set; }
        public string CrById { get; set; }
        public int UPSPaymentModeId { get; set; }
        public string IsProcessed { get; set; }
        public string OrderID { get; set; }
        public string TOrderID { get; set; }
        public string OrderStatus { get; set; }
    }
}
