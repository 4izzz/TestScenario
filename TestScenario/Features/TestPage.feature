Feature: TestPage

A short summary of the feature

@testTag
Scenario: Add n elements
	Given Open browser
	When Navigate to URL
	Then Add '8' elements
	Then Assert that '8' number of elements exist on the page
