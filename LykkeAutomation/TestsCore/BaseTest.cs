﻿using LykkeAutomation.Api;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.TestsCore
{
    class BaseTest
    {
        public LykkeApi lykkeApi;
        public ApiSchemes apiSchemes;
        public IList<string> schemesError;

        public static Dictionary<string, List<HttpResponseMessageWrapper>> responses ;

        public static string RequestInfoOld(IRestRequest request)
        {
            string parameters = "";
            request?.Parameters.ForEach(p => parameters += $"{p.Name}: {p.Value}\r\n");
            var info = $"\r\nrequestInfo: {request?.Method}\r\n{parameters}resource: {request?.Resource}";
            return info;
        }

        public static string ResponseInfoOld(IRestResponse response)
        {
            string headers = "";
            response?.Headers.ToList().ForEach(h => headers += $"{h.Name}: {h.Value}\r\n");
            var info = $"\r\nresponseInfo\r\nStatusCode: {response?.StatusCode}\r\n{headers}Content: \r\n{response?.Content}";
            return info;
        }

        public static string RequestInfo(HttpResponseMessageWrapper response)
        {
            string parameters = "";
            response?.Request.Properties.ToList().ForEach(p => parameters += $"{p.Key}: {p.Value}\r\n");
            string headers = "";
            response?.Request.Headers.ToList().ForEach(h => headers += $"{h.Key}: {h.Value.ElementAt(0)}\r\n");
            var info = $"\r\nrequestInfo: {response?.Request?.Method}\r\n{headers}resource: {response?.Request?.RequestUri}\r\n{response?.Request.ContentJson}";
            return info;
        }

        public static string ResponseInfo(HttpResponseMessageWrapper response)
        {
            string headers = "";
            response?.Headers.ToList().ForEach(h => headers += $"{h.Key}: {h.Value.ElementAt(0)}\r\n");
            var info = $"\r\nresponseInfo\r\nStatusCode: {response?.StatusCode}\r\n{headers}Content: \r\n{response?.ContentJson}";
            return info;
        }

        public static void ValidateScheme(bool valid, IList<string> errors)
        {
            if (!valid)
            {
                errors.ToList().ForEach(e => Console.WriteLine(e));
                Assert.Fail("Scheme not valid");
            }
        }

        [SetUp]
        public void SetUp()
        {
            responses = new Dictionary<string, List<HttpResponseMessageWrapper>>();
            lykkeApi = new LykkeApi();
            apiSchemes = new ApiSchemes();
            schemesError = new List<string>();
            Console.WriteLine("SetUp");
        }


        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
            //we can do it only in case if test fails. Discuss to test team
            Console.WriteLine("Whole Test API log");
            List<HttpResponseMessageWrapper> logs = new List<HttpResponseMessageWrapper>();
            responses.TryGetValue(TestContext.CurrentContext.Test.FullName, out logs);
            logs?.ForEach(l => 
            {
                Console.WriteLine(RequestInfo(l));
                Console.WriteLine(ResponseInfo(l));
                Console.WriteLine("--------------------");
            });
            responses.Remove(TestContext.CurrentContext.Test.FullName);
        }

    }
}
