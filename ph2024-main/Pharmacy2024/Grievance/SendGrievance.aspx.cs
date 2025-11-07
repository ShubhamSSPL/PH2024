using BusinessLayer;
using EntityModel;
using Org.BouncyCastle.Asn1.Tsp;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.Grievance
{
    public partial class SendGrievance : System.Web.UI.Page
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (!IsPostBack)
            {
                try
                {
                    SessionData objSessionData = (SessionData)Session["SessionData"];
                    if (reg.checkActiveTicketExist(objSessionData.PID))
                    {
                        shInfo.SetMessage("Your Previous Ticket is Under Process, You can not Raise New Ticket.", ShowMessageType.Information);

                        ContentTable2.Visible = false;
                    }
                    else
                    {
                        txtApplicationID.Text = Session["UserLoginID"].ToString();
                        ContentTable2.Visible = true;
                        LoadMasters();
                        onPageLoad();
                    }
                }
                catch (System.Threading.ThreadAbortException t)
                {
                }
                catch (Exception ex)
                {
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void LoadMasters()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                ddlGrievanceCategory.DataSource = new BusinessServiceImp().getMasterGrievanceCategory(Convert.ToInt32(Session["UserTypeID"]));
                ddlGrievanceCategory.DataTextField = "GrievanceCategory";
                ddlGrievanceCategory.DataValueField = "GrievanceCategoryID";
                ddlGrievanceCategory.DataBind();
                ddlGrievanceCategory.Items.Insert(0, new ListItem("-- Select --", "-1"));
            }
            catch (System.Threading.ThreadAbortException t)
            {
            }
            catch (Exception ex)
            {
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void onPageLoad()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int16 GrievanceCategoryID = Convert.ToInt16(ddlGrievanceCategory.SelectedValue);
                if (GrievanceCategoryID == 99)
                {
                    trOtherGrievanceCategory.Visible = true;
                }
                else
                {
                    trOtherGrievanceCategory.Visible = false;
                }
            }
            catch (System.Threading.ThreadAbortException t)
            {
            }
            catch (Exception ex)
            {
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlGrievanceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int16 GrievanceCategoryID = Convert.ToInt16(ddlGrievanceCategory.SelectedValue);

                if (GrievanceCategoryID == 99)
                {
                    trOtherGrievanceCategory.Visible = true;
                }
                else
                {
                    trOtherGrievanceCategory.Visible = false;
                }

                txtOtherGrievanceCategory.Text = "";
            }
            catch (System.Threading.ThreadAbortException t)
            {
            }
            catch (Exception ex)
            {
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string ApplicationID = txtApplicationID.Text;
                Int16 GrievanceCategoryID = Convert.ToInt16(ddlGrievanceCategory.SelectedValue);
                string OtherGrievanceCategory = txtOtherGrievanceCategory.Text;
                string Grievance = txtGrievance.Text;
                string GrievanceFileURL = "";
                if (fileAttachment.PostedFile.ContentLength > 0)
                {
                    Stream objStream = fileAttachment.PostedFile.InputStream;
                    FileInfo objFileInfo = new FileInfo(fileAttachment.PostedFile.FileName);
                    string fileName = Session["UserLoginID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + objFileInfo.Extension;

                    GrievanceFileURL = new AzureDocumentUpload().UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), fileName.ToLower(), objStream, fileAttachment.PostedFile.ContentType, "grievance");

                    if (string.IsNullOrEmpty(GrievanceFileURL))
                    {
                        shInfo.SetMessage("Error has encountered during file upload. Please try again.", ShowMessageType.UserError);
                        return;
                    }
                }
                string UserLoginID = Session["UserLoginID"].ToString();
                string IPAddress = UserInfo.GetIPAddress();

                Int64 returnValue = new BusinessServiceImp().SendGrievance(ApplicationID, GrievanceCategoryID, OtherGrievanceCategory, Grievance, GrievanceFileURL, UserLoginID, IPAddress);
                if (returnValue > 0)
                {
                    ddlGrievanceCategory.ClearSelection();
                    txtOtherGrievanceCategory.Text = "";
                    txtGrievance.Text = "";
                    trOtherGrievanceCategory.Visible = false;

                    shInfo.SetMessage("Ticket Generated Successfully. Your Ticket ID : " + returnValue, ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("Ticket has not been generated. Please try again.", ShowMessageType.UserError);
                }
            }
            catch (System.Threading.ThreadAbortException t)
            {
            }
            catch (Exception ex)
            {
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}