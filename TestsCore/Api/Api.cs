using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net.Http.Headers;

namespace LykkeAutomation.TestsCore
{
    public abstract class Api
    {

        protected RestRequest request;
        protected IRestResponse response;
        protected string BaseUri = "https://api-test.lykkex.net/api";

        public List<IRestResponse> responses = new List<IRestResponse>();

        protected HttpClientWrapper client;
        

        public Api(string BaseUri)
        {
            this.BaseUri = BaseUri;
            client = new HttpClientWrapper(BaseUri);
            client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Api()
        {
            client = new HttpClientWrapper(BaseUri);
            client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }  
    }
}
