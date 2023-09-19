Feature: Test Basic Banking scenarios

 @Api
  Scenario: Create Multiple Savings Account with same mobile number
    Given I have a 'POST' API 'CreateASavingsAccount'
    And I have a json input file
    | FileName |
    | TestData\JsonInputForCreateAccountPOST.json   |
    And Header is present'yes'
    And Authentication Type 'No Authentication'
    When 'POST' Enpoint is triggered
    Then getApiReponse()
    And validateResponseCode'200'

    Given I have a 'POST' API 'CreateASavingsAccount'
    And I have a json input file
    | FileName |
    | TestData\JsonInputForCreateAccountPOST.json   |
    And Header is present'yes'
    And Authentication Type 'No Authentication'
    When 'POST' Enpoint is triggered
    Then getApiReponse()
    And validateResponseCode'200'

  Scenario: Delete Savings Account
    Given I have a 'DELETE' API 'DeleteASavingsAccount'
    And Header is present'yes'
    And Authentication Type 'No Authentication'
    When 'DELETE' Enpoint is triggered
    Then getApiReponse()
    Then validateResponseCode'200'
    And ThenValidateTheJsonResponse

  Scenario: Check Balance
    Given I have a 'Post' API 'CheckBalance'
    And I have a json input file
    | FileName |
    | TestData\JsonInputForCheckBalancePOST.json   |
    And Header is present'yes'
    And Authentication Type 'No Authentication'
    When 'POST' Enpoint is triggered
    Then getApiReponse()
    And validateResponseCode'200'
  

Scenario: Deposit Money Morerthan 10k in a single transaction
    Given I have a 'Post' API 'DepositMoney'
    And I have a json input file
    | FileName |
    | TestData\JsonInputForDepositMoneyPOST.json   |
    And Authentication Type 'No Authentication'
    And Header is present'yes'
    When 'POST' Enpoint is triggered
    Then getApiReponse()
    And validateResponseCode'400'
    And validateResponseText('error')

Scenario: Withdraw Money
    Given I have a 'Post' API 'WithdrawMoney'
    And I have a json input file
    | FileName |
    | TestData\JsonInputForWithdrawMoneyPOST.json   |
    And Authentication Type 'No Authentication'
    And Header is present'yes'
    When 'POST' Enpoint is triggered
    Then getApiReponse()
    And validateResponseCode'200'
