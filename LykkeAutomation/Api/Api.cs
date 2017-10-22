using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace LykkeAutomation.Api
{
    public abstract class Api
    {

        protected RestRequest request;
        protected IRestResponse response;
        protected string BaseUri = "https://api-test.lykkex.net/api";

        public List<IRestResponse> responses = new List<IRestResponse>();

        protected RestClientWrapper client;

        public Api(string BaseUri)
        {
            this.BaseUri = BaseUri;
            client = new RestClientWrapper(BaseUri);
        }

        public Api()
        {
            client = new RestClientWrapper(BaseUri);
        }
        
    }
}
