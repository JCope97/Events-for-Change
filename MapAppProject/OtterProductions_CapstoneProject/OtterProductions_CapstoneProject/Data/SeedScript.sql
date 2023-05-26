SET IDENTITY_INSERT Organization ON

INSERT INTO [EventType](EventType)
    VALUES
    ('Food'),
    ('Water'),
    ('Shelter'),
    ('Bathroom'),
    ('Clothing');


INSERT INTO [Organization](OrganizationLoginID, OrganizationName, OrganizationDescription, OrganizationLocation)
    VALUES
    (1, 'Food Bank Organization', 'We are a Food Bank Organization', 'Monmouth OR'),
    (2, 'Hunger Fighters', 'We Fight Hunger' , 'Salem OR'),
    (3, 'Mini-Shelters','We Help Shelter Those In Need', 'Portland OR'),
    (4, 'Mission Save the World','We are on a Mission To Save The World', 'Corvallis OR'),
    (5, 'College Helpers','We Help College Students', 'Salem OR'),
    (6, 'Food Bank Organization','We are a Food Bank Organization', 'Monmouth OR'),
    (7, 'Monmouth Thrift Store','We Have Clothing', 'Monmouth OR');



INSERT INTO [Event](OrganizationID, EventName, EventLocation, EventTypeID, EventDescription, EventDate)
    VALUES
    (1, 'Food Bank Event 2023', '345 Monmouth Ave N, Monmouth, OR - 97361', 1, 'Come and enjoy a warm meal', '5/25/23'),
    (2, 'Hunger Helpers 2023', '4570 Center Street Salem, OR - 97301', 1, 'A lot of soup is being made for anyone!', '5/25/23'),
    (1, 'Food Share Event', '345 Monmouth Ave N, Monmouth, OR - 97361', 1, 'Enjoy an amazing meal', '5/30/23'),
    (1, 'Food Pantry cleanout 2023', '345 Monmouth Ave N, Monmouth, OR - 97361', 1, 'We have too much food to give away, first come first served', '5/26/23'),
    (5, 'Night Strike', '1850 45th Ave NE Salem, OR - 97305', 5, 'A place for food, water, clothes, and handwarmers', '5/27/23'),
    (3, 'Shelter Village', '12350 SE Powell Blvd. Portland, OR - 97236', 3, 'A shelter for the night', '5/28/23'),
    (3, 'Mini Homes', '12350 SE Powell Blvd. Portland, OR - 97236', 3, 'Come and register to stay at one of these mini homes', '5/31/23'),
    (5, 'Cloudy with a chance of free food', '1850 45th Ave NE Salem, OR - 97305', 1, 'Come and enjoy a warm meal', '6/2/23'),
    (4, 'Lifeline', '1800 SW 3rd Street Corvallis, OR - 97333', 1, 'Come and enjoy a warm meal', '5/30/23'),
    (5, 'Operation Sandwich', '1850 45th Ave NE Salem, OR - 97305', 1, 'Free lunch meals', '5/29/23'),
    (7, 'Thrift Store', '885 Commercial Street NE Salem, Oregon - 97301', 5, 'Come thrift shopping! Open 10am - 5pm', '6/3/23'),
    (6, 'Free Dinner', '545 SW 2nd Street Corvallis, OR - 97333', 1, 'Come and enjoy a free warm meal from 5pm - 7pm', '6/4/23'),
    (4, 'Summer Heat Rest', '1800 SW 3rd Street, Corvallis, OR - 97333', 2, 'Come visit if you are thirsty and need water bottles', '5/29/23');


SET IDENTITY_INSERT Organization OFF