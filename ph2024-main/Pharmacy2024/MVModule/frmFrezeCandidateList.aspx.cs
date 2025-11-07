using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using Synthesys.DataAcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.MVModule
{
    public partial class frmFrezeCandidateList : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            shInfo.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    refreshdataSI();
                    refreshdataOthers();
                    refreshdataEWS();
                    refreshdataTFWS();
                    string NormalChoiceCode = Request.QueryString["NormalChoiceCode"].ToString();
                    string ChoiceCode = Session["UserLoginID"].ToString();
                    int InstCode = Convert.ToInt32(ChoiceCode);
                    DataSet ds = new DataSet();
                    ds = reg.getVerifiedByInst(Convert.ToInt64(NormalChoiceCode), 'I');
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                   
                    string date = reg.getCertificateRemarks(NormalChoiceCode.ToString(), 'I');

                    if (dt.Rows.Count > 0)
                    {
                        lblMsg.Text = "Candidate's List already submitted to RO on "+ date +  "   for Merit List Verification.";
                        lblMsg2.Text = "Candidate's List shall be scrutinised by scrutiny officer, RO will let you know the status of scrutiny.";
                        gvReport.Visible = false;
                        gvEWS.Visible = false;
                        gvOthers.Visible = false;
                        gvTFWS.Visible = false;
                        lblOthers.Visible = false;
                        lblEWS.Visible = false;
                        lblTFWS.Visible = false;
                        btnShowList.Visible = true;
                        btnSubmit.Enabled = false;
                        btnSubmit.Visible = false;
                    }
                    else
                    {
                        lblMsg.Text = "Please submit Candidate's List For Merit List Verification.";
                        lblMsg2.Text = "";
                        gvReport.Visible = true;
                        gvOthers.Visible = true;
                        gvEWS.Visible = true;
                        gvTFWS.Visible = true;
                        lblEWS.Visible = true;
                        lblTFWS.Visible = true;
                        lblOthers.Visible = true;
                        btnShowList.Visible = false;
                        btnSubmit.Enabled = true;
                        btnSubmit.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    shInfo.Visible = true;
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public void refreshdataSI()
        {
            string NormalChoiceCode = Request.QueryString["NormalChoiceCode"].ToString();
            string TfwsChoiceCode = Request.QueryString["TFWSChoiceCode"].ToString();
            string ChoiceCode = NormalChoiceCode;
            int InstCode = Convert.ToInt32(Session["UserLoginID"].ToString());
            DataSet ds = new DataSet();
            ds = reg.getAllotmentReportForSO(ChoiceCode, "SI");
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            gvReport.DataSource = ds;
            gvReport.DataBind();
            ViewState["dirState"] = dt;
            ViewState["sortdr"] = "Asc";            
        }
        public void refreshdataOthers()
        {
            string NormalChoiceCode = Request.QueryString["NormalChoiceCode"].ToString();
            string TfwsChoiceCode = Request.QueryString["TFWSChoiceCode"].ToString();
            string ChoiceCode = NormalChoiceCode;
            int InstCode = Convert.ToInt32(Session["UserLoginID"].ToString());
            DataSet ds = new DataSet();
            ds = reg.getAllotmentReportForSO(ChoiceCode, "OTH");
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            gvOthers.DataSource = ds;
            gvOthers.DataBind();
            ViewState["dirStateOTH"] = dt;
            ViewState["sortdrOTH"] = "Asc";

            if (gvOthers.Rows.Count > 0)
            {
                lblOthers.Visible = true;
            }
            else
            {
                lblOthers.Visible = false;
            }
        }
        public void refreshdataEWS()
        {
            string NormalChoiceCode = Request.QueryString["NormalChoiceCode"].ToString();
            string TfwsChoiceCode = Request.QueryString["TFWSChoiceCode"].ToString();
            string ChoiceCode = NormalChoiceCode;
            int InstCode = Convert.ToInt32(Session["UserLoginID"].ToString());
            DataSet ds = new DataSet();
            ds = reg.getAllotmentReportForSO(ChoiceCode, "EWS");
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            gvEWS.DataSource = ds;
            gvEWS.DataBind();
            ViewState["dirStateEWS"] = dt;
            ViewState["sortdrEWS"] = "Asc";
            
            if(gvEWS.Rows.Count>0)
            {
                lblEWS.Visible = true;
            }
            else
            {
                lblEWS.Visible = false;
            }
        }
        public void refreshdataTFWS()
        {
            string NormalChoiceCode = Request.QueryString["NormalChoiceCode"].ToString();
            string TfwsChoiceCode = Request.QueryString["TFWSChoiceCode"].ToString();
            string ChoiceCode = TfwsChoiceCode;
            int InstCode = Convert.ToInt32(Session["UserLoginID"].ToString());
            DataSet ds = new DataSet();
            ds = reg.getAllotmentReportForSO(ChoiceCode, "TFWS");
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            gvTFWS.DataSource = ds;
            gvTFWS.DataBind();
            ViewState["dirStateTFWS"] = dt;
            ViewState["sortdrTFWS"] = "Asc";

            if (gvTFWS.Rows.Count > 0)
            {
                lblTFWS.Visible = true;
            }
            else
            {
                lblTFWS.Visible = false;
            }
        }
        protected void gvReport_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                gvReport.DataSource = dtrslt;
                gvReport.DataBind();
            }
        }
        protected void gvOthers_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirStateEWS"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdrEWS"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdrEWS"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdrEWS"] = "Asc";
                }
                gvEWS.DataSource = dtrslt;
                gvEWS.DataBind();
            }
        }
        protected void gvEWS_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirStateEWS"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdrEWS"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdrEWS"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdrEWS"] = "Asc";
                }
                gvEWS.DataSource = dtrslt;
                gvEWS.DataBind();
            }
        }
        protected void gvTFWS_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirStateTFWS"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdrTFWS"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdrTFWS"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdrTFWS"] = "Asc";
                }
                gvTFWS.DataSource = dtrslt;
                gvTFWS.DataBind();
            }
        }
        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                 
                Label lblAdmissionStatus = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=DEN21" + PID;
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;
                
                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    lblAdmissionStatus.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }

            }
        }
        protected void gvOthers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdmissionStatus = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=DEN21" + PID;
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    lblAdmissionStatus.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }
        protected void gvEWS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdmissionStatus = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=DEN21" + PID;
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    lblAdmissionStatus.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }
        protected void gvTFWS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdmissionStatus = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=DEN21" + PID;
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    lblAdmissionStatus.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }
        protected void btnShowList_Click(object sender, EventArgs e)
        {
            if (gvReport.Visible == false)
            {
                gvReport.Visible = true;
            }
            else
            {
                gvReport.Visible = false;
            }

            if (gvOthers.Visible == false)
            {
                gvOthers.Visible = true;
                if (gvOthers.Rows.Count > 0)
                {
                    lblOthers.Visible = true;
                }
                else
                {
                    lblOthers.Visible = false;
                }

            }
            else
            {
                gvOthers.Visible = false;
                lblOthers.Visible = false;
            }

            if (gvEWS.Visible == false)
            {
                gvEWS.Visible = true;
                if (gvEWS.Rows.Count > 0)
                {
                    lblEWS.Visible = true;
                }
                else
                {
                    lblEWS.Visible = false;
                }

            }
            else
            {
                gvEWS.Visible = false;
                lblEWS.Visible = false;
            }

            if (gvTFWS.Visible == false)
            {
                gvTFWS.Visible = true;
                if (gvTFWS.Rows.Count > 0)
                {
                    lblTFWS.Visible = true;
                }
                else
                {
                    lblTFWS.Visible = false;
                }
            }
            else
            {
                gvTFWS.Visible = false;
                lblTFWS.Visible = false;
            }            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 InstCode, SRNO = 0, PID = 0, FeesPaid = 0, ApplicationFeeToBePaid = 0;
                string CreatedBy = Session["UserLoginID"].ToString();
                string CreatedIPAddress = UserInfo.GetIPAddress();
                InstCode = Convert.ToInt64(Session["UserID"].ToString());
                ApplicationFeeToBePaid = reg.getAdmissionApprovalFeeToBePaid(4, 1, Convert.ToInt32(Session["UserTypeID"].ToString()), InstCode);
                FeesPaid = reg.getAdmissionApprovalFeePaidAmount(InstCode);
                if (FeesPaid >= ApplicationFeeToBePaid && ApplicationFeeToBePaid != 0)
                {
                    string ChoiceCode = Request.QueryString["NormalChoiceCode"].ToString();
                    reg.saveInstituteVarificationStatus(InstCode, 'Y', CreatedBy, CreatedIPAddress, 'I', ChoiceCode);
                    //if (gvReport.Rows.Count > 0)
                    //{                        
                    //    reg.saveInstituteVarificationStatus(InstCode, 'Y', CreatedBy, CreatedIPAddress, 'I', ChoiceCode);
                    //    for (int i = 0; i < gvReport.Rows.Count; i++)
                    //    {
                    //        SRNO = Convert.ToInt64(gvReport.Rows[i].Cells[0].Text);
                    //        PID = Convert.ToInt64(gvReport.Rows[i].Cells[1].Text);
                    //        reg.updateCandidateSrNo(SRNO, PID);
                    //    }
                    //}

                    //if (gvOthers.Rows.Count > 0)
                    //{
                    //    reg.saveInstituteVarificationStatus(InstCode, 'Y', CreatedBy, CreatedIPAddress, 'I', ChoiceCode);
                    //    for (int n = 0; n < gvOthers.Rows.Count; n++)
                    //    {
                    //        SRNO = Convert.ToInt64(gvOthers.Rows[n].Cells[0].Text);
                    //        PID = Convert.ToInt64(gvOthers.Rows[n].Cells[1].Text);
                    //        reg.updateCandidateSrNo(SRNO, PID);
                    //    }
                    //}

                    //if (gvEWS.Rows.Count > 0)
                    //{
                    //    reg.saveInstituteVarificationStatus(InstCode, 'Y', CreatedBy, CreatedIPAddress, 'I', ChoiceCode);
                    //    for (int n = 0; n < gvEWS.Rows.Count; n++)
                    //    {
                    //        SRNO = Convert.ToInt64(gvEWS.Rows[n].Cells[0].Text);
                    //        PID = Convert.ToInt64(gvEWS.Rows[n].Cells[1].Text);
                    //        reg.updateCandidateSrNo(SRNO, PID);
                    //    }
                    //}

                    //if (gvTFWS.Rows.Count > 0)
                    //{
                    //    string ChoiceCodeT = Request.QueryString["TFWSChoiceCode"].ToString();
                    //    reg.saveInstituteVarificationStatus(InstCode, 'Y', CreatedBy, CreatedIPAddress, 'I', ChoiceCodeT);
                    //    for (int c = 0; c < gvTFWS.Rows.Count; c++)
                    //    {
                    //        SRNO = Convert.ToInt64(gvTFWS.Rows[c].Cells[0].Text);
                    //        PID = Convert.ToInt64(gvTFWS.Rows[c].Cells[1].Text);
                    //        reg.updateCandidateSrNo(SRNO, PID);
                    //    }
                    //}
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert(Candidate's List submitted to RO for Merit List Verification. Candidate's List shall be scrutinised by scrutiny officer, RO will let you know the status of scrutiny.');", true);
                    lblMsg.Text = "Candidate's List submitted to RO for Merit List verification.";
                    lblMsg2.Text = "Candidate's List shall be scrutinised by scrutiny officer, RO will let you know the status of scrutiny.";
                    gvReport.Visible = false;
                    gvEWS.Visible = false;
                    gvTFWS.Visible = false;
                    gvOthers.Visible = false;
                    lblEWS.Visible = false;
                    lblOthers.Visible = false;
                    lblTFWS.Visible = false;
                    btnShowList.Visible = true;
                    btnSubmit.Visible = false;
                    btnSubmit.Enabled = false;

                    Response.Redirect("frmInstitute_ChoiceCodeList.aspx?InstituteCode=" + InstCode, true);

                }
                else if(reg.getAdmissionApprovalFeeDetails(InstCode, "Admission Approval Fee", "Unlocked").Tables[0].Rows.Count > 0 && ApplicationFeeToBePaid <= 0)
                {
                    string ChoiceCode = Request.QueryString["NormalChoiceCode"].ToString();
                    if (gvReport.Rows.Count > 0)
                    {                        
                        reg.saveInstituteVarificationStatus(InstCode, 'Y', CreatedBy, CreatedIPAddress, 'I', ChoiceCode);
                        for (int i = 0; i < gvReport.Rows.Count; i++)
                        {
                            SRNO = Convert.ToInt64(gvReport.Rows[i].Cells[0].Text);
                            PID = Convert.ToInt64(gvReport.Rows[i].Cells[1].Text);
                            reg.updateCandidateSrNo(SRNO, PID);
                        }
                    }

                    if (gvOthers.Rows.Count > 0)
                    {
                        reg.saveInstituteVarificationStatus(InstCode, 'Y', CreatedBy, CreatedIPAddress, 'I', ChoiceCode);
                        for (int n = 0; n < gvOthers.Rows.Count; n++)
                        {
                            SRNO = Convert.ToInt64(gvOthers.Rows[n].Cells[0].Text);
                            PID = Convert.ToInt64(gvOthers.Rows[n].Cells[1].Text);
                            reg.updateCandidateSrNo(SRNO, PID);
                        }
                    }

                    if (gvEWS.Rows.Count > 0)
                    {
                        reg.saveInstituteVarificationStatus(InstCode, 'Y', CreatedBy, CreatedIPAddress, 'I', ChoiceCode);
                        for (int n = 0; n < gvEWS.Rows.Count; n++)
                        {
                            SRNO = Convert.ToInt64(gvEWS.Rows[n].Cells[0].Text);
                            PID = Convert.ToInt64(gvEWS.Rows[n].Cells[1].Text);
                            reg.updateCandidateSrNo(SRNO, PID);
                        }
                    }

                    if (gvTFWS.Rows.Count > 0)
                    {
                        string ChoiceCodeT = Request.QueryString["TFWSChoiceCode"].ToString();
                        reg.saveInstituteVarificationStatus(InstCode, 'Y', CreatedBy, CreatedIPAddress, 'I', ChoiceCodeT);
                        for (int c = 0; c < gvTFWS.Rows.Count; c++)
                        {
                            SRNO = Convert.ToInt64(gvTFWS.Rows[c].Cells[0].Text);
                            PID = Convert.ToInt64(gvTFWS.Rows[c].Cells[1].Text);
                            reg.updateCandidateSrNo(SRNO, PID);
                        }
                    }
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert(Candidate's List submitted to RO for Merit List Verification. Candidate's List shall be scrutinised by scrutiny officer, RO will let you know the status of scrutiny.');", true);
                    lblMsg.Text = "Candidate's List submitted to RO for Merit List verification.";
                    lblMsg2.Text = "Candidate's List shall be scrutinised by scrutiny officer, RO will let you know the status of scrutiny.";
                    gvReport.Visible = false;
                    gvEWS.Visible = false;
                    gvTFWS.Visible = false;
                    lblEWS.Visible = false;
                    lblOthers.Visible = false;
                    lblTFWS.Visible = false;
                    btnShowList.Visible = true;
                    btnSubmit.Visible = false;
                    btnSubmit.Enabled = false;
                    Response.Redirect("frmInstitute_ChoiceCodeList.aspx?InstituteCode=" + InstCode, true);
                }
                else
                {
                    Response.Redirect("~/ARAModule/frmInstitute_AdmissionApprovalFeeDetails", true);

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Error saving Records.');", true);
            }
        }
    }
}