Feature: ApiTaskResolution

	As an end user 
	I want to be able to retrieve all product info
	And i should be able to create a new user


@tag1
Scenario: Get all Product List
	Given I have a product resource
	When I request product list
	Then response includes theh following:
	| id | name       | price   | brand | usertype | category |
	| 1  | Blue Top   | Rs. 500 | Polo  | Women    | Tops     |
	| 2  | Men Tshirt | Rs. 400 | H&M   | Men      | Tshirts  |

Scenario: Create user
	Given I have a product resource
	#When I request to create new user with the following:
	#|  |  |  |  |  |  |  |
	#|  |  |  |  |  |  |  |
	Then the response code is 201
	And The response message is 'User created!' 
