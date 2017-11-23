using LykkeAutomation.Api;
using LykkeAutomation.TestsCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.Tests
{
   public class BaseTest
    {
        public LykkeApi lykkeApi;
        public ApiSchemes apiSchemes;
        public IList<string> schemesError;

        #region response info
       

        public static void ValidateScheme(bool valid, IList<string> errors)
        {
            if (!valid)
            {
                errors.ToList().ForEach(e => Console.WriteLine(e));
                Assert.Fail("Scheme not valid");
            }
        }

#endregion

        #region before after
        [SetUp]
        public void SetUp()
        {
            AllureReport.GetInstance().CaseStarted(TestContext.CurrentContext.Test.FullName,
                TestContext.CurrentContext.Test.Name, "");
            lykkeApi = new LykkeApi();
            apiSchemes = new ApiSchemes();
            schemesError = new List<string>();
            TestContext.WriteLine("SetUp");
        }


        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
          
            AllureReport.GetInstance().CaseFinished(TestContext.CurrentContext.Test.FullName,
                TestContext.CurrentContext.Result.Outcome.Status, null);
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AllureReport.GetInstance().RunStarted();
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
