Feature: MA-US-30-Create-Events-Display-Events

User story that has list of events displayed after clicking button to create a new event as an organization

@Cooper
Scenario: The organization should have its name on the profile page
	Given I am logged in as an organization
	When I am on the "OrganizationDetails" page
	Then I should have my name be on the page

@Cooper
Scenario: The organization profile page has an events link
	Given I am logged in as an organization
	When I am on the "OrganizationDetails" page
	And I click the "Events" nav link
	Then I should be routed to "Events" page

@Cooper
Scenario: The Organization can add a new event
	Given I am logged in as an organization
	When I am on the "Events" page
	And I click the "Add New Event" nav link
	Then I should be routed to "CreateEvent" page

@Cooper
Scenario: The organization fills in create new event form
	Given I am logged in as an organization
	When I am on the "CreateEvent" page
	And the Event Name input field is filled in with "Food Bank Event 2023"
	And the Event Location input field is filled in with "Monmouth"
	And the Event Description input field is filled in with "Food Bank Organization"
	And the "createEventForm" button is clicked
	Then I should be routed to the "Events" page

