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
    public class UserManagementDb
    {
        private HttpClient client = new HttpClient();

        public UserManagementDb()
        {
            client.BaseAddress = new Uri("http://localhost:13036");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public DataSet GetGroupDetails(int groupId, out string errorMessage)
        {
            DataSet dataSet = null;
            errorMessage = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync("/api/UserManagement/GetGroupDetails?groupId=" + groupId).Result;
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

        public DataSet GetUserDetails(int userId, out string errorMessage)
        {
            DataSet dataSet = null;
            errorMessage = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync("/api/UserManagement/GetUserDetails?userId=" + userId).Result;
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

        public DataSet ValidateUser(string userName, string password, out string errorMessage)
        {
            DataSet dataSet = null;
            errorMessage = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync("/api/UserManagement/ValidateUser?userName=" + userName + "&password=" + password).Result;
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

        public ErrorDetail UpdateUser(UserDetail userDetail, string flag, string userName)
        {
            ErrorDetail errorDetail = new ErrorDetail();
            try
            {
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("/api/UserManagement/UpdateUser?flag=" + flag + "&userName=" + userName, userDetail).Result;
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

        public ErrorDetail UpdateGroup(GroupDetail groupDetail, string flag, IEnumerable<GroupFormRight> groupFormRights, string userName)
        {
            ErrorDetail errorDetail = new ErrorDetail();
            try
            {
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("/api/UserManagement/UpdateGroup?groupId=" + groupDetail.GroupID + "&groupName=" + groupDetail.GroupName + "&flag=" + flag + "&userName=" + userName, groupFormRights).Result;
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

        //public ErrorDetail UpdateGroupFormRights(IEnumerable<GroupFormRight> groupFormRights)
        //{
        //    ErrorDetail errorDetail = new ErrorDetail();
        //    try
        //    {
        //        HttpResponseMessage responseMessage = client.PostAsJsonAsync("/api/UserManagement/UpdateGroupFormRights", groupFormRights).Result;
        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            string data = responseMessage.Content.ReadAsStringAsync().Result;
        //            errorDetail = JsonConvert.DeserializeObject<ErrorDetail>(data);
        //        }
        //        else
        //        {
        //            errorDetail.Info = responseMessage.ReasonPhrase;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errorDetail.Info = ex.Message;
        //    }

        //    return errorDetail;
        //}
    }
}
