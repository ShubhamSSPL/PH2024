using BusinessLayer;
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

namespace Pharmacy2024.ARAModule
{
    public partial class frmInstitute_ChoiceCodWiseCandidateList : System.Web.UI.Page
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
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    
                    if (Request.QueryString["ChoiceCode"] != null)
                    {
                        //string ChoiceCode = "10122119110";
                        if(Session["UserTypeID"].ToString() =="22" || Session["UserTypeID"].ToString() == "31")
                        {
                            
                            string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                            string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();
                            gvReport.DataSource = reg.GetAdmittedCandidateListToROVerification(ChoiceCode);
                            gvReport.DataBind();
                            this.gvReport.Columns[8].Visible = false;
                            this.gvReport.Columns[9].Visible = true;
                            this.gvReport.Columns[10].Visible = false;
                        }
                        else if (Session["UserTypeID"].ToString() == "61" || Session["UserTypeID"].ToString() == "62")
                        {
                            string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                            string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();
                            gvReport.DataSource = reg.GetAdmittedCandidateListToAraVerification(ChoiceCode);
                            gvReport.DataBind();
                            this.gvReport.Columns[10].Visible = true;
                            this.gvReport.Columns[8].Visible = false;
                            this.gvReport.Columns[9].Visible = false;
                        }
                        else
                        {
                            string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                            string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();
                            gvReport.DataSource = reg.GetAdmittedCandidateListToInstituteVerification(ChoiceCode);
                            gvReport.DataBind();
                            this.gvReport.Columns[8].Visible = true;
                            this.gvReport.Columns[9].Visible = false;
                            this.gvReport.Columns[10].Visible = false;
                        }
                        

                    }
                    else
                    {
                        shInfo.SetMessage("Wrong ChoiceCode.", ShowMessageType.Information);
                    }

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }

        }

        //protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (((Label)e.Row.Cells[8].FindControl("lblInstituteStatus")).Text == "A")
        //        {

        //            //((Button)e.Row.Cells[6].FindControl("Button")).Visible = false;
                    
        //        }
        //        else
        //        {
        //            //((Button)e.Row.Cells[6].FindControl(Button.DisabledCssClass)).Visible = true;
        //        }
        //    }
        //}

        protected void gvReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
            try
            {
                string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();
                Int32 RowID = Convert.ToInt32(e.CommandArgument.ToString());
                Int64 PersonalId = Convert.ToInt64(((Label)gvReport.Rows[RowID].FindControl("lblPersonalID")).Text);
                DataSet ds = new dbUtility().GetInstitute_EditUploadRequiredDocumentForAra(PersonalId);
                if (e.CommandName == "Verify")
                {
                    if (ds != null && ds.Tables[0].Rows.Count > 0 && (Session["UserTypeID"].ToString() == "43"))
                    {
                        Response.Redirect("../ARAModule/frmInstitute_EditUploadRequiredDocument?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString() + "&ChoiceCode=" + ChoiceCode +"&ChoiceCodeDisplay=" + ChoiceCodeDisplay);
                    }
                    else
                    {
                        Response.Redirect("../ARAModule/frmInstitute_VerificationCandidateDocuments?PID=" + PersonalId + "&Code=" + PersonalId.ToString().GetHashCode().ToString() + "&ChoiceCode=" + ChoiceCode + "&ChoiceCodeDisplay=" + ChoiceCodeDisplay);
                    }
                        
                }
                else
                {
                    shInfo.Visible = true;
                    shInfo.SetMessage("Please Enter Replied Message.", ShowMessageType.Information);
                }

            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }

        private class dbUtility
        {
            public DataSet GetInstitute_EditUploadRequiredDocumentForAra(Int64 PersonalId)
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@PersonalId", SqlDbType.BigInt)
                };

                param[0].Value = PersonalId;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("MHDTE_spGetInstitute_EditUploadRequiredDocumentForAra", param);

                }
                finally
                {
                    db.Dispose();
                }

                //return ExecProcedure("MHDTE_spGetAllDocuments", param, "tbl");
            }
        }
    }
}