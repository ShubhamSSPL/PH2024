using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class DocumentDetails
    {
        public string DocumentID { get; set; }

        public string DocumentName { get; set; }
        public string IsSubmittedAtFC { get; set; }
        public string IsSubmittedAtARC { get; set; }
        public string IsUploaded { get; set; }
        public string AbsoluteFilePath { get; set; }
    }
}
