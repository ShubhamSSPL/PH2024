using BusinessLayer;
using EntityModel;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.CandidateModule
{
    public partial class frmBankDetails : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {

                SessionData objSessionData = (SessionData)Session["SessionData"];
                tblEnterBankButtonDetails.Visible = false;
                tblEnterBankDetails.Visible = false;
                tblAccountDetails.Visible = false;
                if (reg.CheckBankDetailsStatus(objSessionData.PID))
                {
                    tblEnterBankButtonDetails.Visible = true;
                    tblEnterBankDetails.Visible = true;
                }
                else
                {
                    DataSet ds = reg.GetBankDetailsStatus(objSessionData.PID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["AadhaarNo"].ToString().Length < 3)
                                lblAadharNo.Text = "-";
                            else
                                lblAadharNo.Text = dr["AadhaarNo"].ToString();
                            lblBankName.Text = dr["BankName"].ToString();
                            lblAccountNo.Text = dr["BankAccountNo"].ToString();
                            lblIFSCCode.Text = dr["IFSCCode"].ToString();
                            lblHolderName.Text = dr["AccountHolderName"].ToString();
                        }
                        tblAccountDetails.Visible = true;

                    }
                    else
                    {
                        shInfo.SetMessage("There is some problem in Data. Please try again.", ShowMessageType.Information);

                    }


                }
            }
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                SessionData objSessionData = (SessionData)Session["SessionData"];
                System.Web.HttpBrowserCapabilities browser = Request.Browser;
                Int64 aadharno = 0;
                if (txtAadhaarNumber.Text.Length > 0)
                {
                    aadharno = Convert.ToInt64(txtAadhaarNumber.Text);
                }
                if (reg.SaveBankDetails(objSessionData.PID, aadharno, txtBankName.Text, txtIFSCCode.Text, txtBankAccountNo.Text, txtAccountHolderName.Text, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), browser.IsMobileDevice.ToString()))
                {
                    shInfo.SetMessage("Bank Details Saved Sucessfully.", ShowMessageType.Information);
                    Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx?BankDetails=Y", true);
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
            tblEnterBankButtonDetails.Visible = true;
            tblEnterBankDetails.Visible = true;
            tblAccountDetails.Visible = false;
        }
        protected void btnSkip_Click(object sender, EventArgs e)
        {
            SessionData objSessionData = (SessionData)Session["SessionData"];
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            reg.SaveBankDetailsSkip(objSessionData.PID, Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), browser.IsMobileDevice.ToString());
            objSessionData.BankDetailsSkip = 'Y';
            Response.Redirect("../ApplicationPages/WelcomePageCandidate.aspx", true);
        }
    }
}