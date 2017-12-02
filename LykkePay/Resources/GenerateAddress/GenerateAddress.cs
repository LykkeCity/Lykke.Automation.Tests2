using LykkePay.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.ApiRestClient;
using TestsCore.TestsCore;

namespace LykkePay.Resources.GenerateAddress
{
    public class GenerateAddress : RestApi
    {
        private string resource = "/generateAddress";


        public override void SetAllureProperties()
        {
            AllurePropertiesBuilder.Instance.AddPropertyPair("Service", client.BaseUrl.AbsoluteUri + resource);
        }

        public IRestResponse GetGenerateAddress(string id)
        {
            IRestRequest request = new RestRequest($"{resource}/{id}", Method.GET);
            string urlToSign = client.BaseUrl + $"{resource}/{id}";
            var merchant = new MerchantModel(urlToSign);
            request.AddHeader("Lykke-Merchant-Id", merchant.LykkeMerchantId);
            request.AddHeader("Lykke-Merchant-Sign", merchant.LykkeMerchantSign);

            return client.Execute(request);
        }
    }
}
