using QuotationAPI.DAL;
using QuotationAPI.Models;
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
    public class QuotationController : ApiController
    {
        QuotationDb quotationDb = new QuotationDb();

        [HttpGet]
        [Route("api/Quotation/GetAllOwnerDetails")]
        [ResponseType(typeof(IEnumerable<OwnerDetail>))]
        public async Task<IHttpActionResult> GetAllOwnerDetails()
        {
            try
            {
                IEnumerable<OwnerDetail> ownerDetails = await Task.Run(() => quotationDb.GetAllOwnerDetails());
                if (ownerDetails == null)
                {
                    return NotFound();
                }

                return Ok(ownerDetails);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/Quotation/GetInsuranceQtnTobeExpired")]
        [ResponseType(typeof(IEnumerable<ExpiredInsurance>))]
        public async Task<IHttpActionResult> GetInsuranceQtnTobeExpired()
        {
            try
            {
                IEnumerable<ExpiredInsurance> ownerDetails = await Task.Run(() => quotationDb.GetInsuranceQtnTobeExpired());
                if (ownerDetails == null)
                {
                    return NotFound();
                }

                return Ok(ownerDetails);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/Quotation/GetMotorQuoationDetails")]
        [ResponseType(typeof(DataSet))]
        public async Task<IHttpActionResult> GetMotorQuoationDetails(string nric, string insuranceQtnNo)
        {
            try
            {
                DataSet quotationDetails = await Task.Run(() => quotationDb.GetMotorQuoationDetails(nric, insuranceQtnNo));
                if (quotationDetails == null)
                {
                    return NotFound();
                }

                return Ok(quotationDetails);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/Quotation/GetUserDetails")]
        [ResponseType(typeof(IEnumerable<UserDetail>))]
        public async Task<IHttpActionResult> GetUserDetails(string userId)
        {
            try
            {
                IEnumerable<UserDetail> userDetails = await Task.Run(() => quotationDb.GetUserDetails(userId));
                if (userDetails == null)
                {
                    return NotFound();
                }

                return Ok(userDetails);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Quotation/UpdateInsuranceDetails")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> UpdateInsuranceDetails([FromBody]MIQuotation quotationDetail)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.UpdateInsuranceDetails(quotationDetail));
                if (errorDetail == null)
                {
                    return NotFound();
                }

                return Ok(errorDetail);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Quotation/UpdateOwnerDetails")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> UpdateOwnerDetails([FromBody]OwnerDetail ownerDetail)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.UpdateOwnerDetails(ownerDetail));
                if (errorDetail == null)
                {
                    return NotFound();
                }

                return Ok(errorDetail);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Quotation/UpdateUser")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> UpdateUser([FromBody]UserDetail userDetail)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.UpdateUser(userDetail));
                if (errorDetail == null)
                {
                    return NotFound();
                }

                return Ok(errorDetail);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Quotation/UpdateUserFormRights")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> UpdateUserFormRights([FromBody]UserFormRight userFormRight)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.UpdateUserFormRights(userFormRight));
                if (errorDetail == null)
                {
                    return NotFound();
                }

                return Ok(errorDetail);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Quotation/UpdateVehicleDetails")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> UpdateVehicleDetails([FromBody]VehicleDetail vehicleDetail)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.UpdateVehicleDetails(vehicleDetail));
                if (errorDetail == null)
                {
                    return NotFound();
                }

                return Ok(errorDetail);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Quotation/ValidateUser")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> ValidateUser([FromBody]string userName, [FromBody]string password)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.ValidateUser(userName, password));
                if (errorDetail == null)
                {
                    return NotFound();
                }

                return Ok(errorDetail);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Quotation/LoadComboDetails")]
        [ResponseType(typeof(DataSet))]
        public async Task<IHttpActionResult> LoadComboDetails([FromBody]string userName, [FromBody]string password)
        {
            try
            {
                DataSet details = await Task.Run(() => quotationDb.LoadComboDetails(userName, password));
                if (details == null)
                {
                    return NotFound();
                }

                return Ok(details);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
