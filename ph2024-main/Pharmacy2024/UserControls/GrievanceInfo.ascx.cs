using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.UserControls
{
    public partial class GrievanceInfo : System.Web.UI.UserControl
    {
        public string _GrievanceID { get; set; }
        public string _ApplicationID { get; set; }
        public string _GrievanceCategory { get; set; }
        public string _SentBy { get; set; }
        public DateTime _SentDateTime { get; set; }
        public string _Grievance { get; set; }
        public string _GrievanceFileURL { get; set; }
        public string _RepliedBy { get; set; }
        public DateTime _RepliedDateTime { get; set; }
        public string _RepliedGrievance { get; set; }
        public string _RepliedGrievanceFileURL { get; set; }
        public string _GrievanceStatus { get; set; }
        public DateTime _GrievanceStatusUpdatedDateTime { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GrievanceID.Text = _GrievanceID;
            ApplicationID.Text = _ApplicationID;
            GrievanceCategory.Text = _GrievanceCategory;
            SentBy.Text = _SentBy;
            SentDateTime.Text = _SentDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", _SentDateTime);
            Grievance.Text = _Grievance + (_GrievanceFileURL.Length > 0 ? "&nbsp;&nbsp;&nbsp;<a href='" + _GrievanceFileURL + "' class='second-box'><i class='fa fa-paperclip' style='font-size:20px'></i></a>" : "");
            if (_RepliedGrievance.Length > 0)
            {
                divRepliedGrievance1.Visible = true;
                divRepliedGrievance2.Visible = true;

                RepliedBy.Text = _RepliedBy;
                RepliedDateTime.Text = _RepliedDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", _RepliedDateTime);
                RepliedGrievance.Text = _RepliedGrievance + (_RepliedGrievanceFileURL.Length > 0 ? "&nbsp;&nbsp;&nbsp;<a href='" + _RepliedGrievanceFileURL + "' class='second-box'><i class='fa fa-paperclip' style='font-size:20px'></i></a>" : "");
            }
            GrievanceStatus.Text = _GrievanceStatus;
            GrievanceStatusUpdatedDateTime.Text = _GrievanceStatusUpdatedDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", _GrievanceStatusUpdatedDateTime);
        }
    }
}