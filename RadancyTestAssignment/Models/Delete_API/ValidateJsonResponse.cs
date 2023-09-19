using Newtonsoft.Json;
using RadancyTestAssignment.Utils.ReportUtils;

namespace RadancyTestAssignment.Models.Delete_API
{
        public class ValidateTheResponse
        {
            public HttpClientHelper clientHelper = new HttpClientHelper();
            public JsonHelper jsonHelper = new JsonHelper();

            public void verifyJsonResponse(string jsonResponse)
            {
                var jsonResponseClass = JsonConvert.DeserializeObject<JsonOutputDeleteCall>(jsonResponse);
                string email = null;

                if (email != jsonResponseClass.data.email)
                {
                    ReportLog.Fail("Email value is not matching");
                }
                else
                {
                ReportLog.Pass("Email value is matching");
                }

        }
    }
}
