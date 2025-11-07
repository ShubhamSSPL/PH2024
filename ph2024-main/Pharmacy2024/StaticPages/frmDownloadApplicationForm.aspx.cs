using BusinessLayer;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Synthesys.Controls;
using SynthesysDAL;
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
    public partial class frmDownloadApplicationForm : System.Web.UI.Page
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

            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            DBConnection db = new DBConnection();
            try
            {

                DataSet ds = new DataSet();
                ds = db.ExecuteDataSet("spDownloadDocumentCandidates", new SqlParameter[] { });
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    Response.Redirect("../StaticPages/frmPrintApplicationForm.aspx?PID=" + long.Parse(dr["PersonalID"].ToString()) + "&Code=" + long.Parse(dr["PersonalID"].ToString()).ToString().GetHashCode(), true);
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);

            }
            finally
            {
                db.Dispose();
            }
        }
        protected void SaveASPFD(string PID)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + PID.ToString() + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}