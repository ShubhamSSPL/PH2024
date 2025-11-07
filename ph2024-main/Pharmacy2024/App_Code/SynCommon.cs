using BusinessLayer;
using DataAccess.Implementation;
using EntityModel;
using forProjectCustomExceptions;
using Pharmacy2024;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Collections.Generic;

public class SynCommon
{
    private readonly IBusinessService reg = new BusinessServiceImp();
    public enum SynSetting
    {
        ApplicationIDLength = 10,
        OtpValidMinutes = 15
    }
    public enum TemplateSystemType
    {
        OtpRegistration = 1,
        OtpMobileChange = 2,
        CancelApplicationFormOTP = 3,
        LoginOTP = 5,
        SendOTPforResetPassword = 6,
        ChangeNameOTP = 7,
        OptionFormUnlockCAPIOTP = 8,
        CAPOptionFormIOTP = 9,
        InstituteCAPOTP = 10,
        CAPOptionFormIIOTP = 11,
        AdmissionCancelOTP = 12,
        InstituteILOTP = 13,
        CAPOptionFormIIIOTP = 14,
        OtpMobileChangeNewMobile = 15,
        OTPApplicationFormConfermation = 16,
        OTPApplicationFormUnlock = 17,
        OTPModeChange = 18,
        OTPSEBCOPEN = 19,
        OTPSEBCEWS = 20,
        OTPTFWS = 21,
        OTPARCSelfGrivanceRase = 22,
        OTPSeatAcceptance = 23,
        CategoryConversionOTP =24,
        CAPOptionFormIIUnlockOTP = 25,

        Registration = 51,
        CancelApplicationForm = 52,
        ConfirmApplicationFormProvisionally = 53,
        ConfirmApplicationForm = 54,
        CancelSeatAcceptance = 55,
        ConfirmSeatAcceptanceForm = 56,
        SeatAcceptanceStatusChange = 57,
        RequestforAdmissionCancellation = 58,
        ConfirmationofRequestforAdmissionCancellation = 59,
        AdmissionCancellationRequesttoCoordinator = 60,
        OptionFormStartCAPI = 61,
        OptionFormConfirmCAPI = 62,
        OptionFormConfirmCAPII = 63,
        OptionFormConfirmCAPIII = 64,
        CanceledAdmissionInstitue = 65,
        CanceledAdmissionInstitueAtIL = 66,
        ConfirmAdmissionCAP = 67,
        ConfirmAdmissionAtIL = 68,
        MobileChange = 69,

        AddFC = 70,
        AddSubFC = 71,
        AddARC = 72,
        AddSubARC = 73,
        CancelConfirmedApplicationForm = 74,
        AllotmentCancellation = 75,
        ApplicationFormConfermation = 76,
        GrievanceApproved = 77,
        GrievanceRejected = 78,
        ApplicationFormUnlock = 79,
        EFCConfirmApplicationFormProvisionally = 80,
        EFCConfirmApplicationForm = 81,
        EFCConfirmApplicationFormDiscrepancy = 82,
        ModeChange = 83,
        SEBCTOOPEN = 84,
        SEBCTOOPENEWS = 85,
        TFWS = 86,
        TFWSFCofficer = 87,
        TFWSVerifySucess = 88,
        TFWSVerifyNotSucess = 89,
            ARCSelfGrivanceRase = 90,
        SeatAceptanceVerify = 91,

        SeatAcceptanceGrievanceRejected = 92,
        SeatAcceptanceGrievanceApprovedWithCancellation = 93,
        SeatAcceptanceGrievanceApprovedWithOutCancellation = 94,
        CVCNCLConvertOpen = 95,
        EWSConvertNo = 96,
        ConvertSucessful = 97,
        CAPOptionFormIIUnlock =98,
        CVCNCLConvertOpenUpdate =99,
        EWSConvertNoUpdate =100,
        DocumentVerificationRequest = 101,
        AddSO = 102,
        verifyCVCTVCNCLEWSSucessful = 103,
             OptionFormStartCAP = 104,
        OptionFormConfirmCAP = 105,
        CVCNCLConvertOpenUpdateNew = 106
    }

    public enum RORegion
    {
        Amravati = 1,
        Aurangabad = 2,
        Mumbai = 3,
        Nagpur = 4,
        Nashik = 5,
        Pune = 6
    }
    public static int GetRoRegionId(string UserLoginID)
    {
        string regionName = UserLoginID.Substring(2, UserLoginID.Length-2);
        if (regionName == RORegion.Amravati.ToString())
            return (int)RORegion.Amravati;
        else if (regionName == RORegion.Aurangabad.ToString())
            return (int)RORegion.Aurangabad;
        else if (regionName == RORegion.Mumbai.ToString())
            return (int)RORegion.Mumbai;
        else if (regionName == RORegion.Nagpur.ToString())
            return (int)RORegion.Nagpur;
        else if (regionName == RORegion.Nashik.ToString())
            return (int)RORegion.Nashik;
        else
            return (int)RORegion.Pune;
    }
    public string ConvertSMSDateTime(string Datetime)
    {
        DateTime dt = Convert.ToDateTime(Datetime);
        return dt.ToString("dd MMM yyyy hh: mm tt");

    }
    public string GenerateTemplate(string Template, SMSTemplate sMSTemplate)
    {
        if (Template != null)
        {
            Template = Template.Replace("<%ProjectName%>", sMSTemplate.ProjectName);
            Template = Template.Replace("<%OTPCode%>", sMSTemplate.OTPCode);
            Template = Template.Replace("<%ValidTill%>", ConvertSMSDateTime(sMSTemplate.ValidTill));
            Template = Template.Replace("<%ApplicationID%>", sMSTemplate.ApplicationID);
            Template = Template.Replace("<%CandidateName%>", sMSTemplate.CandidateName);
            Template = Template.Replace("<%CancelledBy%>", sMSTemplate.CancelledBy);
            Template = Template.Replace("<%CancelledDateTime%>", ConvertSMSDateTime(sMSTemplate.CancelledDateTime));
            Template = Template.Replace("<%ConfirmedBy%>", sMSTemplate.ConfirmedBy);
            Template = Template.Replace("<%ConfirmedDateTime%>", ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime));
            Template = Template.Replace("<%ReportedBy%>", sMSTemplate.ReportedBy);
            Template = Template.Replace("<%ReportedDateTime%>", ConvertSMSDateTime(sMSTemplate.ReportedDateTime));
            Template = Template.Replace("<%UserLoginID%>", sMSTemplate.UserLoginID);
            Template = Template.Replace("<%SeatAcceptanceStatus%>", sMSTemplate.SeatAcceptanceStatus);
            Template = Template.Replace("<%ChoiceCodeDisplay%>", sMSTemplate.ChoiceCodeDisplay);
            Template = Template.Replace("<%CurrentDateTime%>", ConvertSMSDateTime(sMSTemplate.CurrentDateTime));
            Template = Template.Replace("<%InstituteAdmitted%>", sMSTemplate.InstituteAdmitted);
            Template = Template.Replace("<%SeatTypeAdmitted%>", sMSTemplate.SeatTypeAdmitted);
            Template = Template.Replace("<%CurrentYear%>", sMSTemplate.CurrentYear);
            Template = Template.Replace("<%OldMobileNo%>", sMSTemplate.OldMobileNo);
            Template = Template.Replace("<%NewMobileNo%>", sMSTemplate.NewMobileNo);
            Template = Template.Replace("<%AdmissionCategory%>", sMSTemplate.ConversionStatus);
            Template = Template.Replace("<%InstituteID%>", sMSTemplate.InstituteID);
            Template = Template.Replace("<%LoginID%>", sMSTemplate.LoginID);
            Template = Template.Replace("<%Password%>", sMSTemplate.Password);
            Template = Template.Replace("<%AllotmentCancellationRemark%>", sMSTemplate.AllotmentCancellationRemark);
            Template = Template.Replace("<%IPAddress%>", sMSTemplate.IPAddress);
            Template = Template.Replace("<%GrievanceID%>", sMSTemplate.GrievanceID);
            Template = Template.Replace("<%OldMode%>", sMSTemplate.OldMode);
            Template = Template.Replace("<%NewMode%>", sMSTemplate.NewMode);
            Template = Template.Replace("<%ConversionStatus%>", sMSTemplate.ConversionStatus);
            Template = Template.Replace("<%RoundNumber%>", sMSTemplate.RoundNumber);
            Template = Template.Replace("<%FCID%>", sMSTemplate.UserLoginID);
            Template = Template.Replace("<%CAPRound%>", Convert.ToString(Global.CAPRound));
            Template = Template.Replace("<%LastDateofSubmission%>", sMSTemplate.LastDateofSubmission);
        }

        return Template;
    }

    public Int32 GenerateOTPSixDigit()
    {
        string randomnumber = "0";
        do
        {
            Random generator = new Random();
            randomnumber = generator.Next(111111, 999999).ToString("D6");
        }
        while ((randomnumber.Length < 6) || (long.Parse(randomnumber) < 111111));
        return Convert.ToInt32(randomnumber);
    }
    /* 
                                 * Check OTPCode is in the OTPDetails Code
                                 * IF new to Create OTPCode
                                 * Save OTP  
                                 * Get Values for Template
                                 * GetTemplate 
                                 * Bind Template
                                 * send SMS
                                 * Save SMS with Template ID
                                 */
    public bool SendOTPSMS(SMSTemplate sMSTemplate, TemplateSystemType e)
    {
        try
        {
            SMS objSMS = new SMS();

            sMSTemplate.CandidateName = "";
            RegistrationDetails obj = reg.getRegistrationDetails(sMSTemplate.PID);
            string candidateName = obj.CandidateName.ToString();//reg.getCandidateName(sMSTemplate.PID).ToString();

            if (candidateName.Length > 29)
                sMSTemplate.CandidateName = candidateName.Substring(0, 29);
            else
                sMSTemplate.CandidateName = candidateName;

            sMSTemplate.ApplicationID = Global.ApplicationFormPrefix + sMSTemplate.PID.ToString();
            sMSTemplate.ProjectName = Global.ProjectNameSMS;
            if (sMSTemplate.MobileNo == null || sMSTemplate.MobileNo == "")
                sMSTemplate.MobileNo = DataEncryption.DecryptDataByEncryptionKey(obj.MobileNo.ToString());//reg.getMobileNo(sMSTemplate.PID));
            else if (sMSTemplate.MobileNo.Length > 10)
                sMSTemplate.MobileNo = DataEncryption.DecryptDataByEncryptionKey(sMSTemplate.MobileNo);
            sMSTemplate.EmailID = obj.EMailID;
            sMSTemplate.IPAddress = UserInfo.GetIPAddress();
            Int32 OTPCode = GenerateOTPSixDigit();

            //string strSMSTemp = reg.getEmailSMSTemplateBySystemName(e.ToString());

            DataSet dsSMSTemplate = reg.getEmailSMSTemplateBySystemName(e.ToString());
            string strSMSTemp = dsSMSTemplate.Tables[0].Rows[0]["Template"].ToString();
            string strTemplateID = dsSMSTemplate.Tables[0].Rows[0]["TemplateID"].ToString();

            if (strSMSTemp != string.Empty)
            {
                sMSTemplate.ValidTill = DateTime.Now.AddMinutes((int)SynSetting.OtpValidMinutes).ToString();
                sMSTemplate.OTPCode = OTPCode.ToString();
                sMSTemplate.ProjectName = Global.ProjectNameSMS;

                DataSet otpDs = reg.CheckOtp(sMSTemplate.PID, (int)e);
                if (otpDs.Tables.Count > 0 && otpDs.Tables[0].Rows.Count > 0)
                {
                    sMSTemplate.ValidTill = otpDs.Tables[0].Rows[0]["ValidTill"].ToString();
                    sMSTemplate.OTPCode = otpDs.Tables[0].Rows[0]["OTP"].ToString();
                    string strSMSTemplate = GenerateTemplate(strSMSTemp, sMSTemplate);
                    if (strSMSTemplate != null && ConfigurationManager.AppSettings["ApplicationMode"] == "Production")
                    {
                        objSMS.sendOTPSMS(sMSTemplate.MobileNo, strSMSTemplate, sMSTemplate.OTPCode, e.ToString(), sMSTemplate.PID.ToString(), strTemplateID);

                        //if (Global.IsEmailSend == 1)
                        //{
                        //    SendEmail(dsSMSTemplate, sMSTemplate, "O", e.ToString(), sMSTemplate.PID.ToString());
                        //}
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["ApplicationMode"] != "Production")
                            return true;
                        else
                            return false;
                    }
                }
                else
                {
                    reg.SaveOTP(sMSTemplate.PID, OTPCode, (int)e, false, Convert.ToDateTime(sMSTemplate.ValidTill), DataEncryption.EncryptDataByEncryptionKey(sMSTemplate.MobileNo), sMSTemplate.EmailID, sMSTemplate.ApplicationID, sMSTemplate.IPAddress, 1);
                    string strSMSTemplate = GenerateTemplate(strSMSTemp, sMSTemplate);
                    if (strSMSTemplate != null && ConfigurationManager.AppSettings["ApplicationMode"] == "Production")
                    {
                        objSMS.sendOTPSMS(sMSTemplate.MobileNo, strSMSTemplate, sMSTemplate.OTPCode, e.ToString(), sMSTemplate.PID.ToString(), strTemplateID);

                        //if (Global.IsEmailSend == 1)
                        //{
                        //    SendEmail(dsSMSTemplate, sMSTemplate, "O", e.ToString(), sMSTemplate.PID.ToString());
                        //}
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["ApplicationMode"] != "Production")
                            return true;
                        else
                            return false;
                    }
                }
                return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool SendInformationSMS(SMSTemplate sMSTemplate, TemplateSystemType e)
    {
        try
        {
            SMS objSMS = new SMS();
            if (sMSTemplate.PID > 0)
            {
                sMSTemplate.CandidateName = "";
                RegistrationDetails obj = reg.getRegistrationDetails(sMSTemplate.PID);

                string candidateName = obj.CandidateName.ToString();// reg.getCandidateName(sMSTemplate.PID).ToString();

                if (candidateName.Length > 29)
                    sMSTemplate.CandidateName = candidateName.Substring(0, 29);
                else
                    sMSTemplate.CandidateName = candidateName;

                sMSTemplate.ApplicationID = Global.ApplicationFormPrefix + sMSTemplate.PID.ToString();
                sMSTemplate.MobileNo = DataEncryption.DecryptDataByEncryptionKey(obj.MobileNo.ToString());//reg.getMobileNo(sMSTemplate.PID));
                sMSTemplate.EmailID = obj.EMailID;
            }
            sMSTemplate.ProjectName = Global.ProjectNameSMS;
            sMSTemplate.CurrentYear = Global.AdmissionYear;

            //string strSMSTemp = reg.getEmailSMSTemplateBySystemName(e.ToString());

            DataSet dsSMSTemplate = reg.getEmailSMSTemplateBySystemName(e.ToString());
            string strSMSTemp = dsSMSTemplate.Tables[0].Rows[0]["Template"].ToString();
            string strTemplateID = dsSMSTemplate.Tables[0].Rows[0]["TemplateID"].ToString();

            if (strSMSTemp != string.Empty)
            {
                sMSTemplate.ProjectName = Global.ProjectNameSMS;
                string strSMSTemplate = GenerateTemplate(strSMSTemp, sMSTemplate);
                if (strSMSTemplate != null && ConfigurationManager.AppSettings["ApplicationMode"] == "Production")
                {
                    objSMS.sendSingleSMS(sMSTemplate.MobileNo, strSMSTemplate, e.ToString(), sMSTemplate.PID.ToString(), strTemplateID);

                    if (Global.IsEmailSend == 1)
                    {
                        SendEmail(dsSMSTemplate, sMSTemplate, "N", e.ToString(), sMSTemplate.PID.ToString(),e);
                    }

                    if (Global.IsSendWhatsApp == 1)
                    {
                        SendWhatsApp(dsSMSTemplate, sMSTemplate, "N", e.ToString(), sMSTemplate.PID.ToString(), e);
                        //string strTemplateEmail = dsSMSTemplate.Tables[0].Rows[0]["TemplateEmail"].ToString();
                        //string strWhatupTemplate = GenerateTemplate(strTemplateEmail, sMSTemplate);
                        //string MobileNo = "";
                        //string MessageType = "C";
                        //List<WhatsAppMessageParameter> Parameters = new List<WhatsAppMessageParameter>();

                        //if (e.ToString() == "Registration")
                        //{
                        //    MobileNo = sMSTemplate.MobileNo;

                        //    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                        //    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                        //    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                        //}
                        //else if (e.ToString() == "ConfirmApplicationForm")
                        //{
                        //    MobileNo = sMSTemplate.MobileNo;

                        //    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                        //    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                        //}

                        //new WhatsAppHelper().SendWhatsAppMessage(MobileNo, e.ToString(), MessageType, Parameters, sMSTemplate.PID.ToString(), strWhatupTemplate);
                    }
                    return true;
                }
                else
                {
                    if (ConfigurationManager.AppSettings["ApplicationMode"] != "Production")
                        return true;
                    else
                        return false;
                }
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            long messageID = ExceptionMessages.GetMessageDetails();
            throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendInformationSMS()", "Template :" + e + " MobileNo : " + sMSTemplate.MobileNo);
        }
    }

    //public void SendEmail(DataSet dsTemplate, SMSTemplate sMSTemplate, string Type, string TemplateName, string ToUserID)
    //{
    //    try
    //    {
    //        //bool senfEmailFlag = false;

    //        //if (Global.IsOTPVerificationRequired == 1)
    //        //    senfEmailFlag = true;
    //        //else if (Global.IsOTPVerificationRequired == 1)
    //        //    senfEmailFlag = true;
    //        //else
    //        //    senfEmailFlag = false;

    //        //if (senfEmailFlag)
    //        //{
    //        string strEMailSubject = dsTemplate.Tables[0].Rows[0]["TemplateMailSubject"].ToString();
    //        string strFromMailID = ConfigurationManager.AppSettings["SendGridMailFromID"].ToString();
    //        string strFromMailName = ConfigurationManager.AppSettings["SendGridMailFromName"].ToString();//dsSMSTemplate.Tables[0].Rows[0]["MailFromName"].ToString();
    //        string strTemplateEmail = dsTemplate.Tables[0].Rows[0]["TemplateEmail"].ToString();

    //        bool response = false;
    //        if (strTemplateEmail != string.Empty)
    //        {
    //            string strTempEmail = GenerateTemplate(strTemplateEmail, sMSTemplate);
    //            response = SendGridMailSender.SendEMail(strFromMailID, strFromMailName, sMSTemplate.EmailID, sMSTemplate.CandidateName, strEMailSubject, strTempEmail);

    //            DBUtilitySMS reg = new DBUtilitySMS();
    //            reg.savedSentEmailDetails(sMSTemplate.EmailID, strEMailSubject, strTempEmail, response.ToString(), HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), Type, TemplateName, ToUserID);
    //        }
    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //        long messageID = ExceptionMessages.GetMessageDetails();
    //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
    //    }
    //}
    public void SendEmail(DataSet dsTemplate, SMSTemplate sMSTemplate, string Type, string TemplateName, string ToUserID, TemplateSystemType e)
    {
        try
        {
            if (ConfigurationManager.AppSettings["EmailSendBy"] == "SendGrid")
            {
                string strEMailSubject = dsTemplate.Tables[0].Rows[0]["TemplateMailSubject"].ToString();
                string strFromMailID = ConfigurationManager.AppSettings["SendGridMailFromID"].ToString();
                string strFromMailName = ConfigurationManager.AppSettings["SendGridMailFromName"].ToString();//dsSMSTemplate.Tables[0].Rows[0]["MailFromName"].ToString();
                string strTemplateEmail = dsTemplate.Tables[0].Rows[0]["TemplateEmail"].ToString();

                bool response = false;
                if (strTemplateEmail != string.Empty)
                {
                    string strTempEmail = GenerateTemplate(strTemplateEmail, sMSTemplate);
                    response = SendGridMailSender.SendEMail(strFromMailID, strFromMailName, sMSTemplate.EmailID, sMSTemplate.CandidateName, strEMailSubject, strTempEmail);

                    DBUtilitySMS reg = new DBUtilitySMS();
                    reg.savedSentEmailDetails(sMSTemplate.EmailID, strEMailSubject, strTempEmail, response.ToString(), HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), Type, TemplateName, ToUserID);
                }
            }
            else if (ConfigurationManager.AppSettings["EmailSendBy"] == "Msg91")
            {
                string strMsg91EMailSubject = dsTemplate.Tables[0].Rows[0]["TemplateMailSubject"].ToString();
                string strMsg91TemplateEmail = dsTemplate.Tables[0].Rows[0]["TemplateEmail"].ToString();
                string strMsg91TempEmail = GenerateTemplate(strMsg91TemplateEmail, sMSTemplate);

                List<Msg91EMailTo> ToEMailID = new List<Msg91EMailTo>();
                Msg91EMailVariables variables = new Msg91EMailVariables();
               

                string TemplateNameUsed = reg.GetTemplateNameUsedInEmailWhatsapp(TemplateName, 'E');

                if (e.ToString() == "Registration")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;

                }
                else if (e.ToString() == "ApplicationFormConfermation")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = ConvertSMSDateTime(sMSTemplate.ReportedDateTime);
                }
                else if (e.ToString() == "EFCConfirmApplicationFormDiscrepancy")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.ConfirmedBy;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);
                }
                else if (e.ToString() == "EFCConfirmApplicationForm")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.ConversionStatus;
                    variables.VAR5 = sMSTemplate.ConfirmedBy;
                    variables.VAR6 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);
                }
                else if (e.ToString() == "GrievanceApproved")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.UserLoginID;
                }
                else if (e.ToString() == "GrievanceRejected")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.GrievanceID;
                    variables.VAR4 = sMSTemplate.UserLoginID;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "ModeChange")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.OldMode;
                    variables.VAR5 = sMSTemplate.NewMode;
                    variables.VAR6 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "CancelApplicationForm")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.CancelledBy;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.CancelledDateTime);
                }
                else if (e.ToString() == "ConfirmApplicationFormProvisionally")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.ConfirmedBy;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);
                }
                else if (e.ToString() == "CancelSeatAcceptance")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.CancelledBy;
                    variables.VAR4 = ConvertSMSDateTime(sMSTemplate.CancelledDateTime);
                }
                else if (e.ToString() == "ConfirmSeatAcceptanceForm")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ReportedBy;
                    variables.VAR4 = ConvertSMSDateTime(sMSTemplate.ReportedDateTime);
                }
                else if (e.ToString() == "SeatAcceptanceStatusChange")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.SeatAcceptanceStatus;
                    variables.VAR4 = sMSTemplate.UserLoginID;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "RequestforAdmissionCancellation")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ChoiceCodeDisplay;
                    variables.VAR4 = sMSTemplate.ApplicationID;
                }
                else if (e.ToString() == "ConfirmationofRequestforAdmissionCancellation")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.InstituteAdmitted;
                    variables.VAR4 = sMSTemplate.ChoiceCodeDisplay;
                    variables.VAR5 = sMSTemplate.SeatTypeAdmitted;
                    variables.VAR6 = sMSTemplate.IPAddress;
                    variables.VAR7 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);

                }
                else if (e.ToString() == "AdmissionCancellationRequesttoCoordinator")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.UserLoginID;
                    variables.VAR3 = sMSTemplate.ChoiceCodeDisplay;
                    variables.VAR4 = sMSTemplate.SeatTypeAdmitted;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);

                }
                else if (e.ToString() == "OptionFormStartCAP")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.RoundNumber;
                    variables.VAR2 = sMSTemplate.ProjectName;
                    variables.VAR3 = sMSTemplate.CandidateName;
                    variables.VAR4 = sMSTemplate.ApplicationID;
                    variables.VAR5 = sMSTemplate.RoundNumber;
                    variables.VAR6 = sMSTemplate.ProjectName;
                    variables.VAR7 = sMSTemplate.CurrentYear;
                }
                else if (e.ToString() == "OptionFormConfirmCAP")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.RoundNumber;
                    variables.VAR2 = sMSTemplate.ProjectName;
                    variables.VAR3 = sMSTemplate.CandidateName;
                    variables.VAR4 = sMSTemplate.ApplicationID;
                    variables.VAR5 = sMSTemplate.RoundNumber;
                    variables.VAR6 = sMSTemplate.ConfirmedBy;
                    variables.VAR7 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "CanceledAdmissionInstitue")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ChoiceCodeDisplay;
                    variables.VAR4 = sMSTemplate.UserLoginID;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "CanceledAdmissionInstitueAtIL")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ChoiceCodeDisplay;
                    variables.VAR4 = sMSTemplate.UserLoginID;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "ConfirmAdmissionCAP")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ChoiceCodeDisplay;
                    variables.VAR4 = sMSTemplate.UserLoginID;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "MobileChange")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.OldMobileNo;
                    variables.VAR4 = sMSTemplate.NewMobileNo;
                }
                else if (e.ToString() == "AllotmentCancellation")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.AllotmentCancellationRemark;
                    variables.VAR4 = sMSTemplate.UserLoginID;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                    variables.VAR6 = sMSTemplate.ProjectName;
                }
                else if (e.ToString() == "ApplicationFormUnlock")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);

                }
                else if (e.ToString() == "CancelConfirmedApplicationForm")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.UserLoginID;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);

                }
                else if (e.ToString() == "EFCConfirmApplicationForm")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    if (sMSTemplate.ConversionStatus != "")
                    {
                        variables.VAR4 = sMSTemplate.ConversionStatus;
                    }
                    else
                    {
                        variables.VAR4 = "-";
                    }
                    variables.VAR5 = sMSTemplate.ConfirmedBy;
                    variables.VAR6 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);

                }
                else if (e.ToString() == "EFCConfirmApplicationFormDiscrepancy")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.ConfirmedBy;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);

                }
                else if (e.ToString() == "EFCConfirmApplicationFormProvisionally")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.ConversionStatus;
                    variables.VAR5 = sMSTemplate.ConfirmedBy;
                    variables.VAR6 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);

                }
                else if (e.ToString() == "SeatAcceptanceGrievanceRejected")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.ConfirmedBy;
                    variables.VAR4 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);

                }
                else if (e.ToString() == "SeatAcceptanceGrievanceApprovedWithCancellation")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.UserLoginID;
                }
                else if (e.ToString() == "SeatAcceptanceGrievanceApprovedWithOutCancellation")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.UserLoginID;
                }
                else if (e.ToString() == "ARCSelfGrivanceRase")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);
                }
                else if (e.ToString() == "SeatAceptanceVerify")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.SeatAcceptanceStatus;
                    variables.VAR4 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);
                }
                else if (e.ToString() == "ConvertSucessful")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.ConfirmedBy;
                    variables.VAR4 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "EWSConvertNo")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.ConfirmedBy;
                    variables.VAR4 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "CVCNCLConvertOpen")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.ConfirmedBy;
                    variables.VAR4 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "EWSConvertNoUpdate")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.RoundNumber;

                }
                else if (e.ToString() == "CVCNCLConvertOpenUpdate")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.RoundNumber;

                }
                else if (e.ToString() == "ConfirmAdmissionAtIL")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.ChoiceCodeDisplay;
                    variables.VAR5 = sMSTemplate.SeatTypeAdmitted;
                    variables.VAR6 = sMSTemplate.UserLoginID;
                    variables.VAR7 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);

                }
                else if (e.ToString() == "verifyCVCTVCNCLEWSSucessful")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;
                    variables.VAR3 = sMSTemplate.ConfirmedBy;
                    variables.VAR4 = ConvertSMSDateTime(sMSTemplate.CurrentDateTime);
                }
                else if (e.ToString() == "SEBCTOOPENEWS")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.ConfirmedBy;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);
                }
                else if (e.ToString() == "TFWSVerifyNotSucess")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.ConfirmedBy;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);
                }
                else if (e.ToString() == "TFWSVerifySucess")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.CandidateName;
                    variables.VAR3 = sMSTemplate.ApplicationID;
                    variables.VAR4 = sMSTemplate.ConfirmedBy;
                    variables.VAR5 = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime);
                }
                else if (e.ToString() == "CVCNCLConvertOpenUpdateNew")
                {

                    ToEMailID.Add(new Msg91EMailTo() { name = sMSTemplate.CandidateName, email = sMSTemplate.EmailID });
                    variables.VAR1 = sMSTemplate.ProjectName;
                    variables.VAR2 = sMSTemplate.ApplicationID;


                }


                new Msg91EMailHelper().SendMsg91EMail(ToEMailID, TemplateNameUsed, variables, ToUserID, strMsg91TempEmail);
            }
        }
        catch (Exception ex)
        {
            long messageID = ExceptionMessages.GetMessageDetails();
            throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
        }
    }
    public void SendWhatsApp(DataSet dsTemplate, SMSTemplate sMSTemplate, string Type, string TemplateName, string ToUserID, TemplateSystemType e)
    {
        try
        {
            string strTemplateEmail = dsTemplate.Tables[0].Rows[0]["TemplateEmail"].ToString();
            string strWhatupTemplate = GenerateTemplate(strTemplateEmail, sMSTemplate);
            string MobileNo = "";
            string MessageType = "C";
            List<WhatsAppMessageParameter> Parameters = new List<WhatsAppMessageParameter>();
            string TemplateNameUsed = reg.GetTemplateNameUsedInEmailWhatsapp(TemplateName, 'W');

            if (e.ToString() == "Registration")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
            }
            else if (e.ToString() == "ApplicationFormConfermation")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ReportedDateTime) });

            }
            else if (e.ToString() == "EFCConfirmApplicationFormDiscrepancy")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });

            }
            else if (e.ToString() == "EFCConfirmApplicationForm")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                if (sMSTemplate.ConversionStatus != "")
                {
                    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConversionStatus });
                }
                else
                {
                    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = "-" });
                }
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });

            }
            else if (e.ToString() == "GrievanceApproved")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
            }
            else if (e.ToString() == "GrievanceRejected")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.GrievanceID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "ModeChange")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.OldMode });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.NewMode });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "CancelApplicationForm")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CancelledBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CancelledDateTime) });
            }
            else if (e.ToString() == "ConfirmApplicationFormProvisionally")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });
            }
            else if (e.ToString() == "CancelSeatAcceptance")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CancelledBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CancelledDateTime) });
            }
            else if (e.ToString() == "ConfirmSeatAcceptanceForm")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ReportedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ReportedDateTime) });
            }
            else if (e.ToString() == "SeatAcceptanceStatusChange")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.SeatAcceptanceStatus });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "RequestforAdmissionCancellation")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ChoiceCodeDisplay });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
            }
            else if (e.ToString() == "ConfirmationofRequestforAdmissionCancellation")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.InstituteAdmitted });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ChoiceCodeDisplay });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.SeatTypeAdmitted });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.IPAddress });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "AdmissionCancellationRequesttoCoordinator")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ChoiceCodeDisplay });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.SeatTypeAdmitted });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "OptionFormStartCAP")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.RoundNumber });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CurrentYear });
            }
            else if (e.ToString() == "OptionFormConfirmCAP")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.RoundNumber });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "CanceledAdmissionInstitue")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ChoiceCodeDisplay });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "CanceledAdmissionInstitueAtIL")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ChoiceCodeDisplay });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "ConfirmAdmissionCAP")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ChoiceCodeDisplay });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "MobileChange")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.OldMobileNo });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.NewMobileNo });
            }
            else if (e.ToString() == "AllotmentCancellation")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.AllotmentCancellationRemark });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
            }
            else if (e.ToString() == "ApplicationFormUnlock")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "CancelConfirmedApplicationForm")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "EFCConfirmApplicationForm")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                if (sMSTemplate.ConversionStatus != "")
                {
                    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConversionStatus });
                }
                else
                {
                    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = "-" });
                }
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });
            }
            else if (e.ToString() == "EFCConfirmApplicationFormDiscrepancy")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });
            }
            else if (e.ToString() == "EFCConfirmApplicationFormProvisionally")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                if (sMSTemplate.ConversionStatus != "")
                {
                    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConversionStatus });
                }
                else
                {
                    Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = "-" });
                }
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });
            }
            else if (e.ToString() == "SeatAcceptanceGrievanceRejected")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "SeatAcceptanceGrievanceApprovedWithCancellation")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
            }
            else if (e.ToString() == "SeatAcceptanceGrievanceApprovedWithOutCancellation")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
            }
            else if (e.ToString() == "ARCSelfGrivanceRase")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });
            }
            else if (e.ToString() == "SeatAceptanceVerify")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.SeatAcceptanceStatus });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });
            }
            else if (e.ToString() == "ConvertSucessful")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "EWSConvertNo")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "CVCNCLConvertOpen")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "EWSConvertNoUpdate")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.RoundNumber });

            }
            else if (e.ToString() == "CVCNCLConvertOpenUpdate")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.RoundNumber });

            }
            else if (e.ToString() == "ConfirmAdmissionAtIL")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ChoiceCodeDisplay });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.SeatTypeAdmitted });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.UserLoginID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });

            }
            else if (e.ToString() == "verifyCVCTVCNCLEWSSucessful")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.CurrentDateTime) });
            }
            else if (e.ToString() == "SEBCTOOPENEWS")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });
            }
            else if (e.ToString() == "TFWSVerifyNotSucess")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });
            }
            else if (e.ToString() == "TFWSVerifySucess")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.CandidateName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ConfirmedBy });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = ConvertSMSDateTime(sMSTemplate.ConfirmedDateTime) });
            }
            else if (e.ToString() == "CVCNCLConvertOpenUpdateNew")
            {
                MobileNo = sMSTemplate.MobileNo;
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ProjectName });
                Parameters.Add(new WhatsAppMessageParameter() { type = "text", text = sMSTemplate.ApplicationID });


            }

            if (Global.whatsappProvider.ToLower() == "tata")
                new WhatsAppHelper().SendWhatsAppMessage(MobileNo, TemplateNameUsed, MessageType, Parameters, sMSTemplate.PID.ToString(), strWhatupTemplate);
            else if (Global.whatsappProvider.ToLower() == "msg91")
                new WhatsAppHelper().SendWhatsAppMessageMSG91(MobileNo, TemplateNameUsed, MessageType, Parameters, sMSTemplate.PID.ToString(), strWhatupTemplate);

        }
        catch (Exception ex)
        {
            long messageID = ExceptionMessages.GetMessageDetails();
            throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
        }
    }
    public String GetUserEnvironment(HttpRequest request)
    {
        var browser = request.Browser;
        var platform = GetUserPlatform(request);
        return string.Format("{0} / {1} / {2} ", browser.Browser, browser.Version, platform);
    }
    public String GetUserPlatform(HttpRequest request)
    {
        var ua = request.UserAgent;

        if (ua.Contains("Android"))
            return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

        if (ua.Contains("iPad"))
            return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

        if (ua.Contains("iPhone"))
            return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

        if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
            return "Kindle Fire";

        if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
            return "Black Berry";

        if (ua.Contains("Windows Phone"))
            return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

        if (ua.Contains("Mac OS"))
            return "Mac OS";

        if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
            return "Windows XP";

        if (ua.Contains("Windows NT 6.0"))
            return "Windows Vista";

        if (ua.Contains("Windows NT 6.1"))
            return "Windows 7";

        if (ua.Contains("Windows NT 6.2"))
            return "Windows 8";

        if (ua.Contains("Windows NT 6.3"))
            return "Windows 8.1";

        if (ua.Contains("Windows NT 10"))
            return "Windows 10";

        //fallback to basic platform:
        return request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
    }
    public String GetMobileVersion(string userAgent, string device)
    {
        var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
        var version = string.Empty;

        foreach (var character in temp)
        {
            var validCharacter = false;
            int test = 0;

            if (Int32.TryParse(character.ToString(), out test))
            {
                version += character;
                validCharacter = true;
            }

            if (character == '.' || character == '_')
            {
                version += '.';
                validCharacter = true;
            }

            if (validCharacter == false)
                break;
        }

        return version;
    }
    public static string GetPassingYear(string passingYear)
    {
        string _passingYear = "";
        switch (passingYear)
        {
            case "2024_2":
                _passingYear = "2024";
                break;
            case "2024_1":
                _passingYear = "2024";
                break;

            case "2023_2":
                _passingYear = "2023";
                break;
            case "2023_1":
                _passingYear = "2023";
                break;

            case "2022_2":
                //_passingYear = "2020 Re-Evaluation";
                _passingYear = "2022";
                break;
            case "2022_1":
                //_passingYear = "2020 Re-Evaluation";
                _passingYear = "2022";
                break;

            case "2021_2":
                //_passingYear = "2020 Re-Evaluation";
                _passingYear = "2021";
                break;
            case "2021_1":
                //_passingYear = "2020 Re-Evaluation";
                _passingYear = "2021";
                break;

            default:
                _passingYear = passingYear;
                break;
        }
        return _passingYear;
    }
}
