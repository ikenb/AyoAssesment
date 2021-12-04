# unit-conversion-api

This is a high performance calculation engine for Metric to Kelvin.

## Setup instructions

- Clone the app
- Rebuild the solution
- Set ConvertMetric.API as start_up project
- Open package mamagerNB. Default project should be ConvertMetric.data on the package manager console
- Add-Migration InititialMigration
- Update-Database
- Seed the database by running the below against the newly created Metric Db

USE [Metric] GO

INSERT INTO [dbo].[Formuae] ([Name] ,[Syntax]) VALUES ('f to c','((5/9)(F-32))'), ('f to k','((F+459.67)(5/9))'),

       ('c to f','((C*9/5)+32)'),
       ('c to k','K–273'),

       ('k to c','C+273'),
       ('k to f','((K?273.15)*9/5+32))'),

       ('mg to g','mg*0.1'),
       ('mg to kg','mg*0.001'),
       ('mg to t','mg*0.000001'),

       ('g to mg','g*10'),
       ('g to kg','g*100'),
       ('g to t','g*1000'),

       ('kg to mg','kg*10'),
       ('kg to g','kg*100'),
       ('kg to t','kg*1000'),

       ('t to mg','t*1000000'),
       ('t to g','t*1000'),
       ('t to kg','t*100'),
       ('f to c','((5/9)*(F-32))'),
       ('f to k','((F+459.67)*(5/9))'),

       ('c to f','((C*9/5)+32)'),
       ('c to k','K–273'),

       ('k to c','C+273'),
       ('k to f','((K-273.15)*9/5+32))'),

       ('mg to g','mg*0.1'),
       ('mg to kg','mg*0.001'),
       ('mg to t','mg*0.000001'),

       ('g to mg','g*10'),
       ('g to kg','g*100'),
       ('g to t','g*1000'),

       ('kg to mg','kg*10'),
       ('kg to g','kg*100'),
       ('kg to t','kg*1000'),

       ('t to mg','t*1000000'),
       ('t to g','t*1000'),
       ('t to kg','t*100')

GO

USE [Metric] GO

INSERT INTO [dbo].[Length] ([Unit] ,[FormulaId]) VALUES('mm',1), ('cm',2), ('m',3), ('km',4)
GO

USE [Metric] GO

INSERT INTO [dbo].[Length] ([Unit] ,[FormulaId]) VALUES('mm',1), ('cm',2), ('m',3), ('km',4)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

USE Metric GO

CREATE PROCEDURE dbo.Getformula
@converstionName nvarchar(30)
AS
SELECT Syntax
FROM Formuae
WHERE [Name] = @converstionName

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

CREATE PROCEDURE [dbo].[GetUserByUserName]
@userName nvarchar(30)

AS
SELECT TOP 1 Username, Role
FROM Users
WHERE Username = @userName

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveUser]
@userName nvarchar(30),
@password nvarchar(30),
@role nvarchar(30)

AS
INSERT INTO [dbo].[Users]
([Username]
,[Password]
,[Role])
VALUES (@userName,@password,@role)

GO

## Wiki

For detailed information please consult the https://github.com/ikenb/AyoAssesment/wiki
