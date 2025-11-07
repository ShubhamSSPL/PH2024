using EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;


namespace BusinessLayer
{
    public static class BalCommon
    {
        public static List<T> ReadTable<T>(DataSet _dataSet)
        where T : new()
        {
            List<T> result = new List<T>();
            try
            {
                List<T> _objectList = new List<T>();
                if (_dataSet == null) return _objectList;
                if (_dataSet.Tables.Count <= 0) return _objectList;
                DataTable dataTable = _dataSet.Tables[0];

                var properties = GetPropertiesForType<T>();


                foreach (var row in dataTable.Rows)
                {
                    var item = CreateItemFromRow<T>((DataRow)row, properties);
                    result.Add(item);
                }
            }
            catch (Exception) { }
            return result;
        }

        public static List<T> ReadTable<T>(DataTable dataTable)
        where T : new()
        {
            List<T> result = new List<T>();
            try
            {
                List<T> _objectList = new List<T>();
                //if (_dataSet == null) return _objectList;
                if (dataTable.Rows.Count <= 0) return _objectList;
                //DataTable dataTable = _dataSet.Tables[0];

                var properties = GetPropertiesForType<T>();


                foreach (var row in dataTable.Rows)
                {
                    var item = CreateItemFromRow<T>((DataRow)row, properties);
                    result.Add(item);
                }
            }
            catch (Exception ex) { throw ex; }
            return result;
        }
        public static PropertyDescriptorCollection GetPropertiesForType<T>()
        {
            var type = typeof(T);
            if (!typeDictionary.ContainsKey(typeof(T)))
            {
                typeDictionary.Add(type, TypeDescriptor.GetProperties(type));
            }
            return typeDictionary[type];
        }

        
        private static T CreateItemFromRow<T>(DataRow row, PropertyDescriptorCollection properties) where T : new()
        {
            T item = new T();
            DataColumnCollection columns = row.Table.Columns;
            foreach (PropertyDescriptor property in properties)
            {
                if (columns.Contains(property.Name))
                {
                    var value = row[property.Name];
                    if (!(value is System.DBNull))
                    {
                        if(property.PropertyType == typeof(char))
                        {
                            char charvalue;
                            char.TryParse(value.ToString(), out charvalue);
                            property.SetValue(item, charvalue);
                        }
                        else if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(item, value.ToString());
                        }
                        else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                        {
                            int intValue = 0;
                            int.TryParse(value.ToString(), out intValue);
                            property.SetValue(item, intValue);
                        }
                        else if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(decimal?))
                        {
                            decimal intValue = 0;
                            decimal.TryParse(value.ToString(), out intValue);
                            property.SetValue(item, intValue);
                        }
                        else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                        {
                            DateTime intValue = System.DateTime.Now;
                            DateTime.TryParse(value.ToString(), out intValue);
                            property.SetValue(item, intValue);
                        }
                        else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                        {
                            bool intValue = false;
                            bool.TryParse(value.ToString(), out intValue);
                            property.SetValue(item, intValue);
                        }
                        else if (property.PropertyType == typeof(long) || property.PropertyType == typeof(long?))
                        {
                            long intValue = 0;
                            long.TryParse(value.ToString(), out intValue);
                            property.SetValue(item, intValue);
                        }
                        else
                        {
                            //var t = typeof(T);
                            //t = Nullable.GetUnderlyingType(t);
                            //property.SetValue(item, (T)Convert.ChangeType(value, t));
                            property.SetValue(item, value);
                        }
                    }
                }
            }
            return item;
        }
        private static Dictionary<Type, PropertyDescriptorCollection> typeDictionary =
      new Dictionary<Type, PropertyDescriptorCollection>();

        public static bool CheckDsIsNotNull(DataSet ds)
        {
            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static SessionData FillSessionDataForCandidate(DataSet ds)
        {
            SessionData sessionData = new SessionData();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sessionData.PID = Convert.ToInt64(dr["PersonalID"].ToString());
                    sessionData.CETApplicationFormNo = Convert.ToInt64(dr["CETApplicationFormNo"].ToString());
                    sessionData.CandidatureTypeID = Convert.ToInt16(dr["CandidatureTypeID"].ToString());
                    sessionData.StepID = Convert.ToInt16(dr["StepIDApplicationRound"].ToString());
                    sessionData.StepIDCAPRound1 = Convert.ToInt16(dr["StepIDCAPRound1"].ToString());
                    sessionData.StepIDCAPRound2 = Convert.ToInt16(dr["StepIDCAPRound2"].ToString());
                    sessionData.StepIDCAPRound3 = Convert.ToInt16(dr["StepIDCAPRound3"].ToString());
                    sessionData.StepIDCAPRound4 = Convert.ToInt16(dr["StepIDCAPRound4"].ToString());
                    sessionData.ApplicationFormStatus = Convert.ToChar(dr["ApplicationFormStatusApplicationRound"].ToString());
                    sessionData.OptionFormStatusCAPRound1 = Convert.ToChar(dr["OptionFormStatusCAPRound1"]);
                    sessionData.OptionFormStatusCAPRound2 = Convert.ToChar(dr["OptionFormStatusCAPRound2"]);
                    sessionData.OptionFormStatusCAPRound3 = Convert.ToChar(dr["OptionFormStatusCAPRound3"]);
                    sessionData.OptionFormStatusCAPRound4 = Convert.ToChar(dr["OptionFormStatusCAPRound4"]);
                    sessionData.EligibleForCAPRound1 = Convert.ToInt16(dr["EligibleForCAPRound1"].ToString());
                    sessionData.EligibleForCAPRound2 = Convert.ToInt16(dr["EligibleForCAPRound2"].ToString());
                    sessionData.EligibleForCAPRound3 = Convert.ToInt16(dr["EligibleForCAPRound3"].ToString());
                    sessionData.EligibleForCAPRound4 = Convert.ToInt16(dr["EligibleForCAPRound4"].ToString());
                }
            }
            return sessionData;
        }
        public static RegistrationDetails FillRegistrationDetails(DataSet ds)
        {
            RegistrationDetails model = new RegistrationDetails();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.CandidateName = results.GetString(0);
                        model.FatherName = results.GetString(1);
                        model.MotherName = results.GetString(2);
                        model.GenderCode = Convert.ToChar(results.GetValue(3));
                        model.DOB = results.GetDateTime(4);
                        model.ReligionID = results.GetInt16(5);
                        model.RegionCode = Convert.ToChar(results.GetValue(6));
                        model.MotherTongueID = results.GetInt16(7);
                        model.AnnualFamilyIncomeID = results.GetInt16(8);
                        model.AadhaarNumber = results.GetString(9);
                        model.NationalityID = results.GetInt32(10);
                        model.CAddressLine1 = results.GetString(11);
                        model.CAddressLine2 = results.GetString(12);
                        model.CAddressLine3 = results.GetString(13);
                        model.CAddress = results.GetString(14);
                        model.CStateID = results.GetInt16(15);
                        model.CDistrictID = results.GetInt32(16);
                        model.CTalukaID = results.GetInt32(17);
                        model.CVillageID = results.GetInt32(18);
                        model.CPincode = results.GetString(19);
                        model.STDCode = results.GetString(20);
                        model.PhoneNo = results.GetString(21);
                        model.MobileNo = results.GetString(22);
                        model.EMailID = results.GetString(23);
                        model.HasBankAccount = results.GetString(24);
                        model.AccountNumber = results.GetString(25);
                        model.IFSCCode = results.GetString(26);
                    }
                }
            }

            return model;
        }
        public static SpecialReservationDetails FillSpecialReservationDetails(DataSet ds)
        {
            SpecialReservationDetails model = new SpecialReservationDetails();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.PHTypeID = results.GetInt16(0);
                        model.DefenceTypeID = results.GetInt16(1);
                        model.IsOrphan = results.GetString(2);
                        //model.OrphanRegistrationNo = results.GetString(3);
                        //model.OrphanHasRelative = results.GetString(4);
                        model.AppliedForMinoritySeats = results.GetString(3);
                        model.LinguisticMinorityID = results.GetInt16(4);
                        model.ReligiousMinorityID = results.GetInt16(5);
                        model.AppliedForTFWS = results.GetString(6);
                    }
                }
            }
            return model;
        }
        public static QualificationDetails FillQualificationDetails(DataSet ds)
        {
            QualificationDetails model = new QualificationDetails();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.SSCBoardID = results.GetInt16(0);
                        model.SSCPassingYear = results.GetString(1);
                        model.SSCSeatNo = results.GetString(2);
                        model.SSCMathMarksObtained = results.GetDecimal(3);
                        model.SSCMathMarksOutOf = results.GetDecimal(4);
                        model.SSCMathPercentage = results.GetDecimal(5);
                        model.SSCTotalMarksObtained = results.GetDecimal(6);
                        model.SSCTotalMarksOutOf = results.GetDecimal(7);
                        model.SSCTotalPercentage = results.GetDecimal(8);
                        model.HSCPlace = results.GetString(9);
                        model.HSCBoardID = results.GetInt16(10);
                        model.OtherHSCBoard = results.GetString(11);
                        model.HSCPassingYear = results.GetString(12);
                        model.HSCSeatNo = results.GetString(13);
                        model.HSCPassingStatus = results.GetString(14);
                        model.HSCPhysicsMarksObtained = results.GetDecimal(15);
                        model.HSCPhysicsMarksOutOf = results.GetDecimal(16);
                        model.HSCPhysicsPercentage = results.GetDecimal(17);
                        model.HSCChemistryMarksObtained = results.GetDecimal(18);
                        model.HSCChemistryMarksOutOf = results.GetDecimal(19);
                        model.HSCChemistryPercentage = results.GetDecimal(20);
                        model.HSCSubjectID = results.GetInt32(21);
                        model.HSCSubjectMarksObtained = results.GetDecimal(22);
                        model.HSCSubjectMarksOutOf = results.GetDecimal(23);
                        model.HSCSubjectPercentage = results.GetDecimal(24);
                        model.HSCBioTechnologyMarksObtained = results.GetDecimal(25);
                        model.HSCBioTechnologyMarksOutOf = results.GetDecimal(26);
                        model.HSCBioTechnologyPercentage = results.GetDecimal(27);
                        model.HSCEnglishMarksObtained = results.GetDecimal(28);
                        model.HSCEnglishMarksOutOf = results.GetDecimal(29);
                        model.HSCEnglishPercentage = results.GetDecimal(30);
                        model.HSCTotalMarksObtained = results.GetDecimal(31);
                        model.HSCTotalMarksOutOf = results.GetDecimal(32);
                        model.HSCTotalPercentage = results.GetDecimal(33);
                        model.HSCPCSPercentage = results.GetDecimal(34);
                        model.AppearedForDiploma = results.GetString(35);
                        model.DiplomaMarksType = results.GetString(36);
                        model.DiplomaTotalMarksObtained = results.GetDecimal(37);
                        model.DiplomaTotalMarksOutOf = results.GetDecimal(38);
                        model.DiplomaTotalPercentage = results.GetDecimal(39);
                        model.NameAsPerHSCResult = results.GetString(40);
                        model.IsResultFetched = results.GetString(41);
                        model.HSCQDDOB = results.GetDateTime(42);
                        model.HSCMotherName = results.GetString(43);
                    }
                }
            }
            return model;
        }
        public static PersonalInformation FillPersonalInformation(DataSet ds)
        {
            PersonalInformation model = new PersonalInformation();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.PID = results.GetInt64(0);
                        model.ApplicationID = results.GetString(1);
                        model.CandidateName = results.GetString(2);
                        model.FatherName = results.GetString(3);
                        model.MotherName = results.GetString(4);
                        model.Gender = results.GetString(5);
                        model.DOB = results.GetString(6);
                        model.Religion = results.GetString(7);
                        model.Region = results.GetString(8);
                        model.MotherTongue = results.GetString(9);
                        model.AnnualFamilyIncome = results.GetString(10);
                        model.AadhaarNumber = results.GetString(11);
                        model.Nationality = results.GetString(12);
                        model.CAddressLine1 = results.GetString(13);
                        model.CAddressLine2 = results.GetString(14);
                        model.CAddressLine3 = results.GetString(15);
                        model.CAddress = results.GetString(16);
                        model.CState = results.GetString(17);
                        model.CDistrict = results.GetString(18);
                        model.CTaluka = results.GetString(19);
                        model.CVillage = results.GetString(20);
                        model.CPincode = results.GetString(21);
                        model.STDCode = results.GetString(22);
                        model.PhoneNo = results.GetString(23);
                        model.MobileNo = results.GetString(24);
                        model.EMailID = results.GetString(25);
                        model.HasBankAccount = results.GetString(26);
                        model.AccountNumber = results.GetString(27);
                        model.IFSCCode = results.GetString(28);
                        model.CandidatureType = results.GetString(29);
                        model.FinalCandidatureType = results.GetString(30);
                        model.DocumentOf = results.GetString(31);
                        model.MothersName = results.GetString(32);
                        model.SSCDistrict = results.GetString(33);
                        model.HSCDistrict = results.GetString(34);
                        model.HSCTaluka = results.GetString(35);
                        model.HomeUniversity = results.GetString(36);
                        model.FinalHomeUniversity = results.GetString(37);
                        model.Category = results.GetString(38);
                        model.FinalCategory = results.GetString(39);
                        model.CasteNameForOpen = results.GetString(40);
                        model.CasteName = results.GetString(41);
                        model.PHType = results.GetString(42);
                        model.FinalPHType = results.GetString(43);
                        model.DefenceType = results.GetString(44);
                        model.FinalDefenceType = results.GetString(45);
                        model.AppliedForMinoritySeats = results.GetString(46);
                        model.LinguisticMinorityDetails = results.GetString(47);
                        model.FinalLinguisticMinorityDetails = results.GetString(48);
                        model.ReligiousMinorityDetails = results.GetString(49);
                        model.FinalReligiousMinorityDetails = results.GetString(50);
                        model.SSCBoard = results.GetString(51);
                        model.SSCPassingYear = results.GetString(52);
                        model.SSCSeatNo = results.GetString(53);
                        model.SSCMathMarksObtained = results.GetDecimal(54);
                        model.SSCMathMarksOutOf = results.GetDecimal(55);
                        model.SSCMathPercentage = results.GetDecimal(56);
                        model.SSCTotalMarksObtained = results.GetDecimal(57);
                        model.SSCTotalMarksOutOf = results.GetDecimal(58);
                        model.SSCTotalPercentage = results.GetDecimal(59);
                        model.HSCPlace = results.GetString(60);
                        model.HSCBoard = results.GetString(61);
                        model.HSCPassingYear = results.GetString(62);
                        model.HSCSeatNo = results.GetString(63);
                        model.HSCPassingStatus = results.GetString(64);
                        model.HSCPhysicsMarksObtained = results.GetDecimal(65);
                        model.HSCPhysicsMarksOutOf = results.GetDecimal(66);
                        model.HSCPhysicsPercentage = results.GetDecimal(67);
                        model.HSCChemistryMarksObtained = results.GetDecimal(68);
                        model.HSCChemistryMarksOutOf = results.GetDecimal(69);
                        model.HSCChemistryPercentage = results.GetDecimal(70);
                        model.HSCSubject = results.GetString(71);
                        model.HSCSubjectMarksObtained = results.GetDecimal(72);
                        model.HSCSubjectMarksOutOf = results.GetDecimal(73);
                        model.HSCSubjectPercentage = results.GetDecimal(74);
                        model.HSCBioTechnologyMarksObtained = results.GetDecimal(75);
                        model.HSCBioTechnologyMarksOutOf = results.GetDecimal(76);
                        model.HSCBioTechnologyPercentage = results.GetDecimal(77);
                        model.HSCEnglishMarksObtained = results.GetDecimal(78);
                        model.HSCEnglishMarksOutOf = results.GetDecimal(79);
                        model.HSCEnglishPercentage = results.GetDecimal(80);
                        model.HSCTotalMarksObtained = results.GetDecimal(81);
                        model.HSCTotalMarksOutOf = results.GetDecimal(82);
                        model.HSCTotalPercentage = results.GetDecimal(83);
                        model.HSCPCSPercentage = results.GetDecimal(84);
                        model.AppearedForDiploma = results.GetString(85);
                        model.DiplomaMarksType = results.GetString(86);
                        model.DiplomaTotalMarksObtained = results.GetDecimal(87);
                        model.DiplomaTotalMarksOutOf = results.GetDecimal(88);
                        model.DiplomaTotalPercentage = results.GetDecimal(89);
                        model.AppearedForNEET= results.GetString(90);
                        model.NEETRollNo = results.GetInt64(91);

                        model.NEETPhysicsScore = results.GetDecimal(92);
                        model.NEETChemistryScore = results.GetDecimal(93);
                        model.NEETBiologyScore = results.GetDecimal(94);
                        model.NEETTotalScore = results.GetDecimal(95);
                        model.VersionNo = results.GetInt32(96);
                        model.LastModifiedOn = results.GetDateTime(97);
                        model.LastModifiedBy = results.GetString(98);
                        model.LastModifiedByIPAddress = results.GetString(99);
                        model.IsOrphan= results.GetString(100);
                        model.FinalIsOrphan = results.GetString(101);
                        model.AppliedForEWS= results.GetString(102);
                        model.FinalAppliedForEWS = results.GetString(103);
                        model.CETApplicationFee= results.GetInt32(104);
                        model.OnlineApplicationFee= results.GetInt32(105);
                        model.NameAsPerHSCResult = results.GetString(106);
                        model.AppliedForTFWS = results.GetString(107);
                        model.FinalAppliedForTFWS = results.GetString(108);
                        model.QualifyingExamPlace = results.GetString(60);
                        
                        if (results.FieldCount > 110)
                        {
                            if (!results.IsDBNull(109))
                            {
                                model.CETApplicationFormNo = results.GetInt64(109);
                            }
                            if (!results.IsDBNull(110))
                            {
                                model.CETRollNo = results.GetString(110);
                            }
                            if (!results.IsDBNull(111))
                            {
                                model.CETCandidateName = results.GetString(111);
                            }
                            if (!results.IsDBNull(112))
                            {
                                model.CETPhysicsMarks = results.GetString(112);
                            }
                            if (!results.IsDBNull(113))
                            {
                                model.CETChemistryMarks = results.GetString(113);
                            }
                            if (!results.IsDBNull(114))
                            {
                                model.CETMathMarks = results.GetString(114);
                            }
                            if (!results.IsDBNull(115))
                            {
                                model.CETBiologyMarks = results.GetString(115);
                            }
                            if (!results.IsDBNull(116))
                            {
                                model.CETPCMTotalMarks = results.GetString(116);
                            }
                            if (!results.IsDBNull(117))
                            {
                                model.CETPCBTotalMarks = results.GetString(117);
                            }
                            if (!results.IsDBNull(118))
                            {
                                model.CETPCMBMAX = results.GetString(118);
                            }
                            if (!results.IsDBNull(119))
                            {
                                model.NEETCName = results.GetString(119);
                            }
                        }

                        model.HSCVillage = results.GetString(120);

                        if (results.FieldCount>121)
                        {
                            if (!results.IsDBNull(121))
                            {
                                model.Comments = results.GetString(121);
                            }
                        }
                        if (results.FieldCount >= 125)
                        {
                            if (!results.IsDBNull(122))
                            {
                                model.FCRApplicationID = results.GetString(122);
                            }
                        }
                        if (results.FieldCount <= 125)
                        {
                            if (!results.IsDBNull(123))
                            {
                                model.DisplayFinalCategory = results.GetString(123);
                            }
                        }
                        if (results.FieldCount <= 125)
                        {
                            if (!results.IsDBNull(124))
                            {
                                model.DisplayFinalAppliedForEWS = results.GetString(124);
                            }
                        }

                    }
                }
            }
            return model;
        }


        public static InstituteSummary FillInstituteSummary(DataSet ds)
        {
            InstituteSummary model = new InstituteSummary();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.InstituteID = results.GetInt32(0);
                        model.InstituteCode = results.GetString(1);
                        model.InstituteName = results.GetString(2);
                        model.InstituteAddress = results.GetString(3);
                        model.RegionName = results.GetString(4);
                        model.DistrictName = results.GetString(5);
                        model.InstituteStatus1 = results.GetString(6);
                        model.InstituteStatus2 = results.GetString(7);
                        model.InstituteStatus3 = results.GetString(8);
                        model.BoysHostelCapacityIYear = results.GetInt32(9);
                        model.GirlsHostelCapacityIYear = results.GetInt32(10);
                        model.PublicRemark = results.GetString(11);
                    }
                }
            }
            return model;
        }
        public static InstituteProfile FillInstituteProfile(DataSet ds)
        {
            InstituteProfile model = new InstituteProfile();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.InstituteID = results.GetInt32(0);
                        model.InstituteName = results.GetString(1);
                        model.InstituteAddress = results.GetString(2);
                        model.InstitutePhoneNo = results.GetString(3);
                        model.InstituteFaxNo = results.GetString(4);
                        model.CoordinatorName = results.GetString(5);
                        model.CoordinatorDesignation = results.GetString(6);
                        model.CoordinatorDOB = results.GetDateTime(7);
                        model.CoordinatorMobileNo = results.GetString(8);
                        model.CoordinatorAltMobileNo = results.GetString(9);
                        model.CoordinatorEmailID = results.GetString(10);
                        model.CoordinatorPhoneNo = results.GetString(11);
                        model.InstituteCode = results.GetString(12);
                    }
                }
            }
            return model;
        }
        public static HomeUniversityAndCategoryDetails FillHomeUniversityAndCategoryDetails(DataSet ds)
        {
            HomeUniversityAndCategoryDetails model = new HomeUniversityAndCategoryDetails();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.DocumentForTypeACode = Convert.ToChar(results.GetValue(0));
                        model.DocumentOfCode = Convert.ToChar(results.GetValue(1));
                        model.MothersName = results.GetString(2);
                        model.SSCDistrictID = results.GetInt32(3);
                        model.HSCDistrictID = results.GetInt32(4);
                        model.HSCTalukaID = results.GetInt32(5);
                        model.HomeUniversityID = results.GetInt16(6);
                        model.CategoryID = results.GetInt16(7);
                        model.CasteNameForOpen = results.GetString(8);
                        model.CasteID = results.GetInt32(9);
                        model.AppliedForEWS = results.GetString(10);
                        model.CasteValidityStatus = Convert.ToChar(results.GetValue(11));
                        model.CVCApplicationNo = results.GetString(12);
                        model.CVCApplicationDate = results.GetString(13);
                        model.CVCAuthority = results.GetString(14);
                        model.CVCName = results.GetString(15);
                        model.CCNumber = results.GetString(16);
                        model.CVCDistrict = results.GetString(17);
                        model.NCLStatus = Convert.ToChar(results.GetValue(18));
                        model.NCLApplicationNo = results.GetString(19);
                        model.NCLApplicationDate = results.GetString(20);
                        model.NCLAuthority = results.GetString(21);

                        model.EWSStatus = Convert.ToChar(results.GetValue(22));
                        model.EWSApplicationNo = results.GetString(23);
                        model.EWSApplicationDate = results.GetString(24);
                        model.EWSDistrict = results.GetInt32(25);
                        model.EWSTaluka = results.GetInt32(26);
                        model.HSCVillageID = results.GetInt32(27);
                    }
                }
            }
            return model;
        }
        public static CourseInformation FillCourseInformation(DataSet ds)
        {
            CourseInformation model = new CourseInformation();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.InstituteCode = results.GetString(0);
                        model.ChoiceCodeDisplay = results.GetString(1);
                        model.CourseName = results.GetString(2);
                        model.UniversityName = results.GetString(3);
                        model.CourseStatus1 = results.GetString(4);
                        model.CourseStatus2 = results.GetString(5);
                        model.CourseStatus3 = results.GetString(6);
                        model.CourseShift = results.GetString(7);
                        model.Accreditation = results.GetString(8);
                        model.Gender = results.GetString(9);
                        model.IsGov = results.GetString(10);
                        model.IsStateLevel = results.GetString(11);
                        model.IsTFWS = results.GetString(12);
                        model.IsKonkan = results.GetString(13);
                        model.IsNRI = results.GetString(14);
                        model.IsPIO = results.GetString(15);
                        model.ParticipateInCAP = results.GetString(16);
                        model.CourtCaseRemark = results.GetString(17);
                        model.TotalIntake = results.GetInt32(18);
                        model.CAPIntake = results.GetInt32(19);
                        model.ILIntake = results.GetInt32(20);
                        model.MIIntake = results.GetInt32(21);
                        model.JKIntake = results.GetInt32(22);
                        model.MSIntake = results.GetInt32(23);
                        model.AIIntake = results.GetInt32(24);
                        model.GOPENH = results.GetInt32(25);
                        model.GSCH = results.GetInt32(26);
                        model.GSTH = results.GetInt32(27);
                        model.GVJH = results.GetInt32(28);
                        model.GNT1H = results.GetInt32(29);
                        model.GNT2H = results.GetInt32(30);
                        model.GNT3H = results.GetInt32(31);
                        model.GOBCH = results.GetInt32(32);
                        model.GSEBCH = results.GetInt32(33);
                        model.LOPENH = results.GetInt32(34);
                        model.LSCH = results.GetInt32(35);
                        model.LSTH = results.GetInt32(36);
                        model.LVJH = results.GetInt32(37);
                        model.LNT1H = results.GetInt32(38);
                        model.LNT2H = results.GetInt32(39);
                        model.LNT3H = results.GetInt32(40);
                        model.LOBCH = results.GetInt32(41);
                        model.LSEBCH = results.GetInt32(42);
                        model.PHCH = results.GetInt32(43);
                        model.PHCSCH = results.GetInt32(44);
                        model.PHCSTH = results.GetInt32(45);
                        model.PHCVJH = results.GetInt32(46);
                        model.PHCNT1H = results.GetInt32(47);
                        model.PHCNT2H = results.GetInt32(48);
                        model.PHCNT3H = results.GetInt32(49);
                        model.PHCOBCH = results.GetInt32(50);
                        model.PHCSEBCH = results.GetInt32(51);
                        model.GOPENO = results.GetInt32(52);
                        model.GSCO = results.GetInt32(53);
                        model.GSTO = results.GetInt32(54);
                        model.GVJO = results.GetInt32(55);
                        model.GNT1O = results.GetInt32(56);
                        model.GNT2O = results.GetInt32(57);
                        model.GNT3O = results.GetInt32(58);
                        model.GOBCO = results.GetInt32(59);
                        model.GSEBCO = results.GetInt32(60);
                        model.LOPENO = results.GetInt32(61);
                        model.LSCO = results.GetInt32(62);
                        model.LSTO = results.GetInt32(63);
                        model.LVJO = results.GetInt32(64);
                        model.LNT1O = results.GetInt32(65);
                        model.LNT2O = results.GetInt32(66);
                        model.LNT3O = results.GetInt32(67);
                        model.LOBCO = results.GetInt32(68);
                        model.LSEBCO = results.GetInt32(69);
                        model.PHCO = results.GetInt32(70);
                        model.PHCSCO = results.GetInt32(71);
                        model.PHCSTO = results.GetInt32(72);
                        model.PHCVJO = results.GetInt32(73);
                        model.PHCNT1O = results.GetInt32(74);
                        model.PHCNT2O = results.GetInt32(75);
                        model.PHCNT3O = results.GetInt32(76);
                        model.PHCOBCO = results.GetInt32(77);
                        model.PHCSEBCO = results.GetInt32(78);
                        model.DEFO = results.GetInt32(79);
                        model.DEFSCO = results.GetInt32(80);
                        model.DEFSTO = results.GetInt32(81);
                        model.DEFVJO = results.GetInt32(82);
                        model.DEFNT1O = results.GetInt32(83);
                        model.DEFNT2O = results.GetInt32(84);
                        model.DEFNT3O = results.GetInt32(85);
                        model.DEFOBCO = results.GetInt32(86);
                        model.DEFSEBCO = results.GetInt32(87);
                        model.EWS = results.GetInt32(88);
                        model.ORPHAN = results.GetInt32(89);
                        model.PHHT = results.GetInt32(90);
                        model.PHOT = results.GetInt32(91);
                        model.DEFT = results.GetInt32(92);
                    }
                }
            }
            return model;
        }
        public static CasteList FillCasteList(DataSet ds)
        {
            CasteList model = new CasteList();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.CasteID = results.GetInt32(0);
                        model.CasteName = results.GetString(1);
                        model.CasteSrNo = results.GetString(2);
                    }
                }
            }
            return model;
        }
        public static ARCProfile FillARCProfile(DataSet ds)
        {
            ARCProfile model = new ARCProfile();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.ARCCode = results.GetString(0);
                        model.ARCName = results.GetString(1);
                        model.ARCAddress = results.GetString(2);
                        model.ARCPhoneNo = results.GetString(3);
                        model.ARCFaxNo = results.GetString(4);
                        model.CoordinatorName = results.GetString(5);
                        model.CoordinatorDesignation = results.GetString(6);
                        model.CoordinatorDOB = results.GetDateTime(7);
                        model.CoordinatorMobileNo = results.GetString(8);
                        model.CoordinatorAltMobileNo = results.GetString(9);
                        model.CoordinatorEmailID = results.GetString(10);
                        model.CoordinatorPhoneNo = results.GetString(11);
                        model.SecurityQuestionID = results.GetInt16(12);
                        model.SecurityQuestion = results.GetString(13);
                        model.SecurityAnswer = results.GetString(14);
                        model.ARCPassword = results.GetString(15);
                    }
                }
            }
            return model;
        }
        public static AFCProfile FillAFCProfile(DataSet ds)
        {
            AFCProfile model = new AFCProfile();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.AFCCode = results.GetString(0);
                        model.AFCName = results.GetString(1);
                        model.AFCAddress = results.GetString(2);
                        model.AFCPhoneNo = results.GetString(3);
                        model.AFCFaxNo = results.GetString(4);
                        model.CoordinatorName = results.GetString(5);
                        model.CoordinatorDesignation = results.GetString(6);
                        model.CoordinatorDOB = results.GetDateTime(7);
                        model.CoordinatorMobileNo = results.GetString(8);
                        model.CoordinatorAltMobileNo = results.GetString(9);
                        model.CoordinatorEmailID = results.GetString(10);
                        model.CoordinatorPhoneNo = results.GetString(11);
                        model.SecurityQuestionID = results.GetInt16(12);
                        model.SecurityQuestion = results.GetString(13);
                        model.SecurityAnswer = results.GetString(14);
                        model.AFCPassword = results.GetString(15);
                        model.IsEFC = Convert.ToChar(results.GetValue(16));
                        model.EFCCapacity = results.GetInt32(17);
                    }

                }
            }
            return model;
        }
        public static List<Master_Village> FillMasterVillage(DataSet ds)
        {
            List<Master_Village> lstmodel = new List<Master_Village>();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        Master_Village model = new Master_Village();
                        model.VillageID = results.GetInt32(0);
                        model.VillageName = results.GetString(1);
                        model.TalukaID = results.GetInt32(2);
                        lstmodel.Add(model);
                    }
                }
            }
            return lstmodel;
        }
        public static List<Master_Taluka> FillMasterTaluka(DataSet ds)
        {
            List<Master_Taluka> lstmodel = new List<Master_Taluka>();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        Master_Taluka model = new Master_Taluka();
                        model.TalukaID = results.GetInt32(0);
                        model.TalukaName = results.GetString(1);
                        model.DistrictID = results.GetInt32(2);
                        lstmodel.Add(model);
                    }
                }
            }
            return lstmodel;
        }
        public static List<Master_District> FillMasterDistrict(DataSet ds)
        {
            List<Master_District> lstmodel = new List<Master_District>();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        Master_District model = new Master_District();
                        model.DistrictID = results.GetInt32(0);
                        model.DistrictName = results.GetString(1);
                        model.StateID = results.GetInt16(2);
                        lstmodel.Add(model);
                    }
                }
            }
            return lstmodel;
        }
        public static NEETDetails FillNEETDetails(DataSet ds)
        {
            NEETDetails model = new NEETDetails();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.AppearedForNEET = results.GetString(0);
                        model.NEETRollNo = results.GetInt64(1);
                        model.NEETPhysicsScore = results.GetDecimal(2);
                        model.NEETChemistryScore = results.GetDecimal(3);
                        model.NEETBiologyScore = results.GetDecimal(4);
                        model.NEETTotalScore = results.GetDecimal(5);
                        model.NameAsPerNEET = results.GetString(6);

                    }
                }
            }
            return model;
        }
        public static ResponseCommon FillDocumentFetchData(DataSet ds)
        {
            ResponseCommon model = new ResponseCommon();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.PersonalID = results.GetInt64(0);
                        model.DocumentID = results.GetInt64(1);
                        model.Barcode = results.GetString(2);
                        model.ApplicantName = results.GetString(3);
                        if (!results.IsDBNull(4))
                            model.Caste = results.GetString(4);
                        if (!results.IsDBNull(5))
                            model.BenfiName = results.GetString(5);
                        if (!results.IsDBNull(6))
                            model.ClosedOn = results.GetString(6);
                        if (!results.IsDBNull(7))
                            model.DistrictName = results.GetString(7);
                        if (!results.IsDBNull(8))
                            model.PaymentDate = results.GetString(8);
                        if (!results.IsDBNull(9))
                            model.YearsOfResidency = results.GetString(9);
                        if (!results.IsDBNull(10))
                            model.CertificateDate = results.GetString(10);
                        if (!results.IsDBNull(11))
                            model.TribeName = results.GetString(11);
                        if (!results.IsDBNull(12))
                            model.ApplicationType = results.GetString(12);
                        if (!results.IsDBNull(13))
                            model.CommitteeName = results.GetString(13);
                        if (!results.IsDBNull(14))
                            model.CertificateIssuedById = results.GetString(14);
                        if (!results.IsDBNull(15))
                            model.AllottedDate = results.GetString(15);
                        if (!results.IsDBNull(16))
                            model.PercentageOfDisability = results.GetString(16);
                        if (!results.IsDBNull(17))
                            model.DisabilityType = results.GetString(17);
                        if (!results.IsDBNull(18))
                            model.Years = results.GetString(18);
                        if (!results.IsDBNull(19))
                            model.FirstYearIncome = results.GetString(19);
                        if (!results.IsDBNull(20))
                            model.SecondYearIncome = results.GetString(20);
                        if (!results.IsDBNull(21))
                            model.ThirdYearIncome = results.GetString(21);
                    }
                }
            }
            return model;
        }

        public static MVSOProfile FillMVSOProfile(DataSet ds)
        {
            MVSOProfile model = new MVSOProfile();
            using (DataTableReader results = ds.CreateDataReader(ds.Tables[0]))
            {
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        model.SOCode = results.GetString(0);
                        model.SOName = results.GetString(1);
                        model.SOMobile = results.GetString(2);
                        model.Email = results.GetString(3);
                        model.Designation = results.GetString(4);
                    }

                }
            }
            return model;
        }

    }


}
