Feature: MA-135-ListOfPlaces

This User story is to have a list of places show up that are related to the buttons that you press for restrooms, shelters, and food banks. We want uses to have a list of the places pop up along with showing them on the map so that they can see the names of the places without having to hover over each of the points of the map to see what the place is called. clicking on the place that is in the list will also cause the map to center onto the place you clicked on to give you a better view of where it is as well as tell you which one of the markers it is.

@Justin
Scenario: The Map page has the right buttons
	Given I am a visitor
	When I am on the "Map" page
	Then the page presents a restroom button, a shelter button and a food bank button

@Justin
Scenario: The Map page list is not empty for shelters
	Given I am a visitor
	When I am on the "Map" page
	And the address text box is filled in with "Salem, OR"
	And the submit button is clicked
	And the "Shelter" button is clicked
	Then the places list is not empty

@Justin
Scenario: The Map page list is not empty for restrooms
	Given I am a visitor
	When I am on the "Map" page
	And the address text box is filled in with "Salem, OR"
	And the submit button is clicked
	And the "restroom" button is clicked
	Then the places list is not empty

@Justin	
Scenario: The Map page list is not empty for foodbanks
	Given I am a visitor
	When I am on the "Map" page
	And the address text box is filled in with "Salem, OR"
	And the submit button is clicked
	And the "Food Bank" button is clicked
	Then the places list is not empty

