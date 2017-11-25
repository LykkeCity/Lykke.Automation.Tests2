using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.RestRequests.Interfaces;
using LykkeAutomationPrivate.Models.ClientAccount.Models;
using System.Linq;

namespace LykkeAutomationPrivate.Resources.ClientAccountResource
{
    public class BannedClients : ClientAccount
    {
        public IResponse PutBannedClientsBan(string clientId)
        {
            return Request.Put($"/api/BannedClients/ban/{clientId}").Build().Execute();
        }

        public IResponse PutBannedClientsUnBan(string clientId)
        {
            return Request.Put($"/api/BannedClients/unban/{clientId}").Build().Execute();
        }

        public IResponse PostBannedClientsList(IList<string> clients)
        {
            var request = Request.Post("/api/BannedClients/list");
            if (clients != null && clients.Any())
                request.AddJsonBody(clients);

            return request.Build().Execute();
        }

        public IResponse GetBannedClientsIsBanned(string clientId)
        {
            return Request.Get($"/api/BannedClients/isBanned/{clientId}").Build().Execute();
        }
    }
}
