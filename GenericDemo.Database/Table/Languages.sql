CREATE TABLE [dbo].[Languages]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newsequentialid(), 
    [Name] VARCHAR(50) NOT NULL, 
)
