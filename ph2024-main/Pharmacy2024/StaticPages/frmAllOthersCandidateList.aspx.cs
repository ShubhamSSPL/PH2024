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
    public partial class frmAllOthersCandidateList : System.Web.UI.Page
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

            if (Session["UserLoginId"] != null)
            {
                this.Page.MasterPageFile = "~/MasterPages/DynamicMasterPage.master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                ContentTable1.HeaderText = "List of Candidates and their Application Status who have applied under NRI / OCI / PIO / Children of Indian workers in Gulf countries / Foreign National Candidature Type till " + DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
            }
        }
        protected void ddlCandidatureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                dbUtility reg = new dbUtility();

                gvList.DataSource = reg.getAllOthersCandidateList(Convert.ToInt32(ddlCandidatureType.SelectedValue));
                gvList.DataBind();
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
        public DataSet getAllOthersCandidateList(int Flag)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@Flag", SqlDbType.Int)
        };

            parameters[0].Value = Flag;
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetAllOthersCandidateList", parameters);
            }
            finally
            {
                db.Dispose();
            }


        }
    }
}
