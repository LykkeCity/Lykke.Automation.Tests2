﻿using LykkeAutomation.Api.ApiModels.AccountExistModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestsCore.TestsCore;
using Lykke.Client.AutorestClient.Models;
using TestsCore.ApiRestClient;

namespace LykkeAutomation.Api.ApiResources.AccountExist
{
    public class AccountExist : RestApi
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

        public override void SetAllureProperties()
        {
            var isAlive = GetIsAlive();
            AllurePropertiesBuilder.Instance.AddPropertyPair("Service", client.BaseUrl.AbsoluteUri + "/api" + resource);
            AllurePropertiesBuilder.Instance.AddPropertyPair("Environment", isAlive.Env);
            AllurePropertiesBuilder.Instance.AddPropertyPair("Version", isAlive.Version);
        }

        public IsAliveResponse GetIsAlive()
        {
            var request = new RestRequest("/IsAlive", Method.GET);
            var response = client.Execute(request);
            var isAlive = JsonConvert.DeserializeObject<IsAliveResponse>(response.Content);
            return isAlive;
        }
    }
}
