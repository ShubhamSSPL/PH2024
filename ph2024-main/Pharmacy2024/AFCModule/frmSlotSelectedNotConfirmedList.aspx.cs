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
    public partial class frmSlotSelectedNotConfirmedList : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    ddlDate.DataSource = reg.GetSlotDates("1");
                    ddlDate.DataTextField = "SlotDate";
                    ddlDate.DataValueField = "SlotDate";
                    ddlDate.DataBind();
                    ddlDate.Items.Insert(0, new ListItem("ALL", "ALL"));

                    Int16 RegionID = 0;
                    Int32 InstituteID = 0;
                    Int32 AFCID = 0;
                    string ConfirmationDate = ddlDate.SelectedValue;

                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);

                    if (Request.QueryString["AFCID"] != null)
                    {
                        RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                        InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                        AFCID = Convert.ToInt32(Request.QueryString["AFCID"].ToString());
                    }
                    else
                    {
                        if (UserTypeID == 21)
                        {
                            RegionID = 99;
                            InstituteID = 99;
                            AFCID = 99;
                        }

                        else if (UserTypeID == 22)
                        {
                            RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
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
                    gvCandidateList.DataSource = reg.GetSlotSelectedNotConfirmedList(RegionID, InstituteID, AFCID, ConfirmationDate);
                    gvCandidateList.DataBind();

                    for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                    {
                        gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        gvCandidateList.Rows[i].Cells[3].Text = DataEncryption.DecryptDataByEncryptionKey(gvCandidateList.Rows[i].Cells[3].Text);

                        DateTime dt = Convert.ToDateTime(gvCandidateList.Rows[i].Cells[5].Text);
                        gvCandidateList.Rows[i].Cells[5].Text = dt.ToString("dd/MM/yyyy");
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
                string ConfirmationDate = ddlDate.SelectedValue;
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                if (Request.QueryString["AFCID"] != null)
                {
                    RegionID = Convert.ToInt16(Request.QueryString["RegionID"].ToString());
                    InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString());
                    AFCID = Convert.ToInt32(Request.QueryString["AFCID"].ToString());
                }
                else
                {
                    if (UserTypeID == 21)
                    {
                        RegionID = 99;
                        InstituteID = 99;
                        AFCID = 99;
                    }

                    else if (UserTypeID == 22)
                    {
                        RegionID = reg.getRegionID(Convert.ToInt32(Session["UserID"].ToString()));
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

                gvCandidateList.DataSource = reg.GetSlotSelectedNotConfirmedList(RegionID, InstituteID, AFCID, ConfirmationDate);
                gvCandidateList.DataBind();

                for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                {
                    gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                    DateTime dt = Convert.ToDateTime(gvCandidateList.Rows[i].Cells[5].Text);
                    gvCandidateList.Rows[i].Cells[5].Text = dt.ToString("dd/MM/yyyy");
                    gvCandidateList.Rows[i].Cells[3].Text = DataEncryption.DecryptDataByEncryptionKey(gvCandidateList.Rows[i].Cells[3].Text);
                }

                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void gvCandidateList_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void gvCandidateList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 PersonalID = Convert.ToInt64(((Label)gvCandidateList.Rows[RowID].Cells[11].FindControl("lblPersonalID")).Text);
                string RepliedMessage = ((TextBox)gvCandidateList.Rows[RowID].Cells[8].FindControl("txtRepliedMessage")).Text;

                if (e.CommandName == "Reply")
                {
                    if (RepliedMessage.Length > 0)
                    {
                        if (reg.UpdateContactedDetailsFromFC(PersonalID, RepliedMessage, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            Response.Redirect("../AFCModule/frmSlotSelectedNotConfirmedList");
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