using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestsCore.RestRequests.Interfaces;
using Newtonsoft.Json;
using System.Linq;
using LykkeAutomation.TestsCore;
using NUnit.Framework;

namespace TestsCore.RestRequests.RestSharpRequest
{
    public class RestSharpRequestBuilder : IRequestBuilder
    {
        private IRestClient client;
        private IRestRequest request;

        public RestSharpRequestBuilder(string baseUrl)
        {
            client = new RestClient(baseUrl);
#if DEBUG
            client.Proxy = new WebProxy("127.0.0.1", 8888);
#endif
        }

        #region Methods
        public IRequestBuilder Post(string resourse)
        {
            request = new RestRequest(resourse, Method.POST);
            return this;
        }

        public IRequestBuilder Get(string resourse)
        {
            request = new RestRequest(resourse, Method.GET);
            return this;
        }
        #endregion

        #region Client
        public IResponse Execute()
        {
            var response = client.Execute(request);
            Log(response);
            return new Response { StatusCode = response.StatusCode, Content = response.Content };
        }

        public T Execute<T>() where T : new()
        {
            var response = client.Execute<T>(request);
            Log(response);
            return response.Data;
        }

        public IRequestBuilder WithProxy
        {
            get
            {
                client.Proxy = new WebProxy("127.0.0.1", 8888);
                return this;
            }
        }
        #endregion

        #region Request
        public IRequestBuilder WithHeaders()
        {
            throw new NotImplementedException();
        }

        public IRequestBuilder WithBearerToken(string token)
        {
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            return this;
        }

        public IRequestBuilder AddJsonBody(object json)
        {
            string jsonStr = JsonConvert.SerializeObject(json);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", jsonStr, "application/json", ParameterType.RequestBody);
            return this;
        }

        public IRequestBuilder AddQueryParameter(string name, object value)
        {
            request.AddParameter(name, value, ParameterType.QueryString);
            return this;
        }

        public IRequestBuilder ContentType(string contentType)
        {
            request.AddHeader("Content-Type", contentType);
            return this;
        }

        public IRequestBuilder Accept(string mediaType)
        {
            request.AddHeader("Accept", mediaType);
            return this;
        }
        #endregion
        #region Private methods
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

            AllureReport.GetInstance().AddAttachment(TestContext.CurrentContext.Test.FullName,
                Encoding.UTF8.GetBytes(attachContext.ToString()), attachName, "application/json");
        }
        #endregion
    }
}
