using Newtonsoft.Json;
using Quotation.DataAccess.Models;
using System;
using System.Collections.Generic;
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
    }
}
