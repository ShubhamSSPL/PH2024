using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class SessionData
    {
        public Int64 PID { get; set; }
        public Int64 CETApplicationFormNo { get; set; }
        public Int16 CandidatureTypeID { get; set; }
        public Int16 StepID { get; set; }
        public Int16 StepIDCAPRound1 { get; set; }
        public Int16 StepIDCAPRound2 { get; set; }
        public Int16 StepIDCAPRound3 { get; set; }
        public Int16 StepIDCAPRound4 { get; set; }
        public char ApplicationFormStatus { get; set; }
        public char OptionFormStatusCAPRound1 { get; set; }
        public char OptionFormStatusCAPRound2 { get; set; }
        public char OptionFormStatusCAPRound3 { get; set; }
        public char OptionFormStatusCAPRound4 { get; set; }
        public Int16 EligibleForCAPRound1 { get; set; }
        public Int16 EligibleForCAPRound2 { get; set; }
        public Int16 EligibleForCAPRound3 { get; set; }
        public Int16 EligibleForCAPRound4 { get; set; }
        public char BankDetailsSkip { get; set; }
    }
}
