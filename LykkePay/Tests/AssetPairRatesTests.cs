using LykkePay.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using TestsCore.TestsData;

namespace LykkePay.Tests
{
    public class AssetPairRatesTests
    {
        

        public class GetAssetPairEmptyPair : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void GetAssetPairEmptyPairTest()
            {
                var response = lykkePayApi.assetPairRates.GetAssetPairRates("");
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Unexpected status code for empty assetPair");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class GetAssetPairUSDBTCPair : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void GetAssetPairUSDBTCPairTest()
            {
                var response = lykkePayApi.assetPairRates.GetAssetPairRates("USDBTC");
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Unexpected status code for empty assetPair");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class GetAssetPairValidIdPair : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void GetAssetPairValidIdPairTest()
            {
                string assetPair = "BTCUSD";
                var response = lykkePayApi.assetPairRates.GetAssetPairRatesModel(assetPair);
                Assert.That(response, Is.Not.Null, "Unexpected response model for valid assetPair");
                Assert.That(assetPair, Is.EqualTo(response.assetPair), "Unexpected asset Pair");
               
            }
        }

        public class GetAssetPairTextPair : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void GetAssetPairTextPairTest()
            {
                var text = TestData.GenerateString(8);
                
                var response = lykkePayApi.assetPairRates.GetAssetPairRates(text);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Unexpected status code for text assetPair");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class GetAssetPairNumbersPair : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void GetAssetPairNumbersPairTest()
            {
                var numbers = TestData.GenerateNumbers(6);

                var response = lykkePayApi.assetPairRates.GetAssetPairRates(numbers);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Unexpected status code for numbers assetPair");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        #region Post Tests
        public class PostAssetPairEmptyParametersBody : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void PostAssetPairEmptyParametersBodyTest()
            {
                var assetPair = "BTCUSD";
                
                string markUp = "{\"markup\": { \"percent\":, \"pips\":}}";
                var merchant = new MerchantModel(markUp);

                var response = lykkePayApi.assetPairRates.PostAssetPairRatesWithJsonBody(assetPair, merchant, markUp);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Unexpected status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class PostAssetPairSpacesBody : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void PostAssetPairSpacesBodyTest()
            {
                var assetPair = "BTCUSD";
                
                string markUp = "{\"markup\": { \"percent\": , \"pips\": }}";
                var merchant = new MerchantModel(markUp);
                var response = lykkePayApi.assetPairRates.PostAssetPairRatesWithJsonBody(assetPair, merchant, markUp);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Unexpected status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class PostAssetPairEmptyBody : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void PostAssetPairSpacesEmptyTest()
            {
                var assetPair = "BTCUSD";
                
                MarkupModel markUp = null;
                var merchant = new MerchantModel(markUp);
                var response = lykkePayApi.assetPairRates.PostAssetPairRates(assetPair, merchant, markUp);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Unexpected status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class PostAssetPairPercentEmpty : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void PostAssetPairPercentEmptyTest()
            {
                var assetPair = "BTCUSD";
                
                string markUp = "{\"markup\": { \"percent\": , \"pips\": 20 }}";
                var merchant = new MerchantModel(markUp);

                var response = lykkePayApi.assetPairRates.PostAssetPairRatesWithJsonBody(assetPair, merchant, markUp);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Unexpected status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class PostAssetPairWithoutPercent : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void PostAssetPairWithoutPercentTest()
            {
                var assetPair = "BTCUSD";
                
                string markUp = "{\"markup\": {\"pips\": 20 }}";

                var merchant = new MerchantModel(markUp);
                var response = lykkePayApi.assetPairRates.PostAssetPairRatesWithJsonBody(assetPair, merchant, markUp);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Unexpected status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class PostAssetPairPipsEmpty : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void PostAssetPairPipsEmptyTest()
            {
                var assetPair = "BTCUSD";
                
                string markUp = "{\"markup\": { \"percent\":20 , \"pips\":}}";
                var merchant = new MerchantModel(markUp);
                var response = lykkePayApi.assetPairRates.PostAssetPairRatesWithJsonBody(assetPair, merchant, markUp);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Unexpected status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class PostAssetPairWithoutPips : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void PostAssetPairWithoutPipsTest()
            {
                var assetPair = "BTCUSD";
                
                string markUp = "{\"markup\": {\"pips\": 20 }}";
                var merchant = new MerchantModel(markUp);

                var response = lykkePayApi.assetPairRates.PostAssetPairRatesWithJsonBody(assetPair, merchant, markUp);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Unexpected status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class PostAssetPairPercentDiffValues : BaseTest
        {
            [TestCase(0)]
            [TestCase("0.0")]
            [TestCase(1f)]
            [TestCase(50f)]
            [TestCase(100f)]
            [TestCase(500f)]
            [TestCase(-1f)]
            [TestCase(25.5f)]
            [TestCase("testtest")]
            [TestCase("25%")]
            [Category("LykkePay")]
            public void PostAssetPairPercentDiffValuesTest(object percent)
            {
                object p = percent;
                var assetPair = "BTCUSD";
                
                string markUp = $"{{\"markup\": {{ \"percent\":{p} , \"pips\": 0}}";
                var merchant = new MerchantModel(markUp);

                var response = lykkePayApi.assetPairRates.PostAssetPairRatesWithJsonBody(assetPair, merchant, markUp);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Unexpected status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class PostAssetPairPipsDiffValues : BaseTest
        {
            [TestCase(0)]
            [TestCase(1)]
            [TestCase(50)]
            [TestCase(100)]
            [TestCase(500)]
            [TestCase(-1f)]
            [TestCase(3.5)]
            [TestCase("testtest")]
            [TestCase("3 pip")]
            [Category("LykkePay")]
            public void PostAssetPairPipsDiffValuesTest(object pips)
            {
                object p = pips;
                var assetPair = "BTCUSD";
                
                string markUp = $"{{\"markup\": {{ \"percent\":0 , \"pips\": {p}}}";
                var merchant = new MerchantModel(markUp);
                var response = lykkePayApi.assetPairRates.PostAssetPairRatesWithJsonBody(assetPair, merchant, markUp);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Unexpected status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }
        }

        public class PostAssetPairValidValues : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void PostAssetPairValidValuesTest()
            {
                var assetPair = "BTCUSD";
                
                MarkupModel markUp = new MarkupModel(50, 30);
                
                var merchant = new MerchantModel(markUp);
                var response = lykkePayApi.assetPairRates.PostAssetPairRates(assetPair, merchant, markUp);

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Unexpected status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Unexpected response content");
            }

            
        }
        #endregion
    }
}
