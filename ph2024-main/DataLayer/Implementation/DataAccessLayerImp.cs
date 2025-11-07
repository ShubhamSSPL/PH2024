using EntityModel;
using forProjectCustomExceptions;
using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Implementation
{
    public class DataAccessLayerImp : EntityManager, IDataAcesslayer
    {
        public DataSet getMasterSecurityQuestion()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterSecurityQuestion");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterSecurityQuestion()", "");
            }
        }
        public DataSet getMasterGender()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterGender");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterGender()", "");
            }
        }
        public DataSet getMasterReligion()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterReligion");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterReligion()", "");
            }
        }
        public DataSet getMasterRegionType()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterRegionType");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterRegionType()", "");
            }
        }
        public DataSet getMasterMotherTongue()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterMotherTongue");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterMotherTongue()", "");
            }

        }
        public DataSet getMasterAnnualFamilyIncome()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterAnnualFamilyIncome");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterAnnualFamilyIncome()", "");
            }
        }
        public DataSet getMasterNationality()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterNationality");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterNationality()", "");
            }
        }
        public DataSet getMasterState()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterState");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterState()", "");
            }
        }
        public DataSet getMasterDistrictForState(Int32 StateID)
        {
            try
            {
                object[] parameters = { StateID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterDistrictForState", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterDistrictForState()", "");
            }
        }
        public DataSet getMasterTalukaForDistrict(Int32 DistrictID)
        {

            try
            {
                object[] parameters = { DistrictID };

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterTalukaForDistrict", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterTalukaForDistrict()", "");
            }
        }
        public DataSet getMasterVillageForTaluka(Int32 TalukaID)
        {


            try
            {
                object[] parameters = { TalukaID };
                DataSet ds = new DataSet();
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterVillageForTaluka", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterVillageForTaluka()", "");
            }
        }
        public DataSet getMasterCandidatureType()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterCandidatureType");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterCandidatureType()", "");
            }
        }
        public DataSet getMasterDocumentForTypeA()
        {
            try
            {


                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterDocumentForTypeA");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterTalukaForDistrict()", "");
            }
        }
        public DataSet getMasterDocumentOf()
        {

            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterDocumentOf");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterDocumentOf()", "");
            }
        }
        public DataSet getMasterMHDistrict()
        {


            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterMHDistrict");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterMHDistrict()", "");
            }
        }
        public DataSet getMasterMHTalukaForMHDistrict(Int32 DistrictID)
        {
            try
            {
                object[] parameters = { DistrictID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterMHTalukaForMHDistrict", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterMHTalukaForMHDistrict()", "");
            }
        }
        public DataSet getMasterCategory()
        {

            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterCategory");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterCategory()", "");
            }
        }
        public DataSet getMasterCasteForCategory(Int16 CategoryID)
        {

            try
            {
                object[] parameters = { CategoryID };


                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterCasteForCategory", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterCasteForCategory()", "");
            }
        }
        public DataSet getMasterCasteForOpenCategory(string Flag)
        {


            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterCasteForOpenCategory", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterCasteForOpenCategory()", "");
            }
        }
        public DataSet getMasterPHType()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterPHType");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterPHType()", "");
            }
        }
        public DataSet getMasterCourse()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterCourse");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterCourse()", "");
            }
        }
        public DataSet getMasterDefenceType()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterDefenceType");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterDefenceType()", "");
            }
        }
        public DataSet getMasterMinority(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterMinority", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterMinority()", "");
            }

        }
        public DataSet getMasterBoard()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterBoard");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterBoard()", "");
            }
        }
        public DataSet getMasterHSCSubject(Int16 HSCBoardID)
        {
            try
            {
                object[] parameters = { HSCBoardID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterHSCSubject", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterHSCSubject()", "");
            }

        }
        public DataSet getMasterAFC()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterAFC");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterAFC()", "");
            }
        }
        public DataSet getMasterWebSite()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterWebSite");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterWebSite()", "");
            }
        }
        public DataSet getMasterBank()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterBank");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterBank()", "");
            }
        }
        public DataSet getMasterLanguage()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "Content_Mgt_GetLanguages");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterLanguage()", "");
            }
        }
        public DataSet getMasterApplicationBlockStatus()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterApplicationBlockStatus");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterApplicationBlockStatus()", "");
            }
        }
        public DataSet getMasterUniversity(Int32 CAPRound)
        {
            try
            {
                object[] parameters = { CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterUniversity", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterUniversity()", "");
            }

        }
        public DataSet getMasterCourseStatus1(Int32 CAPRound)
        {

            try
            {
                object[] parameters = { CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterCourseStatus1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterCourseStatus1()", "");
            }

        }
        public DataSet getMasterCourseStatus2(Int32 CAPRound)
        {

            try
            {
                object[] parameters = { CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterCourseStatus2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterCourseStatus2()", "");
            }
        }
        public DataSet getMasterCourseStatus3(Int32 CAPRound)
        {

            try
            {
                object[] parameters = { CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterCourseStatus3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterCourseStatus3()", "");
            }
        }
        public DataSet getMasterChoiceCodeStatus(Int32 CAPRound)
        {
            try
            {
                object[] parameters = { CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterChoiceCodeStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterChoiceCodeStatus()", "");
            }
        }
        public DataSet getMasterDistrictForUniversity(Int32 CAPRound, Int16 UniversityID)
        {

            try
            {
                object[] parameters = { CAPRound, UniversityID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterDistrictForUniversity", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterDistrictForUniversity()", "");
            }
        }
        public DataSet getMasterARC()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterARC");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterARC()", "");
            }
        }
        public DataSet getMasterCandidateInstituteMinorityMapping()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterCandidateInstituteMinorityMapping");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterCandidateInstituteMinorityMapping()", "");
            }
        }
        public Int32 getApplicationStatus(string ApplicationName)
        {
            try
            {
                object[] parameters = { ApplicationName };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetApplicationStatusByApplicationName", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getApplicationStatus()", "");
            }
        }
        public string forgotApplicationID(string CandidateName, string FatherName, string MotherName, DateTime DOB)
        {
            try
            {
                object[] parameters = { CandidateName, FatherName, MotherName, DOB };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spForgotApplicationID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "forgotApplicationID()", "");
            }
        }
        public Int64 checkCandidateSecurityQuestionDetails(string ApplicationID, Int16 SecurityQuestionID, string SecurityAnswer)
        {

            try
            {
                object[] parameters = { ApplicationID, SecurityQuestionID, SecurityAnswer };
                return Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckCandidateSecurityQuestionDetails", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkCandidateSecurityQuestionDetails()", "");
            }
        }
        public bool resetCandidatePassword(Int64 PID, string CandidatePassword, string PasswordResetBy, string PasswordResetByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CandidatePassword, PasswordResetBy, PasswordResetByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spResetCandidatePassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "resetCandidatePassword()", "");
            }
        }
        public Int64 checkCandidateApplicationIDAndDOB(string ApplicationID, DateTime DOB)
        {
            try
            {
                object[] parameters = { ApplicationID, DOB };
                return Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckCandidateApplicationIDAndDOB", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkCandidateApplicationIDAndDOB()", "");
            }
        }
        public string verifyCandidateMobileNo(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spVerifyCandidateMobileNo", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyCandidateMobileNo()", "");
            }
        }
        public bool sendCandidateOTPCodeForResetPassword(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSendCandidateOTPCodeForResetPassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "sendCandidateOTPCodeForResetPassword()", "");
            }
        }
        public bool verifyCandidateOTPCode(Int64 PID, string OTPCode)
        {

            try
            {
                object[] parameters = { PID, OTPCode };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spVerifyCandidateOTPCode", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyCandidateMobileNo()", "");
            }
        }
        public string verifyCandidateEMailID(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spVerifyCandidateEMailID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyCandidateEMailID()", "");
            }
        }
        public bool sendCandidateEMailVerificationCodeForResetPassword(Int64 PID, string EMailVerificationCode)
        {
            try
            {
                object[] parameters = { PID, EMailVerificationCode };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSendCandidateEMailVerificationCodeForResetPassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "sendCandidateEMailVerificationCodeForResetPassword()", "");
            }
        }
        public bool verifyCandidateEMailVerificationCode(Int64 PID, string EMailVerificationCode)
        {
            try
            {
                object[] parameters = { PID, EMailVerificationCode };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spVerifyCandidateEMailVerificationCode", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyCandidateEMailVerificationCode()", "");
            }
        }

        public string checkOthersSecurityQuestionDetails(string LoginID, Int16 SecurityQuestionID, string SecurityAnswer)
        {

            try
            {
                object[] parameters = { LoginID, SecurityQuestionID, SecurityAnswer };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckOthersSecurityQuestionDetails", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkOthersSecurityQuestionDetails()", "");
            }
        }
        public bool resetOthersPassword(string LoginID, string Password, string PasswordResetByIPAddress)
        {

            try
            {
                object[] parameters = { LoginID, Password, PasswordResetByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spResetOthersPassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "resetOthersPassword()", "");
            }

        }
        public string checkOthersLoginIDAndDOB(string LoginID, DateTime DOB)
        {

            try
            {
                object[] parameters = { LoginID, DOB };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckOthersLoginIDAndDOB", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkOthersLoginIDAndDOB()", "");
            }
        }
        public string verifyOthersMobileNo(string LoginID)
        {
            try
            {
                object[] parameters = { LoginID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spVerifyOthersMobileNo", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyOthersMobileNo()", "");
            }
        }
        public bool sendOthersOTPCodeForResetPassword(string LoginID)
        {
            try
            {
                object[] parameters = { LoginID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSendOthersOTPCodeForResetPassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "sendOthersOTPCodeForResetPassword()", "");
            }
        }
        public bool verifyOthersOTPCode(string LoginID, string OTPCode)
        {
            try
            {
                object[] parameters = { LoginID, OTPCode };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spVerifyOthersOTPCode", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyOthersOTPCode()", "");
            }
        }
        public string verifyOthersEMailID(string LoginID)
        {
            try
            {
                object[] parameters = { LoginID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spVerifyOthersEMailID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyOthersEMailID()", "");
            }
        }
        public bool sendOthersEMailVerificationCodeForResetPassword(string LoginID, string EMailVerificationCode)
        {
            try
            {
                object[] parameters = { LoginID, EMailVerificationCode };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSendOthersEMailVerificationCodeForResetPassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "sendOthersEMailVerificationCodeForResetPassword()", "");
            }
        }
        public bool verifyOthersEMailVerificationCode(string LoginID, string EMailVerificationCode)
        {
            try
            {
                object[] parameters = { LoginID, EMailVerificationCode };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spVerifyOthersEMailVerificationCode", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyOthersEMailVerificationCode()", "");
            }
        }
        public DataSet checkCETDetails(Int64 CETApplicationFormNo, string CETRollNo, string DOB)
        {
            try
            {
                object[] parameters = { CETApplicationFormNo, CETRollNo, DOB };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCheckCETDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkCETDetails()", "");
            }
        }
        public DataSet getRegistrationDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRegistrationDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRegistrationDetails()", "");
            }
        }
        public string saveRegistrationDetails(RegistrationDetails obj, string CandidatePassword, Int16 SecurityQuestionID, string SecurityAnswer, Int64 CETApplicationFormNo, string OTP, string IsActive, string ModifiedBy, string ModifiedByIPAddress, string FCRApplicationID, string FCRCandidateName, string FCRCandidatureTypeName, string FCRMotherName, string FCRGender, DateTime FCRDOB)
        {
            try
            {
                object[] parameters = {
            obj.CandidateName,obj.FatherName,obj.MotherName,obj.GenderCode,obj.DOB, obj.ReligionID, obj.RegionCode, obj.MotherTongueID,obj.AnnualFamilyIncomeID, obj.AadhaarNumber,
            obj.NationalityID, obj.CAddressLine1, obj.CAddressLine2, obj.CAddressLine3, obj.CAddress, obj.CStateID, obj.CDistrictID, obj.CTalukaID, obj.CVillageID, obj.CPincode,
            obj.STDCode, obj.PhoneNo, obj.MobileNo, obj.EMailID, obj.HasBankAccount, obj.AccountNumber, obj.IFSCCode, CandidatePassword, SecurityQuestionID, SecurityAnswer,
            CETApplicationFormNo, OTP, IsActive, ModifiedBy, ModifiedByIPAddress, FCRApplicationID, FCRCandidateName, FCRCandidatureTypeName, FCRMotherName, FCRGender, FCRDOB };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveRegistrationDetails", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveRegistrationDetails()", "");
            }
        }
        public bool updateRegistrationDetails(RegistrationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = {obj.PID,
            obj.CandidateName,obj.FatherName,obj.MotherName,obj.GenderCode,obj.DOB, obj.ReligionID, obj.RegionCode, obj.MotherTongueID,obj.AnnualFamilyIncomeID, obj.AadhaarNumber,
            obj.NationalityID, obj.CAddressLine1, obj.CAddressLine2, obj.CAddressLine3, obj.CAddress, obj.CStateID, obj.CDistrictID, obj.CTalukaID, obj.CVillageID, obj.CPincode,
            obj.STDCode, obj.PhoneNo,   obj.EMailID, obj.HasBankAccount, obj.AccountNumber, obj.IFSCCode,ModifiedBy, ModifiedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateRegistrationDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateRegistrationDetails()", "");
            }
        }
        public Int16 getCandidatureTypeID(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetCandidatureTypeID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidatureTypeID()", "");
            }
        }
        public bool saveCandidatureTypeDetails(Int64 PID, Int16 CandidatureTypeID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CandidatureTypeID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveCandidatureTypeDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveCandidatureTypeDetails()", "");
            }
        }
        public DataSet getHomeUniversityAndCategoryDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetHomeUniversityAndCategoryDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getHomeUniversityAndCategoryDetails()", "");
            }

        }
        public bool saveHomeUniversityAndCategoryDetails(HomeUniversityAndCategoryDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = {obj.PID, obj.DocumentForTypeACode, obj.DocumentOfCode, obj.MothersName, obj.SSCDistrictID, obj.HSCDistrictID, obj.HSCTalukaID, obj.HomeUniversityID,
                obj.CategoryID, obj.CasteNameForOpen, obj.CasteID, obj.AppliedForEWS, obj.CasteValidityStatus, obj.CVCApplicationNo, obj.CVCApplicationDate, obj.CVCAuthority, obj.CVCName,
                obj.CCNumber, obj.CVCDistrict, obj.NCLStatus, obj.NCLApplicationNo, obj.NCLApplicationDate, obj.NCLAuthority,
                obj.EWSStatus, obj.EWSApplicationNo, obj.EWSApplicationDate, obj.EWSDistrict, obj.EWSTaluka,
                    ModifiedBy, ModifiedByIPAddress,obj.HSCVillageID};
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveHomeUniversityAndCategoryDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveHomeUniversityAndCategoryDetails()", "");
            }
        }
        public DataSet getSpecialReservationDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSpecialReservationDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSpecialReservationDetails()", "");
            }
        }
        public bool saveSpecialReservationDetails(SpecialReservationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { obj.PID, obj.PHTypeID, obj.DefenceTypeID, obj.IsOrphan, obj.OrphanRegistrationNo, obj.OrphanHasRelative,obj.AppliedForTFWS, obj.AppliedForMinoritySeats,
            obj.LinguisticMinorityID, obj.ReligiousMinorityID, ModifiedBy, ModifiedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveSpecialReservationDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveSpecialReservationDetails()", "");
            }
        }
        public DataSet getQualificationDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetQualificationDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getQualificationDetails()", "");
            }
        }
        public bool saveQualificationDetails(QualificationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = {obj.PID,obj.SSCBoardID, obj.SSCPassingYear, obj.SSCSeatNo, obj.SSCMathMarksObtained, obj.SSCMathMarksOutOf, obj.SSCMathPercentage,
             obj.SSCTotalMarksObtained, obj.SSCTotalMarksOutOf, obj.SSCTotalPercentage,obj.HSCPlace,obj.HSCBoardID,obj.OtherHSCBoard,
             obj.HSCPassingYear,obj.HSCSeatNo,obj.HSCPassingStatus,obj.HSCPhysicsMarksObtained, obj.HSCPhysicsMarksOutOf, obj.HSCPhysicsPercentage,
             obj.HSCChemistryMarksObtained, obj.HSCChemistryMarksOutOf,obj.HSCChemistryPercentage,obj.HSCSubjectID,obj.HSCSubjectMarksObtained, obj.HSCSubjectMarksOutOf,
             obj.HSCSubjectPercentage,obj.HSCBioTechnologyMarksObtained,obj.HSCBioTechnologyMarksOutOf,obj.HSCBioTechnologyPercentage,
             obj.HSCEnglishMarksObtained, obj.HSCEnglishMarksOutOf, obj.HSCEnglishPercentage,obj.HSCTotalMarksObtained, obj.HSCTotalMarksOutOf,
             obj.HSCTotalPercentage,obj.HSCPCSPercentage,obj.AppearedForDiploma,obj.DiplomaMarksType,obj.DiplomaTotalMarksObtained, obj.DiplomaTotalMarksOutOf, obj.DiplomaTotalPercentage,
             ModifiedBy, ModifiedByIPAddress,obj.NameAsPerHSCResult,obj.IsResultFetched,obj.HSCQDDOB, obj.HSCMotherName };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveQualificationDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveQualificationDetails()", "");
            }
        }
        public DataSet getNEETDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetNEETDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getNEETDetails()", "");
            }
        }
        public bool saveNEETDetails(NEETDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = {obj.PID, obj.AppearedForNEET, obj.NEETRollNo, obj.NEETPhysicsScore, obj.NEETChemistryScore,
              obj.NEETBiologyScore, obj.NEETTotalScore, obj.NameAsPerNEET, obj.NameMatchingFlag, ModifiedBy, ModifiedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveNEETDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveNEETDetails()", "");
            }
        }
        public DataSet checkNEETDetailsOnSave(NEETDetails obj)
        {
            try
            {
                object[] parameters = { obj.PID, obj.AppearedForNEET, obj.NEETRollNo, obj.NEETPhysicsScore, obj.NEETChemistryScore, obj.NEETBiologyScore, obj.NEETTotalScore };

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCheckNEETDetailsOnSave", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkNEETDetailsOnSave()", "");
            }
        }
        public DataSet checkNEETDetails(Int64 PID, Int64 NEETRollNo, string AppearedForNEET)
        {
            try
            {
                object[] parameters = { PID, NEETRollNo, AppearedForNEET };

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCheckNEETDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkNEETDetails()", "");
            }
        }
        public bool saveScannedImagesStepID(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveScanedImagesStepID", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveScannedImagesStepID()", "");
            }
        }
        public bool savePayApplicationFeeStepID(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSavePayApplicationFeeStepID", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveScannedImagesStepID()", "");
            }
        }
        public DataSet getPersonalInformation(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformation", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPersonalInformation()", "");
            }
        }
        public DataSet getSecurityQuestionDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSecurityQuestionDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSecurityQuestionDetails()", "");
            }
        }
        public bool saveSecurityQuestionDetails(Int64 PID, Int16 SecurityQuestionID, string SecurityAnswer, string ModifiedBy, string ModifiedByIPAddress)
        {


            try
            {
                object[] parameters = { PID, SecurityQuestionID, SecurityAnswer, ModifiedBy, ModifiedByIPAddress };
                int result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveSecurityQuestionDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveSecurityQuestionDetails()", "");
            }
        }
        public bool saveFeedback(Int64 PID, string Feedback, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, Feedback, CreatedBy, CreatedByIPAddress };
                int result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveFeedback", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveFeedback()", "");
            }
        }
        public bool editRegistrationDetails(RegistrationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = {obj.PID,
            obj.CandidateName,obj.FatherName,obj.MotherName,obj.GenderCode,obj.DOB, obj.ReligionID, obj.RegionCode, obj.MotherTongueID,obj.AnnualFamilyIncomeID,
            obj.NationalityID,ModifiedBy, ModifiedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditRegistrationDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editRegistrationDetails()", "");
            }
        }
        public bool editCandidatureTypeDetails(Int64 PID, Int16 CandidatureTypeID, HomeUniversityAndCategoryDetails objHUC, SpecialReservationDetails objSR, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID,  CandidatureTypeID, objHUC.DocumentForTypeACode, objHUC.DocumentOfCode, objHUC.MothersName, objHUC.SSCDistrictID, objHUC.HSCDistrictID,
                    objHUC.HSCTalukaID, objHUC.HomeUniversityID, objHUC.CategoryID, objHUC.CasteNameForOpen, objHUC.CasteID, objHUC.CasteValidityStatus, objHUC.CVCApplicationNo,
                objHUC.CVCApplicationDate, objHUC.CVCAuthority, objHUC.CVCName, objHUC.CCNumber, objHUC.CVCDistrict, objSR.PHTypeID, objSR.DefenceTypeID, objSR.IsOrphan,
                objSR.AppliedForMinoritySeats, objSR.LinguisticMinorityID, objSR.ReligiousMinorityID, ModifiedBy, ModifiedByIPAddress};
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditCandidatureTypeDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editCandidatureTypeDetails()", "");
            }
        }
        public bool editCandidatureTypeDetailsForARC(Int64 PID, Int16 CandidatureTypeID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CandidatureTypeID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditCandidatureTypeDetailsForARC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editCandidatureTypeDetailsForARC()", "");
            }
        }
        public bool editHomeUniversityAndCategoryDetails(HomeUniversityAndCategoryDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = {obj.PID, obj.DocumentForTypeACode, obj.DocumentOfCode, obj.MothersName, obj.SSCDistrictID, obj.HSCDistrictID, obj.HSCTalukaID, obj.HomeUniversityID,
                obj.CategoryID, obj.CasteNameForOpen, obj.CasteID, obj.AppliedForEWS, obj.CasteValidityStatus, obj.CVCApplicationNo, obj.CVCApplicationDate, obj.CVCAuthority, obj.CVCName,
                obj.CCNumber, obj.CVCDistrict, obj.NCLStatus, obj.NCLApplicationNo, obj.NCLApplicationDate, obj.NCLAuthority, obj.HSCVillageID,
                obj.EWSStatus, obj.EWSApplicationNo, obj.EWSApplicationDate, obj.EWSDistrict, obj.EWSTaluka, ModifiedBy, ModifiedByIPAddress};

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditHomeUniversityAndCategoryDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editHomeUniversityAndCategoryDetails()", "");
            }
        }
        public bool editSpecialReservationDetails(SpecialReservationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { obj.PID, obj.PHTypeID, obj.DefenceTypeID, obj.IsOrphan, obj.OrphanRegistrationNo, obj.OrphanHasRelative, obj.AppliedForTFWS, obj.AppliedForMinoritySeats,
            obj.LinguisticMinorityID, obj.ReligiousMinorityID, ModifiedBy, ModifiedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditSpecialReservationDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editSpecialReservationDetails()", "");
            }
        }
        public bool editQualificationDetails(QualificationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = {obj.PID,obj.SSCBoardID, obj.SSCPassingYear, obj.SSCSeatNo, obj.SSCMathMarksObtained, obj.SSCMathMarksOutOf, obj.SSCMathPercentage,
             obj.SSCTotalMarksObtained, obj.SSCTotalMarksOutOf, obj.SSCTotalPercentage,obj.HSCPlace,obj.HSCBoardID,obj.OtherHSCBoard,
             obj.HSCPassingYear,obj.HSCSeatNo,obj.HSCPassingStatus,obj.HSCPhysicsMarksObtained, obj.HSCPhysicsMarksOutOf, obj.HSCPhysicsPercentage,
             obj.HSCChemistryMarksObtained, obj.HSCChemistryMarksOutOf,obj.HSCChemistryPercentage,obj.HSCSubjectID,obj.HSCSubjectMarksObtained, obj.HSCSubjectMarksOutOf,
             obj.HSCSubjectPercentage,obj.HSCBioTechnologyMarksObtained,obj.HSCBioTechnologyMarksOutOf,obj.HSCBioTechnologyPercentage,
             obj.HSCEnglishMarksObtained, obj.HSCEnglishMarksOutOf, obj.HSCEnglishPercentage,obj.HSCTotalMarksObtained, obj.HSCTotalMarksOutOf,
             obj.HSCTotalPercentage,obj.HSCPCSPercentage,obj.AppearedForDiploma,obj.DiplomaMarksType,obj.DiplomaTotalMarksObtained, obj.DiplomaTotalMarksOutOf, obj.DiplomaTotalPercentage,
             ModifiedBy, ModifiedByIPAddress,obj.NameAsPerHSCResult,obj.IsResultFetched,obj.HSCQDDOB,obj.HSCMotherName };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditQualificationDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editQualificationDetails()", "");
            }
        }
        public bool editNEETDetails(NEETDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { obj.PID, obj.AppearedForNEET, obj.NEETRollNo, obj.NEETPhysicsScore, obj.NEETChemistryScore, obj.NEETBiologyScore,  obj.NEETTotalScore, obj.NameAsPerNEET, obj.NameMatchingFlag,
                ModifiedBy, ModifiedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditNEETDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editNEETDetails()", "");
            }
        }
        public Int16 getStepIDApplicationRound(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int16 result = Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetStepIDApplicationRound", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getStepIDApplicationRound()", "");
            }
        }
        public DataSet getSessionDataForCandidate(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSessionDataForCandidate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getStepIDApplicationRound()", "");
            }
        }
        public Int16 getAnnualFamilyIncomeID(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int16 result = Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetAnnualFamilyIncomeID", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAnnualFamilyIncomeID()", "");
            }
        }
        public string getAnnualFamilyIncomeDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetAnnualFamilyIncomeDetails", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAnnualFamilyIncomeDetails()", "");
            }
        }
        public string getNationality(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetNationality", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getNationality()", "");
            }
        }
        public Int16 getCategoryID(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int16 result = Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetCategoryID", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCategoryID()", "");
            }
        }
        public Int16 getPHTypeID(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int16 result = Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPHTypeID", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCategoryID()", "");
            }
        }
        public DataSet getDocumentList(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDocumentList()", "");
            }
        }
        public bool saveLogOutDateTime(Int64 SessionID)
        {
            try
            {
                object[] parameters = { SessionID };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveLogOutDateTime", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveLogOutDateTime()", "");
            }
        }
        public char getApplicationFormStatusApplicationRound(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };

                char result = Convert.ToChar(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetApplicationFormStatusApplicationRound", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getApplicationFormStatusApplicationRound()", "");
            }
        }
        public Int32 getApplicationFeeToBePaid(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetApplicationFeeToBePaid", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getApplicationFeeToBePaid()", "");
            }
        }
        public DataSet getCETDetails(Int64 CETApplicationFormNo)
        {

            try
            {
                object[] parameters = { CETApplicationFormNo };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCETDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCETDetails()", "");
            }
        }
        public DataSet Get_MSNEETDetails(Int64 NEETRollNo)
        {

            try
            {
                object[] parameters = { NEETRollNo };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGet_MSNEETDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCETDetails()", "");
            }
        }
        public Int32 getApplicationFeePaidAmount(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetApplicationFeePaidAmount", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getApplicationFeePaidAmount()", "");
            }
        }
        public Int64 getCETApplicationFormNo(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int64 result = Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetCETApplicationFormNo", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCETApplicationFormNo()", "");
            }
        }
        public string getMotherTongue(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetMotherTongue", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMotherTongue()", "");
            }
        }
        public string getReligion(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetReligion", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReligion()", "");
            }
        }
        public DataSet getRequiredDocumentsUploadStatusReportForCandidate(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRequiredDocumentsUploadStatusReportForCandidate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRequiredDocumentsUploadStatusReportForCandidate()", "");
            }
        }
        public DataSet getCurrentAllotmentDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCurrentAllotmentDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCurrentAllotmentDetails()", "");
            }
        }
        public DataSet getCurrentAdmissionDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCurrentAdmissionDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCurrentAdmissionDetails()", "");
            }
        }
        public bool isCandidateNameAppearedInFinalMeritList(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 QueryResult;
                QueryResult = (Int32)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateNameAppearedInFinalMeritList", parameters);
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateNameAppearedInFinalMeritList()", "");
            }
        }
        public DataSet getResult(Int64 CETApplicationFormNo)
        {
            try
            {
                object[] parameters = { CETApplicationFormNo };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetResult", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getResult()", "");
            }
        }
        public DataSet getCurrentLink(Int64 PID, string URL)
        {
            try
            {
                object[] parameters = { PID, URL };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCurrentLink", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCurrentLink()", "");
            }
        }
        public DataSet getEligibilityFlag(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetEligibilityFlag", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getEligibilityFlag()", "");
            }
        }
        public Int32 getProposedApplicationFeeToBePaid(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsEWSChanged)
        {
            try
            {
                object[] parameters = { PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsEWSChanged };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetProposedApplicationFeeToBePaid", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getEligibilityFlag()", "");
            }
        }
        public DataSet getProvisionalMeritStatus(string ApplicationID, DateTime DOB)
        {
            try
            {
                object[] parameters = { ApplicationID, DOB };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetProvisionalMeritStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProvisionalMeritStatus()", "");
            }
        }
        public DataSet getFinalMeritStatus(string ApplicationID, DateTime DOB)
        {
            try
            {
                object[] parameters = { ApplicationID, DOB };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetFinalMeritStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getFinalMeritStatus()", "");
            }
        }
        public string getQualifyingExam(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetQualifyingExam", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getEligibilityFlag()", "");
            }
        }
        public bool verifyOTP(string ApplicationID, string OneTimePassword, int OTPType)
        {
            try
            {
                object[] parameters = { ApplicationID, Convert.ToInt32(OneTimePassword), OTPType };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spVerifyOTP", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyOTP()", "");
            }
        }
        public DataSet getOTPDetails(string ApplicationID, string OneTimePassword)
        {
            try
            {
                object[] parameters = { ApplicationID, OneTimePassword };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOTPDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOTPDetails()", "");
            }
        }
        public bool isApplicationFormConfirmedUsingThisMobileNo(string MobileNo)
        {

            try
            {
                object[] parameters = { MobileNo };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsApplicationFormConfirmedUsingThisMobileNo", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyOTP()", "");
            }
        }

        public DataSet isApplicationFormConfirmedUsingThisCETApplicationNo(Int64 CETApplicationFormNo, Int64 PID)
        {
            try
            {
                object[] parameters = { CETApplicationFormNo, PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spIsApplicationFormConfirmedUsingThisCETApplicationNo", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isApplicationFormConfirmedUsingThisCETApplicationNo()", "");
            }
        }
        public DataSet isApplicationFormConfirmedUsingThisNEETRollNo(Int64 NEETRollNo, Int64 PID)
        {
            try
            {
                object[] parameters = { NEETRollNo, PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spIsApplicationFormConfirmedUsingThisNEETRollNo", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isApplicationFormConfirmedUsingThisNEETRollNo()", "");
            }
        }

        public DataSet getSMSContent(Int64 PID, string Flag)
        {
            try
            {
                object[] parameters = { PID, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSMSContent", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSMSContent()", "");
            }
        }
        public DataSet checkJEEDetails(Int64 PID, string JEERollNo, string AppearedForJEE)
        {
            try
            {
                object[] parameters = { PID, JEERollNo, AppearedForJEE };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCheckJEEDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkJEEDetails()", "");
            }

        }
        public bool saveOTPForMobileNoChange(Int64 PID, string OTP)
        {
            try
            {
                object[] parameters = { PID, OTP };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOTPForMobileNoChange", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveOTPForMobileNoChange()", "");
            }
        }
        public bool verifyOTPForMobileNoChange(Int64 PID, string OTP, string MobileNo, string IpAddress, string UserLoginID)
        {
            try
            {
                object[] parameters = { PID, OTP, MobileNo, IpAddress, UserLoginID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spVerifyOTPForMobileNoChange", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyOTPForMobileNoChange()", "");
            }
        }
        public string getMobileNo(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetMobileNo", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMobileNo()", "");
            }
        }
        public bool isApplicationFormEligibleForEditting(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 QueryResult;
                QueryResult = (Int32)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsApplicationFormEligibleForEditting", parameters);
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isApplicationFormEligibleForEditting()", "");
            }
        }
        public string isCandidateEligibleForEdittingAtARC(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateEligibleForEdittingAtARC", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateEligibleForEdittingAtARC()", "");
            }
        }

        public DataSet getAdminNonRepliedMessages(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdminNonRepliedMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdminNonRepliedMessages()", "");
            }
        }
        public DataSet getAdminRepliedMessages(string Flag)
        {

            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdminRepliedMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdminRepliedMessages()", "");
            }
        }
        public DataSet getAdminSentMessages(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdminSentMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdminSentMessages()", "");
            }
        }
        public DataSet getMessagesList(string From)
        {
            try
            {
                object[] parameters = { From };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMessagesList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMessagesList()", "");
            }
        }
        public bool replyMessage(Int64 MessageID, string RepliedMessage, string RepliedBy, string RepliedByIPAddress, string RepliedTo, string IsStarMarked)
        {
            try
            {
                object[] parameters = { MessageID, RepliedMessage, RepliedBy, RepliedByIPAddress, RepliedTo, IsStarMarked };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spReplyMessage", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "replyMessage()", "");
            }
        }
        public bool adminComposeMessage(string To, string From, string Message, string FilePath1, string FilePath2, string SentBy, string SentByIPAddress)
        {
            try
            {
                object[] parameters = { To, From, Message, FilePath1, FilePath2, SentBy, SentByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAdminComposeMessage", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "adminComposeMessage()", "");
            }
        }
        public DataSet getAFCNonRepliedMessages(string AFCCode)
        {
            try
            {
                object[] parameters = { AFCCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCNonRepliedMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCNonRepliedMessages()", "");
            }
        }
        public DataSet getAFCBroadcastedMessages(string AFCCode)
        {
            try
            {
                object[] parameters = { AFCCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCBroadcastMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCBroadcastedMessages()", "");
            }
        }
        public DataSet getAFCRepliedMessages(string AFCCode)
        {
            try
            {
                object[] parameters = { AFCCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCRepliedMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCRepliedMessages()", "");
            }
        }
        public bool afcComposeMessage(string To, string From, string Subject, string Message, string FilePath1, string FilePath2, string SentBy, string SentByIPAddress)
        {
            try
            {
                object[] parameters = { To, From, Subject, Message, FilePath1, FilePath2, SentBy, SentByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spAFCComposeMessage", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "afcComposeMessage()", "");
            }
        }
        public DataSet adminComposeSMS(string To, string From, string Message, string SentBy, string SentByIPAddress)
        {
            try
            {
                object[] parameters = { To, From, Message, SentBy, SentByIPAddress };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spAdminComposeSMS", parameters);
                //if (result > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "adminComposeSMS()", "");
            }
        }
        public DataSet getAdminSentSMSs(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdminSentSMSs", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdminSentSMSs()", "");
            }
        }
        public DataSet getRONonRepliedMessages(string Flag, string LoginID)
        {
            try
            {
                object[] parameters = { Flag, LoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRONonRepliedMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRONonRepliedMessages()", "");
            }
        }
        public DataSet getRORepliedMessages(string Flag, string LoginID)
        {
            try
            {
                object[] parameters = { Flag, LoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRORepliedMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRORepliedMessages()", "");
            }
        }
        public DataSet getROSentMessages(string Flag, string LoginID)
        {
            try
            {
                object[] parameters = { Flag, LoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetROSentMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getROSentMessages()", "");
            }

        }
        public bool roComposeMessage(string To, string From, string Message, string FilePath1, string FilePath2, string SentBy, string SentByIPAddress)
        {
            try
            {
                object[] parameters = { To, From, Message, FilePath1, FilePath2, SentBy, SentByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spROComposeMessage", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "afcComposeMessage()", "");
            }
        }
        public DataSet getInstituteNonRepliedMessages(string InstituteCode)
        {
            try
            {
                object[] parameters = { InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteNonRepliedMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteNonRepliedMessages()", "");
            }
        }
        public DataSet getInstituteBroadcastedMessages(string InstituteCode)
        {
            try
            {
                object[] parameters = { InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteBroadcastMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteBroadcastedMessages()", "");
            }
        }
        public DataSet getInstituteRepliedMessages(string InstituteCode)
        {
            try
            {
                object[] parameters = { InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteRepliedMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteRepliedMessages()", "");
            }
        }
        public bool instituteComposeMessage(string To, string From, string Subject, string Message, string FilePath1, string FilePath2, string SentBy, string SentByIPAddress)
        {

            try
            {
                object[] parameters = { To, From, Subject, Message, FilePath1, FilePath2, SentBy, SentByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInstituteComposeMessage", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "instituteComposeMessage()", "");
            }
        }
        public Int64 getPersonalID(string ApplicationID)
        {
            try
            {
                object[] parameters = { ApplicationID };
                return Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPersonalID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdminSentSMSs()", "");
            }
        }
        public string getCandidateName(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetCandidateName", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdminSentSMSs()", "");
            }
        }
        public bool resetCandidatePasswordByAdmin(Int64 PID, string CandidatePassword, string PasswordResetBy, string PasswordResetByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CandidatePassword, PasswordResetBy, PasswordResetByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spResetCandidatePasswordByAdmin", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "resetCandidatePasswordByAdmin()", "");
            }
        }
        public bool updateUserAction(string UserLoginID, string ApplicationID, string ActionTaken, string Module, string IPAddress)
        {

            try
            {
                object[] parameters = { UserLoginID, ApplicationID, ActionTaken, Module, IPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateUserAction", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateUserAction()", "");
            }
        }
        public DataSet getDashboardAFC(Int32 UserTypeID, string UserLoginID, string Flag)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDashboardAFC", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDashboardAFC()", "");
            }
        }
        public DataSet getDashboardARC(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDashboardARC", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDashboardARC()", "");
            }
        }
        public DataSet getDashboardInstitute(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDashboardInstitute", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDashboardInstitute()", "");
            }
        }
        public DataSet getCandidateDetailsForDisplay(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateDetailsForDisplay", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidateDetailsForDisplay()", "");
            }
        }
        public DataSet searchCandidate(string Query)
        {

            try
            {
                object[] parameters = { Query };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spSearchCandidate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "searchCandidate()", "");
            }
        }
        public DataSet getLoginDetails(string LoginID, Int32 UserTypeID)
        {
            try
            {
                object[] parameters = { LoginID, UserTypeID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetLoginDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getLoginDetails()", "");
            }
        }
        public DataSet getMasterAFCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterAFCList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterAFCList()", "");
            }
        }
        public DataSet getNonAFCInstituteList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetNonAFCInstituteList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getNonAFCInstituteList()", "");
            }
        }
        public bool addMasterAFC(Int64 InstituteID, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { InstituteID, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAddMasterAFC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "addMasterAFC()", "");
            }
        }
        public bool deleteMasterAFC(Int64 InstituteID, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { InstituteID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteMasterAFC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteMasterAFC()", "");
            }
        }
        public bool isInstituteWorkingAsAFC(Int64 InstituteID)
        {

            try
            {
                object[] parameters = { InstituteID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsInstituteWorkingAsAFC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isInstituteWorkingAsAFC()", "");
            }
        }
        public DataSet getAFCList(Int64 InstituteID)
        {
            try
            {
                object[] parameters = { InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCListByInstituteID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCList()", "");
            }
        }
        public string addAFC(Int64 InstituteID, string AFCOfficerName, string AFCOfficerMobileNo, string Password, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { InstituteID, AFCOfficerName, AFCOfficerMobileNo, Password, CreatedBy, CreatedByIPAddress };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAddAFC", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "addAFC()", "");
            }
        }
        public bool updateAFC(Int64 AFCID, string AFCOfficerName, string AFCOfficerMobileNo, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { AFCID, AFCOfficerName, AFCOfficerMobileNo, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateAFC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateAFC()", "");
            }
        }
        public bool deleteAFC(Int64 AFCID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { AFCID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteAFC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteAFC()", "");
            }
        }
        public DataSet getSubAFCList(Int64 AFCID)
        {
            try
            {
                object[] parameters = { AFCID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubAFCListByAFCID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSubAFCList()", "");
            }




        }
        public string addSubAFC(Int64 AFCID, string SubAFCOfficerName, string SubAFCOfficerMobileNo, string Password, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { AFCID, SubAFCOfficerName, SubAFCOfficerMobileNo, Password, CreatedBy, CreatedByIPAddress };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAddSubAFC", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "addSubAFC()", "");
            }
        }
        public bool updateSubAFC(Int64 SubAFCID, string SubAFCOfficerName, string SubAFCOfficerMobileNo, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { SubAFCID, SubAFCOfficerName, SubAFCOfficerMobileNo, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateSubAFC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateSubAFC()", "");
            }
        }
        public bool deleteSubAFC(Int64 SubAFCID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { SubAFCID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteSubAFC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteSubAFC()", "");
            }
        }
        public DataSet getROList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetROList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getROList()", "");
            }
        }
        public DataSet getAFCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCList()", "");
            }
        }
        public DataSet getSubAFCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubAFCList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSubAFCList()", "");
            }
        }
        public string getPassword(Int32 UserTypeID, string LoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, LoginID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPassword", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPassword()", "");
            }
        }
        public bool resetPassword(Int32 UserTypeID, string LoginID, string Password, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { UserTypeID, LoginID, Password, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spResetPassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPassword()", "");
            }
        }
        public bool saveAFCProfile(AFCProfile obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { obj.AFCCode, obj.AFCAddress, obj.AFCPhoneNo, obj.AFCFaxNo, obj.CoordinatorName, obj.CoordinatorDesignation, obj.CoordinatorDOB,obj.CoordinatorMobileNo,
                    obj.CoordinatorAltMobileNo,obj.CoordinatorEmailID,obj.CoordinatorPhoneNo,obj.SecurityQuestionID,obj.SecurityAnswer,obj.AFCPassword,
                    ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveAFCProfile", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveAFCProfile()", "");
            }
        }
        public bool updateAFCProfile(AFCProfile obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { obj.AFCCode, obj.AFCAddress, obj.AFCPhoneNo, obj.AFCFaxNo, obj.CoordinatorName, obj.CoordinatorDesignation, obj.CoordinatorDOB,obj.CoordinatorMobileNo,
                   obj.CoordinatorAltMobileNo, obj.CoordinatorEmailID,obj.CoordinatorPhoneNo,obj.SecurityQuestionID,obj.SecurityAnswer, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateAFCProfile", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateAFCProfile()", "");
            }
        }
        public DataSet getAFCProfile(string AFCCode)
        {
            try
            {
                object[] parameters = { AFCCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCProfile", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCProfile()", "");
            }

        }
        public DataSet getAFCListReport()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCListReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCProfile()", "");
            }
        }
        public DataSet checkUser(string UserLoginID)
        {
            try
            {
                object[] parameters = { UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCheckUser", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkUser()", "");
            }
        }
        public DataSet getRegionWiseReport(string ConfirmationDate)
        {
            try
            {
                object[] parameters = { ConfirmationDate };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRegionWiseReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRegionWiseReport()", "");
            }
        }
        public Int16 getRegionID(Int64 AFCID)
        {
            try
            {
                object[] parameters = { AFCID };
                return Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetRegionID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRegionID()", "");
            }
        }
        public DataSet getAFCWiseReport(Int16 RegionID, string ConfirmationDate)
        {
            try
            {
                object[] parameters = { RegionID, ConfirmationDate };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCWiseReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCWiseReport()", "");
            }
        }
        public Int32 getInstituteID(Int64 AFCID)
        {
            try
            {
                object[] parameters = { AFCID };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetInstituteID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteID()", "");
            }
        }
        public DataSet getSubAFCWiseReport(Int16 RegionID, Int32 InstituteID)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubAFCWiseReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSubAFCWiseReport()", "");
            }

        }
        public DataSet getConfirmationDateList()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetConfirmationDateList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getConfirmationDateList()", "");
            }
        }
        public DataSet getDiscrepancyDateList(Int32 InstituteID, Int32 AFCID)
        {
            try
            {
                object[] parameters = { InstituteID, AFCID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDiscrepancyDateList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDiscrepancyDateList()", "");
            }
        }
        public DataSet getConfirmedCandidateList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, AFCID, ConfirmationDate };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetConfirmedCandidateList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getConfirmedCandidateList()", "");
            }
        }
        public DataSet getARCList(Int32 UserTypeID, string UserLoginID)
        {

            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARCList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARCList()", "");
            }
        }
        public DataSet getSubARCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubARCList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSubARCList()", "");
            }
        }
        public Int64 checkApplicationStatus(string ApplicationID, Int32 VersionNo)
        {
            try
            {
                object[] parameters = { ApplicationID, VersionNo };
                Int64 result = Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckApplicationStatus", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkApplicationStatus()", "");
            }


        }
        public bool updateDocumentSubmission(Int64 PID, string XMLString, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, XMLString, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateDocumentSubmission", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateDocumentSubmission()", "");
            }
        }
        public DataSet getDocumentList(Int64 PID, string SubmittedFlag)
        {
            try
            {
                object[] parameters = { PID, SubmittedFlag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentListBySubmittedFlag", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDocumentList()", "");
            }
        }
        public bool confirmApplicationForm(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsMinorityChanged, Int32 IsEWSChanged, Int32 IsOrphanChanged, string Comments, string IsNCLReceiptSubmitted, DateTime NCLIssueDate, Int32 NCLValidUpto, Int32 IsTFWSChanged, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsMinorityChanged, IsEWSChanged, IsOrphanChanged, Comments, IsNCLReceiptSubmitted, NCLIssueDate, NCLValidUpto, IsTFWSChanged, ConfirmedBy, ConfirmedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmApplicationForm", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmApplicationForm()", "");
            }



        }
        public bool confirmApplicationFormProvisionally(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsMinorityChanged, Int32 IsEWSChanged, Int32 IsOrphanChanged, string Comments, string IsNCLReceiptSubmitted, DateTime NCLIssueDate, Int32 NCLValidUpto, Int32 IsTFWSChanged, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsMinorityChanged, IsEWSChanged, IsOrphanChanged, Comments, IsNCLReceiptSubmitted, NCLIssueDate, NCLValidUpto, IsTFWSChanged, ConfirmedBy, ConfirmedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmApplicationFormProvisionally", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmApplicationFormProvisionally()", "");
            }


        }
        public bool isApplicationFormConfirmed(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsApplicationFormConfirmed", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isApplicationFormConfirmed()", "");
            }
        }
        public DataSet getApplicationFormConfirmationDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationFormConfirmationDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getApplicationFormConfirmationDetails()", "");
            }
        }
        public bool checkApplicationFormConfirmationDetails(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {

            try
            {
                object[] parameters = { PID, UserTypeID, UserLoginID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckApplicationFormConfirmationDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkApplicationFormConfirmationDetails()", "");
            }
        }
        public DataSet getNCLDocumentDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetNCLDocumentDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getImportantDates()", "");
            }
        }
        public bool editConfirmedApplicationForm(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsMinorityChanged, Int32 IsEWSChanged, Int32 IsOrphanChanged, string Comments, string IsNCLReceiptSubmitted, DateTime NCLIssueDate, Int32 NCLValidUpto, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsMinorityChanged, IsEWSChanged, IsOrphanChanged, Comments, IsNCLReceiptSubmitted, NCLIssueDate, NCLValidUpto, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditConfirmedApplicationForm", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editConfirmedApplicationForm()", "");
            }
        }
        public bool cancelConfirmedApplicationForm(Int64 PID, string ReasonForCancellation, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ReasonForCancellation, CancelledBy, CancelledByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelConfirmedApplicationForm", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getImportantDates()", "");
            }
        }
        public bool checkDuplicateApplicationForm(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckDuplicateApplicationForm", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkDuplicateApplicationForm()", "");
            }
        }
        public DataSet getDuplicateApplicationFormDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDuplicateApplicationFormDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDuplicateApplicationFormDetails()", "");
            }
        }
        public bool sendSMSToCandidate(string From, string To, string SMSContent, string SentBy, string SentByIPAddress)
        {
            try
            {
                object[] parameters = { From, To, SMSContent, SentBy, SentByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSendSMSToCandidate", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "sendSMSToCandidate()", "");
            }
        }
        public bool editApplicationStatus(string ApplicationName, Int32 ApplicationStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { ApplicationName, ApplicationStatus, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spEditApplicationStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editApplicationStatus()", "");
            }
        }
        public Int64 getParentID(Int64 AFCID)
        {
            try
            {
                object[] parameters = { AFCID };
                return Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetParentID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getParentID()", "");
            }
        }
        public bool saveImportantDates(string ActivityDetails, DateTime ActivityStartDate, string ActivityStartTime, DateTime ActivityEndDate, string ActivityEndTime, DateTime ActivityDisplayStartDateTime, DateTime ActivityDisplayEndDateTime, string ActivityType, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { ActivityDetails, ActivityStartDate, ActivityStartTime, ActivityEndDate, ActivityEndTime, ActivityDisplayStartDateTime, ActivityDisplayEndDateTime, ActivityType, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveImportantDates", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveImportantDates()", "");
            }
        }
        public bool editImportantDates(Int64 ActivityID, string ActivityDetails, DateTime ActivityStartDate, string ActivityStartTime, DateTime ActivityEndDate, string ActivityEndTime, DateTime ActivityDisplayStartDateTime, DateTime ActivityDisplayEndDateTime, string ActivityType, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { ActivityID, ActivityDetails, ActivityStartDate, ActivityStartTime, ActivityEndDate, ActivityEndTime, ActivityDisplayStartDateTime, ActivityDisplayEndDateTime, ActivityType, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spEditImportantDates", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editImportantDates()", "");
            }
        }
        public bool deleteImportantDates(Int64 ActivityID, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { ActivityID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spDeleteImportantDates", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteImportantDates()", "");
            }


        }
        public DataSet getImportantDates(Int64 ActivityID)
        {
            try
            {
                object[] parameters = { ActivityID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetImportantDatesByActivityID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getImportantDates()", "");
            }
        }
        public DataSet getAllImportantDates()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllImportantDates");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllImportantDates()", "");
            }
        }
        public DataSet getImportantDates()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetImportantDates");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getImportantDates()", "");
            }
        }
        public DataSet getTopActiveImportantDates()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetTopActiveImportantDates");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getTopActiveImportantDates()", "");
            }

        }
        public Int32 getApplicationFeeDetails(Int32 CandidatureTypeID, Int32 CategoryID, Int32 PHTypeID, string AppliedForEWS)
        {
            try
            {
                object[] parameters = { CandidatureTypeID, CategoryID, PHTypeID, AppliedForEWS };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetApplicationFeeDetails", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getReportsList()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReportsList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReportsList()", "");
            }
        }
        public DataSet executeReport(Int64 ReportID)
        {
            try
            {
                object[] parameters = { ReportID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spExecuteReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "executeReport()", "");
            }
        }
        public DataSet searchReport(string Query)
        {
            try
            {
                object[] parameters = { Query };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spSearchReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "searchReport()", "");
            }
        }
        public DataSet getTableViewList()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetTableViewList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getTableViewList()", "");
            }




        }
        public DataSet getRejectedKeyWordList()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRejectedKeyWordList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getColumnsList(string TableViewName)
        {

            try
            {
                object[] parameters = { TableViewName };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetColumnsList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getColumnsList()", "");
            }
        }
        public bool saveReportDetails(string ReportName, string ReportQuery, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { ReportName, ReportQuery, CreatedBy, CreatedByIPAddress };
                Int32 QueryResult = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveReportDetails", parameters));
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public bool editReportDetails(Int64 ReportID, string ReportName, string ReportQuery, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { ReportID, ReportName, ReportQuery, ModifiedBy, ModifiedByIPAddress };
                Int32 QueryResult = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditReportDetails", parameters));
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editReportDetails()", "");
            }
        }
        public bool deleteReportDetails(Int64 ReportID, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { ReportID, ModifiedBy, ModifiedByIPAddress };
                Int32 QueryResult = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteReportDetails", parameters));
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteReportDetails()", "");
            }
        }
        public DataSet getReportDetails(Int64 ReportID)
        {
            try
            {
                object[] parameters = { ReportID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReportDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReportDetails()", "");
            }
        }
        public bool saveCaste(string CasteName, string CasteSrNo, Int16 CategoryID)
        {
            try
            {
                object[] parameters = { CasteName, CasteSrNo, CategoryID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveCaste", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveCaste()", "");
            }
        }
        public bool deleteCaste(Int32 CasteID)
        {
            try
            {
                object[] parameters = { CasteID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spDeleteCaste", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteCaste()", "");
            }
        }
        public DataSet getCaste(Int32 CasteID)
        {
            try
            {
                object[] parameters = { CasteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCaste", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCaste()", "");
            }
        }
        public bool updateCaste(CasteList Caste)
        {
            try
            {
                object[] parameters = { Caste.CasteID, Caste.CasteName, Caste.CasteSrNo };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdateCaste", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateCaste()", "");
            }
        }

        public DataSet getInstituteList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteList()", "");
            }
        }
        public bool changeInstitutePassword(string InstituteCode, string OldPassword, string NewPassword)
        {
            try
            {
                object[] parameters = { InstituteCode, OldPassword, NewPassword };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spChangeInstitutePassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public bool updateInstituteProfile(InstituteProfile obj, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { obj.InstituteID,obj.InstitutePhoneNo, obj.InstituteFaxNo,obj.CoordinatorName, obj.CoordinatorDesignation, obj.CoordinatorDOB, obj.CoordinatorMobileNo,
                obj.CoordinatorAltMobileNo, obj.CoordinatorEmailID, obj.CoordinatorPhoneNo, ModifiedBy, ModifiedByIPAddress};
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdateInstituteProfile", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateInstituteProfile()", "");
            }
        }
        public DataSet getInstituteProfile(Int32 InstituteID)
        {
            try
            {
                object[] parameters = { InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteProfile", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteProfile()", "");
            }

        }
        public DataSet getInstituteProfileDS(Int32 InstituteID)
        {
            try
            {
                object[] parameters = { InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteProfile", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteProfileDS()", "");
            }
        }
        public string getInstitutePassword(string InstituteCode)
        {

            try
            {
                object[] parameters = { InstituteCode };
                string QueryResult;
                QueryResult = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetInstitutePassword", parameters));
                if (QueryResult == "")
                {
                    QueryResult = "NA";

                }
                return QueryResult;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstitutePassword()", "");
            }
        }
        public bool resetInstitutePassword(string InstituteCode, string Password, string EncryptedPassword)
        {
            try
            {
                object[] parameters = { InstituteCode, Password, EncryptedPassword };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spResetInstitutePassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "resetInstitutePassword()", "");
            }
        }
        public DataSet getInstitutesDetailedList()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstitutesDetailedList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstitutesDetailedList()", "");
            }
        }
        public DataSet getInstituteSummary(string InstituteCode)
        {
            try
            {
                object[] parameters = { InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteSummary", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteSummary()", "");
            }
        }
        public DataSet getChoiceCodeListByInstitute(string InstituteCode)
        {
            try
            {
                object[] parameters = { InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetChoiceCodeListByInstitute", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getChoiceCodeListByInstitute()", "");
            }
        }
        public DataSet getCourseInformation(string ChoiceCode)
        {
            try
            {
                object[] parameters = { ChoiceCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCourseInformation", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCourseInformation()", "");
            }
        }
        public bool saveCourseInformation(CourseInformation obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {

                object[] parameters = { obj.ChoiceCode, obj.TotalIntake, obj.CAPIntake, obj.ILIntake, obj.MIIntake,  obj.MSIntake, obj.AIIntake,
                obj.GOPENH, obj.GSCH, obj.GSTH, obj.GVJH, obj.GNT1H, obj.GNT2H, obj.GNT3H, obj.GOBCH, obj.GSEBCH,
                obj.LOPENH, obj.LSCH, obj.LSTH, obj.LVJH, obj.LNT1H, obj.LNT2H, obj.LNT3H, obj.LOBCH, obj.LSEBCH,
                obj.PHCH,obj.PHCSCH,obj.PHCSTH, obj.PHCVJH, obj.PHCNT1H, obj.PHCNT2H, obj.PHCNT3H, obj.PHCOBCH, obj.PHCSEBCH,
                obj.GOPENO, obj.GSCO,obj.GSTO, obj.GVJO, obj.GNT1O, obj.GNT2O, obj.GNT3O, obj.GOBCO, obj.GSEBCO,
                obj.LOPENO, obj.LSCO, obj.LSTO, obj.LVJO, obj.LNT1O, obj.LNT2O, obj.LNT3O, obj.LOBCO, obj.LSEBCO,
                obj.PHCO,obj.PHCSCO,obj.PHCSTO, obj.PHCVJO, obj.PHCNT1O, obj.PHCNT2O,obj.PHCNT3O, obj.PHCOBCO, obj.PHCSEBCO,
                obj.DEFO,obj.DEFSCO,obj.DEFSTO, obj.DEFVJO,obj.DEFNT1O, obj.DEFNT2O,obj.DEFNT3O,obj.DEFOBCO,obj.DEFSEBCO,
                obj.EWS,obj.ORPHAN, obj.PHHT, obj.DEFT, ModifiedBy,ModifiedByIPAddress
                };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveCourseInformation", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveCourseInformation()", "");
            }
        }
        public DataSet getInvalidSeatDistributionList()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInvalidSeatDistributionList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInvalidSeatDistributionList()", "");
            }
        }
        public DataSet getAllChoiceCodeList()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllChoiceCodeList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllChoiceCodeList()", "");
            }
        }
        public DataSet getNewChoiceCodesAvailable()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetNewChoiceCodesAvailable");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getNewChoiceCodesAvailable()", "");
            }



        }
        public DataSet getChoiceCodesAvailableForUpdate()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetChoiceCodesAvailableForUpdate");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getChoiceCodesAvailableForUpdate()", "");
            }



        }
        public DataSet getChoiceCodesAvailableForDelete()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetChoiceCodesAvailableForDelete");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getChoiceCodesAvailableForDelete()", "");
            }
        }
        public bool insertNewChoiceCodes(string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spInsertNewChoiceCodes", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertNewChoiceCodes()", "");
            }
        }
        public bool updateChoiceCodes(string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { ModifiedBy, ModifiedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdateChoiceCodes", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateChoiceCodes()", "");
            }
        }
        public bool deleteChoiceCodes(string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spDeleteChoiceCodes", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteChoiceCodes()", "");
            }
        }
        public DataSet getInstituteListReport(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteListReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteListReport()", "");
            }
        }
        public DataSet getAllChoiceCodeListFromDTEPortalForInstitute(string InstituteCode)
        {
            try
            {
                object[] parameters = { InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllChoiceCodeListFromDTEPortalForInstitute", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllChoiceCodeListFromDTEPortalForInstitute()", "");
            }
        }
        public DataSet getInstituteHostelCapacityDetails(Int64 InstituteID)
        {
            try
            {
                object[] parameters = { InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteHostelCapacityDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteHostelCapacityDetails()", "");
            }
        }
        public bool saveInstituteHostelCapacityDetails(Int64 InstituteID, Int32 BoysHostelCapacityIYear, Int32 GirlsHostelCapacityIYear, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { InstituteID, BoysHostelCapacityIYear, GirlsHostelCapacityIYear, ModifiedBy, ModifiedByIPAddress };
                Int32 QueryResult = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveInstituteHostelCapacityDetails", parameters));
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveInstituteHostelCapacityDetails()", "");
            }
        }
        public DataSet getInstituteListHavingCourtCaseRemark()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteListHavingCourtCaseRemark");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteListHavingCourtCaseRemark()", "");
            }
        }
        public DataSet getChoiceCodeListByInstituteHavingCourtCaseRemark(string InstituteCode)
        {
            try
            {
                object[] parameters = { InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetChoiceCodeListByInstituteHavingCourtCaseRemark", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getChoiceCodeListByInstituteHavingCourtCaseRemark()", "");
            }
        }
        public string getInstituteName(string InstituteCode)
        {
            try
            {
                object[] parameters = { InstituteCode };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetInstituteName", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteName()", "");
            }
        }
        public string getCourseName(string ChoiceCode)
        {
            try
            {
                object[] parameters = { ChoiceCode };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetCourseName", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCourseName()", "");
            }
        }
        public DataSet getCompositeReportForAdmin(string Flag, string Flag2)
        {
            try
            {
                object[] parameters = { Flag , Flag2 };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportForAdmin", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getCompositeReportForRO(string RO, string Flag, string Flag2)
        {
            try
            {
                object[] parameters = { RO, Flag,Flag2 };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportForRO", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCompositeReportForRO()", "");
            }
        }
        public DataSet getCompositeReportForInstitute(string InstituteCode, string Flag, string Flag2)
        {
            try
            {
                object[] parameters = { InstituteCode, Flag,Flag2 };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportForInstitute", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getCompositeReport(string ChoiceCode, string ReportingStatus)
        {
            try
            {
                object[] parameters = { ChoiceCode, ReportingStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getInstituteListForAllotmentDisplay()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteListForAllotmentDisplay");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteListForAllotmentDisplay()", "");
            }
        }
        public DataSet getAllotmentReportForAdmin()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentReportForAdmin");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentReportForAdmin()", "");
            }
        }
        public DataSet getAllotmentReportForRO(string RO)
        {
            try
            {
                object[] parameters = { RO };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentReportForRO", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentReportForRO()", "");
            }
        }
        public DataSet getAllotmentReportForInstitute(string InstituteCode)
        {
            try
            {
                object[] parameters = { InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentReportForInstitute", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentReportForInstitute()", "");
            }
        }
        public DataSet getAllotmentReport(string ChoiceCode)
        {
            try
            {
                object[] parameters = { ChoiceCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentReport()", "");
            }
        }
        public DataSet getInvalidSeatSurrenderList()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInvalidSeatSurrenderList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInvalidSeatSurrenderList()", "");
            }
        }
        public string isCandidateAllottedThisInstitute(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {

            try
            {
                object[] parameters = { PID, UserTypeID, UserLoginID };
                return (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateAllottedThisInstitute", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateAllottedThisInstitute()", "");
            }
        }
        public bool isCandidateReportedToARC(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateReportedToARC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateReportedToARC()", "");
            }
        }
        public DataSet getPersonalInformationForInstitute(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationForInstitute", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPersonalInformationForInstitute()", "");
            }
        }
        public DataSet getReportingDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReportingDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReportingDetails()", "");
            }
        }
        public DataSet getDocumentListForInstitute(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentListForInstitute", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getInstituteFeeList(Int64 PID, string FeeType, string InstituteCode, string AdmissionPhase)
        {
            try
            {
                object[] parameters = { PID, FeeType, InstituteCode, AdmissionPhase };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteFeeList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteFeeList()", "");
            }
        }
        public DataSet getInstituteFeeDetails(Int64 FeeID)
        {
            try
            {
                object[] parameters = { FeeID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteFeeDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public Int32 saveInstituteFeeDetails(InstituteFeeDetails obj, string CreatedBy, string CreatedByIPAddress, string AdmissionPhase)
        {
            try
            {
                object[] parameters = { obj.PID, obj.FeeType, obj.PaymentMode, obj.FeeAmount, obj.DDNumber, obj.DDDate, obj.BankID, obj.OtherBankName, obj.BranchName, obj.InstituteCode, CreatedBy, CreatedByIPAddress, AdmissionPhase };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveInstituteFeeDetails", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveInstituteFeeDetails()", "");
            }
        }
        public Int32 editInstituteFeeDetails(InstituteFeeDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { obj.FeeID, obj.PID, obj.PaymentMode, obj.FeeAmount, obj.DDNumber, obj.DDDate, obj.BankID, obj.OtherBankName, obj.BranchName, obj.InstituteCode, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditInstituteFeeDetails", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public bool deleteInstituteFeeDetails(Int64 FeeID, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { FeeID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spDeleteInstituteFeeDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteInstituteFeeDetails()", "");
            }
        }
        public bool updateDocumentSubmissionForInstitute(Int64 PID, string XMLString, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, XMLString, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateDocumentSubmissionForInstitute", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateDocumentSubmissionForInstitute()", "");
            }
        }
        public bool confirmAdmission(Int64 PID, DateTime AdmissionDate, string Comments, string ReportedBy, string ReportedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, AdmissionDate, Comments, ReportedBy, ReportedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmAdmission", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmAdmission()", "");
            }
        }
        public DataSet getReportingDetails(Int64 PID, char ReportingStatus)
        {
            try
            {
                object[] parameters = { PID, ReportingStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReportingDetailsByReportingStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReportingDetails()", "");
            }
        }
        public DataSet getDocumentListForInstitute(Int64 PID, string SubmittedFlag)
        {
            try
            {
                object[] parameters = { PID, SubmittedFlag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentListForInstituteBySubmittedFlag", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDocumentListForInstitute()", "");
            }
        }
        public bool editAdmission(Int64 PID, DateTime AdmissionDate, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, AdmissionDate, Comments, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditAdmission", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editAdmission()", "");
            }
        }
        public bool cancelAdmission(Int64 PID, Int64 CancellationCharge, string ReasonForCancellation, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CancellationCharge, ReasonForCancellation, CancelledBy, CancelledByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelAdmission", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "cancelAdmission()", "");
            }
        }
        public bool editCancelAdmission(Int64 PID, Int64 CancellationCharge, string ReasonForCancellation, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CancellationCharge, ReasonForCancellation, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditCancelAdmission", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editCancelAdmission()", "");
            }
        }
        public bool IsAdmissionConfirmedAtInstitute(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsAdmissionConfirmedAtInstitute", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "IsAdmissionConfirmedAtInstitute()", "");
            }
        }
        public bool isCandidateAdmittedInThisInstitute(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CAPRound, UserTypeID, UserLoginID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateAdmittedInThisInstitute", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateAdmittedInThisInstitute()", "");
            }
        }
        public string isCandidateAllottedThisInstituteCAPRound5(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { PID, UserTypeID, UserLoginID };
                return (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateAllottedThisInstituteCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateAllottedThisInstituteCAPRound5()", "");
            }
        }
        public DataSet getReportingDetailsCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReportingDetailsCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReportingDetailsCAPRound5()", "");
            }
        }
        public bool confirmAdmissionCAPRound5(Int64 PID, DateTime AdmissionDate, string Comments, string ReportedBy, string ReportedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, AdmissionDate, Comments, ReportedBy, ReportedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmAdmissionCAPRound5", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmAdmissionCAPRound5()", "");
            }
        }
        public string isCandidateAllottedThisInstituteByReportingStatus(Int64 PID, Int32 UserTypeID, string UserLoginID, char ReportingStatus)
        {
            try
            {
                object[] parameters = { PID, UserTypeID, UserLoginID, ReportingStatus };
                return (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateAllottedThisInstituteByReportingStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateAllottedThisInstituteByReportingStatus()", "");
            }
        }
        public string isCandidateAllottedThisInstituteByCAPRound(Int64 PID, Int32 UserTypeID, string UserLoginID, string Flag)
        {
            try
            {
                object[] parameters = { PID, UserTypeID, UserLoginID, Flag };
                return (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateAllottedThisInstituteByCAPRound", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateAllottedThisInstituteByCAPRound()", "");
            }
        }
        public DataSet getReportingDetailsByCAPRound(Int64 PID, string Flag)
        {

            try
            {
                object[] parameters = { PID, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReportingDetailsByCAPRound", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReportingDetailsByCAPRound()", "");
            }
        }
        public bool confirmAdmissionByCAPRound(Int64 PID, DateTime AdmissionDate, string Comments, string ReportedBy, string ReportedByIPAddress, string Flag)
        {
            try
            {
                object[] parameters = { PID, AdmissionDate, Comments, ReportedBy, ReportedByIPAddress, Flag };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmAdmissionByCAPRound", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmAdmissionByCAPRound()", "");
            }
        }
        public DataSet getReportingDetailsByChoiceCode(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, char ReportingStatus)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CAPRound, ReportingStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReportingDetailsByChoiceCode", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReportingDetailsByChoiceCode()", "");
            }
        }
        public bool confirmAdmissionByChoiceCode(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, DateTime AdmissionDate, string Comments, string ReportedBy, string ReportedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CAPRound, AdmissionDate, Comments, ReportedBy, ReportedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmAdmissionByChoiceCode", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmAdmissionByChoiceCode()", "");
            }
        }
        public bool editAdmissionByChoiceCode(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, DateTime AdmissionDate, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CAPRound, AdmissionDate, Comments, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditAdmissionByChoiceCode", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editAdmissionByChoiceCode()", "");
            }
        }
        public bool cancelAdmissionByChoiceCode(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, Int64 CancellationCharge, string ReasonForCancellation, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CAPRound, CancellationCharge, ReasonForCancellation, CancelledBy, CancelledByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelAdmissionByChoiceCode", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "cancelAdmissionByChoiceCode()", "");
            }
        }
        public bool editCancelAdmissionByChoiceCode(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, Int64 CancellationCharge, string ReasonForCancellation, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CAPRound, CancellationCharge, ReasonForCancellation, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditCancelAdmissionByChoiceCode", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editCancelAdmissionByChoiceCode()", "");
            }
        }
        public bool isCandidateEligibleForAdmissionAtIL(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 QueryResult;
                QueryResult = (Int32)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateEligibleForAdmissionAtIL", parameters);
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateEligibleForAdmissionAtIL()", "");
            }
        }
        public bool isCandidateEligibleForAdmission(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 QueryResult;
                QueryResult = (Int32)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateEligibleForAdmission", parameters);
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateEligibleForAdmission()", "");
            }
        }
        public string getAdmissionDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetAdmissionDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdmissionDetails()", "");
            }
        }
        public string isCandidateAllottedThisInstituteIL(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {

            try
            {
                object[] parameters = { PID, UserTypeID, UserLoginID };
                return (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateAllottedThisInstituteIL", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateAllottedThisInstituteIL()", "");
            }
        }
        public DataSet getInstituteListForAdmissionAtIL(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteListForAdmissionAtIL", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteListForAdmissionAtIL()", "");
            }
        }
        public DataSet getChoiceCodeListByInstituteForAdmissionAtIL(Int64 PID, string InstituteCode)
        {
            try
            {
                object[] parameters = { PID, InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetChoiceCodeListByInstituteForAdmissionAtIL", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getChoiceCodeListByInstituteForAdmissionAtIL()", "");
            }
        }
        public DataSet getAllChoiceCodeListByInstituteForAdmissionAtIL(string InstituteCode)
        {
            try
            {
                object[] parameters = { InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllChoiceCodeListByInstituteForAdmissionAtIL", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateAllottedThisInstituteCAPRound5()", "");
            }
        }
        public DataSet getSeatTypeListForAdmissionAtIL(string InstituteCode)
        {

            try
            {
                object[] parameters = { InstituteCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatTypeListForAdmissionAtIL", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSeatTypeListForAdmissionAtIL()", "");
            }
        }
        public bool confirmAdmissionAtIL(Int64 PID, Int64 ChoiceCode, string SeatType, Int32 MeritNo, DateTime AdmissionDate, string Comments, string ReportedBy, string ReportedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, SeatType, MeritNo, AdmissionDate, Comments, ReportedBy, ReportedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmAdmissionAtIL", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmAdmissionAtIL()", "");
            }
        }
        public bool editAdmissionAtIL(Int64 PID, Int64 ChoiceCode, string SeatType, Int32 MeritNo, DateTime AdmissionDate, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, SeatType, MeritNo, AdmissionDate, Comments, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditAdmissionAtIL", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editAdmissionAtIL()", "");
            }
        }
        public bool cancelAdmissionAtIL(Int64 PID, Int64 ChoiceCode, Int64 CancellationCharge, string ReasonForCancellation, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CancellationCharge, ReasonForCancellation, CancelledBy, CancelledByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelAdmissionAtIL", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "cancelAdmissionAtIL()", "");
            }
        }
        public bool editCancelAdmissionAtIL(Int64 PID, Int64 ChoiceCode, Int64 CancellationCharge, string ReasonForCancellation, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, ChoiceCode, CancellationCharge, ReasonForCancellation, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditCancelAdmissionAtIL", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editCancelAdmissionAtIL()", "");
            }
        }
        public DataSet getReportingDetailsAtIL(Int64 PID, Int64 ChoiceCode, char ReportingStatus)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, ReportingStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReportingDetailsByReportingStatusAtIL", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReportingDetailsAtIL()", "");
            }
        }
        public DataSet getReportingDetailsAtIL(Int64 PID, char ReportingStatus, Int32 UserTypeID, string UserLoginID, string Flag, string Code)
        {
            try
            {
                object[] parameters = { PID, ReportingStatus, UserTypeID, UserLoginID, Flag, Code };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReportingDetailsAtIL", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReportingDetailsAtIL()", "");
            }
        }
        public DataSet getReportingDetailsAtCAP(Int64 PID, char ReportingStatus, Int32 UserTypeID, string UserLoginID, string Flag, string Code)
        {
            try
            {
                object[] parameters = { PID, ReportingStatus, UserTypeID, UserLoginID, Flag, Code };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReportingDetailsAtCAP", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReportingDetailsAtCAP()", "");
            }
        }

        public DataSet getCandidateDetailsForDisplayInOptionForm(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateDetailsForDisplayInOptionForm", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidateDetailsForDisplayInOptionForm()", "");
            }
        }
        public DataSet getCourseListByPID(Int32 CAPRound, Int64 PID)
        {
            try
            {
                object[] parameters = { CAPRound, PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCourseListByPID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateAllottedThisInstituteCAPRound5()", "");
            }
        }
        public DataSet getUniversityListByPID(Int32 CAPRound, Int64 PID)
        {
            try
            {
                object[] parameters = { CAPRound, PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetUniversityListByPID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getUniversityListByPID()", "");
            }
        }
        public DataSet getInstituteListByUniversityID(Int32 CAPRound, Int64 PID, Int16 UniversityID)
        {
            try
            {
                object[] parameters = { CAPRound, PID, UniversityID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteListByUniversityID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteListByUniversityID()", "");
            }
        }
        public DataSet getChoiceCodeListByInstituteID(Int32 CAPRound, Int64 PID, Int32 InstituteID)
        {
            try
            {
                object[] parameters = { CAPRound, PID, InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetChoiceCodeListByInstituteID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getChoiceCodeListByInstituteID()", "");
            }
        }
        public DataSet getCancelledOptionFormReport(Int32 UserTypeID, string UserLoginID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCancelledOptionFormReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCancelledOptionFormReport()", "");
            }
        }
        public Int64 authenticateApplicationIDnDOB(string ApplicationID, DateTime DOB)
        {
            try
            {
                object[] parameters = { ApplicationID, DOB };
                Int64 result = Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAuthenticateApplicationIDnDOB", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "authenticateApplicationIDnDOB()", "");
            }
        }
        public DataSet getChangeEligibilityReport(Int32 UserTypeID, string UserLoginID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetChangeEligibilityReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getChangeEligibilityReport()", "");
            }
        }
        public DataSet verifyChoiceCode(Int32 CAPRound, Int64 PID, string ChoiceCodeDisplay)
        {

            try
            {
                object[] parameters = { CAPRound, PID, ChoiceCodeDisplay };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spVerifyChoiceCode", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "verifyChoiceCode()", "");
            }
        }

        public DataSet getCurrentLinkCAPRound1(Int64 PID, string URL)
        {

            try
            {
                object[] parameters = { PID, URL };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCurrentLinkCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCurrentLinkCAPRound1()", "");
            }
        }
        public DataSet getCandidateStepListCAPRound1(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateStepListCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidateStepListCAPRound1()", "");
            }
        }
        public DataSet getSelectedOptionsListCAPRound1(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSelectedOptionsListCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSelectedOptionsListCAPRound1()", "");
            }
        }
        public DataSet getOptionsListCAPRound1(Int64 PID, string CourseCode, Int16 UniversityID, string DistrictName, string CourseStatus1, string CourseStatus2, string CourseStatus3, string TFWSStatus)
        {
            try
            {
                object[] parameters = { PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3, TFWSStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionsListCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionsListCAPRound1()", "");
            }
        }
        public Int32 saveOptionsCAPRound1(Int64 PID, string OptionsList, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, OptionsList, CreatedBy, CreatedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOptionsCAPRound1", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveOptionsCAPRound1()", "");
            }
        }
        public Int32 deleteOptionsCAPRound1(Int64 PID, string OptionsList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, OptionsList, ModifiedBy, ModifiedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteOptionsCAPRound1", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteOptionsCAPRound1()", "");
            }
        }
        public Int32 saveShortlistedOptionsCAPRound1(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveShortlistedOptionsCAPRound1", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveShortlistedOptionsCAPRound1()", "");
            }
        }
        public bool checkPreferenceNoCAPRound1(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckPreferenceNoCAPRound1", parameters));
                return Convert.ToBoolean(result);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkPreferenceNoCAPRound1()", "");
            }
        }
        public Int32 savePreferencesCAPRound1(Int64 PID, string PreferencesList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferencesList, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSavePreferencesCAPRound1", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "savePreferencesCAPRound1()", "");
            }
        }
        public DataSet getPreferancedOptionsListCAPRound1(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPreferancedOptionsListCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferancedOptionsListCAPRound1()", "");
            }
        }
        public Int32 getPreferencesCountCAPRound1(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPreferencesCountCAPRound1", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferencesCountCAPRound1()", "");
            }
        }
        public Int32 insertOptionCAPRound1(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCode, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionCAPRound1", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionCAPRound1()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound1(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionDirectCAPRound1", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionDirectCAPRound1()", "");
            }
        }
        public Int32 moveOptionCAPRound1(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCode, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spMoveOptionCAPRound1", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "moveOptionCAPRound1()", "");
            }
        }
        public Int32 confirmOptionFormCAPRound1(Int64 PID, string CandidatePassword, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CandidatePassword, ConfirmedBy, ConfirmedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmOptionFormCAPRound1", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmOptionFormCAPRound1()", "");
            }

        }
        public DataSet getPersonalInformationCAPRound1(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPersonalInformationCAPRound1()", "");
            }
        }
        public DataSet getPreferancedOptionsListForDisplayCAPRound1(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPreferancedOptionsListForDisplayCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getInstructionsCAPRound1(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstructionsCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstructionsCAPRound1()", "");
            }
        }
        public DataSet getOptionFormConfirmationDetailsCAPRound1(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionFormConfirmationDetailsCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionFormConfirmationDetailsCAPRound1()", "");
            }
        }
        public bool isOptionFormConfirmedCAPRound1(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOptionFormConfirmedCAPRound1", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOptionFormConfirmedCAPRound1()", "");
            }
        }
        public bool cancelOptionFormCAPRound1(Int64 PID, String Comments, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                object[] parameters = { PID, Comments, CancelledBy, CancelledByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelOptionFormCAPRound1", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "cancelOptionFormCAPRound1()", "");
            }
        }
        public bool isCandidateEligibleCAPRound1(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateEligibleCAPRound1", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateEligibleCAPRound1()", "");
            }
        }
        public bool changeCandidateEligibilityCAPRound1(Int64 PID, Int32 EligibilityStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, EligibilityStatus, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spChangeCandidateEligibilityCAPRound1", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "changeCandidateEligibilityCAPRound1()", "");
            }
        }
        public bool isOptionFormCancelledBeforeCAPRound1(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOptionFormCancelledBeforeCAPRound1", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOptionFormCancelledBeforeCAPRound1()", "");
            }
        }
        public bool saveOptionFormSummaryStepIDCAPRound1(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOptionFormSummaryStepIDCAPRound1", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveOptionFormSummaryStepIDCAPRound1()", "");
            }
        }
        public string getInvalidChoiceCodeListCAPRound1(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetInvalidChoiceCodeListCAPRound1", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInvalidChoiceCodeListCAPRound1()", "");
            }
        }
        public bool isCandidateSelectedOptionsCAPRound1(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateSelectedOptionsCAPRound1", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateSelectedOptionsCAPRound1()", "");
            }
        }

        public DataSet getAllotmentStatusCAPRound1(string ApplicationID, DateTime DOB)
        {

            try
            {
                object[] parameters = { ApplicationID, DOB };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentStatusCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getAllotmentListCAPRound1()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentListCAPRound1");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentListCAPRound1()", "");
            }



        }
        public DataSet getAllotmentStatusCAPRound2(string ApplicationID, DateTime DOB)
        {
            try
            {
                object[] parameters = { ApplicationID, DOB };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentStatusCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getAllotmentListCAPRound2()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentListCAPRound2");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentListCAPRound2()", "");
            }
        }
        public DataSet getAllotmentStatusCAPRound3(string ApplicationID, DateTime DOB)
        {

            try
            {
                object[] parameters = { ApplicationID, DOB };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentStatusCAPRound3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentStatusCAPRound3()", "");
            }
        }
        public DataSet getAllotmentListCAPRound3()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentListCAPRound3");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentListCAPRound3()", "");
            }




        }
        public DataSet getAllotmentStatusCAPRound4(string ApplicationID, DateTime DOB)
        {
            try
            {
                object[] parameters = { ApplicationID, DOB };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentStatusCAPRound4", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentStatusCAPRound4()", "");
            }
        }
        public DataSet getAllotmentListCAPRound4()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentListCAPRound4");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentListCAPRound4()", "");
            }



        }
        public DataSet getFinalAllotmentStatus(string ApplicationID, DateTime DOB)
        {

            try
            {
                object[] parameters = { ApplicationID, DOB };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetFinalAllotmentStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getFinalAllotmentStatus()", "");
            }
        }
        public DataSet getFinalAllotmentList()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetFinalAllotmentList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getFinalAllotmentList()", "");
            }
        }
        public DataSet getAllotmentStatusCAPRound5(string ApplicationID, DateTime DOB)
        {

            try
            {
                object[] parameters = { ApplicationID, DOB };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentStatusCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentStatusCAPRound5()", "");
            }
        }
        public DataSet getAllotmentListCAPRound5()
        {

            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentListCAPRound5");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentListCAPRound5()", "");
            }
        }

        public DataSet getImportOptionsFromCAPRound1(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetImportOptionsFromCAPRound1", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getImportOptionsFromCAPRound1()", "");
            }
        }
        public bool importOptionsFromCAPRound1(Int64 PID, string CreatedBy, string CreatedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spImportOptionsFromCAPRound1", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "importOptionsFromCAPRound1()", "");
            }
        }
        public DataSet getCurrentLinkCAPRound2(Int64 PID, string URL)
        {
            try
            {
                object[] parameters = { PID, URL };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCurrentLinkCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCurrentLinkCAPRound2()", "");
            }
        }
        public DataSet getCandidateStepListCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateStepListCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidateStepListCAPRound2()", "");
            }
        }
        public DataSet getSelectedOptionsListCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSelectedOptionsListCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSelectedOptionsListCAPRound2()", "");
            }
        }
        public DataSet getOptionsListCAPRound2(Int64 PID, string CourseCode, Int16 UniversityID, string DistrictName, string CourseStatus1, string CourseStatus2, string CourseStatus3, string TFWSStatus)
        {
            try
            {
                object[] parameters = { PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3, TFWSStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionsListCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionsListCAPRound2()", "");
            }

        }
        public Int32 saveOptionsCAPRound2(Int64 PID, string OptionsList, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, OptionsList, CreatedBy, CreatedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOptionsCAPRound2", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveOptionsCAPRound2()", "");
            }
        }
        public Int32 deleteOptionsCAPRound2(Int64 PID, string OptionsList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, OptionsList, ModifiedBy, ModifiedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteOptionsCAPRound2", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteOptionsCAPRound2()", "");
            }
        }
        public Int32 saveShortlistedOptionsCAPRound2(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveShortlistedOptionsCAPRound2", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public bool checkPreferenceNoCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckPreferenceNoCAPRound2", parameters));
                return Convert.ToBoolean(result);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkPreferenceNoCAPRound2()", "");
            }
        }
        public Int32 savePreferencesCAPRound2(Int64 PID, string PreferencesList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferencesList, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSavePreferencesCAPRound2", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "savePreferencesCAPRound2()", "");
            }
        }
        public DataSet getPreferancedOptionsListCAPRound2(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPreferancedOptionsListCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferancedOptionsListCAPRound2()", "");
            }
        }
        public Int32 getPreferencesCountCAPRound2(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPreferencesCountCAPRound2", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferencesCountCAPRound2()", "");
            }
        }
        public Int32 insertOptionCAPRound2(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCode, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionCAPRound2", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionCAPRound2()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound2(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionDirectCAPRound2", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionDirectCAPRound2()", "");
            }
        }
        public Int32 moveOptionCAPRound2(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCode, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spMoveOptionCAPRound2", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "moveOptionCAPRound2()", "");
            }
        }
        public Int32 confirmOptionFormCAPRound2(Int64 PID, string CandidatePassword, string ConfirmedBy, string ConfirmedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, CandidatePassword, ConfirmedBy, ConfirmedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmOptionFormCAPRound2", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmOptionFormCAPRound2()", "");
            }
        }
        public DataSet getPersonalInformationCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPersonalInformationCAPRound2()", "");
            }
        }
        public DataSet getPreferancedOptionsListForDisplayCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPreferancedOptionsListForDisplayCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferancedOptionsListForDisplayCAPRound2()", "");
            }
        }
        public DataSet Getreceiptcandidates(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetreceiptcandidates", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "Getreceiptcandidates()", "");
            }
        }
        public DataSet getInstructionsCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstructionsCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstructionsCAPRound2()", "");
            }
        }
        public DataSet getOptionFormConfirmationDetailsCAPRound2(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionFormConfirmationDetailsCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionFormConfirmationDetailsCAPRound2()", "");
            }
        }
        public bool isOptionFormConfirmedCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOptionFormConfirmedCAPRound2", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOptionFormConfirmedCAPRound2()", "");
            }
        }
        public bool cancelOptionFormCAPRound2(Int64 PID, String Comments, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                object[] parameters = { PID, Comments, CancelledBy, CancelledByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelOptionFormCAPRound2", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "cancelOptionFormCAPRound2()", "");
            }
        }
        public bool isCandidateEligibleCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateEligibleCAPRound2", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateEligibleCAPRound2()", "");
            }
        }
        public bool changeCandidateEligibilityCAPRound2(Int64 PID, Int32 EligibilityStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, EligibilityStatus, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spChangeCandidateEligibilityCAPRound2", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "changeCandidateEligibilityCAPRound2()", "");
            }
        }
        public bool isOptionFormCancelledBeforeCAPRound2(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOptionFormCancelledBeforeCAPRound2", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOptionFormCancelledBeforeCAPRound2()", "");
            }
        }
        public bool saveOptionFormSummaryStepIDCAPRound2(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOptionFormSummaryStepIDCAPRound2", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveOptionFormSummaryStepIDCAPRound2()", "");
            }
        }
        public string getInvalidChoiceCodeListCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetInvalidChoiceCodeListCAPRound2", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInvalidChoiceCodeListCAPRound2()", "");
            }
        }
        public bool isCandidateSelectedOptionsCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateSelectedOptionsCAPRound2", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateSelectedOptionsCAPRound2()", "");
            }
        }

        public DataSet getImportOptionsFromCAPRound2(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetImportOptionsFromCAPRound2", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getImportOptionsFromCAPRound2()", "");
            }
        }
        public bool importOptionsFromCAPRound2(Int64 PID, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spImportOptionsFromCAPRound2", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "importOptionsFromCAPRound2()", "");
            }
        }
        public DataSet getCurrentLinkCAPRound3(Int64 PID, string URL)
        {
            try
            {
                object[] parameters = { PID, URL };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCurrentLinkCAPRound3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCurrentLinkCAPRound3()", "");
            }
        }
        public DataSet getCandidateStepListCAPRound3(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateStepListCAPRound3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidateStepListCAPRound3()", "");
            }
        }
        public DataSet getSelectedOptionsListCAPRound3(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSelectedOptionsListCAPRound3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSelectedOptionsListCAPRound3()", "");
            }
        }
        public DataSet getOptionsListCAPRound3(Int64 PID, string CourseCode, Int16 UniversityID, string DistrictName, string CourseStatus1, string CourseStatus2, string CourseStatus3, string TFWSStatus)
        {
            try
            {
                object[] parameters = { PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3, TFWSStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionsListCAPRound3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionsListCAPRound3()", "");
            }
        }
        public Int32 saveOptionsCAPRound3(Int64 PID, string OptionsList, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, OptionsList, CreatedBy, CreatedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOptionsCAPRound3", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveOptionsCAPRound3()", "");
            }
        }
        public Int32 deleteOptionsCAPRound3(Int64 PID, string OptionsList, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, OptionsList, ModifiedBy, ModifiedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteOptionsCAPRound3", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteOptionsCAPRound3()", "");
            }
        }
        public Int32 saveShortlistedOptionsCAPRound3(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveShortlistedOptionsCAPRound3", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveShortlistedOptionsCAPRound3()", "");
            }
        }
        public bool checkPreferenceNoCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckPreferenceNoCAPRound3", parameters));
                return Convert.ToBoolean(result);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkPreferenceNoCAPRound3()", "");
            }
        }
        public Int32 savePreferencesCAPRound3(Int64 PID, string PreferencesList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferencesList, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSavePreferencesCAPRound3", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "savePreferencesCAPRound3()", "");
            }
        }
        public DataSet getPreferancedOptionsListCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPreferancedOptionsListCAPRound3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferancedOptionsListCAPRound3()", "");
            }
        }
        public Int32 getPreferencesCountCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPreferencesCountCAPRound3", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferencesCountCAPRound3()", "");
            }
        }
        public Int32 insertOptionCAPRound3(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCode, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionCAPRound3", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionCAPRound3()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound3(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionDirectCAPRound3", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionDirectCAPRound3()", "");
            }
        }
        public Int32 moveOptionCAPRound3(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCode, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spMoveOptionCAPRound3", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "moveOptionCAPRound3()", "");
            }
        }
        public Int32 confirmOptionFormCAPRound3(Int64 PID, string CandidatePassword, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CandidatePassword, ConfirmedBy, ConfirmedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmOptionFormCAPRound3", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmOptionFormCAPRound3()", "");
            }
        }
        public DataSet getPersonalInformationCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationCAPRound3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPersonalInformationCAPRound3()", "");
            }
        }
        public DataSet getPreferancedOptionsListForDisplayCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPreferancedOptionsListForDisplayCAPRound3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferancedOptionsListForDisplayCAPRound3()", "");
            }
        }
        public DataSet getInstructionsCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstructionsCAPRound3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstructionsCAPRound3()", "");
            }
        }
        public DataSet getOptionFormConfirmationDetailsCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionFormConfirmationDetailsCAPRound3", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionFormConfirmationDetailsCAPRound3()", "");
            }
        }
        public bool isOptionFormConfirmedCAPRound3(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOptionFormConfirmedCAPRound3", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOptionFormConfirmedCAPRound3()", "");
            }
        }
        public bool cancelOptionFormCAPRound3(Int64 PID, String Comments, string CancelledBy, string CancelledByIPAddress)
        {

            try
            {
                object[] parameters = { PID, Comments, CancelledBy, CancelledByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelOptionFormCAPRound3", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "cancelOptionFormCAPRound3()", "");
            }
        }
        public bool isCandidateEligibleCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateEligibleCAPRound3", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateEligibleCAPRound3()", "");
            }
        }
        public bool changeCandidateEligibilityCAPRound3(Int64 PID, Int32 EligibilityStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, EligibilityStatus, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spChangeCandidateEligibilityCAPRound3", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "changeCandidateEligibilityCAPRound3()", "");
            }
        }
        public bool isOptionFormCancelledBeforeCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOptionFormCancelledBeforeCAPRound3", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOptionFormCancelledBeforeCAPRound3()", "");
            }
        }
        public bool saveOptionFormSummaryStepIDCAPRound3(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOptionFormSummaryStepIDCAPRound3", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveOptionFormSummaryStepIDCAPRound3()", "");
            }
        }
        public string getInvalidChoiceCodeListCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetInvalidChoiceCodeListCAPRound3", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInvalidChoiceCodeListCAPRound3()", "");
            }
        }
        public bool isCandidateSelectedOptionsCAPRound3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateSelectedOptionsCAPRound3", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateSelectedOptionsCAPRound3()", "");
            }
        }

        public DataSet getCurrentLinkCAPRound4(Int64 PID, string URL)
        {
            try
            {
                object[] parameters = { PID, URL };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCurrentLinkCAPRound4", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCurrentLinkCAPRound4()", "");
            }
        }
        public DataSet getCandidateStepListCAPRound4(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateStepListCAPRound4", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidateStepListCAPRound4()", "");
            }
        }
        public DataSet getSelectedOptionsListCAPRound4(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSelectedOptionsListCAPRound4", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSelectedOptionsListCAPRound4()", "");
            }
        }
        public DataSet getOptionsListCAPRound4(Int64 PID, string CourseCode, Int16 UniversityID, string DistrictName, string CourseStatus1, string CourseStatus2, string CourseStatus3, string TFWSStatus)
        {
            try
            {
                object[] parameters = { PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3, TFWSStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionsListCAPRound4", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionsListCAPRound4()", "");
            }
        }
        public Int32 saveOptionsCAPRound4(Int64 PID, string OptionsList, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, OptionsList, CreatedBy, CreatedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOptionsCAPRound4", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveOptionsCAPRound4()", "");
            }
        }
        public Int32 deleteOptionsCAPRound4(Int64 PID, string OptionsList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, OptionsList, ModifiedBy, ModifiedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteOptionsCAPRound4", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteOptionsCAPRound4()", "");
            }
        }
        public Int32 saveShortlistedOptionsCAPRound4(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveShortlistedOptionsCAPRound4", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveShortlistedOptionsCAPRound4()", "");
            }
        }
        public bool checkPreferenceNoCAPRound4(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckPreferenceNoCAPRound4", parameters));
                return Convert.ToBoolean(result);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkPreferenceNoCAPRound4()", "");
            }
        }
        public Int32 savePreferencesCAPRound4(Int64 PID, string PreferencesList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferencesList, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSavePreferencesCAPRound4", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "savePreferencesCAPRound4()", "");
            }
        }
        public DataSet getPreferancedOptionsListCAPRound4(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPreferancedOptionsListCAPRound4", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferancedOptionsListCAPRound4()", "");
            }
        }
        public Int32 getPreferencesCountCAPRound4(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPreferencesCountCAPRound4", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferencesCountCAPRound4()", "");
            }
        }
        public Int32 insertOptionCAPRound4(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string CreatedBy, string CreatedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCode, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionCAPRound4", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionCAPRound4()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound4(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionDirectCAPRound4", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionDirectCAPRound4()", "");
            }



        }
        public Int32 moveOptionCAPRound4(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCode, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spMoveOptionCAPRound4", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "moveOptionCAPRound4()", "");
            }
        }
        public Int32 confirmOptionFormCAPRound4(Int64 PID, string CandidatePassword, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CandidatePassword, ConfirmedBy, ConfirmedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmOptionFormCAPRound4", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmOptionFormCAPRound4()", "");
            }
        }
        public DataSet getPersonalInformationCAPRound4(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationCAPRound4", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPersonalInformationCAPRound4()", "");
            }
        }
        public DataSet getPreferancedOptionsListForDisplayCAPRound4(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPreferancedOptionsListForDisplayCAPRound4", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferancedOptionsListForDisplayCAPRound4()", "");
            }
        }
        public DataSet getInstructionsCAPRound4(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstructionsCAPRound4", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstructionsCAPRound4()", "");
            }
        }
        public DataSet getOptionFormConfirmationDetailsCAPRound4(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionFormConfirmationDetailsCAPRound4", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionFormConfirmationDetailsCAPRound4()", "");
            }

        }
        public bool isOptionFormConfirmedCAPRound4(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOptionFormConfirmedCAPRound4", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOptionFormConfirmedCAPRound4()", "");
            }
        }
        public bool cancelOptionFormCAPRound4(Int64 PID, String Comments, string CancelledBy, string CancelledByIPAddress)
        {

            try
            {
                object[] parameters = { PID, Comments, CancelledBy, CancelledByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelOptionFormCAPRound4", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "cancelOptionFormCAPRound4()", "");
            }
        }
        public bool isCandidateEligibleCAPRound4(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateEligibleCAPRound4", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateEligibleCAPRound4()", "");
            }
        }
        public bool changeCandidateEligibilityCAPRound4(Int64 PID, Int32 EligibilityStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, EligibilityStatus, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spChangeCandidateEligibilityCAPRound4", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "changeCandidateEligibilityCAPRound4()", "");
            }
        }
        public bool isOptionFormCancelledBeforeCAPRound4(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOptionFormCancelledBeforeCAPRound4", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOptionFormCancelledBeforeCAPRound4()", "");
            }

        }
        public bool saveOptionFormSummaryStepIDCAPRound4(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOptionFormSummaryStepIDCAPRound4", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveOptionFormSummaryStepIDCAPRound4()", "");
            }
        }
        public string getInvalidChoiceCodeListCAPRound4(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetInvalidChoiceCodeListCAPRound4", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInvalidChoiceCodeListCAPRound4()", "");
            }
        }
        public bool isCandidateSelectedOptionsCAPRound4(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateSelectedOptionsCAPRound4", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateSelectedOptionsCAPRound4()", "");
            }
        }

        public string getSeatAcceptanceStatus(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetSeatAcceptanceStatus", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSeatAcceptanceStatus()", "");
            }
        }

        public DataSet getCandidateStepListCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateStepListCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidateStepListCAPRound5()", "");
            }

        }
        public DataSet getSelectedOptionsListCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSelectedOptionsListCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSelectedOptionsListCAPRound5()", "");
            }
        }
        public DataSet getOptionsListCAPRound5(Int64 PID, string CourseCode, Int16 UniversityID, string DistrictName, string CourseStatus1, string CourseStatus2, string CourseStatus3)
        {
            try
            {
                object[] parameters = { PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3 };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionsListCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionsListCAPRound5()", "");
            }
        }
        public Int32 saveOptionsCAPRound5(Int64 PID, string OptionsList, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, OptionsList, CreatedBy, CreatedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOptionsCAPRound5", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveOptionsCAPRound5()", "");
            }


        }
        public Int32 deleteOptionsCAPRound5(Int64 PID, string OptionsList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, OptionsList, ModifiedBy, ModifiedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteOptionsCAPRound5", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteOptionsCAPRound5()", "");
            }


        }
        public Int32 saveShortlistedOptionsCAPRound5(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveShortlistedOptionsCAPRound5", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveShortlistedOptionsCAPRound5()", "");
            }


        }
        public bool checkPreferenceNoCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckPreferenceNoCAPRound5", parameters));
                return Convert.ToBoolean(result);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkPreferenceNoCAPRound5()", "");
            }
        }
        public Int32 savePreferencesCAPRound5(Int64 PID, string PreferencesList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferencesList, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSavePreferencesCAPRound5", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "savePreferencesCAPRound5()", "");
            }

        }
        public DataSet getPreferancedOptionsListCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPreferancedOptionsListCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferancedOptionsListCAPRound5()", "");
            }
        }
        public Int32 getPreferencesCountCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPreferencesCountCAPRound5", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferencesCountCAPRound5()", "");
            }


        }
        public Int32 insertOptionCAPRound5(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCode, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionCAPRound5", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionCAPRound5()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound5(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionDirectCAPRound5", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionDirectCAPRound5()", "");
            }
        }
        public Int32 moveOptionCAPRound5(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCode, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spMoveOptionCAPRound5", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "moveOptionCAPRound5()", "");
            }
        }
        public Int32 confirmOptionFormCAPRound5(Int64 PID, string CandidatePassword, string ConfirmedBy, string ConfirmedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, CandidatePassword, ConfirmedBy, ConfirmedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmOptionFormCAPRound5", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmOptionFormCAPRound5()", "");
            }



        }
        public DataSet getPersonalInformationCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPersonalInformationCAPRound5()", "");
            }
        }
        public DataSet getPreferancedOptionsListForDisplayCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPreferancedOptionsListForDisplayCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferancedOptionsListForDisplayCAPRound5()", "");
            }
        }
        public DataSet getInstructionsCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstructionsCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstructionsCAPRound5()", "");
            }
        }
        public DataSet getOptionFormConfirmationDetailsCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionFormConfirmationDetailsCAPRound5", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionFormConfirmationDetailsCAPRound5()", "");
            }
        }
        public bool isOptionFormConfirmedCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOptionFormConfirmedCAPRound5", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOptionFormConfirmedCAPRound5()", "");
            }

        }
        public bool cancelOptionFormCAPRound5(Int64 PID, String Comments, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                object[] parameters = { PID, Comments, CancelledBy, CancelledByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelOptionFormCAPRound5", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "cancelOptionFormCAPRound5()", "");
            }
        }
        public bool isCandidateEligibleCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateEligibleCAPRound5", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateEligibleCAPRound5()", "");
            }

        }
        public bool changeCandidateEligibilityCAPRound5(Int64 PID, Int32 EligibilityStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, EligibilityStatus, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spChangeCandidateEligibilityCAPRound5", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "changeCandidateEligibilityCAPRound5()", "");
            }

        }
        public bool isOptionFormCancelledBeforeCAPRound5(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOptionFormCancelledBeforeCAPRound5", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOptionFormCancelledBeforeCAPRound5()", "");
            }
        }

        public DataSet getSeatAcceptanceFeeList(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptanceFeeList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSeatAcceptanceFeeList()", "");
            }
        }
        public DataSet getSeatAcceptanceFeeList(Int64 PID, string FeeType)
        {
            try
            {
                object[] parameters = { PID, FeeType };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptanceFeeListByType", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSeatAcceptanceFeeList()", "");
            }
        }
        public DataSet getSeatAcceptanceFeeDetails(Int64 FeeID)
        {
            try
            {
                object[] parameters = { FeeID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptanceFeeDetailsByFeeID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSeatAcceptanceFeeDetails()", "");
            }
        }
        public DataSet getSeatAcceptanceFeeDetails(Int64 PID, string FeeType, string FeeLockStatus)
        {
            try
            {
                object[] parameters = { PID, FeeType, FeeLockStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptanceFeeDetails", parameters);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSeatAcceptanceFeeDetails()", "");
            }

        }
        public bool saveSeatAcceptanceFeeDetails(Int64 PID, SeatAcceptanceFeeDetails obj, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, obj.FeeID, obj.FeeType, obj.PaymentMode, obj.DDAmount, obj.DDNumber, obj.DDDate, obj.BankID, obj.OtherBankName, obj.BranchName, CreatedBy, CreatedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveSeatAcceptanceFeeDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveSeatAcceptanceFeeDetails()", "");
            }
        }
        public bool editSeatAcceptanceFeeDetails(SeatAcceptanceFeeDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { obj.FeeID, obj.DDAmount, obj.DDNumber, obj.DDDate, obj.BankID, obj.OtherBankName, obj.BranchName, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditSeatAcceptanceFeeDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editSeatAcceptanceFeeDetails()", "");
            }


        }
        public string getSeatAcceptanceConfirmationStatus(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetSeatAcceptanceConfirmationStatus", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSeatAcceptanceConfirmationStatus()", "");
            }
        }
        public DataSet getPersonalInformationForAllotmentDisplay(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationForAllotmentDisplay", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPersonalInformationForAllotmentDisplay()", "");
            }
        }
        public DataSet getAllotmentDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentDetails()", "");
            }
        }
        public bool isEligibleForSeatAcceptance(Int64 PID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { PID, CAPRound };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsEligibleForSeatAcceptance", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isEligibleForSeatAcceptance()", "");
            }

        }
        public DataSet getSeatAcceptanceStatusDetails(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptanceStatusDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSeatAcceptanceStatusDetails()", "");
            }
        }
        public DataSet getOptionsListAvailableForBetterment(Int64 PID, Int32 CAPRound, string SeatAcceptanceStatus)
        {
            try
            {
                object[] parameters = { PID, CAPRound, SeatAcceptanceStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOptionsListAvailableForBetterment", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOptionsListAvailableForBetterment()", "");
            }
        }
        public Int32 getPreferenceNoAllotted(Int64 PID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { PID, CAPRound };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPreferenceNoAllotted", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPreferenceNoAllotted()", "");
            }

        }
        public bool saveSeatAcceptanceStatusDetails(Int64 PID, string SeatAcceptanceStatus, Int32 CAPRound, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, SeatAcceptanceStatus, CAPRound, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveSeatAcceptanceStatusDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveSeatAcceptanceStatusDetails()", "");
            }

        }
        public bool editSeatAcceptanceStatusDetails(Int64 PID, string SeatAcceptanceStatus, Int32 CAPRound, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, SeatAcceptanceStatus, CAPRound, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditSeatAcceptanceStatusDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editSeatAcceptanceStatusDetails()", "");
            }
        }
        public Int32 getSeatAcceptanceFeePaidAmount(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetSeatAcceptanceFeePaidAmount", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSeatAcceptanceFeePaidAmount()", "");
            }
        }

        public Int64 checkSeatAcceptanceStatus(string ApplicationID, Int32 VersionNo, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { ApplicationID, VersionNo, CAPRound };
                Int64 result = Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckSeatAcceptanceStatus", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkSeatAcceptanceStatus()", "");
            }


        }
        public bool confirmSeatAcceptanceForm(Int64 PID, string XMLString, string ReportingComments, Int32 ReportedCAPRound, string ConfirmedBy, string ConfirmedByIPAddress)
        {

            try
            {
                object[] parameters = { PID, XMLString, ReportingComments, ReportedCAPRound, ConfirmedBy, ConfirmedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmSeatAcceptanceForm", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "confirmSeatAcceptanceForm()", "");
            }

        }
        public bool isSeatAcceptanceFormConfirmed(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsSeatAcceptanceFormConfirmed", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isSeatAcceptanceFormConfirmed()", "");
            }
        }
        public bool checkSeatAcceptanceFormConfirmationDetails(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {

            try
            {
                object[] parameters = { PID, UserTypeID, UserLoginID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckSeatAcceptanceFormConfirmationDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkSeatAcceptanceFormConfirmationDetails()", "");
            }
        }
        public bool cancelSeatAcceptanceForm(Int64 PID, string ReasonForCancellation, string CancelledChequeFilePath, string AccountNumber, string IFSCCode, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ReasonForCancellation, CancelledChequeFilePath, AccountNumber, IFSCCode, CancelledBy, CancelledByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelSeatAcceptanceForm", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "cancelSeatAcceptanceForm()", "");
            }
        }
        public bool isSeatAcceptanceFormCancelled(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsSeatAcceptanceFormCancelled", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isSeatAcceptanceFormCancelled()", "");
            }
        }
        public DataSet getRegionWiseARCReport()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRegionWiseARCReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRegionWiseARCReport()", "");
            }
        }
        public Int16 getARCRegionID(Int64 ARCID)
        {
            try
            {
                object[] parameters = { ARCID };
                Int16 result = Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetARCRegionID", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARCRegionID()", "");
            }
        }
        public DataSet getARCWiseReport(Int16 RegionID)
        {
            try
            {
                object[] parameters = { RegionID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARCWiseReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARCWiseReport()", "");
            }
        }
        public Int32 getARCInstituteID(Int64 ARCID)
        {
            try
            {
                object[] parameters = { ARCID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetARCInstituteID", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARCInstituteID()", "");
            }
        }
        public DataSet getSubARCWiseReport(Int16 RegionID, Int32 InstituteID)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubARCWiseReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSubARCWiseReport()", "");
            }
        }
        public DataSet getARCConfirmationDateList()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARCConfirmationDateList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARCConfirmationDateList()", "");
            }
        }
        public DataSet getARCConfirmedCandidateList(Int16 RegionID, Int32 InstituteID, Int32 ARCID, string ConfirmationDate)
        {

            try
            {
                object[] parameters = { RegionID, InstituteID, ARCID, ConfirmationDate };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARCConfirmedCandidateList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARCConfirmedCandidateList()", "");
            }
        }
        public string getAllotmentCancellationRemark(Int64 PID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { PID, CAPRound };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetAllotmentCancellationRemark", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentCancellationRemark()", "");
            }
        }
        public bool saveAllotmentCancellationRemark(Int64 PID, Int32 CAPRound, string CancellationRemark, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CAPRound, CancellationRemark, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveAllotmentCancellationRemark", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveAllotmentCancellationRemark()", "");
            }
        }

        public bool isEligibleForJKCounseling(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsEligibleForJKCounseling", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isEligibleForJKCounseling()", "");
            }
        }
        public bool isSeatOfferedForJKCounseling(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsSeatOfferedForJKCounseling", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public bool isOfferedSeatCancelledForJKCounseling(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOfferedSeatCancelledForJKCounseling", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOfferedSeatCancelledForJKCounseling()", "");
            }
        }
        public DataSet getPersonalInformationForJKCounseling(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationForJKCounseling", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getPersonalInformationForJKCounseling()", "");
            }
        }
        public DataSet getChoiceCodeListForJKCounseling(Int64 PID, string ChoiceCode)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetChoiceCodeListForJKCounseling", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getChoiceCodeListForJKCounseling()", "");
            }
        }
        public bool offerSeatForJKCounseling(Int64 PID, string ChoiceCodeOffered, string Comments, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ChoiceCodeOffered, Comments, ConfirmedBy, ConfirmedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spOfferSeatForJKCounseling", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "offerSeatForJKCounseling()", "");
            }
        }
        public DataSet getOfferedSeatDetailsForJKCounseling(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOfferedSeatDetailsForJKCounseling", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOfferedSeatDetailsForJKCounseling()", "");
            }
        }
        public bool editOfferedSeatForJKCounseling(Int64 PID, string ChoiceCodeOffered, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ChoiceCodeOffered, Comments, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditOfferedSeatForJKCounseling", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editOfferedSeatForJKCounseling()", "");
            }
        }
        public bool cancelOfferedSeatForJKCounseling(Int64 PID, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, Comments, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelOfferedSeatForJKCounseling", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "cancelOfferedSeatForJKCounseling()", "");
            }
        }
        public DataSet getOfferedSeatCancellationDetailsForJKCounseling(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOfferedSeatCancellationDetailsForJKCounseling", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getOfferedSeatReportForJKCounseling(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOfferedSeatReportForJKCounseling", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOfferedSeatReportForJKCounseling()", "");
            }
        }
        public DataSet getOfferedSeatCancellationReportForJKCounseling(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetOfferedSeatCancellationReportForJKCounseling", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOfferedSeatCancellationReportForJKCounseling()", "");
            }
        }
        public DataSet getVacantInstituteListForJKCounseling()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetVacantInstituteListForJKCounseling");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getVacantInstituteListForJKCounseling()", "");
            }
        }
        public string getTotalVacancyForJKCounseling()
        {
            try
            {
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetTotalVacancyForJKCounseling"));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getTotalVacancyForJKCounseling()", "");
            }
        }
        public DataSet getMeritListForJKCounseling()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMeritListForJKCounseling");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMeritListForJKCounseling()", "");
            }
        }
        public DataSet getAllotmentCancellationRemarkReport()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentCancellationRemarkReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentCancellationRemarkReport()", "");
            }
        }

        public DataSet getGroupByListForMISReport()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetGroupByListForMISReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getGroupByListForMISReport()", "");
            }
        }
        public DataSet getMISReport(string Query)
        {
            try
            {
                object[] parameters = { Query };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMISReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMISReport()", "");
            }
        }
        public DataSet downloadAdmittedCandidateData(Int32 InstituteID)
        {
            try
            {
                object[] parameters = { InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spDownloadAdmittedCandidateData", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "downloadAdmittedCandidateData()", "");
            }
        }
        public DataSet getCompositeReportByCategory(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportByCategory", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCompositeReportByCategory()", "");
            }
        }
        public DataSet getCompositeReportByCourse(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportByCourse", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCompositeReportByCourse()", "");
            }
        }
        public DataSet getCompositeReportByDistrict(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportByDistrict", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCompositeReportByDistrict()", "");
            }
        }
        public DataSet getCompositeReportByGender(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportByGender", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCompositeReportByGender()", "");
            }
        }
        public DataSet getCompositeReportByReligion(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportByReligion", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCompositeReportByReligion()", "");
            }

        }
        public DataSet getCompositeReportByUniversity(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportByUniversity", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCompositeReportByUniversity()", "");
            }
        }
        public string getIntakeForChoiceCode(string ChoiceCode)
        {
            try
            {
                object[] parameters = { ChoiceCode };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetIntakeForChoiceCode", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getIntakeForChoiceCode()", "");
            }
        }
        public DataSet getCompositeReportByChoiceCode(string ChoiceCode)
        {
            try
            {
                object[] parameters = { ChoiceCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportByChoiceCode", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCompositeReportByChoiceCode()", "");
            }
        }
        public DataSet getAdmittedCandidateListToSubmit(string ChoiceCode)
        {
            try
            {
                object[] parameters = { ChoiceCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdmittedCandidateListToSubmit", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdmittedCandidateListToSubmit()", "");
            }
        }
        public DataSet getSupernumeraryCandidateData(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSupernumeraryCandidateData", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSupernumeraryCandidateData()", "");
            }
        }

        public bool isCandidateInterestedInAdmissionCancellation(Int64 PID, Int64 ChoiceCode, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CAPRound };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateInterestedInAdmissionCancellation", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateInterestedInAdmissionCancellation()", "");
            }
        }
        public Int64 authenticateCandidateLogin(string ApplicationID, string Password)
        {

            try
            {
                object[] parameters = { ApplicationID, Password };
                Int64 result = Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAuthenticateCandidateLogin", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "authenticateCandidateLogin()", "");
            }
        }
        public bool saveWillingnessForAdmissionCancellation(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, string CandidatePassword, string RequestedBy, string RequestedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CAPRound, CandidatePassword, RequestedBy, RequestedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveWillingnessForAdmissionCancellation", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveWillingnessForAdmissionCancellation()", "");
            }
        }
        public DataSet getCandidateListRequestedForAdmissionCancellation(Int32 UserTypeID, string UserLoginID)
        {

            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateListRequestedForAdmissionCancellation", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidateListRequestedForAdmissionCancellation()", "");
            }
        }
        public DataSet getAdmittedChoiceCodeListForCancellation(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdmittedChoiceCodeListForCancellation", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdmittedChoiceCodeListForCancellation()", "");
            }
        }
        public DataSet getAdmittedChoiceCodeDetailsForCancellation(Int64 PID, Int64 ChoiceCode, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdmittedChoiceCodeDetailsForCancellation", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdmittedChoiceCodeDetailsForCancellation()", "");
            }
        }
        public DataSet getRequestedForAdmissionCancellationChoiceCodeList(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRequestedForAdmissionCancellationChoiceCodeList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRequestedForAdmissionCancellationChoiceCodeList()", "");
            }
        }
        public DataSet getRequestedForAdmissionCancellationChoiceCodeDetails(Int64 PID, Int64 ChoiceCode, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { PID, ChoiceCode, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRequestedForAdmissionCancellationChoiceCodeDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRequestedForAdmissionCancellationChoiceCodeDetails()", "");
            }

        }

        public bool saveFAQs(string Question, string Answer, string FAQType, Int32 SeqNo, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { Question, Answer, FAQType, SeqNo, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveFAQs", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveFAQs()", "");
            }

        }
        public bool editFAQs(Int64 FAQID, string Question, string Answer, string FAQType, Int32 SeqNo, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { FAQID, Question, Answer, FAQType, SeqNo, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEditFAQs", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editFAQs()", "");
            }
        }
        public bool deleteFAQs(Int64 FAQID, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { FAQID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteFAQs", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteFAQs()", "");
            }
        }
        public DataSet getFAQDetails(Int64 FAQID)
        {
            try
            {
                object[] parameters = { FAQID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetFAQDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getFAQDetails()", "");
            }
        }
        public DataSet getFAQs()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetFAQs");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getFAQs()", "");
            }
        }
        public DataSet getFAQsListForDisplay()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetFAQsListForDisplay");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getFAQsListForDisplay()", "");
            }
        }

        public DataSet getMasterARCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterARCList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterARCList()", "");
            }
        }
        public DataSet getNonARCInstituteList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetNonARCInstituteList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getNonARCInstituteList()", "");
            }
        }
        public bool addMasterARC(Int64 InstituteID, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { InstituteID, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAddMasterARC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "addMasterARC()", "");
            }
        }
        public bool deleteMasterARC(Int64 InstituteID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { InstituteID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteMasterARC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteMasterARC()", "");
            }
        }
        public bool isInstituteWorkingAsARC(Int64 InstituteID)
        {
            try
            {
                object[] parameters = { InstituteID };

                Int32 result = 0;
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsInstituteWorkingAsARC", parameters));
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isInstituteWorkingAsARC()", "");
            }
        }
        public DataSet getARCList(Int64 InstituteID)
        {
            try
            {
                object[] parameters = { InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARCListByInstituteID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARCList()", "");
            }
        }
        public string addARC(Int64 InstituteID, string ARCOfficerName, string ARCOfficerMobileNo, string Password, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { InstituteID, ARCOfficerName, ARCOfficerMobileNo, Password, CreatedBy, CreatedByIPAddress };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAddARC", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "addARC()", "");
            }
        }
        public bool updateARC(Int64 ARCID, string ARCOfficerName, string ARCOfficerMobileNo, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { ARCID, ARCOfficerName, ARCOfficerMobileNo, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateARC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateARC()", "");
            }
        }
        public bool deleteARC(Int64 ARCID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { ARCID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteARC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteARC()", "");
            }
        }
        public DataSet getSubARCList(Int64 ARCID)
        {
            try
            {
                object[] parameters = { ARCID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubARCListByARCID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public string addSubARC(Int64 ARCID, string SubARCOfficerName, string SubARCOfficerMobileNo, string Password, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { ARCID, SubARCOfficerName, SubARCOfficerMobileNo, Password, CreatedBy, CreatedByIPAddress };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAddSubARC", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "addSubARC()", "");
            }
        }
        public bool updateSubARC(Int64 SubARCID, string SubARCOfficerName, string SubARCOfficerMobileNo, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { SubARCID, SubARCOfficerName, SubARCOfficerMobileNo, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateSubARC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateSubARC()", "");
            }
        }
        public bool deleteSubARC(Int64 SubARCID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { SubARCID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spDeleteSubARC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteSubARC()", "");
            }
        }
        public bool saveARCProfile(ARCProfile obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { obj.ARCCode, obj.ARCAddress, obj.ARCPhoneNo, obj.ARCFaxNo, obj.CoordinatorName, obj.CoordinatorDesignation,
                    obj.CoordinatorDOB,obj.CoordinatorMobileNo, obj.CoordinatorAltMobileNo, obj.CoordinatorEmailID, obj.CoordinatorPhoneNo, obj.SecurityQuestionID, obj.SecurityAnswer, obj.ARCPassword, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveARCProfile", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveARCProfile()", "");
            }
        }
        public bool updateARCProfile(ARCProfile obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { obj.ARCCode, obj.ARCAddress, obj.ARCPhoneNo, obj.ARCFaxNo, obj.CoordinatorName, obj.CoordinatorDesignation,
                    obj.CoordinatorDOB,obj.CoordinatorMobileNo, obj.CoordinatorAltMobileNo, obj.CoordinatorEmailID, obj.CoordinatorPhoneNo, obj.SecurityQuestionID, obj.SecurityAnswer, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdateARCProfile", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateARCProfile()", "");
            }
        }
        public DataSet getARCProfile(string ARCCode)
        {
            try
            {
                object[] parameters = { ARCCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARCProfile", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARCProfile()", "");
            }
        }
        public bool changeARCPassword(string LoginID, string Password, string PasswordResetByIPAddress)
        {
            try
            {
                object[] parameters = { LoginID, Password, PasswordResetByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spChangeARCPassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "changeARCPassword()", "");
            }
        }
        public DataSet getARCListReport()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARCListReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARCListReport()", "");
            }
        }
        public DataSet getHSCResult(string hscSeatNo, string hscName, string MotherName, string hscPassingYear)
        {
            try
            {
                object[] parameters = { hscSeatNo, hscName, MotherName, hscPassingYear };
                return SqlHelper.ExecuteDataset(connectionString, "DTEMH_spGetHSCResult", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getHSCResult()", "");
            }
        }
        public DataSet getMasterJuridiction(string DocumentType)
        {

            try
            {
                object[] parameters = { DocumentType };
                return SqlHelper.ExecuteDataset(connectionString, "DTEMH_spGetJurisdiction", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterJuridiction()", "");
            }
        }
        public DataSet getMasterDistrictForJuridiction(int JurisdictionID)
        {
            try
            {
                object[] parameters = { JurisdictionID };
                return SqlHelper.ExecuteDataset(connectionString, "DTEMH_spGetDistrictForJuridiction", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterDistrictForJuridiction()", "");
            }
        }

        public DataSet GetDetailstoCancelAllotment(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "sp_GetDetailstoCancelAllotment", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDetailstoCancelAllotment()", "");
            }
        }
        public bool editCategoryDetails(Int64 PID, Int16 CategoryID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CategoryID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spEditCategoryDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editCategoryDetails()", "");
            }
        }
        public bool saveProjectConfigurationDetails(string AppKey, string AppValue, string ModifiedBy, string ModifiedByIPAddress)
        {

            try
            {
                object[] parameters = { AppKey, AppValue, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveProjectConfigurationDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveProjectConfigurationDetails()", "");
            }


        }
        public DataSet getProjectConfigurationDetails(string AppKey)
        {
            try
            {
                object[] parameters = { AppKey };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetProjectConfigurationDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getProjectConfigurationList()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetProjectConfigurationList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfigurationList()", "");
            }
        }
        public string getProjectConfiguration(string AppKey)
        {
            try
            {
                object[] parameters = { AppKey };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetProjectConfiguration", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getProjectConfiguration()", "");
            }
        }
        public bool saveActivityStatusDetails(string ActivityName, DateTime? ActivityStartDateTime, DateTime? ActivityEndDateTime, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { ActivityName, ActivityStartDateTime, ActivityEndDateTime, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveActivityStatusDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveActivityStatusDetails()", "");
            }
        }
        public DataSet getActivityStatusDetails(string ActivityName)
        {
            try
            {
                object[] parameters = { ActivityName };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetActivityStatusDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getActivityStatusDetails()", "");
            }

        }
        public DataSet getActivityStatusList()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetActivityStatusList");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getActivityStatusList()", "");
            }
        }
        public DataSet getActivityStatus(string ActivityName)
        {
            try
            {
                object[] parameters = { ActivityName };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetActivityStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getActivityStatus()", "");
            }
        }
        public DataSet getApplicationFormLinksStatus(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationFormLinksStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getApplicationFormLinksStatus()", "");
            }
        }
        public string getCategoryName(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetCategoryName", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCategoryName()", "");
            }
        }
        public string getAppliedForEWSFlag(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetAppliedForEWSFlag", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAppliedForEWSFlag()", "");
            }
        }
        public bool isOrphanAndNotEligibleForCategoryReservation(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsOrphanAndNotEligibleForCategoryReservation", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isOrphanAndNotEligibleForCategoryReservation()", "");
            }
        }
        public string getOriginalAppliedForEWSFlag(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetOriginalAppliedForEWSFlag", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getOriginalAppliedForEWSFlag()", "");
            }
        }
        public Int32 getReligiousMinorityID(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetReligiousMinorityID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReligiousMinorityID()", "");
            }
        }
        public Int32 getLinguisticMinorityID(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetLinguisticMinorityID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getLinguisticMinorityID()", "");
            }
        }
        public DataSet CheckOtp(Int64 PID, int OTPType)
        {

            try
            {
                object[] parameters = { PID, OTPType };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCheckOTP", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckOtp()", "");
            }
        }
        public bool SaveOTP(Int64 PID, int OTP, int OTPType, bool Isused, DateTime validtill, string moileNo, string EmailId, string ModifiedBy, string ModifiedByIPAddress, int IsOTPVerificationRequired)
        {
            try
            {
                object[] parameters = { PID, OTP, OTPType, Isused, validtill, moileNo, EmailId, ModifiedBy, ModifiedByIPAddress, IsOTPVerificationRequired };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveOTP", parameters));
                if (result.Length == 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "SaveOTP()", "");
            }
        }

        public bool CheckOtpvalidity(Int64 PID, int OTPType)
        {

            try
            {
                object[] parameters = { PID, OTPType };
                Int16 result = Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckOTP", parameters));
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckOtp()", "");
            }
        }
        //Razorpay
        public string getRazorpayCustormerID(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetRazorpayCustormerID", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRazorpayCustormerID()", "");
            }
        }
        public string updateRazorpayCustormerID(Int64 PID, string RazorpayCustomerID)
        {
            try
            {
                object[] parameters = { PID, RazorpayCustomerID };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateRazorpayCustormerID", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateRazorpayCustormerID()", "");
            }
        }
        public string ValidateDuplicateResponsebyRefNo(string RefNo)
        {
            try
            {
                object[] parameters = { RefNo };
                string Result = (string)SqlHelper.ExecuteScalar(connectionString, "sp_CheckPaymentID", parameters);
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ValidateDuplicateResponsebyRefNo()", "");
            }
        }
        public DataSet GetSMSEmailContent(Int64 PID, string Flag, string IPAddress, int IsOTPVerificationRequired)
        {
            try
            {
                object[] parameters = { PID, Flag, IPAddress, IsOTPVerificationRequired };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSMSEmailContent", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSMSEmailContent()", "");
            }
        }
        public DataSet getApplicationFeePaymentDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationFeePaymentDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSMSEmailContent()", "");
            }
        }
        public DateTime getApplicationFormCreatedDate(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                DateTime Result = Convert.ToDateTime(SqlHelper.ExecuteScalar(connectionString, "MHTDTE_spGetApplicationFormCreatedDate", parameters));
                return Result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSMSEmailContent()", "");
            }
        }
        public DataSet GetIncorrectNEETDetailsCandidate(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetIncorrectNEETDetailsCandidate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetIncorrectNEETDetailsCandidate()", "");
            }
        }
        public bool CheckLockForCAPRound1ByAdmin(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckLockForCAPRound1ByAdmin", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckLockForCAPRound1ByAdmin()", "");
            }
        }
        public bool isCanidateEligibletouploadCVCTVC(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spisCanidateEligibletouploadCVCTVC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCanidateEligibletouploadCVCTVC()", "");
            }
        }
        public bool CheckCandidateCVCStatus(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckCandidateCVCStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckCandidateCVCStatus()", "");
            }
        }
        public bool CategoryConverttoOPEN(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConverttoOPEN", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CategoryConverttoOPEN()", "");
            }
        }
        public bool UpdateCategoryConverttoOPEN(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateConverttoOPEN", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateCategoryConverttoOPEN()", "");
            }
        }
        public DataSet getAllotmentStatusCAPRound2ByPID(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentStatusCAPRound2ByPID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentStatusCAPRound2ByPID()", "");
            }
        }
        public DataSet getAllotmentStatusCAPRound3ByPID(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentStatusCAPRound3ByPID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentStatusCAPRound3ByPID()", "");
            }
        }
        public DataSet getILSeatAcceptanceFeeNotPaidReport(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetILSeatAcceptanceFeeNotPaidReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getILSeatAcceptanceFeeNotPaidReport()", "");
            }
        }
        public DataSet getCategoryConversionFeeNotPaidReport(string UserLoginID)
        {
            try
            {
                object[] parameters = { UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCategoryConversionFeeNotPaidReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCategoryConversionFeeNotPaidReport()", "");
            }
        }

        public DataSet getGetMaster_TemplateFields()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMaster_TemplateFields");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getGetMaster_TemplateFields()", "");
            }
        }
        public DataSet getGetSMSEmailTemplates(string type, string systemName)
        {
            try
            {
                object[] parameters = { type, systemName };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSMSEmailTemplates", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getGetSMSEmailTemplates()", "");
            }
        }
        public bool getSaveSMSEmailTemplates(string name, string template, string type, string systemName, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { name, template, type, systemName, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveSMSEmailTemplates", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getGetSMSEmailTemplates()", "");
            }
        }
        public bool chkDuplicateSMSEmailTemplateSystemName(string systemName)
        {
            try
            {
                object[] parameters = { systemName };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spchkDuplicateSMSEmailTemplateSystemName", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "chkDuplicateSMSEmailTemplateSystemName()", "");
            }
        }
        public DataSet getMasterPassingYear(string IsActive)
        {


            try
            {
                object[] parameters = { IsActive };
                DataSet ds = new DataSet();
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterPassingYear", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterPassingYear()", "");
            }
        }
        public DataSet getAllSMSEmailTemplates()
        {

            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllSMSEmailTemplates");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllSMSEmailTemplates()", "");
            }
        }
        public bool updateSMSEmailTemplates(Int64 Id, string name, string template, string type, string systemName, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { Id, name, template, type, systemName, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateSMSEmailTemplates", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateSMSEmailTemplates()", "");
            }
        }
        public bool updateSMSEmailTemplates(string template, string systemName, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { template, systemName, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateSMSEmailTemplatesBySystemName", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateSMSEmailTemplates()", "");
            }
        }
        public DataSet getEmailSMSTemplateBySystemName(string systemName)
        {
            try
            {
                object[] parameters = { systemName };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSMSEmailTemplatesBySystemName", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getEmailSMSTemplateBySystemName()", "");
            }
        }

        public bool SaveMasterTemplateFiled(string name)
        {
            try
            {
                object[] parameters = { name };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveMasterTemplateFiled", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getGetSMSEmailTemplates()", "");
            }
        }
        public DataSet getApplicationFormCancellationDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationFormCancelDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getApplicationFormCancellationDetails()", "");
            }
        }
        public DataSet getDataForReminderSMS(string systemName)
        {
            try
            {
                object[] parameters = { systemName };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDataForSMSReminderbyTemplate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDataForReminderSMS()", "");
            }

        }
        public DataSet getAdminNonRepliedMessages_Canidate(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdminNonRepliedMessagesToCandidate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdminNonRepliedMessages()", "");
            }
        }
        public bool CandidateComposeMessage(string To, string From, string Subject, string Message, string FilePath1, string FilePath2, string SentBy, string SentByIPAddress)
        {
            try
            {
                object[] parameters = { To, From, Subject, Message, FilePath1, FilePath2, SentBy, SentByIPAddress };
                //Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spAFCComposeMessageToCandidate", parameters));
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spAdminComposeMessageToCandidate", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CandidateComposeMessage()", "");
            }
        }
        public DataSet getCandidateNonRepliedMessages(string CandidateCode)
        {
            try
            {
                object[] parameters = { CandidateCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateNonRepliedMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCNonRepliedMessages()", "");
            }
        }
        public bool CheckCandidateValidForMessage(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckCandidateValidForMessage", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckCandidateValidForMessage()", "");
            }
        }
        public bool replyMessageToCandidate(Int64 MessageID, string RepliedMessage, string RepliedBy, string RepliedByIPAddress, string To, string From, string FilePath1, string FilePath2)
        {
            try
            {
                object[] parameters = { MessageID, RepliedMessage, RepliedBy, RepliedByIPAddress, To, From, FilePath1, FilePath2 };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spReplyMessageToCandidate", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "replyMessageToCandidate()", "");
            }
        }

        public DataSet getMessagesListToCandidate(string From)
        {
            try
            {
                object[] parameters = { From };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMessagesListToCandidate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMessagesListToCandidate()", "");
            }
        }
        public DataSet getAdminRepliedMessagesToCandidate(string Flag)
        {

            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdminRepliedMessagesToCandidate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdminRepliedMessagesToCandidate()", "");
            }
        }
        public DataSet GetRepliedMessagesToCandidateByAdmin(string CandidateCode)
        {
            try
            {
                object[] parameters = { CandidateCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRepliedMessagesToCandidateByAdmin", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetRepliedMessagesToCandidateByAdmin()", "");
            }
        }

        public DataSet getAllMasterVillage()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllMasterVillage");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllMasterVillage()", "");
            }
        }
        public DataSet getAllMasterTaluka()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllMasterTaluka");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllMasterTaluka()", "");
            }
        }
        public DataSet getAllMasterDistrict()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllMasterDistrict");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "etAllMasterDistrict()", "");
            }
        }
        public DataSet getVacancyForAdditionRoundByFlag(string ChoiceCode, string Flag)
        {
            try
            {
                object[] parameters = { ChoiceCode, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRepliedMessagesToCandidateByAdmin", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getVacancyForAdditionRoundByFlag()", "");
            }
        }
        public DataSet GetCvcTvcReport()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHTCET_GETALLADMISSIONCVCTVCCOUNDS");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetCvcTvcReport()", "");
            }
        }
        public DataSet getInstitueAllotedCandidateACAP(string InstitueID, string ChoiceCode)
        {
            try
            {
                object[] parameters = { InstitueID, ChoiceCode };
                return SqlHelper.ExecuteDataset(connectionString, "DTEMH_spgetInstitueAllotedCandidateACAP", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstitueAllotedCandidateACAP()", "");
            }
        }
        public bool getInstitueParticipationInAditionalRound(Int64 InstitueID)
        {
            try
            {
                object[] parameters = { InstitueID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spgetInstituteForParticipationInAditionalRound", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstitueParticipationInAditionalRound()", "");
            }
        }
        public bool updateInstitueParticipationInAditionalRound(Int64 InstitueID, string ParticipationInAditionalRound, string UpdatedBy, string UpdatedByIPAddress)
        {
            try
            {
                object[] parameters = { InstitueID, ParticipationInAditionalRound, UpdatedBy, UpdatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateInstituteForParticipationInAditionalRound", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateInstitueParticipationInAditionalRound()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound3_SpecialChoiceAfterConfirm(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spInsertOptionDirectCAPRound3_SpecialChoiceAfterConfirm", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "insertOptionDirectCAPRound3_SpecialChoiceAfterConfirm()", "");
            }
        }
        public Int32 updateInstitueAllotedCandidateACAPSeatType(Int64 PersonalID, string ChoiceCode, string SelectedSeatType, string UpdatedBy, string UpdatedByIPAddress)
        {
            try
            {
                object[] parameters = { PersonalID, ChoiceCode, SelectedSeatType, UpdatedBy, UpdatedByIPAddress };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "DTEMH_spUpdateInstitueAllotedCandidateACAPSeatType", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateInstitueAllotedCandidateACAPSeatType()", "");
            }
        }
        public DataSet getMasterHSCSubject()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterHSCSubject");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstitueAllotedCandidateACAP()", "");
            }
        }

        public DataSet GetAllMasterMHTaluka()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllMasterMHTaluka");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAllMasterMHTaluka()", "");
            }
        }
        public DataSet getAllMasterofInstituteChoiceCodeUniversity()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllMasterofInstituteChoiceCodeUniversity");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllMasterofInstituteChoiceCodeUniversity()", "");
            }
        }
        public bool CheckFCVerificationStatus(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckFCVerificationStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UnlockApplicationForm()", "PID : " + PID);
            }
        }
        public DataSet getVerificationFlags(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetVerificationFlags", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getVerificationFlags()", "PID :" + PID);
            }
        }
        public bool checkActiveTicketExist(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spcheckActiveTicketExist", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkActiveTicketExist()", "PID :" + PID);
            }
        }
        public string CheckCandidateFCVerificationFor(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckCandidateFCVerificationFor", parameters));
                //if (result > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckCandidateFCVerificationFor()", "PersonalID :" + PersonalID);
            }

        }

        public string GetApplicationLockStatus(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_GetApplicationLockStatus", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCourseAppliedFor()", "");
            }
        }
        public DataSet GetDocumentListByUploadedFlag(Int64 PID, string SubmittedFlag)
        {
            try
            {
                object[] parameters = { PID, SubmittedFlag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentListByUploadedFlag", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListByUploadedFlag()", "PID :" + PID + " SubmittedFlag :" + SubmittedFlag);
            }
        }
        public bool saveUploadDocumentStepID(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveUploadDocumentStepID", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveUploadDocumentStepID()", "");
            }
        }
        public bool CheckBankDetailsStatus(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckBankDetailsStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckBankDetailsStatus()", "PersonalID " + PersonalID);
            }
        }
        public bool SaveBankDetailsSkip(Int64 PersonalID, string CreatedBy, string CreatedByIPAddress, string DeviceInfo)
        {
            try
            {
                object[] parameters = { PersonalID, CreatedBy, CreatedByIPAddress, DeviceInfo };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveBankDetailsSkip", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "SaveBankDetailsSkip()", "PersonalID " + PersonalID);
            }
        }
        public bool SaveBankDetails(Int64 PersonalID, Int64 AadhaarNo, string BankName, string IFSCCODE, string BankAccountNo, string AccountHolderName, string CreatedBy, string CreatedByIPAddress, string DeviceInfo)
        {
            try
            {
                object[] parameters = { PersonalID, AadhaarNo, BankName, IFSCCODE, BankAccountNo, AccountHolderName, CreatedBy, CreatedByIPAddress, DeviceInfo };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveBankDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "SaveBankDetails()", "PersonalID " + PersonalID);
            }
        }

        public DataSet GetBankDetailsStatus(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetBankDetailsStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetBankDetailsStatus()", "PersonalID: " + PersonalID);
            }
        }
        public DataSet GetMasterMHDistrictForFCVerification()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterMHDistrictForFCVerification");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetMasterMHDistrictForFCVerification()", "");
            }

        }
        public DataSet GetCandidateBookingSlotDetails(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateBookingSlotDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetCandidateBookingSlotDetails()", "PersonalID" + PersonalID);
            }

        }
        public DataSet GetSlotDates(string AFCCode)
        {
            try
            {
                object[] parameters = { AFCCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSlotDates", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSlotDates()", "AFCCode" + AFCCode);
            }

        }
        public DataSet GetFCDetailsForSlotBooking(int DistrictID)
        {
            try
            {
                object[] parameters = { DistrictID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetFCDetailsForSlotBooking", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "SaveCandidateBookedSlot()", "DistrictID" + DistrictID);
            }

        }
        public DataSet GetSlotForFC(string FCID, string SlotDate)
        {
            try
            {
                object[] parameters = { FCID, SlotDate };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSlotForFC", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSlotForFC()", "FCID" + FCID);
            }
        }
        public Int16 SaveCandidateBookedSlot(Int64 FCDateID, int SlotID, Int64 PersonalID, string CreatedBy, string CreatedByIpAddress)
        {
            try
            {
                object[] parameters = { FCDateID, SlotID, PersonalID, CreatedBy, CreatedByIpAddress };
                return Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveCandidateBookedSlot", parameters));

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "SaveCandidateBookedSlot()", "PersonalID :" + PersonalID + " FCDateID: " + FCDateID + " SlotID:" + SlotID);
            }

        }
        public bool UpdateCandidateFCVerificationFor(Int64 PersonalID, string FCVerificationFor, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PersonalID, FCVerificationFor, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdateCandidateFCVerificationFor", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateCandidateFCVerificationFor()", "PersonalID :" + PersonalID);
            }

        }
        public bool UpdateCandidateBrowserOS(Int64 PersonalID, string BrowserOS)
        {
            try
            {
                object[] parameters = { PersonalID, BrowserOS };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdateCandidateBrowserOS", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateCandidateBrowserOS()", "PersonalID :" + PersonalID);
            }

        }
        public string getAppliedForTFWSFlag(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetAppliedForTFWSFlag", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAppliedForTFWSFlag()", "");
            }
        }
        public DataSet GetApplicationFormVersionNo(Int64 PID, string VersionNoFlag)
        {
            try
            {
                object[] parameters = { PID, VersionNoFlag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetVersionNo", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListByUploadedFlag()", "PID :" + PID);
            }
        }
        public DataSet GetPersonalInformationByApplicationVersionNo(Int64 PID, Int32 VersionNo)
        {
            try
            {
                object[] parameters = { PID, VersionNo };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationByApplicationVersionNo", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListByUploadedFlag()", "PID :" + PID + " VersionNo :" + VersionNo);
            }
        }
        public DataSet MHDTE_spGetPersonalInformationByAcknowledgementVersionNo(Int64 PID, Int32 VersionNo)
        {
            try
            {
                object[] parameters = { PID, VersionNo };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationByAcknowledgementVersionNo", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListByUploadedFlag()", "PID :" + PID + " VersionNo :" + VersionNo);
            }
        }


        //MAHA IT Document Fetch Start
        public bool InsertUpdateDocumentFetchData(ResponseCommon obj)
        {
            try
            {
                obj.AllottedDate = obj.ClosedOn;
                object[] parameters = {  obj.PersonalID,obj.DocumentID,obj.Barcode,obj.ApplicantName,obj.Caste,obj.BenfiName,obj.AllottedDate,obj.DistrictName,obj.PaymentDate,obj.YearsOfResidency,obj.CertificateDate,
obj.TribeName,obj.ApplicationType,obj.CommitteeName,obj.CertificateIssuedById,obj.AllottedDate,obj.PercentageOfDisability,obj.DisabilityType,obj.Years,obj.FirstYearIncome,obj.SecondYearIncome,obj.ThirdYearIncome,
        obj.CreatedBy,obj.CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spInsertUpdateDocumentFetchData", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "InsertUpdateDocumentFetchData()", "PersonalID :" + obj.PersonalID + " DocumentID" + obj.DocumentID);
            }
        }

        public DataSet GetDocumentFetchData(Int64 PersonalID, Int64 DocID)
        {
            try
            {
                object[] parameters = { PersonalID, DocID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentFetchData", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentFetchData()", "PersonalID" + PersonalID + " DocID: " + DocID);
            }

        }

        //MAHA IT Document Fetch END

        //E verification Start
        public bool editConfirmedApplicationFormEvrification(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsTFWSChanged, Int32 IsMinorityChanged, Int32 IsEWSChanged, Int32 IsOrphanChanged, string Comments, string IsNCLReceiptSubmitted, DateTime NCLIssueDate, Int32 NCLValidUpto, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = {  PID,  IsCandidatureTypeChanged,  IsCategoryChanged,  IsPHTypeChanged,  IsDefenceTypeChanged,  IsTFWSChanged,
                    IsMinorityChanged,    IsEWSChanged,  IsOrphanChanged,  Comments,IsNCLReceiptSubmitted,  NCLIssueDate,  NCLValidUpto,  ModifiedBy,  ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spEditConfirmedApplicationFormEvrification", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "editConfirmedApplicationForm()", "");
            }
        }
        public DataSet GetApplicationFormConfirmationDetailsGrivance(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationFormConfirmationDetailsGrivance", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetApplicationFormConfirmationDetailsGrivance()", "PID" + PID);
            }

        }
        public bool SaveSubmitApplicationFormStepID(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveSubmitApplicationFormStepID", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "SaveSubmitApplicationFormStepID()", "PID : " + PID);
            }
        }
        public bool UnlockApplicationForm(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUnlockApplicationForm", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UnlockApplicationForm()", "PID : " + PID);
            }
        }
        //public DataSet GetPersonalInformationByApplicationVersionNo(Int64 PID, Int32 VersionNo)
        //{
        //    try
        //    {
        //        object[] parameters = { PID, VersionNo };
        //        return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationByApplicationVersionNo", parameters);
        //    }
        //    catch (SqlException Ex)
        //    {
        //        long messageID = ExceptionMessages.GetMessageDetails();
        //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListByUploadedFlag()", "PID :" + PID + " VersionNo :" + VersionNo);
        //    }
        //}
        //public DataSet MHDTE_spGetPersonalInformationByAcknowledgementVersionNo(Int64 PID, Int32 VersionNo)
        //{
        //    try
        //    {
        //        object[] parameters = { PID, VersionNo };
        //        return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetPersonalInformationByAcknowledgementVersionNo", parameters);
        //    }
        //    catch (SqlException Ex)
        //    {
        //        long messageID = ExceptionMessages.GetMessageDetails();
        //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListByUploadedFlag()", "PID :" + PID + " VersionNo :" + VersionNo);
        //    }
        //}
        //public DataSet GetApplicationFormVersionNo(Int64 PID, string VersionNoFlag)
        //{
        //    try
        //    {
        //        object[] parameters = { PID, VersionNoFlag };
        //        return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetVersionNo", parameters);
        //    }
        //    catch (SqlException Ex)
        //    {
        //        long messageID = ExceptionMessages.GetMessageDetails();
        //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListByUploadedFlag()", "PID :" + PID);
        //    }
        //}
        public DataSet GetCandidateVerificationStepwiseStatusForAFC(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateVerificationStepwiseStatusForAFC", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetCandidateVerificationStepwiseStatusForAFC()", "PID :" + PID);
            }
        }
        public DataSet GetDocumentListForDataVerificationByStepID(Int64 PID, Int32 ApplicationFormStepID)
        {
            try
            {
                object[] parameters = { PID, ApplicationFormStepID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentListForDataVerificationByStepID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListForDataVerificationByStepID()", "PID :" + PID);
            }
        }
        public DataSet GetDocumentListForDocumentVerificationByStepID(Int64 PID, Int32 ApplicationFormStepID)
        {
            try
            {
                object[] parameters = { PID, ApplicationFormStepID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentListForDocumentVerificationByStepID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListForDocumentVerificationByStepID()", "PID :" + PID);
            }
        }
        public DataSet GetDiscrepancyListByStepID(Int64 PID, int ApplicationFormStepID)
        {
            try
            {
                object[] parameters = { PID, ApplicationFormStepID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDiscrepancyListByStepID", parameters);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDiscrepancyListByStepID()", "PID :" + PID + "ApplicationFormStepID :" + ApplicationFormStepID);
            }
        }
        public bool UpdatePickedupStatus(Int64 PID, string UserLoginID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, UserLoginID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdatePickedupStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdatePickedupStatus()", "PID :" + PID + " UserLoginID:" + UserLoginID);
            }
        }
        public bool UpdateDiscrepancySubmission(Int64 PID, string XMLString, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, XMLString, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateDiscrepancySubmission", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateDiscrepancySubmission()", "PID :" + PID + " XMLString:" + XMLString);
            }
        }
        public Int32 CheckDiscrepancyExists(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckDiscrepancyExists", parameters));
                //if (result == 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckDiscrepancyExists()", "PID :" + PID);
            }
        }
        public bool ConfirmApplicationFormWithDiscrepancy(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsTFWSChanged, Int32 IsMinorityChanged, Int32 IsIGDChanged, Int32 IsEWSChanged, Int32 IsOrphanChanged, string Comments, DateTime NCLIssueDate, Int32 NCLValidUpto, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                object[] parameters = {  PID,  IsCandidatureTypeChanged,  IsCategoryChanged,  IsPHTypeChanged,  IsDefenceTypeChanged,  IsTFWSChanged,  IsMinorityChanged,
                     IsIGDChanged,  IsEWSChanged,  IsOrphanChanged,  Comments,  NCLIssueDate,  NCLValidUpto,  ConfirmedBy,  ConfirmedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spConfirmApplicationFormWithDiscrepancy", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ConfirmApplicationFormWithDiscrepancy()", "");
            }
        }
        public DataSet GetDiscrepancyDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDiscrepancyDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDiscrepancyDetails()", "PID :" + PID);
            }
        }
        public DataSet GetApplicationFormListForFCReVerificationofGrievance(string UserLoginID, int UserTypeID)
        {
            try
            {
                object[] parameters = { UserLoginID, UserTypeID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationFormListForFCReVerificationofGrievance", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetApplicationFormListForFCReVerificationofGrievance()", "");
            }
        }
        public DataSet CheckFCForConfirmApplicationForm(string UserLoginID, long PersonalID, long ID, string IPAddress)
        {
            try
            {
                object[] parameters = { UserLoginID, PersonalID, ID, IPAddress };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCheckFCForConfirmApplicationForm", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetFCToConfirmApplicationForm()", "");
            }
        }
        public string CheckISEFC(string AFCCode)
        {
            try
            {
                object[] parameters = { AFCCode };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckISEFC", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckISEFC()", " AFCCode " + AFCCode);
            }
        }
        public DataSet GetSubAFCEConfirmedCount(int RegionID, int InstituteID)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubAFCEConfirmedCount", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSubAFCEConfirmedCount()", "RegionID " + RegionID + " InstituteID " + InstituteID);
            }
        }
        public DataSet GetSubAFCDiscrepancyMarkedCount(int RegionID, int InstituteID)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubAFCDiscrepancyMarkedCount", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSubAFCDiscrepancyMarkedCount()", "RegionID " + RegionID + " InstituteID " + InstituteID);
            }
        }
        public DataSet getRegionWiseApplicationFormListForFCVerification()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRegionWiseApplicationFormListForFCVerification");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRegionWiseApplicationFormListForFCVerification()", "");
            }
        }
        public DataSet getRequiredDocumentList(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRequiredDocumentList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRequiredDocumentList()", "");
            }
        }
        public DataSet GetEFCConfiredCandidateList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, AFCID, ConfirmationDate };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetEFCConfiredCandidateList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetEFCConfiredCandidateList()", "");
            }
        }
        public DataSet GetDiscrepancyMarkedCandidateList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, AFCID, ConfirmationDate };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDiscrepancyMarkedCandidateList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDiscrepancyMarkedCandidateList()", "");
            }
        }
        public DataSet GetApplicationFormListForPartialFCVerification(string UserLoginID, int UserTypeID)
        {
            try
            {
                object[] parameters = { UserLoginID, UserTypeID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationFormListForPartialFCVerification", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetApplicationFormListForPartialFCVerification()", "");
            }
        }
        public DataSet GetApplicationFormListForFCVerification(string UserLoginID, int UserTypeID)
        {
            try
            {
                object[] parameters = { UserLoginID, UserTypeID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationFormListForFCVerification", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetApplicationFormListForFCVerification()", "");
            }
        }
        public DataSet getAFCWiseApplicationFormListForFCVerification(Int16 RegionID)
        {
            try
            {
                object[] parameters = { RegionID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCWiseApplicationFormListForFCVerification", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCWiseApplicationFormListForFCVerification()", "");
            }
        }

        // Session 2
        public bool LockApplicationForm(Int64 PersonalID, string CreatedBy, string CreatedByIpAddress)
        {
            try
            {
                object[] parameters = { PersonalID, CreatedBy, CreatedByIpAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spLockApplicationForm", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "LockApplicationForm()", "PersonalID :" + PersonalID);
            }
        }
        public bool UnLockApplicationFormByCandidate(Int64 PersonalID, string CreatedBy, string CreatedByIpAddress)
        {
            try
            {
                object[] parameters = { PersonalID, CreatedBy, CreatedByIpAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUnLockApplicationFormByCandidate", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UnLockApplicationFormByCandidate()", "PersonalID :" + PersonalID);
            }
        }
        public bool CheckFCVerificationStatusForResubmission(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckFCVerificationStatusForResubmission", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckFCVerificationStatusForResubmission()", "PersonalID :" + PersonalID);
            }
        }
        public DataSet GetCandidateEFCAllotted(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateEFCAllotted", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetCandidateEFCAllotted()", "PersonalID" + PersonalID);
            }

        }
        public DataSet GetAFCNonRepliedGrievance(string Flag, string To)
        {
            try
            {
                object[] parameters = { Flag, To };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCNonRepliedGrievance", parameters);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAFCNonRepliedGrievance()", "");
            }
        }
        public DataSet getAFCWiseReport(Int16 RegionID)
        {
            try
            {
                object[] parameters = { RegionID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCWiseReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAFCWiseReport()", "");
            }
        }
        public DataSet GetRegionWiseConfirmationReport()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRegionWiseConfirmationReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetRegionWiseConfirmationReport()", "");
            }
        }
        public DataSet GetEFCRegistrationandConfirmationStatusReport()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetEFCRegistrationandConfirmationStatusReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetEFCRegistrationandConfirmationStatusReport()", "");
            }
        }
        public DataSet GetApplicationFormStatistics()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationFormStatistics");

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetApplicationFormStatistics()", "");

            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetApplicationFormStatistics()", "");
            }
        }
        public DataSet GetAFCWiseConfirmationReport(Int16 RegionID)
        {
            try
            {
                object[] parameters = { RegionID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCWiseConfirmationReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAFCWiseConfirmationReport()", "");
            }
        }
        public bool CheckCETDiscrepancy(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckCETDiscrepancy", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckFCVerificationStatusForResubmission()", "PersonalID :" + PersonalID);
            }
        }
        public bool CheckNEETDiscrepancy(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckNEETDiscrepancy", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckFCVerificationStatusForResubmission()", "PersonalID :" + PersonalID);
            }
        }

        public bool SolveCETDiscrepancy(Int64 PersonalID, Int64 CETApplicationFormNo, string CreatedBy, string CreatedByIpAddress)
        {
            try
            {
                object[] parameters = { PersonalID, CETApplicationFormNo, CreatedBy, CreatedByIpAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSolveCETDiscrepancy", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "SolveCETDiscrepancy()", "PersonalID :" + PersonalID);
            }
        }

        public DataSet getReplyMessageByMessageID(Int64 MessageID)
        {
            try
            {
                object[] parameters = { MessageID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReplyMessageByMessageID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReplyMessageByMessageID()", "");
            }
        }
        public DataSet getRepliedMessagesListToCandidate(string From)
        {
            try
            {
                object[] parameters = { From };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRepliedMessagesListToCandidate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetApplicationFormListForPartialFCVerification()", "");
            }
        }
        public DataSet GetFailTransections(string PID)
        {
            try
            {
                object[] param = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "sp_GetFailedPaymentDetailsForStudent", param);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetFailTransections()", "");

            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetFailTransections()", "");
            }
        }
        public DataSet GetAllTransectionByPersonalID(string PID)
        {
            try
            {
                object[] param = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "sp_GetAllPaymentDetailsForStudentCheckFromRZPay", param);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetFailTransections()", "");

            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetFailTransections()", "");
            }
        }
        public bool UpdatePaymentReconcelation(Int64 ReferenceNo, Int64 PID, string PayGateId, string ModifiedBy)
        {
            try
            {
                object[] parameters = { ReferenceNo, PID, PayGateId, ModifiedBy };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdatePaymentReconcile", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdatePaymentReconcelation()", "PID: " + PID + " ReferenceNo : " + ReferenceNo);
            }
        }
        public bool SaveSelfVerification(SelfVerification obj)
        {
            try
            {
                object[] parameters = { obj.PersonalID ,obj.Gender, obj.FinalCandidatureType, obj.FinalCategory, obj.FinalAppliedForEWS, obj.FinalPHType,obj.FinalDefenceType,obj.FinalIsOrphan, obj.FinalAppliedForTFWS,
obj.FinalLinguisticMinority, obj.FinalReligiousMinority, obj.SSCMathMarksObtained, obj.SSCTotalMarksObtained,obj.SSCTotalPercentage, obj.FinalIsIntermediateGradeDrawing,obj.HSCPhysicsMarksObtained, obj.HSCChemistryMarksObtained,
obj.HSCMathMarksObtained, obj.HSCBiologyMarksObtained, obj.HSCEnglishMarksObtained, obj.HSCTotalMarksObtained, obj.HSCTotalPercentage,obj.SSCMathMarksNew ,obj.SSCTotalMarksNew ,obj.SSCTotalPercentageNew ,obj.FinalIsIntermediateGradeDrawingNew,
obj.HSCPhysicsMarksNew ,obj.HSCChemistryMarksNew , obj.HSCMathMarksNew ,obj.HSCBiologyMarksNew ,obj.HSCEnglishMarksNew ,obj.HSCTotalMarksNew ,obj.HSCTotalPercentageNew ,obj.CreatedBy,obj.CreatedByIPAddress,obj.IsGrivanceRaised,obj.XMLstring, obj.ReportedCAPRound,
                obj.isAllotmentCancellationRequired, obj.Message,obj.SSCMathMarksOutofNew,obj.SSCTotalMarksOutofNew,obj.HSCPhysicsMarksOutofNew,obj.HSCChemistryMarksOutofNew,obj.HSCMathMarksOutofNew,obj.HSCBiologyMarksOutofNew,obj.HSCEnglishMarksOutofNew,obj.HSCTotalMarksOutofNew,
                obj.HSCSubjectMarksObtained,obj.SubjectId, obj.HSCSubjectMarksNew,obj.HSCSubjectMarksOutOfNew,obj.DiplomaMarksType,obj.DiplomaMarksObtained,obj.DiplomaMarksNew,obj.DiplomaMarksOutofNew};
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveSelfVerification", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "SaveSelfVerification()", "PID: " + obj.PersonalID);
            }
        }
        public bool CheckSelfVerificationIsDone(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckSelfVerificationIsDone", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckSelfVerificationIsDone()", "PID: " + PID);
            }
        }

        public DataSet getHSCResult(string SeatNo, string PassingYear)
        {
            try
            {
                object[] param = { SeatNo, PassingYear };
                return SqlHelper.ExecuteDataset(connectionString, "DTEMH_spGetHSCResultForHelp", param);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getHSCResult()", "");

            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getHSCResult()", "");
            }
        }

        public DataSet CheckDiscrepancyDetailsCandidateureType(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spcheckDiscrepancyDetailsCandidateureType", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckDiscrepancyDetailsCandidateureType()", "PID :" + PID);
            }
        }

        public DataSet GetSubAFCWiseSeatAcceptanceGrievanceVerifcationCount(Int16 RegionID, Int32 InstituteID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubAFCWiseSeatAcceptanceGrievanceVerifcationCount", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSubAFCWiseSeatAcceptanceGrievanceVerifcationCount()", "RegionID" + RegionID);
            }
        }

        public DataSet GetSubAFCWiseSeatAcceptanceGrievanceRejectedCount(Int16 RegionID, Int32 InstituteID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubAFCWiseSeatAcceptanceGrievanceRejectedCount", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSubAFCWiseSeatAcceptanceGrievanceRejectedCount()", "RegionID" + RegionID);
            }
        }

        public DataSet GetSubAFCWiseSeatAcceptanceGrievancePickedupCount(Int16 RegionID, Int32 InstituteID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubAFCWiseSeatAcceptanceGrievancePickedupCount", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSubAFCWiseSeatAcceptanceGrievancePickedupCount()", "RegionID" + RegionID);
            }
        }

        public DataSet GetSubAFCWiseSeatAcceptanceGrievanceApprovedCount(Int16 RegionID, Int32 InstituteID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSubAFCWiseSeatAcceptanceGrievanceApprovedCount", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSubAFCWiseSeatAcceptanceGrievanceApprovedCount()", "RegionID" + RegionID);
            }
        }

        public DataSet GetSeatAcceptanceGrievanceListForVerification(Int16 RegionID, Int32 InstituteID, Int32 AFCID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, AFCID, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptanceGrievanceListForVerification", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSeatAcceptanceGrievanceListForVerification()", "AFCID" + AFCID);
            }
        }
        public DataSet GetSeatAcceptanceRejectedGrievanceList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, AFCID, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptanceRejectedGrievanceList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSeatAcceptanceRejectedGrievanceList()", "AFCID" + AFCID);
            }
        }
        public DataSet GetSeatAcceptancePickedupGrievanceList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, AFCID, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptancePickedupGrievanceList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSeatAcceptancePickedupGrievanceList()", "AFCID" + AFCID);
            }
        }
        public DataSet GetSeatAcceptanceApprovedGrievanceList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, AFCID, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptanceApprovedGrievanceList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSeatAcceptanceApprovedGrievanceList()", "AFCID" + AFCID);
            }
        }

        public DataSet GetRegionWiseSeatAcceptanceGrievanceStatus(string GrievanceStatusFlag, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { GrievanceStatusFlag, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRegionWiseSeatAcceptanceGrievanceStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetRegionWiseSeatAcceptanceGrievanceStatus()", "GrievanceStatusFlag" + GrievanceStatusFlag);
            }
        }

        public DataSet GetAFCWiseSeatAcceptanceGrievanceStatus(Int16 RegionID, string GrievanceStatusFlag, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { RegionID, GrievanceStatusFlag, CAPRound };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCWiseSeatAcceptanceGrievanceStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAFCWiseSeatAcceptanceGrievanceStatus()", "GrievanceStatusFlag" + GrievanceStatusFlag);
            }
        }

        public DataSet getSelfVerificationDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSelfVerificationDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSelfVerificationDetails()", "");
            }
        }

        public DataSet GetSelfVerificationstatus(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSelfVerificationstatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAFCWiseSeatAcceptanceGrievanceStatus()", "PersonalID" + PersonalID);
            }
        }

        public DataSet GetSeatAcceptanceGrivanceStatusByPID(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptanceGrivanceStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSeatAcceptanceGrivanceStatusByPID()", "PersonalID" + PersonalID);
            }

        }


        public bool EditConfirmedApplicationFormSelfVerification(Int64 PID, Int32 CAPRound, string NewGenderCode,
            Int32 IsGenderChanged, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsEWSChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsOrphanChanged,
            Int32 IsTFWSChanged, Int32 IsLinguisticMinorityChanged, Int32 IsReligiousMinorityChanged, Int32 IsIGDChanged,
            Int32 IsSSCMathematicsMarksChanged, Int32 IsSSCTotalMarksChanged, Int32 IsHSCPhysicsMarksChanged, Int32 IsHSCChemistryMarksChanged,
            Int32 IsHSCEnglishMarksChanged, 
            //Int32 IsHSCBiologyMarksChanged, Int32 IsHSCMathematicsMarksChanged, 
            Int32 IsHSCTotalMarksChanged, Int32 IsHSCSubjectMarksChanged, Int32 IsDiplomaMarksChanged,
            QualificationDetails obj,
            Int32 IsAllotmentCancelled, string RequestStatus, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CAPRound,  NewGenderCode,
                                        IsGenderChanged,  IsCandidatureTypeChanged,  IsCategoryChanged,  IsEWSChanged,  IsPHTypeChanged,  IsDefenceTypeChanged,  IsOrphanChanged,
                                        IsTFWSChanged,  IsLinguisticMinorityChanged,    IsReligiousMinorityChanged,  IsIGDChanged,
                                        IsSSCMathematicsMarksChanged,  IsSSCTotalMarksChanged,  IsHSCPhysicsMarksChanged,  IsHSCChemistryMarksChanged,
                                        //IsHSCBiologyMarksChanged,  IsHSCMathematicsMarksChanged, 
                                        IsHSCEnglishMarksChanged,  IsHSCTotalMarksChanged, IsHSCSubjectMarksChanged, IsDiplomaMarksChanged,
                                        obj.SSCMathMarksObtained, obj.SSCMathMarksOutOf, obj.SSCMathPercentage,
                                        obj.SSCTotalMarksObtained, obj.SSCTotalMarksOutOf, obj.SSCTotalPercentage,
                                        obj.HSCPhysicsMarksObtained, obj.HSCPhysicsMarksOutOf, obj.HSCPhysicsPercentage,
                                        obj.HSCChemistryMarksObtained, obj.HSCChemistryMarksOutOf, obj.HSCChemistryPercentage,
                                        obj.HSCMathMarksObtained, obj.HSCMathMarksOutOf, obj.HSCMathPercentage,
                                        obj.HSCBioTechnologyMarksObtained, obj.HSCBioTechnologyMarksOutOf, obj.HSCBioTechnologyPercentage,
                                        obj.HSCEnglishMarksObtained, obj.HSCEnglishMarksOutOf, obj.HSCEnglishPercentage,
                                        obj.HSCTotalMarksObtained, obj.HSCTotalMarksOutOf, obj.HSCTotalPercentage,
                                        obj.HSCSubjectMarksObtained,obj.HSCSubjectMarksOutOf,obj.HSCSubjectPercentage,
                                        obj.DiplomaTotalMarksObtained,obj.DiplomaTotalMarksOutOf,obj.DiplomaTotalPercentage,
                                        IsAllotmentCancelled,  RequestStatus,  Comments,  ModifiedBy,  ModifiedByIPAddress
                                      };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spEditConfirmedApplicationFormSelfVerification", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "EditConfirmedApplicationFormSelfVerification()", "PID : " + PID.ToString());
            }
        }


        public bool UpdateSeatAcceptanceGrievanceStaus(Int64 PID, Int32 CAPRound, string RequestStatus, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, CAPRound, RequestStatus, Comments, ModifiedBy, ModifiedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdateSeatAcceptanceGrievanceStaus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateSeatAcceptanceGrievanceStaus()", "PID : " + PID.ToString());
            }
        }

        public DataSet GetRegionWiseSeatAcceptanceGrievanceConfirmationReport()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRegionWiseSeatAcceptanceGrievanceConfirmationReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetRegionWiseSeatAcceptanceGrievanceConfirmationReport()", "");
            }
        }

        public DataSet GetAFCWiseSeatAcceptanceGrievanceConfirmationReport(Int16 RegionID)
        {
            try
            {
                object[] parameters = { RegionID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAFCWiseSeatAcceptanceGrievanceConfirmationReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAFCWiseSeatAcceptanceGrievanceConfirmationReport()", "RegionID : " + RegionID.ToString());
            }
        }

        public bool UpdateSeatAcceptanceGrievancePickedupStatus(Int64 PID, string UserLoginID, Int32 CAPRound, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, UserLoginID, CAPRound, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdateSeatAcceptanceGrievancePickedupStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateSeatAcceptanceGrievancePickedupStatus()", "PID :" + PID + " UserLoginID:" + UserLoginID);
            }
        }

        public DataSet CheckFCForSeatAcceptanceGrievance(string UserLoginID, long PersonalID, long ID, string IPAddress)
        {
            try
            {
                object[] parameters = { UserLoginID, PersonalID, ID, IPAddress };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCheckFCForSeatAcceptanceGrievance", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckFCForSeatAcceptanceGrievance()", "");
            }
        }
        public bool CategoryEWSConverttoOPEN(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spEWSConverttoOPEN", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CategoryConverttoOPEN()", "");
            }
        }
        public bool UpdateCategoryEWSConverttoOPEN(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateCVCTVCNCLEWS", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateCategoryEWSConverttoOPEN()", "");
            }
        }

        public DataSet CheckCandidateValid(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spcheckCandidateCanUploadCVCNCLEWSCertificate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckCandidateValid()", "PID: " + PID);
            }
        }
        public DataSet CheckCandidateUpladedDoc(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCheckCandidateUpladedDoc", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckCandidateValid()", "PID: " + PID);
            }
        }

        public bool CheckCandidateinAllotmentCancellationRemark(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckCandidateinAllotmentCancellationRemark", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckCandidateinAllotmentCancellationRemark()", "");
            }
        }
        public bool CancelSelfVerificationSeatAcceptanceForm(Int64 PID, string UserLoginID, string IPAddress, string Comment)
        {
            try
            {
                object[] parameters = { PID, UserLoginID, IPAddress, Comment };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCancelSelfVerificationSeatAcceptanceForm", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CancelSelfVerificationSeatAcceptanceForm()", "PID : " + PID.ToString() + "UserLoginID : " + UserLoginID);
            }
        }

        public bool ConfirmCVCNCLEWSApplication(Int64 PID, string ModifiedBy, string ModifiedByIPAddress, string CVC, string NCL, string EWS)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress, CVC, NCL, EWS };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmCVCNCLEWSApplication", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ConfirmCVCNCLEWSApplication()", "PID :" + PID + " ModifiedBy:" + ModifiedBy);
            }

        }

        public DataSet GetDocumentListForDataVerificationByStepIDCVCTVCNCLEWS(Int64 PID, Int32 ApplicationFormStepID)
        {
            try
            {
                object[] parameters = { PID, ApplicationFormStepID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentListForDataVerificationByStepIDCVCTVCNCLEWS", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListForDataVerificationByStepID()", "PID :" + PID);
            }
        }
        public DataSet GetDocumentListForDocumentVerificationByStepIDCVCTVCNCLEWS(Int64 PID, Int32 ApplicationFormStepID)
        {
            try
            {
                object[] parameters = { PID, ApplicationFormStepID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentListForDocumentVerificationByStepIDCVCTVCNCLEWS", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListForDocumentVerificationByStepID()", "PID :" + PID);
            }
        }
        public DataSet GetDiscrepancyListByStepIDCVCTVCNCLEWS(Int64 PID, int ApplicationFormStepID)
        {
            try
            {
                object[] parameters = { PID, ApplicationFormStepID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDiscrepancyListByStepIDCVCTVCNCLEWS", parameters);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDiscrepancyListByStepID()", "PID :" + PID + "ApplicationFormStepID :" + ApplicationFormStepID);
            }
        }

        public DataSet getCVCNCLEWSReciptStatistic()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCVCNCLEWSReciptStatistic");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCVCNCLEWSReciptStatistic()", "");
            }
        }

        public Int16 UnlockOptionFormCAPRound2(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                return Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUnlockOptionFormCAPRound2", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckDiscrepancyExists()", "PID :" + PID);
            }
        }
        public Int16 CheckUnlockOptionFormCAPRound2(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckUnlockOptionFormCAPRound2", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckDiscrepancyExists()", "PID :" + PID);
            }
        }

        public string GetAdmissionCategory(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetAdmissionCategory", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAdmissionCategory()", "PID " + PID);
            }
        }


        public DataSet downloadRegisterdCandidateDataWithAdmissionDetails()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spDownloadRegisterdCandidateDataWithAdmissionDetails");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "downloadRegisterdCandidateDataWithAdmissionDetails()", "");
            }
        }
        public DataSet GetDateWiseFCSlotBookingReport(int UserTypeID, string UserLoginID, string date)
        {
            try
            {
                object[] parameters = { UserTypeID, UserLoginID, date };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDateWiseFCSlotBookingReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDateWiseFCSlotBookingReport()", "UserTypeID" + UserTypeID + "UserLoginID " + UserLoginID + " date: " + date);
            }
        }
        public DataSet getFCWiseSlotBookingStausReport()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetFCWiseSlotBookingStausReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getFCWiseSlotBookingStausReport()", "");
            }
        }
        public DataSet GetDatewiseSlotsForFC(string UserLoginID)
        {
            try
            {
                object[] parameters = { UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDatewiseSlotsForFC", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDatewiseSlotsForFC()", "UserLoginID:" + UserLoginID);
            }
        }
        public bool UpdateDatewiseCapacityForFC(Int64 FCDateID, int AvilableSlots, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { FCDateID, AvilableSlots, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateDatewiseCapacityForFC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateDatewiseCapacityForFC()", "FCDateID:" + FCDateID + " ModifiedBy:" + ModifiedBy);
            }
        }
        public DataSet GetRegionwiseSlotBookingStausReport()
        {
            try
            {

                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRegionwiseSlotBookingStausReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetRegionwiseSlotBookingStausReport()", "");
            }
        }
        public DataSet GetFCWiseSlotBookingList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, AFCID, ConfirmationDate };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetFCWiseSlotBookingList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetFCWiseSlotBookingList()", "AFCID" + AFCID);
            }

        }
        public bool UpdateContactedDetailsFromFC(Int64 PersonalID, string Message, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PersonalID, Message, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdateContactedDetailsFromFC", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateContactedDetailsFromFC()", "PersonalID " + PersonalID);
            }

        }
        public DataSet GetSlotSelectedNotConfirmedList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, AFCID, ConfirmationDate };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSlotSelectedNotConfirmedList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSlotSelectedNotConfirmedList()", "AFCID" + AFCID);
            }
        }
        public bool CheckIsSlotBooked(Int64 PersonalID)
        {
            try
            {
                object[] parameters = { PersonalID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetBookedSlotsDetails", parameters));
                if (result > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckIsSlotBooked()", "PersonalID " + PersonalID);
            }

        }
        public bool isApplicationFormConfirmedUsingThisEMailID(string EmailID, Int64 PID)
        {
            try
            {
                object[] parameters = { EmailID, PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsApplicationFormConfirmedUsingThisEMailID", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isApplicationFormConfirmedUsingThisEMailID()", "");
            }
        }

        public DataSet getNEETResult(string NEETRollNo, string NEETDOB)
        {
            try
            {
                object[] parameters = { NEETRollNo,  NEETDOB };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetNEETResult", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getNEETResult()", "");
            }
        }
        public DataSet getFeeDetailsForSupport(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };

                return SqlHelper.ExecuteDataset(connectionString, "SPGetFeeDetailsSupport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getFeeDetailsForSupport()", "");
            }
        }
        public DataSet GetApplicationFormAcknowledgeFormMaxVersionNo(Int64 PID, string VersionNoFlag)
        {
            try
            {
                object[] parameters = { PID, VersionNoFlag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetVersionNoMAXForSupport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListByUploadedFlag()", "PID :" + PID);
            }
        }
        public DataSet getStepIDforSupport(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationFormLinksStatusForSupport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getVerificationFlags()", "PID :" + PID);
            }
        }
        public DataSet GetDocStatusForSupport(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocStatusForSupport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getVerificationFlags()", "PID :" + PID);
            }
        }
        public bool GetPreferancedOptionsListOnlyTFWSSelect(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPreferancedOptionsListOnlyTFWSForDisplayCAPRound1", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetPreferancedOptionsListOnlyTFWSSelect()", " ");
            }
        }
        public string getBenefitTakenByCandidate(Int64 PID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { PID, CAPRound };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spBenefitTakenByCandidate", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getBenefitTakenByCandidate()", "");
            }
        }
        public DataSet GetNEETConfiredCandidateList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                object[] parameters = { RegionID, InstituteID, AFCID, ConfirmationDate };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetNEETConfiredCandidateList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetNEETConfiredCandidateList()", "");
            }
        }
        public bool GetPreferancedOptionsListOnlyTFWSSelectCap2(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPreferancedOptionsListOnlyTFWSForDisplayCAPRound2", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetPreferancedOptionsListOnlyTFWSSelectCap2()", " ");
            }
        }
        public bool isContinueWithReceiptCandidateExist(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetContinueWithReceiptCandidate", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex,
                    ExceptionMessages.GetExceptionMessage(Ex, messageID), "isContinueWithReceiptCandidateExist()", "");
            }
        }

        #region ARA_Module
        // FUNCTION FOR ARA MODULE
        public Int32 getAdmissionApprovalFeePaidAmount(Int64 InstituteID)
        {
            try
            {
                object[] parameters = { InstituteID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetAdmissionApprovalFeePaidAmount", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdmissionApprovalFeePaidAmount()", "");
            }
        }

        public DataSet getAdmissionApprovalFeeDetails(Int64 InstituteID, string FeeType, string FeeLockStatus)
        {
            try
            {
                object[] parameters = { InstituteID, FeeType, FeeLockStatus };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdmissionApprovalFeeDetails", parameters);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdmissionApprovalFeeDetails()", "");
            }

        }

        public bool saveAdmissionApprovalFeeDetails(Int64 InstituteID, AdmissionApprovalFeeDetails obj, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { InstituteID, obj.FeeID, obj.FeeType, obj.PaymentMode, obj.DDAmount, obj.DDNumber, obj.DDDate, obj.BankID, obj.OtherBankName, obj.BranchName, CreatedBy, CreatedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveAdmissionApprovalFeeDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveAdmissionApprovalFeeDetails()", "");
            }
        }

        public Int32 getAdmissionApprovalFeeToBePaid(Int32 FeeGroupID, Int32 PhaseID, Int32 UserTypeID, Int64 PayeeID)
        {
            try
            {
                object[] parameters = { FeeGroupID, PhaseID, UserTypeID, PayeeID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetAdmissionApprovalFeeToBePaid", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdmissionApprovalFeeToBePaid()", "");
            }
        }
        public DataSet getAdmissionApprovalFeeDetailsTable(Int32 FeeGroupID, Int32 PhaseID, Int32 UserTypeID, Int64 InstituteID)
        {
            try
            {
                object[] parameters = { FeeGroupID, PhaseID, UserTypeID, InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdmissionApprovalFeeDetailsTable", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdmissionApprovalFeeDetailsTable()", "");
            }
        }

        public DataSet getARADashBoardForARAAdmin(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARADashBoardForARAAdmin", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARADashBoardForARAAdmin()", "");
            }
        }
        public DataSet getARADashBoardForRO(string RO, string Flag)
        {
            try
            {
                object[] parameters = { RO, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARADashBoardForRO", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARADashBoardForRO()", "");
            }
        }
        public DataSet getARADashBoardForInstitute(string InstituteCode, string Flag)
        {
            try
            {
                object[] parameters = { InstituteCode, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARADashBoardForInstitute", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getARADashBoardForInstitute()", "");
            }
        }

        public DataSet getROwiseAdmissionApprovalFeePaidDetails(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetROwiseAdmissionApprovalFeePaidDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getROwiseAdmissionApprovalFeePaidDetails()", "");
            }
        }

        public DataSet getInstitutewiseAdmissionApprovalFeePaidDetails(string ROName, string Flag)
        {
            try
            {
                object[] parameters = { ROName, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstitutewiseAdmissionApprovalFeePaidDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstitutewiseAdmissionApprovalFeePaidDetails()", "");
            }

        }

        public DataSet GetAdmittedCandidateListToROVerification(string ChoiceCode)
        {
            try
            {
                object[] parameters = { ChoiceCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdmittedCandidateListToROVerification", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAdmittedCandidateListToROVerification()", "");
            }
        }
        public DataSet GetAdmittedCandidateListToAraVerification(string ChoiceCode)
        {
            try
            {
                object[] parameters = { ChoiceCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdmittedCandidateListToAraVerification", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAdmittedCandidateListToAraVerification()", "");
            }
        }
        public DataSet GetAdmittedCandidateListToInstituteVerification(string ChoiceCode)
        {
            try
            {
                object[] parameters = { ChoiceCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdmittedCandidateListToInstituteVerification", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAdmittedCandidateListToInstituteVerification()", "");
            }
        }
        public DataSet GetDocumentListForInstituteToRo(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDocumentListForInstituteToRo", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDocumentListForInstituteToRo()", "");
            }
        }
        public bool UpdateDocumentSubmissionForInstituteToRo(Int64 PID, string XMLString, string ModifiedBy, string ModifiedByIPAddress, string InstituteByRemar)
        {
            try
            {
                object[] parameters = { PID, XMLString, ModifiedBy, ModifiedByIPAddress, InstituteByRemar };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateDocumentSubmissionForInstituteToRo", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateDocumentSubmissionForInstituteToRo()", "");
            }
        }

        //END OF FUNCTION FOR ARA MODULE
        #endregion
        public DataSet getLoginData(string LoginID, string BrowserName, string BrowserVersion, string IPAddress)
        {
            try
            {
                //var param = new Dictionary<string, object>();
                //param.Add("@LoginID", LoginID);
                //param.Add("@BrowserName", BrowserName);
                //param.Add("@BrowserVersion ", BrowserVersion);
                //param.Add("@IPAddress", IPAddress);
                object[] parameters = { LoginID, BrowserName, BrowserVersion, IPAddress };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetLoginData", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterSportsBody()", "");
            }
        }
        public DataSet getAllotedInstitutesForSO(string SOCode, int GrdNo)
        {
            try
            {
                object[] parameters = { SOCode, GrdNo };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotedInstitutesForSO", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentReportForInstitute()", "");
            }
        }
        public DataSet getCandidateListforMV(Int64 InstCode, string Flag)
        {
            try
            {
                object[] parameters = { InstCode, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCandidateListforMV", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidateListforMV()", "");
            }
        }
        public string addMVSO(string ScrutinyOfficerName, string ScrutinyOfficerMobileNo, string ScrutinyOfficerEmailID, string ScrutinyOfficerDesignation, string Password, string CreatedBy, string CreatedByIPAddress, int RegionID, string Password2)
        {


            try
            {
                object[] parameters = { ScrutinyOfficerName, ScrutinyOfficerMobileNo, ScrutinyOfficerDesignation, ScrutinyOfficerEmailID, Password, CreatedBy, CreatedByIPAddress, RegionID, Password2 };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAddMVSO", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "addMVSO()", "");
            }
        }
        public DataSet getMVSOList(Int64 RegionID)
        {
            try
            {
                object[] parameters = { RegionID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMVSCOByREGIONID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMVSOList()", "");
            }
        }
        public DataSet getInstituteList(Int64 RegionID)
        {
            try
            {
                object[] parameters = { RegionID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstituteByREGIONID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteList()", "");
            }
        }
        public bool updateMVSO(Int64 SOID, string ScrutinyOfficerName, string ScrutinyOfficerMobileNo, string ScrutinyOfficerEmailId, string ScrutinyOfficerDesignation, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { SOID, ScrutinyOfficerName, ScrutinyOfficerMobileNo, ScrutinyOfficerEmailId, ScrutinyOfficerDesignation, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spUpdateMVSO", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateMVSO()", "");
            }
        }
        public bool deleteMVSO(Int64 SOID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { SOID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spDeleteMVSO", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "deleteSubAFC()", "");
            }
        }
        public DataSet getInstitutelistSOMappingForRO(string RO, Char Flag)
        {
            try
            {
                object[] parameters = { RO, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetInstListForSOMAPPINGforRO", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstitutelistSOMappingForRO()", "");
            }
        }
        public DataSet SaveInstituteMappingforSO(Int64 SOID, Int64 instituteID, string CreatedBy, string CreatedByIPAddress, Int64 ChoiceCode, Int64 ChoiceTFWS)
        {
            try
            {
                object[] parameters = { SOID, instituteID, CreatedBy, CreatedByIPAddress, ChoiceCode, ChoiceTFWS };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_SPSAVEInstituteMappingSO", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getLoginDetails()", "");
            }
        }
        public DataSet UpdateInstituteMappingforSO(Int64 SOID, Int64 instituteID, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { SOID, instituteID, CreatedBy, CreatedByIPAddress };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_SPUpdateInstituteMappingSO", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateInstituteMappingforSO()", "");
            }
        }
        public DataSet getMasterMVDiscrepancy()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterMVDiscrepancy");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterMVDiscrepancy()", "");
            }
        }
        public bool saveMVDiscrepancy(MeritListVerificaton obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { obj.PID, obj.Recommend, obj.DiscID, obj.DiscRmk, obj.SubDiscID, obj.SubDisc, ModifiedBy, ModifiedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveMVDiscrepancy", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateRegistrationDetails()", "");
            }
        }
        public bool saveInstituteVarificationStatus(Int64 InstCode, char Verified, string CreatedBy, string CreatedIPAddress, char Flg, string ChoiceCode)
        {
            try
            {
                object[] parameters = { InstCode, Verified, CreatedBy, CreatedIPAddress, Flg, ChoiceCode };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveInstituteVarificationStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveInstituteVarificationStatus()", "");
            }
        }
        public bool saveInstituteVarificationARA(Int64 InstCode, char Verified, string CreatedBy, string CreatedIPAddress, DateTime ApprovalDate)
        {
            try
            {
                object[] parameters = { InstCode, Verified, CreatedBy, CreatedIPAddress, ApprovalDate };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveInstituteVarificationARA", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveInstituteVarificationARA()", "");
            }
        }
        public bool saveInstituteVarifyRODTE(Int64 InstCode, char Verified, string CreatedBy, string CreatedIPAddress, char Flg, string Remarks)
        {
            try
            {
                object[] parameters = { InstCode, Verified, CreatedBy, CreatedIPAddress, Flg, Remarks };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveInstituteVarifyRODTE", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveInstituteVarifyRODTE()", "");
            }
        }
        public DataSet getMVSOProfile(Int64 SOID)
        {
            try
            {
                object[] parameters = { SOID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMVSOProfile", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMVSOProfile()", "");
            }
        }
        public DataSet getVerifiedBySO(Int64 SOID)
        {
            try
            {
                object[] parameters = { SOID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetVerifiedBySO", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentReportForSO()", "");
            }
        }
        public DataSet getCandidateVerifiedBySO(Int64 SOID, string InstCode)
        {
            try
            {
                object[] parameters = { SOID, InstCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetChoiceCodeVerifiedBySO", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentReportForSO()", "");
            }
        }
        public DataSet getRODashboardForMV(string RO, char Flag)
        {
            try
            {
                object[] parameters = { RO, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetRODashboardForMV", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRODashboardForMV()", "");
            }
        }
        public DataSet getMVVerifyStatus(int SOID)
        {
            try
            {
                object[] parameters = { SOID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMVVerifyStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMVVerifyStatus()", "");
            }
        }
        public DataSet getVerifiedByInst(Int64 InstCode, Char Flag)
        {
            try
            {
                object[] parameters = { InstCode, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetVerifiedByInst", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentReportForSO()", "");
            }
        }
        public DataSet getMVSOLoad(Int64 SOID)
        {
            try
            {
                object[] parameters = { SOID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMVSOLoad", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMVSOLoad()", "");
            }
        }
        public DataSet getMLVCertificate(Int64 InstCode)
        {
            try
            {
                object[] parameters = { InstCode };
                return SqlHelper.ExecuteDataset(connectionString, "SPMLVCertificate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMVSOLoad()", "");
            }
        }
        public bool updateCandidateSrNo(Int64 SRNO, Int64 PID)
        {
            try
            {
                object[] parameters = { SRNO, PID };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateCandidateSrNo", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateCandidateSrNo()", "");
            }
        }
        public DataSet getDTEDashboardForMV(char Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDTEDashboardForMV", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDTEDashboardForMV()", "");
            }
        }
        public DataSet getSOStats(string SOCode)
        {
            try
            {
                object[] parameters = { SOCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSOStats", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getLoginDetails()", "");
            }
        }
        public string getCertificateRemarks(string InstituteCode, char Flg)
        {
            try
            {
                object[] parameters = { InstituteCode, Flg };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetCertificateRemarks", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getInstituteName()", "");
            }
        }
        public DataSet getAllotmentReportForSO(string ChoiceCode, string Flg)
        {
            try
            {
                object[] parameters = { ChoiceCode, Flg };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAllotmentReportForSO", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAllotmentReportForSO()", "");
            }
        }

        public bool updateMVSO(long SOID, string ScrutinyOfficerName, string ScrutinyOfficerMobileNo, string ScrutinyOfficerEmailId, string ScrutinyOfficerDesignation, string ModifiedBy, string ModifiedByIPAddress, string Password2)
        {
            throw new NotImplementedException();
        }

        public DataSet getCompositeReportForInstitute_ARAFeeReceipt(string InstituteCode, string Flag)
        {
            try
            {
                object[] parameters = { InstituteCode, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetCompositeReportForInstitute_ARAFeeReceipt", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCompositeReportForInstitute_ARAFeeReceipt()", "");
            }
        }
        public bool saveProposalStatus(string InstCD, string Submitted, string CreatedBy, string CreatedByIPAddress, DateTime ProposalDate)
        {
            try
            {
                object[] parameters = { InstCD, Submitted, CreatedBy, CreatedByIPAddress, ProposalDate };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spSaveProposalStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveProposalStatus()", "");
            }
        }
        public DataSet getARADashboardForMV(Char Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARADashboardForMV", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getDTEDashboardForMV()", "");
            }
        }
        public DataSet getMasterUserType()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterUserType");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterUserType()", "");
            }
        }
        public DataSet getMasterUserForReconciliation()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterUserForReconciliation");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterUserForReconciliation()", "");
            }
        }
        public bool addMasterUser(string UserName, string LoginId, string UserPassword, string EncryptedPassword, Int64 UserTypeId, string UserMobNo, string UserEmailId, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                object[] parameters = { UserName, LoginId, UserPassword, EncryptedPassword, UserTypeId, UserMobNo, UserEmailId, CreatedBy, CreatedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAddMasterUser", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getGetSMSEmailTemplates()", "");
            }
        }
        public bool chkDuplicateMasterUserName(string LoginId)
        {
            try
            {
                object[] parameters = { LoginId };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spchkDuplicateMasterUserName", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "chkDuplicateMasterUserName()", "");
            }
        }
        public DataSet CandidateApprovalReport(Int64 InstCode, string Flag)
        {
            try
            {
                object[] parameters = { InstCode, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCandidateApprovalReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CandidateApprovalReport()", "");
            }
        }
        public DataSet ARADashboardReport(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "SPARADASHBOARDREPORT", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ARADashboardReport()", "");
            }
        }
        public DataSet ProposalSubmittedInstitutes(string Region)
        {
            try
            {
                object[] parameters = { Region };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_getProposalSubmittedInstitutes",parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ProposalSubmittedInstitutes()", "");
            }
        }
        public DataSet ARAReportforMV(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spARAReportforMV", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ARAReportforMV()", "");
            }
        }
        public DataSet ARAInstituteList(string Region)
        {
            try
            {
                object[] parameters = { Region };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spARAInstituteList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ARAInstituteList()", "");
            }
        }
        public DataSet ARAFeesPaidInstitutes(string Region)
        {
            try
            {
                object[] parameters = { Region };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARAFeesPaidInstitutes", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ARAFeesPaidInstitutes()", "");
            }
        }
        public DataSet ARAInstituteListConfirmedbyROAndDTE(string Region, string Flag)
        {
            try
            {
                object[] parameters = { Region, Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spARAInstituteListConfirmedbyROAndDTE", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ARAInstituteListConfirmedbyROAndDTE()", "");
            }
        }
        public DataSet ARAVerificationDate(Int64 InstCode)
        {
            try
            {
                object[] parameters = { InstCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARAVerificationDate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ARAVerificationDate()", "");
            }
        }
        public string isApplicationFormRegisteredUsingThisMobileNo(string MobileNo, Int64 PID)
        {
            try
            {
                object[] parameters = { MobileNo, PID };
                string result = SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsApplicationFormRegisteredUsingThisMobileNo", parameters).ToString();
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "isApplicationFormRegisteredUsingThisMobileNo()", "");
            }
        }
        public DataSet getVerifyOTPVerificationAttemptsDetails(string ApplicationID, string ModifiedByIPAddress, int OTPType, string Template)
        {
            try
            {
                object[] parameters = { ApplicationID, ModifiedByIPAddress, OTPType, Template };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spVerifyOTPVerificationAttempts", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getVerifyOTPVerificationAttemptsDetails()", "");
            }
        }
        public bool CheckOldCandidatePassword(string LoginID, string OLDCandidatePassword)
        {
            try
            {
                object[] parameters = { LoginID, OLDCandidatePassword };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "CheckUser_OldPassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckOldCandidatePassword()", "");
            }
        }
        public bool IsApplicationFormRegisteredUsingThisHSCSeatNo(Int64 PID, Int16 StepID, string HSCPassingYear, string HSCSeatNo, Int16 HSCBoardID)
        {
            try
            {
                object[] parameters = { PID, StepID, HSCPassingYear, HSCSeatNo, HSCBoardID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsApplicationFormRegisteredUsingThisHSCSeatNo", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "IsApplicationFormRegisteredUsingThisHSCSeatNo()", "");
            }
        }
        public DataSet getHSCSeatNo(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetHSCSeatNo", parameters);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getHSCSeatNo()", "");
            }
        }
        public DataSet GetApplicationIDIsFormRegisteredUsingHSCSeatNo(Int64 PID, string HSCPassingYear, string HSCSeatNo, Int16 HSCBoardID)
        {
            try
            {
                object[] parameters = { PID, HSCPassingYear, HSCSeatNo, HSCBoardID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationIDIsFormRegisteredUsingHSCSeatNo", parameters);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetApplicationIDIsFormRegisteredUsingHSCSeatNo()", "");
            }
        }
        public DataSet IsApplicationFormRegisteredUsingThisNEETRollNo(Int64 PID, string NEETRollNo, Int16 StepID)
        {
            try
            {
                object[] parameters = { PID, NEETRollNo, StepID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spIsApplicationFormRegisteredUsingThisNEETRollNo", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "IsApplicationFormRegisteredUsingThisNEETRollNo()", "");
            }
        }
        public DataSet ISApplicationFormRegisteredUsingThisCETApplicationNo(Int64 CETApplicationFormNo, Int16 StepID, Int64 PID)
        {
            try
            {
                object[] parameters = { CETApplicationFormNo, StepID, PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spIsApplicationFormRegistaredUsingThisCETApplicationNo", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ISApplicationFormRegisteredUsingThisCETApplicationNo()", "");
            }
        }

        public bool IsApplicationFormConfirmedUsingThisHSCSeatNo(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsApplicationFormConfirmedUsingThisHSCSeatNo", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "IsApplicationFormConfirmedUsingThisHSCSeatNo()", "");
            }
        }
        public DataSet GetApplicationIDIsFormConfirmedUsingHSCSeatNo(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetApplicationIDIsFormConfirmedUsingHSCSeatNo", parameters);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetApplicationIDIsFormConfirmedUsingHSCSeatNo()", "");
            }
        }
        public bool IsEditApplicationFormConfirmedUsingThisHSCSeatNo(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsEditApplicationFormConfirmedUsingThisHSCSeatNo", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "IsEditApplicationFormConfirmedUsingThisHSCSeatNo()", "");
            }
        }
        public DataSet IsApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp(Int64 PID, Int16 CandidatureTypeID)
        {
            try
            {
                object[] parameters = { PID, CandidatureTypeID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spIsApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "IsApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp()", "");
            }
        }
        public DataSet EditApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp(Int64 PID, Int16 CandidatureTypeID)
        {
            try
            {
                object[] parameters = { PID, CandidatureTypeID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spEditApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureType", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "EditApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp()", "");
            }
        }
        public DataSet GetAdmissionCategoryforReceipt(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdmissionCategoryforReceipt", parameters);

            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetAdmissionCategoryforReceipt()", "");
            }
        }
        public bool isCandidateNameAppearedInProvisionalMeritList(string ApplicationID)
        {
            try
            {
                object[] parameters = { ApplicationID };
                Int32 QueryResult;
                QueryResult = (Int32)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spIsCandidateNameAppearedInProvisional", parameters);
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex,
                    ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateNameAppearedInFinalMeritList()", "");
            }
        }
        public bool CheckCandidateCVCTVCEWSStatus(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckCandidateCVCTVCEWSStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckCandidateCVCTVCEWSStatus()", "");
            }
        }
        public bool ConfirmFCCVCNCLEWSApplication(Int64 PID, string ModifiedBy, string ModifiedByIPAddress, string CVC, string NCL, string EWS)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress, CVC, NCL, EWS };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spConfirmFCCVCNCLEWSApplication", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ConfirmFCCVCNCLEWSApplication()", "PID :" + PID + " ModifiedBy:" + ModifiedBy);
            }

        }
        public bool checkApplicationFormModifiedDetailsForCVCTVCEWS(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {

            try
            {
                object[] parameters = { PID, UserTypeID, UserLoginID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spcheckApplicationFormModifiedDetailsForCVCTVCEWS", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "checkApplicationFormModifiedDetailsForCVCTVCEWS()", "");
            }
        }
        public bool GetPreferancedOptionsListOnlyTFWSSelectCap3(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetPreferancedOptionsListOnlyTFWSForDisplayCAPRound3", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetPreferancedOptionsListOnlyTFWSSelectCap3()", " ");
            }
        }
        public bool OnlyThisCandidateOperation(string ApplicationID)
        {
            try
            {
                object[] parameters = { ApplicationID };
                Int32 QueryResult;
                QueryResult = (Int32)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spOnlyThisCandidateOperation", parameters);
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex,
                    ExceptionMessages.GetExceptionMessage(Ex, messageID), "isCandidateNameAppearedInFinalMeritList()", "");
            }
        }
        public bool CheckISOTPverifyed(Int64 PID, int OTPType)
        {
            try
            {
                object[] parameters = {  PID, OTPType };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckISOTPverifyed", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckISOTPverifyed()", "");
            }
        }
        public bool AuthenticateCandidateisActive(string ApplicationID)
        {
            try
            {
                object[] parameters = { ApplicationID };
                Int32 QueryResult;
                QueryResult = (Int32)SqlHelper.ExecuteScalar(connectionString, "MHDTE_spAuthenticateCandidateisActive", parameters);
                if (QueryResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex,
                    ExceptionMessages.GetExceptionMessage(Ex, messageID), "AuthenticateCandidateisActive()", "");
            }
        }
        public bool CheckIsVerifiedUseResetPassword(Int64 PID, int OTPType)
        {
            try
            {
                object[] parameters = { PID, OTPType };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spCheckIsVerifiedUseResetPassword", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckIsVerifiedUseResetPassword()", "");
            }
        }
        public DataSet getARAProcessFeeCandidateCount(Int32 FeeGroupID, Int32 PhaseID, Int32 UserTypeID, Int64 InstituteID)
        {
            try
            {
                object[] parameters = { FeeGroupID, PhaseID, UserTypeID, InstituteID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetARAProcessFeeCandidateCount", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdmissionApprovalFeeDetailsTable()", "");
            }
        }
        public string getCandidateDOB(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetCandidateDOB", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getCandidateDOB()", "");
            }
        }
        public bool GetFCRApplicationID(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetFCRApplicationID", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetFCRApplicationID()", "");
            }
        }

        public bool UpdateFCRDetails(Int64 PID, string FCRApplicationID, string FCRCandidateName, string FCRCandidatureTypeName, string FCRMotherName, string FCRGender, DateTime FCRDOB)
        {
            try
            {
                object[] parameters = { PID, FCRApplicationID, FCRCandidateName, FCRCandidatureTypeName, FCRMotherName, FCRGender, FCRDOB };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateFCRApplicationID", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateRegistrationDetails()", "");
            }
        }
        public string GetTemplateNameUsedInEmailWhatsapp(string TemplateName, char Flag)
        {
            try
            {
                object[] parameters = { TemplateName, Flag };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetTemplateNameUsedInEmailWhatsapp", parameters));
                return result;
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetTemplateNameUsedInEmailWhatsapp()", "");
            }
        }
        public bool ChangeFCVerificationMode(Int64 PID, string Flag, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, Flag, ModifiedBy, ModifiedByIPAddress };

                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spChangeFCVerificationMode", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateRegistrationDetails()", "");
            }
        }

        #region  #region Star Messages Changes
        public DataSet getAdminStarRepliedMessages(string Flag)
        {
            try
            {
                object[] parameters = { Flag };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdminStarRepliedMessages", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdminStarRepliedMessages()", "");
            }
        }
        public DataSet getStarMessagesList(string From)
        {
            try
            {
                object[] parameters = { From };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetStarMessagesList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getStarMessagesList()", "");
            }
        }
        public DataSet getReplyStarMessageByMessageID(Int64 MessageID)
        {
            try
            {
                object[] parameters = { MessageID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetReplyStarMessageByMessageID", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getReplyStarMessageByMessageID()", "");
            }
        }
        public bool updateStarMessageStatus(Int64 MessageID)
        {
            try
            {
                object[] parameters = { MessageID };
                string result = Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateStarMessageStatus", parameters));
                if (result == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "updateStarMessageStatus()", "");
            }
        }
        public DataSet getAdmictionCancellationandAdmitedDetails(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetAdmictionCancellationandAdmitedDetails", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getAdmictionCancellationandAdmitedDetails()", "");
            }
        }
        public DataSet GetNotRecommendedList(string Flag, string Region)
        {
            try
            {
                object[] parameters = { Flag, Region };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetNotRecommendedList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetNotRecommendedList()", "");
            }
        }
        #endregion

        #region Ticketing System
        public DataSet getMasterGrievanceCategory(Int32 UserTypeID)
        {
            try
            {
                object[] param = { UserTypeID };
                return SqlHelper.ExecuteDataset(connectionString, "GRS_GetMasterGrievanceCategory", param);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMasterGrievanceCategory()", "");
            }
        }
        public DataSet GetGrievanceDashboard(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                object[] param = { UserTypeID, UserLoginID };
                return SqlHelper.ExecuteDataset(connectionString, "GRS_GetGrievanceDashboard", param);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetGrievanceDashboard()", "");
            }
        }
        public Int64 SendGrievance(string ApplicationID, Int16 GrievanceCategoryID, string OtherGrievanceCategory, string Grievance, string GrievanceFileURL, string UserLoginID, string IPAddress)
        {
            try
            {
                object[] parameters = { ApplicationID, GrievanceCategoryID, OtherGrievanceCategory, Grievance, GrievanceFileURL, UserLoginID, IPAddress };
                return Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "GRS_SendGrievance", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "SendGrievance()", "");
            }
        }
        public DataSet CheckGrievanceStatus(string UserLoginID, string Search)
        {
            try
            {
                object[] param = { UserLoginID, Search };
                return SqlHelper.ExecuteDataset(connectionString, "GRS_CheckGrievanceStatus", param);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckGrievanceStatus()", "");
            }
        }
        public DataSet GetGrievanceList(Int64 GrievanceID)
        {
            try
            {
                object[] param = { GrievanceID };
                return SqlHelper.ExecuteDataset(connectionString, "GRS_GetGrievanceList", param);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetGrievanceList()", "");
            }
        }
        public DataSet GetGrievanceListByStatus(Int32 UserTypeID, string UserLoginID, string GrievanceStatus, string Search, Int16 GrievanceCategoryID)
        {
            try
            {
                object[] param = { UserTypeID, UserLoginID, GrievanceStatus, Search, GrievanceCategoryID };
                return SqlHelper.ExecuteDataset(connectionString, "GRS_GetGrievanceListByStatus", param);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetGrievanceListByStatus()", "");
            }
        }
        public string OpenGrievance(Int64 GrievanceID, Int32 UserTypeID, string UserLoginID, string IPAddress)
        {
            try
            {
                object[] parameters = { GrievanceID, UserTypeID, UserLoginID, IPAddress };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "GRS_OpenGrievance", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "OpenGrievance()", "");
            }
        }
        public Int64 GetFinalGrievanceID(Int64 GrievanceID, string Flag)
        {
            try
            {
                object[] parameters = { GrievanceID, Flag };
                return Convert.ToInt64(SqlHelper.ExecuteScalar(connectionString, "GRS_GetFinalGrievanceID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetFinalGrievanceID()", "");
            }
        }
        public DataSet GetGrievanceDetails(Int64 GrievanceID)
        {
            try
            {
                object[] param = { GrievanceID };
                return SqlHelper.ExecuteDataset(connectionString, "GRS_GetGrievanceDetails", param);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetGrievanceDetails()", "");
            }
        }
        public string ForwardGrievance(Int64 GrievanceID, Int16 AssignedTo, string UserLoginID, string IPAddress)
        {
            try
            {
                object[] parameters = { GrievanceID, AssignedTo, UserLoginID, IPAddress };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "GRS_ForwardGrievance", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ForwardGrievance()", "");
            }
        }
        public string ReplyGrievance(Int64 GrievanceID, string RepliedGrievance, string RepliedGrievanceFileURL, string UserLoginID, string IPAddress)
        {
            try
            {
                object[] parameters = { GrievanceID, RepliedGrievance, RepliedGrievanceFileURL, UserLoginID, IPAddress };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "GRS_ReplyGrievance", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ReplyGrievance()", "");
            }
        }
        public string ReOpenGrievance(Int64 GrievanceID, string Grievance, string GrievanceFileURL, string UserLoginID, string IPAddress)
        {
            try
            {
                object[] parameters = { GrievanceID, Grievance, GrievanceFileURL, UserLoginID, IPAddress };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "GRS_ReOpenGrievance", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "ReOpenGrievance()", "");
            }
        }

        #endregion
        public DataSet GetDirectorReport()
        {
            try
            {
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetDirectorReport");
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetDirectorReport()", "");
            }
        }
        public bool saveCETDetails(Int64 PersonalID, Int64 CETApplicationFormNo, string CreatedBy, string CreatedByIpAddress)
        {
            try
            {
                object[] parameters = { PersonalID, CETApplicationFormNo, CreatedBy, CreatedByIpAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(connectionString, "MHDTE_spSaveCETDetails", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "saveCETDetails()", "PersonalID :" + PersonalID);
            }
        }
        public bool UploadCorrectDocumentafterReporting(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUploadCorrectDocumentafterReporting", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UploadCorrectDocumentafterReporting()", "PID :" + PID + " ModifiedBy:" + ModifiedBy);
            }

        }
        public bool GetSeatAcceptanceStatusforBettermentcandidate(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetSeatAcceptanceStatusforBettermentcandidate", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSeatAcceptanceStatusforBettermentcandidate()", "");
            }

        }
        public bool UpdateSeatAcceptanceStatusforBettermentcandidate(Int64 PID, string SeatAcceptanceStatus, Int32 CAPRound, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                object[] parameters = { PID, SeatAcceptanceStatus, CAPRound, ModifiedBy, ModifiedByIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spUpdateSeatAcceptanceStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "UpdateSeatAcceptanceStatusforBettermentcandidate()", "");
            }

        }
        public DataSet getSeatAcceptanceStatusDetailsForBettermentCandidate(Int64 PID)
        {

            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetSeatAcceptanceStatusDetailsForBettermentCandidate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getSeatAcceptanceStatusDetails()", "");
            }
        }
        public bool GetSeatAcceptanceCAPRoundWise(Int64 PID, Int32 CAPRound)
        {
            try
            {
                object[] parameters = { PID, CAPRound };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetSeatAcceptanceCAPRoundWise", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GetSeatAcceptanceCAPRoundWise()", "");
            }

        }
        public bool GETBlockCandidateList(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGETBlockCandidateList", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "GETBlockCandidateList()", "");
            }

        }
        public DataSet getMVSubDiscrepancy(Int32 DID)
        {
            try
            {
                object[] parameters = { DID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetMasterMVSubDiscrepancy", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getMVSubDiscrepancy()", "");
            }
        }
        public DataSet getNotRecommendedForApprovalCandidate(Int64 InstCode)
        {
            try
            {
                object[] parameters = { InstCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetNotRecommendedForApprovalCandidate", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getNotRecommendedForApprovalCandidate()", "");
            }
        }
        public DataSet getNotRecommendedAndRecommendedForApprovalCandidateList(Int64 PID)
        {
            try
            {
                object[] parameters = { PID };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spGetNotRecommendedAndRecommendedForApprovalCandidateList", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getNotRecommendedAndRecommendedForApprovalCandidateList()", "");
            }
        }
        public bool SaveARAPenaltyStatus(Int32 InstCD, string Penalty, string CreatedBy, string CreatedIPAddress)
        {
            try
            {
                object[] parameters = { InstCD, Penalty, CreatedBy, CreatedIPAddress };
                Int32 result = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, "MHARA_spSaveARAPenaltyStatus", parameters));
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "SaveARAPenaltyStatus()", "");
            }

        }
        public DataSet CheckARAPenaltyStatus(Int32 InstCode)
        {
            try
            {
                object[] parameters = { InstCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHARA_spCheckARAPenaltyStatus", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CheckARAPenaltyStatus()", "");
            }
        }
        public DataSet CandidateApprovalReport(Int64 InstCode)
        {
            try
            {
                object[] parameters = { InstCode };
                return SqlHelper.ExecuteDataset(connectionString, "MHDTE_spCandidateApprovalReport", parameters);
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "CandidateApprovalReport()", "");
            }
        }
        public Int16 getRORegionID(string RName)
        {
            try
            {
                object[] parameters = { RName };
                return Convert.ToInt16(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetRORegionID", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getRORegionID()", "");
            }
        }
        public string getChoiceCodeDisplayByChoiceCode(Int64 ChoiceCode)
        {
            try
            {
                object[] parameters = { ChoiceCode };
                return Convert.ToString(SqlHelper.ExecuteScalar(connectionString, "MHDTE_spGetChoiceCodeDisplayByChoiceCode", parameters));
            }
            catch (SqlException Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, ExceptionMessages.GetExceptionMessage(Ex, messageID), "getChoiceCodeDisplayByChoiceCode()", "");
            }
        }
    }
}
