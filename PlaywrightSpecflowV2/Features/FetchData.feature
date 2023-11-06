@FetchData
Feature: Weather forecast page
  As a user
  I want to view a list of weather forecasts
  So that I know which hat to wear

Scenario: User views weather forecasts on the Fetch Data page
	Given the user is on the Fetch Data page
	When the page loads
    Then the user should be able to see a table with the following columns:
      | Date       | Temp. (C) | Temp. (F) | Summary  |
    And the table should contain the following weather forecasts:
      | Date       | Temp. (C) | Temp. (F) | Summary  |
      | 2018-06-05 | 1         | 33        | Freezing |
      | 2018-07-05 | 14        | 57        | Bracing  |
      | 2018-08-05 | -13       | 9         | Freezing |
      | 2018-09-05 | -16       | 4         | Balmy    |
      | 2018-10-05 | -2        | 29        | Chilly   |
