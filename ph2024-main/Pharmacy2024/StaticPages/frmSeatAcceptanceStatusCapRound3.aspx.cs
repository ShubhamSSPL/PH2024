using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using Synthesys.Controls;
using Synthesys.DataAcess;

namespace Pharmacy2024.StaticPages
{
    public partial class frmSeatAcceptanceStatusCapRound3 : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            //if (Request.Cookies["Theme"] == null)
            //{
            //    Page.Theme = "default";
            //}
            //else
            //{
            //    Page.Theme = Request.Cookies["Theme"].Value;
            //}

            //if (Session["UserLoginID"] != null)
            //{
            //    if (Request.QueryString["tms"] != null)
            //    {
            //        this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.master";
            //    }
            //    else
            //    {
            //        this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master";
            //    }
            //}
            //else
            //{
            //    if (Request.QueryString["tms"] != null)
            //    {
            //        this.Page.MasterPageFile = "~/MasterPages/StaticMasterPageWithOutLeftMenuSB.master";
            //    }
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserTypeID"] == null  )
            //{
            //    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            //}
            //if (Session["UserTypeID"].ToString() == "21")
            {
                ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                if (!IsPostBack)
                {
                    try
                    {
                        if (Session["SecretKey"] == null)
                        {
                           
                            //if(Session["SecreteKey"].ToString() != Application["SecretKey"].ToString())
                            ClientScript.RegisterStartupScript(GetType(), "id", "showSecretKey()", true);
                        }
                        else
                        {
                           // if (Session["SecreteKey"].ToString() == Application["SecretKey"].ToString())
                                LoadDashboard();
                            //else
                            //{
                              //  ClientScript.RegisterStartupScript(GetType(), "id", "showSecretKey()", true);
                            //}
                        }

                        //gvApplicationFormStatus.DataSource = reg.GetApplicationStatusReport().Tables[1];
                        //gvApplicationFormStatus.DataBind();

                        //for (Int32 i = 0; i < gvApplicationStatusReport.Rows.Count; i++)
                        //{
                        //    //if (i < 4)
                        //    //    gvApplicationStatusReport.Rows[i].BackColor = System.Drawing.Color.Green;
                        //    //if (i > 3 && i < 8)
                        //    //    gvApplicationStatusReport.Rows[i].BackColor = System.Drawing.Color.Yellow;
                        //    if (gvApplicationStatusReport.Rows[i].Cells[0].Text == "Total")
                        //    {
                        //        gvApplicationStatusReport.Rows[i].Cells[1].Text = "( " + gvApplicationStatusReport.Rows[i - 2].Cells[1].Text + " (A) + " + gvApplicationStatusReport.Rows[i - 1].Cells[1].Text + " (B) = " +
                        //            gvApplicationStatusReport.Rows[i].Cells[1].Text + " )";
                        //    }
                        //}
                        //for (Int32 i = 0; i < gvApplicationFormStatus.Rows.Count; i++)
                        //{
                        //    gvApplicationFormStatus.Rows[i].BackColor = System.Drawing.Color.LightYellow;
                        //}
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "[Page Level Error]");
                        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                    }
                }
            }
            

        }
        public void LoadDashboard()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);

            DataSet dsDashboard = new dbUtilityOptionForm().GetStatus();

            gvAll.DataSource = dsDashboard.Tables[0];
            gvAll.DataBind();
        }
        protected void btnSecretKey_Click(object sender, EventArgs e)
        {
            if (txtkey.Text == Application["SecretKey"].ToString())
            {
                Session["SecretKey"] = Application["SecretKey"].ToString();
                Response.Redirect("frmSeatAcceptanceStatusCapRound3");
            }
            else
            {
                lblmsg.Text = "Enter the Correct SecretKey !!";
                lblmsg.Visible = true;
                Label2.Text = "Enter the Correct SecretKey !!";
                Label2.Visible = true;
            }
        }
        public class dbUtilityOptionForm
        {
            public DataSet GetStatus()
            {
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("sp_GetSelfSeatAcceptanceInsituteCntCAPRound3", new SqlParameter[] { });
                }
                finally
                {
                    db.Dispose();
                }

            }
        }
    }
}