Feature: MA-US-59-AddingMapToEventPage

This user story is about being able to see where an event is on a map.  Some one using our site may not know the area well enough to be able to able to know where things just based on address so being able to see where it is on the map where you can see other streets and businesses would be able to give you a better idea about the location of the event.

This will be done using the google maps api. We will have to feed the address of the event into the maps api to create a map centered on the events location. The map will be initially hidden intel the address is click on which will unhide the map. clicking on the address again will re-hide the map.

This feature is for ease of use for when a user might not know the area well enough to know where the address is based on the address.

@Justin
Scenario: The Map is on the page
	Given I am a visitor
	When I am on the "EventInfo" page
	Then there is a map object

@Justin
Scenario: Clicking on the address unhides the map
	Given I am a visitor
	When I am on the "EventInfo" page
	And I click on the address
	Then the map object is unhidden
