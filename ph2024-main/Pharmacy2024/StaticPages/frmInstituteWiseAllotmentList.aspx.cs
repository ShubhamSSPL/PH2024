using BusinessLayer;
using Pharmacy2024;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmInstituteWiseAllotmentList : System.Web.UI.Page
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
                    string[] CapRoundNotInCapRound1 = new string[] { };
                    //string[] CapRoundNotInCapRound1 = new string[] { "1160","1286","2561","2564","2592","5462","6391","6392" };
                    //string[] CapRoundNotInCapRound2 = new string[] { "4654", "2548" };
                    gvInstituteList.DataSource = Global.MasterInstituteListForAllotmentDisplay;
                    gvInstituteList.DataBind();

                    for (Int32 m = 1; m <= gvInstituteList.Rows.Count; m++)
                    {
                        gvInstituteList.Rows[m - 1].Cells[0].Text = m.ToString() + ".";
                        foreach (var bale in CapRoundNotInCapRound1)
                        {
                            if (bale.Contains(gvInstituteList.Rows[m - 1].Cells[1].Text))
                                gvInstituteList.Rows[m - 1].Cells[3].Text = "";
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
}