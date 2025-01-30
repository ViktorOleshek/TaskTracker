INSERT INTO Roles (Name)
VALUES 
    ('admin'), 
    ('user'), 
    ('guest');

INSERT INTO Users (Login, Password, Email)
VALUES 
    ('admin1', 'password1', 'admin1@example.com'),
    ('user1', 'password2', 'user1@example.com'),
    ('user2', 'password3', 'user2@example.com'),
    ('guest1', 'password4', 'guest1@example.com'),
    ('guest2', 'password5', 'guest2@example.com');

DECLARE @ProjectId1 UNIQUEIDENTIFIER;
DECLARE @ProjectId2 UNIQUEIDENTIFIER;

INSERT INTO Projects (Name, Description, StartDate, FinishDate, CreatedAt, CreatedBy)
VALUES
    ('Project A', 'Description of Project A', GETDATE(), NULL, GETDATE(), (SELECT Id FROM Users WHERE Login = 'admin1')),
    ('Project B', 'Description of Project B', GETDATE(), NULL, GETDATE(), (SELECT Id FROM Users WHERE Login = 'user1'));

SET @ProjectId1 = (SELECT Id FROM Projects WHERE Name = 'Project A');
SET @ProjectId2 = (SELECT Id FROM Projects WHERE Name = 'Project B');

INSERT INTO UserProjects (UserId, ProjectId, RoleId)
VALUES 
    ((SELECT Id FROM Users WHERE Login = 'admin1'), @ProjectId1, (SELECT Id FROM Roles WHERE Name = 'admin')),
    ((SELECT Id FROM Users WHERE Login = 'user1'), @ProjectId1, (SELECT Id FROM Roles WHERE Name = 'user')),
    ((SELECT Id FROM Users WHERE Login = 'user2'), @ProjectId2, (SELECT Id FROM Roles WHERE Name = 'user')),
    ((SELECT Id FROM Users WHERE Login = 'guest1'), @ProjectId2, (SELECT Id FROM Roles WHERE Name = 'guest')),
    ((SELECT Id FROM Users WHERE Login = 'guest2'), @ProjectId2, (SELECT Id FROM Roles WHERE Name = 'guest'));

DECLARE @StateId1 UNIQUEIDENTIFIER;
DECLARE @StateId2 UNIQUEIDENTIFIER;

INSERT INTO States (ProjectId, Number, Name, CreatedAt, CreatedBy)
VALUES
    (@ProjectId1, 1, 'To Do', GETDATE(), (SELECT Id FROM Users WHERE Login = 'admin1')),
    (@ProjectId1, 2, 'In Progress', GETDATE(), (SELECT Id FROM Users WHERE Login = 'admin1'));

SET @StateId1 = (SELECT Id FROM States WHERE ProjectId = @ProjectId1 AND Number = 1);
SET @StateId2 = (SELECT Id FROM States WHERE ProjectId = @ProjectId1 AND Number = 2);

DECLARE @TaskId1 UNIQUEIDENTIFIER;
DECLARE @TaskId2 UNIQUEIDENTIFIER;

INSERT INTO Tasks (Name, StartDate, FinishDate, ProjectId, StateId, UserId, CreatedAt, CreatedBy)
VALUES
    ('Task 1', GETDATE(), NULL, @ProjectId1, @StateId1, (SELECT Id FROM Users WHERE Login = 'user1'), GETDATE(), (SELECT Id FROM Users WHERE Login = 'admin1')),
    ('Task 2', GETDATE(), NULL, @ProjectId1, @StateId2, (SELECT Id FROM Users WHERE Login = 'user2'), GETDATE(), (SELECT Id FROM Users WHERE Login = 'admin1'));

SET @TaskId1 = (SELECT Id FROM Tasks WHERE Name = 'Task 1');
SET @TaskId2 = (SELECT Id FROM Tasks WHERE Name = 'Task 2');

DECLARE @ActivityId1 UNIQUEIDENTIFIER;
DECLARE @ActivityId2 UNIQUEIDENTIFIER;

INSERT INTO Activities (Name, UserId, TaskId, CreatedAt, CreatedBy)
VALUES
    ('Activity 1', (SELECT Id FROM Users WHERE Login = 'user1'), @TaskId1, GETDATE(), (SELECT Id FROM Users WHERE Login = 'admin1')),
    ('Activity 2', (SELECT Id FROM Users WHERE Login = 'user2'), @TaskId2, GETDATE(), (SELECT Id FROM Users WHERE Login = 'admin1'));

DECLARE @CommentId1 UNIQUEIDENTIFIER;
DECLARE @CommentId2 UNIQUEIDENTIFIER;

INSERT INTO Comments (Data, TaskId, CreatedAt, CreatedBy)
VALUES
    ('Comment for Task 1', @TaskId1, GETDATE(), (SELECT Id FROM Users WHERE Login = 'user1')),
    ('Comment for Task 2', @TaskId2, GETDATE(), (SELECT Id FROM Users WHERE Login = 'user2'));
