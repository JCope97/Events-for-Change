INSERT INTO [Event](OrganzationID, EventName, EventLocation, EventTypeID, EventDescription)
    VALUES
    (1, 'Food Bank Event 2023', 'Monmouth OR', 1, 'Come and enjoy a warm meal');

INSERT INTO [Organzation](OrganzationLoginID, OrganzationDescription, OrganzationLocation)
    VALUES
    (1, 'Food Bank Organization', 'Monmouth OR');

INSERT INTO [EventType](EventType)
    VALUES
    ('Food');