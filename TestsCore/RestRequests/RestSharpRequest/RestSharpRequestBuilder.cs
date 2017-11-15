using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestsCore.RestRequests.Interfaces;

namespace TestsCore.RestRequests.RestSharpRequest
{
    public class RestSharpRequestBuilder : IRequestBuilder
    {
        private IRestClient client;
        private IRestRequest request;

        public RestSharpRequestBuilder(string baseUrl)
        {
            client = new RestClient(baseUrl);
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
            return new Response { StatusCode = response.StatusCode, Content = response.Content };
        }

        public T Execute<T>() where T : new()
        {
            return client.Execute<T>(request).Data;
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
            request.AddJsonBody(json);
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
    }
}
