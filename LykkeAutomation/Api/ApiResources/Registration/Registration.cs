using LykkeAutomation.ApiModels;
using LykkeAutomation.ApiModels.RegistrationModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Api.RegistrationResource
{
    public class Registration : Api
    {

        private const string resource = "/Registration";

        public HttpResponseMessageWrapper GetRegistrationResponse(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync(resource);
            return response;
        }

        public ResultRegistrationResponseModel PostRegistrationResponse(AccountRegistrationModel user)
        {
            var response = client.PostAsync(resource, new StringContent(JsonConvert.SerializeObject(user)));
            return JsonConvert.DeserializeObject<ResultRegistrationResponseModel>(response?.ContentJson);
        }
    }
}
