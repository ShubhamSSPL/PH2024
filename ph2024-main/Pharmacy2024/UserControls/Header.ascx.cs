using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.UserControls
{
    public partial class Header : System.Web.UI.UserControl
    {
        public string AdmissionYear = Global.AdmissionYear;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void GetHeaderText(string lang)
        {
            //SqlParameter[] param ={ new SqlParameter("@Language", SqlDbType.VarChar) };
            //param[0].Value = lang;

            //DataSet ds = null;
            //try
            //{
            //    ds = new DBUtility().ExecProcedure("Content_Mgt_GetHeaderTextForHeader", param, "tbl");
            //    if (ds.Tables[0].Rows.Count > 0)
            //        lblHeaderText.Text = ds.Tables[0].Rows[0][0].ToString();
            //}
            //catch (DataException decx)
            //{

            //}
            //finally
            //{
            //    if (ds != null)
            //    {
            //        ds.Dispose();
            //        ds = null;
            //    }
            //}

        }
    }
}