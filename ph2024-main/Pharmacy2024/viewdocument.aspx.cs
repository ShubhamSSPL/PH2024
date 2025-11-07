using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024
{
    public partial class viewdocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["fn"] != null)
            {
                if (Request["fn"].ToLower().Contains(".pdf"))
                {
                    divFrame.Visible = true;
                    imgFile.Visible = false;
                }
                else
                {
                    imgFile.ImageUrl = Request["fn"].ToLower();
                    divFrame.Visible = false;
                    imgFile.Visible = true;
                }
            }
        }
    }
}