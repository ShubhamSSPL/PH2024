using DataAccess.Implementation;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using forProjectCustomExceptions;
using DataAccess;

namespace BusinessLayer
{
    public class BusinessServiceImp : IBusinessService
    {
        private IDataAcesslayer dataAccessLayerDao = new DataAccessLayerImp();

        public List<Gender> GetGender()
        {
            try
            {
                return BalCommon.ReadTable<Gender>(dataAccessLayerDao.getMasterGender());
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetGender()", "");
            }
        }

        public DataSet getMasterSecurityQuestion()
        {
            try
            {
                return dataAccessLayerDao.getMasterSecurityQuestion();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterSecurityQuestion()", "");
            }
        }
        public DataSet getMasterGender()
        {
            try
            {
                return dataAccessLayerDao.getMasterGender();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterGender()", "");
            }
        }
        public DataSet getMasterReligion()
        {
            try
            {
                return dataAccessLayerDao.getMasterReligion();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterReligion()", "");
            }
        }
        public DataSet getMasterRegionType()
        {
            try
            {
                return dataAccessLayerDao.getMasterRegionType();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterRegionType()", "");
            }
        }
        public DataSet getMasterMotherTongue()
        {
            try
            {
                return dataAccessLayerDao.getMasterMotherTongue();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterMotherTongue()", "");
            }
        }
        public DataSet getMasterAnnualFamilyIncome()
        {
            try
            {
                return dataAccessLayerDao.getMasterAnnualFamilyIncome();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterAnnualFamilyIncome()", "");
            }
        }
        public DataSet getMasterNationality()
        {
            try
            {
                return dataAccessLayerDao.getMasterNationality();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterNationality()", "");
            }
        }
        public DataSet getMasterState()
        {
            try
            {
                return dataAccessLayerDao.getMasterState();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterState()", "");
            }
        }
        public DataSet getMasterDistrictForState(Int32 StateID)
        {
            try
            {
                return dataAccessLayerDao.getMasterDistrictForState(StateID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterDistrictForState()", "");
            }
        }
        public DataSet getMasterTalukaForDistrict(Int32 DistrictID)
        {
            try
            {
                return dataAccessLayerDao.getMasterTalukaForDistrict(DistrictID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterTalukaForDistrict()", "");
            }
        }
        public DataSet getMasterVillageForTaluka(Int32 TalukaID)
        {
            try
            {
                return dataAccessLayerDao.getMasterVillageForTaluka(TalukaID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterVillageForTaluka()", "");
            }
        }
        public DataSet getMasterCandidatureType()
        {
            try
            {
                return dataAccessLayerDao.getMasterCandidatureType();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterCandidatureType()", "");
            }
        }
        public DataSet getMasterDocumentForTypeA()
        {
            try
            {
                return dataAccessLayerDao.getMasterDocumentForTypeA();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterDocumentForTypeA()", "");
            }
        }
        public DataSet getMasterDocumentOf()
        {
            try
            {
                return dataAccessLayerDao.getMasterDocumentOf();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterDocumentOf()", "");
            }
        }
        public DataSet getMasterMHDistrict()
        {
            try
            {
                return dataAccessLayerDao.getMasterMHDistrict();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterMHDistrict()", "");
            }
        }
        public DataSet getMasterMHTalukaForMHDistrict(Int32 DistrictID)
        {
            try
            {
                return dataAccessLayerDao.getMasterMHTalukaForMHDistrict(DistrictID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterMHTalukaForMHDistrict()", "");
            }
        }
        public DataSet getMasterCategory()
        {
            try
            {
                return dataAccessLayerDao.getMasterCategory();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterCategory()", "");
            }
        }
        public DataSet getMasterCasteForCategory(Int16 CategoryID)
        {
            try
            {
                return dataAccessLayerDao.getMasterCasteForCategory(CategoryID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterCasteForCategory()", "");
            }
        }
        public DataSet getMasterCasteForOpenCategory(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getMasterCasteForOpenCategory(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterCasteForOpenCategory()", "");
            }
        }
        public DataSet getMasterPHType()
        {
            try
            {
                return dataAccessLayerDao.getMasterPHType();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterPHType()", "");
            }
        }
        public DataSet getMasterCourse()
        {
            try
            {
                return dataAccessLayerDao.getMasterCourse();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterCourse()", "");
            }
        }
        public DataSet getMasterDefenceType()
        {
            try
            {
                return dataAccessLayerDao.getMasterDefenceType();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterDefenceType()", "");
            }
        }
        public DataSet getMasterMinority(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getMasterMinority(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterMinority()", "");
            }
        }
        public DataSet getMasterBoard()
        {
            try
            {
                return dataAccessLayerDao.getMasterBoard();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterBoard()", "");
            }
        }
        public DataSet getMasterHSCSubject(Int16 HSCBoardID)
        {
            try
            {
                return dataAccessLayerDao.getMasterHSCSubject(HSCBoardID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterHSCSubject()", "");
            }
        }
        public DataSet getMasterAFC()
        {
            try
            {
                return dataAccessLayerDao.getMasterAFC();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterAFC()", "");
            }
        }
        public DataSet getMasterWebSite()
        {
            try
            {
                return dataAccessLayerDao.getMasterWebSite();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterWebSite()", "");
            }
        }
        public DataSet getMasterBank()
        {
            try
            {
                return dataAccessLayerDao.getMasterBank();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterBank()", "");
            }
        }
        public DataSet getMasterLanguage()
        {
            try
            {
                return dataAccessLayerDao.getMasterLanguage();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterLanguage()", "");
            }
        }
        public DataSet getMasterApplicationBlockStatus()
        {
            try
            {
                return dataAccessLayerDao.getMasterApplicationBlockStatus();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterApplicationBlockStatus()", "");
            }
        }
        public DataSet getMasterUniversity(Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getMasterUniversity(CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterUniversity()", "");
            }
        }
        public DataSet getMasterCourseStatus1(Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getMasterCourseStatus1(CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterCourseStatus1()", "");
            }
        }
        public DataSet getMasterCourseStatus2(Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getMasterCourseStatus2(CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterCourseStatus2()", "");
            }
        }
        public DataSet getMasterCourseStatus3(Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getMasterCourseStatus3(CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterCourseStatus3()", "");
            }
        }
        public DataSet getMasterChoiceCodeStatus(Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getMasterChoiceCodeStatus(CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterChoiceCodeStatus()", "");
            }
        }
        public DataSet getMasterDistrictForUniversity(Int32 CAPRound, Int16 UniversityID)
        {
            try
            {
                return dataAccessLayerDao.getMasterDistrictForUniversity(CAPRound, UniversityID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterDistrictForUniversity()", "");
            }
        }
        public DataSet getMasterARC()
        {
            try
            {
                return dataAccessLayerDao.getMasterARC();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterARC()", "");
            }
        }
        public DataSet getMasterCandidateInstituteMinorityMapping()
        {
            try
            {
                return dataAccessLayerDao.getMasterCandidateInstituteMinorityMapping();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterCandidateInstituteMinorityMapping()", "");
            }
        }
        public Int32 getApplicationStatus(string ApplicationName)
        {
            try
            {
                return dataAccessLayerDao.getApplicationStatus(ApplicationName);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getApplicationStatus()", "");
            }
        }

        public string forgotApplicationID(string CandidateName, string FatherName, string MotherName, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.forgotApplicationID(CandidateName, FatherName, MotherName, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "forgotApplicationID()", "");
            }
        }
        public Int64 checkCandidateSecurityQuestionDetails(string ApplicationID, Int16 SecurityQuestionID, string SecurityAnswer)
        {
            try
            {
                return dataAccessLayerDao.checkCandidateSecurityQuestionDetails(ApplicationID, SecurityQuestionID, SecurityAnswer);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkCandidateSecurityQuestionDetails()", "");
            }
        }
        public bool resetCandidatePassword(Int64 PID, string CandidatePassword, string PasswordResetBy, string PasswordResetByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.resetCandidatePassword(PID, CandidatePassword, PasswordResetBy, PasswordResetByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "resetCandidatePassword()", "");
            }
        }
        public Int64 checkCandidateApplicationIDAndDOB(string ApplicationID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.checkCandidateApplicationIDAndDOB(ApplicationID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkCandidateApplicationIDAndDOB()", "");
            }
        }
        public string verifyCandidateMobileNo(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.verifyCandidateMobileNo(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyCandidateMobileNo()", "");
            }
        }
        public bool sendCandidateOTPCodeForResetPassword(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.sendCandidateOTPCodeForResetPassword(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "sendCandidateOTPCodeForResetPassword()", "");
            }
        }
        public bool verifyCandidateOTPCode(Int64 PID, string OTPCode)
        {
            try
            {
                return dataAccessLayerDao.verifyCandidateOTPCode(PID, OTPCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyCandidateOTPCode()", "");
            }
        }
        public string verifyCandidateEMailID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.verifyCandidateEMailID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyCandidateEMailID()", "");
            }
        }
        public bool sendCandidateEMailVerificationCodeForResetPassword(Int64 PID, string EMailVerificationCode)
        {
            try
            {
                return dataAccessLayerDao.sendCandidateEMailVerificationCodeForResetPassword(PID, EMailVerificationCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "sendCandidateEMailVerificationCodeForResetPassword()", "");
            }
        }
        public bool verifyCandidateEMailVerificationCode(Int64 PID, string EMailVerificationCode)
        {
            try
            {
                return dataAccessLayerDao.verifyCandidateEMailVerificationCode(PID, EMailVerificationCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyCandidateEMailVerificationCode()", "");
            }
        }

        public string checkOthersSecurityQuestionDetails(string LoginID, Int16 SecurityQuestionID, string SecurityAnswer)
        {
            try
            {
                return dataAccessLayerDao.checkOthersSecurityQuestionDetails(LoginID, SecurityQuestionID, SecurityAnswer);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkOthersSecurityQuestionDetails()", "");
            }
        }
        public bool resetOthersPassword(string LoginID, string Password, string PasswordResetByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.resetOthersPassword(LoginID, Password, PasswordResetByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "resetOthersPassword()", "");
            }
        }
        public string checkOthersLoginIDAndDOB(string LoginID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.checkOthersLoginIDAndDOB(LoginID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkOthersLoginIDAndDOB()", "");
            }
        }
        public string verifyOthersMobileNo(string LoginID)
        {
            try
            {
                return dataAccessLayerDao.verifyOthersMobileNo(LoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyOthersMobileNo()", "");
            }
        }
        public bool sendOthersOTPCodeForResetPassword(string LoginID)
        {
            try
            {
                return dataAccessLayerDao.sendOthersOTPCodeForResetPassword(LoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "sendOthersOTPCodeForResetPassword()", "");
            }
        }
        public bool verifyOthersOTPCode(string LoginID, string OTPCode)
        {
            try
            {
                return dataAccessLayerDao.verifyOthersOTPCode(LoginID, OTPCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyOthersOTPCode()", "");
            }
        }
        public string verifyOthersEMailID(string LoginID)
        {
            try
            {
                return dataAccessLayerDao.verifyOthersEMailID(LoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyOthersEMailID()", "");
            }
        }
        public bool sendOthersEMailVerificationCodeForResetPassword(string LoginID, string EMailVerificationCode)
        {
            try
            {
                return dataAccessLayerDao.sendOthersEMailVerificationCodeForResetPassword(LoginID, EMailVerificationCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "sendOthersEMailVerificationCodeForResetPassword()", "");
            }
        }
        public bool verifyOthersEMailVerificationCode(string LoginID, string EMailVerificationCode)
        {
            try
            {
                return dataAccessLayerDao.verifyOthersEMailVerificationCode(LoginID, EMailVerificationCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyOthersEMailVerificationCode()", "");
            }
        }

        public DataSet checkCETDetails(Int64 CETApplicationFormNo, string CETRollNo, string DOB)
        {
            try
            {
                return dataAccessLayerDao.checkCETDetails(CETApplicationFormNo, CETRollNo, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkCETDetails()", "");
            }
        }
        public RegistrationDetails getRegistrationDetails(Int64 PID)
        {
            try
            {
                return BalCommon.FillRegistrationDetails(dataAccessLayerDao.getRegistrationDetails(PID));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRegistrationDetails()", "");
            }
        }
        public string saveRegistrationDetails(RegistrationDetails obj, string CandidatePassword, Int16 SecurityQuestionID, string SecurityAnswer, Int64 CETApplicationFormNo, string OTP, string IsActive, string ModifiedBy, string ModifiedByIPAddress, string FCRApplicationID, string FCRCandidateName, string FCRCandidatureTypeName, string FCRMotherName, string FCRGender, DateTime FCRDOB)
        {
            try
            {
                return dataAccessLayerDao.saveRegistrationDetails(obj, CandidatePassword, SecurityQuestionID, SecurityAnswer, CETApplicationFormNo, OTP, IsActive, ModifiedBy, ModifiedByIPAddress, FCRApplicationID, FCRCandidateName, FCRCandidatureTypeName, FCRMotherName, FCRGender, FCRDOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveRegistrationDetails()", "");
            }
        }
        public bool updateRegistrationDetails(RegistrationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateRegistrationDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateRegistrationDetails()", "");
            }
        }
        public Int16 getCandidatureTypeID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCandidatureTypeID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidatureTypeID()", "");
            }
        }
        public bool saveCandidatureTypeDetails(Int64 PID, Int16 CandidatureTypeID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveCandidatureTypeDetails(PID, CandidatureTypeID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveCandidatureTypeDetails()", "");
            }
        }
        public HomeUniversityAndCategoryDetails getHomeUniversityAndCategoryDetails(Int64 PID)
        {
            try
            {
                return BalCommon.FillHomeUniversityAndCategoryDetails(dataAccessLayerDao.getHomeUniversityAndCategoryDetails(PID));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getHomeUniversityAndCategoryDetails()", "");
            }
        }
        public bool saveHomeUniversityAndCategoryDetails(HomeUniversityAndCategoryDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveHomeUniversityAndCategoryDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveHomeUniversityAndCategoryDetails()", "");
            }
        }
        public SpecialReservationDetails getSpecialReservationDetails(Int64 PID)
        {
            try
            {
                return BalCommon.FillSpecialReservationDetails(dataAccessLayerDao.getSpecialReservationDetails(PID));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSpecialReservationDetails()", "");
            }
        }
        public bool saveSpecialReservationDetails(SpecialReservationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveSpecialReservationDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveSpecialReservationDetails()", "");
            }
        }
        public QualificationDetails getQualificationDetails(Int64 PID)
        {
            try
            {
                return BalCommon.FillQualificationDetails(dataAccessLayerDao.getQualificationDetails(PID));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getQualificationDetails()", "");
            }
        }
        public bool saveQualificationDetails(QualificationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveQualificationDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveQualificationDetails()", "");
            }
        }
        public NEETDetails getNEETDetails(Int64 PID)
        {
            try
            {
                return BalCommon.FillNEETDetails(dataAccessLayerDao.getNEETDetails(PID));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getNEETDetails()", "");
            }
        }
        public bool saveNEETDetails(NEETDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveNEETDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveNEETDetails()", "");
            }
        }
        public DataSet checkNEETDetailsOnSave(NEETDetails obj)
        {
            try
            {
                return dataAccessLayerDao.checkNEETDetailsOnSave(obj);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkNEETDetailsOnSave()", "");
            }
        }
        public DataSet checkNEETDetails(Int64 PID, Int64 NEETRollNo, string AppearedForNEET)
        {
            try
            {
                return dataAccessLayerDao.checkNEETDetails(PID, NEETRollNo, AppearedForNEET);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkNEETDetails()", "");
            }
        }
        public bool saveScannedImagesStepID(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveScannedImagesStepID(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveScannedImagesStepID()", "");
            }
        }
        public bool savePayApplicationFeeStepID(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.savePayApplicationFeeStepID(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "savePayApplicationFeeStepID()", "");
            }
        }
        public PersonalInformation getPersonalInformation(Int64 PID)
        {
            try
            {
                return BalCommon.FillPersonalInformation(dataAccessLayerDao.getPersonalInformation(PID));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPersonalInformation()", "");
            }
        }
        public DataSet getSecurityQuestionDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSecurityQuestionDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSecurityQuestionDetails()", "");
            }
        }
        public bool saveSecurityQuestionDetails(Int64 PID, Int16 SecurityQuestionID, string SecurityAnswer, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveSecurityQuestionDetails(PID, SecurityQuestionID, SecurityAnswer, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveSecurityQuestionDetails()", "");
            }
        }
        public bool saveFeedback(Int64 PID, string Feedback, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveFeedback(PID, Feedback, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveFeedback()", "");
            }
        }

        public bool editRegistrationDetails(RegistrationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editRegistrationDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editRegistrationDetails()", "");
            }
        }
        public bool editCandidatureTypeDetails(Int64 PID, Int16 CandidatureTypeID, HomeUniversityAndCategoryDetails objHUC, SpecialReservationDetails objSR, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editCandidatureTypeDetails(PID, CandidatureTypeID, objHUC, objSR, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editCandidatureTypeDetails()", "");
            }
        }
        public bool editCandidatureTypeDetailsForARC(Int64 PID, Int16 CandidatureTypeID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editCandidatureTypeDetailsForARC(PID, CandidatureTypeID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editCandidatureTypeDetailsForARC()", "");
            }
        }
        public bool editHomeUniversityAndCategoryDetails(HomeUniversityAndCategoryDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editHomeUniversityAndCategoryDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editHomeUniversityAndCategoryDetails()", "");
            }
        }
        public bool editSpecialReservationDetails(SpecialReservationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editSpecialReservationDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editSpecialReservationDetails()", "");
            }
        }
        public bool editQualificationDetails(QualificationDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editQualificationDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editQualificationDetails()", "");
            }
        }
        public bool editNEETDetails(NEETDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editNEETDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editNEETDetails()", "");
            }
        }
        public Int16 getStepIDApplicationRound(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getStepIDApplicationRound(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getStepIDApplicationRound()", "");
            }
        }
        public SessionData getSessionDataForCandidate(Int64 PID)
        {
            try
            {
                return BalCommon.FillSessionDataForCandidate(dataAccessLayerDao.getSessionDataForCandidate(PID));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSessionDataForCandidate()", "");
            }
        }
        public Int16 getAnnualFamilyIncomeID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getAnnualFamilyIncomeID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAnnualFamilyIncomeID()", "");
            }
        }

        public string getNationality(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getNationality(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getNationality()", "");
            }
        }
        public Int16 getCategoryID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCategoryID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCategoryID()", "");
            }
        }
        public Int16 getPHTypeID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPHTypeID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPHTypeID()", "");
            }
        }
        public DataSet getDocumentList(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getDocumentList(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getDocumentList()", "");
            }
        }
        public bool saveLogOutDateTime(Int64 SessionID)
        {
            try
            {
                return dataAccessLayerDao.saveLogOutDateTime(SessionID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveLogOutDateTime()", "");
            }
        }
        public char getApplicationFormStatusApplicationRound(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getApplicationFormStatusApplicationRound(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getApplicationFormStatusApplicationRound()", "");
            }
        }
        public Int32 getApplicationFeeToBePaid(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getApplicationFeeToBePaid(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getApplicationFeeToBePaid()", "");
            }
        }
        public DataSet getCETDetails(Int64 CETApplicationFormNo)
        {
            try
            {
                return dataAccessLayerDao.getCETDetails(CETApplicationFormNo);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCETDetails()", "");
            }
        }
        public DataSet Get_MSNEETDetails(Int64 NEETRollNo)
        {
            try
            {
                return dataAccessLayerDao.Get_MSNEETDetails(NEETRollNo);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCETDetails()", "");
            }
        }
        public Int32 getApplicationFeePaidAmount(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getApplicationFeePaidAmount(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getApplicationFeePaidAmount()", "");
            }
        }
        public Int64 getCETApplicationFormNo(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCETApplicationFormNo(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCETApplicationFormNo()", "");
            }
        }
        public string getMotherTongue(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getMotherTongue(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMotherTongue()", "");
            }
        }
        public string getReligion(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getReligion(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReligion()", "");
            }
        }
        public DataSet getRequiredDocumentsUploadStatusReportForCandidate(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getRequiredDocumentsUploadStatusReportForCandidate(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRequiredDocumentsUploadStatusReportForCandidate()", "");
            }
        }
        public DataSet getCurrentAllotmentDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCurrentAllotmentDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCurrentAllotmentDetails()", "");
            }
        }
        public DataSet getCurrentAdmissionDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCurrentAdmissionDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCurrentAdmissionDetails()", "");
            }
        }
        public bool isCandidateNameAppearedInFinalMeritList(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateNameAppearedInFinalMeritList(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateNameAppearedInFinalMeritList()", "");
            }
        }
        public DataSet getResult(Int64 CETApplicationFormNo)
        {
            try
            {
                return dataAccessLayerDao.getResult(CETApplicationFormNo);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getResult()", "");
            }
        }
        public DataSet getCurrentLink(Int64 PID, string URL)
        {
            try
            {
                return dataAccessLayerDao.getCurrentLink(PID, URL);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCurrentLink()", "");
            }
        }
        public DataSet getEligibilityFlag(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getEligibilityFlag(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getEligibilityFlag()", "");
            }
        }
        public Int32 getProposedApplicationFeeToBePaid(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsEWSChanged)
        {
            try
            {
                return dataAccessLayerDao.getProposedApplicationFeeToBePaid(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsEWSChanged);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getProposedApplicationFeeToBePaid()", "");
            }
        }
        public DataSet getProvisionalMeritStatus(string ApplicationID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.getProvisionalMeritStatus(ApplicationID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getProvisionalMeritStatus()", "");
            }
        }
        public DataSet getFinalMeritStatus(string ApplicationID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.getFinalMeritStatus(ApplicationID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getFinalMeritStatus()", "");
            }
        }
        public bool verifyOTP(string ApplicationID, string OneTimePassword, int OTPType)
        {
            try
            {
                return dataAccessLayerDao.verifyOTP(ApplicationID, OneTimePassword, OTPType);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyOTP()", "");
            }
        }
        public DataSet getOTPDetails(string ApplicationID, string OneTimePassword)
        {
            try
            {
                return dataAccessLayerDao.getOTPDetails(ApplicationID, OneTimePassword);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOTPDetails()", "");
            }
        }
        public bool isApplicationFormConfirmedUsingThisMobileNo(string MobileNo)
        {
            try
            {
                return dataAccessLayerDao.isApplicationFormConfirmedUsingThisMobileNo(MobileNo);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isApplicationFormConfirmedUsingThisMobileNo()", "");
            }
        }
        public DataSet getSMSContent(Int64 PID, string Flag)
        {
            try
            {
                return dataAccessLayerDao.getSMSContent(PID, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSMSContent()", "");
            }
        }
        public bool saveOTPForMobileNoChange(Int64 PID, string OTP)
        {
            try
            {
                return dataAccessLayerDao.saveOTPForMobileNoChange(PID, OTP);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveOTPForMobileNoChange()", "");
            }
        }
        public bool verifyOTPForMobileNoChange(Int64 PID, string OTP, string MobileNo, string IpAddress, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.verifyOTPForMobileNoChange(PID, OTP, MobileNo, IpAddress, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyOTPForMobileNoChange()", "");
            }
        }
        public string getMobileNo(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getMobileNo(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMobileNo()", "");
            }
        }
        public bool isApplicationFormEligibleForEditting(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isApplicationFormEligibleForEditting(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isApplicationFormEligibleForEditting()", "");
            }
        }
        public string isCandidateEligibleForEdittingAtARC(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateEligibleForEdittingAtARC(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateEligibleForEdittingAtARC()", "");
            }
        }

        public DataSet getAdminNonRepliedMessages(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getAdminNonRepliedMessages(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdminNonRepliedMessages()", "");
            }
        }
        public DataSet getAdminRepliedMessages(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getAdminRepliedMessages(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdminRepliedMessages()", "");
            }
        }
        public DataSet getAdminSentMessages(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getAdminSentMessages(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdminSentMessages()", "");
            }
        }
        public DataSet getMessagesList(string From)
        {
            try
            {
                return dataAccessLayerDao.getMessagesList(From);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMessagesList()", "");
            }
        }
        public bool replyMessage(Int64 MessageID, string RepliedMessage, string RepliedBy, string RepliedByIPAddress, string RepliedTo, string IsStarMarked)
        {
            try
            {
                return dataAccessLayerDao.replyMessage(MessageID, RepliedMessage, RepliedBy, RepliedByIPAddress, RepliedTo, IsStarMarked);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "replyMessage()", "");
            }
        }
        public bool adminComposeMessage(string To, string From, string Message, string FilePath1, string FilePath2, string SentBy, string SentByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.adminComposeMessage(To, From, Message, FilePath1, FilePath2, SentBy, SentByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "adminComposeMessage()", "");
            }
        }
        public DataSet getAFCNonRepliedMessages(string AFCCode)
        {
            try
            {
                return dataAccessLayerDao.getAFCNonRepliedMessages(AFCCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAFCNonRepliedMessages()", "");
            }
        }
        public DataSet getAFCBroadcastedMessages(string AFCCode)
        {
            try
            {
                return dataAccessLayerDao.getAFCBroadcastedMessages(AFCCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAFCBroadcastedMessages()", "");
            }
        }
        public DataSet getAFCRepliedMessages(string AFCCode)
        {
            try
            {
                return dataAccessLayerDao.getAFCRepliedMessages(AFCCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAFCRepliedMessages()", "");
            }
        }
        public bool afcComposeMessage(string To, string From, string Subject, string Message, string FilePath1, string FilePath2, string SentBy, string SentByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.afcComposeMessage(To, From, Subject, Message, FilePath1, FilePath2, SentBy, SentByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "afcComposeMessage()", "");
            }
        }
        public DataSet adminComposeSMS(string To, string From, string Message, string SentBy, string SentByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.adminComposeSMS(To, From, Message, SentBy, SentByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "adminComposeSMS()", "");
            }
        }
        public DataSet getAdminSentSMSs(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getAdminSentSMSs(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdminSentSMSs()", "");
            }
        }
        public DataSet getRONonRepliedMessages(string Flag, string LoginID)
        {
            try
            {
                return dataAccessLayerDao.getRONonRepliedMessages(Flag, LoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRONonRepliedMessages()", "");
            }
        }
        public DataSet getRORepliedMessages(string Flag, string LoginID)
        {
            try
            {
                return dataAccessLayerDao.getRORepliedMessages(Flag, LoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRORepliedMessages()", "");
            }
        }
        public DataSet getROSentMessages(string Flag, string LoginID)
        {
            try
            {
                return dataAccessLayerDao.getROSentMessages(Flag, LoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getROSentMessages()", "");
            }
        }
        public bool roComposeMessage(string To, string From, string Message, string FilePath1, string FilePath2, string SentBy, string SentByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.roComposeMessage(To, From, Message, FilePath1, FilePath2, SentBy, SentByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "roComposeMessage()", "");
            }
        }
        public DataSet getInstituteNonRepliedMessages(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getInstituteNonRepliedMessages(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteNonRepliedMessages()", "");
            }
        }
        public DataSet getInstituteBroadcastedMessages(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getInstituteBroadcastedMessages(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteBroadcastedMessages()", "");
            }
        }
        public DataSet getInstituteRepliedMessages(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getInstituteRepliedMessages(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteRepliedMessages()", "");
            }
        }
        public bool instituteComposeMessage(string To, string From, string Subject, string Message, string FilePath1, string FilePath2, string SentBy, string SentByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.instituteComposeMessage(To, From, Subject, Message, FilePath1, FilePath2, SentBy, SentByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "instituteComposeMessage()", "");
            }
        }

        public Int64 getPersonalID(string ApplicationID)
        {
            try
            {
                return dataAccessLayerDao.getPersonalID(ApplicationID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPersonalID()", "");
            }
        }
        public string getCandidateName(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCandidateName(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateName()", "");
            }
        }
        public bool resetCandidatePasswordByAdmin(Int64 PID, string CandidatePassword, string PasswordResetBy, string PasswordResetByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.resetCandidatePasswordByAdmin(PID, CandidatePassword, PasswordResetBy, PasswordResetByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "resetCandidatePasswordByAdmin()", "");
            }
        }
        public bool updateUserAction(string UserLoginID, string ApplicationID, string ActionTaken, string Module, string IPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateUserAction(UserLoginID, ApplicationID, ActionTaken, Module, IPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateUserAction()", "");
            }
        }
        public DataSet getDashboardAFC(Int32 UserTypeID, string UserLoginID, string Flag)
        {
            try
            {
                return dataAccessLayerDao.getDashboardAFC(UserTypeID, UserLoginID, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getDashboardAFC()", "");
            }
        }
        public DataSet getDashboardARC(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getDashboardARC(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getDashboardARC()", "");
            }
        }
        public DataSet getDashboardInstitute(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getDashboardInstitute(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getDashboardInstitute()", "");
            }
        }
        public DataSet getCandidateDetailsForDisplay(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCandidateDetailsForDisplay(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateDetailsForDisplay()", "");
            }
        }
        public DataSet searchCandidate(string Query)
        {
            try
            {
                return dataAccessLayerDao.searchCandidate(Query);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "searchCandidate()", "");
            }
        }
        public DataSet getLoginDetails(string LoginID, Int32 UserTypeID)
        {
            try
            {
                return dataAccessLayerDao.getLoginDetails(LoginID, UserTypeID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getLoginDetails()", "");
            }
        }
        public DataSet getMasterAFCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getMasterAFCList(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterAFCList()", "");
            }
        }
        public DataSet getNonAFCInstituteList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getNonAFCInstituteList(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getNonAFCInstituteList()", "");
            }
        }
        public bool addMasterAFC(Int64 InstituteID, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.addMasterAFC(InstituteID, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "addMasterAFC()", "");
            }
        }
        public bool deleteMasterAFC(Int64 InstituteID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteMasterAFC(InstituteID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteMasterAFC()", "");
            }
        }
        public bool isInstituteWorkingAsAFC(Int64 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.isInstituteWorkingAsAFC(InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isInstituteWorkingAsAFC()", "");
            }
        }
        public DataSet getAFCList(Int64 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.getAFCList(InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAFCList()", "");
            }
        }
        public string addAFC(Int64 InstituteID, string AFCOfficerName, string AFCOfficerMobileNo, string Password, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.addAFC(InstituteID, AFCOfficerName, AFCOfficerMobileNo, Password, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "addAFC()", "");
            }
        }
        public bool updateAFC(Int64 AFCID, string AFCOfficerName, string AFCOfficerMobileNo, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateAFC(AFCID, AFCOfficerName, AFCOfficerMobileNo, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateAFC()", "");
            }
        }
        public bool deleteAFC(Int64 AFCID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteAFC(AFCID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteAFC()", "");
            }
        }
        public DataSet getSubAFCList(Int64 AFCID)
        {
            try
            {
                return dataAccessLayerDao.getSubAFCList(AFCID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSubAFCList()", "");
            }
        }
        public string addSubAFC(Int64 AFCID, string SubAFCOfficerName, string SubAFCOfficerMobileNo, string Password, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.addSubAFC(AFCID, SubAFCOfficerName, SubAFCOfficerMobileNo, Password, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "addSubAFC()", "");
            }
        }
        public bool updateSubAFC(Int64 SubAFCID, string SubAFCOfficerName, string SubAFCOfficerMobileNo, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateSubAFC(SubAFCID, SubAFCOfficerName, SubAFCOfficerMobileNo, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateSubAFC()", "");
            }
        }
        public bool deleteSubAFC(Int64 SubAFCID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteSubAFC(SubAFCID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteSubAFC()", "");
            }
        }
        public DataSet getROList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getROList(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getROList()", "");
            }
        }
        public DataSet getAFCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getAFCList(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAFCList()", "");
            }
        }
        public DataSet getSubAFCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getSubAFCList(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSubAFCList()", "");
            }
        }
        public string getPassword(Int32 UserTypeID, string LoginID)
        {
            try
            {
                return dataAccessLayerDao.getPassword(UserTypeID, LoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPassword()", "");
            }
        }
        public bool resetPassword(Int32 UserTypeID, string LoginID, string Password, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.resetPassword(UserTypeID, LoginID, Password, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "resetPassword()", "");
            }
        }
        public bool saveAFCProfile(AFCProfile obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveAFCProfile(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveAFCProfile()", "");
            }
        }
        public bool updateAFCProfile(AFCProfile obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateAFCProfile(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateAFCProfile()", "");
            }
        }
        public AFCProfile getAFCProfile(string AFCCode)
        {
            try
            {
                return BalCommon.FillAFCProfile(dataAccessLayerDao.getAFCProfile(AFCCode));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAFCProfile()", "");
            }
        }
        public DataSet getAFCListReport()
        {
            try
            {
                return dataAccessLayerDao.getAFCListReport();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAFCListReport()", "");
            }
        }
        public DataSet checkUser(string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.checkUser(UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkUser()", "");
            }
        }
        public DataSet getRegionWiseReport(string ConfirmationDate)
        {
            try
            {
                return dataAccessLayerDao.getRegionWiseReport(ConfirmationDate);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRegionWiseReport()", "");
            }
        }
        public Int16 getRegionID(Int64 AFCID)
        {
            try
            {
                return dataAccessLayerDao.getRegionID(AFCID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRegionID()", "");
            }
        }
        public DataSet getAFCWiseReport(Int16 RegionID, string ConfirmationDate)
        {
            try
            {
                return dataAccessLayerDao.getAFCWiseReport(RegionID, ConfirmationDate);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAFCWiseReport()", "");
            }
        }
        public Int32 getInstituteID(Int64 AFCID)
        {
            try
            {
                return dataAccessLayerDao.getInstituteID(AFCID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteID()", "");
            }
        }
        public DataSet getSubAFCWiseReport(Int16 RegionID, Int32 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.getSubAFCWiseReport(RegionID, InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSubAFCWiseReport()", "");
            }
        }
        public DataSet getConfirmationDateList()
        {
            try
            {
                return dataAccessLayerDao.getConfirmationDateList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getConfirmationDateList()", "");
            }
        }
        public DataSet getDiscrepancyDateList(Int32 InstituteID, Int32 AFCID)
        {
            try
            {
                return dataAccessLayerDao.getDiscrepancyDateList(InstituteID, AFCID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getDiscrepancyDateList()", "");
            }
        }
        public DataSet getConfirmedCandidateList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                return dataAccessLayerDao.getConfirmedCandidateList(RegionID, InstituteID, AFCID, ConfirmationDate);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getConfirmedCandidateList()", "");
            }
        }
        public DataSet getARCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getARCList(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARCList()", "");
            }
        }
        public DataSet getSubARCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getSubARCList(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSubARCList()", "");
            }
        }

        public Int64 checkApplicationStatus(string ApplicationID, Int32 VersionNo)
        {
            try
            {
                return dataAccessLayerDao.checkApplicationStatus(ApplicationID, VersionNo);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkApplicationStatus()", "");
            }
        }
        public bool updateDocumentSubmission(Int64 PID, string XMLString, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateDocumentSubmission(PID, XMLString, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateDocumentSubmission()", "");
            }
        }
        public DataSet getDocumentList(Int64 PID, string SubmittedFlag)
        {
            try
            {
                return dataAccessLayerDao.getDocumentList(PID, SubmittedFlag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getDocumentList()", "");
            }
        }
        public bool confirmApplicationForm(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsMinorityChanged, Int32 IsEWSChanged, Int32 IsOrphanChanged, string Comments, string IsNCLReceiptSubmitted, DateTime NCLIssueDate, Int32 NCLValidUpto, Int32 IsTFWSChanged, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmApplicationForm(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsMinorityChanged, IsEWSChanged, IsOrphanChanged, Comments, IsNCLReceiptSubmitted, NCLIssueDate, NCLValidUpto, IsTFWSChanged, ConfirmedBy, ConfirmedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmApplicationForm()", "");
            }
        }
        public bool confirmApplicationFormProvisionally(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsMinorityChanged, Int32 IsEWSChanged, Int32 IsOrphanChanged, string Comments, string IsNCLReceiptSubmitted, DateTime NCLIssueDate, Int32 NCLValidUpto, Int32 IsTFWSChanged, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmApplicationFormProvisionally(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsMinorityChanged, IsEWSChanged, IsOrphanChanged, Comments, IsNCLReceiptSubmitted, NCLIssueDate, NCLValidUpto, IsTFWSChanged, ConfirmedBy, ConfirmedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmApplicationFormProvisionally()", "");
            }
        }
        public bool isApplicationFormConfirmed(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isApplicationFormConfirmed(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isApplicationFormConfirmed()", "");
            }
        }
        public DataSet getApplicationFormConfirmationDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getApplicationFormConfirmationDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getApplicationFormConfirmationDetails()", "");
            }
        }
        public bool checkApplicationFormConfirmationDetails(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.checkApplicationFormConfirmationDetails(PID, UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkApplicationFormConfirmationDetails()", "");
            }
        }
        public DataSet getNCLDocumentDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getNCLDocumentDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getNCLDocumentDetails()", "");
            }
        }
        public bool editConfirmedApplicationForm(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsMinorityChanged, Int32 IsEWSChanged, Int32 IsOrphanChanged, string Comments, string IsNCLReceiptSubmitted, DateTime NCLIssueDate, Int32 NCLValidUpto, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editConfirmedApplicationForm(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsMinorityChanged, IsEWSChanged, IsOrphanChanged, Comments, IsNCLReceiptSubmitted, NCLIssueDate, NCLValidUpto, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editConfirmedApplicationForm()", "");
            }
        }
        public bool cancelConfirmedApplicationForm(Int64 PID, string ReasonForCancellation, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelConfirmedApplicationForm(PID, ReasonForCancellation, CancelledBy, CancelledByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelConfirmedApplicationForm()", "");
            }
        }
        public bool checkDuplicateApplicationForm(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.checkDuplicateApplicationForm(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkDuplicateApplicationForm()", "");
            }
        }
        public DataSet getDuplicateApplicationFormDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getDuplicateApplicationFormDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getDuplicateApplicationFormDetails()", "");
            }
        }
        public bool sendSMSToCandidate(string From, string To, string SMSContent, string SentBy, string SentByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.sendSMSToCandidate(From, To, SMSContent, SentBy, SentByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "sendSMSToCandidate()", "");
            }
        }
        public bool editApplicationStatus(string ApplicationName, Int32 ApplicationStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editApplicationStatus(ApplicationName, ApplicationStatus, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editApplicationStatus()", "");
            }
        }
        public Int64 getParentID(Int64 AFCID)
        {
            try
            {
                return dataAccessLayerDao.getParentID(AFCID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getParentID()", "");
            }
        }

        public bool saveImportantDates(string ActivityDetails, DateTime ActivityStartDate, string ActivityStartTime, DateTime ActivityEndDate, string ActivityEndTime, DateTime ActivityDisplayStartDateTime, DateTime ActivityDisplayEndDateTime, string ActivityType, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveImportantDates(ActivityDetails, ActivityStartDate, ActivityStartTime, ActivityEndDate, ActivityEndTime, ActivityDisplayStartDateTime, ActivityDisplayEndDateTime, ActivityType, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveImportantDates()", "");
            }
        }
        public bool editImportantDates(Int64 ActivityID, string ActivityDetails, DateTime ActivityStartDate, string ActivityStartTime, DateTime ActivityEndDate, string ActivityEndTime, DateTime ActivityDisplayStartDateTime, DateTime ActivityDisplayEndDateTime, string ActivityType, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editImportantDates(ActivityID, ActivityDetails, ActivityStartDate, ActivityStartTime, ActivityEndDate, ActivityEndTime, ActivityDisplayStartDateTime, ActivityDisplayEndDateTime, ActivityType, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editImportantDates()", "");
            }
        }
        public bool deleteImportantDates(Int64 ActivityID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteImportantDates(ActivityID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteImportantDates()", "");
            }
        }
        public DataSet getImportantDates(Int64 ActivityID)
        {
            try
            {
                return dataAccessLayerDao.getImportantDates(ActivityID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getImportantDates()", "");
            }
        }
        public DataSet getAllImportantDates()
        {
            try
            {
                return dataAccessLayerDao.getAllImportantDates();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllImportantDates()", "");
            }
        }
        public DataSet getImportantDates()
        {
            try
            {
                return dataAccessLayerDao.getImportantDates();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getImportantDates()", "");
            }
        }
        public DataSet getTopActiveImportantDates()
        {
            try
            {
                return dataAccessLayerDao.getTopActiveImportantDates();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getTopActiveImportantDates()", "");
            }
        }
        public Int32 getApplicationFeeDetails(Int32 CandidatureTypeID, Int32 CategoryID, Int32 PHTypeID, string AppliedForEWS)
        {
            try
            {
                return dataAccessLayerDao.getApplicationFeeDetails(CandidatureTypeID, CategoryID, PHTypeID, AppliedForEWS);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getApplicationFeeDetails()", "");
            }
        }

        public DataSet getReportsList()
        {
            try
            {
                return dataAccessLayerDao.getReportsList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReportsList()", "");
            }
        }
        public DataSet executeReport(Int64 ReportID)
        {
            try
            {
                return dataAccessLayerDao.executeReport(ReportID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "executeReport()", "");
            }
        }
        public DataSet searchReport(string Query)
        {
            try
            {
                return dataAccessLayerDao.searchReport(Query);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "searchReport()", "");
            }
        }
        public DataSet getTableViewList()
        {
            try
            {
                return dataAccessLayerDao.getTableViewList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getTableViewList()", "");
            }
        }
        public DataSet getRejectedKeyWordList()
        {
            try
            {
                return dataAccessLayerDao.getRejectedKeyWordList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRejectedKeyWordList()", "");
            }
        }
        public DataSet getColumnsList(string TableViewName)
        {
            try
            {
                return dataAccessLayerDao.getColumnsList(TableViewName);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getColumnsList()", "");
            }
        }
        public bool saveReportDetails(string ReportName, string ReportQuery, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveReportDetails(ReportName, ReportQuery, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveReportDetails()", "");
            }
        }
        public bool editReportDetails(Int64 ReportID, string ReportName, string ReportQuery, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editReportDetails(ReportID, ReportName, ReportQuery, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editReportDetails()", "");
            }
        }
        public bool deleteReportDetails(Int64 ReportID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteReportDetails(ReportID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteReportDetails()", "");
            }
        }
        public DataSet getReportDetails(Int64 ReportID)
        {
            try
            {
                return dataAccessLayerDao.getReportDetails(ReportID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReportDetails()", "");
            }
        }

        public bool saveCaste(string CasteName, string CasteSrNo, Int16 CategoryID)
        {
            try
            {
                return dataAccessLayerDao.saveCaste(CasteName, CasteSrNo, CategoryID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveCaste()", "");
            }
        }
        public bool deleteCaste(Int32 CasteID)
        {
            try
            {
                return dataAccessLayerDao.deleteCaste(CasteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteCaste()", "");
            }
        }
        public CasteList getCaste(Int32 CasteID)
        {
            try
            {
                return BalCommon.FillCasteList(dataAccessLayerDao.getCaste(CasteID));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCaste()", "");
            }
        }
        public bool updateCaste(CasteList Caste)
        {
            try
            {
                return dataAccessLayerDao.updateCaste(Caste);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateCaste()", "");
            }
        }

        public DataSet getInstituteList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getInstituteList(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteList()", "");
            }
        }
        public bool changeInstitutePassword(string InstituteCode, string OldPassword, string NewPassword)
        {
            try
            {
                return dataAccessLayerDao.changeInstitutePassword(InstituteCode, OldPassword, NewPassword);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "changeInstitutePassword()", "");
            }
        }
        public bool updateInstituteProfile(InstituteProfile obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateInstituteProfile(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateInstituteProfile()", "");
            }
        }
        public InstituteProfile getInstituteProfile(Int32 InstituteID)
        {
            try
            {
                return BalCommon.FillInstituteProfile(dataAccessLayerDao.getInstituteProfile(InstituteID));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteProfile()", "");
            }
        }
        public DataSet getInstituteProfileDS(Int32 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.getInstituteProfileDS(InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteProfileDS()", "");
            }
        }
        public string getInstitutePassword(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getInstitutePassword(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstitutePassword()", "");
            }
        }
        public bool resetInstitutePassword(string InstituteCode, string Password, string EncryptedPassword)
        {
            try
            {
                return dataAccessLayerDao.resetInstitutePassword(InstituteCode, Password, EncryptedPassword);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "resetInstitutePassword()", "");
            }
        }
        public DataSet getInstitutesDetailedList()
        {
            try
            {
                return dataAccessLayerDao.getInstitutesDetailedList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstitutesDetailedList()", "");
            }
        }
        public InstituteSummary getInstituteSummary(string InstituteCode)
        {
            try
            {
                return BalCommon.FillInstituteSummary(dataAccessLayerDao.getInstituteSummary(InstituteCode));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteSummary()", "");
            }
        }
        public DataSet getChoiceCodeListByInstitute(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getChoiceCodeListByInstitute(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getChoiceCodeListByInstitute()", "");
            }
        }
        public CourseInformation getCourseInformation(string ChoiceCode)
        {
            try
            {
                return BalCommon.FillCourseInformation(dataAccessLayerDao.getCourseInformation(ChoiceCode));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCourseInformation()", "");
            }
        }
        public bool saveCourseInformation(CourseInformation obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveCourseInformation(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveCourseInformation()", "");
            }
        }
        public DataSet getInvalidSeatDistributionList()
        {
            try
            {
                return dataAccessLayerDao.getInvalidSeatDistributionList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInvalidSeatDistributionList()", "");
            }
        }
        public DataSet getAllChoiceCodeList()
        {
            try
            {
                return dataAccessLayerDao.getAllChoiceCodeList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllChoiceCodeList()", "");
            }
        }
        public DataSet getNewChoiceCodesAvailable()
        {
            try
            {
                return dataAccessLayerDao.getNewChoiceCodesAvailable();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getNewChoiceCodesAvailable()", "");
            }
        }
        public DataSet getChoiceCodesAvailableForUpdate()
        {
            try
            {
                return dataAccessLayerDao.getChoiceCodesAvailableForUpdate();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getChoiceCodesAvailableForUpdate()", "");
            }
        }
        public DataSet getChoiceCodesAvailableForDelete()
        {
            try
            {
                return dataAccessLayerDao.getChoiceCodesAvailableForDelete();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getChoiceCodesAvailableForDelete()", "");
            }
        }
        public bool insertNewChoiceCodes(string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertNewChoiceCodes(ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertNewChoiceCodes()", "");
            }
        }
        public bool updateChoiceCodes(string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateChoiceCodes(ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateChoiceCodes()", "");
            }
        }
        public bool deleteChoiceCodes(string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteChoiceCodes(ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteChoiceCodes()", "");
            }
        }
        public DataSet getInstituteListReport(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getInstituteListReport(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteListReport()", "");
            }
        }
        public DataSet getAllChoiceCodeListFromDTEPortalForInstitute(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getAllChoiceCodeListFromDTEPortalForInstitute(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllChoiceCodeListFromDTEPortalForInstitute()", "");
            }
        }
        public DataSet getInstituteHostelCapacityDetails(Int64 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.getInstituteHostelCapacityDetails(InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteHostelCapacityDetails()", "");
            }
        }
        public bool saveInstituteHostelCapacityDetails(Int64 InstituteID, Int32 BoysHostelCapacityIYear, Int32 GirlsHostelCapacityIYear, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveInstituteHostelCapacityDetails(InstituteID, BoysHostelCapacityIYear, GirlsHostelCapacityIYear, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveInstituteHostelCapacityDetails()", "");
            }
        }
        public DataSet getInstituteListHavingCourtCaseRemark()
        {
            try
            {
                return dataAccessLayerDao.getInstituteListHavingCourtCaseRemark();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteListHavingCourtCaseRemark()", "");
            }
        }
        public DataSet getChoiceCodeListByInstituteHavingCourtCaseRemark(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getChoiceCodeListByInstituteHavingCourtCaseRemark(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getChoiceCodeListByInstituteHavingCourtCaseRemark()", "");
            }
        }
        public string getInstituteName(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getInstituteName(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteName()", "");
            }
        }
        public string getCourseName(string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.getCourseName(ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCourseName()", "");
            }
        }
        public DataSet getCompositeReportForAdmin(string Flag, string Flag2)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReportForAdmin(Flag, Flag2);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReportForAdmin()", "");
            }
        }
        public DataSet getCompositeReportForRO(string RO, string Flag, string Flag2)
        {
            return dataAccessLayerDao.getCompositeReportForRO(RO, Flag, Flag2);
        }
        public DataSet getCompositeReportForInstitute(string InstituteCode, string Flag, string Flag2)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReportForInstitute(InstituteCode, Flag, Flag2);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReportForInstitute()", "");
            }
        }
        public DataSet getCompositeReport(string ChoiceCode, string ReportingStatus)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReport(ChoiceCode, ReportingStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReport()", "");
            }
        }
        public DataSet getInstituteListForAllotmentDisplay()
        {
            try
            {
                return dataAccessLayerDao.getInstituteListForAllotmentDisplay();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteListForAllotmentDisplay()", "");
            }
        }
        public DataSet getAllotmentReportForAdmin()
        {
            try
            {
                return dataAccessLayerDao.getAllotmentReportForAdmin();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentReportForAdmin()", "");
            }
        }
        public DataSet getAllotmentReportForRO(string RO)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentReportForRO(RO);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentReportForRO()", "");
            }
        }
        public DataSet getAllotmentReportForInstitute(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentReportForInstitute(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentReportForInstitute()", "");
            }
        }
        public DataSet getAllotmentReport(string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentReport(ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentReport()", "");
            }
        }
        public DataSet getInvalidSeatSurrenderList()
        {
            try
            {
                return dataAccessLayerDao.getInvalidSeatSurrenderList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInvalidSeatSurrenderList()", "");
            }
        }
        public string isCandidateAllottedThisInstitute(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateAllottedThisInstitute(PID, UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateAllottedThisInstitute()", "");
            }
        }
        public bool isCandidateReportedToARC(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateReportedToARC(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateReportedToARC()", "");
            }
        }
        public DataSet getPersonalInformationForInstitute(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPersonalInformationForInstitute(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPersonalInformationForInstitute()", "");
            }
        }
        public DataSet getReportingDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getReportingDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReportingDetails()", "");
            }
        }
        public DataSet getDocumentListForInstitute(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getDocumentListForInstitute(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getDocumentListForInstitute()", "");
            }
        }
        public DataSet getInstituteFeeList(Int64 PID, string FeeType, string InstituteCode, string AdmissionPhase)
        {
            try
            {
                return dataAccessLayerDao.getInstituteFeeList(PID, FeeType, InstituteCode, AdmissionPhase);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteFeeList()", "");
            }
        }
        public DataSet getInstituteFeeDetails(Int64 FeeID)
        {
            try
            {
                return dataAccessLayerDao.getInstituteFeeDetails(FeeID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteFeeDetails()", "");
            }
        }
        public Int32 saveInstituteFeeDetails(InstituteFeeDetails obj, string CreatedBy, string CreatedByIPAddress, string AdmissionPhase)
        {
            try
            {
                return dataAccessLayerDao.saveInstituteFeeDetails(obj, CreatedBy, CreatedByIPAddress, AdmissionPhase);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveInstituteFeeDetails()", "");
            }
        }
        public Int32 editInstituteFeeDetails(InstituteFeeDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editInstituteFeeDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editInstituteFeeDetails()", "");
            }
        }
        public bool deleteInstituteFeeDetails(Int64 FeeID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteInstituteFeeDetails(FeeID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteInstituteFeeDetails()", "");
            }
        }
        public bool updateDocumentSubmissionForInstitute(Int64 PID, string XMLString, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateDocumentSubmissionForInstitute(PID, XMLString, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateDocumentSubmissionForInstitute()", "");
            }
        }
        public bool confirmAdmission(Int64 PID, DateTime AdmissionDate, string Comments, string ReportedBy, string ReportedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmAdmission(PID, AdmissionDate, Comments, ReportedBy, ReportedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmAdmission()", "");
            }
        }
        public DataSet getReportingDetails(Int64 PID, char ReportingStatus)
        {
            try
            {
                return dataAccessLayerDao.getReportingDetails(PID, ReportingStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReportingDetails()", "");
            }
        }
        public DataSet getDocumentListForInstitute(Int64 PID, string SubmittedFlag)
        {
            try
            {
                return dataAccessLayerDao.getDocumentListForInstitute(PID, SubmittedFlag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getDocumentListForInstitute()", "");
            }
        }
        public bool editAdmission(Int64 PID, DateTime AdmissionDate, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editAdmission(PID, AdmissionDate, Comments, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editAdmission()", "");
            }
        }
        public bool cancelAdmission(Int64 PID, Int64 CancellationCharge, string ReasonForCancellation, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelAdmission(PID, CancellationCharge, ReasonForCancellation, CancelledBy, CancelledByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelAdmission()", "");
            }
        }
        public bool editCancelAdmission(Int64 PID, Int64 CancellationCharge, string ReasonForCancellation, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editCancelAdmission(PID, CancellationCharge, ReasonForCancellation, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editCancelAdmission()", "");
            }
        }
        public bool IsAdmissionConfirmedAtInstitute(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.IsAdmissionConfirmedAtInstitute(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "IsAdmissionConfirmedAtInstitute()", "");
            }
        }
        public bool isCandidateAdmittedInThisInstitute(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateAdmittedInThisInstitute(PID, ChoiceCode, CAPRound, UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateAdmittedInThisInstitute()", "");
            }
        }

        public string isCandidateAllottedThisInstituteCAPRound5(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateAllottedThisInstituteCAPRound5(PID, UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateAllottedThisInstituteCAPRound5()", "");
            }
        }
        public DataSet getReportingDetailsCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getReportingDetailsCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReportingDetailsCAPRound5()", "");
            }
        }
        public bool confirmAdmissionCAPRound5(Int64 PID, DateTime AdmissionDate, string Comments, string ReportedBy, string ReportedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmAdmissionCAPRound5(PID, AdmissionDate, Comments, ReportedBy, ReportedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmAdmissionCAPRound5()", "");
            }
        }
        public string isCandidateAllottedThisInstituteByReportingStatus(Int64 PID, Int32 UserTypeID, string UserLoginID, char ReportingStatus)
        {
            try
            {
                return dataAccessLayerDao.isCandidateAllottedThisInstituteByReportingStatus(PID, UserTypeID, UserLoginID, ReportingStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateAllottedThisInstituteByReportingStatus()", "");
            }
        }
        public string isCandidateAllottedThisInstituteByCAPRound(Int64 PID, Int32 UserTypeID, string UserLoginID, string Flag)
        {
            try
            {
                return dataAccessLayerDao.isCandidateAllottedThisInstituteByCAPRound(PID, UserTypeID, UserLoginID, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateAllottedThisInstituteByCAPRound()", "");
            }
        }
        public DataSet getReportingDetailsByCAPRound(Int64 PID, string Flag)
        {
            try
            {
                return dataAccessLayerDao.getReportingDetailsByCAPRound(PID, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReportingDetailsByCAPRound()", "");
            }
        }
        public bool confirmAdmissionByCAPRound(Int64 PID, DateTime AdmissionDate, string Comments, string ReportedBy, string ReportedByIPAddress, string Flag)
        {
            try
            {
                return dataAccessLayerDao.confirmAdmissionByCAPRound(PID, AdmissionDate, Comments, ReportedBy, ReportedByIPAddress, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmAdmissionByCAPRound()", "");
            }
        }
        public DataSet getReportingDetailsByChoiceCode(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, char ReportingStatus)
        {
            try
            {
                return dataAccessLayerDao.getReportingDetailsByChoiceCode(PID, ChoiceCode, CAPRound, ReportingStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReportingDetailsByChoiceCode()", "");
            }
        }
        public bool confirmAdmissionByChoiceCode(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, DateTime AdmissionDate, string Comments, string ReportedBy, string ReportedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmAdmissionByChoiceCode(PID, ChoiceCode, CAPRound, AdmissionDate, Comments, ReportedBy, ReportedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmAdmissionByChoiceCode()", "");
            }
        }
        public bool editAdmissionByChoiceCode(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, DateTime AdmissionDate, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editAdmissionByChoiceCode(PID, ChoiceCode, CAPRound, AdmissionDate, Comments, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editAdmissionByChoiceCode()", "");
            }
        }
        public bool cancelAdmissionByChoiceCode(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, Int64 CancellationCharge, string ReasonForCancellation, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelAdmissionByChoiceCode(PID, ChoiceCode, CAPRound, CancellationCharge, ReasonForCancellation, CancelledBy, CancelledByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelAdmissionByChoiceCode()", "");
            }
        }
        public bool editCancelAdmissionByChoiceCode(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, Int64 CancellationCharge, string ReasonForCancellation, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editCancelAdmissionByChoiceCode(PID, ChoiceCode, CAPRound, CancellationCharge, ReasonForCancellation, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editCancelAdmissionByChoiceCode()", "");
            }
        }

        public bool isCandidateEligibleForAdmissionAtIL(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateEligibleForAdmissionAtIL(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateEligibleForAdmissionAtIL()", "");
            }
        }
        public bool isCandidateEligibleForAdmission(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateEligibleForAdmission(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateEligibleForAdmission()", "");
            }
        }
        public string getAdmissionDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getAdmissionDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdmissionDetails()", "");
            }
        }
        public string isCandidateAllottedThisInstituteIL(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateAllottedThisInstituteIL(PID, UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateAllottedThisInstituteIL()", "");
            }
        }
        public DataSet getInstituteListForAdmissionAtIL(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getInstituteListForAdmissionAtIL(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteListForAdmissionAtIL()", "");
            }
        }
        public DataSet getChoiceCodeListByInstituteForAdmissionAtIL(Int64 PID, string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getChoiceCodeListByInstituteForAdmissionAtIL(PID, InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getChoiceCodeListByInstituteForAdmissionAtIL()", "");
            }
        }
        public DataSet getAllChoiceCodeListByInstituteForAdmissionAtIL(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getAllChoiceCodeListByInstituteForAdmissionAtIL(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllChoiceCodeListByInstituteForAdmissionAtIL()", "");
            }
        }
        public DataSet getSeatTypeListForAdmissionAtIL(string InstituteCode)
        {
            try
            {
                return dataAccessLayerDao.getSeatTypeListForAdmissionAtIL(InstituteCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSeatTypeListForAdmissionAtIL()", "");
            }
        }
        public bool confirmAdmissionAtIL(Int64 PID, Int64 ChoiceCode, string SeatType, Int32 MeritNo, DateTime AdmissionDate, string Comments, string ReportedBy, string ReportedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmAdmissionAtIL(PID, ChoiceCode, SeatType, MeritNo, AdmissionDate, Comments, ReportedBy, ReportedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmAdmissionAtIL()", "");
            }
        }
        public bool editAdmissionAtIL(Int64 PID, Int64 ChoiceCode, string SeatType, Int32 MeritNo, DateTime AdmissionDate, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editAdmissionAtIL(PID, ChoiceCode, SeatType, MeritNo, AdmissionDate, Comments, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editAdmissionAtIL()", "");
            }
        }
        public bool cancelAdmissionAtIL(Int64 PID, Int64 ChoiceCode, Int64 CancellationCharge, string ReasonForCancellation, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelAdmissionAtIL(PID, ChoiceCode, CancellationCharge, ReasonForCancellation, CancelledBy, CancelledByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelAdmissionAtIL()", "");
            }
        }
        public bool editCancelAdmissionAtIL(Int64 PID, Int64 ChoiceCode, Int64 CancellationCharge, string ReasonForCancellation, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editCancelAdmissionAtIL(PID, ChoiceCode, CancellationCharge, ReasonForCancellation, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editCancelAdmissionAtIL()", "");
            }
        }
        public DataSet getReportingDetailsAtIL(Int64 PID, Int64 ChoiceCode, char ReportingStatus)
        {
            try
            {
                return dataAccessLayerDao.getReportingDetailsAtIL(PID, ChoiceCode, ReportingStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReportingDetailsAtIL()", "");
            }
        }
        public DataSet getReportingDetailsAtIL(Int64 PID, char ReportingStatus, Int32 UserTypeID, string UserLoginID, string Flag, string Code)
        {
            try
            {
                return dataAccessLayerDao.getReportingDetailsAtIL(PID, ReportingStatus, UserTypeID, UserLoginID, Flag, Code);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReportingDetailsAtIL()", "");
            }
        }
        public DataSet getReportingDetailsAtCAP(Int64 PID, char ReportingStatus, Int32 UserTypeID, string UserLoginID, string Flag, string Code)
        {
            try
            {
                return dataAccessLayerDao.getReportingDetailsAtCAP(PID, ReportingStatus, UserTypeID, UserLoginID, Flag, Code);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReportingDetailsAtCAP()", "");
            }
        }

        public DataSet getCandidateDetailsForDisplayInOptionForm(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCandidateDetailsForDisplayInOptionForm(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateDetailsForDisplayInOptionForm()", "");
            }
        }
        public DataSet getCourseListByPID(Int32 CAPRound, Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCourseListByPID(CAPRound, PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCourseListByPID()", "");
            }
        }
        public DataSet getUniversityListByPID(Int32 CAPRound, Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getUniversityListByPID(CAPRound, PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getUniversityListByPID()", "");
            }
        }
        public DataSet getInstituteListByUniversityID(Int32 CAPRound, Int64 PID, Int16 UniversityID)
        {
            try
            {
                return dataAccessLayerDao.getInstituteListByUniversityID(CAPRound, PID, UniversityID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstituteListByUniversityID()", "");
            }
        }
        public DataSet getChoiceCodeListByInstituteID(Int32 CAPRound, Int64 PID, Int32 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.getChoiceCodeListByInstituteID(CAPRound, PID, InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getChoiceCodeListByInstituteID()", "");
            }
        }
        public DataSet getCancelledOptionFormReport(Int32 UserTypeID, string UserLoginID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getCancelledOptionFormReport(UserTypeID, UserLoginID, CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCancelledOptionFormReport()", "");
            }
        }
        public Int64 authenticateApplicationIDnDOB(string ApplicationID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.authenticateApplicationIDnDOB(ApplicationID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "authenticateApplicationIDnDOB()", "");
            }
        }
        public DataSet getChangeEligibilityReport(Int32 UserTypeID, string UserLoginID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getChangeEligibilityReport(UserTypeID, UserLoginID, CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getChangeEligibilityReport()", "");
            }
        }
        public DataSet verifyChoiceCode(Int32 CAPRound, Int64 PID, string ChoiceCodeDisplay)
        {
            try
            {
                return dataAccessLayerDao.verifyChoiceCode(CAPRound, PID, ChoiceCodeDisplay);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "verifyChoiceCode()", "");
            }
        }

        public DataSet getCurrentLinkCAPRound1(Int64 PID, string URL)
        {
            try
            {
                return dataAccessLayerDao.getCurrentLinkCAPRound1(PID, URL);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCurrentLinkCAPRound1()", "");
            }
        }
        public DataSet getCandidateStepListCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCandidateStepListCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateStepListCAPRound1()", "");
            }
        }
        public DataSet getSelectedOptionsListCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSelectedOptionsListCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSelectedOptionsListCAPRound1()", "");
            }
        }
        public DataSet getOptionsListCAPRound1(Int64 PID, string CourseCode, Int16 UniversityID, string DistrictName, string CourseStatus1, string CourseStatus2, string CourseStatus3, string TFWSStatus)
        {
            try
            {
                return dataAccessLayerDao.getOptionsListCAPRound1(PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3, TFWSStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionsListCAPRound1()", "");
            }
        }
        public Int32 saveOptionsCAPRound1(Int64 PID, string OptionsList, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveOptionsCAPRound1(PID, OptionsList, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveOptionsCAPRound1()", "");
            }
        }
        public Int32 deleteOptionsCAPRound1(Int64 PID, string OptionsList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteOptionsCAPRound1(PID, OptionsList, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteOptionsCAPRound1()", "");
            }
        }
        public Int32 saveShortlistedOptionsCAPRound1(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveShortlistedOptionsCAPRound1(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveShortlistedOptionsCAPRound1()", "");
            }
        }
        public bool checkPreferenceNoCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.checkPreferenceNoCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkPreferenceNoCAPRound1()", "");
            }
        }
        public Int32 savePreferencesCAPRound1(Int64 PID, string PreferencesList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.savePreferencesCAPRound1(PID, PreferencesList, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "savePreferencesCAPRound1()", "");
            }
        }
        public DataSet getPreferancedOptionsListCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferancedOptionsListCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListCAPRound1()", "");
            }
        }
        public Int32 getPreferencesCountCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferencesCountCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferencesCountCAPRound1()", "");
            }
        }
        public Int32 insertOptionCAPRound1(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionCAPRound1(PID, PreferenceNo, ChoiceCode, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionCAPRound1()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound1(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionDirectCAPRound1(PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionDirectCAPRound1()", "");
            }
        }
        public Int32 moveOptionCAPRound1(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.moveOptionCAPRound1(PID, PreferenceNo, ChoiceCode, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "moveOptionCAPRound1()", "");
            }
        }
        public Int32 confirmOptionFormCAPRound1(Int64 PID, string CandidatePassword, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmOptionFormCAPRound1(PID, CandidatePassword, ConfirmedBy, ConfirmedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmOptionFormCAPRound1()", "");
            }
        }
        public DataSet getPersonalInformationCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPersonalInformationCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPersonalInformationCAPRound1()", "");
            }
        }
        public DataSet getPreferancedOptionsListForDisplayCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferancedOptionsListForDisplayCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListForDisplayCAPRound1()", "");
            }
        }
        public DataSet getInstructionsCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getInstructionsCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstructionsCAPRound1()", "");
            }
        }
        public DataSet getOptionFormConfirmationDetailsCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getOptionFormConfirmationDetailsCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionFormConfirmationDetailsCAPRound1()", "");
            }
        }
        public bool isOptionFormConfirmedCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOptionFormConfirmedCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOptionFormConfirmedCAPRound1()", "");
            }
        }
        public bool cancelOptionFormCAPRound1(Int64 PID, String Comments, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelOptionFormCAPRound1(PID, Comments, CancelledBy, CancelledByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelOptionFormCAPRound1()", "");
            }
        }
        public bool isCandidateEligibleCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateEligibleCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateEligibleCAPRound1()", "");
            }
        }
        public bool changeCandidateEligibilityCAPRound1(Int64 PID, Int32 EligibilityStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.changeCandidateEligibilityCAPRound1(PID, EligibilityStatus, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "changeCandidateEligibilityCAPRound1()", "");
            }
        }
        public bool isOptionFormCancelledBeforeCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOptionFormCancelledBeforeCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOptionFormCancelledBeforeCAPRound1()", "");
            }
        }
        public bool saveOptionFormSummaryStepIDCAPRound1(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveOptionFormSummaryStepIDCAPRound1(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveOptionFormSummaryStepIDCAPRound1()", "");
            }
        }
        public string getInvalidChoiceCodeListCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getInvalidChoiceCodeListCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInvalidChoiceCodeListCAPRound1()", "");
            }
        }
        public bool isCandidateSelectedOptionsCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateSelectedOptionsCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateSelectedOptionsCAPRound1()", "");
            }
        }

        public DataSet getAllotmentStatusCAPRound1(string ApplicationID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentStatusCAPRound1(ApplicationID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentStatusCAPRound1()", "");
            }
        }
        public DataSet getAllotmentListCAPRound1()
        {
            try
            {
                return dataAccessLayerDao.getAllotmentListCAPRound1();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentListCAPRound1()", "");
            }
        }
        public DataSet getAllotmentStatusCAPRound2(string ApplicationID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentStatusCAPRound2(ApplicationID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentStatusCAPRound2()", "");
            }
        }
        public DataSet getAllotmentListCAPRound2()
        {
            try
            {
                return dataAccessLayerDao.getAllotmentListCAPRound2();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentListCAPRound2()", "");
            }
        }
        public DataSet getAllotmentStatusCAPRound3(string ApplicationID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentStatusCAPRound3(ApplicationID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentStatusCAPRound3()", "");
            }
        }
        public DataSet getAllotmentListCAPRound3()
        {
            try
            {
                return dataAccessLayerDao.getAllotmentListCAPRound3();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentListCAPRound3()", "");
            }
        }
        public DataSet getAllotmentStatusCAPRound4(string ApplicationID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentStatusCAPRound4(ApplicationID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentStatusCAPRound4()", "");
            }
        }
        public DataSet getAllotmentListCAPRound4()
        {
            try
            {
                return dataAccessLayerDao.getAllotmentListCAPRound4();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentListCAPRound4()", "");
            }
        }
        public DataSet getFinalAllotmentStatus(string ApplicationID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.getFinalAllotmentStatus(ApplicationID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getFinalAllotmentStatus()", "");
            }
        }
        public DataSet getFinalAllotmentList()
        {
            try
            {
                return dataAccessLayerDao.getFinalAllotmentList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getFinalAllotmentList()", "");
            }
        }
        public DataSet getAllotmentStatusCAPRound5(string ApplicationID, DateTime DOB)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentStatusCAPRound5(ApplicationID, DOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentStatusCAPRound5()", "");
            }
        }
        public DataSet getAllotmentListCAPRound5()
        {
            try
            {
                return dataAccessLayerDao.getAllotmentListCAPRound5();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentListCAPRound5()", "");
            }
        }

        public DataSet getImportOptionsFromCAPRound1(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getImportOptionsFromCAPRound1(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getImportOptionsFromCAPRound1()", "");
            }
        }
        public bool importOptionsFromCAPRound1(Int64 PID, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.importOptionsFromCAPRound1(PID, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "importOptionsFromCAPRound1()", "");
            }
        }
        public DataSet getCurrentLinkCAPRound2(Int64 PID, string URL)
        {
            try
            {
                return dataAccessLayerDao.getCurrentLinkCAPRound2(PID, URL);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCurrentLinkCAPRound2()", "");
            }
        }
        public DataSet getCandidateStepListCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCandidateStepListCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateStepListCAPRound2()", "");
            }
        }
        public DataSet getSelectedOptionsListCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSelectedOptionsListCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSelectedOptionsListCAPRound2()", "");
            }
        }
        public DataSet getOptionsListCAPRound2(Int64 PID, string CourseCode, Int16 UniversityID, string DistrictName, string CourseStatus1, string CourseStatus2, string CourseStatus3, string TFWSStatus)
        {
            try
            {
                return dataAccessLayerDao.getOptionsListCAPRound2(PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3, TFWSStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionsListCAPRound2()", "");
            }
        }
        public Int32 saveOptionsCAPRound2(Int64 PID, string OptionsList, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveOptionsCAPRound2(PID, OptionsList, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveOptionsCAPRound2()", "");
            }
        }
        public Int32 deleteOptionsCAPRound2(Int64 PID, string OptionsList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteOptionsCAPRound2(PID, OptionsList, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteOptionsCAPRound2()", "");
            }
        }
        public Int32 saveShortlistedOptionsCAPRound2(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveShortlistedOptionsCAPRound2(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveShortlistedOptionsCAPRound2()", "");
            }
        }
        public bool checkPreferenceNoCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.checkPreferenceNoCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkPreferenceNoCAPRound2()", "");
            }
        }
        public Int32 savePreferencesCAPRound2(Int64 PID, string PreferencesList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.savePreferencesCAPRound2(PID, PreferencesList, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "savePreferencesCAPRound2()", "");
            }
        }
        public DataSet getPreferancedOptionsListCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferancedOptionsListCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListCAPRound2()", "");
            }
        }
        public Int32 getPreferencesCountCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferencesCountCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferencesCountCAPRound2()", "");
            }
        }
        public Int32 insertOptionCAPRound2(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionCAPRound2(PID, PreferenceNo, ChoiceCode, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionCAPRound2()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound2(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionDirectCAPRound2(PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionDirectCAPRound2()", "");
            }
        }
        public Int32 moveOptionCAPRound2(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.moveOptionCAPRound2(PID, PreferenceNo, ChoiceCode, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "moveOptionCAPRound2()", "");
            }
        }
        public Int32 confirmOptionFormCAPRound2(Int64 PID, string CandidatePassword, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmOptionFormCAPRound2(PID, CandidatePassword, ConfirmedBy, ConfirmedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmOptionFormCAPRound2()", "");
            }
        }
        public DataSet getPersonalInformationCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPersonalInformationCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPersonalInformationCAPRound2()", "");
            }
        }
        public DataSet getPreferancedOptionsListForDisplayCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferancedOptionsListForDisplayCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListForDisplayCAPRound2()", "");
            }
        }
        public DataSet Getreceiptcandidates(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.Getreceiptcandidates(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListForDisplayCAPRound2()", "");
            }
        }
        public DataSet getInstructionsCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getInstructionsCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstructionsCAPRound2()", "");
            }
        }
        public DataSet getOptionFormConfirmationDetailsCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getOptionFormConfirmationDetailsCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionFormConfirmationDetailsCAPRound2()", "");
            }
        }
        public bool isOptionFormConfirmedCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOptionFormConfirmedCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOptionFormConfirmedCAPRound2()", "");
            }
        }
        public bool cancelOptionFormCAPRound2(Int64 PID, String Comments, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelOptionFormCAPRound2(PID, Comments, CancelledBy, CancelledByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelOptionFormCAPRound2()", "");
            }
        }
        public bool isCandidateEligibleCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateEligibleCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateEligibleCAPRound2()", "");
            }
        }
        public bool changeCandidateEligibilityCAPRound2(Int64 PID, Int32 EligibilityStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.changeCandidateEligibilityCAPRound2(PID, EligibilityStatus, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "changeCandidateEligibilityCAPRound2()", "");
            }
        }
        public bool isOptionFormCancelledBeforeCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOptionFormCancelledBeforeCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOptionFormCancelledBeforeCAPRound2()", "");
            }
        }
        public bool saveOptionFormSummaryStepIDCAPRound2(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveOptionFormSummaryStepIDCAPRound2(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveOptionFormSummaryStepIDCAPRound2()", "");
            }
        }
        public string getInvalidChoiceCodeListCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getInvalidChoiceCodeListCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInvalidChoiceCodeListCAPRound2()", "");
            }
        }
        public bool isCandidateSelectedOptionsCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateSelectedOptionsCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateSelectedOptionsCAPRound2()", "");
            }
        }

        public DataSet getImportOptionsFromCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getImportOptionsFromCAPRound2(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getImportOptionsFromCAPRound2()", "");
            }
        }
        public bool importOptionsFromCAPRound2(Int64 PID, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.importOptionsFromCAPRound2(PID, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "importOptionsFromCAPRound2()", "");
            }
        }
        public DataSet getCurrentLinkCAPRound3(Int64 PID, string URL)
        {
            try
            {
                return dataAccessLayerDao.getCurrentLinkCAPRound3(PID, URL);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCurrentLinkCAPRound3()", "");
            }
        }
        public DataSet getCandidateStepListCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCandidateStepListCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateStepListCAPRound3()", "");
            }
        }
        public DataSet getSelectedOptionsListCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSelectedOptionsListCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSelectedOptionsListCAPRound3()", "");
            }
        }
        public DataSet getOptionsListCAPRound3(Int64 PID, string CourseCode, Int16 UniversityID, string DistrictName, string CourseStatus1, string CourseStatus2, string CourseStatus3, string TFWSStatus)
        {
            try
            {
                return dataAccessLayerDao.getOptionsListCAPRound3(PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3, TFWSStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionsListCAPRound3()", "");
            }
        }
        public Int32 saveOptionsCAPRound3(Int64 PID, string OptionsList, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveOptionsCAPRound3(PID, OptionsList, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveOptionsCAPRound3()", "");
            }
        }
        public Int32 deleteOptionsCAPRound3(Int64 PID, string OptionsList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteOptionsCAPRound3(PID, OptionsList, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteOptionsCAPRound3()", "");
            }
        }
        public Int32 saveShortlistedOptionsCAPRound3(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveShortlistedOptionsCAPRound3(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveShortlistedOptionsCAPRound3()", "");
            }
        }
        public bool checkPreferenceNoCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.checkPreferenceNoCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkPreferenceNoCAPRound3()", "");
            }
        }
        public Int32 savePreferencesCAPRound3(Int64 PID, string PreferencesList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.savePreferencesCAPRound3(PID, PreferencesList, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "savePreferencesCAPRound3()", "");
            }
        }
        public DataSet getPreferancedOptionsListCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferancedOptionsListCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListCAPRound3()", "");
            }
        }
        public Int32 getPreferencesCountCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferencesCountCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferencesCountCAPRound3()", "");
            }
        }
        public Int32 insertOptionCAPRound3(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionCAPRound3(PID, PreferenceNo, ChoiceCode, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionCAPRound3()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound3(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionDirectCAPRound3(PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionDirectCAPRound3()", "");
            }
        }
        public Int32 moveOptionCAPRound3(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.moveOptionCAPRound3(PID, PreferenceNo, ChoiceCode, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "moveOptionCAPRound3()", "");
            }
        }
        public Int32 confirmOptionFormCAPRound3(Int64 PID, string CandidatePassword, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmOptionFormCAPRound3(PID, CandidatePassword, ConfirmedBy, ConfirmedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmOptionFormCAPRound3()", "");
            }
        }
        public DataSet getPersonalInformationCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPersonalInformationCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPersonalInformationCAPRound3()", "");
            }
        }
        public DataSet getPreferancedOptionsListForDisplayCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferancedOptionsListForDisplayCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListForDisplayCAPRound3()", "");
            }
        }
        public DataSet getInstructionsCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getInstructionsCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstructionsCAPRound3()", "");
            }
        }
        public DataSet getOptionFormConfirmationDetailsCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getOptionFormConfirmationDetailsCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionFormConfirmationDetailsCAPRound3()", "");
            }
        }
        public bool isOptionFormConfirmedCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOptionFormConfirmedCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOptionFormConfirmedCAPRound3()", "");
            }
        }
        public bool cancelOptionFormCAPRound3(Int64 PID, String Comments, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelOptionFormCAPRound3(PID, Comments, CancelledBy, CancelledByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelOptionFormCAPRound3()", "");
            }
        }
        public bool isCandidateEligibleCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateEligibleCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateEligibleCAPRound3()", "");
            }
        }
        public bool changeCandidateEligibilityCAPRound3(Int64 PID, Int32 EligibilityStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.changeCandidateEligibilityCAPRound3(PID, EligibilityStatus, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "changeCandidateEligibilityCAPRound3()", "");
            }
        }
        public bool isOptionFormCancelledBeforeCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOptionFormCancelledBeforeCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOptionFormCancelledBeforeCAPRound3()", "");
            }
        }
        public bool saveOptionFormSummaryStepIDCAPRound3(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveOptionFormSummaryStepIDCAPRound3(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveOptionFormSummaryStepIDCAPRound3()", "");
            }
        }
        public string getInvalidChoiceCodeListCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getInvalidChoiceCodeListCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInvalidChoiceCodeListCAPRound3()", "");
            }
        }
        public bool isCandidateSelectedOptionsCAPRound3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateSelectedOptionsCAPRound3(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateSelectedOptionsCAPRound3()", "");
            }
        }

        public DataSet getCurrentLinkCAPRound4(Int64 PID, string URL)
        {
            try
            {
                return dataAccessLayerDao.getCurrentLinkCAPRound4(PID, URL);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCurrentLinkCAPRound4()", "");
            }
        }
        public DataSet getCandidateStepListCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCandidateStepListCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateStepListCAPRound4()", "");
            }
        }
        public DataSet getSelectedOptionsListCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSelectedOptionsListCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSelectedOptionsListCAPRound4()", "");
            }
        }
        public DataSet getOptionsListCAPRound4(Int64 PID, string CourseCode, Int16 UniversityID, string DistrictName, string CourseStatus1, string CourseStatus2, string CourseStatus3, string TFWSStatus)
        {
            try
            {
                return dataAccessLayerDao.getOptionsListCAPRound4(PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3, TFWSStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionsListCAPRound4()", "");
            }
        }
        public Int32 saveOptionsCAPRound4(Int64 PID, string OptionsList, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveOptionsCAPRound4(PID, OptionsList, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveOptionsCAPRound4()", "");
            }
        }
        public Int32 deleteOptionsCAPRound4(Int64 PID, string OptionsList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteOptionsCAPRound4(PID, OptionsList, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteOptionsCAPRound4()", "");
            }
        }
        public Int32 saveShortlistedOptionsCAPRound4(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveShortlistedOptionsCAPRound4(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveShortlistedOptionsCAPRound4()", "");
            }
        }
        public bool checkPreferenceNoCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.checkPreferenceNoCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkPreferenceNoCAPRound4()", "");
            }
        }
        public Int32 savePreferencesCAPRound4(Int64 PID, string PreferencesList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.savePreferencesCAPRound4(PID, PreferencesList, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "savePreferencesCAPRound4()", "");
            }
        }
        public DataSet getPreferancedOptionsListCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferancedOptionsListCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListCAPRound4()", "");
            }
        }
        public Int32 getPreferencesCountCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferencesCountCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferencesCountCAPRound4()", "");
            }
        }
        public Int32 insertOptionCAPRound4(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionCAPRound4(PID, PreferenceNo, ChoiceCode, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionCAPRound4()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound4(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionDirectCAPRound4(PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionDirectCAPRound4()", "");
            }
        }
        public Int32 moveOptionCAPRound4(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.moveOptionCAPRound4(PID, PreferenceNo, ChoiceCode, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "moveOptionCAPRound4()", "");
            }
        }
        public Int32 confirmOptionFormCAPRound4(Int64 PID, string CandidatePassword, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmOptionFormCAPRound4(PID, CandidatePassword, ConfirmedBy, ConfirmedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmOptionFormCAPRound4()", "");
            }
        }
        public DataSet getPersonalInformationCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPersonalInformationCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPersonalInformationCAPRound4()", "");
            }
        }
        public DataSet getPreferancedOptionsListForDisplayCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferancedOptionsListForDisplayCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListForDisplayCAPRound4()", "");
            }
        }
        public DataSet getInstructionsCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getInstructionsCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstructionsCAPRound4()", "");
            }
        }
        public DataSet getOptionFormConfirmationDetailsCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getOptionFormConfirmationDetailsCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionFormConfirmationDetailsCAPRound4()", "");
            }
        }
        public bool isOptionFormConfirmedCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOptionFormConfirmedCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOptionFormConfirmedCAPRound4()", "");
            }
        }
        public bool cancelOptionFormCAPRound4(Int64 PID, String Comments, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelOptionFormCAPRound4(PID, Comments, CancelledBy, CancelledByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelOptionFormCAPRound4()", "");
            }
        }
        public bool isCandidateEligibleCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateEligibleCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateEligibleCAPRound4()", "");
            }
        }
        public bool changeCandidateEligibilityCAPRound4(Int64 PID, Int32 EligibilityStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.changeCandidateEligibilityCAPRound4(PID, EligibilityStatus, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "changeCandidateEligibilityCAPRound4()", "");
            }
        }
        public bool isOptionFormCancelledBeforeCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOptionFormCancelledBeforeCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOptionFormCancelledBeforeCAPRound4()", "");
            }
        }
        public bool saveOptionFormSummaryStepIDCAPRound4(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveOptionFormSummaryStepIDCAPRound4(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveOptionFormSummaryStepIDCAPRound4()", "");
            }
        }
        public string getInvalidChoiceCodeListCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getInvalidChoiceCodeListCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInvalidChoiceCodeListCAPRound4()", "");
            }
        }
        public bool isCandidateSelectedOptionsCAPRound4(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateSelectedOptionsCAPRound4(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateSelectedOptionsCAPRound4()", "");
            }
        }

        public string getSeatAcceptanceStatus(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSeatAcceptanceStatus(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSeatAcceptanceStatus()", "");
            }
        }

        public DataSet getCandidateStepListCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCandidateStepListCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateStepListCAPRound5()", "");
            }
        }
        public DataSet getSelectedOptionsListCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSelectedOptionsListCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSelectedOptionsListCAPRound5()", "");
            }
        }
        public DataSet getOptionsListCAPRound5(Int64 PID, string CourseCode, Int16 UniversityID, string DistrictName, string CourseStatus1, string CourseStatus2, string CourseStatus3)
        {
            try
            {
                return dataAccessLayerDao.getOptionsListCAPRound5(PID, CourseCode, UniversityID, DistrictName, CourseStatus1, CourseStatus2, CourseStatus3);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionsListCAPRound5()", "");
            }
        }
        public Int32 saveOptionsCAPRound5(Int64 PID, string OptionsList, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveOptionsCAPRound5(PID, OptionsList, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveOptionsCAPRound5()", "");
            }
        }
        public Int32 deleteOptionsCAPRound5(Int64 PID, string OptionsList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteOptionsCAPRound5(PID, OptionsList, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteOptionsCAPRound5()", "");
            }
        }
        public Int32 saveShortlistedOptionsCAPRound5(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveShortlistedOptionsCAPRound5(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveShortlistedOptionsCAPRound5()", "");
            }
        }
        public bool checkPreferenceNoCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.checkPreferenceNoCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkPreferenceNoCAPRound5()", "");
            }
        }
        public Int32 savePreferencesCAPRound5(Int64 PID, string PreferencesList, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.savePreferencesCAPRound5(PID, PreferencesList, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "savePreferencesCAPRound5()", "");
            }
        }
        public DataSet getPreferancedOptionsListCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferancedOptionsListCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListCAPRound5()", "");
            }
        }
        public Int32 getPreferencesCountCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferencesCountCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferencesCountCAPRound5()", "");
            }
        }
        public Int32 insertOptionCAPRound5(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionCAPRound5(PID, PreferenceNo, ChoiceCode, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionCAPRound5()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound5(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionDirectCAPRound5(PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionDirectCAPRound5()", "");
            }
        }
        public Int32 moveOptionCAPRound5(Int64 PID, Int32 PreferenceNo, Int64 ChoiceCode, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.moveOptionCAPRound5(PID, PreferenceNo, ChoiceCode, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "moveOptionCAPRound5()", "");
            }
        }
        public Int32 confirmOptionFormCAPRound5(Int64 PID, string CandidatePassword, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmOptionFormCAPRound5(PID, CandidatePassword, ConfirmedBy, ConfirmedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmOptionFormCAPRound5()", "");
            }
        }
        public DataSet getPersonalInformationCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPersonalInformationCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPersonalInformationCAPRound5()", "");
            }
        }
        public DataSet getPreferancedOptionsListForDisplayCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPreferancedOptionsListForDisplayCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferancedOptionsListForDisplayCAPRound5()", "");
            }
        }
        public DataSet getInstructionsCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getInstructionsCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstructionsCAPRound5()", "");
            }
        }
        public DataSet getOptionFormConfirmationDetailsCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getOptionFormConfirmationDetailsCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionFormConfirmationDetailsCAPRound5()", "");
            }
        }
        public bool isOptionFormConfirmedCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOptionFormConfirmedCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOptionFormConfirmedCAPRound5()", "");
            }
        }
        public bool cancelOptionFormCAPRound5(Int64 PID, String Comments, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelOptionFormCAPRound5(PID, Comments, CancelledBy, CancelledByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelOptionFormCAPRound5()", "");
            }
        }
        public bool isCandidateEligibleCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isCandidateEligibleCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateEligibleCAPRound5()", "");
            }
        }
        public bool changeCandidateEligibilityCAPRound5(Int64 PID, Int32 EligibilityStatus, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.changeCandidateEligibilityCAPRound5(PID, EligibilityStatus, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "changeCandidateEligibilityCAPRound5()", "");
            }
        }
        public bool isOptionFormCancelledBeforeCAPRound5(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOptionFormCancelledBeforeCAPRound5(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOptionFormCancelledBeforeCAPRound5()", "");
            }
        }

        public DataSet getSeatAcceptanceFeeList(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSeatAcceptanceFeeList(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSeatAcceptanceFeeList()", "");
            }
        }
        public DataSet getSeatAcceptanceFeeList(Int64 PID, string FeeType)
        {
            try
            {
                return dataAccessLayerDao.getSeatAcceptanceFeeList(PID, FeeType);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSeatAcceptanceFeeList()", "");
            }
        }
        public DataSet getSeatAcceptanceFeeDetails(Int64 FeeID)
        {
            try
            {
                return dataAccessLayerDao.getSeatAcceptanceFeeDetails(FeeID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSeatAcceptanceFeeDetails()", "");
            }
        }
        public DataSet getSeatAcceptanceFeeDetails(Int64 PID, string FeeType, string FeeLockStatus)
        {
            try
            {
                return dataAccessLayerDao.getSeatAcceptanceFeeDetails(PID, FeeType, FeeLockStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSeatAcceptanceFeeDetails()", "");
            }
        }
        public bool saveSeatAcceptanceFeeDetails(Int64 PID, SeatAcceptanceFeeDetails obj, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveSeatAcceptanceFeeDetails(PID, obj, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveSeatAcceptanceFeeDetails()", "");
            }
        }
        public bool editSeatAcceptanceFeeDetails(SeatAcceptanceFeeDetails obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editSeatAcceptanceFeeDetails(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editSeatAcceptanceFeeDetails()", "");
            }
        }
        public string getSeatAcceptanceConfirmationStatus(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSeatAcceptanceConfirmationStatus(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSeatAcceptanceConfirmationStatus()", "");
            }
        }
        public DataSet getPersonalInformationForAllotmentDisplay(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPersonalInformationForAllotmentDisplay(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPersonalInformationForAllotmentDisplay()", "");
            }
        }
        public DataSet getAllotmentDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentDetails()", "");
            }
        }
        public bool isEligibleForSeatAcceptance(Int64 PID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.isEligibleForSeatAcceptance(PID, CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isEligibleForSeatAcceptance()", "");
            }
        }
        public DataSet getSeatAcceptanceStatusDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSeatAcceptanceStatusDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSeatAcceptanceStatusDetails()", "");
            }
        }
        public DataSet getOptionsListAvailableForBetterment(Int64 PID, Int32 CAPRound, string SeatAcceptanceStatus)
        {
            try
            {
                return dataAccessLayerDao.getOptionsListAvailableForBetterment(PID, CAPRound, SeatAcceptanceStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOptionsListAvailableForBetterment()", "");
            }
        }
        public Int32 getPreferenceNoAllotted(Int64 PID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getPreferenceNoAllotted(PID, CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPreferenceNoAllotted()", "");
            }
        }
        public bool saveSeatAcceptanceStatusDetails(Int64 PID, string SeatAcceptanceStatus, Int32 CAPRound, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveSeatAcceptanceStatusDetails(PID, SeatAcceptanceStatus, CAPRound, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveSeatAcceptanceStatusDetails()", "");
            }
        }
        public bool editSeatAcceptanceStatusDetails(Int64 PID, string SeatAcceptanceStatus, Int32 CAPRound, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editSeatAcceptanceStatusDetails(PID, SeatAcceptanceStatus, CAPRound, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editSeatAcceptanceStatusDetails()", "");
            }
        }
        public Int32 getSeatAcceptanceFeePaidAmount(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSeatAcceptanceFeePaidAmount(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSeatAcceptanceFeePaidAmount()", "");
            }
        }

        public Int64 checkSeatAcceptanceStatus(string ApplicationID, Int32 VersionNo, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.checkSeatAcceptanceStatus(ApplicationID, VersionNo, CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkSeatAcceptanceStatus()", "");
            }
        }
        public bool confirmSeatAcceptanceForm(Int64 PID, string XMLString, string ReportingComments, Int32 ReportedCAPRound, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.confirmSeatAcceptanceForm(PID, XMLString, ReportingComments, ReportedCAPRound, ConfirmedBy, ConfirmedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "confirmSeatAcceptanceForm()", "");
            }
        }
        public bool isSeatAcceptanceFormConfirmed(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isSeatAcceptanceFormConfirmed(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isSeatAcceptanceFormConfirmed()", "");
            }
        }
        public bool checkSeatAcceptanceFormConfirmationDetails(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.checkSeatAcceptanceFormConfirmationDetails(PID, UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkSeatAcceptanceFormConfirmationDetails()", "");
            }
        }
        public bool cancelSeatAcceptanceForm(Int64 PID, string ReasonForCancellation, string CancelledChequeFilePath, string AccountNumber, string IFSCCode, string CancelledBy, string CancelledByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelSeatAcceptanceForm(PID, ReasonForCancellation, CancelledChequeFilePath, AccountNumber, IFSCCode, CancelledBy, CancelledByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelSeatAcceptanceForm()", "");
            }
        }
        public bool isSeatAcceptanceFormCancelled(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isSeatAcceptanceFormCancelled(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isSeatAcceptanceFormCancelled()", "");
            }
        }
        public DataSet getRegionWiseARCReport()
        {
            try
            {
                return dataAccessLayerDao.getRegionWiseARCReport();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRegionWiseARCReport()", "");
            }
        }
        public Int16 getARCRegionID(Int64 ARCID)
        {
            try
            {
                return dataAccessLayerDao.getARCRegionID(ARCID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARCRegionID()", "");
            }
        }
        public DataSet getARCWiseReport(Int16 RegionID)
        {
            try
            {
                return dataAccessLayerDao.getARCWiseReport(RegionID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARCWiseReport()", "");
            }
        }
        public Int32 getARCInstituteID(Int64 ARCID)
        {
            try
            {
                return dataAccessLayerDao.getARCInstituteID(ARCID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARCInstituteID()", "");
            }
        }
        public DataSet getSubARCWiseReport(Int16 RegionID, Int32 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.getSubARCWiseReport(RegionID, InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSubARCWiseReport()", "");
            }
        }
        public DataSet getARCConfirmationDateList()
        {
            try
            {
                return dataAccessLayerDao.getARCConfirmationDateList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARCConfirmationDateList()", "");
            }
        }
        public DataSet getARCConfirmedCandidateList(Int16 RegionID, Int32 InstituteID, Int32 ARCID, string ConfirmationDate)
        {
            try
            {
                return dataAccessLayerDao.getARCConfirmedCandidateList(RegionID, InstituteID, ARCID, ConfirmationDate);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARCConfirmedCandidateList()", "");
            }
        }
        public string getAllotmentCancellationRemark(Int64 PID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentCancellationRemark(PID, CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentCancellationRemark()", "");
            }
        }
        public bool saveAllotmentCancellationRemark(Int64 PID, Int32 CAPRound, string CancellationRemark, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveAllotmentCancellationRemark(PID, CAPRound, CancellationRemark, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveAllotmentCancellationRemark()", "");
            }
        }

        public bool isEligibleForJKCounseling(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isEligibleForJKCounseling(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isEligibleForJKCounseling()", "");
            }
        }
        public bool isSeatOfferedForJKCounseling(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isSeatOfferedForJKCounseling(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isSeatOfferedForJKCounseling()", "");
            }
        }
        public bool isOfferedSeatCancelledForJKCounseling(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOfferedSeatCancelledForJKCounseling(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOfferedSeatCancelledForJKCounseling()", "");
            }
        }
        public DataSet getPersonalInformationForJKCounseling(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getPersonalInformationForJKCounseling(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getPersonalInformationForJKCounseling()", "");
            }
        }
        public DataSet getChoiceCodeListForJKCounseling(Int64 PID, string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.getChoiceCodeListForJKCounseling(PID, ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getChoiceCodeListForJKCounseling()", "");
            }
        }
        public bool offerSeatForJKCounseling(Int64 PID, string ChoiceCodeOffered, string Comments, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.offerSeatForJKCounseling(PID, ChoiceCodeOffered, Comments, ConfirmedBy, ConfirmedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "offerSeatForJKCounseling()", "");
            }
        }
        public DataSet getOfferedSeatDetailsForJKCounseling(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getOfferedSeatDetailsForJKCounseling(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOfferedSeatDetailsForJKCounseling()", "");
            }
        }
        public bool editOfferedSeatForJKCounseling(Int64 PID, string ChoiceCodeOffered, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editOfferedSeatForJKCounseling(PID, ChoiceCodeOffered, Comments, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editOfferedSeatForJKCounseling()", "");
            }
        }
        public bool cancelOfferedSeatForJKCounseling(Int64 PID, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.cancelOfferedSeatForJKCounseling(PID, Comments, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "cancelOfferedSeatForJKCounseling()", "");
            }
        }
        public DataSet getOfferedSeatCancellationDetailsForJKCounseling(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getOfferedSeatCancellationDetailsForJKCounseling(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOfferedSeatCancellationDetailsForJKCounseling()", "");
            }
        }
        public DataSet getOfferedSeatReportForJKCounseling(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getOfferedSeatReportForJKCounseling(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOfferedSeatReportForJKCounseling()", "");
            }
        }
        public DataSet getOfferedSeatCancellationReportForJKCounseling(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getOfferedSeatCancellationReportForJKCounseling(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOfferedSeatCancellationReportForJKCounseling()", "");
            }
        }
        public DataSet getVacantInstituteListForJKCounseling()
        {
            try
            {
                return dataAccessLayerDao.getVacantInstituteListForJKCounseling();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getVacantInstituteListForJKCounseling()", "");
            }
        }
        public string getTotalVacancyForJKCounseling()
        {
            try
            {
                return dataAccessLayerDao.getTotalVacancyForJKCounseling();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getTotalVacancyForJKCounseling()", "");
            }
        }
        public DataSet getMeritListForJKCounseling()
        {
            try
            {
                return dataAccessLayerDao.getMeritListForJKCounseling();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMeritListForJKCounseling()", "");
            }
        }
        public DataSet getAllotmentCancellationRemarkReport()
        {
            try
            {
                return dataAccessLayerDao.getAllotmentCancellationRemarkReport();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentCancellationRemarkReport()", "");
            }
        }

        public DataSet getGroupByListForMISReport()
        {
            try
            {
                return dataAccessLayerDao.getGroupByListForMISReport();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getGroupByListForMISReport()", "");
            }
        }
        public DataSet getMISReport(string Query)
        {
            try
            {
                return dataAccessLayerDao.getMISReport(Query);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMISReport()", "");
            }
        }
        public DataSet downloadAdmittedCandidateData(Int32 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.downloadAdmittedCandidateData(InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "downloadAdmittedCandidateData()", "");
            }
        }
        public DataSet getCompositeReportByCategory(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReportByCategory(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReportByCategory()", "");
            }
        }
        public DataSet getCompositeReportByCourse(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReportByCourse(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReportByCourse()", "");
            }
        }
        public DataSet getCompositeReportByDistrict(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReportByDistrict(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReportByDistrict()", "");
            }
        }
        public DataSet getCompositeReportByGender(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReportByGender(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReportByGender()", "");
            }
        }
        public DataSet getCompositeReportByReligion(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReportByReligion(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReportByReligion()", "");
            }
        }
        public DataSet getCompositeReportByUniversity(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReportByUniversity(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReportByUniversity()", "");
            }
        }
        public string getIntakeForChoiceCode(string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.getIntakeForChoiceCode(ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getIntakeForChoiceCode()", "");
            }
        }
        public DataSet getCompositeReportByChoiceCode(string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReportByChoiceCode(ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReportByChoiceCode()", "");
            }
        }
        public DataSet getAdmittedCandidateListToSubmit(string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.getAdmittedCandidateListToSubmit(ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdmittedCandidateListToSubmit()", "");
            }
        }
        public DataSet getSupernumeraryCandidateData(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getSupernumeraryCandidateData(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSupernumeraryCandidateData()", "");
            }
        }

        public bool isCandidateInterestedInAdmissionCancellation(Int64 PID, Int64 ChoiceCode, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.isCandidateInterestedInAdmissionCancellation(PID, ChoiceCode, CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isCandidateInterestedInAdmissionCancellation()", "");
            }
        }
        public Int64 authenticateCandidateLogin(string ApplicationID, string Password)
        {
            try
            {
                return dataAccessLayerDao.authenticateCandidateLogin(ApplicationID, Password);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "authenticateCandidateLogin()", "");
            }
        }
        public bool saveWillingnessForAdmissionCancellation(Int64 PID, Int64 ChoiceCode, Int32 CAPRound, string CandidatePassword, string RequestedBy, string RequestedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveWillingnessForAdmissionCancellation(PID, ChoiceCode, CAPRound, CandidatePassword, RequestedBy, RequestedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveWillingnessForAdmissionCancellation()", "");
            }
        }
        public DataSet getCandidateListRequestedForAdmissionCancellation(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getCandidateListRequestedForAdmissionCancellation(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateListRequestedForAdmissionCancellation()", "");
            }
        }
        public DataSet getAdmittedChoiceCodeListForCancellation(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getAdmittedChoiceCodeListForCancellation(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdmittedChoiceCodeListForCancellation()", "");
            }
        }
        public DataSet getAdmittedChoiceCodeDetailsForCancellation(Int64 PID, Int64 ChoiceCode, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getAdmittedChoiceCodeDetailsForCancellation(PID, ChoiceCode, CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdmittedChoiceCodeDetailsForCancellation()", "");
            }
        }
        public DataSet getRequestedForAdmissionCancellationChoiceCodeList(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getRequestedForAdmissionCancellationChoiceCodeList(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRequestedForAdmissionCancellationChoiceCodeList()", "");
            }
        }
        public DataSet getRequestedForAdmissionCancellationChoiceCodeDetails(Int64 PID, Int64 ChoiceCode, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getRequestedForAdmissionCancellationChoiceCodeDetails(PID, ChoiceCode, CAPRound);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRequestedForAdmissionCancellationChoiceCodeDetails()", "");
            }
        }

        public bool saveFAQs(string Question, string Answer, string FAQType, Int32 SeqNo, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveFAQs(Question, Answer, FAQType, SeqNo, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveFAQs()", "");
            }
        }
        public bool editFAQs(Int64 FAQID, string Question, string Answer, string FAQType, Int32 SeqNo, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editFAQs(FAQID, Question, Answer, FAQType, SeqNo, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editFAQs()", "");
            }
        }
        public bool deleteFAQs(Int64 FAQID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteFAQs(FAQID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteFAQs()", "");
            }
        }
        public DataSet getFAQDetails(Int64 FAQID)
        {
            try
            {
                return dataAccessLayerDao.getFAQDetails(FAQID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getFAQDetails()", "");
            }
        }
        public DataSet getFAQs()
        {
            try
            {
                return dataAccessLayerDao.getFAQs();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getFAQs()", "");
            }
        }
        public DataSet getFAQsListForDisplay()
        {
            try
            {
                return dataAccessLayerDao.getFAQsListForDisplay();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getFAQsListForDisplay()", "");
            }
        }

        public DataSet getMasterARCList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getMasterARCList(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterARCList()", "");
            }
        }
        public DataSet getNonARCInstituteList(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getNonARCInstituteList(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getNonARCInstituteList()", "");
            }
        }
        public bool addMasterARC(Int64 InstituteID, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.addMasterARC(InstituteID, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "addMasterARC()", "");
            }
        }
        public bool deleteMasterARC(Int64 InstituteID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteMasterARC(InstituteID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteMasterARC()", "");
            }
        }
        public bool isInstituteWorkingAsARC(Int64 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.isInstituteWorkingAsARC(InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isInstituteWorkingAsARC()", "");
            }
        }
        public DataSet getARCList(Int64 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.getARCList(InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARCList()", "");
            }
        }
        public string addARC(Int64 InstituteID, string ARCOfficerName, string ARCOfficerMobileNo, string Password, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.addARC(InstituteID, ARCOfficerName, ARCOfficerMobileNo, Password, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "addARC()", "");
            }
        }
        public bool updateARC(Int64 ARCID, string ARCOfficerName, string ARCOfficerMobileNo, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateARC(ARCID, ARCOfficerName, ARCOfficerMobileNo, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateARC()", "");
            }
        }
        public bool deleteARC(Int64 ARCID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteARC(ARCID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteARC()", "");
            }
        }
        public DataSet getSubARCList(Int64 ARCID)
        {
            try
            {
                return dataAccessLayerDao.getSubARCList(ARCID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSubARCList()", "");
            }
        }
        public string addSubARC(Int64 ARCID, string SubARCOfficerName, string SubARCOfficerMobileNo, string Password, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.addSubARC(ARCID, SubARCOfficerName, SubARCOfficerMobileNo, Password, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "addSubARC()", "");
            }
        }
        public bool updateSubARC(Int64 SubARCID, string SubARCOfficerName, string SubARCOfficerMobileNo, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateSubARC(SubARCID, SubARCOfficerName, SubARCOfficerMobileNo, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateSubARC()", "");
            }
        }
        public bool deleteSubARC(Int64 SubARCID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteSubARC(SubARCID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "deleteSubARC()", "");
            }
        }
        public bool saveARCProfile(ARCProfile obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveARCProfile(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveARCProfile()", "");
            }
        }
        public bool updateARCProfile(ARCProfile obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateARCProfile(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateARCProfile()", "");
            }
        }
        public ARCProfile getARCProfile(string ARCCode)
        {
            try
            {
                return BalCommon.FillARCProfile(dataAccessLayerDao.getARCProfile(ARCCode));
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARCProfile()", "");
            }

        }
        public bool changeARCPassword(string LoginID, string Password, string PasswordResetByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.changeARCPassword(LoginID, Password, PasswordResetByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "changeARCPassword()", "");
            }
        }
        public DataSet getARCListReport()
        {
            try
            {
                return dataAccessLayerDao.getARCListReport();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARCListReport()", "");
            }
        }

        public DataSet getHSCResult(string hscSeatNo, string Name, string MotherName, string PassingYear)
        {
            try
            {
                return dataAccessLayerDao.getHSCResult(hscSeatNo, Name, MotherName, PassingYear);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getHSCResult()", "");
            }
        }
        public DataSet getMasterJuridiction(string DocumentType)
        {
            try
            {
                return dataAccessLayerDao.getMasterJuridiction(DocumentType);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterJuridiction()", "");
            }
        }
        public DataSet getMasterDistrictForJuridiction(int JurisdictionID)
        {
            try
            {
                return dataAccessLayerDao.getMasterDistrictForJuridiction(JurisdictionID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterDistrictForJuridiction()", "");
            }
        }

        public bool updateInstitueParticipationInAditionalRound(Int64 InstitueID, string ParticipationInAditionalRound, string UpdatedBy, string UpdatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateInstitueParticipationInAditionalRound(InstitueID, ParticipationInAditionalRound, UpdatedBy, UpdatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateInstitueParticipationInAditionalRound()", "");
            }
        }
        public bool getInstitueParticipationInAditionalRound(Int64 InstitueID)
        {
            try
            {
                return dataAccessLayerDao.getInstitueParticipationInAditionalRound(InstitueID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstitueParticipationInAditionalRound()", "");
            }
        }
        public DataSet getInstitueAllotedCandidateACAP(string InstitueID, string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.getInstitueAllotedCandidateACAP(InstitueID, ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstitueAllotedCandidateACAP()", "");
            }
        }
        public Int32 updateInstitueAllotedCandidateACAPSeatType(Int64 PersonalID, string ChoiceCode, string SelectedSeatType, string UpdatedBy, string UpdatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateInstitueAllotedCandidateACAPSeatType(PersonalID, ChoiceCode, SelectedSeatType, UpdatedBy, UpdatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateInstitueAllotedCandidateACAPSeatType()", "");
            }
        }
        public DataSet getVacancyForAdditionRoundByFlag(string ChoiceCode, string Flag)
        {
            try
            {
                return dataAccessLayerDao.getVacancyForAdditionRoundByFlag(ChoiceCode, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getVacancyForAdditionRoundByFlag()", "");
            }
        }
        public bool editCategoryDetails(Int64 PID, Int16 CategoryID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editCategoryDetails(PID, CategoryID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "editCategoryDetails()", "");
            }
        }
        public bool saveProjectConfigurationDetails(string AppKey, string AppValue, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveProjectConfigurationDetails(AppKey, AppValue, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveProjectConfigurationDetails()", "");
            }
        }
        public DataSet getProjectConfigurationDetails(string AppKey)
        {
            try
            {
                return dataAccessLayerDao.getProjectConfigurationDetails(AppKey);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getProjectConfigurationDetails()", "");
            }
        }
        public DataSet getProjectConfigurationList()
        {
            try
            {
                return dataAccessLayerDao.getProjectConfigurationList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getProjectConfigurationList()", "");
            }
        }
        public string getProjectConfiguration(string AppKey)
        {
            try
            {
                return dataAccessLayerDao.getProjectConfiguration(AppKey);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getProjectConfiguration()", "");
            }
        }
        public bool saveActivityStatusDetails(string ActivityName, DateTime? ActivityStartDateTime, DateTime? ActivityEndDateTime, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveActivityStatusDetails(ActivityName, ActivityStartDateTime, ActivityEndDateTime, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveActivityStatusDetails()", "");
            }
        }
        public DataSet getActivityStatusDetails(string ActivityName)
        {
            try
            {
                return dataAccessLayerDao.getActivityStatusDetails(ActivityName);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getActivityStatusDetails()", "");
            }
        }
        public DataSet getActivityStatusList()
        {
            try
            {
                return dataAccessLayerDao.getActivityStatusList();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getActivityStatusList()", "");
            }
        }
        public DataSet getActivityStatus(string ActivityName)
        {
            try
            {
                return dataAccessLayerDao.getActivityStatus(ActivityName);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getActivityStatus()", "");
            }
        }

        public DataSet getApplicationFormLinksStatus(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getApplicationFormLinksStatus(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getApplicationFormLinksStatus()", "");
            }
        }
        public string getCategoryName(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCategoryName(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCategoryName()", "");
            }
        }
        public string getAppliedForEWSFlag(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getAppliedForEWSFlag(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAppliedForEWSFlag()", "");
            }
        }
        public bool isOrphanAndNotEligibleForCategoryReservation(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isOrphanAndNotEligibleForCategoryReservation(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isOrphanAndNotEligibleForCategoryReservation()", "");
            }
        }
        public string getOriginalAppliedForEWSFlag(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getOriginalAppliedForEWSFlag(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getOriginalAppliedForEWSFlag()", "");
            }
        }
        public Int32 getReligiousMinorityID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getReligiousMinorityID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getReligiousMinorityID()", "");
            }
        }
        public Int32 getLinguisticMinorityID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getLinguisticMinorityID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getLinguisticMinorityID()", "");
            }
        }
        public DataSet CheckOtp(Int64 PID, int OTPType)
        {
            try
            {
                return dataAccessLayerDao.CheckOtp(PID, OTPType);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckOtp()", "");
            }
        }

        public bool SaveOTP(Int64 PID, int OTP, int OTPType, bool Isused, DateTime validtill, string moileNo, string EmailId, string ModifiedBy, string ModifiedByIPAddress, int IsOTPVerificationRequired)
        {
            try
            {
                return dataAccessLayerDao.SaveOTP(PID, OTP, OTPType, Isused, validtill, moileNo, EmailId, ModifiedBy, ModifiedByIPAddress, IsOTPVerificationRequired);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "SaveOTP()", "");
            }
        }
        //Razorpay

        public string getRazorpayCustormerID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getRazorpayCustormerID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRazorpayCustormerID()", "");
            }
        }
        public string updateRazorpayCustormerID(Int64 PID, string RazorpayCustomerID)
        {
            try
            {
                return dataAccessLayerDao.updateRazorpayCustormerID(PID, RazorpayCustomerID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateRazorpayCustormerID()", "");
            }
        }

        public string ValidateDuplicateResponsebyRefNo(string RefNo)
        {
            try
            {
                return dataAccessLayerDao.ValidateDuplicateResponsebyRefNo(RefNo);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "ValidateDuplicateResponsebyRefNo()", "");
            }
        }
        public DataSet GetSMSEmailContent(Int64 PID, string Flag, string IPAddress, int IsOTPVerificationRequired)
        {
            try
            {
                return dataAccessLayerDao.GetSMSEmailContent(PID, Flag, IPAddress, IsOTPVerificationRequired);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetSMSEmailContent()", "");
            }
        }
        public DataSet getApplicationFeePaymentDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getApplicationFeePaymentDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getApplicationFeePaymentDetails()", "");
            }
        }
        public string getAnnualFamilyIncomeDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getAnnualFamilyIncomeDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAnnualFamilyIncomeDetails()", "");
            }
        }
        public DateTime getApplicationFormCreatedDate(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getApplicationFormCreatedDate(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getApplicationFormCreatedDate()", "");
            }
        }
        public DataSet GetIncorrectNEETDetailsCandidate(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetIncorrectNEETDetailsCandidate(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetIncorrectNEETDetailsCandidate()", "");
            }
        }
        public bool CheckCandidateCVCStatus(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.CheckCandidateCVCStatus(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckCandidateCVCStatus()", "");
            }
        }
        public bool CategoryConverttoOPEN(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.CategoryConverttoOPEN(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CategoryConverttoOPEN()", "");
            }
        }
        public bool UpdateCategoryConverttoOPEN(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UpdateCategoryConverttoOPEN(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "UpdateCategoryConverttoOPEN()", "");
            }
        }
        public DataSet GetCvcTvcReport()
        {
            try
            {
                return dataAccessLayerDao.GetCvcTvcReport();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetCvcTvcReport()", "");
            }
        }
        public DataSet getAllotmentStatusCAPRound2ByPID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentStatusCAPRound2ByPID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentStatusCAPRound2ByPID()", "");
            }
        }
        public DataSet getAllotmentStatusCAPRound3ByPID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentStatusCAPRound3ByPID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllotmentStatusCAPRound3ByPID()", "");
            }
        }
        public Int32 insertOptionDirectCAPRound3_SpecialChoiceAfterConfirm(Int64 PID, Int32 PreferenceNo, string ChoiceCodeDisplay, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.insertOptionDirectCAPRound3_SpecialChoiceAfterConfirm(PID, PreferenceNo, ChoiceCodeDisplay, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "insertOptionDirectCAPRound3_SpecialChoiceAfterConfirm()", "");
            }
        }
        public DataSet getILSeatAcceptanceFeeNotPaidReport(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getILSeatAcceptanceFeeNotPaidReport(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getILSeatAcceptanceFeeNotPaidReport()", "");
            }
        }
        public DataSet getCategoryConversionFeeNotPaidReport(string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.getCategoryConversionFeeNotPaidReport(UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCategoryConversionFeeNotPaidReport()", "");
            }
        }
        public DataSet getDataForReminderSMS(string systemName)
        {
            try
            {
                return dataAccessLayerDao.getDataForReminderSMS(systemName);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getDataForReminderSMS()", "");
            }
        }
        public DataSet getApplicationFormCancellationDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getApplicationFormCancellationDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getApplicationFormCancellationDetails()", "");
            }
        }
        public bool SaveMasterTemplateFiled(string name)
        {
            try
            {
                return dataAccessLayerDao.SaveMasterTemplateFiled(name);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "SaveMasterTemplateFiled()", "");
            }
        }
        public DataSet getEmailSMSTemplateBySystemName(string systemName)
        {
            try
            {
                return dataAccessLayerDao.getEmailSMSTemplateBySystemName(systemName);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getEmailSMSTemplateBySystemName()", "");
            }
        }
        public bool updateSMSEmailTemplates(string template, string systemName, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateSMSEmailTemplates(template, systemName, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateSMSEmailTemplates()", "");
            }
        }
        public bool updateSMSEmailTemplates(Int64 Id, string name, string template, string type, string systemName, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateSMSEmailTemplates(Id, name, template, type, systemName, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "updateSMSEmailTemplates()", "");
            }
        }
        public DataSet getAllSMSEmailTemplates()
        {
            try
            {
                return dataAccessLayerDao.getAllSMSEmailTemplates();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllSMSEmailTemplates()", "");
            }
        }
        public DataSet getMasterPassingYear(string IsActive)
        {
            try
            {
                return dataAccessLayerDao.getMasterPassingYear(IsActive);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterPassingYear()", "");
            }
        }
        public bool chkDuplicateSMSEmailTemplateSystemName(string systemName)
        {
            try
            {
                return dataAccessLayerDao.chkDuplicateSMSEmailTemplateSystemName(systemName);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "chkDuplicateSMSEmailTemplateSystemName()", "");
            }
        }
        public bool getSaveSMSEmailTemplates(string name, string template, string type, string systemName, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.getSaveSMSEmailTemplates(name, template, type, systemName, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSaveSMSEmailTemplates()", "");
            }
        }
        public DataSet getGetSMSEmailTemplates(string type, string systemName)
        {
            try
            {
                return dataAccessLayerDao.getGetSMSEmailTemplates(type, systemName);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getGetSMSEmailTemplates()", "");
            }
        }
        public DataSet getGetMaster_TemplateFields()
        {
            try
            {
                return dataAccessLayerDao.getGetMaster_TemplateFields();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getGetMaster_TemplateFields()", "");
            }
        }
        public List<Master_Village> getAllMasterVillage()
        {
            try
            {
                return BalCommon.FillMasterVillage(dataAccessLayerDao.getAllMasterVillage());
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllMasterVillage()", "");
            }
        }
        public List<Master_Taluka> getAllMasterTaluka()
        {
            try
            {
                return BalCommon.FillMasterTaluka(dataAccessLayerDao.getAllMasterTaluka());
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllMasterTaluka()", "");
            }
        }
        public List<Master_District> getAllMasterDistrict()
        {
            try
            {
                return BalCommon.FillMasterDistrict(dataAccessLayerDao.getAllMasterDistrict());
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAllMasterDistrict()", "");
            }
        }
        public bool CandidateComposeMessage(string To, string From, string Subject, string Message, string FilePath1, string FilePath2, string SentBy, string SentByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.CandidateComposeMessage(To, From, Subject, Message, FilePath1, FilePath2, SentBy, SentByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CandidateComposeMessage()", "");
            }
        }

        public bool CheckCandidateValidForMessage(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.CheckCandidateValidForMessage(PersonalID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckCandidateValidForMessage()", "");
            }
        }
        public DataSet getMasterHSCSubject()
        {
            try
            {
                return dataAccessLayerDao.getMasterHSCSubject();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterHSCSubject()", "");
            }
        }
        public DataSet GetRepliedMessagesToCandidateByAdmin(string CandidateCode)
        {
            try
            {
                return dataAccessLayerDao.GetRepliedMessagesToCandidateByAdmin(CandidateCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetRepliedMessagesToCandidateByAdmin()", "");
            }
        }
        public DataSet getCandidateNonRepliedMessages(string CandidateCode)
        {
            try
            {
                return dataAccessLayerDao.getCandidateNonRepliedMessages(CandidateCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateNonRepliedMessages()", "");
            }
        }
        public DataSet getAdminNonRepliedMessages_Canidate(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getAdminNonRepliedMessages_Canidate(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdminNonRepliedMessages_Canidate()", "");
            }
        }
        public DataSet getAdminRepliedMessagesToCandidate(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getAdminRepliedMessagesToCandidate(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdminRepliedMessagesToCandidate()", "");
            }
        }
        public DataSet getMessagesListToCandidate(string From)
        {
            try
            {
                return dataAccessLayerDao.getMessagesListToCandidate(From);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMessagesListToCandidate()", "");
            }
        }
        public bool replyMessageToCandidate(Int64 MessageID, string RepliedMessage, string RepliedBy, string RepliedByIPAddress, string To, string From, string FilePath1, string FilePath2)
        {
            try
            {
                return dataAccessLayerDao.replyMessageToCandidate(MessageID, RepliedMessage, RepliedBy, RepliedByIPAddress, To, From, FilePath1, FilePath2);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "replyMessageToCandidate()", "");
            }
        }

        public List<Master_Taluka> GetAllMasterMHTaluka()
        {
            try
            {
                return BalCommon.FillMasterTaluka(dataAccessLayerDao.GetAllMasterMHTaluka());
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetAllMasterMHTaluka()", "");
            }
        }
        public UpdateInstituteFormPortal getMasterofInstituteChoiceCodeUniversity()
        {
            try
            {
                UpdateInstituteFormPortal updateInstituteFormPortal = new UpdateInstituteFormPortal();
                DataSet ds = dataAccessLayerDao.getAllMasterofInstituteChoiceCodeUniversity();
                List<Master_Institute> master_Institutes = BalCommon.ReadTable<Master_Institute>(ds.Tables[0]);
                List<Master_ChoiceCode> master_ChoiceCodes = BalCommon.ReadTable<Master_ChoiceCode>(ds.Tables[1]);
                List<Master_HomeUniversity> master_HomeUniversities = BalCommon.ReadTable<Master_HomeUniversity>(ds.Tables[2]);
                List<Master_Course> master_Courses = BalCommon.ReadTable<Master_Course>(ds.Tables[3]);
                updateInstituteFormPortal.master_Instituteslst = master_Institutes;
                updateInstituteFormPortal.master_ChoiceCodeslst = master_ChoiceCodes;
                updateInstituteFormPortal.master_HomeUniversitieslst = master_HomeUniversities;
                updateInstituteFormPortal.master_Courseslst = master_Courses;

                return updateInstituteFormPortal;
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterofInstituteChoiceCodeUniversity()", "");
            }
        }
        public bool CheckFCVerificationStatus(Int64 PID)
        {
            return dataAccessLayerDao.CheckFCVerificationStatus(PID);
        }
        public DataSet getVerificationFlags(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getVerificationFlags(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getVerificationFlags()", "");
            }
        }
        public bool checkActiveTicketExist(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.checkActiveTicketExist(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "checkActiveTicketExist()", "");
            }
        }
        public string CheckCandidateFCVerificationFor(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.CheckCandidateFCVerificationFor(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CheckCandidateFCVerificationFor()", "");
            }
        }
        public string GetApplicationLockStatus(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.GetApplicationLockStatus(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationLockStatus()", "PersonalID :" + PersonalID);
            }
        }
        public DataSet GetDocumentListByUploadedFlag(Int64 PID, string SubmittedFlag)
        {
            try
            {
                return dataAccessLayerDao.GetDocumentListByUploadedFlag(PID, SubmittedFlag);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDocumentListByUploadedFlag()", "");
            }
        }
        public bool saveUploadDocumentStepID(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveUploadDocumentStepID(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "saveUploadDocumentStepID()", "");
            }
        }
        public bool CheckBankDetailsStatus(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.CheckBankDetailsStatus(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CheckBankDetailsStatus()", "PersonalID:" + PersonalID);
            }
        }
        public bool SaveBankDetailsSkip(Int64 PersonalID, string CreatedBy, string CreatedByIPAddress, string DeviceInfo)
        {
            try
            {
                return dataAccessLayerDao.SaveBankDetailsSkip(PersonalID, CreatedBy, CreatedByIPAddress, DeviceInfo);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "SaveBankDetailsSkip()", "PersonalID:" + PersonalID + " DeviceInfo:" + DeviceInfo);
            }
        }
        public bool SaveBankDetails(Int64 PersonalID, Int64 AadhaarNo, string BankName, string IFSCCODE, string BankAccountNo, string AccountHolderName, string CreatedBy, string CreatedByIPAddress, string DeviceInfo)
        {
            try
            {
                return dataAccessLayerDao.SaveBankDetails(PersonalID, AadhaarNo, BankName, IFSCCODE, BankAccountNo, AccountHolderName, CreatedBy, CreatedByIPAddress, DeviceInfo);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "SaveBankDetails()", "PersonalID:" + PersonalID + " DeviceInfo:" + DeviceInfo);
            }
        }
        public DataSet GetBankDetailsStatus(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.GetBankDetailsStatus(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetBankDetailsStatus()", "PersonalID :" + PersonalID);
            }
        }
        public DataSet GetMasterMHDistrictForFCVerification()
        {
            try
            {
                return dataAccessLayerDao.GetMasterMHDistrictForFCVerification();
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetMasterMHDistrictForFCVerification()", "");
            }
        }
        public DataSet GetCandidateBookingSlotDetails(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.GetCandidateBookingSlotDetails(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetCandidateBookingSlotDetails()", "PersonalID: " + PersonalID);
            }

        }
        public DataSet GetSlotDates(string AFCCode)
        {
            try
            {
                return dataAccessLayerDao.GetSlotDates(AFCCode);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetSlotDates()", "AFCCode: " + AFCCode);
            }

        }
        public DataSet GetFCDetailsForSlotBooking(int DistrictID)
        {
            try
            {
                return dataAccessLayerDao.GetFCDetailsForSlotBooking(DistrictID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetFCDetailsForSlotBooking()", "DistrictID" + DistrictID);
            }
        }
        public DataSet GetSlotForFC(string FCID, string SlotDate)
        {
            try
            {
                return dataAccessLayerDao.GetSlotForFC(FCID, SlotDate);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetSlotForFC()", "FCID" + FCID);
            }
        }
        public Int16 SaveCandidateBookedSlot(Int64 FCDateID, int SlotID, Int64 PersonalID, string CreatedBy, string CreatedByIpAddress)
        {
            try
            {
                return dataAccessLayerDao.SaveCandidateBookedSlot(FCDateID, SlotID, PersonalID, CreatedBy, CreatedByIpAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "SaveCandidateBookedSlot()", "PersonalID :" + PersonalID + " FCDateID: " + FCDateID + " SlotID:" + SlotID);
            }
        }
        public bool UpdateCandidateFCVerificationFor(Int64 PersonalID, string FCVerificationFor, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UpdateCandidateFCVerificationFor(PersonalID, FCVerificationFor, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UpdateCandidateFCVerificationFor()", "");
            }
        }
        public bool UpdateCandidateBrowserOS(Int64 PersonalID, string BrowserOS)
        {
            try
            {
                return dataAccessLayerDao.UpdateCandidateBrowserOS(PersonalID, BrowserOS);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UpdateCandidateBrowserOS()", "");
            }
        }
        public string getAppliedForTFWSFlag(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getAppliedForTFWSFlag(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAppliedForTFWSFlag()", "");
            }
        }
        public DataSet GetApplicationFormVersionNo(Int64 PID, string VersionNoFlag)
        {
            try
            {
                return dataAccessLayerDao.GetApplicationFormVersionNo(PID, VersionNoFlag);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationFormVersionNo()", "");
            }
        }
        public List<DocumentDetails> GetPersonalInformationByApplicationVersionNoDocuments(Int64 PID, Int32 VersionNo)
        {
            try
            {
                string strDocument = dataAccessLayerDao.GetPersonalInformationByApplicationVersionNo(PID, VersionNo).Tables[0].Rows[0]["RequiredDocuments"].ToString();
                List<string> listofDocument = new List<string>();
                listofDocument = strDocument.Split('|').ToList();
                List<DocumentDetails> documentDetails = new List<DocumentDetails>();
                foreach (var item in listofDocument)
                {
                    List<string> listdoument = new List<string>();
                    listdoument = item.Split(';').ToList();
                    DocumentDetails document = new DocumentDetails();
                    foreach (var doc in listdoument)
                    {

                        if (doc.Contains("DocumentID :"))
                            document.DocumentID = doc.Replace("DocumentID : ", "").ToString();
                        if (doc.Contains("Document Name: "))
                            document.DocumentName = doc.Replace("Document Name: ", "");
                        if (doc.Contains("Is Submitted At FC : "))
                            document.IsSubmittedAtFC = doc.Replace("Is Submitted At FC : ", "");
                        if (doc.Contains("Is Submitted At ARC : "))
                            document.IsSubmittedAtARC = doc.Replace("Is Submitted At ARC : ", "");
                        if (doc.Contains("Is Uploaded : "))
                            document.IsUploaded = doc.Replace("Is Uploaded : ", "");
                        if (doc.Contains("AbsoluteFilePath : "))
                            document.AbsoluteFilePath = doc.Replace("AbsoluteFilePath : ", "");


                    }
                    documentDetails.Add(document);
                }
                return documentDetails;
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPersonalInformationByApplicationVersionNoDocuments()", "");
            }

        }
        public PersonalInformation GetPersonalInformationByApplicationVersionNo(Int64 PID, Int32 VersionNo)
        {
            try
            {
                return BalCommon.FillPersonalInformation(dataAccessLayerDao.GetPersonalInformationByApplicationVersionNo(PID, VersionNo));
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPersonalInformationByApplicationVersionNo()", "");
            }
        }
        public PersonalInformation GetPersonalInformationByAcknowledgementVersionNo(Int64 PID, Int32 VersionNo)
        {
            try
            {
                return BalCommon.FillPersonalInformation(dataAccessLayerDao.MHDTE_spGetPersonalInformationByAcknowledgementVersionNo(PID, VersionNo));
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPersonalInformationByAcknowledgementVersionNo()", "");
            }
        }
        public List<DocumentDetails> GetPersonalInformationByAcknowledgementVersionNoDocuments(Int64 PID, Int32 VersionNo)
        {
            try
            {
                string strDocument = dataAccessLayerDao.MHDTE_spGetPersonalInformationByAcknowledgementVersionNo(PID, VersionNo).Tables[0].Rows[0]["RequiredDocuments"].ToString();
                List<string> listofDocument = new List<string>();
                listofDocument = strDocument.Split('|').ToList();
                List<DocumentDetails> documentDetails = new List<DocumentDetails>();
                foreach (var item in listofDocument)
                {
                    List<string> listdoument = new List<string>();
                    listdoument = item.Split(';').ToList();
                    DocumentDetails document = new DocumentDetails();
                    foreach (var doc in listdoument)
                    {

                        if (doc.Contains("DocumentID :"))
                            document.DocumentID = doc.Replace("DocumentID : ", "").ToString();
                        if (doc.Contains("Document Name: "))
                            document.DocumentName = doc.Replace("Document Name: ", "");
                        if (doc.Contains("Is Submitted At FC : "))
                            document.IsSubmittedAtFC = doc.Replace("Is Submitted At FC : ", "");
                        if (doc.Contains("Is Submitted At ARC : "))
                            document.IsSubmittedAtARC = doc.Replace("Is Submitted At ARC : ", "");
                        if (doc.Contains("Is Uploaded : "))
                            document.IsUploaded = doc.Replace("Is Uploaded : ", "");
                        if (doc.Contains("AbsoluteFilePath : "))
                            document.AbsoluteFilePath = doc.Replace("AbsoluteFilePath : ", "");


                    }
                    documentDetails.Add(document);
                }
                return documentDetails;
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPersonalInformationByAcknowledgementVersionNoDocuments()", "");
            }
        }

        public List<DiscrepancyDetails> GetAcknowledgementVersionNoDiscrepancy(Int64 PID, Int32 VersionNo)
        {
            try
            {
                string strDiscrepancy = dataAccessLayerDao.MHDTE_spGetPersonalInformationByAcknowledgementVersionNo(PID, VersionNo).Tables[0].Rows[0]["DiscrepancyMarked"].ToString();

                List<string> listofDiscrepancy = new List<string>();
                listofDiscrepancy = strDiscrepancy.Split('|').ToList();
                List<DiscrepancyDetails> discrepancyDetails = new List<DiscrepancyDetails>();
                if (strDiscrepancy != "")
                {
                    foreach (var item in listofDiscrepancy)
                    {
                        List<string> listdiscrepancy = new List<string>();
                        listdiscrepancy = item.Split(';').ToList();
                        DiscrepancyDetails discrepancy = new DiscrepancyDetails();
                        foreach (var doc in listdiscrepancy)
                        {
                            if (doc.Contains("ApplicationFormStepID :"))
                                discrepancy.ApplicationFormStepID = doc.Replace("ApplicationFormStepID : ", "").ToString();
                            if (doc.Contains("LinkName : "))
                                discrepancy.LinkName = doc.Replace("LinkName : ", "");
                            if (doc.Contains("DiscrepancyID : "))
                                discrepancy.DiscrepancyID = doc.Replace("DiscrepancyID : ", "");
                            if (doc.Contains("DiscrepancyName : "))
                                discrepancy.DiscrepancyName = doc.Replace("DiscrepancyName : ", "");
                            if (doc.Contains("DiscrepancyRemark : "))
                                discrepancy.DiscrepancyRemark = doc.Replace("DiscrepancyRemark : ", "");
                        }
                        discrepancyDetails.Add(discrepancy);
                    }
                }
                return discrepancyDetails;
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetAcknowledgementVersionNoDiscrepancy()", "");
            }
        }
        public DataSet isApplicationFormConfirmedUsingThisCETApplicationNo(Int64 CETApplicationFormNo, Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isApplicationFormConfirmedUsingThisCETApplicationNo(CETApplicationFormNo, PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isApplicationFormConfirmedUsingThisCETApplicationNo()", "");
            }
        }

        public DataSet isApplicationFormConfirmedUsingThisNEETRollNo(Int64 NEETRollNo, Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isApplicationFormConfirmedUsingThisNEETRollNo(NEETRollNo, PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isApplicationFormConfirmedUsingThisCETApplicationNo()", "");
            }
        }
        //MAHA IT Document Fetch Start
        public bool InsertUpdateDocumentFetchData(ResponseCommon obj)
        {
            try
            {
                return dataAccessLayerDao.InsertUpdateDocumentFetchData(obj);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "InsertUpdateDocumentFetchData()", "PersonalID :" + obj.PersonalID + " DocumentID" + obj.DocumentID);
            }
        }
        public ResponseCommon GetDocumentFetchData(Int64 PersonalID, Int64 DocID)
        {
            try
            {
                return BalCommon.FillDocumentFetchData(dataAccessLayerDao.GetDocumentFetchData(PersonalID, DocID));
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDocumentFetchData()", "PersonalID :" + PersonalID + " DocumentID: " + DocID);
            }
        }
        //MAHA IT Document Fetch END

        //E verification Start

        public bool editConfirmedApplicationFormEvrification(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsTFWSChanged, Int32 IsMinorityChanged, Int32 IsEWSChanged, Int32 IsOrphanChanged, string Comments, string IsNCLReceiptSubmitted, DateTime NCLIssueDate, Int32 NCLValidUpto, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.editConfirmedApplicationFormEvrification(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsTFWSChanged, IsMinorityChanged, IsEWSChanged, IsOrphanChanged, Comments, IsNCLReceiptSubmitted, NCLIssueDate, NCLValidUpto, ModifiedBy, ModifiedByIPAddress);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "editConfirmedApplicationForm()", "");
            }
        }
        public DataSet GetApplicationFormConfirmationDetailsGrivance(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetApplicationFormConfirmationDetailsGrivance(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationFormConfirmationDetailsGrivance()", "PID: " + PID);
            }
        }
        public bool SaveSubmitApplicationFormStepID(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.SaveSubmitApplicationFormStepID(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "SaveSubmitApplicationFormStepID()", "");
            }
        }
        public bool UnlockApplicationForm(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UnlockApplicationForm(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UnlockApplicationForm()", "");
            }
        }
        //public PersonalInformation GetPersonalInformationByApplicationVersionNo(Int64 PID, Int32 VersionNo)
        //{
        //    try
        //    {
        //        return BalCommon.FillPersonalInformation(dataAccessLayerDao.GetPersonalInformationByApplicationVersionNo(PID, VersionNo));
        //    }
        //    catch (CustomException CEx)
        //    {
        //        throw CEx;
        //    }
        //    catch (Exception Ex)
        //    {
        //        long messageID = ExceptionMessages.GetMessageDetails();
        //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPersonalInformationByApplicationVersionNo()", "");
        //    }
        //}
        //public PersonalInformation GetPersonalInformationByAcknowledgementVersionNo(Int64 PID, Int32 VersionNo)
        //{
        //    try
        //    {
        //        return BalCommon.FillPersonalInformation(dataAccessLayerDao.MHDTE_spGetPersonalInformationByAcknowledgementVersionNo(PID, VersionNo));
        //    }
        //    catch (CustomException CEx)
        //    {
        //        throw CEx;
        //    }
        //    catch (Exception Ex)
        //    {
        //        long messageID = ExceptionMessages.GetMessageDetails();
        //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPersonalInformationByAcknowledgementVersionNo()", "");
        //    }
        //}
        //public DataSet GetApplicationFormVersionNo(Int64 PID, string VersionNoFlag)
        //{
        //    try
        //    {
        //        return dataAccessLayerDao.GetApplicationFormVersionNo(PID, VersionNoFlag);
        //    }
        //    catch (CustomException CEx)
        //    {
        //        throw CEx;
        //    }
        //    catch (Exception Ex)
        //    {
        //        long messageID = ExceptionMessages.GetMessageDetails();
        //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationFormVersionNo()", "");
        //    }
        //}
        //public List<DocumentDetails> GetPersonalInformationByApplicationVersionNoDocuments(Int64 PID, Int32 VersionNo)
        //{
        //    try
        //    {
        //        string strDocument = dataAccessLayerDao.GetPersonalInformationByApplicationVersionNo(PID, VersionNo).Tables[0].Rows[0]["RequiredDocuments"].ToString();
        //        List<string> listofDocument = new List<string>();
        //        listofDocument = strDocument.Split('|').ToList();
        //        List<DocumentDetails> documentDetails = new List<DocumentDetails>();
        //        foreach (var item in listofDocument)
        //        {
        //            List<string> listdoument = new List<string>();
        //            listdoument = item.Split(';').ToList();
        //            DocumentDetails document = new DocumentDetails();
        //            foreach (var doc in listdoument)
        //            {

        //                if (doc.Contains("DocumentID :"))
        //                    document.DocumentID = doc.Replace("DocumentID : ", "").ToString();
        //                if (doc.Contains("Document Name: "))
        //                    document.DocumentName = doc.Replace("Document Name: ", "");
        //                if (doc.Contains("Is Submitted At FC : "))
        //                    document.IsSubmittedAtFC = doc.Replace("Is Submitted At FC : ", "");
        //                if (doc.Contains("Is Submitted At ARC : "))
        //                    document.IsSubmittedAtARC = doc.Replace("Is Submitted At ARC : ", "");
        //                if (doc.Contains("Is Uploaded : "))
        //                    document.IsUploaded = doc.Replace("Is Uploaded : ", "");
        //                if (doc.Contains("AbsoluteFilePath : "))
        //                    document.AbsoluteFilePath = doc.Replace("AbsoluteFilePath : ", "");


        //            }
        //            documentDetails.Add(document);
        //        }
        //        return documentDetails;
        //    }
        //    catch (CustomException CEx)
        //    {
        //        throw CEx;
        //    }
        //    catch (Exception Ex)
        //    {
        //        long messageID = ExceptionMessages.GetMessageDetails();
        //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPersonalInformationByApplicationVersionNoDocuments()", "");
        //    }

        //}
        //public List<DocumentDetails> GetPersonalInformationByAcknowledgementVersionNoDocuments(Int64 PID, Int32 VersionNo)
        //{
        //    try
        //    {
        //        string strDocument = dataAccessLayerDao.MHDTE_spGetPersonalInformationByAcknowledgementVersionNo(PID, VersionNo).Tables[0].Rows[0]["RequiredDocuments"].ToString();
        //        List<string> listofDocument = new List<string>();
        //        listofDocument = strDocument.Split('|').ToList();
        //        List<DocumentDetails> documentDetails = new List<DocumentDetails>();
        //        foreach (var item in listofDocument)
        //        {
        //            List<string> listdoument = new List<string>();
        //            listdoument = item.Split(';').ToList();
        //            DocumentDetails document = new DocumentDetails();
        //            foreach (var doc in listdoument)
        //            {

        //                if (doc.Contains("DocumentID :"))
        //                    document.DocumentID = doc.Replace("DocumentID : ", "").ToString();
        //                if (doc.Contains("Document Name: "))
        //                    document.DocumentName = doc.Replace("Document Name: ", "");
        //                if (doc.Contains("Is Submitted At FC : "))
        //                    document.IsSubmittedAtFC = doc.Replace("Is Submitted At FC : ", "");
        //                if (doc.Contains("Is Submitted At ARC : "))
        //                    document.IsSubmittedAtARC = doc.Replace("Is Submitted At ARC : ", "");
        //                if (doc.Contains("Is Uploaded : "))
        //                    document.IsUploaded = doc.Replace("Is Uploaded : ", "");
        //                if (doc.Contains("AbsoluteFilePath : "))
        //                    document.AbsoluteFilePath = doc.Replace("AbsoluteFilePath : ", "");


        //            }
        //            documentDetails.Add(document);
        //        }
        //        return documentDetails;
        //    }
        //    catch (CustomException CEx)
        //    {
        //        throw CEx;
        //    }
        //    catch (Exception Ex)
        //    {
        //        long messageID = ExceptionMessages.GetMessageDetails();
        //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPersonalInformationByAcknowledgementVersionNoDocuments()", "");
        //    }
        //}
        public DataSet GetCandidateVerificationStepwiseStatusForAFC(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetCandidateVerificationStepwiseStatusForAFC(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetCandidateVerificationStepwiseStatusForAFC()", "");
            }
        }
        public DataSet GetDocumentListForDataVerificationByStepID(Int64 PID, Int32 ApplicationFormStepID)
        {
            try
            {
                return dataAccessLayerDao.GetDocumentListForDataVerificationByStepID(PID, ApplicationFormStepID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDocumentListForDataVerificationByStepID()", "");
            }
        }
        public DataSet GetDocumentListForDocumentVerificationByStepID(Int64 PID, Int32 ApplicationFormStepID)
        {
            try
            {
                return dataAccessLayerDao.GetDocumentListForDocumentVerificationByStepID(PID, ApplicationFormStepID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDocumentListForDocumentVerificationByStepID()", "");
            }
        }
        public DataSet GetDiscrepancyListByStepID(Int64 PID, Int32 ApplicationFormStepID)
        {
            try
            {
                return dataAccessLayerDao.GetDiscrepancyListByStepID(PID, ApplicationFormStepID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDiscrepancyListByStepID()", "");
            }
        }
        public bool UpdatePickedupStatus(Int64 PID, string UserLoginID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UpdatePickedupStatus(PID, UserLoginID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UpdatePickedupStatus()", "");
            }
        }
        public bool UpdateDiscrepancySubmission(Int64 PID, string XMLString, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UpdateDiscrepancySubmission(PID, XMLString, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UpdateDiscrepancySubmission()", "");
            }
        }
        public Int32 CheckDiscrepancyExists(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.CheckDiscrepancyExists(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CheckDiscrepancyExists()", "");
            }
        }
        public bool ConfirmApplicationFormWithDiscrepancy(Int64 PID, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsTFWSChanged, Int32 IsMinorityChanged, Int32 IsIGDChanged, Int32 IsEWSChanged, Int32 IsOrphanChanged, string Comments, DateTime NCLIssueDate, Int32 NCLValidUpto, string ConfirmedBy, string ConfirmedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.ConfirmApplicationFormWithDiscrepancy(PID, IsCandidatureTypeChanged, IsCategoryChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsTFWSChanged, IsMinorityChanged, IsIGDChanged, IsEWSChanged, IsOrphanChanged, Comments, NCLIssueDate, NCLValidUpto, ConfirmedBy, ConfirmedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "ConfirmApplicationFormWithDiscrepancy()", "");
            }
        }
        public DataSet GetDiscrepancyDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetDiscrepancyDetails(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDiscrepancyDetails()", "");
            }
        }
        public DataSet GetApplicationFormListForFCReVerificationofGrievance(string UserLoginID, int UserTypeID)
        {
            try
            {
                return dataAccessLayerDao.GetApplicationFormListForFCReVerificationofGrievance(UserLoginID, UserTypeID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationFormListForFCReVerificationofGrievance()", "");
            }
        }
        public DataSet CheckFCForConfirmApplicationForm(string UserLoginID, long PersonalID, long ID, string IPAddress)
        {
            try
            {
                return dataAccessLayerDao.CheckFCForConfirmApplicationForm(UserLoginID, PersonalID, ID, IPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CheckFCForConfirmApplicationForm()", "");
            }
        }
        public string CheckISEFC(string AFCCode)
        {
            try
            {
                return "Y";// dataAccessLayerDao.CheckISEFC(AFCCode);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CheckISEFC()", "AFCCode: " + AFCCode);
            }
        }

        public DataSet GetSubAFCEConfirmedCount(int RegionID, int InstituteID)
        {
            try
            {
                return dataAccessLayerDao.GetSubAFCEConfirmedCount(RegionID, InstituteID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetSubAFCEConfirmedCount()", "RegionID: " + RegionID + " InstituteID " + InstituteID);
            }
        }
        public DataSet GetSubAFCDiscrepancyMarkedCount(int RegionID, int InstituteID)
        {
            try
            {
                return dataAccessLayerDao.GetSubAFCDiscrepancyMarkedCount(RegionID, InstituteID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetSubAFCDiscrepancyMarkedCount()", "RegionID: " + RegionID + " InstituteID " + InstituteID);
            }
        }
        public DataSet getRegionWiseApplicationFormListForFCVerification()
        {
            try
            {
                return dataAccessLayerDao.getRegionWiseApplicationFormListForFCVerification();
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getRegionWiseApplicationFormListForFCVerification()", "");
            }
        }
        public DataSet getRequiredDocumentList(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getRequiredDocumentList(PID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getRequiredDocumentList()", "");
            }
        }
        public DataSet GetEFCConfiredCandidateList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                return dataAccessLayerDao.GetEFCConfiredCandidateList(RegionID, InstituteID, AFCID, ConfirmationDate);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetEFCConfiredCandidateList()", "");
            }
        }
        public DataSet GetDiscrepancyMarkedCandidateList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                return dataAccessLayerDao.GetDiscrepancyMarkedCandidateList(RegionID, InstituteID, AFCID, ConfirmationDate);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDiscrepancyMarkedCandidateList()", "");
            }
        }
        public DataSet GetApplicationFormListForPartialFCVerification(string UserLoginID, int UserTypeID)
        {
            try
            {
                return dataAccessLayerDao.GetApplicationFormListForPartialFCVerification(UserLoginID, UserTypeID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationFormListForPartialFCVerification()", "");
            }
        }
        public DataSet GetApplicationFormListForFCVerification(string UserLoginID, int UserTypeID)
        {
            try
            {
                return dataAccessLayerDao.GetApplicationFormListForFCVerification(UserLoginID, UserTypeID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationFormListForFCVerification()", "");
            }
        }
        public DataSet getAFCWiseApplicationFormListForFCVerification(Int16 RegionID)
        {
            try
            {
                return dataAccessLayerDao.getAFCWiseApplicationFormListForFCVerification(RegionID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getAFCWiseApplicationFormListForFCVerification()", "");
            }
        }
        public DataSet GetCandidateEFCAllotted(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.GetCandidateEFCAllotted(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetCandidateEFCAllotted()", "PersonalID :" + PersonalID);
            }
        }

        public bool LockApplicationForm(Int64 PersonalID, string CreatedBy, string CreatedByIpAddress)
        {
            try
            {
                return dataAccessLayerDao.LockApplicationForm(PersonalID, CreatedBy, CreatedByIpAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "LockApplicationForm()", "PersonalID :" + PersonalID);
            }
        }
        public bool UnLockApplicationFormByCandidate(Int64 PersonalID, string CreatedBy, string CreatedByIpAddress)
        {
            try
            {
                return dataAccessLayerDao.UnLockApplicationFormByCandidate(PersonalID, CreatedBy, CreatedByIpAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UnLockApplicationFormByCandidate()", "PersonalID :" + PersonalID);
            }
        }
        public bool CheckFCVerificationStatusForResubmission(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.CheckFCVerificationStatusForResubmission(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CheckFCVerificationStatusForResubmission()", "PersonalID :" + PersonalID);
            }
        }

        //public DataSet GetCandidateEFCAllotted(Int64 PersonalID)
        //{
        //    try
        //    {
        //        return dataAccessLayerDao.GetCandidateEFCAllotted(PersonalID);
        //    }
        //    catch (CustomException CEx)
        //    {
        //        throw CEx;
        //    }
        //    catch (Exception Ex)
        //    {
        //        long messageID = ExceptionMessages.GetMessageDetails();
        //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetCandidateEFCAllotted()", "PersonalID :" + PersonalID);
        //    }
        //}
        public DataSet GetAFCNonRepliedGrievance(string Flag, string To)
        {
            try
            {
                return dataAccessLayerDao.GetAFCNonRepliedGrievance(Flag, To);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetAFCNonRepliedGrievance()", "");
            }
        }
        public DataSet getAFCWiseReport(Int16 RegionID)
        {
            try
            {
                return dataAccessLayerDao.getAFCWiseReport(RegionID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getAFCWiseReport()", "");
            }
        }
        public DataSet GetAFCWiseConfirmationReport(Int16 RegionID)
        {
            try
            {
                return dataAccessLayerDao.GetAFCWiseConfirmationReport(RegionID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetAFCWiseConfirmationReport()", "");
            }
        }
        public DataSet GetApplicationFormStatistics()
        {
            try
            {
                return dataAccessLayerDao.GetApplicationFormStatistics();
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationFormStatistics()", "");
            }
        }
        public DataSet GetEFCRegistrationandConfirmationStatusReport()
        {
            try
            {
                return dataAccessLayerDao.GetEFCRegistrationandConfirmationStatusReport();
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetEFCRegistrationandConfirmationStatusReport()", "");
            }
        }
        public DataSet GetRegionWiseConfirmationReport()
        {
            try
            {
                return dataAccessLayerDao.GetRegionWiseConfirmationReport();
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetRegionWiseConfirmationReport()", "");
            }
        }
        public bool CheckCETDiscrepancy(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.CheckCETDiscrepancy(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CheckCETDiscrepancy()", "PersonalID :" + PersonalID);
            }
        }
        public bool CheckNEETDiscrepancy(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.CheckNEETDiscrepancy(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CheckCETDiscrepancy()", "PersonalID :" + PersonalID);
            }
        }
        public bool SolveCETDiscrepancy(Int64 PersonalID, Int64 CETApplicationFormNo, string CreatedBy, string CreatedByIpAddress)
        {
            try
            {
                return dataAccessLayerDao.SolveCETDiscrepancy(PersonalID, CETApplicationFormNo, CreatedBy, CreatedByIpAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "SolveCETDiscrepancy()", "PersonalID :" + PersonalID);
            }
        }
        //E verification END

        public DataSet getReplyMessageByMessageID(Int64 MessageID)
        {
            try
            {
                return dataAccessLayerDao.getReplyMessageByMessageID(MessageID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getReplyMessageByMessageID()", "");
            }
        }
        public DataSet getRepliedMessagesListToCandidate(string From)
        {
            try
            {
                return dataAccessLayerDao.getRepliedMessagesListToCandidate(From);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getRepliedMessagesListToCandidate()", "");
            }
        }


        //public bool SavebulkDatafromTechnical(DataTable dt)
        //{
        //    return dataAccessLayerDao.SavebulkDatafromTechnical(dt);
        //}

        public List<Fee_PaidFee> GetFailTransections(string PID)
        {
            try
            {
                return BalCommon.ReadTable<Fee_PaidFee>(dataAccessLayerDao.GetFailTransections(PID));
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetFailTransections()", "PersonalID:" + PID);
            }
        }
        public List<Fee_PaidFee> GetAllTransectionByPersonalID(string PID)
        {
            try
            {
                return BalCommon.ReadTable<Fee_PaidFee>(dataAccessLayerDao.GetAllTransectionByPersonalID(PID));
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetAllTransectionByPersonalID()", "PersonalID:" + PID);
            }
        }
        public bool UpdatePaymentReconcelation(Int64 ReferenceNo, Int64 PID, string PayGateId, string ModifiedBy)
        {
            try
            {
                return dataAccessLayerDao.UpdatePaymentReconcelation(ReferenceNo, PID, PayGateId, ModifiedBy);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UpdatePaymentReconcelation()", "");
            }
        }
        public bool SaveSelfVerification(SelfVerification selfVerification)
        {
            try
            {
                return dataAccessLayerDao.SaveSelfVerification(selfVerification);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPdfURL()", "PID: " + selfVerification.PersonalID);
            }
        }
        public bool CheckSelfVerificationIsDone(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.CheckSelfVerificationIsDone(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CheckSelfVerificationIsDone()", "PID: " + PID);
            }
        }
        public DataSet getHSCResult(string SeatNo, string PassingYear)
        {
            try
            {
                return dataAccessLayerDao.getHSCResult(SeatNo, PassingYear);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getHSCResult()", "SeatNo: " + SeatNo);
            }
        }
        public DataSet CheckDiscrepancyDetailsCandidateureType(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.CheckDiscrepancyDetailsCandidateureType(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDiscrepancyDetails()", "");
            }
        }

        public DataSet GetSubAFCWiseSeatAcceptanceGrievanceVerifcationCount(Int16 RegionID, Int32 InstituteID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.GetSubAFCWiseSeatAcceptanceGrievanceVerifcationCount(RegionID, InstituteID, CAPRound);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetSubAFCWiseSeatAcceptanceGrievanceVerifcationCount()", "RegionID: " + RegionID + " InstituteID: " + InstituteID);
            }
        }
        public DataSet GetSubAFCWiseSeatAcceptanceGrievanceRejectedCount(Int16 RegionID, Int32 InstituteID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.GetSubAFCWiseSeatAcceptanceGrievanceRejectedCount(RegionID, InstituteID, CAPRound);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetSubAFCWiseSeatAcceptanceGrievanceRejectedCount()", "RegionID: " + RegionID + " InstituteID: " + InstituteID);
            }
        }

        public DataSet GetSubAFCWiseSeatAcceptanceGrievancePickedupCount(Int16 RegionID, Int32 InstituteID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.GetSubAFCWiseSeatAcceptanceGrievancePickedupCount(RegionID, InstituteID, CAPRound);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetSubAFCWiseSeatAcceptanceGrievancePickedupCount()", "RegionID: " + RegionID + " InstituteID: " + InstituteID);
            }
        }
        public DataSet GetSubAFCWiseSeatAcceptanceGrievanceApprovedCount(Int16 RegionID, Int32 InstituteID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.GetSubAFCWiseSeatAcceptanceGrievanceApprovedCount(RegionID, InstituteID, CAPRound);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetSubAFCWiseSeatAcceptanceGrievanceApprovedCount()", "RegionID: " + RegionID + " InstituteID: " + InstituteID);
            }
        }

        public DataSet GetSeatAcceptanceGrievanceListForVerification(Int16 RegionID, Int32 InstituteID, Int32 AFCID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.GetSeatAcceptanceGrievanceListForVerification(RegionID, InstituteID, AFCID, CAPRound);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetSeatAcceptanceGrievanceListForVerification()", "RegionID: " + RegionID + " InstituteID: " + InstituteID + " AFCID:" + AFCID);
            }
        }
        public DataSet GetSeatAcceptanceRejectedGrievanceList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.GetSeatAcceptanceRejectedGrievanceList(RegionID, InstituteID, AFCID, CAPRound);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetSeatAcceptanceRejectedGrievanceList()", "RegionID: " + RegionID + " InstituteID: " + InstituteID + " AFCID:" + AFCID);
            }
        }
        public DataSet GetSeatAcceptancePickedupGrievanceList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.GetSeatAcceptancePickedupGrievanceList(RegionID, InstituteID, AFCID, CAPRound);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetSeatAcceptancePickedupGrievanceList()", "RegionID: " + RegionID + " InstituteID: " + InstituteID + " AFCID:" + AFCID);
            }
        }
        public DataSet GetSeatAcceptanceApprovedGrievanceList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.GetSeatAcceptanceApprovedGrievanceList(RegionID, InstituteID, AFCID, CAPRound);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetSeatAcceptanceApprovedGrievanceList()", "RegionID: " + RegionID + " InstituteID: " + InstituteID + " AFCID:" + AFCID);
            }
        }

        public DataSet GetRegionWiseSeatAcceptanceGrievanceStatus(string GrievanceStatusFlag, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.GetRegionWiseSeatAcceptanceGrievanceStatus(GrievanceStatusFlag, CAPRound);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetRegionWiseSeatAcceptanceGrievanceStatus()", "GrievanceStatusFlag: " + GrievanceStatusFlag);
            }
        }

        public DataSet GetAFCWiseSeatAcceptanceGrievanceStatus(Int16 RegionID, string GrievanceStatusFlag, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.GetAFCWiseSeatAcceptanceGrievanceStatus(RegionID, GrievanceStatusFlag, CAPRound);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetAFCWiseSeatAcceptanceGrievanceStatus()", "RegionID: " + RegionID + " GrievanceStatusFlag: " + GrievanceStatusFlag);
            }
        }

        public DataSet getSelfVerificationDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSelfVerificationDetails(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "getSelfVerificationDetails()", "PID: " + PID);
            }
        }

        public DataSet GetSelfVerificationstatus(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.GetSelfVerificationstatus(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetSelfVerificationstatus()", "PersonalID: " + PersonalID);
            }
        }

        public DataSet GetSeatAcceptanceGrivanceStatusByPID(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.GetSeatAcceptanceGrivanceStatusByPID(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(),
                    "GetSeatAcceptanceGrivanceStatusByPID()", "PersonalID: " + PersonalID);
            }
        }


        public bool EditConfirmedApplicationFormSelfVerification(Int64 PID, Int32 CAPRound, string NewGenderCode,
             Int32 IsGenderChanged, Int32 IsCandidatureTypeChanged, Int32 IsCategoryChanged, Int32 IsEWSChanged, Int32 IsPHTypeChanged, Int32 IsDefenceTypeChanged, Int32 IsOrphanChanged,
             Int32 IsTFWSChanged, Int32 IsLinguisticMinorityChanged, Int32 IsReligiousMinorityChanged, Int32 IsIGDChanged,
             Int32 IsSSCMathematicsMarksChanged, Int32 IsSSCTotalMarksChanged, Int32 IsHSCPhysicsMarksChanged, Int32 IsHSCChemistryMarksChanged,
                 Int32 IsHSCEnglishMarksChanged, Int32 IsHSCTotalMarksChanged, Int32 IsHSCSubjectMarksChanged, Int32 IsDiplomaMarksChanged,
             QualificationDetails obj,
             Int32 IsAllotmentCancelled, string RequestStatus, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.EditConfirmedApplicationFormSelfVerification(PID, CAPRound, NewGenderCode,
                                        IsGenderChanged, IsCandidatureTypeChanged, IsCategoryChanged, IsEWSChanged, IsPHTypeChanged, IsDefenceTypeChanged, IsOrphanChanged,
                                        IsTFWSChanged, IsLinguisticMinorityChanged, IsReligiousMinorityChanged, IsIGDChanged,
                                        IsSSCMathematicsMarksChanged, IsSSCTotalMarksChanged, IsHSCPhysicsMarksChanged, IsHSCChemistryMarksChanged,
                                         IsHSCEnglishMarksChanged, IsHSCTotalMarksChanged, IsHSCSubjectMarksChanged, IsDiplomaMarksChanged,
                                        obj,
                                        IsAllotmentCancelled, RequestStatus, Comments, ModifiedBy, ModifiedByIPAddress);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "EditConfirmedApplicationFormSelfVerification()", "PID" + PID.ToString());
            }
        }

        public bool UpdateSeatAcceptanceGrievanceStaus(Int64 PID, Int32 CAPRound, string RequestStatus, string Comments, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UpdateSeatAcceptanceGrievanceStaus(PID, CAPRound, RequestStatus, Comments, ModifiedBy, ModifiedByIPAddress);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UpdateSeatAcceptanceGrievanceStaus()", "PID" + PID.ToString());
            }
        }

        public DataSet GetRegionWiseSeatAcceptanceGrievanceConfirmationReport()
        {
            try
            {
                return dataAccessLayerDao.GetRegionWiseSeatAcceptanceGrievanceConfirmationReport();
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetRegionWiseSeatAcceptanceGrievanceConfirmationReport()", "");
            }
        }

        public DataSet GetAFCWiseSeatAcceptanceGrievanceConfirmationReport(Int16 RegionID)
        {
            try
            {
                return dataAccessLayerDao.GetAFCWiseSeatAcceptanceGrievanceConfirmationReport(RegionID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetAFCWiseSeatAcceptanceGrievanceConfirmationReport()", "RegionID : " + RegionID.ToString());
            }
        }

        public bool UpdateSeatAcceptanceGrievancePickedupStatus(Int64 PID, string UserLoginID, Int32 CAPRound, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UpdateSeatAcceptanceGrievancePickedupStatus(PID, UserLoginID, CAPRound, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UpdateSeatAcceptanceGrievancePickedupStatus()", "");
            }
        }

        public DataSet CheckFCForSeatAcceptanceGrievance(string UserLoginID, long PersonalID, long ID, string IPAddress)
        {
            try
            {
                return dataAccessLayerDao.CheckFCForSeatAcceptanceGrievance(UserLoginID, PersonalID, ID, IPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CheckFCForSeatAcceptanceGrievance()", "");
            }
        }
        public bool CategoryEWSConverttoOPEN(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.CategoryEWSConverttoOPEN(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CategoryEWSConverttoOPEN()", "PID: " + PID);
            }
        }
        public bool UpdateCategoryEWSConverttoOPEN(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UpdateCategoryEWSConverttoOPEN(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "UpdateCategoryEWSConverttoOPEN()", "PID: " + PID);
            }
        }
        public DataSet CheckCandidateValid(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.CheckCandidateValid(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckCandidateValid()", "PID : " + PID);
            }
        }
        public DataSet CheckCandidateUpladedDoc(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.CheckCandidateUpladedDoc(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckCandidateUpladedDoc()", "PID : " + PID);
            }
        }

        public bool CheckCandidateinAllotmentCancellationRemark(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.CheckCandidateinAllotmentCancellationRemark(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckCandidateinAllotmentCancellationRemark()", "PID: " + PID);
            }
        }
        public bool CancelSelfVerificationSeatAcceptanceForm(Int64 PID, string UserLoginID, string IPAddress, string Comment)
        {
            try
            {
                return dataAccessLayerDao.CancelSelfVerificationSeatAcceptanceForm(PID, UserLoginID, IPAddress, Comment);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CancelSelfVerificationSeatAcceptanceForm()", "PID : " + PID + "UserLoginID :" + UserLoginID);
            }
        }

        public bool ConfirmCVCNCLEWSApplication(Int64 PID, string ModifiedBy, string ModifiedByIPAddress, string CVC, string NCL, string EWS)
        {
            try
            {
                return dataAccessLayerDao.ConfirmCVCNCLEWSApplication(PID, ModifiedBy, ModifiedByIPAddress, CVC, NCL, EWS);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "ConfirmCVCNCLEWSApplication()", "PID : " + PID + "ModifiedBy :" + ModifiedBy);
            }
        }

        public DataSet GetDocumentListForDataVerificationByStepIDCVCTVCNCLEWS(Int64 PID, Int32 ApplicationFormStepID)
        {
            try
            {
                return dataAccessLayerDao.GetDocumentListForDataVerificationByStepIDCVCTVCNCLEWS(PID, ApplicationFormStepID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetDocumentListForDataVerificationByStepIDCVCTVCNCLEWS()", "PID : " + PID);
            }
        }

        public DataSet GetDocumentListForDocumentVerificationByStepIDCVCTVCNCLEWS(Int64 PID, Int32 ApplicationFormStepID)
        {
            try
            {
                return dataAccessLayerDao.GetDocumentListForDocumentVerificationByStepIDCVCTVCNCLEWS(PID, ApplicationFormStepID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetDocumentListForDocumentVerificationByStepIDCVCTVCNCLEWS()", "PID : " + PID);
            }
        }
        public DataSet GetDiscrepancyListByStepIDCVCTVCNCLEWS(Int64 PID, int ApplicationFormStepID)
        {
            try
            {
                return dataAccessLayerDao.GetDiscrepancyListByStepIDCVCTVCNCLEWS(PID, ApplicationFormStepID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetDiscrepancyListByStepIDCVCTVCNCLEWS()", "PID : " + PID);
            }
        }

        public DataSet getCVCNCLEWSReciptStatistic()
        {
            try
            {
                return dataAccessLayerDao.getCVCNCLEWSReciptStatistic();
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getCVCNCLEWSReciptStatistic()", "");
            }
        }

        public Int16 UnlockOptionFormCAPRound2(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UnlockOptionFormCAPRound2(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UnlockOptionFormCAPRound2()", "PersonalID :" + PID);
            }
        }
        public Int16 CheckUnlockOptionFormCAPRound2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.CheckUnlockOptionFormCAPRound2(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UnlockOptionFormCAPRound2()", "PersonalID :" + PID);
            }
        }

        public string GetAdmissionCategory(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetAdmissionCategory(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetAdmissionCategory()", "PersonalID :" + PID);
            }
        }


        public DataSet downloadRegisterdCandidateDataWithAdmissionDetails()
        {
            try
            {
                return dataAccessLayerDao.downloadRegisterdCandidateDataWithAdmissionDetails();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "downloadRegisterdCandidateDataWithAdmissionDetails()", "");
            }
        }
        public DataSet GetDateWiseFCSlotBookingReport(int UserTypeID, string UserLoginID, string date)
        {
            try
            {
                return dataAccessLayerDao.GetDateWiseFCSlotBookingReport(UserTypeID, UserLoginID, date);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDateWiseFCSlotBookingReport()", "UserTypeID" + UserTypeID + "UserLoginID " + UserLoginID + " date: " + date);
            }
        }
        public DataSet getFCWiseSlotBookingStausReport()
        {
            try
            {
                return dataAccessLayerDao.getFCWiseSlotBookingStausReport();
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getFCWiseSlotBookingStausReport()", "");
            }
        }
        public DataSet GetDatewiseSlotsForFC(string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.GetDatewiseSlotsForFC(UserLoginID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDatewiseSlotsForFC()", "");
            }
        }
        public bool UpdateDatewiseCapacityForFC(Int64 FCDateID, int AvilableSlots, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UpdateDatewiseCapacityForFC(FCDateID, AvilableSlots, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UpdateDatewiseCapacityForFC()", "FCDateID:" + FCDateID + " ModifiedBy:" + ModifiedBy);
            }
        }
        public DataSet GetRegionwiseSlotBookingStausReport()
        {
            try
            {
                return dataAccessLayerDao.GetRegionwiseSlotBookingStausReport();
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetRegionwiseSlotBookingStausReport()", "");
            }
        }
        public DataSet GetFCWiseSlotBookingList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                return dataAccessLayerDao.GetFCWiseSlotBookingList(RegionID, InstituteID, AFCID, ConfirmationDate);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetFCWiseSlotBookingList()", "AFCID: " + AFCID);
            }
        }
        public bool UpdateContactedDetailsFromFC(Int64 PersonalID, string Message, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UpdateContactedDetailsFromFC(PersonalID, Message, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UpdateContactedDetailsFromFC()", "PersonalID:" + PersonalID);
            }
        }
        public DataSet GetSlotSelectedNotConfirmedList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                return dataAccessLayerDao.GetSlotSelectedNotConfirmedList(RegionID, InstituteID, AFCID, ConfirmationDate);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetSlotSelectedNotConfirmedList()", "AFCID: " + AFCID);
            }
        }

        public bool CheckIsSlotBooked(Int64 PersonalID)
        {
            try
            {
                return dataAccessLayerDao.CheckIsSlotBooked(PersonalID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UpdateContactedDetailsFromFC()", "PersonalID:" + PersonalID);
            }
        }
        public bool isApplicationFormConfirmedUsingThisEMailID(string EmailID, Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isApplicationFormConfirmedUsingThisEMailID(EmailID, PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "isApplicationFormConfirmedUsingThisEMailID()", "");
            }
        }

        public DataSet getNEETResult(string NEETRollNo, string NEETDOB)
        {
            try
            {
                return dataAccessLayerDao.getNEETResult(NEETRollNo, NEETDOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getNEETResult()", "");
            }
        }
        public DataSet getFeeDetailsForSupport(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getFeeDetailsForSupport(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getFeeDetailsForSupport()", "");
            }
        }
        public DataSet GetApplicationFormAcknowledgeFormMaxVersionNo(Int64 PID, string VersionNoFlag)
        {
            try
            {
                return dataAccessLayerDao.GetApplicationFormAcknowledgeFormMaxVersionNo(PID, VersionNoFlag);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationFormVersionNo()", "");
            }
        }
        public DataSet getStepIDforSupport(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getStepIDforSupport(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getStepIDforSupport()", "");
            }
        }

        public DataSet GetDocStatusForSupport(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetDocStatusForSupport(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDocStatusForSupport()", "");
            }
        }
        public bool GetPreferancedOptionsListOnlyTFWSSelect(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetPreferancedOptionsListOnlyTFWSSelect(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPreferancedOptionsListOnlyTFWSSelect()", " ");
            }
        }
        public string getBenefitTakenByCandidate(Int64 PID, Int32 CAPRound)
        {
            try
            {
                return dataAccessLayerDao.getBenefitTakenByCandidate(PID, CAPRound);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getBenefitTakenByCandidate()", "");
            }
        }
        public DataSet GetNEETConfiredCandidateList(Int16 RegionID, Int32 InstituteID, Int32 AFCID, string ConfirmationDate)
        {
            try
            {
                return dataAccessLayerDao.GetNEETConfiredCandidateList(RegionID, InstituteID, AFCID, ConfirmationDate);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetNEETConfiredCandidateList()", "");
            }
        }
        public bool GetPreferancedOptionsListOnlyTFWSSelectCap2(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetPreferancedOptionsListOnlyTFWSSelectCap2(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPreferancedOptionsListOnlyTFWSSelectCap2()", " ");
            }
        }
        public bool isContinueWithReceiptCandidateExist(Int64 PID)
        {
            return dataAccessLayerDao.isContinueWithReceiptCandidateExist(PID);
        }

        #region ARA_Module
        // FUNCTION FOR ARA MODULE
        public Int32 getAdmissionApprovalFeePaidAmount(Int64 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.getAdmissionApprovalFeePaidAmount(InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdmissionApprovalFeePaidAmount()", "");
            }
        }

        public DataSet getAdmissionApprovalFeeDetails(Int64 InstituteID, string FeeType, string FeeLockStatus)
        {
            try
            {
                return dataAccessLayerDao.getAdmissionApprovalFeeDetails(InstituteID, FeeType, FeeLockStatus);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdmissionApprovalFeeDetails()", "");
            }
        }
        public bool saveAdmissionApprovalFeeDetails(Int64 InstituteID, AdmissionApprovalFeeDetails obj, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveAdmissionApprovalFeeDetails(InstituteID, obj, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "saveAdmissionApprovalFeeDetails()", "");
            }
        }
        public Int32 getAdmissionApprovalFeeToBePaid(Int32 FeeGroupID, Int32 PhaseID, Int32 UserTypeID, Int64 PayeeID)
        {
            try
            {
                return dataAccessLayerDao.getAdmissionApprovalFeeToBePaid(FeeGroupID, PhaseID, UserTypeID, PayeeID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdmissionApprovalFeeToBePaid()", "");
            }
        }

        public DataSet getAdmissionApprovalFeeDetailsTable(Int32 FeeGroupID, Int32 PhaseID, Int32 UserTypeID, Int64 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.getAdmissionApprovalFeeDetailsTable(FeeGroupID, PhaseID, UserTypeID, InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdmissionApprovalFeeDetailsTable()", "");
            }
        }



        public DataSet getARADashBoardForARAAdmin(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getARADashBoardForARAAdmin(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARADashBoardForARAAdmin()", "");
            }
        }
        public DataSet getARADashBoardForRO(string RO, string Flag)
        {
            try
            {
                return dataAccessLayerDao.getARADashBoardForRO(RO, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARADashBoardForRO()", "");
            }
        }
        public DataSet getARADashBoardForInstitute(string InstituteCode, string Flag)
        {
            try
            {
                return dataAccessLayerDao.getARADashBoardForInstitute(InstituteCode, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getARADashBoardForInstitute()", "");
            }
        }

        public DataSet getROwiseAdmissionApprovalFeePaidDetails(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getROwiseAdmissionApprovalFeePaidDetails(Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getROwiseAdmissionApprovalFeePaidDetails()", "");
            }
        }

        public DataSet getInstitutewiseAdmissionApprovalFeePaidDetails(string ROName, string Flag)
        {
            try
            {
                return dataAccessLayerDao.getInstitutewiseAdmissionApprovalFeePaidDetails(ROName, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getInstitutewiseAdmissionApprovalFeePaidDetails()", "");
            }
        }

        public DataSet GetAdmittedCandidateListToROVerification(string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.GetAdmittedCandidateListToROVerification(ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetAdmittedCandidateListToROVerification()", "");
            }
        }
        public DataSet GetAdmittedCandidateListToAraVerification(string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.GetAdmittedCandidateListToAraVerification(ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetAdmittedCandidateListToAraVerification()", "");
            }
        }
        public DataSet GetAdmittedCandidateListToInstituteVerification(string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.GetAdmittedCandidateListToInstituteVerification(ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetAdmittedCandidateListToInstituteVerification()", "");
            }
        }
        public DataSet GetDocumentListForInstituteToRo(Int64 PID)
        {
            return dataAccessLayerDao.GetDocumentListForInstituteToRo(PID);
        }
        public bool UpdateDocumentSubmissionForInstituteToRo(Int64 PID, string XMLString, string ModifiedBy, string ModifiedByIPAddress, string InstituteByRemark)
        {
            try
            {
                return dataAccessLayerDao.UpdateDocumentSubmissionForInstituteToRo(PID, XMLString, ModifiedBy, ModifiedByIPAddress, InstituteByRemark);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "UpdateDocumentSubmissionForInstituteToRo()", "");
            }
        }

        //END OF FUNCTION FOR ARA MODULE
        #endregion
        public DataSet getLoginData(string LoginID, string BrowserName, string BrowserVersion, string IPAddress)
        {
            try
            {
                return dataAccessLayerDao.getLoginData(LoginID, BrowserName, BrowserVersion, IPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetApplicationStatusReport()", "");
            }
        }
        public DataSet getAllotedInstitutesForSO(string SOCode, int GrdNo)
        {
            try
            {
                return dataAccessLayerDao.getAllotedInstitutesForSO(SOCode, GrdNo);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getAllotedInstitutesForSO()", "");
            }
        }
        public DataSet getCandidateListforMV(Int64 InstCode, string Flag)
        {
            try
            {
                return dataAccessLayerDao.getCandidateListforMV(InstCode, Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getCandidateListforMV()", "");
            }
        }
        public string addMVSO(string ScrutinyOfficerName, string ScrutinyOfficerMobileNo, string ScrutinyOfficerEmailID, string ScrutinyOfficerDesignation, string Password, string CreatedBy, string CreatedByIPAddress, int RegionID, string Password2)
        {
            try
            {
                return dataAccessLayerDao.addMVSO(ScrutinyOfficerName, ScrutinyOfficerMobileNo, ScrutinyOfficerEmailID, ScrutinyOfficerDesignation, Password, CreatedBy, CreatedByIPAddress, RegionID, Password2);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "addSubAFC()", "");
            }
        }
        public DataSet getMVSOList(Int64 RegionID)
        {
            try
            {
                //return dataAccessLayerDao.getSubAFCList(RegionID);
                return dataAccessLayerDao.getMVSOList(RegionID);

            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getSubAFCList()", "");
            }
        }
        public DataSet getInstituteList(Int64 RegionID)
        {
            try
            {
                //return dataAccessLayerDao.getSubAFCList(RegionID);
                return dataAccessLayerDao.getInstituteList(RegionID);

            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getInstituteList()", "");
            }
        }

        public bool updateMVSO(Int64 SOID, string ScrutinyOfficerName, string ScrutinyOfficerMobileNo, string ScrutinyOfficerEmailId, string ScrutinyOfficerDesignation, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.updateMVSO(SOID, ScrutinyOfficerName, ScrutinyOfficerMobileNo, ScrutinyOfficerEmailId, ScrutinyOfficerDesignation, ModifiedBy, ModifiedByIPAddress);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "updateSubAFC()", "");
            }
        }
        public bool deleteMVSO(Int64 SOID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.deleteMVSO(SOID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "deleteMVSO()", "");


            }
        }


        public DataSet getInstitutelistSOMappingForRO(string RO, char Flag)
        {
            try
            {
                return dataAccessLayerDao.getInstitutelistSOMappingForRO(RO, Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getInstitutelistSOMappingForRO()", "");
            }
        }
        public DataSet SaveInstituteMappingforSO(Int64 SOID, Int64 instituteID, string CreatedBy, string CreatedByIPAddress, Int64 ChoiceCode, Int64 ChoiceTFWS)
        {
            try
            {
                // return dataAccessLayerDao.GetVerifyingMismatchHSCResultData(PID);
                return dataAccessLayerDao.SaveInstituteMappingforSO(SOID, instituteID, CreatedBy, CreatedByIPAddress, ChoiceCode, ChoiceTFWS);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetVerifyingMismatchHSCResultData()", "");
            }
        }
        public DataSet UpdateInstituteMappingforSO(Int64 SOID, Int64 instituteID, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                // return dataAccessLayerDao.GetVerifyingMismatchHSCResultData(PID);
                return dataAccessLayerDao.UpdateInstituteMappingforSO(SOID, instituteID, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "UpdateInstituteMappingforSO()", "");
            }
        }
        public DataSet getMasterMVDiscrepancy()
        {
            try
            {
                return dataAccessLayerDao.getMasterMVDiscrepancy();
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getMasterMVDiscrepancy()", "");
            }

        }
        public bool saveMVDiscrepancy(MeritListVerificaton obj, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.saveMVDiscrepancy(obj, ModifiedBy, ModifiedByIPAddress);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "saveMVDiscrepancy()", "");
            }

        }
        public bool saveInstituteVarificationStatus(Int64 InstCode, char Verified, string CreatedBy, string CreatedIPAddress, char Flg, string ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.saveInstituteVarificationStatus(InstCode, Verified, CreatedBy, CreatedIPAddress, Flg, ChoiceCode);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "saveInstituteVarificationStatus()", "");
            }
        }
        public bool saveInstituteVarificationARA(Int64 InstCode, char Verified, string CreatedBy, string CreatedIPAddress, DateTime ApprovalDate)
        {
            try
            {
                return dataAccessLayerDao.saveInstituteVarificationARA(InstCode, Verified, CreatedBy, CreatedIPAddress, ApprovalDate);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "saveInstituteVarificationARA()", "");
            }
        }
        public bool saveInstituteVarifyRODTE(Int64 InstCode, char Verified, string CreatedBy, string CreatedIPAddress, char Flg, string Remarks)
        {
            try
            {
                return dataAccessLayerDao.saveInstituteVarifyRODTE(InstCode, Verified, CreatedBy, CreatedIPAddress, Flg, Remarks);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "saveInstituteVarifyRODTE()", "");
            }

        }
        public MVSOProfile getMVSOProfile(Int64 SOID)
        {
            try
            {
                return BalCommon.FillMVSOProfile(dataAccessLayerDao.getMVSOProfile(SOID));
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getMVSOProfile()", "");
            }
        }
        public DataSet getVerifiedBySO(Int64 SOID)
        {
            try
            {
                return dataAccessLayerDao.getVerifiedBySO(SOID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getAllotmentReportForSO()", "");
            }
        }
        public DataSet getCandidateVerifiedBySO(Int64 SOID, string InstCode)
        {
            try
            {
                return dataAccessLayerDao.getVerifiedBySO(SOID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getAllotmentReportForSO()", "");
            }
        }
        public DataSet getRODashboardForMV(string RO, char Flag)
        {
            try
            {
                return dataAccessLayerDao.getRODashboardForMV(RO, Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getRODashboardForMV()", "");
            }
        }
        public DataSet getMVVerifyStatus(int SOID)
        {
            try
            {
                return dataAccessLayerDao.getMVVerifyStatus(SOID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getMVVerifyStatus()", "");
            }
        }
        public DataSet getVerifiedByInst(Int64 InstCode, Char Flag)
        {
            try
            {
                return dataAccessLayerDao.getVerifiedByInst(InstCode, Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getVerifiedByInst()", "");
            }
        }
        public DataSet getMVSOLoad(Int64 SOID)
        {
            try
            {
                return dataAccessLayerDao.getMVSOLoad(SOID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getMVSOLoad()", "");
            }
        }
        public DataSet getMLVCertificate(Int64 InstCode)
        {
            try
            {
                return dataAccessLayerDao.getMLVCertificate(InstCode);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getMLVCertificate()", "");
            }
        }
        public bool updateCandidateSrNo(Int64 SRNO, Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.updateCandidateSrNo(SRNO, PID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "updateCandidateSrNo()", "");
            }
        }
        public DataSet getDTEDashboardForMV(char Flag)
        {
            try
            {
                return dataAccessLayerDao.getDTEDashboardForMV(Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getDTEDashboardForMV()", "");
            }
        }
        public DataSet getSOStats(string SOCode)
        {
            try
            {
                return dataAccessLayerDao.getSOStats(SOCode);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getSOStats()", "");
            }
        }
        public string getCertificateRemarks(string InstituteCode, char Flg)
        {
            try
            {
                return dataAccessLayerDao.getCertificateRemarks(InstituteCode, Flg);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getCertificateRemarks()", "");
            }
        }
        public DataSet getAllotmentReportForSO(string ChoiceCode, string Flg)
        {
            try
            {
                return dataAccessLayerDao.getAllotmentReportForSO(ChoiceCode, Flg);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getAllotmentReportForSO()", "");
            }
        }


        public DataSet getCompositeReportForInstitute_ARAFeeReceipt(string InstituteCode, string Flag)
        {
            try
            {
                return dataAccessLayerDao.getCompositeReportForInstitute_ARAFeeReceipt(InstituteCode, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCompositeReportForInstitute_ARAFeeReceipt()", "");
            }
        }
        public bool saveProposalStatus(string InstCD, string Submitted, string CreatedBy, string CreatedByIPAddress, DateTime ProposalDate)
        {
            try
            {
                return dataAccessLayerDao.saveProposalStatus(InstCD, Submitted, CreatedBy, CreatedByIPAddress, ProposalDate);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "saveProposalStatus()", "");
            }
        }
        public DataSet getARADashboardForMV(Char Flag)
        {
            try
            {
                return dataAccessLayerDao.getARADashboardForMV(Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getDTEDashboardForMV()", "");
            }
        }

        public DataSet getMasterUserType()
        {
            try
            {
                return dataAccessLayerDao.getMasterUserType();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterUserType()", "");
            }
        }
        public DataSet getMasterUserForReconciliation()
        {
            try
            {
                return dataAccessLayerDao.getMasterUserForReconciliation();
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterUserForReconciliation()", "");
            }
        }
        public bool chkDuplicateMasterUserName(string LoginId)
        {
            try
            {
                return dataAccessLayerDao.chkDuplicateMasterUserName(LoginId);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "chkDuplicateMasterUserName()", "");
            }
        }
        public bool addMasterUser(string UserName, string LoginId, string UserPassword, string EncryptedPassword, Int64 UserTypeId, string UserMobNo, string UserEmailId, string CreatedBy, string CreatedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.addMasterUser(UserName, LoginId, UserPassword, EncryptedPassword, UserTypeId, UserMobNo, UserEmailId, CreatedBy, CreatedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "chkDuplicateMasterUserName()", "");
            }
        }
        public DataSet CandidateApprovalReport(Int64 InstCode, string Flag)
        {
            try
            {
                return dataAccessLayerDao.CandidateApprovalReport(InstCode, Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CandidateApprovalReport()", "");
            }
        }
        public DataSet ARADashboardReport(string Flag)
        {
            try
            {
                return dataAccessLayerDao.ARADashboardReport(Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "ARADashboardReport()", "");
            }
        }
        public DataSet ProposalSubmittedInstitutes(string Region)
        {
            try
            {
                return dataAccessLayerDao.ProposalSubmittedInstitutes(Region);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "ProposalSubmittedInstitutes()", "");
            }
        }
        public DataSet ARAReportforMV(string Flag)
        {
            try
            {
                return dataAccessLayerDao.ARAReportforMV(Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "ARAReportforMV()", "");
            }
        }
        public DataSet ARAInstituteList(string Region)
        {
            try
            {
                return dataAccessLayerDao.ARAInstituteList(Region);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "ARAInstituteList()", "");
            }
        }
        public DataSet ARAFeesPaidInstitutes(string Region)
        {
            try
            {
                return dataAccessLayerDao.ARAFeesPaidInstitutes(Region);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "ARAFeesPaidInstitutes()", "");
            }
        }
        public DataSet ARAInstituteListConfirmedbyROAndDTE(string Region, string Flag)
        {
            try
            {
                return dataAccessLayerDao.ARAInstituteListConfirmedbyROAndDTE(Region, Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "ARAInstituteListConfirmedbyROAndDTE()", "");
            }
        }
        public DataSet ARAVerificationDate(Int64 InstCode)
        {
            try
            {
                return dataAccessLayerDao.ARAVerificationDate(InstCode);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "ARAVerificationDate()", "");
            }
        }
        public string isApplicationFormRegisteredUsingThisMobileNo(string MobileNo, Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.isApplicationFormRegisteredUsingThisMobileNo(MobileNo, PID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "isApplicationFormRegisteredUsingThisMobileNo()", "");
            }
        }
        public DataSet getVerifyOTPVerificationAttemptsDetails(string ApplicationID, string ModifiedByIPAddress, int OTPType, string Template)
        {
            try
            {
                return dataAccessLayerDao.getVerifyOTPVerificationAttemptsDetails(ApplicationID, ModifiedByIPAddress, OTPType, Template);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getVerifyOTPVerificationAttemptsDetails()", "");
            }
        }
        public bool CheckOldCandidatePassword(string LoginID, string OLDCandidatePassword)
        {
            try
            {
                return dataAccessLayerDao.CheckOldCandidatePassword(LoginID, OLDCandidatePassword);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckOldCandidatePassword()", "");
            }
        }
        public bool IsApplicationFormRegisteredUsingThisHSCSeatNo(Int64 PID, Int16 StepID, string HSCPassingYear, string HSCSeatNo, Int16 HSCBoardID)
        {
            try
            {
                return dataAccessLayerDao.IsApplicationFormRegisteredUsingThisHSCSeatNo(PID, StepID, HSCPassingYear, HSCSeatNo, HSCBoardID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "IsApplicationFormRegisteredUsingThisHSCSeatNo()", "");
            }
        }
        public DataSet getHSCSeatNo(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getHSCSeatNo(PID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getHSCSeatNo()", "");
            }
        }
        public DataSet GetApplicationIDIsFormRegisteredUsingHSCSeatNo(Int64 PID, string HSCPassingYear, string HSCSeatNo, Int16 HSCBoardID)
        {
            try
            {
                return dataAccessLayerDao.GetApplicationIDIsFormRegisteredUsingHSCSeatNo(PID, HSCPassingYear, HSCSeatNo, HSCBoardID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationIDIsFormRegisteredUsingHSCSeatNo()", "");
            }
        }
        public DataSet IsApplicationFormRegisteredUsingThisNEETRollNo(Int64 PID, string NEETRollNo, Int16 StepID)
        {
            try
            {
                return dataAccessLayerDao.IsApplicationFormRegisteredUsingThisNEETRollNo(PID, NEETRollNo, StepID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "IsApplicationFormRegisteredUsingThisNEETRollNo()", "");
            }
        }
        public DataSet ISApplicationFormRegisteredUsingThisCETApplicationNo(Int64 CETApplicationFormNo, Int16 StepID, Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.ISApplicationFormRegisteredUsingThisCETApplicationNo(CETApplicationFormNo, StepID, PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "ISApplicationFormRegisteredUsingThisCETApplicationNo()", "");
            }
        }
        public bool IsApplicationFormConfirmedUsingThisHSCSeatNo(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.IsApplicationFormConfirmedUsingThisHSCSeatNo(PID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "IsApplicationFormConfirmedUsingThisHSCSeatNo()", "");
            }
        }
        public DataSet GetApplicationIDIsFormConfirmedUsingHSCSeatNo(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetApplicationIDIsFormConfirmedUsingHSCSeatNo(PID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetApplicationIDIsFormConfirmedUsingHSCSeatNo()", "");
            }
        }
        public bool IsEditApplicationFormConfirmedUsingThisHSCSeatNo(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.IsEditApplicationFormConfirmedUsingThisHSCSeatNo(PID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "IsEditApplicationFormConfirmedUsingThisHSCSeatNo()", "");
            }
        }
        public DataSet IsApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp(Int64 PID, Int16 CandidatureTypeID)
        {
            try
            {
                return dataAccessLayerDao.IsApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp(PID, CandidatureTypeID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "IsApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp()", "");
            }
        }
        public DataSet EditApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp(Int64 PID, Int16 CandidatureTypeID)
        {
            try
            {
                return dataAccessLayerDao.EditApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp(PID, CandidatureTypeID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "EditApplicationFormConfirmedUsingThisCETApplicationNoCheckCandidatureTyp()", "");
            }
        }
        public DataSet GetAdmissionCategoryforReceipt(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetAdmissionCategoryforReceipt(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetAdmissionCategoryforReceipt()", "PersonalID :" + PID);
            }
        }
        public bool isCandidateNameAppearedInProvisionalMeritList(string ApplicationID)
        {
            return dataAccessLayerDao.isCandidateNameAppearedInProvisionalMeritList(ApplicationID);
        }
        public bool CheckCandidateCVCTVCEWSStatus(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.CheckCandidateCVCTVCEWSStatus(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckCandidateCVCTVCEWSStatus()", "");
            }
        }
        public bool ConfirmFCCVCNCLEWSApplication(Int64 PID, string ModifiedBy, string ModifiedByIPAddress, string CVC, string NCL, string EWS)
        {
            try
            {
                return dataAccessLayerDao.ConfirmFCCVCNCLEWSApplication(PID, ModifiedBy, ModifiedByIPAddress, CVC, NCL, EWS);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "ConfirmFCCVCNCLEWSApplication()", "PID : " + PID + "ModifiedBy :" + ModifiedBy);
            }
        }
        public bool checkApplicationFormModifiedDetailsForCVCTVCEWS(Int64 PID, Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.checkApplicationFormModifiedDetailsForCVCTVCEWS(PID, UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "checkApplicationFormModifiedDetailsForCVCTVCEWS()", "");
            }
        }
        public bool GetPreferancedOptionsListOnlyTFWSSelectCap3(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetPreferancedOptionsListOnlyTFWSSelectCap3(PID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetPreferancedOptionsListOnlyTFWSSelectCap3()", " ");
            }
        }
        public bool OnlyThisCandidateOperation(string ApplicationID)
        {
            return dataAccessLayerDao.OnlyThisCandidateOperation(ApplicationID);
        }
        public DataSet getAdmictionCancellationandAdmitedDetails(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getAdmictionCancellationandAdmitedDetails(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdmictionCancellationandAdmitedDetails()", "");
            }
        }
        public bool CheckISOTPverifyed(Int64 PID, int OTPType)
        {
            try
            {
                return dataAccessLayerDao.CheckISOTPverifyed(PID, OTPType);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckISOTPverifyed()", "");
            }
        }
        public bool AuthenticateCandidateisActive(string ApplicationID)
        {
            return dataAccessLayerDao.AuthenticateCandidateisActive(ApplicationID);
        }
        public bool CheckIsVerifiedUseResetPassword(Int64 PID, int OTPType)
        {
            try
            {
                return dataAccessLayerDao.CheckIsVerifiedUseResetPassword(PID, OTPType);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckIsVerifiedUseResetPassword()", "");
            }
        }
        public DataSet getARAProcessFeeCandidateCount(Int32 FeeGroupID, Int32 PhaseID, Int32 UserTypeID, Int64 InstituteID)
        {
            try
            {
                return dataAccessLayerDao.getARAProcessFeeCandidateCount(FeeGroupID, PhaseID, UserTypeID, InstituteID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getAdmissionApprovalFeeDetailsTable()", "");
            }
        }
        public DataSet GetNotRecommendedList(string Flag, string Region)
        {
            try
            {
                return dataAccessLayerDao.GetNotRecommendedList(Flag, Region);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetNotRecommendedList()", "");
            }
        }
        public string getCandidateDOB(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getCandidateDOB(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getCandidateDOB()", "");
            }
        }
        public bool GetFCRApplicationID(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.GetFCRApplicationID(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetFCRApplicationID()", "");
            }
        }
        public bool UpdateFCRDetails(Int64 PID, string FCRApplicationID, string FCRCandidateName, string FCRCandidatureTypeName, string FCRMotherName, string FCRGender, DateTime FCRDOB)
        {
            try
            {
                return dataAccessLayerDao.UpdateFCRDetails(PID, FCRApplicationID, FCRCandidateName, FCRCandidatureTypeName, FCRMotherName, FCRGender, FCRDOB);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "UpdateFCRDetails()", "");
            }
        }
        public string GetTemplateNameUsedInEmailWhatsapp(string TemplateName, char Flag)
        {
            try
            {
                return dataAccessLayerDao.GetTemplateNameUsedInEmailWhatsapp(TemplateName, Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetTemplateNameUsedInEmailWhatsapp()", "");
            }
        }
        public bool ChangeFCVerificationMode(Int64 PID, string Flag, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.ChangeFCVerificationMode(PID, Flag, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "ChangeFCVerificationMode()", "");
            }
        }
        #region  #region Star Messages Changes
        public DataSet getAdminStarRepliedMessages(string Flag)
        {
            try
            {
                return dataAccessLayerDao.getAdminStarRepliedMessages(Flag);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getAdminStarRepliedMessages()", "");
            }
        }
        public DataSet getStarMessagesList(string From)
        {
            try
            {
                return dataAccessLayerDao.getStarMessagesList(From);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getStarMessagesList()", "");
            }
        }
        public DataSet getReplyStarMessageByMessageID(Int64 MessageID)
        {
            try
            {
                return dataAccessLayerDao.getReplyStarMessageByMessageID(MessageID);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getReplyStarMessageByMessageID()", "");
            }
        }
        public bool updateStarMessageStatus(Int64 MessageID)
        {
            try
            {
                return dataAccessLayerDao.updateStarMessageStatus(MessageID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "updateStarMessageStatus()", "");
            }
        }
        #endregion

        #region Ticketing System
        public DataSet getMasterGrievanceCategory(Int32 UserTypeID)
        {
            try
            {
                return dataAccessLayerDao.getMasterGrievanceCategory(UserTypeID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getMasterGrievanceCategory()", "");
            }
        }
        public DataSet GetGrievanceDashboard(Int32 UserTypeID, string UserLoginID)
        {
            try
            {
                return dataAccessLayerDao.GetGrievanceDashboard(UserTypeID, UserLoginID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetGrievanceDashboard()", "");
            }
        }
        public Int64 SendGrievance(string ApplicationID, Int16 GrievanceCategoryID, string OtherGrievanceCategory, string Grievance, string GrievanceFileURL, string UserLoginID, string IPAddress)
        {
            try
            {
                return dataAccessLayerDao.SendGrievance(ApplicationID, GrievanceCategoryID, OtherGrievanceCategory, Grievance, GrievanceFileURL, UserLoginID, IPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "SendGrievance()", "");
            }
        }
        public DataSet CheckGrievanceStatus(string UserLoginID, string Search)
        {
            try
            {
                return dataAccessLayerDao.CheckGrievanceStatus(UserLoginID, Search);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckGrievanceStatus()", "");
            }
        }
        public DataSet GetGrievanceList(Int64 GrievanceID)
        {
            try
            {
                return dataAccessLayerDao.GetGrievanceList(GrievanceID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetGrievanceList()", "");
            }
        }
        public DataSet GetGrievanceListByStatus(Int32 UserTypeID, string UserLoginID, string GrievanceStatus, string Search, Int16 GrievanceCategoryID)
        {
            try
            {
                return dataAccessLayerDao.GetGrievanceListByStatus(UserTypeID, UserLoginID, GrievanceStatus, Search, GrievanceCategoryID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetGrievanceListByStatus()", "");
            }
        }
        public string OpenGrievance(Int64 GrievanceID, Int32 UserTypeID, string UserLoginID, string IPAddress)
        {
            try
            {
                return dataAccessLayerDao.OpenGrievance(GrievanceID, UserTypeID, UserLoginID, IPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "OpenGrievance()", "");
            }
        }
        public Int64 GetFinalGrievanceID(Int64 GrievanceID, string Flag)
        {
            try
            {
                return dataAccessLayerDao.GetFinalGrievanceID(GrievanceID, Flag);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetFinalGrievanceID()", "");
            }
        }
        public DataSet GetGrievanceDetails(Int64 GrievanceID)
        {
            try
            {
                return dataAccessLayerDao.GetGrievanceDetails(GrievanceID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "GetGrievanceDetails()", "");
            }
        }
        public string ForwardGrievance(Int64 GrievanceID, Int16 AssignedTo, string UserLoginID, string IPAddress)
        {
            try
            {
                return dataAccessLayerDao.ForwardGrievance(GrievanceID, AssignedTo, UserLoginID, IPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "ForwardGrievance()", "");
            }
        }
        public string ReplyGrievance(Int64 GrievanceID, string RepliedGrievance, string RepliedGrievanceFileURL, string UserLoginID, string IPAddress)
        {
            try
            {
                return dataAccessLayerDao.ReplyGrievance(GrievanceID, RepliedGrievance, RepliedGrievanceFileURL, UserLoginID, IPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "ReplyGrievance()", "");
            }
        }
        public string ReOpenGrievance(Int64 GrievanceID, string Grievance, string GrievanceFileURL, string UserLoginID, string IPAddress)
        {
            try
            {
                return dataAccessLayerDao.ReOpenGrievance(GrievanceID, Grievance, GrievanceFileURL, UserLoginID, IPAddress);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "ReOpenGrievance()", "");
            }
        }

        #endregion
        public DataSet GetDirectorReport()
        {
            try
            {
                return dataAccessLayerDao.GetDirectorReport();
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "GetDirectorReport()", "");
            }
        }
        public bool saveCETDetails(Int64 PersonalID, Int64 CETApplicationFormNo, string CreatedBy, string CreatedByIpAddress)
        {
            try
            {
                return dataAccessLayerDao.saveCETDetails(PersonalID, CETApplicationFormNo, CreatedBy, CreatedByIpAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "saveCETDetails()", "PersonalID :" + PersonalID);
            }
        }
        public bool UploadCorrectDocumentafterReporting(Int64 PID, string ModifiedBy, string ModifiedByIPAddress)
        {
            try
            {
                return dataAccessLayerDao.UploadCorrectDocumentafterReporting(PID, ModifiedBy, ModifiedByIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "UploadCorrectDocumentafterReporting()", "PID : " + PID + "ModifiedBy :" + ModifiedBy);
            }
        }
        public bool GetSeatAcceptanceStatusforBettermentcandidate(Int64 PID)
        {
            return dataAccessLayerDao.GetSeatAcceptanceStatusforBettermentcandidate(PID);
        }
        public bool UpdateSeatAcceptanceStatusforBettermentcandidate(Int64 PID, string SeatAcceptanceStatus, Int32 CAPRound, string ModifiedBy, string ModifiedByIPAddress)
        {
            return dataAccessLayerDao.UpdateSeatAcceptanceStatusforBettermentcandidate(PID, SeatAcceptanceStatus, CAPRound, ModifiedBy, ModifiedByIPAddress);
        }
        public DataSet getSeatAcceptanceStatusDetailsForBettermentCandidate(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getSeatAcceptanceStatusDetailsForBettermentCandidate(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getSeatAcceptanceStatusDetailsForBettermentCandidate()", "");
            }
        }
        public bool GetSeatAcceptanceCAPRoundWise(Int64 PID, Int32 CAPRound)
        {
            return dataAccessLayerDao.GetSeatAcceptanceCAPRoundWise(PID, CAPRound);
        }
        public bool GETBlockCandidateList(Int64 PID)
        {
            return dataAccessLayerDao.GETBlockCandidateList(PID);
        }
        public DataSet getMVSubDiscrepancy(Int32 DID)
        {
            try
            {
                return dataAccessLayerDao.getMVSubDiscrepancy(DID);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "getMVSubDiscrepancy()", "");
            }

        }
        public DataSet getNotRecommendedForApprovalCandidate(Int64 InstCode)
        {
            try
            {
                return dataAccessLayerDao.getNotRecommendedForApprovalCandidate(InstCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getNotRecommendedForApprovalCandidate()", "");
            }
        }
        public DataSet getNotRecommendedAndRecommendedForApprovalCandidateList(Int64 PID)
        {
            try
            {
                return dataAccessLayerDao.getNotRecommendedAndRecommendedForApprovalCandidateList(PID);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getNotRecommendedAndRecommendedForApprovalCandidateList()", "");
            }
        }
        public bool SaveARAPenaltyStatus(Int32 InstCD, string Penalty, string CreatedBy, string CreatedIPAddress)
        {
            try
            {
                return dataAccessLayerDao.SaveARAPenaltyStatus(InstCD, Penalty, CreatedBy, CreatedIPAddress);
            }
            catch (CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "SaveARAPenaltyStatus()", "");
            }
        }
        public DataSet CheckARAPenaltyStatus(Int32 InstCode)
        {
            try
            {
                return dataAccessLayerDao.CheckARAPenaltyStatus(InstCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "CheckARAPenaltyStatus()", "");
            }
        }
        public DataSet CandidateApprovalReport(Int64 InstCode)
        {
            try
            {
                return dataAccessLayerDao.CandidateApprovalReport(InstCode);
            }
            catch (forProjectCustomExceptions.CustomException CEx)
            {
                throw CEx;
            }
            catch (Exception Ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), Ex, "Unknwon error occured, Please contact to Administrator, Message ID: " + messageID.ToString(), "CandidateApprovalReport()", "");
            }
        }
        public Int16 getRORegionID(string RName)
        {
            try
            {
                return dataAccessLayerDao.getRORegionID(RName);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getRORegionID()", "");
            }
        }
        public string getChoiceCodeDisplayByChoiceCode(Int64 ChoiceCode)
        {
            try
            {
                return dataAccessLayerDao.getChoiceCodeDisplayByChoiceCode(ChoiceCode);
            }
            catch (CustomException cEx)
            {
                throw cEx;
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured, Please contact to Administrator; Message ID:" + messageID.ToString(), "getChoiceCodeDisplayByChoiceCode()", "");
            }
        }
    }
}
