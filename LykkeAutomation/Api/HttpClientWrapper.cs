using LykkeAutomation.TestCore;
using LykkeAutomation.TestsCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Api
{
    public class HttpClientWrapper : HttpClient
    {
        private string BaseURI = "";

        public new HttpResponseMessageWrapper GetAsync(string requestUri)
        {
            var response = new HttpResponseMessageWrapper(base.GetAsync(BaseURI + requestUri));
            AddToLog(response);
            return response;
        }

        public new HttpResponseMessageWrapper PostAsync(string requestUri, HttpContent content)
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = new HttpResponseMessageWrapper(base.PostAsync(BaseURI + requestUri, content));
            AddToLog(response);
            return response;
        }

        public new HttpResponseMessageWrapper DeleteAsync(string requestUri)
        {
            var response = new HttpResponseMessageWrapper(base.DeleteAsync(BaseURI + requestUri));
            AddToLog(response);
            return response;
        }

        public new HttpResponseMessageWrapper PutAsync(string requestUri, HttpContent content)
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = new HttpResponseMessageWrapper(base.PutAsync(BaseURI + requestUri, content));
            AddToLog(response);
            return response;

        }

        private void AddToLog(HttpResponseMessageWrapper response)
        {
            TestLog.WriteLine(BaseTest.RequestInfo(response));
            TestLog.WriteLine(BaseTest.ResponseInfo(response));
        }

        public HttpClientWrapper()
        {

        }

        public HttpClientWrapper(string baseUri)
        {
            BaseURI = baseUri;
        }
    }

    public class HttpRequestMessageWrapper : HttpRequestMessage
    {
        public string ContentJson { get { return Message.Content?.ReadAsStringAsync().Result == null? "": Message.Content.ReadAsStringAsync().Result; } }
        private HttpRequestMessage Message;

        public new HttpRequestHeaders Headers { get { return Message.Headers; } }

        public HttpRequestMessageWrapper(HttpRequestMessage message)
        {
            Message = message;
            Version = message.Version;
            Method = message.Method;
            RequestUri = message.RequestUri;
        }
    }

    public class HttpResponseMessageWrapper : HttpResponseMessage
    {
        private HttpResponseMessage resultMessage;
        public string ContentJson = "";

        public new HttpResponseHeaders Headers { get { return resultMessage.Headers; } }

        public new bool IsSuccessStatusCode { get { return resultMessage.IsSuccessStatusCode; } }

        public HttpRequestMessageWrapper Request;

        public async void PerformRequest(Task<HttpResponseMessage> t) {
            Request = new HttpRequestMessageWrapper((await t).RequestMessage);
        }

        public HttpResponseMessageWrapper(Task<HttpResponseMessage> t)
        {
            resultMessage = t.Result;
            ContentJson = resultMessage.Content.ReadAsStringAsync().Result;
            PerformRequest(t);
            Content = t.Result.Content;
            ReasonPhrase = t.Result.ReasonPhrase;
            StatusCode = t.Result.StatusCode;
            Version = t.Result.Version;
        }
    }
}
