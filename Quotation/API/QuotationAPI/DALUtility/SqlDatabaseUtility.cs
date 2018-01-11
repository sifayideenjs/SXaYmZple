using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuotationAPI.DALUtility
{
    public class SqlDatabaseUtility
    {
        public SqlConnection GetConnection(string connectionName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public int ExecuteNonQuery(string connectionName, string storedProcName, Dictionary<string, SqlParameter> procParameters)
        {
          int result;
          using (SqlConnection connection = GetConnection(connectionName))
          {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcName;
                    foreach (var procParameter in procParameters)
                    {
                        cmd.Parameters.Add(procParameter.Value);
                    }
                    result = cmd.ExecuteNonQuery();
                }
          }
          return result;
        }

        public SqlDataReader ExecuteReader(string connectionName, string storedProcName, Dictionary<string, SqlParameter> procParameters)
        {
            SqlDataReader dataReader;
            using (SqlConnection connection = GetConnection(connectionName))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcName;
                    foreach (var procParameter in procParameters)
                    {
                        cmd.Parameters.Add(procParameter.Value);
                    }
                    dataReader = cmd.ExecuteReader();
                }
            }
            return dataReader;
        }

        public DataSet ExecuteQuery(string connectionName, string storedProcName, Dictionary<string, SqlParameter> procParameters)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = GetConnection(connectionName))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcName;
                    foreach (var procParameter in procParameters)
                    {
                        cmd.Parameters.Add(procParameter.Value);
                    }
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        dataAdapter.Fill(dataSet);
                    }
                }
            }
            return dataSet;
        }
    }
}