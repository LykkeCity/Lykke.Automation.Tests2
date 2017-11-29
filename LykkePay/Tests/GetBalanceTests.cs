using NUnit.Framework;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace LykkePay.Tests
{
    public class GetBalanceTests
    {
        public class GetBalance : BaseTest
        {
            [TestCase("BTC")]
            [TestCase("btc")]
            [TestCase("USD")]
            [Category("LykkePay")]
            public void GetBalanceTest(string asset)
            {
                var r = lykkePayApi.getBalance.GetGetBalance(asset);
                Assert.That(r.ResponseStatus, Is.EqualTo(HttpStatusCode.OK), "Not 200 code on valid getbalance request");
            }
        }

        public class GetBalanceNonEmpty : BaseTest
        {
            [TestCase("BTC")]
            [TestCase("btc")]
            [TestCase("USD")]
            [Category("LykkePay")]
            public void GetBalanceNonEmptyTest(string asset)
            {
                var r = lykkePayApi.getBalance.GetGetBalanceNonEmpty(asset);
                Assert.That(r.ResponseStatus, Is.EqualTo(HttpStatusCode.OK), 
                    "Not 200 code on valid getbalance/nonempty request");
            }
        }

        public class GetBalanceUserHasNoWalletsAtAll : BaseTest
        {
            [OneTimeSetUp]
            public void CreateUserWithNoWalletsAtAll()
            {
                //TODO: Add implementation
            }

            [Test]
            public void GetBalanceUserHasNoWalletsAtAllTest()
            {
                //TODO: Add implementation
            }
        }
    }
}
