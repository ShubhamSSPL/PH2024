using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmNews : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request.Cookies["Theme"] == null)
            {
                //Page.Theme = "default";
            }
            else
            {
                //Page.Theme = Request.Cookies["Theme"].Value;
            }

            if (Session["UserLoginID"] != null)
            {
                if (Request.QueryString["tms"] != null)
                {
                    this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.master";
                }
                else
                {
                    this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master";
                }
            }
            else
            {
                if (Request.QueryString["tms"] != null)
                {
                    this.Page.MasterPageFile = "~/MasterPages/StaticMasterPageWithOutLeftMenuSB.master";
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
                    DataSet ds = reg.getListOfLinksOfaPanel(2);
                    tblLinks.Rows.Clear();

                    if (ds.Tables.Count > 0)
                    {
                        HtmlTableRow row = new HtmlTableRow();
                        HtmlTableCell cell = new HtmlTableCell();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            this.cb.HeaderText = ds.Tables[0].Rows[0]["GroupDisplayText"].ToString();

                            for (Int32 i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                row = new HtmlTableRow();
                                cell = new HtmlTableCell();

                                if (Int32.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                                {
                                    HyperLink child = new HyperLink();
                                    child.Text = "<img src='../SynthesysModules_Files/Images/expandermenu_arrow.gif' alt='' border='0' />" + ds.Tables[0].Rows[i]["MenuName"].ToString();
                                    child.NavigateUrl = ds.Tables[0].Rows[i]["MenuUrl"].ToString();
                                    cell.Controls.Add(child);
                                }
                                else
                                {
                                    cell.InnerHtml = "<img src='../SynthesysModules_Files/Images/expandermenu_arrow.gif' alt='' border='0' />" + ds.Tables[0].Rows[i]["MenuName"].ToString();
                                    cell.Attributes.Add("class", "text");
                                }

                                row.Cells.Add(cell);
                                tblLinks.Rows.Add(row);
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
        }
        public class dbUtility  
        {
            public DataSet getListOfLinksOfaPanel(Int32 GroupID)
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@GroupID", SqlDbType.Int)
                };

                parameters[0].Value = GroupID;

                DBConnection db = new DBConnection();
                try
                {
                   return db.ExecuteDataSet("Menu_Mgt_GetListOfLinksOfaPanel", parameters);
                     
                   
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}