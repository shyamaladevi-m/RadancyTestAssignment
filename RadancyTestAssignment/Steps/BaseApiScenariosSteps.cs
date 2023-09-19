using RadancyTestAssignment.Helper;
using TechTalk.SpecFlow;
using static RadancyTestAssignment.HttpClientHelper;
using RadancyTestAssignment.Utils.ReportUtils;
using NUnit.Framework;
using RadancyTestAssignment.Models.Delete_API;
using ClassLibrary1.Steps;

namespace RadancyTestAssignment.Steps
{
    [Binding]
    public sealed class BaseApiScenariosSteps : BaseTest
    {
        public JsonHelper jsonHelper = new JsonHelper();
        public HttpClientHelper clientHelper = new HttpClientHelper();
        public TestHelper testHelper = new TestHelper();
        public ApiResponse apiResponse = new ApiResponse();
        public ValidateTheResponse validation = new ValidateTheResponse();
        public string inputParameters;
        public string requestType;
        public string endpoint;
        public string header;
        public string jsonResponse;
        public int statusCode;
        public string statusMessage;
        public int responseTime;
        public string responseParameter;

        [Given(@"I have a '(.*)' API '(.*)'")]
        public void GivenIHaveAAPI(string httpVerb, string API)
        {
            requestType = httpVerb;
            endpoint = jsonHelper.GetDataByEnvironment(API);
        }

        [Given(@"I have a json input file")]
        public void GivenIHaveAJsonInputFile(Table table)
        {
            inputParameters = jsonHelper.ReadJsonFile(table);  // Passing table
        }

        [Given(@"I have a json input file '(.*)'")]
        public void GivenIHaveAJsonInputFile(string filePath)
        {
            inputParameters = jsonHelper.ReadJsonFile(filePath);
        }

        [Given(@"Authentication Type '(.*)'")]
        public void WhenAuthenticationType(string authenticationType)
        {
            clientHelper.GetAuthorization(authenticationType); // call get Authorization method.
        }

        [Given(@"Header is present'(.*)'")]
        public void WhenHeaderIsPresent(string headerVariable)
        {
            clientHelper.AddHeaders(headerVariable, requestType);
        }

        [When(@"(.*)' Enpoint is triggered")]
        public void WhenEnpointIsTriggered(string post)
        {
            apiResponse = clientHelper.getApiReponse(endpoint, requestType, inputParameters);
        }


        [Then(@"getApiReponse\(\)")]
        public void ThenGetApiReponse()
        {
            jsonResponse = apiResponse.jsonResponse;
            statusCode = apiResponse.statusCode;
            statusMessage = apiResponse.statusMessage;
            responseTime = apiResponse.responseTimeInMilliseconds;
            ReportLog.Pass("I receive response successfully");
        }

        [Then(@"validateResponseCode'(.*)'")]
        public void ThenValidateResponseCode(int StatusCode)
        {
            if (apiResponse.statusCode != StatusCode)
            {
                ReportLog.Fail("Status Code mismtach. Expected Status Code is: " + StatusCode + " Received Status Code is: " + apiResponse.statusCode);
            }
            else
                ReportLog.Pass("Status Code: " + StatusCode + " matched successfully.");
        }


        [Then(@"validateResponseTime\((.*)\)")]
        public void ThenValidateResponseTime(int ResponseTimeInMilliseconds)
        {
            if (apiResponse.responseTimeInMilliseconds > ResponseTimeInMilliseconds)
            {
                Assert.AreEqual(ResponseTimeInMilliseconds, apiResponse.responseTimeInMilliseconds);
                ReportLog.Fail("Response Time mismtach. Expected Response within: " + ResponseTimeInMilliseconds + "  milliseconds.Received Response Time is: " + apiResponse.responseTimeInMilliseconds);
            }
            else
                ReportLog.Pass("Response Receieved within " + ResponseTimeInMilliseconds + " milliseconds. Response Time  is: " + apiResponse.responseTimeInMilliseconds + " milliseconds");
        }

        [Then(@"validateResponseText\((.*)\)")]
        public void ThenValidateResponseText(string expetedText)
        {
            if (!apiResponse.jsonResponse.Contains(expetedText.ToLower()))
                ReportLog.Fail("API Response does not contains text: " + expetedText);
            else
                ReportLog.Pass("API Response contains text: " + expetedText);
        }

        [Then(@"ThenValidateTheJsonResponse")]
        public void ThenThenIValidateTheJsonResponse()
        {
            validation.verifyJsonResponse(jsonResponse);
        }

    }
}