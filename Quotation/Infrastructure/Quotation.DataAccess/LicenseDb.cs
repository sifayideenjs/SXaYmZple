using Newtonsoft.Json;
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
    public class LicenseDb
    {
        private HttpClient client = new HttpClient();

        public LicenseDb()
        {
            client.BaseAddress = new Uri("http://localhost:13036");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Dictionary<string, string> DecryptLicense([FromBody]DataTable licenseInfo, out string errorMessage)
        {
            Dictionary<string, string> decryptDetails = null;
            errorMessage = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("/api/license/decryptlicense", licenseInfo).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    decryptDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseData);
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

            return decryptDetails;
        }
    }
}
