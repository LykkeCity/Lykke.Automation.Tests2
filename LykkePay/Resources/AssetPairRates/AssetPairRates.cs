using LykkePay.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.ApiRestClient;

namespace LykkePay.Resources.AssetPairRates
{
    public class AssetPairRates : RestApi
    {
        private string resource = "/assetPairRates";

        public IRestResponse GetAssetPairRates(string assetPair)
        {
            IRestRequest request = new RestRequest($"{resource}/{assetPair}", Method.GET);
            var respose = client.Execute(request);
            return respose;
        }

        public AssetsPaiRatesResponseModel GetAssetPairRatesModel(string assetPair) => 
            JsonConvert.DeserializeObject<AssetsPaiRatesResponseModel>(GetAssetPairRates(assetPair).Content);

        #region POST
        public IRestResponse PostAssetPairRates(string assetPair, MerchantModel merchant, MarkupModel markup)
        {
            IRestRequest request = new RestRequest($"{resource}/{assetPair}", Method.POST);
            request.AddHeader("Lykke-Merchant-Id", merchant.LykkeMerchantId);
            request.AddHeader("Lykke-Merchant-Sign", merchant.LykkeMerchantSign);
            if(markup != null)
                request.AddJsonBody(markup);
            
            var respose = client.Execute(request);
            return respose;
        }

        public IRestResponse PostAssetPairRatesWithJsonBody(string assetPair, MerchantModel merchant, string body)
        {
            IRestRequest request = new RestRequest($"{resource}/{assetPair}", Method.POST);
            request.AddHeader("Lykke-Merchant-Id", merchant.LykkeMerchantId);
            request.AddHeader("Lykke-Merchant-Sign", merchant.LykkeMerchantSign);
            if (body != null)
                request.AddParameter("application/json", body, ParameterType.RequestBody);

            var respose = client.Execute(request);
            return respose;
        }

        public PostAssetsPairRatesModel PostAssetsPairRatesModel(string assetPair, MerchantModel merchant, MarkupModel markup) =>
            JsonConvert.DeserializeObject<PostAssetsPairRatesModel>(PostAssetPairRates(assetPair, merchant, markup).Content);
        #endregion
    }
}
