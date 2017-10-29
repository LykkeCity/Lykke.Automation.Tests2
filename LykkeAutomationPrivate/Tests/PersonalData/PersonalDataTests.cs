using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LykkeAutomationPrivate.Tests.PersonalData
{
    class PersonalDataTests
    {
        public class Test1 : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            public void Test1Test()
            {
                var test = lykkeApi.PersonalData.GetPersonalDataModel("test_6f78f87f06@gmail.com");
                Assert.That(test.Email, Is.EqualTo("test_6f78f87f06@gmail.com"));
            }
        }
    }
}
