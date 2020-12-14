Feature: Feedback

As a user I wish to provide feedback

@feedback
Scenario: Send Feedback
	Given I have navigated to the Feedback page
	When I enter the following data into the feedback form
	| Name        | EmailAddress          | Subject                  | Question                                     |
	| John Doe    | john@doe@email.com    | This is a question       | The rain in Spain falls mainly in the plain  |
	And I click the Send Message button
	Then an acknowledgement screen and text are displayed