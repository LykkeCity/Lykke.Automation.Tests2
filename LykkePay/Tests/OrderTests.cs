using LykkePay.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestsCore.TestsData;

namespace LykkePay.Tests
{
    public class OrderTests
    {

        const string successURL = "http://lykkePostBack.pythonanywhere.com/successURL";
        const string progressURL = "http://lykkePostBack.pythonanywhere.com/progressURL";
        const string errorURL = "http://lykkePostBack.pythonanywhere.com/errorURL";

        public class OrderResponseValidate : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            [Description("Validate Order response json")]
            public void OrderResponseValidateTest()
            {
                var assetPair = "BTCUSD";

                MarkupModel markUp = new MarkupModel(50, 30);

                var merchant = new MerchantModel(markUp);
                var response = lykkePayApi.assetPairRates.PostAssetPairRates(assetPair, merchant, markUp);

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Unexpected status code");
                var postModel = JsonConvert.DeserializeObject<PostAssetsPairRatesModel>(response.Content);
                Assert.That(postModel.LykkeMerchantSessionId, Is.Not.Null, "LykkeMerchantSessionId not present in response");

                // order request below

                var orderRequest = new OrderRequestModel() {currency = "USD", amount = 10, exchangeCurrency = "BTC", successURL = successURL, errorURL = errorURL, progressURL = progressURL, orderId = TestData.GenerateNumbers(5), markup = new PostMarkup(markUp, 0)};
                var orderRequestJson = JsonConvert.SerializeObject(orderRequest);
                merchant = new MerchantModel(orderRequestJson);

                var orderResponse = lykkePayApi.order.PostOrderModel(merchant, orderRequestJson, postModel.LykkeMerchantSessionId);
            }
        }
    }
}
