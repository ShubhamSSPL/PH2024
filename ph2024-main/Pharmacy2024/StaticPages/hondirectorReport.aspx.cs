using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using Synthesys.Controls;

namespace Pharmacy2024.StaticPages
{
    public partial class hondirectorReport : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
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
            //if (Session["UserTypeID"] == null  )
            //{
            //    Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            //}
            //if (Session["UserTypeID"].ToString() == "21")
            {
                ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                lblPrintedOn1.Text = "Date : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);

                if (!IsPostBack)
                {
                    try
                    {
                        //if (Session["SecretKey"] == null)
                        //{

                        //    //if(Session["SecreteKey"].ToString() != Application["SecretKey"].ToString())
                        //    ClientScript.RegisterStartupScript(GetType(), "id", "showSecretKey()", true);
                        //}
                        //else
                        //{

                        DataSet ds = reg.GetDirectorReport();

                        gvRegistration.DataSource = ds.Tables[0];
                        gvRegistration.DataBind();

                        gvDevice.DataSource = ds.Tables[1];
                        gvDevice.DataBind();

                        gvScrutinyMode.DataSource = ds.Tables[2];
                        gvScrutinyMode.DataBind();

                        gvEVerificationStatus.DataSource = ds.Tables[3];
                        gvEVerificationStatus.DataBind();

                        gvEVerificationStatus.Rows[4].BackColor = Color.Chocolate;
                        gvEVerificationStatus.Rows[4].Cells[0].Font.Bold = true;
                        gvEVerificationStatus.Rows[4].Cells[1].Font.Bold = true;
                        //gvEVerificationStatus.Rows[4].Cells[2].Font.Bold = true;
                        //gvEVerificationStatus.Rows[4].Cells[3].Font.Bold = true;
                        //gvEVerificationStatus.Rows[4].Cells[2].Font.Bold = true;

                        gvPVerificationStatus.DataSource = ds.Tables[4];
                        gvPVerificationStatus.DataBind();

                        gvPVerificationStatus.Rows[3].BackColor = Color.Chocolate;
                        gvPVerificationStatus.Rows[3].Cells[0].Font.Bold = true;
                        gvPVerificationStatus.Rows[3].Cells[1].Font.Bold = true;
                        //gvPVerificationStatus.Rows[3].Cells[2].Font.Bold = true;
                        //gvPVerificationStatus.Rows[3].Cells[3].Font.Bold = true;
                        //gvPVerificationStatus.Rows[3].Cells[2].Font.Bold = true;

                        gvEScrutinyBreakup.DataSource = ds.Tables[5];
                        gvEScrutinyBreakup.DataBind();

                        lbleFCAwating.Text = ds.Tables[3].Rows[1]["Total"].ToString();


                        //}  // Secret Key end
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "[Page Level Error]");
                        shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                    }
                }
            }
            //else
            //{
            //    ContentTable1.Visible = false;
            //}

        }

        protected void btnSecretKey_Click(object sender, EventArgs e)
        {
            if (txtkey.Text == Application["SecretKey"].ToString())
            {
                Session["SecretKey"] = Application["SecretKey"].ToString();
                Response.Redirect("directorReport");
            }
            else
            {
                lblmsg.Text = "Enter the Correct SecretKey !!";
                lblmsg.Visible = true;
                Label2.Text = "Enter the Correct SecretKey !!";
                Label2.Visible = true;
            }
        }
    }
}