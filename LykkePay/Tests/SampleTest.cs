using LykkeAutomation.TestsCore;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestsCore.TestsData;

namespace LykkePay.Tests
{
    public class SampleTest
    {

        public class RestSharpRequest : BaseTest
        {
            [Test]
            public void RestSharpRequestTest()
            {
                RestClientWrapper client = new RestClientWrapper("https://api-test.lykkex.net/api");
                RestRequest request = new RestRequest("/AccountExist" + $"?email=test@gmail.com", Method.GET);

                var response = client.Execute(request);
            }
        }

        public class RestSharpPostRequest : BaseTest
        {
            [Test]
            public void RestSharpRequestPostTest()
            {
                RestClientWrapper client = new RestClientWrapper("https://api-test.lykkex.net/api");
                RestRequest request = new RestRequest("/AccountExist", Method.POST);
                string json = "{\"a\":\"b\"}";
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;

                var response = client.Execute(request);
            }
        }
    }
}
