using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmControlFAQs : System.Web.UI.Page
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
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;

                    gvFAQList.DataSource = reg.getFAQs();
                    gvFAQList.DataBind();

                    for (Int32 i = 0; i < gvFAQList.Rows.Count; i++)
                    {
                        gvFAQList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";
                    }

                    ddlSeqNo.Items.Clear();
                    ddlSeqNo.Items.Insert(0, new ListItem("-- Select Seq No --", "0"));
                    for (Int32 i = 1; i <= gvFAQList.Rows.Count + 1; i++)
                    {
                        ddlSeqNo.Items.Add(i.ToString());
                    }
                    ddlSeqNo.SelectedIndex = ddlSeqNo.Items.Count - 1;
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (reg.saveFAQs(txtQuestion.Text, txtAnswer.Text, ddlFAQType.SelectedValue, Convert.ToInt32(ddlSeqNo.SelectedValue), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    shInfo.SetMessage("FAQ's  Add Successfully.", ShowMessageType.Information);
                    gvFAQList.DataSource = reg.getFAQs();
                    gvFAQList.DataBind();

                    for (Int32 i = 0; i < gvFAQList.Rows.Count; i++)
                    {
                        gvFAQList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";
                    }

                    ddlSeqNo.Items.Clear();
                    ddlSeqNo.Items.Insert(0, new ListItem("-- Select Seq No --", "0"));
                    for (Int32 i = 1; i <= gvFAQList.Rows.Count + 1; i++)
                    {
                        ddlSeqNo.Items.Add(i.ToString());
                    }
                    ddlSeqNo.SelectedIndex = ddlSeqNo.Items.Count - 1;

                    txtQuestion.Text = "";
                    txtAnswer.Text = "";
                    ddlFAQType.SelectedValue = "0";
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (reg.editFAQs(Convert.ToInt64(hdnFAQID.Value), txtQuestion.Text, txtAnswer.Text, ddlFAQType.SelectedValue, Convert.ToInt32(ddlSeqNo.SelectedValue), Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    shInfo.SetMessage("FAQ's  Update Successfully.", ShowMessageType.Information);
                    gvFAQList.DataSource = reg.getFAQs();
                    gvFAQList.DataBind();

                    for (Int32 i = 0; i < gvFAQList.Rows.Count; i++)
                    {
                        gvFAQList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";
                    }

                    ddlSeqNo.Items.Clear();
                    ddlSeqNo.Items.Insert(0, new ListItem("-- Select Seq No --", "0"));
                    for (Int32 i = 1; i <= gvFAQList.Rows.Count + 1; i++)
                    {
                        ddlSeqNo.Items.Add(i.ToString());
                    }
                    ddlSeqNo.SelectedIndex = ddlSeqNo.Items.Count - 1;

                    txtQuestion.Text = "";
                    txtAnswer.Text = "";
                    ddlFAQType.SelectedValue = "0";

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                gvFAQList.DataSource = reg.getFAQs();
                gvFAQList.DataBind();

                for (Int32 i = 0; i < gvFAQList.Rows.Count; i++)
                {
                    gvFAQList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";
                }

                ddlSeqNo.Items.Clear();
                ddlSeqNo.Items.Insert(0, new ListItem("-- Select Seq No --", "0"));
                for (Int32 i = 1; i <= gvFAQList.Rows.Count + 1; i++)
                {
                    ddlSeqNo.Items.Add(i.ToString());
                }
                ddlSeqNo.SelectedIndex = ddlSeqNo.Items.Count - 1;

                txtQuestion.Text = "";
                txtAnswer.Text = "";
                ddlFAQType.SelectedValue = "0";

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
        protected void gvFAQList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 FAQID = Convert.ToInt64(((Label)gvFAQList.Rows[e.RowIndex].Cells[0].FindControl("lblFAQID")).Text);

                if (reg.deleteFAQs(FAQID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    shInfo.SetMessage("FAQ's  delete Successfully.", ShowMessageType.Information);
                    gvFAQList.DataSource = reg.getFAQs();
                    gvFAQList.DataBind();

                    for (Int32 i = 0; i < gvFAQList.Rows.Count; i++)
                    {
                        gvFAQList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";
                    }

                    ddlSeqNo.Items.Clear();
                    ddlSeqNo.Items.Insert(0, new ListItem("-- Select Seq No --", "0"));
                    for (Int32 i = 1; i <= gvFAQList.Rows.Count + 1; i++)
                    {
                        ddlSeqNo.Items.Add(i.ToString());
                    }
                    ddlSeqNo.SelectedIndex = ddlSeqNo.Items.Count - 1;

                    txtQuestion.Text = "";
                    txtAnswer.Text = "";
                    ddlFAQType.SelectedValue = "0";

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    ContentTable2.Focus();
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
        protected void gvFAQList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 FAQID = Convert.ToInt64(((Label)gvFAQList.Rows[e.NewSelectedIndex].Cells[0].FindControl("lblFAQID")).Text);
                DataSet ds = reg.getFAQDetails(FAQID);

                hdnFAQID.Value = FAQID.ToString();
                txtQuestion.Text = ds.Tables[0].Rows[0]["Question"].ToString();
                txtAnswer.Text = ds.Tables[0].Rows[0]["Answer"].ToString();
                ddlFAQType.SelectedValue = ds.Tables[0].Rows[0]["FAQType"].ToString();
                ddlSeqNo.Items.Clear();
                ddlSeqNo.Items.Insert(0, new ListItem("-- Select Seq No --", "0"));
                for (Int32 i = 1; i <= gvFAQList.Rows.Count; i++)
                {
                    ddlSeqNo.Items.Add(i.ToString());
                }
                ddlSeqNo.SelectedValue = ds.Tables[0].Rows[0]["SeqNo"].ToString();

                gvFAQList.DataSource = reg.getFAQs();
                gvFAQList.DataBind();

                for (Int32 i = 0; i < gvFAQList.Rows.Count; i++)
                {
                    gvFAQList.Rows[i].Cells[1].Text = (i + 1).ToString() + ".";
                }

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