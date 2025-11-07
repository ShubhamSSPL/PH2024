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
    public partial class frmInstituteWiseAllotmentList : System.Web.UI.Page
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
                    db.SaveLogView(Session["UserLoginID"].ToString());

                    if (Session["UserTypeID"].ToString() == "43")
                    {

                        gvInstituteList.DataSource = db.GetStatus(Convert.ToInt32(Session["UserLoginID"]), 43);
                        gvInstituteList.DataBind();

                        if (Global.DisplayMockAllotmentForCAPRound == 0)
                        {
                            ctVerification.Visible = false;
                            shInfo.SetMessage("The draft allotment has not been published. ", ShowMessageType.Information);
                        }
                        else 
                        { 
                            ds = db.getDraftAllotmentVerificcationStatisByInstituteID(Convert.ToInt32(Session["UserLoginID"]), Global.DisplayMockAllotmentForCAPRound);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                shInfo.SetMessage("You have already given Feedback/Verification on Draft Allotment of CAP Round " + Global.DisplayMockAllotmentForCAPRound.ToString() + ".", ShowMessageType.Information);
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
                    else if (Session["UserTypeID"].ToString() == "21")
                    {
                        gvInstituteList.DataSource = db.GetStatus(0, 21);
                        gvInstituteList.DataBind();
                    }
                    else if (Session["UserTypeID"].ToString() == "22")
                    {
                        gvInstituteList.DataSource = db.GetStatus(SynCommon.GetRoRegionId(Session["UserLoginID"].ToString()), 22);
                        gvInstituteList.DataBind();
                    }
                    // string[] CapRoundNotInCapRound1 = new string[] { "6907" };
                    for (Int32 m = 1; m <= gvInstituteList.Rows.Count; m++)
                    {
                        gvInstituteList.Rows[m - 1].Cells[0].Text = m.ToString() + ".";
                        //foreach (var bale in CapRoundNotInCapRound1)
                        //{
                        //    if (bale.Contains(gvInstituteList.Rows[m - 1].Cells[1].Text))
                        //        gvInstituteList.Rows[m - 1].Cells[3].Text = "";
                        //}
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
                DataSet ds = db.saveDraftAllotmentVerificationStatus(Convert.ToInt32(Session["UserLoginID"]), rbLstRequest.SelectedValue.ToString(), txtComments.Text.ToString(), Global.DisplayMockAllotmentForCAPRound, "Y", Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    shInfo.SetMessage("Your Feedback/Verification Status for CAP Round " + Global.DisplayMockAllotmentForCAPRound.ToString() + " saved Successfully. ", ShowMessageType.Information);
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
            public DataSet GetStatus(int InstituteID, int UserTypeID)
            {
                DBConnection db = new DBConnection();
                try
                {
                    SqlParameter[] param =
                   {
                    new SqlParameter("@InstituteID",SqlDbType.Int),
                     new SqlParameter("@UserTypeID",SqlDbType.Int),
                     // new SqlParameter("@ChoiceCodeType",SqlDbType.Int)
                };

                    param[0].Value = InstituteID;
                    param[1].Value = UserTypeID;


                    return db.ExecuteDataSet("MHDTE_spGetInstituteListForAllotmentDisplayMock", param);
                }
                finally
                {
                    db.Dispose();
                }

            }
            public void SaveLogView(string UserLoginID)
            {
                DBConnection db = new DBConnection();
                try
                {
                    SqlParameter[] param =
                   {
                    new SqlParameter("@UserLoginID",SqlDbType.VarChar),
                     new SqlParameter("@Activity",SqlDbType.VarChar),
                     // new SqlParameter("@ChoiceCodeType",SqlDbType.Int)
                };

                    param[0].Value = UserLoginID;
                    param[1].Value = "Draft Allotment";
                    db.ExecuteNonQuery("MHDTE_spSaveLog_ViewActivity", param);
                }
                finally
                {
                    db.Dispose();
                }

            }
            public DataSet saveDraftAllotmentVerificationStatus(int InstituteID, string VerificationStatus, string Remark, int DisplayMockAllotmentForCAPRound, string IsActive, string ModifiedBy, string ModifiedByIPAddress)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@InstituteID",SqlDbType.Int),
                    new SqlParameter("@VerificationStatus",SqlDbType.VarChar),
                    new SqlParameter("@Remark",SqlDbType.VarChar),
                    new SqlParameter("@DisplayMockAllotmentForCAPRound",SqlDbType.Int),
                    new SqlParameter("@IsActive",SqlDbType.VarChar),
                    new SqlParameter("@ModifiedBy",SqlDbType.VarChar),
                    new SqlParameter("@ModifiedByIPAddress",SqlDbType.VarChar)
                };

                param[0].Value = InstituteID;
                param[1].Value = VerificationStatus;
                param[2].Value = Remark;
                param[3].Value = DisplayMockAllotmentForCAPRound;
                param[4].Value = IsActive;
                param[5].Value = ModifiedBy;
                param[6].Value = ModifiedByIPAddress;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spSaveDraftAllotmentVerificationStatus", param);

                }
                finally
                {
                    db.Dispose();
                }
            }

            public DataSet getDraftAllotmentVerificcationStatisByInstituteID(int InstituteID, int DisplayMockAllotmentForCAPRound)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@InstituteID",SqlDbType.Int),
                    new SqlParameter("@DisplayMockAllotmentForCAPRound",SqlDbType.Int),
                };

                param[0].Value = InstituteID;
                param[1].Value = DisplayMockAllotmentForCAPRound;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetDraftAllotmentVerificcationStatusByInstituteID", param);

                }
                finally
                {
                    db.Dispose();
                }
            }
        }

        protected void gvInstituteList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton btnCap1 = (ImageButton)e.Row.FindControl("btnCap1");
            ImageButton btnCap2 = (ImageButton)e.Row.FindControl("btnCap2");
            ImageButton btnCap3 = (ImageButton)e.Row.FindControl("btnCap3");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Global.DisplayMockAllotmentForCAPRound == 1)
                {
                    if (btnCap1 != null)
                    {
                        btnCap1.Visible = true;
                    }
                }
                else if (Global.DisplayMockAllotmentForCAPRound == 2)
                {
                    if (btnCap2 != null)
                    {
                        btnCap1.Visible = true;
                        btnCap2.Visible = true;
                    }
                }
                else if (Global.DisplayMockAllotmentForCAPRound == 3)
                {
                    //TemplateField cap3MockField = gvInstituteList.Columns.OfType<TemplateField>().FirstOrDefault(field => field.HeaderText == "CAP-II Mock");
                    //if (cap3MockField != null)
                    //{                        
                    if (btnCap3 != null)
                    {
                        btnCap1.Visible = true;
                        btnCap2.Visible = true;
                        //cap3MockField.Visible = true;
                        btnCap3.Visible = true;
                    }
                    //}
                }
            }
        }
    }
}