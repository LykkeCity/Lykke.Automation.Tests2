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
        private RestSharpRequest request;

        public RestSharpRequestBuilder(string baseUrl)
        {
            request = new RestSharpRequest(baseUrl);
        }

        public IRequest Build()
        {
            return request;
        }

        #region Methods
        public IRequestBuilder Post(string resourse)
        {
            request.Method = Method.POST;
            request.Resource = resourse;
            return this;
        }

        public IRequestBuilder Get(string resourse)
        {
            request.Method = Method.GET;
            request.Resource = resourse;
            return this;
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
            request.JsonBody = json;
            return this;
        }

        public IRequestBuilder AddQueryParameter(string name, object value)
        {
            throw new NotImplementedException();
            //request2.AddParameter(name, value, ParameterType.QueryString);
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
