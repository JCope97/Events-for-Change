Feature: MA-US-24-Search-Specific-Events

This user story is about being able to search events by their specfic name. 
Some one using our site may know the exact event they are looking for and be able to search based on the name instead of the location.
This feature is for a user that knows the event name, but not the location or organization.

@Jacob
Scenario: I can see both forms on the event search page
Given I am a visitor
When I am on the "SearchEvent" page
Then I can see an option to search by location or by the event name

@Jacob
Scenario: I can search for a specific event and get the results for it
Given I am a visitor
When I am on the "SearchEvent" page
And I type "Free Dinner" in the name form
Then it will populate all events with the title "Free Dinner"