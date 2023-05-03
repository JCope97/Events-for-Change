ALTER TABLE [Event] DROP CONSTRAINT [Fk Organization ID];
ALTER TABLE [Event] DROP CONSTRAINT [Fk EventType ID];
ALTER TABLE [UserEventList] DROP CONSTRAINT [Fk MapAppUser ID];
ALTER TABLE [UserEventList] DROP CONSTRAINT [Fk Event ID];
ALTER TABLE [Comment] DROP CONSTRAINT [Fk MapAppUser ID];
ALTER TABLE [Comment] DROP CONSTRAINT [Fk Event ID];




DROP TABLE [Event];
DROP TABLE [UserEventList];
DROP TABLE [Organization];
DROP TABLE [MapAppUser];
DROP TABLE [EventType];
DROP TABLE [Comment];