using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.RestRequests;
using LykkeAutomationPrivate.Models.ClientAccount.Models;
using TestsCore.RestRequests.Interfaces;

namespace LykkeAutomationPrivate.Resources.ClientAccountResource
{
    public class ClientAccount
    {
        private string serviseUrl =
            EnvConfig.Env == Env.Test ? "http://client-account.service.svc.cluster.local" :
            EnvConfig.Env == Env.Dev ? "http://client-account.lykke-service.svc.cluster.local" : 
            throw new Exception("Undefined env");

        public void PostClientAccountInformationsetPIN(string clientId, string pin)
        {
            Requests.For(serviseUrl).Post($"/api/ClientAccountInformation/setPIN/{clientId}/{pin}").Build().Execute();
        }

        public WalletDto PostCreateWallet(CreateWalletRequest wallet)
        {
            return Requests.For(serviseUrl).Post("api/Wallets").AddJsonBody(wallet).Build().Execute<WalletDto>();
        }

        public IResponse GetWalletById(string id)
        {
            return Requests.For(serviseUrl).Get($"/api/Wallets/{id}").Build().Execute();
        }

        public IResponse DeleteWalletById(string id)
        {
            return Requests.For(serviseUrl).Delete($"/api/Wallets/{id}").Build().Execute();
        }

        public IResponse PutWalletById(string id, ModifyWalletRequest modifyWallet)
        {
            return Requests.For(serviseUrl).Put($"/api/Wallets/{id}").AddJsonBody(modifyWallet).Build().Execute();
        }

        public IResponse GetWalletsForClientById(string id)
        {
            return Requests.For(serviseUrl).Get($"api/Wallets/client/{id}").Build().Execute();
        }
    }
}
