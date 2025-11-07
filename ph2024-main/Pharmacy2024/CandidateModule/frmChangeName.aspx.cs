using BusinessLayer;
using EntityModel;
using Pharmacy2024;
using Synthesys.Controls;
using SynthesysDAL;
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
    public partial class frmChangeName : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string MHTCETName = Global.MHTCETName;
        public string AdmissionYear = Global.AdmissionYear;
        public string CurrentYear = Global.CurrentYear;

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

                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    RegistrationDetails obj = reg.getRegistrationDetails(objSessionData.PID);

                    lblOldCandidateName.Text = obj.CandidateName;
                    DateTime bday = obj.DOB;
                    lblDOB.Text = bday.ToString("dd MMM yyyy");

                    DBConnection db = new DBConnection();
                    DataSet ds = db.ExecuteDataSet("sp_GetCandidateNameChangeRequestDetails", new SqlParameter[]
                    {
                    new SqlParameter("@PersonalID", objSessionData.PID)
                    });
                    db.Dispose();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["ApprovedStatus"]) == 1)
                        {
                            shInfo.SetMessage("Your Request for Correction in Name is Already Approved !", ShowMessageType.Information);
                            trHSCName.Visible = false;
                            trNewCandidateName.Visible = true;
                            lblNewCandidateName.Text = ds.Tables[0].Rows[0]["NewCandidateName"].ToString();
                            trCandidateName.Visible = false;
                            btnSubmite.Visible = false;
                        }
                        else
                        {
                            shInfo.SetMessage("Your Request for Correction in Name is yet to Approve !", ShowMessageType.Information);
                            rbnNameOnHSCYes.Checked = true;
                            trHSCName.Visible = true;
                            txtCandidateName.Text = ds.Tables[0].Rows[0]["NewCandidateName"].ToString();
                            trNewCandidateName.Visible = false;
                            trCandidateName.Visible = true;
                            btnSubmite.Visible = true;
                        }
                    }
                    else if (reg.getCETApplicationFormNo(objSessionData.PID) > 0)
                    {

                        trHSCName.Visible = true;
                        trNewCandidateName.Visible = false;
                        trCandidateName.Visible = false;
                        btnSubmite.Visible = false;

                    }
                    else
                    {
                        shInfo.SetMessage("You are not allowed to Edit Name !", ShowMessageType.Information);
                        trHSCName.Visible = false;
                        trNewCandidateName.Visible = false;
                        trCandidateName.Visible = false;
                        btnSubmite.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void NameOnHSC_CheckedChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                if (rbnNameOnHSCYes.Checked)
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];

                    DBConnection dBConnection = new DBConnection();
                    DataSet dsqualification = dBConnection.ExecuteDataSet("MHDTE_spGetQualificationDetails", new SqlParameter[] { new SqlParameter("@PID", objSessionData.PID) });
                    dBConnection.Dispose();

                    if (dsqualification.Tables[0] != null && dsqualification.Tables[0].Rows.Count > 0)
                    {
                        QualificationDetails objQualification = reg.getQualificationDetails(objSessionData.PID);

                        if (objQualification.HSCSeatNo != null || objQualification.HSCSeatNo != "")
                        {
                            if (objQualification.HSCPassingYear == CurrentYear)
                            {
                                trCandidateName.Visible = true;
                                btnSubmite.Visible = true;

                                DBConnection db = new DBConnection();
                                DataSet ds = db.ExecuteDataSet("sp_GetCandidateDetails", new SqlParameter[] { new SqlParameter("@HSCSeatNo", objQualification.HSCSeatNo) });
                                db.Dispose();


                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    txtCandidateName.Text = Convert.ToString(ds.Tables[0].Rows[0]["NAME"]);
                                }
                                else
                                {
                                    txtCandidateName.Text = lblOldCandidateName.Text;
                                }
                            }
                            else
                            {

                                trCandidateName.Visible = true;
                                txtCandidateName.Text = "";
                                btnSubmite.Visible = true;
                            }
                            txtCandidateName.Enabled = true;
                            btnSubmite.Enabled = true;
                        }
                        else
                        {
                            // shInfo.SetMessage("Your name not Found !", ShowMessageType.Information);

                            txtCandidateName.Text = lblOldCandidateName.Text;
                            txtCandidateName.Visible = true;
                            btnSubmite.Visible = true;
                        }
                    }
                    else
                    {
                        shInfo.SetMessage("You have not Fill Your Qualification Details. Please Fill First Qualification Details.", ShowMessageType.Information);
                    }

                }
                else if (rbnNameOnHSCNo.Checked)
                {
                    txtCandidateName.Text = "";
                    txtCandidateName.Enabled = false;
                    btnSubmite.Enabled = false;
                }

            }

            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void btnSubmite_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];
                if (txtCandidateName.Text != "")
                {
                    if (lblOldCandidateName.Text == txtCandidateName.Text)
                    {
                        shInfo.SetMessage("New Name should be different from " + lblOldCandidateName.Text + ".", ShowMessageType.Information);
                    }
                    else
                    {
                        DBConnection db = new DBConnection();
                        db.ExecuteNonQuery("sp_ChangeCandidateNameRequest", new SqlParameter[]
                    {
                    new SqlParameter("@PersonalID", objSessionData.PID),
                    new SqlParameter("@OldCandidateName", lblOldCandidateName.Text),
                    new SqlParameter("@NewCandidateName", txtCandidateName.Text),
                    new SqlParameter("@CreatedBy", lblOldCandidateName.Text),
                    new SqlParameter("@CreatedByIPAddress", UserInfo.GetIPAddress()),
                    new SqlParameter("@ModifiedBy", lblOldCandidateName.Text),
                    new SqlParameter("@ModifiedByIPAddress", UserInfo.GetIPAddress())
                    });
                        db.Dispose();

                        shInfo.SetMessage("Your Correction in Name Request has been Sent for Approval. Please Contact to Nearest SC.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("Please Enter New Candidate Name.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}