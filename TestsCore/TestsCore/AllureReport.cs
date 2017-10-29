using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AllureCSharpCommons;
using AllureCSharpCommons.AllureModel;
using AllureCSharpCommons.Events;
using NUnit.Framework.Interfaces;

namespace LykkeAutomation.TestsCore
{
    public class AllureReport
    {
        private static AllureReport allureReport;
        private static Allure _lifecycle;
        private static Dictionary<string, List<dynamic>> _caseStorage = new Dictionary<string, List<dynamic>>();
        private object debugLock = new object();
        private static string resultDir;
        private static object myLock = new object();

        private AllureReport()
        {
        }

        public static AllureReport GetInstance()
        {
            if (allureReport == null)
            {
                lock (myLock)
                {
                    if (allureReport == null)
                        allureReport = new AllureReport();
                }
            }
            return allureReport;
        }

        public void RunStarted(string workDirectory)
        {
            resultDir = workDirectory + "allure-results/";
            AllureConfig.ResultsPath = resultDir;
            Directory.CreateDirectory(AllureConfig.ResultsPath);
            _lifecycle = Allure.Lifecycle;
        }

        public void RunFinished()
        {
            CreateEnvFile();
            CreateCategoryFile();
        }

        public void CaseStarted(string fullName, string name, string description)
        {
            lock (_caseStorage)
            {
                string fixtureName = GetFixtureName(fullName);

                _caseStorage.Add(fullName, new List<dynamic>());

                _caseStorage[fullName].Add(new TestSuiteStartedEvent(fixtureName, fixtureName));

                label[] labels =
                {
                    new label("label1", "value1"?? ""),
                    new label("host", "Local machine")
                };

                string displayedCaseName = name;

                _caseStorage[fullName].Add(new TestCaseStartedEvent(fixtureName, displayedCaseName, DateTime.Now)
                {
                    Labels = labels,
                    Description = new description(descriptiontype.html, description),
                    Title = displayedCaseName
                });
            }
        }

        public void CaseFinished(string fullName, TestStatus result, Exception exception)
        {
            lock (_caseStorage)
            {
                string fixtureName = GetFixtureName(fullName);

                if (result == TestStatus.Failed)
                {
                    _caseStorage[fullName].Add(new TestCaseFailureEvent()
                    {
                        Throwable = exception,
                        StackTrace = exception.StackTrace
                    });
                }
                if (result == TestStatus.Skipped)
                {
                    _caseStorage[fullName].Add(new TestCaseCanceledEvent()
                    {
                        Throwable = exception
                    });
                }
                if (result == TestStatus.Inconclusive)
                {
                    _caseStorage[fullName].Add(new TestCasePendingEvent()
                    {
                        Throwable = exception
                    });
                }

                AddAttachment(fullName, Encoding.UTF8.GetBytes(TestLog.GetLog()), "TestLog", "text/plain");

                var ev = _caseStorage[fullName].First(e => e is TestCaseStartedEvent) as TestCaseStartedEvent;
                var newLabels = ev.Labels?.ToList();
                newLabels.Add(new label("feature", result.ToString()));
                newLabels.Add(new label("story", result.ToString()));
                ev.Labels = newLabels.ToArray();

                _caseStorage[fullName].Add(new TestCaseFinishedEvent(DateTime.Now));
                _caseStorage[fullName].Add(new TestSuiteFinishedEvent(fixtureName, DateTime.Now));

                foreach (var evt in _caseStorage[fullName])
                {
                    _lifecycle.Fire(evt);
                }
                _caseStorage.Remove(fullName);
            }
        }

        public void StepStarted(string fullName, string stepName)
        {
            lock (_caseStorage)
            {
                _caseStorage[fullName].Add(new StepStartedEvent(stepName, DateTime.Now) { Title = stepName });
            }
        }

        public void StepFinished(string fullName, TestStatus result, Exception exception = null)
        {
            lock (_caseStorage)
            {
                if (!_caseStorage.ContainsKey(fullName))
                    throw new Exception("Not existed step " + fullName);
                if (result == TestStatus.Failed || result == TestStatus.Inconclusive)
                {
                    _caseStorage[fullName].Add(new StepFailureEvent()
                    {
                        Throwable = exception
                    });
                }
                if (result == TestStatus.Skipped)
                {
                    _caseStorage[fullName].Add(new StepCanceledEvent()
                    {
                        Throwable = exception
                    });
                }

                var log = TestLog.GetStepLog();
                if (log != null && log.ToString() != "")
                {
                    AddAttachment(fullName, Encoding.UTF8.GetBytes(log.ToString()), "StepLog", "text/plain");
                }
                _caseStorage[fullName].Add(new StepFinishedEvent(DateTime.Now));
            }
        }

        public void AddAttachment(string fullName, byte[] attach, string title, string type)
        {
            lock (_caseStorage)
            {
                try
                {
                    _caseStorage[fullName].Add(new MakeAttachEvent(attach, title, type));
                }
                catch
                {
                    TestLog.WriteLine($"Cannot attach {title} into report");
                }
            }
        }

        public void CreateMinimumReport(string message)
        {
            _lifecycle.Fire(new TestSuiteStartedEvent("", "Before run"));
            _lifecycle.Fire(new TestCaseStartedEvent("minId", "TestCase"));
            _lifecycle.Fire(new TestCaseFailureEvent() { Throwable = new Exception(message) });
            _lifecycle.Fire(new TestCaseFinishedEvent());
            _lifecycle.Fire(new TestSuiteFinishedEvent("minId"));
        }

        private void CreateEnvFile()
        {
            string environmetFilePath = Path.Combine(resultDir, "environment.properties");
            string[] lines = new[]
            {
                String.Format("{0}={1}", "TestCategory", "Sample category" ?? ""), // work with categories here
            };
            File.WriteAllLines(environmetFilePath, lines);
        }

        private void CreateCategoryFile()
        {
            string categoryFilePath = Path.Combine(resultDir, "categories.json");
            File.WriteAllText(categoryFilePath, new AllureCategoriesJson().GetJson());
        }

        private string GetFixtureName(string fullName)
        {
            try
            {
                string fixtureName = fullName.Contains("+") ? fullName.Remove(fullName.IndexOf('+')) : fullName;
                return fixtureName.Substring(fixtureName.LastIndexOf('.') + 1);
            }
            catch (IndexOutOfRangeException)
            {
                TestLog.WriteLine("Cannot get fixture name", fullName);
                throw;
            }
            catch (ArgumentOutOfRangeException)
            {
                return fullName.Substring(fullName.LastIndexOf('.') + 1);
            }
        }
    }

}
