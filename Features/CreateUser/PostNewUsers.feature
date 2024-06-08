Feature: PostNewUsers

@Api
@Post
Scenario: Create new user
	Given I have a "Create new" user enpoint
	When I request to "Create" a new user with the following body:
	| name   | job    |
	| Joseph | leader |
	Then The response code for newly created user is 201
	And the response body includes the following
	| name   | job    |
	| Joseph | leader |

@Api
@Post
Scenario Outline: Create new user with scenario outline example
	Given I have a "Create new" user enpoint
	When I request to "Create" a new user with the following body:
	| name   | job    |
	| <title> | <profesion> |
	Then The response code for newly created user is 201
	And the response body includes the following
	| name    | job         |
	| <title> | <profesion> |
Examples: 
| title  | profesion |
| Joseph | leader    |
| Joe    | teacher   |
| Kay    | student   |
| Nath   | leader    |
| Ade    | professor |

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