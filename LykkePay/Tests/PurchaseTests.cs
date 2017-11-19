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
                #region create merchant model
                MarkupModel markUp = new MarkupModel(20, 10);
                var merchant = new MerchantModel(markUp);
                var assetPair = "BTCUSD";
                var responseModel = lykkePayApi.assetPairRates.PostAssetsPairRatesModel(assetPair, merchant, markUp);

                #endregion

                PostMerchantModel merchantModel = new PostMerchantModel(merchant.LykkeMerchantId, merchant.LykkeMerchantSign, responseModel.LykkeMerchantSessionId);
                PostPurchaseModel purchaseModel = new PostPurchaseModel(new PostMarkup(markUp, 0.001f), assetPair);

               var result = lykkePayApi.purchase.PostPurchaseResponse(merchantModel, purchaseModel);
            }
        }

    }
}
