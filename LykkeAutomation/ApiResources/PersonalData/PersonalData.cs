using LykkeAutomation.ApiModels;
using LykkeAutomation.ApiModels.PersonalDataModels;
using LykkeAutomation.TestsCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Api.PersonalDataResource
{
   public class PersonalData : LykkeAutomation.TestsCore.Api
    {
        private const string resource = "/PersonalData";

        public HttpResponseMessageWrapper GetPersonalDataResponse(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync(resource);
            return response;
        }

        public PersonalDataModel GetPersonalDataModel(string token) => JsonConvert.DeserializeObject<PersonalDataModel>(GetPersonalDataResponse(token)?.ContentJson);
    }
}
