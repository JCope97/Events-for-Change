--CREATE DATABASE[ApplicationOtterProductions_CapstoneProject]


CREATE TABLE [Event] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [OrganzationID] int NOT NULL,
  [EventName] nvarchar(255) NOT NULL,
  [EventLocation] nvarchar(255) NOT NULL,
  [EventTypeID] int NOT NULL,
  [EventDescription] nvarchar(255) NOT NULL
);


CREATE TABLE [Organzation] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [OrganzationLoginID] int NOT NULL,
  [OrganzationDescription] nvarchar(255) NOT NULL,
  [OrganzationLocation] nvarchar(255) NOT NULL,
  [OrganzationPicture] VARBINARY(MAX)
);

CREATE TABLE [EventType] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [EventType] nvarchar(255)
);

CREATE TABLE [MapAppUser] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [AspnetIdentityId] nvarchar(50),
  [FirstName] nvarchar(50),
  [LastName] nvarchar(50)

);

CREATE TABLE [UserEventList] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [MapAppUserID] int NOT NULL,
  [EventID] int NOT NULL
);

ALTER TABLE [Event] ADD CONSTRAINT [Fk Organzation ID]
  FOREIGN KEY ([OrganzationID]) REFERENCES [Organzation] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--ALTER TABLE [Events] ADD CONSTRAINT ([EventTypeID]) REFERENCES [EventType] ([ID]);

ALTER TABLE [Event] ADD CONSTRAINT [Fk EventType ID]
  FOREIGN KEY ([OrganzationID]) REFERENCES [EventType] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--ALTER TABLE [UserEventList] ADD CONSTRAINT ([MapAppUserID]) REFERENCES [MapAppUsers] ([ID]);

ALTER TABLE [UserEventList] ADD CONSTRAINT [Fk MapAppUser ID]
  FOREIGN KEY ([MapAppUserID]) REFERENCES [MapAppUser] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--ALTER TABLE [UserEventList] ADD CONSTRAINT ([EventID]) REFERENCES [Events] ([ID]);

ALTER TABLE [UserEventList] ADD CONSTRAINT [Fk Event ID]
  FOREIGN KEY ([EventID]) REFERENCES [Event] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;