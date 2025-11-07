using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using EntityModel;
using System.Data;
using System.Configuration;
using Synthesys.Controls;

namespace Pharmacy2024.E_FCModule
{
    public partial class frmDiscrepancyMarkCandidateList : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    //Int32 InstituteID = 0;
                    //Int32 AFCID = 0;
                    //InstituteID = reg.getInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                    //AFCID = Convert.ToInt32(Session["UserID"].ToString());
                    //ddlDate.DataSource = reg.getDiscrepancyDateList(InstituteID, AFCID);
                    //ddlDate.DataTextField = "DiscrepancyDateTime";
                    //ddlDate.DataValueField = "DiscrepancyDateTime";

                    ddlDate.DataSource = reg.getConfirmationDateList();
                    ddlDate.DataTextField = "ConfirmedDateTime";
                    ddlDate.DataValueField = "ConfirmedDateTime";
                    ddlDate.DataBind();
                    ddlDate.Items.Insert(0, new ListItem("ALL", "ALL"));

                    Int16 RegionID = 0;
                    Int32 InstituteID = 0;
                    Int32 AFCID = 0;
                    string ConfirmationDate = ddlDate.SelectedValue;
                    if (Request.QueryString["AFCID"] != null)
                    {
                        RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                        InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                        AFCID = Convert.ToInt32(Request.QueryString["AFCID"].ToString());
                    }
                    else
                    {
                        if (Session["UserTypeID"].ToString() == "21")
                        {
                            RegionID = 99;
                            InstituteID = 99;
                            AFCID = 99;
                        }
                        else
                        {
                            RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                            InstituteID = reg.getInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                            AFCID = Convert.ToInt32(Session["UserID"].ToString());
                        }
                    }

                    gvCandidateList.DataSource = reg.GetDiscrepancyMarkedCandidateList(RegionID, InstituteID, AFCID, ConfirmationDate);
                    gvCandidateList.DataBind();

                    for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                    {
                        gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        DateTime dt = Convert.ToDateTime(gvCandidateList.Rows[i].Cells[6].Text);
                        gvCandidateList.Rows[i].Cells[6].Text = dt.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", dt);
                        gvCandidateList.Rows[i].Cells[5].Text = DataEncryption.DecryptDataByEncryptionKey(gvCandidateList.Rows[i].Cells[5].Text);
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
                

                Int16 RegionID = 0;
                Int32 InstituteID = 0;
                Int32 AFCID = 0;
                string filterdate;
                string ConfirmationDate = ddlDate.SelectedValue;
                if (ConfirmationDate != "ALL")
                {
                    DateTime selecteddate = Convert.ToDateTime(ConfirmationDate.Split("/".ToCharArray())[1] + "/" + ConfirmationDate.Split("/".ToCharArray())[0] + "/" + ConfirmationDate.Split("/".ToCharArray())[2]);
                    filterdate = selecteddate.ToString();
                }
                else
                    filterdate = ConfirmationDate;
                if (Request.QueryString["AFCID"] != null)
                {
                    RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                    InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                    AFCID = Convert.ToInt32(Request.QueryString["AFCID"].ToString());
                }
                else
                {
                    if (Session["UserTypeID"].ToString() == "21")
                    {
                        RegionID = 99;
                        InstituteID = 99;
                        AFCID = 99;
                    }
                    else
                    {
                        RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
                        InstituteID = reg.getInstituteID(Convert.ToInt32(Session["UserID"].ToString()));
                        AFCID = Convert.ToInt32(Session["UserID"].ToString());
                    }
                }

                gvCandidateList.DataSource = reg.GetDiscrepancyMarkedCandidateList(RegionID, InstituteID, AFCID, filterdate.ToString());
                gvCandidateList.DataBind();

                for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                {
                    gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    DateTime dt = Convert.ToDateTime(gvCandidateList.Rows[i].Cells[6].Text);
                    gvCandidateList.Rows[i].Cells[6].Text = dt.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", dt);
                    gvCandidateList.Rows[i].Cells[5].Text = DataEncryption.DecryptDataByEncryptionKey(gvCandidateList.Rows[i].Cells[5].Text);
                }

                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void gvCandidateList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("gvChildGrid");
                Label lblPersonalID = (Label)e.Row.FindControl("lblPersonalID");
                Int64 PersonalID = Convert.ToInt64(lblPersonalID.Text.ToString());

                gv.DataSource = reg.GetDiscrepancyDetails(PersonalID);
                gv.DataBind();
            }
        }
    }
}