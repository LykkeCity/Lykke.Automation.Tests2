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
                Assert.That(first.FullName, Is.Null, "Finded First Name for personal data is  not equal");
                Assert.That(first.Country, Is.EqualTo(finded.Country), "Finded Country for personal data is  not equal");
                //Assert.That(first.Regitered, Is.EqualTo(finded.Regitered), "Finded Registered for personal data is  not equal");
            }
        }

        public class GetFullPersonalDataById : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            public void GetFullPersonalDataByIdTest()
            {
                var first = lykkeApi.PersonalData.GetPersonalDataListModel()[0];
                var finded = lykkeApi.PersonalData.GetFullPersonalDataModelById(first.Id);
                Assert.That(first.Email, Is.EqualTo(finded.Email), "Finded email for personal data is  not equal");
                Assert.That(first.Id, Is.EqualTo(finded.Id), "Finded ID for personal data is  not equal");
                Assert.That(first.FirstName, Is.EqualTo(finded.FirstName), "Finded First Name for personal data is  not equal");
                Assert.That(finded.FullName, Is.Not.Null, "Finded Full Name for personal data is  not equal");
                Assert.That(first.Country, Is.EqualTo(finded.Country), "Finded Country for personal data is  not equal");
                //Assert.That(first.Regitered, Is.EqualTo(finded.Regitered), "Finded Registered for personal data is  not equal");
            }
        }

        public class GetProfilePersonalDataById : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            public void GetProfilePersonalDataByIdTest()
            {
                var first = lykkeApi.PersonalData.GetPersonalDataListModel()[0];
                var finded = lykkeApi.PersonalData.GetProfilePersonalDataModelById(first.Id);
                Assert.That(first.Email, Is.EqualTo(finded.Email), "Finded email for personal data is  not equal");
                Assert.That(first.Address, Is.EqualTo(finded.Address), "Finded ID for personal data is  not equal");
                Assert.That(first.FirstName, Is.EqualTo(finded.FirstName), "Finded First Name for personal data is  not equal");
            }
        }

        public class SearchPersonalDataModel : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            [Description("Search client by part of full name, email or contact phone")]
            public void SearchPersonalDataModelTest()
            {
                var first = lykkeApi.PersonalData.GetPersonalDataListModel().Find(data =>  (data.Email?.Length > 0) );
                var findedByFullName = lykkeApi.PersonalData.GetSearchPersonalDataModel(first.Email.Substring(0, first.Email.Length-2));
                Assert.That(first.Id, Is.EqualTo(findedByFullName.Id), "Id are not equals");

                //search by FullName
                //search by contact phone
                //create a uniq personal data
            }
        }

        public class GetDocumentById : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            [Description("Get document scan by id")]
            public void GetDocumentByIdTest()
            {
                // create pd with document as precondition
                var first = lykkeApi.PersonalData.GetPersonalDataListModel().Find(data => (data.Email?.Length > 0));
                var document = lykkeApi.PersonalData.GetDocumentByIdModel("b92353fd-51ce-4698-8f90-78b3eeaef224");
                //Assert.That(document, Is.Not.Null, "Document is null");
            }
        }

        #region Post
        public class PostPersonalDataList : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            [Description("Post request. Get Personal data list by ids")]
            public void PostPersonalDataListTest()
            {
                
                var list = lykkeApi.PersonalData.GetPersonalDataListModel();
                Random r = new Random();
                int size = r.Next(1, 15);
                string[] array = new string[size];
                for (int i = 0; i < size; i++)
                    array[i] = list[i].Id;
                
                var postList = lykkeApi.PersonalData.PostPersonalDataListByIdModel(array);
                Assert.That(postList.Count, Is.EqualTo(size), "Personal Data list size is not as expected");
            }
        }

        public class FullPostPersonalDataList : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            [Description("Post request. Get Personal Full data list by ids")]
            public void FullPostPersonalDataListTest()
            {

                var list = lykkeApi.PersonalData.GetPersonalDataListModel();
                Random r = new Random();
                int size = r.Next(1, 15);
                string[] array = new string[size];
                for (int i = 0; i < size; i++)
                    array[i] = list[i].Id;

                var postList = lykkeApi.PersonalData.PostFullPersonalDataListByIdModel(array);
                Assert.That(postList.Count, Is.EqualTo(size), "Personal Data list size is not as expected");
            }
        }

        public class PostListExcludedPage : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            [Description("Post request. Get Personal Full data list by ids")]
            public void PostListExcludedPageTest()
            {
                // get test scenario
            }
        }

        public class PostListPage : BaseTest
        {
            [Test]
            [Category("PersonalDataService"), Category("ServiceAll")]
            [Description("Post request. Get Personal Full data list by ids")]
            public void PostListPageTest()
            {
                // get test scenario
            }
        }
        #endregion
    }
}
