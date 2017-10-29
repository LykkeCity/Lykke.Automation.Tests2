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
using Lykke.Client.AutorestClient.Models;
using System.Net;
using TestsCore.ServiceSettings.SettingsModels;

namespace LykkeAutomationPrivate.Api.PersonalDataResource
{
    class PersonalData : LykkeAutomation.TestsCore.Api
    {
        private const string resource = "/PersonalData";
        private static PersonalDataSettings _settings;
        private static PersonalDataSettings Settings()
        {
            if(_settings == null)
            _settings = new LykkeApi().settings.PersonalDataSettings().PersonalDataSettings;
            return _settings;
        }

        private static string apiKey { get { return Settings().ApiKey; } set { } }
        private static string ServiceUri { get { return Settings().ServiceUri; } set { } }
        private static string ExternalServiceUri { get { return Settings().ServiceExternalUri; } set { } }

        public PersonalData() : base()
        {
            client.SetBaseURI(ExternalServiceUri + "/api");
        }

        public HttpResponseMessageWrapper GetPersonalDataResponseByEmail(string email)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var response = client.GetAsync(resource + $"?email={WebUtility.UrlEncode(email)}");
            return response;
        }

        public PersonalDataModel GetPersonalDataModel(string email) => JsonConvert.DeserializeObject<PersonalDataModel>(GetPersonalDataResponseByEmail(email)?.ContentJson);


        //list
        public HttpResponseMessageWrapper GetPersonalDataListResponse()
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var response = client.GetAsync(resource + "/public/list");
            return response;
        }

        public List<PersonalDataModel> GetPersonalDataListModel() => JsonConvert.DeserializeObject<List<PersonalDataModel>>(GetPersonalDataListResponse()?.ContentJson);

        //personal data by id
        public HttpResponseMessageWrapper GetPersonalDataById(string id)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var response = client.GetAsync(resource + $"/{id}");
            return response;
        }

        public PersonalDataModel GetPersonalDataModelById(string id) => JsonConvert.DeserializeObject<PersonalDataModel>(GetPersonalDataById(id)?.ContentJson);
    }
}
