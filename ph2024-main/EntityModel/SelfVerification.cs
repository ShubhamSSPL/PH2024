using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class SelfVerification
    {
        public Int64 PersonalID { get; set; }
        public string Gender { get; set; }
        public string FinalCandidatureType { get; set; }
        public string FinalCategory { get; set; }
        public string FinalAppliedForEWS { get; set; }
        public string FinalPHType { get; set; }
        public string FinalDefenceType { get; set; }
        public string FinalIsOrphan { get; set; }
        public string FinalAppliedForTFWS { get; set; }
        public string FinalLinguisticMinority { get; set; }
        public string FinalReligiousMinority { get; set; }
        public string SSCMathMarksObtained { get; set; }
        public string SSCTotalMarksObtained { get; set; }
        public string SSCTotalPercentage { get; set; }
        public string FinalIsIntermediateGradeDrawing { get; set; }
        public string HSCPhysicsMarksObtained { get; set; }
        public string HSCChemistryMarksObtained { get; set; }
        public string HSCMathMarksObtained { get; set; }
        public string HSCBiologyMarksObtained { get; set; }
        public string HSCEnglishMarksObtained { get; set; }
        public string HSCTotalMarksObtained { get; set; }
        public string HSCTotalPercentage { get; set; }
        public decimal SSCMathMarksNew { get; set; }
        public decimal SSCTotalMarksNew { get; set; }
        public decimal SSCTotalPercentageNew { get; set; }
        public string FinalIsIntermediateGradeDrawingNew { get; set; }
        public decimal HSCPhysicsMarksNew { get; set; }
        public decimal HSCChemistryMarksNew { get; set; }
        public decimal HSCMathMarksNew { get; set; }
        public decimal HSCBiologyMarksNew { get; set; }
        public decimal HSCEnglishMarksNew { get; set; }
        public decimal HSCTotalMarksNew { get; set; }
        public decimal HSCTotalPercentageNew { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIPAddress { get; set; }
        public string IsGrivanceRaised { get; set; }
        public Int32 ReportedCAPRound { get; set; }
        public string XMLstring { get; set; }
        public Int32 isAllotmentCancellationRequired { get; set; }
        public string Message { get; set; }
        public decimal HSCPhysicsMarksOutofNew { get; set; }
        public decimal HSCChemistryMarksOutofNew { get; set; }
        public decimal HSCMathMarksOutofNew { get; set; }
        public decimal HSCBiologyMarksOutofNew { get; set; }
        public decimal HSCEnglishMarksOutofNew { get; set; }
        public decimal HSCTotalMarksOutofNew { get; set; }
        public decimal HSCTotalPercentageOutofNew { get; set; }
        public decimal SSCMathMarksOutofNew { get; set; }
        public decimal SSCTotalMarksOutofNew { get; set; }


        public string DiplomaMarksType { get; set; }
        public string DiplomaMarksObtained { get; set; }
        public decimal DiplomaMarksNew { get; set; }
        public decimal DiplomaMarksOutofNew { get; set; }
        public int SubjectId { get; set; }

        public string HSCSubjectMarksObtained { get; set; }
        public decimal HSCSubjectMarksNew { get; set; }
        public decimal HSCSubjectMarksOutOfNew { get; set; }


    }
}
