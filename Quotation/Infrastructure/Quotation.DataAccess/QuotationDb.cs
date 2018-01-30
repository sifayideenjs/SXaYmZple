using Newtonsoft.Json;
using Quotation.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.DataAccess
{
    public class QuotationDb
    {
        private HttpClient client = new HttpClient();

        public QuotationDb()
        {
            client.BaseAddress = new Uri("http://localhost:13036");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<OwnerDetail> GetAllOwnerDetails(out string errorMessage)
        {
            IEnumerable<OwnerDetail> ownerDetails = null;
            errorMessage = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync("/api/Quotation/GetAllOwnerDetails").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    ownerDetails = JsonConvert.DeserializeObject<IEnumerable<OwnerDetail>>(responseData);
                }
                else
                {
                    errorMessage = "No Record Found!";
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }

            return ownerDetails;
        }

        public DataSet GetMIQuoationDetails(string insuranceQtnNo, out string errorMessage)
        {
            DataSet dataSet = null;
            errorMessage = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync("/api/Quotation/GetMIQuoationDetails?insuranceQtnNo=" + insuranceQtnNo).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    dataSet = JsonConvert.DeserializeObject<DataSet>(responseData);
                }
                else
                {
                    errorMessage = "No Record Found!";
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            if (dataSet != null && dataSet.Tables.Count == 4 && dataSet.Tables[0].Rows.Count > 0)
            {
                dataSet.Tables[0].TableName = "OwnerDetails";
                dataSet.Tables[1].TableName = "DriverDetails";
                dataSet.Tables[2].TableName = "VehicleDetails";
                dataSet.Tables[3].TableName = "InsuranceDetails";
            }

            return dataSet;
        }

        public IEnumerable<ExpiredInsurance> GetInsuranceQtnTobeExpired(out string errorMessage)
        {
            IEnumerable<ExpiredInsurance> expiredInsurances = null;
            errorMessage = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync("/api/Quotation/GetInsuranceQtnTobeExpired").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    expiredInsurances = JsonConvert.DeserializeObject<IEnumerable<ExpiredInsurance>>(responseData);
                }
                else
                {
                    errorMessage = "No Record Found!";
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return expiredInsurances;
        }

        public DataSet GetNRICDetails(string nric, out string errorMessage)
        {
            DataSet dataSet = null;
            errorMessage = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync("/api/Quotation/GetNRICDetails?nric=" + nric).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    dataSet = JsonConvert.DeserializeObject<DataSet>(responseData);
                }
                else
                {
                    errorMessage = "No Record Found!";
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            if (dataSet != null && dataSet.Tables.Count == 3 && dataSet.Tables[0].Rows.Count > 0)
            {
                dataSet.Tables[0].TableName = "OwnerDetails";
                dataSet.Tables[1].TableName = "DriverDetails";
                dataSet.Tables[2].TableName = "VehicleDetails";
                dataSet.Tables[3].TableName = "InsuranceDetails";
            }

            return dataSet;
        }


        public ErrorDetail AddOwnerDetails(OwnerDetail ownerDetail)
        {
            ErrorDetail errorDetail = new ErrorDetail();
            try
            {
                //using (var formData = new MultipartFormDataContent())
                //{
                //    formData.Add(new StringContent(JsonConvert.SerializeObject(ownerDetail), Encoding.UTF8, "application/json"), "ownerDetail");
                //    //formData.Add(new StringContent(flag), "flag");

                //    HttpResponseMessage responseMessage = client.PostAsync("/api/Quotation/UpdateOwnerDetails", formData).Result;
                //    if (responseMessage.IsSuccessStatusCode)
                //    {
                //        string data = responseMessage.Content.ReadAsStringAsync().Result;
                //        errorDetail = JsonConvert.DeserializeObject<ErrorDetail>(data);
                //    }
                //    else
                //    {
                //        errorDetail.Info = responseMessage.ReasonPhrase;
                //    }
                //}

                ownerDetail.CreatedDate = DateTime.Now;
                ownerDetail.LastUpdatedDate = DateTime.Now;

                HttpResponseMessage responseMessage = client.PostAsJsonAsync("/api/Quotation/AddOwnerDetails", ownerDetail).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    errorDetail = JsonConvert.DeserializeObject<ErrorDetail>(data);
                }
                else
                {
                    errorDetail.Info = responseMessage.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                errorDetail.Info = ex.Message;
            }

            return errorDetail;
        }

        public ErrorDetail EditOwnerDetails(OwnerDetail ownerDetail)
        {
            ErrorDetail errorDetail = new ErrorDetail();
            try
            {
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("/api/Quotation/EditOwnerDetails", ownerDetail).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    errorDetail = JsonConvert.DeserializeObject<ErrorDetail>(data);
                }
                else
                {
                    errorDetail.Info = responseMessage.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                errorDetail.Info = ex.Message;
            }

            return errorDetail;
        }

        public ErrorDetail DeleteOwnerDetails(OwnerDetail ownerDetail)
        {
            ErrorDetail errorDetail = new ErrorDetail();
            try
            {
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("/api/Quotation/DeleteOwnerDetails", ownerDetail).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    errorDetail = JsonConvert.DeserializeObject<ErrorDetail>(data);
                }
                else
                {
                    errorDetail.Info = responseMessage.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                errorDetail.Info = ex.Message;
            }

            return errorDetail;
        }


        public ErrorDetail AddDriverDetails(string nric, IEnumerable<DriverDetail> driverDetails)
        {
            ErrorDetail errorDetail = new ErrorDetail();
            try
            {
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("/api/Quotation/UpdateDriverDetails/" + nric , driverDetails).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    errorDetail = JsonConvert.DeserializeObject<ErrorDetail>(data);
                }
                else
                {
                    errorDetail.Info = responseMessage.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                errorDetail.Info = ex.Message;
            }

            return errorDetail;
        }

        public ErrorDetail AddVehicleDetails(VehicleDetail vehicleDetail)
        {
            ErrorDetail errorDetail = new ErrorDetail();
            try
            {
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("/api/Quotation/AddVehicleDetails", vehicleDetail).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    errorDetail = JsonConvert.DeserializeObject<ErrorDetail>(data);
                }
                else
                {
                    errorDetail.Info = responseMessage.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                errorDetail.Info = ex.Message;
            }

            return errorDetail;
        }

        public ErrorDetail AddInsuranceDetails(MIQuotation quotationDetail)
        {
            ErrorDetail errorDetail = new ErrorDetail();
            try
            {
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("/api/Quotation/AddInsuranceDetails", quotationDetail).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    errorDetail = JsonConvert.DeserializeObject<ErrorDetail>(data);
                }
                else
                {
                    errorDetail.Info = responseMessage.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                errorDetail.Info = ex.Message;
            }

            return errorDetail;
        }


        public ErrorDetail EditVehicleDetails(VehicleDetail vehicleDetail)
        {
            return new ErrorDetail();
        }

        public ErrorDetail EditInsuranceDetails(MIQuotation insuranceDetail)
        {
            return new ErrorDetail();
        }

        public IEnumerable<UserDetail> GetUserDetails(string userId, out string errorMessage)
        {
            IEnumerable<UserDetail> userDetails = null;
            errorMessage = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync("/api/Quotation/GetUserDetails/" + userId).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    userDetails = JsonConvert.DeserializeObject<IEnumerable<UserDetail>>(responseData);
                }
                else
                {
                    errorMessage = "No Record Found!";
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return userDetails;
        }

        public DataSet LoadComboDetails(string flag, out string errorMessage)
        {
            DataSet dataSet = null;
            errorMessage = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync("/api/UserManagement/LoadComboDetails?flag=" + flag).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    dataSet = JsonConvert.DeserializeObject<DataSet>(responseData);
                }
                else
                {
                    errorMessage = "No Record Found!";
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return dataSet;
        }
    }
}
