CREATE TABLE [Event] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [OrganizationID] int NOT NULL,
  [EventName] nvarchar(255) NOT NULL,
  [EventLocation] nvarchar(255) NOT NULL,
  [EventTypeID] int NOT NULL,
  [EventDescription] nvarchar(255) NOT NULL
);


CREATE TABLE [Organization] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [AspnetIdentityId] nvarchar(50),
  [Email] nvarchar(256) NULL,
  [Address] nvarchar(256) NULL,
  [OrganizationName] nvarchar(256) NULL,
  [OrganizationDescription] nvarchar(256) NULL,
  [OrganizationLocation] nvarchar(256) NULL,
  [PhoneNumber] varchar(15) NULL,
);

CREATE TABLE [EventType] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [EventType] nvarchar(255)
);

CREATE TABLE [MapAppUser] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [AspnetIdentityId] nvarchar(50)
);

CREATE TABLE [UserEventList] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [MapAppUserID] int NOT NULL,
  [EventID] int NOT NULL
);

ALTER TABLE [Event] ADD CONSTRAINT [Fk Organization ID]
  FOREIGN KEY ([OrganizationID]) REFERENCES [Organization] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--ALTER TABLE [Events] ADD CONSTRAINT ([EventTypeID]) REFERENCES [EventType] ([ID]);

ALTER TABLE [Event] ADD CONSTRAINT [Fk EventType ID]
  FOREIGN KEY ([OrganizationID]) REFERENCES [EventType] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--ALTER TABLE [UserEventList] ADD CONSTRAINT ([MapAppUserID]) REFERENCES [MapAppUsers] ([ID]);

ALTER TABLE [UserEventList] ADD CONSTRAINT [Fk MapAppUser ID]
  FOREIGN KEY ([MapAppUserID]) REFERENCES [MapAppUser] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--ALTER TABLE [UserEventList] ADD CONSTRAINT ([EventID]) REFERENCES [Events] ([ID]);

ALTER TABLE [UserEventList] ADD CONSTRAINT [Fk Event ID]
  FOREIGN KEY ([EventID]) REFERENCES [Event] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;