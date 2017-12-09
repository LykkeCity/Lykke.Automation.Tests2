using LykkeAutomationPrivate.DataGenerators;
using LykkeAutomationPrivate.Models.Registration.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LykkeAutomationPrivate.Tests.ClientAccount
{
    class GetClientAccountInformation : BaseTest
    {
        AccountRegistrationModel registrationModel;
        ClientAccountInformationModel account;
        string pin = "1111";

        [SetUp]
        public void CreateClient()
        {
            registrationModel = new AccountRegistrationModel().GetTestModel();
            account = lykkeApi.Registration.PostRegistration(registrationModel).Account;
            lykkeApi.ClientAccount.Wallets.PostClientAccountInformationsetPIN(account.Id, pin);
        }

        [Test]
        [Description("Get client by id.")]
        [Category("ClientAccountInformationResource"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetClientAccountInformationTest()
        {
            var getAccountInformation = lykkeApi.ClientAccount.ClientAccountInformation.GetClientAccountInformation(account.Id);
            Assert.That(getAccountInformation.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var accountInformation = getAccountInformation.GetResponseObject();
            Assert.That(accountInformation.Email, Is.EqualTo(registrationModel.Email));
            Assert.That(accountInformation.Id, Is.EqualTo(account.Id));
            Assert.That(accountInformation.IsReviewAccount, Is.EqualTo(false));
            Assert.That(accountInformation.IsTrusted, Is.EqualTo(false));
            Assert.That(accountInformation.NotificationsId, Is.EqualTo(account.NotificationsId));
            Assert.That(accountInformation.PartnerId, Is.Null);
            Assert.That(accountInformation.Phone, Is.EqualTo(registrationModel.ContactPhone));
            Assert.That(accountInformation.Pin, Is.EqualTo(pin));
            Assert.That(accountInformation.Registered, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromMinutes(10)));
        }
    }
}
