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
        string userId;

        [OneTimeSetUp]
        public void CreateUser()
        {
            var client = new AccountRegistrationModel().GetTestModel();
            var registeredclient = lykkeApi.Registration.PostRegistration(client);
            userId = registeredclient.Account.Id;
            lykkeApi.ClientAccount.Wallets.PostClientAccountInformationsetPIN(userId, "1111");            
        }

        [Test]
        [Category("Wallets"), Category("ClientAccount"), Category("ServiceAll")]
        public void PostCreateWallet()
        {
            CreateWalletRequest createWalletRequest = new CreateWalletRequest().GetTestModel(userId);
            var postWalletPesp = lykkeApi.ClientAccount.Wallets.PostCreateWallet(createWalletRequest);
            var wallet = postWalletPesp.GetJson<WalletDto>();

            Assert.That(wallet.Id, Is.Not.Null);
            Assert.That(wallet.Type, Is.EqualTo(createWalletRequest.Type.ToSerializedValue()));
            Assert.That(wallet.Name, Is.EqualTo(createWalletRequest.Name));
            Assert.That(wallet.Description, Is.EqualTo(createWalletRequest.Description));
        }

        [TestCase("5000000-aaaa-bbbb-cccc-5555aaa111000")]
        [TestCase("oloasdakj jashdasdjal asdjuasdasa")]
        [TestCase("")]
        [TestCase(null)]
        [Category("Wallets"), Category("ClientAccount"), Category("ServiceAll")]
        public void PostCreateWalletClientId(string _userId)
        {
            CreateWalletRequest createWalletRequest = new CreateWalletRequest().GetTestModel(_userId);
            var postWalletPesp = lykkeApi.ClientAccount.Wallets.PostCreateWallet(createWalletRequest);

            Assert.That(postWalletPesp.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
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
        [Category("Wallets"), Category("ClientAccount"), Category("ServiceAll")]
        public HttpStatusCode PostCreateWalletType(object _walletType)
        {
            var clientAccountUrl = lykkeApi.ClientAccount.ServiseUrl;
            var walletResponse = Requests.For(clientAccountUrl).Post("/api/Wallets")
                .AddJsonBody(new CreateWalletRequestMock
                {
                    ClientId = userId,
                    Name = "Some test name",
                    Type = _walletType,
                    Description = "Some test description"
                })
                .Build().Execute();

            return walletResponse.StatusCode;
        }

        [TestCase("Some long-long-long maybe or not name...", ExpectedResult = HttpStatusCode.OK)]
        [TestCase("N", ExpectedResult = HttpStatusCode.OK)]
        [TestCase("", ExpectedResult = HttpStatusCode.BadRequest)]
        [TestCase(null, ExpectedResult = HttpStatusCode.BadRequest)]
        [Category("Wallets"), Category("ClientAccount"), Category("ServiceAll")]
        public HttpStatusCode PostCreateWalletName(string _walletName)
        {
            CreateWalletRequest createWalletRequest = new CreateWalletRequest().GetTestModel(userId);
            createWalletRequest.Name = _walletName;
            var postWalletPesp = lykkeApi.ClientAccount.Wallets.PostCreateWallet(createWalletRequest);

            return postWalletPesp.StatusCode;
        }

        [TestCase("Some long-long-long maybe or not description", ExpectedResult = HttpStatusCode.OK)]
        [TestCase("", ExpectedResult = HttpStatusCode.OK)]
        [Category("Wallets"), Category("ClientAccount"), Category("ServiceAll")]
        public HttpStatusCode PostCreateWalletDescription(string _walletDescription)
        {
            CreateWalletRequest createWalletRequest = new CreateWalletRequest().GetTestModel(userId);
            createWalletRequest.Description = _walletDescription;
            
            var postWalletPesp = lykkeApi.ClientAccount.Wallets.PostCreateWallet(createWalletRequest);

            return postWalletPesp.StatusCode;
        }

        [Test]
        [Category("Wallets"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetWallet()
        {
            var walletToCreate = new CreateWalletRequest().GetTestModel(userId);
            var createdWalet = lykkeApi.ClientAccount.Wallets.PostCreateWallet(walletToCreate).GetJson<WalletDto>();

            var getWalletById = lykkeApi.ClientAccount.Wallets.GetWalletById(createdWalet.Id);

            Assert.That(getWalletById.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var recievedWallet = getWalletById.GetJson<WalletDto>();
            Assert.That(recievedWallet.Id, Is.EqualTo(createdWalet.Id));
            Assert.That(recievedWallet.Name, Is.EqualTo(createdWalet.Name));
            Assert.That(recievedWallet.Type, Is.EqualTo(createdWalet.Type));
            Assert.That(recievedWallet.Description, Is.EqualTo(createdWalet.Description));
        }

        [Test]
        [Category("Wallets"), Category("ClientAccount"), Category("ServiceAll")]
        public void DeleteWallet()
        {
            var walletToCreate = new CreateWalletRequest().GetTestModel(userId);
            var createdWalet = lykkeApi.ClientAccount.Wallets.PostCreateWallet(walletToCreate).GetJson<WalletDto>();

            var deleteWalletById = lykkeApi.ClientAccount.Wallets.DeleteWalletById(createdWalet.Id);
            Assert.That(deleteWalletById.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var getWalletById = lykkeApi.ClientAccount.Wallets.GetWalletById(createdWalet.Id);
            Assert.That(getWalletById.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        [Category("Wallets"), Category("ClientAccount"), Category("ServiceAll")]
        public void PutWallet()
        {
            var walletToCreate = new CreateWalletRequest().GetTestModel(userId);
            var createdWalet = lykkeApi.ClientAccount.Wallets.PostCreateWallet(walletToCreate).GetJson<WalletDto>();

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
        [Category("Wallets"), Category("ClientAccount"), Category("ServiceAll")]
        public void GetWalletsForClient()
        {
            //create new client
            var client = new AccountRegistrationModel().GetTestModel();
            var registeredclient = lykkeApi.Registration.PostRegistration(client);
            var userId = registeredclient.Account.Id;
            lykkeApi.ClientAccount.Wallets.PostClientAccountInformationsetPIN(userId, "1111");

            //Create 3 wallets
            var createdWalet1 = lykkeApi.ClientAccount.Wallets.PostCreateWallet(new CreateWalletRequest().GetTestModel(userId)).GetJson<WalletDto>();
            var createdWalet2 = lykkeApi.ClientAccount.Wallets.PostCreateWallet(new CreateWalletRequest().GetTestModel(userId)).GetJson<WalletDto>();
            var createdWalet3 = lykkeApi.ClientAccount.Wallets.PostCreateWallet(new CreateWalletRequest().GetTestModel(userId)).GetJson<WalletDto>();

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
