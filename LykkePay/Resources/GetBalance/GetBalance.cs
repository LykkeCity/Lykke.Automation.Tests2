using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.ApiRestClient;
using TestsCore.TestsCore;
using RestSharp;
using LykkePay.Models;
using Newtonsoft.Json;

namespace LykkePay.Resources.GetBalance
{
    public class GetBalance : RestApi
    {
        private string resource = "/getBalance";

        public override void SetAllureProperties()
        {
            AllurePropertiesBuilder.Instance.AddPropertyPair("Service", client.BaseUrl.AbsoluteUri + resource);
        }

        private void SetMerchantHeadersForGetRequest(ref IRestRequest request)
        {
            string urlToSign = client.BaseUrl + request.Resource;
            var merchant = new MerchantModel(urlToSign.Replace("https:", "http:"));
            request.AddHeader("Lykke-Merchant-Id", merchant.LykkeMerchantId);
            request.AddHeader("Lykke-Merchant-Sign", merchant.LykkeMerchantSign);
        }

        public (IRestResponse Response, List<GetGetBalanceResponseModel> Data) GetGetBalance(string assertId)
        {
            IRestRequest request = new RestRequest($"{resource}/{assertId}", Method.GET);
            SetMerchantHeadersForGetRequest(ref request);

            var response = client.Execute(request);
            var data = JsonConvert.DeserializeObject<List<GetGetBalanceResponseModel>>(response.Content);
            return (response, data);
        }

        public (IRestResponse Response, List<GetGetBalanceResponseModel> Data) GetGetBalanceNonEmpty(string assertId)
        {
            IRestRequest request = new RestRequest($"{resource}/{assertId}/nonempty", Method.GET);
            SetMerchantHeadersForGetRequest(ref request);

            var response = client.Execute(request);
            var data = JsonConvert.DeserializeObject<List<GetGetBalanceResponseModel>>(response.Content);
            return (response, data);
        }
    }
}
