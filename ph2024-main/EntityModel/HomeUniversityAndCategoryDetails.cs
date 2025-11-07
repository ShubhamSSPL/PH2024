using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class HomeUniversityAndCategoryDetails
    {
        public Int64 PID { get; set; }
        public char DocumentForTypeACode { get; set; }
        public char DocumentOfCode { get; set; }
        public string MothersName { get; set; }
        public Int32 SSCDistrictID { get; set; }
        public Int32 HSCDistrictID { get; set; }
        public Int32 HSCTalukaID { get; set; }
        public Int16 HomeUniversityID { get; set; }
        public Int16 CategoryID { get; set; }
        public string CasteNameForOpen { get; set; }
        public Int32 CasteID { get; set; }
        public string AppliedForEWS { get; set; }
        public char CasteValidityStatus { get; set; }
        public string CVCApplicationNo { get; set; }
        public string CVCApplicationDate { get; set; }
        public string CVCAuthority { get; set; }
        public string CVCName { get; set; }
        public string CCNumber { get; set; }
        public string CVCDistrict { get; set; }
        public char NCLStatus { get; set; }
        public string NCLApplicationNo { get; set; }
        public string NCLApplicationDate { get; set; }
        public string NCLAuthority { get; set; }

        public char EWSStatus { get; set; }
        public string EWSApplicationNo { get; set; }
        public string EWSApplicationDate { get; set; }
        public Int32 EWSDistrict { get; set; }
        public Int32 EWSTaluka { get; set; }
        public Int32 HSCVillageID { get; set; }

    }
}
