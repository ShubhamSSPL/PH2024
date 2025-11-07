using BusinessLayer;
using ClosedXML.Excel;
using Synthesys.Controls;
using SynthesysDAL;
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
    public partial class frmProvisionallyConfirmedCandidateList : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                    string UserLoginID = Session["UserLoginID"].ToString();

                    gvCandidateList.DataSource = new GetProvisionalConfirmedcandidatelist().getProvisionallyConfirmedCandidateList(UserTypeID, UserLoginID);
                    gvCandidateList.DataBind();

                    for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                    {
                        gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        gvCandidateList.Rows[i].Cells[3].Text = DataEncryption.DecryptDataByEncryptionKey(gvCandidateList.Rows[i].Cells[3].Text);

                        DateTime dt = Convert.ToDateTime(gvCandidateList.Rows[i].Cells[4].Text);
                        gvCandidateList.Rows[i].Cells[4].Text = dt.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", dt);
                    }

                    lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public void exportToExcel(string FileName, DataSet ds)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(ds.Tables[0], FileName);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        
        protected void btnexporttoExcel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string attachment = "attachment; filename=ProvConfirmCandList.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);
                gvCandidateList.RenderControl(htextw);
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
            //Required to verify that the control is rendered properly on page
        }

    }
    public class GetProvisionalConfirmedcandidatelist
    {
        public DataSet getProvisionallyConfirmedCandidateList(Int32 UserTypeID, string UserLoginID)
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
                return db.ExecuteDataSet("MHDTE_spGetProvisionallyConfirmedCandidateList", parameters);
            }
            finally
            {
                db.Dispose();
            }


        }
    }
}