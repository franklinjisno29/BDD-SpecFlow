Feature: Search


@Product_Search
Scenario Outline: Search For Products
	Given User will be on Homepage
	When User will type the '<searchtext>' in the searchbox
	Then Search Results are loaded in the same page with '<searchtext>'
Examples: 
	| searchtext |
	| water      |
	| Java       |
	| hairgrass  |
