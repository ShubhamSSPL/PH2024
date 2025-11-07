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
    public partial class frmMessagesNonRepliedAdmin : System.Web.UI.Page
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
                    

                    gvMessages.DataSource = reg.getAdminNonRepliedMessages("INSTITUTE");
                    gvMessages.DataBind();

                    Int32 Count = gvMessages.Rows.Count;
                    if (Count == 0)
                    {
                        gvMessages.Visible = false;
                        tblMsg.Visible = true;
                    }
                    else
                    {
                        for (Int32 m = 0; m < Count; m++)
                        {
                            DateTime tempSentDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[4].Text);
                            string SentDate = tempSentDate.ToString("dd/MM/yyyy") + "<br />" + String.Format("{0:T}", tempSentDate);
                            gvMessages.Rows[m].Cells[4].Text = SentDate;

                            gvMessages.Rows[m].Cells[0].Text = (m + 1).ToString() + ".";
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
        protected void gvMessages_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                //this.Context.Items["From"] = ((Label)gvMessages.Rows[e.NewSelectedIndex].Cells[6].FindControl("lblFrom")).Text;
                //this.Context.Items["Sender"] = gvMessages.Rows[e.NewSelectedIndex].Cells[1].Text;

                //Server.Transfer("../InstituteModule/frmReplyMessagesAdmin.aspx");
                string from = ((Label)gvMessages.Rows[e.NewSelectedIndex].Cells[6].FindControl("lblFrom")).Text;
                string senderstr = gvMessages.Rows[e.NewSelectedIndex].Cells[1].Text;

                Response.Redirect("../InstituteModule/frmReplyMessagesAdmin.aspx?From=" + from + "&Sender=" + senderstr.Replace("<br />", ""));
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}