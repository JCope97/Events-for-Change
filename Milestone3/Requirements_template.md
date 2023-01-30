# Requirements Workup

## Elicitation

1. Is the goal or outcome well defined?  Does it make sense?
    * Have a map on a web page that is showing locations of shelters
    * Be able to see soup kitchens on the map
    * Be able to see general events on the map
    * Users should be able to make a profile and store events they want to keep track of
    * Users should be able to view events they have previously saved
    * Organizers should be able to post/edit events they are having
    * Users should be able to search events by location.

2. What is not clear from the given description?
    * We believe the overall description of the project within our previous deliverables such as the needs and features, architecture, and vision statement gives a clear picture of what our project is.
3. How about scope?  Is it clear what is included and what isn't?
4. What do you not understand?
    * Technical domain knowledge
        * Google API
        * Location API
    * Business domain knowledge
5. Is there something missing?
6. Get answers to these questions.

## Analysis

Go through all the information gathered during the previous round of elicitation.  

1. For each attribute, term, entity, relationship, activity ... precisely determine its bounds, limitations, types and constraints in both form and function.  Write them down.
2. Do they work together or are there some conflicting requirements, specifications or behaviors?
3. Have you discovered if something is missing?  
4. Return to Elicitation activities if unanswered questions remain.


## Design and Modeling
Our first goal is to create a **data model** that will support the initial requirements.

1. Identify all entities;  for each entity, label its attributes; include concrete types

Within ERD

2. Identify relationships between entities.  Write them out in English descriptions.

    * A single user can have one or many profiles (though they should really only have one)
    * An event can have multiple users and a user can have multiple events
    * A single map can have multiple events and their locations
    * A single organization can have one or many events. 
    * A single user can have multiple organizations that they follow or are connected to. This is implying that there is only one user tied to each organization as the owner or holder of the account.
    * A single organization can have one or many profiles (though they should also only have one)

3. Draw these entities and relationships in an _informal_ Entity-Relation Diagram.

    * See ERD image

4. If you have questions about something, return to elicitation and analysis before returning here.

## Analysis of the Design
The next step is to determine how well this design meets the requirements _and_ fits into the existing system.

1. Does it support all requirements/features/behaviors?
    * For each requirement, go through the steps to fulfill it.  Can it be done?  Correctly?  Easily?

        * The design of our data model could likely be improved and use adjustments as we continue to solidify our overall plans for this project

2. Does it meet all non-functional requirements?
    * May need to look up specifications of systems, components, etc. to evaluate this.

