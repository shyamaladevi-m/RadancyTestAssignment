namespace RadancyTestAssignment.Models.Delete_API;
    public class Data
    {
        public int account_number { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

    }
    public class JsonOutputDeleteCall
    {
        public Data data { get; set; }

    }
