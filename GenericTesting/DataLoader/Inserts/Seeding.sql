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
--TRUNCATIONS
TRUNCATE TABLE dbo.TreeTest

--DELETIONS
DELETE dbo.teSku
DBCC CHECKIDENT ('dbo.teSku', RESEED, 0);
GO

DELETE dbo.tbPerson_Address
DBCC CHECKIDENT ('dbo.tbPerson_Address', RESEED, 0);
GO

DELETE dbo.teAddress
DBCC CHECKIDENT ('dbo.teAddress', RESEED, 0);
GO

DELETE dbo.teOrder
DBCC CHECKIDENT ('dbo.teOrder', RESEED, 0);
GO

DELETE dbo.tePerson
DBCC CHECKIDENT ('dbo.tePerson', RESEED, 0);
GO

--INSERTS
INSERT INTO dbo.TreeTest (Val, ParentID, Created, Modified, Active )
VALUES ('A', NULL, GETDATE(), GETDATE(), 1),('B', 1, GETDATE(), GETDATE(), 1),('C', 2, GETDATE(), GETDATE(), 1),('AA', NULL, GETDATE(), GETDATE(), 0),('AAA', NULL, GETDATE(), GETDATE(), 1)
,('BBB', 5, GETDATE(), GETDATE(), 1),('CCC', 6, GETDATE(), GETDATE(), 1),('DDD', 7, GETDATE(), GETDATE(), 1),('AAAA', NULL, GETDATE(), GETDATE(), 1),('BBBB', 9, GETDATE(), GETDATE(), 1)

SET IDENTITY_INSERT dbo.teAddress ON;
INSERT INTO dbo.teAddress (AddressId, StreetAddress, City, [State], ZipCode, Latitude, Longitude) VALUES (1, '7560 SW Lara St.', 'Portland', 'OR', 97223, 45.4573057, -122.7565177);
SET IDENTITY_INSERT dbo.teAddress OFF;

SET IDENTITY_INSERT dbo.tePerson ON;
INSERT INTO dbo.tePerson (PersonId, FirstName, LastName) VALUES (1, 'Brett', 'Morin'),(2, 'Emily', 'Morin');
SET IDENTITY_INSERT dbo.tePerson OFF;

SET IDENTITY_INSERT dbo.tbPerson_Address ON;
INSERT INTO dbo.tbPerson_Address (Person_AddressId, PersonId, AddressId) VALUES (1, 1, 1), (2,2,1);
SET IDENTITY_INSERT dbo.tbPerson_Address OFF;

SET IDENTITY_INSERT dbo.teOrder ON;
INSERT INTO dbo.teOrder ( OrderId, PersonId, [Description]) VALUES (1, 1, 'Clothing'),(2, 1, 'Electronics'),(3, 2, 'Clothing'),(4,2,'Pets');
SET IDENTITY_INSERT dbo.teOrder OFF;

SET IDENTITY_INSERT dbo.teSku ON;
INSERT INTO dbo.teSku (SkuId, OrderId, [Description]) VALUES (1, 1, 'Shirt'),(2, 1, 'Pants'),(3, 1, 'Shoes'),(4, 2, 'Laptop'),(5, 3, 'Dress'),(6, 3, 'Shoes'),(7, 4, 'Dog Food'),(8,4,'Dog Medicine');
SET IDENTITY_INSERT dbo.teOrder OFF;

GO