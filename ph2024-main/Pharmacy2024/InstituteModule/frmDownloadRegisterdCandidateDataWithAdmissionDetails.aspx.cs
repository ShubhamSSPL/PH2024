using BusinessLayer;
using ClosedXML.Excel;
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

namespace Pharmacy2024.InstituteModule
{
    public partial class frmDownloadRegisterdCandidateDataWithAdmissionDetails : System.Web.UI.Page
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
                    //this.BindAdmittedCandidateList();
                    dbUtilityDownLoad db = new dbUtilityDownLoad();

                    DataSet ds = db.GetAllRegistrationData();
                    int count = ds.Tables[0].Rows.Count;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        db.UpdateCandidateDecryptedMobileNo(Convert.ToInt64(dr["PersonalID"].ToString()), DataEncryption.DecryptDataByEncryptionKey(dr["MobileNo"].ToString()));

                        count--;
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        //protected void OnExportExcel(object sender, EventArgs e)
        //{
        //    using (XLWorkbook wb = new XLWorkbook())
        //    {
        //        for (int i = 0; i < gvAdmittedCandidateList.PageCount; i++)
        //        {
        //            gvAdmittedCandidateList.PageIndex = i;
        //            this.BindAdmittedCandidateList();

        //            DataTable dt = new DataTable("Page_" + (i + 1));
        //            foreach (TableCell cell in gvAdmittedCandidateList.HeaderRow.Cells)
        //            {
        //                dt.Columns.Add(cell.Text);
        //            }
        //            foreach (GridViewRow row in gvAdmittedCandidateList.Rows)
        //            {
        //                dt.Rows.Add();
        //                for (int j = 0; j < row.Cells.Count - 1; j++)
        //                {
        //                    if (row.Cells[j].Controls.Count > 0)
        //                    {
        //                        dt.Rows[dt.Rows.Count - 1][j] = (row.Cells[j].Controls[1] as Label).Text;
        //                    }
        //                    else
        //                    {
        //                        dt.Rows[dt.Rows.Count - 1][j] = row.Cells[j].Text;
        //                    }
        //                }
        //            }
        //            wb.Worksheets.Add(dt);
        //        }
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        Response.AddHeader("content-disposition", "attachment;filename=GridView.xlsx");
        //        using (MemoryStream MyMemoryStream = new MemoryStream())
        //        {
        //            wb.SaveAs(MyMemoryStream);
        //            MyMemoryStream.WriteTo(Response.OutputStream);
        //            Response.Flush();
        //            Response.End();
        //        }
        //    }
        //}

        //protected void gvAdmittedCandidateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    this.gvAdmittedCandidateList.PageIndex = e.NewPageIndex;
        //    this.BindAdmittedCandidateList();
             
        //}

        private void BindAdmittedCandidateList()
        {
            gvAdmittedCandidateList.DataSource = reg.downloadRegisterdCandidateDataWithAdmissionDetails();
            gvAdmittedCandidateList.DataBind();

            for (Int32 m = 1; m <= gvAdmittedCandidateList.Rows.Count; m++)
            {
                //gvAdmittedCandidateList.Rows[m - 1].Cells[0].Text = m.ToString() + ".";
                gvAdmittedCandidateList.Rows[m - 1].Cells[23].Text = DataEncryption.DecryptDataByEncryptionKey(gvAdmittedCandidateList.Rows[m - 1].Cells[23].Text);
            }
        }
        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=AdmittedCandidateList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvAdmittedCandidateList.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        public class dbUtilityDownLoad
        {
            public DataSet GetAllRegistrationData()
            {
                DBConnection db = new DBConnection();
                try
                {
                    SqlParameter[] param =
                   {  new SqlParameter("@PID",SqlDbType.BigInt),
                    };

                    param[0].Value = 0;

                    return db.ExecuteDataSet("MHDTE_spGetAllRegistrationData", param);
                }
                finally
                {
                    db.Dispose();
                }

            }
            public bool UpdateCandidateDecryptedMobileNo(Int64 PID, string DecryptedMobileNo)
            {
                DBConnection db = new DBConnection();
                try
                {
                    SqlParameter[] param =
                   {
                    new SqlParameter("@PID",SqlDbType.Int),
                    new SqlParameter("@DecryptedMobileNo", SqlDbType.VarChar),
                };

                    param[0].Value = PID;
                    param[1].Value = DecryptedMobileNo;

                    Int32 result = Convert.ToInt32(db.ExecuteNonQuery("MHDTE_spUpdateCandidateDecryptedMobileNo", param).ToString());
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                finally
                {
                    db.Dispose();
                }

            }
        }
    }
}