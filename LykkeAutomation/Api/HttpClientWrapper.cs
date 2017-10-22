using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Api
{
    class HttpClientWrapper : HttpClient
    {

        public new HttpResponseMessageWrapper GetAsync(string requestUri)
        {
            var rMessage = new HttpResponseMessageWrapper(base.GetAsync(requestUri));
            return rMessage;
        }
/*
        public new Task<HttpResponseMessageWrapper> PostAsync(string requestUri, HttpContent content)
        {
            return base.PostAsync(requestUri, content);
        }

        public new Task<HttpResponseMessageWrapper> DeleteAsync(string requestUri)
        {
            return base.DeleteAsync(requestUri);
        }

        public new Task<HttpResponseMessageWrapper> PutAsync(string requestUri, HttpContent content)
        {
            return base.PutAsync(requestUri, content);
        }*/
    }

    public class HttpResponseMessageWrapper : HttpResponseMessage
    {
        public string ContentJson = "";

        public HttpRequestMessage Request;
        //
        public new HttpContent Content { get; set; }
       
        public new HttpResponseHeaders Headers { get; }
        
        public new bool IsSuccessStatusCode { get; }
        
        public new string ReasonPhrase { get; set; }

        public new HttpRequestMessage RequestMessage { get; set; }

        public new HttpStatusCode StatusCode { get; set; }

        public new Version Version { get; set; }

        public new void Dispose() { base.Dispose(); }

        public new HttpResponseMessage EnsureSuccessStatusCode() { return base.EnsureSuccessStatusCode(); }

        public override string ToString() { return base.ToString(); }

        protected new void Dispose(bool disposing) { base.Dispose(); }


        public async void PerformRequest(Task<HttpResponseMessage> t) {
            var tt = (await t);
            Request = tt.RequestMessage;
        }

        //
        public HttpResponseMessageWrapper(Task<HttpResponseMessage> t)
        {
            this.ContentJson = t.Result.Content.ReadAsStringAsync().Result;
            PerformRequest(t);
        }

        
    }
}
