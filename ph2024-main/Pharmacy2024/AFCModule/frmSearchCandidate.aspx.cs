using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmSearchCandidate : System.Web.UI.Page
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
                txtCandidateName.Attributes.Add("onBlur", "makeUpper()");
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string strQuery = "";

                if (txtCandidateName.Text.Length > 0)
                {
                    for (int i = 0; i < txtCandidateName.Text.Split(" ".ToCharArray()).Length; i++)
                    {
                        if (strQuery.Length == 0)
                        {
                            strQuery = "CandidateName LIKE '%" + txtCandidateName.Text.Split(" ".ToCharArray())[i] + "%'";
                        }
                        else
                        {
                            strQuery += " AND CandidateName LIKE '%" + txtCandidateName.Text.Split(" ".ToCharArray())[i] + "%'";
                        }
                    }
                }
                if (txtDOB.Text.Length > 0)
                {
                    if (strQuery.Length == 0)
                    {
                        strQuery = "DOB = '" + txtDOB.Text + "'";
                    }
                    else
                    {
                        strQuery += " AND DOB = '" + txtDOB.Text + "'";
                    }
                }
                if (txtMobileNo.Text.Length > 0)
                {
                    if (strQuery.Length == 0)
                    {
                        strQuery = "MobileNo = '" + DataEncryption.EncryptDataByEncryptionKey(txtMobileNo.Text) + "'";
                    }
                    else
                    {
                        strQuery += " AND MobileNo = '" + DataEncryption.EncryptDataByEncryptionKey(txtMobileNo.Text) + "'";
                    }
                }
                if (txtEMailID.Text.Length > 0)
                {
                    if (strQuery.Length == 0)
                    {
                        strQuery = "EMailID = '" + txtEMailID.Text + "'";
                    }
                    else
                    {
                        strQuery += " AND EMailID = '" + txtEMailID.Text + "'";
                    }
                }
                if (txtApplicationNo.Text.Length > 0)
                {
                    if (strQuery.Length == 0)
                    {
                        strQuery = "ApplicationNo = '" + txtApplicationNo.Text + "'";
                    }
                    else
                    {
                        strQuery += " AND ApplicationNo = '" + txtApplicationNo.Text + "'";
                    }
                }

                if (strQuery.Length > 0)
                {
                    gvApplicationDetails.DataSource = reg.searchCandidate(strQuery);
                    gvApplicationDetails.DataBind();

                    if (gvApplicationDetails.Rows.Count > 0)
                    {
                        ContentBox2.Visible = true;

                        for (Int32 i = 0; i < gvApplicationDetails.Rows.Count; i++)
                        {
                            gvApplicationDetails.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                        }
                    }
                    else
                    {
                        ContentBox2.Visible = false;
                        shInfo.SetMessage("No Records Found.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("Please Enter atleast one parameter.", ShowMessageType.Information);
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