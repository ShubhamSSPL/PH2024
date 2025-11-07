using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.SupportModule
{
    public partial class frmSearchCandidate : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session["UserLoginID"] = "ADMINSNEHDEEP";
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (Session["Error"] != null)
            {
                shInfo.SetMessage(Session["Error"].ToString(), ShowMessageType.Information);
                Session["Error"] = null;
            }


            if (!IsPostBack)
            {
                try
                {
                    txtCandidateName.Attributes.Add("onBlur", "makeUpper()");
                    txtFatherName.Attributes.Add("onBlur", "makeUpper()");
                    txtMotherName.Attributes.Add("onBlur", "makeUpper()");
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
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
                if (txtemail.Text.Length > 0)
                {
                    if (strQuery.Length == 0)
                    {
                        strQuery = "EMailID = '" + txtemail.Text + "'";
                    }
                    else
                    {
                        strQuery += " AND EMailID = '" + txtemail.Text + "'";
                    }
                }
                if (txtApplicationID.Text.Length > 0)
                {
                    if (strQuery.Length == 0)
                    {
                        strQuery = "ApplicationNo = '" + txtApplicationID.Text + "'";
                    }
                    else
                    {
                        strQuery += " AND ApplicationNo = '" + txtApplicationID.Text + "'";
                    }
                }
                if (txtMotherName.Text.Length > 0)
                {
                    if (strQuery.Length == 0)
                    {
                        strQuery = "MotherName = '" + txtMotherName.Text + "'";
                    }
                    else
                    {
                        strQuery += " AND MotherName = '" + txtMotherName.Text + "'";
                    }
                }
                if (txtFatherName.Text.Length > 0)
                {
                    if (strQuery.Length == 0)
                    {
                        strQuery = "FatherName = '" + txtFatherName.Text + "'";
                    }
                    else
                    {
                        strQuery += " AND FatherName = '" + txtFatherName.Text + "'";
                    }
                }

                if (strQuery.Length > 0)
                {
                    gvReport.DataSource = reg.searchCandidate(strQuery);
                    gvReport.DataBind();

                    if (gvReport.Rows.Count > 0)
                    {
                        // ContentBox2.Visible = true;

                        for (Int32 i = 0; i < gvReport.Rows.Count; i++)
                        {
                            gvReport.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";
                            gvReport.Rows[i].Cells[6].Text = DataEncryption.DecryptDataByEncryptionKey(gvReport.Rows[i].Cells[6].Text);
                           

                        }
                    }
                    else
                    {
                        // ContentBox2.Visible = false;
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