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
    public partial class frmMeritListVerificationRODTE : System.Web.UI.Page
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

                    //gvReport.DataSource = reg.getAllotmentReportForSO(ChoiceCode, "S");
                    //gvReport.DataBind();

                    refreshdata();
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

        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownCheckBoxes ddlMVDiscrepency = (e.Row.FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                ddlMVDiscrepency.DataSource = reg.getMasterMVDiscrepancy();
                ddlMVDiscrepency.DataTextField = "MVDiscrepancyName";
                ddlMVDiscrepency.DataValueField = "MVDiscrepancyID";
                ddlMVDiscrepency.DataBind();
                ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                //Add Default Item in the DropDownList
                //ddlMVDiscrepency.Items.Insert(0, new ListItem("Please select", "0"));

                //Select the Discrepency in DropDownList
                string Discrepency = (e.Row.FindControl("lblMVDiscrepency") as Label).Text;
                if (Discrepency != "")
                {
                    string[] tmp = Discrepency.Split(',');
                    int len = tmp.Length;
                    for (int i = 0; i < len; i++)
                    {
                        ddlMVDiscrepency.Items.FindByValue(tmp[i]).Selected = true;
                    }
                    ddlMVDiscrepency.Texts.SelectBoxCaption = len + " Discrepancy Selected.";
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
                
                //int DID= Convert.ToInt32(Discrepency);
                //ddlMVDiscrepency.Items.FindByValue(Discrepency).Selected = true;

                //RadioButton rbtReject = new RadioButton();
                //rbtReject = (RadioButton)(gvReport.Rows[i].FindControl("rbtReject"));
                //string rbtValue = (e.Row.FindControl("rbtReject") as RadioButton).Checked==true;
                TextBox txtDescription = (e.Row.FindControl("txtDescription") as TextBox);
                RadioButton rbtReject = (e.Row.FindControl("rbtReject") as RadioButton);
                RadioButton rbtAccept = (e.Row.FindControl("rbtAccept") as RadioButton);
                //if ((e.Row.FindControl("rbtReject") as RadioButton).Checked == false)
                Label lblAdmissionStatus  = (e.Row.FindControl("lblAdmissionStatus") as Label);
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string PID = drv["PersonalID"].ToString();                    
                    hl.NavigateUrl = "frmViewDocuments.aspx?PID=" + PID + "&Code=" + PID + "&ApplicationID=DEN21" + PID;                    
                }
                string AdmStatus = (e.Row.FindControl("lblAdmissionStatus") as Label).Text;

                string ChoiceCode = Request.QueryString["ChoiceCode"].ToString();
                Int64 InstCode = Convert.ToInt64(ChoiceCode.Substring(0, 4));
                DataSet ds = new DataSet();
                ds = reg.getVerifiedByInst(InstCode, 'R');
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
                    hl.Visible = false;
                    rbtReject.Checked = true;
                    rbtAccept.Checked = false;
                    rbtAccept.Enabled = false;
                    txtDescription.Enabled = false;
                    txtDescription.Text = "Admission Cancelled";
                    ddlMVDiscrepency.Enabled = false;
                    //string Dis = "6";
                    //ddlMVDiscrepency.Items.FindByValue(Dis).Selected = true;
                    lblAdmissionStatus.ForeColor= System.Drawing.Color.Black;
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
                    RadioButton rbtReject = new RadioButton();
                    rbtReject = (RadioButton)(gvReport.Rows[i].FindControl("rbtReject"));
                    if (rbtReject.Checked == true && (gvReport.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                    {
                        //if(ddlMVDiscrepency.SelectedIndex != 0)
                        //{
                            if (txtDescription.Text != "")
                            {

                            }
                            else
                            {
                                gvReport.Rows[i].BackColor = System.Drawing.Color.LightYellow;
                                MendetFlg = MendetFlg + 1;
                            }
                        //}
                        //else
                        //{
                        //    gvReport.Rows[i].BackColor = System.Drawing.Color.LightYellow;
                        //    MendetFlg = MendetFlg + 1;
                        //}
                    }                    
                }
                saveDiscrepency();
                
                btnSubmitAll.Visible = false;
                btnSubmitAll.Enabled = false;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Error saving Records.');", true);
            }
        }
        public void saveDiscrepency()
        {
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
                        //DescID = ddlMVDiscrepency.SelectedValue.ToString();
                        obj.DiscID = "";
                        obj.DiscID = DescID;

                        TextBox txtDescription = (TextBox)(gvReport.Rows[i].FindControl("txtDescription"));
                        obj.DiscRmk = txtDescription.Text;

                        string ModifiedBy = Session["UserLoginID"].ToString();
                        string ModifiedByIPAddress = UserInfo.GetIPAddress();

                        reg.saveMVDiscrepancy(obj, ModifiedBy, ModifiedByIPAddress);                        
                        txtDescription.Enabled = false;
                        ddlMVDiscrepency.Enabled = false;
                        //gvReport.Rows[i].BackColor = System.Drawing.Color.White;
                    }
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Records saved.');", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('The record marked with yellow coloured background are not recommended however you have not selected the Type of discrepancy and or not entered Nature Of Discrepancy in Short, or please select Recommended if no discrepancy found.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Error saving Records.');", true);
            }
        }

        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Reference the DropDownList.
            DropDownCheckBoxes dropDownList = sender as DropDownCheckBoxes;

            ////Get the ID of the DropDownList.
            string id = dropDownList.ID;
            e.ToString();
            ////Display the Selected Text of DropDownList.
            //DescID = dropDownList.SelectedValue.ToString();
            int i = 0, cnt = 0;
            MeritListVerificaton obj = new MeritListVerificaton();

            for (i = 0; i < gvReport.Rows.Count; i++)
            {
                DropDownCheckBoxes ddlMVDiscrepency = new DropDownCheckBoxes();
                ddlMVDiscrepency = (DropDownCheckBoxes)(gvReport.Rows[i].FindControl("ddlMVDiscrepency"));
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
                            Selected = Selected + item.Text + ". ";
                        }
                        lblSelected.Text = Selected;
                        cnt = MVDiscrepency_list.Count();
                        //ddlMVDiscrepency.Texts.SelectBoxCaption = String.Join(", ", MVDiscrepency_list.ToArray());
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
                    //shInfo.Visible = true;
                    //shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
                if ((gvReport.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvReport.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                {
                    (gvReport.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                }
            }
        }
        protected void rbtReject_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;

            for (i = 0; i < gvReport.Rows.Count; i++)
            {
                DropDownCheckBoxes ddlMVDiscrepency = (gvReport.Rows[i].FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                TextBox txtDescription = (gvReport.Rows[i].FindControl("txtDescription") as TextBox);
                if ((gvReport.Rows[i].FindControl("rbtReject") as RadioButton).Checked == true && (gvReport.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                {
                    txtDescription.Enabled = true;
                    ddlMVDiscrepency.Enabled = true;
                    gvReport.Rows[i].BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    txtDescription.Enabled = false;
                    ddlMVDiscrepency.Enabled = false;
                    (gvReport.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                }
            }
        }
        protected void rbtAccept_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;

            for (i = 0; i < gvReport.Rows.Count; i++)
            {
                DropDownCheckBoxes ddlMVDiscrepency = (gvReport.Rows[i].FindControl("ddlMVDiscrepency") as DropDownCheckBoxes);
                TextBox txtDescription = (gvReport.Rows[i].FindControl("txtDescription") as TextBox);
                if ((gvReport.Rows[i].FindControl("rbtAccept") as RadioButton).Checked == true)
                {
                    txtDescription.Enabled = false;
                    ddlMVDiscrepency.Enabled = false;                    
                    gvReport.Rows[i].BackColor = System.Drawing.Color.White;
                    txtDescription.Text = "";
                    ddlMVDiscrepency.ClearSelection();
                    ddlMVDiscrepency.Texts.SelectBoxCaption = "-- Select Discrepancy Type --";
                    Label lblSelected = new Label();
                    lblSelected = (Label)(gvReport.Rows[i].FindControl("lblSelected"));
                    lblSelected.Text = "";
                }
                else
                {
                    //txtDescription.Enabled = true;
                    //ddlMVDiscrepency.Enabled = true;
                }
                if ((gvReport.Rows[i].FindControl("rbtReject") as RadioButton).Checked != true && (gvReport.Rows[i].FindControl("lblAdmissionStatus") as Label).Text != "Cancelled")
                {
                    (gvReport.Rows[i].FindControl("rbtAccept") as RadioButton).Checked = true;
                }
            }
        }

           
    }
}