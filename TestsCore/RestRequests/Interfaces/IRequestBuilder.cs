using System;
using System.Collections.Generic;
using System.Text;

namespace TestsCore.RestRequests.Interfaces
{
    public interface IRequestBuilder
    {
        IRequestBuilder Post(string resourse);
        IRequestBuilder Get(string resourse);

        IRequestBuilder WithHeaders();
        IRequestBuilder AddJsonBody(object json);
        IRequestBuilder AddQueryParameter(string paramName, object paramValue);
        IRequestBuilder WithBearerToken(string token);
        //IRequestBuilder WithProxy { get; }
        IRequestBuilder Accept(string mediaType);
        IRequestBuilder ContentType(string contentType);

        IRequest Build();
    }
}
