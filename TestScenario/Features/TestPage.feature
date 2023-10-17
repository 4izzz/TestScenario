Feature: TestPage

Add n elements to the page and verify that they're exist

@testTag
Scenario: Add n elements
	Given Open browser
	When Navigate to URL
	Then Add '<n>' elements
	Then Assert that '<n>' number of elements exist on the page
	Examples:
    | n     |
    | 1     |
    | 10    |
    | 0     |
    | 100   |
	| 1000  |