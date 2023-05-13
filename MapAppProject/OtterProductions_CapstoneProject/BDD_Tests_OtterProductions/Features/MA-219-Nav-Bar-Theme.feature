@Antonia

Feature: New working nav bar and updated theme

    Adding a new vertical nav bar with more links to pages and features
    as well as updating the theme on all pages with old theme to better user experience

    Scenario: There exists a nav bar
        Given I am a visitor
        When I am on the "Home" page
        Then the page presents a navigation bar


    Scenario: Clicking on Map in nav bar takes me to the Map page
        Given I am on the "Home" page
        When I click on Map in the navbar
        Then I am redirected to the "Map" page


    Scenario: Clicking on Local Events in nav bar takes me to the Events Search page
        Given I am on the "Home" page
        When I click on Local Events in the navbar
        Then I am redirected to the "Events Search" page


    Scenario: Clicking on Create an Account in nav bar takes me to the Registration page
        Given I am on the "Home" page
        When I click on Create an Account in the navbar
        Then I am redirected to the "Registration" page


    Scenario: Clicking on Login in nav bar takes me to the Login page
        Given I am on the "Home" page
        When I click on Login in the navbar
        Then I am redirected to the "Login" page


    Scenario: Clicking on Privacy in nav bar takes me to the Privacy page
        Given I am on the "Home" page
        When I click on Privacy in the navbar
        Then I am redirected to the "Privacy" page


    Scenario: Clicking on FAQ in nav bar takes me to the FAQ page
        Given I am on the "Home" page
        When I click on FAQ in the navbar
        Then I am redirected to the "FAQ" page