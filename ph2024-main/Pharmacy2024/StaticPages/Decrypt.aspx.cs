using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.StaticPages
{
    public partial class Decrypt : System.Web.UI.Page
    {
        public string cnnString = @"Data Source=10.15.15.74;User ID=mkdbadmin;Password=Mkcl#Adm!n#; Initial Catalog=MHDTE_2017_PHARMACY;";
        protected void Page_Load(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            ds = GetData();

            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataSet dsDecrypt = new DataSet();
                    dsDecrypt = GetDecryptData(DecryptDataByEncryptionKey(dr["MobileNo"].ToString()), Convert.ToInt32(dr["PersonalID"].ToString()));


                }
            }
        }
        public static string DecryptDataByEncryptionKey(string Data)
        {
            string EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"].ToString();
            byte[] cipherBytes = Convert.FromBase64String(Data);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    Data = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return Data;
        }
        public DataSet GetDecryptData(string MobileNo, int PersonalID)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DecryptData";
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                SqlParameter param = new SqlParameter("@MobileNo", SqlDbType.VarChar, 5000);
                SqlParameter param1 = new SqlParameter("@PersonalID", SqlDbType.Int);
                param.Value = MobileNo;
                param1.Value = PersonalID;
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param1);
                adt.Fill(ds);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return ds;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = "select a.PersonalID,Mobileno from AppForm_ApplicationFormConfirmationDetails a JOIN AppForm_RegistrationDetails b ON a.PersonalID=b.PersonalID WHERE ConfirmedUnder='CAP' AND CancelFlag='N' AND a.PersonalID NOT IN (select PersonalID from Master_CAPCandidateMobileNos)";
                //cmd.CommandText = "SELECT DISTINCT APPLICATIONFORMNO AS  APPLICATIONFORMNO,41 AS USERTYPEID,CENTER_CODE FROM RES_SEATNO WHERE POSTID=1 AND APplicationFormno IN (900139009,900032983,900045260,900104169,900084263,900090160,900018873) ORDER BY CENTER_CODE,APPLICATIONFORMNO ";

                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return ds;
        }
    }
}