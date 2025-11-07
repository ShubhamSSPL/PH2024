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
    public partial class frmCandidateListRequestedForAdmissionCancellation : System.Web.UI.Page
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
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();

                    gvReport.DataSource = reg.getCandidateListRequestedForAdmissionCancellation(UserTypeID, UserLoginID);
                    gvReport.DataBind();

                    for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                    {
                        //gvReport.Rows[i].Cells[3].Text = DataEncryption.DecryptDataByEncryptionKey(gvReport.Rows[i].Cells[3].Text);
                        DateTime RequestedDateTime = Convert.ToDateTime(gvReport.Rows[i].Cells[7].Text);
                        gvReport.Rows[i].Cells[7].Text = RequestedDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", RequestedDateTime);
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
        protected void gvReport_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                string UserLoginID = Session["UserLoginID"].ToString();
                Int64 PID = Convert.ToInt64(((Label)gvReport.Rows[e.NewSelectedIndex].FindControl("lblPersonalID")).Text);
                Int64 ChoiceCode = Convert.ToInt64(((Label)gvReport.Rows[e.NewSelectedIndex].FindControl("lblChoiceCode")).Text);
                Int32 CAPRound = Convert.ToInt32(((Label)gvReport.Rows[e.NewSelectedIndex].FindControl("lblCAPRound")).Text);
                string InstituteCode = ((Label)gvReport.Rows[e.NewSelectedIndex].FindControl("lblInstituteCode")).Text;
                DataSet ds = reg.getAdmittedChoiceCodeDetailsForCancellation(PID, ChoiceCode, CAPRound);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    shInfo.SetMessage("Admission of this Candidate in this Course in Already Cancelled.", ShowMessageType.Information);
                }
                else
                {
                    if (ds.Tables[0].Rows[0]["IsCandidateInterestedInAdmissionCancellation"].ToString() == "Y")
                    {
                        if (reg.isCandidateAdmittedInThisInstitute(PID, ChoiceCode, CAPRound, UserTypeID, UserLoginID))
                        {
                            if (ds.Tables[0].Rows[0]["AdmittedThrough"].ToString() == "IL Level")
                            {
                                Response.Redirect("../InstituteModule/frmCancelAdmissionAtIL.aspx?PID=" + PID.ToString() + "&ChoiceCode=" + ChoiceCode.ToString() + "&CAPRound=" + CAPRound.ToString() + "&InstituteCode=" + InstituteCode.ToString() + "&Code=" + PID.ToString().GetHashCode().ToString());
                            }
                            else
                            {
                                Response.Redirect("../InstituteModule/frmCancelAdmission.aspx?PID=" + PID.ToString() + "&ChoiceCode=" + ChoiceCode.ToString() + "&CAPRound=" + CAPRound.ToString() + "&InstituteCode=" + InstituteCode.ToString() + "&Code=" + PID.ToString().GetHashCode().ToString());
                            }
                        }
                        else
                        {
                            if (UserTypeID == 21)
                            {
                                shInfo.SetMessage("This candidate is not admitted in any institute. So you can not cancel it.", ShowMessageType.Information);
                            }
                            else if (UserTypeID == 22)
                            {
                                shInfo.SetMessage("This candidate is not admitted in any institute in your region. So you can not cancel it.", ShowMessageType.Information);
                            }
                            else
                            {
                                shInfo.SetMessage("This candidate is not admitted in your institute. So you can not cancel it.", ShowMessageType.Information);
                            }
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("This candidate has not given willingness through Online System for admission cancellation through his/her login. So you can not cancel his/her admission.", ShowMessageType.Information);
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