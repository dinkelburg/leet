-------------------------------------------------------------------------
--
-- This is a custom script that can be added in a Web Deployment Package
--
--	It adds logins and rights to SQL Server that are necessary to run 
--	applications that are hosted in IIS (and use the default application pool)
--
-------------------------------------------------------------------------
--	In this script: 
--    rename the [exampleDBname] to the name of the database that you are installing
--
--  In Visual studio:
--    open the properties tab of your project
--    go to the Package/Publsh SQL tab
--	  gor to the Cutom scripts (on the bottom of the page)
--	  Add this script AFTER [Auto script Schema (and data)]
--

USE [master]
IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'IIS APPPOOL\DefaultAppPool')
BEGIN
    CREATE LOGIN [IIS APPPOOL\DefaultAppPool] 
	FROM WINDOWS
END
GO


USE [master]
IF EXISTS(select * from sys.databases where name='Leet_PcSWinkelenDatabase')
BEGIN
	alter database [Leet_PcSWinkelenDatabase] set single_user with rollback immediate
	DROP DATABASE [Leet_PcSWinkelenDatabase]
END
GO

CREATE DATABASE [Leet_PcSWinkelenDatabase] 
GO

USE [Leet_PcSWinkelenDatabase]	-- RENAME this to the name of the database that you are installing
GO
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
