using BusinessLayer;
using OptionDropDownList;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ApplicationPages
{
    public partial class WelcomePageHelpDesk : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
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
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                    string UserLoginID = Session["UserLoginID"].ToString();
                    DataSet ds = Global.MasterWebSite;
                    List<OptionGroupItem> lista = new List<OptionGroupItem>();

                    if (ds != null)
                    {
                        OptionGroupItem items = new OptionGroupItem();
                        items.Text = "-- Select WebSite --";
                        items.Value = "0";
                        lista.Add(items);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                OptionGroupItem item = new OptionGroupItem();
                                item.Value = dr["WebSiteURL"].ToString();
                                item.Text = dr["WebSiteName"].ToString();
                                item.OptionGroup = dr["WebSiteGroup"].ToString();
                                lista.Add(item);

                            }
                        }
                    }
                    ddlWebSite.DataSource = lista;

                    ddlWebSite.DataBind();

                    //ddlWebSite.DataSource = Global.MasterWebSite;
                    //ddlWebSite.DataTextField = "WebSiteName";
                    //ddlWebSite.DataValueField = "WebSiteURL";
                    //ddlWebSite.DataGroupField = "WebSiteGroup";
                    //ddlWebSite.DataBind();
                    //ListItem liWebSite = new ListItem("-- Select WebSite --", "0");
                    //liWebSite.Attributes.Add("DataGroupField", "");
                    //ddlWebSite.Items.Insert(0, liWebSite);

                    DataSet dsLoginDetails = reg.getLoginDetails(UserLoginID, UserTypeID);
                    if (dsLoginDetails.Tables[0].Rows.Count > 0)
                    {
                        lblLoginID.Text = dsLoginDetails.Tables[0].Rows[0]["LoginID"].ToString();
                        lblUserName.Text = dsLoginDetails.Tables[0].Rows[0]["UserName"].ToString();
                        lblUserType.Text = dsLoginDetails.Tables[0].Rows[0]["UserTypeName"].ToString();
                        DateTime CurrentLoginDateTime = Convert.ToDateTime(dsLoginDetails.Tables[0].Rows[0]["CurrentLoginDateTime"].ToString());
                        lblCurrentLoginTime.Text = CurrentLoginDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", CurrentLoginDateTime);
                        DateTime LastLoginDateTime = Convert.ToDateTime(dsLoginDetails.Tables[0].Rows[0]["LastLoginDateTime"].ToString());
                        lblPreviousLoginTime.Text = LastLoginDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", LastLoginDateTime);
                        lblIPAddress.Text = UserInfo.GetIPAddress();
                    }

                    if (UserTypeID == 21 || UserTypeID == 22 || UserTypeID == 66)
                    {
                        trWebSiteNavigation1.Visible = true;
                        trWebSiteNavigation2.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlWebSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlWebSite.SelectedValue != "0")
                {
                    Response.Redirect(ddlWebSite.SelectedValue + Session["UserLoginID"].ToString() + "&Code=" + Session["UserLoginID"].ToString().GetHashCode(), true);
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