using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BusinessLayer;
using Synthesys.Controls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmReplyMessagesRO : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMessageBoxDocument));
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    if (Request.QueryString["From"] == null || Request.QueryString["Sender"] == null)
                    {
                        Response.Redirect("../AFCModule/frmMessagesNonRepliedRO.aspx");
                    }
                    else
                    {
                        string From = Request.QueryString["From"].ToString();
                        string Sender = Request.QueryString["Sender"].ToString();

                        ContentTable2.HeaderText = "Reply Message from " + Sender.Replace("<br />", " ");

                        gvMessages.DataSource = reg.getMessagesList(From);
                        gvMessages.DataBind();

                        Int32 Count = gvMessages.Rows.Count;
                        if (Count == 0)
                        {
                            Response.Redirect("../AFCModule/frmMessagesNonRepliedRO.aspx");
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
        protected void gvMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 MessageID = Convert.ToInt64(((Label)gvMessages.Rows[RowID].Cells[3].FindControl("lblMessageID")).Text);
                string RepliedMessage = ((TextBox)gvMessages.Rows[RowID].Cells[1].FindControl("txtRepliedMessage")).Text;

                if (e.CommandName == "Reply")
                {
                    if (RepliedMessage.Length > 0)
                    {
                        string From = Request.QueryString["From"].ToString();

                        if (reg.replyMessage(MessageID, RepliedMessage, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), From,"N"))
                        {
                            gvMessages.DataSource = reg.getMessagesList(From);
                            gvMessages.DataBind();

                            Int32 Count = gvMessages.Rows.Count;
                            if (Count == 0)
                            {
                                Response.Redirect("../AFCModule/frmMessagesNonRepliedRO.aspx");
                            }

                            shInfo.SetMessage("Message Replied Successfully.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("Technical Problem In Saving Data. Please Try After sometime.", ShowMessageType.Information);
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("Please Enter Replied Message.", ShowMessageType.Information);
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