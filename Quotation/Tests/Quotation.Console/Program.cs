using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Quotation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = "Admin";
            string clearTextPassword = "Pichai";
            string hashedPassword = CalculateToHash(clearTextPassword, userName);
            string decryptedPassword = CalculateFromHash(hashedPassword, userName);
            System.Console.ReadKey();
        }

        private static string CalculateToHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt.ToUpper());
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }

        private static string CalculateFromHash(string hashedPassword, string salt)
        {
            byte[] hash = Convert.FromBase64String(hashedPassword);

            HashAlgorithm algorithm = new SHA256Managed();
            byte[] saltedHashBytes = algorithm.ComputeHash(hash);
            string saltedText = Encoding.UTF8.GetString(saltedHashBytes);
            return null;
        }

        public static string Encrypt(string clearTextPassword)
        {
            RiskLicense.RiskLicense license = new RiskLicense.RiskLicense();
            return license.EnCrypt(ref clearTextPassword);
        }

        public static string passPhrase = "YOUR KEY1";
        public static string saltValue = "YOUR KE2";
        public static string initVector = "YOUR KE3";

        public static string FunForEncrypt(string objText)
        {
            int keySize = 256;
            int passwordIterations = 03;
            string hashAlgorithm = "MD5";
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(objText);
            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                passPhrase,
                saltValueBytes,
                hashAlgorithm,
                passwordIterations
            );
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor
            (
                keyBytes,
                initVectorBytes
            );
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream
            (
                memoryStream,
                encryptor,
                CryptoStreamMode.Write
            );
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            cipherText = HttpUtility.UrlEncode(cipherText);
            return cipherText;
        }

        public static string FunForDecrypt(string cipherText)
        {
            string plainText = "";
            int keySize = 256;
            int passwordIterations = 03;
            string hashAlgorithm = "MD5";
            try
            {
                cipherText = HttpUtility.UrlDecode(cipherText);
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                PasswordDeriveBytes password = new PasswordDeriveBytes
                (
                    passPhrase,
                    saltValueBytes,
                    hashAlgorithm,
                    passwordIterations
                );
                byte[] keyBytes = password.GetBytes(keySize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor
                (
                    keyBytes,
                    initVectorBytes
                );
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream
                (
                    memoryStream,
                    decryptor,
                    CryptoStreamMode.Read
                );
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read
                (
                    plainTextBytes,
                    0,
                    plainTextBytes.Length
                );
                memoryStream.Close();
                cryptoStream.Close();
                plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            }
            catch (Exception ex)
            {
                plainText = "";
            }
            return plainText;
        }

    }
}
