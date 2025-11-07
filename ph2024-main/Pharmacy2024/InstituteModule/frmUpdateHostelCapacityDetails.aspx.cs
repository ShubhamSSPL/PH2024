using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmUpdateHostelCapacityDetails : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            Page.Theme = "default";
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
                    if (Convert.ToInt32(Session["UserTypeID"]) != 43)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePage.aspx");
                    }
                    else
                    {
                        Int64 InstituteID = Convert.ToInt64(Session["UserID"]);
                        DataSet ds = reg.getInstituteHostelCapacityDetails(InstituteID);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtBoysHostelCapacityIYear.Text = ds.Tables[0].Rows[0]["BoysHostelCapacityIYear"].ToString();
                            txtGirlsHostelCapacityIYear.Text = ds.Tables[0].Rows[0]["GirlsHostelCapacityIYear"].ToString();
                        }
                        else
                        {
                            ContentTable1.Visible = false;
                            shInfo.SetMessage("You are not authorised to Update Hostel Capacity Details.", ShowMessageType.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 InstituteID = Convert.ToInt64(Session["UserID"]);
                Int32 BoysHostelCapacityIYear = Convert.ToInt32(txtBoysHostelCapacityIYear.Text);
                Int32 GirlsHostelCapacityIYear = Convert.ToInt32(txtGirlsHostelCapacityIYear.Text);

                if (reg.saveInstituteHostelCapacityDetails(InstituteID, BoysHostelCapacityIYear, GirlsHostelCapacityIYear, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    shInfo.SetMessage("Hostel Capacity Details Saved Successfully.", ShowMessageType.Information);
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