CREATE TABLE [Events] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [OrganzationID] int NOT NULL,
  [EventName] nvarchar(255) NOT NULL,
  [EventLocation] nvarchar(255) NOT NULL,
  [EventTypesID] int NOT NULL,
  [EventDiscreption] nvarchar(255) NOT NULL
);


CREATE TABLE [Organzation] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [OrganzationLoginID] int NOT NULL,
  [OrganzationDescription] nvarchar(255) NOT NULL,
  [OrganzationLocation] nvarchar(255) NOT NULL,
  [OrganzationPicture] VARBINARY(MAX)
);

CREATE TABLE [EventTypes] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [EventType] nvarchar(255)
);

CREATE TABLE [Users] (
  [ID] int PRIMARY KEY IDENTITY(1, 1)
);

CREATE TABLE [UserEventList] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [UserID] int NOT NULL,
  [EventID] int NOT NULL
);

ALTER TABLE [Events] ADD CONSTRAINT [Fk Organzation ID]
  FOREIGN KEY ([OrganzationID]) REFERENCES [Organzation] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--ALTER TABLE [Events] ADD CONSTRAINT ([EventTypesID]) REFERENCES [EventTypes] ([ID]);

ALTER TABLE [Event] ADD CONSTRAINT [Fk EventTypes ID]
  FOREIGN KEY ([OrganzationID]) REFERENCES [EventTypes] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--ALTER TABLE [UserEventList] ADD CONSTRAINT ([UserID]) REFERENCES [Users] ([ID]);

ALTER TABLE [UserEventList] ADD CONSTRAINT [Fk User ID]
  FOREIGN KEY ([UserID]) REFERENCES [Users] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--ALTER TABLE [UserEventList] ADD CONSTRAINT ([EventID]) REFERENCES [Events] ([ID]);

ALTER TABLE [UserEventList] ADD CONSTRAINT [Fk Event ID]
  FOREIGN KEY ([EventID]) REFERENCES [Events] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
