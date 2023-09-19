namespace RadancyTestAssignment.Utils
{
    class Utility
    {
        public static string GetProjectRootDirectory()
        {
            string CurrentDirectory = Directory.GetCurrentDirectory();
            return CurrentDirectory.Split("bin")[0];
        }
    }
}
