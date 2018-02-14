using Quotation.DataAccess;
using Quotation.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.MotorInsuranceModule.Utilities
{
    public static class DbUtility
    {
        public static List<string> GetFormList(UserManagementDb dbContext)
        {
            string errorMessage;
            var formdataset = dbContext.LoadComboDetails("FORM", out errorMessage);
            var formDetails = GetFormDetails(formdataset);
            return formDetails.Select(f => f.FormName).ToList();
        }

        private static List<FormDetail> GetFormDetails(DataSet dataset)
        {
            List<FormDetail> formDetails = new List<FormDetail>();
            if (dataset != null && dataset.Tables.Count > 0)
            {
                DataTable dataTable = dataset.Tables[0];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    formDetails = dataTable.AsEnumerable().Select(row => new FormDetail
                    {
                        FormID = (int)row.Field<long>("FormID"),
                        FormName = row.Field<string>("FormName"),
                        CustomeText = row.Field<string>("CustomeText")
                    }).ToList();
                }
            }
            return formDetails;
        }

        public static string GetNewQuotationNumber(QuotationDb dbContext)
        {
            string quotationNo = string.Empty;
            string errorMessage;
            var qtndataset = dbContext.LoadComboDetails("QTN", out errorMessage);
            if(qtndataset != null && qtndataset.Tables.Count > 0)
            {
                var qtnDetails = GetInsuranceDetail(qtndataset.Tables[0]);
                var quotationNos = qtnDetails.Select(q => int.Parse(q.InsuranceQtnNo));
                int max = 10000;
                if (quotationNos != null && quotationNos.Count() == 0) max = 10000;
                else max = quotationNos.Max();
                quotationNo = (max + 1).ToString();
            }
            else
            {
                quotationNo = "1001";
            }
            return quotationNo;
        }

        private static List<MIQuotation> GetInsuranceDetail(DataTable dataTable)
        {
            List<MIQuotation> insuranceDetails = new List<MIQuotation>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                insuranceDetails = dataTable.AsEnumerable().Select(row => new MIQuotation
                {
                    NRIC = row.Field<string>("NRIC"),
                    InsuranceQtnNo = row.Field<string>("InsuranceQtnNo")
                }).ToList();
            }
            return insuranceDetails;
        }
    }
}
