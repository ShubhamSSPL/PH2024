using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmEFCOfficerCapacityPOSTHSC : System.Web.UI.Page
    {
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
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();
                    DBUtilityChangeMode regDB = new DBUtilityChangeMode();
                    gvReport.DataSource = regDB.GetCapacity(UserTypeID, UserLoginID);
                    gvReport.DataBind();

                    for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                    {
                        gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                    }

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
               


        }

        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string attachment = "attachment; filename=E-SC_Officer_Capacity_POSTHSC.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);
                gvReport.RenderControl(htextw);
                Response.Write(stw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        private class DBUtilityChangeMode
        {
            public DataSet GetCapacity(Int32 UserTypeID, string UserLoginID)
            {
                SqlParameter[] parameters =
            {
            new SqlParameter("@UserTypeID",SqlDbType.Int),
            new SqlParameter("@UserLoginID",SqlDbType.VarChar,50),
        };
                parameters[0].Value = UserTypeID;
                parameters[1].Value = UserLoginID;
                DBConnection db = new DBConnection();
                try
                {
                //return db.ExecuteDataSet("MHDTE_spGetApplicationfromEFCOfficerCapacity");
                    return db.ExecuteDataSet("MHDTE_spGetApplicationfromEFCOfficerCapacity", parameters);

                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}