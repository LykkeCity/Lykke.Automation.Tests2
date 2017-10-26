﻿using LykkeAutomation.Api.ApiModels.AccountExistModels;
using LykkeAutomation.TestCore;
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
            [Parallelizable]
            [Category("AccountExist"), Category("All")]
            public void AccountExistInvalidEmailTest()
            {
                string invalidEmail = TestData.GenerateEmail();

                TestLog.WriteStep("GetAccountExistResponse");
                var response = lykkeApi.AccountExist.GetAccountExistResponse(invalidEmail);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code");

                TestLog.WriteStep("ValidateScheme");
                var obj = JObject.Parse(response.ContentJson);
                ValidateScheme(obj.IsValid(apiSchemes.AccountExistSchemes.AuthResponseScheme, out schemesError), schemesError);

                TestLog.WriteStep("ValidateModel");
                var model = AccountExistModel.ConvertToAccountExistModel(response.ContentJson);
                Assert.That(model.Result.IsEmailRegistered, Is.False, "Email is registered");
                Assert.That(model.Error, Is.Null, "Error is not null");
            }
        }
    }
}
