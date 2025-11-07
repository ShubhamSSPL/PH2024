using Synthesys.Controls;
using System;
using System.Web.UI;
using Pharmacy2024;
using BusinessLayer;

namespace Pharmacy2024.RegistrationModule
{
    public partial class frmInstructionsAfterRegistration : System.Web.UI.Page
    {
        public string AdmissionYear = Global.AdmissionYear;
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    string ApplicationID = Request.QueryString["ApplicationID"];
                    string Code = Request.QueryString["Code"];

                    if(reg.AuthenticateCandidateisActive(ApplicationID))
                    {
                        if (ApplicationID.GetHashCode().ToString() == Code)
                        {
                            lblApplicationID.Text = ApplicationID;
                        }
                        else
                        {
                            Response.Write("<BR /><BR /><center><H1>You are not authorised to see this page.</H1></center>");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Redirect("../StaticPages/frmLoginPage");
                    }
                    
                }
                catch (Exception ex)
                {
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            Response.Redirect("../StaticPages/frmLoginPage");
        }
    }
}