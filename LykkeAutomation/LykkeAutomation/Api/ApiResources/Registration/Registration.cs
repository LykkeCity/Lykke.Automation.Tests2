using LykkeAutomation.ApiModels;
using LykkeAutomation.ApiModels.RegistrationModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Api.RegistrationResource
{
    public class Registration : Api
    {

        private const string resource = "/Registration";

        public IRestResponse GetRegistrationResponse(string token)
        {
            request = new RestRequest(resource, Method.GET);
            request.AddHeader("Authorization", token);
            response = client.Execute(request);
            return response;
        }

        public ResultRegistrationResponseModel PostRegistrationResponse(AccountRegistrationModel user)
        {
            request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(user);
            response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResultRegistrationResponseModel>(response?.Content);
        }
    }
}
