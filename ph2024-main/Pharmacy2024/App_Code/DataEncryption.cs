using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;


public class DataEncryption
{
    public static string EncryptDataByHashSHA1(string Data)
    {
        byte[] hash = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(Data));
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < hash.Length; ++index)
            stringBuilder.Append(hash[index].ToString("X2"));
        return stringBuilder.ToString();
        //var sha1 = System.Security.Cryptography.SHA1.Create();
        //var inputBytes = Encoding.ASCII.GetBytes(Data);
        //var hash = sha1.ComputeHash(inputBytes);

        //var sb = new StringBuilder();
        //for (var i = 0; i < hash.Length; i++)
        //{
        //    sb.Append(hash[i].ToString("X2"));
        //}
        //return sb.ToString();
    }
    public static string EncryptDataByEncryptionKey(string Data)
    {
        string EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"].ToString();
        byte[] clearBytes = Encoding.Unicode.GetBytes(Data);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                Data = Convert.ToBase64String(ms.ToArray());
            }
        }
        return Data;
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

    public static string URLParamEncrypt(string inputText)
    {
        string encryptionkey = "SAUW193BX6dev28TD57";
        byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
        RijndaelManaged rijndaelCipher = new RijndaelManaged();
        byte[] plainText = Encoding.Unicode.GetBytes(inputText);
        PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
        using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
        {
            using (MemoryStream mstrm = new MemoryStream())
            {
                using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
                {
                    cryptstm.Write(plainText, 0, plainText.Length);
                    cryptstm.Close();
                    return Convert.ToBase64String(mstrm.ToArray());
                }
            }
        }
    }
    public static string URLParamDecrypt(string encryptText)
    {
        string encryptionkey = "SAUW193BX6dev28TD57";
        byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
        RijndaelManaged rijndaelCipher = new RijndaelManaged();
        byte[] encryptedData = Convert.FromBase64String(encryptText.Replace(" ", "+"));
        PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
        using (ICryptoTransform decryptrans = rijndaelCipher.CreateDecryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
        {
            using (MemoryStream mstrm = new MemoryStream(encryptedData))
            {
                using (CryptoStream cryptstm = new CryptoStream(mstrm, decryptrans, CryptoStreamMode.Read))
                {
                    byte[] plainText = new byte[encryptedData.Length];
                    int decryptedCount = cryptstm.Read(plainText, 0, plainText.Length);
                    return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                }
            }
        }
    }
    public static string MaskAadhaarNo(string AadhaarNo)
    {
        return "********" + AadhaarNo.Substring(8, 4);
    }
    public static string MaskMobileNo(string mobileNo)
    {
        return mobileNo.Substring(0, 2) + "XXXXX" + mobileNo.Substring(7, 3);
    }
}
