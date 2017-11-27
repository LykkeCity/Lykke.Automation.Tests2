using System;
using System.Collections.Generic;
using System.Text;
using TestsCore.RestRequests.Interfaces;
using LykkeAutomationPrivate.Models.ClientAccount.Models;

namespace LykkeAutomationPrivate.Resources.ClientAccountResource
{
    public class ClientAccount : ClientAccountBase
    {
        public IResponse DeleteClientAccount(string id)
        {
            return Request.Delete($"/api/ClientAccount/{id}").Build().Execute();
        }

        public IResponse PutClientAccountEmail(string id, string email)
        {
            throw new NotImplementedException();
        }

        public IResponse GetClientAccountTrusted(string id)
        {
            throw new NotImplementedException();
        }

        public IResponse GetUsersCountByPartnerId(string partnerId)
        {
            throw new NotImplementedException();
        }
    }
}
