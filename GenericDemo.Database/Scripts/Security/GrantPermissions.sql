EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'GenericDemo';
GO
EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'GenericDemo';
GO