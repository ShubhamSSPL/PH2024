using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class QualificationDetails
    {
        public Int64 PID { get; set; }
        public Int16 SSCBoardID { get; set; }
        public string OtherSSCBoard { get; set; }
        public string SSCPassingYear { get; set; }
        public string SSCSeatNo { get; set; }
        public decimal SSCMathMarksObtained { get; set; }
        public decimal SSCMathMarksOutOf { get; set; }
        public decimal SSCMathPercentage { get; set; }
        public string HSCPlace { get; set; }
        public decimal SSCTotalMarksObtained { get; set; }
        public decimal SSCTotalMarksOutOf { get; set; }
        public decimal SSCTotalPercentage { get; set; }
        public string QualifyingExam { get; set; }
        public string QualifyingExamPlace { get; set; }
        public Int16 HSCBoardID { get; set; }
        public string OtherHSCBoard { get; set; }
        public string HSCPassingYear { get; set; }
        public string HSCSeatNo { get; set; }
        public string HSCPassingStatus { get; set; }
        public decimal HSCPhysicsMarksObtained { get; set; }
        public decimal HSCPhysicsMarksOutOf { get; set; }
        public decimal HSCPhysicsPercentage { get; set; }
        public decimal HSCChemistryMarksObtained { get; set; }
        public decimal HSCChemistryMarksOutOf { get; set; }
        public decimal HSCChemistryPercentage { get; set; }
        public decimal HSCMathMarksObtained { get; set; }
        public decimal HSCMathMarksOutOf { get; set; }
        public decimal HSCMathPercentage { get; set; }
        public Int32 HSCSubjectID { get; set; }
        public decimal HSCSubjectMarksObtained { get; set; }
        public decimal HSCSubjectMarksOutOf { get; set; }
        public decimal HSCSubjectPercentage { get; set; }
        public decimal HSCBioTechnologyMarksObtained { get; set; }
        public decimal HSCBioTechnologyMarksOutOf { get; set; }
        public decimal HSCBioTechnologyPercentage { get; set; }
        public decimal HSCEnglishMarksObtained { get; set; }
        public decimal HSCEnglishMarksOutOf { get; set; }
        public decimal HSCEnglishPercentage { get; set; }
        public decimal HSCTotalMarksObtained { get; set; }
        public decimal HSCTotalMarksOutOf { get; set; }
        public decimal HSCTotalPercentage { get; set; }
        public decimal HSCPCSPercentage { get; set; }
        public string AppearedForDiploma { get; set; }
        public decimal HSCPMSPercentage { get; set; }
        public string DiplomaMarksType { get; set; }
        public decimal DiplomaTotalMarksObtained { get; set; }
        public decimal DiplomaTotalMarksOutOf { get; set; }
        public decimal DiplomaTotalPercentage { get; set; }
        public string NameAsPerHSCResult { get; set; }
        public string  IsResultFetched { get; set; }
        public Nullable<DateTime> HSCQDDOB { get; set; }
        public string HSCMotherName { get; set; }

    }
}
