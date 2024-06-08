Feature: UpdateUserRecords1

@Api
@Post
Scenario: Update existing user
	Given I have a "Update" user enpoint
	When I request to "Update" a new user with the following body:
	| name   | job    |
	| Joseph | teacher|
	Then The response code for newly created user is 200
	And the response body includes the following
	| name   | job    |
	| Joseph | teacher|
