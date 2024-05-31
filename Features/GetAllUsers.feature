Feature: GetAllUsers

@mytag
Scenario: Retrieve all user info
	Given I have a resource
	When I request all users info
	Then The response code is 200
	And the response body includes the following:
	| page | per_page | total | total_pages | id | email                      | first_name | last_name | avatar                                  |
	| 2    | 6        | 12    | 2           | 7  | michael.lawson@reqres.in   | Michael    | Lawson    | https://reqres.in/img/faces/7-image.jpg |
	| 2    | 6        | 12    | 2           | 8  | lindsay.ferguson@reqres.in | Lindsay    | Ferguson  | https://reqres.in/img/faces/8-image.jpg |