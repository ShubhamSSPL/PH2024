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
    public partial class frmMessagesRepliedAFC : System.Web.UI.Page
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

                    gvMessages.DataSource = reg.getAFCRepliedMessages(Session["UserLoginID"].ToString());
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
                            DateTime tempSentDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[4].Text);
                            string SentDate = tempSentDate.Day.ToString() + "/" + tempSentDate.Month.ToString() + "/" + tempSentDate.Year.ToString() + " " + String.Format("{0:T}", tempSentDate);
                            gvMessages.Rows[m].Cells[4].Text = SentDate;

                            DateTime tempReplyDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[6].Text);
                            string ReplyDate = tempReplyDate.Day.ToString() + "/" + tempReplyDate.Month.ToString() + "/" + tempReplyDate.Year.ToString() + " " + String.Format("{0:T}", tempReplyDate);
                            gvMessages.Rows[m].Cells[6].Text = ReplyDate;

                            gvMessages.Rows[m].Cells[0].Text = j.ToString() + ".";
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

        protected void gvMessages_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string From = ((Label)gvMessages.Rows[e.NewSelectedIndex].Cells[7].FindControl("lblFrom")).Text;
                string Sender = gvMessages.Rows[e.NewSelectedIndex].Cells[1].Text;

                Response.Redirect("../AFCModule/frmReplyStarMessagesAFC.aspx?From=" + From + "&Sender=" + From);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvMessages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("gvChildGrid");
                Label lblMessageID = (Label)e.Row.FindControl("lblMessageID");
                Label lblReplyCount = (Label)e.Row.FindControl("lblReplyCount");
                Int64 MessageID = Convert.ToInt64(lblMessageID.Text);
                Int64 ReplyCount = Convert.ToInt64(lblReplyCount.Text);

               
                if (ReplyCount > 1)
                {
                    gv.DataSource = reg.getReplyStarMessageByMessageID(MessageID);
                    gv.DataBind();
                }

            }
        }

        protected void gvMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                //Int64 MessageID = Convert.ToInt64(((Label)gvMessages.Rows[RowID].Cells[8].FindControl("lblMessageID")).Text);

                string From = ((Label)gvMessages.Rows[RowID].Cells[8].FindControl("lblFrom")).Text;
               // string Sender = gvMessages.Rows[RowID].Cells[1].Text;

                if (e.CommandName == "Reply")
                {
                    Response.Redirect("../AFCModule/frmReplyStarMessagesAFC.aspx?From=" + From + "&Sender=" + From);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvMessages_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowExapandEutton();", true);
        }
    }
}