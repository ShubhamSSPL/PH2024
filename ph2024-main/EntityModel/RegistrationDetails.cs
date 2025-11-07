using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class RegistrationDetails
    {
        public Int64 PID { get; set; }
        public string CandidateName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public char GenderCode { get; set; }
        public DateTime DOB { get; set; }
        public Int16 ReligionID { get; set; }
        public char RegionCode { get; set; }
        public Int16 MotherTongueID { get; set; }
        public Int16 AnnualFamilyIncomeID { get; set; }
        public string AadhaarNumber { get; set; }
        public Int32 NationalityID { get; set; }
        public string CAddressLine1 { get; set; }
        public string CAddressLine2 { get; set; }
        public string CAddressLine3 { get; set; }
        public string CAddress { get; set; }
        public Int32 CStateID { get; set; }
        public Int32 CDistrictID { get; set; }
        public Int32 CTalukaID { get; set; }
        public Int32 CVillageID { get; set; }
        public string CPincode { get; set; }
        public string STDCode { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string EMailID { get; set; }
        public string HasBankAccount { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
    }
}
