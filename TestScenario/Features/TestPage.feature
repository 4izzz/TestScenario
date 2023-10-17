Feature: TestPage

Add n elements to the page and verify that they're exist

@testTag
Scenario: Add n elements
	Given Open browser
	When Navigate to URL
	Then Add '8' elements
	Then Assert that '8' number of elements exist on the page
