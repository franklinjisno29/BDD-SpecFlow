Feature: GoogleSearch

To perform search operations on google home page

@tag1
Scenario: To perform search with google search button
	Given Google Homepage should be loaded
	When Type "hp laptop" in search text box
	And Click on the Google Search Button
	Then the results should be displayed on the next page with title "hp laptop - Google Search"

Scenario: To perform search with IMFL button
	Given Google Homepage should be loaded
	When Type "hp laptop" in search text box
	And Click on the IMFL Button
	Then the results should be redirected to a new page with title "HP Laptops"
