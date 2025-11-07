using BusinessLayer;
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
    public partial class frmILSeatAcceptanceFeeNotPaidReport : System.Web.UI.Page
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
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();

                    gvILSeatAcceptanceFeeNotPaidInstituteList.DataSource = reg.getILSeatAcceptanceFeeNotPaidReport(UserTypeID, UserLoginID);
                    gvILSeatAcceptanceFeeNotPaidInstituteList.DataBind();

                    for (Int32 m = 1; m <= gvILSeatAcceptanceFeeNotPaidInstituteList.Rows.Count; m++)
                    {
                        gvILSeatAcceptanceFeeNotPaidInstituteList.Rows[m - 1].Cells[0].Text = m.ToString() + ".";
                    }
                    for (Int32 m = 0; m < gvILSeatAcceptanceFeeNotPaidInstituteList.Rows.Count; m++)
                    {
                        gvILSeatAcceptanceFeeNotPaidInstituteList.Rows[m].Cells[7].Text = DataEncryption.DecryptDataByEncryptionKey(gvILSeatAcceptanceFeeNotPaidInstituteList.Rows[m].Cells[7].Text);
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
}