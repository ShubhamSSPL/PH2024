using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmControlReportQuery : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public List<string> LRejectedKeyWordList;
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
            LRejectedKeyWordList = new List<string>();
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.gvList);
            if (!IsPostBack)
            {
                try
                {
                    LRejectedKeyWordList = new List<string>();
                    gvList.DataSource = reg.getReportsList();
                    gvList.DataBind();

                    ddlTableView.DataSource = reg.getTableViewList();
                    ddlTableView.DataTextField = "name";
                    ddlTableView.DataValueField = "name";
                    ddlTableView.DataBind();
                    ddlTableView.Items.Insert(0, new ListItem("-- Select Table/View --", "0"));

                    if (gvList.Rows.Count > 0)
                    {
                        cbReportsList.Visible = true;

                        for (Int32 i = 0; i < gvList.Rows.Count; i++)
                        {
                            gvList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        }
                    }
                    else
                    {
                        cbReportsList.Visible = false;
                    }

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;

                    DataSet RejectedKeyWordList = reg.getRejectedKeyWordList();
                    System.Text.StringBuilder RejectedKeyWordData = new System.Text.StringBuilder();

                    for (int i = 0; i < RejectedKeyWordList.Tables[0].Rows.Count; i++)
                    {
                        RejectedKeyWordData.Append("" + RejectedKeyWordList.Tables[0].Rows[i]["KeyWordName"].ToString() + ",");
                    }
                    RejectedKeyWordData.Length = RejectedKeyWordData.Length - 1;
                    rejectedkeywordlist.InnerHtml = RejectedKeyWordData.ToString();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void ddlTableView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlTableView.SelectedValue == "0")
                {
                    lbColumn.Items.Clear();
                }
                else
                {
                    lbColumn.DataSource = reg.getColumnsList(ddlTableView.SelectedValue);
                    lbColumn.DataTextField = "name";
                    lbColumn.DataValueField = "name";
                    lbColumn.DataBind();
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string sql = txtReportQuery.Text.ToString();
                bool flag = false;
                List<string> tempList = new List<string>();
                string userenteredwrongwords = " ";
                DataSet RejectedKeyWordList = reg.getRejectedKeyWordList();
                for (Int32 i = 0; i < RejectedKeyWordList.Tables[0].Rows.Count; i++)
                {
                    LRejectedKeyWordList.Add(RejectedKeyWordList.Tables[0].Rows[i]["KeyWordName"].ToString());
                }
                sql = sql.ToUpper();
                string[] partsofwords = sql.Split(' ');
                System.Text.StringBuilder RejectedKeyWordData = new System.Text.StringBuilder();
                for (Int32 i = 0; i < RejectedKeyWordList.Tables[0].Rows.Count; i++)
                {
                    RejectedKeyWordData.Append("" + RejectedKeyWordList.Tables[0].Rows[i]["KeyWordName"].ToString() + ",");
                }
                userenteredwrongwords = "";
                for (Int32 i = 0; i < partsofwords.Length; i++)
                {
                    tempList = LRejectedKeyWordList.Where(x => x.Equals(partsofwords[i].ToString())).ToList();
                    if (tempList.Count > 0)
                    {
                        flag = true;
                        foreach (string value in tempList)
                        {
                            userenteredwrongwords = userenteredwrongwords + " " + value + " , ";
                        }
                        break;
                    }
                }

                if (flag == false)
                {
                    string ReportName = txtReportName.Text;
                    string ReportQuery = txtReportQuery.Text;

                    if (ReportQuery.Contains("DELETE ") || ReportQuery.Contains("UPDATE ") || ReportQuery.Contains("CREATE ") || ReportQuery.Contains("ALTER ") || ReportQuery.Contains("DROP ") || ReportQuery.Contains("TRUNCATE "))
                    {
                        shInfo.SetMessage("Report Query can not contain Keywords like DELETE, UPDATE, CREATE, ALTER, DROP, TRUNCATE etc.", ShowMessageType.Information);
                    }
                    else
                    {
                        if (reg.saveReportDetails(ReportName, ReportQuery, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                        {
                            gvList.DataSource = reg.getReportsList();
                            gvList.DataBind();

                            if (gvList.Rows.Count > 0)
                            {
                                cbReportsList.Visible = true;

                                for (Int32 i = 0; i < gvList.Rows.Count; i++)
                                {
                                    gvList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                                }
                            }
                            else
                            {
                                cbReportsList.Visible = false;
                            }

                            txtReportName.Text = "";
                            txtReportQuery.Text = "";

                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                            btnCancel.Visible = false;

                            shInfo.SetMessage("Report Saved Successfully.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                        }
                    }
                }
                else
                {
                    userenteredwrongwords = userenteredwrongwords.Substring(0, userenteredwrongwords.Length - 2);
                    ScrollgvResultSet.InnerHtml = "<div class=fk-fail-msg>Please Don't Use" + userenteredwrongwords + ".</div>";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string sql = txtReportQuery.Text.ToString();
                bool flag = false;
                List<string> tempList = new List<string>();
                string userenteredwrongwords = " ";
                DataSet RejectedKeyWordList = reg.getRejectedKeyWordList();
                for (Int32 i = 0; i < RejectedKeyWordList.Tables[0].Rows.Count; i++)
                {
                    LRejectedKeyWordList.Add(RejectedKeyWordList.Tables[0].Rows[i]["KeyWordName"].ToString());
                }
                sql = sql.ToUpper();
                string[] partsofwords = sql.Split(' ');
                System.Text.StringBuilder RejectedKeyWordData = new System.Text.StringBuilder();
                for (Int32 i = 0; i < RejectedKeyWordList.Tables[0].Rows.Count; i++)
                {
                    RejectedKeyWordData.Append("" + RejectedKeyWordList.Tables[0].Rows[i]["KeyWordName"].ToString() + ",");
                }
                userenteredwrongwords = "";
                for (Int32 i = 0; i < partsofwords.Length; i++)
                {
                    tempList = LRejectedKeyWordList.Where(x => x.Equals(partsofwords[i].ToString())).ToList();
                    if (tempList.Count > 0)
                    {
                        flag = true;
                        foreach (string value in tempList)
                        {
                            userenteredwrongwords = userenteredwrongwords + " " + value + " , ";
                        }
                        break;
                    }
                }

                if (flag == false)
                {
                    Int64 ReportID = Convert.ToInt64(hdnReportID.Value);
                    string ReportName = txtReportName.Text;
                    string ReportQuery = txtReportQuery.Text;
                    string ModifiedBy = Session["UserLoginID"].ToString();
                    string ModifiedByIPAddress = UserInfo.GetIPAddress();

                    if (ReportQuery.Contains("DELETE ") || ReportQuery.Contains("UPDATE ") || ReportQuery.Contains("CREATE ") || ReportQuery.Contains("ALTER ") || ReportQuery.Contains("DROP ") || ReportQuery.Contains("TRUNCATE "))
                    {
                        shInfo.SetMessage("Report Query can not contain Keywords like DELETE, UPDATE, CREATE, ALTER, DROP, TRUNCATE etc.", ShowMessageType.Information);
                    }
                    else
                    {
                        if (reg.editReportDetails(ReportID, ReportName, ReportQuery, ModifiedBy, ModifiedByIPAddress))
                        {
                            gvList.DataSource = reg.getReportsList();
                            gvList.DataBind();

                            if (gvList.Rows.Count > 0)
                            {
                                cbReportsList.Visible = true;

                                for (Int32 i = 0; i < gvList.Rows.Count; i++)
                                {
                                    gvList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                                }
                            }
                            else
                            {
                                cbReportsList.Visible = false;
                            }

                            txtReportName.Text = "";
                            txtReportQuery.Text = "";

                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                            btnCancel.Visible = false;

                            shInfo.SetMessage("Report Updated Successfully.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                        }
                    }
                }
                else
                {
                    userenteredwrongwords = userenteredwrongwords.Substring(0, userenteredwrongwords.Length - 2);
                    ScrollgvResultSet.InnerHtml = "<div class=fk-fail-msg>Please Don't Use" + userenteredwrongwords + ".</div>";
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                txtReportName.Text = "";
                txtReportQuery.Text = "";

                btnAdd.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 ReportID = Convert.ToInt64(((Label)gvList.Rows[e.RowIndex].Cells[4].FindControl("lblReportID")).Text);

                if (reg.deleteReportDetails(ReportID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    gvList.DataSource = reg.getReportsList();
                    gvList.DataBind();

                    if (gvList.Rows.Count > 0)
                    {
                        cbReportsList.Visible = true;

                        for (Int32 i = 0; i < gvList.Rows.Count; i++)
                        {
                            gvList.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        }
                    }
                    else
                    {
                        cbReportsList.Visible = false;
                    }

                    txtReportName.Text = "";
                    txtReportQuery.Text = "";

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;

                    shInfo.SetMessage("Report Deleted Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 ReportID = Convert.ToInt64(((Label)gvList.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].FindControl("lblReportID")).Text);
                string FileName = gvList.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                FileName = FileName.Trim().Replace(' ', '_');
                DataSet ds = reg.executeReport(ReportID);
                if (e.CommandName == "Excel")
                {
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GridView gvReport = new GridView();
                    gvReport.DataSource = ds;
                    gvReport.DataBind();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    gvReport.RenderControl(hw);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 ReportID = Convert.ToInt64(((Label)gvList.Rows[e.NewSelectedIndex].Cells[4].FindControl("lblReportID")).Text);
                DataSet ds = reg.getReportDetails(ReportID);

                hdnReportID.Value = ReportID.ToString();
                txtReportName.Text = ds.Tables[0].Rows[0]["ReportName"].ToString();
                txtReportQuery.Text = ds.Tables[0].Rows[0]["ReportQuery"].ToString();

                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}