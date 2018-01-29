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
    public class UserManagementController : ApiController
    {
        UserManagementDb usermanagementDb = new UserManagementDb();

        [HttpGet]
        [Route("api/UserManagement/GetGroupDetails")]
        [ResponseType(typeof(DataSet))]
        public async Task<IHttpActionResult> GetGroupDetails(string groupId)
        {
            try
            {
                DataSet dataSet = await Task.Run(() => usermanagementDb.GetGroupDetails(groupId));
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
        [Route("api/UserManagement/GetUserDetails")]
        [ResponseType(typeof(DataSet))]
        public async Task<IHttpActionResult> GetUserDetails(string userId)
        {
            try
            {
                DataSet dataSet = await Task.Run(() => usermanagementDb.GetUserDetails(userId));
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
        [Route("api/UserManagement/LoadComboDetails")]
        [ResponseType(typeof(DataSet))]
        public async Task<IHttpActionResult> LoadComboDetails(string flag)
        {
            try
            {
                DataSet details = await Task.Run(() => usermanagementDb.LoadComboDetails(flag));
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

        [HttpGet]
        [Route("api/UserManagement/ValidateUser")]
        [ResponseType(typeof(UserValidateDetail))]
        public async Task<IHttpActionResult> UserValidate(string userName, string password)
        {
            try
            {
                UserValidateDetail userValidateDetail = await Task.Run(() => usermanagementDb.UserValidate(userName, password));
                if (userValidateDetail == null)
                {
                    return NotFound();
                }

                return Ok(userValidateDetail);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/UserManagement/UpdateGroup")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> UpdateGroup([FromBody]IEnumerable<GroupFormRight> groupFormRights, string groupId, string groupName, string flag, string userName)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => usermanagementDb.UpdateGroup(groupFormRights, groupId, groupName, flag, userName));
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

        //[HttpPost]
        //[Route("api/UserManagement/UpdateGroupFormRights")]
        //[ResponseType(typeof(ErrorDetail))]
        //public async Task<IHttpActionResult> UpdateGroupFormRights([FromBody]IEnumerable<GroupFormRight> groupFormRights)
        //{
        //    try
        //    {
        //        ErrorDetail errorDetail = await Task.Run(() => usermanagementDb.UpdateGroupFormRights(groupFormRights));
        //        if (errorDetail == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(errorDetail);
        //    }
        //    catch (Exception)
        //    {
        //        return InternalServerError();
        //    }
        //}

        [HttpPost]
        [Route("api/UserManagement/UpdateUser")]
        [ResponseType(typeof(ErrorDetail))]
        public async Task<IHttpActionResult> UpdateUser([FromBody]UserDetail userDetail, string flag, string userName)
        {
            try
            {
                ErrorDetail errorDetail = await Task.Run(() => usermanagementDb.UpdateUser(userDetail, flag, userName));
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
    }
}
