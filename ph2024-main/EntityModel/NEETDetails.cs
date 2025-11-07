using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class NEETDetails
    {
        public Int64 PID { get; set; }
        public string AppearedForNEET { get; set; }
        public Int64 NEETRollNo { get; set; }
        public decimal NEETPhysicsScore { get; set; }
        public decimal NEETChemistryScore { get; set; }
        public decimal NEETBiologyScore { get; set; }
        public decimal NEETTotalScore { get; set; }
        public string NameAsPerNEET { get; set; }
        public string NameMatchingFlag { get; set; }
    }
}
