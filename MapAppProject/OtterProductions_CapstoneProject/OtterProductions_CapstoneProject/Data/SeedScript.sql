INSERT INTO [Events](OrganzationID, EventName, EventLocation, EventTypesID, EventDiscreption)
    VALUES
    (1, 'Food Bank Event 2023', 'Monmouth OR', 1, 'Come and enjoy a warm meal');

INSERT INTO [Organzation](OrganzationLoginID, OrganzationDescription, OrganzationLocation)
    VALUES
    (1, 'Food Bank Organization', 'Monmouth OR');

INSERT INTO [EventTypes](EventType)
    VALUES
    ('Food');