using Quotation.Infrastructure.Interfaces;
using Quotation.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private class InternalUserData
        {
            public InternalUserData(string name, string username, string hashedPassword, string[] roles)
            {
                Name = name;
                Username = username;
                HashedPassword = hashedPassword;
                Roles = roles;
            }

            public string Name
            {
                get;
                private set;
            }

            public string Username
            {
                get;
                private set;
            }

            public string HashedPassword
            {
                get;
                private set;
            }

            public string[] Roles
            {
                get;
                private set;
            }
        }

        private static readonly List<InternalUserData> _users = new List<InternalUserData>()
        {
            new InternalUserData("Super Administrator", "Admin", "XYe3Vs7WzqV+aglmNmwxZg0XhDN0560nL6c0imwiUbU=", new string[] { "Super-Administrator" }),
            new InternalUserData("Mark Zuckerberg", "Mark", "3t+xSzmHldJCtbneg/o3ISj4ISxYANB5iLJqHLKOgoY=", new string[] { "Administrator" }),
            new InternalUserData("Satya Nadella", "Satya", "1TwZVFwIbBPmx7tG+O7xxDrJTdWCvrA0B45zDPkmito=", new string[] { "User" }),
            new InternalUserData("Sundar Pichai", "Pichai", "+JmEE5Mbfcxj5n45JiyVIZX3hsp/3BU/M847cBuoXUY=", new string[] { "User" })
        };

        public User AuthenticateUser(string username, string clearTextPassword)
        {
            InternalUserData userData = _users.FirstOrDefault(u => u.Username.Equals(username) && u.HashedPassword.Equals(CalculateHash(clearTextPassword, u.Username)));
            if (userData == null)
            {
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");
            }

            return new User(userData.Name, userData.Username, userData.Roles);
        }

        private string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt.ToUpper());
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }
}
