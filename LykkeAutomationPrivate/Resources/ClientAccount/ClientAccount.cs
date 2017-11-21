using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.RestRequests;
using LykkeAutomationPrivate.Models.ClientAccount.Models;

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
    }
}
