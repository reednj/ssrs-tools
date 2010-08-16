using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Security.Cryptography;

namespace ReportingTools.Common
{
    public class LicenseKey
    {
        const int DefaultZeroCount = 3;
        const string KeySalt = "reporting-tools-e987982fbbd3-";

        public static bool ValidateKey()
        {
            return ValidateKey(SharedSettings.LicenseKey);
        }

        public static bool ValidateKey(string KeyString)
        {
            return ValidateKey(KeyString, DefaultZeroCount);
        }

        public static bool ValidateKey(string KeyString, int ZeroCount)
        {

            string KeyHash = SHA1(KeySalt + KeyString.ToUpper().Trim());
            return (KeyHash.Substring(0, ZeroCount) == new String('0', ZeroCount));
        }

        static string SHA1(string text)
        {
            return CalculateSHA1(text, Encoding.ASCII);
        }

        static string CalculateSHA1(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            System.Security.Cryptography.SHA1CryptoServiceProvider cryptoTransformSHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }
    }

    public class LicenseTest
    {
        const string DefaultValue = "mr.tickle";
        const string EncryptKey = "reporting-tools-e987982fbbd3-";
        const int TrialLengthDays = 31;

        public static int DaysLeft()
        {
            // we are running for the first time, so it has definately not expired
            // encode the current date, return false;
            if (IsNew())
            {
                SetTrialDate();
                return TrialLengthDays;
            }

            DateTime? StartDate = GetTrialDate();

            // invalid date stored in the config file.
            if (StartDate == null)
            {
                return 0;
            }

            TimeSpan TimeLeft = (TimeSpan)(StartDate + TimeSpan.FromDays(TrialLengthDays) - DateTime.Now);
            return TimeLeft.Days;

        }

        public static void SetTrialDate()
        {
            string EncodedString = SimpleEncrypt.Encrypt(DateTime.Now.ToString("yyyy-MM-dd"), EncryptKey);
            SharedSettings.LicenseValue = EncodedString;
        }

        public static DateTime? GetTrialDate()
        {
            if (IsNew())
            {
                return null;
            }

            DateTime DateValue;
            string DateString = SimpleEncrypt.Decrypt(SharedSettings.LicenseValue, EncryptKey);
            return DateTime.TryParse(DateString, out DateValue) ? (DateTime?)DateValue : null;

        }

        // has the software been used before? the license value should equal the stored value
        // (which will be set by the installer usually)
        public static bool IsNew()
        {
            return (SharedSettings.LicenseValue == DefaultValue);
        }
    }

    // from: http://www.codeproject.com/KB/security/DotNetCrypto.aspx
    public class SimpleEncrypt
    {
        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {

            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;

            try
            {
                CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(clearData, 0, clearData.Length);
                cs.Close();
            }
            catch
            {
                return new byte[] { };
            }

            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        public static string Encrypt(string clearText, string Password)
        {

            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        public static byte[] Encrypt(byte[] clearData, string Password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {

            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            try
            {
                CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cipherData, 0, cipherData.Length);
                cs.Close();
            }
            catch
            {
                return new byte[] { };
            }

            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }



        public static string Decrypt(string cipherText, string Password)
        {
            if (cipherText == "")
            {
                return "";
            }

            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }



        public static byte[] Decrypt(byte[] cipherData, string Password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
        }
    }
}
