using BusinessLayer;
using EntityModel;
using Razorpay.Api;
using Razorpay.Api.Errors;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
 
using System.Web.UI.WebControls;

namespace Pharmacy2024.AdminModule
{
    public partial class frmCheckHSCResult : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        private string AccessUser = "adminvaibhav";
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
                    ContentTable2.Visible = true;
                    ContentBox1.Visible = false;
                    


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
            lblApplicationID.Text += txtHSCSeatNo.Text;
            lblPersonalID.Text += txtPassingYear.Text;
            DataSet ds = reg.getHSCResult(txtHSCSeatNo.Text, txtPassingYear.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvResult.DataSource = ds;
                        gvResult.DataBind();
                        ContentBox1.Visible = true;
                        ContentTable2.Visible = false;

                    }
                }
            }


        }
       
    }

}