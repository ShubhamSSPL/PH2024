using DataAccess.Implementation;
using EntityModel;
using forProjectCustomExceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class MahaITDocumentFetch 
{
    public Token GetAccessToken(string ClientKeyId, string ClientSecret)
    {
        //List<Table> lstchoiceCode = new List<Table>();
        Token token = new Token();
        try
        {
            var client = new RestClient("http://citizenapi.mahaonlinegov.in/api/Authenticate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.RequestFormat = DataFormat.Json;
            //request.AddParameter("application/json", "{\n\"ClientKeyId\":\"V55Y1XGgWIZXzLu\"\n,\n\"ClientSecret\":\"9F24teLMdGdmtRL\"\n}", ParameterType.RequestBody);
            request.AddParameter("application/json", "{\n\"ClientKeyId\":\"" + ClientKeyId + "\"\n,\n\"ClientSecret\":\"" + ClientSecret + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                token.tokenStatus = response.StatusCode.ToString();
                token.token = response.Content;
            }
            else
            {
                token.tokenStatus = response.StatusCode.ToString();
                token.tokenErroMsg = response.Content.ToString();
            }
        }
        catch (Exception ex)
        {
            long messageID = ExceptionMessages.GetMessageDetails();
            new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "api/InstDataForAdmission?degreeLevel=UG&degreeName=ENGG", "");
        }

        return token;
    }
    public T FetchDocument<T>(string Barcode, string DocumentName) where T : new ()
    {
        //List<Table> lstchoiceCode = new List<Table>();
        T responseResult = new T();
        try
        {
            Token token = new Token();
            SecretKey secretKey = GetClientIDScreat.Where(x => x.Id == DocumentName).FirstOrDefault();
            token = GetAccessToken(secretKey.ClientKeyId, secretKey.ClientSecret);
            if (token.tokenStatus == "OK")
            {
                dynamic accessKey = JsonConvert.DeserializeObject(token.token.ToString());
                //Object json = JObject.Parse(accessKey);
                //token.token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlY1NVkxWEdnV0laWHpMdSIsInJvbGUiOiJDbGllbnQiLCJTZXJ2aWNlIjoiMyIsIm5iZiI6MTYwMjMxODgzNSwiZXhwIjoxNjAyNDA1MjM1LCJpYXQiOjE2MDIzMTg4MzUsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTQ0ODAiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjU0NDgwIn0.6xfFJLlZFEtJw8fkPQ5TiQ_yFCjZ_rcq_Lt9tGZhY3o";
                var client = new RestClient("http://citizenapi.mahaonlinegov.in/api/" + DocumentName);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddHeader("authorization", accessKey);
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("application/json", "{\n\"Barcode\": \"" + Barcode + "\"\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    responseResult = JsonConvert.DeserializeObject<T>(response.Content);
                }
                 
            }
        }
        catch (Exception ex)
        {
            long messageID = ExceptionMessages.GetMessageDetails();
            new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "api/InstDataForAdmission?degreeLevel=UG&degreeName=ENGG", "");
        }
        return responseResult;
    }
    public class Token
    {
        public string token { get; set; }
        public string tokenStatus { get; set; }
        public string tokenErroMsg { get; set; }
    }

    public class SecretKey
    {
        public string Id { get; set; }
        public string ClientKeyId { get; set; }
        public string ClientSecret { get; set; }
    }
    public List<SecretKey> GetClientIDScreat
    {
        get
        {
            List<SecretKey> lstSecretKye = new List<SecretKey>();
            lstSecretKye.Add(new SecretKey { Id = "Income", ClientKeyId = "hyzShNUj0nrEhFf", ClientSecret = "nYGOuBYWqAAEm0O" });
            lstSecretKye.Add(new SecretKey { Id = "CasteCertificate", ClientKeyId = "maeWiC6S4njHGwL", ClientSecret = "Lul7OfhMuNOJJ2m" });
            lstSecretKye.Add(new SecretKey { Id = "AgeNationalityDomicile", ClientKeyId = "V55Y1XGgWIZXzLu", ClientSecret = "9F24teLMdGdmtRL" });
            lstSecretKye.Add(new SecretKey { Id = "CasteValidity", ClientKeyId = "oaxWNjN6d8RnIca", ClientSecret = "lHNScLvph5CQoG5" });
            lstSecretKye.Add(new SecretKey { Id = "DisabilityCertificate", ClientKeyId = "cEN7faIkMFh2cYu", ClientSecret = "X3ev6FrWtcDrkVw" });
            lstSecretKye.Add(new SecretKey { Id = "NclCertificate", ClientKeyId = "G7fIg2pkk4Glf8d", ClientSecret = "nRcHt8J8uI6AxVo" });



            return lstSecretKye;
        }
    }

    public ResponseCommon MapResult(ResponseIncome result) 
    {
        ResponseCommon response = new ResponseCommon();
        response.ApplicantName = result.ApplicantName;
        response.Barcode = result.Barcode;
        response.BenfiName = result.BenfiName;
        response.FirstYearIncome = result.FirstYearIncome;
        response.SecondYearIncome = result.SecondYearIncome;
        response.ThirdYearIncome = result.ThirdYearIncome;
        response.Years = result.Years;
        return response;
    }
    public ResponseCommon MapResult(ResponseNCL result)
    {
        ResponseCommon response = new ResponseCommon();
        response.ApplicantName = result.ApplicantName;
        response.Barcode = result.Barcode;
        response.BenfiName = result.BenfiName;
        response.FirstYearIncome = result.FirstYearIncome;
        response.SecondYearIncome = result.SecondYearIncome;
        response.ThirdYearIncome = result.ThirdYearIncome;
        response.Years = result.Years;
        return response;

    }
    public ResponseCommon MapResult(ResponseDisabilityCertificate result)
    {
        ResponseCommon response = new ResponseCommon();
        response.ApplicantName = result.Name;
        response.Barcode = result.Barcode;
        response.DistrictName = result.DistrictName;
        response.PercentageOfDisability = result.PercentageOfDisability;
        response.DisabilityType = result.DisabilityType;
        response.AllottedDate = result.Date.ToString();
        return response;
    }
    public ResponseCommon MapResult(ResponseCasteCertificate result)
    {
        ResponseCommon response = new ResponseCommon();
        response.ApplicantName = result.ApplicantName;
        response.Barcode = result.Barcode;
        response.Caste = result.Caste;
        response.BenfiName = result.BenfiName;
        response.ClosedOn = (result.ClosedOn.Day + "/" + result.ClosedOn.Month + "/" +  result.ClosedOn.Year).ToString();
        return response;
    }
    public ResponseCommon MapResult(ResponseCasteValidity result)
    {
        ResponseCommon response = new ResponseCommon();
        response.ApplicantName = result.ApplicantName;
        response.Barcode = result.Barcode;
        response.DistrictName = result.DistrictName;
        response.CertificateDate = result.CertificateDate;
        response.TribeName = result.TribeName;
        response.ApplicationType = result.ApplicationType;
        response.CommitteeName = result.CommitteeName;
        response.CertificateIssuedById = result.CertificateIssuedById;

        return response;
    }
    public ResponseCommon MapResult(ResponseAgeNationalityDomicile result)
    {
        ResponseCommon response = new ResponseCommon();
        response.ApplicantName = result.ApplicantName;
        response.Barcode = result.Barcode;
        response.YearsOfResidency = result.YearsOfResidency;
        //response.PaymentDate = (result.PaymentDate.Day + "/" + result.PaymentDate.Month + "/" + result.PaymentDate.Year).ToString();
        response.BenfiName = result.BenfiName;
        response.DistrictName = result.Districtname;
        return response;
    }
}


