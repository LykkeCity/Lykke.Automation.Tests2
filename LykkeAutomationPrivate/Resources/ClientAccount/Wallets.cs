﻿using LykkeAutomationPrivate.Models.ClientAccount.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.RestRequests.Interfaces;

namespace LykkeAutomationPrivate.Resources.ClientAccountResource
{
    public class Wallets: ClientAccount
    {
        public void PostClientAccountInformationsetPIN(string clientId, string pin)
        {
            Request.Post($"/api/ClientAccountInformation/setPIN/{clientId}/{pin}").Build().Execute();
        }

        public WalletDto PostCreateWallet(CreateWalletRequest wallet)
        {
            return Request.Post("api/Wallets").AddJsonBody(wallet).Build().Execute<WalletDto>();
        }

        public IResponse GetWalletById(string id)
        {
            return Request.Get($"/api/Wallets/{id}").Build().Execute();
        }

        public IResponse DeleteWalletById(string id)
        {
             return Request.Delete($"/api/Wallets/{id}").Build().Execute();
        }

        public IResponse PutWalletById(string id, ModifyWalletRequest modifyWallet)
        {
            return Request.Put($"/api/Wallets/{id}").AddJsonBody(modifyWallet).Build().Execute();
        }

        public IResponse GetWalletsForClientById(string id)
        {
            return Request.Get($"api/Wallets/client/{id}").Build().Execute();
        }
    }
}
