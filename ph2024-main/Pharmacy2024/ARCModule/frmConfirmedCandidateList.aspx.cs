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

namespace Pharmacy2024.ARCModule
{
    public partial class frmConfirmedCandidateList : System.Web.UI.Page
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
                    ddlDate.DataSource = reg.getARCConfirmationDateList();
                    ddlDate.DataTextField = "ReportedDateTime";
                    ddlDate.DataValueField = "ReportedDateTime";
                    ddlDate.DataBind();
                    ddlDate.Items.Insert(0, new ListItem("ALL", "ALL"));

                    Int16 RegionID = 0;
                    Int32 InstituteID = 0;
                    Int32 ARCID = 0;
                    string ConfirmationDate = ddlDate.SelectedValue;

                    if (Request.QueryString["ARCID"] != null)
                    {
                        RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                        InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                        ARCID = Convert.ToInt32(Request.QueryString["ARCID"].ToString());
                    }
                    else
                    {
                        RegionID = reg.getARCRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                        InstituteID = reg.getARCInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                        ARCID = Convert.ToInt32(Session["UserID"].ToString());
                    }

                    DataSet ds = reg.getARCConfirmedCandidateList(RegionID, InstituteID, ARCID, ConfirmationDate);

                    gvConfirmedCandidateList.DataSource = ds.Tables[0];
                    gvConfirmedCandidateList.DataBind();

                    for (Int32 i = 0; i < gvConfirmedCandidateList.Rows.Count; i++)
                    {
                        gvConfirmedCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        DateTime dt = Convert.ToDateTime(gvConfirmedCandidateList.Rows[i].Cells[3].Text);
                        gvConfirmedCandidateList.Rows[i].Cells[3].Text = dt.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", dt);
                    }

                    gvCancelledCandidateList.DataSource = ds.Tables[1];
                    gvCancelledCandidateList.DataBind();

                    for (Int32 i = 0; i < gvCancelledCandidateList.Rows.Count; i++)
                    {
                        gvCancelledCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        DateTime dt = Convert.ToDateTime(gvCancelledCandidateList.Rows[i].Cells[3].Text);
                        gvCancelledCandidateList.Rows[i].Cells[3].Text = dt.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", dt);
                    }

                    lblPrintedOn1.Text = lblPrintedOn2.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int16 RegionID = 0;
                Int32 InstituteID = 0;
                Int32 ARCID = 0;
                string ConfirmationDate = ddlDate.SelectedValue;

                if (Request.QueryString["ARCID"] != null)
                {
                    RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                    InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                    ARCID = Convert.ToInt32(Request.QueryString["ARCID"].ToString());
                }
                else
                {
                    RegionID = reg.getARCRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                    InstituteID = reg.getARCInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                    ARCID = Convert.ToInt32(Session["UserID"].ToString());
                }

                DataSet ds = reg.getARCConfirmedCandidateList(RegionID, InstituteID, ARCID, ConfirmationDate);

                gvConfirmedCandidateList.DataSource = ds.Tables[0];
                gvConfirmedCandidateList.DataBind();

                for (Int32 i = 0; i < gvConfirmedCandidateList.Rows.Count; i++)
                {
                    gvConfirmedCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    DateTime dt = Convert.ToDateTime(gvConfirmedCandidateList.Rows[i].Cells[3].Text);
                    gvConfirmedCandidateList.Rows[i].Cells[3].Text = dt.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", dt);
                }

                gvCancelledCandidateList.DataSource = ds.Tables[1];
                gvCancelledCandidateList.DataBind();

                for (Int32 i = 0; i < gvCancelledCandidateList.Rows.Count; i++)
                {
                    gvCancelledCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    DateTime dt = Convert.ToDateTime(gvCancelledCandidateList.Rows[i].Cells[3].Text);
                    gvCancelledCandidateList.Rows[i].Cells[3].Text = dt.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", dt);
                }

                lblPrintedOn1.Text = lblPrintedOn2.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}