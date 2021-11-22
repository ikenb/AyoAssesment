# AyoAssesment

Setup Steps

-Clone the app
-Rebuild the solution
-Set ConvertMetric.API as start_up project

Open package mamager and run the following 
NB. Default project should be ConvertMetric.data on the package manager console

Add-Migration InititialMigration
Update-Database

Seed the database by running the below against the newly created Metric Db
USE [Metric]
GO

INSERT INTO [dbo].[Formuae]
           ([Name]
           ,[Syntax])
     VALUES
           ('f to c','((5/9)*(F-32))'),
		   ('f to k','((F+459.67)*(5/9))'),

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

USE [Metric]
GO

INSERT INTO [dbo].[Length]
           ([Unit]
           ,[FormulaId])
     VALUES('mm',1),
			('cm',2),
			('m',3),
			('km',4)
GO

Run the below script against the newly created Metric Db to create the stored procedure "GetFormula"

USE Metric
GO

CREATE PROCEDURE dbo.Getformula
@converstionName nvarchar(30)

Declare @converstionName nvarchar(30) ='mm to cm'

--AS
SELECT Syntax
FROM Formuae
WHERE [Name] = @converstionName

GO





