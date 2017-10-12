using LykkeAutomation.ApiModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Api.PersonalData
{
    class PersonalData : Api
    {
        private const string resource = "/PersonalData";

        public IRestResponse GetPersonalDataResponse(string token)
        {
            request = new RestRequest(resource, Method.GET);
            request.AddHeader("Authorization", token);
            response = client.Execute(request);
            return response;
        }

        public PersonalDataModel GetPersonalDataModel(string token)
        {
            request = new RestRequest(resource, Method.GET);
            request.AddHeader("Authorization", token);
            response = client.Execute(request);
            return JsonConvert.DeserializeObject<PersonalDataModel>(response?.Content);
        }
    }
}
