ALTER TABLE [Event] DROP CONSTRAINT [Fk Organzation ID];
ALTER TABLE [Event] DROP CONSTRAINT [Fk EventType ID];
ALTER TABLE [UserEventList] DROP CONSTRAINT [Fk MapAppUser ID];
ALTER TABLE [UserEventList] DROP CONSTRAINT [Fk Event ID];



DROP TABLE [Event];
DROP TABLE [UserEventList];
DROP TABLE [Organzation];
DROP TABLE [MapAppUser];
DROP TABLE [EventType];