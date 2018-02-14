using QuotationAPI.DALUtility;
using QuotationAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuotationAPI.DAL
{
    public class QuotationDb
    {
        SqlDatabaseUtility dbutility = new SqlDatabaseUtility();

        internal IEnumerable<OwnerDetail> GetAllOwnerDetails()
        {
            List<OwnerDetail> ownerDetails = new List<OwnerDetail>();

            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.GetAllOwnerDetails", queryParameters);
            if(dataSet != null)
            {
                var dataTable = dataSet.Tables[0];
                ownerDetails = dataTable.AsEnumerable().Select(row =>
                                new OwnerDetail
                                {
                                    Name = row.Field<string>("Name"),
                                    NRIC = row.Field<string>("NRIC"),
                                    DateOfBirth = row.Field<DateTime?>("DateOfBirth"),
                                    Gender = row.Field<string>("Gender"),
                                    MaritalStatus = row.Field<string>("MaritalStatus"),
                                    Occupation = row.Field<string>("Occupation"),
                                    LicenseDate = row.Field<DateTime?>("LicenseDate"),
                                    CreatedBy = row.Field<string>("CreatedBy"),
                                    CreatedDate = row.Field<DateTime?>("CreatedDate"),
                                    LastUpdatedBy = row.Field<string>("LastUpdatedBy"),
                                    LastUpdatedDate = row.Field<DateTime?>("LastUpdatedDate"),
                                    Email = row.Field<string>("Email"),
                                    Address = row.Field<string>("Address"),
                                    RenewalRemindDays = row.Field<short?>("RenewalRemindDays"),
                                }).ToList();
            }

            return ownerDetails;
        }

        internal DataSet GetMIQuoationDetails(string insuranceQtnNo)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["InsuranceQtnNo"] = new SqlParameter("InsuranceQtnNo", insuranceQtnNo);

            DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.GetMIQuoationDetails", cmdParameters);
            return dataSet;
        }

        internal IEnumerable<ExpiredInsurance> GetInsuranceQtnTobeExpired()
        {
            List<ExpiredInsurance> expiredInsurances = new List<ExpiredInsurance>();

            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.GetInsuranceQtnTobeExpired", queryParameters);

            if (dataSet != null)
            {
                var dataTable = dataSet.Tables[0];
                expiredInsurances = dataTable.AsEnumerable().Select(row =>
                                new ExpiredInsurance
                                {
                                    Name = row.Field<string>("Name"),
                                    NRIC = row.Field<string>("NRIC"),
                                    LicenseDate = row.Field<DateTime?>("LicenseDate"),
                                    Email = row.Field<string>("Email"),
                                    Address = row.Field<string>("Address"),
                                    InsuranceQtnNo = row.Field<string>("InsuranceQtnNo"),
                                    InsuranceExpiryDate = row.Field<DateTime?>("InsuranceExpiryDate"),
                                    RoadTaxExpiryDate = row.Field<DateTime?>("RoadTaxExpiryDate")
                                }).ToList();
            }

            return expiredInsurances;
        }

        internal DataSet GetNRICDetails(string nric)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["NRIC"] = new SqlParameter("NRIC", nric);

            DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.GetNRICDetails", cmdParameters);
            return dataSet;
        }

        //internal IEnumerable<UserDetail> GetUserDetails(string userId)
        //{
        //    List<UserDetail> userDetails = new List<UserDetail>();

        //    Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
        //    cmdParameters["UserID"] = new SqlParameter("UserID", userId);

        //    DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.GetUserDetails", cmdParameters);

        //    if (dataSet != null)
        //    {
        //        var dataTable = dataSet.Tables[0];
        //        userDetails = dataTable.AsEnumerable().Select(row =>
        //                        new UserDetail
        //                        {
        //                            UserID = (int)row.Field<long>("UserID"),
        //                            UserName = row.Field<string>("UserName"),
        //                            Password = row.Field<string>("Password"),
        //                            CreatedBy = row.Field<string>("CreatedBy"),
        //                            CreatedDate = row.Field<DateTime?>("CreatedDate"),
        //                            LastUpdatedBy = row.Field<string>("LastUpdatedBy"),
        //                            LastUpdatedDate = row.Field<DateTime?>("LastUpdatedDate")
        //                        }).ToList();
        //    }

        //    return userDetails;
        //}

        internal ErrorDetail UpdateOwnerDetails(OwnerDetail ownerDetail, string flag)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["@Flag"] = new SqlParameter("@Flag", flag);
            cmdParameters["@Name"] = new SqlParameter("@Name", ownerDetail.Name);
            cmdParameters["@NRIC"] = new SqlParameter("@NRIC", ownerDetail.NRIC);
            cmdParameters["@Contact"] = new SqlParameter("@Contact", ownerDetail.Contact);
            cmdParameters["@BizRegNo"] = new SqlParameter("@BizRegNo", ownerDetail.BizRegNo);
            cmdParameters["@DateOfBirth"] = new SqlParameter("@DateOfBirth", ownerDetail.DateOfBirth);
            cmdParameters["@Gender"] = new SqlParameter("@Gender", ownerDetail.Gender);
            cmdParameters["@MaritalStatus"] = new SqlParameter("@MaritalStatus", ownerDetail.MaritalStatus);
            cmdParameters["@Occupation"] = new SqlParameter("@Occupation", ownerDetail.Occupation);
            cmdParameters["@Industry"] = new SqlParameter("@Industry", ownerDetail.Industry);
            cmdParameters["@LicenseDate"] = new SqlParameter("@LicenseDate", ownerDetail.LicenseDate);
            cmdParameters["@Email"] = new SqlParameter("@Email", ownerDetail.Email);
            cmdParameters["@Address"] = new SqlParameter("@Address", ownerDetail.Address);
            cmdParameters["@RenewalRemindDays"] = new SqlParameter("RenewalRemindDays", ownerDetail.RenewalRemindDays);
            cmdParameters["@LogUser"] = new SqlParameter("@LogUser", ownerDetail.CreatedBy);

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
            dbutility.ExecuteNonQuery("QuotationDb", "dbo.UpdateOwnerDetails", cmdParameters);
            //if (dataSet != null && dataSet.Tables.Count > 1)
            //{
            //    var dataTable = dataSet.Tables[0];
            //    errorDetail.Code = dataTable.Rows[0].Field<int>("@ERRORNO");
            //    errorDetail.Info = dataTable.Rows[0].Field<string>("@ERRORDESC");
            //}

            errorDetail.Code = int.Parse(outPutParameter1.Value.ToString());
            errorDetail.Info = outPutParameter2.Value.ToString();

            return errorDetail;
        }

        internal ErrorDetail UpdateDriverDetails(string nric, IEnumerable<DriverDetail> driverDetails)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("InsuredName", typeof(string));
            dataTable.Columns.Add("InsuredNRIC", typeof(string));
            dataTable.Columns.Add("BizRegNo", typeof(string));
            dataTable.Columns.Add("DateOfBirth", typeof(DateTime));
            dataTable.Columns.Add("Gender", typeof(string));
            dataTable.Columns.Add("MaritalStatus", typeof(string));
            dataTable.Columns.Add("Occupation", typeof(string));
            dataTable.Columns.Add("Industry", typeof(string));
            dataTable.Columns.Add("LicenseDate", typeof(DateTime));

            foreach(var driverDetail in driverDetails)
            {
                dataTable.Rows.Add(driverDetail.InsuredName, driverDetail.InsuredNRIC, driverDetail.BizRegNo, driverDetail.DateofBirth, driverDetail.Gender, driverDetail.MaritalStatus, driverDetail.Occupation, driverDetail.Industry, driverDetail.LicenseDate);
            }

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["NRIC"] = new SqlParameter("NRIC", nric);
            cmdParameters["DriverDetails"] = new SqlParameter("DriverDetails", dataTable);

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "ERRORNO";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter1.Size = 50;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["ERRORNO"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "ERRORDESC";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["ERRORDESC"] = outPutParameter2;

            ErrorDetail errorDetail = new ErrorDetail();
            dbutility.ExecuteNonQuery("QuotationDb", "dbo.UpdateDriverDetails", cmdParameters);

            errorDetail.Code = int.Parse(outPutParameter1.Value.ToString());
            errorDetail.Info = outPutParameter2.Value.ToString();

            return errorDetail;
        }

        internal ErrorDetail UpdateMIQuotation(MIQuotation quotationDetail)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["NRIC"] = new SqlParameter("NRIC", quotationDetail.NRIC);
            cmdParameters["InsuranceQtnNo"] = new SqlParameter("InsuranceQtnNo", quotationDetail.InsuranceQtnNo);
            cmdParameters["InsuranceExpiryDate"] = new SqlParameter("InsuranceExpiryDate", quotationDetail.InsuranceExpiryDate);
            cmdParameters["InsuranceRenewalDate"] = new SqlParameter("InsuranceRenewalDate", quotationDetail.InsuranceExpiryDate);
            cmdParameters["RoadTaxExpiryDate"] = new SqlParameter("RoadTaxExpiryDate", quotationDetail.RoadTaxExpiryDate);
            cmdParameters["RoadTaxRenewalDate"] = new SqlParameter("RoadTaxRenewalDate", quotationDetail.RoadTaxExpiryDate);
            cmdParameters["PreviousDealer"] = new SqlParameter("PreviousDealer", quotationDetail.PreviousDealer ?? "NIL");
            cmdParameters["Agency"] = new SqlParameter("Agency", quotationDetail.Agency ?? "NIL");
            cmdParameters["PrevYearPremium"] = new SqlParameter("PrevYearPremium", quotationDetail.PrevYearPremium ?? "NIL");
            cmdParameters["FinanceBank"] = new SqlParameter("FinanceBank", quotationDetail.FinanceBank);
            cmdParameters["InsuranceRenewed"] = new SqlParameter("InsuranceRenewed", quotationDetail.InsuranceRenewed);
            cmdParameters["RoadTaxRenewed"] = new SqlParameter("RoadTaxRenewed", quotationDetail.RoadTaxRenewed);

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "ERRORNO";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter1.Size = 255;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["ERRORNO"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "ERRORDESC";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["ERRORDESC"] = outPutParameter2;

            ErrorDetail errorDetail = new ErrorDetail();
            dbutility.ExecuteNonQuery("QuotationDb", "dbo.UpdateMIQuotation", cmdParameters);

            errorDetail.Code = outPutParameter1.Value == null ? -1 :  int.Parse(outPutParameter1.Value.ToString());
            errorDetail.Info = outPutParameter2.Value == null ? "ERROR" : outPutParameter2.Value.ToString();

            return errorDetail;
        }

        internal ErrorDetail UpdateUser(UserDetail userDetail)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserID"] = new SqlParameter("UserID", userDetail.UserID);
            cmdParameters["UserName"] = new SqlParameter("UserName", userDetail.UserName);
            cmdParameters["Password"] = new SqlParameter("Password", userDetail.Password);
            cmdParameters["Flag"] = new SqlParameter("Flag", userDetail.CreatedBy);
            cmdParameters["LogUser"] = new SqlParameter("LogUser", userDetail.CreatedDate);

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "ERRORNO";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter1.Size = 255;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["ERRORNO"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "ERRORDESC";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["ERRORDESC"] = outPutParameter2;

            ErrorDetail errorDetail = new ErrorDetail();
            dbutility.ExecuteNonQuery("QuotationDb", "dbo.UpdateUser", cmdParameters);
            //if (dataSet != null && dataSet.Tables.Count > 1)
            //{
            //    var dataTable = dataSet.Tables[0];
            //    errorDetail.Code = dataTable.Rows[0].Field<int>("@ERRORNO");
            //    errorDetail.Info = dataTable.Rows[0].Field<string>("@ERRORDESC");
            //}

            errorDetail.Code = int.Parse(outPutParameter1.Value.ToString());
            errorDetail.Info = outPutParameter2.Value.ToString();

            return errorDetail;
        }

        internal ErrorDetail UpdateVehicleDetails(VehicleDetail vehicleDetail)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["NRIC"] = new SqlParameter("NRIC", vehicleDetail.NRIC);
            cmdParameters["Make"] = new SqlParameter("Make", vehicleDetail.Make);
            cmdParameters["Model"] = new SqlParameter("Model", vehicleDetail.Model);
            cmdParameters["Capacity"] = new SqlParameter("Capacity", vehicleDetail.Capacity);
            cmdParameters["Tonnage"] = new SqlParameter("Tonnage", vehicleDetail.Tonnage);
            cmdParameters["DateOfRegistered"] = new SqlParameter("DateOfRegistered", vehicleDetail.DateOfRegistered);
            cmdParameters["YearMade"] = new SqlParameter("YearMade", vehicleDetail.YearMade);
            cmdParameters["RegNo"] = new SqlParameter("RegNo", vehicleDetail.RegNo);
            cmdParameters["ParallelImport"] = new SqlParameter("ParallelImport", vehicleDetail.ParallelImport);
            cmdParameters["OffPeakVehicle"] = new SqlParameter("OffPeakVehicle", vehicleDetail.OffPeakVehicle);
            cmdParameters["NCD"] = new SqlParameter("NCD", vehicleDetail.NCD);
            cmdParameters["ExistingInsurer"] = new SqlParameter("ExistingInsurer", vehicleDetail.ExistingInsurer ?? "NIL");
            cmdParameters["PreviousRegNo"] = new SqlParameter("PreviousRegNo", vehicleDetail.PreviousRegNo ?? "NIL");
            cmdParameters["Claims"] = new SqlParameter("Claims", vehicleDetail.Claims ?? "NIL");

            SqlParameter outPutParameter1 = new SqlParameter();
            outPutParameter1.ParameterName = "ERRORNO";
            outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            outPutParameter1.Size = 255;
            outPutParameter1.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["ERRORNO"] = outPutParameter1;

            SqlParameter outPutParameter2 = new SqlParameter();
            outPutParameter2.ParameterName = "ERRORDESC";
            outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter2.Size = 255;
            outPutParameter2.Direction = System.Data.ParameterDirection.Output;
            cmdParameters["ERRORDESC"] = outPutParameter2;

            ErrorDetail errorDetail = new ErrorDetail();
            dbutility.ExecuteNonQuery("QuotationDb", "dbo.UpdateVehicleDetails", cmdParameters);
            //if (dataSet != null && dataSet.Tables.Count > 1)
            //{
            //    var dataTable = dataSet.Tables[0];
            //    errorDetail.Code = dataTable.Rows[0].Field<int>("@ERRORNO");
            //    errorDetail.Info = dataTable.Rows[0].Field<string>("@ERRORDESC");
            //}

            errorDetail.Code = int.Parse(outPutParameter1.Value.ToString());
            errorDetail.Info = outPutParameter2.Value.ToString();

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
    }
}