using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class ClientTransaction
    {
        private string applicantName = string.Empty;
        private string applicationFormNo = string.Empty;
        private string bankCode = string.Empty;
        private string bankReferenceNo = string.Empty;
        private string candidateAddress = string.Empty;
        private string city = string.Empty;
        private string dOB = string.Empty;
        private string emailId = string.Empty;
        private string fatherName = string.Empty;
        private string feeAmount = string.Empty;
        private string itemId = string.Empty;
        private string itemName = string.Empty;
        private string lastPaymentDate = string.Empty;
        private string mobileNo = string.Empty;
        private string optional1 = string.Empty;
        private string optional2 = string.Empty;
        private string optional3 = string.Empty;
        private string optional4 = string.Empty;
        private string optional5 = string.Empty;
        private string paidStatus = string.Empty;
        private string payGateId = string.Empty;
        private string paymentAccountCode = string.Empty;
        private string phaseId = string.Empty;
        private string pincode = string.Empty;
        private string projectId = string.Empty;
        private string purpose = string.Empty;
        private string referenceNo = string.Empty;
        private string responseURL = string.Empty;
        private string serviceCharge = string.Empty;
        private string totalFee = string.Empty;
        private string vendorCode = string.Empty;
        private string otherDetails = string.Empty;
        private string isLoggedToEgrassServer = string.Empty;
        private string isReturnStatus_SavedInDB = string.Empty;
        private string feeGroupId = string.Empty;
        private string paymentGatewayResponse = string.Empty;
        private string responseType = string.Empty;
        private string errorMessage = string.Empty;
        private string orderStatus = string.Empty;
        private string paymentMode = string.Empty;
        private string advertiseName = string.Empty;

        public string PaymentMode
        {
            get
            {
                return this.paymentMode;
            }
            set
            {
                this.paymentMode = value;
            }
        }
        public string OrderStatus
        {
            get
            {
                return this.orderStatus;
            }
            set
            {
                this.orderStatus = value;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
            set
            {
                this.errorMessage = value;
            }
        }
        public string ApplicantName
        {
            get
            {
                return this.applicantName;
            }
            set
            {
                this.applicantName = value;
            }
        }

        public string ApplicationFormNo
        {
            get
            {
                return this.applicationFormNo;
            }
            set
            {
                this.applicationFormNo = value;
            }
        }

        public string BankCode
        {
            get
            {
                return this.bankCode;
            }
            set
            {
                this.bankCode = value;
            }
        }

        public string BankReferenceNo
        {
            get
            {
                return this.bankReferenceNo;
            }
            set
            {
                this.bankReferenceNo = value;
            }
        }

        public string CandidateAddress
        {
            get
            {
                return this.candidateAddress;
            }
            set
            {
                this.candidateAddress = value;
            }
        }

        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }

        public string DOB
        {
            get
            {
                return this.dOB;
            }
            set
            {
                this.dOB = value;
            }
        }

        public string EmailId
        {
            get
            {
                return this.emailId;
            }
            set
            {
                this.emailId = value;
            }
        }

        public string FatherName
        {
            get
            {
                return this.fatherName;
            }
            set
            {
                this.fatherName = value;
            }
        }

        public string FeeAmount
        {
            get
            {
                return this.feeAmount;
            }
            set
            {
                this.feeAmount = value;
            }
        }

        public string ItemId
        {
            get
            {
                return this.itemId;
            }
            set
            {
                this.itemId = value;
            }
        }

        public string ItemName
        {
            get
            {
                return this.itemName;
            }
            set
            {
                this.itemName = value;
            }
        }

        public string LastPaymentDate
        {
            get
            {
                return this.lastPaymentDate;
            }
            set
            {
                this.lastPaymentDate = value;
            }
        }

        public string MobileNo
        {
            get
            {
                return this.mobileNo;
            }
            set
            {
                this.mobileNo = value;
            }
        }

        public string Optional1
        {
            get
            {
                return this.optional1;
            }
            set
            {
                this.optional1 = value;
            }
        }

        public string Optional2
        {
            get
            {
                return this.optional2;
            }
            set
            {
                this.optional2 = value;
            }
        }

        public string Optional3
        {
            get
            {
                return this.optional3;
            }
            set
            {
                this.optional3 = value;
            }
        }

        public string Optional4
        {
            get
            {
                return this.optional4;
            }
            set
            {
                this.optional4 = value;
            }
        }

        public string Optional5
        {
            get
            {
                return this.optional5;
            }
            set
            {
                this.optional5 = value;
            }
        }

        public string PaidStatus
        {
            get
            {
                return this.paidStatus;
            }
            set
            {
                this.paidStatus = value;
            }
        }

        public string PayGateId
        {
            get
            {
                return this.payGateId;
            }
            set
            {
                this.payGateId = value;
            }
        }

        public string PaymentAccountCode
        {
            get
            {
                return this.paymentAccountCode;
            }
            set
            {
                this.paymentAccountCode = value;
            }
        }

        public string PhaseId
        {
            get
            {
                return this.phaseId;
            }
            set
            {
                this.phaseId = value;
            }
        }

        public string Pincode
        {
            get
            {
                return this.pincode;
            }
            set
            {
                this.pincode = value;
            }
        }

        public string ProjectId
        {
            get
            {
                return this.projectId;
            }
            set
            {
                this.projectId = value;
            }
        }

        public string Purpose
        {
            get
            {
                return this.purpose;
            }
            set
            {
                this.purpose = value;
            }
        }

        public string ReferenceNo
        {
            get
            {
                return this.referenceNo;
            }
            set
            {
                this.referenceNo = value;
            }
        }

        public string ResponseURL
        {
            get
            {
                return this.responseURL;
            }
            set
            {
                this.responseURL = value;
            }
        }

        public string ServiceCharge
        {
            get
            {
                return this.serviceCharge;
            }
            set
            {
                this.serviceCharge = value;
            }
        }

        public string TotalFee
        {
            get
            {
                return this.totalFee;
            }
            set
            {
                this.totalFee = value;
            }
        }

        public string VendorCode
        {
            get
            {
                return this.vendorCode;
            }
            set
            {
                this.vendorCode = value;
            }
        }

        public string OtherDetails
        {
            get
            {
                return this.otherDetails;
            }
            set
            {
                this.otherDetails = value;
            }
        }

        public string IsLoggedToEgrassServer
        {
            get
            {
                return this.isLoggedToEgrassServer;
            }
            set
            {
                this.isLoggedToEgrassServer = value;
            }
        }

        public string IsReturnStatus_SavedInDB
        {
            get
            {
                return this.isReturnStatus_SavedInDB;
            }
            set
            {
                this.isReturnStatus_SavedInDB = value;
            }
        }

        public string FeeGroupId
        {
            get
            {
                return this.feeGroupId;
            }
            set
            {
                this.feeGroupId = value;
            }
        }

        public string PaymentGatewayResponse
        {
            get
            {
                return this.paymentGatewayResponse;
            }
            set
            {
                this.paymentGatewayResponse = value;
            }
        }

        public string ResponseType
        {
            get
            {
                return this.responseType;
            }
            set
            {
                this.responseType = value;
            }
        }
        public string AdvertiseName
        {
            get
            {
                return this.advertiseName;
            }
            set
            {
                this.advertiseName = value;
            }
        }
    }
}
