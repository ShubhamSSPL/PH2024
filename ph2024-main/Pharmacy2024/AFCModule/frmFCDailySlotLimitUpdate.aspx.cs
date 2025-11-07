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
    public partial class frmFCDailySlotLimitUpdate : System.Web.UI.Page
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
            if (Session["UserTypeID"].ToString() != "23")
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                gvList.DataSource = reg.GetDatewiseSlotsForFC(Session["UserLoginID"].ToString());
                gvList.DataBind();
            }
        }
        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Convert.ToDateTime(e.Row.Cells[1].Text) <= DateTime.Now)
                    {
                        CheckBox chkSelect = ((CheckBox)e.Row.FindControl("chkSelect"));
                        chkSelect.Enabled = false;
                    }
                    e.Row.Cells[1].Text = Convert.ToDateTime(e.Row.Cells[1].Text).ToString("dd/MM/yyyy");

                    //Label lblFCDateID = (Label)e.Row.FindControl("lblFCDateID");
                    string chkClientId = e.Row.FindControl("chkSelect").ClientID;
                    string txt2ClientId = e.Row.FindControl("txtAvilableSlots").ClientID;
                    string rfvAvilableSlot = e.Row.FindControl("rfvtxtAvilableSlots").ClientID;
                    string cvAvilableSlot = e.Row.FindControl("cvtxtAvilableSlot").ClientID;
                    ((RequiredFieldValidator)e.Row.FindControl("rfvtxtAvilableSlots")).ControlToValidate = ((TextBox)e.Row.FindControl("txtAvilableSlots")).ID;
                    ((CompareValidator)e.Row.FindControl("cvtxtAvilableSlot")).ControlToValidate = ((TextBox)e.Row.FindControl("txtAvilableSlots")).ID;
                    ((CompareValidator)e.Row.FindControl("cvAvilablegrater")).ControlToValidate = ((TextBox)e.Row.FindControl("txtAvilableSlots")).ID;
                    ((CheckBox)e.Row.FindControl("chkSelect")).Attributes.Add("onclick", "javascript:checkitem(" + chkClientId + "," + txt2ClientId + "," + rfvAvilableSlot + "," + cvAvilableSlot + ");");
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnUpdaeSlot_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 Count = gvList.Rows.Count;
                string faillDate = "";
                for (int m = 0; m < Count; m++)
                {
                    if (((CheckBox)gvList.Rows[m].Cells[0].FindControl("chkSelect")).Checked == true)
                    {
                        Label lblFCDateID = (Label)gvList.Rows[m].FindControl("lblFCDateID");
                        TextBox txtAvilableSlot = (TextBox)gvList.Rows[m].FindControl("txtAvilableSlots");
                        if (reg.UpdateDatewiseCapacityForFC(Convert.ToInt64(lblFCDateID.Text), Convert.ToInt32(txtAvilableSlot.Text), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            ((CheckBox)gvList.Rows[m].Cells[0].FindControl("chkSelect")).Checked = false;
                        }
                        else
                        {
                            faillDate += ", " + gvList.Rows[m].Cells[1].Text;
                        }
                    }

                }
                if (faillDate.Length > 0)
                {
                    shInfo.SetMessage("Available Slots Updation failed for " + faillDate + " Dates.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Available Slots Updated Successfully.", ShowMessageType.Information);

                }


                //((CheckBox)gvList.HeaderRow.Cells[0].FindControl("chkAll")).Checked = false;

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}