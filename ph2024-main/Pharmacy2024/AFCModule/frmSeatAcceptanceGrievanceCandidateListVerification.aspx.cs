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

namespace Pharmacy2024.AFCModule
{
    public partial class frmSeatAcceptanceGrievanceCandidateListVerification : System.Web.UI.Page
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
            //Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);

            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    Int16 RegionID = 0;
                    Int32 InstituteID = 0;
                    Int32 AFCID = 0;
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

                    gvCandidateList.DataSource = reg.GetSeatAcceptanceGrievanceListForVerification(RegionID, InstituteID, AFCID, Global.CAPRound);
                    gvCandidateList.DataBind();

                    for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                    {
                        gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        DateTime dt = Convert.ToDateTime(gvCandidateList.Rows[i].Cells[4].Text);
                        gvCandidateList.Rows[i].Cells[4].Text = dt.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", dt);
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
            shInfo.Visible = false;
            try
            {
                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 PID = Convert.ToInt64(((Label)gvCandidateList.Rows[RowID].FindControl("lblPersonalID")).Text);
                char VerificationMode = Convert.ToChar(((Label)gvCandidateList.Rows[RowID].FindControl("lblVerificationMode")).Text);
                Int64 ID = Convert.ToInt64(((Label)gvCandidateList.Rows[RowID].FindControl("lblID")).Text);

                if (e.CommandName == "Verify")
                {

                    //if (VerificationMode == 'E')
                    //{
                    //    Response.Redirect("../E_FCModule/EVerificationHomeDistrictAndCategoryDetails?PID=" + PID + "&Code=" + PID.ToString().GetHashCode().ToString() + "&ApplicationFormStepID=4&ForSEBC=Y");
                    //}
                    //else
                    //    Response.Redirect("../AFCModule/frmEditRequiredDocuments.aspx?PID=" + PID + "&Code=" + PID.ToString().GetHashCode(), true);

                    DataSet ds = reg.CheckFCForSeatAcceptanceGrievance(Session["UserLoginID"].ToString(), PID, ID, UserInfo.GetIPAddress());
                    if (ds.Tables[0].Rows[0][0].ToString().Length > 1)
                    {
                        shInfo.Visible = true;
                        shInfo.SetMessage("Candidate : " + Global.ApplicationFormPrefix + PID.ToString() + " is being used by SC :" + ds.Tables[0].Rows[0][0].ToString() + " !!!", ShowMessageType.Information);
                    }
                    else
                    {
                        if (reg.UpdateSeatAcceptanceGrievancePickedupStatus(PID, Session["UserLoginID"].ToString(), Global.CAPRound, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            Response.Redirect("../AFCModule/frmSeatAcceptanceGrievanceVerification?PID=" + PID + "&Code=" + PID.ToString().GetHashCode().ToString());
                        }
                        else
                        {
                            shInfo.Visible = true;
                            shInfo.SetMessage("Error on SC Pick Status Update", ShowMessageType.TechnicalError);
                        }
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