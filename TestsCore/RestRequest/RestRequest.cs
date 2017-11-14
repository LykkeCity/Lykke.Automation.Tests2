using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using RestSharp;
using Newtonsoft.Json;

//TODO: Move code to other files
namespace TestsCore.RestRequest
{
    public interface IResponse
    {
        HttpStatusCode StatusCode { get; set; }
        string Content { get; set; }
        T GetJson<T>();
    }

    public class Response : IResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }

        public T GetJson<T>()
        {
            throw new NotImplementedException();
        }
    }

    public class RestSharpRequestBuilder : IRequestBuilder
    {
        private IRestClient client;
        private IRestRequest request;

        public RestSharpRequestBuilder(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public IRequestBuilder Post(string resourse)
        {
            request = new RestSharp.RestRequest(resourse, Method.POST);
            return this;
        }

        public IRequestBuilder Get(string resourse)
        {
            request = new RestSharp.RestRequest(resourse, Method.GET);
            return this;
        }

        public IRequestBuilder WithHeaders()
        {
            throw new NotImplementedException();
        }

        public IRequestBuilder AddJsonBody(object json)
        {
            request.AddJsonBody(json);
            return this;
        }

        public IRequestBuilder WithBearerToken(string token)
        {
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));
            return this;
        }

        public IResponse Execute()
        {
            var response = client.Execute(request);
            return new Response { StatusCode = response.StatusCode, Content = response.Content };
        }

        public T Execute<T>() where T : new()
        {
            return client.Execute<T>(request).Data;
        }

        public IRequestBuilder AddQueryParameter(string name, object value)
        {
            request.AddParameter(name, value, ParameterType.QueryString);
            return this;
        }

        public IRequestBuilder Accept(string mediaType)
        {
            request.AddHeader("Accept", mediaType);
            return this;
        }

        public IRequestBuilder ContentType(string contentType)
        {
            request.AddHeader("Content-Type", contentType);
            return this;
        }

        public IRequestBuilder WithProxy
        {
            get
            {
                client.Proxy = new WebProxy("127.0.0.1", 8888);
                return this;
            }
        }
    }

    public interface IRequestBuilder
    {
        IRequestBuilder Post(string resourse);
        IRequestBuilder Get(string resourse);
        IRequestBuilder WithHeaders();
        IRequestBuilder AddJsonBody(object json);
        IRequestBuilder AddQueryParameter(string paramName, object paramValue);
        IRequestBuilder WithBearerToken(string token);
        IRequestBuilder WithProxy { get; }
        IRequestBuilder Accept(string mediaType);
        IRequestBuilder ContentType(string contentType);
        IResponse Execute();
        T Execute<T>() where T : new();
    }



    public static class Request
    {
        public static IRequestBuilder For(string baseUrl)
        {
            return new RestSharpRequestBuilder(baseUrl);
        }
    }
}
