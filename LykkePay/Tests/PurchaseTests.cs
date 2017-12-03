using LykkePay.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LykkePay.Tests
{
    public class PurchaseTests
    {
        public class PostPurchaseRequiredParamsOnly : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void PostPurchaseRequiredParamsOnlyTest()
            {
                var address = "mnosddsjcchkwjfnnjcdodsc=";
                var assetPair = "BTCUSD";
                var baseAsset = "USD";
                decimal amount = 100;

                var merchant = new MerchantModel();
                var purchaseModel = new PostPurchaseModel(address, assetPair, baseAsset, amount);
                var purchase = lykkePayApi.purchase.PostPurchaseResponse(merchant, purchaseModel);

                Assert.That(purchase.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                //TODO: Check purchase
            }
        }

        public class PostPurchaseAllParams : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void PostPurchaseAllParamsTest()
            {
                var address = "mnosddsjcchkwjfnnjcdodsc=";
                var assetPair = "BTCUSD";
                var baseAsset = "USD";
                decimal amount = 100;

                var merchant = new MerchantModel();
                var purchaseModel = new PostPurchaseModel(address, assetPair, baseAsset, amount)
                {
                    successUrl = "",
                    errorUrl = "",
                    progressUrl = "",
                    orderId = "",
                    markup = new PostMarkup(0,0,0)
                };

                var purchase = lykkePayApi.purchase.PostPurchaseResponse(merchant, purchaseModel);

                Assert.That(purchase.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                //TODO: Check purchase
            }
        }

        public class PostPurchaseSample : BaseTest
        {
            [Test]
            public void PostPurchaseSampleTest()
            {
                var markUp = new MarkupModel(20, 10);
                var merchant = new MerchantModel(markUp);
                var address = "mnosddsjcchkwjfnnjcdodsc=";
                var assetPair = "BTCUSD";
                var baseAsset = "USD";
                decimal amount = 100;
                var postAssetsPairRates = lykkePayApi.assetPairRates.PostAssetsPairRatesModel(assetPair, merchant, markUp);

                var purchaseModel = new PostPurchaseModel(address, assetPair, baseAsset, amount);
                merchant.LykkeMerchantSessionId = postAssetsPairRates.LykkeMerchantSessionId;

                var result = lykkePayApi.purchase.PostPurchaseResponse(merchant, purchaseModel);
            }
        }
    }
}
