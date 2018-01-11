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
            SqlDataReader dataReader = dbutility.ExecuteReader("QuotationDb", "dbo.GetAllOwnerDetails", queryParameters);

            while (dataReader.Read())
            {
                OwnerDetail ownerDetail = new OwnerDetail();

                ownerDetail.Name = dataReader["Name"].ToString();
                ownerDetail.NRIC = dataReader["NRIC"].ToString();
                ownerDetail.DateOfBirth = DateTime.Parse(dataReader["DateOfBirth"].ToString());
                ownerDetail.Gender = dataReader["Gender"].ToString();
                ownerDetail.MaritalStatus = bool.Parse(dataReader["MaritalStatus"].ToString());
                ownerDetail.Occupation = dataReader["Occupation"].ToString();
                ownerDetail.LicenseDate = DateTime.Parse(dataReader["LicenseDate"].ToString());
                ownerDetail.CreatedBy = dataReader["CreatedBy"].ToString();
                ownerDetail.CreatedDate = DateTime.Parse(dataReader["CreatedDate"].ToString());
                ownerDetail.LastUpdatedBy = dataReader["LastUpdatedBy"].ToString();
                ownerDetail.LastUpdatedDate = DateTime.Parse(dataReader["LastUpdatedDate"].ToString());
                ownerDetail.Email = dataReader["Email"].ToString();
                ownerDetail.Address = dataReader["Address"].ToString();
                ownerDetail.RenewalRemindDays = short.Parse(dataReader["RenewalRemindDays"].ToString());

                ownerDetails.Add(ownerDetail);
            }

            return ownerDetails;
        }

        internal IEnumerable<ExpiredInsurance> GetInsuranceQtnTobeExpired()
        {
            List<ExpiredInsurance> expiredInsurances = new List<ExpiredInsurance>();

            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            SqlDataReader dataReader = dbutility.ExecuteReader("QuotationDb", "dbo.GetInsuranceQtnTobeExpired", queryParameters);

            while (dataReader.Read())
            {
                ExpiredInsurance expiredInsurance = new ExpiredInsurance();

                expiredInsurance.Name = dataReader["Name"].ToString();
                expiredInsurance.NRIC = dataReader["NRIC"].ToString();
                expiredInsurance.LicenseDate = DateTime.Parse(dataReader["LicenseDate"].ToString());
                expiredInsurance.Email = dataReader["Email"].ToString();
                expiredInsurance.Address = dataReader["Address"].ToString();
                expiredInsurance.InsuranceQtnNo = dataReader["InsuranceQtnNo"].ToString();
                expiredInsurance.InsuranceExpiryDate = DateTime.Parse(dataReader["InsuranceExpiryDate"].ToString());
                expiredInsurance.RoadTaxExpiryDate = DateTime.Parse(dataReader["RoadTaxExpiryDate"].ToString());

                expiredInsurances.Add(expiredInsurance);
            }

            return expiredInsurances;
        }

        internal DataSet GetMotorQuoationDetails(string nric, string insuranceQtnNo)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["NRIC"] = new SqlParameter("NRIC", nric);
            cmdParameters["InsuranceQtnNo"] = new SqlParameter("InsuranceQtnNo", insuranceQtnNo);

            DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.GetMotorQuoationDetails", cmdParameters);
            return dataSet;
        }

        internal IEnumerable<UserDetail> GetUserDetails(string userId)
        {
            List<UserDetail> userDetails = new List<UserDetail>();

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserID"] = new SqlParameter("UserID", userId);

            SqlDataReader dataReader = dbutility.ExecuteReader("QuotationDb", "dbo.GetUserDetails", cmdParameters);

            while (dataReader.Read())
            {
                UserDetail userDetail = new UserDetail();

                userDetail.UserID = int.Parse(dataReader["UserID"].ToString());
                userDetail.UserName = dataReader["UserName"].ToString();
                userDetail.Password = dataReader["Password"].ToString();
                userDetail.CreatedBy = dataReader["CreatedBy"].ToString();
                userDetail.CreatedDate = DateTime.Parse(dataReader["CreatedDate"].ToString());
                userDetail.LastUpdatedBy = dataReader["LastUpdatedBy"].ToString();
                userDetail.LastUpdatedDate = DateTime.Parse(dataReader["LastUpdatedDate"].ToString());

                userDetails.Add(userDetail);
            }

            return userDetails;
        }

        internal ErrorDetail UpdateInsuranceDetails(MIQuotation quotationDetail)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["NRIC"] = new SqlParameter("NRIC", quotationDetail.NRIC);
            cmdParameters["InsuranceQtnNo"] = new SqlParameter("InsuranceQtnNo", quotationDetail.InsuranceQtnNo);
            cmdParameters["InsuranceExpiryDate"] = new SqlParameter("InsuranceExpiryDate", quotationDetail.InsuranceExpiryDate);
            cmdParameters["InsuranceRenewalDate"] = new SqlParameter("InsuranceRenewalDate", quotationDetail.InsuranceRenewalDate);
            cmdParameters["RoadTaxExpiryDate"] = new SqlParameter("RoadTaxExpiryDate", quotationDetail.RoadTaxExpiryDate);
            cmdParameters["RoadTaxRenewalDate"] = new SqlParameter("RoadTaxRenewalDate", quotationDetail.RoadTaxRenewalDate);
            cmdParameters["PreviousDealer"] = new SqlParameter("PreviousDealer", quotationDetail.PreviousDealer);
            cmdParameters["Agency"] = new SqlParameter("Agency", quotationDetail.Agency);
            cmdParameters["PrevYearPremium"] = new SqlParameter("PrevYearPremium", quotationDetail.PrevYearPremium);
            cmdParameters["FinanceBank"] = new SqlParameter("FinanceBank", quotationDetail.FinanceBank);
            cmdParameters["InsuranceRenewed"] = new SqlParameter("InsuranceRenewed", quotationDetail.InsuranceRenewed);
            cmdParameters["RoadTaxRenewed"] = new SqlParameter("RoadTaxRenewed", quotationDetail.RoadTaxRenewed);

            SqlDataReader dataReader = dbutility.ExecuteReader("QuotationDb", "dbo.UpdateInsuranceDetails", cmdParameters);

            ErrorDetail errorDetail = new ErrorDetail();
            bool result = dataReader.Read();
            if(result)
            {
                errorDetail.Code = int.Parse(dataReader["ERRORNO"].ToString());
                errorDetail.Info = dataReader["ERRORDESC"].ToString();
            }
            return errorDetail;
        }

        internal ErrorDetail UpdateOwnerDetails(OwnerDetail ownerDetail)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["Name"] = new SqlParameter("Name", ownerDetail.Name);
            cmdParameters["NRIC"] = new SqlParameter("NRIC", ownerDetail.NRIC);
            cmdParameters["DateOfBirth"] = new SqlParameter("DateOfBirth", ownerDetail.DateOfBirth);
            cmdParameters["Gender"] = new SqlParameter("Gender", ownerDetail.Gender);
            cmdParameters["MaritalStatus"] = new SqlParameter("MaritalStatus", ownerDetail.MaritalStatus);
            cmdParameters["Occupation"] = new SqlParameter("Occupation", ownerDetail.Occupation);
            cmdParameters["LicenseDate"] = new SqlParameter("LicenseDate", ownerDetail.LicenseDate);
            cmdParameters["CreatedBy"] = new SqlParameter("CreatedBy", ownerDetail.CreatedBy);
            cmdParameters["CreatedDate"] = new SqlParameter("CreatedDate", ownerDetail.CreatedDate);
            cmdParameters["LastUpdatedBy"] = new SqlParameter("LastUpdatedBy", ownerDetail.LastUpdatedBy);
            cmdParameters["LastUpdatedDate"] = new SqlParameter("LastUpdatedDate", ownerDetail.LastUpdatedDate);
            cmdParameters["Email"] = new SqlParameter("Email", ownerDetail.Email);
            cmdParameters["Address"] = new SqlParameter("Address", ownerDetail.Address);
            cmdParameters["RenewalRemindDays"] = new SqlParameter("RenewalRemindDays", ownerDetail.RenewalRemindDays);

            SqlDataReader dataReader = dbutility.ExecuteReader("QuotationDb", "dbo.UpdateOwnerDetails", cmdParameters);

            ErrorDetail errorDetail = new ErrorDetail();
            bool result = dataReader.Read();
            if (result)
            {
                errorDetail.Code = int.Parse(dataReader["ERRORNO"].ToString());
                errorDetail.Info = dataReader["ERRORDESC"].ToString();
            }
            return errorDetail;
        }

        internal ErrorDetail UpdateUser(UserDetail userDetail)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserID"] = new SqlParameter("UserID", userDetail.UserID);
            cmdParameters["UserName"] = new SqlParameter("UserName", userDetail.UserName);
            cmdParameters["Password"] = new SqlParameter("Password", userDetail.Password);
            cmdParameters["CreatedBy"] = new SqlParameter("CreatedBy", userDetail.CreatedBy);
            cmdParameters["CreatedDate"] = new SqlParameter("CreatedDate", userDetail.CreatedDate);
            cmdParameters["LastUpdatedBy"] = new SqlParameter("LastUpdatedBy", userDetail.LastUpdatedBy);
            cmdParameters["LastUpdatedDate"] = new SqlParameter("LastUpdatedDate", userDetail.LastUpdatedDate);

            SqlDataReader dataReader = dbutility.ExecuteReader("QuotationDb", "dbo.UpdateUser", cmdParameters);

            ErrorDetail errorDetail = new ErrorDetail();
            bool result = dataReader.Read();
            if (result)
            {
                errorDetail.Code = int.Parse(dataReader["ERRORNO"].ToString());
                errorDetail.Info = dataReader["ERRORDESC"].ToString();
            }
            return errorDetail;
        }

        internal ErrorDetail UpdateUserFormRights(UserFormRight userFormRight)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserID"] = new SqlParameter("UserID", userFormRight.UserID);
            cmdParameters["FormID"] = new SqlParameter("FormID", userFormRight.FormID);
            cmdParameters["Options"] = new SqlParameter("Options", userFormRight.Options);

            SqlDataReader dataReader = dbutility.ExecuteReader("QuotationDb", "dbo.UpdateUserFormRights", cmdParameters);

            ErrorDetail errorDetail = new ErrorDetail();
            bool result = dataReader.Read();
            if (result)
            {
                errorDetail.Code = int.Parse(dataReader["ERRORNO"].ToString());
                errorDetail.Info = dataReader["ERRORDESC"].ToString();
            }
            return errorDetail;
        }

        internal ErrorDetail UpdateVehicleDetails(VehicleDetail vehicleDetail)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["NRIC"] = new SqlParameter("NRIC", vehicleDetail.NRIC);
            cmdParameters["Make"] = new SqlParameter("Make", vehicleDetail.Make);
            cmdParameters["Model"] = new SqlParameter("Model", vehicleDetail.Model);
            cmdParameters["Capacity"] = new SqlParameter("Capacity", vehicleDetail.Capacity);
            cmdParameters["DateOfRegistered"] = new SqlParameter("DateOfRegistered", vehicleDetail.DateOfRegistered);
            cmdParameters["YearMade"] = new SqlParameter("YearMade", vehicleDetail.YearMade);
            cmdParameters["RegNo"] = new SqlParameter("RegNo", vehicleDetail.RegNo);
            cmdParameters["ParallelImport"] = new SqlParameter("ParallelImport", vehicleDetail.ParallelImport);
            cmdParameters["OffPeakVehicle"] = new SqlParameter("OffPeakVehicle", vehicleDetail.OffPeakVehicle);
            cmdParameters["NCD"] = new SqlParameter("NCD", vehicleDetail.NCD);
            cmdParameters["ExistingInsurer"] = new SqlParameter("ExistingInsurer", vehicleDetail.ExistingInsurer);
            cmdParameters["PreviousRegNo"] = new SqlParameter("PreviousRegNo", vehicleDetail.PreviousRegNo);
            cmdParameters["Claims"] = new SqlParameter("Claims", vehicleDetail.Claims);

            SqlDataReader dataReader = dbutility.ExecuteReader("QuotationDb", "dbo.UpdateVehicleDetails", cmdParameters);

            ErrorDetail errorDetail = new ErrorDetail();
            bool result = dataReader.Read();
            if (result)
            {
                errorDetail.Code = int.Parse(dataReader["ERRORNO"].ToString());
                errorDetail.Info = dataReader["ERRORDESC"].ToString();
            }
            return errorDetail;
        }

        internal ErrorDetail ValidateUser(string userName, string password)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["UserName"] = new SqlParameter("UserName", userName);
            cmdParameters["Password"] = new SqlParameter("Password", password);

            SqlDataReader dataReader = dbutility.ExecuteReader("QuotationDb", "dbo.sp_UserValidate", cmdParameters);

            ErrorDetail errorDetail = new ErrorDetail();
            bool result = dataReader.Read();
            if (result)
            {
                //errorDetail.Code = int.Parse(dataReader["ERRORNO"].ToString());
                errorDetail.Info = dataReader["ERRORDESC"].ToString();
            }
            return errorDetail;
        }

        internal DataSet LoadComboDetails(string flag, string condition)
        {
            List<string> details = new List<string>();

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["Flag"] = new SqlParameter("UserName", flag);
            cmdParameters["Condition"] = new SqlParameter("Password", condition);

            DataSet dataSet = dbutility.ExecuteQuery("QuotationDb", "dbo.LoadComboDetails", cmdParameters);
            return dataSet;
        }
    }
}