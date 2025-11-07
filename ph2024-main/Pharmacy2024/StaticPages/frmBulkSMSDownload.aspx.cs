using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class frmBulkSMSDownload : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
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
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {

                    gvSMSList.Visible = false;
                    //dbUtility db = new dbUtility();

                    //DataSet ds = db.GetStatus();
                    //int count = ds.Tables[0].Rows.Count;
                    //foreach (DataRow dr in ds.Tables[0].Rows)
                    //{
                    //    dr["MobileNo"] = DataEncryption.DecryptDataByEncryptionKey(dr["MobileNo"].ToString());
                    //    count--;
                    //}

                    //StringWriter sw = new StringWriter();
                    //HtmlTextWriter hw = new HtmlTextWriter(sw);
                    //GridView gvReport = new GridView();
                    //gvReport.DataSource = ds;
                    //gvReport.DataBind();

                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.AddHeader("content-disposition", "attachment;filename=fe.xls");
                    //Response.Charset = "";
                    //Response.ContentType = "application/vnd.ms-excel";
                    //gvReport.RenderControl(hw);
                    //Response.Output.Write(sw.ToString());
                    //Response.Flush();
                    //Response.End();

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

        protected void ddlSMSType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                dbUtility db = new dbUtility();

                
                string smstype = ddlSMSType.SelectedValue.ToString();
                DataSet ds = db.GetStatus(smstype);
                //string strSMSTemp = reg.getEmailSMSTemplateBySystemName(smstype);

                DataSet dsSMSTemplate = reg.getEmailSMSTemplateBySystemName(smstype);
                string strSMSTemp = dsSMSTemplate.Tables[0].Rows[0]["Template"].ToString();
                string strTemplateID = dsSMSTemplate.Tables[0].Rows[0]["TemplateID"].ToString();

                List<FinalSMS> lstFinalSMS = new List<FinalSMS>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ParallelLoopResult result = Parallel.ForEach(ds.Tables[0].Rows.Cast<DataRow>(), item =>
                    {
                        FinalSMS sm = CreateSmsTemplate(item, strSMSTemp);
                        if(sm.MobileNo != "")
                        lstFinalSMS.Add(sm);
                    });
                }
                gvSMSList.DataSource = lstFinalSMS;
                gvSMSList.DataBind();
                gvSMSList.Visible = true;
            }
            catch (Exception ex)
            {

            }
        }
        private FinalSMS CreateSmsTemplate(DataRow dr, string strSMSTemp)
        {
            try
            {
                FinalSMS sm = new FinalSMS();
                SMSTemplate sMSTemplate = new SMSTemplate();
                sMSTemplate.ProjectName = Global.ProjectNameSMS;
                if (dr["CandidateName"] != null)
                    sMSTemplate.CandidateName = dr["CandidateName"].ToString();
                if (dr["MobileNo"] != null)
                {
                    sm.MobileNo = DataEncryption.DecryptDataByEncryptionKey(dr["MobileNo"].ToString());
                }
                if (dr["ApplicationID"] != null)
                    sMSTemplate.ApplicationID = dr["ApplicationID"].ToString();
                sm.ApplicationID = sMSTemplate.ApplicationID;
                sm.CandidateName = sMSTemplate.CandidateName;
                if (ddlSMSType.SelectedValue.ToString() == "CVCNCLEWSAdmissionCancelled")
                    sm.ChoiceCodeAllotted = dr["ChoiceCodeDisplay"].ToString();
                if (ddlSMSType.SelectedValue.ToString() == "CVCNCLEWSPending")
                {
                    sm.AdmissionCategory = new dbUtility().GetAdmissionCategory(Convert.ToInt64(dr["PersonalID"].ToString()));
                    sMSTemplate.ConversionStatus = sm.AdmissionCategory;
                }
                if (ddlSMSType.SelectedValue.ToString() == "SEBC_CVC_6MonthLastDate")
                {
                    if (dr["LastDateofSubmission"] != null)
                        sMSTemplate.LastDateofSubmission = dr["LastDateofSubmission"].ToString();
                }
                sm.SMS = new SynCommon().GenerateTemplate(strSMSTemp, sMSTemplate);
                sm.SMSUnit = sm.SMS.Length.ToString();
                if (dr["EMailID"] != null)
                {
                    sm.EMailID = dr["EMailID"].ToString();
                }
                if (ddlSMSType.SelectedValue.ToString() == "CVCNCLEWSPending")
                {
                    if (sm.AdmissionCategory.Contains("$") || sm.AdmissionCategory.Contains("#") || sm.AdmissionCategory.Contains("@"))
                        return sm;
                    else
                    {
                        sm.ApplicationID = "";
                        return sm;
                    }
                }
                else
                    return sm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class FinalSMS
        {
            public string ApplicationID { get; set; }
            public string CandidateName { get; set; }
            public string MobileNo { get; set; }
            public string SMS { get; set; }
            public string SMSUnit { get; set; }
            public string AdmissionCategory { get; set; }
            public string ChoiceCodeAllotted { get; set; }
            public string EMailID { get; set; }
        }


        public class dbUtility
        {
            public DataSet GetStatus(string smstype)
            {
                DBConnection db = new DBConnection();
                try
                {
                    SqlParameter[] param =
                   {
                    new SqlParameter("@SystemName",SqlDbType.VarChar),
                };

                    param[0].Value = smstype;
                    
                    return db.ExecuteDataSet("MHDTE_spGetDataForSMSReminderbyTemplate", param );
                }
                finally
                {
                    db.Dispose();
                }

            }
            public string GetAdmissionCategory(Int64 PID)
            {
                DBConnection db = new DBConnection();
                try
                {
                    SqlParameter[] param =
                   {
                    new SqlParameter("@PID",SqlDbType.Int),
                };

                    param[0].Value = PID;

                    return db.ExecuteScaler("MHDTE_spGetAdmissionCategory", param).ToString();
                }
                finally
                {
                    db.Dispose();
                }

            }
        }


    }
}