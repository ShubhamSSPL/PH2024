using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmFCSlotBookingStatusReport : System.Web.UI.Page
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
            trFclist.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                    ddlDate.DataSource = reg.GetSlotDates("1");
                    ddlDate.DataTextField = "SlotDate";
                    ddlDate.DataValueField = "SlotDate";
                    ddlDate.DataBind();
                    ddlDate.Items.Insert(0, new ListItem("ALL", "ALL"));
                    if (UserTypeID == 21)
                    {
                        trFclist.Visible = false;
                        ddlFCList.DataSource = reg.getAFCList(UserTypeID, Session["UserLoginID"].ToString());
                        ddlFCList.DataTextField = "AFCName";
                        ddlFCList.DataValueField = "LoginID";
                        ddlFCList.DataBind();
                        ddlFCList.Items.Insert(0, new ListItem("ALL", "ALL"));
                    }
                    //Int16 RegionID = 0;
                    //Int32 InstituteID = 0;
                    //Int32 AFCID = 0;
                    string ConfirmationDate = ddlDate.SelectedValue;
                    //if (Request.QueryString["AFCID"] != null)
                    //{
                    //    RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                    //    InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                    //    AFCID = Convert.ToInt32(Request.QueryString["AFCID"].ToString());
                    //}
                    //else
                    //{
                    //    RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                    //    InstituteID = reg.getInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                    //    AFCID = Convert.ToInt32(Session["UserID"].ToString());
                    //}


                    gvCandidateList.DataSource = reg.GetDateWiseFCSlotBookingReport(UserTypeID, Session["UserLoginID"].ToString(), ConfirmationDate);
                    gvCandidateList.DataBind();

                    for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                    {
                        gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        DateTime dt = Convert.ToDateTime(gvCandidateList.Rows[i].Cells[2].Text);
                        gvCandidateList.Rows[i].Cells[2].Text = dt.ToString("dd/MM/yyyy");
                    }

                    lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
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

                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                //Int16 RegionID = 0;
                //Int32 InstituteID = 0;
                //Int32 AFCID = 0;
                string ConfirmationDate = ddlDate.SelectedValue;
                //if (Request.QueryString["AFCID"] != null)
                //{
                //    RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                //    InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                //    AFCID = Convert.ToInt32(Request.QueryString["AFCID"].ToString());
                //}
                //else
                //{
                //    RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                //    InstituteID = reg.getInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                //    AFCID = Convert.ToInt32(Session["UserID"].ToString());
                //}
                string Username = Session["UserLoginID"].ToString();
                if (UserTypeID == 21)
                {
                    Username = ddlFCList.SelectedValue;
                }
                string filterdate;
                if (ConfirmationDate != "ALL")
                {
                    DateTime selecteddate = Convert.ToDateTime(ConfirmationDate.Split("/".ToCharArray())[1] + "/" + ConfirmationDate.Split("/".ToCharArray())[0] + "/" + ConfirmationDate.Split("/".ToCharArray())[2]);
                    filterdate = selecteddate.ToString();
                }
                else
                    filterdate = ConfirmationDate;

                gvCandidateList.DataSource = reg.GetDateWiseFCSlotBookingReport(UserTypeID, Username, filterdate.ToString());
                gvCandidateList.DataBind();

                for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                {
                    gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    DateTime dt = Convert.ToDateTime(gvCandidateList.Rows[i].Cells[2].Text);
                    gvCandidateList.Rows[i].Cells[2].Text = dt.ToString("dd/MM/yyyy");
                }

                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void ddlFC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                //Int16 RegionID = 0;
                //Int32 InstituteID = 0;
                //Int32 AFCID = 0;
                string ConfirmationDate = ddlDate.SelectedValue;
                //if (Request.QueryString["AFCID"] != null)
                //{
                //    RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                //    InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                //    AFCID = Convert.ToInt32(Request.QueryString["AFCID"].ToString());
                //}
                //else
                //{
                //    RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                //    InstituteID = reg.getInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                //    AFCID = Convert.ToInt32(Session["UserID"].ToString());
                //}
                string Username = Session["UserLoginID"].ToString();
                if (UserTypeID == 21)
                {
                    Username = ddlFCList.SelectedValue;
                }
                string filterdate;
                if (ConfirmationDate != "ALL")
                {
                    DateTime selecteddate = Convert.ToDateTime(ConfirmationDate.Split("/".ToCharArray())[1] + "/" + ConfirmationDate.Split("/".ToCharArray())[0] + "/" + ConfirmationDate.Split("/".ToCharArray())[2]);
                    filterdate = selecteddate.ToString();
                }
                else
                    filterdate = ConfirmationDate;

                gvCandidateList.DataSource = reg.GetDateWiseFCSlotBookingReport(UserTypeID, Username, filterdate.ToString());
                gvCandidateList.DataBind();

                for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                {
                    gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    DateTime dt = Convert.ToDateTime(gvCandidateList.Rows[i].Cells[2].Text);
                    gvCandidateList.Rows[i].Cells[2].Text = dt.ToString("dd/MM/yyyy");
                }

                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}