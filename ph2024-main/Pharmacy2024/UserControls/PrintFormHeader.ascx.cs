using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.UserControls
{
    public partial class PrintFormHeader : System.Web.UI.UserControl
    {
        public string HeaderTitle { get; set; }
        public bool CAPTitle { get; set; }
        public bool CAPTitleSpecial { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblHeaderTitle.Text = HeaderTitle;
            if (CAPTitle)
            {
                lblTitle.Visible = true;
            }
            if (CAPTitleSpecial)
            {
                lblTitle.Visible = true;
                lblTitle.Text=  "Minority Status is Applicable for Institution Level and ACAP Seats after CAP";
            }
        }
    }
}