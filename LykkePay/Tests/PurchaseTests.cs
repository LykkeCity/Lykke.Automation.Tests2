using LykkePay.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LykkePay.Tests
{
    public class PurchaseTests
    {

        public class PostPurchaseSample : BaseTest
        {
            [Test]
            public void PostPurchaseSampleTest()
            {
                var markUp = new MarkupModel(20, 10);
                var merchant = new MerchantModel(markUp);
                var assetPair = "BTCUSD";
                var baseAsset = "USD";
                decimal amount = 100;
                var postAssetsPairRates = lykkePayApi.assetPairRates.PostAssetsPairRatesModel(assetPair, merchant, markUp);

                var purchaseModel = new PostPurchaseModel(assetPair, baseAsset, amount);
                merchant.LykkeMerchantSessionId = postAssetsPairRates.LykkeMerchantSessionId;

                var result = lykkePayApi.purchase.PostPurchaseResponse(merchant, purchaseModel);
            }
        }
    }
}
