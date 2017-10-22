using LykkeAutomation.TestsCore;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Api
{
    public class RestClientWrapper : RestClient
    {

        public new IRestResponse Execute(IRestRequest request)
        {
            var response = base.Execute(request);
            List<IRestResponse> r;
            BaseTest.responses.TryGetValue(TestContext.CurrentContext.Test.FullName, out r);
            if(r==null)
                r= new List<IRestResponse>();
            r.Add(response);
            BaseTest.responses[TestContext.CurrentContext.Test.FullName] = r;

            return response;
        }

        public RestClientWrapper(string URL) : base(URL)
        { }
    }
}
