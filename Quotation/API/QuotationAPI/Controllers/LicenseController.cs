using QuotationAPI.DAL;
using QuotationAPI.DALUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuotationAPI.Controllers
{
    public class LicenseController : ApiController
    {
        LicenseDb licenseDb = new LicenseDb();

        [HttpGet]
        [Route("api/license/updatelicense")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> UpdateLicense(int userId, string encryptedLicenseDetail)
        {
            try
            {
                bool updateResult = await Task.Run(() => licenseDb.UpdateLicense(userId, encryptedLicenseDetail));
                if (updateResult == false)
                {
                    return NotFound();
                }

                return Ok(updateResult);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/license/getlicensedetails")]
        [ResponseType(typeof(Dictionary<string, string>))]
        public async Task<IHttpActionResult> GetLicenseDetails()
        {
            try
            {
                Dictionary<string, string> decryptDetails = await Task.Run(() => licenseDb.GetLicenseDetails());
                if (decryptDetails == null)
                {
                    return NotFound();
                }

                return Ok(decryptDetails);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //[HttpPost]
        //[Route("api/license/updategroup")]
        //[ResponseType(typeof(Dictionary<string, string>))]
        //public async Task<IHttpActionResult> DecryptLicense(DataTable licenseInfo)
        //{
        //    try
        //    {
        //        Dictionary<string, string> decryptDetails = await Task.Run(() => CryptographyUtility.DecryptLicense(licenseInfo));
        //        if (decryptDetails == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(decryptDetails);
        //    }
        //    catch (Exception)
        //    {
        //        return InternalServerError();
        //    }
        //}

        //[HttpPost]
        //[Route("api/license/decrypt")]
        //[ResponseType(typeof(string))]
        //public async Task<IHttpActionResult> Decrypt(string encryptedstring)
        //{
        //    try
        //    {
        //        string decryptedstring = await Task.Run(() => CryptographyUtility.Decrypt(encryptedstring));
        //        if (string.IsNullOrEmpty(decryptedstring))
        //        {
        //            return NotFound();
        //        }

        //        return Ok(decryptedstring);
        //    }
        //    catch (Exception)
        //    {
        //        return InternalServerError();
        //    }
        //}

        //[HttpPost]
        //[Route("api/license/encrypt")]
        //[ResponseType(typeof(string))]
        //public async Task<IHttpActionResult> Encrypt(string decryptedstring)
        //{
        //    try
        //    {
        //        string encryptedstring = await Task.Run(() => CryptographyUtility.Encrypt(decryptedstring));
        //        if (string.IsNullOrEmpty(encryptedstring))
        //        {
        //            return NotFound();
        //        }

        //        return Ok(encryptedstring);
        //    }
        //    catch (Exception)
        //    {
        //        return InternalServerError();
        //    }
        //}
    }
}
