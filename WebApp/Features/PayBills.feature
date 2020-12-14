Feature: PayBills
	In order to make pay bills
	As a logged in user
	I need to make payments to my saved payees

Background: Verify Logged In
		Given the accounts screen is displayed
		And the Account Summary tab is displayed

@PayBills
Scenario: Make payments to my saved payees
		When I click the pay Bills tab
		And the Pay Saved Payee tab is active
		And I make a payment to a saved payee
		| Payee           | Account     | Amount | Date       | Description       |
		| Bank of America | Credit Card | 250    | Today+1    | This is a payment |
		Then a payment success message is displayed

