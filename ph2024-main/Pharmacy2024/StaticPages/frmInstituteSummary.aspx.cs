using BusinessLayer;
using EntityModel;
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
    public partial class frmInstituteSummary : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                try
                {


                    string InstituteCode = Request.QueryString["InstituteCode"].ToString();
                    InstituteSummary obj = reg.getInstituteSummary(InstituteCode);

                    lblInstituteCode.Text = obj.InstituteCode;
                    lblInstituteName.Text = obj.InstituteName;
                    lblInstituteAddress.Text = obj.InstituteAddress;
                    lblRegion.Text = obj.RegionName;
                    lblDistrict.Text = obj.DistrictName;
                    lblStatus1.Text = obj.InstituteStatus1;
                    lblStatus2.Text = obj.InstituteStatus2;
                    lblStatus3.Text = obj.InstituteStatus3;
                    lblPublicRemark.Text = obj.PublicRemark;

                    gvChoiceCodeList.DataSource = new dbUtility().getParticipateInCAPChoiceCodeList(InstituteCode);
                    gvChoiceCodeList.DataBind();
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
            public DataSet getParticipateInCAPChoiceCodeList(string InstituteCode)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@InstituteCode", SqlDbType.VarChar, 5)
            };

                parameters[0].Value = InstituteCode;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetParticipateInCAPChoiceCodeList", parameters);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}