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
using System.Net.Http;

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

#region GET requests
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

        //full personal
        public HttpResponseMessageWrapper GetFullPersonalDataById(string id)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var response = client.GetAsync(resource + $"/full/{id}");
            return response;
        }

        public PersonalDataModel GetFullPersonalDataModelById(string id) => JsonConvert.DeserializeObject<PersonalDataModel>(GetFullPersonalDataById(id)?.ContentJson);

        //profile data
        public HttpResponseMessageWrapper GetProfilePersonalDataById(string id)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var response = client.GetAsync(resource + $"/profile/{id}");
            return response;
        }

        public ProfilePersonalData GetProfilePersonalDataModelById(string id) => JsonConvert.DeserializeObject<ProfilePersonalData>(GetProfilePersonalDataById(id)?.ContentJson);

        //search
        public HttpResponseMessageWrapper GetSearchPersonalData(string querry)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var response = client.GetAsync(resource + $"/search?phrase={querry}");
            return response;
        }

        public SearchPersonalDataModel GetSearchPersonalDataModel(string id) => JsonConvert.DeserializeObject<SearchPersonalDataModel>(GetSearchPersonalData(id)?.ContentJson);

        //get document by id
        public HttpResponseMessageWrapper GetDocumentById(string id)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var response = client.GetAsync(resource + $"/documentscan/{id}");
            return response;
        }

        public SearchPersonalDataModel GetDocumentByIdModel(string id) => JsonConvert.DeserializeObject<SearchPersonalDataModel>(GetDocumentById(id)?.ContentJson);
        #endregion

        #region Post Requests
        public HttpResponseMessageWrapper PostPersonalDataListById(params string[] id)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(id));
            var response = client.PostAsync(resource + $"/list", content);
            return response;
        }

        public List<PersonalDataModel> PostPersonalDataListByIdModel(params string[] id) => JArray.Parse(PostPersonalDataListById(id)?.ContentJson).ToObject<List<PersonalDataModel>>();

        //post full list
        public HttpResponseMessageWrapper PostFullPersonalDataListById(params string[] id)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(id));
            var response = client.PostAsync(resource + $"/list", content);
            return response;
        }

        public List<FullPersonalDataModel> PostFullPersonalDataListByIdModel(params string[] id) => JArray.Parse(PostFullPersonalDataListById(id)?.ContentJson).ToObject<List<FullPersonalDataModel>>();

        //post paged Exclude
        public HttpResponseMessageWrapper PostPageExclude(PagingInfoModel pageInfo)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(pageInfo));
            var response = client.PostAsync(resource + $"/list/pagedExclude", content);
            return response;
        }

        public PagedRequestModel PostPageExcludeModel(PagingInfoModel pageInfo) => JsonConvert.DeserializeObject<PagedRequestModel>(PostPageExclude(pageInfo)?.ContentJson);

        //POST /api/PersonalData/list/paged
        public HttpResponseMessageWrapper PostPage(PagingInfoModel pageInfo)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(pageInfo));
            var response = client.PostAsync(resource + $"/list/paged", content);
            return response;
        }

        public PagedRequestModel PostPageModel(PagingInfoModel pageInfo) => JsonConvert.DeserializeObject<PagedRequestModel>(PostPage(pageInfo)?.ContentJson);

        #endregion
    }
}
