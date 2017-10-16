﻿using LykkeAutomation.ApiModels;
using LykkeAutomation.ApiModels.RegistrationModels;
using LykkeAutomation.TestsCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
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

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), $"Invalid status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.False, $"Invalid response content ");
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

        public class PersonalDataValidToken : BaseTest
        {
            [Test]
            [Category("PersonalData"), Category("All")]
            public void PersonalDataValidTokenTest()
            {
                AccountRegistrationModel user = new AccountRegistrationModel();
                var registationResponse = lykkeApi.Registration.PostRegistrationResponse(user);
                Assert.That(registationResponse.Error, Is.Null, "Error is not null");

                var response = lykkeApi.PersonalData.GetPersonalDataResponse(registationResponse.Result.Token);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code");
                Assert.That(string.IsNullOrEmpty(response.Content), Is.False, "Invalid response content");

                JObject responseObject = JObject.Parse(response.Content);
                bool valid = responseObject.IsValid(apiSchemes.PersonalDataSheme.PersonalDataResponseSchema, out schemesError);
                ValidateScheme(valid, schemesError);

                var responseModel = lykkeApi.PersonalData.GetPersonalDataModel(registationResponse.Result.Token);
                Assert.That(responseModel.PersonalData.FullName, Is.EqualTo(user.FullName), "Full Name is not the same");
                Assert.That(responseModel.PersonalData.Email, Is.EqualTo(user.Email), "Email is not the same");
                Assert.That(responseModel.PersonalData.Phone, Is.EqualTo(user.ContactPhone), "Phone is not the same");
            }
        }
    }
}
