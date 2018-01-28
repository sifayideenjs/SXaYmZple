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
                        FormName = row.Field<string>("FormName")
                    }).ToList();
                }
            }
            return formDetails;
        }
    }
}
