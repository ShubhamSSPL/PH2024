using Pharmacy2024;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmTotalAdmittedandVacancy : System.Web.UI.Page
    {
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
            if (!IsPostBack)
            {
                try
                {

                    dbUtility db = new dbUtility();


                    ContentBox1.HeaderText = "LIST SHOWING CURRENT SUMMARY OF (B. PHARMACY AND PHARM. D.), (B.E. / B. TECH.), (M.E. / M. TECH) , (POSTHSC Diploma) ADMISSSIONS "+ AdmissionYear + " AS ON " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToShortTimeString();
                    Int64 CAPVacancy = 0, CAPAdmitted = 0, CAPCancelled = 0, CAP = 0;


                    GridView1.DataSource = db.getInstituteWiseIntakeList().Tables[0];
                    GridView1.DataBind();

                    for (Int32 i = 0; i < GridView1.Rows.Count; i++)
                    {
                        CAPAdmitted += Convert.ToInt64(GridView1.Rows[i].Cells[2].Text);
                        CAPCancelled += Convert.ToInt64(GridView1.Rows[i].Cells[3].Text);
                        CAPVacancy += Convert.ToInt64(GridView1.Rows[i].Cells[4].Text);
                        CAP += Convert.ToInt64(GridView1.Rows[i].Cells[5].Text);
                        GridView1.Rows[i].Cells[6].Text = (System.Math.Round(((Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text) / Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text)) * 100), 2)).ToString() + " %";
                    }
                    GridView1.FooterRow.Cells[1].Text = "Total";
                    GridView1.FooterRow.Cells[2].Text = CAPAdmitted.ToString();
                    GridView1.FooterRow.Cells[3].Text = CAPCancelled.ToString();
                    GridView1.FooterRow.Cells[4].Text = CAPVacancy.ToString();
                    GridView1.FooterRow.Cells[5].Text = CAP.ToString();
                    GridView1.FooterRow.Cells[6].Text = (System.Math.Round(((Convert.ToDecimal(CAP) / Convert.ToDecimal(CAPCancelled)) * 100), 2)).ToString() + " %";

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    //shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }


        public class dbUtility 
        {
            public DataSet getInstituteWiseIntakeList()
            {
                SqlParameter[] parameters =
                { 
                 //new SqlParameter("@District", SqlDbType.VarChar)
            };
                // parameters[0].Value = DistrictID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGet_TAV_AllApplications", parameters);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=CompositeReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            GridView1.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}