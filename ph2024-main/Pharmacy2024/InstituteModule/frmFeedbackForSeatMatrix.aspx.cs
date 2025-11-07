using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using Synthesys.Controls;
using System.Data;
using System.Data.SqlClient;
using Synthesys.DataAcess;
using EntityModel;
using System.Configuration;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmFeedbackForSeatMatrix : System.Web.UI.Page
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
                    dbUtility db = new dbUtility();
                    DataSet ds;
                    if (Session["UserTypeID"].ToString() == "43")
                    {
                      

                        ds = db.getSeatMatrixVerificcationStatisByInstituteID(Convert.ToInt32(Session["UserLoginID"]), Global.CAPRound);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //shInfo.SetMessage("You have already given Feedback/Verification on Draft Allotment of CAP Round " + Global.CAPRound.ToString() + ".", ShowMessageType.Information);
                            shInfo.SetMessage("You have already given Feedback/Verification Status on Seat Matrix.", ShowMessageType.Information);
                            rbLstRequest.SelectedValue = ds.Tables[0].Rows[0]["VerificationStatus"].ToString();
                            rbLstRequest.Enabled = false;
                            txtComments.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                            txtComments.Enabled = false;
                            btnProceed.Visible = false;
                        }
                        else
                        {
                            rbLstRequest.Enabled = true;
                            txtComments.Enabled = true;
                            btnProceed.Visible = true;
                        }
                    }                 
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                dbUtility db = new dbUtility();
                DataSet ds = db.saveSeatMatrixVerificationStatus(Convert.ToInt32(Session["UserLoginID"]), rbLstRequest.SelectedValue.ToString(), txtComments.Text.ToString(), 1 ,  "Y", Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //shInfo.SetMessage("Your Feedback/Verification Status for CAP Round " + Global.CAPRound.ToString() + "saved Successfully.", ShowMessageType.Information);
                    shInfo.SetMessage("Your Feedback/Verification Status of Seat Matrix is saved Successfully.", ShowMessageType.Information);
                    rbLstRequest.Enabled = false;
                    txtComments.Enabled = false;
                    btnProceed.Visible = false;
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                    shInfo.Focus();
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        public class dbUtility
        {
            
            public DataSet saveSeatMatrixVerificationStatus(int InstituteID, string VerificationStatus, string Remark, int CAPRound, string IsActive, string ModifiedBy, string ModifiedByIPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@InstituteID",SqlDbType.Int),
                    new SqlParameter("@VerificationStatus",SqlDbType.VarChar),
                    new SqlParameter("@Remark",SqlDbType.VarChar),
                    new SqlParameter("@CAPRound",SqlDbType.Int),
                    new SqlParameter("@IsActive",SqlDbType.VarChar),
                    new SqlParameter("@ModifiedBy",SqlDbType.VarChar),
                    new SqlParameter("@ModifiedByIPAddress",SqlDbType.VarChar)
                };

                param[0].Value = InstituteID;
                param[1].Value = VerificationStatus;
                param[2].Value = Remark;
                param[3].Value = CAPRound;
                param[4].Value = IsActive;
                param[5].Value = ModifiedBy;
                param[6].Value = ModifiedByIPAddress;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spSaveSeatMatrixVerificationStatus", param);

                }
                finally
                {
                    db.Dispose();
                }
            }

            public DataSet getSeatMatrixVerificcationStatisByInstituteID(int InstituteID, int CAPRound)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@InstituteID",SqlDbType.Int),
                    new SqlParameter("@CAPRound",SqlDbType.Int),
                };

                param[0].Value = InstituteID;
                param[1].Value = CAPRound;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetSeatMatrixVerificcationStatusByInstituteID", param);

                }
                finally
                {
                    db.Dispose();
                }
            }


        }
    }
}