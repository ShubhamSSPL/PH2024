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
    public partial class frmMessagesRepliedAdmin : System.Web.UI.Page
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
            shInfo.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    DataSet ds = reg.getAdminRepliedMessages("INSTITUTE");
                    gvMessages.DataSource = ds;
                    gvMessages.DataBind();
                    ViewState["ds"] = ds;

                    FormateGridValues();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void FormateGridValues()
        {
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
                    DateTime tempSentDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[5].Text);
                    string SentDate = tempSentDate.Day.ToString() + "/" + tempSentDate.Month.ToString() + "/" + tempSentDate.Year.ToString() + " " + String.Format("{0:T}", tempSentDate);
                    gvMessages.Rows[m].Cells[5].Text = SentDate;

                    DateTime tempReplyDate = Convert.ToDateTime(gvMessages.Rows[m].Cells[7].Text);
                    string ReplyDate = tempReplyDate.Day.ToString() + "/" + tempReplyDate.Month.ToString() + "/" + tempReplyDate.Year.ToString() + " " + String.Format("{0:T}", tempReplyDate);
                    gvMessages.Rows[m].Cells[7].Text = ReplyDate;

                    gvMessages.Rows[m].Cells[0].Text = j.ToString() + ".";
                    j++;
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet ds = (DataSet)ViewState["ds"];
                DataRow[] result = ds.Tables[0].Select("Sender LIKE '%" + txtSearch.Text + "%' or Message LIKE '%" + txtSearch.Text + "%' or RepliedMessage LIKE '%" + txtSearch.Text + "%'");
                DataTable dt = new DataTable();
                dt.Columns.Add("Sender");
                dt.Columns.Add("Subject");
                dt.Columns.Add("Message");
                dt.Columns.Add("SentDateTime");
                dt.Columns.Add("RepliedMessage");
                dt.Columns.Add("RepliedDateTime");
                dt.Columns.Add("RepliedBy");
                dt.Columns.Add("MessageID");
                dt.Columns.Add("ReplyCount");
                dt.Columns.Add("IsStarMarked", typeof(bool));

                foreach (DataRow row in result)
                {
                    DataRow dr = dt.NewRow();
                    dr["Sender"] = row["Sender"].ToString();
                    dr["Subject"] = row["Subject"].ToString();
                    dr["Message"] = row["Message"].ToString();
                    dr["SentDateTime"] = row["SentDateTime"].ToString();
                    dr["RepliedMessage"] = row["RepliedMessage"].ToString();
                    dr["RepliedDateTime"] = row["RepliedDateTime"].ToString();
                    dr["RepliedBy"] = row["RepliedBy"].ToString();
                    dr["MessageID"] = row["MessageID"].ToString();
                    dr["ReplyCount"] = row["ReplyCount"].ToString();
                    dr["IsStarMarked"] = row["IsStarMarked"];
                    dt.Rows.Add(dr);
                }

                gvMessages.DataSource = dt;
                gvMessages.DataBind();

                FormateGridValues();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet ds = reg.getAdminRepliedMessages("INSTITUTE");
                txtSearch.Text = "";
                gvMessages.DataSource = ds;
                gvMessages.DataBind();
                ViewState["ds"] = ds;

                FormateGridValues();
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
        protected void gvMessages_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowExapandEutton();", true);
        }

        protected void gvMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 MessageID = Convert.ToInt64(((Label)gvMessages.Rows[RowID].Cells[9].FindControl("lblMessageID")).Text);

                ImageButton btnStar = (ImageButton)gvMessages.Rows[RowID].Cells[1].FindControl("btnStar");
                HiddenField hdnIsStarMarked = (HiddenField)gvMessages.Rows[RowID].Cells[9].FindControl("hdnIsStarMarked");

                string lblIsStarMarked = ((Label)gvMessages.Rows[RowID].Cells[9].FindControl("lblIsStarMarked")).Text;
                if (e.CommandName == "Star")
                {
                    if (reg.updateStarMessageStatus(MessageID))
                    {
                        btnStar.ImageUrl = "~/Images/Star_Empty.png";
                    }
                    else
                    {
                        btnStar.ImageUrl = "~/Images/Star_fill.png";
                    }

                    DataSet ds = reg.getAdminRepliedMessages("INSTITUTE");
                    gvMessages.DataSource = ds;
                    gvMessages.DataBind();
                    ViewState["ds"] = ds;

                    FormateGridValues();
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