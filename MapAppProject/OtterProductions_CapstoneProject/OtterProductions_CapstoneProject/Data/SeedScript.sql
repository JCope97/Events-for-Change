INSERT INTO [EventType](EventType)
    VALUES
    ('Food');

INSERT INTO [EventType](EventType)
    VALUES
    ('Clothing');

INSERT INTO [Organzation](OrganzationLoginID, OrganzationDescription, OrganzationLocation)
    VALUES
    (1, 'Food Bank Organization', 'Monmouth OR');

INSERT INTO [Organzation](OrganzationLoginID, OrganzationDescription, OrganzationLocation)
    VALUES
    (2, 'Monmouth Thrift Store', 'Monmouth OR');
    
INSERT INTO [Event](OrganzationID, EventName, EventLocation, EventTypeID, EventDescription)
    VALUES
    (1, 'Food Bank Event 2023', 'Monmouth OR', 1, 'Come and enjoy a warm meal');

INSERT INTO [Event](OrganzationID, EventName, EventLocation, EventTypeID, EventDescription)
    VALUES
    (1, 'Free Dinner', 'Monmouth OR', 1, 'Come and enjoy a free warm meal from 5pm - 7pm');

	
INSERT INTO [Event](OrganzationID, EventName, EventLocation, EventTypeID, EventDescription)
    VALUES
    (2, 'Thrift Store', 'Monmouth OR', 2, 'Come thrift shopping! Open 10am - 5pm');




