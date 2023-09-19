using RadancyTestAssignment.Utils.ReportUtils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Steps
{
    [Binding]
    public class BaseTest : ExtentService
    {

        [BeforeFeature]
        public static void GlobalSetup()
        {
            ExtentTestManager.CreateParentTest("Parent");
        }
        [BeforeScenario]
        public static void Setup()
        {
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);

        }
        [AfterScenario]
        public static void TearDown()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var errorMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message) ? "" : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
                var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
                switch (status)
                {
                    case TestStatus.Failed:
                        ReportLog.Fail("Test Failed");
                        ReportLog.Fail(errorMessage);
                        ReportLog.Fail(stackTrace);
                        break;

                    case TestStatus.Skipped:
                        ReportLog.Skip("Test Skipped");
                        break;

                    case TestStatus.Passed:
                        ReportLog.Skip("Test Passed");
                        ReportLog.Pass("Test Passed");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception" + ex);
            }

            finally
            {
                extent.Flush();
            }
        }
       }
    }
