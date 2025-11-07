using BusinessLayer;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Pharmacy2024
{
    public class Global : HttpApplication
    {
        private readonly IBusinessService _IbusinessService = new BusinessServiceImp();
        public static DataSet MasterSecurityQuestion;
        public static DataSet MasterGender;
        public static DataSet MasterReligion;
        public static DataSet MasterRegionType;
        public static DataSet MasterMotherTongue;
        public static DataSet MasterAnnualFamilyIncome;
        public static DataSet MasterNationality;
        public static DataSet MasterState;
        public static DataSet MasterHSCPassingYear;
        public static DataSet MasterSSCPassingYear;
        public static DataSet MasterDiplomaPassingYear;
        public static DataSet MasterCandidatureType;
        public static DataSet MasterDocumentForTypeA;
        public static DataSet MasterDocumentOf;
        public static DataSet MasterMHDistrict;
        public static DataSet MasterCategory;
        public static DataSet MasterPHType;
        public static DataSet MasterCourse;
        public static DataSet MasterDefenceType;
        public static DataSet MasterLinguisticMinority;
        public static DataSet MasterReligiousMinority;
        public static DataSet MasterBoard;
        public static DataSet MasterHSCSubject;
        public static DataSet MasterWebSite;
        public static DataSet MasterBank;
        public static DataSet MasterAFC;
        public static DataSet MasterARC;
        public static DataSet MasterCandidateInstituteMinorityMapping;

        public static DataSet MasterCourseCAPRound1;
        public static DataSet MasterCourseCAPRound2;
        public static DataSet MasterCourseCAPRound3;
        public static DataSet MasterCourseCAPRound4;
        public static DataSet MasterUniversityCAPRound1;
        public static DataSet MasterUniversityCAPRound2;
        public static DataSet MasterUniversityCAPRound3;
        public static DataSet MasterUniversityCAPRound4;
        public static DataSet MasterCourseStatus1CAPRound1;
        public static DataSet MasterCourseStatus1CAPRound2;
        public static DataSet MasterCourseStatus1CAPRound3;
        public static DataSet MasterCourseStatus1CAPRound4;
        public static DataSet MasterCourseStatus2CAPRound1;
        public static DataSet MasterCourseStatus2CAPRound2;
        public static DataSet MasterCourseStatus2CAPRound3;
        public static DataSet MasterCourseStatus2CAPRound4;
        public static DataSet MasterCourseStatus3CAPRound1;
        public static DataSet MasterCourseStatus3CAPRound2;
        public static DataSet MasterCourseStatus3CAPRound3;
        public static DataSet MasterCourseStatus3CAPRound4;
        public static DataSet MasterChoiceCodeStatusCAPRound1;
        public static DataSet MasterChoiceCodeStatusCAPRound2;
        public static DataSet MasterChoiceCodeStatusCAPRound3;
        public static DataSet MasterChoiceCodeStatusCAPRound4;
        public static DataSet MasterInstituteListForAllotmentDisplay;

        public static string CurrentDate;
        public static DataSet ImportantDates;
        public static DataSet TopImportantDates;
        public static DataSet MasterLanguage;
        public static Int32 CAPRound;

        public static Int32 ApplicationFormFilling;
        public static Int32 DocumentVerification;
        public static Int32 EdittingOfApplicationForm;
        public static Int32 ARCReporting;
        public static Int32 InstituteCAPReporting;
        public static Int32 InstituteReporting;
        public static Int32 OptionFormFillingCAPRound1;
        public static Int32 OptionFormFillingCAPRound2;
        public static Int32 OptionFormFillingCAPRound3;
        public static Int32 OptionFormFillingCAPRound4;


        public static Int16 CheckDuplicateMobileNo;
        public static Int16 CheckDuplicateHSCSeatNo;
        public static Int16 CheckDuplicateNEETSetNo;
        public static Int16 CheckDuplicateCETApplicationNo;
        public static Int16 CheckDuplicateEmailID;
        public static Int16 IsOTPVerificationRequired;
        public static Int16 IsCaptchaRequired;
        public static Int16 IsDocumentUploadRequired;
        public static Int16 CurrentCAPRoundForARCReporting;

        public static Int16 SendSMSToCandidate;
        public static DateTime CutOffDateForAdmission;
        public static DateTime CutOffDateForUploading;
        public static Int16 CurrentCAPRoundForOptionFormFilling;
        public static Int16 DisplayMoreInfoColumnInOptionFormFilling;
        public static Int16 DisplayProvisionalMeritList;
        public static Int16 DisplayFinalMeritList;
        public static Int16 DisplayProvisionalAllotmentListCAPRound1;
        public static Int16 DisplayProvisionalAllotmentListCAPRound2;
        public static Int16 DisplayProvisionalAllotmentListCAPRound3;
        public static Int16 DisplayProvisionalAllotmentListCAPRound4;
        public static Int16 DisplayAdmissionStatusInCandidateLogin;
        public static Int16 IsOTPVerificationRequiredForLogin;

        public static DateTime ApplicationFormFillingStartDateTime;
        public static DateTime ApplicationFormFillingEndDateTime;
        public static DateTime EdittingOfApplicationFormStartDateTime;
        public static DateTime EdittingOfApplicationFormEndDateTime;
        public static DateTime DocumentVerificationStartDateTime;
        public static DateTime DocumentVerificationEndDateTime;
        public static DateTime InstituteCAPReportingStartDateTime;
        public static DateTime InstituteCAPReportingEndDateTime;
        public static DateTime InstituteNonCAPReportingStartDateTime;
        public static DateTime InstituteNonCAPReportingEndDateTime;
        public static DateTime OptionFormFillingCAPRound1StartDateTime;
        public static DateTime OptionFormFillingCAPRound1EndDateTime;
        public static DateTime OptionFormFillingCAPRound2StartDateTime;
        public static DateTime OptionFormFillingCAPRound2EndDateTime;
        public static DateTime OptionFormFillingCAPRound3StartDateTime;
        public static DateTime OptionFormFillingCAPRound3EndDateTime;
        public static DateTime OptionFormFillingCAPRound4StartDateTime;
        public static DateTime OptionFormFillingCAPRound4EndDateTime;
        public static DateTime ARCReportingCAPRound1StartDateTime;
        public static DateTime ARCReportingCAPRound1EndDateTime;
        public static DateTime ARCReportingCAPRound2StartDateTime;
        public static DateTime ARCReportingCAPRound2EndDateTime;
        public static DateTime ARCReportingCAPRound3StartDateTime;
        public static DateTime ARCReportingCAPRound3EndDateTime;
        public static DateTime ARCReportingCAPRound4StartDateTime;
        public static DateTime ARCReportingCAPRound4EndDateTime;

        public static DateTime ProvisionalAllotmentDisplayCAPRound1StartDateTime;
        public static DateTime ProvisionalAllotmentDisplayCAPRound1EndDateTime;
        public static DateTime ProvisionalAllotmentDisplayCAPRound2StartDateTime;
        public static DateTime ProvisionalAllotmentDisplayCAPRound2EndDateTime;
        public static DateTime ProvisionalAllotmentDisplayCAPRound3StartDateTime;
        public static DateTime ProvisionalAllotmentDisplayCAPRound3EndDateTime;
        public static DateTime ProvisionalAllotmentDisplayCAPRound4StartDateTime;
        public static DateTime ProvisionalAllotmentDisplayCAPRound4EndDateTime;

        public static Int16 IsOTPVerificationRequiredForCancelApplicationForm;
        public static Int16 IsOTPVerificationRequiredForConfirmApplicationForm;
        public static Int16 IsOTPVerificationRequiredForAdmissionConfirm;
        public static Int16 IsEmailSend;
        public static Int16 IsOTPVerificationRequiredForOptionForm2;
        public static Int16 IsOTPVerificationRequiredForAdmissionConfirmatIL;
        public static Int16 IsOTPVerificationRequiredForOptionForm3;
        public static Int16 IsOTPVerificationRequiredForOptionForm4;
        public static Int16 IsOTPVerificationRequiredForCandidateApplicationFormConfermation;
        public static Int16 IsOTPVerificationRequiredForUnlockApplicationForm;
        public static string ProjectNameSMS;
        public static string ApplicationFormPrefix;
        public static string AdmissionYear;
        public static string CurrentYear;
        // public static string JEEName;
        public static string NEETName;
        public static string MHTCETName;
        public static string MHTCETPercentile;
        public static bool CheckNEETResult = true;//true;
        public static string NextYear;
        public static Int16 IsVerifyNewMobileOTP;
        public static List<Master_District> AllDistrict;
        public static List<Master_Taluka> AllTaluka;
        public static List<Master_Village> AllVillage;

        public static List<Master_Taluka> AllMHTaluka;
        public static Int16 IsGrivanceApprovalActive;
        public static Int16 IsSendGrivanceActive;
        public static Int16 IsOTPCategoryConversion;
        public static Int16 IsOTPVerificationRequiredForUnlockOptionForm2;
        public static string CurrentScrutinyMode;
        public static Int16 IsSendWhatsApp;
        public static string hSCMarksFetchBy;
        public static string IsCAPRegistrationStart;
        public static Int16 DisplayMockAllotmentForCAPRound;
        public static string whatsappProvider;
        public Global()
        {
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Console.WriteLine("Global Variables Setting Stared !");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            setGlobalVariables();
            timer.Stop();
            Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}", timer.Elapsed);
        }

        [Obsolete]
        protected void Application_BeginRequest()
        {

            Application["SecretKey"] = ConfigurationSettings.AppSettings["TestSecretKey"];
            string ApplicationURL = ConfigurationSettings.AppSettings["ApplicationURL"].ToLower();

            //below is the new line code added by Balaji
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("http://ph2024.mahacet.org"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location",
                    Request.Url.ToString().ToLower().Replace("http://ph2024.mahacet.org", "https://ph2024.mahacet.org"));
            }
            //end

            if (HttpContext.Current.Request.Url.ToString().ToLower() == ApplicationURL + "default.aspx")
            {
                HttpContext.Current.Response.Redirect(ApplicationURL + "StaticPages/HomePage");
            }
            else if (HttpContext.Current.Request.Url.ToString().ToLower() == ApplicationURL || HttpContext.Current.Request.Url.ToString().ToLower() == ApplicationURL.TrimEnd('/'))
            {
                HttpContext.Current.Response.Redirect(ApplicationURL + "StaticPages/HomePage");
            }
        }
        void Application_End(object sender, EventArgs e)
        {
        }
        void Session_Start(object sender, EventArgs e)
        {
        }
        void Session_End(object sender, EventArgs e)
        {
        }
        void Application_Error(object sender, EventArgs e)
        {

            Logging.LogException(Server.GetLastError(), "[Application Level Error]");
            Server.ClearError();
        }

        public override void Init()
        {
            base.Init();

        }
        public void setGlobalVariables()
        {

            MasterSecurityQuestion = _IbusinessService.getMasterSecurityQuestion();
            MasterGender = _IbusinessService.getMasterGender();
            MasterReligion = _IbusinessService.getMasterReligion();
            MasterRegionType = _IbusinessService.getMasterRegionType();
            MasterMotherTongue = _IbusinessService.getMasterMotherTongue();
            MasterAnnualFamilyIncome = _IbusinessService.getMasterAnnualFamilyIncome();
            MasterNationality = _IbusinessService.getMasterNationality();
            MasterState = _IbusinessService.getMasterState();
            MasterHSCPassingYear = _IbusinessService.getMasterPassingYear("H");
            MasterSSCPassingYear = _IbusinessService.getMasterPassingYear("S");
            MasterDiplomaPassingYear = _IbusinessService.getMasterPassingYear("D");
            MasterCandidatureType = _IbusinessService.getMasterCandidatureType();
            MasterDocumentForTypeA = _IbusinessService.getMasterDocumentForTypeA();
            MasterDocumentOf = _IbusinessService.getMasterDocumentOf();
            MasterMHDistrict = _IbusinessService.getMasterMHDistrict();
            MasterCategory = _IbusinessService.getMasterCategory();
            MasterPHType = _IbusinessService.getMasterPHType();
            MasterCourse = _IbusinessService.getMasterCourse();
            MasterDefenceType = _IbusinessService.getMasterDefenceType();
            MasterLinguisticMinority = _IbusinessService.getMasterMinority("L");
            MasterReligiousMinority = _IbusinessService.getMasterMinority("R");
            MasterBoard = _IbusinessService.getMasterBoard();
            MasterHSCSubject = _IbusinessService.getMasterHSCSubject();
            MasterWebSite = _IbusinessService.getMasterWebSite();
            MasterBank = _IbusinessService.getMasterBank();
            MasterAFC = _IbusinessService.getMasterAFC();
            MasterARC = _IbusinessService.getMasterARC();
            MasterCandidateInstituteMinorityMapping = _IbusinessService.getMasterCandidateInstituteMinorityMapping();
            MasterUniversityCAPRound1 = _IbusinessService.getMasterUniversity(1);
            MasterUniversityCAPRound2 = _IbusinessService.getMasterUniversity(2);
            MasterUniversityCAPRound3 = _IbusinessService.getMasterUniversity(3);
            MasterUniversityCAPRound4 = _IbusinessService.getMasterUniversity(4);
            MasterCourseStatus1CAPRound1 = _IbusinessService.getMasterCourseStatus1(1);
            MasterCourseStatus1CAPRound2 = _IbusinessService.getMasterCourseStatus1(2);
            MasterCourseStatus1CAPRound3 = _IbusinessService.getMasterCourseStatus1(3);
            MasterCourseStatus1CAPRound4 = _IbusinessService.getMasterCourseStatus1(4);
            MasterCourseStatus2CAPRound1 = _IbusinessService.getMasterCourseStatus2(1);
            MasterCourseStatus2CAPRound2 = _IbusinessService.getMasterCourseStatus2(2);
            MasterCourseStatus2CAPRound3 = _IbusinessService.getMasterCourseStatus2(3);
            MasterCourseStatus2CAPRound4 = _IbusinessService.getMasterCourseStatus2(4);
            MasterCourseStatus3CAPRound1 = _IbusinessService.getMasterCourseStatus3(1);
            MasterCourseStatus3CAPRound2 = _IbusinessService.getMasterCourseStatus3(2);
            MasterCourseStatus3CAPRound3 = _IbusinessService.getMasterCourseStatus3(3);
            MasterCourseStatus3CAPRound4 = _IbusinessService.getMasterCourseStatus3(4);
            MasterChoiceCodeStatusCAPRound1 = _IbusinessService.getMasterChoiceCodeStatus(1);
            MasterChoiceCodeStatusCAPRound2 = _IbusinessService.getMasterChoiceCodeStatus(2);
            MasterChoiceCodeStatusCAPRound3 = _IbusinessService.getMasterChoiceCodeStatus(3);
            MasterChoiceCodeStatusCAPRound4 = _IbusinessService.getMasterChoiceCodeStatus(4);
            MasterInstituteListForAllotmentDisplay = _IbusinessService.getInstituteListForAllotmentDisplay();

            CurrentDate = DateTime.Now.ToString("dd/MM/yyyy");
            ImportantDates = _IbusinessService.getImportantDates();
            TopImportantDates = _IbusinessService.getTopActiveImportantDates();
            MasterLanguage = _IbusinessService.getMasterLanguage();

            // CAPRound = 1;
            ApplicationFormFilling = _IbusinessService.getApplicationStatus("ApplicationFormFilling");
            DocumentVerification = _IbusinessService.getApplicationStatus("DocumentVerification");
            EdittingOfApplicationForm = _IbusinessService.getApplicationStatus("EdittingOfApplicationForm");
            ARCReporting = _IbusinessService.getApplicationStatus("ARCReporting");
            InstituteCAPReporting = _IbusinessService.getApplicationStatus("InstituteCAPReporting");
            InstituteReporting = _IbusinessService.getApplicationStatus("InstituteReporting");
            OptionFormFillingCAPRound1 = _IbusinessService.getApplicationStatus("OptionFormFillingCAPRound1");
            OptionFormFillingCAPRound2 = _IbusinessService.getApplicationStatus("OptionFormFillingCAPRound2");
            OptionFormFillingCAPRound3 = _IbusinessService.getApplicationStatus("OptionFormFillingCAPRound3");
            OptionFormFillingCAPRound4 = _IbusinessService.getApplicationStatus("OptionFormFillingCAPRound4");
            CheckDuplicateMobileNo = Convert.ToInt16(_IbusinessService.getProjectConfiguration("CheckDuplicateMobileNo"));
            CheckDuplicateHSCSeatNo = Convert.ToInt16(_IbusinessService.getProjectConfiguration("CheckDuplicateHSCSeatNo"));
            CheckDuplicateNEETSetNo = Convert.ToInt16(_IbusinessService.getProjectConfiguration("CheckDuplicateNEETSetNo"));
            CheckDuplicateCETApplicationNo = Convert.ToInt16(_IbusinessService.getProjectConfiguration("CheckDuplicateCETApplicationNo"));
            CheckDuplicateEmailID = Convert.ToInt16(_IbusinessService.getProjectConfiguration("CheckDuplicateEmailID"));
            IsOTPVerificationRequired = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequired"));
            IsCaptchaRequired = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsCaptchaRequired"));
            IsDocumentUploadRequired = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsDocumentUploadRequired"));

            CurrentCAPRoundForARCReporting = Convert.ToInt16(_IbusinessService.getProjectConfiguration("CurrentCAPRoundForARCReporting"));
            CurrentScrutinyMode = Convert.ToString(_IbusinessService.getProjectConfiguration("CurrentScrutinyMode"));
            //CAPRound = 1;
            CAPRound = CurrentCAPRoundForARCReporting;
            DisplayMockAllotmentForCAPRound = 0;
            //DisplayMockAllotmentForCAPRound = Convert.ToInt16(_IbusinessService.getProjectConfiguration("DisplayMockAllotmentForCAPRound"));
            SendSMSToCandidate = Convert.ToInt16(_IbusinessService.getProjectConfiguration("SendSMSToCandidate"));
            CutOffDateForAdmission = Convert.ToDateTime(_IbusinessService.getProjectConfiguration("CutOffDateForAdmission"));
            CutOffDateForUploading = Convert.ToDateTime(_IbusinessService.getProjectConfiguration("CutOffDateForUploading"));

            CurrentCAPRoundForOptionFormFilling = Convert.ToInt16(_IbusinessService.getProjectConfiguration("CurrentCAPRoundForOptionFormFilling"));

            DisplayMoreInfoColumnInOptionFormFilling = Convert.ToInt16(_IbusinessService.getProjectConfiguration("DisplayMoreInfoColumnInOptionFormFilling"));

            DisplayProvisionalMeritList = Convert.ToInt16(_IbusinessService.getProjectConfiguration("DisplayProvisionalMeritList"));

            DisplayFinalMeritList = Convert.ToInt16(_IbusinessService.getProjectConfiguration("DisplayFinalMeritList"));

            DisplayProvisionalAllotmentListCAPRound1 = Convert.ToInt16(_IbusinessService.getProjectConfiguration("DisplayProvisionalAllotmentListCAPRound1"));

            DisplayProvisionalAllotmentListCAPRound2 = Convert.ToInt16(_IbusinessService.getProjectConfiguration("DisplayProvisionalAllotmentListCAPRound2"));

            DisplayProvisionalAllotmentListCAPRound3 = Convert.ToInt16(_IbusinessService.getProjectConfiguration("DisplayProvisionalAllotmentListCAPRound3"));

            DisplayProvisionalAllotmentListCAPRound4 = Convert.ToInt16(_IbusinessService.getProjectConfiguration("DisplayProvisionalAllotmentListCAPRound4"));

            DisplayAdmissionStatusInCandidateLogin = Convert.ToInt16(_IbusinessService.getProjectConfiguration("DisplayAdmissionStatusInCandidateLogin"));

            IsOTPVerificationRequiredForLogin = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequiredForLogin"));

            DataSet dsApplicationFormFilling = _IbusinessService.getActivityStatus("ApplicationFormFilling");
            ApplicationFormFillingStartDateTime = Convert.ToDateTime(dsApplicationFormFilling.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            ApplicationFormFillingEndDateTime = Convert.ToDateTime(dsApplicationFormFilling.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsEdittingOfApplicationForm = _IbusinessService.getActivityStatus("EdittingOfApplicationForm");
            EdittingOfApplicationFormStartDateTime = Convert.ToDateTime(dsEdittingOfApplicationForm.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            EdittingOfApplicationFormEndDateTime = Convert.ToDateTime(dsEdittingOfApplicationForm.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsDocumentVerification = _IbusinessService.getActivityStatus("DocumentVerification");
            DocumentVerificationStartDateTime = Convert.ToDateTime(dsDocumentVerification.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            DocumentVerificationEndDateTime = Convert.ToDateTime(dsDocumentVerification.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsInstituteCAPReporting = _IbusinessService.getActivityStatus("InstituteCAPReporting");
            InstituteCAPReportingStartDateTime = Convert.ToDateTime(dsInstituteCAPReporting.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            InstituteCAPReportingEndDateTime = Convert.ToDateTime(dsInstituteCAPReporting.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsInstituteNonCAPReporting = _IbusinessService.getActivityStatus("InstituteNonCAPReporting");
            InstituteNonCAPReportingStartDateTime = Convert.ToDateTime(dsInstituteNonCAPReporting.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            InstituteNonCAPReportingEndDateTime = Convert.ToDateTime(dsInstituteNonCAPReporting.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsOptionFormFillingCAPRound1 = _IbusinessService.getActivityStatus("OptionFormFillingCAPRound1");
            OptionFormFillingCAPRound1StartDateTime = Convert.ToDateTime(dsOptionFormFillingCAPRound1.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            OptionFormFillingCAPRound1EndDateTime = Convert.ToDateTime(dsOptionFormFillingCAPRound1.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsOptionFormFillingCAPRound2 = _IbusinessService.getActivityStatus("OptionFormFillingCAPRound2");
            OptionFormFillingCAPRound2StartDateTime = Convert.ToDateTime(dsOptionFormFillingCAPRound2.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            OptionFormFillingCAPRound2EndDateTime = Convert.ToDateTime(dsOptionFormFillingCAPRound2.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsOptionFormFillingCAPRound3 = _IbusinessService.getActivityStatus("OptionFormFillingCAPRound3");
            OptionFormFillingCAPRound3StartDateTime = Convert.ToDateTime(dsOptionFormFillingCAPRound3.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            OptionFormFillingCAPRound3EndDateTime = Convert.ToDateTime(dsOptionFormFillingCAPRound3.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsOptionFormFillingCAPRound4 = _IbusinessService.getActivityStatus("OptionFormFillingCAPRound4");
            OptionFormFillingCAPRound4StartDateTime = Convert.ToDateTime(dsOptionFormFillingCAPRound4.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            OptionFormFillingCAPRound4EndDateTime = Convert.ToDateTime(dsOptionFormFillingCAPRound4.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsARCReportingCAPRound1 = _IbusinessService.getActivityStatus("ARCReportingCAPRound1");
            ARCReportingCAPRound1StartDateTime = Convert.ToDateTime(dsARCReportingCAPRound1.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            ARCReportingCAPRound1EndDateTime = Convert.ToDateTime(dsARCReportingCAPRound1.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsARCReportingCAPRound2 = _IbusinessService.getActivityStatus("ARCReportingCAPRound2");
            ARCReportingCAPRound2StartDateTime = Convert.ToDateTime(dsARCReportingCAPRound2.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            ARCReportingCAPRound2EndDateTime = Convert.ToDateTime(dsARCReportingCAPRound2.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsARCReportingCAPRound3 = _IbusinessService.getActivityStatus("ARCReportingCAPRound3");
            ARCReportingCAPRound3StartDateTime = Convert.ToDateTime(dsARCReportingCAPRound3.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            ARCReportingCAPRound3EndDateTime = Convert.ToDateTime(dsARCReportingCAPRound3.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsARCReportingCAPRound4 = _IbusinessService.getActivityStatus("ARCReportingCAPRound4");
            ARCReportingCAPRound4StartDateTime = Convert.ToDateTime(dsARCReportingCAPRound4.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            ARCReportingCAPRound4EndDateTime = Convert.ToDateTime(dsARCReportingCAPRound4.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            DataSet dsProvisionalAllotmentDisplayCAPRound1 = _IbusinessService.getActivityStatus("ProvisionalAllotmentDisplayCAPRound1");
            ProvisionalAllotmentDisplayCAPRound1StartDateTime = Convert.ToDateTime(dsProvisionalAllotmentDisplayCAPRound1.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            ProvisionalAllotmentDisplayCAPRound1EndDateTime = Convert.ToDateTime(dsProvisionalAllotmentDisplayCAPRound1.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());
            DataSet dsProvisionalAllotmentDisplayCAPRound2 = _IbusinessService.getActivityStatus("ProvisionalAllotmentDisplayCAPRound2");
            ProvisionalAllotmentDisplayCAPRound2StartDateTime = Convert.ToDateTime(dsProvisionalAllotmentDisplayCAPRound2.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            ProvisionalAllotmentDisplayCAPRound2EndDateTime = Convert.ToDateTime(dsProvisionalAllotmentDisplayCAPRound2.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());
            DataSet dsProvisionalAllotmentDisplayCAPRound3 = _IbusinessService.getActivityStatus("ProvisionalAllotmentDisplayCAPRound3");
            ProvisionalAllotmentDisplayCAPRound3StartDateTime = Convert.ToDateTime(dsProvisionalAllotmentDisplayCAPRound3.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            ProvisionalAllotmentDisplayCAPRound3EndDateTime = Convert.ToDateTime(dsProvisionalAllotmentDisplayCAPRound3.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());
            DataSet dsProvisionalAllotmentDisplayCAPRound4 = _IbusinessService.getActivityStatus("ProvisionalAllotmentDisplayCAPRound4");
            ProvisionalAllotmentDisplayCAPRound4StartDateTime = Convert.ToDateTime(dsProvisionalAllotmentDisplayCAPRound4.Tables[0].Rows[0]["ActivityStartDateTime"].ToString());
            ProvisionalAllotmentDisplayCAPRound4EndDateTime = Convert.ToDateTime(dsProvisionalAllotmentDisplayCAPRound4.Tables[0].Rows[0]["ActivityEndDateTime"].ToString());

            IsOTPVerificationRequiredForCancelApplicationForm = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequiredForCancelApplicationForm")); ;

            IsOTPVerificationRequiredForConfirmApplicationForm = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequiredForConfirmApplicationForm"));

            IsEmailSend = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsEmailSend"));

            IsOTPVerificationRequiredForAdmissionConfirm = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequiredForAdmissionConfirm"));

            IsOTPVerificationRequiredForOptionForm2 = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequiredForOptionForm2"));

            IsOTPVerificationRequiredForAdmissionConfirmatIL = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequiredForAdmissionConfirmatIL"));

            IsOTPVerificationRequiredForOptionForm3 = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequiredForOptionForm3"));

            IsOTPVerificationRequiredForOptionForm4 = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequiredForOptionForm4"));
            IsOTPVerificationRequiredForCandidateApplicationFormConfermation = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequiredForCandidateApplicationFormConfermation"));
            IsOTPVerificationRequiredForUnlockApplicationForm = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsOTPVerificationRequiredForUnlockApplicationForm"));

            IsVerifyNewMobileOTP = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsVerifyNewMobileOTP"));
            ProjectNameSMS = ConfigurationManager.AppSettings["ProjectNameSMS"];
            ApplicationFormPrefix = ConfigurationManager.AppSettings["FormPrefix"];
            AdmissionYear = ConfigurationManager.AppSettings["CurrentAdmisisonYear"];
            CurrentYear = ConfigurationManager.AppSettings["CurrentYear"];
            NextYear = ConfigurationManager.AppSettings["NextYear"];
            //JEEName = ConfigurationManager.AppSettings["JEEName"];
            NEETName = ConfigurationManager.AppSettings["NEETName"];
            MHTCETName = ConfigurationManager.AppSettings["MHTCETName"];
            MHTCETPercentile = ConfigurationManager.AppSettings["MHTCETPercentile"];

            AllDistrict = _IbusinessService.getAllMasterDistrict();
            AllTaluka = _IbusinessService.getAllMasterTaluka();
            AllVillage = _IbusinessService.getAllMasterVillage();

            AllMHTaluka = _IbusinessService.GetAllMasterMHTaluka();
            IsGrivanceApprovalActive = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsGrivanceApprovalActive"));
            IsSendGrivanceActive = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsSendGrivanceActive"));
            IsOTPCategoryConversion = 1;
            IsOTPVerificationRequiredForUnlockOptionForm2 = 1;
            IsSendWhatsApp = Convert.ToInt16(_IbusinessService.getProjectConfiguration("IsSendWhatsApp"));
            hSCMarksFetchBy = ConfigurationManager.AppSettings["HSCMarksFetchBy"];
            IsCAPRegistrationStart = ConfigurationManager.AppSettings["IsCAPRegistrationStart"];

            whatsappProvider = "msg91";
        }
        //Add by Sharad For Same user id login in different browser only single  login allowed 
        //protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //Only access session state if it is available
        //        if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
        //        {
        //            //If we are authenticated AND we don't have a session here then redirect to login page.
        //            //IDAFormsAuth
        //            HttpCookie authenticationCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
        //            if (authenticationCookie != null)
        //            {
        //                FormsAuthenticationTicket authenticationTicket = FormsAuthentication.Decrypt(authenticationCookie.Value);
        //                if (!authenticationTicket.Expired)
        //                {
        //                    //Check if session is available
        //                    if (HttpContext.Current.Session["UserLoginID"] == null)
        //                    {
        //                        //This means for some reason the session expired before the authentication ticket. Force a login.
        //                        FormsAuthentication.SignOut();
        //                        Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        //                        return;
        //                    }
        //                    else
        //                    {
        //                        if (Session["keyUserName"] != null)
        //                        {
        //                            string cacheKey = Session["keyUserName"].ToString();
        //                            if ((string)HttpContext.Current.Cache[cacheKey] != Session.SessionID)
        //                            {
        //                                FormsAuthentication.SignOut();
        //                                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
        //                                return;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    catch (CryptographicException cex)
        //    {
        //        FormsAuthentication.SignOut();
        //    }
        //}

        //Add by sharad set HTPFlag cookin False
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            // Iterate through any cookies found in the Response object.
            bool status = false;
            foreach (string cookieName in Response.Cookies.AllKeys)
            {
                if (Response.Cookies[cookieName]?.Secure == true)
                {
                    status = true;
                }
            }
            return;
        }
    }
}