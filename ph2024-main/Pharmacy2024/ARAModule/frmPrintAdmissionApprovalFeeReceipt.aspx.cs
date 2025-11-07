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

namespace Pharmacy2024.ARAModule
{
    public partial class frmPrintAdmissionApprovalFeeReceipt : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string CurrentYear = Global.CurrentYear;
        public string AdmissionYear = Global.AdmissionYear;
        //public string JEEName = Global.JEEName;
        public string MHTCETPercentile = Global.MHTCETPercentile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (!IsPostBack)
            {
                try
                {

                    Int32 InstituteID = Convert.ToInt32(Session["UserLoginID"].ToString());
                    InstituteProfile obj = reg.getInstituteProfile(InstituteID);
                    InstituteSummary objInstSummary = reg.getInstituteSummary(InstituteID.ToString());

                    lblInstituteCode.Text = obj.InstituteID.ToString();
                    lblInstituteName.Text = obj.InstituteName;
                    lblInstituteAddress.Text = obj.InstituteAddress;
                    lblEmail.Text = obj.CoordinatorEmailID;
                    lblMobile.Text = obj.CoordinatorMobileNo;

                    lblInstCodeName.Text = obj.InstituteID.ToString() + " - " + obj.InstituteName;
                    lblInstCodeBottom.Text = obj.InstituteID.ToString();
                    lblStatus.Text = objInstSummary.InstituteStatus1 + " - " + objInstSummary.InstituteStatus2 + " - " + objInstSummary.InstituteStatus3;

                    Int64 PID = Convert.ToInt64(Session["UserLoginID"].ToString());
                    DataSet dsDashboard = reg.getAdmissionApprovalFeeDetailsTable(4, 1, Convert.ToInt32(Session["UserTypeID"].ToString()), PID);
                    if (dsDashboard.Tables[0].Rows.Count > 0)
                    {
                        gvDashboardInstitute.DataSource = dsDashboard.Tables[0];
                        gvDashboardInstitute.DataBind();

                        Int32 TotalCAPIntake = 0;
                        Int32 TotalTFWSIntake = 0;
                        Int32 TotalDSEIntake = 0;
                        Int32 TotalAnyOtherSchemeIntake = 0;
                        Int32 TotalTotalNoofSeatsIntake = 0;
                        Int32 TotalIntakeAmount = 0;
                        Int32 TotalILIntake = 0;
                        Int32 TotalNRIIntake = 0;
                        Int32 TotalILAmount = 0;
                        Int32 TotalNRIAmount = 0;
                        Int32 TotalTotalAmount = 0;

                        int isGovt = 0;
                        int isUnAided = 0;

                        for (Int32 k = 0; k < gvDashboardInstitute.Rows.Count; k++)
                        {
                            TotalCAPIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[2].Text);
                            TotalTFWSIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[3].Text);
                            TotalDSEIntake += 0;// Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[4].Text);
                            TotalAnyOtherSchemeIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[5].Text);
                            TotalTotalNoofSeatsIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[6].Text);
                            //TotalIntakeAmount += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[7].Text);
                            TotalILIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[8].Text);
                            TotalNRIIntake += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[9].Text);
                            TotalILAmount += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[10].Text);
                            TotalNRIAmount += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[11].Text);
                            TotalTotalAmount += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[12].Text);

                            if (gvDashboardInstitute.Rows[k].Cells[1].Text == "Government" || gvDashboardInstitute.Rows[k].Cells[1].Text == "Government-Aided"
                                || gvDashboardInstitute.Rows[k].Cells[1].Text == "University Department" || gvDashboardInstitute.Rows[k].Cells[1].Text == "University Managed"
                                    || gvDashboardInstitute.Rows[k].Cells[1].Text == "Deemed University")
                            {
                                isGovt += 1;
                                TotalIntakeAmount += 0;
                            }
                            else
                            {
                                isUnAided += 1;
                                TotalIntakeAmount += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[7].Text);
                            }
                        }

                        if (TotalIntakeAmount < 20000 && isUnAided > 0)
                        {
                            TotalIntakeAmount = 20000;
                            TotalTotalAmount = TotalIntakeAmount + TotalILAmount + TotalNRIAmount;

                            for (Int32 i = 0; i < gvDashboardInstitute.Rows.Count; i++)
                            {
                                gvDashboardInstitute.Rows[i].Cells[7].Text = " - ";
                                //gvDashboardInstitute.Rows[i].Cells[9].Text = " - ";
                                gvDashboardInstitute.Rows[i].Cells[10].Text = " - ";
                                gvDashboardInstitute.Rows[i].Cells[11].Text = " - ";
                                gvDashboardInstitute.Rows[i].Cells[12].Text = " - ";
                            }
                        }

                        if (isGovt > 0 && isUnAided < 1)
                        {
                            TotalIntakeAmount = 0;
                            TotalTotalAmount = 0;

                            for (Int32 i = 0; i < gvDashboardInstitute.Rows.Count; i++)
                            {
                                gvDashboardInstitute.Rows[i].Cells[7].Text = " - ";
                                //gvDashboardInstitute.Rows[i].Cells[9].Text = " - ";
                                gvDashboardInstitute.Rows[i].Cells[10].Text = " - ";
                                gvDashboardInstitute.Rows[i].Cells[11].Text = " - ";
                                gvDashboardInstitute.Rows[i].Cells[12].Text = " - ";
                            }
                        }

                        gvDashboardInstitute.FooterRow.Cells[0].Text = "";
                        gvDashboardInstitute.FooterRow.Cells[1].Text = "Total";
                        gvDashboardInstitute.FooterRow.Cells[2].Text = TotalCAPIntake.ToString();
                        gvDashboardInstitute.FooterRow.Cells[3].Text = TotalTFWSIntake.ToString();
                        gvDashboardInstitute.FooterRow.Cells[4].Text = TotalDSEIntake.ToString();
                        gvDashboardInstitute.FooterRow.Cells[5].Text = TotalAnyOtherSchemeIntake.ToString();
                        gvDashboardInstitute.FooterRow.Cells[6].Text = TotalTotalNoofSeatsIntake.ToString();
                        gvDashboardInstitute.FooterRow.Cells[7].Text = TotalIntakeAmount.ToString();
                        gvDashboardInstitute.FooterRow.Cells[8].Text = TotalILIntake.ToString();
                        gvDashboardInstitute.FooterRow.Cells[9].Text = TotalNRIIntake.ToString();
                        gvDashboardInstitute.FooterRow.Cells[10].Text = TotalILAmount.ToString();
                        gvDashboardInstitute.FooterRow.Cells[11].Text = TotalNRIAmount.ToString();
                        gvDashboardInstitute.FooterRow.Cells[12].Text = TotalTotalAmount.ToString();
                    }
                    Int32 ApplicationFeeToBePaid = 0, FeesPaid = 0;
                    FeesPaid = reg.getAdmissionApprovalFeePaidAmount(PID);
                    lblAdmissionApprovalFeePaid.Text = FeesPaid.ToString() + "/-";

                    //lblApplicationFeePaidAmount.Text = obj.CETApplicationFee.ToString() + "/-";
                    //lblOnlineApplicationFee.Text = obj.OnlineApplicationFee.ToString() + "/-";


                    DataSet ds = reg.getAdmissionApprovalFeeDetails(PID, "Admission Approval Fee", "Unlocked");

                    lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                    lblLastModifiedOn.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["LastModifiedDateTime"].ToString()).ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ds.Tables[0].Rows[0]["LastModifiedDateTime"]);
                    lblLastModifiedBy.Text = ds.Tables[0].Rows[0]["LastModifiedBy"].ToString() + ", " + ds.Tables[0].Rows[0]["LastModifiedByIPAddress"].ToString();

                    lblReceiptNo.Text = ds.Tables[0].Rows[0]["ReceiptNo"].ToString();
                    lblBankReferenceNo.Text = ds.Tables[0].Rows[0]["BankReferenceNo"].ToString();

                    lblConfirmDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ConfirmedOn"].ToString()).ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", ds.Tables[0].Rows[0]["ConfirmedOn"]);
                    lblPrintDateInst.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);

                    //CODE FOR Composite GRID
                    gvReportComposite.DataSource = reg.getCompositeReportForInstitute_ARAFeeReceipt(PID.ToString(), "ALL");
                    gvReportComposite.DataBind();

                    Int64 SanctionIntake = 0, CAPAdmitted = 0, ACAPAdmitted = 0, CAPMIAdmitted = 0, ACAPMIAdmitted = 0, ILAdmitted = 0, TotalAdmitted = 0,
                    JKAdmitted = 0, OAAAdmitted = 0, TotalEWSAdmitted = 0, TotalAdmittedUploaded = 0;
                    for (Int32 i = 0; i < gvReportComposite.Rows.Count; i++)
                    {
                        gvReportComposite.Rows[i].Cells[0].Text = (i + 1).ToString() + ".";

                        SanctionIntake += Convert.ToInt64(gvReportComposite.Rows[i].Cells[3].Text);
                        CAPAdmitted += Convert.ToInt64(gvReportComposite.Rows[i].Cells[4].Text);
                        ACAPAdmitted += Convert.ToInt64(gvReportComposite.Rows[i].Cells[5].Text);
                        CAPMIAdmitted += Convert.ToInt64(gvReportComposite.Rows[i].Cells[6].Text);
                        ACAPMIAdmitted += Convert.ToInt64(gvReportComposite.Rows[i].Cells[7].Text);
                        ILAdmitted += Convert.ToInt64(gvReportComposite.Rows[i].Cells[8].Text);
                        TotalAdmitted += Convert.ToInt64(gvReportComposite.Rows[i].Cells[9].Text);
                        JKAdmitted += Convert.ToInt64(gvReportComposite.Rows[i].Cells[10].Text);
                        OAAAdmitted += Convert.ToInt64(gvReportComposite.Rows[i].Cells[11].Text);
                        TotalEWSAdmitted += Convert.ToInt64(gvReportComposite.Rows[i].Cells[12].Text);
                        TotalAdmittedUploaded += Convert.ToInt64(gvReportComposite.Rows[i].Cells[13].Text);

                    }

                    gvReportComposite.FooterRow.Cells[2].Text = "Total";
                    gvReportComposite.FooterRow.Cells[3].Text = SanctionIntake.ToString();
                    gvReportComposite.FooterRow.Cells[4].Text = CAPAdmitted.ToString();
                    gvReportComposite.FooterRow.Cells[5].Text = ACAPAdmitted.ToString();
                    gvReportComposite.FooterRow.Cells[6].Text = CAPMIAdmitted.ToString();
                    gvReportComposite.FooterRow.Cells[7].Text = ACAPMIAdmitted.ToString();
                    gvReportComposite.FooterRow.Cells[8].Text = ILAdmitted.ToString();
                    gvReportComposite.FooterRow.Cells[9].Text = TotalAdmitted.ToString();
                    gvReportComposite.FooterRow.Cells[10].Text = JKAdmitted.ToString();
                    gvReportComposite.FooterRow.Cells[11].Text = OAAAdmitted.ToString();
                    gvReportComposite.FooterRow.Cells[12].Text = TotalEWSAdmitted.ToString();
                    gvReportComposite.FooterRow.Cells[13].Text = TotalAdmittedUploaded.ToString();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }

        protected void gvReportComposite_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();

                Cell_Header.Text = "Sr. No.";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Choice Code";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Course Name";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Sanction Intake";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Number of  Admissions made";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ColumnSpan = 9;
                Cell_Header.RowSpan = 1;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Total Admitted & Uploaded";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 3;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvReportComposite.Controls[0].Controls.AddAt(0, HeaderRow);


                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                Cell_Header = new TableCell();
                Cell_Header.Text = "CAP";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Against CAP";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "As Minority";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Against Minority";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Institute level";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Total";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "J&K quota";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "GOI / PIO/ NRI / FNS / Others";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "EWS";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.RowSpan = 2;
                Cell_Header.CssClass = "Header";
                Cell_Header.Wrap = false;
                HeaderRow.Cells.Add(Cell_Header);

                gvReportComposite.Controls[0].Controls.AddAt(1, HeaderRow);

                HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


                gvReportComposite.Controls[0].Controls.AddAt(2, HeaderRow);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Intake";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 1;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Admitted";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 1;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Cancelled";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 1;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.Text = "Vacancy";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.RowSpan = 1;
                //Cell_Header.CssClass = "Header";
                //Cell_Header.Wrap = false;
                //HeaderRow.Cells.Add(Cell_Header);
            }
        }
    }
}