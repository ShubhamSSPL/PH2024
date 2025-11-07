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

namespace Pharmacy2024.AFCModule
{
    public partial class frmControlProjectConfiguration : System.Web.UI.Page
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
            if (Session["UserTypeID"].ToString() != "21")
            {
                Response.Redirect("../ApplicationPages/WelcomePage.aspx", true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    onPageLoad();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void onPageLoad()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                gvProjectConfigurationList.DataSource = reg.getProjectConfigurationList();
                gvProjectConfigurationList.DataBind();

                for (Int32 i = 0; i < gvProjectConfigurationList.Rows.Count; i++)
                {
                    gvProjectConfigurationList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                }

                cbProjectConfigurationDetails.Visible = false;

                lblAppKeyDetails.Text = "";
                ddlAppValue.Items.Clear();
                txtAppValue.Text = "";
                hdnAppKey.Value = "";
                hdnControlRequired.Value = "";
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
                string AppKey = hdnAppKey.Value;
                string AppValue = "";
                if (hdnControlRequired.Value == "DropDownList")
                {
                    AppValue = ddlAppValue.SelectedValue;
                }
                else if (hdnControlRequired.Value == "TextBox")
                {
                    AppValue = txtAppValue.Text;
                }
                string ModifiedBy = Session["UserLoginID"].ToString();
                string ModifiedByIPAddress = UserInfo.GetIPAddress();

                if (reg.saveProjectConfigurationDetails(AppKey, AppValue, ModifiedBy, ModifiedByIPAddress))
                {
                    Global g = new Global();
                    g.setGlobalVariables();

                    onPageLoad();

                    shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
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
                onPageLoad();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvProjectConfigurationList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string AppKey = ((Label)gvProjectConfigurationList.Rows[e.NewSelectedIndex].FindControl("lblAppKey")).Text;
                DataSet ds = reg.getProjectConfigurationDetails(AppKey);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbProjectConfigurationDetails.Visible = true;

                    hdnAppKey.Value = AppKey;
                    hdnControlRequired.Value = ds.Tables[0].Rows[0]["ControlRequired"].ToString();

                    lblAppKeyDetails.Text = ds.Tables[0].Rows[0]["AppKeyDetails"].ToString();
                    if (hdnControlRequired.Value == "DropDownList")
                    {
                        trDropDownList.Visible = true;
                        trTextBox.Visible = false;
                        ddlAppValue.Items.Clear();
                        if (lblAppKeyDetails.Text == "Current Scrutiny Mode")
                        {
                            ddlAppValue.Items.Add("E");
                            ddlAppValue.Items.Add("P");
                            ddlAppValue.Items.Add("Both");

                        }
                        else
                        {
                            for (Int32 i = 0; i <= Convert.ToInt16(ds.Tables[0].Rows[0]["ControlMaxValue"].ToString()); i++)
                            {
                                ddlAppValue.Items.Add(i.ToString());
                            }
                        }
                        
                        //for (Int32 i = 0; i <= Convert.ToInt16(ds.Tables[0].Rows[0]["ControlMaxValue"].ToString()); i++)
                        //{
                        //    ddlAppValue.Items.Add(i.ToString());
                        //}
                        ddlAppValue.Items.Insert(0, new ListItem("-- Select Key Value --", "-1"));

                        ddlAppValue.SelectedValue = ds.Tables[0].Rows[0]["AppValue"].ToString();
                    }
                    else if (hdnControlRequired.Value == "TextBox")
                    {
                        trDropDownList.Visible = false;
                        trTextBox.Visible = true;

                        txtAppValue.Text = ds.Tables[0].Rows[0]["AppValue"].ToString();
                    }
                    else
                    {
                        trDropDownList.Visible = false;
                        trTextBox.Visible = false;
                    }
                }
                else
                {
                    cbProjectConfigurationDetails.Visible = false;
                    shInfo.SetMessage("No Record Found.", ShowMessageType.Information);
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