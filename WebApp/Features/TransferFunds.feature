Feature: TransferFunds

   As a logged in user
   to order to make multiple transfers

   Background: Verify Logged In
		Given the accounts screen is displayed
		And the Account Summary tab is displayed

	@Transfer
	Scenario Outline: Transfer Funds Between Accounts
		When I click the Transfer Funds Tab
		Then the Transfer Money & Make Payments screen is displayed
		When I select a From Account <From Account>
		And I select a To Account <To Account>
		And I enter an Amount <Amount>
		And I type a description <Description>
		And I click the Continue button
		Then the verify screen is displayed
		When I click the Submit button
		Then a success message is displayed

		Examples: 
		| From Account | To Account | Amount | Description          |
		| 1            | 2          | 1000   | Transfer details one |
		| 2            | 3          | 2500   | Transfer details two |



