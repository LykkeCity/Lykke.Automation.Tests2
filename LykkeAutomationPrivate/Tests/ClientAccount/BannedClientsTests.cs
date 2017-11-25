using LykkeAutomationPrivate.Models.Registration.Models;
using LykkeAutomationPrivate.DataGenerators;
using NUnit.Framework;
using System.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace LykkeAutomationPrivate.Tests.ClientAccount
{
    class PutClientBan : BaseTest
    {
        string clientId;

        [SetUp]
        public void CreateClient()
        {
            clientId = lykkeApi.Registration.PostRegistration(new AccountRegistrationModel().GetTestModel()).Account.Id;
        }

        [TearDown]
        public void UnBanClient()
        {
            if (clientId != null)
                lykkeApi.ClientAccount.BannedClients.PutBannedClientsUnBan(clientId);
        }

        [Test]
        [Category("BannedClients"), Category("ClientAccount"), Category("ServiceAll")]
        public void PutClientBanTest()
        {
            var putClientBan = lykkeApi.ClientAccount.BannedClients.PutBannedClientsBan(clientId);
            Assert.That(putClientBan.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var getIsClientBanned = lykkeApi.ClientAccount.BannedClients.GetBannedClientsIsBanned(clientId);
            Assert.That(getIsClientBanned.GetResponseObject(), Is.True);
        }
    }

    class PutClientsUnBan : BaseTest
    {
        string clientId;

        [SetUp]
        public void CreateClient()
        {
            clientId = lykkeApi.Registration.PostRegistration(new AccountRegistrationModel().GetTestModel()).Account.Id;
        }

        [TearDown]
        public void UnBanClientAtTheEnd()
        {
            if (clientId != null)
                lykkeApi.ClientAccount.BannedClients.PutBannedClientsUnBan(clientId);
        }

        [Test]
        [Category("BannedClients"), Category("ClientAccount"), Category("ServiceAll")]
        public void PutClientsUnBanTest()
        {
            var putClientBan = lykkeApi.ClientAccount.BannedClients.PutBannedClientsBan(clientId);
            var getIsClientBanned = lykkeApi.ClientAccount.BannedClients.GetBannedClientsIsBanned(clientId);
            Assert.That(getIsClientBanned.GetResponseObject(), Is.True);

            var putUnBanClient = lykkeApi.ClientAccount.BannedClients.PutBannedClientsUnBan(clientId);
            getIsClientBanned = lykkeApi.ClientAccount.BannedClients.GetBannedClientsIsBanned(clientId);
            Assert.That(getIsClientBanned.GetResponseObject(), Is.False);
        }
    }

    class PostBannedClientList : BaseTest
    {
        string clientId;

        [SetUp]
        public void CreateClient()
        {
            clientId = lykkeApi.Registration.PostRegistration(new AccountRegistrationModel().GetTestModel()).Account.Id;
        }

        [TearDown]
        public void UnBanClientAtTheEnd()
        {
            if (clientId != null)
                lykkeApi.ClientAccount.BannedClients.PutBannedClientsUnBan(clientId);
        }

        [Test]
        [Category("BannedClients"), Category("ClientAccount"), Category("ServiceAll")]
        public void PostBannedClientListTest()
        {
            //TODO: Divide by 3 tests?
            var postBannedClientsList = lykkeApi.ClientAccount.BannedClients.PostBannedClientsList(new List<string>());
            Assert.That(postBannedClientsList.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(postBannedClientsList.GetResponseObject(), Does.Not.Contain(clientId));

            var clientsList = new List<string>() { clientId };
            postBannedClientsList = lykkeApi.ClientAccount.BannedClients.PostBannedClientsList(clientsList);
            Assert.That(postBannedClientsList.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(postBannedClientsList.GetResponseObject(), Does.Not.Contain(clientId));

            lykkeApi.ClientAccount.BannedClients.PutBannedClientsBan(clientId);

            postBannedClientsList = lykkeApi.ClientAccount.BannedClients.PostBannedClientsList(new List<string>());
            Assert.That(postBannedClientsList.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(postBannedClientsList.GetResponseObject(), Does.Contain(clientId));

            postBannedClientsList = lykkeApi.ClientAccount.BannedClients.PostBannedClientsList(clientsList);
            Assert.That(postBannedClientsList.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(postBannedClientsList.GetResponseObject(), Does.Contain(clientId));
        }
    }

    class GetClientIsBanned : BaseTest
    {
        string clientId;
        string clientIdToBan;

        [SetUp]
        public void CreateClient()
        {
            clientId = lykkeApi.Registration.PostRegistration(new AccountRegistrationModel().GetTestModel()).Account.Id;
            clientIdToBan = lykkeApi.Registration.PostRegistration(new AccountRegistrationModel().GetTestModel()).Account.Id;
        }

        [TearDown]
        public void UnBanClientAtTheEnd()
        {
            if (clientIdToBan != null)
                lykkeApi.ClientAccount.BannedClients.PutBannedClientsUnBan(clientIdToBan);
        }

        [Test]
        [Category("BannedClients"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetClientIsBannedTest()
        {
            var putClientBan = lykkeApi.ClientAccount.BannedClients.PutBannedClientsBan(clientIdToBan);

            var getBannedClient = lykkeApi.ClientAccount.BannedClients.GetBannedClientsIsBanned(clientIdToBan);
            Assert.That(getBannedClient.GetResponseObject(), Is.True);

            var getNotBannedClient = lykkeApi.ClientAccount.BannedClients.GetBannedClientsIsBanned(clientId);
            Assert.That(getNotBannedClient.GetResponseObject(), Is.False);
        }
    }
}
