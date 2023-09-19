using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using TechTalk.SpecFlow;

namespace RadancyTestAssignment.Utils.ReportUtils
{
    [Binding]
    public class ExtentService
    {
        public static ExtentReports extent;

        [BeforeFeature()]
        public static ExtentReports GetExtent()
        {
            if (extent == null)
            {

                string reportDir = Path.Combine(Utility.GetProjectRootDirectory(), "Report/Reports");
                extent = new ExtentReports();
                var reporter = new ExtentHtmlReporter(reportDir);
                if (!Directory.Exists(reportDir))
                {
                    string path = Path.Combine(reportDir, "index.html");
                    reporter = new ExtentHtmlReporter(path);
                }
                else
                {
                    string path = Path.Combine(reportDir, "index.html");
                    reporter = new ExtentHtmlReporter(reportDir);

                }

                reporter.Config.DocumentTitle = "Fraework report";
                reporter.Config.ReportName = "Test Automation Report";
                reporter.Config.Theme = Theme.Dark;
                extent.AttachReporter(reporter);
            }
            return extent;
        }
    }
}


