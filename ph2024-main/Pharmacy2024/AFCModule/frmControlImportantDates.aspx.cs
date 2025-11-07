using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmControlImportantDates : System.Web.UI.Page
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
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;

                    gvImportantDatesList.DataSource = reg.getAllImportantDates();
                    gvImportantDatesList.DataBind();

                    for (Int32 i = 0; i < gvImportantDatesList.Rows.Count; i++)
                    {
                        gvImportantDatesList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";

                        if (gvImportantDatesList.Rows[i].Cells[3].Text == gvImportantDatesList.Rows[i].Cells[4].Text)
                        {
                            gvImportantDatesList.Rows[i].Cells[3].ColumnSpan = 2;
                            gvImportantDatesList.Rows[i].Cells.RemoveAt(4);
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                IFormatProvider culture = new CultureInfo("en-US", true);
                string ActivityDetails = txtActivity.Text;
                DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.Split("/".ToCharArray())[1] + "/" + txtStartDate.Text.Split("/".ToCharArray())[0] + "/" + txtStartDate.Text.Split("/".ToCharArray())[2]);
                string StartTime = txtStartTime.Text;
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.Split("/".ToCharArray())[1] + "/" + txtEndDate.Text.Split("/".ToCharArray())[0] + "/" + txtEndDate.Text.Split("/".ToCharArray())[2]);
                string EndTime = txtEndTime.Text;
                DateTime DisplayStartDateTime = Convert.ToDateTime(txtDisplayStartDateTime.Text.Split("/".ToCharArray())[1] + "/" + txtDisplayStartDateTime.Text.Split("/".ToCharArray())[0] + "/" + txtDisplayStartDateTime.Text.Split("/".ToCharArray())[2]);
                //DateTime.ParseExact(txtDisplayStartDateTime.Text, "dd/MM/yyyy HH:mm", culture);
                DateTime DisplayEndDateTime = Convert.ToDateTime(txtDisplayEndDateTime.Text.Split("/".ToCharArray())[1] + "/" + txtDisplayEndDateTime.Text.Split("/".ToCharArray())[0] + "/" + txtDisplayEndDateTime.Text.Split("/".ToCharArray())[2]);
                //DateTime.ParseExact(txtDisplayEndDateTime.Text, "dd/MM/yyyy HH:mm", culture);
                string ActivityType = ddlActivityType.SelectedValue;

                if (reg.saveImportantDates(ActivityDetails, StartDate, StartTime, EndDate, EndTime, DisplayStartDateTime, DisplayEndDateTime, ActivityType, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    Global.ImportantDates = reg.getImportantDates();
                    Global.TopImportantDates = reg.getTopActiveImportantDates();

                    gvImportantDatesList.DataSource = reg.getAllImportantDates();
                    gvImportantDatesList.DataBind();

                    for (Int32 i = 0; i < gvImportantDatesList.Rows.Count; i++)
                    {
                        gvImportantDatesList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";

                        if (gvImportantDatesList.Rows[i].Cells[3].Text == gvImportantDatesList.Rows[i].Cells[4].Text)
                        {
                            gvImportantDatesList.Rows[i].Cells[3].ColumnSpan = 2;
                            gvImportantDatesList.Rows[i].Cells.RemoveAt(4);
                        }
                    }

                    txtActivity.Text = "";
                    txtStartDate.Text = "";
                    txtStartTime.Text = "";
                    txtEndDate.Text = "";
                    txtEndTime.Text = "";
                    txtDisplayStartDateTime.Text = "";
                    txtDisplayEndDateTime.Text = "";
                    ddlActivityType.SelectedValue = "0";
                    shInfo.SetMessage("Record added successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                IFormatProvider culture = new CultureInfo("en-US", true);
                Int64 ActivityID = Convert.ToInt64(hdnActivityID.Value);
                string ActivityDetails = txtActivity.Text;
                DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.Split("/".ToCharArray())[1] + "/" + txtStartDate.Text.Split("/".ToCharArray())[0] + "/" + txtStartDate.Text.Split("/".ToCharArray())[2]);
                string StartTime = txtStartTime.Text;
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.Split("/".ToCharArray())[1] + "/" + txtEndDate.Text.Split("/".ToCharArray())[0] + "/" + txtEndDate.Text.Split("/".ToCharArray())[2]);
                string EndTime = txtEndTime.Text;
                DateTime DisplayStartDateTime = Convert.ToDateTime(txtDisplayStartDateTime.Text.Split("/".ToCharArray())[1] + "/" + txtDisplayStartDateTime.Text.Split("/".ToCharArray())[0] + "/" + txtDisplayStartDateTime.Text.Split("/".ToCharArray())[2]);
                //DateTime.ParseExact(txtDisplayStartDateTime.Text, "dd/MM/yyyy HH:mm", culture);
                DateTime DisplayEndDateTime = Convert.ToDateTime(txtDisplayEndDateTime.Text.Split("/".ToCharArray())[1] + "/" + txtDisplayEndDateTime.Text.Split("/".ToCharArray())[0] + "/" + txtDisplayEndDateTime.Text.Split("/".ToCharArray())[2]);
                //DateTime.ParseExact(txtDisplayEndDateTime.Text, "dd/MM/yyyy HH:mm", culture);
                string ActivityType = ddlActivityType.SelectedValue;

                if (reg.editImportantDates(ActivityID, ActivityDetails, StartDate, StartTime, EndDate, EndTime, DisplayStartDateTime, DisplayEndDateTime, ActivityType, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    Global.ImportantDates = reg.getImportantDates();
                    Global.TopImportantDates = reg.getTopActiveImportantDates();

                    gvImportantDatesList.DataSource = reg.getAllImportantDates();
                    gvImportantDatesList.DataBind();

                    for (Int32 i = 0; i < gvImportantDatesList.Rows.Count; i++)
                    {
                        gvImportantDatesList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";

                        if (gvImportantDatesList.Rows[i].Cells[3].Text == gvImportantDatesList.Rows[i].Cells[4].Text)
                        {
                            gvImportantDatesList.Rows[i].Cells[3].ColumnSpan = 2;
                            gvImportantDatesList.Rows[i].Cells.RemoveAt(4);
                        }
                    }

                    txtActivity.Text = "";
                    txtStartDate.Text = "";
                    txtStartTime.Text = "";
                    txtEndDate.Text = "";
                    txtEndTime.Text = "";
                    txtDisplayStartDateTime.Text = "";
                    txtDisplayEndDateTime.Text = "";
                    ddlActivityType.SelectedValue = "0";

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    shInfo.SetMessage("Update added successfully.", ShowMessageType.Information);

                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                gvImportantDatesList.DataSource = reg.getAllImportantDates();
                gvImportantDatesList.DataBind();

                for (Int32 i = 0; i < gvImportantDatesList.Rows.Count; i++)
                {
                    gvImportantDatesList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";

                    if (gvImportantDatesList.Rows[i].Cells[3].Text == gvImportantDatesList.Rows[i].Cells[4].Text)
                    {
                        gvImportantDatesList.Rows[i].Cells[3].ColumnSpan = 2;
                        gvImportantDatesList.Rows[i].Cells.RemoveAt(4);
                    }
                }

                txtActivity.Text = "";
                txtStartDate.Text = "";
                txtStartTime.Text = "";
                txtEndDate.Text = "";
                txtEndTime.Text = "";
                txtDisplayStartDateTime.Text = "";
                txtDisplayEndDateTime.Text = "";
                ddlActivityType.SelectedValue = "0";

                btnAdd.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvImportantDatesList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 ActivityID = Convert.ToInt64(((Label)gvImportantDatesList.Rows[e.RowIndex].Cells[0].FindControl("lblActivityID")).Text);

                if (reg.deleteImportantDates(ActivityID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    Global.ImportantDates = reg.getImportantDates();
                    Global.TopImportantDates = reg.getTopActiveImportantDates();

                    gvImportantDatesList.DataSource = reg.getAllImportantDates();
                    gvImportantDatesList.DataBind();

                    for (Int32 i = 0; i < gvImportantDatesList.Rows.Count; i++)
                    {
                        gvImportantDatesList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";

                        if (gvImportantDatesList.Rows[i].Cells[3].Text == gvImportantDatesList.Rows[i].Cells[4].Text)
                        {
                            gvImportantDatesList.Rows[i].Cells[3].ColumnSpan = 2;
                            gvImportantDatesList.Rows[i].Cells.RemoveAt(4);
                        }
                    }

                    txtActivity.Text = "";
                    txtStartDate.Text = "";
                    txtStartTime.Text = "";
                    txtEndDate.Text = "";
                    txtEndTime.Text = "";
                    txtDisplayStartDateTime.Text = "";
                    txtDisplayEndDateTime.Text = "";
                    ddlActivityType.SelectedValue = "0";

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    shInfo.SetMessage("Delete added successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvImportantDatesList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 ActivityID = Convert.ToInt64(((Label)gvImportantDatesList.Rows[e.NewSelectedIndex].Cells[0].FindControl("lblActivityID")).Text);
                DataSet ds = reg.getImportantDates(ActivityID);

                hdnActivityID.Value = ActivityID.ToString();
                txtActivity.Text = ds.Tables[0].Rows[0]["ActivityDetails"].ToString();
                txtStartDate.Text = ds.Tables[0].Rows[0]["ActivityStartDate"].ToString();
                txtStartTime.Text = ds.Tables[0].Rows[0]["ActivityStartTime"].ToString();
                txtEndDate.Text = ds.Tables[0].Rows[0]["ActivityEndDate"].ToString();
                txtEndTime.Text = ds.Tables[0].Rows[0]["ActivityEndTime"].ToString();

                string ActivityDisplayStartDateTime = ds.Tables[0].Rows[0]["ActivityDisplayStartDateTime"].ToString();
                string ActivityDisplayEndDateTime = ds.Tables[0].Rows[0]["ActivityDisplayEndDateTime"].ToString();
                ddlActivityType.SelectedValue = ds.Tables[0].Rows[0]["ActivityType"].ToString();

                ClientScript.RegisterStartupScript(this.GetType(), "ActivityDisplayStartDateTime", "activityDisplayStartDateTime('" + ActivityDisplayStartDateTime + "');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "ActivityDisplayEndDateTime", "activityDisplayEndDateTime('" + ActivityDisplayEndDateTime + "');", true);

                gvImportantDatesList.DataSource = reg.getAllImportantDates();
                gvImportantDatesList.DataBind();

                for (Int32 i = 0; i < gvImportantDatesList.Rows.Count; i++)
                {
                    gvImportantDatesList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";

                    if (gvImportantDatesList.Rows[i].Cells[3].Text == gvImportantDatesList.Rows[i].Cells[4].Text)
                    {
                        gvImportantDatesList.Rows[i].Cells[3].ColumnSpan = 2;
                        gvImportantDatesList.Rows[i].Cells.RemoveAt(4);
                    }
                }

                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}