using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.ApiRestClient;
using TestsCore.TestsCore;
using RestSharp;
using LykkePay.Models;

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
            var merchant = new MerchantModel(urlToSign);
            request.AddHeader("Lykke-Merchant-Id", merchant.LykkeMerchantId);
            request.AddHeader("Lykke-Merchant-Sign", merchant.LykkeMerchantSign);
        }

        public IRestResponse GetGetBalance(string assertId)
        {
            IRestRequest request = new RestRequest($"{resource}/{assertId}", Method.GET);
            SetMerchantHeadersForGetRequest(ref request);

            return client.Execute(request);
        }

        public IRestResponse GetGetBalanceNonEmpty(string assertId)
        {
            IRestRequest request = new RestRequest($"{resource}/{assertId}/nonempty", Method.GET);
            SetMerchantHeadersForGetRequest(ref request);

            return client.Execute(request);
        }
    }
}
