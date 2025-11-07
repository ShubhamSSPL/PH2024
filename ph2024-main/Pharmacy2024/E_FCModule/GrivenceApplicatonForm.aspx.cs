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

namespace Pharmacy2024.E_FCModule
{
    public partial class GrivenceApplicatonForm : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["UserTypeID"] == null || Session["UserTypeID"].ToString() == "91")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (reg.CheckISEFC(Session["UserLoginId"].ToString()) == "N" && (Convert.ToInt16(Session["UserTypeID"]) == 23 || Convert.ToInt16(Session["UserTypeID"]) == 24))
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            gvReport.DataSource = reg.GetApplicationFormListForFCReVerificationofGrievance(Session["UserLoginId"].ToString(), Convert.ToInt16(Session["UserTypeID"].ToString()));
            gvReport.DataBind();
            for (Int32 i = 0; i < gvReport.Rows.Count; i++)
            {
                //gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                gvReport.Rows[i].Cells[3].Text = DataEncryption.DecryptDataByEncryptionKey(gvReport.Rows[i].Cells[3].Text);
            }
        }
        protected void gvReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
            try
            {
                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 PersonalId = Convert.ToInt64(((Label)gvReport.Rows[RowID].FindControl("lblPersonalID")).Text);
                Int64 Id = Convert.ToInt64(((Label)gvReport.Rows[RowID].FindControl("lblID")).Text);
                if (e.CommandName == "Verify")
                {
                    DataSet ds = reg.CheckFCForConfirmApplicationForm(Session["UserLoginId"].ToString(), PersonalId, Id, UserInfo.GetIPAddress());
                    if (ds.Tables[0].Rows[0][0].ToString().Length > 1)
                    {
                        shInfo.SetMessage("Candidate : " + Global.ApplicationFormPrefix + PersonalId.ToString() + " is being used by SC :" + ds.Tables[0].Rows[0][0].ToString() + " !!!", ShowMessageType.Information);
                    }
                    else
                    {
                        if (reg.UpdatePickedupStatus(PersonalId, Session["UserLoginId"].ToString(), Session["UserLoginId"].ToString(), UserInfo.GetIPAddress()))
                        {
                            Response.Redirect("../E_FCModule/FCApplicationFormVerificationDashboard?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString());
                        }
                        else
                        {
                            shInfo.SetMessage("Error on SC Pick Status Update", ShowMessageType.TechnicalError);
                        }
                    }
                }
                else
                {
                    shInfo.SetMessage("Please Enter Replied Message.", ShowMessageType.Information);
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