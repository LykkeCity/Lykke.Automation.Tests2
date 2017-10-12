using LykkeAutomation.TestsCore;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Tests.PersonalData
{
    class PersonalDataResourceTests
    {

        public class PersonalDataInvalidToken : BaseTest
        {
            [Test]
            [Category("PersonalData"), Category("All")]
            public void PersonalDataInvalidTokenTest()
            {
                var invalidToken = "invalidToken";
                var response = lykkeApi.PersonalData.GetPersonalDataResponse(invalidToken);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), $"Invalid status code;\n {RequestInfo(response.Request)}, \n {ResponseInfo(response)}");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.False, $"Invalid response content \n {RequestInfo(response.Request)}, \n {ResponseInfo(response)}");
            }
        }

        public class PersonalDataEmptyToken : BaseTest
        {
            [Test]
            [Category("PersonalData"), Category("All")]
            public void PersonalDataEmptyTokenTest()
            {
                var emptyToken = "";
                var response = lykkeApi.PersonalData.GetPersonalDataResponse(emptyToken);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.True, "Invalid response content");
            }
        }
    }
}
