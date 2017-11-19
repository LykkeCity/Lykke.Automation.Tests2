using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.RestRequests;
using NUnit.Framework;
using LykkeAutomationPrivate.Tests;
using Lykke.Client.AutorestClient.Models;
using System.Net;

namespace LykkeAutomation.Tests.Wallets
{
    class WalletResourceTests : BaseTest
    {
        readonly string clientAccountUrl = "http://client-account.lykke-service.svc.cluster.local";
        readonly string registrationUrl = "http://registration.lykke-service.svc.cluster.local";
        readonly string devBaseUrl = "https://api-dev.lykkex.net";

        string userId;
        string walletName = "Some wallet name";
        string walletDescription = "Some wallet description";
        WalletType walletType = WalletType.Trusted;

        [OneTimeSetUp]
        public void CreateUser()
        {
            var client = new FullPersonalDataModel().Init();
            var registered = Requests.For(registrationUrl).Post("/api/Registration")
                .AddJsonBody(client)
                .Build().Execute().GetJObject();


            string bearerToken = (string)registered["Token"];
            userId = (string)registered["Account"]["Id"];

            Requests.For(devBaseUrl).Post("api/PinSecurity")
                .AddJsonBody(new { Pin = "1111" })
                .WithBearerToken(bearerToken).Build().Execute();
        }

        [Test]
        [Category("Wallet")]
        public void PostCreateWallet()
        {

            var wallet = Requests.For(clientAccountUrl).Post("/api/Wallets")
                .AddJsonBody(new CreateWalletRequest
                {
                    ClientId = userId,
                    Name = walletName,
                    Type = walletType,
                    Description = walletDescription
                })
                .Build().Execute<WalletDto>();

            Assert.That(wallet.Id, Is.Not.Null);
            Assert.That(wallet.Type, Is.EqualTo(walletType.ToSerializedValue()));
            Assert.That(wallet.Name, Is.EqualTo(walletName));
            Assert.That(wallet.Description, Is.EqualTo(walletDescription));
        }

        [TestCase("5000000-aaaa-bbbb-cccc-5555aaa111000")]
        [TestCase("oloasdakj jashdasdjal asdjuasdasa")]
        [TestCase("")]
        [TestCase(null)]
        [Category("Wallet")]
        public void PostCreateWalletClientId(string _userId)
        {
            var walletResponse = Requests.For(clientAccountUrl).Post("/api/Wallets")
                .AddJsonBody(new CreateWalletRequest
                {
                    ClientId = _userId,
                    Name = walletName,
                    Type = walletType,
                    Description = walletDescription
                })
                .Build().Execute();

            Assert.That(walletResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        public class CreateWalletRequestMock : CreateWalletRequest
        {
            public new object Type { get; set; }
        }

        [TestCase(WalletType.Trading, ExpectedResult = HttpStatusCode.OK)]
        [TestCase(WalletType.Trusted, ExpectedResult = HttpStatusCode.OK)]
        [TestCase("SomeType", ExpectedResult = HttpStatusCode.BadRequest)]
        [TestCase("", ExpectedResult = HttpStatusCode.BadRequest)]
        [TestCase(null, ExpectedResult = HttpStatusCode.BadRequest)]
        [Category("Wallet")]
        public HttpStatusCode PostCreateWalletType(object _walletType)
        {
            var walletResponse = Requests.For(clientAccountUrl).Post("/api/Wallets")
                .AddJsonBody(new CreateWalletRequestMock
                {
                    ClientId = userId,
                    Name = walletName,
                    Type = _walletType,
                    Description = walletDescription
                })
                .Build().Execute();

            return walletResponse.StatusCode;
        }

        [TestCase("Some long-long-long maybe or not name...", ExpectedResult = HttpStatusCode.OK)]
        [TestCase("N", ExpectedResult = HttpStatusCode.OK)]
        [TestCase("", ExpectedResult = HttpStatusCode.BadRequest)]
        [TestCase(null, ExpectedResult = HttpStatusCode.BadRequest)]
        [Category("Wallet")]
        public HttpStatusCode PostCreateWalletName(string _walletName)
        {
            var walletResponse = Requests.For(clientAccountUrl).Post("/api/Wallets")
                .AddJsonBody(new CreateWalletRequest
                {
                    ClientId = userId,
                    Name = _walletName,
                    Type = walletType,
                    Description = walletDescription
                })
                .Build().Execute();

            return walletResponse.StatusCode;
        }

        [TestCase("Some long-long-long maybe or not description", ExpectedResult = HttpStatusCode.OK)]
        [TestCase("", ExpectedResult = HttpStatusCode.OK)]
        [Category("Wallet")]
        public HttpStatusCode PostCreateWalletDescription(string _walletDescription)
        {
            var walletResponse = Requests.For(clientAccountUrl).Post("/api/Wallets")
                .AddJsonBody(new CreateWalletRequest
                {
                    ClientId = userId,
                    Name = walletName,
                    Type = walletType,
                    Description = _walletDescription
                })
                .Build().Execute();

            return walletResponse.StatusCode;
        }
    }
}
