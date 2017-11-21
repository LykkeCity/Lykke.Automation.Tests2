﻿using LykkeAutomationPrivate.Api;
using LykkeAutomation.TestsCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LykkeAutomationPrivate.Tests
{
    class BaseTest
    {
        public LykkeApi lykkeApi = new LykkeApi();
        public ApiSchemes apiSchemes;
        public IList<string> schemesError;

        public static Dictionary<string, List<HttpResponseMessageWrapper>> responses ;

        #region response info
       

        public static void ValidateScheme(bool valid, IList<string> errors)
        {
            if (!valid)
            {
                errors.ToList().ForEach(e => Console.WriteLine(e));
                Assert.Fail("Scheme not valid");
            }
        }

        public static void AreEqualByJson(object expected, object actual)
        {

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            Assert.That(expectedJson, Is.EqualTo(actualJson),  "Objects are not equals");
        }

        #endregion

        #region before after
        [SetUp]
        public void SetUp()
        {
            var testDescription = TestContext.CurrentContext.Test.Properties["Description"];
            var textDescription = testDescription.Count>0 ? testDescription[0].ToString() : "No Description";
            
            AllureReport.GetInstance().CaseStarted(TestContext.CurrentContext.Test.FullName,
                TestContext.CurrentContext.Test.Name, textDescription);
            responses = new Dictionary<string, List<HttpResponseMessageWrapper>>();
            apiSchemes = new ApiSchemes();
            schemesError = new List<string>();
            TestContext.WriteLine("SetUp");
        }


        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
          
            AllureReport.GetInstance().CaseFinished(TestContext.CurrentContext.Test.FullName,
                TestContext.CurrentContext.Result.Outcome.Status,null);
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var path = TestContext.CurrentContext.WorkDirectory.Remove(TestContext.CurrentContext.WorkDirectory.IndexOf("bin")) + "TestReportHelpers/";
            AllureReport.GetInstance().RunStarted(path);
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AllureReport.GetInstance().RunFinished();
        }

    #endregion

    #region allure helpers

        public static void Step(string name, Action action)
        {
            Exception ex = null;
            try
            {
                AllureReport.GetInstance().StepStarted(TestContext.CurrentContext.Test.FullName,
                    name);
                TestLog.WriteLine($"Step: {name}");
                action();
            }catch(Exception e) {
                ex = e;
            }
            finally
            {
                AllureReport.GetInstance().StepFinished(TestContext.CurrentContext.Test.FullName,
             TestContext.CurrentContext.Result.Outcome.Status, ex);
            }
        }
        #endregion

    }
}
