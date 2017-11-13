using LykkePay.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.ApiRestClient;

namespace LykkePay.Resources.Purchase
{
    public class Purchase : RestApi
    {
        private const string resource = "/purchase";

        public IRestResponse PostPurchaseResponse(PostMerchantModel merchantModel, PostPurchaseModel purchaseModel)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("Lykke-Merchant-Id", merchantModel.LykkeMerchantId);
            request.AddHeader("Lykke-Merchant-Sign", merchantModel.LykkeMerchantSign);
            request.AddHeader("Lykke-Merchant-Session-Id", merchantModel.LykkeMerchantSessionID);
            request.AddJsonBody(purchaseModel);
            var response = client.Execute(request);

            return response;
        }

        public PostPurchaseResponseModel PostPurchaseResponseModel(PostMerchantModel merchantModel, PostPurchaseModel purchaseModel) =>
            JsonConvert.DeserializeObject<PostPurchaseResponseModel>(PostPurchaseResponse(merchantModel, purchaseModel).Content);
    }
}
