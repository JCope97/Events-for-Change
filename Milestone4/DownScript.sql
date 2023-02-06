ALTER TABLE [Events] DROP CONSTRAINT [Fk Organzation ID];
ALTER TABLE [Events] DROP CONSTRAINT [Fk EventTypes ID];
ALTER TABLE [UserEventList] DROP CONSTRAINT [Fk User ID];
ALTER TABLE [UserEventList] DROP CONSTRAINT [Fk Event ID];



DROP TABLE [Events];
DROP TABLE [UserEventList];
DROP TABLE [Organzation];
DROP TABLE [Users];
DROP TABLE [EventTypes];