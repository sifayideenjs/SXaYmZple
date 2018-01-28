using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //string userName = "Admin";
            string clearTextPassword = "Admin123$";
            string hashedPassword = Encrypt(clearTextPassword);
            System.Console.ReadKey();
        }

        private static string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt.ToUpper());
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }

        public static string Encrypt(string clearTextPassword)
        {
            RiskLicense.RiskLicense license = new RiskLicense.RiskLicense();
            return license.EnCrypt(ref clearTextPassword);
        }
    }
}
