using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QuotationAPI.DALUtility
{
    public static class CryptographyUtility
    {
        public static string Encrypt(string clearTextPassword)
        {
            RiskLicense.RiskLicense license = new RiskLicense.RiskLicense();
            return license.EnCrypt(ref clearTextPassword);
        }

        //public static string Encrypt(string clearTextPassword, string salt)
        //{
        //    // Convert the salted password to a byte array
        //    byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt.ToUpper());
        //    // Use the hash algorithm to calculate the hash
        //    HashAlgorithm algorithm = new SHA256Managed();
        //    byte[] hash = algorithm.ComputeHash(saltedHashBytes);
        //    // Return the hash as a base64 encoded string to be compared to the stored password
        //    return Convert.ToBase64String(hash);
        //}

        public static string Decrypt(string hashedTextPassword)
        {
            RiskLicense.RiskLicense license = new RiskLicense.RiskLicense();
            return license.DeCrypt(ref hashedTextPassword);
        }
    }
}