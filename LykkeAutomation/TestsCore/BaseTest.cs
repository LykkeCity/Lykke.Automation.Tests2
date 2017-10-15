using LykkeAutomation.Api;
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
        public static Dictionary<string, List<IRestResponse>> responses = new Dictionary<string, List<IRestResponse>>();

        public static string RequestInfo(IRestRequest request)
        {
            string parameters = "";
            request?.Parameters.ForEach(p => parameters += $"{p.Name}: {p.Value}\r\n");
            var info = $"\r\nrequestInfo: {request?.Method}\r\n{parameters}resource: {request?.Resource}";
            return info;
        }

        public static string ResponseInfo(IRestResponse response)
        {
            string headers = "";
            response?.Headers.ToList().ForEach(h => headers += $"{h.Name}: {h.Value}\r\n");
            var info = $"\r\nresponseInfo\r\nStatusCode: {response?.StatusCode}\r\n{headers}Content: \r\n{response?.Content}";
            return info;
        }

        [SetUp]
        public void SetUp()
        {
            lykkeApi = new LykkeApi();
            Console.WriteLine("SetUp");
        }


        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
            //we can do it only in case if test fails. Discuss to test team
            Console.WriteLine("Whole Test API log");
            List<IRestResponse> logs = new List<IRestResponse>();
            responses.TryGetValue(TestContext.CurrentContext.Test.FullName, out logs);
            logs?.ForEach(l => 
            {
                Console.WriteLine(RequestInfo(l.Request));
                Console.WriteLine(ResponseInfo(l));
                Console.WriteLine("--------------------");
            });
            responses.Remove(TestContext.CurrentContext.Test.FullName);
        }

    }
}
