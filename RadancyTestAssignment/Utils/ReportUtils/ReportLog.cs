namespace RadancyTestAssignment.Utils.ReportUtils
{
    public class ReportLog: ExtentService
    {
        public static void Pass(string message)
        {
            ExtentTestManager.GetTest().Pass(message);
        }
        public static void Fail(string message)
        {
            ExtentTestManager.GetTest().Fail(message);
        }
        public static void Skip(string message)
        {
            ExtentTestManager.GetTest().Skip(message);
        }
        
    }
}
