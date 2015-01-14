﻿/*
Deployment script for DemoDCProjectDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DemoDCProjectDB"
:setvar DefaultFilePrefix "DemoDCProjectDB"
:setvar DefaultDataPath "C:\Users\Steven\AppData\Local\Microsoft\VisualStudio\SSDT"
:setvar DefaultLogPath "C:\Users\Steven\AppData\Local\Microsoft\VisualStudio\SSDT"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[Token].[BillingAccountId] on table [dbo].[Token] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[Token])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping [dbo].[Token].[IX_ChannelTitle]...';


GO
DROP INDEX [IX_ChannelTitle]
    ON [dbo].[Token];


GO
PRINT N'Starting rebuilding table [dbo].[Token]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Token] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [BillingAccountId] INT          NOT NULL,
    [Pec]              VARCHAR (50) NOT NULL,
    [TokenNumber]      VARCHAR (50) NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Token] PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Token])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Token] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Token] ([Id], [Pec], [TokenNumber])
        SELECT   [Id],
                 [Pec],
                 [TokenNumber]
        FROM     [dbo].[Token]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Token] OFF;
    END

DROP TABLE [dbo].[Token];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Token]', N'Token';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Token]', N'PK_Token', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[Token].[IX_BillingAccountId]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BillingAccountId]
    ON [dbo].[Token]([BillingAccountId] ASC);


GO
PRINT N'Altering [dbo].[CreateToken]...';


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE dbo.CreateToken
@BillingAccountId INT,
@Pec varchar(50),
@TokenNumber varchar(50)
AS
	SET NOCOUNT ON

	INSERT	INTO dbo.Token
			(BillingAccountId, Pec, TokenNumber)
	VALUES	(@BillingAccountId, @Pec, @TokenNumber)

	RETURN SCOPE_IDENTITY()
GO
PRINT N'Creating [dbo].[DeleteTokenWithTokenNumber]...';


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTokenWithTokenNumber]
@TokenNumber varchar(50)
AS
	SET NOCOUNT ON

	DELETE 
	FROM	[dbo].[Token]
	WHERE	TokenNumber = @TokenNumber
GO
PRINT N'Update complete.';


GO
