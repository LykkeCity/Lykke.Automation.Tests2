using System;
using System.Collections.Generic;
using System.Text;

namespace TestsCore.RestRequests.Interfaces
{
    public interface IRequest
    {
        string BaseUrl { get; set; }
        string Resource { get; set; }
        RestSharp.Method Method { get; set; }
        Dictionary<string, string> Headers { get; }
        object JsonBody { get; set; }

        void AddHeader(string name, string value);

        IResponse Execute();
        T Execute<T>() where T : new();
    }
}
