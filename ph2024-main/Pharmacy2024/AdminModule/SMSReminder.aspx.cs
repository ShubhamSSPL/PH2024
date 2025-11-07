using BusinessLayer;
using EntityModel;
using RestSharp;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AdminModule
{
    public partial class SMSReminder : System.Web.UI.Page
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
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) != 21)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }

            if (!IsPostBack)
            {
                TemplateDataBind();
                trTemplateradiobtn.Visible = false;
                trUpdateTemplate.Visible = false;
                btnSendSMS.Visible = false;
            }
        }

        public void TemplateDataBind()
        {
            DataSet ds = reg.getAllSMSEmailTemplates();
            DataView dataView = ds.Tables[0].DefaultView;
            dataView.RowFilter = "TemplateFor  = 'R'";
            ddlsmsTemplate.Items.Clear();
            ddlsmsTemplate.DataSource = dataView;
            ddlsmsTemplate.DataTextField = "Name";
            ddlsmsTemplate.DataValueField = "SystemName";
            ddlsmsTemplate.DataBind();
            ddlsmsTemplate.Items.Insert(0, new ListItem("-- Select Template --", "0"));
        }
        protected void btnUpdateTemplate_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (reg.updateSMSEmailTemplates(txttemplate.Text, ddlsmsTemplate.SelectedValue, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
            {
                btnSendSMS.Visible = true;
                btnUpdateTemplate.Visible = false;
            }
            else
            {
                shInfo.SetMessage("SMS Template Update!", ShowMessageType.Information);
            }
        }

        protected async void btnSendSMS_Click(object sender, EventArgs e)
        {
            string template = ddlsmsTemplate.SelectedValue;
            if (new DBUtilityCheckActivity().CheckActivity(template))
            {
                SynCommon synCommon = new SynCommon();
                DataSet ds = reg.getDataForReminderSMS(template);
                //List<SMSTemplate> lstsMSTemplate = new List<SMSTemplate>();
                Msg91 msg91 = new Msg91();
                List<Sm> Sms = new List<Sm>();
                if (ds.Tables.Count > 0)
                {
                    //string strSMSTemp = reg.getEmailSMSTemplateBySystemName(template);

                    DataSet dsSMSTemplate = reg.getEmailSMSTemplateBySystemName(template);
                    string strSMSTemp = dsSMSTemplate.Tables[0].Rows[0]["Template"].ToString();
                    string strTemplateID = dsSMSTemplate.Tables[0].Rows[0]["TemplateID"].ToString();

                    //ParallelLoopResult parallelLoopResult = Parallel.ForEach(ds.Tables[0].Rows, dr => CreateSmsTemplate(dr, strSMSTemp));
                    //Sms.Add(parallelLoopResult);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ParallelLoopResult result = Parallel.ForEach(ds.Tables[0].Rows.Cast<DataRow>(), item =>
                        {
                            Sm sm = CreateSmsTemplate(item, strSMSTemp);
                            Sms.Add(sm);
                        });
                    }
                    //foreach (DataRow dr in ds.Tables[0].Rows)
                    //{
                    //    Sm sm = new Sm();
                    //    SMSTemplate sMSTemplate = new SMSTemplate();
                    //    sMSTemplate.ProjectName = Global.ProjectNameSMS;
                    //    if (dr["CandidateName"] != null)
                    //        sMSTemplate.CandidateName = dr["CandidateName"].ToString();
                    //    if (dr["MobileNo"] != null)
                    //    {
                    //        List<string> To = new List<string>();
                    //        To.Add(DataEncryption.DecryptDataByEncryptionKey(dr["MobileNo"].ToString()));
                    //        sm.To = To;
                    //    }
                    //    if (dr["ApplicationID"] != null)
                    //        sMSTemplate.ApplicationID = dr["ApplicationID"].ToString();
                    //    sm.Message = synCommon.GenerateTemplate(strSMSTemp, sMSTemplate);
                    //    if (dr["PersonalID"] != null)
                    //        sm.PersonalID = dr["PersonalID"].ToString();
                    //    Sms.Add(sm);
                    //}
                    msg91.Sms = Sms;
                }
                if (msg91.Sms.Count > 0)
                {
                    ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                    SMS sMS = new SMS();
                    string response = await sMS.SendBulkSMS(msg91, template);
                    if (response.Length > 0)
                    {
                        shInfo.SetMessage("You SMS for " + ddlsmsTemplate.SelectedItem.Text + " Total SMS " + msg91.Sms.Count + " sent sucessfully", ShowMessageType.Information);
                    }
                    else
                    {
                        shInfo.SetMessage("You SMS for " + ddlsmsTemplate.SelectedItem.Text + " with error ", ShowMessageType.UserError);
                    }
                }
            }
            else
            {
                ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                shInfo.SetMessage("You are trying to send SMS for " + ddlsmsTemplate.SelectedItem.Text + " is not Active. Contact to Admin!", ShowMessageType.Information);
            }
        }

        private Sm CreateSmsTemplate(DataRow dr, string strSMSTemp)
        {
             Sm sm = new Sm();
           
            try
            {
                SMSTemplate sMSTemplate = new SMSTemplate();
                sMSTemplate.ProjectName = Global.ProjectNameSMS;
                if (dr["CandidateName"] != null)
                    sMSTemplate.CandidateName = dr["CandidateName"].ToString();
                if (dr["MobileNo"] != null)
                {
                    List<string> To = new List<string>();
                    To.Add(DataEncryption.DecryptDataByEncryptionKey(dr["MobileNo"].ToString()));
                    sm.To = To;
                }
                if (dr["ApplicationID"] != null)
                    sMSTemplate.ApplicationID = dr["ApplicationID"].ToString();
                sm.Message = new SynCommon().GenerateTemplate(strSMSTemp, sMSTemplate);
                if (dr["PersonalID"] != null)
                    sm.PersonalID = dr["PersonalID"].ToString();
            }
            catch (Exception ex) { }
            return sm;
        }
        protected void ddlsmsTemplate_SelectedIndexChange(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (ddlsmsTemplate.SelectedValue == "")
            {
                shInfo.SetMessage("Select template!", ShowMessageType.Information);
            }
            else
            {
                //string template = reg.getEmailSMSTemplateBySystemName(ddlsmsTemplate.SelectedValue);

                DataSet dsSMSTemplate = reg.getEmailSMSTemplateBySystemName(ddlsmsTemplate.SelectedValue);
                string strSMSTemp = dsSMSTemplate.Tables[0].Rows[0]["Template"].ToString();
                string strTemplateID = dsSMSTemplate.Tables[0].Rows[0]["TemplateID"].ToString();

                if (strSMSTemp.Length > 0)
                {
                    txttemplate.Text = strSMSTemp;
                    trTemplateradiobtn.Visible = true;
                    btnSendSMS.Visible = true;
                }
                else
                    shInfo.SetMessage("SMS Template Not Found !", ShowMessageType.Information);
            }
        }

        protected void TemplateEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnrbnTemplateEditYes.Checked)
            {
                txttemplate.Enabled = true;
                trUpdateTemplate.Visible = true;
                tdTemplateFields.Visible = true;
                btnSendSMS.Visible = false;
                dltemplatekey.DataSource = reg.getGetMaster_TemplateFields();
                dltemplatekey.DataBind();
            }
            else
            {
                txttemplate.Enabled = false;
                trUpdateTemplate.Visible = false;
                tdTemplateFields.Visible = false;
            }
        }

        public bool CheckActivity(string template)
        {
            bool result = false;
            switch (template)
            {
                case "AFLDR":
                    if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime)
                        result = true;
                    break;
                case "MeritListDisplay":
                    result = true;
                    break;
                case "OFormCAPRound1":
                    if (DateTime.Now < Global.OptionFormFillingCAPRound1StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound1EndDateTime)
                        result = true;
                    break;
                case "OFormCAPRound2":
                    if (DateTime.Now < Global.OptionFormFillingCAPRound2StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound2EndDateTime)
                        result = true;
                    break;
                case "OFormCAPRound3":
                    if (DateTime.Now < Global.OptionFormFillingCAPRound3StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound3EndDateTime)
                        result = true;
                    break;
                case "OFormCAPRound4":
                    if (DateTime.Now < Global.OptionFormFillingCAPRound4StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound4EndDateTime)
                        result = true;
                    break;
                case "OFormCAPRound1LastDate":
                    if (DateTime.Now < Global.OptionFormFillingCAPRound1StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound1EndDateTime)
                        result = true;
                    break;
                case "OFormCAPRound2LastDate":
                    if (DateTime.Now < Global.OptionFormFillingCAPRound2StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound2EndDateTime)
                        result = true;
                    break;
                case "OFormCAPRound3LastDate":
                    if (DateTime.Now < Global.OptionFormFillingCAPRound3StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound3EndDateTime)
                        result = true;
                    break;
                case "OFormCAPRound4LastDate":
                    if (DateTime.Now < Global.OptionFormFillingCAPRound4StartDateTime || DateTime.Now > Global.OptionFormFillingCAPRound4EndDateTime)
                        result = true;
                    break;
                case "ARCReportingCAPRound1":
                    if (DateTime.Now < Global.ARCReportingCAPRound1StartDateTime || DateTime.Now > Global.ARCReportingCAPRound1EndDateTime)
                        result = true;
                    break;
                case "ARCReportingCAPRound2":
                    if (DateTime.Now < Global.ARCReportingCAPRound2StartDateTime || DateTime.Now > Global.ARCReportingCAPRound2EndDateTime)
                        result = true;
                    break;
                case "ARCReportingCAPRound3":
                    if (DateTime.Now < Global.ARCReportingCAPRound3StartDateTime || DateTime.Now > Global.ARCReportingCAPRound3EndDateTime)
                        result = true;
                    break;
                case "ARCReportingCAPRound4":
                    if (DateTime.Now < Global.ARCReportingCAPRound4StartDateTime || DateTime.Now > Global.ARCReportingCAPRound4EndDateTime)
                        result = true;
                    break;
                case "ARCReportingCAPRound1LastDate":
                    if (DateTime.Now < Global.ARCReportingCAPRound1StartDateTime || DateTime.Now > Global.ARCReportingCAPRound1EndDateTime)
                        result = true;
                    break;
                case "ARCReportingCAPRound2LastDate":
                    if (DateTime.Now < Global.ARCReportingCAPRound2StartDateTime || DateTime.Now > Global.ARCReportingCAPRound2EndDateTime)
                        result = true;
                    break;
                case "ARCReportingCAPRound3LastDate":
                    if (DateTime.Now < Global.ARCReportingCAPRound3StartDateTime || DateTime.Now > Global.ARCReportingCAPRound3EndDateTime)
                        result = true;
                    break;
                case "ARCReportingCAPRound4LastDate":
                    if (DateTime.Now < Global.ARCReportingCAPRound4StartDateTime || DateTime.Now > Global.ARCReportingCAPRound4EndDateTime)
                        result = true;
                    break;
                case "ProvisionalAllotmentDisplayCAPRound1":
                    if (DateTime.Now < Global.ProvisionalAllotmentDisplayCAPRound1StartDateTime || DateTime.Now > Global.ProvisionalAllotmentDisplayCAPRound1EndDateTime)
                        result = true;
                    break;
                case "ProvisionalAllotmentDisplayCAPRound2":
                    if (DateTime.Now < Global.ProvisionalAllotmentDisplayCAPRound2StartDateTime || DateTime.Now > Global.ProvisionalAllotmentDisplayCAPRound2EndDateTime)
                        result = true;
                    break;
                case "ProvisionalAllotmentDisplayCAPRound3":
                    if (DateTime.Now < Global.ProvisionalAllotmentDisplayCAPRound3StartDateTime || DateTime.Now > Global.ProvisionalAllotmentDisplayCAPRound3EndDateTime)
                        result = true;
                    break;
                case "ProvisionalAllotmentDisplayCAPRound4":
                    if (DateTime.Now < Global.ProvisionalAllotmentDisplayCAPRound4StartDateTime || DateTime.Now > Global.ProvisionalAllotmentDisplayCAPRound4EndDateTime)
                        result = true;
                    break;
                case "InstituteCAPReportingForRound1":
                    if (DateTime.Now < Global.InstituteCAPReportingStartDateTime || DateTime.Now > Global.InstituteCAPReportingEndDateTime)
                        result = true;
                    break;
                case "InstituteCAPReportingForRound2":
                    if (DateTime.Now < Global.InstituteCAPReportingStartDateTime || DateTime.Now > Global.InstituteCAPReportingEndDateTime)
                        result = true;
                    break;
                case "InstituteCAPReportingForRound3":
                    if (DateTime.Now < Global.InstituteCAPReportingStartDateTime || DateTime.Now > Global.InstituteCAPReportingEndDateTime)
                        result = true;
                    break;
                case "InstituteCAPReportingForRound4":
                    if (DateTime.Now < Global.InstituteCAPReportingStartDateTime || DateTime.Now > Global.InstituteCAPReportingEndDateTime)
                        result = true;
                    break;
                case "InstituteCAPReportingForRound1LastDate":
                    if (DateTime.Now < Global.InstituteCAPReportingStartDateTime || DateTime.Now > Global.InstituteCAPReportingEndDateTime)
                        result = true;
                    break;
                case "InstituteCAPReportingForRound2LastDate":
                    if (DateTime.Now < Global.InstituteCAPReportingStartDateTime || DateTime.Now > Global.InstituteCAPReportingEndDateTime)
                        result = true;
                    break;
                case "InstituteCAPReportingForRound3LastDate":
                    if (DateTime.Now < Global.InstituteCAPReportingStartDateTime || DateTime.Now > Global.InstituteCAPReportingEndDateTime)
                        result = true;
                    break;
                case "InstituteCAPReportingForRound4LastDate":
                    if (DateTime.Now < Global.InstituteCAPReportingStartDateTime || DateTime.Now > Global.InstituteCAPReportingEndDateTime)
                        result = true;
                    break;
                case "JandKCAPRound":
                    result = true;
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }

        public class DBUtilityCheckActivity
        {
            public bool CheckActivity(string template)
            {

                DBConnection db = new DBConnection();
                try
                {
                    int res = Convert.ToInt16(db.ExecuteScaler("MHDTE_spCheckSMSTemplate", new SqlParameter[]
                      {
                    new SqlParameter("@Template",template)
                      }));

                    if (res > 0)
                        return true;
                    else
                        return false;
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}