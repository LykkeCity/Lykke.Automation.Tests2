using LykkeAutomationPrivate.DataGenerators;
using LykkeAutomationPrivate.Models.Registration.Models;
using NUnit.Framework;
using System.Net;
using System;
using System.Collections.Generic;
using System.Text;


namespace LykkeAutomationPrivate.Tests.ClientAccount
{
    class DeleteClientAccount : BaseTest
    {
        string clientId;
        string clientEmail;

        [SetUp]
        public void CreateClient()
        {
            var postRegistration = lykkeApi.Registration.PostRegistration(new AccountRegistrationModel().GetTestModel());
            clientId = postRegistration.Account.Id;
            clientEmail = postRegistration.Account.Email;
        }

        [Test]
        [Category("ClientAccountResource"), Category("ClientAccount"), Category("ServiceAll")]
        public void DeleteClientAccountTest()
        {
            var deleteClient = lykkeApi.ClientAccount.ClientAccount.DeleteClientAccount(clientId);
            Assert.That(deleteClient.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            //delete again
            deleteClient = lykkeApi.ClientAccount.ClientAccount.DeleteClientAccount(clientId);
            Assert.That(deleteClient.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

            //check exist
            var getAccountExist = lykkeApi.ClientAccount.AccountExist.GetAccountExist(clientEmail);
            Assert.That(getAccountExist.GetResponseObject().IsClientAccountExisting, Is.False);
        }
    }
}
