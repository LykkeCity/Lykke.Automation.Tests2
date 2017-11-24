using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.RestRequests;
using NUnit.Framework;
using LykkeAutomationPrivate.Tests;
using LykkeAutomationPrivate.Models.Registration.Models;
using System.Net;
using LykkeAutomationPrivate.DataGenerators;
using LykkeAutomationPrivate.Models.ClientAccount.Models;
using System.Linq;

namespace LykkeAutomation.Tests.ClientAccount
{
    class WalletResourceTests : BaseTest
    {
        readonly string clientAccountUrl = "http://client-account.lykke-service.svc.cluster.local";

        string userId;
        string walletName = "Some wallet name";
        string walletDescription = "Some wallet description";
        WalletType walletType = WalletType.Trusted;

        [OneTimeSetUp]
        public void CreateUser()
        {
            var client = new AccountRegistrationModel().GetTestModel();
            var registeredclient = lykkeApi.Registration.PostRegistration(client);
            userId = registeredclient.Account.Id;
            lykkeApi.ClientAccount.Wallets.PostClientAccountInformationsetPIN(userId, "1111");            
        }

        [Test]
        [Category("Wallet"), Category("ClientAccount"), Category("ServiceAll")]
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
        [Category("Wallet"), Category("ClientAccount"), Category("ServiceAll")]
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
        [Category("Wallet"), Category("ClientAccount"), Category("ServiceAll")]
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
        [Category("Wallet"), Category("ClientAccount"), Category("ServiceAll")]
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
        [Category("Wallet"), Category("ClientAccount"), Category("ServiceAll")]
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

        [Test]
        [Category("Wallet"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetWallet()
        {
            var walletToCreate = new CreateWalletRequest().GetTestModel(userId);
            var createdWalet = lykkeApi.ClientAccount.Wallets.PostCreateWallet(walletToCreate);

            var getWalletById = lykkeApi.ClientAccount.Wallets.GetWalletById(createdWalet.Id);

            Assert.That(getWalletById.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var recievedWallet = getWalletById.GetJson<WalletDto>();
            Assert.That(recievedWallet.Id, Is.EqualTo(createdWalet.Id));
            Assert.That(recievedWallet.Name, Is.EqualTo(createdWalet.Name));
            Assert.That(recievedWallet.Type, Is.EqualTo(createdWalet.Type));
            Assert.That(recievedWallet.Description, Is.EqualTo(createdWalet.Description));
        }

        [Test]
        [Category("Wallet"), Category("ClientAccount"), Category("ServiceAll")]
        public void DeleteWallet()
        {
            var walletToCreate = new CreateWalletRequest().GetTestModel(userId);
            var createdWalet = lykkeApi.ClientAccount.Wallets.PostCreateWallet(walletToCreate);

            var deleteWalletById = lykkeApi.ClientAccount.Wallets.DeleteWalletById(createdWalet.Id);
            Assert.That(deleteWalletById.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var getWalletById = lykkeApi.ClientAccount.Wallets.GetWalletById(createdWalet.Id);
            Assert.That(getWalletById.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        [Category("Wallet"), Category("ClientAccount"), Category("ServiceAll")]
        public void PutWallet()
        {
            var walletToCreate = new CreateWalletRequest().GetTestModel(userId);
            var createdWalet = lykkeApi.ClientAccount.Wallets.PostCreateWallet(walletToCreate);

            var newWallet = new ModifyWalletRequest().GetTestModel();

            var putWalletById = lykkeApi.ClientAccount.Wallets.PutWalletById(createdWalet.Id, newWallet);
            Assert.That(putWalletById.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var changedWallet = lykkeApi.ClientAccount.Wallets.GetWalletById(createdWalet.Id).GetJson<WalletDto>();
            //Have not to change
            Assert.That(changedWallet.Id, Is.EqualTo(createdWalet.Id));
            Assert.That(changedWallet.Type, Is.EqualTo(createdWalet.Type));
            //Have to be changed
            Assert.That(changedWallet.Name, Is.EqualTo(newWallet.Name));
            Assert.That(changedWallet.Description, Is.EqualTo(newWallet.Description));
        }

        [Test]
        [Category("Wallet"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetWalletsForClient()
        {
            //create new client
            var client = new AccountRegistrationModel().GetTestModel();
            var registeredclient = lykkeApi.Registration.PostRegistration(client);
            var userId = registeredclient.Account.Id;
            lykkeApi.ClientAccount.Wallets.PostClientAccountInformationsetPIN(userId, "1111");

            //Create 3 wallets
            var createdWalet1 = lykkeApi.ClientAccount.Wallets.PostCreateWallet(new CreateWalletRequest().GetTestModel(userId));
            var createdWalet2 = lykkeApi.ClientAccount.Wallets.PostCreateWallet(new CreateWalletRequest().GetTestModel(userId));
            var createdWalet3 = lykkeApi.ClientAccount.Wallets.PostCreateWallet(new CreateWalletRequest().GetTestModel(userId));

            var getWalletsForClientById = lykkeApi.ClientAccount.Wallets.GetWalletsForClientById(userId).GetJson<List<WalletDto>>();

            Assert.That(getWalletsForClientById.Count, Is.EqualTo(4));
            Assert.That(getWalletsForClientById.Select(w => w.Id),
                Does.Contain(createdWalet1.Id).And.Contain(createdWalet2.Id).And.Contain(createdWalet3.Id));
            Assert.That(getWalletsForClientById.Select(w => w.Name),
                Does.Contain(createdWalet1.Name).And.Contain(createdWalet2.Name).And.Contain(createdWalet3.Name));
            Assert.That(getWalletsForClientById.Select(w => w.Type),
                Does.Contain(createdWalet1.Type).And.Contain(createdWalet2.Type).And.Contain(createdWalet3.Type));
            Assert.That(getWalletsForClientById.Select(w => w.Description),
                Does.Contain(createdWalet1.Description).And.Contain(createdWalet2.Description).And.Contain(createdWalet3.Description));
        }
    }
}
