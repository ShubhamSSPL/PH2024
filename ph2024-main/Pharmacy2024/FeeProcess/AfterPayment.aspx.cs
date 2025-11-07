using BusinessLayer;
using EntityModel;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.FeeProcess
{
    public partial class AfterPayment : System.Web.UI.Page
    {

        private readonly IBusinessService reg = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["FeeGroupId"] = null;
            Session["PhaseId"] = null;
            Session["PayeeUserTypeId"] = null;
            Session["PayeeId"] = null;

            if (Request.QueryString["ReferenceNo"] == null)
            {
                Response.Redirect("PaymentDetails.aspx", true);
            }
            else
            {

                Int64 ReferenceNo = Convert.ToInt64(Request.QueryString["ReferenceNo"].ToString());
                DataSet ds = new dbUtility().getPaymentDetailsByReferenceNo(ReferenceNo);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Int64 PayeeId = Convert.ToInt64(ds.Tables[0].Rows[0]["PayeeId"].ToString());

                    if (ds.Tables[0].Rows[0]["FeeGroupId"].ToString() == "1")
                    {
                        Response.Redirect("../InstituteModule/frmControlAdvertisement.aspx", true);
                    }
                    else if (ds.Tables[0].Rows[0]["FeeGroupId"].ToString() == "2")
                    {
                        if (Session["UserTypeID"].ToString() == "91")
                        {
                            SessionData objSessionData = (SessionData)Session["SessionData"];

                            if (objSessionData.StepID < 9)
                            {
                                objSessionData.StepID = 9;
                            }
                            if (objSessionData.ApplicationFormStatus == 'I')
                            {
                                objSessionData.ApplicationFormStatus = 'C';
                            }

                            Session["SessionData"] = objSessionData;
                            //DataSet statusDs = reg.getVerificationFlags(objSessionData.PID);
                            //char FCVerificationStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["FCVerificationStatus"].ToString().ToUpper());
                            //char ApplicationFormStatus = Convert.ToChar(statusDs.Tables[0].Rows[0]["ApplicationFormStatusApplicationRound"].ToString().ToUpper());
                            //char IsLockedByCandidate = Convert.ToChar(statusDs.Tables[0].Rows[0]["IsLockedByCandidate"].ToString());
                            //if (reg.CheckCandidateFCVerificationFor(objSessionData.PID) == "E" && reg.GetApplicationLockStatus(objSessionData.PID) == "N" && ApplicationFormStatus == 'C')
                            //{
                            //    PersonalInformation obj = reg.getPersonalInformation(objSessionData.PID);

                            //    if (obj.FinalHomeUniversity == "NA")
                            //    {
                            //        if (objSessionData.CandidatureTypeID == 1 || objSessionData.CandidatureTypeID == 2 || objSessionData.CandidatureTypeID == 3 || objSessionData.CandidatureTypeID == 4 || objSessionData.CandidatureTypeID == 5)
                            //        {
                            //            Response.Redirect("../CandidateModule/frmHomeUniversityAndCategoryDetails.aspx");
                            //        }
                            //    }
                            //    else if (obj.HSCTotalMarksObtained == 0)
                            //    {
                            //        Response.Redirect("../CandidateModule/frmQualificationDetails.aspx", true);
                            //    }
                            //    else
                            //        Response.Redirect("../CandidateModule/frmVerifyAndConfirmApplicationForm.aspx", true);
                            //}

                            //else
                                Response.Redirect("../CandidateModule/frmApplicationForm.aspx", true);
                        }
                        else
                        {
                            if (reg.isApplicationFormConfirmed(PayeeId))
                            {
                                Response.Redirect("../AFCModule/frmAcknowledgement.aspx?PID=" + PayeeId + "&Code=" + PayeeId.ToString().GetHashCode(), true);
                            }
                            else
                            {
                                Response.Redirect("../AFCModule/frmApplicationForm.aspx?PID=" + PayeeId + "&Code=" + PayeeId.ToString().GetHashCode(), true);
                            }
                        }
                    }
                    else if (ds.Tables[0].Rows[0]["FeeGroupId"].ToString() == "3")
                    {
                        if (Session["UserTypeID"].ToString() == "91")
                        {
                            Response.Redirect("../CandidateAdmissionReportingModule/frmSeatAcceptanceForm.aspx", true);
                        }
                        else
                        {
                            if (reg.isSeatAcceptanceFormConfirmed(PayeeId))
                            {
                                Response.Redirect("../ARCModule/frmSeatAcceptanceAcknowledgement.aspx?PID=" + PayeeId + "&Code=" + PayeeId.ToString().GetHashCode(), true);
                            }
                            else
                            {
                                Response.Redirect("../ARCModule/frmSeatAcceptanceForm.aspx?PID=" + PayeeId + "&Code=" + PayeeId.ToString().GetHashCode(), true);
                            }
                        }
                    }
                    else if (ds.Tables[0].Rows[0]["FeeGroupId"].ToString() == "4")
                    {
                        Response.Redirect("../ARAModule/frmInstitute_AdmissionApprovalFeeDetails.aspx?From=PaymentSuccess", true);
                    }
                }
                else
                {
                    Response.Redirect("PaymentDetails.aspx", true);
                }
            }
        }
        public class dbUtility
        {
            public DataSet getPaymentDetailsByReferenceNo(Int64 ReferenceNo)
            {
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@ReferenceNo", SqlDbType.BigInt)
                };
                parameters[0].Value = ReferenceNo;
                DBConnection db = new DBConnection();
                try
                {
                    return db.ExecuteDataSet("Fee_spGetPaymentData", parameters);

                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}