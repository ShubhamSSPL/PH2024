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

namespace Pharmacy2024.ARCModule
{
    public partial class frmEditDDDetails : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                    Int32 Code = Convert.ToInt32(Request.QueryString["Code"].ToString());

                    if (PID.ToString().GetHashCode() != Code)
                    {
                        Response.Redirect("../ApplicationPages/WelcomePageARC.aspx", true);
                    }

                    ddlBankName.DataSource = Global.MasterBank;
                    ddlBankName.DataTextField = "BankName";
                    ddlBankName.DataValueField = "BankID";
                    ddlBankName.DataBind();
                    ddlBankName.Items.Insert(0, new ListItem("-- Select Bank --", "0"));

                    tblDDDetails.Visible = false;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;

                    gvDDList.DataSource = reg.getSeatAcceptanceFeeList(PID);
                    gvDDList.DataBind();

                    if (gvDDList.Rows.Count == 0)
                    {
                        ContentTable2.Visible = false;

                        shInfo.SetMessage("No DD List Found.", ShowMessageType.Information);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string BankName = ddlBankName.SelectedItem.Text;

                if (BankName == "[Other Bank]")
                {
                    trOtherBankName.Visible = true;
                }
                else
                {
                    trOtherBankName.Visible = false;
                }

                txtOtherBankName.Text = "";
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void onPageLoad()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string BankName = ddlBankName.SelectedItem.Text;
                if (BankName == "[Other Bank]")
                {
                    trOtherBankName.Visible = true;
                }
                else
                {
                    trOtherBankName.Visible = false;
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
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                SeatAcceptanceFeeDetails obj = new SeatAcceptanceFeeDetails();

                obj.FeeID = Convert.ToInt64(hdnFeeID.Value);
                obj.DDAmount = Convert.ToInt64(txtDDAmount.Text);
                obj.DDNumber = txtDDNumber.Text;
                obj.DDDate = Convert.ToDateTime(txtDDDate.Text.Split("/".ToCharArray())[1] + "/" + txtDDDate.Text.Split("/".ToCharArray())[0] + "/" + txtDDDate.Text.Split("/".ToCharArray())[2]);
                obj.BankID = Convert.ToInt16(ddlBankName.SelectedValue);
                if (ddlBankName.SelectedItem.ToString() == "[Other Bank]")
                {
                    obj.OtherBankName = txtOtherBankName.Text;
                }
                else
                {
                    obj.OtherBankName = "";
                }
                obj.BranchName = txtBranchName.Text;

                if (reg.editSeatAcceptanceFeeDetails(obj, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    gvDDList.DataSource = reg.getSeatAcceptanceFeeList(PID);
                    gvDDList.DataBind();

                    txtDDAmount.Text = "";
                    txtDDNumber.Text = "";
                    txtDDDate.Text = "";
                    ddlBankName.SelectedIndex = 0;
                    txtOtherBankName.Text = "";
                    txtBranchName.Text = "";

                    tblDDDetails.Visible = false;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
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
                txtDDAmount.Text = "";
                txtDDNumber.Text = "";
                txtDDDate.Text = "";
                ddlBankName.SelectedIndex = 0;
                txtOtherBankName.Text = "";
                txtBranchName.Text = "";

                tblDDDetails.Visible = false;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvDDList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 FeeID = Convert.ToInt64(((Label)gvDDList.Rows[e.NewSelectedIndex].Cells[7].FindControl("lblFeeID")).Text);
                DataSet ds = reg.getSeatAcceptanceFeeDetails(FeeID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    hdnFeeID.Value = ds.Tables[0].Rows[0]["FeeID"].ToString();
                    txtDDAmount.Text = ds.Tables[0].Rows[0]["DDAmount"].ToString();
                    txtDDNumber.Text = ds.Tables[0].Rows[0]["DDNumber"].ToString();
                    txtDDDate.Text = ds.Tables[0].Rows[0]["DDDate"].ToString();
                    ddlBankName.SelectedValue = ds.Tables[0].Rows[0]["BankID"].ToString();
                    txtOtherBankName.Text = ds.Tables[0].Rows[0]["OtherBankName"].ToString();
                    txtBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                }

                onPageLoad();

                tblDDDetails.Visible = true;
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