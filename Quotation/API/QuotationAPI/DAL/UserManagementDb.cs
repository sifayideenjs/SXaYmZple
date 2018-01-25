using QuotationAPI.DALUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuotationAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace QuotationAPI.DAL
{
    public class UserManagementDb
    {
        SqlDatabaseUtility dbutility = new SqlDatabaseUtility();

        internal ErrorDetail UpdateUser(UserDetail userDetail, string flag, string userName)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserID"] = new SqlParameter("UserID", userDetail.UserID);
            cmdParameters["UserName"] = new SqlParameter("UserName", userDetail.UserName);
            cmdParameters["Password"] = new SqlParameter("Password", CryptographyUtility.CalculateHash(userDetail.Password, userDetail.UserName));
            cmdParameters["GroupID"] = new SqlParameter("GroupID", userDetail.GroupID);
            cmdParameters["Flag"] = new SqlParameter("Flag", flag);
            cmdParameters["LogUser"] = new SqlParameter("LogUser", userName);

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "@ERRORNO";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter1.Size = 255;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORNO"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "@ERRORDESC";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORDESC"] = outPutParameter2;

            ErrorDetail errorDetail = new ErrorDetail();
            dbutility.ExecuteNonQuery("QuotationDb", "dbo.UpdateUser", cmdParameters);

            errorDetail.Code = int.Parse(outPutParameter1.Value.ToString());
            errorDetail.Info = outPutParameter2.Value.ToString();

            return errorDetail;
        }

        internal ErrorDetail UpdateGroup(GroupDetail groupDetail, string flag, string userName)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["GroupID"] = new SqlParameter("GroupID", groupDetail.GroupID);
            cmdParameters["GroupName"] = new SqlParameter("GroupName", groupDetail.GroupName);
            cmdParameters["Flag"] = new SqlParameter("Flag", flag);
            cmdParameters["LogUser"] = new SqlParameter("LogUser", userName);

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "@ERRORNO";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter1.Size = 255;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORNO"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "@ERRORDESC";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORDESC"] = outPutParameter2;

            ErrorDetail errorDetail = new ErrorDetail();
            dbutility.ExecuteNonQuery("QuotationDb", "dbo.UpdateGroup", cmdParameters);

            errorDetail.Code = int.Parse(outPutParameter1.Value.ToString());
            errorDetail.Info = outPutParameter2.Value.ToString();

            return errorDetail;
        }

        internal ErrorDetail UpdateGroupFormRights(IEnumerable<GroupFormRight> groupFormRights)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("GroupID", typeof(int));
            dataTable.Columns.Add("FormID", typeof(int));
            dataTable.Columns.Add("Options", typeof(string));

            foreach (var groupFormRight in groupFormRights)
            {
                dataTable.Rows.Add(groupFormRight.GroupID, groupFormRight.FormID, groupFormRight.Options);
            }

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserFormRightsDT"] = new SqlParameter("UserFormRightsDT", dataTable);

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "@ERRORNO";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter1.Size = 255;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORNO"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "@ERRORDESC";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORDESC"] = outPutParameter2;

            ErrorDetail errorDetail = new ErrorDetail();
            dbutility.ExecuteNonQuery("QuotationDb", "dbo.UpdateGroupFormRights", cmdParameters);

            errorDetail.Code = int.Parse(outPutParameter1.Value.ToString());
            errorDetail.Info = outPutParameter2.Value.ToString();

            return errorDetail;
        }

        internal DataSet GetGroupDetails(string groupId)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["GroupID"] = new SqlParameter("GroupID", groupId);

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "@ERRORNO";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter1.Size = 255;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORNO"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "@ERRORDESC";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORDESC"] = outPutParameter2;

            DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.GetGroupDetails", cmdParameters);
            return dataSet;
        }

        internal ErrorDetail UserValidate(string userName, string password)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserName"] = new SqlParameter("UserName", userName);
            cmdParameters["Password"] = new SqlParameter("Password", CryptographyUtility.CalculateHash(password, userName));

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "@ERRORNO";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter1.Size = 255;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORNO"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "@ERRORDESC";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORDESC"] = outPutParameter2;

            ErrorDetail errorDetail = new ErrorDetail();
            dbutility.ExecuteNonQuery("QuotationDb", "dbo.sp_UserValidate", cmdParameters);

            int code = -1;
            int.TryParse(outPutParameter1.Value == null ? "-1" : outPutParameter1.Value.ToString(), out code);
            errorDetail.Code = code;

            errorDetail.Info = outPutParameter2.Value == null ? "ERROR" : outPutParameter2.Value.ToString();

            return errorDetail;
        }

        internal DataSet LoadComboDetails(string flag)
        {
            List<string> details = new List<string>();

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["Flag"] = new SqlParameter("Flag", flag);

            DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.LoadComboDetails", cmdParameters);
            return dataSet;
        }

        internal DataSet GetUserDetails(string userId)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserID"] = new SqlParameter("UserID", userId);

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "@ERRORNO";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter1.Size = 255;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORNO"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "@ERRORDESC";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORDESC"] = outPutParameter2;

            DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.GetUserDetails", cmdParameters);
            return dataSet;
        }
    }
}