using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.TestsCore
{
    public class HttpClientWrapper : HttpClient
    {
        private string BaseURI = "";

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
            TestLog.WriteLine(RequestInfo(response));
            TestLog.WriteLine(ResponseInfo(response));
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
