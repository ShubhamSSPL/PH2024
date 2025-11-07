using BusinessLayer;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmInstituteList_BATU : System.Web.UI.Page
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
                    dbUtility reg = new dbUtility();

                    gvInstituteList.DataSource = reg.getInstituteWiseIntakeList();
                    gvInstituteList.DataBind();

                    Int32 TotalIntake = 0;

                    for (Int32 i = 0; i < gvInstituteList.Rows.Count; i++)
                    {
                        gvInstituteList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        TotalIntake += Convert.ToInt32(gvInstituteList.Rows[i].Cells[4].Text);
                    }

                    gvInstituteList.FooterRow.Cells[3].Text = "Total";
                    gvInstituteList.FooterRow.Cells[4].Text = TotalIntake.ToString();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public class dbUtility
        {
            public DataSet getInstituteWiseIntakeList()
            {
                SqlParameter[] parameters =
                {
            };
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetInstituteWiseIntakeList_BATU", parameters);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}