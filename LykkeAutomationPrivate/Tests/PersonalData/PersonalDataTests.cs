using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LykkeAutomationPrivate.Tests.PersonalData
{
    class PersonalDataTests
    {
        public class GetPersonalDataByEmail : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            public void GetPersonalDataByEmailTest()
            {
                var test = lykkeApi.PersonalData.GetPersonalDataModel("test_6f78f87f06@gmail.com");
                Assert.That(test.Email, Is.EqualTo("test_6f78f87f06@gmail.com"));
            }
        }

        public class GetPersonalDataList: BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            public void GetPersonalDataListTest()
            {
                var list = lykkeApi.PersonalData.GetPersonalDataListModel();
                Assert.That(list.Count, Is.GreaterThan(0), "List count is not as expected");
            }
        }

        public class GetPersonalDataById : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            public void GetPersonalDataByIdTest()
            {
                var first = lykkeApi.PersonalData.GetPersonalDataListModel()[0];
                var finded = lykkeApi.PersonalData.GetPersonalDataModelById(first.Id);
                Assert.That(first.Email, Is.EqualTo(finded.Email), "Finded email for personal data is  not equal");
                Assert.That(first.Id, Is.EqualTo(finded.Id), "Finded ID for personal data is  not equal");
                Assert.That(first.FirstName, Is.EqualTo(finded.FirstName), "Finded First Name for personal data is  not equal");
                Assert.That(first.Country, Is.EqualTo(finded.Country), "Finded Country for personal data is  not equal");
                //Assert.That(first.Regitered, Is.EqualTo(finded.Regitered), "Finded Registered for personal data is  not equal");
            }
        }
    }
}
