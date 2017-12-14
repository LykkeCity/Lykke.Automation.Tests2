﻿using LykkeAutomationPrivate.DataGenerators;
using LykkeAutomationPrivate.Models.ClientAccount.Models;
using LykkeAutomationPrivate.Models.Registration.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LykkeAutomationPrivate.Tests.ClientAccount
{
    class GetClientAccountInformation : BaseTest
    {
        AccountRegistrationModel registration;
        ClientAccountInformationModel account;
        string pin = "1111";
        string partnerId = "NewTestPartner";

        [OneTimeSetUp]
        public void CreateClient()
        {
            registration = new AccountRegistrationModel().GetTestModel();
            registration.PartnerId = partnerId;
            account = lykkeApi.Registration.PostRegistration(registration).Account;
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
            Assert.That(accountInformation.Email, Is.EqualTo(registration.Email));
            Assert.That(accountInformation.Id, Is.EqualTo(account.Id));
            Assert.That(accountInformation.IsReviewAccount, Is.EqualTo(false));
            Assert.That(accountInformation.IsTrusted, Is.EqualTo(false));
            Assert.That(accountInformation.NotificationsId, Is.EqualTo(account.NotificationsId));
            Assert.That(accountInformation.PartnerId, Is.EqualTo(partnerId));
            Assert.That(accountInformation.Phone, Is.EqualTo(registration.ContactPhone));
            Assert.That(accountInformation.Pin, Is.EqualTo(pin));
            Assert.That(accountInformation.Registered, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromMinutes(10)));
        }

        [Test]
        [Ignore("Could not send body in GET request")]
        [Description("Get clients by ids.")]
        [Category("ClientAccountInformationResource"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetClientsByIdsTest()
        {

        }

        [Test]
        [Description("Get clients by phone.")]
        [Category("ClientAccountInformationResource"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetClientsByPhoneTest()
        {
            var getClientsByPhone = lykkeApi.ClientAccount.ClientAccountInformation
                .GetClientsByPhone(registration.ContactPhone);
            Assert.That(getClientsByPhone.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(getClientsByPhone.GetResponseObject(), Does.Contain(account.Id));
        }

        [Test]
        [Description("Check if password is correct.")]
        [Category("ClientAccountInformationResource"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetIsPasswordCorrectTest()
        {
            var isPasswordCorrect = lykkeApi.ClientAccount.ClientAccountInformation
                .GetIsPasswordCorrect(account.Id, registration.Password);
            Assert.That(isPasswordCorrect.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(isPasswordCorrect.GetResponseObject(), Is.True);
        }

        [Test]
        [Description("Get client by id.")]
        [Category("ClientAccountInformationResource"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetClientByIdTest()
        {
            var client = lykkeApi.ClientAccount.ClientAccountInformation
                .GetClientById(account.Id);
            Assert.That(client.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var clientModel = client.GetResponseObject();
            Assert.That(clientModel.Id, Is.EqualTo(account.Id));
            Assert.That(clientModel.Email, Is.EqualTo(account.Email));
            Assert.That(clientModel.PartnerId, Is.EqualTo(partnerId));
            Assert.That(clientModel.Phone, Is.EqualTo(account.Phone));
            Assert.That(clientModel.Pin, Is.EqualTo(pin));
            Assert.That(clientModel.NotificationsId, Is.EqualTo(account.NotificationsId));
            Assert.That(clientModel.Registered, Is.EqualTo(account.Registered));
            Assert.That(clientModel.IsReviewAccount, Is.EqualTo(account.IsReviewAccount));
        }

        [Test]
        [Description("Get clients by email.")]
        [Category("ClientAccountInformationResource"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetClientsByEmailTest()
        {
            var client = lykkeApi.ClientAccount.ClientAccountInformation
                .GetClientsByEmail(account.Email);
            Assert.That(client.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(client.GetResponseObject().Count, Is.EqualTo(1));

            var clientModel = client.GetResponseObject().First();

            Assert.That(clientModel.Id, Is.EqualTo(account.Id));
            Assert.That(clientModel.Email, Is.EqualTo(account.Email));
            Assert.That(clientModel.PartnerId, Is.EqualTo(partnerId));
            Assert.That(clientModel.Phone, Is.EqualTo(account.Phone));
            Assert.That(clientModel.Pin, Is.EqualTo(pin));
            Assert.That(clientModel.NotificationsId, Is.EqualTo(account.NotificationsId));
            Assert.That(clientModel.Registered, Is.EqualTo(account.Registered));
            Assert.That(clientModel.IsReviewAccount, Is.EqualTo(account.IsReviewAccount));
        }

        [Test]
        [Description("Get client by email and partner id.")]
        [Category("ClientAccountInformationResource"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetClientByEmailAndPartnerIdTest()
        {
            var client = lykkeApi.ClientAccount.ClientAccountInformation
                .GetClientByEmailAndPartnerId(account.Email, partnerId);
            Assert.That(client.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var clientModel = client.GetResponseObject();

            Assert.That(clientModel.Id, Is.EqualTo(account.Id));
            Assert.That(clientModel.Email, Is.EqualTo(account.Email));
            Assert.That(clientModel.PartnerId, Is.EqualTo(partnerId));
            Assert.That(clientModel.Phone, Is.EqualTo(account.Phone));
            Assert.That(clientModel.Pin, Is.EqualTo(pin));
            Assert.That(clientModel.NotificationsId, Is.EqualTo(account.NotificationsId));
            Assert.That(clientModel.Registered, Is.EqualTo(account.Registered));
            Assert.That(clientModel.IsReviewAccount, Is.EqualTo(account.IsReviewAccount));
        }
    }
}
