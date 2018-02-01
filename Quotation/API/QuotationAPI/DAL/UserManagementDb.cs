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
            cmdParameters["Name"] = new SqlParameter("Name", userDetail.Name);
            cmdParameters["Password"] = new SqlParameter("Password", CryptographyUtility.EncryptPassword(userDetail.Password, userDetail.UserName));
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

        internal ErrorDetail UpdateGroup(IEnumerable<GroupFormRight> groupFormRights, string groupId, string groupName, string flag, string userName)
        {
            DataTable dataTable = new DataTable();
            //dataTable.Columns.Add("GroupID", typeof(int));
            dataTable.Columns.Add("FormID", typeof(int));
            dataTable.Columns.Add("Options", typeof(string));

            foreach (var groupFormRight in groupFormRights)
            {
                dataTable.Rows.Add(groupFormRight.FormID, groupFormRight.Options);
            }

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["GroupFormRightsDT"] = new SqlParameter("GroupFormRightsDT", dataTable);
            cmdParameters["GroupID"] = new SqlParameter("GroupID", groupId);
            cmdParameters["GroupName"] = new SqlParameter("GroupName", groupName);
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

        //internal ErrorDetail UpdateGroupFormRights(IEnumerable<GroupFormRight> groupFormRights)
        //{
        //    DataTable dataTable = new DataTable();
        //    //dataTable.Columns.Add("GroupID", typeof(int));
        //    dataTable.Columns.Add("FormID", typeof(int));
        //    dataTable.Columns.Add("Options", typeof(string));

        //    foreach (var groupFormRight in groupFormRights)
        //    {
        //        dataTable.Rows.Add(groupFormRight.GroupID, groupFormRight.FormID, groupFormRight.Options);
        //    }

        //    Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
        //    cmdParameters["GroupFormRightsDT"] = new SqlParameter("GroupFormRightsDT", dataTable);

        //    SqlParameter outPutParameter1 = new SqlParameter();
        //    outPutParameter1.ParameterName = "@ERRORNO";
        //    outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
        //    outPutParameter1.Size = 255;
        //    outPutParameter1.Direction = System.Data.ParameterDirection.Output;
        //    cmdParameters["@ERRORNO"] = outPutParameter1;

        //    SqlParameter outPutParameter2 = new SqlParameter();
        //    outPutParameter2.ParameterName = "@ERRORDESC";
        //    outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
        //    outPutParameter2.Size = 255;
        //    outPutParameter2.Direction = System.Data.ParameterDirection.Output;
        //    cmdParameters["@ERRORDESC"] = outPutParameter2;

        //    ErrorDetail errorDetail = new ErrorDetail();
        //    dbutility.ExecuteNonQuery("QuotationDb", "dbo.UpdateGroupFormRights", cmdParameters);

        //    errorDetail.Code = int.Parse(outPutParameter1.Value.ToString());
        //    errorDetail.Info = outPutParameter2.Value.ToString();

        //    return errorDetail;
        //}

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

        internal UserValidateDetail UserValidate(string userName, string password)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserName"] = new SqlParameter("UserName", userName);
            cmdParameters["Password"] = new SqlParameter("Password", CryptographyUtility.EncryptPassword(password, userName));

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "@Name";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter1.Size = 255;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@Name"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "@GroupID";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@GroupID"] = outPutParameter2;

            SqlParameter outPutParameter3 = new SqlParameter();
            outPutParameter3.ParameterName = "@ERRNo";
            outPutParameter3.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter3.Size = 255;
            outPutParameter3.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRNo"] = outPutParameter3;

            SqlParameter outPutParameter4 = new SqlParameter();
            outPutParameter4.ParameterName = "@ERRORDESC";
            outPutParameter4.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter4.Size = 255;
            outPutParameter4.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@ERRORDESC"] = outPutParameter4;

            SqlParameter outPutParameter5 = new SqlParameter();
            outPutParameter5.ParameterName = "@UserID";
            outPutParameter5.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter5.Size = 255;
            outPutParameter5.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["@UserID"] = outPutParameter5;

            UserValidateDetail userValidateDetail = new UserValidateDetail();
            dbutility.ExecuteNonQuery("QuotationDb", "dbo.UserValidate", cmdParameters);

            userValidateDetail.Name = outPutParameter1.Value == null ? null : outPutParameter1.Value.ToString();
            userValidateDetail.GroupId = outPutParameter2.Value == null ? -1 : (outPutParameter2.Value.ToString() == string.Empty ? -1 : int.Parse(outPutParameter2.Value.ToString()));
            userValidateDetail.Code = outPutParameter3.Value == null ? -1 : (outPutParameter3.Value.ToString() == string.Empty ? -1 : int.Parse(outPutParameter3.Value.ToString()));
            userValidateDetail.Info = outPutParameter4.Value == null ? "ERROR" : outPutParameter4.Value.ToString();
            userValidateDetail.UserId = outPutParameter5.Value == null ? -1 : (outPutParameter5.Value.ToString() == string.Empty ? -1 : int.Parse(outPutParameter5.Value.ToString()));
            return userValidateDetail;
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