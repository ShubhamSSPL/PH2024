using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class FCSlotBooking : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string strVerificationMode = "";
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
            if (Convert.ToInt16(Session["UserTypeID"]) != 91)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");


            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["From"] != null)
                    {
                        if (Request.QueryString["From"].ToString() == "ModeChange")
                            shInfo.SetMessage("Your SC Verification Mode Changed to Physical Verification Mode. Please Book a Slot for Visit to Scrutiny Center(SC) for Confirmation of Application Form.", ShowMessageType.Information);
                        if (Request.QueryString["From"].ToString() == "ApplicationForm")
                            shInfo.SetMessage("Please Book a Slot for Visit to Scrutiny Center(SC) for Confirmation of Application Form.", ShowMessageType.Information);
                    }

                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    strVerificationMode = reg.CheckCandidateFCVerificationFor(objSessionData.PID);
                    //btnUpdateSlot.Visible = false;
                    ddlCDistrict.DataSource = reg.GetMasterMHDistrictForFCVerification();
                    ddlCDistrict.DataTextField = "DistrictName";
                    ddlCDistrict.DataValueField = "DTEDistrictID";
                    ddlCDistrict.DataBind();
                    ddlCDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
                    ddlCDistrict.Items.Insert(1, new ListItem("All", "200"));
                    ddlFC.Items.Insert(0, new ListItem("-- Select Scrutiny Centers --", "0"));
                    ddlDate.Items.Insert(0, new ListItem("-- Select Date --", "0"));

                    //if (Request.QueryString["FromStep"] != null)
                    //{
                    // Check PScrutiny and EScrutiny Mode.
                    if (Global.CurrentScrutinyMode == "E")
                    {
                        tblPScrutiny.Visible = false;
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowFCVerificationPopUp();", true);
                    }
                    else if (Global.CurrentScrutinyMode == "P")
                    {
                        tblEScrutiny.Visible = false;
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowFCVerificationPopUp();", true);
                    }
                    else if (Global.CurrentScrutinyMode == "Both")
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowFCVerificationPopUp();", true);
                        tblPScrutiny.Visible = true;
                        tblEScrutiny.Visible = true;

                    }
                    if (strVerificationMode == "E")
                    {
                        ContentBox1.Visible = false;
                        btnUpdateSlot.Visible = false;
                        shInfo.SetMessage("You have chosen E-Verification so You don't have access for SC Appointment.", ShowMessageType.Information);
                    }
                    else if (strVerificationMode == " " || strVerificationMode == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowFCVerificationPopUp();", true);
                    }
                    else if (strVerificationMode == "P")
                    {
                        ViewBookSlotDetails(objSessionData.PID);

                    }
                    else
                    {
                        ContentBox1.Visible = false;
                    }
                    //ViewState["RedirecttoForm"] = "Y";
                    //}
                    //else
                    //{
                    //    ViewState["RedirecttoForm"] = "N";

                    //    if (objSessionData.StepID < 9)
                    //    {
                    //        shInfo.SetMessage("Complate Your Application form for SC Appointment.", ShowMessageType.Information);
                    //        ContentBox1.Visible = false;
                    //        btnUpdateSlot.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        if (strVerificationMode == "E")
                    //        {
                    //            ContentBox1.Visible = false;
                    //            btnUpdateSlot.Visible = false;
                    //            shInfo.SetMessage("You have chose E-Verification so You don't have access for SC Appointment.", ShowMessageType.Information);
                    //        }
                    //        else
                    //        {
                    //            ViewBookSlotDetails(objSessionData.PID);
                    //        }
                    //    }
                    //}
                    // reg.GetSlotForFC(FCID);
                    //Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        private void ViewBookSlotDetails(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet ds = reg.GetCandidateBookingSlotDetails(PID);
                if (ds.Tables[0].Rows.Count > 0 && strVerificationMode != "E")
                {
                    ContentBox2.Visible = true;
                    lblApplicationID.Text = ds.Tables[0].Rows[0]["ApplicationID"].ToString();
                    lblCandidateName.Text = ds.Tables[0].Rows[0]["CandidateName"].ToString();
                    lblSlotDateTime.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["SlotDate"]).ToString("dd/MM/yyyy") + "  " + ds.Tables[0].Rows[0]["SlotTime"].ToString();
                    lblFCDetails.Text = ds.Tables[0].Rows[0]["FCDetails"].ToString();
                    if (ds.Tables[0].Rows[0]["TimeLaps"].ToString() == "Y")
                    {
                        btnUpdateSlot.Visible = false;
                    }
                    else
                        btnUpdateSlot.Visible = true;

                    ContentBox1.Visible = false;
                    ContentTable1.Visible = false;
                }
                else
                {
                    ContentBox1.Visible = true;
                }
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
                if (ddlFC.SelectedValue != "0")
                {
                    ddlDate.DataSource = reg.GetSlotDates(ddlFC.SelectedValue.ToString());
                    ddlDate.DataTextField = "SlotDate";
                    ddlDate.DataValueField = "SlotDate";
                    ddlDate.DataBind();
                    ddlDate.Items.Insert(0, new ListItem("-- Select Date --", "0"));
                }
                else
                {
                    shInfo.SetMessage("Please Select District", ShowMessageType.Information);
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }


        }

        protected void ddlCDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                ddlFC.DataSource = reg.GetFCDetailsForSlotBooking(Convert.ToInt16(ddlCDistrict.SelectedValue));
                ddlFC.DataTextField = "FCName";
                ddlFC.DataValueField = "AFCCode";
                ddlFC.DataBind();
                ddlFC.Items.Insert(0, new ListItem("-- Select Scrutiny Centers --", "0"));
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContentTable1.Visible = false;
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DateTime selectedDate = Convert.ToDateTime(ddlDate.SelectedValue.Split("/".ToCharArray())[1] + "/" + ddlDate.SelectedValue.Split("/".ToCharArray())[0] + "/" + ddlDate.SelectedValue.Split("/".ToCharArray())[2]);
                DataSet ds = reg.GetSlotForFC(ddlFC.SelectedValue, selectedDate.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ContentTable1.HeaderText = ddlFC.SelectedItem.Text + ", Slot Status For Date : " + ddlDate.SelectedValue;
                    ContentTable1.Visible = true;
                    gvSlots.DataSource = ds;
                    gvSlots.DataBind();
                    ContentBox2.Visible = false;
                }
                else
                {
                    tblMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvSlots_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];
                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                //Int32 RowID = Convert.ToInt32(e.CommandName.ToString());
                Int16 SlotId = Convert.ToInt16(((Label)gvSlots.Rows[RowID].FindControl("lblSlotId")).Text);
                Int64 FCDateID = Convert.ToInt64(((Label)gvSlots.Rows[RowID].FindControl("lblFCDateID")).Text);

                if (e.CommandName == "BookSlot")
                {
                    Int16 res = reg.SaveCandidateBookedSlot(FCDateID, SlotId, objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
                    if (res == 3)
                    {
                        shInfo.SetMessage("Previous Appointment Booked is Laps. You can visit to SC.", ShowMessageType.Information);
                    }
                    else
                    {
                        shInfo.SetMessage("Your Slot is Booked Successfully. Following are the Details, Please visit the SC on Time.", ShowMessageType.Information);
                        ViewBookSlotDetails(objSessionData.PID);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvSlots_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lblEnableFlag = (Label)e.Row.FindControl("lblEnableFlag");
                    string EnableFlag = lblEnableFlag.Text;

                    DateTime startTime = Convert.ToDateTime(e.Row.Cells[0].Text);
                    Label lblEndTime = (Label)e.Row.FindControl("lblEndTime");
                    DateTime endTime = Convert.ToDateTime(lblEndTime.Text);

                    e.Row.Cells[0].Text = startTime.ToString("hh:mm tt") + " - " + endTime.ToString("hh:mm tt");



                    if (EnableFlag == "N")
                    {
                        e.Row.Cells[4].Controls[1].Visible = false;
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        decimal AvilabeleSlot = Convert.ToDecimal(e.Row.Cells[1].Text);
                        decimal BookedSlot = Convert.ToDecimal(e.Row.Cells[2].Text);
                        decimal vacantSlot = Convert.ToDecimal(e.Row.Cells[3].Text);
                        if ((BookedSlot / AvilabeleSlot) * 100 > 75)
                        {
                            e.Row.BackColor = System.Drawing.Color.Green;
                        }
                        else if ((BookedSlot / AvilabeleSlot) * 100 > 50)
                        {
                            e.Row.BackColor = System.Drawing.Color.Orange;
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

        protected void btnPScrutiny_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            SessionData objSessionData = (SessionData)Session["SessionData"];
            try
            {
                if (reg.UpdateCandidateFCVerificationFor(objSessionData.PID, "P", Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    DataSet ds = reg.GetCandidateBookingSlotDetails(objSessionData.PID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ContentBox2.Visible = true;
                        lblApplicationID.Text = ds.Tables[0].Rows[0]["ApplicationID"].ToString();
                        lblCandidateName.Text = ds.Tables[0].Rows[0]["CandidateName"].ToString();
                        lblSlotDateTime.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["SlotDate"]).ToString("dd/MM/yyyy") + "  " + ds.Tables[0].Rows[0]["SlotTime"].ToString();
                        lblFCDetails.Text = ds.Tables[0].Rows[0]["FCDetails"].ToString();
                        if (ds.Tables[0].Rows[0]["TimeLaps"].ToString() == "Y")
                        {
                            btnUpdateSlot.Visible = false;
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "HideFCVerificationPopUp();", true);
                }
                else
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "There is some problem in sending Message. Please try after some time.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnEScrutiny_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (reg.UpdateCandidateFCVerificationFor(objSessionData.PID, "E", Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "HideFCVerificationPopUp();", true);
                    Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
                }
                else
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "There is some problem in sending Message. Please try after some time.";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        //protected void btnFcVerification_Click(object sender, EventArgs e)
        //{
        //    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
        //    try
        //    {

        //        SessionData objSessionData = (SessionData)Session["SessionData"];

        //        string res = rbnlVerification.SelectedItem.Value;

        //        if (reg.UpdateCandidateFCVerificationFor(objSessionData.PID, res))
        //        {

        //            strVerificationMode = res;

        //            if (strVerificationMode == "P")
        //            {


        //                DataSet ds = reg.GetCandidateBookingSlotDetails(objSessionData.PID);
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    ContentBox2.Visible = true;
        //                    lblApplicationID.Text = ds.Tables[0].Rows[0]["ApplicationID"].ToString();
        //                    lblCandidateName.Text = ds.Tables[0].Rows[0]["CandidateName"].ToString();
        //                    lblSlotDateTime.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["SlotDate"]).ToString("dd/MM/yyyy") + "  " + ds.Tables[0].Rows[0]["SlotTime"].ToString();
        //                    lblFCDetails.Text = ds.Tables[0].Rows[0]["FCDetails"].ToString();
        //                    if (ds.Tables[0].Rows[0]["TimeLaps"].ToString() == "Y")
        //                    {
        //                        btnUpdateSlot.Visible = false;
        //                    }
        //                }
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "HideFCVerificationPopUp();", true);
        //            }
        //            else
        //            {
        //                if (strVerificationMode == "E")
        //                {
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "HideFCVerificationPopUp();", true);
        //                    Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "HideFCVerificationPopUp();", true);
        //                    ContentBox1.Visible = true;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            lblmessage.Visible = true;
        //            lblmessage.Text = "There is some problem in sending Message. Please try after some time.";
        //            //shInfo.SetMessage("There is some problem in sending Message. Please try after some time.", ShowMessageType.UserError);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logging.LogException(ex, "[Page Level Error]");
        //        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
        //    }
        //}
        protected void btnUpdateSlot_Click(object sender, EventArgs e)
        {
            ContentBox1.Visible = true;
            btnUpdateSlot.Visible = false;
        }
    }
}