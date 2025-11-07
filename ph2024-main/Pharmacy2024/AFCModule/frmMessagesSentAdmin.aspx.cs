using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityModel;
using System.Data;
using System.Configuration;
using BusinessLayer;
using Synthesys.Controls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmMessagesSentAdmin : System.Web.UI.Page
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
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMessageBoxDocument));
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    gvMessages.DataSource = reg.getAdminSentMessages("AFC");
                    gvMessages.DataBind();

                    Int32 Count = gvMessages.Rows.Count;
                    if (Count == 0)
                    {
                        gvMessages.Visible = false;
                        tblMsg.Visible = true;
                    }
                    else
                    {
                        Int32 j = 1;
                        for (Int32 m = 0; m < Count; m++)
                        {
                            DateTime tempSentDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[3].Text);
                            string SentDate = tempSentDate.Day.ToString() + "/" + tempSentDate.Month.ToString() + "/" + tempSentDate.Year.ToString() + " " + String.Format("{0:T}", tempSentDate);
                            gvMessages.Rows[m].Cells[3].Text = SentDate;

                            gvMessages.Rows[m].Cells[0].Text = j.ToString() + ".";
                            j++;
                        }
                    }

                    gvSMS.DataSource = reg.getAdminSentSMSs("AFC");
                    gvSMS.DataBind();

                    Count = gvSMS.Rows.Count;
                    if (Count == 0)
                    {
                        gvSMS.Visible = false;
                        tblSMS.Visible = true;
                    }
                    else
                    {
                        Int32 j = 1;
                        for (Int32 m = 0; m < Count; m++)
                        {
                            DateTime tempSentDate = Convert.ToDateTime(gvSMS.Rows[m].Cells[3].Text);
                            string SentDate = tempSentDate.Day.ToString() + "/" + tempSentDate.Month.ToString() + "/" + tempSentDate.Year.ToString() + " " + String.Format("{0:T}", tempSentDate);
                            gvSMS.Rows[m].Cells[3].Text = SentDate;

                            gvSMS.Rows[m].Cells[0].Text = j.ToString() + ".";
                            j++;
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
    }
}