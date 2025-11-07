using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmInstituteWiseCapRoundIList : System.Web.UI.Page
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
                    if (Session["UserTypeID"].ToString() == "43")
                    {
                        gvSMSList.Visible = true;
                        gvRegion.Visible = false;
                        dbUtility db = new dbUtility();
                        DataSet ds = db.GetStatus(Convert.ToInt32(Session["UserLoginID"]), 43, 1);
                        gvSMSList.DataSource = ds;
                        gvSMSList.DataBind();
                    }
                    else if (Session["UserTypeID"].ToString() == "21")
                    {
                        gvSMSList.Visible = false;
                        gvRegion.Visible = true;
                        dbUtility db = new dbUtility();
                        DataSet ds = db.GetStatus(0, 21, 1);
                        gvRegion.DataSource = ds;
                        gvRegion.DataBind();
                    }
                    else if (Session["UserTypeID"].ToString() == "22")
                    {

                        gvSMSList.Visible = false;
                        gvRegion.Visible = true;
                        dbUtility db = new dbUtility();

                        DataSet ds = db.GetStatus(SynCommon.GetRoRegionId(Session["UserLoginID"].ToString()), 22, 1);
                        gvRegion.DataSource = ds;
                        gvRegion.DataBind();
                    }
                    else
                    {
                        gvSMSList.Visible = false;
                    }
                    for (Int32 i = 0; i < gvSMSList.Rows.Count; i++)
                    {
                        // gvSMSList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        gvSMSList.Rows[i].Cells[2].Text = DataEncryption.DecryptDataByEncryptionKey(gvSMSList.Rows[i].Cells[2].Text);
                    }
                    for (Int32 i = 0; i < gvRegion.Rows.Count; i++)
                    {
                        // gvRegion.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        gvRegion.Rows[i].Cells[4].Text = DataEncryption.DecryptDataByEncryptionKey(gvRegion.Rows[i].Cells[4].Text);
                    }


                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                    //_ServiceMonitorThread.Abort();
                }
            }
        }
        protected void gvSMSList_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        protected void gvRegion_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void ddlSMSType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                dbUtility db = new dbUtility();

                int smstype = Convert.ToInt16(ddlSMSType.SelectedValue.ToString());
                if (Session["UserTypeID"].ToString() == "43")
                {
                    gvSMSList.Visible = true;
                    gvRegion.Visible = false;
                    DataSet ds = db.GetStatus(Convert.ToInt32(Session["UserLoginID"]), 43, smstype);
                    gvSMSList.DataSource = ds;
                    gvSMSList.DataBind();
                }
                else if (Session["UserTypeID"].ToString() == "21")
                {
                    gvSMSList.Visible = false;
                    gvRegion.Visible = true;
                    DataSet ds = db.GetStatus(0, 21, smstype);
                    gvRegion.DataSource = ds;
                    gvRegion.DataBind();
                }
                else if (Session["UserTypeID"].ToString() == "22")
                {

                    gvSMSList.Visible = false;
                    gvRegion.Visible = true;
                    DataSet ds = db.GetStatus(SynCommon.GetRoRegionId(Session["UserLoginID"].ToString()), 22, smstype);
                    gvRegion.DataSource = ds;
                    gvRegion.DataBind();
                }
                else
                {
                    gvSMSList.Visible = false;
                    gvRegion.Visible = false;
                }

                for (Int32 i = 0; i < gvSMSList.Rows.Count; i++)
                {
                    // gvSMSList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    gvSMSList.Rows[i].Cells[2].Text = DataEncryption.DecryptDataByEncryptionKey(gvSMSList.Rows[i].Cells[2].Text);
                }
                for (Int32 i = 0; i < gvRegion.Rows.Count; i++)
                {
                    // gvRegion.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                    gvRegion.Rows[i].Cells[4].Text = DataEncryption.DecryptDataByEncryptionKey(gvRegion.Rows[i].Cells[4].Text);
                }

            }
            catch (Exception ex)
            {

            }
        }
        //private FinalSMS CreateSmsTemplate(DataRow dr, string strSMSTemp)
        //{
        //    FinalSMS sm = new FinalSMS();
        //    SMSTemplate sMSTemplate = new SMSTemplate();
        //    sMSTemplate.ProjectName = Global.ProjectNameSMS;
        //    if (dr["CandidateName"] != null)
        //        sMSTemplate.CandidateName = dr["CandidateName"].ToString();
        //    if (dr["MobileNo"] != null)
        //    {
        //        sm.MobileNo = DataEncryption.DecryptDataByEncryptionKey(dr["MobileNo"].ToString());
        //    }
        //    if (dr["ApplicationID"] != null)
        //        sMSTemplate.ApplicationID = dr["ApplicationID"].ToString();
        //    sm.ApplicationID = sMSTemplate.ApplicationID;
        //    sm.CandidateName = sMSTemplate.CandidateName;
        //    sm.SMS = new SynCommon().GenerateTemplate(strSMSTemp, sMSTemplate);
        //    sm.SMSUnit = sm.SMS.Length.ToString();
        //    return sm;
        //}

        //public class FinalSMS
        //{
        //    public string ApplicationID { get; set; }
        //    public string CandidateName { get; set; }
        //    public string MobileNo { get; set; }
        //    public string SMS { get; set; }
        //    public string SMSUnit { get; set; }
        //}


        public class dbUtility
        {
            public DataSet GetStatus(int InstituteID, int UserTypeID, int ReportType)
            {
                DBConnection db = new DBConnection();
                try
                {
                    SqlParameter[] param =
                   {
                    new SqlParameter("@InstituteID",SqlDbType.Int),
                     new SqlParameter("@UserTypeID",SqlDbType.Int),
                      new SqlParameter("@ChoiceCodeType",SqlDbType.Int)
                };

                    param[0].Value = InstituteID;
                    param[1].Value = UserTypeID;
                    param[2].Value = ReportType;

                    return db.ExecuteDataSet("MHDTE_spGetIntitutewiseAllotemetListCapRound1", param);
                }
                finally
                {
                    db.Dispose();
                }

            }
        }


    }
}