using LykkeAutomation.TestsCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TestsCore.ApiRestClient
{
    public class RestApi
    {
        protected RestClientWrapper client;
        private string BaseURL = "https://payapi-test.lykkex.net/api";

        public RestApi()
        {
            client = new RestClientWrapper(BaseURL);
            SetLocalProxy();
        }

        public RestApi(string BaseURL)
        {
            this.BaseURL = BaseURL;
            client = new RestClientWrapper(BaseURL);
            SetLocalProxy();
        }

        private void SetLocalProxy()
        {
            if (Environment.OSVersion.ToString().ToLower().Contains("windows"))
                client.Proxy = new WebProxy("127.0.0.1", 8888);
        }
    }
}
