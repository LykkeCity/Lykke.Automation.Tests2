using LykkeAutomationPrivate.DataGenerators;
using LykkeAutomationPrivate.Models.ClientAccount.Models;
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
        AccountRegistrationModel registration;
        ClientAccountInformationModel account;
        string pin = "1111";

        [OneTimeSetUp]
        public void CreateClient()
        {
            registration = new AccountRegistrationModel().GetTestModel();
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
            Assert.That(accountInformation.PartnerId, Is.Null);
            Assert.That(accountInformation.Phone, Is.EqualTo(registration.ContactPhone));
            Assert.That(accountInformation.Pin, Is.EqualTo(pin));
            Assert.That(accountInformation.Registered, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromMinutes(10)));
        }

        //TODO: Body in GET does not alowed https://msdn.microsoft.com/en-us/library/d4cek6cc%28v=vs.110%29.aspx
        //[Test]
        //[Description("Get clients by ids.")]
        //[Category("ClientAccountInformationResource"), Category("ClientAccount"), Category("ServiceAll")]
        //public void GetClientsByIdsTest()
        //{
        //    var clientAccountIds = new ClientAccountIdsModel()
        //    {
        //        Ids = new List<string>() { account.Id }
        //    };

        //    var getClientsByIds = lykkeApi.ClientAccount.ClientAccountInformation
        //        .GetClientsByIds(clientAccountIds);
        //    Assert.That(getClientsByIds.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        //    var clientsByIds = getClientsByIds.GetResponseObject();
        //}

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
    }
}
