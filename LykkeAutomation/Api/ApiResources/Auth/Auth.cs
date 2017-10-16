using LykkeAutomation.Api.ApiModels.AuthModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LykkeAutomation.Api.ApiModels.AuthModels.AuthModels;

namespace LykkeAutomation.Api.AuthResource
{
    public class Auth : Api
    {
        private const string resource = "/Auth";
        private const string resourceLogOut = "/Auth/LogOut";

        public IRestResponse PostAuthResponse(AuthenticateModel auth)
        {
            request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(auth);
            response = client.Execute(request);
            return response;
        }

        public AuthModelResponse PostAuthResponseModel(AuthenticateModel auth)
        {
            return JsonConvert.DeserializeObject<AuthModelResponse>(PostAuthResponse(auth)?.Content);
        }

        public IRestResponse PostAuthLogOutResponse(AuthenticateModel auth)
        {
            request = new RestRequest(resource, Method.GET);
            request.AddBody(auth);
            response = client.Execute(request);
            return response;
        }
    }
}
