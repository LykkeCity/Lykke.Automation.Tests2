﻿using LykkeAutomation.Api.ApiModels.AccountExistModels;
using LykkeAutomation.TestsCore;
using LykkeAutomation.TestsData;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Tests
{
    class AccountExistTests
    {
        public class AccountExistInvalidEmail : BaseTest
        {
            [Test]
            [Category("AccountExist"), Category("All")]
            public void AccountExistInvalidEmailTest()
            {
                string invalidEmail = TestData.GenerateEmail();
                var response = lykkeApi.AccountExist.GetAccountExistResponse(invalidEmail);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code");

                var obj = JObject.Parse(response.Content);
                ValidateScheme(obj.IsValid(apiSchemes.AccountExistSchemes.AuthResponseScheme, out schemesError), schemesError);

                var model = AccountExistModel.ConvertToAccountExistModel(response.Content);
                Assert.That(model.Result.IsEmailRegistered, Is.False, "Email is registered");
                Assert.That(model.Error, Is.Null, "Error is not null");
            }
        }


        public class AccountExistInvalidEmail1 : BaseTest
        {
            [Test]
            [Category("AccountExist"), Category("All")]
            public void AccountExistInvalidEmail1Test()
            {
                string invalidEmail = TestData.GenerateEmail();
                lykkeApi.AccountExist.GetAccountExistNew(invalidEmail).Wait();
                //Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code");

               // var obj = JObject.Parse(response.Content);
               // ValidateScheme(obj.IsValid(apiSchemes.AccountExistSchemes.AuthResponseScheme, out schemesError), schemesError);

               // var model = AccountExistModel.ConvertToAccountExistModel(response.Content);
               // Assert.That(model.Result.IsEmailRegistered, Is.False, "Email is registered");
               // Assert.That(model.Error, Is.Null, "Error is not null");
            }
        }
    }
}
