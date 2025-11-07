using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmEditInstituteProfile : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request.Cookies["Theme"] == null)
            {
                Page.Theme = "default";
            }
            else
            {
                Page.Theme = Request.Cookies["Theme"].Value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int32 InstituteID = Convert.ToInt32(Session["UserID"].ToString());
                    InstituteProfile obj = reg.getInstituteProfile(InstituteID);

                    lblInstituteCode.Text = obj.InstituteCode.ToString();
                    lblInstituteName.Text = obj.InstituteName;
                    lblInstituteAddress.Text = obj.InstituteAddress;
                    txtInstitutePhoneNo.Text = obj.InstitutePhoneNo;
                    txtInstituteFaxNo.Text = obj.InstituteFaxNo;
                    txtCoordinatorName.Text = obj.CoordinatorName;
                    txtCoordinatorDesignation.Text = obj.CoordinatorDesignation;
                    txtCoordinatorDOB.Text = obj.CoordinatorDOB.ToString("dd/MM/yyyy");
                    txtCoordinatorMobileNo.Text = obj.CoordinatorMobileNo;
                    txtCoordinatorAltMobileNo.Text = obj.CoordinatorAltMobileNo;
                    txtCoordinatorEmailID.Text = obj.CoordinatorEmailID;
                    txtCoordinatorPhoneNo.Text = obj.CoordinatorPhoneNo;
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    ContentTable2.Visible = false;
                    shInfo.SetMessage("You are not authorised to Update Profile.", ShowMessageType.Information);
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 InstituteID = Convert.ToInt32(Session["UserID"].ToString());
                InstituteProfile obj = new InstituteProfile();

                obj.InstituteID = InstituteID;
                obj.InstitutePhoneNo = txtInstitutePhoneNo.Text;
                obj.InstituteFaxNo = txtInstituteFaxNo.Text;
                obj.CoordinatorName = txtCoordinatorName.Text;
                obj.CoordinatorDesignation = txtCoordinatorDesignation.Text;
                obj.CoordinatorDOB = Convert.ToDateTime(txtCoordinatorDOB.Text.Split("/".ToCharArray())[1] + "/" + txtCoordinatorDOB.Text.Split("/".ToCharArray())[0] + "/" + txtCoordinatorDOB.Text.Split("/".ToCharArray())[2]);
                obj.CoordinatorMobileNo = txtCoordinatorMobileNo.Text;
                obj.CoordinatorAltMobileNo = txtCoordinatorAltMobileNo.Text;
                obj.CoordinatorEmailID = txtCoordinatorEmailID.Text;
                obj.CoordinatorPhoneNo = txtCoordinatorPhoneNo.Text;

                if (reg.updateInstituteProfile(obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}