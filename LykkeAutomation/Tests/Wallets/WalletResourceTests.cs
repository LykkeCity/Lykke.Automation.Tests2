using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.RestRequest;
using NUnit.Framework;
using LykkeAutomation.ApiModels.RegistrationModels;
using TestsCore.TestsData;

namespace LykkeAutomation.Tests.Wallets
{
    class WalletResourceTests : BaseTest
    {
        readonly string baseUrl = "http://client-account.lykke-service.svc.cluster.local";
        readonly string devBaseUrl = "https://api-dev.lykkex.net";

        [Test]
        public void WaletTest1()
        {
            var registered = Request.For(devBaseUrl).Post("/api/Registration")
                .AddJsonBody(new AccountRegistrationModel())
                .WithProxy.Execute<ResultRegistrationResponseModel>();

            string bearerToken = registered.Result.Token;

            Request.For(devBaseUrl).Post("api/PinSecurity")
                .AddJsonBody(new { Pin = "12345"})
                .WithBearerToken(bearerToken).WithProxy.Execute();

            Request.For(devBaseUrl).Get("api/PinSecurity").WithBearerToken(bearerToken).WithProxy.Execute();

            var r = Request.For(baseUrl)
                .Post("/api/Wallets")
                .AddJsonBody(new
                {
                    Id = "string",
                    Name = "Some name",
                    Type = "Trusted",
                    Description = "Some descr"
                })
                .WithProxy
                .Execute();
        }
    }
}
