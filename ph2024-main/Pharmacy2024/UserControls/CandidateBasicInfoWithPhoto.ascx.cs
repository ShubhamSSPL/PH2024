using BusinessLayer;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.UserControls
{
    public partial class CandidateBasicInfoWithPhoto : System.Web.UI.UserControl
    {
        public Int64 PID { get; set; }
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonalInformation obj = reg.getPersonalInformation(PID);
           // lblCourseApplied.Text = "Diploma in " + obj.CourseApplied;
            lblApplicationID.Text = obj.ApplicationID;
            lblVersionNo.Text = obj.VersionNo.ToString();
            //imgPhotograph.ImageUrl = "../CandidateModule/frmGetScannedImages.aspx?PID=" + PID.ToString() + "&ImageType=Photograph";
            imgPhotograph.ImageUrl = UserInfo.GetImageURL(PID, "Photograph");

            lblCandidateName.Text =   obj.CandidateName;
            lblGender.Text = obj.Gender;
            lblCandidatureType.Text = obj.FinalCandidatureType;
            lblCategoryForAdmission.Text = obj.FinalCategory;
        }
    }
}