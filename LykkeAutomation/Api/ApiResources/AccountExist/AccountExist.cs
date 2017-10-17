using LykkeAutomation.Api.ApiModels.AccountExistModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Api.ApiResources.AccountExist
{
    public class AccountExist : Api
    {

        private string resource = "/AccountExist";

        public IRestResponse GetAccountExistResponse(string email)
        {
            var request = new RestRequest(resource, Method.GET);
            request.AddQueryParameter("email", email);
            var response = client.Execute(request);
            return response;
        }

        public AccountExistModel GetAccountExistResponseModel(string email) => 
            JsonConvert.DeserializeObject<AccountExistModel>(GetAccountExistResponse(email)?.Content);
    }
}
