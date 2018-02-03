using QuotationAPI.DALUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuotationAPI.DAL
{
    public class LicenseDb
    {
        SqlDatabaseUtility dbutility = new SqlDatabaseUtility();

        internal bool UpdateLicense(int userId, string encryptedLicenseDetail)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserID"] = new SqlParameter("UserID", userId);
            cmdParameters["LiceseDetails"] = new SqlParameter("LiceseDetails", encryptedLicenseDetail);

            var result = dbutility.ExecuteNonQuery("QuotationDb", "dbo.UpdateLicense", cmdParameters);

            return result == 1 ? true : false;
        }

        internal Dictionary<string, string> GetLicenseDetails()
        {
            Dictionary<string, string> result = null;
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();

            DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.GetLicenseDetails", cmdParameters);
            if(dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                result = CryptographyUtility.DecryptLicense(dataSet.Tables[0]);
            }

            return result;
        }
    }
}