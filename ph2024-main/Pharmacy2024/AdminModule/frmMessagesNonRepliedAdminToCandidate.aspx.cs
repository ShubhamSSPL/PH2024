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

namespace Pharmacy2024.AdminModule
{
    public partial class frmMessagesNonRepliedAdminToCandidate : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            //if (Request.Cookies["Theme"] == null)
            //{
            //    Page.Theme = "default";
            //}
            //else
            //{
            //    Page.Theme = Request.Cookies["Theme"].Value;
            //}
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
                    DataSet ds = new DataSet();
                    ds = reg.getAdminNonRepliedMessages_Canidate(Global.ApplicationFormPrefix);
                    int i = 0;
                    foreach (DataRow x in ds.Tables[0].Rows)
                    {
                        string s = ds.Tables[0].Rows[i]["Sender"].ToString();
                        String[] spearator = { "(", ")" };
                        Int32 count = 2;

                        // using the method 
                        String[] strlist = s.Split(spearator, count,
                               StringSplitOptions.RemoveEmptyEntries);
                        string[] sx = strlist[1].Split(spearator[1].ToCharArray(), count,
                               StringSplitOptions.RemoveEmptyEntries);
                        ds.Tables[0].Rows[i]["Sender"] = strlist[0] + DataEncryption.DecryptDataByEncryptionKey(sx[0]) + sx[1];
                        i++;
                    }

                    gvMessages.DataSource = ds;
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
                            //DateTime tempSentDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[4].Text);
                            //string SentDate = tempSentDate.Day.ToString() + "/" + tempSentDate.Month.ToString() + "/" + tempSentDate.Year.ToString() + " " + String.Format("{0:T}", tempSentDate);
                            //gvMessages.Rows[m].Cells[4].Text = SentDate;

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
                string From = ((Label)gvMessages.Rows[e.NewSelectedIndex].Cells[6].FindControl("lblFrom")).Text;
                string Sender = gvMessages.Rows[e.NewSelectedIndex].Cells[1].Text;

                Response.Redirect("../AdminModule/frmReplyMessagesAdminToCandidate.aspx?From=" + From + "&Sender=" + From);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}