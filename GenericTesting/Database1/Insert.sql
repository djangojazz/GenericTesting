/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--alter table dbo.[Order] drop constraint FK_Person_Order_PersonID
--GO

--Truncate table dbo.[Order]
--GO

--Truncate table dbo.[Person]
--GO

--alter table dbo.[Order] add CONSTRAINT FK_Person_Order_PersonID FOREIGN KEY (PersonId) REFERENCES Person(PersonId)
--GO

Insert into dbo.[Person] values ('Brett'),('Neil')
GO

Insert into dbo.[Order] values (1,'Shirt'),(1,'Pants'),(2,'Shirt'),(2,'Pants'),(2,'Hat')
GO