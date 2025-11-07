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
    public partial class frmGrievancesApprovedAFC : System.Web.UI.Page
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
            if (reg.CheckISEFC(Session["UserLoginId"].ToString()) == "N" && (Convert.ToInt16(Session["UserTypeID"]) == 23 || Convert.ToInt16(Session["UserTypeID"]) == 24))
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMessageBoxDocument));
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    string AFCCode = Session["UserLoginID"].ToString().Substring(0, 6);
                    DBUtility regDB = new DBUtility();
                    //gvMessages.Attributes.Add("style", "word-break:break-all; word-wrap:break-word");
                    gvMessages.DataSource = regDB.GetAFCApprovedGrievances("AFC", AFCCode);
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
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
    }
}