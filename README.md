REST API AUTOMATION USING BDD FRAMEWORK :
Overview: To automate REST API this framework uses SpecFlow which is a testing framework that supports Behaviour Driven Development (BDD). In order to consume web API I have used HttpClient class. 
Consume API which do not have authentication or authorization but requires client Key and client Secret to be passed on headers.

Framework structure: 
1.	Config Folder: This folder contains the BaseURL and endpoints for different environments.
2.	Features Folder : All the feature files are kept under the Test folder. These tests are described here in a simple English language called as Gherkin language. 
3.	Helpers Folder: This folder contains the class files which helps us to read the Json request and read the responses.
4.	Reports Folder: The test results are under this folder. This report is in html format. 
5.	Steps Folder: All the Step definition files are kept under the Test folder
6.	Test Data Folder: This folder contains various combination of json inputs/params required to provide for an API. These files are in json format. You can provide positive as well as negative inputs to the API. 
7.	Utils Folder: This folder contains the class files which helps with generating reports.

Packages used: Extent Reports(4.1.0), Microsoft.NET.Test.Sdk(16.9.1), Nunit3TestAdapter(4.5.0),RestSharp(110.2.0),Specflow(3.9.74),Specflow.NUnit(3.9.74).
Reporting: The test execution report is generated in Html format. This report allows to filter tests according to pass/ fail criteria.

Test Cases Covered :
1.Create  Multiple Savings Account with same mobile number
2.Delete Savings Account
3.Check Available Balance
4.Deposit Money More than 10k in a single transaction 
5.Withdraw Money from account

Advantages: Supports Html reporting. Supports execution for testing multiple environments by simply providing required test environment name.

To use this framework you need to perform following steps:
Install Visual Studio (VS 2022 recommended)
Install supporting packages.
Update the API_Data_Config.json file with your project specific API base URLs and endpoints.
Update the app.config by simply entering the environment name to execute all the tests for that environment.
Segregate the test data as per the test environment.
Test data should be in .json format.
Follow the specflow feature file scenario standards (scenario standards can also be customized).