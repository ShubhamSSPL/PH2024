using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Xml;
using RestSharp;
using Synthesys.DataAcess;
using System.Data.SqlClient;
using System.Net;
public class HSCResultAPIFetch
{
    public static DataSet GetHSCResultData(Int64 PID, string passingYear, string hscSeatNo)
    {
        DataSet dsResult = new DataSet();

        try
        {
            string cetKey = "e2b27095cf0549f17bd19386616e546178066a181eb2b77c02fc4a1ab339803e";

            string apiUrl = "https://boardmarksheet.maharashtra.gov.in/StateBoardCETAPI/api/1/pull/uri";

            // Set the necessary headers, such as authentication if required

            // Create the XML payload as a string
            string xmlPayload = "";

            string timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss+05:30");
            string orgid = "in.gov.maharashtra.cetcell";
            string xmlns = "https://cetcell.mahacet.org/pullurireuest";
            string ver = "1.0";

            Guid uId = Guid.NewGuid();

            string uniqueIDforRequest = uId.ToString().Replace("-", ""); //"d8757c3dba993421678876dc82156852"; // Uniquid ID to calculated up to 35 max length

            string keyhashgenerated = CalculateSHA256(cetKey + timestamp);
            keyhashgenerated = keyhashgenerated;
            StringBuilder strbuild = new StringBuilder();
            strbuild.Append(@"<?xml version = ""1.0"" encoding = ""UTF - 8"" standalone = ""yes""?>");
            strbuild.Append(@"<PullURIRequest xmlns=""" + xmlns + @""" ver=""" + ver + @""" ts=""" + timestamp + @"""  txn = """ + uniqueIDforRequest + @""" orgid = """ + orgid + @""" keyhash =""" + keyhashgenerated + @""" portalid =""1"">");
            string Doctype = "HSC";
            string DocYear = passingYear; // "2023";
            string DocRollno = hscSeatNo;  //"S075450";
            string Docexsession = "MAR";
            strbuild.Append(@"<DocDetails><DocType>" + Doctype + @"</DocType><year>" + DocYear + @"</year><rollnumber>" + DocRollno + @"</rollnumber><exsession>" + Docexsession + @"</exsession></DocDetails></PullURIRequest>");

            xmlPayload = strbuild.ToString();

            byte[] xmlreqBytes = Encoding.UTF8.GetBytes(xmlPayload);

            string strResult;
            using (StreamReader reader = new StreamReader(new MemoryStream(xmlreqBytes), Encoding.UTF8))
            {
                strResult = reader.ReadToEnd();
            }

            string cal_hmac = HmacSha256(cetKey, strResult);
            byte[] hmacBytes = Encoding.UTF8.GetBytes(cal_hmac);
            string encodedBase64 = Convert.ToBase64String(hmacBytes);

            string xhmac = encodedBase64;
            byte[] payloadBytes = Encoding.UTF8.GetBytes(strResult);

            // Create a RestRequest with the XML payload
            RestRequest request = new RestRequest(Method.POST);
            request.Resource = apiUrl;
            request.AddParameter("application/xml", payloadBytes, ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/xml");
            request.AddHeader("x-hmac", xhmac);

            // Create a RestClient and execute the request
            RestClient restClient = new RestClient();
            IRestResponse response = restClient.Execute(request);

            string ResponseStatus = "-1";

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = response.Content;
                DataTable DTIMPORT = ReadXmlData(result);
                if (DTIMPORT.Rows.Count > 0)
                {
                    ResponseStatus = DTIMPORT.Rows[0]["ResponseStatus"].ToString();
                }
                else
                {
                    DTIMPORT = new DataTable();
                    DTIMPORT.Columns.Add("ResponseStatus");
                    DataRow DR = DTIMPORT.NewRow();
                    DR["ResponseStatus"] = "-1";
                    DTIMPORT.Rows.Add(DR);
                }

                dsResult.Tables.Add(DTIMPORT);
            }
            else
            {
                DataTable DTIMPORT = new DataTable();
                DTIMPORT.Columns.Add("ResponseStatus");
                DataRow DR = DTIMPORT.NewRow();
                DR["ResponseStatus"] = "-1";
                DTIMPORT.Rows.Add(DR);
                dsResult.Tables.Add(DTIMPORT);
            }

            DBUtilityHSCAPI reg = new DBUtilityHSCAPI();
            UserInfo.GetIPAddress();
            reg.saveHSCResultAPIFetchDetails(PID, passingYear, hscSeatNo, uniqueIDforRequest, keyhashgenerated, timestamp, strResult, xhmac, response.StatusCode.ToString(), response.Content.ToString(),
                DateTime.Now, ResponseStatus, HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

            // Save Request to the Database

            // ID - autogenerate bigint
            // PersonalID bigint
            // DocYear nvarchar (5)
            // DocRollno nvarchar (10)
            // uniqueIDforRequest nvarchar(35)
            // keyhashgenerated nvarchar(150)
            // timestamp nvarchar(50)
            // RequestXML - strResult nvarchar(1000)
            // xhmac nvarchar(200)
            // response.StatusCode - response.StatusCode nvarchar(10)
            // ResponseXML -  response.Content (save to database) nvarchar(max)
            // RequestEndTime - datetime.now datetime
            // ResponseStatus nvarchar(3)

            // End Request to the Database

        }
        catch (Exception)
        {
            DataTable DTIMPORT = new DataTable();


            DTIMPORT.Columns.Add("ResponseStatus");
            DataRow DR = DTIMPORT.NewRow();
            DR["ResponseStatus"] = "-1";
            DTIMPORT.Rows.Add(DR);
            dsResult.Tables.Add(DTIMPORT);
        }


        return dsResult;
    }
    private static DataTable ReadXmlData(string xmldata)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmldata);

        DataTable DTIMPORT = new DataTable();

        DTIMPORT.Columns.Add("ResponseStatus");
        DTIMPORT.Columns.Add("DocType");
        DTIMPORT.Columns.Add("flag");
        DTIMPORT.Columns.Add("year");
        DTIMPORT.Columns.Add("NAME");
        DTIMPORT.Columns.Add("session");
        DTIMPORT.Columns.Add("rollnumber");
        DTIMPORT.Columns.Add("totalmarks");
        DTIMPORT.Columns.Add("TOTAL");
        DTIMPORT.Columns.Add("PASS_FAIL");
        DTIMPORT.Columns.Add("PERCENT");
        DTIMPORT.Columns.Add("gender");
        DTIMPORT.Columns.Add("reservation_category");
        DTIMPORT.Columns.Add("fresher_repater_indic");
        DTIMPORT.Columns.Add("minority");
        DTIMPORT.Columns.Add("ENGLISH");
        DTIMPORT.Columns.Add("MARATHI");
        DTIMPORT.Columns.Add("SANSKRIT");

        DTIMPORT.Columns.Add("HINDI");
        DTIMPORT.Columns.Add("PHYSICS");
        DTIMPORT.Columns.Add("MATHEMATICS&STATISTICS");
        DTIMPORT.Columns.Add("CHEMISTRY");
        DTIMPORT.Columns.Add("BIOLOGY");
        DTIMPORT.Columns.Add("INFORMATIONTECHNOLOGY");
        DTIMPORT.Columns.Add("ELECTRICALMAINTENANCE");
        DTIMPORT.Columns.Add("MECHANICALMAINTENANCE");
        DTIMPORT.Columns.Add("SCOOTERMOTORCYCLESERV");
        DTIMPORT.Columns.Add("GENERALCIVILENGINEERING");
        DTIMPORT.Columns.Add("ELECTRONICS");
        DTIMPORT.Columns.Add("COMPUTERSCIENCE");
        DTIMPORT.Columns.Add("TOTAL_HINDI");
        DTIMPORT.Columns.Add("TOTAL_MARATHI");
        DTIMPORT.Columns.Add("TOTAL_SANSKRIT");

        DTIMPORT.Columns.Add("TOTAL_ENGLISH");
        DTIMPORT.Columns.Add("TOTAL_PHYSICS");
        DTIMPORT.Columns.Add("TOTAL_MATHEMATICS&STATISTICS");
        DTIMPORT.Columns.Add("TOTAL_CHEMISTRY");
        DTIMPORT.Columns.Add("TOTAL_BIOLOGY");
        DTIMPORT.Columns.Add("TOTAL_INFORMATIONTECHNOLOGY");
        DTIMPORT.Columns.Add("TOTAL_ELECTRICALMAINTENANCE");
        DTIMPORT.Columns.Add("TOTAL_MECHANICALMAINTENANCE");
        DTIMPORT.Columns.Add("TOTAL_SCOOTERMOTORCYCLESERV");
        DTIMPORT.Columns.Add("TOTAL_GENERALCIVILENGINEERING");
        DTIMPORT.Columns.Add("TOTAL_ELECTRONICS");
        DTIMPORT.Columns.Add("TOTAL_COMPUTERSCIENCE");
        DTIMPORT.Columns.Add("MaxMarkColumn");
        DTIMPORT.Columns.Add("MaxMark");
        DTIMPORT.Columns.Add("MAX_OPTIONAL_TOTAL");


        DTIMPORT.Columns["TOTAL"].DefaultValue = 0;
        DTIMPORT.Columns["PERCENT"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL"].DefaultValue = 0;
        DTIMPORT.Columns["ENGLISH"].DefaultValue = 0;
        DTIMPORT.Columns["MARATHI"].DefaultValue = 0;
        DTIMPORT.Columns["SANSKRIT"].DefaultValue = 0;

        DTIMPORT.Columns["HINDI"].DefaultValue = 0;
        DTIMPORT.Columns["PHYSICS"].DefaultValue = 0;
        DTIMPORT.Columns["MATHEMATICS&STATISTICS"].DefaultValue = 0;
        DTIMPORT.Columns["CHEMISTRY"].DefaultValue = 0;
        DTIMPORT.Columns["BIOLOGY"].DefaultValue = 0;
        DTIMPORT.Columns["INFORMATIONTECHNOLOGY"].DefaultValue = 0;
        DTIMPORT.Columns["ELECTRICALMAINTENANCE"].DefaultValue = 0;
        DTIMPORT.Columns["MECHANICALMAINTENANCE"].DefaultValue = 0;
        DTIMPORT.Columns["SCOOTERMOTORCYCLESERV"].DefaultValue = 0;
        DTIMPORT.Columns["GENERALCIVILENGINEERING"].DefaultValue = 0;
        DTIMPORT.Columns["ELECTRONICS"].DefaultValue = 0;
        DTIMPORT.Columns["COMPUTERSCIENCE"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_HINDI"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_MARATHI"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_SANSKRIT"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_ENGLISH"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_PHYSICS"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_MATHEMATICS&STATISTICS"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_CHEMISTRY"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_BIOLOGY"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_INFORMATIONTECHNOLOGY"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_ELECTRICALMAINTENANCE"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_MECHANICALMAINTENANCE"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_SCOOTERMOTORCYCLESERV"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_GENERALCIVILENGINEERING"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_ELECTRONICS"].DefaultValue = 0;
        DTIMPORT.Columns["TOTAL_COMPUTERSCIENCE"].DefaultValue = 0;
        DTIMPORT.Columns["MaxMark"].DefaultValue = 0;
        DTIMPORT.Columns["MAX_OPTIONAL_TOTAL"].DefaultValue = 0;

        DataRow DR = DTIMPORT.NewRow();

        foreach (XmlNode node1 in doc.DocumentElement.ChildNodes)
        {
            if (node1.Name == "ResponseStatus")
            {
                DR["ResponseStatus"] = node1.InnerText;
            }
            if (node1.Name == "DocDetails")
            {

                foreach (XmlNode node2 in node1.ChildNodes)
                {
                    if (node2.NodeType == XmlNodeType.Element)
                    {
                        string name = node2.Name;
                        string value = node2.InnerText;
                        if (name == "subjects")
                        {
                            foreach (XmlNode node3 in node2.ChildNodes)
                            {

                                string subname = node3.ChildNodes[0].InnerText;
                                string totalmarks = node3.ChildNodes[1].InnerText;
                                string obtainmarks_str = node3.ChildNodes[2].InnerText == "" ? "0" : node3.ChildNodes[2].InnerText; //node3.ChildNodes[2].InnerText;
                                string subcolname = GetColumnName(subname);

                                if (DTIMPORT.Columns.Contains(subcolname))
                                {
                                    DR[subcolname] = obtainmarks_str;
                                    DR["TOTAL_" + subcolname] = totalmarks;
                                }

                            }
                        }
                        else
                        {
                            DR[GetColumnName(name)] = value;
                        }
                    }
                    else
                    {

                    }
                }
                string[] optional_subject = { "BIOLOGY", "INFORMATIONTECHNOLOGY", "ELECTRICALMAINTENANCE", "MECHANICALMAINTENANCE", "SCOOTERMOTORCYCLESERV", "GENERALCIVILENGINEERING" };
                int max_marks = 0;

                for (int i = 0; i < optional_subject.Length; i++)
                {
                    string OPT_SUB = optional_subject[i];
                    int OPT_marks = getMarks(DR[OPT_SUB].ToString());
                    if (OPT_marks > max_marks)
                    {
                        DR["MaxMarkColumn"] = OPT_SUB;
                        DR["MaxMark"] = DR[OPT_SUB];
                        DR["MAX_OPTIONAL_TOTAL"] = DR["TOTAL_" + OPT_SUB];

                    }
                }
            }
        }

        string obtainmarks = DR["TOTAL"].ToString();
        if (obtainmarks.IndexOf("+") > -1)
        {
            string[] obtainlst = obtainmarks.Split(new string[] { "$", "@", "*", "+" }, StringSplitOptions.RemoveEmptyEntries);
            float obtain_marks = 0;
            for (int i = 0; i < obtainlst.Length; i++)
            {
                obtain_marks = obtain_marks + float.Parse(obtainlst[i]);
            }
            DR["TOTAL"] = obtain_marks.ToString();

        }
        DTIMPORT.Rows.Add(DR);
        return DTIMPORT;
    }

    public static int getMarks(string marks)
    {
        int marks_val = 0;
        try
        {
            marks_val = int.Parse(marks);
        }
        catch (Exception)
        {
        }
        return marks_val;
    }
    public static string GetColumnName(string name)
    {
        string colname = name;
        switch (name)
        {
            case "MATHEMATICS AND STATISTICS":
                colname = "MATHEMATICS&STATISTICS";
                break;
            case "studname":
                colname = "NAME";
                break;
            case "result":
                colname = "PASS_FAIL";
                break;
            case "obtainedmarks":
                colname = "TOTAL";
                break;
            case "percentage":
                colname = "PERCENT";
                break;


            default:
                break;

        }
        colname = colname.Replace(" ", "");
        return colname;

    }

    public static string HmacSha256(string KEY, string VALUE)
    {
        return HmacSha(KEY, VALUE, "HmacSHA256");
    }
    public static string CalculateSHA256(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
    public static string HmacSha(string KEY, string VALUE, string SHA_TYPE)
    {
        try
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(KEY);
            byte[] valueBytes = Encoding.UTF8.GetBytes(VALUE);

            using (HMACSHA256 hmac = new HMACSHA256(keyBytes))
            {
                byte[] rawHmac = hmac.ComputeHash(valueBytes);

                byte[] hexArray = {
                (byte)'0', (byte)'1', (byte)'2', (byte)'3',
                (byte)'4', (byte)'5', (byte)'6', (byte)'7',
                (byte)'8', (byte)'9', (byte)'a', (byte)'b',
                (byte)'c', (byte)'d', (byte)'e', (byte)'f'
            };
                byte[] hexChars = new byte[rawHmac.Length * 2];
                for (int j = 0; j < rawHmac.Length; j++)
                {
                    int v = rawHmac[j] & 0xFF;
                    hexChars[j * 2] = hexArray[v >> 4];
                    hexChars[j * 2 + 1] = hexArray[v & 0x0F];
                }
                return Encoding.UTF8.GetString(hexChars);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}

public class DBUtilityHSCAPI
{
    public void saveHSCResultAPIFetchDetails(Int64 PID, string PassingYear, string HSCSeatNo, 
        string UniqueIDforRequest, string KeyHashGenerated, string TimeStamp, 
        string RequestXML, string xhmac, string ResponseStatusCode,
        string ResponseXML, DateTime RequestEndTime, string ResponseStatus, string CreatedBy, string CreatedByIPAddress)
    {
        DBConnection db = new DBConnection();
        try
        {
            db.ExecuteScaler("MHDTE_spSaveHSCResultAPIFetch", new SqlParameter[]
            {
                new SqlParameter("@PersonalID", PID),
                new SqlParameter("@PassingYear", PassingYear),
                new SqlParameter("@HSCSeatNo", HSCSeatNo),

                new SqlParameter("@UniqueIDforRequest", UniqueIDforRequest),
                new SqlParameter("@KeyHashGenerated", KeyHashGenerated),
                new SqlParameter("@TimeStamp", TimeStamp),

                new SqlParameter("@RequestXML", RequestXML),
                new SqlParameter("@xhmac", xhmac),
                new SqlParameter("@ResponseStatusCode", ResponseStatusCode),

                new SqlParameter("@ResponseXML", ResponseXML),
                new SqlParameter("@RequestEndTime", RequestEndTime),
                new SqlParameter("@ResponseStatus", ResponseStatus),

                new SqlParameter("@CreatedBy", CreatedBy),
                new SqlParameter("@CreatedByIPAddress", CreatedByIPAddress) 
                 
             
            });
        }
        finally
        {
            db.Dispose();
        }

    }
}