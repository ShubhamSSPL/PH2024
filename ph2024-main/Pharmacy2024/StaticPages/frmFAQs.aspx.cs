using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmFAQs : System.Web.UI.Page
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

            if (Session["UserLoginID"] != null)
            {
                if (Request.QueryString["tms"] != null)
                {
                    this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageWithOutLeftMenu.master";
                }
                else
                {
                    this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPage.master";
                }
            }
            else
            {
                if (Request.QueryString["tms"] != null)
                {
                    this.Page.MasterPageFile = "~/MasterPages/StaticMasterPageWithOutLeftMenu.master";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {


                    DataSet ds = reg.getFAQsListForDisplay();

                    if (ds != null && ds.Tables.Count > 1 && ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Relations.Add("MyRelation", ds.Tables[0].Columns["SectionID"], ds.Tables[1].Columns["SectionID"]);

                        SectionRepeater.DataSource = ds.Tables[0];
                        SectionRepeater.DataBind();
                    }
                    else
                    {
                        shInfo.SetMessage("No Data Found", ShowMessageType.Information);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public void SectionRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
            {
                Repeater QuestionRepeater = (Repeater)item.FindControl("QuestionRepeater");
                DataRowView drv = (DataRowView)item.DataItem;
                QuestionRepeater.DataSource = drv.CreateChildView("MyRelation");
                QuestionRepeater.DataBind();
            }
        }
    }
}