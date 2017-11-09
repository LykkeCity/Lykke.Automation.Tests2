using LykkeAutomation.Api.ApiModels.AccountExistModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LykkeAutomation.TestsCore;

namespace LykkeAutomation.Api.ApiResources.AccountExist
{
    public class AccountExist : LykkeAutomation.TestsCore.Api
    {

        private string resource = "/AccountExist";
/*
        public IRestResponse GetAccountExistResponseOld(string email)
        {
            var request = new RestRequest(resource, Method.GET);
            request.AddQueryParameter("email", email);
            var response = client.Execute(request);
            return response;
        }

        public AccountExistModel GetAccountExistResponseModelOld(string email) => 
            JsonConvert.DeserializeObject<AccountExistModel>(GetAccountExistResponseOld(email)?.Content);
            */
        public HttpResponseMessageWrapper GetAccountExistResponse(string email)
        { 
            return client.GetAsync(resource + $"?email={email}"); 
        }

        public AccountExistModel GetAccountExistResponseModel(string email) =>
            JsonConvert.DeserializeObject<AccountExistModel>(GetAccountExistResponse(email)?.ContentJson);
    }
}
