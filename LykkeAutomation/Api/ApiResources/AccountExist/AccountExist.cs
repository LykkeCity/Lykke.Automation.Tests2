using LykkeAutomation.Api.ApiModels.AccountExistModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Api.ApiResources.AccountExist
{
    public class AccountExist : Api
    {

        private string resource = "/AccountExist";

        public IRestResponse GetAccountExistResponse(string email)
        {
            var request = new RestRequest(resource, Method.GET);
            request.AddQueryParameter("email", email);
            var response = client.Execute(request);
            return response;
        }

        public AccountExistModel GetAccountExistResponseModel(string email) => 
            JsonConvert.DeserializeObject<AccountExistModel>(GetAccountExistResponse(email)?.Content);

        public async Task GetAccountExistNew(string email)
        {
            var client = new HttpClientWrapper();
            client.DefaultRequestHeaders.Accept.Clear(); 
            var stringTask = client.GetAsync(BaseUri + resource + $"?email={email}");

            //var msg = await stringTask;
            /*string text = await msg.Content.ReadAsStringAsync(); //тут контент
            Console.Write(msg);
            Console.WriteLine(msg.Content);
            //Console.WriteLine(text);
            Console.WriteLine(msg.RequestMessage); // тут запрос, все хорошо
            Console.WriteLine(msg.RequestMessage.RequestUri);
            Console.WriteLine(msg.RequestMessage.Content);
            */
        }
    }
}
