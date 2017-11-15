using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.RestRequests;
using NUnit.Framework;
using LykkeAutomationPrivate.Tests;
using Lykke.Client.AutorestClient.Models;

namespace LykkeAutomation.Tests.Wallets
{
    class WalletResourceTests : BaseTest
    {
        readonly string clientAccountUrl = "http://client-account.lykke-service.svc.cluster.local";
        readonly string registrationUrl = "http://registration.lykke-service.svc.cluster.local";
        readonly string devBaseUrl = "https://api-dev.lykkex.net";

        [Test]
        [Category("Wallet")]
        public void PostWallet()
        {
            string walletName = "Some wallet name";
            string walletDescription = "Some wallet description";

            var client = new FullPersonalDataModel().Init();
            var registered = Requests.For(registrationUrl).Post("/api/Registration")
                .AddJsonBody(client)
                .WithProxy.Execute().GetJObject();


            string bearerToken = (string)registered["Token"];
            string id = (string)registered["Account"]["Id"];

            Requests.For(devBaseUrl).Post("api/PinSecurity")
                .AddJsonBody(new { Pin = "1111"})
                .WithBearerToken(bearerToken).WithProxy.Execute();

            var wallet = Requests.For(clientAccountUrl).Post("/api/Wallets")
                .AddJsonBody(new
                {
                    ClientId = id,
                    Name = walletName,
                    Type = "Trusted",
                    Description = walletDescription
                })
                //.WithBearerToken(bearerToken)
                .WithProxy.Execute().GetJObject();

            Assert.That((string)wallet["Id"], Is.Not.Null);
            Assert.That((string)wallet["Name"], Is.EqualTo(walletName));
            Assert.That((string)wallet["Description"], Is.EqualTo(walletDescription));
        }
    }
}
