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
	Given I have new user product resource
	When I request to create new user with the following parameters:
	| name       | email                | password     | title | birth_date | birth_month | birth_year | firstname | lastname | company | address1  | address2 | country        | zipcode | state  | city       | mobile_number |
	| John Stone | john{0}@testuser.com | Password001! | Mr    | 01         | 01          | 1940       | John      | Stone    | ztec    | 01 adress | lostock  | United Kingdom | Bl2 8rd | bolton | manchester | 07890987655   |
	Then the response code is 201
	And The response message is 'User created!' 
