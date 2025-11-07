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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class CandidateSmsSent : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
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
            if (!IsPostBack)
            {
                String SMSType = (Request.QueryString["SMSType"].ToString());

                if (SMSType == "S")
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    LoadSMSDetails(objSessionData.PID);
                }
                else if (SMSType == "W")
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    LoadWhatupMessageDetails(objSessionData.PID);
                }
                else if (SMSType == "E")
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    LoadEmailSendDetails(objSessionData.PID);
                }
                else
                {
                    Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx");
                }

            }
        }
        protected void LoadSMSDetails(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            DataSet ds = null;
            try
            {
                string acvtiveBackColor = "#b77b52";
                string InacvtiveBackColor = "#8e9fb1";

                //lkgvSentSMS.BackColor = System.Drawing.Color.Blue;
                lkgvSentSMS.BackColor = System.Drawing.ColorTranslator.FromHtml(acvtiveBackColor);
                lkgvSendWhatsUpSMS.BackColor = System.Drawing.ColorTranslator.FromHtml(InacvtiveBackColor);
                lkgvSendEmail.BackColor = System.Drawing.ColorTranslator.FromHtml(InacvtiveBackColor);
                ContentTable2.HeaderText = "SMS Sent to Candidate";
                ds = new dbUtility().GetAllSMSDetails(PID);

                DataTable dt = ds.Tables[0];
                DataTable dtMsg = null;
                DataSet dsMobileNo = new dbUtility().GetMobileNOFromBackup(PID);
                if (dsMobileNo != null && dsMobileNo.Tables.Count > 0)
                {
                    if (dsMobileNo.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsMobileNo.Tables[0].Rows)
                        {
                            dtMsg = new dbUtility().GetAllReminderSMSDetails(DataEncryption.DecryptDataByEncryptionKey(dr["MobileNo"].ToString())).Tables[0];

                            if (dtMsg.Rows.Count > 0)
                            {
                                dt.Merge(dtMsg);
                            }
                        }
                    }
                }



                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataView dv = dt.DefaultView;
                        dv.Sort = "SentDateTime DESC";

                        gvSentSMS.DataSource = dv;
                        gvSentSMS.DataBind();
                        for (Int32 i = 0; i < gvSentSMS.Rows.Count; i++)
                        {
                            if (gvSentSMS.Rows[i].Cells[4].Text == "O")
                            {
                                gvSentSMS.Rows[i].Cells[4].Text = "OTP Message";
                                gvSentSMS.Rows[i].Cells[1].Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(gvSentSMS.Rows[i].Cells[1].Text));
                            }
                            else if (gvSentSMS.Rows[i].Cells[4].Text == "N")
                            {
                                gvSentSMS.Rows[i].Cells[4].Text = "Normal Message";
                                gvSentSMS.Rows[i].Cells[1].Text = DataEncryption.MaskMobileNo(DataEncryption.DecryptDataByEncryptionKey(gvSentSMS.Rows[i].Cells[1].Text));
                            }
                            else if (gvSentSMS.Rows[i].Cells[4].Text == "R")
                            {
                                gvSentSMS.Rows[i].Cells[4].Text = "Reminder Message";
                                gvSentSMS.Rows[i].Cells[1].Text = DataEncryption.MaskMobileNo(gvSentSMS.Rows[i].Cells[1].Text);
                            }

                            gvSentSMS.Rows[i].Cells[3].Text = (Convert.ToDateTime(gvSentSMS.Rows[i].Cells[3].Text).ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", Convert.ToDateTime(gvSentSMS.Rows[i].Cells[3].Text))).ToString();
                        }
                    }
                }
                else
                {
                    shInfo.SetMessage("No Data Found!!!", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError);
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
        }
        protected void LoadWhatupMessageDetails(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            DataSet ds = null;
            try
            {
                string acvtiveBackColor = "#b77b52";
                string InacvtiveBackColor = "#8e9fb1";

                lkgvSentSMS.BackColor = System.Drawing.ColorTranslator.FromHtml(InacvtiveBackColor);
                lkgvSendWhatsUpSMS.BackColor = System.Drawing.ColorTranslator.FromHtml(acvtiveBackColor);
                lkgvSendEmail.BackColor = System.Drawing.ColorTranslator.FromHtml(InacvtiveBackColor);

                ContentTable2.HeaderText = "WhatsApp Messege Sent to Candidate";
                ds = new dbUtility().GetAllWhatsupMessageDetails(PID);

                DataTable dt = ds.Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataView dv = dt.DefaultView;
                        dv.Sort = "SentDateTime DESC";

                        gvSendWhatsUpSMS.DataSource = dv;
                        gvSendWhatsUpSMS.DataBind();
                        for (Int32 i = 0; i < gvSendWhatsUpSMS.Rows.Count; i++)
                        {
                            if (gvSendWhatsUpSMS.Rows[i].Cells[4].Text == "O")
                            {
                                gvSendWhatsUpSMS.Rows[i].Cells[4].Text = "OTP Message";
                                gvSendWhatsUpSMS.Rows[i].Cells[1].Text = DataEncryption.MaskMobileNo(gvSendWhatsUpSMS.Rows[i].Cells[1].Text);
                            }
                            else if (gvSendWhatsUpSMS.Rows[i].Cells[4].Text == "W")
                            {
                                gvSendWhatsUpSMS.Rows[i].Cells[4].Text = "Normal Message";
                                gvSendWhatsUpSMS.Rows[i].Cells[1].Text = DataEncryption.MaskMobileNo(gvSendWhatsUpSMS.Rows[i].Cells[1].Text);
                            }
                            else if (gvSendWhatsUpSMS.Rows[i].Cells[4].Text == "R")
                            {
                                gvSendWhatsUpSMS.Rows[i].Cells[4].Text = "Reminder Message";
                                gvSendWhatsUpSMS.Rows[i].Cells[1].Text = DataEncryption.MaskMobileNo(gvSendWhatsUpSMS.Rows[i].Cells[1].Text);
                            }

                            gvSendWhatsUpSMS.Rows[i].Cells[3].Text = (Convert.ToDateTime(gvSendWhatsUpSMS.Rows[i].Cells[3].Text).ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", Convert.ToDateTime(gvSendWhatsUpSMS.Rows[i].Cells[3].Text))).ToString();
                        }
                    }
                }
                else
                {
                    shInfo.SetMessage("No Data Found!!!", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError);
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
        }
        protected void LoadEmailSendDetails(Int64 PID)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            DataSet ds = null;
            try
            {
                string acvtiveBackColor = "#b77b52";
                string InacvtiveBackColor = "#8e9fb1";

                lkgvSentSMS.BackColor = System.Drawing.ColorTranslator.FromHtml(InacvtiveBackColor);
                lkgvSendWhatsUpSMS.BackColor = System.Drawing.ColorTranslator.FromHtml(InacvtiveBackColor);
                lkgvSendEmail.BackColor = System.Drawing.ColorTranslator.FromHtml(acvtiveBackColor);

                ContentTable2.HeaderText = "Email Sent to Candidate";
                ds = new dbUtility().GetAllSendEmailDetails(PID);

                DataTable dt = ds.Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataView dv = dt.DefaultView;
                        dv.Sort = "SentDateTime DESC";

                        gvSendEmail.DataSource = dv;
                        gvSendEmail.DataBind();
                        for (Int32 i = 0; i < gvSendEmail.Rows.Count; i++)
                        {
                            if (gvSendEmail.Rows[i].Cells[4].Text == "O")
                            {
                                gvSendEmail.Rows[i].Cells[4].Text = "OTP ";

                            }
                            else if (gvSendEmail.Rows[i].Cells[4].Text == "E")
                            {
                                gvSendEmail.Rows[i].Cells[4].Text = "Normal Message";

                            }
                            else if (gvSendEmail.Rows[i].Cells[4].Text == "R")
                            {
                                gvSendEmail.Rows[i].Cells[4].Text = "Reminder Message";

                            }

                            gvSendEmail.Rows[i].Cells[3].Text = (Convert.ToDateTime(gvSendEmail.Rows[i].Cells[3].Text).ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", Convert.ToDateTime(gvSendEmail.Rows[i].Cells[3].Text))).ToString();
                        }
                    }
                }
                else
                {
                    shInfo.SetMessage("No Data Found!!!", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError);
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
        }
        protected void gvSentSMS_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                dvgvSentSMS.Visible = true;
                dvgvSendWhatsUpSMS.Visible = false;
                dvgvSendEmail.Visible = false;
                SessionData objSessionData = (SessionData)Session["SessionData"];
                LoadSMSDetails(objSessionData.PID);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvSendWhatsUpSMS_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                dvgvSentSMS.Visible = false;
                dvgvSendWhatsUpSMS.Visible = true;
                dvgvSendEmail.Visible = false;
                SessionData objSessionData = (SessionData)Session["SessionData"];
                LoadWhatupMessageDetails(objSessionData.PID);

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvSendEmail_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                dvgvSentSMS.Visible = false;
                dvgvSendWhatsUpSMS.Visible = false;
                dvgvSendEmail.Visible = true;
                SessionData objSessionData = (SessionData)Session["SessionData"];
                LoadEmailSendDetails(objSessionData.PID);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        private class dbUtility
        {
            public DataSet GetMobileNOFromBackup(Int64 PID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.VarChar)
                };

                param[0].Value = PID;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetMobileNOFromBackup", param);

                }
                finally
                {
                    db.Dispose();
                }
            }
            public DataSet GetAllSMSDetails(Int64 PID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.VarChar)
                };

                param[0].Value = PID.ToString();
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetAllSMSDetails", param);

                }
                finally
                {
                    db.Dispose();
                }
            }
            public DataSet GetAllReminderSMSDetails(string MobileNo)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@MobileNo", SqlDbType.VarChar)
                };

                param[0].Value = MobileNo.ToString();
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetAllReminderSMSDetails", param);

                }
                finally
                {
                    db.Dispose();
                }
            }
            public DataSet GetAllSMSDetails(Int64 PID, string MobileNo)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.VarChar),
                    new SqlParameter("@MobileNo", SqlDbType.VarChar),
                };

                param[0].Value = PID.ToString();
                param[1].Value = MobileNo.ToString();
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetAllSMSDetails", param);

                }
                finally
                {
                    db.Dispose();
                }
            }
            public DataSet GetAllWhatsupMessageDetails(Int64 PID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.VarChar)
                };

                param[0].Value = PID.ToString();
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetAllWhatsupMessageDetails", param);

                }
                finally
                {
                    db.Dispose();
                }
            }
            public DataSet GetAllSendEmailDetails(Int64 PID)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PID", SqlDbType.VarChar)
                };

                param[0].Value = PID.ToString();
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetAllSendEmailDetails", param);

                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}