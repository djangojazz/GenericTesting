CREATE TABLE [dbo].[TreeTest]
(
  [Id] INT IDENTITY NOT NULL PRIMARY KEY
, [Val] Varchar(32) NOT NULL
, [ParentID] INT CONSTRAINT FK_TreeTest_ParentId REFERENCES TreeTest(Id)
, [Created] SMALLDATETIME
, [Modified] SMALLDATETIME
, [Active] Bit
)