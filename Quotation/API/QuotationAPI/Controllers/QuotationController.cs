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
        [Route("api/Quotation/GetMIQuoationDetails")]
        [ResponseType(typeof(DataSet))]
        public async Task<IHttpActionResult> GetMIQuoationDetails(string insuranceQtnNo)
        {
            try
            {
                DataSet dataSet = await Task.Run(() => quotationDb.GetMIQuoationDetails(insuranceQtnNo));
                if (dataSet == null)
                {
                    return NotFound();
                }

                return Ok(dataSet);
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
        [Route("api/Quotation/GetNRICDetails")]
        [ResponseType(typeof(DataSet))]
        public async Task<IHttpActionResult> GetNRICDetails(string nric)
        {
            try
            {
                DataSet dataSet = await Task.Run(() => quotationDb.GetNRICDetails(nric));
                if (dataSet == null)
                {
                    return NotFound();
                }

                return Ok(dataSet);
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
        [Route("api/Quotation/AddOwnerDetails")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> AddOwnerDetails([FromBody]OwnerDetail ownerDetail)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.UpdateOwnerDetails(ownerDetail, "ADD"));
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
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.UpdateOwnerDetails(ownerDetail, "EDIT"));
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
        [Route("api/Quotation/DeleteOwnerDetails")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> DeleteOwnerDetails([FromBody]OwnerDetail ownerDetail)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.UpdateOwnerDetails(ownerDetail, "DELETE"));
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
        [Route("api/Quotation/UpdateDriverDetails")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> UpdateDriverDetails([FromBody]List<DriverDetail> driverDetails)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.UpdateDriverDetails(driverDetails));
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
        [Route("api/Quotation/UpdateMIQuotation")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> UpdateMIQuotation([FromBody]MIQuotation quotationDetail)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => quotationDb.UpdateMIQuotation(quotationDetail));
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
        [Route("api/Quotation/AddVehicleDetails")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> AddVehicleDetails([FromBody]VehicleDetail vehicleDetail)
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
        public async Task<IHttpActionResult> ValidateUser(string userName, string password)
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
        public async Task<IHttpActionResult> LoadComboDetails(string flag)
        {
            try
            {
                DataSet details = await Task.Run(() => quotationDb.LoadComboDetails(flag));
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
