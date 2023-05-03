SET IDENTITY_INSERT Organization ON

INSERT INTO [EventType](EventType)
    VALUES
    ('Food'),
    ('Water'),
    ('Shelter'),
    ('Bathroom'),
    ('Clothing');


INSERT INTO [Organization](OrganizationLoginID, OrganizationDescription, OrganizationLocation)
    VALUES
    (1, 'Food Bank Organization', 'Monmouth OR'),
    (2, 'Hunger Fighters', 'Salem OR'),
    (3, 'Mini-Shelters', 'Portland OR'),
    (4, 'Mission Save the World', 'Corvallis OR'),
    (5, 'College Helpers', 'Salem OR'),
    (6, 'Food Bank Organization', 'Monmouth OR'),
    (7, 'Monmouth Thrift Store', 'Monmouth OR');



INSERT INTO [Event](OrganizationID, EventName, EventLocation, EventTypeID, EventDescription, EventDate)
    VALUES
    (1, 'Food Bank Event 2023', '345 Monmouth Ave N, Monmouth, OR - 97361', 1, 'Come and enjoy a warm meal', '4/28/23'),
    (2, 'Hunger Helpers 2023', '4570 Center Street Salem, OR - 97301', 1, 'A lot of soup is being made for anyone!', '4/29/23'),
    (1, 'Food Share Event', '345 Monmouth Ave N, Monmouth, OR - 97361', 1, 'Enjoy an amazing meal', '4/19/23'),
    (1, 'Food Pantry cleanout 2023', '345 Monmouth Ave N, Monmouth, OR - 97361', 1, 'We have too much food to give away, first come first served', '4/30/23'),
    (5, 'Night Strike', '1850 45th Ave NE Salem, OR - 97305', 5, 'A place for food, water, clothes, and handwarmers', '4/30/23'),
    (3, 'Shelter Village', '12350 SE Powell Blvd. Portland, OR - 97236', 3, 'A shelter for the night', '4/20/23'),
    (3, 'Mini Homes', '12350 SE Powell Blvd. Portland, OR - 97236', 3, 'Come and register to stay at one of these mini homes', '4/29/23'),
    (5, 'Cloudy with a chance of free food', '1850 45th Ave NE Salem, OR - 97305', 1, 'Come and enjoy a warm meal', '4/30/23'),
    (4, 'Lifeline', '1800 SW 3rd Street Corvallis, OR - 97333', 1, 'Come and enjoy a warm meal', '5/1/23'),
    (5, 'Operation Sandwich', '1850 45th Ave NE Salem, OR - 97305', 1, 'Free lunch meals', '5/2/23'),
    (7, 'Thrift Store', '885 Commercial Street NE Salem, Oregon - 97301', 5, 'Come thrift shopping! Open 10am - 5pm', '5/4/23'),
    (6, 'Free Dinner', '545 SW 2nd Street Corvallis, OR - 97333', 1, 'Come and enjoy a free warm meal from 5pm - 7pm', '5/10/23'),
    (4, 'Summer Heat Rest', '1800 SW 3rd Street, Corvallis, OR - 97333', 2, 'Come visit if you are thirsty and need water bottles', '5/11/23');


SET IDENTITY_INSERT Organization OFF