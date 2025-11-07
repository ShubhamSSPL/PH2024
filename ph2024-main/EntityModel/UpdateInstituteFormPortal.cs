using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class UpdateInstituteFormPortal
    {
        public List<Master_ChoiceCode> master_ChoiceCodeslst { get; set; }
        public List<Master_Institute> master_Instituteslst { get; set; }
        public List<Master_HomeUniversity> master_HomeUniversitieslst { get; set; }
        public List<Master_Course> master_Courseslst { get; set; }
        public List<viewChoiceCodeListFromPortal> viewChoiceCodeListFromPortalslst { get; set; }
    }
}
