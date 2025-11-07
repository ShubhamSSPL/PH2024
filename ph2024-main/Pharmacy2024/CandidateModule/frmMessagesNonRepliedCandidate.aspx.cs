using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace Pharmacy2024.CandidateModule
{
    public partial class frmMessagesNonRepliedCandidate : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    if (Request.Cookies["Theme"] == null)
        //    {
        //        Page.Theme = "default";
        //    }
        //    else
        //    {
        //        Page.Theme = Request.Cookies["Theme"].Value;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMessageBoxDocument));
            var ss = Session["UserLoginID"].ToString().Substring(4);
            Int64 PersonalID = Convert.ToInt64(ss);
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!reg.CheckCandidateValidForMessage(PersonalID))
            {
                Session["Error"] = "Your Application form is not confirmed So you are not able to send Message to Admin.";
                Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx",true);
            }
            if (!IsPostBack)
            {
                try
                {


                    gvMessages.DataSource = reg.getCandidateNonRepliedMessages(Session["UserLoginID"].ToString());
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
                           // DateTime tempSentDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[3].Text);
                            DateTime tempSentDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[4].Text);
                            string SentDate = tempSentDate.Day.ToString() + "/" + tempSentDate.Month.ToString() + "/" + tempSentDate.Year.ToString() + " " + String.Format("{0:T}", tempSentDate);
                            gvMessages.Rows[m].Cells[3].Text = SentDate;

                            gvMessages.Rows[m].Cells[0].Text = j.ToString() + ".";
                            j++;
                        }
                    }

                    //gvBroadcastMessage.DataSource = reg.getAFCBroadcastedMessages(Session["UserLoginID"].ToString());
                    //gvBroadcastMessage.DataBind();

                    //Count = gvBroadcastMessage.Rows.Count;
                    //if (Count == 0)
                    //{
                    //    pB.Visible = false;
                    //}
                    //else
                    //{
                    //    Int32 j = 1;
                    //    for (Int32 m = 0; m < Count; m++)
                    //    {
                    //        DateTime tempSentDate = Convert.ToDateTime(gvBroadcastMessage.Rows[m].Cells[2].Text);
                    //        string SentDate = tempSentDate.Day.ToString() + "/" + tempSentDate.Month.ToString() + "/" + tempSentDate.Year.ToString() + " " + String.Format("{0:T}", tempSentDate);
                    //        gvBroadcastMessage.Rows[m].Cells[2].Text = SentDate;

                    //        gvBroadcastMessage.Rows[m].Cells[0].Text = j.ToString() + ".";
                    //        j++;
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void gvMessages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("gvChildGrid");
                Int64 MessageID = Convert.ToInt64(e.Row.Cells[2].Text);

                gv.DataSource = reg.getReplyMessageByMessageID(MessageID);
                gv.DataBind();
            }
        }
        protected void gvMessages_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string From = ((Label)gvMessages.Rows[e.NewSelectedIndex].Cells[4].FindControl("lblFrom")).Text;
                string Sender = gvMessages.Rows[e.NewSelectedIndex].Cells[1].Text;

                Response.Redirect("../CandidateModule/frmReplyMessagesCandidateToAdmin.aspx?From=" + From + "&Sender=" + From);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}