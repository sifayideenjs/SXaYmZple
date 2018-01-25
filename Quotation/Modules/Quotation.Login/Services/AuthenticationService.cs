using Quotation.Core;
using Quotation.DataAccess;
using Quotation.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.LoginModule.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private UserManagementDb dbContext = null;
        public AuthenticationService(UserManagementDb dbContext)
        {
            this.dbContext = dbContext;
        }

        private class InternalUserData
        {
            public InternalUserData(string name, string username, string hashedPassword, string role)
            {
                Name = name;
                Username = username;
                HashedPassword = hashedPassword;
                Role = role;
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

            public string Role
            {
                get;
                private set;
            }
        }

        private static readonly List<InternalUserData> _users = new List<InternalUserData>()
        {
            new InternalUserData("Administrator", "Admin", "XYe3Vs7WzqV+aglmNmwxZg0XhDN0560nL6c0imwiUbU=", "Administrator"),
            new InternalUserData("Mark Zuckerberg", "Mark", "3t+xSzmHldJCtbneg/o3ISj4ISxYANB5iLJqHLKOgoY=", "User"),
            new InternalUserData("Satya Nadella", "Satya", "1TwZVFwIbBPmx7tG+O7xxDrJTdWCvrA0B45zDPkmito=", "User"),
            new InternalUserData("Sundar Pichai", "Pichai", "+JmEE5Mbfcxj5n45JiyVIZX3hsp/3BU/M847cBuoXUY=", "User")
        };

        public User AuthenticateUser(string username, string clearTextPassword)
        {
            if(dbContext != null)
            {
                InternalUserData userData = _users.FirstOrDefault(u => u.Username.Equals(username) && u.HashedPassword.Equals(CalculateHash(clearTextPassword, u.Username)));
                if (userData == null)
                {
                    throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");
                }

                return new User(userData.Username, userData.Username, userData.Role);

                //string errorMessage = string.Empty;
                //var errorDetail = dbContext.ValidateUser(username, clearTextPassword, out errorMessage);
                //if(errorDetail != null && errorDetail.Code == 0)
                //{
                //    var userdataset = dbContext.LoadComboDetails("USER", out errorMessage);
                //    var userGroupDetails = GetUserDetails(userdataset);
                //    var userGroupDetail = userGroupDetails.Single(ud => ud.UserName.ToUpper() == username.ToUpper());
                //    var groupdataset = dbContext.GetGroupDetails(userGroupDetail.GroupID, out errorMessage);
                //    var groupDetail = GetGroupDetail(groupdataset);

                //    return new User(userGroupDetail.UserName, userGroupDetail.UserName, groupDetail.GroupName);
                //}
                //else
                //{
                //    throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");
                //}                
            }
            else
            {
                throw new UnauthorizedAccessException("Access denied. Please contact your administrator.");
            }
        }

        private GroupDetail GetGroupDetail(DataSet dataset)
        {
            GroupDetail groupDetail = null;
            if (dataset != null && dataset.Tables.Count > 0)
            {
                DataTable dataTable = dataset.Tables[0];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    groupDetail = new GroupDetail
                    {
                        GroupID = dataTable.Rows[0].Field<string>("GroupID"),
                        GroupName = dataTable.Rows[0].Field<string>("GroupName")
                    };
                }
            }
            return groupDetail;
        }

        private List<UserGroupDetail> GetUserDetails(DataSet dataset)
        {
            List<UserGroupDetail> userDetails = new List<UserGroupDetail>();
            if (dataset != null && dataset.Tables.Count > 0)
            {
                DataTable dataTable = dataset.Tables[0];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    userDetails = dataTable.AsEnumerable().Select(row => new UserGroupDetail
                    {
                        UserID = row.Field<string>("UserID"),
                        UserName = row.Field<string>("UserName"),
                        GroupID = row.Field<string>("GroupID")
                    }).ToList();
                }
            }
            return userDetails;
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
