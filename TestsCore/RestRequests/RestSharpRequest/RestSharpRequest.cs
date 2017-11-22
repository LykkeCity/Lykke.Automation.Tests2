using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using TestsCore.RestRequests.Interfaces;
using System.Net;
using Newtonsoft.Json;
using LykkeAutomation.TestsCore;
using System.Linq;
using NUnit.Framework;

namespace TestsCore.RestRequests.RestSharpRequest
{
    public class RestSharpRequest : IRequest
    {
        public string BaseUrl { get; set; }
        public string Resource { get; set; }
        public Method Method { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public object JsonBody { get; set; }

        private IRestClient client;
        private IRestRequest request;

        public RestSharpRequest(string baseUrl)
        {
            BaseUrl = baseUrl;
            Headers = new Dictionary<string, string>();
        }

        public IResponse Execute()
        {
            CreateRestSharp();
            var response = client.Execute(request);
            Log(response);
            return new Response() { StatusCode = response.StatusCode, Content = response.Content };
        }

        public T Execute<T>() where T : new()
        {
            CreateRestSharp();
            var response = client.Execute<T>(request);
            Log(response);
            return response.Data;
        }

        public void AddHeader(string name, string value)
        {
            Headers.Add(name, value);
        }

        private void CreateRestSharp()
        {
            client = new RestClient(BaseUrl);
            if (Environment.OSVersion.ToString().ToLower().Contains("windows"))
                client.Proxy = new WebProxy("127.0.0.1", 8888);

            request = new RestRequest(Resource, Method);

            if (JsonBody != null)
            {
                var settings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
                string jsonStr = JsonConvert.SerializeObject(JsonBody, settings);
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("application/json", jsonStr, "application/json", ParameterType.RequestBody);
            }

            foreach (KeyValuePair<string, string> header in Headers)
            {
                request.AddHeader(header.Key, header.Value);
            }
        }

        private void Log(IRestResponse response)
        {
            var requestBody = response.Request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);

            string attachName = $"{response.Request.Method} {response.Request.Resource}";
            var attachContext = new StringBuilder();
            attachContext.AppendLine($"Executing {response.Request.Method} {response.ResponseUri}");
            if (requestBody != null)
            {
                attachContext.AppendLine($"Content-Type: {requestBody.ContentType}").AppendLine();
                attachContext.AppendLine(requestBody.Value.ToString());
            }
            attachContext.AppendLine().AppendLine();
            attachContext.AppendLine($"Response: {response.StatusCode}");
            attachContext.AppendLine(response.Content);
            TestLog.WriteLine(attachContext.ToString());
           // AllureReport.GetInstance().AddAttachment(TestContext.CurrentContext.Test.FullName,
           //  Encoding.UTF8.GetBytes(attachContext.ToString()), attachName, "application/json");
        }
    }
}
