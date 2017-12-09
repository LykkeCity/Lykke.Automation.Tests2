using System;
using System.Collections.Generic;
using System.Text;
using LykkeAutomationPrivate.Models.ClientAccount.Models;
using TestsCore.RestRequests.Interfaces;

namespace LykkeAutomationPrivate.Resources.ClientAccountResource
{
    public class ClientAccountInformationResource : ClientAccountBase
    {
        public IResponse<ClientAccountInformation> GetClientAccountInformation(string id)
        {
            return Request.Get("/api/ClientAccountInformation").AddQueryParameter("id", id)
                .Build().Execute<ClientAccountInformation>();
        }
    }
}
