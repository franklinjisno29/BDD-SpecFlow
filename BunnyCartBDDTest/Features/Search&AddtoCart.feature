Feature: Search&AddtoCart


@E2E-Search_AddtoCart
Scenario: Search & Add to Cart
	Given User will be on Homepage
	When User will type the '<searchtext>' in the searchbox
	Then Search Results are loaded in the same page with '<searchtext>'
	When User selects a '<productno>'
	Then Product page '<searchtext>' is loaded
	When User select the quantity of the product
	* User Clicks the Add to Cart Button
	Then Product '<searchtext>' added to cart

Examples:
	| searchtext | productno |
	| Water      | 2	|
	| Java	     | 1	|


#@E2E-Search_AddtoCart
#Scenario: 02 Click a Particular Product
#	Given Search page is loaded
#	When User selects a '<productno>'
#	Then Product page is loaded
#Examples:
#	| productno |
#	| 1	|


