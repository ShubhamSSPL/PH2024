using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BusinessLayer;
using System.Data.SqlClient;
using Synthesys.DataAcess;
using System.IO;
using Synthesys.Controls;

namespace Pharmacy2024.InstituteModule
{

    public partial class frmDraftAllotmentVerificationStatusReport : System.Web.UI.Page
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
                    GetData();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void GetData()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
                string UserLoginID = Session["UserLoginID"].ToString();


                Int32 RegionID = SynCommon.GetRoRegionId(Session["UserLoginID"].ToString());

                if (UserTypeID == 21) // Admin
                {
                    trRegion.Visible = true;
                }
                else if (UserTypeID == 22) //RO
                {
                    trRegion.Visible = true;
                    ddlRegion.SelectedValue = RegionID.ToString();
                    ddlRegion.Enabled = false;
                    //RegionID = SynCommon.GetRoRegionId(Session["UserLoginID"].ToString());
                }

                gvCandidateList.DataSource = new GetDraftAllotmentVerificationStatusReport().getDraftAllotmentVerificcationStatusReport(Convert.ToInt32(ddlRegion.SelectedValue.ToString()), ddlVerificationStatus.SelectedValue.ToString(), ddlVerificationDetails.SelectedValue.ToString(), Global.DisplayMockAllotmentForCAPRound);
                gvCandidateList.DataBind();

                for (Int32 i = 0; i < gvCandidateList.Rows.Count; i++)
                {
                    gvCandidateList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                }

                lblPrintedOn.Text = "Printed On : " + DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlVerificationStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlVerificationStatus.SelectedValue == "Y")
                {
                    trVerificationDetails.Visible = true;
                    ddlVerificationDetails.SelectedValue = "0";
                }
                else
                {
                    trVerificationDetails.Visible = false;
                    ddlVerificationDetails.SelectedValue = "0";
                }
                GetData();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlVerificationDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvReport_PreRender(object sender, EventArgs e)
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
    }


    public class GetDraftAllotmentVerificationStatusReport
    {
        public DataSet getDraftAllotmentVerificcationStatusReport(int RegionID, string VerificationStatus, string VerificationDetails, int DisplayMockAllotmentForCAPRound)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@RegionID",SqlDbType.Int),
                new SqlParameter("@VerificationStatus",SqlDbType.VarChar,50),
                new SqlParameter("@VerificationDetails",SqlDbType.VarChar,50),
                new SqlParameter("@DisplayMockAllotmentForCAPRound",SqlDbType.Int),
            };
            parameters[0].Value = RegionID;
            parameters[1].Value = VerificationStatus;
            parameters[2].Value = VerificationDetails;
            parameters[3].Value = DisplayMockAllotmentForCAPRound;
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("MHDTE_spGetDraftAllotmentVerificcationStatus", parameters);
            }
            finally
            {
                db.Dispose();
            }


        }
    }

}