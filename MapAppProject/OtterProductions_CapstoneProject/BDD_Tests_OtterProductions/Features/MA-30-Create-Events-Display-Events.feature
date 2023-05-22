Feature: MA-US-30-Create-Events-Display-Events

User story that has list of events displayed after clicking button to create a new event as an organization


Scenario: The organization should have its event name be on the page
    Given I am logged in as an organization
    When I am on the "Events" page
    Then I should have my event name on the page


Scenario: The organization events page should have a title on the page
    Given I am logged in as an organization
    When I am on the "Events" page
    Then I should see the title on the page


Scenario: The Organization can add a new event
    Given I am logged in as an organization
    When I am on the "Events" page
    And I click the "Add New Event" nav link
    Then I should be routed to "CreateEvent" page

    
Scenario: The organization fills in create new event form
    Given I am logged in as an organization
    When I am on the "CreateEvent" page
    And the Event Name input field is filled in with "Food Bank Event 2023"
    And the Event Location input field is filled in with "Monmouth"
    And the Event Description input field is filled in with "Food Bank Organization"
    And the Event Date with "01/01/2023 12:00 AM"
    And the Event Type input field with "Food"
    And the "createEventForm" button is clicked
    Then I should be routed to the "Events" page
