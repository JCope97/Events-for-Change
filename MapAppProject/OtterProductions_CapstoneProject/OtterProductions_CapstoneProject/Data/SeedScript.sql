INSERT INTO [Event](OrganizationID, EventName, EventLocation, EventTypeID, EventDescription, EventDate)
    VALUES
    (1, 'Food Bank Event 2023', 'Monmouth OR', 1, 'Come and enjoy a warm meal', '3/10/23'),
    (2, 'Hunger Helpers 2023', 'Salem OR', 1, 'A lot of soup is being made for anyone!', '3/7/23'),
    (1, 'Food Share Event', 'Monmouth OR', 1, 'Enjoy an amazing meal', '3/12/23'),
    (1, 'Food Pantry cleanout 2023', 'Monmouth OR', 1, 'We have too much food to give away, first come first served', '3/6/23'),
    (5, 'Night Strike', 'Salem OR', 5, 'A place for food, water, clothes, and handwarmers', '3/14/23'),
    (3, 'Shelter Village', 'Portland OR', 3, 'A shelter for the night', '3/12/23'),
    (3, 'Mini Homes', 'Portland OR', 3, 'Come and register to stay at one of these mini homes', '3/12/23'),
    (5, 'Cloudy with a chance of free food', 'Salem OR', 1, 'Come and enjoy a warm meal', '3/11/23'),
    (4, 'Lifeline', 'Corvallis OR', 1, 'Come and enjoy a warm meal', '3/7/23'),
    (5, 'Operation Sandwich', 'Monmouth OR', 1, 'Free lunch meals', '3/9/23'),
    (7, 'Thrift Store', 'Monmouth OR', 2, 'Come thrift shopping! Open 10am - 5pm', '3/8/23'),
    (6, 'Free Dinner', 'Monmouth OR', 1, 'Come and enjoy a free warm meal from 5pm - 7pm', '3/10/23'),
    (4, 'Summer Heat Rest', 'Corvallis OR', 2, 'Come visit if you are thirsty and need water bottles', '3/8/23');

INSERT INTO [Organization](OrganizationLoginID, OrganizationDescription, OrganizationLocation)
    VALUES
    (1, 'Food Bank Organization', 'Monmouth OR'),
    (2, 'Hunger Fighters', 'Salem OR'),
    (3, 'Mini-Shelters', 'Portland OR'),
    (4, 'Mission Save the World', 'Corvallis OR'),
    (5, 'College Helpers', 'Salem OR'),
    (6, 'Food Bank Organization', 'Monmouth OR'),
    (7, 'Monmouth Thrift Store', 'Monmouth OR');

INSERT INTO [EventType](EventType)
    VALUES
    ('Food'),
    ('Water'),
    ('Shelter'),
    ('Bathroom'),
    ('Clothing');
	
INSERT INTO [Event](OrganzationID, EventName, EventLocation, EventTypeID, EventDescription)
    VALUES
    (2, 'Thrift Store', 'Monmouth OR', 2, 'Come thrift shopping! Open 10am - 5pm');




	
INSERT INTO [Event](OrganzationID, EventName, EventLocation, EventTypeID, EventDescription)
    VALUES
    (2, 'Thrift Store', 'Monmouth OR', 2, 'Come thrift shopping! Open 10am - 5pm');




