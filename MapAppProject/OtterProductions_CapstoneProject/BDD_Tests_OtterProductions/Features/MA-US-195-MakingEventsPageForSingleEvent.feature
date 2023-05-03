Feature: MA-US-195-MakingEventsPageForSingleEvent

This user story is about making an event page that users can go to to get more info about a event that they are interested in. We want users to be able to see the name of the event, the organization that is putting on the event, the place that the event is at, and a detailed description of the event. 

To do this we will have to create a new web page that has all of the event info for an event coming from the database. To get to this page a user will have to click on an event from the event list. 

This will be useful to users because it would let them get more info about an event instead of only seeing the events in a list.
@Justin
Scenario: The event page has the name of the event
	Given I am a visitor
	When I am on the "EventInfo" page
	Then The event title is "Free Dinner"

@Justin
Scenario:  The event page has the Date of the event
	Given I am a visitor
	When I am on the "EventInfo" page
	Then The event date is "4/27/2023 12:00:00 AM"

@Justin
Scenario:  The event page has the location of the event
	Given I am a visitor
	When I am on the "EventInfo" page
	Then The event location is "545 SW 2nd Street Corvallis, OR - 97333"

@Justin
Scenario:  The event page has the discription of the event
	Given I am a visitor
	When I am on the "EventInfo" page
	Then The event discription is "Come and enjoy a free warm meal from 5pm - 7pm"

@Justin
Scenario:  The event page has the Type of the event
	Given I am a visitor
	When I am on the "EventInfo" page
	Then The event Type is "Food"