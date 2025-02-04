﻿CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Login NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedAt DATETIME NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_Users_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
    CONSTRAINT FK_Users_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES Users(Id)
);

CREATE TABLE Projects (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    StartDate DATETIME NOT NULL,
    FinishDate DATETIME NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedAt DATETIME NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_Projects_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
    CONSTRAINT FK_Projects_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES Users(Id)
);

CREATE TABLE UserProjects (
    UserId UNIQUEIDENTIFIER NOT NULL,
    ProjectId UNIQUEIDENTIFIER NOT NULL,
    RoleId UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (UserId, ProjectId),
    CONSTRAINT FK_UserProjects_User FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_UserProjects_Project FOREIGN KEY (ProjectId) REFERENCES Projects(Id),
    CONSTRAINT FK_UserProjects_Role FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);

CREATE TABLE States (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ProjectId UNIQUEIDENTIFIER NOT NULL,
    Number INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedAt DATETIME NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_States_Project FOREIGN KEY (ProjectId) REFERENCES Projects(Id),
    CONSTRAINT FK_States_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
    CONSTRAINT FK_States_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES Users(Id)
);

CREATE TABLE Tasks (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255) NOT NULL,
    StartDate DATETIME NOT NULL,
    FinishDate DATETIME NULL,
    ProjectId UNIQUEIDENTIFIER NOT NULL,
    StateId UNIQUEIDENTIFIER NOT NULL,
    UserId UNIQUEIDENTIFIER NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedAt DATETIME NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_Tasks_Project FOREIGN KEY (ProjectId) REFERENCES Projects(Id),
    CONSTRAINT FK_Tasks_State FOREIGN KEY (StateId) REFERENCES States(Id),
    CONSTRAINT FK_Tasks_User FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_Tasks_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
    CONSTRAINT FK_Tasks_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES Users(Id)
);

CREATE TABLE Activities (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255) NOT NULL,
    UserId UNIQUEIDENTIFIER NOT NULL,
    TaskId UNIQUEIDENTIFIER NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedAt DATETIME NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_Activities_User FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_Activities_Task FOREIGN KEY (TaskId) REFERENCES Tasks(Id),
    CONSTRAINT FK_Activities_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
    CONSTRAINT FK_Activities_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES Users(Id)
);

CREATE TABLE Comments (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Data NVARCHAR(MAX) NOT NULL,
    TaskId UNIQUEIDENTIFIER NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedAt DATETIME NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_Comments_Task FOREIGN KEY (TaskId) REFERENCES Tasks(Id),
    CONSTRAINT FK_Comments_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
    CONSTRAINT FK_Comments_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES Users(Id)
);
