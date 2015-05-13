CREATE TABLE [dbo].[Order]
(
	[OrderId] INT NOT NULL Identity PRIMARY KEY,
	[PersonId] INT NOT NULL,
	[Name] varchar(256),

	CONSTRAINT FK_Person_Order_PersonID FOREIGN KEY (PersonId) REFERENCES Person(PersonId),
)
