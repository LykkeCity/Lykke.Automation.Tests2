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

        //TODO: Body in GET does not alowed https://msdn.microsoft.com/en-us/library/d4cek6cc%28v=vs.110%29.aspx
        //public IResponse<List<ClientAccountInformation>> GetClientsByIds(ClientAccountIdsModel ids)
        //{
        //    return Request.Get("/api/ClientAccountInformation/getClientsByIds").AddJsonBody(ids)
        //        .Build().Execute<List<ClientAccountInformation>>();
        //}

        public IResponse<List<string>> GetClientsByPhone(string phoneNumber)
        {
            return Request.Get($"/api/ClientAccountInformation/getClientsByPhone/{phoneNumber}")
                .Build().Execute<List<string>>();
        }

        public IResponse<bool> GetIsPasswordCorrect(string clientId, string password)
        {
            return Request.Get($"/api/ClientAccountInformation/isPasswordCorrect/{clientId}/{password}")
                .Build().Execute<bool>();
        }
    }
}
