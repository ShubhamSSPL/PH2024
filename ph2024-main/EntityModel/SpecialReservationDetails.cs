using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class SpecialReservationDetails
    {
        public Int64 PID { get; set; }
        public Int16 PHTypeID { get; set; }
        public Int16 DefenceTypeID { get; set; }
        public string IsOrphan { get; set; }
        public string AppliedForTFWS { get; set; }
        public string OrphanRegistrationNo { get; set; }
        public string OrphanHasRelative { get; set; }
        public string AppliedForMinoritySeats { get; set; }
        public Int16 LinguisticMinorityID { get; set; }
        public Int16 ReligiousMinorityID { get; set; }
    }
}
