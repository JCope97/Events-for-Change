@Antonia

Feature: Login Basic Testing for SpecFlow and Selenium

    Basic testing for the "Login" page


Scenario: Login page contains a Login button
    Given I am a visitor
    When I am on the "Login" page
    Then The page presents a Login button
    

Scenario: Login page contains a welcome message
    Given I am a visitor
    When I am on the "Login" page
    Then The page contains a welcome message


Scenario: Login page allows access to Registration page
    Given I am a visitor
    When I am on the "Login" page
        And I click on Don't have an account? Create one here!
    Then I am redirected to the "Register" page


Scenario: As a registered user, I can login using the login page
    Given I am a registered user
        And I am on the "Login" page
    When I login
    Then I am redirected to the "Home" page