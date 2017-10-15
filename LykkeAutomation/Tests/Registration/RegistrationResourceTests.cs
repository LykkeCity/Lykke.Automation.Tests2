﻿using LykkeAutomation.ApiModels;
using LykkeAutomation.TestsCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Tests.Registration
{
    class RegistrationResourceTests
    {

        public class PostRegistrationPositive : BaseTest
        {
            [Test]
            [Category("Registration"), Category("All")]
            public void PostRegistrationPositiveTest()
            {
                AccountRegistrationModel newUser = new AccountRegistrationModel();
                var response = lykkeApi.Registration.PostRegistrationResponse(newUser);
                Assert.That(response.Error, Is.Null, $"Error message not empty {response.Error?.Message}");
                Assert.That(response.Result.PersonalData.FullName, Is.EqualTo(newUser.FullName), "FullName is not the same");
            }
        }
    }
}
