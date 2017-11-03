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
using LykkeAutomationPrivate.Models;

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

        public FullPersonalDataModel GetFullPersonalDataModelById(string id) => JsonConvert.DeserializeObject<FullPersonalDataModel>(GetFullPersonalDataById(id)?.ContentJson);

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

        public PagedResultModelPersonalDataModel PostPageModel(PagingInfoModel pageInfo) => JsonConvert.DeserializeObject<PagedResultModelPersonalDataModel>(PostPage(pageInfo)?.ContentJson);

        //POST /api/PersonalData/list/pagedIncludeOnly
        public HttpResponseMessageWrapper PostPagedIncludedOnly(PagingInfoModel pageInfo)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(pageInfo));
            var response = client.PostAsync(resource + $"/list/pagedIncludeOnly", content);
            return response;
        }

        public PagedResultModelPersonalDataModel PostPagedIncludedOnlyModel(PagingInfoModel pageInfo) => JsonConvert.DeserializeObject<PagedResultModelPersonalDataModel>(PostPagedIncludedOnly(pageInfo)?.ContentJson);

        //POST /api/PersonalData/list/byRegistrationDate
        public HttpResponseMessageWrapper PostListbyRegistrationDate(RegistrationDatesModel registrationDates)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(registrationDates));
            var response = client.PostAsync(resource + $"/list/pagedIncludeOnly", content);
            return response;
        }

        public List<FullPersonalDataModel> PostListbyRegistrationDateModel(RegistrationDatesModel registrationDates) => JArray.Parse(PostListbyRegistrationDate(registrationDates)?.ContentJson).ToObject<List<FullPersonalDataModel>>();

        //POST /api/PersonalData  Save personal info
        //no result model
        public HttpResponseMessageWrapper PostPersonalData(FullPersonalDataModel fullPersonalDataModel)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(fullPersonalDataModel));
            var response = client.PostAsync(resource, content);
            return response;
        }

        //POST /api/PersonalData/{id}/archive Delete item with id provided
        //no result model
        public HttpResponseMessageWrapper PostPersonalDataArchive(ArchiveRequest archiveRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(archiveRequest));
            var response = client.PostAsync(resource + $"/{archiveRequest.ClientId}/archive", content);
            return response;
        }

        //POST /api/PersonalData/{id}/email  Changing email
        public HttpResponseMessageWrapper PostPersonalDataChangeEmail(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PostAsync(resource + $"/{changeFieldRequest.ClientId}/email", content);
            return response;
        }

        public ChangeFieldResponseModel PostPersonalDataChangeEmailModel(ChangeFieldRequest changeFieldRequest) => JsonConvert.DeserializeObject<ChangeFieldResponseModel>(PostPersonalDataChangeEmail(changeFieldRequest)?.ContentJson);

        //POST /api/PersonalData/avatar/{id}  Add avatar
        public HttpResponseMessageWrapper PostAddAvatar(string id, string filePath)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(filePath);
            var response = client.PostAsync(resource + $"/avatar/{id}", content);
            return response;
        }
        #endregion

        #region PUT
        //PUT /api/PersonalData Update personal info
        public HttpResponseMessageWrapper PutPersonalData(PersonalDataModel personalDataModel)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(personalDataModel));
            var response = client.PutAsync(resource, content);
            return response;
        }

        //PUT /api/PersonalData/{id}/fullname
        public HttpResponseMessageWrapper PutPersonalDataFullName(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/fullname", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/firstName
        public HttpResponseMessageWrapper PutPersonalDataFirstName(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/firstName", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/lastName
        public HttpResponseMessageWrapper PutPersonalDataLastName(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/lastName", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/dateOfBirth  Change date of birth (MM/DD/YYYY)
        public HttpResponseMessageWrapper PutPersonalDataDateOfBirth(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/dateOfBirth", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/DateOfExpiryOfID  Change date of expiry of ID birth (MM/DD/YYYY)
        public HttpResponseMessageWrapper PutPersonalDataDateOfExpiryOfId(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/DateOfExpiryOfID", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/country  Change country
        public HttpResponseMessageWrapper PutPersonalDataCountry(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/country", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/countryFromID  Change country from ID
        public HttpResponseMessageWrapper PutPersonalDataCountryFromId(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/countryFromID", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/countryFromPOA  Change country from IP
        public HttpResponseMessageWrapper PutPersonalDataCountryFromPOA(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/countryFromPOA", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/city  Change city
        public HttpResponseMessageWrapper PutPersonalDataCity(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/city", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/zip  Change zip
        public HttpResponseMessageWrapper PutPersonalDataZip(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/zip", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/address  Change address
        public HttpResponseMessageWrapper PutPersonalDataAddress(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/address", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/phoneNumber  Change contact phone number
        public HttpResponseMessageWrapper PutPersonalDataPhoneNumber(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/phoneNumber", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/geolocation  Change geolocation data
        public HttpResponseMessageWrapper PutPersonalDataGeolocation(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/geolocation", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/passwordHint  Change password hint
        public HttpResponseMessageWrapper PutPersonalDataPasswordHint(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/passwordHint", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/refCode  Set referral code
        public HttpResponseMessageWrapper PutPersonalDataRefCode(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/refCode", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/spotRegulator  Change spot regulator
        public HttpResponseMessageWrapper PutPersonalDataSpotRegulator(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/spotRegulator", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/marginRegulator  Change margin regulator
        public HttpResponseMessageWrapper PutPersonalDataMarginRegulator(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/marginRegulator", content);
            return response;
        }

        //PUT /api/PersonalData/{id}/paymentSystem  Change payment system
        public HttpResponseMessageWrapper PutPersonalDataPaymentSystem(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/{changeFieldRequest.ClientId}/paymentSystem", content);
            return response;
        }

        //PUT /api/PersonalData/profile  Update profile info
        public HttpResponseMessageWrapper PutPersonalDataProfile(UpdateProfileInfoRequest updateProfileInfoRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(updateProfileInfoRequest));
            var response = client.PutAsync(resource + $"/profile", content);
            return response;
        }

        //PUT /api/PersonalData/documentscan/{id}  Add document scan
        public HttpResponseMessageWrapper PutPersonalDataDocumentScan(ChangeFieldRequest changeFieldRequest)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            StringContent content = new StringContent(JsonConvert.SerializeObject(changeFieldRequest));
            var response = client.PutAsync(resource + $"/documentscan/{changeFieldRequest.ClientId}", content);
            return response;
        }
        #endregion

        #region DELETE

        //DELETE /api/PersonalData/avatar/{id}  Delete avatar
        public HttpResponseMessageWrapper DELETEPersonalDataAvatar(string id)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var response = client.DeleteAsync(resource + $"/documentscan/{id}");
            return response;
        }

        //DELETE /api/PersonalData/cache  Clears cache
        public HttpResponseMessageWrapper DELETEPersonalDataCache(string id)
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var response = client.DeleteAsync(resource + $"/cache");
            return response;
        }
        #endregion
    }
}
