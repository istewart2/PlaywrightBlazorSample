﻿@Counter
Feature: Counter should be properly incrementing its value

Scenario: Click increases the counter 2
    Given a user in the counter page
    When the increase button is clicked 2 times
    Then the counter value is 2

Scenario: Click increases the counter 3
    Given a user in the counter page
    When the increase button is clicked 3 times
    Then the counter value is 3

Scenario: Click increases the counter 4
    Given a user in the counter page
    When the increase button is clicked 4 times
    Then the counter value is 4

Scenario: Click increases the counter 5
    Given a user in the counter page
    When the increase button is clicked 5 times
    Then the counter value is 5