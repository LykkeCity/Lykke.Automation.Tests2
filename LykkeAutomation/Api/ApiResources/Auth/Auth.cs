using LykkeAutomation.Api.ApiModels.AuthModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static LykkeAutomation.Api.ApiModels.AuthModels.AuthModels;

namespace LykkeAutomation.Api.AuthResource
{
    public class Auth : Api
    {
        private const string resource = "/Auth";
        private const string resourceLogOut = "/Auth/LogOut";

        public HttpResponseMessageWrapper PostAuthResponse(AuthenticateModel auth)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(auth));
            var response = client.PostAsync(resource, content);
            return response;
        }

        public AuthModelResponse PostAuthResponseModel(AuthenticateModel auth)
        {
            return JsonConvert.DeserializeObject<AuthModelResponse>(PostAuthResponse(auth)?.ContentJson);
        }

        public HttpResponseMessageWrapper PostAuthLogOutResponse(AuthenticateModel auth)
        {
            var response = client.PostAsync(resourceLogOut, new StringContent(JsonConvert.SerializeObject(auth)));
            return response;
        }
    }
}
