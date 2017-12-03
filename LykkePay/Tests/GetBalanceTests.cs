using NUnit.Framework;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

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
                var getBalance = lykkePayApi.getBalance.GetGetBalance(asset);
                Assert.That(getBalance.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), 
                    "Not 200 code on valid getbalance request");
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
                var getBalanceNE = lykkePayApi.getBalance.GetGetBalanceNonEmpty(asset);
                Assert.That(getBalanceNE.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), 
                    "Not 200 code on valid getbalance/nonempty request");
                Assert.That(getBalanceNE.Data?.Where(w => w.Amount == 0).Count(), Is.EqualTo(0), 
                    "Empty wallets has been returned");
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
            [Description("User has no wallets at all(for /{assertId})")]
            public void GetBalanceUserHasNoWalletsAtAllTest()
            {
                throw new NotImplementedException();
            }

            [Test]
            [Description("User has no wallets at all(for /{assertId}/nonempty)")]
            public void GetBalanceNonEmptyUserHasNoWalletsAtAllTest()
            {
                throw new NotImplementedException();
            }
        }

        public class GetBalanceUserHasNoWalletForAsset : BaseTest
        {
            [OneTimeSetUp]
            public void CreateUserWithNoWalletsAtAll()
            {
                //TODO: Add implementation
            }

            [Test]
            [Description("User has no wallets for assertId(for /{assertId})")]
            public void GetBalanceUserHasNoWalletForAssetTest()
            {
                throw new NotImplementedException();
            }

            [Test]
            [Description("User has no wallets for assertId(for /{assertId}/nonempty)")]
            public void GetBalanceNonEmptyUserHasNoWalletForAssetTest()
            {
                throw new NotImplementedException();
            }
        }

        public class GetBalanceUserHasEmptyAndNoEmptyWallets : BaseTest
        {
            [OneTimeSetUp]
            public void CreateUserWithNoWalletsAtAll()
            {
                //TODO: Add implementation
            }

            [Test]
            [Description("User has empty and non empty wallets (for /{assertId})")]
            public void GetBalanceUserHasEmptyAndNoEmptyWalletsTest()
            {
                throw new NotImplementedException();
            }

            [Test]
            [Description("User has empty and non empty wallets (for /{assertId}/nonempty)")]
            public void GetBalanceNonEmptyUserHasEmptyAndNoEmptyWalletsTest()
            {
                throw new NotImplementedException();
            }
        }

        public class GetBalanceUserHasEmptyAndNoEmptyWalletsForSeveralCurrs : BaseTest
        {
            [OneTimeSetUp]
            public void CreateUserWithNoWalletsAtAll()
            {
                //TODO: Add implementation
            }

            [Test]
            [Description("User has empty and non empty wallets for several currencies (for /{assertId})")]
            public void GetBalanceUserHasEmptyAndNoEmptyWalletsForSeveralCurrsTest()
            {
                throw new NotImplementedException();
            }

            [Test]
            [Description("User has empty and non empty wallets for several currencies (for /{assertId}/nonempty)")]
            public void GetBalanceNonEmptyUserHasEmptyAndNoEmptyWalletsForSeveralCurrsTest()
            {
                throw new NotImplementedException();
            }
        }
    }
}
