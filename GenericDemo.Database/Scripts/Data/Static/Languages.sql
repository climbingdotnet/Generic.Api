USE [$(DatabaseName)];
GO

PRINT 'Insert Default Languages'
GO


MERGE INTO [dbo].[Languages] AS Target
USING (
VALUES
	('29d59bfb-229c-4ddd-a764-b32c0807f70e', 'C'),
	('bf7ccdfc-e7cc-4d5e-b4ec-5d5447cbb606', 'C#'),
	('0d4342f4-9fbf-4c21-b244-f4a644b4d41b', 'C++'),
	('454e9959-3e4c-47a3-8604-f44aa1014996', 'Objective-C'),
	('f73916c3-df1b-4b23-ab1e-4bf3281a38ae', 'Javascript'),
	('d137aec1-4f22-4a4b-9cdf-46b8ed25d765', 'Python'),
	('db4678b0-4282-4fee-bddd-cece2821622f', 'Java'),
	('9d18c332-29fc-4651-a403-1611f2b3488c', 'LISP'),
	('0176ebf4-7ec9-4f3f-8756-c0b131888ae0', 'elm sucks!'),
	('bb74b4a8-f10d-47a1-96c0-2cf409b903b6', 'SQL')
)
AS Source (
	[Id], 
	[Name]
)
ON Target.Id = Source.Id

-- Update matched rows
WHEN MATCHED THEN
UPDATE SET 
	Target.[Id] = Source.[Id],
	Target.[Name] = Source.[Name]

-- Insert new rows
WHEN NOT MATCHED BY Target THEN
INSERT (
	[Id], 
	[Name]
)
VALUES (
	Source.[Id], 
	Source.[Name]
)

-- Delete rows in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO

