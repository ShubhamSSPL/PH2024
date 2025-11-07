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
using Saplin.Controls;
using System.Collections;

namespace Pharmacy2024.MVModule
{
    public partial class frmMeritListVerificationDTE : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        string DescID;
        int MendetFlg;
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
                    string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                    string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();

                    lblInstituteName.Text = "[" + ChoiceCodeDisplay.Substring(0, 5) + "]" + " " + reg.getInstituteName(ChoiceCodeDisplay.Substring(0, 5)) + "<br /><br />" + Request.QueryString["ChoiceCodeDisplay"].ToString() + " - " + reg.getCourseName(ChoiceCode);
                                       

                    refreshdata();
                    refreshdataOthers();
                    refreshdataEWS();
                }
                catch (Exception ex)
                {
                    shInfo.Visible = true;
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public void refreshdata()
        {
            string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
            string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();

            DataSet ds = new DataSet();
            ds = reg.getAllotmentReportForSO(ChoiceCode, "S");
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            
            gvReport.DataSource = ds;
            gvReport.DataBind();
            ViewState["dirState"] = dt;
            ViewState["sortdr"] = "Asc";
        }
        public void refreshdataOthers()
        {
            string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
            string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();

            DataSet ds = new DataSet();
            ds = reg.getAllotmentReportForSO(ChoiceCode, "O");
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            gvOthers.DataSource = ds;
            gvOthers.DataBind();
            ViewState["dirState"] = dt;
            ViewState["sortdr"] = "Asc";

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
            string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
            string ChoiceCodeDisplay = Request.QueryString["ChoiceCodeDisplay"].ToString();

            DataSet ds = new DataSet();
            ds = reg.getAllotmentReportForSO(ChoiceCode, "E");
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            gvEWS.DataSource = ds;
            gvEWS.DataBind();
            ViewState["dirState"] = dt;
            ViewState["sortdr"] = "Asc";

            if (gvEWS.Rows.Count > 0)
            {
                lblEWS.Visible = true;
            }
            else
            {
                lblEWS.Visible = false;
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
                gvOthers.DataSource = dtrslt;
                gvOthers.DataBind();
            }
        }
        protected void gvEWS_Sorting(object sender, GridViewSortEventArgs e)
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
                gvEWS.DataSource = dtrslt;
                gvEWS.DataBind();
            }
        }
        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                DropDownCheckBoxes ddlMVDiscrepency = (e.Row.FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                DropDownCheckBoxes ddlSubMVDiscrepency = (e.Row.FindControl("ddlSubMVDiscrepency") as DropDownCheckBoxes);
                ddlMVDiscrepency.DataSource = reg.getMasterMVDiscrepancy();
                ddlMVDiscrepency.DataTextField = "MVDiscrepancyName";
                ddlMVDiscrepency.DataValueField = "MVDiscrepancyID";
                ddlMVDiscrepency.DataBind();
                ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";               
                string Discrepency = (e.Row.FindControl("lblMVDiscrepency") as Label).Text;
                if (Discrepency != "")
                {
                    string[] tmp = Discrepency.Split(',');
                    int len = tmp.Length; 
                    ListItemCollection items = new ListItemCollection();
                    DataSet ds1;

                    for (int i = 0; i < len; i++)
                    {
                        ddlMVDiscrepency.Items.FindByValue(tmp[i]).Selected = true;
                        Int32 DID = Convert.ToInt32(tmp[i]);
                        ds1 = reg.getMVSubDiscrepancy(DID);
                        int c = ds1.Tables[0].Rows.Count;
                        for (int rn = 0; rn < c; rn++)
                        {
                            items.Add(new ListItem(ds1.Tables[0].Rows[rn]["MVSubDiscrepancy"].ToString(), ds1.Tables[0].Rows[rn]["MVSubDiscrepancyID"].ToString()));
                        }
                    }
                    ddlSubMVDiscrepency.DataSource = items;
                    ddlSubMVDiscrepency.DataTextField = "Text";
                    ddlSubMVDiscrepency.DataValueField = "Value";
                    ddlSubMVDiscrepency.DataBind();
                    ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                    ddlMVDiscrepency.Texts.SelectBoxCaption = len + " Discrepancy Selected.";                    
                }

                string SubDiscrepency = (e.Row.FindControl("lblMVSubDiscrepency") as Label).Text;
                if (SubDiscrepency != "")
                {
                    string[] tmp = SubDiscrepency.Split(',');
                    int len = tmp.Length;
                    for (int i = 0; i < len; i++)
                    {
                        ddlSubMVDiscrepency.Items.FindByValue(tmp[i]).Selected = true;                        
                    }
                    ddlSubMVDiscrepency.Texts.SelectBoxCaption = len + " Sub Discrepancy Selected.";
                }

                Label lblSelected = (e.Row.FindControl("lblSelected") as Label);
                    try
                    {
                        string Selected = "";
                        List<String> MVDiscrepency_list = new List<string>();

                        foreach (System.Web.UI.WebControls.ListItem item in ddlMVDiscrepency.Items)
                        {
                            if (item.Selected)
                            {
                                MVDiscrepency_list.Add(item.Text);
                                Selected = Selected + item.Text + ". ";
                            }
                            lblSelected.Text = Selected;  
                        }

                        if (ddlMVDiscrepency.Texts.SelectBoxCaption == "")
                        {
                            ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                        }

                        DescID = String.Join(", ", MVDiscrepency_list.ToArray());
                    }
                    catch (Exception ex)
                    {
                        
                    }
                
                TextBox txtDescription = (e.Row.FindControl("txtDescription") as TextBox);
                RadioButton rbtReject = (e.Row.FindControl("rbtReject") as RadioButton);
                RadioButton rbtAccept = (e.Row.FindControl("rbtAccept") as RadioButton);
                
                Label lblAdmissionStatus  = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();                    
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=PH23" + PID;                    
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                Int64 InstCode = Convert.ToInt64(ChoiceCode.Substring(0, 4));
                DataSet ds = new DataSet();
                ds = reg.getVerifiedByInst(InstCode, 'D');
                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (rbtReject.Checked == false)
                    {                        
                        rbtAccept.Checked = true;

                    }
                    else
                    {                       
                        rbtReject.Checked = true;
                        e.Row.BackColor = System.Drawing.Color.LightCyan;
                    }
                    txtDescription.Enabled = false;
                    ddlMVDiscrepency.Enabled = false;
                    btnSubmitAll.Visible = false;
                    btnSubmitAll.Enabled = false;
                    rbtAccept.Enabled = false;
                    rbtReject.Enabled = false;
                }
                else
                {
                    if (rbtReject.Checked == false)
                    {
                        txtDescription.Enabled = false;
                        ddlMVDiscrepency.Enabled = false;
                        rbtAccept.Checked = true;

                    }
                    else
                    {
                        txtDescription.Enabled = true;
                        ddlMVDiscrepency.Enabled = true;
                        rbtReject.Checked = true;
                        e.Row.BackColor = System.Drawing.Color.LightCyan;
                    }
                    btnSubmitAll.Visible = true;
                    btnSubmitAll.Enabled = true;
                }
                
                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    rbtReject.Checked = true;
                    rbtAccept.Checked = false;
                    rbtAccept.Enabled = false;
                    txtDescription.Enabled = false;
                    txtDescription.Text = "Admission Cancelled";
                    ddlMVDiscrepency.Enabled = false;                    
                    lblAdmissionStatus.ForeColor= System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }          
                
            }            
        }
        protected void gvOthers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownCheckBoxes ddlMVDiscrepency = (e.Row.FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                DropDownCheckBoxes ddlSubMVDiscrepency = (e.Row.FindControl("ddlSubMVDiscrepency") as DropDownCheckBoxes);
                ddlMVDiscrepency.DataSource = reg.getMasterMVDiscrepancy();
                ddlMVDiscrepency.DataTextField = "MVDiscrepancyName";
                ddlMVDiscrepency.DataValueField = "MVDiscrepancyID";
                ddlMVDiscrepency.DataBind();
                ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                string Discrepency = (e.Row.FindControl("lblMVDiscrepency") as Label).Text;
                if (Discrepency != "")
                {
                    string[] tmp = Discrepency.Split(',');
                    int len = tmp.Length;
                    for (int i = 0; i < len; i++)
                    {
                        ddlMVDiscrepency.Items.FindByValue(tmp[i]).Selected = true;
                        Int32 DID = Convert.ToInt32(tmp[i]);
                       
                        ddlSubMVDiscrepency.DataSource = reg.getMVSubDiscrepancy(DID);
                        ddlSubMVDiscrepency.DataTextField = "MVSubDiscrepancy";
                        ddlSubMVDiscrepency.DataValueField = "MVSubDiscrepancyID";
                        ddlSubMVDiscrepency.DataBind();
                        ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                    }
                    ddlMVDiscrepency.Texts.SelectBoxCaption = len + " Discrepancy Selected.";
                }

                string SubDiscrepency = (e.Row.FindControl("lblMVSubDiscrepency") as Label).Text;
                if (SubDiscrepency != "")
                {
                    string[] tmp = SubDiscrepency.Split(',');
                    int len = tmp.Length;
                    for (int i = 0; i < len; i++)
                    {
                        ddlSubMVDiscrepency.Items.FindByValue(tmp[i]).Selected = true;
                    }
                    ddlSubMVDiscrepency.Texts.SelectBoxCaption = len + " Sub Discrepancy Selected.";
                }

                Label lblSelected = (e.Row.FindControl("lblSelected") as Label);
                try
                {
                    string Selected = "";
                    List<String> MVDiscrepency_list = new List<string>();

                    foreach (System.Web.UI.WebControls.ListItem item in ddlMVDiscrepency.Items)
                    {
                        if (item.Selected)
                        {
                            MVDiscrepency_list.Add(item.Text);
                            Selected = Selected + item.Text + ". ";
                        }
                        lblSelected.Text = Selected;
                    }

                    if (ddlMVDiscrepency.Texts.SelectBoxCaption == "")
                    {
                        ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                    }

                    DescID = String.Join(", ", MVDiscrepency_list.ToArray());
                }
                catch (Exception ex)
                {

                }

                TextBox txtDescription = (e.Row.FindControl("txtDescription") as TextBox);
                RadioButton rbtReject = (e.Row.FindControl("rbtReject") as RadioButton);
                RadioButton rbtAccept = (e.Row.FindControl("rbtAccept") as RadioButton);

                Label lblAdmissionStatus = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=PH23" + PID;
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                Int64 InstCode = Convert.ToInt64(ChoiceCode.Substring(0, 4));
                DataSet ds = new DataSet();
                ds = reg.getVerifiedByInst(InstCode, 'D');
                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (rbtReject.Checked == false)
                    {
                        rbtAccept.Checked = true;

                    }
                    else
                    {
                        rbtReject.Checked = true;
                        e.Row.BackColor = System.Drawing.Color.LightCyan;
                    }
                    txtDescription.Enabled = false;
                    ddlMVDiscrepency.Enabled = false;
                    btnSubmitAll.Visible = false;
                    btnSubmitAll.Enabled = false;
                    rbtAccept.Enabled = false;
                    rbtReject.Enabled = false;
                }
                else
                {
                    if (rbtReject.Checked == false)
                    {
                        txtDescription.Enabled = false;
                        ddlMVDiscrepency.Enabled = false;
                        rbtAccept.Checked = true;

                    }
                    else
                    {
                        txtDescription.Enabled = true;
                        ddlMVDiscrepency.Enabled = true;
                        rbtReject.Checked = true;
                        e.Row.BackColor = System.Drawing.Color.LightCyan;
                    }
                    btnSubmitAll.Visible = true;
                    btnSubmitAll.Enabled = true;
                }

                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    rbtReject.Checked = true;
                    rbtAccept.Checked = false;
                    rbtAccept.Enabled = false;
                    txtDescription.Enabled = false;
                    txtDescription.Text = "Admission Cancelled";
                    ddlMVDiscrepency.Enabled = false;
                    lblAdmissionStatus.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }

            }
        }
        protected void gvEWS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownCheckBoxes ddlMVDiscrepency = (e.Row.FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                DropDownCheckBoxes ddlSubMVDiscrepency = (e.Row.FindControl("ddlSubMVDiscrepency") as DropDownCheckBoxes);
                ddlMVDiscrepency.DataSource = reg.getMasterMVDiscrepancy();
                ddlMVDiscrepency.DataTextField = "MVDiscrepancyName";
                ddlMVDiscrepency.DataValueField = "MVDiscrepancyID";
                ddlMVDiscrepency.DataBind();
                ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                string Discrepency = (e.Row.FindControl("lblMVDiscrepency") as Label).Text;
                if (Discrepency != "")
                {
                    string[] tmp = Discrepency.Split(',');
                    int len = tmp.Length;
                    for (int i = 0; i < len; i++)
                    {
                        ddlMVDiscrepency.Items.FindByValue(tmp[i]).Selected = true;
                        Int32 DID = Convert.ToInt32(tmp[i]);

                        ddlSubMVDiscrepency.DataSource = reg.getMVSubDiscrepancy(DID);
                        ddlSubMVDiscrepency.DataTextField = "MVSubDiscrepancy";
                        ddlSubMVDiscrepency.DataValueField = "MVSubDiscrepancyID";
                        ddlSubMVDiscrepency.DataBind();
                        ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                    }
                    ddlMVDiscrepency.Texts.SelectBoxCaption = len + " Discrepancy Selected.";
                }

                string SubDiscrepency = (e.Row.FindControl("lblMVSubDiscrepency") as Label).Text;
                if (SubDiscrepency != "")
                {
                    string[] tmp = SubDiscrepency.Split(',');
                    int len = tmp.Length;
                    for (int i = 0; i < len; i++)
                    {
                        ddlSubMVDiscrepency.Items.FindByValue(tmp[i]).Selected = true;
                    }
                    ddlSubMVDiscrepency.Texts.SelectBoxCaption = len + " Sub Discrepancy Selected.";
                }

                Label lblSelected = (e.Row.FindControl("lblSelected") as Label);
                try
                {
                    string Selected = "";
                    List<String> MVDiscrepency_list = new List<string>();

                    foreach (System.Web.UI.WebControls.ListItem item in ddlMVDiscrepency.Items)
                    {
                        if (item.Selected)
                        {
                            MVDiscrepency_list.Add(item.Text);
                            Selected = Selected + item.Text + ". ";
                        }
                        lblSelected.Text = Selected;
                    }

                    if (ddlMVDiscrepency.Texts.SelectBoxCaption == "")
                    {
                        ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                    }

                    DescID = String.Join(", ", MVDiscrepency_list.ToArray());
                }
                catch (Exception ex)
                {

                }

                TextBox txtDescription = (e.Row.FindControl("txtDescription") as TextBox);
                RadioButton rbtReject = (e.Row.FindControl("rbtReject") as RadioButton);
                RadioButton rbtAccept = (e.Row.FindControl("rbtAccept") as RadioButton);

                Label lblAdmissionStatus = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=PH23" + PID;
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                Int64 InstCode = Convert.ToInt64(ChoiceCode.Substring(0, 4));
                DataSet ds = new DataSet();
                ds = reg.getVerifiedByInst(InstCode, 'D');
                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (rbtReject.Checked == false)
                    {
                        rbtAccept.Checked = true;

                    }
                    else
                    {
                        rbtReject.Checked = true;
                        e.Row.BackColor = System.Drawing.Color.LightCyan;
                    }
                    txtDescription.Enabled = false;
                    ddlMVDiscrepency.Enabled = false;
                    btnSubmitAll.Visible = false;
                    btnSubmitAll.Enabled = false;
                    rbtAccept.Enabled = false;
                    rbtReject.Enabled = false;
                }
                else
                {
                    if (rbtReject.Checked == false)
                    {
                        txtDescription.Enabled = false;
                        ddlMVDiscrepency.Enabled = false;
                        rbtAccept.Checked = true;

                    }
                    else
                    {
                        txtDescription.Enabled = true;
                        ddlMVDiscrepency.Enabled = true;
                        rbtReject.Checked = true;
                        e.Row.BackColor = System.Drawing.Color.LightCyan;
                    }
                    btnSubmitAll.Visible = true;
                    btnSubmitAll.Enabled = true;
                }

                if (AdmStatus == "Cancelled")
                {
                    hl.Enabled = false;
                    hl.Text = "Not Applicable";
                    rbtReject.Checked = true;
                    rbtAccept.Checked = false;
                    rbtAccept.Enabled = false;
                    txtDescription.Enabled = false;
                    txtDescription.Text = "Admission Cancelled";
                    ddlMVDiscrepency.Enabled = false;
                    lblAdmissionStatus.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }

            }
        }
        protected void btnSubmitAll_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                MendetFlg = 0;
                MeritListVerificaton obj = new MeritListVerificaton();

                for (i = 0; i < gvReport.Rows.Count; i++)
                {
                    DropDownCheckBoxes ddlMVDiscrepency = new DropDownCheckBoxes();
                    ddlMVDiscrepency = (DropDownCheckBoxes)(gvReport.Rows[i].FindControl("ddlMVDiscrepency"));
                    TextBox txtDescription = new TextBox();
                    txtDescription = (TextBox)(gvReport.Rows[i].FindControl("txtDescription"));
                    Label lblSelectedDisc = (Label)(gvReport.Rows[i].FindControl("lblSelectedDisc"));
                    RadioButton rbtReject = new RadioButton();
                    rbtReject = (RadioButton)(gvReport.Rows[i].FindControl("rbtReject"));
                    if (rbtReject.Checked == true && (gvReport.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                    {
                            if (lblSelectedDisc.Text != "")
                            {

                            }
                            else
                            {
                                gvReport.Rows[i].BackColor = System.Drawing.Color.LightYellow;
                                MendetFlg = MendetFlg + 1;
                            }                        
                    }                    
                }
                if (gvOthers.Rows.Count > 0)
                {
                    for (i = 0; i < gvOthers.Rows.Count; i++)
                    {
                        DropDownCheckBoxes ddlMVDiscrepency = new DropDownCheckBoxes();
                        ddlMVDiscrepency = (DropDownCheckBoxes)(gvOthers.Rows[i].FindControl("ddlMVDiscrepency"));
                        TextBox txtDescription = new TextBox();
                        txtDescription = (TextBox)(gvOthers.Rows[i].FindControl("txtDescription"));
                        Label lblSelectedDisc = (Label)(gvOthers.Rows[i].FindControl("lblSelectedDisc"));
                        RadioButton rbtReject = new RadioButton();
                        rbtReject = (RadioButton)(gvOthers.Rows[i].FindControl("rbtReject"));
                        if (rbtReject.Checked == true && (gvOthers.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                        {
                            if (lblSelectedDisc.Text != "")
                            {

                            }
                            else
                            {
                                gvOthers.Rows[i].BackColor = System.Drawing.Color.LightYellow;
                                MendetFlg = MendetFlg + 1;
                            }
                        }
                    }
                }
                if (gvEWS.Rows.Count > 0)
                {
                    for (i = 0; i < gvEWS.Rows.Count; i++)
                    {
                        DropDownCheckBoxes ddlMVDiscrepency = new DropDownCheckBoxes();
                        ddlMVDiscrepency = (DropDownCheckBoxes)(gvEWS.Rows[i].FindControl("ddlMVDiscrepency"));
                        TextBox txtDescription = new TextBox();
                        txtDescription = (TextBox)(gvEWS.Rows[i].FindControl("txtDescription"));
                        Label lblSelectedDisc = (Label)(gvEWS.Rows[i].FindControl("lblSelectedDisc"));
                        RadioButton rbtReject = new RadioButton();
                        rbtReject = (RadioButton)(gvEWS.Rows[i].FindControl("rbtReject"));
                        if (rbtReject.Checked == true && (gvEWS.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                        {
                            if (lblSelectedDisc.Text != "")
                            {

                            }
                            else
                            {
                                gvEWS.Rows[i].BackColor = System.Drawing.Color.LightYellow;
                                MendetFlg = MendetFlg + 1;
                            }
                        }
                    }
                }               
                saveDiscrepency();               
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Error saving Records.');", true);
            }
            finally
            {
                
            }
        }
        public void saveDiscrepency()
        {
            string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
            string InstCode = ChoiceCode.Substring(0, 4);
            try
            {
                if (MendetFlg == 0)
                { 
                    int i = 0;
                    MeritListVerificaton obj = new MeritListVerificaton();

                    for (i = 0; i < gvReport.Rows.Count; i++)
                    {
                        Label PerID = new Label();
                        PerID = (Label)(gvReport.Rows[i].FindControl("lblPID"));
                        obj.PID = Convert.ToInt64(PerID.Text);

                        RadioButton rbtAccept = new RadioButton();
                        rbtAccept = (RadioButton)(gvReport.Rows[i].FindControl("rbtAccept"));
                        RadioButton rbtReject = new RadioButton();
                        rbtReject = (RadioButton)(gvReport.Rows[i].FindControl("rbtReject"));
                        if (rbtAccept.Checked == true)
                            obj.Recommend = 'A';
                        else if (rbtReject.Checked == true)
                            obj.Recommend = 'R';
                        else
                            obj.Recommend = 'N';

                        DropDownCheckBoxes ddlMVDiscrepency = new DropDownCheckBoxes();
                        ddlMVDiscrepency = (DropDownCheckBoxes)(gvReport.Rows[i].FindControl("ddlMVDiscrepency"));
                        if (ddlMVDiscrepency.Texts.SelectBoxCaption != "All")
                        {
                            List<String> MVDiscrepency_list = new List<string>();
                            string strCourseTypeID = "";
                            foreach (System.Web.UI.WebControls.ListItem item in ddlMVDiscrepency.Items)
                            {
                                if (item.Selected)
                                {
                                    MVDiscrepency_list.Add(item.Value);
                                }
                                DescID = String.Join(",", MVDiscrepency_list.ToArray());
                            }
                        }                        
                        obj.DiscID = "";
                        obj.DiscID = DescID;

                        DropDownCheckBoxes ddlSubMVDiscrepency = new DropDownCheckBoxes();
                        ddlSubMVDiscrepency = (DropDownCheckBoxes)(gvReport.Rows[i].FindControl("ddlSubMVDiscrepency"));
                        if (ddlSubMVDiscrepency.Texts.SelectBoxCaption != "All")
                        {
                            List<String> MVSubDiscrepency_list = new List<string>();
                            //string strCourseTypeID = "";
                            foreach (System.Web.UI.WebControls.ListItem item in ddlSubMVDiscrepency.Items)
                            {
                                if (item.Selected)
                                {
                                    MVSubDiscrepency_list.Add(item.Value);
                                }
                                DescID = String.Join(",", MVSubDiscrepency_list.ToArray());
                            }
                        }
                        obj.SubDiscID = "";
                        obj.SubDiscID = DescID;

                        Label lblSelectedDisc = (Label)(gvReport.Rows[i].FindControl("lblSelectedDisc"));
                        obj.SubDisc = lblSelectedDisc.Text;

                        TextBox txtDescription = (TextBox)(gvReport.Rows[i].FindControl("txtDescription"));
                        obj.DiscRmk = txtDescription.Text;

                        string ModifiedBy = Session["UserLoginID"].ToString();
                        string ModifiedByIPAddress = UserInfo.GetIPAddress();

                        reg.saveMVDiscrepancy(obj, ModifiedBy, ModifiedByIPAddress);                        
                        txtDescription.Enabled = false;
                        ddlMVDiscrepency.Enabled = false;                        
                    }
                    if (gvOthers.Rows.Count > 0)
                    {
                        for (i = 0; i < gvOthers.Rows.Count; i++)
                        {
                            Label PerID = new Label();
                            PerID = (Label)(gvOthers.Rows[i].FindControl("lblPID"));
                            obj.PID = Convert.ToInt64(PerID.Text);

                            RadioButton rbtAccept = new RadioButton();
                            rbtAccept = (RadioButton)(gvOthers.Rows[i].FindControl("rbtAccept"));
                            RadioButton rbtReject = new RadioButton();
                            rbtReject = (RadioButton)(gvOthers.Rows[i].FindControl("rbtReject"));
                            if (rbtAccept.Checked == true)
                                obj.Recommend = 'A';
                            else if (rbtReject.Checked == true)
                                obj.Recommend = 'R';
                            else
                                obj.Recommend = 'N';

                            DropDownCheckBoxes ddlMVDiscrepency = new DropDownCheckBoxes();
                            ddlMVDiscrepency = (DropDownCheckBoxes)(gvOthers.Rows[i].FindControl("ddlMVDiscrepency"));
                            if (ddlMVDiscrepency.Texts.SelectBoxCaption != "All")
                            {
                                List<String> MVDiscrepency_list = new List<string>();
                                string strCourseTypeID = "";
                                foreach (System.Web.UI.WebControls.ListItem item in ddlMVDiscrepency.Items)
                                {
                                    if (item.Selected)
                                    {
                                        MVDiscrepency_list.Add(item.Value);
                                    }
                                    DescID = String.Join(",", MVDiscrepency_list.ToArray());
                                }
                            }
                            obj.DiscID = "";
                            obj.DiscID = DescID;

                            DropDownCheckBoxes ddlSubMVDiscrepency = new DropDownCheckBoxes();
                            ddlSubMVDiscrepency = (DropDownCheckBoxes)(gvOthers.Rows[i].FindControl("ddlSubMVDiscrepency"));
                            if (ddlSubMVDiscrepency.Texts.SelectBoxCaption != "All")
                            {
                                List<String> MVSubDiscrepency_list = new List<string>();
                                //string strCourseTypeID = "";
                                foreach (System.Web.UI.WebControls.ListItem item in ddlSubMVDiscrepency.Items)
                                {
                                    if (item.Selected)
                                    {
                                        MVSubDiscrepency_list.Add(item.Value);
                                    }
                                    DescID = String.Join(",", MVSubDiscrepency_list.ToArray());
                                }
                            }
                            obj.SubDiscID = "";
                            obj.SubDiscID = DescID;

                            Label lblSelectedDisc = (Label)(gvOthers.Rows[i].FindControl("lblSelectedDisc"));
                            obj.SubDisc = lblSelectedDisc.Text;

                            TextBox txtDescription = (TextBox)(gvOthers.Rows[i].FindControl("txtDescription"));
                            obj.DiscRmk = txtDescription.Text;

                            string ModifiedBy = Session["UserLoginID"].ToString();
                            string ModifiedByIPAddress = UserInfo.GetIPAddress();

                            reg.saveMVDiscrepancy(obj, ModifiedBy, ModifiedByIPAddress);
                            txtDescription.Enabled = false;
                            ddlMVDiscrepency.Enabled = false;
                        }
                    }
                    if (gvEWS.Rows.Count > 0)
                    {
                        for (i = 0; i < gvEWS.Rows.Count; i++)
                        {
                            Label PerID = new Label();
                            PerID = (Label)(gvEWS.Rows[i].FindControl("lblPID"));
                            obj.PID = Convert.ToInt64(PerID.Text);

                            RadioButton rbtAccept = new RadioButton();
                            rbtAccept = (RadioButton)(gvEWS.Rows[i].FindControl("rbtAccept"));
                            RadioButton rbtReject = new RadioButton();
                            rbtReject = (RadioButton)(gvEWS.Rows[i].FindControl("rbtReject"));
                            if (rbtAccept.Checked == true)
                                obj.Recommend = 'A';
                            else if (rbtReject.Checked == true)
                                obj.Recommend = 'R';
                            else
                                obj.Recommend = 'N';

                            DropDownCheckBoxes ddlMVDiscrepency = new DropDownCheckBoxes();
                            ddlMVDiscrepency = (DropDownCheckBoxes)(gvEWS.Rows[i].FindControl("ddlMVDiscrepency"));
                            if (ddlMVDiscrepency.Texts.SelectBoxCaption != "All")
                            {
                                List<String> MVDiscrepency_list = new List<string>();
                                string strCourseTypeID = "";
                                foreach (System.Web.UI.WebControls.ListItem item in ddlMVDiscrepency.Items)
                                {
                                    if (item.Selected)
                                    {
                                        MVDiscrepency_list.Add(item.Value);
                                    }
                                    DescID = String.Join(",", MVDiscrepency_list.ToArray());
                                }
                            }
                            obj.DiscID = "";
                            obj.DiscID = DescID;

                            DropDownCheckBoxes ddlSubMVDiscrepency = new DropDownCheckBoxes();
                            ddlSubMVDiscrepency = (DropDownCheckBoxes)(gvEWS.Rows[i].FindControl("ddlSubMVDiscrepency"));
                            if (ddlSubMVDiscrepency.Texts.SelectBoxCaption != "All")
                            {
                                List<String> MVSubDiscrepency_list = new List<string>();
                                //string strCourseTypeID = "";
                                foreach (System.Web.UI.WebControls.ListItem item in ddlSubMVDiscrepency.Items)
                                {
                                    if (item.Selected)
                                    {
                                        MVSubDiscrepency_list.Add(item.Value);
                                    }
                                    DescID = String.Join(",", MVSubDiscrepency_list.ToArray());
                                }
                            }
                            obj.SubDiscID = "";
                            obj.SubDiscID = DescID;

                            Label lblSelectedDisc = (Label)(gvEWS.Rows[i].FindControl("lblSelectedDisc"));
                            obj.SubDisc = lblSelectedDisc.Text;

                            TextBox txtDescription = (TextBox)(gvEWS.Rows[i].FindControl("txtDescription"));
                            obj.DiscRmk = txtDescription.Text;

                            string ModifiedBy = Session["UserLoginID"].ToString();
                            string ModifiedByIPAddress = UserInfo.GetIPAddress();

                            reg.saveMVDiscrepancy(obj, ModifiedBy, ModifiedByIPAddress);
                            txtDescription.Enabled = false;
                            ddlMVDiscrepency.Enabled = false;
                        }                       
                    }
                    btnSubmitAll.Visible = false;
                    btnSubmitAll.Enabled = false;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Records saved.');", true);
                    
                    
                    Response.Redirect("frmAllotedChoiceCodeList.aspx?InstituteCode=" + InstCode, true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('The record marked with yellow coloured background are not recommended however you have not selected the Type of discrepancy and or not entered Nature Of Discrepancy in Short, or please select Recommended if no discrepancy found.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Error saving Records.');", true);
                //Response.Redirect("frmAllotedChoiceCodeList.aspx?InstituteCode=" + InstCode, true);
            }
            finally
            {

            }
        }
        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reference the DropDownList.
            DropDownCheckBoxes dropDownList = sender as DropDownCheckBoxes;

            //Get the ID of the DropDownList.
            string id = dropDownList.ID;
            e.ToString();
            //Display the Selected Text of DropDownList.

            int i = 0, cnt = 0;
            MeritListVerificaton obj = new MeritListVerificaton();
            ListItemCollection items = new ListItemCollection();

            for (i = 0; i < gvReport.Rows.Count; i++)
            {
                DropDownCheckBoxes ddlMVDiscrepency = new DropDownCheckBoxes();
                ddlMVDiscrepency = (DropDownCheckBoxes)(gvReport.Rows[i].FindControl("ddlMVDiscrepency"));
                DropDownCheckBoxes ddlSubMVDiscrepency = (gvReport.Rows[i].FindControl("ddlSubMVDiscrepency") as DropDownCheckBoxes);
                Label lblSelected = new Label();
                lblSelected = (Label)(gvReport.Rows[i].FindControl("lblSelected"));
                try
                {
                    string Selected = "";
                    List<String> MVDiscrepency_list = new List<string>();

                    foreach (System.Web.UI.WebControls.ListItem item in ddlMVDiscrepency.Items)
                    {
                        if (item.Selected)
                        {
                            MVDiscrepency_list.Add(item.Text);
                            Int32 DID = Convert.ToInt32(item.Value);
                            Selected = Selected + item.Text + ". ";
                            DataSet ds = reg.getMVSubDiscrepancy(DID);
                           
                            int c = ds.Tables[0].Rows.Count;                            
                            for (int rn = 0; rn < c; rn++)
                            {
                                items.Add(new ListItem(ds.Tables[0].Rows[rn]["MVSubDiscrepancy"].ToString(), ds.Tables[0].Rows[rn]["MVSubDiscrepancyID"].ToString()));
                            }
                            
                            //ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                        }
                        lblSelected.Text = Selected;
                        cnt = MVDiscrepency_list.Count();

                        if (cnt != 0)
                        {
                            ddlMVDiscrepency.Texts.SelectBoxCaption = cnt + " Discrepancy Selected.";
                        }
                        else
                        {
                            ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                        }
                    }
                    ddlSubMVDiscrepency.DataSource = items;
                    ddlSubMVDiscrepency.DataTextField = "Text";
                    ddlSubMVDiscrepency.DataValueField = "Value";
                    ddlSubMVDiscrepency.DataBind();
                    ddlSubMVDiscrepency.Enabled = true;
                    if (ddlMVDiscrepency.Texts.SelectBoxCaption == "")
                    {
                        ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                    }

                    DescID = String.Join(", ", MVDiscrepency_list.ToArray());
                }
                catch (Exception ex)
                {

                }
                if ((gvReport.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvReport.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                {
                    (gvReport.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                }
            }
            if (gvOthers.Rows.Count > 0)
            {
                for (i = 0; i < gvOthers.Rows.Count; i++)
                {
                    DropDownCheckBoxes ddlMVDiscrepency = new DropDownCheckBoxes();
                    ddlMVDiscrepency = (DropDownCheckBoxes)(gvOthers.Rows[i].FindControl("ddlMVDiscrepency"));
                    Label lblSelected = new Label();
                    lblSelected = (Label)(gvOthers.Rows[i].FindControl("lblSelected"));
                    try
                    {
                        string Selected = "";
                        List<String> MVDiscrepency_list = new List<string>();

                        foreach (System.Web.UI.WebControls.ListItem item in ddlMVDiscrepency.Items)
                        {
                            if (item.Selected)
                            {
                                MVDiscrepency_list.Add(item.Text);
                                Int32 DID = Convert.ToInt32(item.Value);
                                Selected = Selected + item.Text + ". ";
                                DropDownCheckBoxes ddlSubMVDiscrepency = (gvOthers.Rows[i].FindControl("ddlSubMVDiscrepency") as DropDownCheckBoxes);
                                ddlSubMVDiscrepency.DataSource = reg.getMVSubDiscrepancy(DID);
                                ddlSubMVDiscrepency.DataTextField = "MVSubDiscrepancy";
                                ddlSubMVDiscrepency.DataValueField = "MVSubDiscrepancyID";
                                ddlSubMVDiscrepency.DataBind();
                                ddlSubMVDiscrepency.Enabled = true;
                                ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                            }
                            lblSelected.Text = Selected;
                            cnt = MVDiscrepency_list.Count();

                            if (cnt != 0)
                            {
                                ddlMVDiscrepency.Texts.SelectBoxCaption = cnt + " Discrepancy Selected.";
                            }
                            else
                            {
                                ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                            }
                        }

                        if (ddlMVDiscrepency.Texts.SelectBoxCaption == "")
                        {
                            ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                        }

                        DescID = String.Join(", ", MVDiscrepency_list.ToArray());
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((gvOthers.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvOthers.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                    {
                        (gvOthers.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                    }
                }
            }
            if (gvEWS.Rows.Count > 0)
            {
                for (i = 0; i < gvEWS.Rows.Count; i++)
                {
                    DropDownCheckBoxes ddlMVDiscrepency = new DropDownCheckBoxes();
                    ddlMVDiscrepency = (DropDownCheckBoxes)(gvEWS.Rows[i].FindControl("ddlMVDiscrepency"));
                    Label lblSelected = new Label();
                    lblSelected = (Label)(gvEWS.Rows[i].FindControl("lblSelected"));
                    try
                    {
                        string Selected = "";
                        List<String> MVDiscrepency_list = new List<string>();

                        foreach (System.Web.UI.WebControls.ListItem item in ddlMVDiscrepency.Items)
                        {
                            if (item.Selected)
                            {
                                MVDiscrepency_list.Add(item.Text);
                                Int32 DID = Convert.ToInt32(item.Value);
                                Selected = Selected + item.Text + ". ";
                                DropDownCheckBoxes ddlSubMVDiscrepency = (gvEWS.Rows[i].FindControl("ddlSubMVDiscrepency") as DropDownCheckBoxes);
                                ddlSubMVDiscrepency.DataSource = reg.getMVSubDiscrepancy(DID);                                
                                ddlSubMVDiscrepency.DataTextField = "MVSubDiscrepancy";
                                ddlSubMVDiscrepency.DataValueField = "MVSubDiscrepancyID";
                                ddlSubMVDiscrepency.DataBind();
                                ddlSubMVDiscrepency.Enabled = true;
                                ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                            }
                            lblSelected.Text = Selected;
                            cnt = MVDiscrepency_list.Count();

                            if (cnt != 0)
                            {
                                ddlMVDiscrepency.Texts.SelectBoxCaption = cnt + " Discrepancy Selected.";
                            }
                            else
                            {
                                ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                            }
                        }

                        if (ddlMVDiscrepency.Texts.SelectBoxCaption == "")
                        {
                            ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                        }

                        DescID = String.Join(", ", MVDiscrepency_list.ToArray());
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((gvEWS.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvEWS.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                    {
                        (gvEWS.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                    }
                }
            }
        }
        protected void SelectedIndexChangedSubDics(object sender, EventArgs e)
        {
            //Reference the DropDownList.
            DropDownCheckBoxes dropDownList = sender as DropDownCheckBoxes;

            //Get the ID of the DropDownList.
            string id = dropDownList.ID;
            e.ToString();
            //Display the Selected Text of DropDownList.

            int i = 0, cnt = 0;
            MeritListVerificaton obj = new MeritListVerificaton();

            for (i = 0; i < gvReport.Rows.Count; i++)
            {
                DropDownCheckBoxes ddlSubMVDiscrepency = new DropDownCheckBoxes();
                ddlSubMVDiscrepency = (DropDownCheckBoxes)(gvReport.Rows[i].FindControl("ddlSubMVDiscrepency"));
                Label lblSelectedDisc = new Label();
                lblSelectedDisc = (Label)(gvReport.Rows[i].FindControl("lblSelectedDisc"));
                try
                {
                    string Selected = "";
                    List<String> MVSubDiscrepency_list = new List<string>();

                    foreach (System.Web.UI.WebControls.ListItem item in ddlSubMVDiscrepency.Items)
                    {
                        if (item.Selected)
                        {
                            MVSubDiscrepency_list.Add(item.Text);                            
                            Selected = Selected + item.Text + ". ";                            
                        }
                        lblSelectedDisc.Text = Selected;
                        cnt = MVSubDiscrepency_list.Count();

                        if (cnt != 0)
                        {
                            ddlSubMVDiscrepency.Texts.SelectBoxCaption = cnt + " Sub Discrepancy Selected.";
                        }
                        else
                        {
                            ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                        }
                    }

                    if (ddlSubMVDiscrepency.Texts.SelectBoxCaption == "")
                    {
                        ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                    }

                    DescID = String.Join(", ", MVSubDiscrepency_list.ToArray());
                }
                catch (Exception ex)
                {

                }
                if ((gvReport.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvReport.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                {
                    (gvReport.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                }
            }
            if (gvOthers.Rows.Count > 0)
            {
                for (i = 0; i < gvOthers.Rows.Count; i++)
                {
                    DropDownCheckBoxes ddlSubMVDiscrepency = new DropDownCheckBoxes();
                    ddlSubMVDiscrepency = (DropDownCheckBoxes)(gvOthers.Rows[i].FindControl("ddlSubMVDiscrepency"));
                    Label lblSelectedDisc = new Label();
                    lblSelectedDisc = (Label)(gvOthers.Rows[i].FindControl("lblSelectedDisc"));
                    try
                    {
                        string Selected = "";
                        List<String> MVSubDiscrepency_list = new List<string>();

                        foreach (System.Web.UI.WebControls.ListItem item in ddlSubMVDiscrepency.Items)
                        {
                            if (item.Selected)
                            {
                                MVSubDiscrepency_list.Add(item.Text);
                                Selected = Selected + item.Text + ". ";
                            }
                            lblSelectedDisc.Text = Selected;
                            cnt = MVSubDiscrepency_list.Count();

                            if (cnt != 0)
                            {
                                ddlSubMVDiscrepency.Texts.SelectBoxCaption = cnt + " Sub Discrepancy Selected.";
                            }
                            else
                            {
                                ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                            }
                        }

                        if (ddlSubMVDiscrepency.Texts.SelectBoxCaption == "")
                        {
                            ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                        }

                        DescID = String.Join(", ", MVSubDiscrepency_list.ToArray());
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((gvOthers.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvOthers.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                    {
                        (gvOthers.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                    }
                }
            }
            if (gvEWS.Rows.Count > 0)
            {
                for (i = 0; i < gvEWS.Rows.Count; i++)
                {
                    DropDownCheckBoxes ddlSubMVDiscrepency = new DropDownCheckBoxes();
                    ddlSubMVDiscrepency = (DropDownCheckBoxes)(gvEWS.Rows[i].FindControl("ddlSubMVDiscrepency"));
                    Label lblSelectedDisc = new Label();
                    lblSelectedDisc = (Label)(gvEWS.Rows[i].FindControl("lblSelectedDisc"));
                    try
                    {
                        string Selected = "";
                        List<String> MVSubDiscrepency_list = new List<string>();

                        foreach (System.Web.UI.WebControls.ListItem item in ddlSubMVDiscrepency.Items)
                        {
                            if (item.Selected)
                            {
                                MVSubDiscrepency_list.Add(item.Text);
                                Selected = Selected + item.Text + ". ";
                            }
                            lblSelectedDisc.Text = Selected;
                            cnt = MVSubDiscrepency_list.Count();

                            if (cnt != 0)
                            {
                                ddlSubMVDiscrepency.Texts.SelectBoxCaption = cnt + " Sub Discrepancy Selected.";
                            }
                            else
                            {
                                ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                            }
                        }

                        if (ddlSubMVDiscrepency.Texts.SelectBoxCaption == "")
                        {
                            ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Sub Discrepancy --";
                        }

                        DescID = String.Join(", ", MVSubDiscrepency_list.ToArray());
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((gvEWS.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvEWS.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                    {
                        (gvEWS.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                    }
                }
            }
        }
        protected void rbtReject_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;

            for (i = 0; i < gvReport.Rows.Count; i++)
            {
                DropDownCheckBoxes ddlMVDiscrepency = (gvReport.Rows[i].FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                DropDownCheckBoxes ddlSubMVDiscrepency = (gvReport.Rows[i].FindControl("ddlSubMVDiscrepency") as DropDownCheckBoxes);
                TextBox txtDescription = (gvReport.Rows[i].FindControl("txtDescription") as TextBox);
                if ((gvReport.Rows[i].FindControl("rbtReject") as RadioButton).Checked == true && (gvReport.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                {
                    txtDescription.Enabled = true;
                    ddlMVDiscrepency.Enabled = true;
                    ddlSubMVDiscrepency.Enabled = true;
                    gvReport.Rows[i].BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    txtDescription.Enabled = false;
                    ddlMVDiscrepency.Enabled = false;
                    ddlSubMVDiscrepency.Enabled = false;
                    (gvReport.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                }
            }
            if (gvOthers.Rows.Count > 0)
            {
                for (i = 0; i < gvOthers.Rows.Count; i++)
                {
                    DropDownCheckBoxes ddlMVDiscrepency = (gvOthers.Rows[i].FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                    DropDownCheckBoxes ddlSubMVDiscrepency = (gvReport.Rows[i].FindControl("ddlSubMVDiscrepency") as DropDownCheckBoxes);
                    TextBox txtDescription = (gvOthers.Rows[i].FindControl("txtDescription") as TextBox);
                    if ((gvOthers.Rows[i].FindControl("rbtReject") as RadioButton).Checked == true && (gvOthers.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                    {
                        txtDescription.Enabled = true;
                        ddlMVDiscrepency.Enabled = true;
                        ddlSubMVDiscrepency.Enabled = true;
                        gvOthers.Rows[i].BackColor = System.Drawing.Color.LightCyan;
                    }
                    else
                    {
                        txtDescription.Enabled = false;
                        ddlMVDiscrepency.Enabled = false;
                        ddlSubMVDiscrepency.Enabled = false;
                        (gvOthers.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                    }
                }
            }
            if (gvEWS.Rows.Count > 0)
            {
                for (i = 0; i < gvEWS.Rows.Count; i++)
                {
                    DropDownCheckBoxes ddlMVDiscrepency = (gvEWS.Rows[i].FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                    DropDownCheckBoxes ddlSubMVDiscrepency = (gvReport.Rows[i].FindControl("ddlSubMVDiscrepency") as DropDownCheckBoxes);
                    TextBox txtDescription = (gvEWS.Rows[i].FindControl("txtDescription") as TextBox);
                    if ((gvEWS.Rows[i].FindControl("rbtReject") as RadioButton).Checked == true && (gvEWS.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                    {
                        txtDescription.Enabled = true;
                        ddlMVDiscrepency.Enabled = true;
                        ddlSubMVDiscrepency.Enabled = true;
                        gvEWS.Rows[i].BackColor = System.Drawing.Color.LightCyan;
                    }
                    else
                    {
                        txtDescription.Enabled = false;
                        ddlMVDiscrepency.Enabled = false;
                        ddlSubMVDiscrepency.Enabled = false;
                        (gvEWS.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                    }
                }
            }
        }
        protected void rbtAccept_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;

            for (i = 0; i < gvReport.Rows.Count; i++)
            {
                DropDownCheckBoxes ddlMVDiscrepency = (gvReport.Rows[i].FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                DropDownCheckBoxes ddlSubMVDiscrepency = (gvReport.Rows[i].FindControl("ddlSubMVDiscrepency") as DropDownCheckBoxes);
                TextBox txtDescription = (gvReport.Rows[i].FindControl("txtDescription") as TextBox);
                if ((gvReport.Rows[i].FindControl("rbtAccept") as RadioButton).Checked == true)
                {
                    txtDescription.Enabled = false;
                    ddlMVDiscrepency.Enabled = false;
                    gvReport.Rows[i].BackColor = System.Drawing.Color.White;
                    txtDescription.Text = "";
                    ddlMVDiscrepency.ClearSelection();
                    ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                    ddlSubMVDiscrepency.ClearSelection();
                    ddlSubMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                    Label lblSelected = new Label();
                    lblSelected = (Label)(gvReport.Rows[i].FindControl("lblSelected"));
                    lblSelected.Text = "";
                    Label lblSelectedDisc = new Label();
                    lblSelectedDisc = (Label)(gvReport.Rows[i].FindControl("lblSelectedDisc"));
                    lblSelectedDisc.Text = "";
                }
                if ((gvReport.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvReport.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                {
                    (gvReport.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                }
            }
            if (gvOthers.Rows.Count > 0)
            {
                for (i = 0; i < gvOthers.Rows.Count; i++)
                {
                    DropDownCheckBoxes ddlMVDiscrepency = (gvOthers.Rows[i].FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                    TextBox txtDescription = (gvOthers.Rows[i].FindControl("txtDescription") as TextBox);
                    if ((gvOthers.Rows[i].FindControl("rbtAccept") as RadioButton).Checked == true)
                    {
                        txtDescription.Enabled = false;
                        ddlMVDiscrepency.Enabled = false;
                        gvOthers.Rows[i].BackColor = System.Drawing.Color.White;
                        txtDescription.Text = "";
                        ddlMVDiscrepency.ClearSelection();
                        ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                        Label lblSelected = new Label();
                        lblSelected = (Label)(gvOthers.Rows[i].FindControl("lblSelected"));
                        lblSelected.Text = "";
                    }
                    if ((gvOthers.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvOthers.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                    {
                        (gvOthers.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                    }
                }
            }
            if (gvEWS.Rows.Count > 0)
            {
                for (i = 0; i < gvEWS.Rows.Count; i++)
                {
                    DropDownCheckBoxes ddlMVDiscrepency = (gvEWS.Rows[i].FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                    TextBox txtDescription = (gvEWS.Rows[i].FindControl("txtDescription") as TextBox);
                    if ((gvEWS.Rows[i].FindControl("rbtAccept") as RadioButton).Checked == true)
                    {
                        txtDescription.Enabled = false;
                        ddlMVDiscrepency.Enabled = false;
                        gvEWS.Rows[i].BackColor = System.Drawing.Color.White;
                        txtDescription.Text = "";
                        ddlMVDiscrepency.ClearSelection();
                        ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                        Label lblSelected = new Label();
                        lblSelected = (Label)(gvEWS.Rows[i].FindControl("lblSelected"));
                        lblSelected.Text = "";
                    }
                    if ((gvEWS.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvEWS.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                    {
                        (gvEWS.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                    }
                }
            }
        }

    }
}